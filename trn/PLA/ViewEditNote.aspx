<%@ Page language="c#" Codebehind="ViewEditNote.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.ViewEditNote" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>View/Edit Expense Note</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover {CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
		<script>
			function reloadclose()
			{
				opener.window.location="TrainingExpenses.aspx";
				document.focus();
				window.close();
			}
			
			function RemainingLetters()
			{
			   currentStr = document.getElementById('txtDescribtion').value;
			   currentLength = currentStr.length;			   
			   document.getElementById('txtRemaining').value=4000-currentLength;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="90%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%">
									<asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD>
									<asp:label id="lblEmployeeInfo" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label2" runat="server">Employer</asp:label></TD>
								<TD>
									<asp:label id="lblDivision" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server"></asp:label>
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" height="55%">
						<TABLE class="fontsmall" id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD width="80%" height="5%">
									<asp:Label id="Label4" runat="server">Note For: </asp:Label>
									<asp:Label id="lblExpenseType" runat="server">Label</asp:Label></TD>
								<TD height="5%"></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:textbox id="txtDescribtion" onkeyup="RemainingLetters()" runat="server" Height="98%" MaxLength="4000"
										TextMode="MultiLine" Width="98%" CssClass="fontsmall"></asp:textbox></TD>
								<TD vAlign="top">
									<asp:Label id="Label26" runat="server">Maximum 4000 Character</asp:Label>
									<asp:Label id="Label27" runat="server">Remaining</asp:Label>
									<asp:TextBox id="txtRemaining" runat="server" Width="40px" BorderColor="White" BorderStyle="None">4000</asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="BORDER-TOP: silver thin solid" height="1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD height="1%">
						<asp:LinkButton id="lnkbtnCancel" runat="server" CausesValidation="False">Cancel</asp:LinkButton>&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="lnkbtnSaveAndStay" runat="server"> Save</asp:LinkButton></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>document.focus()</SCRIPT>
	</body>
</HTML>
