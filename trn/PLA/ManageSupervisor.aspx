<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="ManageSupervisor.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ManageSupervisor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Supervisor Selection</title>
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
		  function CheckSave(url_)
			{
				var chk = confirm("The data was changed. Do you wish to save the data first? If Yes click Ok otherwise click Cancel")
				if (!chk)
					document.location.href=url_;
				else
				{
					document.Form1.doSave.value=url_;
					__doPostBack('','');
				}
			}
		  function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		  function CheckReroute(strSupName)
	        {
	            var retResult = confirm('Are you sure you want to reroute this application to supervisor '+strSupName);
	            if (retResult)
	            {
	                eval(document.getElementById('hidReroute')).value = 'Reroute',
	                Form1.submit();
	            }
	            else
	            {
	                eval(document.getElementById('hidReroute')).value = 'CancelReroute',
	                Form1.submit();
	            }
	        }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" >
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif">
					<cc1:UltimateMenu id="UltimateMenu1" runat="server"></cc1:UltimateMenu>
					<asp:Label id="lblWizardError" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Maroon"></asp:Label></TD>
			</TR>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="fontsmall" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid">
									<TABLE class="fontsmall" id="Table2" height="1%" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD width="220">
												<asp:label id="lblTrainingRequest" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD>
												<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label>
												<asp:Label id="lblScript" runat="server"></asp:Label><input id="doSave" type="hidden" name="doSave" runat="server"></TD>
										</TR>
										<TR>
											<TD width="220">
												<asp:Label id="Label5" runat="server" Font-Bold="True">Remaining Budget For: </asp:Label>
												<asp:DropDownList id="ddlBudgetYear" runat="server" CssClass="fontsmall" AutoPostBack="True" Width="60px"></asp:DropDownList></TD>
											<TD>
												<asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
									</TABLE>
									<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
									&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lbl_fldTraing_source_ManageSupervisorInstruction" runat="server">Instruction</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblAssignSupervisor" runat="server">Supervisor Assignment</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:TextBox id="txtSupervisorName" runat="server" CssClass="fontsmall" ReadOnly="True" BackColor="Gainsboro"></asp:TextBox>
									<asp:Button id="btnSelect" runat="server" CssClass="fontsmall" Text="Select" CausesValidation="False"></asp:Button>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" CssClass="fontsmall" ErrorMessage="Suprivisor Assignmentnis Required"
										Display="Dynamic" ControlToValidate="txtSupervisorName"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
                            <tr>
                                <td style="height: 15px">
                                    <asp:Label ID="lblifo" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="#880000"
                                        Text="Changing your supervisor will cause this application to be reset to Pending Submission"
                                        Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="300">
												<asp:Button id="btnHome" runat="server" Width="75px" CssClass="fontsmall" Text="Home" CausesValidation="False"
													ToolTip="Rrturn to select application"></asp:Button>
												<asp:Button id="btnBack" runat="server" Width="75px" CssClass="fontsmall" Text="Back" CausesValidation="False"
													ToolTip="Back to previous page"></asp:Button>
												<asp:Button id="btnNext" runat="server" Width="75px" CssClass="fontsmall" Text="Next" CausesValidation="False"
													ToolTip="GoTo next page"></asp:Button></TD>
											<TD>&nbsp;
												<asp:button id="btnSave" runat="server" Width="75px" CssClass="fontsmall" Text="Save" ToolTip="Save Data"></asp:button>
												<asp:button id="btnReset" runat="server" Width="200px" CssClass="fontsmall" Text="Reset Current Screen Data"
													CausesValidation="False" ToolTip="Reset Data"></asp:button>
                                                <asp:HiddenField ID="hidReroute" runat="server" />
                                            </TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
