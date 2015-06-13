<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IKitchen.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/catalog.css" />
    <script type="text/javascript" src="Script/main.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>מוצרים מומלצים</h2>

    <asp:ListView runat="server" DataSourceID="DefaultDataSource" ID="productsListView">
        <LayoutTemplate>

            <div runat="server" id="itemPlaceHolder"></div>
            <div>
        </LayoutTemplate>
        <ItemTemplate>
            <div <%if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString())) Response.Write("class='catalogItem adminItem'"); else Response.Write("class='catalogItem'"); %>  id="item_<%#Eval("product_id")%>" style="position:relative">
                <h3>
                    <span class="productType" ><%#Eval("app_name") %></span><br />
                    <span class="productModel" > <%#Eval("product_model") %></span>
                    <span class="productCompany" ><%#Eval("company_name") %></span>
                </h3>
                <span class="productImg" > <img src="Images/Big/<%#Eval("product_model") %>.jpg" /></span>
                <input type='button'"  value='הוסף לעגלה' class='btn'/> 
                <span class='productId' style='display:none'> <%#Eval("product_id") %></span>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="DefaultDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

</asp:Content>