<%@ Page Title="Changing Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangingPassword.aspx.cs" Inherits="EdukuJez.ChangingPassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Accounts_Management_Page_Title.png" class="logo1" style="height: 82px; width: 661px" />
        <hr />
    </div>
    <asp:Label ID="MainInfoLabel" runat="server" Text="Hasło zostało zmienione pomyślnie!" Visible="False" Font-Size="32px"></asp:Label>
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:Label ID="InfoPassword" runat="server" Text="Podaj obecne hasło:" Font-Size="24px"></asp:Label>
    </div>
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:TextBox ID="OldPasswordBox" runat="server" Style="width: 250px; height: 25px; font-size: 16px;"></asp:TextBox>
        <asp:TextBox ID="NewPasswordBox" runat="server" Style="width: 250px; height: 25px; font-size: 16px;" Visible="false"></asp:TextBox>
    </div>
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:Button ID="ConfirmPasswordButton" runat="server" Text="Zatwierdź" Style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmPasswordClick" />
        <asp:Button ID="ChangePasswordButton" runat="server" Text="Zmień hasło" Style="width: 150px; height: 40px; font-size: 20px;" Visible="false" OnClick="ChangePasswordClick" />
    </div>
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:Label ID="InfoLabel" runat="server" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
        <asp:Button ID="ReturnButton" runat="server" Text="Wróć do strony głównej" Style="width: 300px; height: 40px; font-size: 20px;" Visible="false" OnClick="ReturnClick" />
    </div>

</asp:Content>