<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="TrainingExpenses.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.TrainingExpenses" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training Expenses</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
		  function CheckDelete(expenseName)
			{
				var chk = confirm("Are you sure you want to delete "+expenseName+"? If Yes click Ok otherwise click Cancel")
				if (chk)				
				{
					document.Form1.doSave.value='Delete';
					__doPostBack('','');
				}
			}
		  function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		  function AddValues()
		  {
		    try
		    {
		       document.getElementById('txtCourseHoursTotal').value = 
		       parseFloat(document.getElementById('txtCourseHoursDuty').value)+parseFloat(document.getElementById('CourseHoursNonDuty').value);
		    }
		    catch (err)
		    {
				document.getElementById('txtCourseHoursTotal').value = "Error";
		    }
		  }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" >
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif">
					<cc1:UltimateMenu id="UltimateMenu1" runat="server"></cc1:UltimateMenu>
					<asp:Label id="lblWizardError" runat="server" Font-Bold="True" CssClass="fontsmall" ForeColor="Maroon"></asp:Label></TD>
			</TR>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="fontsmall" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%">
									<TABLE class="fontsmall" id="Table2" height="1%" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label><asp:label id="lblScript" runat="server"></asp:label><INPUT id="doSave" type="hidden" name="doSave" runat="server"></TD>
										</TR>
										<TR>
											<TD width="220"><asp:label id="Label5" runat="server" Font-Bold="True">Remaining Budget For: </asp:label><asp:dropdownlist id="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall"></asp:dropdownlist></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" height="5%"><asp:label id="lbl_fldTrainingExpenses" runat="server">Instruction</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top"><asp:linkbutton id="lnkbtnAddNewExpense" runat="server">(Add New Expense)</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:linkbutton id="lnkBtnNoExpense" runat="server">(No Expenses for Training)</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD vAlign="top" height="3%"></TD>
							</TR>
							<TR>
								<TD vAlign="top" height="60%"><asp:datagrid id="dgExpense" runat="server" Width="100%" CssClass="fontsmall" AutoGenerateColumns="False"
										BorderColor="White" CellPadding="3">
										<SelectedItemStyle BackColor="Yellow"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
										<ItemStyle BackColor="White"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#505050"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="expense_type" HeaderText="Expense Type">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="amount" HeaderText="Estimated Amount" DataFormatString="{0:C}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="approved_amount" HeaderText="Approved Amount" DataFormatString="{0:C}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vendor_name" HeaderText="Vendor Name"></asp:BoundColumn>
											<asp:BoundColumn DataField="vendor_contact_name" HeaderText="Vendor Contact"></asp:BoundColumn>
											<asp:BoundColumn DataField="vendor_phone" HeaderText="Vendor Phone"></asp:BoundColumn>
											<asp:BoundColumn DataField="vendor_email" HeaderText="Vendor E_mail"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
									<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="10%"><asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="Black">Total</asp:label>
												<asp:Label id="lblNoteMark" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Small">*</asp:Label></TD>
											<TD align="right" width="10%"><asp:label id="lblAmount" runat="server" Font-Bold="True" ForeColor="Black">58856.22</asp:label></TD>
											<TD>
                                                &nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<asp:Label id="Label1" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Small">*</asp:Label>
												<asp:Label id="lblNote" runat="server" CssClass="fontsmall">The Total Amount Shown Excludes ETV Expenses.</asp:Label></TD>
										</TR>
										<TR>
											<TD width="10%">&nbsp;</TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD width="10%" colSpan="3" style="height: 24px">
												<asp:Button id="btnHome" runat="server" Width="75px" CssClass="fontsmall" CausesValidation="False"
													Text="Home" ToolTip="Rrturn to select application"></asp:Button>
												<asp:Button id="btnBack" runat="server" Width="75px" CssClass="fontsmall" CausesValidation="False"
													Text="Back" ToolTip="Back to previous page"></asp:Button>
												<asp:Button id="btnNext" runat="server" Width="75px" CssClass="fontsmall" CausesValidation="False"
													Text="Next" ToolTip="GoTo next page"></asp:Button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top"></TD>
							</TR>
							<TR>
								<TD height="5%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD height="5%">&nbsp;</TD>
							</TR>
						</TABLE>
						&nbsp;</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
