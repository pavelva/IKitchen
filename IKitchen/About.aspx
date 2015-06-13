<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="IKitchen.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/about.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="aboutContent">
        <h2>שמות המגישים:</h2>
        <ul>
            <li>
                פבל וויסבורג
                <a href="http://ipiass1.apphb.com/" target="_blank">לאתר האישי</a>
            </li>
            <li>
                אלכס זלצר
                <a href="http://myawesomeprofile.co.nf/" target="_blank">לאתר האישי</a>
            </li>
            <li>
                רונן ליברזון
                <a href="http://ronenlib.apphb.com/" target="_blank">לאתר האישי</a>
            </li>
        </ul>
        <h2>
            קשיים שנתקלו בהם:
        </h2>
        <ul>
            <li>
                התמודדות עם ה-Master Page
            </li>
            <li>
                התממשקות מול ה-Sql Server
            </li>
            <li>
                מעבר בין מצב משתמש למצב מנהל והתאמת תוכן העמודים בהתאם למצב
            </li>
            <li>
                התאמה בין פעולות ב-JavaScript לבין פעולות בשרת
            </li>
        </ul>

        <a id="packMan" href="http://pacman-1.apphb.com/" target="_blank">לאתר הפקמן</a>
    </div>
</asp:Content>
