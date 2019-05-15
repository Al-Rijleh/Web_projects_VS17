<%@ Page language="c#" Codebehind="CancelPaidRequest.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.CancelPaidRequest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CancelPaidRequest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<<META http-equiv="Pragma" content="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
		function RemainingLetters(txtfld,countername)
			{
			   //currentStr = document.getElementById(txtfldname).value;
			   currentStr = txtfld.value;
			   currentLength = currentStr.length;			   
			   document.getElementById(countername).value=4000-currentLength;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="95%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="1">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="HEIGHT: 11px" colSpan="2">
									<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
								<TD style="HEIGHT: 11px" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 11px" colSpan="2">
									<asp:label id="Label12" runat="server">Cancel Paid Request</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD width="25%">&nbsp;</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20%">
									<asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD>
									<asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label>
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD>
									<asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
								<TD>
									<asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="2">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" vAlign="top" height="19">
						<asp:Label id="Label5" runat="server" Font-Bold="True" ForeColor="Red">Once you cancel this item, you will not be able to reactivate it</asp:Label></TD>
				</TR>
				<TR>
					<TD vAlign="top" height="20">
						<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0"
							height="30">
							<TR>
								<TD width="400" vAlign="middle" height="100%">
									<asp:Label id="Label4" runat="server">Reason for Cancellation</asp:Label>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required Information"
										ControlToValidate="txtReason" BackColor="Yellow" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px"
										Height="18px"></asp:RequiredFieldValidator></TD>
								<TD vAlign="middle" height="100%">
									<asp:Label id="Label13" runat="server">Maximum 4000 Character</asp:Label>&nbsp;
									<asp:Label id="Label6" runat="server">Remaining</asp:Label>
									<asp:TextBox id="txtReasonCounter" runat="server" Width="40px" BorderColor="White" BorderStyle="None">4000</asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="120">
						<asp:TextBox id="txtReason" onkeyup="RemainingLetters(this,'txtReasonCounter')" runat="server"
							CssClass="fontsmall" TextMode="MultiLine" Width="99%" Height="119px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top" height="10">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<asp:LinkButton id="lnkbtnSave" runat="server" CssClass="act_save_button">Save</asp:LinkButton>&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="lnkbtnCancel" runat="server" CssClass="act_close_button" CausesValidation="False">Cancel</asp:LinkButton></TD>
				</TR>
			</TABLE>
			<script>document.getElementById('txtReason').focus();	</script>
		</form>
	</body>
</HTML>
