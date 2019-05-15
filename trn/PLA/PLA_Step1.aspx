<%@ Page language="c#" Codebehind="PLA_Step1.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.PLA_Step1" %>
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
											<TD width="20%" height="1%">
												<asp:Label id="Label20" runat="server" Font-Bold="True">Privacy Notice - Submitting A Request for Training</asp:Label>
												<asp:Label id="Label21" runat="server" ForeColor="Red">*</asp:Label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" style="BORDER-BOTTOM: silver thin solid">
												<asp:Label id="lbl_fldPLAPrivacyNotice" runat="server">Star Functionality Field</asp:Label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" height="14%">
												<TABLE class="smallsize" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="20%">
															<asp:RadioButtonList id="optAgree" runat="server" RepeatDirection="Horizontal" CssClass="smallsize" AutoPostBack="True">
																<asp:ListItem Value="0">I Agree</asp:ListItem>
																<asp:ListItem Value="1">I Disagree</asp:ListItem>
															</asp:RadioButtonList></TD>
														<TD>
															<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
																ControlToValidate="optAgree"></asp:RequiredFieldValidator></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-TOP: silver thin solid" height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:LinkButton id="lnkbtnCancel" runat="server" CausesValidation="False">Cancel</asp:LinkButton>&nbsp;
									<asp:LinkButton id="lnkbtnSaveAndNext" runat="server" CausesValidation="False" Enabled="False"> Next</asp:LinkButton></TD>
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
