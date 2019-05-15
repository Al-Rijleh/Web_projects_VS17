<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="Confirmation.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.Confirmation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Confirmation Page</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META HTTP-EQUIV="Pragma" CONTENT="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<style type="text/css">TEXTAREA { BORDER-RIGHT: medium none; BORDER-TOP: medium none; OVERFLOW: auto; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none }
		</style>
		<script>
			function CheckResetAccountNumber()
			{
				var chk = confirm("You have selected a Mandatory request. All requests submitted after 01/23/2008 will be changed to a non-Mandatory  (PLA (5632))\n\n If you wish to continue with the submission of the request press the Ok button. Please note that, this action will change your request to a non-Mandatory (PLA (5632)). If you do not wish to continue then select the Cancel button.")
				if (!chk)
					document.location.href="SelectApp.aspx?SkipCheck=YES";
				else
				{
				   document.location.href="Confirmation.aspx?action=PLA";
		//			document.Form1.hidCommand.value="doit";				
		//			__doPostBack('','');				
				}
			}
		    function GoHome()
		    {
				window.location.href='SelectApp.aspx';
		    }
		    function ConfirmaSave(strnote)
		    {
				alert(strnote);
				window.location.href='SelectApp.aspx';
		    }
			function ScreenScroll()
			{
				window.scrollBy(0,100);
			}
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
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
				window.setTimeout("Blink(str)",2000);
			}	
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif">
					<cc1:UltimateMenu id="UltimateMenu1" runat="server"></cc1:UltimateMenu>
					<asp:Label id="lblWizardError" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Maroon"></asp:Label></TD>
			</TR>
			<TR>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top" style="WIDTH: 475px; HEIGHT: 99.05%">
					<form id="Form1" method="post" runat="server">
						<TABLE id="TableMain" height="98%" cellSpacing="0" cellPadding="0" width="795" border="0">
							<tr>
								<td vAlign="top" style="HEIGHT: 286px">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="790" border="0">
													<TR>
														<TD width="220">
															<asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
														<TD width="570" style="height: 25px" valign="top">
															<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label>
															<asp:Label id="lblScript" runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD width="220">
															<asp:Label id="Label28" runat="server" Font-Bold="True">Remaining Budget For: </asp:Label>
															<asp:DropDownList id="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall"></asp:DropDownList></TD>
														<TD width="570" valign="bottom">
															<asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label></TD>
													</TR>
													<TR>
														<TD style="BORDER-BOTTOM: silver thin solid" colSpan="2">
															<asp:Label id="lblLine1" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label><BR>
															<asp:Label id="lblLine2" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></TD>
													</TR>
												</TABLE>
												<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="fontsmall" DisplayMode="List"></asp:ValidationSummary>
												<asp:label id="lblerrorbadPassword" runat="server" CssClass="fontsmall" ForeColor="Red" Visible="False">
													<a href="JavaScript:SetFocus('txtPassword')"><b><font color="#800000">ERROR</font></b><font color='blue'>
															- <u>Invalid Password</u></font></a></asp:label>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 87px">
												<TABLE class="fontsmall" id="TableSignature" style="WIDTH: 795px; HEIGHT: 1px" cellSpacing="0"
													cellPadding="0" bgColor="navajowhite" border="0">
													<TR>
														<TD style="HEIGHT: 15px" bgColor="brown">
															<asp:label id="Label40" runat="server" Font-Bold="True" ForeColor="White" BackColor="Brown">Employee Signature Block</asp:label></TD>
													</TR>
													<TR>
														<TD height="1">
															<asp:Label id="lblNotEnoughBudgetThisYear" runat="server" Font-Bold="True" ForeColor="Maroon"
																Visible="False" CssClass="fontsmall">You do not have enough money in this year budget to cover the expense of this request. If you wish to borrow from  ~year~ budget year, you must fill the Continuation form.</asp:Label></TD>
													</TR>
													<TR>
														<TD height="1">
															<TABLE class="fontsmall" id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD width="375">
																		<asp:Label id="lblHaveYouSubmitedForm" runat="server" Visible="False" CssClass="fontsmall">Have You Completed The Continued Service Agreement Form</asp:Label><br />
                                                                        <asp:HyperLink ID="hlServiceAgreement" runat="server" NavigateUrl="Continued Service Agreement 2600-25.doc"
                                                                            Target="_blank" Visible="False">Continued Service Agreement</asp:HyperLink></TD>
																	<TD>
																		<asp:RadioButtonList id="opnSubmitedForm" runat="server" AutoPostBack="True" CssClass="fontsmall" Visible="False"
																			RepeatDirection="Horizontal">
																			<asp:ListItem Value="1">Yes</asp:ListItem>
																			<asp:ListItem Value="0">No</asp:ListItem>
																		</asp:RadioButtonList></TD>
																	<TD width="5">&nbsp;</TD>
																	<TD>
																		<asp:Label id="lblsubmitNote" runat="server" Font-Bold="True" Visible="False" CssClass="fontsmall">You may not submit this request until you Complete the Continued Service Agreement Form</asp:Label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<asp:Label id="Label35" runat="server" CssClass="fontsmall">Supervisor Assignment</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:TextBox id="txtSupervisorName" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"></asp:TextBox>&nbsp;&nbsp;&nbsp;
															<asp:Button id="btnSelect" runat="server" CssClass="fontsmall" CausesValidation="False" Text="Replace"
																ToolTip="Change Supervisor "></asp:Button></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
													</TR>
													<TR>
														<TD>
															<asp:label id="Label36" runat="server" CssClass="fontsmall">Your Approval Signature:</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 2px">
															<asp:label id="Label37" runat="server" CssClass="fontsmall">Enter Your MyEnroll.com Password</asp:label>&nbsp;&nbsp;&nbsp;
															<asp:label id="req8" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
															<asp:textbox id="txtPassword" runat="server" Width="100px" CssClass="fontsmall" TextMode="Password"></asp:textbox>
															<asp:Button id="btnSave" runat="server" CssClass="fontsmall" Text="Save &amp; Submit to Supervisor"></asp:Button>
															<asp:label id="lblErrorPassword" runat="server" CssClass="fontsmall" ForeColor="Red" Visible="False"
																Height="20px">
																<a href="JavaScript:SetFocus('txtPassword')"><b><font color="#800000">ERROR</font></b><font color='blue'>
																		- <u>Invalid Password</u></font></a></asp:label>
															<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtPassword" ErrorMessage="Password Required "></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD width="1%"></TD>
																	<TD vAlign="middle" align="left"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD bgColor="white"><INPUT class="fontsmall" id="htmbtnHome" title="Back to Select Application" style="WIDTH: 75px"
																type="button" size="20" value="Home" name="Home" onclick="GoHome()"><INPUT id="hidCommand" type="hidden"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td>
								</td>
							</tr>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
