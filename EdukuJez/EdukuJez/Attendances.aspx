<%@ Page Title="Obecności" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendances.aspx.cs" Inherits="EdukuJez.Attendances" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <h2>Obecności</h2>
        <hr />
    </div>

    <div>
        <asp:DropDownList ID="SubjectsDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SubjectsDropDown_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:Repeater ID="attendanceRepeater" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <th>Nazwa Przedmiotu</th>
                        <th>Data</th>
                        <th>Imię</th>
                        <th>Nazwisko</th>
                        <th>Obecność</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("SubjectName") %></td>
                    <td><%# Eval("Date", "{0:dd/MM/yyyy}") %></td>
                    <td><%# Eval("TeacherName") %></td>
                    <td><%# Eval("TeacherSurname") %></td>
                    <td><%# Eval("Presence") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
