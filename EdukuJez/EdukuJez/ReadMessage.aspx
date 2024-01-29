<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadMessage.aspx.cs" Inherits="EdukuJez.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Messages_Title.png" class="logo1" style="height: 82px; width: 350px" />
        <hr />
    </div>
    <div>
                <asp:Table ID="MainTable" runat="server" CellSpacing="20" CssClass="Center-Form  Main-Table" HorizontalAlign="Left">


    </asp:Table>
                <asp:Panel ID="TextBoxesPanel" runat="server" Style="display: inline-block; vertical-align: top;">

            <asp:Button ID="ButtonReadGet" runat="server" Text="Odebrane" OnClick="btnCzytaj_Click" />
              <asp:Button ID="ButtonReadSend" runat="server" Text="Wysłane" OnClick="btnCzytajWys_Click" />
                    <br>
                    <br></br>
                    <br></br>
                    <asp:TextBox ID="TextBox" runat="server" AutoPostBack="false" ReadOnly="true" Style="display: block; margin-top: 10px; width: 2000px; height:500px; font-size: 16px; overflow: auto;" Text="Tutaj jest wiadomosc" TextMode="MultiLine" Visible="true"></asp:TextBox>
            </br>
    </asp:Panel>


            </asp:Panel>
        </div>
            </asp:Panel>
    <asp:HiddenField ID="Hidden" runat="server" />
</asp:Content>
