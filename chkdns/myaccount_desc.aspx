<%@ Register TagPrefix="LoginModule" TagName="LoginModule" Src="control/login.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="myaccount_desc.aspx.vb" Inherits="checkdns_uniplace_com.myaccount_desc"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>myaccount_desc</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Table id="Table1" runat="server" Width="242px" Height="79px" style="Z-INDEX: 101; LEFT: 372px; POSITION: absolute; TOP: 215px">
				<asp:TableRow>
					<asp:TableCell>
						<asp:Panel id="Login" EnableViewState="false" visible="true" runat="server">
							<LoginModule:LoginModule runat="server" ID="Loginmodule1"></LoginModule:LoginModule>
						</asp:Panel>
					</asp:TableCell>
				</asp:TableRow>
			</asp:Table></form>
	</body>
</HTML>
