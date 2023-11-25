<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EdukuJez.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="MainTable" runat="server" CellSpacing="20" CssClass="Center-Form">
         <asp:TableRow>
                    <asp:TableCell>
                        <asp:Panel ID="Panel1" CssClass="Main-Panel" runat="server" BackColor="#808000" BorderColor="Black" BorderStyle="Double">
                            <asp:Panel ID="Panel2" CssClass="Main-Label-Panel" runat="server">Przedmioty</asp:Panel>
                            <asp:Image ID="Image1" CssClass="Main-Panel-Image" runat="server" ImageUrl="~/Imgs/Arrow_left.png" />
                        </asp:Panel>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Panel ID="Panel3" CssClass="Main-Panel" runat="server" BackColor="#D2691E" BorderColor="Black" BorderStyle="Double">
                            <asp:Panel ID="Panel4" CssClass="Main-Label-Panel" runat="server">Ogłoszenia</asp:Panel>
                            <asp:Image ID="Image2" CssClass="Main-Panel-Image" runat="server" ImageUrl="~/Imgs/Arrow_left.png" />
                        </asp:Panel>
                    </asp:TableCell>
         </asp:TableRow>
        <asp:TableRow>
                    <asp:TableCell>
                        <asp:Panel ID="Panel5" CssClass="Main-Panel" runat="server" BackColor="#996515" BorderColor="Black" BorderStyle="Double">
                            <asp:Panel ID="Panel6" CssClass="Main-Label-Panel" runat="server">Plan Zajęć</asp:Panel>
                            <asp:Image ID="Image3" CssClass="Main-Panel-Image" runat="server" ImageUrl="~/Imgs/Arrow_left.png" />
                        </asp:Panel>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Panel ID="Panel7" CssClass="Main-Panel" runat="server" BackColor="#DAA520" BorderColor="Black" BorderStyle="Double">
                            <asp:Panel ID="Panel8" CssClass="Main-Label-Panel" runat="server">Wiadomości</asp:Panel>
                            <asp:Image ID="Image4" CssClass="Main-Panel-Image" runat="server" ImageUrl="~/Imgs/Arrow_left.png" />
                        </asp:Panel>
                    </asp:TableCell>
         </asp:TableRow>

    </asp:Table>
    

</asp:Content>
