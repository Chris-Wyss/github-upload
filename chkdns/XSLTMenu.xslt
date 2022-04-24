<?xml version="1.0" encoding="UTF-8" ?>
<!DOCTYPE stylesheet [
<!ENTITY cr "<xsl:text>
</xsl:text>">
<!ENTITY nbsp "<xsl:text disable-output-escaping='yes'>&amp;nbsp</xsl:text>">

]>


<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" omit-xml-declaration="yes"/>

    
    <xsl:template match="/">
        <table border="0" width="100%" cellspacing="0" cellpadding="0" bgcolor="#DCE1ED">
            <tr>
                <td width="100%">
                    <div align="center">
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <xsl:apply-templates />
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </xsl:template>
    <xsl:template match="MenuItem">
        <td bgcolor="#EEEECC">
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td bgcolor="#4E6498" width="1">
                        <img border="0" src='/images/platz.gif' width="1" height="1" />
                    </td>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr><td bgcolor="#4E6498" width="100%"><img border="0" src="/images/platz.gif" width="1" height="1" /></td></tr>
                            <tr>
                                <td width='100%' height='100%'>
                                    &nbsp;<a class="special">
                                        <xsl:attribute name="href">
                                            <xsl:value-of select="@URL" />
                                        </xsl:attribute>
                                        <xsl:value-of select="@Name" />
                                    </a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td bgcolor="#4E6498" width="1">
                        <img border="0" src="/images/platz.gif" width="1" />
                    </td>
                </tr>
            </table>
        </td>&cr;
        <td>&nbsp;</td>&cr;
    </xsl:template>
</xsl:stylesheet>
