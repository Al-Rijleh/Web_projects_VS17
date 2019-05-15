<%@ Page language="c#" Codebehind="TrainingTypesAndNeeds.aspx.cs" AutoEventWireup="false" Inherits="Training_Source.TrainingTypesAndNeeds" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training Types & Needs</title>
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
		  function callPostBack()
          {
			    ob=document.getElementById("btnCausePostBack");
			    if (ob==null)
			      window.setTimeout("callPostBack()",200);
				ob.click();
          }
          
          function alertWait(elementToWaitFor,msg)
          {            
			    ob=document.getElementById(elementToWaitFor);
			    if (ob==null)
			      window.setTimeout("alertWait(elementToWaitFor,msg)",200);
			    alert(msg);
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
		  function popup(url1,height1,width1)
          {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
          } 
          
          function DisableNavigation()
		  {
			//	document.getElementById('pnlNav').disabled = true;
			//	document.getElementById('pnlAction').disabled = false;
	      }
	      function EnableNavigation()
			{
			//	document.getElementById('pnlNav').disabled = false;
			//	document.getElementById('pnlAction').disabled = true;			
			}
		    function CheckListLength(checkBoxListId)
		    {
		        objCtrl = document.getElementById(checkBoxListId);
				
				for (i=0; i<100;i++)	
				{
					objItem = document.getElementById(checkBoxListId + '_' + i);
					if(objItem == null)
					{
						return (i);
					}
				}
		    }
			function test(checkBoxListId)
			{
				objCtrl = document.getElementById(checkBoxListId);
				document.getElementById('txtSelectedDevelopments').value='';
				counter = CheckListLength(checkBoxListId);
				for (i=0; i<counter;i++)	
				{
					objItem = document.getElementById(checkBoxListId + '_' + i);
					if(objItem == null)
					{
						continue;
					}

					if (objItem.checked==true)
						document.getElementById('txtSelectedDevelopments').value='abc' ; 
				}			 
					
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif">
					<cc1:UltimateMenu id="UltimateMenu1" runat="server"></cc1:UltimateMenu>
					<asp:Label id="lblWizardError" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:Label></TD>
			</TR>
			<TR vAlign="top" height="1%">
				<TD></TD>
				<TD>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TD></TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="fontsmall" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%">
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD width="570"><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD width="220">
												<asp:Label id="Label8" runat="server" Font-Bold="True">Remaining Budget For: </asp:Label>
												<asp:DropDownList id="ddlBudgetYear" runat="server" Width="60px" CssClass="fontsmall" AutoPostBack="True"></asp:DropDownList></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:label id="lblMandatoryOnly" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></TD>
										</TR>
									</TABLE>
									<asp:validationsummary id="ValidationSummary1" runat="server" Height="1px" DisplayMode="List"></asp:validationsummary></TD>
							</TR>
							<TR>
								<TD vAlign="top" height="60%">
									<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="3" height="1%"><asp:label id="lbl_fldTrainingTypeNeeds" runat="server" CssClass="fontsmall">Instruction</asp:label></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%"><asp:label id="Label11" runat="server" CssClass="fontsmall">Department ID#</asp:label><asp:label id="Label10" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD colSpan="2" height="1%"><asp:textbox id="txtDepartmentID" onblur="reset__(this)" runat="server" MaxLength="4" CssClass="Input_Control_Small"
													Width="200px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%"></TD>
											<TD colSpan="2" height="1%">
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Department ID# is required"
													ControlToValidate="txtDepartmentID"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD width="20%"><asp:label id="lblProgramCode" runat="server" CssClass="fontsmall">Program Code</asp:label><asp:label id="lblStarProgramCode" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD colSpan="2">
												<asp:TextBox id="txtProgramCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
													ReadOnly="True" Width="200px"></asp:TextBox>&nbsp;
												<asp:Button id="btnSelect" runat="server" CssClass="fontsmall" Text="Select" CausesValidation="False"
													Width="50px"></asp:Button></TD>
										</TR>
										<TR>
											<TD width="20%"></TD>
											<TD colSpan="2">
												<asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" Display="Dynamic" ErrorMessage="Program Code is Required"
													ControlToValidate="txtProgramCode"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%"><asp:label id="Label15" runat="server" CssClass="fontsmall">Account #</asp:label><asp:label id="Label16" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD colSpan="2" height="1%">
												<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="1%"><asp:radiobuttonlist id="opnlstAccountNumber" onblur="reset__(this)" runat="server" Width="250px" CssClass="Input_Radio_Button_Small"
																RepeatDirection="Horizontal">
																<asp:ListItem Value="T">Yes</asp:ListItem>
																<asp:ListItem Value="F">No</asp:ListItem>
															</asp:radiobuttonlist></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD width="1%" colSpan="2">
															<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" Display="Dynamic" ErrorMessage="Account # is Required"
																ControlToValidate="opnlstAccountNumber"></asp:requiredfieldvalidator></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD><asp:label id="Label6" runat="server" CssClass="fontsmall">Source of Training</asp:label><asp:label id="Label14" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist id="ddlSourseTraining" onblur="reset__(this)" runat="server" Width="200px" CssClass="Input_Control_Small"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD colSpan="2">
												<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="Source of Training is Required"
													ControlToValidate="ddlSourseTraining" InitialValue="xx"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label5" runat="server" CssClass="fontsmall">Purpose of Training </asp:label><asp:label id="Label19" runat="server" ForeColor="Red">*</asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist id="ddlPurposeOfTraining" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
													AutoPostBack="True" Width="200px"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD colSpan="2">
												<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Purpose of Training is Required"
													ControlToValidate="ddlPurposeOfTraining" InitialValue="xx"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD height="1%"><asp:label id="Label7" runat="server" CssClass="fontsmall">Purpose of Training (other)</asp:label><asp:label id="lblReq" runat="server" Visible="False" ForeColor="Red">*</asp:label></TD>
											<TD colSpan="2" height="1%"><asp:textbox id="txtPurposeOfTainingOther" onblur="reset__(this)" runat="server" MaxLength="100"
													CssClass="Input_Control_Small" Width="200px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD height="1%"></TD>
											<TD colSpan="2" height="1%">
												<asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" Display="Dynamic" ErrorMessage="Purpose of Training (Others) is Required"
													ControlToValidate="txtPurposeOfTainingOther" Visible="False"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD vAlign="top" height="1%"><asp:label id="Label37" runat="server" CssClass="fontsmall">Type of Development</asp:label><BR>
												<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="You Must Select at Least one Item From Type of Development List"
													ControlToValidate="txtSelectedDevelopments" Display="Dynamic"></asp:requiredfieldvalidator></TD>
											<TD colSpan="2" height="1%"><asp:checkboxlist id="chklstTypeofDev" onclick="test('chklstTypeofDev')" runat="server" CssClass="fontsmall"
													BorderWidth="1px" BorderStyle="Solid" BorderColor="DimGray" RepeatColumns="4"></asp:checkboxlist>&nbsp;</TD>
										</TR>
										<TR>
											<TD vAlign="top" height="1%"><asp:label id="Label9" runat="server" CssClass="fontsmall">Type of Development (other)</asp:label></TD>
											<TD colSpan="2" height="1%"><asp:textbox id="txtTypeofDevelopmentOthers" onblur="reset__(this)" runat="server" MaxLength="100"
													CssClass="Input_Control_Small" Width="200px"></asp:textbox><asp:label id="lblOtherTextError" runat="server" ForeColor="Red"> Type of Development (Other) is  Required</asp:label></TD>
										</TR>
										<TR>
											<TD height="1%">&nbsp;</TD>
											<TD height="1%"></TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD colSpan="3" height="1%"><asp:label id="Label30" runat="server" ForeColor="Red">*</asp:label><asp:label id="Label29" runat="server">Denotes required Information</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="3" height="1%">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3" height="1%"></TD>
										</TR>
									</TABLE>
									<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="300"><asp:panel id="pnlNav" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:panel>
												<asp:Button id="btnHome" runat="server" CssClass="fontsmall" Width="75px" CausesValidation="False"
													Text="Home" ToolTip="Rrturn to select application"></asp:Button>
												<asp:Button id="btnBack" runat="server" CssClass="fontsmall" Width="75px" CausesValidation="False"
													Text="Back" ToolTip="Back to previous page"></asp:Button>
												<asp:Button id="btnNext" runat="server" CssClass="fontsmall" Width="75px" CausesValidation="False"
													Text="Next" ToolTip="GoTo next page"></asp:Button></TD>
											<TD><asp:panel id="pnlAction" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:panel>
												<asp:button id="btnSaveandStay" runat="server" CssClass="fontsmall" Width="75px" Text="Save"
													ToolTip="GoTo next page"></asp:button>
												<asp:button id="btnReset" runat="server" CssClass="fontsmall" Width="200px" CausesValidation="False"
													Text="Reset Current Screen Data" ToolTip="GoTo next page"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><asp:button id="btnSaveNext" runat="server" Text="btnSaveNext"></asp:button><asp:button id="btnSaveBack" runat="server" Text="btnSaveBack"></asp:button><asp:label id="lblScript" runat="server"></asp:label><asp:listbox id="lbTypeofDev" runat="server"></asp:listbox><asp:textbox id="txtSelectedDevelopments" onblur="reset__(this)" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="1%">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 2px" height="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD height="1%">&nbsp;</TD>
							</TR>
						</TABLE>
						&nbsp;
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
