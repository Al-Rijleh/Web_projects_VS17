<%@ Page language="c#" Codebehind="TrainingAnswers.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.TrainingAnswers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training Request and Evaluation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
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
									<TD vAlign="top" height="10%">
										<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="gold" colSpan="2">
													<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD>
																<asp:image id="Image1" runat="server" ImageUrl="/img/fdiclogo.jpg"></asp:image></TD>
															<TD width="140" background="img/Fill.JPG"></TD>
															<TD align="right" width="600">
																<asp:image id="Image2" runat="server" ImageUrl="/img/Met_Logo_Bar_MyEnroll_Logo.jpg"></asp:image></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD align="center" height="1%">
										<asp:Label id="Label1" runat="server">Federal Deposit Insurance Corporation</asp:Label></TD>
								</TR>
								<TR>
									<TD align="center" height="1%">
										<asp:Label id="Label2" runat="server" Font-Size="Small" Font-Bold="True">TRAINING EVALUATION</asp:Label></TD>
								</TR>
								<TR>
									<TD style="BORDER-BOTTOM: silver thin solid" height="1%"><FONT size="1">&nbsp;</FONT></TD>
								</TR>
								<TR>
									<TD height="1%">
										<asp:Label id="Label9" runat="server"><b>INSTRUCTIONS:</b> Complete this evaluation for training. After you complete the form, it will be forwarded to your supervisor for review and acknowledgement</asp:Label></TD>
								</TR>
								<TR>
									<TD height="1%">
										<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="30%" height="30">
													<P>&nbsp;
														<asp:label id="Label4" runat="server">1.  Employee Name (Last, First, MI)</asp:label></P>
												</TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="25%" height="30">
													<P>&nbsp;
														<asp:label id="Label5" runat="server">2.  Employee SSN (last 4 digits)</asp:label></P>
												</TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="20%" height="30">
													<P>&nbsp;
														<asp:label id="Label6" runat="server">3.  Telephone Number</asp:label></P>
												</TD>
												<TD style="BORDER-RIGHT: silver thin; BORDER-TOP: silver thin solid; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin"
													vAlign="top" width="23%" height="30">
													<P>&nbsp;
														<asp:label id="Label7" runat="server">4.  Division/Office/Location</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													width="30%" height="15">&nbsp;
													<asp:label id="lblName" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													height="15">&nbsp;
													<asp:label id="lblSSN" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													width="20%" height="15">&nbsp;
													<asp:label id="lblPhone" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
												<TD style="BORDER-RIGHT: silver thin; BORDER-TOP: silver thin; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin solid"
													vAlign="top" width="23%" height="15">&nbsp;
													<asp:label id="lblOffice" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
													height="45">
													<TABLE class="fontsmall" id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%"
														border="0">
														<TR>
															<TD>&nbsp;
																<asp:label id="Label8" runat="server">5. Title of Course</asp:label></TD>
														</TR>
														<TR>
															<TD>&nbsp;</TD>
														</TR>
														<TR>
															<TD>&nbsp;
																<asp:label id="lblTitleCourse" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
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
																<asp:label id="Label12" runat="server">Start Date</asp:label></TD>
															<TD style="BORDER-BOTTOM: silver thin solid" align="center" height="15">
																<asp:label id="Label13" runat="server">Completion Date</asp:label></TD>
														</TR>
														<TR>
															<TD style="BORDER-RIGHT: silver thin solid" vAlign="bottom">&nbsp;
																<asp:label id="lblStartDate" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
															<TD vAlign="bottom">&nbsp;
																<asp:label id="lblEndDate" runat="server" Width="90%" BackColor="Gainsboro"></asp:label></TD>
														</TR>
													</TABLE>
												</TD>
												<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="45">
													<TABLE class="fontsmall" id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%"
														border="0">
														<TR>
															<TD>&nbsp;
																<asp:label id="Label10" runat="server">7.  Type of Training (Check One)</asp:label></TD>
														</TR>
														<TR>
															<TD>&nbsp;</TD>
														</TR>
														<TR>
															<TD>&nbsp;
																<asp:label id="Label21" runat="server" BackColor="Gainsboro">PLA</asp:label>&nbsp;
																<asp:Image id="imgPLA" runat="server" ImageUrl="img/incomplete.JPG"></asp:Image>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:label id="Label22" runat="server" BackColor="Gainsboro">Other</asp:label>
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
										<asp:Label id="Label3" runat="server" Font-Bold="True">AREAS OF EVALUATION </asp:Label></TD>
								</TR>
								<TR>
									<TD align="center" height="1%">
										<asp:Label id="Label14" runat="server">(Select the answer in the appropriate column by selecting the radio button to  indicate your evaluation of items 8-11. )</asp:Label></TD>
								</TR>
								<TR>
									<TD height="1%">&nbsp;</TD>
								</TR>
								<TR>
									<TD height="1%">
										<asp:DataGrid id="dgQA" runat="server" Width="100%" GridLines="Horizontal" CellPadding="3" BorderWidth="2px"
											BorderColor="White" AutoGenerateColumns="False" CssClass="fontsmall">
											<ItemStyle BackColor="Gainsboro"></ItemStyle>
											<HeaderStyle BackColor="#AAAADD"></HeaderStyle>
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
										<asp:Label id="lblError" runat="server" BackColor="Yellow" BorderWidth="1px" BorderColor="Red"
											Height="20px" BorderStyle="Solid" ForeColor="Red"></asp:Label>&nbsp;</TD>
								</TR>
                                <tr>
                                    <td style="height: 1%">
                                        <table style="width: 700px">
                                            <tr>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="lblComments" runat="server" CssClass="fontsmall" Text="Comments"></asp:Label></td>
                                                <td style="width: 594px; height: 18px">
                                                    <asp:TextBox ID="txtComments" runat="server" CssClass="fontsmall" Height="100px"
                                                        MaxLength="4000" TextMode="MultiLine" Width="575px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComments"
                                                        CssClass="fontsmall" ErrorMessage="Required Information"></asp:RequiredFieldValidator></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
								<TR>
									<TD height="69" style="HEIGHT: 69px">
										<asp:button id="btnSave" runat="server" CssClass="act_save_button" Text="Save &amp; Exit"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="btnCancel" runat="server" CssClass="act_close_button" Text="Cancel &amp; Exit" CausesValidation="False"></asp:button>
										<asp:label id="lblScript" runat="server"></asp:label>
										<asp:Label id="lbl_fldInstructionForTriningCourseTrainingAnswer" runat="server">
											<B>Once you save this form, you will not be able to access it again</B></asp:Label>
										<asp:ListBox id="lbAnweres" runat="server"></asp:ListBox></TD>
								</TR>
								<TR>
									<TD height="1%"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD height="5%">
							<asp:Label id="Label15" runat="server" CssClass="fontsmall">FDIC 2610/12A (10-06)</asp:Label></TD>
					</TR>
				</TABLE>
			</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
