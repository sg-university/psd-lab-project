<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdministratorNavigation.Master" AutoEventWireup="true" CodeBehind="ManageMemberPage.aspx.cs" Inherits="Project.Views.ManageMemberPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Member Page</h1>
    </div>
    <div>
        <div>
            <a href="/Views/ManageMemberInsertPage.aspx">Insert</a>
        </div>
        <br />
        <div>
            <asp:GridView ID="GridViewMember" runat="server" OnRowCommand="GridViewMember_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="Update" ButtonType="Button" Text="Update" runat="server" />
                    <asp:ButtonField CommandName="Remove" ButtonType="Button" Text="Remove" runat="server" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
