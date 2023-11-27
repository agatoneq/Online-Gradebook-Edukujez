<%@ Page Title="Zarządzanie grupami" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupManger.aspx.cs" Inherits="EdukuJez.GroupManger" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header Container-Title ">
        <img src="Imgs/Groups_Management_Page_Title.png" class="logo"/>
        </div>
        <hr/>
    <div class="Center-Form">
        <div  style="float:left;">
            <asp:Repeater ID="myRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th>Id</th>
                            <th>Nazwa</th>
                            <th>Grupa nadrzędna</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("ParentGroup") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="float:right;">
            <asp:Label ID="Label1" runat="server" Text="Nazwa: "></asp:Label>
            <asp:TextBox ID="NewGroupTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="    Grupa nadrzędna"></asp:Label>
            <asp:DropDownList ID="PGroupDropdown" runat="server"></asp:DropDownList>
            <asp:Button ID="NewGroupButton" runat="server" Text="Dodaj nową" OnClick="NewGroupButton_Click" />
        </div>

</div>
    </asp:Content>
