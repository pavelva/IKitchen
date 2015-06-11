<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="IKitchen.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/MyPurchases.css" />
    <link rel="stylesheet" type="text/css" href="Style/cart.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="saleWrapper" runat="server">
        <asp:GridView ID="cartGrid"  ShowFooter="true" ClientIDMode="Static" CssClass="salesTable" runat="server" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="cartQuery" OnRowDataBound="cartGrid_RowDataBound">
            <RowStyle CssClass="mySalesRow" />
            <HeaderStyle CssClass="tableHeader" />
            <FooterStyle CssClass="tableFooter" />
            <Columns>
                <asp:BoundField DataField="app_name" HeaderText="סוג"  ReadOnly="True" SortExpression="appName" />
                <asp:BoundField DataField="product_model" HeaderText="דגם"  ReadOnly="True" SortExpression="productModel" />
                <asp:BoundField DataField="company_name" HeaderText="חברה"  ReadOnly="True" SortExpression="companyName" />
                <asp:BoundField DataField="appType_name" HeaderText="תיאור מוצר"  ReadOnly="True" SortExpression="appTypeName" />
                <asp:BoundField DataField="product_made" HeaderText="ארץ יצור"  ReadOnly="True" SortExpression="productMade" />
                <asp:BoundField DataField="product_price" DataFormatString="{0} ש&quot;ח" HeaderText="מחיר"  ReadOnly="True" SortExpression="productPrice" />
                <asp:BoundField DataField="product_install_price" DataFormatString="{0} ש&quot;ח" HeaderText="מחיר התקנה"  ReadOnly="True" SortExpression="productInstall" />
                <asp:TemplateField HeaderText="כמות">
                    <ItemTemplate>
                        <asp:DropDownList ID="amount" CssClass="dropAmount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="amount_SelectedIndexChanged">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField DataImageUrlField="product_model" DataImageUrlFormatString="~/Images/big/{0}.jpg" ControlStyle-Width="100px"></asp:ImageField>
                <asp:BoundField DataField="product_id" HeaderText="" ReadOnly="True" SortExpression="productId">
                    <ItemStyle CssClass="hidden" />
                    <HeaderStyle CssClass="hidden" />
                </asp:BoundField>
            </Columns>
            
        </asp:GridView>
        <asp:Button ID="btnBuy" CssClass="btn" runat="server" Text="בצע רכישה"/>
        <asp:Button ID="btnClear" CssClass="btn" runat="server" Text="נקה" OnClick="btnClead_Click"/>
    </div>
    <asp:SqlDataSource ID="cartQuery" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
</asp:Content>
