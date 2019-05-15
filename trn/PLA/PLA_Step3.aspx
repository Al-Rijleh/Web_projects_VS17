<%@ Page language="c#" Codebehind="PLA_Step3.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.PLA_Step3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Formulas Setup</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { COLOR: red; TEXT-DECORATION: underline }
		</style>
		<script>
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
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="100%" cellSpacing="0" cellPadding="0" width="96%" align="center" border="0">
			<tr vAlign="top" height="1%">
				<td align="left" width="100%"><asp:label id="LblTemplateHeader" runat="server"></asp:label></td>
			</tr>
			<tr vAlign="top" height="98%">
				<td vAlign="top" align="left" width="100%">
					<form id="Form1" method="post" runat="server">
						<TABLE class="smallsize" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%"><TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20%">
												<asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
											<TD>
												<asp:label id="lblEmployeeInfo" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label2" runat="server">Division</asp:label></TD>
											<TD>
												<asp:label id="lblDivision" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
											<TD>
												<asp:label id="lblCourseTitle" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" height="60%">
									<TABLE class="smallsize" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20%" height="1%">
												<asp:Label id="Label20" runat="server">Course Start Date</asp:Label>
												<asp:Label id="Label21" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD width="35%" height="1%">
												<asp:TextBox id="txtStartDate" runat="server" CssClass="smallsize" Width="175px" MaxLength="10"
													onKeyPress="javascript:return dFilter(event.keyCode, this, '##/##/####');"></asp:TextBox>
												<asp:Label id="Label5" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:Label></TD>
											<TD width="45%" height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtStartDate" Display="Dynamic"></asp:RequiredFieldValidator>
												<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Incorrect Date" ControlToValidate="txtStartDate"
													Display="Dynamic" Type="Date" MaximumValue="1/1/3000" MinimumValue="1/1/1000"></asp:RangeValidator></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%">
												<asp:Label id="Label4" runat="server">Course End Date</asp:Label>
												<asp:Label id="Label13" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD height="1%">
												<asp:TextBox id="txtEndDate" runat="server" CssClass="smallsize" Width="175px" MaxLength="10"
													onKeyPress="javascript:return dFilter(event.keyCode, this, '##/##/####');"></asp:TextBox>
												<asp:Label id="Label9" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:Label></TD>
											<TD height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtEndDate" Display="Dynamic"></asp:RequiredFieldValidator>
												<asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="Incorrect Date" ControlToValidate="txtEndDate"
													Display="Dynamic" Type="Date" MaximumValue="1/1/3000" MinimumValue="1/1/1000"></asp:RangeValidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label22" runat="server">Course Time</asp:Label></TD>
											<TD width="80%" colSpan="2" height="1%">
												<TABLE class="smallsize" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="20%" height="1%">
															<asp:RadioButtonList id="optCoursrTime" runat="server" CssClass="smallsize" RepeatDirection="Horizontal">
																<asp:ListItem Value="XX">N/A</asp:ListItem>
																<asp:ListItem Value="AM">AM</asp:ListItem>
																<asp:ListItem Value="PM">PM</asp:ListItem>
															</asp:RadioButtonList></TD>
														<TD height="1%">
															<asp:Label id="Label10" runat="server">( 1/2 Day Courses Only)</asp:Label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label6" runat="server">Course - Duty</asp:Label>
												<asp:Label id="Label14" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD height="1%">
												<asp:TextBox id="txtCourseHoursDuty" onkeyup="AddValues()" runat="server" MaxLength="6" Width="175px"
													CssClass="smallsize">0</asp:TextBox>&nbsp;
											</TD>
											<TD height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtCourseHoursDuty"
													ErrorMessage="Required Information"></asp:RequiredFieldValidator>
												<asp:RangeValidator id="RangeValidator3" runat="server" Display="Dynamic" ControlToValidate="txtCourseHoursDuty"
													ErrorMessage="Incorrect Number" MinimumValue="0" MaximumValue="100000" Type="Double"></asp:RangeValidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label7" runat="server">Course Non-Duty</asp:Label>
												<asp:Label id="Label19" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD height="1%">
												<asp:TextBox onkeyup="AddValues()" id="txtCourseHoursNonDuty" runat="server" CssClass="smallsize"
													Width="175px" MaxLength="6">0</asp:TextBox></TD>
											<TD height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtCourseHoursNonDuty" Display="Dynamic"></asp:RequiredFieldValidator>
												<asp:RangeValidator id="RangeValidator4" runat="server" ErrorMessage="Incorrect Number" ControlToValidate="txtCourseHoursNonDuty"
													Display="Dynamic" Type="Double" MaximumValue="100000" MinimumValue="0"></asp:RangeValidator></TD>
										</TR>
										<TR>
											<TD style="BORDER-TOP: black 2pt solid" height="1%">&nbsp;</TD>
											<TD style="BORDER-TOP: black 2pt solid" height="1%">&nbsp;</TD>
											<TD style="BORDER-TOP: black 2pt solid" height="1%">&nbsp;</TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label8" runat="server" Font-Bold="True">Course Hours Total</asp:Label></TD>
											<TD height="1%">
												<asp:TextBox id="txtCourseHoursTotal" runat="server" CssClass="smallsize" Width="175px" MaxLength="30"
													Font-Bold="True" ReadOnly="True" BorderStyle="Solid">0</asp:TextBox></TD>
											<TD height="1%">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-TOP: silver thin solid" height="1%">&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:LinkButton id="lnkbtnCancel" runat="server" CausesValidation="False">Cancel</asp:LinkButton>&nbsp;
									<asp:LinkButton id="lnkbtnBack" runat="server" CausesValidation="False">Back</asp:LinkButton>&nbsp;
									<asp:LinkButton id="lnkbtnSaveAndStay" runat="server"> Save</asp:LinkButton>&nbsp;
									<asp:LinkButton id="lnkbtnSaveAndNext" runat="server" CausesValidation="False"> Next</asp:LinkButton></TD>
							</TR>
						</TABLE>
						&nbsp;
					</form>
					<SCRIPT>document.focus()</SCRIPT>
				</td>
			</tr>
			<tr vAlign="top" height="1%">
				<td align="left" width="100%"><asp:label id="LblTemplateFooter" runat="server"></asp:label></td>
			</tr>
		</table>
	</body>
</HTML>
