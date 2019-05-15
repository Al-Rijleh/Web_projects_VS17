<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="Communication.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.Communication" validateRequest=false  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Communication Module</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
		  function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" >
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
			</TR>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="fontsmall" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD vAlign="top" height="1%">
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="2">
												<asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course:</asp:label>&nbsp;&nbsp;
												<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" height="60%">
									<TABLE class="fontsmall" id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD vAlign="top" width="237">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 290px; text_aligh: left" align="left"
																class="fontsmall">
																<asp:datagrid id="dgComm" runat="server" BorderWidth="1px" CellPadding="1" BorderColor="Black"
																	AutoGenerateColumns="False" Width="100%" CssClass="fontsmall" GridLines="Horizontal">
																	<SelectedItemStyle BackColor="Khaki"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
																	<ItemStyle BackColor="White"></ItemStyle>
																	<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Messages"></asp:TemplateColumn>
																	</Columns>
																</asp:datagrid></DIV>
														</TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
													</TR>
													<TR>
														<TD>
															<asp:Button id="btnBack" runat="server" Width="75px" CssClass="fontsmall" Text="Back"></asp:Button><asp:label id="lblScript" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="top" width="10">&nbsp;</TD>
											<TD style="BORDER-RIGHT: thin solid; BORDER-TOP: thin solid; BORDER-LEFT: thin solid; BORDER-BOTTOM: thin solid"
												vAlign="top" width="540"><asp:panel id="pnlView" runat="server">
													<TABLE class="fontsmall" id="Table4" style="HEIGHT: 261px" height="261" cellSpacing="0"
														cellPadding="0" width="543" border="0">
														<TR>
															<TD height="1">&nbsp;
																<asp:Label id="Label7" runat="server" CssClass="FontSmallTitle">Message</asp:Label>&nbsp; 
																&nbsp;
																<asp:Button id="btnReply" runat="server" CssClass="fontsmall" Text="Reply" Enabled="False"></asp:Button></TD>
														</TR>
														<TR>
															<TD style="BORDER-BOTTOM: thin solid" height="1"></TD>
														</TR>
														<TR>
															<TD vAlign="top" width="543">
																<asp:TextBox id="txtMessage" runat="server" CssClass="fontsmall" Width="543px" BorderColor="White"
																	BorderWidth="0px" TextMode="MultiLine" Height="100%" ReadOnly="True" BorderStyle="None" BackColor="Gainsboro"></asp:TextBox></TD>
														</TR>
													</TABLE>
												</asp:panel><asp:panel id="pnlReply" runat="server" Visible="False">
													<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD vAlign="top">
																<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD style="BORDER-BOTTOM: silver 1px solid" colSpan="2">
																			<asp:Label id="Label14" runat="server" CssClass="FontSmallTitle">Response</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD colSpan="2">
																			<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="fontsmall" DisplayMode="List"></asp:ValidationSummary>
																			<asp:label id="lblPassordError2" runat="server" ForeColor="Red" CssClass="fontsmall">
																				<a href="JavaScript:SetFocus('txtPassword')"><b><font color="#800000">ERROR</font></b><font color='blue'>
																						- <u>Invalid Password</u></font></a></asp:label></TD>
																	</TR>
																	<TR>
																		<TD width="200">
																			<asp:Label id="Label12" runat="server" Font-Bold="True" CssClass="fontsmall">Original Message  From:</asp:Label></TD>
																		<TD>&nbsp;
																			<asp:Label id="lblFromPosition" runat="server" CssClass="fontsmall"></asp:Label>&nbsp;-
																			<asp:Label id="lblFromName" runat="server" CssClass="fontsmall"></asp:Label></TD>
																	</TR>
																	<TR>
																		<TD width="185">
																			<asp:Label id="Label13" runat="server" Font-Bold="True" CssClass="fontsmall">Original Message To:</asp:Label></TD>
																		<TD>&nbsp;
																			<asp:Label id="lblToPosition" runat="server" CssClass="fontsmall"></asp:Label>&nbsp;-
																			<asp:Label id="lblToName" runat="server" CssClass="fontsmall"></asp:Label></TD>
																	</TR>
																	<TR>
																		<TD style="BORDER-TOP: silver thin solid">
																			<asp:Label id="Label6" runat="server" Font-Bold="True" CssClass="fontsmall">Reply From</asp:Label></TD>
																		<TD style="BORDER-TOP: silver thin solid">&nbsp;
																			<asp:Label id="lblReplayFrom" runat="server" CssClass="fontsmall"></asp:Label></TD>
																	</TR>
																	<TR>
																		<TD vAlign="top">
																			<asp:Label id="Label9" runat="server" Font-Bold="True" CssClass="fontsmall">Reply To</asp:Label></TD>
																		<TD>
																			<asp:CheckBoxList id="chklstEmailTo" runat="server" CssClass="fontsmall" Width="100%"></asp:CheckBoxList></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD vAlign="top" height="5"></TD>
														</TR>
														<TR>
															<TD height="1%">
																<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD style="WIDTH: 200px" width="200">
																			<asp:label id="Label4" runat="server" CssClass="fontsmall">Message Subject</asp:label></TD>
																		<TD width="10">
																			<asp:label id="Label2" runat="server" ForeColor="Maroon" CssClass="fontsmall">| </asp:label></TD>
																		<TD width="320">
																			<asp:textbox id="txtSubject" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
																				Width="300px" MaxLength="255"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px" width="200"></TD>
																		<TD width="1"></TD>
																		<TD width="326">
																			<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" CssClass="fontsmall" Display="Dynamic"
																				ErrorMessage="Message Subject is Required" ControlToValidate="txtSubject"></asp:RequiredFieldValidator></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px" vAlign="top">
																			<asp:label id="Label5" runat="server" CssClass="fontsmall"> Message Body</asp:label><BR>
																			&nbsp;<BR>
																			<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="fontsmall" Display="Dynamic"
																				ErrorMessage="Message Body is Required" ControlToValidate="txtMemo"></asp:requiredfieldvalidator></TD>
																		<TD>
																			<asp:label id="req8" runat="server" ForeColor="Maroon" CssClass="fontsmall">| </asp:label></TD>
																		<TD>
																			<asp:textbox id="txtMemo" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
																				Width="300px" TextMode="MultiLine" Height="100px"></asp:textbox></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px">&nbsp;</TD>
																		<TD></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px">
																			<asp:label id="Label8" runat="server" CssClass="fontsmall">Enter Your MyEnroll.com Password</asp:label></TD>
																		<TD vAlign="top">
																			<asp:label id="Label1" runat="server" ForeColor="Maroon" CssClass="fontsmall">| </asp:label></TD>
																		<TD vAlign="top">
																			<asp:textbox id="txtPassword" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
																				Width="300px" TextMode="Password"></asp:textbox>
																			<asp:label id="lblPassordError" runat="server" ForeColor="Red">
																				<a href="JavaScript:SetFocus('txtPassword')"><b><font color="#800000">ERROR</font></b><font color='blue'>
																						- <u>Invalid Password</u></font></a></asp:label>
																			<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="fontsmall" Display="Dynamic"
																				ErrorMessage="Password is Required" ControlToValidate="txtPassword"></asp:requiredfieldvalidator></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px">&nbsp;</TD>
																		<TD></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px" colSpan="2">
																			<asp:Button id="btnSave" runat="server" CssClass="fontsmall" Width="75px" Text="Save"></asp:Button>
																			<asp:Button id="btnCancel" runat="server" CssClass="fontsmall" Width="75px" Text="Cancel" CausesValidation="False"></asp:Button></TD>
																		<TD style="WIDTH: 200px"></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</asp:panel></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD height="1%">&nbsp;</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
