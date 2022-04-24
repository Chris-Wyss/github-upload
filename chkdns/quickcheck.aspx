<%@ Register TagPrefix="uc1" TagName="CDNSCheckerWrapped" Src="Control/CDNSCheckerWrapped.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MainMenuStatic" Src="Control/MainMenuStatic.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="quickcheck.aspx.vb" Inherits="checkdns_uniplace_com.check" EnableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>check</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="/css/style.css" type="text/css" rel="stylesheet">
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
		
		function PopupWinMessageHelp(mylink, strWindowName)
		{
		if (! window.focus)return true;
		var href;
		if (typeof(mylink) == 'string')
		href=mylink;
		else
		href=mylink.href;
		window.open(href, strWindowName, 'width=600,height=400,scrollbars=yes,left=20%,top=10%');
		}		
		//-->
		</SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="get" runat="server">
			<P>
				<uc1:MainMenuStatic id="MainMenuStatic1" runat="server"></uc1:MainMenuStatic>
			</P>
			<P>
				<b>Domain name:</b><asp:TextBox id="Domain" runat="server"></asp:TextBox>
				<input type="submit" name="submit" value="&nbsp;Check!&nbsp;" style="FONT-WEIGHT:bold; FONT-SIZE:9pt; BORDER-LEFT-COLOR:#69f; BORDER-BOTTOM-COLOR:#69f; COLOR:#ffffff; BORDER-TOP-COLOR:#69f; BACKGROUND-COLOR:#004080; BORDER-RIGHT-COLOR:#69f">&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:CheckBox id="Detailed" runat="server"></asp:CheckBox>&nbsp;<b>Maximum details</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<span id="spanLogin" style="FONT: 8pt verdana, arial; COLOR: red" runat="server" Visible="true">
					<A href="login.aspx">Login</A> </span>
			</P>
			<br>
			Enter domain name (for example: <b>yourdomain.com</b>) and click Check
			<%# oUser.AccessToObject("Powercheck")%>
		</form>
		<uc1:CDNSCheckerWrapped id="CDNSCheckerWrapped1" runat="server"></uc1:CDNSCheckerWrapped>
		<P></P>
		<table border="0" width="80%" align="center" cellspacing="0" class="headertd">
			<tr>
				<td width="10%">
					&nbsp;
				</td>
				<td width="80%" align="middle">
					© 2001-2002 Uniplace AG, Förrlibuckstr. 178, CH-8005 Zürich<br>
					Tel: +41 1 2761925, Fax: +41 1 2761920, <a href="mailto:info@uniplace.com">e-Mail</a>
				</td>
				<td width="10%" align="right">
					Powered by <a href="http://www.unitradex.net">UNITRADEX.NET</a>
				</td>
			</tr>
		</table>
		<P>
		</P>
	</body>
</HTML>
