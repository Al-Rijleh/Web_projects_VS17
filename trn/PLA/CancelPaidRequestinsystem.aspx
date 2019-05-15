<%@ Page language="c#" Codebehind="CancelPaidRequestinsystem.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.CancelPaidRequestinsystem" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CancelPaidRequestinsystem</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Pragma" content="no-cache">
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
			<TABLE class="fontslall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="95%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="1">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="220">
									<asp:label id="Label3" runat="server" Font-Bold="True" CssClass="fontsmall"> Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label>
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" vAlign="top" height="19"></TD>
				</TR>
				<TR>
					<TD vAlign="top" height="20">
						<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0"
							height="30">
							<TR>
								<TD width="400" vAlign="middle" height="100%">
									<asp:Label id="Label4" runat="server" CssClass="fontsmall">Reason for Cancellation</asp:Label>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required Information"
										ControlToValidate="txtReason" BorderStyle="None" BorderWidth="1px" Height="18px" CssClass="fontsmall"></asp:RequiredFieldValidator></TD>
								<TD vAlign="middle" height="100%">
									<asp:Label id="Label13" runat="server" CssClass="fontsmall">Maximum 4000 Character</asp:Label>&nbsp;
									<asp:Label id="Label6" runat="server" CssClass="fontsmall">Remaining</asp:Label>
									<asp:TextBox id="txtReasonCounter" onblur="reset__(this)" runat="server" Width="40px" BorderColor="White"
										BorderStyle="None" CssClass="fontsmall">4000</asp:TextBox></TD>
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
						<asp:Button id="btnSave" runat="server" Width="75px" CssClass="fontsmall" Text="Save"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Width="75px" CssClass="fontsmall" Text="Cancel" CausesValidation="False"></asp:Button>&nbsp;&nbsp;
						<asp:Label id="Label5" runat="server" Font-Bold="True" CssClass="fontsmall">Once you cancel this item, you will not be able to reactivate it</asp:Label></TD>
				</TR>
			</TABLE>
			<SCRIPT>document.getElementById('txtReason').focus();	</SCRIPT>
		</form>
	</body>
</HTML>
