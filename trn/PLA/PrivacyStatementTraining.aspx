<%@ Page Language="c#" Codebehind="PrivacyStatementTraining.aspx.cs" AutoEventWireup="false"
    Inherits="PLA_Source.PrivacyStatementTraining" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Privacy Statement</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Pragma" content="no-cache">

    <script src="dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet">

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script>
		function IsPopupBlocker() {
			var strNewURL = "Dummy.htm"
			var Strfeature = "" ;
			var WindowOpen = window.open(strNewURL,"MainWindow","directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");
			try{
			var obj = WindowOpen.name;
			WindowOpen.close();		
			} 
			catch(e){ 
			alert("This program utilizes POP-UP windows. Please disable the POP-UP BLOCKER and try again.\nor Please contact your system administrator. ");
			window.location.href="/scripts/basweb.exe/view?Module=N";
			}
			}
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="Table" style="z-index: 100; left: 0px; position: absolute; top: 0px" height="1"
        cellspacing="0" cellpadding="0" width="790" border="0">
        <tr>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
        </tr>
        <tr valign="top" height="1%">
            <td>
            </td>
            <td>
            </td>
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
                    <table class="fontsmall" id="Table1" height="1" cellspacing="0" cellpadding="0" width="790"
                        border="0">
                        <tr>
                            <td valign="top">
                                <table class="fontsmall" id="Table3" cellspacing="0" cellpadding="0" width="790"
                                    border="0">
                                    <tr>
                                        <td width="20%" height="1%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="1%" align="center">
                                            <asp:Label ID="Label20" runat="server" CssClass="smallfont" Font-Bold="True">Privacy Act Statement</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="1%" width="20%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left" headers="250">
                                            <div style="overflow: auto; width: 780px; height: 240px; text-align: left; border-bottom: silver thin solid;"
                                                align="left">
                                                <asp:Label ID="lbl_fldPLAPrivacyNotice" runat="server" CssClass="smallfont">Star Functionality Field</asp:Label>6</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: silver thin solid" valign="top" align="left" height="1">
                                            <table id="Table4" cellspacing="0" cellpadding="0" width="790" border="0">
                                                <tr>
                                                    <td valign="bottom" width="150" height="1">
                                                        <asp:RadioButtonList ID="optAgree" runat="server" CssClass="fontsmall" ToolTip="Click I Agree to access the Professional Learning Account program.\\n Click Disagree to return to the main employee page."
                                                            AutoPostBack="True" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">I Agree</asp:ListItem>
                                                            <asp:ListItem Value="1">I Disagree</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                    <td valign="bottom" height="1">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    &nbsp;
                </form>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
