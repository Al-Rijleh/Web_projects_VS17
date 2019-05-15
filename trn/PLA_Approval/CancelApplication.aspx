<%@ Page language="c#" Codebehind="CancelApplication.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.CancelApplication" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CancelApplication</title>
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
		    	tmp=window.open(url1,'','status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 5px; POSITION: absolute; TOP: 5px"
				cellSpacing="0" cellPadding="0" width="790" border="0">
				<TR>
					<TD vAlign="top">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">							
							
							<TR>
								<TD width="150">
									<asp:label id="lblCourceName" runat="server" Font-Bold="False" CssClass="fontsmall">Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label></TD>
							</TR>
							
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD id="q" style="BORDER-TOP: silver thin solid" vAlign="top">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<asp:label id="lbl_fldPla_ApprovalSupervisorDoCancellation" runat="server" CssClass="fontsmall"><strong><span style="color: red;">Warring:</span></strong><span style="color: red;"> </span>Once the above mentioned CDP application is removed, Only Employee <b>[ee]</b> can reset it</asp:label></TD>
				<TR>
					<TD vAlign="top">
						&nbsp;&nbsp;</TD>
				<TR>
					<TD vAlign="top">
						&nbsp; &nbsp;</TD>
				<TR>
					<TD height="1%">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0"  runat="server" visible = "false">
							<TR>
								<TD vAlign="top" width="20%" height="15"></TD>
								<TD vAlign="top" height="15"></TD>
							</TR>
							<TR>
								<TD vAlign="top">&nbsp;</TD>
								<TD>
									<asp:Label id="Label26" runat="server" CssClass="fontsmall">Maximum 4000 Character</asp:Label>
									<asp:Label id="Label27" runat="server">Remaining</asp:Label>
									<asp:TextBox id="txtCounter" runat="server" Width="40px" BorderColor="White" BorderStyle="None" CssClass="fontsmall">4000</asp:TextBox></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:label id="Label5" runat="server" CssClass="fontsmall"> Reason for Cancelation</asp:label><BR>
									&nbsp;<BR>
								</TD>
								<TD>
									<asp:textbox id="txtOther" runat="server" Width="98%" Height="150px" onkeyup="RemainingLetters(this,'txtCounter')"
										CssClass="input_control_small" TextMode="MultiLine" MaxLength="4000"></asp:textbox></TD>
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
                            Text="Save" Width="75px" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="fontsmall" OnClick="btnCancel_Click"
                            Text="Cancel" Width="75px" />
						<asp:label id="lblScript" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
