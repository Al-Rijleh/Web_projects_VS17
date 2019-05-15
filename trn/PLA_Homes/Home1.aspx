<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>

<%@ Page Language="c#" Codebehind="Home1.aspx.cs" AutoEventWireup="false" Inherits="PLA_Homes.Home1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>PLA Managesr Home</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />

    <script src="/js/dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet">

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <script type="text/javascript"">
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
            
            function GetEE(url_)
            {
              alert('You must select an employee first');
              window.open(url_,'_self');
            }
    </script>

    <style type="text/css">
        .style1
        {
            width: 60%;
        }
        .style3
        {
            height: 14px;
            width: 203px;
        }
        .style7
        {
            width: 1px;
        }
        .style8
        {
            width: 203px;
        }
    </style>

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
                    <table id="Table18" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td colspan="1" height="1">
                                <table id="Table19" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td height="1">
                                            <table id="Table2" height="1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td>
                                                        <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <table id="Table20" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td width="15">
                                                                            </td>
                                                                            <td style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080">
                                                                                <asp:Label ID="LblTemplateHeader0" runat="server" Font-Bold="True">Welcome To Training Support Home Page!</asp:Label>
                                                                                <asp:Label ID="lblScript" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table id="Table21" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td width="15" style="height: 18px">
                                                                            </td>
                                                                            <td style="height: 18px">
                                                                                <asp:HyperLink ID="hlInstruction" runat="server" CssClass="fontsmall" Visible="False">Instructions</asp:HyperLink>&nbsp;
                                                                                <asp:Label ID="Label1" runat="server" CssClass="fontsmall" Visible="False">(click here)</asp:Label>
                                                                                </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="1">
                                                                    <table id="Table22" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td width="15" height="5">
                                                                            </td>
                                                                            <td width="10" bgcolor="#ffcccc" height="5">
                                                                            </td>
                                                                            <td width="750" bgcolor="#ffcccc" height="5">
                                                                            </td>
                                                                            <td width="10" bgcolor="#ffcccc" height="5">
                                                                            </td>
                                                                            <td height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="15" height="60">
                                                                            </td>
                                                                            <td valign="top" width="10" bgcolor="#ffcccc" height="60">
                                                                            </td>
                                                                            <td valign="top" bgcolor="#ffcccc" height="60">
                                                                                <asp:Label ID="lblSpecicalMessage" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                            <td width="10" bgcolor="#ffcccc" height="60">
                                                                            </td>
                                                                            <td height="60">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="15" height="5">
                                                                            </td>
                                                                            <td width="10" bgcolor="#ffcccc" height="5">
                                                                            </td>
                                                                            <td width="350" bgcolor="#ffcccc" height="5">
                                                                            </td>
                                                                            <td width="10" bgcolor="#ffcccc" height="5">
                                                                            </td>
                                                                            <td height="5">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 37px">
                                                                    <table id="Table13" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td width="15">
                                                                            </td>
                                                                            <td style="border-right: black 1px; border-top: black 1px solid; border-left: black 1px solid;
                                                                                border-bottom: black 1px solid" width="200" bgcolor="#d7d0c8">
                                                                                <asp:Label ID="Label3" runat="server" CssClass="fontsmall">Select</asp:Label></td>
                                                                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                                                                border-bottom: black 1px solid" width="1">
                                                                                <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="fontsmall" Width="246px"
                                                                                    BorderStyle="None"></asp:TextBox></td>
                                                                            <td>
                                                                                &nbsp;
                                                                                <asp:Button ID="btnSearch" runat="server" CssClass="fontsmall" Width="75px" BorderStyle="Solid"
                                                                                    Font-Names="Arial" BackColor="#D7D0C8" Text="Search" BorderWidth="1px"></asp:Button>&nbsp;
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="input_control_small" OnClick="LinkButton1_Click">Click Here To Select Yourself</asp:LinkButton></td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="15">
                                                                            </td>
                                                                            <td style="border-right: black 1px; border-top: black 1px solid; border-left: black 1px solid;
                                                                                border-bottom: black 1px solid" width="200">
                                                                            </td>
                                                                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                                                                border-bottom: black 1px solid" width="1">
                                                                                <asp:RadioButtonList ID="opnWho" runat="server" CssClass="fontsmall" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="0" Selected="True">Employee</asp:ListItem>
                                                                                    <asp:ListItem Value="Super">Supervisor</asp:ListItem>
                                                                                    <asp:ListItem Value="pla_adminee">Administrator</asp:ListItem>
                                                                                </asp:RadioButtonList></td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table class="fontsmall" id="Table5" cellspacing="0" cellpadding="0" width="100%"
                                                                        border="0">
                                                                        <tr>
                                                                            <td valign="top" width="15">
                                                                            </td>
                                                                            <td valign="top" width="25%">
                                                                                <table class="fontsmall" id="Table6" cellspacing="0" cellpadding="0" width="100%"
                                                                                    border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblLastSelected" runat="server" Font-Bold="True" CssClass="fontsmall">Last Selected Employee</asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblEEName" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top" width="30%">
                                                                                <table class="fontsmall" id="Table7" cellspacing="0" cellpadding="0" width="100%"
                                                                                    border="0">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" CssClass="fontsmall">Contact Information</asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblWPhoneTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Work Ph#:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblWorkPh" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr runat="server" visible ="false" >
                                                                                        <td>
                                                                                            <asp:Label ID="lblHPhoneTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Home Ph#:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblHomePh" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr runat="server" visible ="false">
                                                                                        <td>
                                                                                            <asp:Label ID="lblMPhoneTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Mobile Ph#:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblMobilePh" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr runat="server" visible ="false">
                                                                                        <td>
                                                                                            <asp:Label ID="lblEmailTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Home Email:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblHomeEmail" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblWEmailTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Work Email:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblWorkEmail" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table class="hpmepage" id="Table8" cellspacing="0" cellpadding="0" width="100%"
                                                                                    border="0">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:Label ID="lblEmployeeIfo" runat="server" Font-Bold="True" CssClass="fontsmall">Employee Information</asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblEmployerTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Employer:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblEmployer" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 16px">
                                                                                            <asp:Label ID="lblEmployerNoTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Employer #:</asp:Label></td>
                                                                                        <td style="height: 16px">
                                                                                            <asp:Label ID="lblEmployeNo" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblMyEnrollNoTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">MyEnroll #:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblEENumber" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr runat="server" visible ="false">
                                                                                        <td>
                                                                                            <asp:Label ID="lblEmployeeClassCodeTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Benefit Class:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblBenefitClass" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr runat="server" visible ="false">
                                                                                        <td>
                                                                                            <asp:Label ID="lblEmployeePayScheduleTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Pay Schedule:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPaySchedule" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblCurrentPYTitle" runat="server" CssClass="fontsmall" ForeColor="DimGray">Current Plan Yr.</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblProcessingYear" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        &nbsp;&nbsp;&nbsp;
                                                        <table id="Table14" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td width="15">
                                                                </td>
                                                                <td width="1">
                                                                    <asp:Button ID="btnPLA" runat="server" CssClass="fontsmall" Width="175px" BorderStyle="Solid"
                                                                        Font-Names="Arial" BackColor="#D7D0C8" Text="Employee Training Module" BorderWidth="1px">
                                                                    </asp:Button></td>
                                                                <td width="1">
                                                                    &nbsp;</td>
                                                                <td width="1">
                                                                    <asp:Button ID="btnSupervisorApproval" runat="server" CssClass="fontsmall" Width="175px"
                                                                        BorderStyle="Solid" Font-Names="Arial" BackColor="#D7D0C8" Text="Supervisor Processing"
                                                                        BorderWidth="1px"></asp:Button></td>
                                                                <td width="1">
                                                                    &nbsp;</td>
                                                                <td style="width: 1px">
                                                                    <asp:Button ID="btnAdministratorApproval" runat="server" CssClass="fontsmall" Width="175px"
                                                                        BorderStyle="Solid" Font-Names="Arial" BackColor="#D7D0C8" Text="Administrator Processing"
                                                                        BorderWidth="1px"></asp:Button></td>
                                                                <td width="1">
                                                                    &nbsp;</td>
                                                                <td valign="middle" style="width: 1px">
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="15" style="height: 20px">
                                                                </td>
                                                                <td width="1" style="height: 20px">
                                                                    <asp:Button ID="btnCareerDevll" runat="server" BackColor="#D7D0C8" BorderStyle="Solid"
                                                                        BorderWidth="1px" OnClick="btnCareerDevll_Click1" Text="Career Development Plan"
                                                                        Width="175px" /></td>
                                                                <td width="1" style="height: 20px">
                                                                </td>
                                                                <td width="1" style="height: 20px">
                                                                    <asp:Button ID="btnManagmentPage" runat="server" BackColor="#D7D0C8" BorderStyle="Solid"
                                                                        BorderWidth="1px" CssClass="fontsmall" Font-Names="Arial" Text="Management Page"
                                                                        Width="175px" /></td>
                                                                <td width="1" style="height: 20px">
                                                                </td>
                                                                <td style="width: 1px; height: 20px;">
                                                                    <asp:Button ID="btnCompetitiveProgram" runat="server" BackColor="#D7D0C8" BorderStyle="Solid"
                                                                        BorderWidth="1px" CssClass="fontsmall" Font-Names="Arial" OnClick="btnCompetitiveProgram_Click"
                                                                        Text="Competitive Program Setup" Width="175px" Visible="False" /></td>
                                                                <td width="1" style="height: 20px">
                                                                </td>
                                                                <td style="width: 1px; height: 20px;" valign="middle">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                    <table cellpadding="0" cellspacing="1" class="fontsmall" 
                                                            style="border: 1px solid #000000" width="250">
                                                            <tr>
                                                                <td align="center" 
                                                                    
                                                                    style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080" 
                                                                    class="style7">
                                                                                &nbsp;</td>
                                                                <td align="center" 
                                                                    
                                                                    
                                                                    style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080" 
                                                                    class="style8">
                                                                                <asp:Label ID="lblHeadingFotTrainingFacts0" runat="server" 
                                                                        Font-Bold="True" CssClass="fontsmall">Know the Training Facts</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                                &nbsp;</td>
                                                                <td class="style3">
                                                                                <asp:LinkButton ID="lnkbtnEmployeew_noCDP" runat="server" 
                                                                                    onclick="lnkbtnEmployeew_noCDP_Click">CDP Not Submitted for Plan Year</asp:LinkButton>
                                                                            </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style7">
                                                                                &nbsp;</td>
                                                                <td class="style8">
                                                                                <asp:LinkButton ID="lnkbtnCDPEnrolleeList" runat="server" 
                                                                                    onclick="lnkbtnCDPEnrolleeList_Click">CDP for Plan Year</asp:LinkButton>
                                                                            </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style7" width="1">
                                                                                &nbsp;</td>
                                                                <td class="style8">
                                                                                <asp:LinkButton ID="lnkbtnPLAActivityBetweenDates" runat="server" 
                                                                                    onclick="lnkbtnPLAActivityBetweenDates_Click">PLA Activity Between Dates (Summary)</asp:LinkButton>
                                                                            </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="style7" width="1">
                                                                                &nbsp;</td>
                                                                <td class="style8">
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" 
                                                                                    onclick="lnkbtnPLAActivityBetweenDatesCOM_Click">PLA Activity Between Dates (Comprehensive)</asp:LinkButton>
                                                                            </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="style7">
                                                                                &nbsp;</td>
                                                                <td class="style8">
                                                                                <asp:LinkButton ID="lnkbtnPLANoActivityBetweenDates" runat="server" 
                                                                                    onclick="lnkbtnPLANoActivityBetweenDates_Click">PLA No Activity Between Dates</asp:LinkButton>
                                                                            </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style7">
                                                                    &nbsp;</td>
                                                                <td class="style8">
                                                                                <asp:LinkButton ID="lnkbtnStatisticsReport" runat="server" 
                                                                                    onclick="lnkbtnStatisticsReport_Click">Statistics Report</asp:LinkButton>
                                                                            </td>
                                                            </tr>
                                                        </table>
