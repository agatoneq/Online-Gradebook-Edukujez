<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadMessage.aspx.cs" Inherits="EdukuJez.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div>
                <asp:Panel ID="TextBoxesPanel" runat="server" Style="display: inline-block; vertical-align: top;">

            <asp:Button ID="ButtonReadGet" runat="server" Text="Czytaj" OnClick="btnCzytaj_Click" />
              <asp:Button ID="ButtonReadSend" runat="server" Text="CzytajWys" OnClick="btnCzytajWys_Click" />
            </br>
             <asp:Label ID="TopicLabelGet" runat="server" Text="Wybierz Wiadomosc" Visible="false"></asp:Label>
              <asp:Label ID="TopicLabelSend" runat="server" Text="Wybierz Wiadomosc" Visible="false"></asp:Label>
<asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
              </br>
            <asp:TextBox ID="TextBox" runat="server" Text="Tutaj jest wiadomosc" ReadOnly="true" TextMode="MultiLine" Style="display: block; margin-top: 10px; width: 1000px; height:500px; font-size: 16px; overflow: auto;" AutoPostBack="false" Visible="false"></asp:TextBox>
    </asp:Panel>


            </asp:Panel>
        </div>
            </asp:Panel>
</asp:Content>
