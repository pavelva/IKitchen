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
    /// Summary description for Account
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class Account : System.Web.Services.WebService
    {
        [WebMethod]
        public User login(string userName, string pass)
        {
            User user = null;
            int id = -1;
            string fName = "";
            string lName = "";
            bool isAdmin = false;
            SqlDataReader sqlData = null;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from users where user_email= '" + userName + "' AND user_password= N'" + pass + "'";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            sqlData = command.ExecuteReader();
            if (sqlData != null)
            {
                if (sqlData.Read())
                {
                    id = int.Parse(sqlData["user_id"].ToString());
                    fName = sqlData["user_firstName"].ToString();
                    lName = sqlData["user_lastName"].ToString();
                    isAdmin = bool.Parse(sqlData["user_isAdmin"].ToString());

                    user = new User(fName, lName, id, isAdmin);
                }
            }
            con.Close();

            return user;
        }

        [WebMethod]
        public int register(string fName, string lName, string userName, string pass, int question, string ans, string email, string country, List<string> categories)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                string sql = "INSERT INTO users (user_firstName, user_LastName, user_email, user_password, user_question, user_answer, user_realEmail, user_country)" +
                                "VALUES (N'" + fName + "',N'" + lName + "','" + userName + "',N'" + pass + "'," + question + ",N'" + ans + "','" + email + "','" + country + "')" +
                                "SELECT SCOPE_IDENTITY();";
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                int id = int.Parse(command.ExecuteScalar().ToString());
                fillFavoritesInDB(id, categories);

                return id;
            }
            catch
            {
                return -1;
            }
            
        }

        private void fillFavoritesInDB(int uid, List<string> categories)
        {
            string sqlInsertFavorites = "";
            foreach (string cat in categories)
            {
                sqlInsertFavorites += "Insert Into favorites (fav_user, fav_app) " +
                                        "Values ('" + uid + "','" + cat + "');";
            }

            if (sqlInsertFavorites != "")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                con.Open();
                SqlCommand com = new SqlCommand(sqlInsertFavorites, con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }
    }

}
