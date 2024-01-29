<%@ Page Title="Timetable Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditClasses.aspx.cs" Inherits="EdukuJez.EditClasses" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <asp:Table ID="LessonTable" runat="server" CssClass="LessonPlan"></asp:Table>
        </div>

        <div style="margin-bottom: 30px;" class="header Container-Title ">
                <asp:Button ID="GoBackButton" runat="server" Text="Panel Administratora" Style="margin-top: 12px; width: 170px; height: 60px; font-size: 20px; float: left; white-space: normal;" OnClick="GoBackButton_Click" CssClass="Main-Panel-Image" ForeColor="Black" EnableTheming="True"/>
        <img src="Imgs/Timetable_Management_Page_Title.png" class="logo1" style="height: 82px; width: 661px" />
            <asp:Button ID="Button1" runat="server" Text=" " Style="width: 250px; height: 40px; font-size: 20px; float: right;" BackColor="#FEFAE0" BorderColor="#FEFAE0" BorderStyle="None" />
         <hr />
    </div>


    <asp:Table ID="MainTable" runat="server" CellSpacing="20" CssClass="Center-Form  Main-Table">
         

    </asp:Table>
    

</asp:Content>
