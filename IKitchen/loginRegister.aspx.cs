using System;
using System.Collections.Generic;
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
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["userName"] != null)
                    Response.Redirect("Catalog.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            HttpCookie userName = new HttpCookie("userName", loginEmailInput.Text.ToString());
            userName.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Add(userName);

            //redirect to welcome  
            Response.Redirect("Catalog.aspx"); 
        }
    }
}