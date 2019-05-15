<%@ Page language="c#" Codebehind="ItemDetail.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ItemDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Expense Items</title>
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
		<script>
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="window.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%">
									<asp:label id="Label4" runat="server" Font-Bold="True">Employee</asp:label></TD>
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
								<TD style="BORDER-BOTTOM: silver thin solid" align="center" colSpan="2">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="Small">Expense Items</asp:Label></TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid">&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:DataGrid id="dgBudgetDetail" runat="server" CssClass="fontsmall" Width="75%" AutoGenerateColumns="False"
							BorderColor="Black" BorderWidth="1px" CellPadding="5">
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#0066CC"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Expense" HeaderText="Expense Type"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Amount">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server" ForeColor="Red">*</asp:Label>&nbsp;
						<asp:Label id="Label5" runat="server">Denote Estimated ETV Expense</asp:Label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:HyperLink id="HyperLink1" runat="server" CssClass="act_close_button" NavigateUrl="Javascript:window.close()">Close</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
