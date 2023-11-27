<%@ Page Title="Account Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountsManagement.aspx.cs" Inherits="EdukuJez.AccountsManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Accounts_Management_Page_Title.png" class="logo1" style="height: 82px; width: 661px" />
        <hr/>
    </div>
    <div>
         <asp:Label ID="MainInfoLabel" runat="server" Text="Wpisz login użytkownika, którego chcesz dodać lub usunąć:" Font-Size="24px" ></asp:Label>
        <div style="margin-top: 20px; width: 2000px;">
            <asp:Label ID="LoginLabel" runat="server" Text="Login:  " Font-Size="20px"></asp:Label>
            <asp:TextBox ID="LoginBox" runat="server" style="width: 250px; height: 20px; font-size: 16px;" AutoPostBack="True" OnTextChanged="LoginBoxChanged"></asp:TextBox>
        </div>
    <div style="margin-top: 20px; width: 2020px;">
        <asp:Button ID="ConfirmDeleteButton" runat="server" Text="Potwierdź" style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmDeleteClick" Visible="false"/>
        <asp:Button ID="AddUserButton" runat="server" Text="Dodaj" OnClick="AddClick" style="width: 150px; height: 40px; font-size: 20px;" Enabled="False" />
        <asp:Button ID="DeleteUserButton" runat="server" Text="Usuń" OnClick="DeleteClick" style="width: 150px; height: 40px; font-size: 20px;" Enabled="False" />
        <asp:Label ID="NameLabel" runat="server" Text="Imię:  " Font-Size="20px" Visible="False"></asp:Label>
        <asp:TextBox ID="NameBox" runat="server" style="width: 250px; height: 20px; font-size: 16px;" Visible="false"></asp:TextBox>
    </div>
    <div style="margin-top: 20px; width: 1960px;">
        <asp:Label ID="SurnameLabel" runat="server" Text="Nazwisko:  " Font-Size="20px" Visible="False"></asp:Label>
        <asp:TextBox ID="SurnameBox" runat="server" style="width: 250px; height: 20px; font-size: 16px;" Visible="false"></asp:TextBox>
    </div>
    <div style="margin-top: 20px; width: 2000px;">
        <asp:Label ID="PasswordLabel" runat="server" Text="Hasło:  " Font-Size="20px" Visible="False"></asp:Label>
        <asp:TextBox ID="PasswordBox" runat="server" style="width: 250px; height: 20px; font-size: 16px;" Visible="false"></asp:TextBox>
    </div>
        <div style="margin-top: 20px; width: 2000px;">
            <asp:Label ID="GroupLabel" runat="server" Text="Grupa:  " Font-Size="20px" Visible="False"></asp:Label>
            <asp:TextBox ID="GroupBox" runat="server" style="width: 250px; height: 20px; font-size: 16px;" Visible="false"></asp:TextBox>
            <div style="margin-top: 20px; width: 2020px">
            <asp:Button ID="ConfirmAddButton" runat="server" Text="Zatwierdź" style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmAddClick" Visible="false"/>
            </div>
    </div>
    </div>    

</asp:Content>