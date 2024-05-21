<%@ Page Title="Obecności" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendances.aspx.cs" Inherits="EdukuJez.Attendances" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <h2>Obecności</h2>
        <hr />
    </div>

    <div style="overflow: auto;">
        <div style="float: left;"><asp:Calendar ID="Calendar1" runat="server" Height="226px" OnSelectionChanged="Calendar1_SelectionChanged" Width="565px"></asp:Calendar></div>
        <div style="float: right;"><asp:GridView ID="AttendanceGridView" runat="server" Visible = "false"></asp:GridView></div>
    </div>
    <asp:GridView ID="TeacherGridView" runat="server" Visible ="false"></asp:GridView>
</asp:Content>