&nbsp;<table id="Table9" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server" visible="false">
                                                            <tr>
                                                                <td width="15">
                                                                </td>
                                                                <td valign="top" width="25%">
                                                                    <table class="fontsmall" id="Table10" cellspacing="0" cellpadding="0" width="100%"
                                                                        border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblHeadingForAttenstionRequired" runat="server" Font-Bold="True" CssClass="fontsmall">Attention Required</asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkbtnRequestinLast7Days" runat="server" 
                                                                                    CssClass="fontsmall" Visible="False">Requests in last 7 days</asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkbtnPaidInLast7Days" runat="server" CssClass="fontsmall" 
                                                                                    Visible="False">Paid in last 7 days</asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkbtnDeclinedInLastSevenDays" runat="server" 
                                                                                    CssClass="fontsmall" Visible="False">Declined in last 7 days</asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkbtnEmployeeOverBudget" runat="server" 
                                                                                    CssClass="fontsmall" Visible="False">Employees over budget</asp:LinkButton></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" width="30%">
                                                                    <table class="fontsmall" id="Table11" cellspacing="0" cellpadding="0" width="100%"
                                                                        border="0">
                                                                        <tr>
                                                                            <td style="height: 15px">
                                                                                <asp:Label ID="lblHeadingFotTrainingFacts" runat="server" Font-Bold="True" CssClass="fontsmall">Know the Training Facts</asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblMore" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table class="fontsmall" id="Table12" cellspacing="0" cellpadding="0" width="100%"
                                                                        border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblHeadingForMessageFromBAS" runat="server" Font-Bold="True" CssClass="fontsmall">Messages From BAS</asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblMessageFromBas" runat="server" CssClass="fontsmall"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkbtnsurvey_non_respond" runat="server" 
                                                                                    CssClass="fontsmall" Visible="False">! Survey non-respondents</asp:LinkButton></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkbtnRequestNotReviewed" runat="server" CssClass="fontsmall">! Request not reviewed</asp:LinkButton></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
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
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
