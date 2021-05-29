<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MemberNavigation.Master" AutoEventWireup="true" CodeBehind="PreOrderPage.aspx.cs" Inherits="Project.Views.PreOrderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Pre-order Page</h1>
    </div>
    <br />
    <div>
        <asp:Label ID="LabelMember" runat="server" Text="Member"></asp:Label>
        <asp:DropDownList ID="DropDownListMember" runat="server">
        </asp:DropDownList>
        <asp:Label ID="LabelMessageMember" Text="" runat="server" />
        <br />
        <asp:Label ID="LabelEmployee" runat="server" Text="Employee"></asp:Label>
        <asp:DropDownList ID="DropDownListEmployee" runat="server">
        </asp:DropDownList>
        <asp:Label ID="LabelMessageEmployee" Text="" runat="server" />
        <br />
        <asp:Label Text="Transaction Date" runat="server" />
        <asp:TextBox ID="TextBoxTransactionDate" TextMode="Date" runat="server" />
        <asp:Label ID="LabelMessageTransactionDate" Text="" runat="server" />
        <br />
        <asp:Label Text="Discount Percentage" runat="server" />
        <asp:TextBox ID="TextBoxDiscountPercentage" TextMode="Number" runat="server" />
        <asp:Label ID="LabelMessageDiscountPercentage" Text="" runat="server" />
        <br />
        <asp:Label Text="Quantity" runat="server" />
        <asp:TextBox ID="TextBoxQuantity" TextMode="Number" runat="server" />
        <asp:Label ID="LabelMessageQuantity" Text="" runat="server" />
        <br />
        <asp:Label Text="Flower Selection" runat="server" />
        <asp:GridView ID="GridViewFlowerSelection" runat="server" OnRowCommand="GridViewFlowerSelection_RowCommand" AutoGenerateColumns="False">
            <Columns>
                <asp:ButtonField CommandName="Add" ButtonType="Button" Text="Add" runat="server" />
                <asp:BoundField DataField="FlowerID" HeaderText="ID" />
                <asp:BoundField DataField="FlowerName" HeaderText="Name" />
                <asp:BoundField DataField="MsFlowerType.FlowerTypeName" HeaderText="TypeName" />
                <asp:BoundField DataField="FlowerDescription" HeaderText="Description" />
                <asp:ImageField DataImageUrlField="FlowerImage" HeaderText="Image" ControlStyle-Width="100">
                </asp:ImageField>
                <asp:BoundField DataField="FlowerPrice" HeaderText="Price" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="LabelMessageFlowerSelection" Text="" runat="server" />
        <br />
        <asp:Label Text="Transaction Detail" runat="server" />
        <asp:GridView ID="GridViewTransactionDetail" runat="server" OnRowCommand="GridViewTransactionDetail_RowCommand" AutoGenerateColumns="False">
            <Columns>
                <asp:ButtonField CommandName="Remove" ButtonType="Button" Text="Remove" runat="server" />
                <asp:BoundField DataField="FlowerID" HeaderText="Flower ID" />
                <asp:BoundField DataField="Quantity" HeaderText="Detail Quantity" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="LabelMessageTransactionDetail" Text="" runat="server" />
        <br />
        <asp:Label ID="LabelMessageStatus" Text="" runat="server" />
        <br />
        <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" OnClick="ButtonSubmit_Click" />
    </div>
</asp:Content>
