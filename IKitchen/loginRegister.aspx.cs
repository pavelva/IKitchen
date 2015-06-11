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
    public partial class loginRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ((TextBox)form1.FindControl("passwordInput")).Attributes["type"] = "password";
            ((TextBox)form1.FindControl("regPasswordInput")).Attributes["type"] = "password";
            ((TextBox)form1.FindControl("regConfirmPasswordInput")).Attributes["type"] = "password";
            //if (!Page.IsPostBack)
            //{
                if (Request.Cookies["email"] != null && Request.Cookies["pass"] != null)
                {
                    getUserIDFromDB(Request.Cookies["email"].Value.ToString(), Request.Cookies["pass"].Value.ToString());
                    goToPageByUserType();
                }
            //}
        }

        private void goToPageByUserType()
        {
            bool userIsAdmin = bool.Parse(Session["isAdmin"].ToString());
            if(!userIsAdmin)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("Catalog.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            int id = getUserIDFromDB(loginEmailInput.Text.ToString(), passwordInput.Text.ToString());
            if (id != -1)
            {
                HttpCookie userEmail = new HttpCookie("email", loginEmailInput.Text.ToString());
                userEmail.Expires = DateTime.Now.AddDays(1);
                
                HttpCookie userPassword = new HttpCookie("pass", passwordInput.Text.ToString());
                userPassword.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(userEmail);
                Response.Cookies.Add(userPassword);
                goToPageByUserType();
            }
            else
            {
                ((Label)form1.FindControl("errorLbl")).Attributes.Add("style", "display:inline");
            }
        }

        protected int getUserIDFromDB(string email, string pass)
        {
            int id = -1;
            string fName = "";
            string lName = "";
            bool isAdmin = false;
            SqlDataReader sqlData = null; 
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from users where user_email= '" + email + "' AND user_password= '" + pass + "'";
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
                    Session.Add("firstName", fName);
                    Session.Add("lastName", lName);
                    Session.Add("userID", id);
                    Session.Add("isAdmin", isAdmin);
                }
            }
            con.Close();
            return id;
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            //int id = 3;
            string fName = firstNameInput.Text.ToString();
            string lName = lastNameInput.Text.ToString();
            string email = emailInput.Text.ToString();
            string pass = regPasswordInput.Text.ToString();
            int question = listOfQestions.SelectedIndex;
            string ans = answer.Text.ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "INSERT INTO users (user_firstName, user_LastName, user_email, user_password, user_question, user_answer)"+
                            "VALUES ('" + fName + "','" + lName + "','" + email + "','" + pass + "'," + question + ",'" + ans + "')";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
            con.Close();
        }
    
    }
}