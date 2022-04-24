<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Login.aspx.vb" Inherits="checkdns_uniplace_com.LoginPage"%>
<%@ Register TagPrefix="LoginModule" TagName="LoginModule" Src="control/login.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Login</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 355px; POSITION: absolute; TOP: 233px" runat="server" Width="286px" Height="137px">
				<LoginModule:LoginModule runat="server" ID="Loginmodule1"></LoginModule:LoginModule>
			</asp:Panel>

		</form>
	</body>
</HTML>
