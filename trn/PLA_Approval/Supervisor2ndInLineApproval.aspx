<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="Supervisor2ndInLineApproval.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.Supervisor2ndInLineApproval" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Supervisor2ndInLineApproval</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
			
			var estimatedValues = new Array(25);
			function addEstimatedValue(indx,dblValue)
			{
			  estimatedValues[indx] = dblValue;			  
			}
			function getvalue(indx)
			{
			  alert(estimatedValues[indx]);
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
				<TD></TD>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
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
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True">Training Requested</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD width="220">
												<asp:label id="Label28" runat="server" Font-Bold="True">Remaining Budget For: </asp:label>
												<asp:dropdownlist id="ddlBudgetYear" runat="server" CssClass="fontsmall" Width="60px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD style="BORDER-BOTTOM: silver thin solid" colSpan="2"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE class="fontsmall" id="Table9" height="25" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD colSpan="2"><asp:label id="lbl_fldPLA_ApproSupervisorApproval" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<asp:Label id="Label1" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Maroon"
													Font-Italic="True">Click on the "View This Request Summary" hyperlink below to see the vendor and other information regarding this request.</asp:Label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:LinkButton id="lnkbtnViewSummary" runat="server" Font-Bold="True" CssClass="fontsmall" CausesValidation="False">View This Request Summary</asp:LinkButton>&nbsp;</TD>
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
												<TD width="25%" height="1%">
													<asp:label id="Label20" runat="server">Event Code / Event Title</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseCode" runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="20"></asp:textbox>&nbsp;
													<asp:textbox id="txtCourseTitle" runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="50"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">
													<asp:Label id="Label35" runat="server">Location of Training</asp:Label></TD>
												<TD height="1%">
													<asp:textbox id="txtLocation" runat="server" Width="350px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="50"></asp:textbox></TD>
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
													<asp:textbox id="txtVedorName" runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="50"></asp:textbox>&nbsp;
													<asp:textbox id="txtVendorContact" runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="50"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label6" runat="server">Telephone & Fax</asp:label></TD>
												<TD height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
														runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro" MaxLength="14"></asp:textbox>&nbsp;
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
														runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro" MaxLength="14"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label7" runat="server">Address Line 1/Line 2</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtAddressLine1" runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="30"></asp:textbox>&nbsp;
													<asp:textbox id="txtAddressLine2" runat="server" Width="171px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label9" runat="server">City</asp:label>&nbsp;
													<asp:label id="Label10" runat="server">State</asp:label>&nbsp;
													<asp:label id="Label11" runat="server">Zip Code</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCity" runat="server" Width="119px" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"
														MaxLength="20"></asp:textbox>&nbsp;
													<asp:dropdownlist id="ddlStates" runat="server" Width="118px" CssClass="fontsmall" Visible="False"
														Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtState" runat="server" Width="116px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro"></asp:TextBox>&nbsp;
													<asp:textbox id="txtZipCode" runat="server" Width="97px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="10"></asp:textbox>&nbsp;
												</TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label24" runat="server">Web Site</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtWebSite" runat="server" Width="350px" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="100"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD vAlign="top">
													<asp:label id="Label12" runat="server">Purpose of Training</asp:label></TD>
												<TD vAlign="top">
													<asp:Label id="lblDescribtion" runat="server" Width="80%" BackColor="Gainsboro" BorderStyle="Solid"
														BorderColor="Black" BorderWidth="1px"></asp:Label>
													<asp:LinkButton id="lnkbtnViewDescripeValue" runat="server" CssClass="actbtn_go_next_button" CausesValidation="False">View</asp:LinkButton></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlDateTime" runat="server">
										<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="20%" bgColor="gold" colSpan="3" height="1%">
													<asp:label id="Label21" runat="server" Font-Bold="True">Course Dates & Times</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 18px" width="25%" height="18">
													<asp:label id="Label29" runat="server">Course Start Date</asp:label></TD>
												<TD style="HEIGHT: 18px" width="35%" height="18">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtStartDate"
														runat="server" Width="175px" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro" MaxLength="10"
														BorderColor="LightGray"></asp:textbox>
													<asp:label id="Label27" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
												<TD style="HEIGHT: 18px" width="45%" height="18"></TD>
											</TR>
											<TR>
												<TD width="20%" height="1%">
													<asp:label id="Label26" runat="server">Course End Date</asp:label></TD>
												<TD height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtEndDate"
														runat="server" Width="175px" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro" MaxLength="10"
														BorderColor="LightGray"></asp:textbox>
													<asp:label id="Label25" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label17" runat="server">Course Hours - Duty</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursDuty" onkeyup="AddValues()" runat="server" Width="175px" CssClass="fontsmall"
														ReadOnly="True" BackColor="Gainsboro" MaxLength="6" BorderColor="LightGray">0</asp:textbox>&nbsp;
												</TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label16" runat="server">Course Hours - Non-Duty</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursNonDuty" onkeyup="AddValues()" runat="server" Width="175px" CssClass="fontsmall"
														ReadOnly="True" BackColor="Gainsboro" MaxLength="6" BorderColor="LightGray">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label15" runat="server" Font-Bold="True">Course Hours Total</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursTotal" runat="server" Font-Bold="True" Width="175px" CssClass="fontsmall"
														ReadOnly="True" BackColor="Gainsboro" MaxLength="30" BorderStyle="Solid">0</asp:textbox></TD>
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
												<TD height="1%">
													<asp:label id="Label45" runat="server">Department ID#</asp:label></TD>
												<TD height="1%">
													<asp:TextBox id="txtDepartmentID" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"
														MaxLength="4"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label46" runat="server">Program Code</asp:label></TD>
												<TD height="1%">
													<asp:TextBox id="txtProgramCode" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"
														MaxLength="4"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label47" runat="server">Account #</asp:label></TD>
												<TD height="1%">
													<asp:RadioButton id="rbAccountNo" runat="server" Width="300px" CssClass="fontsmall" BackColor="Gainsboro"
														BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" Height="20px" Checked="True"></asp:RadioButton></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label33" runat="server">Mandatory Training</asp:label></TD>
												<TD height="1%">
													<asp:radiobuttonlist id="optMandatoryTraining" runat="server" CssClass="fontsmall" Visible="False" Font-Size="X-Small"
														RepeatDirection="Horizontal">
														<asp:ListItem Value="T">Yes</asp:ListItem>
														<asp:ListItem Value="F">No</asp:ListItem>
													</asp:radiobuttonlist>
													<asp:RadioButton id="rbMandatory" runat="server" Width="300px" CssClass="fontsmall" BackColor="Gainsboro"
														BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" Checked="True"></asp:RadioButton></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label31" runat="server">Source of Training</asp:label></TD>
												<TD height="1%">
													<asp:dropdownlist id="ddlSourseTraining" runat="server" CssClass="fontsmall" Visible="False" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtSource" runat="server" Width="300px" CssClass="fontsmall" BackColor="Gainsboro"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label30" runat="server">Purpose of Training </asp:label></TD>
												<TD height="1%">
													<asp:dropdownlist id="ddlPurposeOfTraining" runat="server" CssClass="fontsmall" Visible="False" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtPurpose" runat="server" CssClass="fontsmall" BackColor="Gainsboro"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label13" runat="server">Purpose of Training (other)</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtPurposeOfTainingOther" runat="server" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="100"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD vAlign="top" height="1%">
													<asp:Label id="Label43" runat="server">Type of Development</asp:Label></TD>
												<TD height="1%">
													<asp:Table id="tblTypeofDeve" runat="server" Width="300px" CssClass="fontsmall" BackColor="Gainsboro"
														BorderStyle="Solid" BorderColor="DimGray" BorderWidth="1px">
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
													<asp:textbox id="txtTypeofDevelopmentOther" runat="server" CssClass="fontsmall" ReadOnly="True"
														BackColor="Gainsboro" MaxLength="100"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3" height="1%"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlExpenses" runat="server" DESIGNTIMEDRAGDROP="58">
										<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="gold">
													<asp:label id="Label34" runat="server" Font-Bold="True">Expenses</asp:label></TD>
											</TR>
											<TR>
												<TD>
													<asp:DataGrid id="dgExpense" runat="server" Width="100%" CssClass="fontsmall" BorderColor="White"
														CellPadding="3" AutoGenerateColumns="False" OnItemCreated="dgExpense_ItemCreated1">
														<FooterStyle BackColor="#AAAADD"></FooterStyle>
														<SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
														<ItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#505050" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
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
															<asp:BoundColumn DataField="Approved_amount" HeaderText="Approved&lt;br&gt; Amount" DataFormatString="{0:C}">
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
															<asp:BoundColumn DataField="vendor_phone" HeaderText="Vendor Phone"></asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Action"></asp:TemplateColumn>
														</Columns>
                                                        <AlternatingItemStyle BackColor="#F0F0F0" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                            Font-Strikeout="False" Font-Underline="False" />
													</asp:DataGrid>
													<TABLE class="fontsmall" id="Table8" cellSpacing="0" cellPadding="0" width="98%" border="0">
														<TR>
															<TD width="10%">
																<asp:label id="Label14" runat="server" Font-Bold="True" ForeColor="Black">Totals</asp:label>
																<asp:Label id="lblNoteMark" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label></TD>
															<TD align="right" width="10%">
																<asp:label id="lblAmount" runat="server" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="right" width="10%">
																<asp:label id="lblApprovedAmount" runat="server" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="left" width="30%" colSpan="3">&nbsp;&nbsp;
															</TD>
															<TD align="left" width="40%"></TD>
														</TR>
														<TR>
															<TD width="10%"></TD>
															<TD align="right" width="10%"></TD>
															<TD align="right" width="10%"></TD>
															<TD align="left" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															</TD>
															<TD align="left"></TD>
														</TR>
														<TR>
															<TD colSpan="6">
																<asp:Label id="lblNoteMarkDetail" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label>
																<asp:Label id="lblNote" runat="server" CssClass="fontsmall">The Total Amounts Shown Exclude ETV Expenses.</asp:Label></TD>
															<TD width="10%"></TD>
														</TR>
														<TR>
															<TD colSpan="6">
																<asp:label id="Label18" runat="server" Font-Bold="True" ForeColor="Black">Approval Status</asp:label>:
																<asp:Label id="lblApprovalStatus" runat="server" Font-Bold="True"></asp:Label>&nbsp;
																<asp:Label id="lblPaidExceedApproved" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></TD>
															<TD width="10%"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel>&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:Button id="btnBack" runat="server" Width="75px" CssClass="fontsmall" CausesValidation="False"
										Text="Back" ToolTip="Back to Supervisor Pending Approvals"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lnkbtnBack" runat="server" CssClass="Act_Back_Button" CausesValidation="False"
										Enabled="False" Visible="False">Back</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:linkbutton id="lnkbtnNext" runat="server" CssClass="actbtn_go_next_button" CausesValidation="False"
										Visible="False">Next</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE class="fontsmall" id="TableSignature" cellSpacing="0" cellPadding="0" width="100%"
							bgColor="navajowhite" border="0">
							<TR>
								<TD style="HEIGHT: 19px" bgColor="#a52a2a">
									<asp:label id="lbl_FldPLA_ApprovalSuperVisorAbbprovalOptions" runat="server" Font-Bold="True"
										BackColor="Brown" Font-Size="Small" ForeColor="White">Second Inline Supervisor's Processing Options</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;
									<asp:label id="lblNotEnoughBudgetThisYear" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="25%">
												<asp:label id="Label4" runat="server">Training Type:</asp:label></TD>
											<TD>
												<asp:TextBox id="txtTrainingType" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro" Width="300px"></asp:TextBox>
									<asp:Button id="btnNoMoneyPeriod" runat="server" CausesValidation="False" Text="inform EE No Money Period"></asp:Button>
									<asp:Button id="btnInformee" runat="server" CausesValidation="False" Text="Inform EEcan borrow"></asp:Button></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
                                    <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="btnSave_Click"
                                        Text="Approve" ToolTip="Approve Application  and exit" Width="75px" />
                                    <asp:Button ID="btnDecline" runat="server" CssClass="fontsmall" OnClick="btnDecline_Click"
                                        Text="Decline" ToolTip="Decline Application and exit" Width="75px" /></TD>
							</TR>
							<TR>
								<TD>&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 18px" align="left" width="100%">
									<asp:label id="lblScript" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:linkbutton id="btnVendor" runat="server" CssClass="actbtn_go_next_button" Visible="False" CausesValidation="False"
										DESIGNTIMEDRAGDROP="344">(Step 1) Vendor</asp:linkbutton>
									<asp:linkbutton id="btnDateTime" runat="server" CssClass="actbtn_go_next_button" Visible="False"
										CausesValidation="False" DESIGNTIMEDRAGDROP="345">(Step 2) Course Date & Time</asp:linkbutton>
									<asp:linkbutton id="btnTypesNeeds" runat="server" CssClass="actbtn_go_next_button" Visible="False"
										CausesValidation="False" DESIGNTIMEDRAGDROP="346">(Step 3) Training Types & Needs</asp:linkbutton>
									<asp:linkbutton id="btnExpenses" runat="server" CssClass="actbtn_go_next_button" Visible="False"
										CausesValidation="False" DESIGNTIMEDRAGDROP="347">(Step 4) Expenses</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
						<TR>
							<TD align="left" width="10">
							</TD>
						</TR>
					
		</TABLE>
		<script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>
	</body>
</HTML>
