<%@ Page language="c#" Codebehind="ProgramCodes.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ProgramCodes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProgramCodes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script>
		  function returnvalue(txt)
		  {			
			window.opener.document.getElementById('txtProgramCode').value = txt;
			window.close();
		  }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center"><asp:label id="Label1" runat="server" Font-Bold="True">Program Codes</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:hyperlink id="HyperLink1" runat="server" CssClass="act_close_button" NavigateUrl="javascript:window.close()">Close</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:RadioButtonList id="optProgramCode" runat="server" CssClass="fontsmall" RepeatColumns="2" AutoPostBack="True"></asp:RadioButtonList></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblScript" runat="server"></asp:label><asp:hyperlink id="HyperLink2" runat="server" CssClass="act_close_button" NavigateUrl="javascript:window.close()">Close</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				</TD></TR></TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
