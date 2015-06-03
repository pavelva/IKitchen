<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="IKitchen.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ListView runat="server" DataSourceID="CatalogDataSource">
        <LayoutTemplate>
            <table cellpadding="2" runat="server" id="tblEmployees" 
                style="width:460px">
              <tr runat="server" id="itemPlaceholder">
              </tr>
            </table>
            <asp:DataPager runat="server" ID="DataPager" PageSize="5">
              <Fields>
                <asp:NumericPagerField
                  ButtonCount="5"
                  PreviousPageText="<--"
                  NextPageText="-->" />
              </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <tr><td style="float:left;border:1px solid black; margin:0 5px; width:30%"><%#Eval("product_model") %></td></tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="CatalogDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
            

</asp:Content>
