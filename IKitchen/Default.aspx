<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IKitchen.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/catalog.css" />
    <script type="text/javascript" src="Script/main.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div id="categorys" runat="server">
        <h2>מוצרים חדשים לפי ההגדרות שלך</h2>

        <asp:ListView runat="server" DataSourceID="categorysProductsDataSource" ID="categorysProductsListView">
            <LayoutTemplate>

                <div runat="server" id="itemPlaceHolder"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="catalogItem categorysCatalogItem" id="item_<%#Eval("product_id")%>" style="position:relative">
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

        <asp:SqlDataSource ID="categorysProductsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
        </asp:SqlDataSource>
    </div>
    <div class =" clear"></div>

    <div id="buys" runat="server">
        <h2>מוצרים מומלצים לפי הקניות שלך</h2>

        <asp:ListView runat="server" DataSourceID="buysProductsDataSource" ID="buysProductsListView">
            <LayoutTemplate>

                <div runat="server" id="itemPlaceHolder"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="catalogItem buysCatalogItem" id="item_<%#Eval("product_id")%>" style="position:relative">
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

        <asp:SqlDataSource ID="buysProductsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
        </asp:SqlDataSource>
    </div>
    <div class =" clear"></div>

    <div id="defaultList" runat="server">
        <h2>מוצרים חדשים</h2>

        <asp:ListView runat="server" DataSourceID="DefaultDataSource" ID="defaultProductsListView">
            <LayoutTemplate>

                <div runat="server" id="itemPlaceHolder"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="catalogItem defaultCatalogItem" id="item_<%#Eval("product_id")%>" style="position:relative">
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
    </div>
</asp:Content>