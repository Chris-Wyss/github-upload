<%@ Page Language="vb" AutoEventWireup="false" Codebehind="myaccount.aspx.vb" Inherits="checkdns_uniplace_com.myaccount"%>
<%@ Register TagPrefix="uc1" TagName="MainMenuStatic" Src="Control/MainMenuStatic.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>myaccount</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<P><asp:textbox id="SubscriptionStatus" style="Z-INDEX: 119; LEFT: 579px; POSITION: absolute; TOP: 230px" runat="server" Width="159px" MaxLength="50"></asp:textbox>
				<asp:Button id="btnChangeSubscription" style="Z-INDEX: 128; LEFT: 211px; POSITION: absolute; TOP: 397px" runat="server" Text="Change subscription" Width="124px" Height="23px"></asp:Button><asp:label id="Label7" style="Z-INDEX: 122; LEFT: 66px; POSITION: absolute; TOP: 440px" runat="server" Font-Bold="True">Parameterisation Information</asp:label><asp:label id="Label8" style="Z-INDEX: 121; LEFT: 167px; POSITION: absolute; TOP: 342px" runat="server">Type :</asp:label><asp:label id="Label2" style="Z-INDEX: 120; LEFT: 163px; POSITION: absolute; TOP: 366px" runat="server">Satus :</asp:label><uc1:mainmenustatic id="MainMenuStatic1" runat="server"></uc1:mainmenustatic></P>
			<P><asp:button id="btnSignOut" style="Z-INDEX: 101; LEFT: 786px; POSITION: absolute; TOP: 19px" runat="server" Text="Sign Out"></asp:button></P>
			<asp:label id="Label1" style="Z-INDEX: 100; LEFT: 132px; POSITION: absolute; TOP: 216px" runat="server">First Name :</asp:label><asp:textbox id="LastName" style="Z-INDEX: 115; LEFT: 213px; POSITION: absolute; TOP: 242px" runat="server" MaxLength="50"></asp:textbox><asp:label id="Label11" style="Z-INDEX: 114; LEFT: 134px; POSITION: absolute; TOP: 245px" runat="server" Width="77px">Last Name :</asp:label><asp:label id="Label3" style="Z-INDEX: 102; LEFT: 140px; POSITION: absolute; TOP: 160px" runat="server">Password :</asp:label><asp:label id="Label4" style="Z-INDEX: 103; LEFT: 87px; POSITION: absolute; TOP: 186px" runat="server">Confirm Password :</asp:label><asp:label id="Label5" style="Z-INDEX: 104; LEFT: 82px; POSITION: absolute; TOP: 133px" runat="server" Width="124px">User name (e-mail) :</asp:label><asp:label id="Label9" style="Z-INDEX: 113; LEFT: 63px; POSITION: absolute; TOP: 102px" runat="server" Font-Bold="True">Personal Information</asp:label><asp:textbox id="TextBox1" style="Z-INDEX: 105; LEFT: 213px; POSITION: absolute; TOP: 214px" runat="server"></asp:textbox><asp:textbox id="Password" style="Z-INDEX: 107; LEFT: 214px; POSITION: absolute; TOP: 159px" runat="server" MaxLength="20"></asp:textbox><asp:textbox id="ConfirmPassword" style="Z-INDEX: 108; LEFT: 214px; POSITION: absolute; TOP: 187px" runat="server" MaxLength="20"></asp:textbox><asp:textbox id="UserName" style="Z-INDEX: 109; LEFT: 580px; POSITION: absolute; TOP: 342px" runat="server" MaxLength="50" ReadOnly="True"></asp:textbox><asp:textbox id="FirstName" style="Z-INDEX: 106; LEFT: 213px; POSITION: absolute; TOP: 214px" runat="server" MaxLength="50"></asp:textbox><asp:button id="btnCreateAccount" style="Z-INDEX: 112; LEFT: 199px; POSITION: absolute; TOP: 535px" runat="server" Text="Create Account"></asp:button><asp:requiredfieldvalidator id="RequiredFieldValidator2" style="Z-INDEX: 111; LEFT: 379px; POSITION: absolute; TOP: 161px" runat="server" ErrorMessage="Pl. enter password" ControlToValidate="Password"></asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator1" style="Z-INDEX: 110; LEFT: 379px; POSITION: absolute; TOP: 161px" runat="server" ErrorMessage="Passwords must match" ControlToValidate="Password" ControlToCompare="ConfirmPassword"></asp:comparevalidator><asp:dropdownlist id="dpSubscriptionType" style="Z-INDEX: 116; LEFT: 596px; POSITION: absolute; TOP: 383px" runat="server">
				<asp:ListItem Value="1" Selected="True">Subscription 1</asp:ListItem>
				<asp:ListItem Value="2">Subscription 2</asp:ListItem>
				<asp:ListItem Value="3">Subscription 3</asp:ListItem>
			</asp:dropdownlist><asp:label id="Label6" style="Z-INDEX: 117; LEFT: 67px; POSITION: absolute; TOP: 311px" runat="server" Font-Bold="True">Subscription Information</asp:label><asp:label id="lblMessage" style="Z-INDEX: 118; LEFT: 354px; POSITION: absolute; TOP: 539px" runat="server" Width="343px" Visible="False" ForeColor="Red">Label</asp:label><asp:label id="lblSubscriptionType" style="Z-INDEX: 123; LEFT: 208px; POSITION: absolute; TOP: 343px" runat="server" Width="217px" Height="12px">Label</asp:label><asp:label id="lblStatus" style="Z-INDEX: 124; LEFT: 209px; POSITION: absolute; TOP: 366px" runat="server" Width="258px" Height="2px">Label</asp:label><asp:label id="lblUserName" style="Z-INDEX: 125; LEFT: 214px; POSITION: absolute; TOP: 134px" runat="server" Width="263px" Height="12px" Font-Bold="True">Label</asp:label>
			<asp:Button id="btnUpdateUser" style="Z-INDEX: 127; LEFT: 212px; POSITION: absolute; TOP: 273px" runat="server" Text="Update" Width="81px" Height="23px"></asp:Button></form>
	</body>
</HTML>
