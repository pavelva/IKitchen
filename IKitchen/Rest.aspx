﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Rest.aspx.cs" Inherits="IKitchen.Rest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="Style/rest.css" />
    <link rel="stylesheet" type="text/css" href="Style/main.css" />
    <script type="text/javascript" src="Script/rest.js"></script>

    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js'></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?libraries=places&sensor=false"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="worldImg" src="Images/icon-WorldWideWeb.png" />
    <input id="autoCompleteInput" placeholder="Enter City Name (In English)"/>
    <div id="weather">
        <span id="weatherPlace"></span>
        <div id="weatherImage"></div>
        <span id="cityLearn">
        </span>
        <br />
        <button id="learnBtn" class="btn" type="button">I Want To Learn</button>
        <div id="aboutCity"></div>
    </div>
</asp:Content>
