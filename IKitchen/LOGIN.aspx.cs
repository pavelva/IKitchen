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
        private Account.AccountSoapClient account;

        protected void Page_Load(object sender, EventArgs e)
        {
            account = new Account.AccountSoapClient();

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

            Account.User u = account.login(email, pass);

            if (u != null)
            {
                Session.Add("firstName", u.firstName);
                Session.Add("lastName", u.lastName);
                Session.Add("userID", u.userID);
                Session.Add("isAdmin", u.isAdmin);

                return u.userID;
            }
            
            return -1;
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if (validRegistration())
            {
                string fName = firstNameInput.Text.ToString();
                string lName = lastNameInput.Text.ToString();
                string userName = emailInput.Text.ToString();
                string pass = regPasswordInput.Text.ToString();
                int question = listOfQestions.SelectedIndex;
                string ans = answer.Text.ToString();
                string email = realEmailInput.Text.ToString();
                string country = CountryDropDown.SelectedItem.Text;

                Account.ArrayOfString categories = new Account.ArrayOfString();

                foreach (ListItem item in (categoriesListBox as ListControl).Items)
                {
                    if (item.Selected)
                        categories.Add(item.Value);
                }

                account.register(fName, lName, userName, pass, question, ans, email, country, categories);

                congratsPopup.Style.Add("display", "block");

                resetRegisterPanel();
            }
        }

        private void resetRegisterPanel()
        {
            firstNameInput.Text = "";
            lastNameInput.Text = "";
            emailInput.Text = "";
            regPasswordInput.Text = "";
            regConfirmPasswordInput.Text = "";
            listOfQestions.SelectedIndex = 0;
            answer.Text = "";
            realEmailInput.Text = "";
            CountryDropDown.SelectedIndex = 0;
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
                        Response.Redirect("~/Login.aspx");
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