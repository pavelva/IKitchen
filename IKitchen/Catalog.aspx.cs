
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
    public partial class Catalog : System.Web.UI.Page
    {
        public Products.ProductsSoapClient productsWS;

        protected void Page_Load(object sender, EventArgs e)
        {

            productsWS = new Products.ProductsSoapClient();

            if(Request.QueryString["func"] != null)
            {
                switch (Request.QueryString["func"])
                {
                    case "getItems":
                        if (Session["addItem"] == null && Session["editItem"] == null)
                        {
                            getItems();
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "addToCart":
                        if (Session["userID"] == null)
                        {
                            Response.Redirect("loginRedister");
                            break;
                        }
                        if (Request.QueryString["pID"] != null)
                        {
                            string pId = Request.QueryString["pID"].ToString().Replace(" ", "");

                            if (!isInStock(pId))
                            {
                                Response.Status = "410 Gone";
                                break;
                            }

                            if (Session["cart"] == null)
                                Session.Add("cart", new Dictionary<string, int>());

                            if (!((Dictionary<string, int>)Session["cart"]).ContainsKey(pId))
                                ((Dictionary<string, int>)Session["cart"]).Add(pId, 1);
                            else
                            {
                                if (((Dictionary<string, int>)Session["cart"])[pId] == 9)
                                {
                                    Response.Status = "406 Not Acceptable";
                                }
                                else
                                {
                                    ((Dictionary<string, int>)Session["cart"])[pId]++;
                                }

                            }
                            string products = "Update products Set product_inventory = product_inventory - 1 where product_id = " + pId;
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                            con.Open();
                            SqlCommand com = new SqlCommand(products, con);
                            com.ExecuteNonQuery();
                        }
                        else
                            Response.Status = "400 Bad Request";

                        break;
                    default:
                        Response.Status = "400 Bad Request";
                        break;

                }

                Response.End();
                return;
            }

            addNewItemPopUp.Style.Add("display", "none");

            FillProductTypes();
            fillCompanys();

            if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString()))
            {
                CatalogHeader.InnerText = "ניהול מוצרים";
                newItem.Style.Add("display", "block");
            }

            if (Request.QueryString["updateId"] != null)
            {
                OpenUpdatePopup(int.Parse(Request.QueryString["updateId"].ToString()));
            }
            
            if (Request.QueryString["removeId"] != null)
            {
                removeItem(Request.QueryString["removeId"].ToString());
            }
        }

        private bool isInStock(string pId)
        {
            string sqlStock = "Select product_inventory " +
                              "From products " +
                              "Where product_id = " + pId;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            con.Open();
            SqlCommand commande = new SqlCommand(sqlStock, con);
            SqlDataReader reader = commande.ExecuteReader();

            bool ans = false;

            if (reader.Read())
            {
                ans = int.Parse(reader["product_inventory"].ToString()) > 0;
            }

            con.Close();
            return ans;
        }

        private void getItems()
        {
            List<string> apps;
            List<string> companys;

            if (Request.QueryString["apps"] != null)
            {
                apps = arrayStringToList("apps");
            }
            else
            {
                apps = new List<string>();
            }

            if (Request.QueryString["companys"] != null)
            {
                companys = arrayStringToList("companys");
            }
            else
            {
                companys = new List<string>();
            }

            List<string> items = extractItems(apps, companys);

            Response.Write(string.Join("\n", items));
        }

        private List<string> arrayStringToList(string id)
        {
            return Request.QueryString[id].ToString().Replace("[", "").Replace("]", "").Split(',').ToList(); ;
        }

        private void FillCatalog(string sql)
        {
            CatalogDataSource.SelectCommand = sql;
            CatalogDataSource.DataBind();

        }

        private void FillProductTypes()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from applience";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable comp = new DataTable();
            adapter.Fill(comp);

            foreach (DataRow r in comp.Rows)
            {
                int value = int.Parse(r[0].ToString());
                string text = r[1].ToString();

                CheckBox c = new CheckBox();
                c.CssClass = "catalogChk app";
                c.Text = text;
                itemTypePicker.Controls.Add(c);

            }
            con.Close();
        }

        private void fillCompanys()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            string sql = "select * from companys";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable comp = new DataTable();
            adapter.Fill(comp);

            foreach (DataRow r in comp.Rows)
            {
                int value = int.Parse(r[0].ToString());
                string text = r[1].ToString();

                CheckBox c = new CheckBox();
                c.CssClass = "catalogChk company";
                c.Text = text;
                CompanyPIcker.Controls.Add(c);

            }
            con.Close();
        }

        public List<string> extractItems(List<string> apps, List<string> companys)
        {
            List<string> itemsHtml = new List<string>();
            Products.ArrayOfString requestApps = new Products.ArrayOfString();
            Products.ArrayOfString requestCompanys = new Products.ArrayOfString();

            requestApps.AddRange(apps);
            requestCompanys.AddRange(companys);

            List<Products.Item> items = productsWS.getItems(requestApps, requestCompanys).ToList();

            foreach (Products.Item item in items)
            {
                if (item.isExist)
                {
                    string itemHtml = "<div class='catalogItem'> " +
                        "<h3>" +
                        "<span class='productType' >" + item.appName + "</span><br /> " +
                            "<span class='productModel' >" + item.productModel + "</span> " +
                            "<span class='productCompany' >" + item.companyName + "</span> " +
                        "</h3>" +
                    "<span class='productImg' > <img src='" + item.imgURL + "' /></span> " +
                    addButtons(item.inventory, item.productID.ToString()) +
                    "<span class='productId' style='display:none'>" + item.productID + "</span>" +
                    "</div>";

                    itemsHtml.Add(itemHtml);
                }
            }

            return itemsHtml;
        }

        private string addButtons(int quantity, string pId)
        {
            if (Session["isAdmin"] != null)
            {
                string txtColor = (quantity > 3) ? "black" : "red";
                bool admin = bool.Parse(Session["isAdmin"].ToString());
                if (!admin)
                    return "<input type='button' value='הוסף לעגלה' class='btn'/> ";
                else
                {
                    return "<div id=adminPlace>" +
                                "<p id=quantity style=\"color:" + txtColor + "\">" + "כמות במלאי : " + quantity + "</p>" +
                                "<input id=removeButton type='button' value='מחק מוצר' class='btn adminButton' onclick=\"removeItem(" + pId + ")\" />" +
                                "<input id=editButton type='button' value='ערוך מוצר' class='btn adminButton' onclick=\"updateItem(" + pId + ")\" />" +
                            "</div>";
                }
            }
            else
                return "<input type='button' value='הוסף לעגלה' class='btn'/> ";
        }

        protected void OpenPopup_click(object sender, EventArgs e)
        {
            addNewItemPopUp.Style.Add("display", "block");
            popupHeaderText.InnerText = "הוספת מוצר";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            fillCompanysDropDownList(con);
            fillCategorysDropDownList(con);
            fillSubCatDropDownList(con);
            Session["AddItem"] = 1;
        }

        protected void OpenUpdatePopup(int id)
        {
            addNewItemPopUp.Style.Add("display", "block");
            if (!IsPostBack)
            {
                popupHeaderText.InnerText = "עריכת מוצר";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
                fillCompanysDropDownList(con);
                fillCategorysDropDownList(con);
                fillSubCatDropDownList(con);
                getallProperties(con, id);
            }
            Session["editItem"] = 1;
        }

        private void removeItem(string id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            con.Open();
            string update = "Update products Set product_exist = 'False' Where product_id = " + id;

            SqlCommand command = new SqlCommand(update, con);
            command.ExecuteNonQuery();

            con.Close();
            Response.Redirect("~/Catalog.aspx");
        }

        private void getallProperties(SqlConnection con, int id)
        {
            con.Open();
            string query = "Select * from products where product_id =" + id;
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader sqlData = command.ExecuteReader();

            if (sqlData.Read())
            {
                ProductModel.Text = sqlData["product_model"].ToString();
                ProductPrice.Text = sqlData["product_price"].ToString();
                ProductInstalationPrice.Text = sqlData["product_install_price"].ToString();
                productCountry.Text = sqlData["product_made"].ToString();
                ProductDescription.InnerHtml = sqlData["product_desc"].ToString();
                CompanyName.SelectedValue = sqlData["product_company"].ToString();
                ProductCategory.SelectedValue = sqlData["product_type"].ToString();
                ProductSubCategory.SelectedValue = sqlData["product_type2"].ToString();
                ProductInventory.Text = sqlData["product_inventory"].ToString();
            }
        }

        protected void addNewDesc_Click(object sender, EventArgs e)
        {
            string curDesc = ProductDescription.InnerHtml.Replace("</ul>", "");
            curDesc += "<li>" + ProductNewDescription.Text + "</li></lu>";
            ProductDescription.InnerHtml = curDesc;
            ProductNewDescription.Text = "";
            addNewItemPopUp.Style.Add("display", "block");
        }

        private void fillSubCatDropDownList(SqlConnection con)
        {
            string com = "Select * from applience_types";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            ProductSubCategory.DataSource = dt;
            ProductSubCategory.DataBind();
            ProductSubCategory.DataTextField = "appType_name";
            ProductSubCategory.DataValueField = "appType_id";
            ProductSubCategory.DataBind();
        }

        private void fillCategorysDropDownList(SqlConnection con)
        {
            string com = "Select * from applience";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            ProductCategory.DataSource = dt;
            ProductCategory.DataBind();
            ProductCategory.DataTextField = "app_name";
            ProductCategory.DataValueField = "app_id";
            ProductCategory.DataBind();
        }

        private void fillCompanysDropDownList(SqlConnection con)
        {

            string com = "Select * from companys";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            CompanyName.DataSource = dt;
            CompanyName.DataBind();
            CompanyName.DataTextField = "company_name";
            CompanyName.DataValueField = "company_id";
            CompanyName.DataBind();
        }

        protected void close_click(object sender, EventArgs e)
        {
            addNewItemPopUp.Style.Add("display", "non");
            if (Session["editItem"] != null)
            {
                Session.Remove("editItem");
            }
            if (Session["addItem"] != null)
            {
                Session.Remove("addItem");
            }
            Response.Redirect("~/Catalog.aspx");
        }

        public void createItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IKitchenDB"].ConnectionString);
            con.Open();
            string sqlString = "";
            if (Session["editItem"] != null)
            {
                sqlString = "Update products Set product_model='" + ProductModel.Text + "', product_made= N'" + productCountry.Text + "'" +
                ", product_price= '" + ProductPrice.Text + "', product_install_price= '" + ProductInstalationPrice.Text + "'" +
                ", product_desc= N'" + ProductDescription.InnerHtml + "', product_company= '" + CompanyName.Text + "'" +
                ", product_type= '" + ProductCategory.Text + "', product_type2= '" + ProductSubCategory.Text + "'" +
                ", product_inventory= '" + ProductInventory.Text + "', product_exist=  'True' " +
                "Where product_id = " + Request.QueryString["updateId"].ToString();
            }
            else if (Session["addItem"] != null)
            {
                sqlString = "INSERT INTO products " +
                    "(product_model, product_made, product_price, product_install_price, product_desc, " +
                    "product_company, product_type, product_type2, product_create, product_inventory, product_exist) " +
                            "VALUES ('" + ProductModel.Text + "',N'" + productCountry.Text +
                            "','" + ProductPrice.Text + "','" + ProductInstalationPrice.Text +
                            "',N'" + ProductDescription.InnerHtml + "','" + CompanyName.Text +
                            "','" + ProductCategory.Text + "','" + ProductSubCategory.Text +
                            "','" + DateTime.Now +
                            "','" + ProductInventory.Text + "','" + CompanyName.Text + "')";
            }

            SqlCommand command = new SqlCommand(sqlString, con);
            command.ExecuteNonQuery();

            con.Close();

            addNewItemPopUp.Style.Add("display", "non");
            if (Session["editItem"] != null)
            {
                Session.Remove("editItem");
            }
            if (Session["addItem"] != null)
            {
                Session.Remove("addItem");
            }
            Response.Redirect("~/Catalog.aspx");
        }
    }
}
