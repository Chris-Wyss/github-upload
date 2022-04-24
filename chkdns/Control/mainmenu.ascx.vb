Imports System.Xml, System.Xml.Xsl, System.Xml.XPath, System.IO, System.Text
Public MustInherit Class mainmenu
    Inherits System.Web.UI.UserControl

    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private strResult As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strXML As String
        ' Get XML
        Dim objXML As XmlDocument
        objXML = GetXMLMenu()

        ' Load XSL
        Dim objXSLTransform As New XslTransform()
        objXSLTransform.Load(Server.MapPath("/XSLTMenu.xslt"))

        ' Apply XSL and write result to StringWriter
        Dim objStringBuilder As New StringBuilder()
        Dim objStringWriter As New StringWriter(objStringBuilder)

        objXSLTransform.Transform(objXML, Nothing, objStringWriter)
        'MenuDiv.InnerHtml = objStringWriter.ToString()
    End Sub

    Function GetXMLMenu() As XmlDocument
        Dim objXMLDoc As New XmlDocument()
        Dim objXMLNode As XmlNode
        Dim xmlproc As XmlProcessingInstruction

        xmlproc = objXMLDoc.CreateProcessingInstruction("xml", "version=""1.0""")
        objXMLDoc.InsertBefore(xmlproc, objXMLDoc.ChildNodes.Item(0))

        objXMLNode = objXMLDoc.CreateElement("Menu")
        objXMLDoc.AppendChild(objXMLNode)

        ' Add items
        Dim objXMLElem As XmlElement
        objXMLElem = objXMLDoc.CreateElement("MenuItem")
        Call objXMLElem.SetAttribute("Name", "Sites")
        Call objXMLElem.SetAttribute("URL", "/servicepart/Sites.aspx")
        objXMLNode.AppendChild(objXMLElem)
        objXMLElem = Nothing

        objXMLElem = objXMLDoc.CreateElement("MenuItem")
        Call objXMLElem.SetAttribute("Name", "Coin Transactions")
        Call objXMLElem.SetAttribute("URL", "/servicepart/CoinsTransactions.aspx")
        objXMLNode.AppendChild(objXMLElem)
        objXMLElem = Nothing

        objXMLElem = objXMLDoc.CreateElement("MenuItem")
        Call objXMLElem.SetAttribute("Name", "Credit Card Transactions")
        Call objXMLElem.SetAttribute("URL", "/servicepart/CCTransactions.aspx")
        objXMLNode.AppendChild(objXMLElem)
        objXMLElem = Nothing

        objXMLElem = objXMLDoc.CreateElement("MenuItem")
        Call objXMLElem.SetAttribute("Name", "Analyse")
        Call objXMLElem.SetAttribute("URL", "/servicepart/analysis.aspx")
        objXMLNode.AppendChild(objXMLElem)
        objXMLElem = Nothing


        GetXMLMenu = objXMLDoc
    End Function


End Class

