<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IKitchen.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/catalog.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>מוצרים מומלצים</h2>

    <asp:ListView runat="server" DataSourceID="DefaultDataSource" ID="productsListView">
        <LayoutTemplate>

            <div runat="server" id="itemPlaceHolder"></div>

        </LayoutTemplate>
        <ItemTemplate>
            <div class="catalogItem">
                <h3>
                    <span class="productType" ><%#Eval("app_name") %></span><br />
                    <span class="productModel" > <%#Eval("product_model") %></span>
                    <span class="productCompany" ><%#Eval("company_name") %></span>
                </h3>
                <span class="productImg" > <img src="Images/Big/<%#Eval("product_model") %>.jpg" /></span>
                <asp:Button Text="הוסף לעגלה" runat="server" CssClass="btnProduct" />
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="DefaultDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

</asp:Content>