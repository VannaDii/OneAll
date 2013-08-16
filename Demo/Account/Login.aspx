<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OneAll.ASPNET.Account.Login" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <%= Page.OneAllHeaderScript() %>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Log In</h2>
    <%= this.Page.OneAllDisplayLogOnScript() %>
</asp:Content>
