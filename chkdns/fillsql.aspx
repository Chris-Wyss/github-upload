<%@ Page Language="vb" AutoEventWireup="false" Codebehind="fillsql.aspx.vb" Inherits="checkdns_uniplace_com.fillsql"%>
<%@ Register TagPrefix="uc1" TagName="CDNSCheckerWrapped" Src="Control/CDNSCheckerWrapped.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>fillsql</TITLE>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT type="text/javascript">
		<!--
		function PopupWin(mylink, strWindowName)
		{
		if (! window.focus)return true;
		var href;
		if (typeof(mylink) == 'string')
		href=mylink;
		else
		href=mylink.href;
		window.open(href, strWindowName, 'width=650,height=600,scrollbars=yes,left=20%,top=10%');
		}
		//-->
		</SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:cdnscheckerwrapped id="CDNSCheckerWrapped1" runat="server"></uc1:cdnscheckerwrapped>
			<asp:textbox id="TextBox1" runat="server"></asp:textbox>
		</form>
	</body>
</HTML>
