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
    public partial class loginRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            passwordInput.Attributes["type"] = "password";
            regPasswordInput.Attributes["type"] = "password";
            regConfirmPasswordInput.Attributes["type"] = "password";
            newPassInput.Attributes["type"] = "password";
            if (!Page.IsPostBack)
            {
                addCategoriesToListBox();
                LoadCountriesToDropdownList();
            }
            if (Request.Cookies["email"] != null && Request.Cookies["pass"] != null)
            {
                if (getUserIDFromDB(Request.Cookies["email"].Value.ToString(), Request.Cookies["pass"].Value.ToString()) == -1)
                {
                    Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                }
                else
                    goToPageByUserType();
            }
        }

        private void LoadCountriesToDropdownList()
        {
            try
            {
                DataSet dsDept = new DataSet();
                dsDept.ReadXml(Server.MapPath("countries.xml"));
                CountryDropDown.DataSource = dsDept;
                CountryDropDown.DataTextField = "Name";
                CountryDropDown.DataValueField = "ID";
                CountryDropDown.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void addCategoriesToListBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                string sql = "select * from applience";
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                categoriesListBox.DataSource = dataTable;
                categoriesListBox.DataTextField = "app_name";
                categoriesListBox.DataValueField = "app_id";
                categoriesListBox.DataBind();
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error occured: " + ex.Message.ToString());
            }
        }
    
        private void goToPageByUserType()
        {
            if (Session["isAdmin"] != null)
            {
                bool userIsAdmin = bool.Parse(Session["isAdmin"].ToString());
                if (!userIsAdmin)
                    Response.Redirect("Default.aspx");
                else
                    Response.Redirect("Catalog.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (UserNameRequiredFieldValidator.IsValid && PasswordRequiredFieldValidator.IsValid)
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
                    errorLbl.Attributes.Add("style", "display:inline");
                }
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
            string sql = "select * from users where user_email= '" + email + "' AND user_password= N'" + pass + "'";
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
            if (validRegistration())
            {
                try
                {
                    string fName = firstNameInput.Text.ToString();
                    string lName = lastNameInput.Text.ToString();
                    string userName = emailInput.Text.ToString();
                    string pass = regPasswordInput.Text.ToString();
                    int question = listOfQestions.SelectedIndex;
                    string ans = answer.Text.ToString();
                    string email = realEmailInput.Text.ToString();
                    string country = CountryDropDown.SelectedItem.Text;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                    string sql = "INSERT INTO users (user_firstName, user_LastName, user_email, user_password, user_question, user_answer, user_realEmail, user_country)" +
                                    "VALUES (N'" + fName + "',N'" + lName + "','" + userName + "',N'" + pass + "'," + question + ",N'" + ans + "','" + email + "','" + country + "')" +
                                    "SELECT SCOPE_IDENTITY();";
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    string id = command.ExecuteScalar().ToString();
                    fillFavoritesInDB(id);
                    
                    congratsPopup.Style.Add("display", "block");

                    firstNameInput.Text = "";
                    lastNameInput.Text = "";
                    emailInput.Text = "";
                    regPasswordInput.Text = "";
                    regConfirmPasswordInput.Text = "";
                    listOfQestions.SelectedIndex = 0;
                    answer.Text = "";
                    realEmailInput.Text = "";
                    CountryDropDown.SelectedIndex = 0;
                    con.Close();
                }
                catch{
                    
                }
                
            }
        }

        protected void closeCongratsPopup(object sender, EventArgs e)
        {
            congratsPopup.Style.Add("display", "none");
        }

        private bool validRegistration()
        {
            return FirstNameRequiredFieldValidator.IsValid && LastNameRequiredFieldValidator.IsValid && RegEmailRequiredFieldValidator.IsValid
                && emailRegularExpressionValidator.IsValid && RegPasswordRequiredFieldValidator.IsValid && PasswordRegularExpressionValidator.IsValid
                && RegConfirmPasswordRequiredFieldValidator.IsValid && RegConfirmCompareValidator.IsValid && AnswerRequiredFieldValidator.IsValid
                && RealEmailRequiredFieldValidator.IsValid && RealEmailRegexValidator.IsValid;
        }

        private void fillFavoritesInDB(string uid)
        {
            string sqlInsertFavorites = "";
            foreach (ListItem item in (categoriesListBox as ListControl).Items)
            {
                if (item.Selected)
                {
                    sqlInsertFavorites += "Insert Into favorites (fav_user, fav_app) " +
                                            "Values ('" + uid + "','" + item.Value + "');";
                }
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

        protected void ForgatPAssDetails_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlData = null;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from users where user_email= '" + emailForgotPass.Text + "' AND user_question= '" + forgotListOfQestions.SelectedValue.ToString() +
                "' AND user_answer = N'" + answerForgatPass.Text + "'";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            sqlData = command.ExecuteReader();
            if (sqlData != null)
            {
                var btn = (Button)sender;
                if(btn.Text.ToString() == "סיסמא חדשה"){
                    if (sqlData.Read())
                    {
                        Session["userForgotId"] = sqlData["user_id"].ToString();
                        newPasswordPopup.Style.Add("display", "block");
                        forgotPassPopup.Style.Add("display", "none");
                    }
                    else
                    {
                        forgotPassPopup.Style.Add("display", "block");
                        forgotPassErrorlabel.Text = "הפרטים אינם נכונים";
                    }
                }
                else if (btn.Text.ToString() == "אחזור סיסמא")
                {
                    if (sqlData.Read())
                    {
                        forgotPassPopup.Style.Add("display", "block");
                        forgotPassErrorlabel.Text = "הסיסמא שלך היא : " + sqlData["user_password"].ToString();
                    }
                    else
                    {
                        forgotPassPopup.Style.Add("display", "block");
                        forgotPassErrorlabel.Text = "הפרטים אינם נכונים";
                    }
                    
                }
            }
            else
            {
                forgotPassPopup.Style.Add("display", "block");
                forgotPassErrorlabel.Text = "שגיאה במערכת";
            }
        }

        protected void sendNewPass_Click(object sender, EventArgs e)
        {
            if (Session["userForgotId"] != null)
            {
                forgotPassErrorlabel.Text = "";
                forgotListOfQestions.SelectedIndex = 0;
                emailForgotPass.Text = "";
                answerForgatPass.Text = "";
                forgotPassPopup.Style.Add("display", "none");
                if (newPassInput.Text != "")
                {
                    newPassError.Text = "";
                    if (ForgotPasswordRegularExpressionValidator.IsValid)
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                        string sql = "Update users Set user_password = N'" + newPassInput.Text + "' Where user_id = " + Session["userForgotId"];
                        con.Open();
                        SqlCommand command = new SqlCommand(sql, con);
                        command.ExecuteNonQuery();
                        Session.Remove("userForgotId");
                        con.Close();
                        newPasswordPopup.Style.Add("display", "none");
                        Response.Redirect("~/LOGIN.aspx");
                    }
                }
                else
                {
                    newPassError.Text = "סיסמא לא יכולה להיות ריקה";
                }
            }
        }
    }
}