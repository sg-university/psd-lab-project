<%@ Page Title="" Language="C#" MasterPageFile="~/Views/EmployeeNavigation.Master" AutoEventWireup="true" CodeBehind="ManageFlowerPage.aspx.cs" Inherits="Project.Views.ManageFlowerPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .image-field {
            width: 100vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Flower Page</h1>
    </div>
    <div>
        <div>
            <a href="/Views/ManageFlowerInsertPage.aspx">Insert</a>
        </div>
        <br />
        <div>
            <asp:GridView ID="GridViewFlower" runat="server" OnRowCommand="GridViewFlower_RowCommand" AutoGenerateColumns="False">
                <columns>
                    <asp:ButtonField CommandName="Update" ButtonType="Button" Text="Update" runat="server" />
                    <asp:ButtonField CommandName="Remove" ButtonType="Button" Text="Remove" runat="server" />
                
                    <asp:BoundField DataField="FlowerID" HeaderText="ID" />
                    <asp:BoundField DataField="FlowerName" HeaderText="Name" />
                    <asp:BoundField DataField="MsFlowerType.FlowerTypeName" HeaderText="TypeName" />
                    <asp:BoundField DataField="FlowerDescription" HeaderText="Description"/>
                    <asp:ImageField DataImageUrlField="FlowerImage" HeaderText="Image" ControlStyle-Width="100">
                    </asp:ImageField>
                    <asp:BoundField DataField="FlowerPrice" HeaderText="Price" />
                    </columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
