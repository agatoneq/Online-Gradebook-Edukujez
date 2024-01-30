<%@ Page Title="Obecności" Language="C#" AutoEventWireup="true" CodeBehind="AttendanceAdminPanel.aspx.cs" Inherits="EdukuJez.AttendanceAdminPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <h2>Obecności</h2>
        <hr />
    </div>

    <div>
        <asp:DropDownList ID="GroupsDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GroupsDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="StudentsDropDown" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="PresenceDropDown" runat="server">
            <asp:ListItem Text="Obecny" Value="obecny" />
            <asp:ListItem Text="Nieobecny" Value="nieobecny" />
        </asp:DropDownList>

        <asp:Button ID="AddAttendanceButton" runat="server" Text="Dodaj Obecność" OnClick="AddAttendanceButton_Click" />

        <asp:ListBox ID="ListBoxAllAttendances" runat="server" Width="300px" Height="200px"></asp:ListBox>
    </div>
</asp:Content>
