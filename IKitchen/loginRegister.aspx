﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginRegister.aspx.cs" Inherits="IKitchen.loginRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title></title>
    <link href="style/loginRegister.css" rel="stylesheet" type="text/css" />

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="Script/logReg.js"></script>
    
</head>
<body>
    <header>
        <span id=logo>
            I<span id="logo_content">Kitchen</span>
        </span>
    </header>
    <nav></nav>
    <div id="line"></div>
    <form id="form1" runat="server">
        <div id="registerCell" class="logReg">
            <div id="registerHeader" class="contentHeader">
                הרשמה
            </div>
            <div id="registerContent" class="content">
                <p>חדש באתר ?</p>
                <p>הרשם עכשיו, זה מהיר ופשוט !</p>
                <br />
                <asp:Button ID="registerBtn" class="btn" runat="server" Text="להרשמה" OnClientClick="makeRegisterDetailes()"/>
            </div>
            <div id="signUpContent" class="content">
                <p>
                    <span class="inputText">
                        שם פרטי :
                    </span>
                    <br />
                    <asp:TextBox id="firstNameInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span class="inputText">
                        שם משפחה :
                    </span>
                    <br />
                    <asp:TextBox id="lastNameInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span class="inputText">
                        דואר אלקטרוני :
                    </span>
                    <br />
                    <asp:TextBox id="emailInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span class="inputText">
                        סיסמא :
                    </span>
                    <br />
                    <asp:TextBox id="regPasswordInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span class="inputText">
                        וידוא סיסמא :
                    </span>
                    <br />
                    <asp:TextBox id="regConfirmPasswordInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span class="inputText">
                        שאלה לאחזור סיסמא :
                    </span>
                    <br />
                    <asp:DropDownList ID="listOfQestions" runat="server">
                        <asp:ListItem Text="שם של החבר/ה שלך" Value="0"></asp:ListItem>
                        <asp:ListItem Text="שם של הכלב שלך" Value="1"></asp:ListItem>
                        <asp:ListItem Text="שם משפחה קודם" Value="2"></asp:ListItem>
                        <asp:ListItem Text="ארץ לידה" Value="3"></asp:ListItem>
                        <asp:ListItem Text="קורס שנהנית בו" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <span class="inputText">
                        תשובה לשאלה :
                    </span>
                    <br />
                    <asp:TextBox id="answer" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <asp:Button ID="signUpBtn" class="btn" runat="server" Text="הרשם" />
            </div>
        </div>

        <div id="loginCell" class="logReg">
            <div id="loginHeader" class="contentHeader">
                התחברות
            </div>
            <div id="loginContent" class="content">
            <p>
                <span class="inputText">
                    שם משתמש :
                </span>
                <br />
                <asp:TextBox id="userNameInput" CssClass="loginInput input" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" ControlToValidate="userNameInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <span class="inputText">
                    סיסמא :
                </span>
                <br />
                <asp:TextBox ID="passwordInput" CssClass="loginInput input" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" ControlToValidate="passwordInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
            <asp:Button ID="loginBtn" CssClass="btn" runat="server" Text="התחבר" />
            <p>
                <span id="forgotPassword" class="inputText">
                    שכחתי סיסמא
                </span>
            </p>
        </div>
        </div>
    </form>
</body>
</html>
