<%@ Page language="c#" Codebehind="PartialPayment.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.PartialPayment" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Payor Approves Partial Payment</title>
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
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 5px; POSITION: absolute; TOP: 5px"
				cellSpacing="0" cellPadding="0" width="790" border="0">
				<TR>
					<TD vAlign="top" style="BORDER-BOTTOM: thin solid">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							
							<TR>
								<TD width="150">
									<asp:label id="Label3" runat="server" Font-Bold="False" CssClass="fontsmall">Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label>
                                    <asp:TextBox ID="txtMemo" runat="server"></asp:TextBox></TD>
							</TR>							
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top"></TD>
				</TR>
				<TR>
					<td style="background-color: #800000; height: 100px;" valign="middle">
                            <asp:Label ID="lblPayedinFull" runat="server" CssClass="fontmedium" Text="If you paid less than the full amount because you received a discount on this application, then press the button labeled Full Payment Approval" Font-Bold="True" ForeColor="White"></asp:Label>
                            <asp:Button ID="btnFullPaymentApproval" runat="server" CssClass="fontsmall" OnClick="btnFullPaymentApproval_Click"
                                Text="Full Payment Approval" ToolTip="Full Payment Approval" style="margin-left:auto;margin-right:auto;" Height="35px" Width="200px"/></td>
                    <tr>
                        
                                <TD vAlign="middle">
						<asp:Label id="lbl_fldPla_ApprovalPayorParitalPayment" runat="server" CssClass="fontsmall" Width="641px"><br />To finalize your partial payments of the expenses for the above captioned training, click <b>
								Save</b>; otherwise, click <b>Cancel</b> <br><br> </asp:Label><br />
                    </TD>
                    </tr>
				<TR>
					<TD height="1%">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" width="20%" height="15"></TD>
								<TD vAlign="top" height="15">
									<asp:LinkButton id="lnkbtnManageReasons" runat="server" CssClass="actbtn_go_next_button">Manage Reasons</asp:LinkButton></TD>
							</TR>
							<TR>
								<TD vAlign="top" width="20%" height="5"></TD>
								<TD vAlign="top" height="5"></TD>
							</TR>
							<TR>
								<TD vAlign="top" height="180" width="20%">
									<asp:Label id="Label4" runat="server" CssClass="fontsmall"> Reason for Partial Payment</asp:Label>
								</TD>
								<TD vAlign="top" height="180"><DIV style="BORDER-RIGHT: silver thin solid; BORDER-TOP: silver thin solid; OVERFLOW: auto; BORDER-LEFT: silver thin solid; WIDTH: 100%; BORDER-BOTTOM: silver thin solid; POSITION: relative; HEIGHT: 100%; text-align: left"
										align="left">
										<asp:checkboxlist id="chklstReasons" runat="server" Width="100%" CssClass="input_control_small" BorderColor="Silver"
											BorderStyle="None" BorderWidth="1px"></asp:checkboxlist></DIV>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" style="HEIGHT: 2px">&nbsp;</TD>
								<TD style="HEIGHT: 2px">
									<asp:Label id="Label26" runat="server" CssClass="fontsmall">Maximum 3000 Character</asp:Label>
									<asp:Label id="Label27" runat="server">Remaining</asp:Label>
									<asp:TextBox id="txtCounter" runat="server" Width="40px" BorderStyle="None" BorderColor="White" CssClass="fontsmall">3000</asp:TextBox></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:Label id="Label5" runat="server" CssClass="fontsmall">Other Reason for Partial Payment</asp:Label>
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
								<TD>
									<asp:TextBox id="txtOther" runat="server" Height="50px" onkeyup="RemainingLetters(this,'txtCounter')"
										TextMode="MultiLine" Width="100%" CssClass="input_control_small"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
							</TR>
						</TABLE>
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
