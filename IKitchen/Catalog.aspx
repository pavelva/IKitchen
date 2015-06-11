<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="IKitchen.Catalog" %>
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
    <asp:Label ID="newItem" ClientIDMode="Static" runat="server" Text="Label">
        <input id="addNewItemButton" type="button" value='הוסף מוצר' class="btnProduct adminButton"/>
    </asp:Label>
    <div id="catalog">
    
    </div>

    <asp:SqlDataSource ID="CatalogDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
            

</asp:Content>
