<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="system_administrator_process_Reroute.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.system_administrator_process_Reroute" %>
<HTML>
	<HEAD>
		<title>Select Application</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META HTTP-EQUIV="Pragma" CONTENT="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		</STYLE>
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
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="smallsize">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid">
									<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<asp:label id="Label1" runat="server" Font-Bold="True">Super User</asp:label></TD>
											<TD>
												<asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
											<TD>
												<asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
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
									<asp:DataGrid id="dgReroute" runat="server" CssClass="smallsize" AutoGenerateColumns="False" CellPadding="5"
										Width="100%">
										<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
										<ItemStyle BackColor="White"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Top"
											BackColor="#505050"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="ee_name" HeaderText="Employee Name"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Training Requested"></asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Action">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:HyperLink id="HyperLink1" runat="server" CssClass="fontsmall" NavigateUrl="Javascript:window.location.href='System_Administrator.aspx?SkipCheck=YES'">Back</asp:HyperLink>
									<asp:label id="lblScript" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
