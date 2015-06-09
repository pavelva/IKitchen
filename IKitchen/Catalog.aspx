﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="IKitchen.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/Catalog.css" />

    <script type="text/javascript" src="Script/catalog.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>קטלוג מוצרים</h2>
    <div id="itemTypePicker" class="itemTypePicker" runat="server" >
        <h3>בחר מוצר:</h3>
    </div>
    <div id="CompanyPIcker" class="itemTypePicker" runat="server">
        <h3>בחר חברה:</h3>
    </div>
    
    <div id="catalog">

    </div>

   <%-- <asp:ListView runat="server" DataSourceID="CatalogDataSource">
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
                <asp:Button Text="הוסף לעגלה" runat="server" CssClass="btnProduct"/>
            </div>
            
        </ItemTemplate>
    </asp:ListView>--%>

    <asp:SqlDataSource ID="CatalogDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
            

</asp:Content>
