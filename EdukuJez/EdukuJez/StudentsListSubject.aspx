<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsListSubject.aspx.cs" Inherits="EdukuJez.StudentsListSubject" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header Container-Title ">
        
        <hr/>
    </div>
    <div class="Center-Form" style="flex-direction: column;">

        <hr/>
        <asp:Button ID="GoBackButton" runat="server" Text="Powrót"  Style="width: 200px; height: 40px; font-size: 20px;" OnClick="GoBackButton_Click" />
    </div>
</asp:Content>

