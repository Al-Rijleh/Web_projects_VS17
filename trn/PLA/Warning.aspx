<%@ Page language="c#" Codebehind="Warning.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.Warning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Warning</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
		<script>
		  function closerefresh()
		  {
			opener.document.focus();
		    window.close();
		  }
		  function savenext()
		  {
			opener.document.getElementById('btnSaveNext').click();
			window.close();
		  }
		  function saveback()
		  {
			opener.document.getElementById('btnSaveBack').click();
			window.close();
		  }
		  function closeparent()
		  {
			opener.document.getElementById('btnClose').click();
			window.close();
		  }
		  
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onblur="window.window.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 4px; POSITION: absolute; TOP: 4px"
				cellSpacing="0" cellPadding="0" width="98%" border="0">
				<TR>
					<TD bgColor="#ff6600" height="50"><asp:label id="Label1" runat="server" BackColor="#FF6600" ForeColor="White" Font-Bold="True"
							Font-Size="Small">WARNING! </asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:label id="lblScript" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="left"><asp:label id="lblInstruction" runat="server" Width="90%">Data was modified without being saved before navigating to the next  screen. Choose one of the options below:</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px" align="center">
						<asp:linkbutton id="lnkbtnSaveNext" runat="server" CssClass="act_save_button">Save Changes, then Continue</asp:linkbutton>&nbsp;&nbsp;<asp:linkbutton id="lnkbtnCloseStay" runat="server" CssClass="act_close_button">Close and Stay on Page</asp:linkbutton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
