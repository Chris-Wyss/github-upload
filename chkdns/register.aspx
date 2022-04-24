<%@ Page Language="vb" AutoEventWireup="false" Codebehind="register.aspx.vb" Inherits="checkdns_uniplace_com.register"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>register</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 111px; POSITION: absolute; TOP: 223px" runat="server">First Name :</asp:label>
			<asp:textbox id="LastName" style="Z-INDEX: 120; LEFT: 192px; POSITION: absolute; TOP: 249px" runat="server" MaxLength="50"></asp:textbox>
			<asp:label id="Label11" style="Z-INDEX: 119; LEFT: 113px; POSITION: absolute; TOP: 252px" runat="server" Width="77px">Last Name :</asp:label>
			<asp:label id="Label3" style="Z-INDEX: 102; LEFT: 119px; POSITION: absolute; TOP: 114px" runat="server">Password :</asp:label>
			<asp:label id="Label4" style="Z-INDEX: 103; LEFT: 66px; POSITION: absolute; TOP: 140px" runat="server">Confirm Password :</asp:label>
			<asp:label id="Label5" style="Z-INDEX: 104; LEFT: 61px; POSITION: absolute; TOP: 87px" runat="server" Width="124px">User name (e-mail) :</asp:label>
			<asp:Label id="Label2" style="Z-INDEX: 115; LEFT: 53px; POSITION: absolute; TOP: 59px" runat="server" Font-Bold="True" Font-Size="Small">Sign-In Information</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 116; LEFT: 192px; POSITION: absolute; TOP: 58px" runat="server" Font-Italic="True">(Required)</asp:Label>
			<asp:Label id="Label9" style="Z-INDEX: 117; LEFT: 54px; POSITION: absolute; TOP: 193px" runat="server" Font-Bold="True">Personal Information</asp:Label>
			<asp:Label id="Label10" style="Z-INDEX: 118; LEFT: 203px; POSITION: absolute; TOP: 193px" runat="server" Font-Italic="True">(Optional) </asp:Label>
			<asp:textbox id="TextBox1" style="Z-INDEX: 105; LEFT: 192px; POSITION: absolute; TOP: 221px" runat="server"></asp:textbox>
			<asp:textbox id="Password" style="Z-INDEX: 107; LEFT: 193px; POSITION: absolute; TOP: 113px" runat="server" MaxLength="20"></asp:textbox>
			<asp:textbox id="ConfirmPassword" style="Z-INDEX: 108; LEFT: 193px; POSITION: absolute; TOP: 141px" runat="server" MaxLength="20"></asp:textbox>
			<asp:textbox id="UserName" style="Z-INDEX: 109; LEFT: 193px; POSITION: absolute; TOP: 87px" runat="server" MaxLength="50"></asp:textbox>
			<asp:textbox id="FirstName" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 221px" runat="server" MaxLength="50"></asp:textbox>
			<asp:button id="btnCreateAccount" style="Z-INDEX: 113; LEFT: 173px; POSITION: absolute; TOP: 357px" runat="server" Text="Create Account"></asp:button>
			<asp:requiredfieldvalidator id="RequiredFieldValidator2" style="Z-INDEX: 111; LEFT: 358px; POSITION: absolute; TOP: 115px" runat="server" ControlToValidate="Password" ErrorMessage="Pl. enter password"></asp:requiredfieldvalidator>
			<asp:requiredfieldvalidator id="RequiredFieldValidator3" style="Z-INDEX: 114; LEFT: 356px; POSITION: absolute; TOP: 87px" runat="server" ControlToValidate="UserName" ErrorMessage="Pl. enter email address" Height="20px" Width="175px"></asp:requiredfieldvalidator>
			<asp:comparevalidator id="CompareValidator1" style="Z-INDEX: 110; LEFT: 358px; POSITION: absolute; TOP: 115px" runat="server" ControlToValidate="Password" ErrorMessage="Passwords must match" ControlToCompare="ConfirmPassword"></asp:comparevalidator>
			<asp:regularexpressionvalidator id="RegularExpressionValidator1" style="Z-INDEX: 112; LEFT: 355px; POSITION: absolute; TOP: 88px" runat="server" ControlToValidate="UserName" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
			<asp:DropDownList id="dpSubscriptionType" style="Z-INDEX: 121; LEFT: 196px; POSITION: absolute; TOP: 291px" runat="server">
				<asp:ListItem Value="1" Selected="True">Subscription 1</asp:ListItem>
				<asp:ListItem Value="2">Subscription 2</asp:ListItem>
				<asp:ListItem Value="3">Subscription 3</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="Label6" style="Z-INDEX: 122; LEFT: 61px; POSITION: absolute; TOP: 291px" runat="server" Font-Bold="True">Subscription Type</asp:Label>
			<asp:Label id="lblMessage" style="Z-INDEX: 123; LEFT: 328px; POSITION: absolute; TOP: 361px" runat="server" Width="343px" ForeColor="Red" Visible="False">Label</asp:Label>
		</form>
	</body>
</HTML>
