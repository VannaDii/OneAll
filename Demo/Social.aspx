<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Social.aspx.cs" Inherits="OneAll.ASPNET.Social" %>
<asp:Content ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
	<asp:Image runat="server" ID="_imageSocialThum" />
	<br />
	<asp:Label runat="server" ID="_labelSocialName" />
	<br />
	<asp:Label runat="server" ID="_labelMessages" />
</asp:Content>
