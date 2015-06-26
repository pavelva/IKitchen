<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Rest.aspx.cs" Inherits="IKitchen.Rest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/rest.css" />

    <script type="text/javascript" src="Script/rest.js"></script>

    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js'></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?libraries=places&sensor=false"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="worldImg" src="Images/icon-WorldWideWeb.png" />
    <input id="autoCompleteInput" placeholder="Enter City Name"/>
    <div id="weather">
        <span id="weatherPlace"></span>
        <div id="weatherImage"></div>
    </div>
</asp:Content>
