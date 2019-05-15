<%@ Page language="c#" Codebehind="ViewEmail.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ViewEmail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewEmail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0" class="fontsmall">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%">
									<asp:label id="Label4" runat="server" Font-Bold="True" Visible="False">Employee</asp:label></TD>
								<TD>
									<asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label2" runat="server" Font-Bold="True" Visible="False">Employer</asp:label></TD>
								<TD>
									<asp:label id="lblDivision" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="lblCourceName" runat="server" Font-Bold="True" Visible="False"> Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
								<TD>
									<asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" align="center" colSpan="2">
									<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="Small">Email History</asp:Label></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid" colSpan="1">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<asp:Label id="Label6" runat="server" Font-Bold="True">To:</asp:Label></TD>
								<TD>
									<asp:Label id="lblTo" runat="server"></asp:Label></TD>
								<TD align="right">
									<asp:Label id="Label9" runat="server" Font-Bold="True">Sent:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Label id="lblSent" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="Label1" runat="server" Font-Bold="True">Subject:</asp:Label></TD>
								<TD colSpan="2">
									<asp:Label id="lblSubject" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblMemo" runat="server" BorderStyle="None"></asp:Label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:HyperLink id="HyperLink1" runat="server" CssClass="act_close_button" NavigateUrl="javascript:window.close()">Close</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</form>
		<script>window.focus()</script>
	</body>
</HTML>
