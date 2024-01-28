<%@ Page Title="Plan Lekcji" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LessonPlan.aspx.cs" Inherits="EdukuJez.LessonPlan" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Lesson_Plan_Title.png" class="logo1" style="height: 82px; width: 480px" />
        <hr />
    </div>
        <div>
            <asp:Table ID="LessonTable" runat="server" CssClass="LessonPlan"></asp:Table>
        </div>
    <asp:DropDownList ID="GroupDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GroupSelectionChanged">
    <asp:ListItem Text="-- Wybierz grupę --" Value="" />
    </asp:DropDownList>

    <div class="Center-Form">
            <asp:Repeater ID="myRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th>Dzień Tygodnia</th>
                            <th>Przedmiot</th>
                            <th>Prowadzący</th>
                            <th>Prowadzący</th>
                            <th>Sala</th>
                            <th>Godzina</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Day") %></td>
                        <td><%# Eval("SubjectName") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Surname") %></td>
                        <td><%# Eval("Class") %></td>
                        <td><%# Eval("Hour") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    

</asp:Content>
