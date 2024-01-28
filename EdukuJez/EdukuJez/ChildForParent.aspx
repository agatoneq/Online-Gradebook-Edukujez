<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChildForParent.aspx.cs" Inherits="EdukuJez.ChildForParent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 30px;" class="header Container-Title ">
        <img src="Imgs/Messages_Title.png" class="logo1" style="height: 82px; width: 350px" />
        <hr />
    </div>
    <asp:Label ID="TopicLabelGet" runat="server" Text="Wybierz Rodzica"></asp:Label>
    <asp:DropDownList ID="DropDownListParent" runat="server" OnSelectedIndexChanged="SelectedName" AutoPostBack="true" style="width: 100px; height: 30px; margin-right: 50px;" ></asp:DropDownList>
    <asp:DropDownList ID="DropDownListChild" runat="server" OnSelectedIndexChanged="SelectedName" AutoPostBack="true" style="width: 100px; height: 30px;" ></asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text="Wybierz Dziecko" ></asp:Label>
    </br>
      <asp:Label ID="LabelParent" runat="server" Text="Rodzic " style="margin-right: 100px;" ></asp:Label>
      <asp:Label ID="LabelChild" runat="server" Text="Dziecko" ></asp:Label>


        </br>
                <asp:Button ID="ButtonMarge" runat="server" Text="Przydziel" OnClick="MargeChildToParent" margin-right: 50px;/>
    <asp:Button ID="ButtonDestroy" runat="server" Text="Przydziel" OnClick="DestroyChildToParent" />
</asp:Content>

