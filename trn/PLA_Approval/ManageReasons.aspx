<%@ Page language="c#" Codebehind="ManageReasons.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.ManageReasons" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageReasons</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { COLOR: red; TEXT-DECORATION: underline }
		</style>
		<script>
		function setFocus(ele)
		{
			document.getElementById(ele).focus;
		}
		function popup(url1,height1,width1)
        {				
		    tmp=window.open(url1,'','status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
        }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="smallsize" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="gold"><asp:label id="lblTitle" runat="server" Font-Size="Small" Font-Bold="True">Label</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblInstruction" runat="server" Font-Bold="True">To delete an item clear the description of that item</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;
						<asp:Label id="lblScript" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:LinkButton id="lnkbtnAddItem" runat="server" CssClass="actbtn_go_next_button">Add Reason</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="dgReasons" runat="server" CssClass="smallsize" AutoGenerateColumns="False" BorderColor="White"
							CellPadding="3" PageSize="6" AllowPaging="True" Width="100%">
							<ItemStyle BackColor="Gainsboro"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#AAAADD"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Description"></asp:TemplateColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="txtNew" runat="server" TextMode="MultiLine" Width="98%" Height="50px" Visible="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:LinkButton id="lnkbtnSave" runat="server" CssClass="act_save_button">Save</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="lkbtnReset" runat="server" CssClass="act_reset_button">Reset Current Screen Data</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="lnkbtnClose" runat="server" CssClass="act_close_button">Close</asp:LinkButton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
