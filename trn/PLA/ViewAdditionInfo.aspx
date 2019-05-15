<%@ Page language="c#" Codebehind="ViewAdditionInfo.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ViewAdditionInfo" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewAdditionInfo</title>
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="95%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" height="10%">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" bgColor="gold" colSpan="2">
									<asp:Label id="Label4" runat="server" Font-Size="Small" Font-Bold="True">Training Value</asp:Label></TD>
							</TR>
							<TR>
								<TD width="20%">&nbsp;</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20%">
									<asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD>
									<asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD>
									<asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="60%">
						<asp:TextBox id="txtAdditionInformation" runat="server" Width="100%" CssClass="fontsmall" Height="95%"
							TextMode="MultiLine" ReadOnly="True" BackColor="Gainsboro" BorderColor="White" BorderStyle="None"
							BorderWidth="1px"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD height="1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD height="1%">
						<asp:LinkButton id="lnkbtnCancel" runat="server" CssClass="act_close_button" CausesValidation="False">Close</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
