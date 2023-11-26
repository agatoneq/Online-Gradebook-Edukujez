<%@ Page Title="Administration Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="EdukuJez.AdminPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="header Container-Title">
        <img src="Imgs/Admin_Page_Title.png" class="logo1" style="height: 82px; width: 661px" />
        <hr />
    </div>
    <asp:Table ID="MainAdminTable" runat="server" CellSpacing="20" CssClass="Center-Form Main-Table">
    </asp:Table>
</asp:Content>