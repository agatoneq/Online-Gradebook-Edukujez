<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectAddAdminPanel.aspx.cs" Inherits="EdukuJez.SubjectAddAdminPanel" %>
<asp:Content ID="MainContentID" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <asp:Button ID="GoBackButton" runat="server" Text="Panel Administratora" Style="margin-top: 12px; width: 170px; height: 60px; font-size: 20px; float: left; white-space: normal;" OnClick="GoBackButton_Click" CssClass="Main-Panel-Image" ForeColor="Black" EnableTheming="True"/>
        <img src="Imgs/Subjects_Management_Page_Title.png" class="logo1" style="height: 82px; width: 650px" />
                    <asp:Button ID="Button1" runat="server" Text=" " Style="width: 250px; height: 40px; font-size: 20px; float: right;" BackColor="#FEFAE0" BorderColor="#FEFAE0" BorderStyle="None" />
         <hr />
    </div>
       <p align="center">
       <asp:Label ID="LabelSubjectName" runat="server" Text="Nazwa przedmiotu: " Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
       <asp:TextBox ID="TextBoxSubjectName" runat="server" MaxLength="100" Style="display: block; margin-bottom: 10px; width: 250px; height: 25px; font-size: 16px;"></asp:TextBox>
   </p>   
    <br />
    <p align="center">
        <asp:Label ID="LabelDescription" runat="server" Text="Opis przedmiotu: " Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
        <asp:TextBox ID="TextBoxSubjectDescription" runat="server" TextMode="MultiLine" Style="display: block; margin-bottom: 10px; width: 250px; height: 100px; font-size: 16px;" Rows="5"></asp:TextBox>
    </p>
    <br />
    <p align="center">
        <asp:Label ID="LabelStudentsGroup" runat="server" Text="Grupa uczniów:" Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
        <asp:DropDownList ID="DropDownListStudents" runat="server" style="width: 255px; height: 30px; font-size: 16px;"></asp:DropDownList>
    </p>
    <p align="center">
        <asp:Label ID="LabelTeachersGroup" runat="server" Text="Grupa nauczycieli:"  Font-Size="24px" Style="display: block; margin-bottom: 10px;"></asp:Label>
        <asp:DropDownList ID="DropDownListTeachers" runat="server" style="width: 255px; height: 30px; font-size: 16px;"></asp:DropDownList>
        <br />
        <br />
    </p>
    <br />
    <p align="center">
        <asp:Button ID="ButtonSubjectAccept"  runat="server" Text="Dodaj przedmiot" OnClick="ButtonSubjectAccept_Click" Style="width: 200px; height: 40px; font-size: 20px;" />
        <asp:Button ID="ButtonSubjectCancel"  runat="server" Text="Anuluj" OnClick="ButtonSubjectCancel_Click" Style="width: 200px; height: 40px; font-size: 20px;" />
    </p>
            <div style="margin-top: 20px; width: 2000px; text-align: center;">
            <asp:Label ID="LabelInfo" runat="server" Text="Label" Visible="False" Font-Size="24px" ForeColor="#CC0000"></asp:Label>
    </div>
</asp:Content>

