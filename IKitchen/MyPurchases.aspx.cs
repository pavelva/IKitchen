using System;
using System.Collections.Generic;
using System.Configuration;
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
                Response.Redirect("~/loginRegister.aspx");

            

            int uId = int.Parse(Session["userID"].ToString());

            string sqlUserPurchases = "select purchase_id, purchase_productId, purchase_date, comments, product_model, company_name, product_made, product_desc, app_name, appType_name " +
                                        "from (((purchases Join products on purchase_productId = product_id) Join companys on product_company = company_id) Join applience on product_type = app_id) Join applience_types on product_type2 = appType_id " +
                                        "where purchase_userid = " + uId;
            
            MyPurchasesDataSource.SelectCommand = sqlUserPurchases;
            MyPurchasesDataSource.DataBind();

            MyPurchasesTable.Style.Add("min-width", "100px");
        }
    }
}