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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["func"] != null)
            {
                switch (Request.QueryString["func"]){
                    case "getItems":
                        getItems();
                        break;
                    case "addToCart":
                        if (Session["userID"] == null)
                        {
                            Response.Redirect("loginRedister");
                            break;
                        }
                        if ( Request.QueryString["pID"] != null)
                        {
                            if(Session["cart"] == null)
                                Session["cart"] = new List<string>();

                            ((List<string>)Session["cart"]).Add(Request.QueryString["pID"].ToString());
                        }
                        else
                            Response.Status = 400 + "";

                        break;
                    default:
                        Response.Status = 400 + "";
                        break;
                        
                }



                Response.End();
                return;
            }

            FillProductTypes();
            fillCompanys();
            if (Session["sql"] != null)
                FillCatalog(Session["sql"].ToString());
        }

        private void getItems()
        {
            List<string> apps;
            List<string> companys;

            if (Request.QueryString["apps"] != null)
            {
                apps = arrayStringToList("apps");
            }
            else
            {
                apps = new List<string>();
            }

            if (Request.QueryString["companys"] != null)
            {
                companys = arrayStringToList("companys");
            }
            else
            {
                companys = new List<string>();
            }

            List<string> items = extractItems(apps, companys);

            Response.Write(string.Join("\n", items));
        }

        private List<string> arrayStringToList(string id)
        {
            return Request.QueryString[id].ToString().Replace("[", "").Replace("]", "").Split(',').ToList();;
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
                c.CssClass = "catalogChk app";
                c.Text = text;
                itemTypePicker.Controls.Add(c);
                
            }
            con.Close();
        }

        private void fillCompanys()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from companys";
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
                c.CssClass = "catalogChk company";
                c.Text = text;
                CompanyPIcker.Controls.Add(c);

            }
            con.Close();
        }

        public static List<string> extractItems(List<string> apps, List<string> companys){

            string sql = "select product_id, product_model, product_price, product_install_price, product_desc, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id ";
            
                                

            if(apps.Count > 0 || companys.Count > 0)
            {
                sql +="Where " ;
                sql += (apps.Count >0 ? "app_name in (N'" + string.Join("',N'", apps) + "') " + (companys.Count > 0? " AND " : ""): "");
                sql += (companys.Count > 0? "company_name in (N'" + string.Join("',N'", companys) + "') " : "");
            }

            sql+=" order by app_name";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            sqlCon.Open();
            SqlCommand comm = new SqlCommand(sql, sqlCon);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);

            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            List<string> items = new List<string>();
            
            foreach(DataRow r in tbl.Rows)
            {
                string item = "<div class='catalogItem'> " + 
                "<h3>"+
                    "<span class='productType' >" + r[5].ToString() + "</span><br /> " +
                    "<span class='productModel' >" +  r[1].ToString() + "</span> " +
                    "<span class='productCompany' >" + r[7].ToString() + "</span> "+
                "</h3>"+
                "<span class='productImg' > <img src='Images/Big/" + r[1].ToString() + ".jpg' /></span> " +
                "<input type='button' value='הוסף לעגלה' class='btnProduct'/> " + 
                "<span class='productId' style='display:none'>" + r[0].ToString() + "</span>" +
                "</div>";

                items.Add(item);
            }

            return items;
        }
    }
}