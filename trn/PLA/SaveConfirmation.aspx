<%@ Page language="c#" Codebehind="SaveConfirmation.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.SaveConfirmation" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SaveConfirmation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="1%">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%">
									<asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD>
									<asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD>
									<asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label28" runat="server" Font-Bold="True">Current Available Balance</asp:label></TD>
								<TD>
									<asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="1%">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="25%" bgColor="yellow" colSpan="2" height="1%">
									<asp:label id="Label19" runat="server" Font-Bold="True">Vendor Information</asp:label></TD>
							</TR>
							<TR>
								<TD width="25%" height="1%">
									<asp:label id="Label20" runat="server">Course Code</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtCourseCode" runat="server" MaxLength="20" Width="350px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD width="20%" height="1%">
									<asp:label id="Label4" runat="server">Course Title</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtCourseTitle" runat="server" MaxLength="50" Width="350px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%"></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label5" runat="server" Font-Bold="True" Font-Underline="True">Vendor</asp:label></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label22" runat="server">Name</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtVedorName" runat="server" MaxLength="50" Width="350px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label6" runat="server">Telephone & Fax</asp:label></TD>
								<TD height="1%">
									<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
										runat="server" MaxLength="14" Width="171px" CssClass="fontsmall"></asp:textbox>&nbsp;
									<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
										runat="server" MaxLength="14" Width="171px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label7" runat="server">Address Line 1</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtAddressLine1" runat="server" MaxLength="30" Width="350px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label8" runat="server">Address Line 2</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtAddressLine2" runat="server" MaxLength="30" Width="350px" CssClass="fontsmall"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label9" runat="server">City</asp:label>&nbsp;
									<asp:label id="Label10" runat="server">State</asp:label>&nbsp;
									<asp:label id="Label11" runat="server">ZipCode</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtCity" runat="server" MaxLength="20" Width="119px" CssClass="fontsmall"></asp:textbox>&nbsp;
									<asp:dropdownlist id="ddlStates" runat="server" Width="118px" CssClass="fontsmall"></asp:dropdownlist>&nbsp;
									<asp:textbox id="txtZipCode" runat="server" MaxLength="10" Width="97px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label24" runat="server">Web Site</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtWebSite" runat="server" MaxLength="100" Width="350px" CssClass="fontsmall"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:label id="Label12" runat="server">Purpose of Training</asp:label></TD>
								<TD vAlign="top">
									<asp:textbox id="txtDescribtion" onkeyup="RemainingLetters()" runat="server" MaxLength="4000"
										Width="98%" CssClass="fontsmall" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="1%">
						<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" bgColor="yellow" colSpan="3" height="1%">
									<asp:label id="Label21" runat="server" Font-Bold="True">Course Dates & Times</asp:label></TD>
							</TR>
							<TR>
								<TD width="25%" height="1%">
									<asp:label id="Label29" runat="server">Course Start Date</asp:label></TD>
								<TD width="35%" height="1%">
									<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtStartDate"
										runat="server" MaxLength="10" Width="175px" CssClass="fontsmall"></asp:textbox>
									<asp:label id="Label27" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
								<TD width="45%" height="1%"></TD>
							</TR>
							<TR>
								<TD width="20%" height="1%">
									<asp:label id="Label26" runat="server">Course End Date</asp:label></TD>
								<TD height="1%">
									<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtEndDate"
										runat="server" MaxLength="10" Width="175px" CssClass="fontsmall"></asp:textbox>
									<asp:label id="Label25" runat="server" Font-Size="XX-Small">(MM/DD/YYYY)</asp:label></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label23" runat="server">Course Time</asp:label></TD>
								<TD width="80%" colSpan="2" height="1%">
									<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20%" height="1%">
												<asp:radiobuttonlist id="optCoursrTime" runat="server" CssClass="fontsmall" RepeatDirection="Horizontal">
													<asp:ListItem Value="XX">N/A</asp:ListItem>
													<asp:ListItem Value="AM">AM</asp:ListItem>
													<asp:ListItem Value="PM">PM</asp:ListItem>
												</asp:radiobuttonlist></TD>
											<TD height="1%">
												<asp:label id="Label18" runat="server">( 1/2 Day Courses Only)</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label17" runat="server">Course Hours - Duty</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtCourseHoursDuty" onkeyup="AddValues()" runat="server" MaxLength="6" Width="175px"
										CssClass="fontsmall">0</asp:textbox>&nbsp;
								</TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label16" runat="server">Course Hours - Non-Duty</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtCourseHoursNonDuty" onkeyup="AddValues()" runat="server" MaxLength="6" Width="175px"
										CssClass="fontsmall">0</asp:textbox></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:Label id="Label15" runat="server">Course Hours Total</asp:Label></TD>
								<TD height="1%">
									<asp:TextBox id="txtCourseHoursTotal" runat="server" MaxLength="30" Width="175px" CssClass="fontsmall"
										BorderStyle="Solid" ReadOnly="True">0</asp:TextBox></TD>
								<TD height="1%"></TD>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="1%">
						<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="25%" bgColor="#ffff00" colSpan="3" height="1%">
									<asp:Label id="Label32" runat="server" Font-Bold="True">Training Types & Needs</asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="1%">
									<asp:Label id="Label35" runat="server">Training Type</asp:Label></TD>
								<TD width="30%" height="1%">
									<asp:DropDownList id="ddlTrainingType" runat="server" CssClass="fontsmall" AutoPostBack="True"></asp:DropDownList></TD>
								<TD width="50%" height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:Label id="Label33" runat="server">Mandatory Training</asp:Label></TD>
								<TD height="1%">
									<asp:RadioButtonList id="optMandatoryTraining" runat="server" CssClass="fontsmall" Font-Size="X-Small"
										RepeatDirection="Horizontal">
										<asp:ListItem Value="T">Yes</asp:ListItem>
										<asp:ListItem Value="F">No</asp:ListItem>
									</asp:RadioButtonList></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:Label id="Label31" runat="server">Source of Training</asp:Label></TD>
								<TD height="1%">
									<asp:DropDownList id="ddlSourseTraining" runat="server" CssClass="fontsmall"></asp:DropDownList></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:Label id="Label30" runat="server">Purpose of Training </asp:Label></TD>
								<TD height="1%">
									<asp:DropDownList id="ddlPurposeOfTraining" runat="server" CssClass="fontsmall"></asp:DropDownList></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:Label id="Label13" runat="server">Purpose of Training (other)</asp:Label></TD>
								<TD height="1%">
									<asp:TextBox id="txtPurposeOfTainingOther" runat="server" MaxLength="100" CssClass="fontsmall"></asp:TextBox></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3" height="1%"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3" height="1%">&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="1%">
						<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#ffff00">
									<asp:Label id="Label34" runat="server" Font-Bold="True">Expenses</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:DataGrid id="dgExpense" runat="server" Width="100%" CssClass="fontsmall" AutoGenerateColumns="False">
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
									</asp:DataGrid>
									<TABLE class="fontsmall" id="Table8" cellSpacing="0" cellPadding="0" width="100%" bgColor="#33cc00"
										border="0">
										<TR>
											<TD width="10%">
												<asp:Label id="Label14" runat="server" Font-Bold="True" BackColor="#33CC00" ForeColor="White">Total</asp:Label></TD>
											<TD>
												<asp:Label id="lblAmount" runat="server" Font-Bold="True" BackColor="#33CC00" ForeColor="White">58856.22</asp:Label></TD>
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
					<TD vAlign="top" height="1%"></TD>
				</TR>
				<TR>
					<TD height="1%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" height="1%"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
