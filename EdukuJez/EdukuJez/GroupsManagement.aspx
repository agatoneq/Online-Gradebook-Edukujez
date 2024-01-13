<%@ Page Title="Zarządzanie grupami" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupsManagement.aspx.cs" Inherits="EdukuJez.GroupsManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Groups_Management_Page_Title.png" class="logo1" style="height: 82px; width: 800px" />
        <hr />
    </div>
        <asp:Label ID="MainInfoLabel" runat="server" Text="Dodaj lub usuń nową grupę podrzędną:" Font-Size="28px"></asp:Label>
    

        <div style="margin-top: 20px; width: 2000px;">
            <asp:Panel ID="LabelsPanel" runat="server" Style="display: inline-block;">
                <asp:Label ID="NameLabel" runat="server" Text="Nazwa:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
               <asp:Label ID="MainGroupLabel" runat="server" Text="Grupa nadrzędna:" Font-Size="24px" Style="display: block; margin-bottom: 10px;" Visible="false"></asp:Label>
                <asp:Label ID="EducatorLabel" runat="server" Text="Wychowawca:" Font-Size="24px" Style="display: block; margin-bottom: 10px;" Visible="false"></asp:Label>
                </asp:Panel>

            <asp:Panel ID="TextBoxesPanel" runat="server" Style="display: inline-block;">
                <asp:TextBox ID="NewGroupTextBox" runat="server" Style="display: block; margin-bottom: 10px; width: 250px; height: 25px; font-size: 16px;" AutoPostBack="true" OnTextChanged="NameGroupBoxChanged"></asp:TextBox>
                <asp:DropDownList ID="MainGroupList" runat="server" Style="display: block; margin-bottom: 10px; width: 255px; height: 30px; font-size: 16px;" AutoPostBack="true" OnSelectedIndexChanged="MainGroupListSelectedIndexChanged" Visible="false"></asp:DropDownList>
                <asp:DropDownList ID="TeachersList" runat="server" Style="display: block; margin-bottom: 10px; width: 255px; height: 30px; font-size: 16px;" Visible="false"></asp:DropDownList>
                </asp:Panel>
            <br/>
            <asp:Button  ID="AddNewGroupButton" runat="server" Text="Dodaj" Style="width: 150px; height: 40px; font-size: 20px;" Enabled="False" OnClick="AddNewGroupButton_Click"/>
            <asp:Button  ID="DeleteGroupButton" runat="server" Text="Usuń" Style="width: 150px; height: 40px; font-size: 20px;" Enabled="False" OnClick="DeleteGroupButton_Click"/>
            </div>
        <div style="margin-top: 20px; width: 2020px;">
            <asp:Button ID="RestartButton" runat="server" Text="Zatwierdź" Style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmRestartClick" Visible="false" />
            <asp:Button ID="ConfirmDeleteButton" runat="server" Text="Potwierdź" Style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmDeleteClick" Visible="false" />
            </div>



    <div class="Center-Form" style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Repeater ID="myRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th>Id</th>
                            <th>Nazwa</th>
                            <th>Grupa nadrzędna</th>
                            <th>Wychowawca</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("ParentGroup.Name") ?? "brak" %></td>
                        <td><%# Eval("Educator") != null ? string.Format("{0} {1}", Eval("Educator.UserName") ?? "brak", Eval("Educator.UserSurname") ?? "brak") : "brak" %></td>
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
