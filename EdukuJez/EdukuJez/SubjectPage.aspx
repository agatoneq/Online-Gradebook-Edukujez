<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectPage.aspx.cs" Inherits="EdukuJez.SubjectPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
    <asp:ListBox ID="ListBoxSubjects" runat="server" style="width: 350px; height: 400px; font-size: 20px;"></asp:ListBox>
    <asp:Label ID="LabelSubjectName" runat="server" Text="Label" Font-Size="50px" Visible="False" Font-Bold="True"></asp:Label>
    <br />
    <asp:Label ID="LabelSubjectDesc" runat="server" Text="Label" Font-Size="30px" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="LabelMaterials" runat="server" Text="Materiały:" Font-Size="30px" Visible="False" Font-Bold="True"></asp:Label>
    <p align="center">
    <asp:Label ID="LabelLink" runat="server" Text="Link: " Font-Size="24px" Style="display: block; margin-bottom: 10px;" Visible="False"></asp:Label>
    <asp:TextBox ID="TextBoxLink" runat="server" MaxLength="100" Style="display: block; margin-bottom: 10px; width: 250px; height: 25px; font-size: 16px;" Visible="False"></asp:TextBox>
    <asp:Button ID="ButtonAddMaterials"  runat="server" Text="Dodaj materiały" Style="width: 200px; height: 40px; font-size: 20px;" OnClick="ButtonAddMaterials_Click" Visible="False" />
    </p>
    <br />
    <asp:Button ID="ButtonSubjectShow"  runat="server" Text="Wyświetl" Style="width: 200px; height: 40px; font-size: 20px;" OnClick="ButtonSubjectShow_Click" />
        <asp:Button ID="ButtonBack" runat="server" Text="Wróć" Style="width: 200px; height: 40px; font-size: 20px;" Visible="False" OnClick="ButtonBack_Click"/>
    </div>
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:Label ID="LabelInfo" runat="server" Text="Label" Visible="False" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
