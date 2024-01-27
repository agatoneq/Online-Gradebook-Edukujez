<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WriteMessage.aspx.cs" Inherits="EdukuJez.WriteMessage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
    <div style="margin-top: 20px; width: 2000px;">
        <asp:Panel ID="LabelsPanel" runat="server" Style="display: inline-block; vertical-align: top;">
            <asp:Label ID="Label1" runat="server" Text=" Adresat:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text=" Temat:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text=" Treść:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
        </asp:Panel>


        <asp:Panel ID="TextBoxesPanel" runat="server" Style="display: inline-block; vertical-align: top;">
            <asp:TextBox ID="NameBox" runat="server" Style="display: inline-block; width: 350px; height: 25px; font-size: 16px;" AutoPostBack="false"></asp:TextBox>
            <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="true">

            </asp:DropDownList>
            <br />
            <asp:TextBox ID="TopicBox" runat="server" Style="display: block; margin-top: 10px; width: 350px; height: 25px; font-size: 16px;" AutoPostBack="false"></asp:TextBox>
            <asp:TextBox ID="MessageBox" runat="server" TextMode="MultiLine" Style="display: block; margin-top: 10px; width: 350px; height:350px; font-size: 16px; overflow: auto;" AutoPostBack="false"></asp:TextBox>
        </asp:Panel>
        <br />
                <asp:Button ID="SubmitButton" runat="server" Text="Wyślij" Style="margin-top: 10px;" OnClick="SendMessage" />

        <br />
        <br />
        <asp:Label ID="InfoLabel" runat="server" Text="" Visible="true"></asp:Label>
    </div>
                 </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>