<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="Communication.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.Communication" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Communication Module</title>
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
		  function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" height="98%"
			cellSpacing="0" cellPadding="0" width="98%" border="0">
			<TR vAlign="top" height="1%">
				<TD>
					<TABLE id="Table1head" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD><asp:label id="LblTemplateHeader1" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD><cc1:ultimatemenu id="um" runat="server"></cc1:ultimatemenu></TD>
						</TR>
						<TR>
							<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="smallsize" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD vAlign="top" height="10%">
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
											<TD>
												<asp:label id="lblCourseName" runat="server" Font-Bold="True">Training Requested</asp:label></TD>
											<TD>
												<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
											<TD>
												<asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
									</TABLE>
									<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" height="60%">
									<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0"
										class="smallsize">
										<TR>
											<TD colSpan="3" height="1%">
												<asp:Label id="lbl_fldPla_Approval_Communication_Module" runat="server"></asp:Label>
												<asp:Label id="lbl_fldPla_Approval_Communication_ModuleCDP" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD width="30%"><DIV style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; text_aligh: left"
													align="left">
													<asp:DataGrid id="dgComm" runat="server" CssClass="smallsize" Width="100%" AutoGenerateColumns="False"
														BorderColor="White" CellPadding="1" BorderWidth="2px">
														<SelectedItemStyle BackColor="Khaki"></SelectedItemStyle>
														<ItemStyle BackColor="Gainsboro"></ItemStyle>
														<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Messages"></asp:TemplateColumn>
														</Columns>
													</asp:DataGrid></DIV>
											</TD>
											<TD vAlign="top" width="2%">&nbsp;</TD>
											<TD vAlign="top" style="BORDER-RIGHT: thin solid; BORDER-TOP: thin solid; BORDER-LEFT: thin solid; BORDER-BOTTOM: thin solid">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" class="smallsize"
													height="100%">
													<TR>
														<TD height="1%" bgColor="gold">
															<asp:LinkButton id="lmkbtnRespond" runat="server" CssClass="act_reset_button" Enabled="False">Reply </asp:LinkButton>&nbsp;</TD>
													</TR>
													<TR>
														<TD style="BORDER-BOTTOM: thin solid" height="1%"></TD>
													</TR>
													<TR>
														<TD vAlign="top">
															<asp:TextBox id="txtMessage" runat="server" Width="100%" CssClass="smallsize" TextMode="MultiLine"
																Height="100%" ReadOnly="True" BorderWidth="0px" BorderColor="White" BackColor="Gainsboro"
																BorderStyle="None"></asp:TextBox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:LinkButton id="lnkbtnBack" runat="server" CssClass="act_back_button">Back</asp:LinkButton>
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD height="1%">&nbsp;</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
			<TR vAlign="top" height="1%">
				<TD><asp:label id="LblTemplateFooter" runat="server"></asp:label></TD>
			</TR>
		</TABLE>
		<cc2:ultimatepanel id="upPO" style="Z-INDEX: 101; LEFT: 200px; POSITION: absolute; TOP: 1px" runat="server"></cc2:ultimatepanel>
	</body>
</HTML>
