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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                int id = int.Parse(Session["userID"].ToString());


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);

                string sqlUserPurchases = "select sale_userId, product_type " +
                                           "from (sales join purchases on sale_Id = purchase_saleId) join products on purchase_productId = product_id " +
                                           "where sale_userId = " + id;

                SqlCommand command = new SqlCommand(sqlUserPurchases, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable tblPurchases = new DataTable();
                adapter.Fill(tblPurchases);

                FillDefault();
                FillUserReccomendations(id, tblPurchases);

                
            }
            else {
                buys.Style.Add("display", "none");
                categorys.Style.Add("display", "none");
                defaultList.Style.Add("display", "block");

                FillDefault();
            }
        }

        private void FillUserReccomendations(int id, DataTable tbl)
        {
            List<string> app_ids = new List<string>();

            foreach (DataRow r in tbl.Rows)
            {
                app_ids.Add(r[1].ToString());
            }

            string sql = "select top 12 product_id, product_create, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where app_id in ('" + string.Join("','", app_ids.Distinct()) + "') " +
                                " order by app_id";
            
            FillCatalog(sql, buysProductsDataSource);

            sql = "select top 12 product_id, product_create, product_model, product_price, product_install_price, product_desc, product_company, app_id, app_name, appType_name, company_name, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where app_id in (select app_id " +
                                                    "from applience " +
                                                    "where app_id in (select fav_app from favorites where fav_user = " + id +")) " +
                                " order by app_id";

            FillCatalog(sql, categorysProductsDataSource);
        }

        private void FillDefault()
        {
            string sql = "select top 12 product_id, product_create, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "order by company_name";

            FillCatalog(sql, DefaultDataSource, true);
        }

        private void FillCatalog(string sql, SqlDataSource dataSource , bool date = false)
        {
            dataSource.SelectCommand = sql;
            if (date)
            {
                Parameter param = new Parameter("date");
                param.DbType = DbType.DateTime;
                param.DefaultValue = DateTime.Now.AddDays(-7).ToString();
                dataSource.FilterParameters.Add(param);
                //dataSource.FilterExpression = "product_create > #{0}#";

                Parameter param_exist = new Parameter("create");
                param_exist.DbType = DbType.Boolean;
                param_exist.DefaultValue = true.ToString();
                dataSource.FilterParameters.Add(param_exist);
                dataSource.FilterExpression = "product_create > #{0}# AND product_exist = {1}";
            }
            else
            {
                Parameter param_exist = new Parameter("create");
                param_exist.DbType = DbType.Boolean;
                param_exist.DefaultValue = true.ToString();
                dataSource.FilterParameters.Add(param_exist);
                dataSource.FilterExpression = "product_exist = {0}";
            }

            

            dataSource.DataBind();
        }
    }
}