<%@ Page Title="Kalendarz Admin Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalendarAdminPanel.aspx.cs" Inherits="EdukuJez.CalendarAdminPanel" %>
<asp:Content ID="MainContentID" ContentPlaceHolderID="MainContent" runat="server">
            <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Calendar_Management_Page_Title.png" class="logo1" style="height: 82px; width: 650px" />
        <hr />
    </div>
    <div style="text-align:center;">
        <asp:ListBox ID="ListBoxAllDates" runat="server" style="width: 350px; height: 400px; font-size: 20px;"></asp:ListBox>
    </div>
    <br />
    <div style="text-align:center;">
        <asp:TextBox ID="TextBoxDate" runat="server" placeholder="Wprowadź datę" style="width: 300px; height: 30px; font-size: 16px;"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxDescription" runat="server" placeholder="Wprowadź opis" style="width: 300px; height: 30px; font-size: 16px;"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonAdd" runat="server" Text="Dodaj nowy wpis" OnClick="ButtonAdd_Click" Style="width: 220px; height: 40px; font-size: 20px;" />
    </div>
    <br />
    <asp:Button ID="ButtonEdit" runat="server" Text="Edytuj date" OnClick="ButtonEdit_Click" Style="width: 220px; height: 40px; font-size: 20px;" />
    <br />
    <asp:Button ID="ButtonDelete" runat="server" Text="Usuń date" OnClick="ButtonDelete_Click" Style="width: 220px; height: 40px; font-size: 20px;" />
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:Label ID="LabelInfo" runat="server" Text="Label" Visible="False" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
