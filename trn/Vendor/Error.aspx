<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Vendor.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Error</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
	</HEAD>
	<body onblur="window.focus()">
    <form id="form1" runat="server">
    <TABLE class="fontsmall" id="Table2" style="LEFT: 4px; POSITION: absolute; TOP: 4px" height="100%"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" bgColor="#ffff99">
						<TABLE class="fontsmall" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="red" height="50">
									<asp:label id="Label1" runat="server" BackColor="Red" ForeColor="White" Font-Bold="True" Font-Size="Small">ERROR</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#ffff99" height="1%">&nbsp;
								</TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ffff99" height="1%">&nbsp;
									<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#ffff99" height="1%">&nbsp;
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ffff99" height="1%">
									<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="Javascript:window.close()" CssClass="act_close_button">Close</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="fontsmall" id="Table3" style="LEFT: 4px; POSITION: absolute; TOP: 4px" height="100%"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" bgColor="#ffff99">
						<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="red" height="50">
									<asp:label id="Label2" runat="server" BackColor="Red" ForeColor="White" Font-Bold="True" Font-Size="Small">ERROR</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#ffff99" height="1%">&nbsp;
								</TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ffff99" height="1%">&nbsp;
									<asp:label id="Label3" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#ffff99" height="1%">&nbsp;
									<asp:Label id="Label4" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ffff99" height="1%">
									<asp:HyperLink id="HyperLink2" runat="server" NavigateUrl="Javascript:window.close()" CssClass="act_close_button">Close</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
    </form>
    <script> window.focus(); </script>
</body>
</html>
