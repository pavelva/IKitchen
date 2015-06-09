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
                string sqlUserPurchases = "select purchase_userid, product_type " +
                                           "from purchases join products on purchase_productId = product_id " +
                                           "where purchase_userid = " + id;

                SqlCommand command = new SqlCommand(sqlUserPurchases, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable tblPurchases = new DataTable();
                adapter.Fill(tblPurchases);

                if (tblPurchases.Rows.Count == 0)
                    FillDefault();
                else
                    FillUserReccomendations(id, tblPurchases);

                
            }
            else {
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

            string sql = "select product_id, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where app_id in ('" + string.Join("','", app_ids) + "')" +
                                " order by app_id";
            
            FillCatalog(sql);
        }

        private void FillDefault()
        {
            string sql = "select product_id, product_create, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                " order by company_name";

            FillCatalog(sql, true);
        }

        private void FillCatalog(string sql, bool date = false)
        {
            DefaultDataSource.SelectCommand = sql;
            if (date)
            {
                Parameter param = new Parameter("date");
                param.DbType = DbType.DateTime;
                param.DefaultValue = DateTime.Now.AddDays(-7).ToString();
                DefaultDataSource.FilterParameters.Add(param);
                DefaultDataSource.FilterExpression = "product_create > #{0}#";
            }
            
            DefaultDataSource.DataBind();

        }
    }
}