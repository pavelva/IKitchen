using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private Convertor.ConvertorSoapClient convertor;
        protected void Page_Load(object sender, EventArgs e)
        {
            convertor = new Convertor.ConvertorSoapClient();

            string userCss = ".user{display:none}";
            string adminCss = ".admin{display:none}";
            string anonymousCss = "";

            if (Request.Cookies["email"] != null && Request.Cookies["pass"] != null && Session["userID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            else if (Session["userID"] != null)
            {

                if (bool.Parse(Session["isAdmin"].ToString()))
                {
                    linkCatalog.Text = "ניהול מוצרים";
                    adminCss = "";
                    anonymousCss = ".anonymous{display:none !important}";
                }
                else
                    userCss = "";

                if (Session["firstName"] == null|| Session["lastName"] == null)
                    Response.Redirect("~/Login.aspx");
                

                userName.Text = Session["firstName"] + " " + Session["lastName"];
                login.Style.Add("display", "none");
            }
            else
            {
                userName.Style.Add("display", "none");
                logout.Style.Add("display", "none");
                login.Style.Add("display", "block");
            }

            Page.Header.Controls.Add(new LiteralControl("<style type='text/css'>" + userCss + "\n" + adminCss +"\n" + anonymousCss +  "</style>"));

            string linkID = "link" + Request.Url.AbsolutePath.Replace("/", "").Replace(".aspx", "");
            LinkButton link;

            if (linkID == "linkItem")
            {
                link = (LinkButton)(this.FindControl("linkCatalog"));
            }
            else
            {
                link = ((LinkButton)this.FindControl(linkID));
                
            }

            if (link != null)
            {
                link.Enabled = false;
                link.ForeColor = Color.FromArgb(255, 106, 0);
                link.CssClass += " aActive";
                if (link.ID == "linkRest")
                {
                    link.Style.Add("opacity", "0.5");
                }
            }
        }
        protected void redirect(object sender, EventArgs e)
        {
            WebControl element = ((WebControl)sender);
            var url = element.ID.Replace("link", "") + ".aspx";
            Response.Redirect(url);
        }
        protected void disconect(object sender, EventArgs e)
        
        {
            if (Request.Cookies["pass"] != null && Request.Cookies["email"] != null)
            {
                Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        protected void btnConver_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            txtConvert.Style.Add("color", "black");
            txtConvert.Style.Add("font-weight", "normal");
            string from = currencyFrom.SelectedValue;
            string to = currencyTo.SelectedValue;
            double amount;

            try
            {
                amount = double.Parse(txtConvert.Text);
            }
            catch
            {
                txtConvert.Style.Add("color", "red");
                txtConvert.Style.Add("font-weight", "bold");
                return;
            }

            txtResult.Text = convertor.convert(from, to, amount).ToString("f2");
        }

        //private double Convert(string from, string to, double amount)
        //{
        //    if (from == "shekel" && to != from)
        //    {
        //        return amount / 3.85;
        //    }
        //    else if (from == "dollar" && to != from)
        //    {
        //        return amount * 3.85;
        //    }
        //    else
        //        return amount;
        //}
    }
}