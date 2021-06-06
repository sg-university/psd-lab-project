<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MemberNavigation.Master" AutoEventWireup="true" CodeBehind="ViewReportPage.aspx.cs" Inherits="Project.Views.ViewReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CR:CrystalReportViewer ID="reportViewer" runat="server" AutoDataBind="true" />
</asp:Content>
