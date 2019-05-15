<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="PayorApprovalPage.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.PayorApprovalPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Payor Approval Page</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="-1"> 
		<script src="/js/dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
			function Inform(btnname)
			{
				var fRet; 
				fRet = confirm('Are you sure?'); 
				if (fRet == true) 
				  window.document.getElementById(btnname).click();
			}
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
			function CheckReroute(strSupName)
	        {
	            var retResult = confirm('Are you sure you want to reroute this application to supervisor '+strSupName);
	            if (retResult)
	            {
	                eval(document.getElementById('hidReroute')).value = 'Reroute',
	                Form1.submit();
	            }
	        }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
			</TR>
			<TR vAlign="top" height="1%">
				<TD></TD>
				<TD>
			<TR>
				<TD width="10" style="height: 18px">&nbsp;</TD>
				<TD style="height: 18px"><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TD>
			</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top" width="10"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="height: 25px" colspan="2" valign="top"><asp:label id="Label3" runat="server" Font-Bold="True" CssClass="fontsmall">Training Requested</asp:label>
                                                &nbsp; &nbsp; &nbsp;
                                                <asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label>&nbsp;
                                                <asp:HiddenField ID="hidReroute" runat="server" />
                                            </TD>
										</TR>
										<TR>
											<TD><asp:label id="Label28" runat="server" Font-Bold="True" CssClass="fontsmall">Remaining Budget For: </asp:label><asp:dropdownlist id="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall"></asp:dropdownlist>
                                                &nbsp; &nbsp;&nbsp;
                                                <asp:label id="lblBalance" runat="server" Font-Bold="True" CssClass="fontsmall">$2,500.00</asp:label></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="BORDER-BOTTOM: silver thin solid" colSpan="2">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="2"><asp:label id="lbl_fldPLA_ApproPayorApproval" runat="server" CssClass="fontsmall"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<asp:Label id="Label1" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Maroon"
													Font-Italic="True">Click on the "View This Request Summary" hyperlink below to see the vendor and other information regarding this request.</asp:Label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
												<asp:LinkButton id="lnkbtnViewSummary" runat="server" CssClass="fontsmall" Font-Bold="True" CausesValidation="False"
													ToolTip="View This Request Summary">View This Request Summary</asp:LinkButton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><asp:panel id="pnlVendor" runat="server">
										<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25%" bgColor="gold" colSpan="2" height="1%">
													<asp:label id="Label19" runat="server" Font-Bold="True">Vendor Information</asp:label></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">&nbsp;</TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">
													<asp:label id="Label20" runat="server">Event Code / Event Title</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseCode" runat="server" CssClass="fontsmall" Width="171px" MaxLength="20"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
													<asp:textbox id="txtCourseTitle" runat="server" CssClass="fontsmall" Width="171px" MaxLength="50"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">
													<asp:Label id="Label4" runat="server">Location of Training</asp:Label></TD>
												<TD height="1%">
													<asp:textbox id="txtLocation" runat="server" CssClass="fontsmall" Width="350px" MaxLength="50"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label5" runat="server" Font-Bold="True" Font-Underline="True">Vendor</asp:label></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label22" runat="server">Vendor Name / Contact Person</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtVedorName" runat="server" CssClass="fontsmall" Width="171px" MaxLength="50"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
													<asp:textbox id="txtVendorContact" runat="server" CssClass="fontsmall" Width="171px" MaxLength="50"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label6" runat="server">Telephone & Fax</asp:label></TD>
												<TD height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
														runat="server" CssClass="fontsmall" Width="171px" MaxLength="14" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
														runat="server" CssClass="fontsmall" Width="171px" MaxLength="14" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label7" runat="server">Address Line 1/Line 2</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtAddressLine1" runat="server" CssClass="fontsmall" Width="171px" MaxLength="30"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
													<asp:textbox id="txtAddressLine2" runat="server" CssClass="fontsmall" Width="171px" MaxLength="30"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 19px" height="19">
													<asp:label id="Label9" runat="server">City</asp:label>&nbsp;
													<asp:label id="Label10" runat="server">State</asp:label>&nbsp;
													<asp:label id="Label11" runat="server">Zip Code</asp:label></TD>
												<TD style="HEIGHT: 19px" height="19">
													<asp:textbox id="txtCity" runat="server" CssClass="fontsmall" Width="119px" MaxLength="20" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox>&nbsp;
													<asp:dropdownlist id="ddlStates" runat="server" CssClass="fontsmall" Width="118px" Visible="False"
														Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtState" runat="server" CssClass="fontsmall" Width="118px" ReadOnly="True"
														BackColor="Gainsboro"></asp:TextBox>&nbsp;
													<asp:textbox id="txtZipCode" runat="server" CssClass="fontsmall" Width="97px" MaxLength="10"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label24" runat="server">Web Site</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtWebSite" runat="server" CssClass="fontsmall" Width="350px" MaxLength="100"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD vAlign="top">
													<asp:label id="Label12" runat="server">Purpose of Training</asp:label></TD>
												<TD vAlign="top">
													<asp:Label id="lblDescribtion" runat="server" Width="70%" BackColor="Gainsboro" BorderWidth="1px"
														BorderColor="Black" BorderStyle="Solid"></asp:Label>
													<asp:LinkButton id="lnkbtnViewDescripeValue" runat="server" CssClass="actbtn_go_next_button">View full comments</asp:LinkButton></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlDateTime" runat="server">
										<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="20%" bgColor="gold" colSpan="3" height="1%">
													<asp:label id="Label21" runat="server" Font-Bold="True">Course Dates & Times</asp:label></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">&nbsp;</TD>
												<TD width="35%" height="1%"></TD>
												<TD width="45%" height="1%"></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">
													<asp:label id="Label29" runat="server">Course Start Date</asp:label></TD>
												<TD width="35%" height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtStartDate"
														runat="server" CssClass="fontsmall" Width="175px" MaxLength="10" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
													<asp:label id="Label27" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
												<TD width="45%" height="1%"></TD>
											</TR>
											<TR>
												<TD width="20%" height="1%">
													<asp:label id="Label26" runat="server">Course End Date</asp:label></TD>
												<TD height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtEndDate"
														runat="server" CssClass="fontsmall" Width="175px" MaxLength="10" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>
													<asp:label id="Label25" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label17" runat="server">Course Hours - Duty</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursDuty" onkeyup="AddValues()" runat="server" CssClass="fontsmall"
														Width="175px" MaxLength="6" ReadOnly="True" BackColor="Gainsboro">0</asp:textbox>&nbsp;
												</TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label16" runat="server">Course Hours - Non-Duty</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursNonDuty" onkeyup="AddValues()" runat="server" CssClass="fontsmall"
														Width="175px" MaxLength="6" ReadOnly="True" BackColor="Gainsboro">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label15" runat="server" Font-Bold="True">Course Hours Total</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursTotal" runat="server" CssClass="fontsmall" Font-Bold="True" Width="175px"
														MaxLength="30" ReadOnly="True" BackColor="Gainsboro" BorderStyle="Solid">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlTypesNeeds" runat="server">
										<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25%" bgColor="gold" colSpan="3" height="1%">
													<asp:label id="Label32" runat="server" Font-Bold="True">Training Types & Needs</asp:label></TD>
											</TR>
											<TR>
												<TD height="1%">&nbsp;</TD>
												<TD height="1%"></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label45" runat="server">Department ID#</asp:label></TD>
												<TD height="1%">
													<asp:TextBox id="txtDepartmentID" runat="server" CssClass="fontsmall" MaxLength="4" ReadOnly="True"
														BackColor="Gainsboro"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label46" runat="server">Program Code</asp:label></TD>
												<TD height="1%">
													<asp:TextBox id="txtProgramCode" runat="server" CssClass="fontsmall" MaxLength="4" ReadOnly="True"
														BackColor="Gainsboro"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label47" runat="server">Account #</asp:label></TD>
												<TD height="1%">
													<asp:RadioButton id="rbAccountNo" runat="server" CssClass="fontsmall" Width="300px" BackColor="Gainsboro"
														BorderWidth="1px" BorderColor="Black" BorderStyle="Solid" Checked="True" Height="20px"></asp:RadioButton></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label31" runat="server">Source of Training</asp:label></TD>
												<TD height="1%">
													<asp:dropdownlist id="ddlSourseTraining" runat="server" CssClass="fontsmall" Visible="False" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtSource" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label30" runat="server">Purpose of Training </asp:label></TD>
												<TD height="1%">
													<asp:dropdownlist id="ddlPurposeOfTraining" runat="server" CssClass="fontsmall" Visible="False" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtPurpose" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label13" runat="server">Purpose of Training (other)</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtPurposeOfTainingOther" runat="server" CssClass="fontsmall" MaxLength="100"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD vAlign="top" height="1%">
													<asp:Label id="Label43" runat="server">Type of Development</asp:Label></TD>
												<TD height="1%">
													<asp:Table id="tblTypeofDeve" runat="server" CssClass="fontsmall" Width="300px" BackColor="Gainsboro"
														BorderWidth="1px" BorderColor="DimGray" BorderStyle="Solid">
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
														<asp:TableRow>
															<asp:TableCell></asp:TableCell>
															<asp:TableCell></asp:TableCell>
														</asp:TableRow>
													</asp:Table></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:Label id="Label44" runat="server">Type of Development (other)</asp:Label></TD>
												<TD height="1%">
													<asp:textbox id="txtTypeofDevelopmentOther" runat="server" CssClass="fontsmall" MaxLength="100"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3" height="1%"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlExpenses" runat="server" DESIGNTIMEDRAGDROP="330">
										<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="gold">
													<asp:label id="Label34" runat="server" CssClass="fontsmall" Font-Bold="True">Expenses</asp:label></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD>
													<asp:DataGrid id="dgExpense" runat="server" CssClass="fontsmall" Width="795px" BorderColor="White"
														CellPadding="3" AutoGenerateColumns="False">
														<SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="expense_type" HeaderText="Expense Type">
															</asp:BoundColumn>
															<asp:BoundColumn DataField="amount" HeaderText="Estimated&lt;br&gt; Amount" DataFormatString="{0:C}">
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Approved&lt;br&gt; Amount">
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Paid&lt;br&gt;Amount">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Paid&lt;br&gt;Amount">
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="vendor_name" HeaderText="Vendor Name">
															</asp:BoundColumn>
															<asp:BoundColumn DataField="vendor_contact_name" HeaderText="Vendor Contact">
															</asp:BoundColumn>
															<asp:BoundColumn DataField="vendor_phone" HeaderText="Vendor Phone">
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
														</Columns>
													</asp:DataGrid>
													<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="10%">
																<asp:label id="Label23" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">Totals</asp:label>
																<asp:Label id="lblNoteMark" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label></TD>
															<TD align="right" width="10%">
																<asp:label id="lblAmount" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="right" width="10%">
																<asp:label id="lblApprovedAmount" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="right" width="10%">
																<asp:label id="lblTotalPaid" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="left" width="30%" colSpan="3">&nbsp;&nbsp;
																<asp:LinkButton id="lnkbtnCopyAll" runat="server" CssClass="input_control_small" CausesValidation="False" OnClick="lnkbtnCopyAll_Click1">Pay All Approved Amounts</asp:LinkButton></TD>
															<TD align="left" width="30%">
																<asp:LinkButton id="lnkbtnEdit" runat="server" CssClass="input_control_small" CausesValidation="False" OnClick="lnkbtnEdit_Click1">Edit Paid Amount</asp:LinkButton></TD>
														</TR>
														<TR>
															<TD width="10%"></TD>
															<TD align="right" width="10%"></TD>
															<TD align="right" width="10%"></TD>
															<TD align="right" width="10%"></TD>
															<TD align="left" width="30%" colSpan="3">&nbsp;&nbsp;
																<asp:LinkButton id="lnkbtnSaveApprovedAmount" runat="server" CssClass="input_control_small" CausesValidation="False" OnClick="lnkbtnSaveApprovedAmount_Click1">Save Paid Amount</asp:LinkButton></TD>
															<TD align="left" width="30%">
																<asp:LinkButton id="lnkbtnCancelChanges" runat="server" CssClass="input_control_small" CausesValidation="False" OnClick="lnkbtnCancelChanges_Click1">Cancel Changes</asp:LinkButton></TD>
														</TR>
														<TR>
															<TD colSpan="8">
																<asp:Label id="lblNoteMarkDetail" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label>
																<asp:Label id="lblNote" runat="server" CssClass="fontsmall">The Total Amounts Shown Exclude ETV Expenses.</asp:Label></TD>
														</TR>
														<TR>
															<TD width="10%" colSpan="7">
																<asp:label id="Label18" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">Approval Status</asp:label>:&nbsp;
																<asp:Label id="lblApprovalStatus" runat="server" CssClass="fontsmall" Font-Bold="True"></asp:Label>&nbsp;
																<asp:Label id="lblPaidExceedApproved" runat="server" CssClass="fontsmall" Font-Bold="True"
																	ForeColor="Red"></asp:Label>
																<asp:textbox id="Blinker" runat="server" Font-Bold="True" Width="250px" ForeColor="Red" ReadOnly="True"
																	BorderColor="White" BorderStyle="None" Font-Size="X-Small" Font-Names="Arial">blinker</asp:textbox></TD>
															<TD width="10%"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 19px">
                                    &nbsp;<asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home"
                                        ToolTip="Return to main administrator page" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                                    <asp:Button ID="btnViewDocuments" runat="server" Text="View Documents" Visible="False" ToolTip="View Documents" CausesValidation="False" OnClick="btnViewDocuments_Click" />
                                    <asp:Label ID="lblNew" runat="server" BackColor="Yellow" CssClass="fontsmall" Font-Bold="True"
                                        Font-Italic="True" ForeColor="Red" Text="(New)" Visible="False"></asp:Label>    
                                    <asp:linkbutton id="lnkbtnNext" runat="server" CssClass="actbtn_go_next_button" Enabled="False"
										Visible="False">Next</asp:linkbutton>
                                    <asp:linkbutton id="lnkbtnBack" runat="server" CssClass="act_back_button" Visible="False">Back</asp:linkbutton>
                                    
                                </TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="TableSignature" cellSpacing="0" cellPadding="0" width="100%"
										bgColor="navajowhite" border="0">
										<TR>
											<TD bgColor="white">&nbsp;</TD>
											<TD style="WIDTH: 136px" bgColor="#ffffff"></TD>
											<TD bgColor="#ffffff"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 15px" bgColor="brown">
												<asp:label id="lbl_fld_pla_approval_payorApplrovalPage_Option" runat="server" Font-Bold="True"
													CssClass="fontsmall" BackColor="Brown" Font-Size="Small" ForeColor="White">Payor's Processing Options</asp:label></TD>
											<TD style="WIDTH: 136px; HEIGHT: 15px" bgColor="#a52a2a"></TD>
											<TD style="HEIGHT: 15px" bgColor="#a52a2a"></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="lblNotEnoughBudgetThisYear" runat="server" Font-Bold="True" CssClass="fontsmall"
													ForeColor="Red"></asp:label></TD>
											<TD style="WIDTH: 136px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="lblNoCreereDevelopmentPlan" runat="server" CssClass="fontsmall" Font-Bold="True"
													Width="100%" ForeColor="White" BackColor="#FF5600" Visible="False">Note: Employee does not  have an approved Career Development Plan</asp:label></TD>
											<TD style="WIDTH: 136px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD height="5">
												<asp:CheckBox id="cbEEFilledServiceAgreement" runat="server" Font-Bold="True" CssClass="fontsmall"
													AutoPostBack="True" Font-Underline="True" Visible="False" Text="Check this box if the employee has completed the Continued Service Agreement Form<br>"></asp:CheckBox>&nbsp;</TD>
											<TD style="WIDTH: 136px" height="5"></TD>
											<TD height="5"></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<asp:label id="Label37" runat="server" CssClass="fontsmall">Reroute Application to Different Administrator</asp:label>&nbsp;
												<asp:textbox id="txtSupervisorName" runat="server" CssClass="input_control_small" BackColor="Gainsboro"
													ReadOnly="True"></asp:textbox>&nbsp;
												<asp:button id="btnSelect" runat="server" CssClass="fontsmall" CausesValidation="False" Text="Reroute"></asp:button>
												<asp:button id="btnInformee" runat="server" CausesValidation="False" Text="Inform EEcan borrow"></asp:button>
												<asp:button id="btnNoMoneyPeriod" runat="server" CausesValidation="False" Text="inform EE No Money Period"></asp:button>
												<asp:button id="btnCannotVerify" runat="server" CausesValidation="False" Text="Cannot Verify"></asp:button>
												<asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<asp:Label id="lblRequisitionNumber" runat="server" CssClass="fontsmall">Enter Document/Purchase Order/Requisition Number for reimbursement of training costs to responsible Training Vendor. (Optional)</asp:Label></TD>
														<TD>
															<asp:TextBox id="txtrequisitionnumber" runat="server" CssClass="input_control_small" MaxLength="50"></asp:TextBox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="3">&nbsp;</TD>
										</TR>
										<TR>
											<TD style="height: 22px">
                                                <asp:Button ID="btnFinalize" runat="server" CssClass="fontsmall" OnClick="btnFinalize_Click"
                                                    Text="Finalize Request" />
                                                <asp:Button ID="btnRequestMoreInfo" runat="server" CssClass="fontsmall" OnClick="btnRequestMoreInfo_Click"
                                                    Text="Request More Information" ToolTip="Request More Information from applicant" /></TD>
											<TD style="WIDTH: 136px; height: 22px;"></TD>
											<TD style="height: 22px"></TD>
										</TR>
										<TR>
											<TD>&nbsp;&nbsp;</TD>
											<TD style="WIDTH: 136px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="Label8" runat="server" CssClass="fontsmall" Font-Bold="True" Visible="False"
										DESIGNTIMEDRAGDROP="343">Request Steps:</asp:label>
									<asp:linkbutton id="btnVendor" runat="server" CssClass="actbtn_go_next_button" Visible="False" CausesValidation="False"
										DESIGNTIMEDRAGDROP="344">(Step 1) Vendor</asp:linkbutton>
									<asp:linkbutton id="btnDateTime" runat="server" CssClass="actbtn_go_next_button" Visible="False"
										CausesValidation="False" DESIGNTIMEDRAGDROP="345">(Step 2) Course Date & Time</asp:linkbutton>
									<asp:linkbutton id="btnTypesNeeds" runat="server" CssClass="actbtn_go_next_button" Visible="False"
										CausesValidation="False" DESIGNTIMEDRAGDROP="346">(Step 3) Training Types & Needs</asp:linkbutton>
									<asp:linkbutton id="btnExpenses" runat="server" CssClass="actbtn_go_next_button" Visible="False"
										CausesValidation="False" DESIGNTIMEDRAGDROP="347">(Step 4) Expenses</asp:linkbutton></TD>
							</TR>
						</TABLE></form>

				</TD>
			</TR>
						
					
		</TABLE>
		<script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>
	</body>
</HTML>
