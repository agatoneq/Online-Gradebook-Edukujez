<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EdukuJez._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Login ID="Login1" runat="server" Height="346px" Width="730px" OnAuthenticate="Login1_Authenticate" style="margin-left: 314px">
    </asp:Login>

</asp:Content>
