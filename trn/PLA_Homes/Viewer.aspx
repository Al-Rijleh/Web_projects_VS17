<%@ Page language="c#" Codebehind="Viewer.aspx.cs" AutoEventWireup="false" Inherits="PLA_Homes.Viewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Viewer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { COLOR: red; TEXT-DECORATION: underline }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="BORDER-RIGHT: #d8d8d8 1px solid; BORDER-TOP: #d8d8d8 1px solid; Z-INDEX: 101; LEFT: 0px; BORDER-LEFT: #d8d8d8 1px solid; BORDER-BOTTOM: #d8d8d8 1px solid; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" border="0" height="100%" width="100%">
				<TR>
					<TD class="header_cell" width="11"></TD>
					<TD class="Header_cell">
						<asp:label id="lblTitle" runat="server" Text="Generate Personalized, Bar Coded Flexible Spending Account Claim Forms"></asp:label></TD>
				</TR>
				<TR>
					<TD class="White_Body_Cell" width="11" height="5"></TD>
					<TD class="White_Body_Cell" vAlign="top" height="5"></TD>
				</TR>
				<TR>
					<TD class="White_Body_Cell" width="11"></TD>
					<TD class="White_Body_Cell" vAlign="top">
						<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 100%; text_aligh: left" align="left">
							<asp:Label id="lblInstruction" runat="server"></asp:Label>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD class="White_Body_Cell" width="11" height="5"></TD>
					<TD class="White_Body_Cell" vAlign="top" height="5"></TD>
				</TR>
				<TR>
					<TD class="White_Body_Cell" style="HEIGHT: 20px" width="11" height="20"></TD>
					<TD class="White_Body_Cell" height="20">
						<asp:Button id="btnCancel" runat="server" CssClass="General_button" Text="Cancel" CausesValidation="False"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="White_Body_Cell" width="11" height="10"></TD>
					<TD class="White_Body_Cell" height="10"></TD>
				</TR>
				<TR>
					<TD class="Footer_cell" width="11"></TD>
					<TD class="Footer_cell">
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
