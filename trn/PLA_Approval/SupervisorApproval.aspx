<%@ Page Language="c#" Codebehind="SupervisorApproval.aspx.cs" AutoEventWireup="false"
    Inherits="PLA_Approval.SupervisorApproval" %>

<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Supervisor Approval Page</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <META http-equiv="Pragma" content="no-cache">
	<meta http-equiv="Expires" content="-1"> 
	<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
	<script src="/js/StyleSetter.js" type="text/javascript"></script>
	<script src="/js/BAS_Utility.js" type="text/javascript"></script>
    <script>
			function ScreenScroll()
			{
				window.scrollBy(0,100);
			}
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
			function RemainingLetters()
			{
			   currentStr = document.getElementById('txtDescribtion').value;
			   currentLength = currentStr.length;			   
			   document.getElementById('txtRemaining').value=4000-currentLength;
			}
			OrignialStarter = "";
			function Blink(Startstr)
			{
			  if (window.document.getElementById('Blinker')==null)
			     return;
				if (Startstr=="end")
				{					
					window.document.getElementById('Blinker').value = "";
					return;
				}
				if (OrignialStarter=="")
					OrignialStarter = Startstr;
				str=Startstr;
				if (str=="")
					str = OrignialStarter;
				else
					str = "";
				window.document.getElementById('Blinker').value = str;
				window.setTimeout("Blink(str)",500);
			}	
			
			var estimatedValues = new Array(25);
			function addEstimatedValue(indx,dblValue)
			{
			  estimatedValues[indx] = dblValue;			  
			}
			function getvalue(indx)
			{
			  alert(estimatedValues[indx]);
			}
			function Inform(btnname)
			{
				var fRet; 
				fRet = confirm('Are you sure?'); 
				if (fRet == true) 
				  window.document.getElementById(btnname).click();
			}
			function CheckReroute(strSupName)
	        {
	            var retResult = confirm('Are you sure you want to reroute this application to supervisor '+strSupName);
	            if (retResult)
	            {
	                eval(document.getElementById('hidReroute')).value = 'Reroute',
	                Form1.submit();
	            }
	            else
	            {
	                eval(document.getElementById('hidReroute')).value = 'CancelReroute',
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
                        
            </td>
        </tr>
        <tr valign="top" height="98%">
            <td valign="top" width="10">
            </td>
            <td valign="top">
                <form id="Form1" method="post" runat="server">
                    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                                <table class="fontsmall" id="Table2" cellspacing="0" cellpadding="0" width="790"
                                    border="0">
                                    <tr>
                                        <td style="height: 25px" colspan="2" valign="top">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" CssClass="fontsmall">Training Requested</asp:Label>
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label28" runat="server" Font-Bold="True" CssClass="fontsmall">Remaining Budget For: </asp:Label><asp:DropDownList
                                                ID="ddlBudgetYear" runat="server" CssClass="fontsmall" AutoPostBack="True" Width="60px">
                                            </asp:DropDownList>
                                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblBalance" runat="server" Font-Bold="True" CssClass="fontsmall">$2,500.00</asp:Label></td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: silver thin solid" colspan="2">
                                            <asp:TextBox ID="Blinker" runat="server" Font-Bold="True" Width="448px" Font-Size="Small"
                                                BorderStyle="None" ReadOnly="True" BorderColor="White" ForeColor="Red" Font-Names="Arial">blinker</asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table class="fontsmall" id="Table9" height="25" cellspacing="0" cellpadding="0"
                                    width="100%" border="0">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lbl_fldPLA_ApproSupervisorApproval" runat="server" CssClass="fontsmall"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Maroon"
                                                Font-Italic="True">Click on the "View This Request Summary" hyperlink below to see the vendor and other information regarding this request.</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:LinkButton ID="lnkbtnViewSummary" runat="server" Font-Bold="True" CssClass="fontsmall"
                                                ToolTip="View This Request Summary" CausesValidation="False">View This Request Summary</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="fontsmall" id="Table7" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr>
                                        <td bgcolor="gold">
                                            <asp:Label ID="Label34" runat="server" CssClass="fontsmall" Font-Bold="True">Expenses</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataGrid ID="dgExpense" runat="server" CssClass="fontsmall" Width="100%" BorderColor="White"
                                                AutoGenerateColumns="False" CellPadding="3">
                                                <FooterStyle BackColor="#AAAADD"></FooterStyle>
                                                <SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
                                                <AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
                                                <ItemStyle BackColor="White"></ItemStyle>
                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050">
                                                </HeaderStyle>
                                                <Columns>
                                                    <asp:BoundColumn DataField="expense_type" HeaderText="Expense Type" FooterText="Total">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Estimated&lt;br&gt;Amount">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn Visible="False" HeaderText="Approved &lt;br&gt;Amount">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn DataField="Approved_amount" HeaderText="Approved&lt;br&gt; Amount"
                                                        DataFormatString="{0:C}">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="paid_amount" HeaderText="Paid&lt;br&gt;Amount" DataFormatString="{0:C}">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="vendor_name" HeaderText="Vendor Name">
                                                        <HeaderStyle Width="15%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="vendor_contact_name" HeaderText="Vendor Contact">
                                                        <HeaderStyle Width="15%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="vendor_phone" HeaderText="Vendor Phone">
                                                        <HeaderStyle Width="15%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                            <table class="fontsmall" id="Table8" cellspacing="0" cellpadding="0" width="98%"
                                                border="0">
                                                <tr>
                                                    <td style="height: 16px" width="10%">
                                                        <asp:Label ID="Label14" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">Totals</asp:Label>
                                                        <asp:Label ID="lblNoteMark" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label></td>
                                                    <td style="height: 16px" align="right" width="10%">
                                                        <asp:Label ID="lblAmount" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">58856.22</asp:Label></td>
                                                    <td style="height: 16px" align="right" width="10%">
                                                        <asp:Label ID="lblApprovedAmount" runat="server" CssClass="fontsmall" Font-Bold="True"
                                                            ForeColor="Black">58856.22</asp:Label></td>
                                                    <td style="height: 16px" align="left" width="30%" colspan="3">
                                                        &nbsp;&nbsp;
                                                        <asp:LinkButton ID="lnkbtnCopyAll" runat="server" CssClass="input_control_small" CausesValidation="False">Approve All Estimated Amounts</asp:LinkButton></td>
                                                    <td style="height: 16px" align="left" width="40%">
                                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="input_control_small" CausesValidation="False">Edit Approved Amount</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" colspan="3" style="height: 15px">
                                                    </td>
                                                    <td align="left" colspan="3" style="height: 15px">
                                                        &nbsp;&nbsp;
                                                        <asp:LinkButton ID="lnkbtnSaveApprovedAmount" runat="server" CssClass="input_control_small"
                                                            CausesValidation="False">Save Approved Amount</asp:LinkButton>&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left" style="height: 15px">
                                                        <asp:LinkButton ID="lnkbtnCancelChanges" runat="server" CssClass="input_control_small" CausesValidation="False">Cancel Changes</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:Label ID="lblNoteMarkDetail" runat="server" Font-Bold="True" ForeColor="Red"
                                                            Font-Size="Small">*</asp:Label>
                                                        <asp:Label ID="lblNote" runat="server" CssClass="fontsmall">The Total Amounts Shown Exclude ETV Expenses.</asp:Label></td>
                                                    <td width="10%">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:Label ID="Label18" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">Approval Status</asp:Label>:
                                                        <asp:Label ID="lblApprovalStatus" runat="server" CssClass="fontsmall" Font-Bold="True"></asp:Label>&nbsp;
                                                        <asp:Label ID="lblPaidExceedApproved" runat="server" CssClass="fontsmall" Font-Bold="True"
                                                            ForeColor="Red"></asp:Label></td>
                                                    <td width="10%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                    ShowMessageBox="True"></asp:ValidationSummary>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 18px">
                                <asp:Button ID="btnHome" runat="server" CausesValidation="False" CssClass="fontsmall"
                                    OnClick="btnHome_Click" Text="Home" ToolTip="Return to Supervisor Main Page"
                                    Width="75px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:Button ID="btnViewDocuments" runat="server" CausesValidation="False" OnClick="btnViewDocuments_Click"
                                    Text="View Documents" ToolTip="View Documents" Visible="False" /><asp:Label ID="lblNew"
                                        runat="server" BackColor="Yellow" CssClass="fontsmall" Font-Bold="True" Font-Italic="True"
                                        ForeColor="Red" Text="(New)" Visible="False"></asp:Label>
                                &nbsp;&nbsp;<asp:HiddenField ID="hidReroute" runat="server" />
                                <asp:Label ID="lblScript2" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;&nbsp;
                    <table class="fontsmall" id="TableSignature" cellspacing="0" cellpadding="0" width="100%"
                        bgcolor="navajowhite" border="0">
                        <tr>
                            <td style="height: 19px" bgcolor="#a52a2a">
                                <asp:Label ID="lbl_FldPLA_ApprovalSuperVisorAbbprovalOptions" runat="server" Font-Bold="True"
                                    CssClass="fontsmall" Font-Size="Small" ForeColor="White" BackColor="Brown">Supervisor's Processing Options</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 15px">
                                <table class="fontsmall" id="Table4" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr>
                                        <td align="left" width="100%" colspan="3">
                                            <asp:Label ID="lblNoCreereDevelopmentPlan" runat="server" Font-Bold="True" CssClass="fontsmall"
                                                Width="100%" ForeColor="White" BackColor="#FF5600" Visible="False">Note: Employee does not  have an approved Career Development Plan</asp:Label><asp:Label
                                                    ID="lblNotEnoughBudgetThisYear" runat="server" Font-Bold="True" CssClass="fontsmall"
                                                    ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100%" colspan="3" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100%" colspan="3" height="5">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label37" runat="server" CssClass="fontsmall">Reroute Application to Different Supervisor</asp:Label>&nbsp;
                                            <asp:TextBox ID="txtSupervisorName" runat="server" CssClass="fontsmall" ReadOnly="True"
                                                BackColor="Gainsboro"></asp:TextBox>&nbsp;
                                            <asp:Button ID="btnSelect" runat="server" CssClass="fontsmall" CausesValidation="False"
                                                Text="Reroute" ToolTip="Reroute Application to another supervisor"></asp:Button>
                                <asp:Button ID="btnInformee" runat="server" CausesValidation="False" Text="Inform EEcan borrow">
                                </asp:Button><asp:Button ID="btnNoMoneyPeriod" runat="server" CausesValidation="False"
                                    Text="inform EE No Money Period"></asp:Button><asp:Label ID="lblScript" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px" width="121">
                                            <asp:Label ID="Label4" runat="server" CssClass="fontsmall">Training Type:</asp:Label>&nbsp;
                                            <asp:Label ID="Label23" runat="server" ForeColor="Red">*</asp:Label></td>
                                        <td width="400">
                                            <asp:RadioButtonList ID="opnlstType" runat="server" CssClass="fontsmall" Width="500px"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Within Employee’s Occupation</asp:ListItem>
                                                <asp:ListItem Value="2">Outside Employee’s Occupation</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BorderStyle="Solid"
                                                BorderColor="Red" BackColor="Yellow" BorderWidth="1px" Height="20px" ControlToValidate="opnlstType"
                                                ErrorMessage=" Training Type Required Information "></asp:RequiredFieldValidator>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="121">
                                            <asp:Label ID="Label36" runat="server" CssClass="fontsmall" Visible="False"> Account#</asp:Label><asp:Label
                                                ID="lblNOCDP" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Red"
                                                Visible="False">Employe does not have an approved CDP</asp:Label></td>
                                        <td>
                                            <asp:RadioButtonList ID="opnlstAccountNo" runat="server" CssClass="fontsmall" AutoPostBack="True"
                                                Width="500px" RepeatDirection="Horizontal" Visible="False">
                                            </asp:RadioButtonList></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="121">
                                            <asp:Label ID="Label38" runat="server" CssClass="fontsmall">2nd Line Supervisor</asp:Label></td>
                                        <td>
                                            <table class="fontsmall" id="Table10" height="1%" cellspacing="0" cellpadding="0"
                                                width="100%" border="0">
                                                <tr>
                                                    <td style="height: 42px">
                                                        <asp:RadioButtonList ID="opnlst2ndSupervisor" runat="server" CssClass="fontsmall"
                                                            AutoPostBack="True" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="T">Yes</asp:ListItem>
                                                            <asp:ListItem Value="F">No</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                    <td style="height: 42px">
                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" BorderStyle="Solid"
                                                            BorderColor="Red" BackColor="Yellow" BorderWidth="1px" Height="20px" ControlToValidate="opnlst2ndSupervisor"
                                                            ErrorMessage="2nd Line Supervisor Required Information"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lbl2ndSupervisorName" runat="server" CssClass="fontsmall" Visible="False">2nd Line Supervisor Name</asp:Label><asp:TextBox
                                                ID="txt2ndSupervisorName" runat="server" CssClass="fontsmall" ReadOnly="True"
                                                BackColor="Gainsboro" Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSelect2ndAdvisor" runat="server" CssClass="fontsmall" CausesValidation="False"
                                                Visible="False" Text="Select" ToolTip="Select the second in line supervisor"></asp:Button><asp:RequiredFieldValidator ID="rf2ndSupervisor"
                                                    runat="server" BorderStyle="Solid" BorderColor="Red" BackColor="Yellow" BorderWidth="1px"
                                                    Height="20px" ControlToValidate="txt2ndSupervisorName" ErrorMessage="2nd Line Supervisor Required Name"></asp:RequiredFieldValidator></td>
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
                                <asp:Button ID="btnApprove" runat="server" CssClass="fontsmall" OnClick="btnApprove_Click"
                                    Text="Approve" ToolTip="Approve Application" />
                                <asp:Button ID="btnDecline" runat="server" CssClass="fontsmall" OnClick="btnDecline_Click"
                                    Text="Decline" ToolTip="Decline Application" Width="75px" />
                                <asp:Button ID="btnRequestInfo" runat="server" CssClass="fontsmall" OnClick="btnRequestInfo_Click"
                                    Text="Request More Information" ToolTip="Request More Information from the applicant"
                                    Width="175px" /></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;</td>
                        </tr>
                    </table>
                </form>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

    <p>
        GetAdminNumberName</p>

</body>
</html>
