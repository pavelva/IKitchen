using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Catalog : System.Web.UI.Page
    {
        int a = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlCatalog = "select product_id, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                " order by company_name";

            //FillCatalog(sqlCatalog);
            //if(!IsPostBack)
            FillProductTypes();

            if (Session["sql"] != null)
                FillCatalog(Session["sql"].ToString());
        }

        private void FillCatalog(string sql)
        {
            CatalogDataSource.SelectCommand = sql;
            CatalogDataSource.DataBind();
            
        }

        private void FillProductTypes()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from applience";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable comp = new DataTable();
            adapter.Fill(comp);

            foreach (DataRow r in comp.Rows)
            {
                int value = int.Parse(r[0].ToString());
                string text = r[1].ToString();

                CheckBox c = new CheckBox();
                c.ID = "chk_" + value;
                c.CssClass = "catalogChk";
                c.Text = text;
                c.AutoPostBack = true;
                c.CheckedChanged += new EventHandler(Product_CheckedChanged);
                itemTypePicker.Controls.Add(c);
            }

        }

        protected void Product_CheckedChanged(object sender, EventArgs e)
        {
            List<string> products = new List<string>();

            foreach (Control c in itemTypePicker.Controls)
            {
                if (c.GetType().Equals(typeof(CheckBox)))
                {
                    if(((CheckBox)c).Checked)
                    {
                        //string id = c.ID.Substring(c.ID.IndexOf("chk_") + 1);
                        string name = ((CheckBox)c).Text;
                        products.Add(name);
                    }
                        
                }
            }

            string sql = "select product_id, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where app_name in (N'" + string.Join("',N'", products) + "') " + 
                                " order by company_name";
            Session.Add("sql", sql);
            a++;
            FillCatalog(sql);            
        } 
    }
}