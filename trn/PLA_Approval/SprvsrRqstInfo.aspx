<%@ Page language="c#" Codebehind="SprvsrRqstInfo.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.SprvsrRqstInfo" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Request More Information</title>
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
			   document.getElementById(countername).value=4000-currentLength;
			}

			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 3px; POSITION: absolute; TOP: 5px"
				cellSpacing="0" cellPadding="0" width="790" border="0">
				<TR>
					<TD vAlign="top">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="150">
									<asp:label id="lblCourseName" runat="server" Font-Bold="False" CssClass="fontsmall">Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="BORDER-TOP: silver thin solid" vAlign="top">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<asp:Label id="lbl_fld_pla_approval_suppervisor_request_more_information" runat="server" CssClass="fontsmall">To request additional information from the above captioned employee, write your request in the "Information Requested" text box, and click <B>
								Save</B>; otherwise, click <B>Cancel</B></asp:Label></TD>
				</TR>
				<TR>
					<TD height="1%">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="215">&nbsp;</TD>
								<TD>
									<asp:Label id="Label26" runat="server" CssClass="fontsmall">Maximum 4000 Character</asp:Label>
									<asp:Label id="Label27" runat="server">Remaining</asp:Label>
									<asp:TextBox id="txtCounter" runat="server" Width="40px" BorderColor="White" BorderStyle="None" CssClass="fontsmall">4000</asp:TextBox></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:Label id="Label5" runat="server" CssClass="fontsmall"> Information Requested</asp:Label>
									<asp:Label id="Label7" runat="server" ForeColor="Red">*</asp:Label><BR>
									&nbsp;<BR>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Required Field"
										ControlToValidate="txtMemo" CssClass="fontsmall"></asp:RequiredFieldValidator></TD>
								<TD>
									<asp:TextBox id="txtMemo" runat="server" onkeyup="RemainingLetters(this,'txtCounter')" CssClass="fontsmall"
										Width="98%" TextMode="MultiLine" Height="200px" MaxLength="4000"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:label id="Label30" runat="server" ForeColor="Red">*</asp:label>
									<asp:label id="Label29" runat="server" CssClass="fontsmall">Denotes required Information</asp:label>
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
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
                                runat="server" CssClass="fontsmall" OnClick="btnCancel_Click" Text="Cancel" ToolTip="Exit without saving"
                                Width="75px" CausesValidation="False" /></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
