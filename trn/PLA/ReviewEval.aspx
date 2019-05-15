<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="ReviewEval.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ReviewEval" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training Request and Evaluation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META HTTP-EQUIV="Pragma" CONTENT="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script>
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=0,resizable=1, toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0" onclick="return Table_onclick()">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
			</TR>
			<TR vAlign="top" height="1%">
				<TD></TD>
				<TD>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TD>
			</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="fontsmall" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center" height="1%"><asp:label id="Label1" runat="server">Federal Deposit Insurance Corporation</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" height="1%"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Size="Small"> TRAINING EVALUATION</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" height="1%"><FONT size="1">&nbsp;</FONT></TD>
							</TR>
							<TR>
								<TD height="1%"><asp:label id="Label9" runat="server"><b>INSTRUCTIONS:</b>  Complete the evaluation form for your training. After you complete the form it will go to your supervisor for review and acknowledgement.</asp:label></TD>
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
												<asp:label id="lblName" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
											<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
												height="15">&nbsp;
												<asp:label id="lblSSN" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
											<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
												width="20%" height="15">&nbsp;
												<asp:label id="lblPhone" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
											<TD style="BORDER-RIGHT: silver thin; BORDER-TOP: silver thin; BORDER-LEFT: silver thin; BORDER-BOTTOM: silver thin solid"
												vAlign="top" width="23%" height="15">&nbsp;
												<asp:label id="lblOffice" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
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
															<asp:label id="lblTitleCourse" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
													</TR>
												</TABLE>
												&nbsp;</TD>
											<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" vAlign="top"
												colSpan="2" height="45">
												<TABLE class="fontsmall" id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD style="BORDER-BOTTOM: silver thin solid" align="center" colSpan="2" height="15"><asp:label id="Label11" runat="server">6.  Training Period</asp:label></TD>
													</TR>
													<TR>
														<TD style="BORDER-RIGHT: silver thin solid; BORDER-BOTTOM: silver thin solid" align="center"
															width="50%" height="15"><asp:label id="Label12" runat="server">Start Date</asp:label></TD>
														<TD style="BORDER-BOTTOM: silver thin solid" align="center" height="15"><asp:label id="Label13" runat="server">Completion Date</asp:label></TD>
													</TR>
													<TR>
														<TD style="BORDER-RIGHT: silver thin solid" vAlign="bottom">&nbsp;
															<asp:label id="lblStartDate" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
														<TD vAlign="bottom">&nbsp;
															<asp:label id="lblEndDate" runat="server" BackColor="Gainsboro" Width="90%"></asp:label></TD>
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
															<asp:label id="Label21" runat="server" BackColor="Gainsboro">PLA</asp:label>
															<asp:Image id="imgPLA" runat="server" ImageUrl="img/incomplete.JPG"></asp:Image>
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
								<TD align="center" height="1%"><asp:label id="Label3" runat="server" Font-Bold="True">AREAS OF EVALUATION </asp:label></TD>
							</TR>
							<TR>
								<TD align="center" height="1%"><asp:label id="Label14" runat="server"> (Select the answer in the appropriate column by selecting the radio button  to indicate your evaluation of items 8-11.)</asp:label></TD>
							</TR>
							<TR>
								<TD height="1%">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="height: 1%"><asp:datagrid id="dgQA" runat="server" Width="100%" CssClass="fontsmall" AutoGenerateColumns="False"
										BorderColor="White" BorderWidth="2px" CellPadding="3" GridLines="Horizontal">
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
											<asp:TemplateColumn HeaderText="Answer">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
                            <tr>
                                <td height="1%">
                                    <table style="width: 700px">
                                        <tr>
                                            <td style="width: 100px; height: 18px">
                                                &nbsp;</td>
                                            <td style="width: 594px; height: 18px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="lblComments" runat="server" CssClass="fontsmall" Text="Comments"></asp:Label></td>
                                            <td style="width: 594px; height: 18px">
                                                <asp:TextBox ID="txtComments" runat="server" Height="100px" MaxLength="4000" ReadOnly="True"
                                                    TextMode="MultiLine" Width="575px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
							<TR>
								<TD height="1%">&nbsp;
									<asp:listbox id="lbAnweres" runat="server"></asp:listbox></TD>
							</TR>
							<TR>
								<TD height="1%">&nbsp;
									<asp:LinkButton id="lnkbtnBack" runat="server" CssClass="act_back_button">Back</asp:LinkButton><asp:label id="lblScript" runat="server"></asp:label>
									<asp:LinkButton id="lnkbtnAcknowledge" runat="server" CssClass="act_save_button">Acknowledge  Reviewing  the Evaluation</asp:LinkButton></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<script>setLocalElementsStyleClass (Get_Cookie('ClassName'));function Table_onclick() {

}

</script>
	</body>
</HTML>
