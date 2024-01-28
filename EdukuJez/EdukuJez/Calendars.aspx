<%@ Page Title="Kalendarz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendars.aspx.cs" Inherits="EdukuJez.Calendars" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Table ID="Calendar" runat="server" CssClass="Calendars"></asp:Table>
        </div>
    <div class="Center-Form">
            <asp:Repeater ID="myRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th>Data</th>
                            <th>Opis</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Date") %></td>
                        <td><%# Eval("Desc") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    

</asp:Content>
