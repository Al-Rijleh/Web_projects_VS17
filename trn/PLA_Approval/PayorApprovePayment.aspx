<%@ Page language="c#" Codebehind="PayorApprovePayment.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.PayorApprovePayment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Payor Approves Full Payment</title>
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
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 5px; POSITION: absolute; TOP: 5px"
				cellSpacing="0" cellPadding="0" width="790" border="0">
				<TR>
					<TD vAlign="top" style="BORDER-BOTTOM: silver thin solid">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							
							
							<TR>
								<TD width="150">
									<asp:label id="Label3" runat="server" Font-Bold="True" CssClass="fontsmall">Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label></TD>
							</TR>
							
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
                        &nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<asp:Label id="lbl_fldPla_Approval_PayorPayFulllPayment" runat="server" CssClass="fontsmall">
							To finalize your payments of the expenses for the above captioned training, click <b>
								Save</b>; otherwise, click <b>Cancel</b></asp:Label>
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD height="50" valign="top">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="2" align="center">&nbsp;
									<asp:Label id="lblWarning" runat="server" Font-Bold="True" CssClass="fontsmall" ToolTip="Warning supervisor that he/she will approving a request which has a Zero approved amount"
										ForeColor="Maroon"><br>You are about to approve an application which has ZERO paid amount. Are you sure  want to continue?<br><br></asp:Label></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD height="1%">
                        <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="btnSave_Click"
                            Text="Save" ToolTip="Save decision  and exit" Width="75px" />&nbsp;<asp:Button ID="btnCancel"
                                runat="server" OnClick="btnCancel_Click" Text="Cancel" ToolTip="Exit without saving"
                                Width="75px" /></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
