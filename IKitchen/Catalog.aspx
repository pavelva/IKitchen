<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="IKitchen.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/Catalog.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                <span class="productType" >דגם: <%#Eval("product_model") %></span>
                <span class="productModel" >דגם: <%#Eval("product_model") %></span>

                <asp:Button Text="Buy" runat="server" />
            </div>
            
        </ItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="CatalogDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
            

</asp:Content>
