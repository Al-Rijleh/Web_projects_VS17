<%@ Page language="c#" Codebehind="BudgetDetail.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.BudgetDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Budget Detail</title>
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
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="window.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE class="smallsize" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%"><asp:label id="Label4" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD><asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD><asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" align="center" colSpan="2">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="Label3" runat="server" Font-Bold="True" Font-Size="Small">Budget Detail</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px"><asp:label id="Label1" runat="server" Font-Bold="True">Budget Year</asp:label><asp:dropdownlist id="ddlBudgetYear" runat="server" Width="60px" CssClass="smallsize" AutoPostBack="True"></asp:dropdownlist><asp:label id="lblBalance" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid">&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center"><asp:datagrid id="dgBudgetDetail" runat="server" Width="75%" CssClass="smallsize" CellPadding="5"
							BorderWidth="1px" BorderColor="Black" AutoGenerateColumns="False">
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#0066CC"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Category Name"></asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Amount">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>
                        <br />
                        &nbsp;<asp:Label ID="lblCompetitveProgramBudget" runat="server" CssClass="fontsmall"
                            Font-Bold="True" Text="Competitive Program Budget Detail"></asp:Label><br />
                    </TD>
				</TR>
				<TR>
					<TD style="height: 16px" align="center">
                        <asp:DataGrid ID="dgCPDetail" runat="server" AutoGenerateColumns="False" BorderColor="Black"
                            BorderWidth="1px" CellPadding="5" CssClass="fontsmall" OnItemDataBound="dgCPDetail_ItemDataBound"
                            Width="75%">
                            <Columns>
                                <asp:BoundColumn DataField="category_name" HeaderText="Category Name"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Amount" HeaderText="Amount">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Right" />
                                </asp:BoundColumn>
                            </Columns>
                            <HeaderStyle BackColor="#0066CC" Font-Bold="True" ForeColor="White" />
                        </asp:DataGrid></TD>
				</TR>
                <tr>
                    <td style="height: 16px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 16px">
						<asp:HyperLink id="HyperLink1" runat="server" CssClass="act_close_button" NavigateUrl="Javascript:window.close()">Close</asp:HyperLink></td>
                </tr>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
