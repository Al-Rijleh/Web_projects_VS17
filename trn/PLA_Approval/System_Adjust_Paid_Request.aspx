<%@ Page language="c#" Codebehind="System_Adjust_Paid_Request.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.System_Adjust_Paid_Request" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>System_Adjust_Paid_Request</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
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
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" height="395"
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
						<TABLE class="fontsmall" id="TableData" runat="server" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="150"><asp:label id="Label3" runat="server">Employee Name</asp:label></TD>
											<TD><asp:textbox id="txtEmployeeName" runat="server" CssClass="input_contrl_small" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:button id="btnSelect" runat="server" CssClass="actbtn_go_next_button" Text="Select" CausesValidation="False"></asp:button><asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD align="left"><asp:datagrid id="dgTrainingRequest" runat="server" CssClass="fontsmall" Width="100%" AutoGenerateColumns="False"
										CellPadding="5">
										<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
										<ItemStyle BackColor="White"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="title" HeaderText="Training Request"></asp:BoundColumn>
											<asp:BoundColumn DataField="description" HeaderText="Aproval Status"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Action">
                                                <HeaderStyle Width="250px" />
                                            </asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
                                    <asp:Button ID="btnExit" runat="server" CssClass="fontsmall" OnClick="btnExit_Click"
                                        Text="Exit" Width="75px" /></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
