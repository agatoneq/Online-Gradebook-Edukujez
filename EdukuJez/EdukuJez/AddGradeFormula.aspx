<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGradeFormula.aspx.cs" Inherits="EdukuJez.AddGradeFormula" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Center-Form">
        <asp:Label ID="Label1" runat="server" Text="Nowa Formuła" Font-Size="Larger"></asp:Label>
        <br><br>
        <asp:Label ID="Label3" runat="server" Text="Przedmiot"></asp:Label>
        <br><br>
        <asp:DropDownList ID="SubjectDropDownList" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="SubjectDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br>
        <asp:Label ID="Label4" runat="server" Text="Nazwa"></asp:Label>
        <br />
        <asp:TextBox ID="NameTextBox" runat="server" Width="141px"></asp:TextBox>
        <br />
        <br>
        <asp:Label ID="Label2" runat="server" Text="Aktywności"></asp:Label>
        <br>
        <asp:DropDownList ID="ActivtyDropDownList" runat="server" Width="150px"></asp:DropDownList><asp:Button ID="ButtonActivity" runat="server" Text="Dodaj do formuły" OnClick="ButtonActivity_Click" />
        <br><br>
        <asp:TextBox ID="MainTextBox" runat="server" Height="92px" Width="266px" TextMode="MultiLine"></asp:TextBox>
        <br><br>
        <asp:Button ID="ButtonAdd" runat="server" Text="Zatwierdź" OnClick="ButtonAdd_Click" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Anuluj" Width="75px" OnClick="ButtonCancel_Click" />
    </div>


</asp:Content>
