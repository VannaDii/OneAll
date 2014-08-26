<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="OneAll.ASPNET._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h2>
		Welcome to OneAll ASP.NET!
	</h2>
	<p>
		To learn more about OneAll visit <a href="http://www.oneall.com" title="OneAll Website">www.oneall.com</a>.
	</p>
	<p>
		You can also find documentation in CHM format in the ZIP file this sample was ship in, or online at <a href="http://docs.oneall.com" title="OneAll Documentation Website">docs.oneall.com</a>.
	</p>
	<p>
		To see OneAll in action, please follow these simple steps.
	</p>
	<ol>
		<li>Edit the web configuration file of this site to include <span style="text-decoration: underline;">your OneAll API credentials</span>.</li>
		<li>Save the configuration, <strong>this step is VERY important</strong>.</li>
		<li>Refresh this page (<i>it's only common sense to you</i>).</li>
		<li>Click the &quot;[ Login ]&quot; link in the upper right corner of this page.</li>
	</ol>
</asp:Content>
