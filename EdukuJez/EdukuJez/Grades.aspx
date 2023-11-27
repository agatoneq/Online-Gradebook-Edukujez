<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grades.aspx.cs" Inherits="EdukuJez.Grades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <asp:DropDownList ID="GroupDropDownList" runat="server"></asp:DropDownList> <asp:DropDownList ID="SubjectsDropDownList" runat="server"></asp:DropDownList>  <asp:Button ID="ShowButton" runat="server" Text="Pokaż" OnClick="ShowButton_Click" /> <asp:Button ID="EditButton" runat="server" Text="Edytuj oceny" OnClick="EditButton_Click" Visible ="false"/>
   <asp:GridView ID="GradesGridView" runat="server"  Visible ="false"></asp:GridView>
    <asp:Button ID="AddButton" runat="server" Text="Anuluj zmiany" OnClick="AddButton_Click" Visible="false" /> <asp:Button ID="SaveButton" runat="server" Text="Zapisz zmiany" OnClick="SaveButton_Click" Visible="false" />
</asp:Content>