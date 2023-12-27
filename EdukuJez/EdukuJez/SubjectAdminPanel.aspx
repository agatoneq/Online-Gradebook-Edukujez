<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectAdminPanel.aspx.cs" Inherits="EdukuJez.SubjectAdminPanel" %>
<asp:Content ID="MainContentID" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Subjects_Management_Page_Title.png" class="logo1" style="height: 82px; width: 650px" />
        <hr />
    </div>
       <p align="center">
       <asp:Label ID="LabelSubjectName" runat="server" Text="Nazwa przedmiotu: "></asp:Label>
       <asp:TextBox ID="TextBoxSubjectName" runat="server" MaxLength="100"></asp:TextBox>
   </p>   
    <br />
    <p align="center">
        <asp:Label ID="LabelDescription" runat="server" Text="Opis przedmiotu: "></asp:Label>
        &nbsp;<asp:TextBox ID="TextBoxSubjectDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
    </p>
    <br />
    <p align="center">
        <asp:Label ID="LabelGroupsAndUsers" runat="server" Text="Grupy i użytkownicy: "></asp:Label>
        <asp:DropDownList ID="DropDownList" runat="server"></asp:DropDownList>
        <asp:Button ID="ButtonAdd" runat="server" Text="Dodaj" OnClick="ButtonAdd_Click" />
        <br />
        <br />
            <asp:ListBox ID="ListBox1" runat="server" BackColor="White"></asp:ListBox>
        <asp:Button ID="ButtonDelete" runat="server" Text="Usuń" OnClick="ButtonDelete_Click" />
    </p>
    <br />
    <p align="center">
        <asp:Button ID="ButtonSubjectAccept"  runat="server" Text="Dodaj przedmiot" OnClick="ButtonSubjectAccept_Click" />
    </p>
</asp:Content>

