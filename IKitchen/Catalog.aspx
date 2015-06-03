<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="IKitchen.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/Catalog.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>קטלוג מוצרים</h2>
    <div id="itemTypePicker" class="itemTypePicker" runat="server">
        <h3>בחר מוצא:</h3>
    </div>
    
    <asp:ListView runat="server" DataSourceID="CatalogDataSource">
        <LayoutTemplate>
            <div runat="server" id="itemPlaceHolder"></div>
            <div id="catalogPager"dir="ltr">
                <asp:DataPager runat="server" ID="DataPager" PageSize="12" >
                  <Fields>
                    <asp:NumericPagerField 
                      ButtonCount="5"
                      PreviousPageText="<--"
                      NextPageText="-->" />
                  </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="catalogItem">
                <h3>
                    <span class="productType" ><%#Eval("app_name") %></span><br />
                    <span class="productModel" > <%#Eval("product_model") %></span>
                    <span class="productCompany" ><%#Eval("company_name") %></span>
                </h3>
                <span class="productImg" > <img src="Images/Big/<%#Eval("product_model") %>.jpg" /></span>
                <asp:Button Text="הוסף לעגלה" runat="server" />
            </div>
            
        </ItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="CatalogDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
            

</asp:Content>
