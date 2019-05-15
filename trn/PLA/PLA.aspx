<%@ Page language="c#" Codebehind="PLA.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.PLA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add/Edit Submission Wizard</title>
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
			<tr vAlign="top" height="98%">
				<td vAlign="top" align="left" width="100%">
					<form id="Form1" method="post" runat="server">
						<TABLE class="smallsize" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%">
									<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20%"><asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
											<TD><asp:label id="lblEmployeeInfo" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label2" runat="server">Division</asp:label></TD>
											<TD><asp:label id="lblDivision" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server"></asp:label></TD>
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
									<TABLE class="smallsize" id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD width="25%" height="1%"><asp:label id="Label20" runat="server">Course Code</asp:label><asp:label id="Label21" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD height="1%"><asp:textbox id="txtCourseCode" runat="server" MaxLength="20" Width="350px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtCourseCode" Display="Dynamic"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%"><asp:label id="Label4" runat="server">Course Title</asp:label><asp:label id="Label13" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD height="1%"><asp:textbox id="txtCourseTitle" runat="server" MaxLength="50" Width="350px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtCourseTitle" Display="Dynamic"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD height="1%">&nbsp;</TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD height="1%"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Underline="True">Vendor</asp:label></TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD height="1%"><asp:label id="Label22" runat="server">Name</asp:label><asp:label id="Label23" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD height="1%"><asp:textbox id="txtVedorName" runat="server" MaxLength="50" Width="350px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtVedorName" Display="Dynamic"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD height="1%"><asp:label id="Label6" runat="server">Telephone & Fax</asp:label><asp:label id="Label14" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD height="1%"><asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
													runat="server" MaxLength="14" Width="171px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
													runat="server" MaxLength="14" Width="171px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Phone Required Information"
													ControlToValidate="txtPhoneNumber" Display="Dynamic"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:label id="Label7" runat="server">Address Line 1</asp:label>
												<asp:label id="Label19" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD height="1%">
												<asp:textbox id="txtAddressLine1" runat="server" CssClass="smallsize" Width="350px" MaxLength="30"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Required Information"
													ControlToValidate="txtAddressLine1" Display="Dynamic"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:label id="Label8" runat="server">Address Line 2</asp:label></TD>
											<TD height="1%">
												<asp:textbox id="txtAddressLine2" runat="server" CssClass="smallsize" Width="350px" MaxLength="30"></asp:textbox></TD>
										</TR>
										<TR>
											<TD height="1%"><asp:label id="Label9" runat="server">City</asp:label><asp:label id="Label15" runat="server" ForeColor="Red">*</asp:label>&nbsp;
												<asp:label id="Label10" runat="server">State</asp:label><asp:label id="Label16" runat="server" ForeColor="Red">*</asp:label>&nbsp;
												<asp:label id="Label11" runat="server">ZipCode</asp:label><asp:label id="Label17" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD height="1%"><asp:textbox id="txtCity" runat="server" MaxLength="20" Width="119px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:dropdownlist id="ddlStates" runat="server" Width="118px" CssClass="smallsize"></asp:dropdownlist>&nbsp;
												<asp:textbox id="txtZipCode" runat="server" MaxLength="10" Width="97px" CssClass="smallsize"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ErrorMessage="City Required Information"
													ControlToValidate="txtCity" Display="Dynamic"></asp:requiredfieldvalidator>
												<asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ErrorMessage="Zip Required Information"
													ControlToValidate="txtZipCode" Display="Dynamic"></asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Zipcode" ControlToValidate="txtZipCode"
													Display="Dynamic" ValidationExpression="\d{5}(-\d{4})?"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label24" runat="server">Wb Stie</asp:Label>
												<asp:Label id="Label25" runat="server" Font-Size="XX-Small"> (http://www.myenroll.com</asp:Label></TD>
											<TD height="1%">
												<asp:textbox id="txtWebSite" runat="server" CssClass="smallsize" Width="350px" MaxLength="100"></asp:textbox>&nbsp;
												<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Invalid Web URL" ControlToValidate="txtWebSite"
													Display="Dynamic" ValidationExpression="http://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<TD vAlign="top" height="20%">
												<asp:label id="Label12" runat="server">Describe Course Value</asp:label><asp:label id="Label18" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD vAlign="top">
												<TABLE class="smallsize" id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD width="75%" rowSpan="3"><asp:textbox id="txtDescribtion" runat="server" Width="98%" CssClass="smallsize" Height="98%"
																TextMode="MultiLine" onkeyup="RemainingLetters()" MaxLength="4000"></asp:textbox></TD>
														<TD>
															<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" ErrorMessage="Required Information"
																ControlToValidate="txtDescribtion" Display="Dynamic"></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD vAlign="top">
															<asp:Label id="Label26" runat="server">Maximum 4000 Character</asp:Label><BR>
															<asp:Label id="Label27" runat="server">Remaining</asp:Label>
															<asp:TextBox id="txtRemaining" runat="server" Width="40px" BorderColor="White" BorderStyle="None">4000</asp:TextBox></TD>
													</TR>
													<TR>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-TOP: silver thin solid" height="1%">&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%"><asp:linkbutton id="lnkbtnCancel" runat="server" CausesValidation="False">Cancel</asp:linkbutton>&nbsp;&nbsp;<asp:linkbutton id="lnkbtnBack" runat="server" CausesValidation="False">Back</asp:linkbutton>&nbsp;&nbsp;<asp:linkbutton id="lnkbtnSaveAndStay" runat="server"> Save</asp:linkbutton>&nbsp;&nbsp;<asp:linkbutton id="lnkbtnSaveAndNext" runat="server"> Next</asp:linkbutton></TD>
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
