using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
                Response.Redirect("~/loginRegister.aspx");

            if (Session["cart"] != null)
            {
                displayCart();
            }
        }

        private void displayCart()
        {
            List<string> cart = ((Dictionary<string, int>)Session["cart"]).Keys.ToList();
            if (cart.Count == 0)
                return;

            string sqlSale = "select * " +
                             "from ((products " +
                             "join applience on app_id = product_type) join applience_types on appType_id = product_type2) " +
                             "join companys on company_id = product_company " +
                             "Where product_id in ('" + string.Join("','", cart) + "')";

            cartQuery.SelectCommand = sqlSale;

            cartQuery.DataBind();
        }

        int totalPrice = 0;
        int totalInstall = 0;
        int total = 0;
        protected void cartGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Session["cart"] == null)
            {
                return;
            }

            Dictionary<string, int> cart = (Dictionary<string, int>)Session["cart"];

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string pId = e.Row.Cells[9].Text;
                int price = int.Parse(e.Row.Cells[5].Text.Split(' ')[0]);
                totalPrice += cart[pId] * price;
                int installPrice = int.Parse(e.Row.Cells[6].Text.Split(' ')[0]);
                DropDownList count = (DropDownList)e.Row.Cells[7].Controls[1];
                count.SelectedIndex = cart[pId] - 1;
                totalInstall += cart[pId]*installPrice;
                total += cart[pId];
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "סה\"כ";
                e.Row.Cells[5].Text = totalPrice.ToString() + " ש\"ח";
                e.Row.Cells[6].Text = totalInstall.ToString() + " ש\"ח";
                e.Row.Cells[7].Text = total.ToString() + " מוצרים";

            }

        }


        protected void amount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList count = (DropDownList)sender;
            string pId = ((GridViewRow)count.Parent.Parent).Cells[9].Text;
            ((Dictionary<string, int>)Session["cart"])[pId] = int.Parse(count.SelectedItem.Text);

            totalPrice = 0;
            totalInstall = 0;
            total = 0;

            cartGrid.DataBind();
        }

        protected void btnClead_Click(object sender, EventArgs e)
        {
            totalPrice = 0;
            totalInstall = 0;
            total = 0;

            Session.Remove("cart");

            cartQuery.SelectCommand = null;
            cartQuery.DataBind();
        }
    }
}