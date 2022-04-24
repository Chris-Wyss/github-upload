<%@ Register TagPrefix="uc1" TagName="MainMenuStatic" Src="Control/MainMenuStatic.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="powercheck.aspx.vb" Inherits="checkdns_uniplace_com.domains" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>domains</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/css/style.css" type="text/css" rel="stylesheet">
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
function PopupWinShowMessageDetails(mylink, strWindowName)
{
if (! window.focus)return true;
var href;
if (typeof(mylink) == 'string')
   href=mylink;
else
   href=mylink.href;
window.open(href, strWindowName, 'width=650,height=400,scrollbars=yes,left=300,top=200');
}
//-->
		</SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><uc1:mainmenustatic id="MainMenuStatic1" runat="server"></uc1:mainmenustatic></P>
			<P><asp:label id="Label2" runat="server" Width="337px" Height="25px" Font-Size="Large">Domains</asp:label></P>
			<P><input type="hidden" name="__VIEWSTATE">
				<asp:textbox id="tbNewDomain" runat="server"></asp:textbox><asp:button id="btnAdd" runat="server" Text="Add"></asp:button><asp:label id="lblMessage" runat="server" Width="537px" Visible="False" Font-Bold="True" BackColor="White" ForeColor="Red">  label1</asp:label><asp:datagrid id=dgSessions runat="server" Width="90%" Height="185px" BackColor="White" ForeColor="White" DataSource="<%# DsDomains1 %>" AutoGenerateColumns="False" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" GridLines="Vertical" AllowPaging="True" HorizontalAlign="Center" PageSize="40" DataKeyField="DomainID" DataMember="Domains" AllowSorting="True">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="SteelBlue"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
					<ItemStyle Height="10px" ForeColor="Black" BorderColor="White" CssClass="TableText" BackColor="WhiteSmoke"></ItemStyle>
					<HeaderStyle Font-Bold="True" BorderWidth="0px" ForeColor="White" BorderStyle="Solid" BorderColor="White" BackColor="SteelBlue"></HeaderStyle>
					<FooterStyle ForeColor="White" CssClass="TableText" BackColor="#CCCCCC"></FooterStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Domain name">
							<HeaderStyle Width="20%"></HeaderStyle>
							<ItemTemplate>
								<a runat="server" href='<%# MakeDomainLink(Container) %>' ID="A1">
									<asp:Label runat="server" Text='<% # Container.DataItem("DomainName") %>' ID="Label1">
									</asp:Label>
								</a>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Check">
							<HeaderStyle Width="5%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" Font-Names="Wingdings"></ItemStyle>
							<ItemTemplate>
								<A id=A2 href="<%# MakeCheckLink(Container) %>" runat="server">ü </A>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Root servers">
							<HeaderStyle Width="32%"></HeaderStyle>
							<ItemTemplate>
								<%'# ShowPicture(Container.Dataitem("DNS_ROOT")) %>
								<%# ShowPicture(Container.Dataitem("LogSessionID"), Container.Dataitem("DomainID"), Container.Dataitem("DNS_ROOT"), "ROOT") %>
								<%# Container.Dataitem("DNS") %>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="DNS servers">
							<HeaderStyle Width="6%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<%'# ShowPicture_old(Container.Dataitem("DNS_ALIVE")) %>
								<%# ShowPicture(Container.Dataitem("LogSessionID"), Container.Dataitem("DomainID"), Container.Dataitem("DNS_Severity"), "DNS") %>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn Visible="False" HeaderText="DNS synch">
							<ItemTemplate>
								<%'# ShowPicture(Container.Dataitem("DNS_SYNCH")) %>
								<%# ShowPicture(Container.Dataitem("LogSessionID"), Container.Dataitem("DomainID"), Container.Dataitem("DNS_Severity"), "DNS") %>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Web servers">
							<HeaderStyle Width="6%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<%'# ShowPicture(Container.Dataitem("HTTP")) %>
								<%# ShowPicture(Container.Dataitem("LogSessionID"), Container.Dataitem("DomainID"), Container.Dataitem("HTTP"), "HTTP") %>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="E-Mail servers">
							<HeaderStyle Width="6%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<%'# ShowPicture(Container.Dataitem("SMTP")) %>
								<%# ShowPicture(Container.Dataitem("LogSessionID"), Container.Dataitem("DomainID"), Container.Dataitem("SMTP"), "SMTP") %>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Comment" HeaderText="Comment">
							<HeaderStyle Width="25%"></HeaderStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle Font-Size="10px" HorizontalAlign="Center" ForeColor="White" BackColor="#999999" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></P>
			<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="btnCheckAllDomains" runat="server" Text="CheckAllDomains"></asp:button>&nbsp;
				<asp:label id="lblResultsOfDomains" runat="server" Width="553px" Visible="False" ForeColor="Red">Label</asp:label></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
