<%@ Page language="c#" Codebehind="TrainingAnswers3.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.TrainingAnswers3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training Request and Evaluation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<META http-equiv="Pragma" content="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
			function ConfirmaSave()
		    {
				alert('Your answers were saved successfully.');
				window.location.href='http://www.myenroll.com';
		    }
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=0,resizable=1, toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE id="Table8" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" height="100%"
					cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD vAlign="top">
							<TABLE class="fontsmall" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="1%">
										<asp:Label id="Label9" runat="server" CssClass="fontsmall"><b>INSTRUCTIONS:</b> Complete this evaluation for training. After you complete the form, it will be forwarded to your supervisor for review and acknowledgement</asp:Label></TD>
								</TR>
								<TR>
									<TD height="1%">
										<asp:Label id="lblError2" runat="server" ForeColor="Maroon" BorderStyle="None" Height="20px"
											Visible="False"><font color="#800000">Error : </font>&nbsp;<font color="#0000FF">All 
												questions must be answered</font></asp:Label></TD>
								</TR>
								<TR>
									<TD height="1%">
										<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="30%" height="30">
													<P>&nbsp;
														<asp:label id="Label4" runat="server" CssClass="fontsmall">1.  Employee Name (Last, First, MI)</asp:label></P>
												</TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="25%" height="30">
													<P>&nbsp;
														<asp:label id="Label5" runat="server" CssClass="fontsmall">2.  Employee SSN (last 4 digits)</asp:label></P>
												</TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="20%" height="30">
													<P>&nbsp;
														<asp:label id="Label6" runat="server" CssClass="fontsmall">3.  Telephone Number</asp:label></P>
												</TD>
												<TD style="BORDER-RIGHT: silver thin; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="23%" height="30">
													<P>&nbsp;
														<asp:label id="Label7" runat="server" CssClass="fontsmall">4.  Division/Office/Location</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													width="30%" height="15">&nbsp;
													<asp:label id="lblName" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													height="15">&nbsp;
													<asp:label id="lblSSN" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													width="20%" height="15">&nbsp;
													<asp:label id="lblPhone" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
												<TD style="BORDER-RIGHT: silver thin; BORDER-TOP: silver thin; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin solid"
													vAlign="top" width="23%" height="15">&nbsp;
													<asp:label id="lblOffice" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													height="45">
													<TABLE class="fontsmall" id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%"
														border="0">
														<TR>
															<TD>&nbsp;
																<asp:label id="Label8" runat="server" CssClass="fontsmall">5. Title of Course</asp:label></TD>
														</TR>
														<TR>
															<TD>&nbsp;</TD>
														</TR>
														<TR>
															<TD>&nbsp;
																<asp:label id="lblTitleCourse" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
														</TR>
													</TABLE>
													&nbsp;</TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													colSpan="2" height="45">
													<TABLE class="fontsmall" id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%"
														border="0">
														<TR>
															<TD style="BORDER-BOTTOM: silver thin solid" align="center" colSpan="2" height="15">
																<asp:label id="Label11" runat="server">6.  Training Period</asp:label></TD>
														</TR>
														<TR>
															<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" align="center"
																width="50%" height="15">
																<asp:label id="Label12" runat="server" CssClass="fontsmall">Start Date</asp:label></TD>
															<TD style="BORDER-BOTTOM: silver thin solid" align="center" height="15">
																<asp:label id="Label13" runat="server" CssClass="fontsmall">Completion Date</asp:label></TD>
														</TR>
														<TR>
															<TD style="BORDER-RIGHT: silver thin solid" vAlign="bottom">&nbsp;
																<asp:label id="lblStartDate" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
															<TD vAlign="bottom">&nbsp;
																<asp:label id="lblEndDate" runat="server" Width="90%" BackColor="Gainsboro" CssClass="fontsmall"></asp:label></TD>
														</TR>
													</TABLE>
												</TD>
												<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="45">
													<TABLE class="fontsmall" id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%"
														border="0">
														<TR>
															<TD>&nbsp;
																<asp:label id="Label10" runat="server" CssClass="fontsmall">7.  Type of Training (Check One)</asp:label></TD>
														</TR>
														<TR>
															<TD>&nbsp;</TD>
														</TR>
														<TR>
															<TD>&nbsp;
																<asp:label id="Label21" runat="server" BackColor="Gainsboro" CssClass="fontsmall">PLA</asp:label>&nbsp;
																<asp:Image id="imgPLA" runat="server" ImageUrl="img/incomplete.JPG"></asp:Image>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:label id="Label22" runat="server" BackColor="Gainsboro" CssClass="fontsmall">Other</asp:label>
																<asp:Image id="imgOther" runat="server" ImageUrl="img/incomplete.JPG"></asp:Image></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD height="1%"><FONT size="1">&nbsp;</FONT></TD>
								</TR>
								<TR>
									<TD align="center" height="1%">
										<asp:Label id="Label3" runat="server" Font-Bold="True" CssClass="fontsmall">AREAS OF EVALUATION </asp:Label></TD>
								</TR>
								<TR>
									<TD align="center" height="1%">
										<asp:Label id="Label14" runat="server" CssClass="fontsmall">(Select the answer in the appropriate column by selecting the radio button to  indicate your evaluation of items 8-11. )</asp:Label></TD>
								</TR>
								<TR>
									<TD height="1%">&nbsp;</TD>
								</TR>
								<TR>
									<TD height="1%">
										<asp:DataGrid id="dgQA" runat="server" Width="100%" GridLines="Horizontal" CellPadding="3" BorderWidth="2px"
											BorderColor="White" AutoGenerateColumns="False" CssClass="fontsmall">
											<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
											<ItemStyle BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="record_id">
													<HeaderStyle Width="20px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="question" HeaderText="Question">
													<HeaderStyle Width="40%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Answer"></asp:TemplateColumn>
											</Columns>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD height="1%">
										<asp:Label id="lblError" runat="server" Height="20px" BorderStyle="None" ForeColor="Maroon"
											Visible="False"><font color="#800000">Error : </font>&nbsp;<font color="#0000FF">All 
												questions must be answered</font></asp:Label>&nbsp;</TD>
								</TR>
                                <tr>
                                    <td height="1%">
                                        
                                        <table style="width: 700px">
                                            <tr>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="lblComments" runat="server" CssClass="fontsmall" Text="Comments"></asp:Label></td>
                                                <td style="height: 18px; width: 594px;">
                                                    <span class="fontsmall" id="Label1" style="FONT-WEIGHT: bold">Comments (Required field. Enter 'none' if you have no additional comments)</span> 
                                                    <asp:TextBox ID="txtComments" runat="server" Height="100px" MaxLength="4000" TextMode="MultiLine"
                                                        Width="575px" CssClass="fontsmall"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComments"
                                                        CssClass="fontsmall" ErrorMessage="Required Information"></asp:RequiredFieldValidator></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
								<TR>
									<TD>
										<asp:button id="btnSave" runat="server" CssClass="fontsmall" Text="Save &amp; Exit"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnCancel" runat="server" CssClass="fontsmall" Text="Cancel &amp; Exit" CausesValidation="False"></asp:button>
										<asp:label id="lblScript" runat="server"></asp:label>
										<asp:Label id="lbl_fldInstructionForTriningCourseTrainingAnswer" runat="server" CssClass="fontsmall">
											<B>Once you save this form, you will not be able to access it again</B></asp:Label></TD>
								</TR>
								<TR>
									<TD height="1%"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
