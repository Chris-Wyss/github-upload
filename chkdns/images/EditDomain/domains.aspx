<%@ Page Language="vb" AutoEventWireup="false" Codebehind="domains.aspx.vb" Inherits="www.unipcorp.net.domains"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>domains</title>
        <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
        <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link rel="stylesheet" TYPE="text/css" HREF="/css/style.css">
        <SCRIPT TYPE="text/javascript">
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
            <P>
                <asp:Label id="Label2" runat="server" Width="337px" Height="25px" Font-Size="Large">Domains</asp:Label></P>
            <P>
                <asp:DataGrid id=dgSessions runat="server" DataSource="<%# DsDomains1 %>" AutoGenerateColumns="False" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="1" GridLines="Vertical" ForeColor="White" AllowPaging="True" HorizontalAlign="Center" PageSize="40" DataKeyField="DomainID" DataMember="Domains" AllowSorting="True" Height="185px" Width="90%">
                    <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="SteelBlue"></SelectedItemStyle>
                    <AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
                    <ItemStyle Height="10px" ForeColor="Black" BorderColor="White" CssClass="TableText" BackColor="WhiteSmoke"></ItemStyle>
                    <HeaderStyle Font-Bold="True" BorderWidth="0px" ForeColor="White" BorderStyle="Solid" BorderColor="White" BackColor="SteelBlue"></HeaderStyle>
                    <FooterStyle ForeColor="White" CssClass="TableText" BackColor="#CCCCCC"></FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="DomainName">
                            <HeaderStyle Width="200px"></HeaderStyle>
                            <ItemTemplate>
                                <a runat="server" href='<%# MakeDomainLink(Container) %>' ID="A1">
                                    <asp:Label runat="server" Text='<%# Container.DataItem("DomainName") %>' ID="Label1">
                                    </asp:Label>
                                </a>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DomainName") %>'>
                                </asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Check">
                                <ItemTemplate>
                                <a runat="server" href='<%# MakeCheckLink(Container) %>' ID="A2">
                                    Go!
                                    </asp:Label>
                                </a>
                            </ItemTemplate>                        
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Comment" HeaderText="Comment"></asp:BoundColumn>
                    </Columns>
                    <PagerStyle Font-Size="10px" HorizontalAlign="Center" ForeColor="White" BackColor="#999999" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid></P>
        </form>
    </body>
</HTML>
