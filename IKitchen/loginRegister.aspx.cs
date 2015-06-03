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
        }
    }
}