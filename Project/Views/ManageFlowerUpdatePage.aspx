<%@ Page Title="" Language="C#" MasterPageFile="~/Views/EmployeeNavigation.Master" AutoEventWireup="true" CodeBehind="ManageFlowerUpdatePage.aspx.cs" Inherits="Project.Views.ManageFlowerUpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Flower Insert Page</h1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>
        <asp:DropDownList ID="DropDownListType" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="TextBoxPrice" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Upload picture"></asp:Label>
        <asp:FileUpload ID="FileUploadImage" runat="server" />
        <br />
        <asp:Label ID="LabelMessageStatus" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
    </div>
</asp:Content>
