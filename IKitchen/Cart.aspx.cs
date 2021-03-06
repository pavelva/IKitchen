﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class Cart : System.Web.UI.Page
    {
        private Store.StoreSoapClient store;

        protected void Page_Load(object sender, EventArgs e)
        {

            store = new Store.StoreSoapClient();

            if (Session["userID"] == null)
                Response.Redirect("~/Login.aspx");

            if (Session["cart"] != null)
            {
                displayCart();
                cartMode();
            }
            else
            {
                emptyMode();
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
                string pId = e.Row.Cells[10].Text;
                int price = int.Parse(e.Row.Cells[5].Text.Split(' ')[0]);
                totalPrice += cart[pId] * price;
                int installPrice = int.Parse(e.Row.Cells[6].Text.Split(' ')[0]);
                DropDownList count = (DropDownList)e.Row.Cells[7].Controls[1];
                int tmp = cart[pId] - 1;
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
            string pId = ((GridViewRow)count.Parent.Parent).Cells[10].Text;

            int addedAmount = int.Parse(count.SelectedItem.Text) - ((Dictionary<string, int>)Session["cart"])[pId];

            if (addedAmount < 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                con.Open();
                string returnToSql = "Update products set product_inventory = product_inventory + " + (-addedAmount) + " Where product_id = " + pId;
                SqlCommand com = new SqlCommand(returnToSql, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                con.Open();
                string checkInventory = "Select product_inventory from products where product_id = " + pId;
                SqlCommand com = new SqlCommand(checkInventory, con);
                SqlDataReader reader = com.ExecuteReader();

                bool hasInInventory = false;
                if (reader.Read())
                {
                    hasInInventory = int.Parse(reader["product_inventory"].ToString()) >= addedAmount;
                }

                if(!hasInInventory)
                {
                    Response.Write("<script>alert('אין מספיק מוצרים במלאי: " + reader["product_inventory"].ToString() + " נותרו במלאי');</script>");
                    count.ClearSelection();
                    count.Items.FindByValue((((Dictionary<string, int>)Session["cart"])[pId]).ToString()).Selected = true;
                    return;
                }

                con.Close();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                con.Open();
                string updateInventory = "Update products Set product_inventory = product_inventory - " + addedAmount + " where product_id = " + pId;
                SqlCommand comUpdate = new SqlCommand(updateInventory, con);
                comUpdate.ExecuteNonQuery();
                con.Close();
            }

            

            ((Dictionary<string, int>)Session["cart"])[pId] = int.Parse(count.SelectedItem.Text);

            totalPrice = 0;
            totalInstall = 0;
            total = 0;

            cartGrid.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            emptyCart(true);
        }

        

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            if(calSale.SelectedDate.Date.Equals(DateTime.MinValue))
            {
                lblError.Visible = true;
                lblError.Text = "יש לבחור תאריך למשלוח";
                return;
            }

            List<Store.CartItem> cartItems = new List<Store.CartItem>();
            
            foreach (string pId in ((Dictionary<string, int>)Session["cart"]).Keys)
            {
                cartItems.Add(new Store.CartItem() { productID = pId, amount = ((Dictionary<string, int>)Session["cart"])[pId] });
            }


            int saleId = store.buy(int.Parse(Session["userID"].ToString()), txtComments.Text, calSale.SelectedDate, cartItems.ToArray());
            emptyCart(false);
            Response.Redirect("MyPurchases.aspx?sale=" + saleId);
        }

        private void cartMode()
        {
            lblEmpty.Visible = false;
            lblError.Visible = false;

            btnBuy.Visible = true;
            btnClear.Visible = true;
            lblComments.Visible = true;
            txtComments.Visible = true;
            calSale.Visible = true;
            lblCal.Visible = true;
        }

        private void emptyMode()
        {
            lblError.Visible = false;
            btnBuy.Visible = false;
            btnClear.Visible = false;
            lblComments.Visible = false;
            txtComments.Visible = false;
            calSale.Visible = false;
            lblCal.Visible = false;
            lblEmpty.Visible = true;
        }

        private void emptyCart(Boolean returnToDb)
        {
            totalPrice = 0;
            totalInstall = 0;
            total = 0;

            Dictionary<string, int> products = (Dictionary<string, int>)Session["cart"];

            string updateInventory = "";

            if (returnToDb)
            {
                foreach (string pId in products.Keys)
                {
                    updateInventory += "Update products Set product_inventory = product_inventory + " + products[pId] + " Where product_id = " + pId + "; ";
                }

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                con.Open();
                SqlCommand com = new SqlCommand(updateInventory, con);
                com.ExecuteNonQuery();
            }
            

            Session.Remove("cart");

            cartQuery.SelectCommand = null;
            cartQuery.DataBind();

            emptyMode();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            string pId = row.Cells[10].Text;

            int amount = ((Dictionary<string, int>)Session["cart"])[pId];

            ((Dictionary<string, int>)Session["cart"]).Remove(pId);

            if (((Dictionary<string, int>)Session["cart"]).Count == 0)
                Session.Remove("cart");


            string updateInventory = "Update products Set product_inventory = product_inventory + " + amount + " Where product_id = " + pId;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand(updateInventory, con);
            com.ExecuteNonQuery();

            cartQuery.SelectCommand = null;
            cartQuery.DataBind();

            if (Session["cart"] != null)
            {
                displayCart();
                cartMode();
            }
            else
            {
                emptyMode();
            }

        }
    }
}