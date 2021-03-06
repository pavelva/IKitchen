﻿using System;
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
                                "Where app_id in ('" + string.Join("','", app_ids.Distinct()) + "') AND product_exist = 'true' " +
                                " order by product_create DESC";
            
            FillCatalog(sql, buysProductsDataSource);

            sql = "select top 12 product_id, product_create, product_model, product_price, product_install_price, product_desc, product_company, app_id, app_name, appType_name, company_name, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "Where app_id in (select app_id " +
                                                    "from applience " +
                                                    "where app_id in (select fav_app from favorites where fav_user = " + id +")) " +
                                       "AND product_exist = 'true' " +
                                " order by product_create DESC";

            FillCatalog(sql, categorysProductsDataSource);
        }

        private void FillDefault()
        {
            string sql = "select top 12 product_id, product_create, product_model, product_price, product_install_price, product_desc, product_company, app_name, appType_name, company_name, product_exist " +
                                "from ((products Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id) Join companys on product_company = company_id " +
                                "where product_create >= dateadd(week, -1, GETDATE()) AND product_exist = 1 " +
                                "order by company_name";

            FillCatalog(sql, DefaultDataSource);
        }

        private void FillCatalog(string sql, SqlDataSource dataSource)
        {
            dataSource.SelectCommand = sql;
            dataSource.DataBind();
        }
    }
}