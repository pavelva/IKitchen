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
    public partial class manageUsers : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sale"] != null)
            {
                displaySale(int.Parse(Request.QueryString["sale"].ToString()));
            }
            else if (Request.QueryString["userID"] != null)
            {
                fillSalesTable();
            }
            else
            {
                string selectUsers = "select * " +
                                 "from users";
                usersDataSource.SelectCommand = selectUsers;
                usersDataSource.DataBind();
                backBtn.Style.Add("display", "none");
            }
            
        }

        private void fillSalesTable()
        {
            int uid = int.Parse(Request.QueryString["userID"].ToString());
            string sqlUserPurchases = "select *" +
                                        "from sales " +
                                        "where sale_userid = " + uid;

            UserPurchasesDataSource.SelectCommand = sqlUserPurchases;
            UserPurchasesDataSource.DataBind();
        }

        private void displaySale(int saleId)
        {
            string sqlSale = "select * " +
                             "from ((((sales join purchases on sale_id = purchase_saleId) join products on product_id = purchase_productId) " +
                             "join applience on app_id = product_type) join applience_types on appType_id = product_type2) " +
                             "join companys on company_id = product_company " +
                             "Where sale_id = " + saleId;

            UserSalesQuery.SelectCommand = sqlSale;

            UserSalesQuery.DataBind();
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

        protected void backBtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["sale"] != null && Request.QueryString["userID"] != null)
                Response.Redirect("~/manageUsers.aspx?userID=" + Request.QueryString["userID"]);
            else if (Request.QueryString["userID"] != null) 
                Response.Redirect("~/manageUsers.aspx");
            else
                Response.Redirect("~/Default.aspx");
        }

        protected void changeUserType(object sender, EventArgs e)
        {
            try
            {
                var btn = (Button)sender;
                bool type = (btn.Text.ToString() == "החלף למנהל")?true:false;
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                connection.Open();
                string update = "Update users Set user_isAdmin = '" + type + "' Where user_id = " + btn.CommandArgument.ToString() ;

                SqlCommand command = new SqlCommand(update, connection);
                command.ExecuteNonQuery();
                Response.Redirect("~/ManageUsers.aspx");
            }
            catch
            {
                //StatusMessage.Text = "Noget er galt, prøv lidt senere";
            }
        }
    }
}