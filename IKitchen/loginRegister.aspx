<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginRegister.aspx.cs" Inherits="IKitchen.loginRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title></title>
    <link href="css/loginRegister.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginCell" class="logReg">
            התחברות
        </div>
        <div id="loginContent" class="content">
            <p>שם משתמש :
                <br />
                <asp:TextBox ID="userNameInput" class="input" runat="server"></asp:TextBox>
            </p>
            <p>סיסמא :
                <br />
                <asp:TextBox ID="passwordInput" class="input" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="loginBtn" CssClass="btn" runat="server" Text="התחבר" />
        </div>
        <div id="registerCell" class="logReg">
            הרשמה
        </div>
        <div id="registerContent" class="content">
            <p>חדש באתר ?</p>
            <p>התחבר עכשיו, זה מהיר ופשוט !</p>
            <asp:Button ID="registerBtn" class="btn" runat="server" Text="הרשם" />
        </div>
    </form>
</body>
</html>
