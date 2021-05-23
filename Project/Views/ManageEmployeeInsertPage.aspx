<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdministratorNavigation.Master" AutoEventWireup="true" CodeBehind="ManageEmployeeInsertPage.aspx.cs" Inherits="Project.Views.ManageEmployeeInsertPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Employee Insert Page</h1>
    </div>
    <div>
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="TextBoxEmail" TextMode="Email" runat="server" />
        <asp:Label ID="LabelMessageEmail" Text="" runat="server" />
        <br />
        <asp:Label Text="Password" runat="server" />
        <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" />
        <asp:Label ID="LabelMessagePassword" Text="" runat="server" />
        <br />
        <asp:Label Text="Name" runat="server" />
        <asp:TextBox ID="TextBoxName" runat="server" />
        <asp:Label ID="LabelMessageName" Text="" runat="server" />
        <br />
        <asp:Label Text="Date of Birth" runat="server" />
        <asp:TextBox ID="TextBoxDOB" TextMode="Date" runat="server" />
        <asp:Label ID="LabelMessageDOB" Text="" runat="server" />
        <br />
        <asp:Label Text="Gender" runat="server" />
        <asp:DropDownList ID="DropDownListGender" runat="server">
            <asp:ListItem Value="other">Other</asp:ListItem>
            <asp:ListItem Value="male">Male</asp:ListItem>
            <asp:ListItem Value="female">Female</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LabelMessageGender" Text="" runat="server" />
        <br />
        <asp:Label Text="Phone Number" runat="server" />
        <asp:TextBox ID="TextBoxPhoneNumber" runat="server" />
        <asp:Label ID="LabelMessagePhoneNumber" Text="" runat="server" />
        <br />
        <asp:Label Text="Address" runat="server" />
        <asp:TextBox ID="TextBoxAddress" runat="server" />
        <asp:Label ID="LabelMessageAddress" Text="" runat="server" />
        <br />
        <asp:Label Text="Salary" runat="server" />
        <asp:TextBox ID="TextBoxSalary" runat="server" />
        <asp:Label ID="LabelMessageSalary" Text="" runat="server" />
        <br />
        <asp:Label Text="Role" runat="server" />
        <asp:DropDownList ID="DropDownListRole" runat="server">
            <asp:ListItem Value="staff">Staff (Basic Employee)</asp:ListItem>
            <asp:ListItem Value="admin">Admin (Special Employee)</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="LabelMessageStatus" Text="" runat="server" />
        <br />
        <asp:Button ID="ButtonInsert" Text="Insert" runat="server" OnClick="ButtonInsert_Click" />
    </div>
</asp:Content>
