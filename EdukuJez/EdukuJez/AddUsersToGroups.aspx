<%@ Page Title="Accounts In Groups Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsersToGroups.aspx.cs" Inherits="EdukuJez.AddUsersToGroups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
                       <asp:Button ID="GoBackButton" runat="server" Text="Panel Administratora" Style="margin-top: 12px; width: 170px; height: 60px; font-size: 20px; float: left; white-space: normal;" OnClick="GoBackButton_Click" CssClass="Main-Panel-Image" ForeColor="Black" EnableTheming="True"/>
        <img src="Imgs/Users_In_Groups_Management_Title.png" class="logo1" style="height: 82px; width: 880px" />
             <asp:Button ID="x" runat="server" Text=" " Style="width: 250px; height: 40px; font-size: 20px; float: right;" BackColor="#FEFAE0" BorderColor="#FEFAE0" BorderStyle="None" />
        <hr />
    </div>
    <div>
        <asp:Label ID="MainInfoLabel" runat="server" Text="Wybierz grupę, do której chcesz dodać, lub z której chcesz usunąć użytkownika:" Font-Size="28px"></asp:Label>
        <div style="margin-top: 20px; width: 2000px;">
            <asp:Panel ID="LabelsPanel" runat="server" Style="display: inline-block;">
                <asp:Label ID="UserLabel" runat="server" Text="Użytkownik:" Font-Size="24px" Style="display: block; margin-bottom: 20px;"></asp:Label>
                <asp:Label ID="CurrentGroups" runat="server" Text="Obecne grupy:" Font-Size="24px" Style="display: block; margin-bottom: 20px;"></asp:Label>
                <asp:Label ID="PossibleGroups" runat="server" Text="Grupy możliwe do przypisania:" Font-Size="24px" Style="display: block; margin-bottom: 20px;"></asp:Label>
                </asp:Panel>

            <asp:Panel ID="TextBoxesPanel" runat="server" Style="display: inline-block;">
                <asp:DropDownList ID="UsersBox" runat="server" Style="display: block; margin-bottom: 20px; width: 255px; height: 30px; font-size: 16px;" AutoPostBack="true" OnSelectedIndexChanged="UsersGroupsListSelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="CurrentGroupsBox" runat="server" Style="display: block; margin-bottom: 20px; width: 255px; height: 30px; font-size: 16px;"></asp:DropDownList>
                <asp:DropDownList ID="PossibleGroupsBox" runat="server" Style="display: block; margin-bottom: 20px; width: 255px; height: 30px; font-size: 16px;"></asp:DropDownList>

            </asp:Panel>

            <asp:Panel ID="ButtonsPanel" runat="server" Style="display: inline-block;">
                <asp:Label ID="ph" runat="server" Text=" " Font-Size="24px" Style="display: block; margin-bottom: 20px;"></asp:Label>
                <asp:Button ID="DeleteUserFromGroupButton" runat="server" Text="Usuń" OnClick="DeleteClick" Style="display: block; margin-bottom: 10px; width: 150px; height: 40px; font-size: 20px;"/>
                <asp:Button ID="AddUserToGroupButton" runat="server" Text="Dodaj" OnClick="AddClick" Style="display: block; width: 150px; height: 40px; font-size: 20px;"/>
             
            </asp:Panel>

        </div>

        <div style="margin-top: 20px; width: 2020px;">
            <asp:Label ID="ConfirmInfoLabel" runat="server" Text="" Font-Size="28px"></asp:Label>
            </div>
        <div style="margin-top: 20px; width: 2020px">
            <asp:Button ID="CancelButton" runat="server" Text="Anuluj" Style="width: 150px; height: 40px; font-size: 20px;" OnClick="CancelClick" Visible="false" />
            <asp:Button ID="ConfirmAddButton" runat="server" Text="Potwierdź" Style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmAddClick" Visible="false" />
        <asp:Button ID="ConfirmDeleteButton" runat="server" Text="Potwierdź" Style="width: 150px; height: 40px; font-size: 20px;" OnClick="ConfirmDeleteClick" Visible="false" />

        </div>
        <div style="margin-top: 20px; width: 2020px">
            <asp:Label ID="InfoLabel" runat="server" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
        </div>
    </div>

</asp:Content>