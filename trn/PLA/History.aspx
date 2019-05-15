<%@ Page language="c#" Codebehind="History.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.History" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Request History</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		</STYLE>
		<script>
		  function ShowEmail(email_id)
		  {	  
			//eval(document.getElementById('txtLoading')).value = 'LOADING';
		    document.location.href="history.aspx?email_id="+email_id;
			//document.Form1.doShow.value=email_id;			
			//__doPostBack('','');
		  }
		  
		  function ShowMsg(msg_id)
		  {
		    document.location.href="history.aspx?msg_id="+msg_id;
			//document.Form1.doShow.value='-'+msg_id;
			//__doPostBack('','');
		  }
		  
		  function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
          function goBack()
			{
				strurl = document.getElementById('txtUrl').value;
				window.location.href = strurl;
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="1"
			cellSpacing="0" cellPadding="0" width="790" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
			</TR>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TD></TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="790" border="0">
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD colSpan="2"><asp:label id="lblCourseName" runat="server" Font-Bold="True"> Training Requested</asp:label>:&nbsp;
															<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label><INPUT id="doShow" type="hidden" name="doShow" runat="server"></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
														<TD></TD>
													</TR>
												</TABLE>
												<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
									</TABLE>
									<asp:label id="Label2" runat="server" CssClass="fontsmall"><b>Instruction: </b>Click on any record in the left panel title “Email History” to display the corresponding email details.”</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="790" border="0">
										<TR>
											<TD style="WIDTH: 381px" vAlign="top" width="370">
												<TABLE id="Table6" height="305" cellSpacing="0" cellPadding="0" width="370" border="0">
													<TR>
														<TD style="BORDER-BOTTOM: silver 1px solid">
															<DIV class="fontsmall" style="OVERFLOW: auto; WIDTH: 365px; HEIGHT: 285px; text_aligh: left"
																align="left" DESIGNTIMEDRAGDROP="827"><asp:datagrid id="dgHistory" runat="server" CssClass="fontsmall" GridLines="Horizontal" BorderWidth="1px"
																	Width="345px" CellPadding="3" BorderColor="Black" AutoGenerateColumns="False">
																	<SelectedItemStyle BackColor="Khaki"></SelectedItemStyle>
																	<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
																	<ItemStyle BackColor="White"></ItemStyle>
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Email History"></asp:TemplateColumn>
																	</Columns>
																</asp:datagrid></DIV>
														</TD>
													</TR>
													<TR>
														<TD height="20"><asp:button id="btnBack" runat="server" CssClass="fontsmall" Width="75px" Text="Back"></asp:button><asp:label id="lblScript" runat="server"></asp:label><asp:hyperlink id="hlBack" runat="server" CssClass="act_back_button" Visible="False">Back</asp:hyperlink></TD>
													</TR>
												</TABLE>
											</TD>
											<TD width="1"></TD>
											<TD vAlign="top" align="left" width="400"><asp:panel id="pnlViewer" runat="server" CssClass="fontsmall" Visible="False">
													<TABLE class="fontsmall" id="Table4" style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid; BORDER-BOTTOM: silver 1px solid"
														cellSpacing="0" cellPadding="0" width="395" border="0">
														<TR>
															<TD></TD>
															<TD colSpan="1">
																<asp:label id="Label6" runat="server" Font-Bold="True">To:</asp:label></TD>
															<TD>
																<asp:label id="lblTo" runat="server"></asp:label></TD>
															<TD>
																<asp:label id="Label9" runat="server" Font-Bold="True">Sent:</asp:label></TD>
															<TD>
																<asp:label id="lblSent" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD>
																<asp:label id="Label1" runat="server" Font-Bold="True">Subject:</asp:label></TD>
															<TD colSpan="3">
																<asp:label id="lblSubject" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD style="BORDER-TOP: silver 1px solid" width="5">&nbsp;
															</TD>
															<TD style="BORDER-TOP: silver 1px solid" colSpan="4">
																<asp:Label id="lblMemo" runat="server" CssClass="fontsmall" BorderStyle="None"></asp:Label></TD>
														</TR>
													</TABLE>
												</asp:panel></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<P>&nbsp;</P>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
