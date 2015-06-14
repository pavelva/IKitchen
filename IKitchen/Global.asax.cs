using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace IKitchen
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                Dictionary<string, int> products = (Dictionary<string, int>)Session["cart"];

                string updateInventory = "";
                foreach (string pId in products.Keys)
                {
                    updateInventory += "Update products Set product_inventory = product_inventory + " + products[pId] + " Where product_id = " + pId + "; ";
                }

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                con.Open();
                SqlCommand com = new SqlCommand(updateInventory, con);
                com.ExecuteNonQuery();
            }
            
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}