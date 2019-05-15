<%@ Page language="c#" Codebehind="System_Add_Extra_Budget_Money.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.System_Add_Extra_Budget_Money" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add Extra Budget Money</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="-1"> 
		<script src="/js/dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>

		<script>
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
			function IsPopupBlocker() {
			var strNewURL = "Dummy.htm"
			var Strfeature = "" ;
			var WindowOpen = window.open(strNewURL,"MainWindow","directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");
			try{
			var obj = WindowOpen.name;
			WindowOpen.close();		
			} 
			catch(e){ 
			alert("This program utilizes POP-UP windows. Please disable the POP-UP BLOCKER and try again.\nor Please contact your system administrator. ");
			window.location.href="/scripts/basweb.exe/view?Module=N";
			}
			
		}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
			</TR>
			<TR vAlign="top" height="1%">
				<TD></TD>
				<TD></TD>
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
								<TD>&nbsp;
									<asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="List"></asp:validationsummary></TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="100"><asp:label id="Label3" runat="server" CssClass="fontsmall">Employee Name</asp:label></TD>
											<TD><asp:textbox id="txtEmployeeName" onblur="reset__(this)" runat="server" BackColor="#F0F0F0"
													ReadOnly="True" CssClass="input_control_small" Width="300px"></asp:textbox>
                                                &nbsp;
                                                <asp:button id="btnSelect" runat="server" CssClass="fontsmall" CausesValidation="False"
													Text="Select"></asp:button><asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label4" runat="server" CssClass="fontsmall">Budget Year</asp:label></TD>
											<TD height="28">
												<TABLE class="fontsmall" id="Table4" height="1" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD width="200"><asp:radiobuttonlist id="opnlstBudgetYear" onblur="reset__(this)" runat="server" CssClass="fontsmall"
																RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
														<TD><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="fontsmall" ControlToValidate="opnlstBudgetYear"
																ErrorMessage="Budget Year is Required"></asp:requiredfieldvalidator></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD><asp:label id="Label5" runat="server" CssClass="fontsmall">Amout</asp:label></TD>
											<TD><asp:textbox id="txtAmount" onblur="reset__(this)" runat="server" CssClass="fontsmall"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="fontsmall" ControlToValidate="txtAmount"
													ErrorMessage="Amount is Required" Display="Dynamic"></asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidator1" runat="server" CssClass="fontsmall" ControlToValidate="txtAmount"
													ErrorMessage="Require Numeric Value Only" Display="Dynamic" Type="Double" MinimumValue="-99999999" MaximumValue="999999999"></asp:rangevalidator></TD>
										</TR>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblReason" runat="server" CssClass="fontsmall" Text="Reason"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtReason" runat="server" CssClass="input_control_small" Height="150px"
                                                    MaxLength="4000" TextMode="MultiLine" Width="620px"></asp:TextBox></td>
                                        </tr>
									</TABLE>
									&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="height: 24px">
                                    <asp:Button ID="btnReturn" runat="server" CssClass="fonsmall" OnClick="btnReturn_Click"
                                        Text="Exit Without Saving" CausesValidation="False" />
                                    <asp:Button ID="btnSaveExit" runat="server" CssClass="fonsmall" OnClick="btnSaveExit_Click"
                                        Text="Save and Exit" /></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
