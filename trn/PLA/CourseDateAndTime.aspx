<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="rjs" Namespace="RJS.Web.WebControl" Assembly="RJS.Web.WebControl.PopCalendar" %>

<%@ Page Language="c#" Codebehind="CourseDateAndTime.aspx.cs" AutoEventWireup="false"
    Inherits="PLA_Source.CourseDateAndTime" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Course Dates & Times</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Pragma" content="no-cache">

    <script src="dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet">

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <script>
		    function Do_Save()
			{
			    document.getElementById('btnSave').style.visibility='hidden';
			    document.getElementById('dvSaving').style.visibility='visible';
			    eval(document.getElementById('hidCommand')).value='DoSave';
			    postBack();
			}
			
			function postBack()
			{
			 var theForm = document.forms['form1'];
             if (!theForm) 
                theForm = document.Form1;
             theForm.submit();            
			}
			
			function CheckSave(url_)
			{
				var chk = confirm("The data was changed. Do you wish to save the data first? If Yes click Ok otherwise click Cancel")
				if (!chk)
					document.location.href=url_;
				else
				{
					document.Form1.doSave.value=url_;
					__doPostBack('','');
				}

			}
		  function AddValues()
		  {
		    try
		    {
		       document.getElementById('txtCourseHoursTotal').value = 
		       parseFloat(document.getElementById('txtCourseHoursDuty').value)+parseFloat(document.getElementById('txtCourseHoursNonDuty').value);
		    }
		    catch (err)
		    {
				document.getElementById('txtCourseHoursTotal').value = "Error";
		    }
		  }
		  function popup(url1,height1,width1)
          {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
          } 
          function DisableNavigation()
			{
			//	document.getElementById('pnlNav').disabled = true;
			//	document.getElementById('pnlAction').disabled = false;
				
			//	document.getElementById('pnlAction').style.visibility="visible";
			//	document.getElementById('pnlDisabeledAction').style.visibility="hidden";	
				
			//	document.getElementById('pnlNav').style.visibility="hidden";
			//	document.getElementById('pnlDisableNav').style.visibility="visible";
			}
		  function EnableNavigation()
			{
			//	document.getElementById('pnlNav').disabled = false;
			//	document.getElementById('pnlAction').disabled = true;
					
			//	document.getElementById('pnlAction').style.visibility="hidden";	
			//	document.getElementById('pnlAction').style.height=1;
			//	document.getElementById('pnlDisabeledAction').style.visibility="visible";
				
			//	document.getElementById('pnlNav').style.visibility="visible";
			//	document.getElementById('pnlDisableNav').style.visibility="hidden";
			}
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="Table" style="z-index: 101; left: 0px; position: absolute; top: 0px" height="390"
        cellspacing="0" cellpadding="0" width="795" border="0">
        <tr>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
            <td background="/karama/Images/WinSubTab.gif">
                <cc1:UltimateMenu ID="UltimateMenu1" runat="server">
                </cc1:UltimateMenu>
                <asp:Label ID="lblWizardError" runat="server" Font-Bold="True" CssClass="fontsmall"
                    ForeColor="Maroon"></asp:Label></td>
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
                    <table class="fontsmall" id="Table1" height="95%" cellspacing="0" cellpadding="0"
                        width="100%" border="0">
                        <tr>
                            <td style="border-bottom: silver thin solid" valign="top" height="10%">
                                <table class="fontsmall" id="Table2" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr>
                                        <td width="220">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True"> Training Requested</asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="220">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True">Remaining Budget For: </asp:Label>
                                            <asp:DropDownList ID="ddlBudgetYear" runat="server" Width="60px" CssClass="fontsmall"
                                                AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:Label>
                                            <asp:HiddenField ID="hidCommand" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"></asp:ValidationSummary>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" height="55%">
                                <table class="fontsmall" id="Table3" height="95%" cellspacing="0" cellpadding="0"
                                    width="100%" border="0">
                                    <tr>
                                        <td height="1%" colspan="3">
                                            <asp:Label ID="lbl_fldTrainingCourseDate" runat="server">Instruction</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 1%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 1%" bgcolor="palegoldenrod">
                                            <asp:Label ID="lblCourseHours" runat="server">

<head>
<style>
<!--
p
	{margin-right:0in;
	margin-left:0in;
	font-size:12.0pt;
	font-family:"Times New Roman","serif";
	}
