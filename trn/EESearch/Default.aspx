<%@ Page Language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="EESearch._Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Employee Search</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Pragma" content="no-cache" />
	<meta http-equiv="Expires" content="-1" /> 
	<link href="/styles/Main.css" type="text/css" rel="stylesheet" />
	<script src="/js/StyleSetter.js" type="text/javascript"></script>
	<script src="/js/BAS_Utility.js" type="text/javascript"></script>
    <script type="text/javascript">
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
            function setTableWidth(width_)
            {
				eval(document.getElementById('Tablemain')).width=width_;
            }
            function docloseWindow(id)
        {    
        closeWindow(id); return false;
        }
        
        function GetRadWindow()
        {
          var oWindow = null;
          if (window.radWindow)
             oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
             oWindow = window.frameElement.radWindow;
          return oWindow;
        }  
        
        function closeWindow(id)
        {       
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }  
    </script>


    <link href="Main.css" rel="stylesheet" type="text/css" />

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="Tablemain" style="z-index: 100; left: 0px; position: absolute; top: 0px"
        height="98%" cellspacing="0" cellpadding="0" width="795" border="0" runat="server">
        <tr>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></td>
        </tr>
        <tr valign="top" height="98%">
            <td valign="top">
            </td>
            <td valign="top">
                <form id="Form1" method="post" runat="server">
                    <table class="fontsmall" id="Table1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblInstruction" runat="server" CssClass="fontsmall"> Search for the name of the Employee you would like to select by typing his/her last name, first  name. The more letters of the name you type, more specific results will appear  listed. Click on the Employee’s Name, Email or Go link to select the employee.</asp:Label></td>
                        </tr>
                        <tr>
                            <td id="TD1" valign="top">
                                &nbsp;
                                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td width="175" valign="middle">
                                            <asp:Label ID="lblHeading" runat="server" CssClass="fontsmall"> Search For (last, first): </asp:Label></td>
                                        <td valign="middle">
                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="input_control_small"></asp:TextBox>&nbsp;<asp:LinkButton
                                                ID="lnkbtnGo" runat="server" CssClass="fontsmall">Go</asp:LinkButton><asp:Label ID="lblScript"
                                                    runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px">
                                        </td>
                                        <td style="height: 18px">
                                            <asp:CheckBox ID="chkTerminated" runat="server" CssClass="input_control_small" Text="Show Terminated">
                                            </asp:CheckBox><asp:CheckBox ID="chbShowCannotAccess" runat="server" CssClass="input_control_small"
                                                Text="Show Employees Who Cannot Have PLA" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DataGrid ID="dgEEs" runat="server" CssClass="fontsmall" AutoGenerateColumns="False"
                                                Width="100%">
                                                <AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
                                                <ItemStyle BackColor="White"></ItemStyle>
                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" BackColor="#505050"
                                                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                </HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Name"></asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Email"></asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="POI" HeaderText="POI"></asp:BoundColumn>
                                                </Columns>
                                                <PagerStyle Mode="NumericPages" />
                                            </asp:DataGrid></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnCack" runat="server" CssClass="fontsmall" Text="Back" Width="75px"
                                                CausesValidation="False"></asp:Button></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </form>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>
    
</body>
    <% Response.CacheControl = "no-cache";%>
    <% Response.Expires = -1; %>
</html>
