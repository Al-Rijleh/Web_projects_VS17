<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>

<%@ Page Language="c#" Codebehind="SelectAccountCategory.aspx.cs" AutoEventWireup="false"
    Inherits="Training_Source.SelectAccountCategory" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Training Homepage</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Pragma" content="no-cache">

    <script src="dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet">

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script>
		  function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
          function mandatoryOnly(msg)
            {
            //  alert(msg);
              window.location.href='SelectApp.aspx';
            }
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="TableMain" style="z-index: 100; left: 0px; position: absolute; top: 0px"
        height="1" cellspacing="0" cellpadding="0" width="795" border="0">
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
                    <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label>
                    <asp:Label ID="lblScript" runat="server"></asp:Label></td>
            </tr>
        <tr valign="top" height="98%">
            <td valign="top" height="1">
            </td>
            <td valign="top" height="1">
                <form id="Form1" method="post" runat="server">
                    <table class="fontsmall" id="TableData" runat="server" cellspacing="0" cellpadding="0"
                        width="790" border="0">
                        <tr>
                            <td valign="top" height="60%">
                                <table class="fontsmall" id="Table3" height="1" cellspacing="0" cellpadding="0" width="790"
                                    border="0">
                                    <tr>
                                        <td width="20%" height="5%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="5%">
                                            <asp:Label ID="lblWeclome" runat="server" CssClass="FontSmallTitle">Welcome!</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="5%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="5%">
                                            <asp:Label ID="lblWelcomeInstruction" runat="server" Font-Bold="True" CssClass="fontsmall"> This training module provides you with the ability to manage your career development and submit/manage your training requests.<br><br>
											You may use the second, third and the fourth menu items shown in the left navigator menu or you may click below.</asp:Label><br>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5%" width="20%">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblInstruction2" runat="server" CssClass="fontsmall" Font-Bold="True">Start creating your</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td height="5%" width="20%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="14" style="height: 14px">
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkbtnHelpOptionNeedsAssessmsnts" runat="server" CssClass="input_control_small"
                                                OnClick="lnkbtnHelpOptionNeedsAssessmsnts_Click1">....Needs Assessment Tool (Optional)</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 14px" width="20%" height="14">
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            <asp:LinkButton ID="lnlHelpCreerDevelopmentPlan" runat="server" CssClass="input_control_small"
                                                OnClick="lnlHelpCreerDevelopmentPlan_Click1">....Career Development Plan (CDP) </asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 14px" width="20%" height="14">
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkbtnHelpTrainingRequest" runat="server" CssClass="input_control_small"
                                                OnClick="lnkbtnHelpTrainingRequest_Click1">....Training Requests</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 14px" width="20%" height="14">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 14px" width="20%">
                                            <table id="TableSelectEmployee" cellspacing="0" runat="server" cellpadding="0" width="790"
                                                border="0">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblISelectEmployee" runat="server" CssClass="fontsmall" Visible="False">Select Employee</asp:Label>&nbsp;
                                                        <asp:Button ID="btnSelectEmployee" runat="server" CssClass="fontsmall" Text="Select"
                                                            Visible="False"></asp:Button></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </form>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td valign="top">
                <table id="TableHelp" cellspacing="0" cellpadding="0" width="790" border="0" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="lblHelp" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 17px" align="left">
                            <asp:Label ID="lblHelpText" runat="server" CssClass="fontsmall">Your local FDIC career counselor can assist you in preparing your online CDP</asp:Label>
                            <asp:HyperLink ID="hlCreerCounselorList" runat="server" CssClass="fontsmall" Target="_blank"
                                NavigateUrl="/web_projects/trn/CDP2008/CounselorsList.aspx" ToolTip="Get list of career counselor">“ - Click Here to Find a Counselor"</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                            <asp:Button ID="btnReturnToDataPage" runat="server" Width="100px" Text="Close Help">
                            </asp:Button></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

</body>
	
</html>