-->
</style>
</head>

<p><b>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
If this is a training course, conference, etc. you must complete the duty and/or 
non-duty hours</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
with the hours</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
of the training before moving to the next screen.&nbsp; Zero is not accepted</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
as</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
duty/non-duty hours for a training event.</span></b></p>
<p><b>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
If this is a book</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
and/or study materials</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
purchase (no training)</span>
<span style="font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">
– </span>
<span style="font-size:10.0pt;
font-family:&quot;Arial&quot;,&quot;sans-serif&quot;">cancel this request, and 
select <font color="#800000">New Book and/or new Study Materials Only.</font></span></b></p><br />
                                            </asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="1%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="1%">
                                            <asp:Label ID="lblRequiredSymbol" runat="server" CssClass="fontsmall">The <font color="#800000">
														|</font> symbol before a data entry field indicates required data.</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="1%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="150" height="1%">
                                            <asp:Label ID="lblCourseStartDate" runat="server" ToolTip="Course Start Date" AssociatedControlID="txtStartDate">Course Start Date</asp:Label>
                                            <asp:Label ID="lblDateFormat" runat="server" Text="MM/DD/YYYY"></asp:Label></td>
                                        <td height="1%" colspan="2">
                                            <asp:Label ID="req8" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                            <asp:TextBox ID="txtStartDate" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                Width="175px" MaxLength="10"></asp:TextBox>&nbsp;
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtStartDate" Culture="en-US English (United States)"
                                                MessageAlignment="RightCalendarControl" MessageCssClass="fontsmall" Separator="/"
                                                Format="mm dd yyyy" From-Today="True" From-Message="Start Date Cannot Be In The Past"
                                                To-Message="Start Date Cannot Be more than on year into the future" ScriptsValidators="No Validate"
                                                ControlFocusOnError="False" ShowErrorMessage="False"></rjs:PopCalendar>
                                            &nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Course Start Date is Required"
                                                ControlToValidate="txtStartDate" Display="Dynamic" ToolTip="Course Start Date is Required"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Date" ErrorMessage="Incorrect Start Date Format(MM/DD/YYYY)"
                                                ControlToValidate="txtStartDate" Display="Dynamic" MinimumValue="01/01/1000"
                                                MaximumValue="01/01/3000"></asp:RangeValidator></td>
                                    </tr>
                                    <tr>
                                        <td width="150" height="1%">
                                            <asp:Label ID="lblCourseEndDate" runat="server" ToolTip="Course End Date" AssociatedControlID="txtEndDate">Course End Date</asp:Label>
                                            <asp:Label ID="lblFormatDateEnd" runat="server" Text="MM/DD/YYYY"></asp:Label></td>
                                        <td colspan="2" height="1%">
                                            <asp:Label ID="Label1" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                            <asp:TextBox ID="txtEndDate" onblur="reset__(this)" runat="server" Width="175px"
                                                MaxLength="10" CssClass="Input_Control_Small"></asp:TextBox>&nbsp;
                                            <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtEndDate" Culture="en-US English (United States)"
                                                MessageAlignment="RightCalendarControl" MessageCssClass="fontsmall" Separator="/"
                                                Format="mm dd yyyy" From-Today="True" From-Message="End Date Cannot Be In The Past"
                                                To-Message="End Date Cannot Be more than on year into the future" ScriptsValidators="No Validate"
                                                ControlFocusOnError="False" ShowErrorMessage="False"></rjs:PopCalendar>
                                            &nbsp;
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEndDate"
                                                ErrorMessage="End Date cannot be smaller than Begin Date" Type="Date" ControlToCompare="txtStartDate"
                                                Operator="GreaterThanEqual"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Course End Date is Required"
                                                ControlToValidate="txtEndDate" Display="Dynamic" ToolTip="Course End Date is Required"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" Type="Date" ErrorMessage="Incorrect End Date Format(MM/DD/YYYY)"
                                                ControlToValidate="txtEndDate" Display="Dynamic" MinimumValue="01/01/1000" MaximumValue="01/01/3000"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 1%" width="150">
                                            <asp:Label ID="lblCourseHourDutey" runat="server" ToolTip="Course Hours - Duty" AssociatedControlID="txtCourseHoursDuty">Course Hours - Duty</asp:Label></td>
                                        <td colspan="2" style="height: 1%">
                                            <asp:Label ID="Label2" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                            <asp:TextBox ID="txtCourseHoursDuty" onblur="reset__(this)" onkeyup="AddValues();DisableNavigation();"
                                                runat="server" CssClass="Input_Control_Small" Width="175px" MaxLength="6">0</asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Hours  Duty Required Information"
                                                ControlToValidate="txtCourseHoursDuty" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Incorrect Hours Duty Number"
                                                ControlToValidate="txtCourseHoursDuty" Display="Dynamic" Type="Double" MaximumValue="100000"
                                                MinimumValue="0"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1%" width="150">
                                            <asp:Label ID="lblCourseHiursNonDuty" runat="server" ToolTip="Course Hours - Non-Duty"
                                                AssociatedControlID="txtCourseHoursTotal">Course Hours - Non-Duty</asp:Label></td>
                                        <td height="1%" colspan="2">
                                            <asp:Label ID="Label9" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                            <asp:TextBox ID="txtCourseHoursNonDuty" onblur="reset__(this)" onkeyup="AddValues();DisableNavigation();"
                                                runat="server" CssClass="Input_Control_Small" Width="175px" MaxLength="6">0</asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Hours Non-Duty Required Information"
                                                ControlToValidate="txtCourseHoursNonDuty" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Incorrect Hours Non-Duty Number"
                                                ControlToValidate="txtCourseHoursNonDuty" Display="Dynamic" Type="Double" MaximumValue="100000"
                                                MinimumValue="0"></asp:RangeValidator></td>
                                    </tr>
                                    <tr>
                                        <td height="1%" width="150">
                                            <asp:Label ID="lblCourseHourTotal" runat="server" Font-Bold="True" ToolTip="Course Hours Total">Course Hours Total</asp:Label></td>
                                        <td height="1%" colspan="2">
                                            <asp:Label ID="Label43" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label>
                                            <asp:TextBox ID="txtCourseHoursTotal" runat="server" Font-Bold="True" CssClass="Input_Control_Small"
                                                Width="175px" MaxLength="30" ReadOnly="True" BorderStyle="Solid">0</asp:TextBox>&nbsp;
                                            <asp:Label ID="lblScript" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 1%" width="150">
                                            &nbsp;</td>
                                        <td style="height: 1%">
                                        </td>
                                        <td style="width: 315px; height: 1%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="1%">
                                            <table class="fontsmall" id="Table4" cellspacing="0" cellpadding="0" width="100%"
                                                border="0">
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" width="40">
                                                        <asp:Label ID="lblColor" runat="server" Visible="False" ForeColor="Cyan" BorderStyle="Solid"
                                                            Height="18px" BorderColor="Black" BackColor="Cyan" BorderWidth="1px">Label</asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblInfo" runat="server" Visible="False">Fields highlighted with cyan color, denote key fields. If any key field is modified, this Application will be reset to Pending Approval</asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="1%">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="1%">
                                            <table class="fontsmall" id="Table7" cellspacing="0" cellpadding="0" width="100%"
                                                border="0" height="85">
                                                <tr>
                                                    <td height="8" valign="top" style="width: 300px">
                                                        <asp:Button ID="btnHome" runat="server" CssClass="fontsmall" Width="75px" CausesValidation="False"
                                                            Text="Home" ToolTip="Rrturn to select application"></asp:Button>
                                                        <asp:Button ID="btnBack" runat="server" CssClass="fontsmall" Width="75px" CausesValidation="False"
                                                            Text="Back" ToolTip="Back to previous page"></asp:Button>
                                                        <asp:Button ID="btnNext" runat="server" CssClass="fontsmall" Width="75px" CausesValidation="False"
                                                            Text="Next" ToolTip="GoTo next page"></asp:Button>
                                                    </td>
                                                    <td valign="top">
                                                        <div id="dvSaving" style="visibility: hidden; float: right">
                                                                <b><font face="Arial" color="#800000">Saving..</font></b></div>
                                                    </td>
                                                    <td height="8" valign="top">
                                                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" />
                                                        <asp:Button ID="btnReset" runat="server" CssClass="fontsmall" Width="200px" CausesValidation="False"
                                                            Text="Reset Current Screen Data" ToolTip="Reset Data"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" colspan="3">
                                        </td>
                                    </tr>
                                </table>
                                <input id="doSave" type="hidden" name="doSave" runat="server">
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" height="1%">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                </form>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

</body>
</html>
