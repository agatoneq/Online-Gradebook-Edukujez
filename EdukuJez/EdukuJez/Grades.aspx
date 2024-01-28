<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grades.aspx.cs" Inherits="EdukuJez.Grades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Grades_Title.png" class="logo1" style="height: 82px; width: 500px" />
        <hr />
    </div>
    
    <asp:DropDownList ID="GroupDropDownList" runat="server" OnSelectedIndexChanged="GroupDropDownList_SelectedIndexChanged">

    </asp:DropDownList> 
    <asp:DropDownList ID="SubjectsDropDownList" runat="server" OnSelectedIndexChanged="SubjectsDropDownList_SelectedIndexChanged">

    </asp:DropDownList>  

    <asp:Button ID="ShowButton" runat="server" Text="Pokaż" OnClick="ShowButton_Click" /> 
    <asp:Button ID="EditButton" runat="server" Text="Edytuj oceny" OnClick="EditButton_Click" Visible ="false"/>
   
    <asp:GridView ID="GradesGridView"  CssClass="Center-Form" runat="server"  Visible ="false" OnRowCancelingEdit="GradesGridView_RowCancelingEdit" OnRowEditing="GradesGridView_RowEditing" OnRowUpdating="GradesGridView_RowUpdating"></asp:GridView>
    <asp:Button ID="AddButton" runat="server" Text="Anuluj zmiany"  Visible="false" /> 
    <asp:Button ID="SaveButton" runat="server" Text="Zapisz zmiany"  Visible="false" />
</asp:Content>