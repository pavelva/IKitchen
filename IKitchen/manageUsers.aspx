<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="manageUsers.aspx.cs" Inherits="IKitchen.manageUsers" %>

<asp:Content ID="manageUserHead" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/manageUsers.css" />
</asp:Content>
<asp:Content ID="manageUserContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--<table id="manageUserTable">
       <tr class="tableRow">
           <td class="tableCell">
               שם משתמש
           </td>
           <td class="tableCell">
               אימייל
           </td>
           <td class="tableCell">
               סוג משתמש
           </td>
           <td class="tableCell">
               פרטי קניות
           </td>
           <td class="tableCell">
               החלף סטטוס
           </td>
       </tr>
       <tr class="tableRow">
           <td class="tableCell">
               אלכס זלצר
           </td>
           <td class="tableCell">
               alex@gmail.com
           </td>
           <td class="tableCell">
               משתמש רגיל
           </td>
           <td class="tableCell">
               כפתור יצירה
           </td>
           <td class="tableCell">
               כפתור לקניות המשתמש
           </td>
       </tr>
   </table>--%>
     <asp:GridView ID="usresTable" CssClass="MyPurchasesTable" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="" DataSourceID="usersDataSource">
        <RowStyle CssClass="myPurchasesRow" />
        <HeaderStyle CssClass="tableHeader" />
        
        <Columns>
            <asp:BoundField DataField="user_id" HeaderText="" Visible="false" ReadOnly="True" SortExpression="purchaseId" />
            <asp:TemplateField HeaderText="שם">
                <ItemTemplate>
                    <asp:Label runat="server"><%#Eval("user_firstName") %>&nbsp<%#Eval("user_lastName") %></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="user_email" HeaderText="אימייל" ReadOnly="True" SortExpression="purchseDate" />
      </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="usersDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IKitchenDB %>">
    </asp:SqlDataSource>
</asp:Content>