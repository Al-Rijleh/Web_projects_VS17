<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="System_Assign_Supervisor.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.System_Assign_Supervisor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>System_Assign_Supervisor</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
								<TD style="BORDER-BOTTOM: silver thin double">
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;
									<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="fontsmall" DisplayMode="List"></asp:ValidationSummary></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin double">
									<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="300">
												<asp:Label id="Label3" runat="server" CssClass="fontsmall">Employee Needing Supervisor Assignment:</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtEmployee" onblur="reset__(this)" runat="server" CssClass="input_control_small" ReadOnly="True"
													BackColor="Gainsboro"></asp:TextBox>
												<asp:Button id="lnkbtnSearchEmployee" runat="server" CssClass="fontsmall" Text="Search" CausesValidation="False"></asp:Button>
												<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Employee is Required"
													ControlToValidate="txtEmployee" CssClass="fontsmall"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 35px">
												<asp:Label id="Label4" runat="server" CssClass="fontsmall">Supervisor:</asp:Label></TD>
											<TD style="HEIGHT: 35px">
												<asp:TextBox id="txtSupervisor" onblur="reset__(this)" runat="server" CssClass="input_control_small" ReadOnly="True"
													BackColor="Gainsboro"></asp:TextBox>
												<asp:Button id="lnkbtnSupervisor" runat="server" CssClass="fontsmall" Text="Search" CausesValidation="False"></asp:Button>
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Supervisor is Required"
													ControlToValidate="txtSupervisor" CssClass="fontsmall"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="Label5" runat="server" CssClass="fontsmall">Supervisor FDIC Employee Number</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtSupervisorClientNumber" onblur="reset__(this)" runat="server" CssClass="input_control_small"></asp:TextBox>
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Supervisor's FDIC Employee Number is Required"
													ControlToValidate="txtSupervisorClientNumber" CssClass="fontsmall"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:Button id="btnExir" runat="server" CssClass="fontsmall" Text="Exit Without Saving" CausesValidation="False"></asp:Button>&nbsp;&nbsp;
									<asp:Button id="btnSave" runat="server" CssClass="fontsmall" Text="Save and Exit"></asp:Button>
									<asp:label id="lblScript" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:TextBox id="txtEmployeeClientNumber" runat="server" Visible="False"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
