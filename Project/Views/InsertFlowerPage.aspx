<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertFlowerPage.aspx.cs" Inherits="Project.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Insert Flower</h3>
            <br />

            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="FlowerName" runat="server"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Upload picture:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label>
            <textarea id="Description" rows="5"></textarea>

            <asp:Label ID="Label3" runat="server" Text="Type:"></asp:Label>
            <asp:DropDownList ID="DropDownType" runat="server">
                <asp:ListItem>Daisies</asp:ListItem>
                <asp:ListItem>Lilies</asp:ListItem>
                <asp:ListItem>Roses</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Label4" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="price" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
