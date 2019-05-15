<%@ Page language="c#" Codebehind="TrainingSummary.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.TrainingSummary" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Request Summary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover {CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
		<script>
			function RemainingLetters()
			{
			   currentStr = document.getElementById('txtDescribtion').value;
			   currentLength = currentStr.length;			   
			   document.getElementById('txtRemaining').value=4000-currentLength;
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="100%" cellSpacing="0" cellPadding="0" width="96%" align="center" border="0">
			<tr vAlign="top" height="1%">
				<td align="left" width="100%"><asp:label id="LblTemplateHeader" runat="server"></asp:label></td>
			</tr>
			<TR>
				<TD align="left" width="100%">
					<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD width="20%"><asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
							<TD><asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
						</TR>
						<TR>
							<TD><asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
							<TD><asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
						</TR>
						<TR>
							<TD><asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
							<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 16px"><asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
							<TD style="HEIGHT: 16px"><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
							<TD></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<tr vAlign="top" height="98%">
				<td vAlign="top" align="left" width="100%">
					<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 100%; text_aligh: left" align="left">
						<form id="Form1" method="post" runat="server">
							<TABLE class="smallsize" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TR>
									<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="1%"></TD>
								</TR>
								<TR>
									<TD vAlign="top" height="1%">
										<TABLE class="smallsize" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25%" bgColor="yellow" colSpan="2" height="1%"><asp:label id="Label19" runat="server" Font-Bold="True">Vendor Information</asp:label></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%"><asp:label id="Label20" runat="server">Course Code</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtCourseCode" runat="server" CssClass="smallsize" Width="350px" MaxLength="20"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD width="20%" height="1%"><asp:label id="Label4" runat="server">Course Title</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtCourseTitle" runat="server" CssClass="smallsize" Width="350px" MaxLength="50"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%"></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Underline="True">Vendor</asp:label></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label22" runat="server">Name</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtVedorName" runat="server" CssClass="smallsize" Width="350px" MaxLength="50"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label6" runat="server">Telephone & Fax</asp:label></TD>
												<TD height="1%"><asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
														runat="server" CssClass="smallsize" Width="171px" MaxLength="14"></asp:textbox>&nbsp;
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
														runat="server" CssClass="smallsize" Width="171px" MaxLength="14"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label7" runat="server">Address Line 1</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtAddressLine1" runat="server" CssClass="smallsize" Width="350px" MaxLength="30"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label8" runat="server">Address Line 2</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtAddressLine2" runat="server" CssClass="smallsize" Width="350px" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label9" runat="server">City</asp:label>&nbsp;
													<asp:label id="Label10" runat="server">State</asp:label>&nbsp;
													<asp:label id="Label11" runat="server">ZipCode</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtCity" runat="server" CssClass="smallsize" Width="119px" MaxLength="20"></asp:textbox>&nbsp;
													<asp:dropdownlist id="ddlStates" runat="server" CssClass="smallsize" Width="118px"></asp:dropdownlist>&nbsp;
													<asp:textbox id="txtZipCode" runat="server" CssClass="smallsize" Width="97px" MaxLength="10"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label24" runat="server">Web Site</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtWebSite" runat="server" CssClass="smallsize" Width="350px" MaxLength="100"></asp:textbox>&nbsp;</TD>
											</TR>
											<TR>
												<TD vAlign="top"><asp:label id="Label12" runat="server">Purpose of Training</asp:label></TD>
												<TD vAlign="top"><asp:textbox id="txtDescribtion" onkeyup="RemainingLetters()" runat="server" CssClass="smallsize"
														Width="98%" MaxLength="4000" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TABLE>
										&nbsp;</TD>
								</TR>
								<TR>
									<TD vAlign="top" height="1%">
										<TABLE class="smallsize" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="20%" bgColor="yellow" colSpan="3" height="1%"><asp:label id="Label21" runat="server" Font-Bold="True">Course Dates & Times</asp:label></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%"><asp:label id="Label29" runat="server">Course Start Date</asp:label></TD>
												<TD width="35%" height="1%"><asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtStartDate"
														runat="server" CssClass="smallsize" Width="175px" MaxLength="10"></asp:textbox><asp:label id="Label27" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
												<TD width="45%" height="1%"></TD>
											</TR>
											<TR>
												<TD width="20%" height="1%"><asp:label id="Label26" runat="server">Course End Date</asp:label></TD>
												<TD height="1%"><asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtEndDate"
														runat="server" CssClass="smallsize" Width="175px" MaxLength="10"></asp:textbox><asp:label id="Label25" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label23" runat="server">Course Time</asp:label></TD>
												<TD width="80%" colSpan="2" height="1%">
													<TABLE class="smallsize" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="20%" height="1%"><asp:radiobuttonlist id="optCoursrTime" runat="server" CssClass="smallsize" RepeatDirection="Horizontal">
																	<asp:ListItem Value="XX">N/A</asp:ListItem>
																	<asp:ListItem Value="AM">AM</asp:ListItem>
																	<asp:ListItem Value="PM">PM</asp:ListItem>
																</asp:radiobuttonlist></TD>
															<TD height="1%"><asp:label id="Label18" runat="server">( 1/2 Day Courses Only)</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label17" runat="server">Course Hours - Duty</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtCourseHoursDuty" onkeyup="AddValues()" runat="server" CssClass="smallsize"
														Width="175px" MaxLength="6">0</asp:textbox>&nbsp;
												</TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label16" runat="server">Course Hours - Non-Duty</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtCourseHoursNonDuty" onkeyup="AddValues()" runat="server" CssClass="smallsize"
														Width="175px" MaxLength="6">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label15" runat="server">Course Hours Total</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtCourseHoursTotal" runat="server" CssClass="smallsize" Width="175px" MaxLength="30"
														ReadOnly="True" BorderStyle="Solid">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
										</TABLE>
										&nbsp;</TD>
								</TR>
								<TR>
									<TD vAlign="top" height="1%">
										<TABLE class="smallsize" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25%" bgColor="#ffff00" colSpan="3" height="1%"><asp:label id="Label32" runat="server" Font-Bold="True">Training Types & Needs</asp:label></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%"><asp:label id="Label35" runat="server">Training Type</asp:label></TD>
												<TD width="30%" height="1%"><asp:dropdownlist id="ddlTrainingType" runat="server" CssClass="smallsize" AutoPostBack="True"></asp:dropdownlist></TD>
												<TD width="50%" height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label33" runat="server">Mandatory Training</asp:label></TD>
												<TD height="1%"><asp:radiobuttonlist id="optMandatoryTraining" runat="server" CssClass="smallsize" Font-Size="X-Small"
														RepeatDirection="Horizontal">
														<asp:ListItem Value="T">Yes</asp:ListItem>
														<asp:ListItem Value="F">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label31" runat="server">Source of Training</asp:label></TD>
												<TD height="1%"><asp:dropdownlist id="ddlSourseTraining" runat="server" CssClass="smallsize"></asp:dropdownlist></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label30" runat="server">Purpose of Training </asp:label></TD>
												<TD height="1%"><asp:dropdownlist id="ddlPurposeOfTraining" runat="server" CssClass="smallsize"></asp:dropdownlist></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%"><asp:label id="Label13" runat="server">Purpose of Training (other)</asp:label></TD>
												<TD height="1%"><asp:textbox id="txtPurposeOfTainingOther" runat="server" CssClass="smallsize" MaxLength="100"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3" height="1%"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" height="1%">
										<TABLE class="smallsize" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="#ffff00"><asp:label id="Label34" runat="server" Font-Bold="True">Expenses</asp:label></TD>
											</TR>
											<TR>
												<TD><asp:datagrid id="dgExpense" runat="server" CssClass="smallsize" Width="100%" AutoGenerateColumns="False">
														<SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
														<HeaderStyle Font-Bold="True" BackColor="Silver"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="expense_type" HeaderText="Expense Type">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="amount" HeaderText="Amout" DataFormatString="{0:C}">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Notes">
																<HeaderStyle Width="80%"></HeaderStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
													<TABLE class="smallsize" id="Table8" cellSpacing="0" cellPadding="0" width="100%" bgColor="#33cc00"
														border="0">
														<TR>
															<TD width="10%"><asp:label id="Label14" runat="server" Font-Bold="True" BackColor="#33CC00" ForeColor="White">Total</asp:label></TD>
															<TD><asp:label id="lblAmount" runat="server" Font-Bold="True" BackColor="#33CC00" ForeColor="White">58856.22</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="BORDER-TOP: silver thin solid" height="1%"></TD>
								</TR>
							</TABLE>
					</DIV>
			<TR>
				<TD style="BORDER-TOP: silver thin solid" height="1%">&nbsp;&nbsp;<asp:linkbutton id="lnkbtnBack" runat="server" CssClass="sct_back_button" CausesValidation="False">Back</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
			</TR>
			</FORM>
			<SCRIPT>document.focus()</SCRIPT>
			<DIV></DIV>
			</td></tr>
			<TR>
				<TD height="1%">&nbsp;</TD>
			</TR>
			<tr vAlign="top" height="1%">
				<td align="left" width="100%"><asp:label id="LblTemplateFooter" runat="server"></asp:label></td>
			</tr>
		</table>
	</body>
</HTML>
