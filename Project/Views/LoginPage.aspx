<%@ Page Title="" Language="C#" MasterPageFile="~/Views/GuestNavigation.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project.Views.LoginPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Login Page</h1>
    </div>
    <div>
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="TextBoxEmail" TextMode="Email" runat="server" />
        <asp:Label ID="LabelMessageEmail" Text="" runat="server" />
        <br />
        <asp:Label Text="Password" runat="server" />
        <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" />
        <asp:Label ID="Label5" Text="" runat="server" />
        <br />
        <asp:Button ID="ButtonLogin" Text="Login" runat="server" OnClick="ButtonLogin_Click" />
    </div>
</asp:Content>
