using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string linkID = "link" + Request.Url.AbsolutePath.Replace("/", "").Replace(".aspx", "");

            var link = ((LinkButton)this.FindControl(linkID));
            link.Enabled = false;
            link.ForeColor = Color.FromArgb(255, 106, 0);
            link.CssClass += " aActive";
            LinkButton userName = (LinkButton)form1.FindControl("userName");
            userName.Text = Request.QueryString["name"].ToString();
        }
        protected void redirect(object sender, EventArgs e)
        {
            WebControl element = ((WebControl)sender);
            var url = element.ID.Replace("link", "") + ".aspx";
            Response.Redirect(url + "?id=" + Session["userID"]);
        }
    }
}