<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="System_Administrator.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.System_Administrator" %>
<HTML>
	<HEAD>
		<title>Select Application</title>
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
						<TABLE class="smallsize" id="Table1" runat="server" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="smallsize" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="500"><asp:label id="Label3" runat="server">Reroute PLA requests with terminated  administrator</asp:label>&nbsp;
												<asp:label id="lblRerouteAdminCount" runat="server" CssClass="fontsmall">(0 Pending)</asp:label></TD>
											<TD><asp:linkbutton id="lnkbtnRerouteAdministrators" runat="server" CssClass="fontsmall">Process</asp:linkbutton><asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px; HEIGHT: 16px"><asp:label id="Label4" runat="server" CssClass="fontsmall">Reroute PLA requests with terminated  2nd inline supervisor</asp:label>&nbsp;
												<asp:label id="lblReroute2nsSupCount" runat="server" CssClass="fontsmall">(0 Pending)</asp:label></TD>
											<TD style="HEIGHT: 16px"><asp:linkbutton id="lnkbtnReroute2ndSInlineSup" runat="server" CssClass="fontsmall">Process</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px">&nbsp;</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px">
												<asp:Label id="Label5" runat="server" CssClass="fontsmall">Enter Extra Budget Amount Approved By Office/Division Director</asp:Label></TD>
											<TD>
												<asp:linkbutton id="lnkbtnAddBudget" runat="server" CssClass="fontsmall">Process</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px; HEIGHT: 15px">
												<asp:Label id="Label6" runat="server" CssClass="fontsmall">Adjust Paid Amount For Paid Training Request</asp:Label></TD>
											<TD style="HEIGHT: 15px">
												<asp:linkbutton id="lnkbtnAdjustPaidRequest" runat="server" CssClass="fontsmall">Process</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px">&nbsp;</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px">
												<asp:Label id="Label7" runat="server" CssClass="fontsmall">Assign Supervisor</asp:Label></TD>
											<TD>
												<asp:linkbutton id="lnkbtnAssignSupervisor" runat="server" CssClass="fontsmall">Process</asp:linkbutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 479px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="/scripts/basweb.exe/view?Module=N" CssClass="fontsmall" Visible="False">Home to MyEnroll Main Page</asp:hyperlink></TD>
							</TR>
						</TABLE>
						&nbsp;
                        <asp:Label ID="Label1" runat="server" CssClass="fontsmall" Text="Functionality of this page moved to "></asp:Label>
                        <asp:HyperLink ID="hlData_maintnance" runat="server" CssClass="fontsmall" NavigateUrl="/WEB_PROJECTS/TRN/DATA_MAINTNANCE/DEFAULT.ASPX?SkipCheck=YES"
                            ToolTip="Go to Super User Managment Page">Super User Managment Page</asp:HyperLink></form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
