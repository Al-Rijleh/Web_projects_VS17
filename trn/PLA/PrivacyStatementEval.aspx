<%@ Page language="c#" Codebehind="PrivacyStatementEval.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.PrivacyStatementEval" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrivacyStatementEval</title>
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD height="70">
						<TABLE id="Table6" height="62" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="gold" colSpan="3">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<asp:image id="Image1" runat="server" ImageUrl="/img/fdiclogo.jpg"></asp:image></TD>
											<TD width="140" background="img/Fill.JPG"></TD>
											<TD align="right" width="600">
												<asp:image id="Image2" runat="server" ImageUrl="/img/Met_Logo_Bar_MyEnroll_Logo.jpg"></asp:image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3">&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="3"><asp:label id="Label4" runat="server" CssClass="fontsmall" Font-Bold="True">Privacy Act Statement</asp:label>
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="3">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="71">
						<TABLE class="fontsmall" id="Table2" height="1" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD width="20%"><asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD><asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD><asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label3" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
								<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="10" align="center"><asp:label id="Label20" runat="server" Font-Bold="True">Privacy Act Statement</asp:label></TD>
				</TR>
				<TR>
					<TD height="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="280"><asp:label id="lbl_fldPLAPrivacyNotice" runat="server">Star Functionality Field</asp:label></TD>
				</TR>
				<TR>
					<TD height="30" style="border-top: silver thin solid; border-bottom: silver thin solid"><asp:radiobuttonlist id="optAgree" runat="server" CssClass="fontsmall" AutoPostBack="True" RepeatDirection="Horizontal">
							<asp:ListItem Value="0">I Agree</asp:ListItem>
							<asp:ListItem Value="1">I Disagree</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
				<TR>
					<TD height="20"><asp:label id="lblFormID" runat="server" CssClass="fontsmall">FDIC 2610/12 (10-06)</asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
