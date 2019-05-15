<%@ Page language="c#" Codebehind="SupervisorApprove.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.SupervisorApprove" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Supervisor Approve Request</title>
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
			function RemainingLetters(txtfld,countername)
			{
			   currentStr = txtfld.value;
			   currentLength = currentStr.length;			   
			   document.getElementById(countername).value=3000-currentLength;
			}
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" width="795" border="0">
				<TR>
					<TD vAlign="top">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="795" border="0">
							<TR>
								<TD width="150">
									<asp:label id="lblCourceName" runat="server" Font-Bold="False" CssClass="fontsmall">Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label>
									<asp:TextBox id="txtMemo" runat="server" Width="56px" Height="20px"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="BORDER-TOP: silver thin solid" vAlign="top">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<asp:Label id="lbl_fldPla_ApprovalSupervisorDoApprove" runat="server" CssClass="fontsmall">You have chosen to approve the training request, as captioned above.  If you wish to continue with this approval and assign an Administrator/Payor, click on the 
						<B>Search for Email link</B> below. If you prefer to discontinue  this assignment, click on the 
								<B>Cancel</B> button below. </asp:Label>
						<asp:Label id="lbl_fldPla_ApprovalSupervisorDoApproveCDP" runat="server" Visible="False" CssClass="fontsmall">You have chosen to approve the Career Development Plan application, If you wish to continue with this approval, click on the <B>
								Save</B> button below. If you prefer to discontinue this assignment,click on the <b>Cancel</b> button below. </asp:Label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<asp:Label id="lblWarning" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Maroon"
							ToolTip="Warning supervisor that he/she will approving a request which has a Zero approved amount"><BR>You are about to approve an application which has ZERO approved amount. Are you sure  want to continue?<BR><br></asp:Label>&nbsp;</TD>
				</TR>
				<TR>
					<TD height="1%">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="175" style="WIDTH: 175px"></TD>
								<TD>
                                    &nbsp;<asp:LinkButton id="lnkbtnSearch" runat="server" CausesValidation="False" CssClass="input_control_small">Search For Administrator</asp:LinkButton></TD>
							</TR>
							<TR>
								<TD width="175" style="WIDTH: 175px">
									<asp:Label id="lblName" runat="server" CssClass="fontsmall">Payor Name</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtName" runat="server" Width="250px" CssClass="input_control_small" MaxLength="15" ReadOnly="True"
										BackColor="Gainsboro"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px">
									<asp:Label id="lblAddress" runat="server" CssClass="fontsmall">Payor Email Address</asp:Label>
									<asp:Label id="lblStar" runat="server" ForeColor="Red">*</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtEmail" runat="server" Width="250px" CssClass="input_control_small" ReadOnly="True"
										BackColor="Gainsboro"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="txtEmail"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px" vAlign="top" height="2">
									<P><FONT size="1"></FONT>&nbsp;</P>
								</TD>
								<TD vAlign="top" height="2"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px" vAlign="top" height="15"></TD>
								<TD vAlign="top" height="15">
									<asp:LinkButton id="lnkbtnManageReasons" runat="server" CssClass="actbtn_go_next_button">Manage Reasons</asp:LinkButton></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px" vAlign="top" height="2"></TD>
								<TD vAlign="top" height="2"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px" vAlign="top" height="95">
									<asp:Label id="lblReasonMain" runat="server" CssClass="fontsmall">Reason for Partial Payment</asp:Label></TD>
								<TD vAlign="top" height="95">
									<DIV style="OVERFLOW: auto; WIDTH: 100%; POSITION: relative; HEIGHT: 100%; text-align: left"
										align="left">
										<asp:CheckBoxList id="chklstReasons" runat="server" CssClass="input_control_small" Width="98%" Height="100%"
											BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></asp:CheckBoxList></DIV>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px" vAlign="top" height="5"><FONT size="1">&nbsp;</FONT></TD>
								<TD vAlign="top" height="5">
									<asp:Label id="lblnumofchar" runat="server" CssClass="fontsmall">Maximum 3000 Character</asp:Label>
									<asp:Label id="lblRemainingText" runat="server">Remaining</asp:Label>
									<asp:TextBox id="txtCounter" runat="server" Width="40px" BorderStyle="None" BorderColor="White" CssClass="fontsmall">3000</asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 175px" vAlign="top">
									<asp:Label id="lblNoteTitle" runat="server" CssClass="fontsmall">Other Reason for Partial Payment</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtOther" onkeyup="RemainingLetters(this,'txtCounter')" runat="server" CssClass="input_control_small"
										Width="98%" TextMode="MultiLine" Height="40px" MaxLength="3000"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:label id="lblStar2" runat="server" ForeColor="Red">*</asp:label>
									<asp:label id="lblStarDescription" runat="server" CssClass="fontsmall">Denotes required Information</asp:label>
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD height="1%">
                        <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="btnSave_Click"
                            Text="Save" ToolTip="Save decision  and exit" Width="75px" />
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                            ToolTip="Exit without saving" Width="75px" CausesValidation="False" /></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
