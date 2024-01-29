<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activities.aspx.cs" Inherits="EdukuJez.Activities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <asp:Label ID="NameLabel" runat="server" Text="Nazwa: *"></asp:Label><br>
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    <br><br>
    <asp:Label ID="GroupLabel" runat="server" Text="Grupa: *"></asp:Label><br>
    <asp:DropDownList ID="GroupDropDownList" runat="server"></asp:DropDownList>
    <br><br>
    <asp:Label ID="SubjectLabel" runat="server" Text="Przedmiot: *"></asp:Label><br>
    <asp:DropDownList ID="SubjectDropDownList" runat="server" ></asp:DropDownList>
    <br><br>
    <asp:Label ID="WitghtLabel" runat="server" Text="Waga oceny: *"></asp:Label><br>
    <asp:TextBox ID="WeightTextBox" runat="server"></asp:TextBox>
    <br><br>
    <asp:Label ID="TypeLabel" runat="server" Text="Typ oceny: *"></asp:Label><br>
    <asp:DropDownList ID="TypeDropDownList" runat="server">
        <asp:ListItem>Skala nominalna</asp:ListItem>
        <asp:ListItem Value="Skala procentowa"></asp:ListItem>
    </asp:DropDownList>
    <br><br>
    <asp:CheckBox ID="ISFinalCheckBox1" runat="server" Text="Aktywność jest oceną końcową" OnCheckedChanged="ISFinalCheckBox1_CheckedChanged" AutoPostBack="True" /><br>
    <asp:DropDownList ID="FormulaDropDownList" runat="server" Visible="false"></asp:DropDownList>
    <asp:Button ID="FormulaButton" runat="server" Text="Nowa formuła" Visible="false" OnClick="FormulaButton_Click"/>
    <br><br>
    <asp:Button ID="DodajButton" runat="server" Text="Dodaj aktywność" OnClick="DodajButton_Click" />
    <asp:Button ID="AnulujButton" runat="server" Text="Anuluj" OnClick="AnulujButton_Click" />
    <br><br>
    
</asp:Content>