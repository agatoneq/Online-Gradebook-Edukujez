<%@ Page Title="Obecności" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendances.aspx.cs" Inherits="EdukuJez.Attendance" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Attendance_Title.png" class="logo1" style="height: 82px; width: 485px" />
        <hr />
    </div>
    <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="true">
    <div class="Center-Form">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Data" SortExpression="Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="SubjectName" HeaderText="Przedmiot" SortExpression="SubjectName" />
                <asp:TemplateField HeaderText="Nauczyciel">
                    <ItemTemplate>
                        <%# Eval("TeacherName") %> <%# Eval("TeacherSurname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Presence" HeaderText="Obecność" SortExpression="Presence" />
            </Columns>
        </asp:GridView>

        <asp:Repeater ID="myRepeater" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <th>Data</th>
                        <th>Przedmiot</th>
                        <th>Nauczyciel</th>
                        <th>Obecność</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Date", "{0:yyyy-MM-dd}") %></td>
                    <td><%# Eval("SubjectName") %></td>
                    <td><%# Eval("TeacherName") %> <%# Eval("TeacherSurname") %></td>
                    <td><%# Eval("Presence") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
