<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="loginRegister.aspx.cs" Inherits="IKitchen.loginRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/loginRegister.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="Script/logReg.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="registerCell" class="logReg">
            <div id="registerHeader" class="contentHeader">
                הרשמה
            </div>
           <%-- <div id="registerContent" class="content">
                <p>חדש באתר ?</p>
                <p>הרשם עכשיו, זה מהיר ופשוט !</p>
                <br />
                <asp:Button ID="registerBtn" CssClass="btn" runat="server" Text="להרשמה" OnClientClick="makeRegisterDetailes()"/>
            </div>--%>
            <div id="signUpContent" class="content">
                <p>
                    <span class="inputText">
                        שם פרטי :
                    </span>
                    <br />
                    <asp:TextBox id="firstNameInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" ControlToValidate="firstNameInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    
                </p>
                <p>
                    <span class="inputText">
                        שם משפחה :
                    </span>
                    <br />
                    <asp:TextBox id="lastNameInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" ControlToValidate="lastNameInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    
                </p>
                <p>
                    <span class="inputText">
                        שם משתמש :
                    </span>
                    <br />
                    <asp:TextBox id="emailInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RegEmailRequiredFieldValidator" ControlToValidate="emailInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>         
                    <asp:RegularExpressionValidator ID="emailRegularExpressionValidator" ControlToValidate="emailInput" ValidationExpression="([a-zA-Z]{3,8})$" runat="server" ErrorMessage="חייב להכיל 3-8 תווים באנגלית"></asp:RegularExpressionValidator>
                </p>
                <p>
                    <span class="inputText">
                        סיסמא :
                    </span>
                    <br />
                    <asp:TextBox ID="regPasswordInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RegPasswordRequiredFieldValidator" ControlToValidate="regPasswordInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PasswordRegularExpressionValidator" ControlToValidate="regPasswordInput" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{5,10}$" runat="server" ErrorMessage="חייב להכיל 5-10 תווים"></asp:RegularExpressionValidator>
                </p>
                <p>
                    <span class="inputText">
                        וידוא סיסמא :
                    </span>
                    <br />
                    <asp:TextBox id="regConfirmPasswordInput" CssClass="registerInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RegConfirmPasswordRequiredFieldValidator" ControlToValidate="regConfirmPasswordInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="RegConfirmCompareValidator" runat="server" ControlToValidate="regConfirmPasswordInput" ControlToCompare="regPasswordInput" ErrorMessage="לא תואם לסיסמא"></asp:CompareValidator>
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
                        <asp:ListItem Text="קורס שאהבת" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <span class="inputText">
                        תשובה לשאלה :
                    </span>
                    <br />
                    <asp:TextBox id="answer" CssClass="registerInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AnswerRequiredFieldValidator" ControlToValidate="answer" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    
                </p>
                <asp:Button ID="signUpBtn" CssClass="logRegBtn" runat="server" Text="הרשם" OnClientClick="registerBtn_Click" OnClick="registerBtn_Click"/>
                </div>
            </div>

        <div id="loginCell" class="logReg">
            <div id="loginHeader" class="contentHeader">
                התחברות
            </div>
            <div id="loginContent" class="content">
                <p>
                    <span class="inputText">
                        דואר אלקטרוני :
                    </span>
                    <br />
                    <asp:TextBox id="loginEmailInput" CssClass="loginInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" ControlToValidate="loginEmailInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <span class="inputText">
                        סיסמא :
                    </span>
                    <br />
                    <asp:TextBox ID="passwordInput" CssClass="loginInput input" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" ControlToValidate="passwordInput" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </p>
                    <asp:Label ID="errorLbl" Text="הפרטים אינם נכונים" runat="server"></asp:Label>
                    <asp:Button ID="loginBtn" CssClass="logRegBtn" runat="server" Text="התחבר" OnClientClick="loginBtn_Click" OnClick="loginBtn_Click" />
                <p>
                    <span id="forgotPassword" class="inputText forgotPassword" onclick="forgotPasswordPopUp()" runat="server">
                        שכחתי סיסמא
                    </span>
                </p>
            </div>
        </div>
        <div id="forgotPassPopup" class="divFordialog forgotPassPopup" runat="server">
            <div id="forgotPasswordDialog" title="Basic dialog">
                 <div class="dialogHeader contentHeader">
                    אחזור סיסמא
                </div>
                 <p>
                    <span class="inputText">
                        דואר אלקטרוני :
                    </span>
                    <br />
                    <asp:TextBox id="emailForgotPass" CssClass="input" runat="server"></asp:TextBox>
                </p>
                 <p>
                    <span class="inputText">
                        שאלה לאחזור סיסמא :
                    </span>
                    <br />
                    <asp:DropDownList ID="forgotListOfQestions" runat="server">
                        <asp:ListItem Text="שם של החבר/ה שלך" Value="0"></asp:ListItem>
                        <asp:ListItem Text="שם של הכלב שלך" Value="1"></asp:ListItem>
                        <asp:ListItem Text="שם משפחה קודם" Value="2"></asp:ListItem>
                        <asp:ListItem Text="ארץ לידה" Value="3"></asp:ListItem>
                        <asp:ListItem Text="קורס שאהבת" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                 <p>
                    <span class="inputText">
                        תשובה לשאלה :
                    </span>
                    <br />
                    <asp:TextBox id="answerForgatPass" CssClass="registerInput input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="forgotPassErrorlabel" runat="server" ClientIDMode="Static"></asp:Label>
                </p>
                  <asp:Button ID="ForgatBtn" CssClass="logRegBtn" runat="server" OnClick="ForgatPAssDetails_Click" OnClientClick="ForgatPAssDetails_Click" Text="שלח" style="margin-left:10%"/>
                    <asp:Button ID="closeDialogBtn" CssClass="logRegBtn" runat="server" Text="סגור" OnClientClick="closeDialog()" />
            </div>
        </div>
        <div id="newPasswordPopup"  class="divFordialog newPasswordPopup" runat="server">
            <div id="newPassDialog" title="Basic dialog">
                 <div class="dialogHeader contentHeader">
                    אחזור סיסמא
                </div>
                 <p>
                    <span class="inputText">
                        בחר סיסמא חדשה :
                    </span>
                    <br />
                    <asp:TextBox id="newPassInput" CssClass="input" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="newPassError" runat="server" ClientIDMode="Static"></asp:Label>
                </p>
                  <asp:Button ID="sendNewPass" ClientIDMode="Static" CssClass="logRegBtn" runat="server" OnClick="sendNewPass_Click" OnClientClick="sendNewPass_Click" Text="שלח" style="margin-left:10%"/>
            </div>
        </div>
</asp:Content>

