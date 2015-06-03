<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyPurchases.aspx.cs" Inherits="IKitchen.MyPurchases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/MyPurchases.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="MyPurchasesTable" CssClass="MyPurchasesTable" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="MyPurchasesDataSource">
        <RowStyle CssClass="myPurchasesRow" />
        <HeaderStyle CssClass="tableHeader" />
        
        <Columns>
            <asp:BoundField DataField="purchase_id" HeaderText="" Visible="false" ReadOnly="True" SortExpression="purchaseId" />
            <asp:BoundField DataField="purchase_productId" HeaderText="" Visible="false" ReadOnly="True" SortExpression="productId" />
            <asp:BoundField DataField="purchase_date" HeaderText="תאריך קניה"  ReadOnly="True" SortExpression="purchseDate" />
            <asp:BoundField DataField="app_name" HeaderText="סוג"  ReadOnly="True" SortExpression="appName" />
            <asp:BoundField DataField="product_model" HeaderText="דגם"  ReadOnly="True" SortExpression="productModel" />
            <asp:BoundField DataField="company_name" HeaderText="חברה"  ReadOnly="True" SortExpression="companyName" />
            <asp:BoundField DataField="appType_name" HeaderText="תיאור מוצר"  ReadOnly="True" SortExpression="appTypeName" />
            <asp:BoundField DataField="product_made" HeaderText="ארץ יצור"  ReadOnly="True" SortExpression="productMade" />
            <asp:BoundField DataField="comments" HeaderText="הערות"  ReadOnly="True" SortExpression="purchaseComments" />
            
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="MyPurchasesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

</asp:Content>
