<%@ Register TagPrefix="LoginModule" TagName="LoginModule" Src="control/login.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="servermonitor_desc.aspx.vb" Inherits="checkdns_uniplace_com.servermonitor_desc"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>powercheck_desc</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" runat="server">
			<P>
				<h2>Some text about server monitor
				</h2>
			<P></P>
			<P>
				<asp:Table id="Table1" runat="server" Width="242px" Height="79px" style="Z-INDEX: 101; LEFT: 372px; POSITION: absolute; TOP: 215px">
					<asp:TableRow>
						<asp:TableCell>
							<asp:Panel id="Login" EnableViewState="false" visible="true" runat="server">
								<LoginModule:LoginModule runat="server" ID="Loginmodule1"></LoginModule:LoginModule>
								<span id="Msg" style="FONT: 9pt verdana, arial; COLOR: red" runat="server" Visible="false">
									You don't have permision to use this servis!
									<br>
									If you want to use this servis, please click on <A href="/myaccount.aspx">My 
										Account </A>and change your subscription type! </span>
							</asp:Panel>
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
			</P>
		</form>
	</body>
</HTML>
