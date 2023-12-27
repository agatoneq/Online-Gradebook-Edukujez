<%@ Page Title="Zarządzanie grupami" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupsManagement.aspx.cs" Inherits="EdukuJez.GroupsManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Groups_Management_Page_Title.png" class="logo1" style="height: 82px; width: 720px" />
        <hr />
    </div>
        <asp:Label ID="MainInfoLabel" runat="server" Text="Dodaj lub usuń nową grupę podrzędną:" Font-Size="28px"></asp:Label>
        <div style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Label ID="NameLabel" runat="server" Text="Nazwa:" Font-Size="24px"></asp:Label>
            <asp:TextBox ID="NewGroupTextBox" runat="server" Style="width: 250px; height: 25px; font-size: 16px;"></asp:TextBox>
        </div>
        <div style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Label ID="MainGroupLabel" runat="server" Text="Grupa nadrzędna:" Font-Size="24px"></asp:Label>
            <asp:DropDownList ID="MainGroupList" runat="server" Style="width: 250px; height: 25px; font-size: 16px;"></asp:DropDownList>
        </div>
        <div style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Button  ID="NewGroupButton" runat="server" Text="Dodaj nową" Style="width: 300px; height: 40px; font-size: 20px;" OnClick="NewGroupButton_Click" />
        </div>
    <div class="Center-Form" style="margin-top: 20px; width: 2000px; text-align: center;">
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
           
            <br />
            <asp:Button  />
        </div>
    </asp:Content>
