<%@ Control Language="vb" AutoEventWireup="false" Codebehind="login.ascx.vb" Inherits="checkdns_uniplace_com.login" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="5" width="205">
	<tr bgColor="#3333ff">
		<td style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="left" height="25"><font face="Arial" color="white"><b>Login</b></font>
		</td>
	</tr>
	<tr bgColor="#dcdcdc">
		<td style="BORDER-RIGHT: black 1px solid; BORDER-TOP: 1px; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="middle" height="25">
			<table width="100%">
				<tr>
					<td><font face="Arial" size="-1">UserName:</font>
					</td>
					<td><b><asp:textbox id="UserName" runat="server" MaxLength="50"></asp:textbox></b></td>
				</tr>
				<tr>
					<td><font face="Arial" size="-1">Password:</font>
					</td>
					<td><b><asp:textbox id="Password" runat="server" MaxLength="50" TextMode="Password" Width="153px"></asp:textbox></b></td>
				</tr>
				<tr>
					<td></td>
					<td><asp:button id="btnLogin" runat="server" Text="     Sign In     "></asp:button></td>
				</tr>
				<tr>
					<td align="middle" colSpan="2"><span style="FONT: 8pt verdana, arial; COLOR: black"><A href="forgotpassword.aspx"><SPAN style="FONT: 8pt verdana, arial; COLOR: black">Forgot 
									Password&nbsp;</SPAN></A>&nbsp;<A href="register.aspx"><span style="FONT: 8pt verdana, arial; COLOR: black">Create New Account 
								</FONT></A></span></td>
				</tr>
				<tr>
					<td align="middle" colSpan="2"><span id="ErrorMsg" style="FONT: 8pt verdana, arial; COLOR: red" runat="server" Visible="false"><b>Invalid 
								Account Name or Password!</b> </span>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
