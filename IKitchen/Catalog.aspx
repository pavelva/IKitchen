<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="IKitchen.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/Catalog.css" />

    <script type="text/javascript" src="Script/catalog.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 runat="server" id="CatalogHeader">קטלוג מוצרים</h2>
    <div id="itemTypePicker" class="itemTypePicker" runat="server" >
        <h3>בחר מוצר:</h3>
    </div>
    <div id="CompanyPIcker" class="itemTypePicker" runat="server">
        <h3>בחר חברה:</h3>
    </div>
    <asp:Label ID="newItem" ClientIDMode="Static" runat="server">
        <asp:Button ID="AddNewItemButton" ClientIDMode="Static" CssClass="btn adminButton" OnClick="OpenPopup_click" runat="server" Text="הוסף מוצר" />
    </asp:Label>
    
    <div id="catalog">
    
    </div>

    <asp:SqlDataSource ID="CatalogDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
            
    <div id="addNewItemPopUp" class="popup" runat="server">
        <div  class="popupHeader" >
            <h4 id="popupHeaderText" runat="server">הוספת מוצר</h4>
        </div>
        <div class="popupRow">
            <div class="popupLabel">קטגוריה :</div>
            <asp:DropDownList ID="ProductCategory" ClientIDMode="Static" CssClass="popupDropDownList" runat="server">
            </asp:DropDownList>
        </div>
        <div class="popupRow">
            <div class="popupLabel">תת קטגוריה :</div>
            <asp:DropDownList ID="ProductSubCategory" ClientIDMode="Static" CssClass="popupDropDownList" runat="server">
            </asp:DropDownList>
        </div>
        <div class="popupRow">
            <div class="popupLabel">שם חברה :</div>
            <asp:DropDownList ID="CompanyName" ClientIDMode="Static" CssClass="popupDropDownList" runat="server">
            </asp:DropDownList>
        </div>
        <div class="popupRow">
            <div class="popupLabel">דגם :</div>
            <asp:TextBox ID="ProductModel" CssClass="popupInputText" runat="server"></asp:TextBox>
        </div>
        <div class="popupRow">
            <div class="popupLabel">מדינת יצור :</div>
            <asp:TextBox ID="productCountry" CssClass="popupInputText" runat="server"></asp:TextBox>
        </div>
        <div class="popupRow">
            <div class="popupLabel">מחיר מוצר :</div>
            <asp:TextBox ID="ProductPrice" CssClass="popupInputText" runat="server"></asp:TextBox>
        </div>
        <div class="popupRow">
            <div class="popupLabel">מחיר התקנה :</div>
            <asp:TextBox ID="ProductInstalationPrice" CssClass="popupInputText" runat="server"></asp:TextBox>
        </div>
        <div class="popupRow">
            <div class="popupLabel">כמות :</div>
            <asp:TextBox ID="ProductInventory" ClientIDMode="Static" CssClass="popupInputText" runat="server"></asp:TextBox>
        </div>
        <div class="popupRow">
            <div class="popupLabel">הוספת תכונה :</div>
            <asp:TextBox id="ProductNewDescription" runat="server" class="popupInputText"></asp:TextBox>
            <asp:Button ID="addNewDesc" ClientIDMode="Static" OnClick="addNewDesc_Click" runat="server" Text="הוסף" />
        </div>
        <div id="inputRowDescription" class="popupRow">
            <div class="popupLabel">תכונות :</div>
            <div id="ProductDescription" runat="server" class="popupInputText descriptionContainer"></div>
        </div>
        <%--<div class="popupRow">
            <asp:Label ID="imageExplanation" ClientIDMode="Static" runat="server" Text="*על מנת שתופיע תמונה יש לשמור תמונה עם שם הדגם בקובץ המתאים"></asp:Label>></asp:Label>
        </div>--%>
        <div class="popupRow">
            <asp:Button ID="createBtn" ClientIDMode="Static" CssClass="btn adminButton" runat="server" Text="שמור" OnClick="createItem_Click"/>
            <asp:Button ID="closePopupBtn" ClientIDMode="Static" CssClass="btn adminButton" OnClick="close_click" OnClientClick="closePopup()" runat="server" Text="סגור" />
        </div>
        
    </div>
</asp:Content>
