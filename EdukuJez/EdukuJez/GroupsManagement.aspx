<%@ Page Title="Zarządzanie grupami" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupsManagement.aspx.cs" Inherits="EdukuJez.GroupsManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Groups_Management_Page_Title.png" class="logo1" style="height: 82px; width: 720px" />
        <hr />
    </div>
        <asp:Label ID="MainInfoLabel" runat="server" Text="Dodaj lub usuń nową grupę podrzędną:" Font-Size="28px"></asp:Label>
    

        <div style="margin-top: 20px; width: 2000px;">
            <asp:Panel ID="LabelsPanel" runat="server" Style="display: inline-block;">
                <asp:Label ID="NameLabel" runat="server" Text="Nazwa:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
               <asp:Label ID="MainGroupLabel" runat="server" Text="Grupa nadrzędna:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
                <asp:Label ID="EducatorLabel" runat="server" Text="Wychowawca:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
                </asp:Panel>

            <asp:Panel ID="TextBoxesPanel" runat="server" Style="display: inline-block;">
                <asp:TextBox ID="NewGroupTextBox" runat="server" Style="display: block; margin-bottom: 10px; width: 250px; height: 25px; font-size: 16px;"></asp:TextBox>
                <asp:DropDownList ID="MainGroupList" runat="server" Style="display: block; margin-bottom: 10px; width: 255px; height: 30px; font-size: 16px;"></asp:DropDownList>
                <asp:DropDownList ID="TeachersList" runat="server" Style="display: block; margin-bottom: 10px; width: 255px; height: 30px; font-size: 16px;"></asp:DropDownList>
                </asp:Panel>
            <br/>
            <asp:Button  ID="AddNewGroupButton" runat="server" Text="Dodaj nową" Style="width: 150px; height: 40px; font-size: 20px;" Enabled="False" OnClick="DeleteGroupButton_Click" />
            <asp:Button  ID="DeleteGroupButton" runat="server" Text="Usuń" Style="width: 150px; height: 40px; font-size: 20px;" Enabled="False"  OnClick="AddNewGroupButton_Click"/>

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
