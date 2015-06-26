using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServices.DataTypes;

namespace WebServices
{
    /// <summary>
    /// Summary description for Store
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Store : System.Web.Services.WebService
    {

        [WebMethod]
        public int buy(int userID, string comments, DateTime deliveryDate, List<CartItem> products)
        {
            string sale = "Insert Into sales (sale_userId, sale_date, sale_comments, sale_delivery) " +
                          "Values (@user, @date, @comments, @delDate) " +
                          "SELECT SCOPE_IDENTITY();";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand(sale, con);
            com.Parameters.AddWithValue("@user", userID);
            com.Parameters.AddWithValue("@date", DateTime.Now);
            com.Parameters.AddWithValue("@comments", comments);
            com.Parameters.AddWithValue("@delDate", deliveryDate);

            int saleId = int.Parse(com.ExecuteScalar().ToString());

            string productsSQL = "";
            foreach (CartItem item in products)
            {
                for (int i = 0; i < item.amount; i++)
                {
                    productsSQL += "Insert Into purchases (purchase_saleId, purchase_productId) " +
                                "Values (" + saleId + ", " + item.productID + "); ";
                }
            }

            com = new SqlCommand(productsSQL, con);
            com.ExecuteNonQuery();

            con.Close();

            return saleId;
        }
    }
}
