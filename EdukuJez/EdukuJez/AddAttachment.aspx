<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAttachment.aspx.cs" Inherits="EdukuJez.AddAttachment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <p align="center">
       <asp:Label ID="LabelAttachmentName" runat="server" Text="Nazwa materiału: " Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
       <asp:TextBox ID="TextBoxAttachmentName" runat="server" MaxLength="100" Style="display: block; margin-bottom: 10px; width: 250px; height: 25px; font-size: 16px;"></asp:TextBox>
   </p>   
    <br />
    <p align="center">
        <asp:Label ID="LabelAttachmentContentType" runat="server" Text="Kategoria:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
        <asp:DropDownList ID="DropDownListAttachmentContentType" runat="server" MaxLength="100" style="width: 255px; height: 30px; font-size: 16px;" AutoPostBack="True" OnSelectedIndexChanged="DropDownListAttachmentContentType_SelectedIndexChanged"></asp:DropDownList>
    </p>
    <p align="center">
        <asp:Label ID="LabelAttachmentLink" runat="server" Text="Link:"  Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
        <asp:TextBox ID="TextBoxAttachmentLink" runat="server" MaxLength="100" Style="display: block; margin-bottom: 10px; width: 250px; height: 25px; font-size: 16px;"></asp:TextBox>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
    </p>
    <br />
    <p align="center">
        <asp:Button ID="ButtonAttachmentAccept"  runat="server" Text="Dodaj materiał"  Style="width: 200px; height: 40px; font-size: 20px;" OnClick="ButtonAttachmentAccept_Click" />
        <asp:Button ID="ButtonAttachmentCancel"  runat="server" Text="Anuluj"  Style="width: 200px; height: 40px; font-size: 20px;" OnClick="ButtonAttachmentCancel_Click" />
    </p>
            <div style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Label ID="LabelInfo" runat="server" Text="Label" Visible="False" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>
