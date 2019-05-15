<%@ Page language="c#" Codebehind="MoreReports.aspx.cs" AutoEventWireup="false" Inherits="PLA_Homes.MoreReports" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD id="Head1">
		<title>Know the Facts: Available Reports Listin</title>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
			<script>
        function GoBack()
        {
            strURL = document.getElementById("lblHidden").value;
            alert(document.getElementById('lblHidden').value);
            alert(document.getElementById("lblHidden").Value);
            window.location.href=strURL;
        }
			</script>
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<div>
				
							<table style="BORDER-RIGHT: #d8d8d8 1px solid; BORDER-TOP: #d8d8d8 1px solid; BORDER-LEFT: #d8d8d8 1px solid; WIDTH: 795px; BORDER-BOTTOM: #d8d8d8 1px solid; HEIGHT: 1px"
								cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<td class="header_cell" width="11"></td>
									<td class="Header_cell"><asp:label id="lblTitle" runat="server" Text="Generate Personalized, Bar Coded Flexible Spending Account Claim Forms">Know the Facts: Available Reports Listing</asp:label></td>
								</tr>
								<tr>
									<td class="Instruction_cell" width="11" height="60"></td>
									<td class="Instruction_cell" height="60"><asp:label id="lblInstruction" runat="server" Text="Choose to generate a PDF of your personalized, bar coded claim form. Your selection will appear in a separate browser window. Within your browser window that pops up you can use the browser’s print and save functions to print and save your PDF.">Choose a report below by clicking on the report name.  This window will remain open underneath the report window that appears from your selection. To close this window, click the “Cancel” button in the lower left</asp:label></td>
								</tr>
								<tr>
									<td class="Body_cell" width="11"></td>
									<td class="Body_cell">
										<table class="body_cell" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td height="5"></td>
											</tr>
											<tr>
												<td><asp:label id="lblReportNameTitle" runat="server" Font-Underline="True">Report Name</asp:label></td>
											</tr>
											<tr>
												<td height="5"></td>
											</tr>
											<tr>
												<td>
													<TABLE class="body_cell" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD><asp:linkbutton id="lnkbtnRequestinLast7Days" runat="server" CssClass="homepage">Requests in last 7 days</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD><asp:linkbutton id="lnkbtnPaidInLast7Days" runat="server" CssClass="homepage">Paid in last 7 days</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD><asp:linkbutton id="lnkbtnDeclinedInLastSevenDays" runat="server" CssClass="homepage">Declined in last 7 days</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD><asp:linkbutton id="lnkbtnEmployeeOverBudget" runat="server" CssClass="homepage">Employees over budget</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD><asp:linkbutton id="lnkbtnCDPEmployeeList" runat="server">FDIC - CDP Employee List</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD><asp:linkbutton id="lnkbtnComprehense" runat="server">FDIC - Comprehensive Training Request Listing</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD><asp:linkbutton id="lnkbtnNoCDP" runat="server">FDIC Employees with No CDP</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD></TD>
														</TR>
													</TABLE>
												</td>
											</tr>
											<tr>
												<td height="5"></td>
											</tr>
											<tr>
												<td><asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="General_button" CausesValidation="False"></asp:button></td>
											</tr>
											<tr>
												<td height="5"></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td class="Footer_cell" width="11" style="height: 30px"></td>
									<td class="Footer_cell" style="height: 30px"><asp:label id="lblHidden" runat="server" CssClass="footer_cell"></asp:label><asp:label id="lblScript" runat="server"></asp:label></td>
								</tr>
							</table>
						
			</div>
		</form>
	</body>
</HTML>
