<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdministratorNavigation.Master" AutoEventWireup="true" CodeBehind="ManageEmployeePage.aspx.cs" Inherits="Project.Views.ManageEmployeePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Employee Page</h1>
    </div>
    <div>
        <div>
            <a href="/Views/ManageEmployeeInsertPage.aspx">Insert</a>
        </div>
        <br />
        <div>
            <asp:GridView ID="GridViewEmployee" runat="server" OnRowCommand="GridViewEmployee_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="Update" ButtonType="Button" Text="Update" runat="server" />
                    <asp:ButtonField CommandName="Delete" ButtonType="Button" Text="Delete" runat="server" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
