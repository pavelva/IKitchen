<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyPurchases.aspx.cs" Inherits="IKitchen.MyPurchases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/MyPurchases.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="MySalesTable" ClientIDMode="Static" CssClass="salesTable" runat="server" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="MyPurchasesDataSource">
        <RowStyle CssClass="mySalesRow" />
        <HeaderStyle CssClass="tableHeader" />
        <Columns>
            <asp:BoundField DataField="sale_id" HeaderText="" Visible="false" ReadOnly="True" SortExpression="saleId" />
            <asp:BoundField DataField="sale_date" HeaderText="תאריך קניה"  ReadOnly="True" SortExpression="saleDate" />
            <asp:BoundField DataField="sale_comments" HeaderText="הערות"  ReadOnly="True" SortExpression="purchaseComments" />
            <asp:HyperLinkField DataNavigateUrlFields="sale_id" DataNavigateUrlFormatString="?sale={0}" Text="פרטים" />
            
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="MyPurchasesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

    <div id="saleWrapper" runat="server">
        <asp:GridView ID="saleGrid" ShowFooter="true" ClientIDMode="Static" CssClass="salesTable" runat="server" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="SalesQuery" OnRowDataBound="saleGrid_RowDataBound">
            <RowStyle CssClass="mySalesRow" />
            <HeaderStyle CssClass="tableHeader" />
            <FooterStyle CssClass="tableFooter" />
            <Columns>
                <asp:BoundField DataField="purchase_id" HeaderText="" Visible="false" ReadOnly="True" SortExpression="purchaseId" />
                <asp:BoundField DataField="purchase_productId" HeaderText="" Visible="false" ReadOnly="True" SortExpression="productId" />
                <asp:BoundField DataField="app_name" HeaderText="סוג"  ReadOnly="True" SortExpression="appName" />
                <asp:BoundField DataField="product_model" HeaderText="דגם"  ReadOnly="True" SortExpression="productModel" />
                <asp:BoundField DataField="company_name" HeaderText="חברה"  ReadOnly="True" SortExpression="companyName" />
                <asp:BoundField DataField="appType_name" HeaderText="תיאור מוצר"  ReadOnly="True" SortExpression="appTypeName" />
                <asp:BoundField DataField="product_made" HeaderText="ארץ יצור"  ReadOnly="True" SortExpression="productMade" />
                <asp:BoundField DataField="product_price" DataFormatString="{0} ש&quot;ח" HeaderText="מחיר"  ReadOnly="True" SortExpression="productPrice" />
                <asp:BoundField DataField="product_install_price" DataFormatString="{0} ש&quot;ח" HeaderText="מחיר התקנה"  ReadOnly="True" SortExpression="productInstall" />
                <asp:ImageField DataImageUrlField="product_model" DataImageUrlFormatString="~/Images/big/{0}.jpg" ControlStyle-Width="100px"></asp:ImageField>
            </Columns>
            
        </asp:GridView>
        <asp:Button ID="backToMyPurcases" CssClass="btn" runat="server" Text="חזור לרכישות" OnClick="backToMyPurcases_Click" />
    </div>
    <asp:SqlDataSource ID="SalesQuery" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

</asp:Content>
