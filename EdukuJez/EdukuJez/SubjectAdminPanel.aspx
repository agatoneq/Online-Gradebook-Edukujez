<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectAdminPanel.aspx.cs" Inherits="EdukuJez.SubjectAdminPanel" %>
<asp:Content ID="MainContentID" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Subjects_Management_Page_Title.png" class="logo1" style="height: 82px; width: 650px" />
        <hr />
    </div>
      <div style="text-align:center;">
      <asp:ListBox ID="ListBoxAllSubjects" runat="server" style="width: 350px; height: 400px; font-size: 20px;"></asp:ListBox>
        </div>
     <asp:Button ID="ButtonAdd" runat="server" Text="Dodaj nowy przedmiot" Visible="False" OnClick="ButtonAdd_Click" Style="width: 220px; height: 40px; font-size: 20px;"/>
        <br />
    <asp:Button ID="ButtonEdit" runat="server" Text="Edytuj przedmiot" Visible="False" OnClick="ButtonEdit_Click" Style="width: 220px; height: 40px; font-size: 20px;"/>
        <br />
    <asp:Button ID="ButtonDelete" runat="server" Text="Usuń przedmiot" Visible="False" OnClick="ButtonDelete_Click" Style="width: 220px; height: 40px; font-size: 20px;" />
        <div style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Label ID="LabelInfo" runat="server" Text="Label" Visible="False" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>

