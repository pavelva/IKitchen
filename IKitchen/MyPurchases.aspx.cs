using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class MyPurchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
                Response.Redirect("~/LOGIN.aspx");

            if (Request.QueryString["sale"] == null)
            {
                fillSalesTable();
                saleWrapper.Visible = false;
            }
            else
            {
                displaySale(int.Parse(Request.QueryString["sale"].ToString()));
            }

        }

        private void displaySale(int saleId)
        {
            string sqlSale = "select * "+
                             "from ((((sales join purchases on sale_id = purchase_saleId) join products on product_id = purchase_productId) "+
                             "join applience on app_id = product_type) join applience_types on appType_id = product_type2) " + 
                             "join companys on company_id = product_company " +
                             "Where sale_id = " + saleId;

            SalesQuery.SelectCommand = sqlSale;
            
            SalesQuery.DataBind();
            saleHeader.DataSource = new List<int>() { saleId };
            saleHeader.DataBind();
        }

        private void fillSalesTable()
        {
            int uId = int.Parse(Session["userID"].ToString());
            string sqlUserPurchases = "select *" +
                                        "from sales " +
                                        "where sale_userid = " + uId;

            MyPurchasesDataSource.SelectCommand = sqlUserPurchases;
            MyPurchasesDataSource.DataBind();
        }

        protected void backToMyPurcases_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyPurchases.aspx");
        }
        int totalPrice = 0;
        int totalInstall = 0;
        int total = 0;
        protected void saleGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int price = int.Parse(e.Row.Cells[7].Text.Split(' ')[0]);
                totalPrice += price;
                int installPrice = int.Parse(e.Row.Cells[8].Text.Split(' ')[0]);
                totalInstall += installPrice;
                total++;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "סה\"כ";
                e.Row.Cells[7].Text = totalPrice.ToString() + " ש\"ח";
                e.Row.Cells[8].Text = totalInstall.ToString() + " ש\"ח";
                e.Row.Cells[9].Text = total.ToString() + " מוצרים";

            }
            
        }
    }
};