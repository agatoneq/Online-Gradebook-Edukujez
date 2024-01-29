﻿<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectContentPage.aspx.cs" Inherits="EdukuJez.SubjectContentPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header Container-Title ">
        <img src="Imgs/Subjects_Title.png" class="logo"/>
        <hr/>
    </div>
    <div class="Center-Form" style="flex-direction: column;">
        <asp:Label ID="SubjectNameLabel" runat="server" Text="SubjectName" CssClass="Subject-Label"></asp:Label>
        <asp:Panel ID="AttachmentPanel" runat="server" CssClass="Subject-Panel">
            <asp:Label ID="AttachmentLabel" runat="server" Text="Materiały" CssClass="Subject-Label"></asp:Label>
            <asp:Table ID="AttachmentTable" runat="server"></asp:Table>
            <asp:Button ID="NewAttachmentButton" runat="server" Text="Dodaj Materiały" OnClick="NewAttachmentButton_Click" Width="118px" />
        </asp:Panel>
        <hr/>
        <asp:Panel ID="ActivitesPanel" runat="server" CssClass="Subject-Panel">
            <asp:Label ID="ActivitesLabel" runat="server" Text="Aktywności" CssClass="Subject-Label"></asp:Label>
            <asp:Table ID="ActivitesTable" runat="server"></asp:Table>
            <asp:Button ID="NewActivityButton" runat="server" Text="Dodaj aktywność" OnClick="NewActivityButton_Click" Width="115px" />
        </asp:Panel>
        <hr/>
    </div>
</asp:Content>
