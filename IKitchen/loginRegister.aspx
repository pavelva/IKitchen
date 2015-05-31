<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginRegister.aspx.cs" Inherits="IKitchen.loginRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title></title>
    <link href="css/loginRegister.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header>אני מטבח</header>
    <div id="line"></div>
    <form id="form1" runat="server">
        <div id="loginCell" class="logReg">
            התחברות
        </div>
        <div id="loginContent" class="content">
            <p>
                <span class="inputText">
                    שם משתמש :
                </span>
                <br />
                <asp:TextBox id="userNameInput" CssClass="loginInput input" runat="server"></asp:TextBox>
            </p>
            <p>
                <span class="inputText">
                    סיסמא :
                </span>
                <br />
                <asp:TextBox ID="passwordInput" CssClass="loginInput input" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="loginBtn" CssClass="btn" runat="server" Text="התחבר" />
        </div>
        <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" ControlToValidate="userNameInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" ControlToValidate="passwordInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
        <div id="registerCell" class="logReg">
            הרשמה
        </div>
        <div id="registerContent" class="content">
            <p>חדש באתר ?</p>
            <p>הרשם עכשיו, זה מהיר ופשוט !</p>
            <asp:Button ID="registerBtn" class="btn" runat="server" Text="להרשמה" />
        </div>
    </form>
</body>
</html>
