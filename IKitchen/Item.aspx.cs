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
    public partial class Item : System.Web.UI.Page
    {
        Products.ProductsSoapClient products;

        protected void Page_Load(object sender, EventArgs e)
        {
            products = new Products.ProductsSoapClient();

            if (Request.QueryString["item"] != null)
            {
                extractItem(int.Parse(Request.QueryString["item"].ToString()));
            }
            else
                Response.Redirect("~/Catalog.aspx");
        }

        private void extractItem(int productID)
        {
            Products.Item responseItem = products.getItem(productID);

            if (responseItem != null)
            {
                app.Text = responseItem.appName;
                type.Text = responseItem.productModel + " " + responseItem.companyName;
                desc.InnerHtml = "<div id='desc'>" + responseItem.desc + "</div>";
                price.Text = responseItem.price.ToString();
                installPrice.Text = responseItem.installPrice.ToString();
                img.ImageUrl = "Images/Big/" + responseItem.productModel + ".jpg";
                currencyPrice.Text = "ש\"ח";
                currencyInstall.Text = "ש\"ח";
                productId.Value = responseItem.productID.ToString();
            }
            else
            {
                item.Style.Add("display", "none");
                error.Style.Add("display", "block");
            }
        }

        public void backToCatalog(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalog.aspx");
        }
    }
}