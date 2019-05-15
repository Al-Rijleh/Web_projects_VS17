<%@ Page language="c#" Codebehind="Saved.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.Saved" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Saved</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover {CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onblur="window.close()">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="#00cc00" height="50">
						<asp:label id="Label1" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="White"
							BackColor="#00CC00">MESSAGE </asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
					</TD>
				</TR>
				<TR>
					<TD align="center">&nbsp;
						<asp:label id="lblSaved" runat="server"> Data was Successfully Saved</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center">&nbsp;
						<asp:linkbutton id="lnklabYes" runat="server">Close</asp:linkbutton>&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
		<script> window.focus(); </script>
	</body>
</HTML>
