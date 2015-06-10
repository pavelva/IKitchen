using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["item"] != null)
            {
                extractItem();
            }
            else
                Response.Redirect("~/Catalog.aspx");
        }

        private void extractItem()
        {
            string sql = "select product_id, product_model, product_price, product_install_price, product_desc, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where product_id = " + Request.QueryString["item"].ToString();

            sql += " order by app_name";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            sqlCon.Open(); 
            SqlCommand comm = new SqlCommand(sql, sqlCon);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                app.Text = reader["app_name"].ToString();
                type.Text = reader["product_model"].ToString() + " " + reader["company_name"].ToString();
                desc.InnerHtml = "<div id='desc'>" + reader["product_desc"].ToString() + "</div>";
                price.Text = reader["product_price"].ToString();
                installPrice.Text = reader["product_install_price"].ToString();
                img.ImageUrl = "Images/Big/" + reader["product_model"].ToString() + ".jpg";
                currencyPrice.Text = "ש\"ח";
                currencyInstall.Text = "ש\"ח";
                productId.Value = reader["product_id"].ToString();
            }
            else
            {
                item.Style.Add("display", "none");
                error.Style.Add("display", "block");
            }

            sqlCon.Close();
        }

        public void backToCatalog(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalog.aspx");
        }
    }
}