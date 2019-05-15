<%@ Page language="c#" Codebehind="ExpenseAdjustmentWriter.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.ExpenseAdjustmentWriter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExpenseAdjustmentWriter</title>
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
		function RemainingLetters(txtfld,countername)
		{
			currentStr = txtfld.value;
			currentLength = currentStr.length;			   
			document.getElementById(countername).value=4000-currentLength;
		}
		
		var fldNameConst = "";
		function GetInitialData(fldName)
		{
			if (fldNameConst=="")
				fldNameConst = fldName;
			strValue = opener.document.getElementById(fldNameConst).value;
			txtreasonfield = document.getElementById('txtReason');
			if (txtreasonfield == null)
				window.setTimeout("GetInitialData(fldNameConst)",200);
			try
			{
			document.getElementById('txtReason').value = strValue;
			document.getElementById('txtCounter').value = 4000-strValue.length;
			}
			catch (e)
			{
			}			
		}
		
		function SaveData(fldName)
		{
		  opener.document.getElementById(fldName).value = document.getElementById('txtReason').value;
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="smallsize" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="gold"><asp:label id="lblTitle" runat="server" Font-Size="Small" Font-Bold="True">Expense Writer For Item #</asp:label></TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid">
						<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%"><asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD><asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD><asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
								<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label><asp:label id="lblScript" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
								<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="2">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="smallsize" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><asp:label id="lblReasonTitle" runat="server">Reason For Adjustment of Item #</asp:label></TD>
								<TD><asp:label id="Label26" runat="server">Maximum 4000 Character</asp:label>&nbsp;&nbsp;
									<asp:label id="Label27" runat="server">Remaining</asp:label>&nbsp;
									<asp:textbox id="txtCounter" runat="server" BorderColor="White" BorderStyle="None" Width="40px">4000</asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:textbox id="txtReason" onkeyup="RemainingLetters(this,'txtCounter')" runat="server" Width="98%"
							TextMode="MultiLine" MaxLength="4000" Height="150px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						<asp:HyperLink id="hlSave" runat="server" CssClass="act_Save_button">Save and Close</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:HyperLink id="HyperLink1" runat="server" CssClass="act_close_button" NavigateUrl="javascript:window.close()">Close Without Saving</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
