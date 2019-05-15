<%@ Page language="c#" Codebehind="SearchEmployee.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.SearchEmployee" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Employee Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { COLOR: red; TEXT-DECORATION: underline }
		</style>
		<script>
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="smallsize" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" bgColor="gold" colSpan="2"><asp:label id="lblTitle" runat="server" Font-Size="Small" Font-Bold="True">Find an Administrator to Assign</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD width="20%">&nbsp;</TD>
								<TD><asp:label id="lblScript" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD width="20%"><asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD><asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD><asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblCourceName" runat="server" Font-Bold="True">Training Requested</asp:label></TD>
								<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
								<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" colSpan="2">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblInstruction" runat="server">Type in the name of the administrator you would like to assign by typing his/her last name, first name.  The more letters of the name you type, more specific results will appear listed.  Click on the administrator’s Name, Email or Action to select as the assigned Administrator</asp:label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblHeading" runat="server">Find an administrator (last, first): </asp:label>&nbsp;
						<asp:textbox id="txtSearch" runat="server" CssClass="smallsize"></asp:textbox><asp:linkbutton id="lnkbtnGo" runat="server" CssClass="actbtn_go_next_button">Go</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgEEs" runat="server" CssClass="smallsize" AutoGenerateColumns="False" Width="100%"
							BorderColor="White" BorderWidth="2px">
							<ItemStyle BackColor="Gainsboro"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" BackColor="#AAAADD"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Name"></asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Email"></asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px">&nbsp;</TD>
				</TR>
				<TR>
					<TD><asp:linkbutton id="lmkbtnCancel" runat="server" CssClass="act_close_button">Close</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
