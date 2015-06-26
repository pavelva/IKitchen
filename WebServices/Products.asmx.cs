using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServices.DataTypes;

namespace WebServices
{
    /// <summary>
    /// Summary description for Products
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Products : System.Web.Services.WebService
    {

        [WebMethod]
        public Item getItem(int productId)
        {
            Item item = null;
            string sql = "select product_id, product_model, product_price, product_install_price, product_desc, app_name, appType_name, company_name, product_inventory, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where product_id = " + productId + " " +
                                "order by app_name";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            sqlCon.Open();
            SqlCommand comm = new SqlCommand(sql, sqlCon);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                string appName = reader["app_name"].ToString();
                string productModel = reader["product_model"].ToString();
                string companyName = reader["company_name"].ToString();
                string desc = reader["product_desc"].ToString();
                int price = int.Parse(reader["product_price"].ToString());
                int installPrice = int.Parse(reader["product_install_price"].ToString());
                string imgUrl = "Images/Big/" + reader["product_model"].ToString() + ".jpg";
                int productID = int.Parse(reader["product_id"].ToString());
                int inventory = int.Parse(reader["product_inventory"].ToString());
                bool isExist = bool.Parse(reader["product_exist"].ToString());

                item = new Item(productID, appName, productModel, companyName, desc, price, installPrice, imgUrl, inventory, isExist);
            }

            sqlCon.Close();

            return item;
        }

        [WebMethod]
        public List<Item> getItems(List<string> apps, List<string> companys)
        {
            string sql = "select product_id, product_model, product_price, product_install_price, product_desc, app_name, appType_name, company_name, product_inventory, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id ";



            if (apps.Count > 0 || companys.Count > 0)
            {
                sql += "Where ";
                sql += (apps.Count > 0 ? "app_name in (N'" + string.Join("',N'", apps) + "') " + (companys.Count > 0 ? " AND " : "") : "");
                sql += (companys.Count > 0 ? "company_name in (N'" + string.Join("',N'", companys) + "') " : "");
            }

            sql += " order by app_name";

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            sqlCon.Open();
            SqlCommand comm = new SqlCommand(sql, sqlCon);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);

            DataTable tbl = new DataTable();
            adapter.Fill(tbl);

            List<Item> items = new List<Item>();

            foreach (DataRow r in tbl.Rows)
            {
                if (r[9].ToString().Equals("True"))
                {
                    string appName = r[5].ToString();
                    string productModel = r[1].ToString();
                    string companyName = r[7].ToString();
                    string desc = r[4].ToString();
                    int price = int.Parse(r[2].ToString());
                    int installPrice = int.Parse(r[3].ToString());
                    string imgUrl = "Images/Big/" + r[1].ToString() + ".jpg";
                    int productID = int.Parse(r[0].ToString());
                    int inventory = int.Parse(r[8].ToString());
                    bool isExist = bool.Parse(r[9].ToString());

                    items.Add(new Item(productID, appName, productModel, companyName, desc, price, installPrice, imgUrl, inventory, isExist));
                }
            }

            return items;
        }
    }
}
