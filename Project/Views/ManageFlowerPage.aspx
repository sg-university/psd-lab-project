<%@ Page Title="" Language="C#" MasterPageFile="~/Views/EmployeeNavigation.Master" AutoEventWireup="true" CodeBehind="ManageFlowerPage.aspx.cs" Inherits="Project.Views.ManageFlowerPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <asp:GridView ID="GridViewFlower" runat="server" OnRowCommand="GridViewFlower_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="Update" ButtonType="Button" Text="Update" runat="server" />
                    <asp:ButtonField CommandName="Delete" ButtonType="Button" Text="Delete" runat="server" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
