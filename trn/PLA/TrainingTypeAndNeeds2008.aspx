<%@ Page language="c#" Codebehind="TrainingTypeAndNeeds2008.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.TrainingTypeAndNeeds2008" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Training Types & Needs</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="-1"> 
		<script src="/js/dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
			function CheckSave(url_)
			{
				var chk = confirm("The data was changed. Do you wish to save the data first? If Yes click Ok otherwise click Cancel")
				if (!chk)
					document.location.href=url_;
				else
				{
					document.Form1.doSave.value=url_;
					__doPostBack('','');
				}

			}
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"><cc1:ultimatemenu id="UltimateMenu1" runat="server"></cc1:ultimatemenu><asp:label id="lblWizardError" runat="server" ForeColor="Maroon" CssClass="fontsmall" Font-Bold="True"></asp:label></TD>
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
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top">
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD width="570"><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label><INPUT id="doSave" type="hidden" name="doSave" runat="server"></TD>
										</TR>
										<TR>
											<TD width="220"><asp:label id="Label8" runat="server" Font-Bold="True">Remaining Budget For: </asp:label><asp:dropdownlist id="ddlBudgetYear" runat="server" CssClass="fontsmall" AutoPostBack="True" Width="60px"></asp:dropdownlist></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label>
                                                <asp:HiddenField ID="hidCommand" runat="server" />
                                            </TD>
										</TR>
										<TR>
											<TD width="220">&nbsp;</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:label id="lblMandatoryOnly" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></TD>
										</TR>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
									</TABLE>
									</TD>
							</TR>
                            <tr>
                                <td valign="top">
									<asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="List" CssClass="fontsmall"></asp:validationsummary>
                                </td>
                            </tr>
							<TR>
								<TD vAlign="top"><asp:panel id="pnlData" runat="server">
										<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="3" height="1%">
													<asp:label id="lbl_fldTrainingTypeNeeds" runat="server" CssClass="fontsmall">Instruction</asp:label>
                                                    &nbsp;&nbsp;
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="SF-182 _2_ _3_ _4_.pdf"
                                                        Target="_blank" ToolTip="Click this link for help">(Help)</asp:HyperLink>
													<asp:label id="lblScript" runat="server" CssClass="fontsmall"></asp:label></TD>
											</TR>
											<TR>
												<TD colSpan="3" height="1%">
													<asp:label id="lblRequiredSymbol" runat="server" CssClass="fontsmall">The <font color="#800000">
															|</font> symbol before a data entry field indicates required data.</asp:label></TD>
											</TR>
											<TR>
												<TD width="150" height="1%">
													<asp:label id="lblDepartmentID" runat="server" CssClass="fontsmall" ToolTip="Label for Department ID#"
														AssociatedControlID="txtDepartmentID">Department ID#</asp:label></TD>
												<TD width="640" colSpan="2" height="1%">
													<asp:label id="Label25" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtDepartmentID" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" MaxLength="4"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Department ID# is required"
														ControlToValidate="txtDepartmentID"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 20px">
													<asp:label id="lblPositionLevel" runat="server" CssClass="fontsmall" ToolTip="Label For Position Level"
														AssociatedControlID="ddlPositionLevel">Position Level</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label9" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlPositionLevel" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ErrorMessage="Position Level is Required"
														ControlToValidate="ddlPositionLevel" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblNeedSpecialAccomodation" runat="server" CssClass="fontsmall" ToolTip="Label For Need Special Accomodation"
														AssociatedControlID="txtAccomodationDescription">Need Special Accomodation</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label27" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlAccomodation" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" AutoPostBack="True">
														<asp:ListItem Value="0">No</asp:ListItem>
														<asp:ListItem Value="1">Yes</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblAccomodationDescription" runat="server" CssClass="fontsmall" Visible="False"
														ToolTip="Label For Accomodation Description" AssociatedControlID="txtAccomodationDescription">Accomodation Description</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="req1" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtAccomodationDescription" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" MaxLength="100" Visible="False"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="fontsmall" Display="Dynamic"
														ErrorMessage="Accomodation Description is Required" ControlToValidate="txtAccomodationDescription"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblTypeofAppointmant" runat="server" CssClass="fontsmall" ToolTip="Type of Appointment"
														AssociatedControlID="ddlTypeofAppointment">Type of Appointment</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label10" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlTypeofAppointment" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" Display="Dynamic" ErrorMessage="Type of Appointment is Required"
														ControlToValidate="ddlTypeofAppointment" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblTrainingPurpose" runat="server" CssClass="fontsmall" ToolTip="Training Purpose Type"
														AssociatedControlID="ddlPurposeOfTraining">Training Purpose Type</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label18" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlPurposeOfTraining" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Purpose of Training is Required"
														ControlToValidate="ddlPurposeOfTraining" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblDeliveryTypeCode" runat="server" CssClass="fontsmall" ToolTip="Delivery Type Code"
														AssociatedControlID="ddlDelivaryTypeCode">Delivery Type Code</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label19" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlDelivaryTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator9" runat="server" Display="Dynamic" ErrorMessage="Delivery Type Code is Required"
														ControlToValidate="ddlDelivaryTypeCode" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblDesignationTypeCode" runat="server" CssClass="fontsmall" ToolTip="Designation Type Code"
														AssociatedControlID="ddlDesignationTypeCode">Designation Type Code</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label20" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlDesignationTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" AutoPostBack="True"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator11" runat="server" Display="Dynamic" ErrorMessage="Designation Type Code is Required"
														ControlToValidate="ddlDesignationTypeCode" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblDesinationOther" runat="server" CssClass="fontsmall" Visible="False" ToolTip="Training Designation Type Other"
														AssociatedControlID="txtDesignationOther">Designation Other</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="req2" runat="server" CssClass="fontsmall" ForeColor="Maroon" Visible="False">| </asp:label>
													<asp:textbox id="txtDesignationOther" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" MaxLength="100" Visible="False" ToolTip="Text Explaining the Designation"></asp:textbox>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" CssClass="fontsmall" Display="Dynamic"
														ErrorMessage="Designation Other is Required" ControlToValidate="txtDesignationOther" Visible="False"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblTrainingCredit" runat="server" CssClass="fontsmall" ToolTip="Training Designation Type Code"
														AssociatedControlID="txtTrainingCredit">Training Credit</asp:label></TD>
												<TD colSpan="2">
													<P>
														<asp:label id="Label7" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
														<asp:textbox id="txtTrainingCredit" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
															Width="196px" MaxLength="100" ToolTip="Text Explaining the Designation"></asp:textbox>
														<asp:CheckBox id="cbTrainingCredit" runat="server" AutoPostBack="True" Text="Not Applicable"></asp:CheckBox>
														<asp:requiredfieldvalidator id="Requiredfieldvalidator18" runat="server" CssClass="fontsmall" Display="Dynamic"
															ErrorMessage="Training Credit is Required" ControlToValidate="txtTrainingCredit"></asp:requiredfieldvalidator>
														<asp:RangeValidator id="RangeValidator1" runat="server" CssClass="fontsmall" Display="Dynamic" ErrorMessage="Training Credit Must be a Positive Number"
															ControlToValidate="txtTrainingCredit" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator></P>
												</TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblCreditTypeCode" runat="server" CssClass="fontsmall" ToolTip="Training Credit Type Code"
														AssociatedControlID="ddlCreditTypeCode">Credit Type Code</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="req3" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlCreditTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" AutoPostBack="True"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator12" runat="server" Display="Dynamic" ErrorMessage="Credit Type Code is Required"
														ControlToValidate="ddlCreditTypeCode" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblCreditTypeOther" runat="server" CssClass="fontsmall" Visible="False" ToolTip="Training Code Type Other"
														AssociatedControlID="txtCreditTypeOther">Credit Type Other</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="req4" runat="server" CssClass="fontsmall" ForeColor="Maroon" Visible="False">| </asp:label>
													<asp:textbox id="txtCreditTypeOther" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" MaxLength="100" Visible="False" ToolTip="Text Explaining the Designation"></asp:textbox>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" CssClass="fontsmall" Display="Dynamic"
														ErrorMessage="Credit Type Other is Required" ControlToValidate="txtCreditTypeOther" Visible="False"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 29px">
													<asp:label id="lblAccreditationIndicator" runat="server" CssClass="fontsmall" ToolTip="Is the Course Accredited "
														AssociatedControlID="ddlAccredetionIndicator">Accreditation Indicator</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label22" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlAccredetionIndicator" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator13" runat="server" Display="Dynamic" ErrorMessage="Accreditation Indicator is Required"
														ControlToValidate="ddlCreditTypeCode" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblSourceOfTraining" runat="server" CssClass="fontsmall" AssociatedControlID="ddlSourseTraining">Source of Training</asp:label></TD>
												<TD colSpan="2" height="1%">
													<asp:label id="Label23" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:dropdownlist id="ddlSourseTraining" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px"></asp:dropdownlist>
													<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="Source of Training is Required"
														ControlToValidate="ddlSourseTraining" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblEducationLevel" runat="server" CssClass="fontsmall" ToolTip="Education Level"
														AssociatedControlID="txtEducationLevel">Education Level</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label36" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtEducationLevel" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" ReadOnly="True"></asp:textbox>
													<asp:button id="btnSelectEducationLevel" runat="server" CssClass="fontsmall" Width="50px" ToolTip="Select Education Level"
														Text="Select" CausesValidation="False"></asp:button>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator16" runat="server" Display="Dynamic" ErrorMessage="Edutation Level is Required"
														ControlToValidate="txtEducationLevel" InitialValue="xx"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblTrainingSubTypeCode" runat="server" CssClass="fontsmall" ToolTip="Training Sub-Type Code"
														AssociatedControlID="txtTrainingSubTypeCode">Training Sub-Type Code</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label31" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtTrainingSubTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" ReadOnly="True"></asp:textbox>
													<asp:button id="btnTrainingTypeCode" runat="server" CssClass="fontsmall" Width="50px" ToolTip="Select Training Sub-Type Code"
														Text="Select" CausesValidation="False"></asp:button>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator15" runat="server" Display="Dynamic" ErrorMessage="Training Sub-Type Code is Required"
														ControlToValidate="txtTrainingSubTypeCode"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblTrainingTypeCode" runat="server" CssClass="fontsmall" ToolTip="Training Type Code"
														AssociatedControlID="txtTrainingTypeCode">Training Type Code</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label32" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtTrainingTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" ReadOnly="True"></asp:textbox>
													<asp:button id="btnTrainingTypeCode2" runat="server" CssClass="fontsmall" Width="50px" ToolTip="Select Training Type Code"
														Text="Select" CausesValidation="False"></asp:button>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator14" runat="server" Display="Dynamic" ErrorMessage="Training Type Code is Required"
														ControlToValidate="txtTrainingTypeCode"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblTypeOfDevelopment" runat="server" CssClass="fontsmall" ToolTip="Type of Development"
														AssociatedControlID="txtTypeOfDevelopmentSummary">Type of Development</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label39" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtTypeOfDevelopmentSummary" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" ReadOnly="True"></asp:textbox>
													<asp:button id="btnTypeOfDevelopment" runat="server" CssClass="fontsmall" Width="50px" ToolTip="Select Type of Development"
														Text="Select" CausesValidation="False"></asp:button>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator17" runat="server" Display="Dynamic" ErrorMessage="Type of Development is Required"
														ControlToValidate="txtTypeOfDevelopmentSummary"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD>
													<asp:label id="lblProgramCode" runat="server" CssClass="fontsmall" ToolTip="Program Code">Program Code</asp:label></TD>
												<TD colSpan="2">
													<asp:label id="Label26" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
													<asp:textbox id="txtProgramCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
														Width="300px" ReadOnly="True">67200</asp:textbox>
													<asp:button id="btnSelect" runat="server" CssClass="fontsmall" Width="50px" ToolTip="Select Program Code"
														Text="Select" CausesValidation="False" Visible="False"></asp:button>
													<asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" Display="Dynamic" ErrorMessage="Program Code is Required"
														ControlToValidate="txtProgramCode" Visible="False"></asp:requiredfieldvalidator></TD>
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
												<TD vAlign="top" width="300">
													<asp:Button id="btnHome" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Rrturn to select application"
														Text="Home" CausesValidation="False"></asp:Button>
													<asp:Button id="btnBack" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Back to previous page"
														Text="Back" CausesValidation="False"></asp:Button>
													<asp:button id="btnNext" runat="server" CssClass="fontsmall" Width="75px" ToolTip="GoTo next page"
														Text="Next" CausesValidation="False"></asp:button></TD>
												<TD>
                                                    <input id="htmbtnSave" runat="server" class="fontsmall" onclick="DoCommand(this,'DoSave')" style="width: 75px"
                                                        type="button" value="Save" />
													<asp:button id="btnReset" runat="server" CssClass="fontsmall" Width="200px" ToolTip="Reset Data"
														Text="Reset Current Screen Data" CausesValidation="False"></asp:button></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlTrainingTypeCode" runat="server" Visible="False">
										<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center">
													<asp:label id="Label33" runat="server" Font-Bold="True" CssClass="fontsmall">Training Type Code/Training Sub-Type Code</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 20px" align="right">
													<asp:Button id="btnCloseTrainingType1" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Training Type Code/Training Sub-Type Code"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
											<TR>
												<TD>
													<asp:DataGrid id="dgTrainingTypeCode" runat="server" CssClass="fontsmall" Visible="False" AutoGenerateColumns="False">
														<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
														<ItemStyle BackColor="White"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Training Code"></asp:TemplateColumn>
															<asp:BoundColumn DataField="sub_code_long_description" HeaderText="Training Description"></asp:BoundColumn>
														</Columns>
													</asp:DataGrid></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 15px" align="right">
													<asp:Button id="btnCloseTrainingType2" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Training Type Code/Training Sub-Type Code"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlEducationLevel" runat="server" Visible="False">
										<TABLE class="fontsmall" id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center">
													<asp:label id="Label34" runat="server" Font-Bold="True" CssClass="fontsmall">Education Level</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 20px" align="right">
													<asp:Button id="btnEducationLevelClose1" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Education Level"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
											<TR>
												<TD>
													<asp:DataGrid id="dgEducationLevel" runat="server" CssClass="fontsmall" Visible="False" AutoGenerateColumns="False">
														<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
														<ItemStyle BackColor="White"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Education Level"></asp:TemplateColumn>
															<asp:BoundColumn DataField="long_description" HeaderText="Description"></asp:BoundColumn>
														</Columns>
													</asp:DataGrid></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 15px" align="right">
													<asp:Button id="btnEducationLevelClose2" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Education Level"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="pnlProgramCode" runat="server" Visible="False">
										<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center">
													<asp:label id="Label29" runat="server" Font-Bold="True" CssClass="fontsmall">Program Codes</asp:label></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:Button id="btnClose1" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Program Code Page"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
											<TR>
												<TD>
													<asp:RadioButtonList id="optProgramCode" runat="server" CssClass="fontsmall" AutoPostBack="True" RepeatColumns="3"></asp:RadioButtonList></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 15px" align="right">
													<asp:Button id="bntnClose2" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Program Code Page"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</asp:panel>
									<asp:panel id="pnlDevelopmentType" runat="server" Visible="False" ToolTip="Close Type of Development">
										<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="center">
													<asp:label id="Label17" runat="server" Font-Bold="True" CssClass="fontsmall">Type of Development</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 22px" align="right">
													<asp:Button id="btnDevClose0" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Type of Development"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 22px" align="left">
													<asp:Label id="lblTypeOfDevelopmentInstuction" runat="server">Click on the Close Button to accept changes.</asp:Label></TD>
											</TR>
											<TR>
												<TD>
													<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="790" border="0">
														<TR>
															<TD width="125">
																<asp:label id="Label37" runat="server" CssClass="fontsmall">Type of Development</asp:label></TD>
															<TD width="670">
																<asp:checkboxlist id="chklstTypeofDev" runat="server" CssClass="Input_Control_Small" RepeatColumns="4"
																	BorderWidth="1px" BorderStyle="Solid" BorderColor="DimGray"></asp:checkboxlist></TD>
														</TR>
														<TR>
															<TD>&nbsp;</TD>
															<TD></TD>
														</TR>
														<TR>
															<TD width="150">
																<asp:label id="Label38" runat="server" CssClass="fontsmall">Type of Development (other)</asp:label></TD>
															<TD>
																<asp:textbox id="txtTypeofDevelopmentOthers" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
																	Width="300px" MaxLength="100"></asp:textbox></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD>
																<asp:label id="lblOtherTextError" runat="server" CssClass="fontsmall" ForeColor="Red"> Type of Development (Other) is  Required</asp:label></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD>
																<asp:Button id="btnResetChanges" runat="server" ToolTip="Reset Type of Development Selection"
																	Text="Reset Type of Development Selection"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 15px" align="right">
													<asp:Button id="btnDevClose" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Reset Type of Type of Development"
														Text="Close"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
