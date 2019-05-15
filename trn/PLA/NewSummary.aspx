<%@ Register TagPrefix="kswc" Namespace="Karamasoft.WebControls.UltimateTabstrip" Assembly="UltimateTabstrip" %>
<%@ Page language="c#" Codebehind="NewSummary.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.NewSummary" validateRequest=false %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Request Summary</title>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD width="220"><asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="fontsmall">
									<TABLE id="Table9" height="25" cellSpacing="0" cellPadding="0" width="100%" border="0">
									</TABLE>
									<kswc:ultimatetabstrip id="uts" runat="server" Scheme="XP" IncludeDirectory="/karama/UltimateTabstripInclude/"
										AutoPostBack="True" Width="100%">
										<Tabs>
											<kswc:Tab ID="UltimateTabstrip1t0" HeaderText="Vendor Information">
												<ContentTemplate></ContentTemplate>
											</kswc:Tab>
											<kswc:Tab ID="UltimateTabstrip1t1" HeaderText="Course Dates &amp; Times">
												<ContentTemplate></ContentTemplate>
											</kswc:Tab>
											<kswc:Tab ID="UltimateTabstrip1t2" HeaderText="Training Types &amp; Needs">
												<ContentTemplate></ContentTemplate>
											</kswc:Tab>
											<kswc:Tab ID="utst3" HeaderText="Expenses"></kswc:Tab>
										</Tabs>
										<TabActiveStyle CssClass="TabActive TabOuter TabInner Tab"></TabActiveStyle>
										<TabstripStyle CssClass="Tabstrip"></TabstripStyle>
										<TabHoverStyle CssClass="TabHover TabOuter TabInner Tab"></TabHoverStyle>
										<TabstripContentStyle CssClass="TabstripContent"></TabstripContentStyle>
										<TabDefaultStyle CssClass="TabDefault TabOuter TabInner Tab"></TabDefaultStyle>
									</kswc:ultimatetabstrip></TD>
							</TR>
							<TR>
								<TD><asp:panel id="pnlVendor" runat="server">
										<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="790" border="0">
											<TR>
												<TD colSpan="2"></TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<asp:Label id="lblVendor" runat="server" Font-Bold="True" CssClass="FontSmallTitle">Vendor Information</asp:Label></TD>
											</TR>
											<TR>
												<TD colSpan="2"></TD>
											</TR>
											<TR>
												<TD width="395">
													<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="395" border="0">
														<TR>
															<TD width="150">
																<asp:label id="Label20" runat="server" CssClass="fontsmall">Training Event Code</asp:label></TD>
															<TD>
																<asp:textbox id="txtCourseCode" runat="server" Width="220px" CssClass="Input_Control_Small" BackColor="Gainsboro"
																	ReadOnly="True" MaxLength="20"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label4" runat="server" CssClass="fontsmall">Training Event Title</asp:label></TD>
															<TD>
																<asp:textbox id="txtCourseTitle" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="50"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label5" runat="server" Font-Bold="True" CssClass="fontsmall" Font-Underline="True">Vendor</asp:label></TD>
															<TD></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label22" runat="server" CssClass="fontsmall">Name</asp:label></TD>
															<TD>
																<asp:textbox id="txtVedorName" runat="server" Width="220px" CssClass="Input_Control_Small" BackColor="Gainsboro"
																	ReadOnly="True" MaxLength="50"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label50" runat="server" CssClass="fontsmall">Contact</asp:label></TD>
															<TD>
																<asp:textbox id="txtVendorContact" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="50"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label6" runat="server" CssClass="fontsmall">Telephone & Fax</asp:label></TD>
															<TD>
																<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="230" border="0">
																	<TR>
																		<TD width="110">
																			<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
																				runat="server" Width="100px" CssClass="Input_Control_Small" BackColor="Gainsboro" ReadOnly="True"
																				MaxLength="14"></asp:textbox></TD>
																		<TD width="10"></TD>
																		<TD width="110">
																			<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
																				runat="server" Width="100px" CssClass="Input_Control_Small" BackColor="Gainsboro" ReadOnly="True"
																				MaxLength="14"></asp:textbox></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label7" runat="server" CssClass="fontsmall">Address Line 1</asp:label></TD>
															<TD>
																<asp:textbox id="txtAddressLine1" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="30"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label8" runat="server" CssClass="fontsmall">Address Line 2</asp:label></TD>
															<TD>
																<asp:textbox id="txtAddressLine2" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="30"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label9" runat="server" CssClass="fontsmall">City / State</asp:label></TD>
															<TD>
																<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="230" border="0">
																	<TR>
																		<TD width="110">
																			<asp:textbox id="txtCity" runat="server" Width="100px" CssClass="Input_Control_Small" BackColor="Gainsboro"
																				ReadOnly="True" MaxLength="20"></asp:textbox></TD>
																		<TD></TD>
																		<TD borderColor="black" width="115" borderColorDark="#000000">
																			<asp:textbox id="txtState" runat="server" Width="105px" CssClass="Input_Control_Small" BackColor="Gainsboro"
																				ReadOnly="True" MaxLength="20"></asp:textbox></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label11" runat="server" CssClass="fontsmall">Zip Code</asp:label></TD>
															<TD>
																<asp:textbox id="txtZipCode" runat="server" Width="220px" CssClass="Input_Control_Small" BackColor="Gainsboro"
																	ReadOnly="True" MaxLength="10"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="Label24" runat="server" CssClass="fontsmall">Web Site</asp:label></TD>
															<TD>
																<asp:textbox id="txtWebSite" runat="server" Width="220px" CssClass="Input_Control_Small" BackColor="Gainsboro"
																	ReadOnly="True" MaxLength="100"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD width="395">
													<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="395" border="0">
														<TR>
															<TD width="150"></TD>
															<TD></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD></TD>
														</TR>
														<TR>
															<TD align="left" colSpan="2">
																<asp:label id="Label52" runat="server" Font-Bold="True" CssClass="fontsmall" Font-Underline="True">Location of Training Site (if same as vendor, check box)</asp:label>&nbsp;
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="lblLearningAddress1" runat="server" CssClass="fontsmall">Address Line 1</asp:label></TD>
															<TD>
																<asp:textbox id="txtLearningAddress1" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="30"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="lblLearningAddress2" runat="server" CssClass="fontsmall">Address Line 2</asp:label></TD>
															<TD>
																<asp:textbox id="txtLearningAddress2" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="30"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="lblLearningCityState" runat="server" CssClass="fontsmall">City / State</asp:label></TD>
															<TD>
																<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="230" border="0">
																	<TR>
																		<TD width="110">
																			<asp:textbox id="txtLearningCity" runat="server" Width="100px" CssClass="Input_Control_Small"
																				BackColor="Gainsboro" ReadOnly="True" MaxLength="20"></asp:textbox></TD>
																		<TD></TD>
																		<TD width="115">
																			<asp:textbox id="txtLearningState" runat="server" Width="105px" CssClass="Input_Control_Small"
																				BackColor="Gainsboro" ReadOnly="True" MaxLength="20"></asp:textbox></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<asp:label id="lblLearningZipCode" runat="server" CssClass="fontsmall">Zip Code</asp:label></TD>
															<TD>
																<asp:textbox id="txtLearningZipCode" runat="server" Width="220px" CssClass="Input_Control_Small"
																	BackColor="Gainsboro" ReadOnly="True" MaxLength="10"></asp:textbox></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD vAlign="top" width="100">
													<asp:label id="Label12" runat="server" CssClass="fontsmall">Purpose of Training</asp:label></TD>
												<TD vAlign="top" width="500">
													<asp:textbox id="txtDescribtion" runat="server" Width="500px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4000" TextMode="MultiLine" Height="70px"></asp:textbox></TD>
												<TD vAlign="top"></TD>
											</TR>
											<TR>
												<TD colSpan="3"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlDateTime" runat="server">
										<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="20%" colSpan="3" height="1%">
													<asp:label id="Label21" runat="server" Font-Bold="True" CssClass="FontSmallTitle">Course Dates & Times</asp:label></TD>
											</TR>
											<TR>
												<TD width="25%" height="1%">
													<asp:label id="Label29" runat="server" CssClass="fontsmall">Course Start Date</asp:label></TD>
												<TD width="35%" height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtStartDate"
														runat="server" Width="175px" CssClass="Input_Control_Small" BackColor="Gainsboro" ReadOnly="True"
														MaxLength="10"></asp:textbox></TD>
												<TD width="45%" height="1%"></TD>
											</TR>
											<TR>
												<TD width="20%" height="1%">
													<asp:label id="Label26" runat="server" CssClass="fontsmall">Course End Date</asp:label></TD>
												<TD height="1%">
													<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '##/##/####');" id="txtEndDate"
														runat="server" Width="175px" CssClass="Input_Control_Small" BackColor="Gainsboro" ReadOnly="True"
														MaxLength="10"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label17" runat="server" CssClass="fontsmall">Course Hours - Duty</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursDuty" onkeyup="AddValues()" runat="server" Width="175px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="6">0</asp:textbox>&nbsp;
												</TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label16" runat="server" CssClass="fontsmall">Course Hours - Non-Duty</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursNonDuty" onkeyup="AddValues()" runat="server" Width="175px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="6">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label15" runat="server" Font-Bold="True" CssClass="fontsmall">Course Hours Total</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtCourseHoursTotal" runat="server" Font-Bold="True" Width="175px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="30" BorderStyle="Solid">0</asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">&nbsp;</TD>
												<TD height="1%"></TD>
												<TD height="1%"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlTypesNeeds" runat="server">
										<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="3" style="height: 1%">
													<asp:label id="Label18" runat="server" Font-Bold="True" CssClass="FontSmallTitle">Training Types & Needs</asp:label></TD>
											</TR>
											<TR>
												<TD width="150" height="1%">
													<asp:label id="Label57" runat="server" CssClass="fontsmall">Department ID#</asp:label></TD>
												<TD colSpan="2" height="1%" style="width: 301px">
													<asp:textbox id="txtDepartmentID" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 19px" height="19" width="150">
													<asp:label id="Label55" runat="server" CssClass="fontsmall">Position Level</asp:label></TD>
												<TD style="HEIGHT: 19px; width: 301px;" colSpan="2" height="19">
													<asp:textbox id="txtPositionLevel" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 19px" height="19" width="150">
													<asp:label id="Label53" runat="server" CssClass="fontsmall">Need Special Accomodation</asp:label></TD>
												<TD style="HEIGHT: 19px; width: 301px;" colSpan="2" height="19">
													<asp:textbox id="txtAccomodation" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="lblAccomodationDescription" runat="server" CssClass="fontsmall">Accomodation Description</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtAccomodationDescription" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label49" runat="server" CssClass="fontsmall">Type of Appointment</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txTypeofAppointment" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label48" runat="server" CssClass="fontsmall">Training Purpose Type</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtPurposeOfTraining" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label47" runat="server" CssClass="fontsmall">Delivery Type Code</asp:label></TD>
												<TD style="HEIGHT: 14px; width: 301px;" colSpan="2">
													<asp:textbox id="txtDelivaryTypeCode" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label13" runat="server" CssClass="fontsmall" ToolTip="Training Designation Type Code">Designation Type Code</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtDesignationTypeCode" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="lblTrainingCredit" runat="server" CssClass="fontsmall" ToolTip="Training Designation Type Code">Training Credit</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtTrainingCredit" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label45" runat="server" CssClass="fontsmall" ToolTip="Training Credit Type Code">Credit Type Code</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtCreditTypeCode" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label43" runat="server" CssClass="fontsmall" ToolTip="Is the Course Accredited ">Accreditation Indicator</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtAccredetionIndicator" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label41" runat="server" CssClass="fontsmall">Source of Training</asp:label></TD>
												<TD colSpan="2" height="1%" style="width: 301px">
													<asp:textbox id="txtSourseTraining" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label39" runat="server" Visible="False" CssClass="fontsmall">Account #</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtAccountNumber" runat="server" Visible="False" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:Label id="Label10" runat="server">Education Level</asp:Label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtEducationLevel" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label37" runat="server" CssClass="fontsmall" ToolTip="Training Type Code">Training Type Code</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtTrainingTypeCode" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label30" runat="server" CssClass="fontsmall" ToolTip="Training Sub-Type Code">Training Sub-Type Code</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtTrainingSubTypeCode" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="lblTypeOfDevelopment" runat="server" CssClass="fontsmall" ToolTip="Type of Development">Type of Development</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtTypeOfDevelopmentSummary" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="Label38" runat="server" CssClass="fontsmall">Type of Development (other)</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:TextBox id="txtTypeofDevelopmentOther182" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD width="150">
													<asp:label id="lblProgramCode" runat="server" CssClass="fontsmall">Program Code</asp:label></TD>
												<TD colSpan="2" style="width: 301px">
													<asp:textbox id="txtProgramCode" runat="server" Width="300px" CssClass="Input_Control_Small"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD colSpan="3" height="1%">&nbsp;</TD>
											</TR>
											<TR>
												<TD align="left" colSpan="3" height="1%"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlExpenses" runat="server" DESIGNTIMEDRAGDROP="58">
										<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD>
													<asp:label id="Label19" runat="server" Font-Bold="True" CssClass="FontSmallTitle">Expenses</asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD>
													<asp:DataGrid id="dgExpense" runat="server" Width="100%" CssClass="fontsmall" BorderColor="White"
														AutoGenerateColumns="False" CellPadding="3">
														<SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
														<ItemStyle BackColor="White"></ItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="expense_type" HeaderText="Expense Type">
																<HeaderStyle Width="10%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="amount" HeaderText="Estimated Amout" DataFormatString="{0:C}">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="approved_amount" HeaderText="Approved Amount" DataFormatString="{0:C}">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="paid_amount" HeaderText="Paid Amount" DataFormatString="{0:C}">
																<HeaderStyle Width="10%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="vendor_name" HeaderText="Vendor Name">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="vendor_contact_name" HeaderText="Vendor Contact">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="vendor_phone" HeaderText="Vendor Phone">
																<HeaderStyle Width="15%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
														</Columns>
													</asp:DataGrid>
													<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="795" border="0">
														<TR>
															<TD width="73">
																<asp:label id="Label14" runat="server" Font-Bold="True" ForeColor="Black" CssClass="fontsmall">Total</asp:label>
																<asp:Label id="lblNoteMark" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label></TD>
															<TD align="right" width="73">
																<asp:label id="lblAmount" runat="server" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="right" width="73">
																<asp:label id="lblApprovedAmount" runat="server" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="right" width="73">
																<asp:label id="lblTotalPaid" runat="server" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
															<TD align="left" width="503" colSpan="3">&nbsp;&nbsp;
															</TD>
														</TR>
														<TR>
															<TD colSpan="7">
																<asp:Label id="lblNoteMarkDetail" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Small">*</asp:Label>
																<asp:Label id="lblNote" runat="server" CssClass="fontsmall">Total excludes Travel Expense because such expenses are not deducted from PLA Balances.</asp:Label></TD>
														</TR>
														<TR>
															<TD colSpan="7"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlTypesNeeds2007" runat="server">
										<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="HEIGHT: 15px" width="25%" bgColor="gold" colSpan="3" height="15">
													<asp:label id="Label32" runat="server" Font-Bold="True">Training Types & Needs</asp:label></TD>
											</TR>
											<TR>
												<TD height="1%">&nbsp;</TD>
												<TD height="1%"></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 19px" height="19">
													<asp:label id="Label1" runat="server">Department ID#</asp:label></TD>
												<TD style="HEIGHT: 19px" height="19">
													<asp:TextBox id="txtDepartmentID2007" runat="server" CssClass="fontsmall" BackColor="Gainsboro"
														ReadOnly="True" MaxLength="4"></asp:TextBox></TD>
												<TD style="HEIGHT: 19px" height="19"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label46" runat="server">Program Code</asp:label></TD>
												<TD height="1%">
													<asp:TextBox id="txtProgramCode2007" runat="server" CssClass="fontsmall" BackColor="Gainsboro"
														ReadOnly="True" MaxLength="4"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label2" runat="server">Account #</asp:label></TD>
												<TD height="1%">
													<asp:RadioButton id="rbAccountNo" runat="server" Width="300px" CssClass="fontsmall" BackColor="Gainsboro"
														Height="20px" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" Checked="True"></asp:RadioButton></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label31" runat="server">Source of Training</asp:label></TD>
												<TD height="1%">
													<asp:dropdownlist id="ddlSourseTraining" runat="server" Visible="False" CssClass="fontsmall" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtSource" runat="server" CssClass="fontsmall" BackColor="Gainsboro" ReadOnly="True"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label23" runat="server">Purpose of Training </asp:label></TD>
												<TD height="1%">
													<asp:dropdownlist id="ddlPurposeOfTraining" runat="server" Visible="False" CssClass="fontsmall" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="txtPurpose" runat="server" CssClass="fontsmall" BackColor="Gainsboro" ReadOnly="True"></asp:TextBox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">
													<asp:label id="Label25" runat="server">Purpose of Training (other)</asp:label></TD>
												<TD height="1%">
													<asp:textbox id="txtPurposeOfTainingOther" runat="server" CssClass="fontsmall" BackColor="Gainsboro"
														ReadOnly="True" MaxLength="100"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD vAlign="top" height="1%">
													<asp:Label id="Label27" runat="server">Type of Development</asp:Label></TD>
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
													<asp:Label id="Label33" runat="server">Type of Development (other)</asp:Label></TD>
												<TD height="1%">
													<asp:textbox id="txtTypeofDevelopmentOther" runat="server" CssClass="fontsmall" BackColor="Gainsboro"
														ReadOnly="True" MaxLength="100"></asp:textbox></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD height="1%">&nbsp;</TD>
												<TD height="1%"></TD>
												<TD height="1%"></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3" height="1%"></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD><asp:button id="btnHome" runat="server" Width="75px" CssClass="fontsmall" ToolTip="Back to Previous page"
										Text="Back"></asp:button></TD>
							</TR>
							<TR>
								<TD align="left" width="100%">&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblScript" runat="server" CssClass="fontsmall"></asp:label></TD>
							</TR>
						</TABLE>
						&nbsp;
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
