<%@ Page language="c#" Codebehind="AdjutmentHistory.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.AdjutmentHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdjutmentHistory</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="-1"> 
		<script src="/js/dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="795" border="0">
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server" Font-Bold="False">Adjustments Histor For:</asp:Label>&nbsp;
						<asp:Label id="lblType" runat="server" Font-Bold="True"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="dgAdjust" runat="server" CssClass="fontsmall" AutoGenerateColumns="False" Width="98%" OnItemCreated="dgAdjust_ItemCreated1">
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Created_By" HeaderText="Created By"></asp:BoundColumn>
								<asp:BoundColumn DataField="Add_Date" HeaderText="Add Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="expense_type" HeaderText="Expense Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="paid_amount_adjustment" HeaderText="Adjustment Amount" DataFormatString="{0:C}"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Reason"></asp:TemplateColumn>
							</Columns>
                            <AlternatingItemStyle BackColor="#F0F0F0" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" />
                            <ItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" />
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>Reason</TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="txtReason" runat="server" CssClass="fontsmall" TextMode="MultiLine" ReadOnly="True"
							BackColor="Gainsboro" Width="98%" Height="100px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
                        <asp:Button ID="btnClose" runat="server" CssClass="fontsmall" OnClick="btnClose_Click"
                            Text="Close" Width="75px" /></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
