<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="System_ApplyETV.aspx.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.System_ApplyETV_aspx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>System Apply ETV</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { COLOR: red; TEXT-DECORATION: underline }
		</style>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" height="98%"
			cellSpacing="0" cellPadding="0" width="98%" border="0">
			<TR vAlign="top" height="1%">
				<TD>
					<TABLE id="Table1head" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD><asp:label id="LblTemplateHeader1" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD><cc1:ultimatemenu id="um" runat="server"></cc1:ultimatemenu></TD>
						</TR>
						<TR>
							<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="smallsize" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
												<asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label>
												<asp:label id="lblScript" runat="server"></asp:label></TD>
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
									<TABLE class="smallsize" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="150">
												<asp:Label id="Label3" runat="server">Employee Name</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtEmployeeName" runat="server" BackColor="Gainsboro" ReadOnly="True" CssClass="smallsize"></asp:TextBox>
												<asp:Button id="btnSelect" runat="server" CssClass="actbtn_go_next_button" CausesValidation="False"
													Text="Select"></asp:Button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD align="left">
									<asp:datagrid id="dgTrainingRequest" runat="server" CssClass="smallsize" CellPadding="5" BorderWidth="1px"
										BorderColor="Black" AutoGenerateColumns="False" Width="75%">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#0066CC"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="title" HeaderText="Training Request"></asp:BoundColumn>
											<asp:BoundColumn DataField="description" HeaderText="Aproval Status"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<asp:HyperLink id="HyperLink1" runat="server" CssClass="act_back_button" NavigateUrl="Javascript:window.location.href='System_Administrator.aspx?SkipCheck=YES'">Exit </asp:HyperLink>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
			<TR vAlign="top" height="1%">
				<TD><asp:label id="LblTemplateFooter" runat="server"></asp:label></TD>
			</TR>
		</TABLE>
		<cc2:ultimatepanel id="upPO" style="Z-INDEX: 101; LEFT: 200px; POSITION: absolute; TOP: 1px" runat="server"></cc2:ultimatepanel>
	</body>
</HTML>
