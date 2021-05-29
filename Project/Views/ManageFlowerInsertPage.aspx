<%@ Page Title="" Language="C#" MasterPageFile="~/Views/EmployeeNavigation.Master" AutoEventWireup="true" CodeBehind="ManageFlowerInsertPage.aspx.cs" Inherits="Project.Views.ManageFlowerInsertPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Description {
            width: 326px;
            height: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Flower Insert Page</h1>
    </div>
    <div>
        <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Label ID="LabelMessageName" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelType" runat="server" Text="Type"></asp:Label>
        <asp:DropDownList ID="DropDownListType" runat="server">
        </asp:DropDownList>
        <asp:Label ID="LabelMessageType" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="LabelMessageDescription" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="TextBoxPrice" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="LabelMessagePrice" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelImage" runat="server" Text="Upload image"></asp:Label>
        <asp:FileUpload ID="FileUploadImage" runat="server" />
        <asp:Label ID="LabelMessageImage" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelMessageStatus" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="ButtonInsert" runat="server" Text="Insert" OnClick="ButtonInsert_Click" />
    </div>
</asp:Content>
