<%@ Page language="c#" Codebehind="PLA_Step4.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.PLA_Step4" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Formulas Setup</title>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="100%" cellSpacing="0" cellPadding="0" width="96%" align="center" border="0">
			<tr vAlign="top" height="1%">
				<td align="left" width="100%"><asp:label id="LblTemplateHeader" runat="server"></asp:label></td>
			</tr>
			<tr vAlign="top" height="98%">
				<td vAlign="top" align="left" width="100%">
					<form id="Form1" method="post" runat="server">
						<TABLE class="smallsize" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%">
									<TABLE class="smallsize" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20%">
												<asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
											<TD>
												<asp:label id="lblEmployeeInfo" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label2" runat="server">Division</asp:label></TD>
											<TD>
												<asp:label id="lblDivision" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
											<TD>
												<asp:label id="lblCourseTitle" runat="server"></asp:label></TD>
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
									<TABLE class="smallsize" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20%" height="1%">
												<asp:Label id="Label20" runat="server">Training Type</asp:Label>
												<asp:Label id="Label21" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD width="30%" height="1%">
												<asp:DropDownList id="ddlTrainingType" runat="server" CssClass="smallsize" AutoPostBack="True"></asp:DropDownList></TD>
											<TD width="50%" height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="ddlTrainingType"
													ErrorMessage="Require Selection" InitialValue="xx"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%">
												<asp:Label id="Label4" runat="server">Career Development Form</asp:Label></TD>
											<TD height="1%">
												<asp:LinkButton id="lnkbtnCarrerDevelopmentForm" runat="server" CssClass="smallsize" CausesValidation="False">View</asp:LinkButton></TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label22" runat="server">Mandatory Training</asp:Label>
												<asp:Label id="Label8" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD height="1%">
												<asp:RadioButtonList id="optMandatoryTraining" runat="server" CssClass="smallsize" RepeatDirection="Horizontal"
													Font-Size="X-Small">
													<asp:ListItem Value="T">Yes</asp:ListItem>
													<asp:ListItem Value="F">No</asp:ListItem>
												</asp:RadioButtonList></TD>
											<TD height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="optMandatoryTraining"
													ErrorMessage="Require Selection"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label6" runat="server">Source of Training</asp:Label>
												<asp:Label id="Label14" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD height="1%">
												<asp:DropDownList id="ddlSourseTraining" runat="server" CssClass="smallsize"></asp:DropDownList></TD>
											<TD height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" InitialValue="xx" ErrorMessage="Require Selection"
													ControlToValidate="ddlSourseTraining" Display="Dynamic"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label5" runat="server">Purpose of Training </asp:Label>
												<asp:Label id="Label19" runat="server" ForeColor="Red">*</asp:Label></TD>
											<TD height="1%">
												<asp:DropDownList id="ddlPurposeOfTraining" runat="server" CssClass="smallsize"></asp:DropDownList></TD>
											<TD height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="ddlPurposeOfTraining"
													ErrorMessage="Require Selection" InitialValue="xx"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD height="1%">
												<asp:Label id="Label7" runat="server">Purpose of Training (other)</asp:Label></TD>
											<TD height="1%">
												<asp:TextBox id="txtPurposeOfTainingOther" runat="server" CssClass="smallsize" MaxLength="100"></asp:TextBox></TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD height="1%">&nbsp;</TD>
											<TD height="1%"></TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD colSpan="3" height="1%">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="3" height="1%">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3" height="1%">
												<asp:Label id="lblMessage" runat="server" Font-Bold="True" Width="75%" BackColor="#FFFF99">Since you selected Type 2 from "Training Type", you will need to complete a "Career Development Plan" in the next step following the completion of this page.</asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BORDER-TOP: silver thin solid" height="1%">&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:LinkButton id="lnkbtnCancel" runat="server" CausesValidation="False">Cancel</asp:LinkButton>&nbsp;&nbsp;
									<asp:LinkButton id="lnkbtnBack" runat="server" CausesValidation="False">Back</asp:LinkButton>&nbsp;&nbsp;
									<asp:LinkButton id="lnkbtnSaveAndStay" runat="server"> Save</asp:LinkButton>&nbsp;&nbsp;
									<asp:LinkButton id="lnkbtnSaveAndNext" runat="server" CausesValidation="False"> Next</asp:LinkButton></TD>
							</TR>
						</TABLE>
					</form>
					<SCRIPT>document.focus()</SCRIPT>
				</td>
			</tr>
			<tr vAlign="top" height="1%">
				<td align="left" width="100%"><asp:label id="LblTemplateFooter" runat="server"></asp:label></td>
			</tr>
		</table>
	</body>
</HTML>
