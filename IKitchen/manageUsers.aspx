<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="manageUsers.aspx.cs" Inherits="IKitchen.manageUsers" %>

<asp:Content ID="manageUserHead" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/manageUsers.css" />
    <link rel="stylesheet" type="text/css" href="Style/MyPurchases.css" />
</asp:Content>
<asp:Content ID="manageUserContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <asp:GridView ID="usresTable" CssClass="salesTable" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="usersDataSource">
        <RowStyle CssClass="mySalesRow" />
        <HeaderStyle CssClass="tableHeader" />
        
        <Columns>
            <asp:TemplateField HeaderText="שם">
                <ItemTemplate>
                    <asp:Label ID="name" runat="server"><%#Eval("user_firstName") %>&nbsp<%#Eval("user_lastName") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="user_email" HeaderText="שם משתמש" ReadOnly="True" SortExpression="purchseDate" />
            <asp:BoundField DataField="user_realEmail" HeaderText="דואר אלקטרוני" ReadOnly="True" SortExpression="purchseDate" />
            <asp:BoundField DataField="user_country" HeaderText="מדינה" ReadOnly="True" SortExpression="purchseDate" />
            <asp:TemplateField HeaderText="סוג משתמש">
                <ItemTemplate>
                    <asp:Label ID="userType" runat="server"><%#Eval("user_isAdmin").ToString() == "True"? "מנהל":"רגיל" %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="שנה סוג משתמש">
                <ItemTemplate>
                    <asp:Button ID="changeUserTypeBtn" ClientIDMode="Static" CssClass="btn" CommandArgument='<%#Eval("user_id")%>' runat="server" Text='<%# Eval("user_isAdmin").ToString()=="True"? "החלף למשתמש רגיל":"החלף למנהל" %>' OnClick="changeUserType"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="היסטוריית קניות"  DataNavigateUrlFields="user_id" DataNavigateUrlFormatString="?userID={0}" Text="רשימת קניות" />
            
      </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="usersDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

    <asp:GridView ID="UserSalesTable" ClientIDMode="Static" CssClass="salesTable" runat="server" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="UserPurchasesDataSource">
        <RowStyle CssClass="mySalesRow" />
        <HeaderStyle CssClass="tableHeader" />
        <Columns>
            <asp:BoundField DataField="sale_id" HeaderText="" Visible="false" ReadOnly="True" SortExpression="saleId" />
            <asp:BoundField DataField="sale_date" HeaderText="תאריך קניה"  ReadOnly="True" SortExpression="saleDate" />
            <asp:BoundField DataField="sale_comments" HeaderText="הערות"  ReadOnly="True" SortExpression="purchaseComments" />
            <asp:HyperLinkField DataNavigateUrlFields="sale_id, sale_userid" DataNavigateUrlFormatString="?sale={0}&userID={1}" Text="פרטים" />
            
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="UserPurchasesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

    <div id="saleWrapper" runat="server">
        <asp:GridView ID="saleGrid2" ShowFooter="true" ClientIDMode="Static" CssClass="salesTable" runat="server" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="UserSalesQuery" OnRowDataBound="saleGrid_RowDataBound">
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
        <asp:Button ID="backBtn" CssClass="btn" runat="server" Text="חזרה" OnClick="backBtn_Click" />
    </div>

    <asp:SqlDataSource ID="UserSalesQuery" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>

</asp:Content>