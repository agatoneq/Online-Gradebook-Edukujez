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
            <asp:Button ID="NewAttachmentButton" runat="server" Text="Dodaj Materiały" OnClick="NewAttachmentButton_Click" Width="118px" Visible="False" />
            <asp:Button ID="DelAttachmentButton" runat="server" Text="Usuń materiał" Width="98px" OnClick="DelAttachmentButton_Click" Visible="False" />
            <asp:DropDownList ID="AttachmentDropDownList" runat="server" Width="121px" Visible="False">
            </asp:DropDownList>
        </asp:Panel>
        <hr/>
        <asp:Panel ID="ActivitesPanel" runat="server" CssClass="Subject-Panel">
            <asp:Label ID="ActivitesLabel" runat="server" Text="Aktywności" CssClass="Subject-Label"></asp:Label>
            <asp:Table ID="ActivitesTable" runat="server"></asp:Table>
            <asp:Button ID="NewActivityButton" runat="server" Text="Dodaj aktywność" OnClick="NewActivityButton_Click" Width="115px" Visible="False" />
            <asp:Button ID="DelActivityButton" runat="server" Text="Usuń aktywność" Width="98px" OnClick="DelActivityButton_Click" Visible="False" />
            <asp:DropDownList ID="ActivityDropDownList" runat="server" Width="121px" Visible="False">
            </asp:DropDownList>
        </asp:Panel>
        <hr/>
        <asp:Button ID="GoBackButton" runat="server" Text="Powrót"  Width="115px" OnClick="GoBackButton_Click" />
    </div>
</asp:Content>
