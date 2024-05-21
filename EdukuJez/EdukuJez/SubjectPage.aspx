<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectPage.aspx.cs" Inherits="EdukuJez.SubjectPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Subjects_Title.png" class="logo1" style="height: 82px; width: 340px" />
        <hr />
    </div>
    <div style="text-align:center;">
    <asp:ListBox ID="ListBoxSubjects" runat="server" style="width: 350px; height: 400px; font-size: 20px;"></asp:ListBox>
    <br />
    <asp:Button ID="ButtonSubjectShow"  runat="server" Text="Wyświetl" Style="width: 200px; height: 40px; font-size: 20px;" OnClick="ButtonSubjectShow_Click" />
     <br />
    <asp:Button ID="GoBackButton" runat="server" Text="Powrót"  Style="width: 200px; height: 40px; font-size: 20px;" OnClick="GoBackButton_Click" />
    </div>
    <div style="margin-top: 20px; width: 2000px; text-align: center;">
        <asp:Label ID="LabelInfo" runat="server" Text="Label" Visible="False" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
