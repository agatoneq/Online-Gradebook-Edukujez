<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChildForParent.aspx.cs" Inherits="EdukuJez.ChildForParent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-bottom: 30px;" class="header Container-Title ">
                       <asp:Button ID="GoBackButton" runat="server" Text="Panel Administratora" Style="margin-top: 12px; width: 170px; height: 60px; font-size: 20px; float: left; white-space: normal;" OnClick="GoBackButton_Click" CssClass="Main-Panel-Image" ForeColor="Black" EnableTheming="True"/>
        <img src="Imgs/Child_To_Parent_Management_Title.png" class="logo1" style="height: 82px; width: 1400px" />
             <asp:Button ID="x" runat="server" Text=" " Style="width: 250px; height: 40px; font-size: 20px; float: right;" BackColor="#FEFAE0" BorderColor="#FEFAE0" BorderStyle="None" />
        <hr />
    </div>
    <asp:Label ID="TopicLabelGet" runat="server" Text="Wybierz Rodzica"></asp:Label>
    <asp:DropDownList ID="DropDownListParent" runat="server"   style="width: 100px; height: 30px; margin-right: 50px;" ></asp:DropDownList>
    <asp:DropDownList ID="DropDownListChild" runat="server" style="width: 100px; height: 30px;" ></asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text="Wybierz Dziecko" ></asp:Label>
    <br />



        <br />
    <asp:Button ID="ButtonMarge" runat="server" Text="Przydziel" OnClick="MargeChildToParent" style="margin-right: 50px;"/>
    <asp:Button ID="ButtonDestroy" runat="server" Text="Rozłącz" OnClick="DestroyChildToParent" />
</asp:Content>

