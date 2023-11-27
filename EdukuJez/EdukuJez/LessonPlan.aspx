<%@ Page Title="Plan Lekcji" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LessonPlan.aspx.cs" Inherits="EdukuJez.LessonPlan" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Table ID="LessonTable" runat="server" CssClass="LessonPlan"></asp:Table>
        </div>
    <asp:Table ID="MainTable" runat="server" CellSpacing="20" CssClass="Center-Form  Main-Table">
         

    </asp:Table>
    

</asp:Content>
