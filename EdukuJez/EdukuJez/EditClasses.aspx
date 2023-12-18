<%@ Page Title="Timetable Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditClasses.aspx.cs" Inherits="EdukuJez.EditClasses" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <asp:Table ID="LessonTable" runat="server" CssClass="LessonPlan"></asp:Table>
        </div>
    <div class="header Container-Title ">
        <img src="Imgs/Timetable_Management_Page_Title.png" class="logo1" style="height: 82px; width: 661px" />
        <hr/>
    </div>
    <asp:Table ID="MainTable" runat="server" CellSpacing="20" CssClass="Center-Form  Main-Table">
         

    </asp:Table>
    

</asp:Content>
