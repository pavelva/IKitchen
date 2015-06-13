<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="IKitchen.Item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/catalog.css" />

    <script src="Script/item.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="item" runat="server">
        <div id="itemContent">
            <div id="itemDescription">
                <h3>
                    <asp:Label ID="app" ClientIDMode="Static" runat="server"></asp:Label><br />
                    <asp:Label ID="type" ClientIDMode="Static" runat="server"></asp:Label><br />
                </h3>
                <div id="itemPrice">
                    מחיר:&nbsp<asp:Label ID="price" ClientIDMode="Static" runat="server"></asp:Label>
                    <asp:Label ID="currencyPrice" ClientIDMode="Static" runat="server"></asp:Label><br />
                    התקנה:&nbsp<asp:Label ID="installPrice" ClientIDMode="Static" runat="server"></asp:Label>
                    <asp:Label ID="currencyInstall" ClientIDMode="Static" runat="server"></asp:Label>
                </div>
                <div id="desc" runat="server"></div>
            </div>
            <asp:Image ID="img" runat="server" />
            <span class="clear"></span>
            <input type="button" id="btnProduct" class="btn" value="הוסף לעגלה" <%if (Session["isAdmin"] != null && bool.Parse(Session["isAdmin"].ToString())) Response.Write("style='display:none'"); %> />
            <asp:Button ID="back" CssClass="btn" runat="server" OnClick="backToCatalog" Text="בחזרה לקטלוג" />
            <span class="clear"></span>
            <asp:HiddenField ID="productId" ClientIDMode="Static"  runat="server" />
        </div>
    </div>
    <div id="error" runat="server" style="display:none">
        המוצר אינו נמצא במערכת
    </div>

    
    
</asp:Content>
