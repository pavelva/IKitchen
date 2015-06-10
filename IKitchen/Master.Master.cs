﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {

                if (Session["firstName"] == null|| Session["lastName"] == null)
                    Response.Redirect("~/loginRegister.aspx");
                

                userName.Text = Session["firstName"] + " " + Session["lastName"];
                login.Style.Add("display", "none");
            }
            else
            {
                userName.Style.Add("display", "none");
                logout.Style.Add("display", "none");
            }


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

            link.Enabled = false;
            link.ForeColor = Color.FromArgb(255, 106, 0);
            link.CssClass += " aActive";
        }
        protected void redirect(object sender, EventArgs e)
        {
            WebControl element = ((WebControl)sender);
            var url = element.ID.Replace("link", "") + ".aspx";
            Response.Redirect(url);
        }
    }
}