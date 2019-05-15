<%@ Page Language="c#" Codebehind="PayorPendingApprovals.aspx.cs" AutoEventWireup="false"
    Inherits="PLA_Approval.PayorPendingApprovals" %>

<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<html>
<head>
    <title>Select Application</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Expires" content="-1">

    <script src="/js/dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet">

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <script>
		function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		function IsPopupBlocker() 
		{
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
		function CheckReroute(strSupName)
	        {
	            var retResult = confirm('Are you sure you want to reroute this application to Administrator '+strSupName);
	            if (retResult)
	            {
	                eval(document.getElementById('hidReroute')).value = 'Reroute',
	                Form1.submit();
	            }
	        }
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="Table" style="z-index: 100; left: 0px; position: absolute; top: 0px" height="98%"
        cellspacing="0" cellpadding="0" width="795" border="0">
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
                            <td height="20%">
                                <table class="fontsmall" id="Table2" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr>
                                        <td width="220">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" CssClass="fontsmall">Processing Year</asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblProcessing_Year" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:Label><asp:Label
                                                ID="lblScript" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: silver thin solid" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="1%">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td height="1%">
                                <asp:Label ID="lbl_fldPLAPayorPendingApproval" runat="server" CssClass="fontsmall"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 18px">
                                <asp:LinkButton ID="lnkbtnSystemAdministrator" runat="server" CssClass="fontsmall"
                                    Visible="False">Super User Page</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkbtnSelectEmployee" runat="server" CssClass="fontsmall" Visible="False">Select Administrator</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="fontsmall">Show Request Status: </asp:Label><asp:DropDownList
                                    ID="ddlWhat" runat="server" CssClass="fontsmall">
                                    <asp:ListItem Value="2" Selected="True">Pending Payment</asp:ListItem>
                                    <asp:ListItem Value="10">Request Declined</asp:ListItem>
                                    <asp:ListItem Value="11">Paid - Partial Payment</asp:ListItem>
                                    <asp:ListItem Value="3">Paid - Full Payment</asp:ListItem>
                                    <asp:ListItem Value="5">Applicant Completed Evaluation Form</asp:ListItem>
                                    <asp:ListItem Value="1000">All Requests</asp:ListItem>
                                </asp:DropDownList>&nbsp;<asp:LinkButton ID="lnkbtnGo" runat="server" CssClass="fontsmall">Select</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:DataGrid ID="dgPending" runat="server" CssClass="fontsmall" AutoGenerateColumns="False"
                                    Width="100%">
                                    <AlternatingItemStyle BackColor="#F0F0F0" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
                                    <ItemStyle BackColor="White"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050">
                                    </HeaderStyle>
                                    <Columns>
                                        <asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Course Code &amp; Name"></asp:TemplateColumn>
                                        <asp:BoundColumn DataField="description" HeaderText="Request Status"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Budget">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Action">
                                            <HeaderStyle Width="275px" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid></td>
                        </tr>
                        <tr>
                            <td style="height: 12px">
                                <asp:Label ID="lblNote" runat="server" CssClass="fontsmall">Applications submitted before 1/1/2007 do not have budget records</asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<asp:HiddenField ID="hidReroute" runat="server" />
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
