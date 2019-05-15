
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="TrainingVendorInfo.aspx.cs" AutoEventWireup="false" Inherits="Training_Source.TrainingVendorInfo" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Vendor Information</title>
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
			
			var changed;
			function MarkChanged()
			{
			  changed = true;  
			}
			
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
			
		    var name = null;
		    function Message(msg,btnOk,btnCancel)
		    {
		        if (window.document.getElementById(btnOk) == null)
		        {
		          window.setTimeout("Message(msg,btnOk,btnCancel)",500);
		        }
		        if (name != null)
		          return;
				name = confirm(msg);
				if (name==true)
				{
					window.document.getElementById(btnOk).click();									
				}
				else
				{
					tourl = document.getElementById(btnCancel).value;
					window.location.href=tourl;
				}				
		    }
		    
			function RemainingLetters()
			{
			   currentStr = document.getElementById('txtDescribtion').value;
			   currentLength = currentStr.length;			   
			   document.getElementById('txtRemaining').value=4000-currentLength;
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
			
			function SavedMessage()
			{
			    alert('Data Saved Successfully');
			    document.location.replace('TrainingVendorInfo.aspx');
			}
			
			function DisableSaveButton()
			{
			    eval(document.getElementById('htmbtnSave')).Disabled=true;
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
			<TR vAlign="top" height="1%">
				<TD></TD>
				<TD></TD>
			<TR>
				<TD width="10">&nbsp;</TD>
				<TD><asp:label id="LblTemplateHeader2" runat="server"></asp:label></TD>
				</TR>
			<TR vAlign="top" height="98%">
				<TD vAlign="top"></TD>
				<TD vAlign="top">
					<form id="Form1" method="post" runat="server">
						<TABLE class="fontsmall" id="Table1" height="95%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" colSpan="2" height="10%">
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
										<TR>
											<TD><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD width="220"><asp:label id="Label28" runat="server" Font-Bold="True">Remaining Budget For: </asp:label><asp:dropdownlist id="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall"></asp:dropdownlist></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label>
                                                <asp:HiddenField ID="hidCommand" runat="server" />
                                            </TD>
										</TR>
										<TR>
											<TD>&nbsp;</TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="790" border="0">
										<TR>
											<TD colSpan="2"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="fontsmall" DisplayMode="List"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:label id="lbl_fldTrainingVendor" runat="server" CssClass="fontsmall">Instruction</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="2"></TD>
										</TR>
										<TR>
											<TD width="395">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="395" border="0">
													<TR>
														<TD width="150"><asp:label id="lblrainingEventCode" runat="server" CssClass="fontsmall" AssociatedControlID="txtCourseCode"
																ToolTip="Learning Event Code">Training Event Code</asp:label></TD>
														<TD><asp:label id="req16" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtCourseCode" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="20"></asp:textbox></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblTrainingEvent" runat="server" CssClass="fontsmall" AssociatedControlID="txtCourseTitle"
																ToolTip="Training Title">Training Event Title</asp:label></TD>
														<TD><asp:label id="req8" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtCourseTitle" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="50"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtCourseTitle" ErrorMessage="Event Title Required Information"></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="Label5" runat="server" Font-Bold="True" CssClass="fontsmall" Font-Underline="True">Vendor</asp:label></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblVendorName" runat="server" CssClass="fontsmall" AssociatedControlID="txtVedorName"
																ToolTip="Vendor Name">Name</asp:label></TD>
														<TD><asp:label id="Label1" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtVedorName" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="50"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtVedorName" ErrorMessage="Vendor Name Required Information"></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblVendorContact" runat="server" CssClass="fontsmall" AssociatedControlID="txtVendorContact"
																ToolTip="Vendor Contact">Contact</asp:label></TD>
														<TD><asp:label id="Label43" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtVendorContact" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="50"></asp:textbox></TD>
													</TR>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCountry" runat="server" CssClass="fontsmall" Text="Country"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label>
                                                            <asp:dropdownlist id="ddlContries" runat="server" Width="220px" CssClass="Input_Control_Small" AutoPostBack="True" OnSelectedIndexChanged="ddlContries_SelectedIndexChanged">
                                                            </asp:DropDownList></td>
                                                    </tr>
													<TR>
														<TD><asp:label id="lblVendorPhoneFax" runat="server" CssClass="fontsmall" AssociatedControlID="txtPhoneNumber"
																ToolTip="Vendor Phone Number and Fax Number">Telephone & Fax</asp:label><br />
                                                            <asp:Label ID="lblPhoneFormat" runat="server" Text='<font face="Arial" size="1">(###) ###-####</font>'></asp:Label></TD>
														<TD>
															<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="230" border="0">
																<TR>
																	<TD width="110"><asp:label id="Label2" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox  id="txtPhoneNumber"
																			onblur="reset__(this)" runat="server" Width="100px" CssClass="Input_Control_Small" MaxLength="14"></asp:textbox></TD>
																	<TD width="10"></TD>
																	<TD width="110"><asp:label id="Label37" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox  id="txtFaxNumber"
																			onblur="reset__(this)" runat="server" Width="100px" CssClass="Input_Control_Small" MaxLength="14"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtFaxNumber" ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\b\d{3}-\d{4}"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Required Information"></asp:requiredfieldvalidator>
															<asp:requiredfieldvalidator id="Requiredfieldvalidator11" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtFaxNumber" ErrorMessage="Fax Required Information"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\b\d{3}-\d{4}"></asp:regularexpressionvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblAddress1" runat="server" CssClass="fontsmall" AssociatedControlID="txtAddressLine1"
																ToolTip="Vendor Address Line 1">Address Line 1</asp:label></TD>
														<TD><asp:label id="Label38" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtAddressLine1" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="30"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtAddressLine1" ErrorMessage="Address Line 1 Required Information"></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblAddress2" runat="server" CssClass="fontsmall" AssociatedControlID="txtAddressLine2"
																ToolTip="Vendor Address Line 2">Address Line 2</asp:label></TD>
														<TD><asp:label id="Label44" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtAddressLine2" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="30"></asp:textbox></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblCityState" runat="server" CssClass="fontsmall" AssociatedControlID="txtCity"
																ToolTip="Vendor City / State">City / State</asp:label></TD>
														<TD>
															<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="230" border="0">
																<TR>
																	<TD width="110"><asp:label id="Label39" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtCity" onblur="reset__(this)" runat="server" Width="100px" CssClass="Input_Control_Small"
																			MaxLength="20"></asp:textbox></TD>
																	<TD></TD>
																	<TD style="width: 115px"><asp:label id="req100" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:Label
                                                                            ID="req102" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:dropdownlist id="ddlStates" runat="server" Width="105px" CssClass="Input_Control_Small">
                                                                            </asp:DropDownList>
                                                                        <asp:TextBox ID="txtProvince" runat="server" CssClass="input_control_small" Width="105px"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtCity" ErrorMessage="City Required Information"></asp:requiredfieldvalidator>
                                                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator13" runat="server" ControlToValidate="ddlStates"
                                                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="State Required Information"
                                                                InitialValue="x"></asp:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblZipCode" runat="server" CssClass="fontsmall" AssociatedControlID="txtZipCode"
																ToolTip="Vendor Zip Code">Zip Code</asp:label></TD>
														<TD><asp:label id="req101" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtZipCode" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="10"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtZipCode" ErrorMessage="Zip Required Information"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtZipCode" ErrorMessage="Invalid Zipcode" ValidationExpression="\d{5}(-\d{4})?"></asp:regularexpressionvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblWebSite" runat="server" CssClass="fontsmall" AssociatedControlID="txtWebSite"
																ToolTip="Vendor Web Site">Web Site</asp:label></TD>
														<TD><asp:label id="Label45" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtWebSite" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="100"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtWebSite" ErrorMessage="Invalid Web URL (http(s)://www.basusa.com)" ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:regularexpressionvalidator></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD>
															<asp:label id="lblEnail" runat="server" CssClass="fontsmall" AssociatedControlID="txtEmail"
																ToolTip="Vendor Email">Email</asp:label></TD>
														<TD>
															<asp:label id="Label10" runat="server" ForeColor="Maroon" CssClass="fontsmall">| </asp:label>
															<asp:textbox id="txtEmail" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
																Width="220px" MaxLength="255" ToolTip="Vendor Email"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD>
                                                            &nbsp;<asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" CssClass="fontsmall" ErrorMessage="Invalid Email"
																ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></TD>
													</TR>
												</TABLE>
											</TD>
											<TD width="395" valign="top">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="395" border="0">
													<TR>
														<TD height="83"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD colspan="2">
															<asp:checkbox id="cbSameAddress" runat="server" AutoPostBack="True" CssClass="fontsmall" ToolTip="Check this box if the vendor address is the same as the location of training"></asp:checkbox>
                                                            <asp:Label ID="Label6" runat="server" CssClass="fontsmall" Font-Bold="True" Font-Underline="True">Location of Training Site </asp:Label>
                                                            <asp:Label ID="Label52" runat="server" Font-Bold="True"
                                                                Font-Underline="True"><b><font face="Arial" size="1">(if same as vendor, check box)</font></b></asp:Label>
                                                        </TD>
													</TR>
													<TR>
														<TD>
                                                            <asp:Label ID="lblTrainingCountry" runat="server" CssClass="fontsmall" Text="Country"></asp:Label></TD>
														<TD>
                                                            <asp:Label ID="Label7" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:dropdownlist id="ddlTrainingContries" runat="server" Width="220px" CssClass="Input_Control_Small" AutoPostBack="True" OnSelectedIndexChanged="ddlTrainingContries_SelectedIndexChanged">
                                                            </asp:DropDownList></TD>
													</TR>
                                                    <tr>
                                                        <td>
                                                            <asp:label id="lblLearningAddress1" runat="server" CssClass="fontsmall" AssociatedControlID="txtLearningAddress1">Address Line 1</asp:label></td>
                                                        <td>
                                                            <asp:Label ID="req103" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:textbox id="txtLearningAddress1" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="30"></asp:textbox></td>
                                                    </tr>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="Requiredfieldvalidator10" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtLearningAddress1" ErrorMessage="Address Line 1 Required Information"></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblLearningAddress2" runat="server" CssClass="fontsmall" AssociatedControlID="txtLearningAddress2">Address Line 2</asp:label></TD>
														<TD><asp:label id="Label19" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtLearningAddress2" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="30"></asp:textbox></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblLearningCityState" runat="server" CssClass="fontsmall" AssociatedControlID="txtLearningCity">City / State</asp:label></TD>
														<TD>
															<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="230" border="0">
																<TR>
																	<TD width="110"><asp:label id="Label17" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtLearningCity" onblur="reset__(this)" runat="server" Width="100px" CssClass="Input_Control_Small"
																			MaxLength="20"></asp:textbox></TD>
																	<TD></TD>
																	<TD style="width: 114px"><asp:label id="req105" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label>
																	<asp:Label ID="req104" runat="server" CssClass="fontsmall" ForeColor="White" Visible="False">|</asp:Label>
                                                                    <asp:dropdownlist id="ddlLearningState" runat="server" Width="105px" CssClass="Input_Control_Small"></asp:dropdownlist>
                                                                    <asp:TextBox ID="txtLearningProvince" runat="server" CssClass="input_control_small" Width="105px" Visible="False"></asp:TextBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="Requiredfieldvalidator9" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtLearningCity" ErrorMessage="City Required Information"></asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD><asp:label id="lblLearningZipCode" runat="server" CssClass="fontsmall" AssociatedControlID="txtLearningZipCode">Zip Code</asp:label></TD>
														<TD><asp:label id="req106" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtLearningZipCode" onblur="reset__(this)" runat="server" Width="220px" CssClass="Input_Control_Small"
																MaxLength="10"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtLearningZipCode" ErrorMessage="Zip Required Information"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" CssClass="fontsmall" Display="Dynamic"
																ControlToValidate="txtLearningZipCode" ErrorMessage="Invalid Zipcode" ValidationExpression="\d{5}(-\d{4})?"></asp:regularexpressionvalidator></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD></TD>
													</TR>
												</TABLE>
                                                </TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top" width="1%"></TD>
							</TR>
							<TR>
								<TD vAlign="top" height="1">
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="100"><asp:label id="lblPurposeofTraining" runat="server" CssClass="fontsmall" AssociatedControlID="txtDescribtion"
													ToolTip="Purpose of Training">Purpose of Training</asp:label><asp:label id="Label42" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label></TD>
											<TD vAlign="top" width="500"><asp:textbox id="txtDescribtion" onkeyup="RemainingLetters();DisableNavigation()" runat="server"
													Width="500px" CssClass="Input_Control_Small" Height="70px" MaxLength="4000" TextMode="MultiLine"></asp:textbox></TD>
											<TD vAlign="top"><asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtDescribtion" ErrorMessage="Purpose of Training Required Information"></asp:requiredfieldvalidator><asp:label id="Label26" runat="server" CssClass="fontsmall">Maximum 4000 Character</asp:label><asp:label id="Label27" runat="server" CssClass="fontsmall">Remaining</asp:label><asp:textbox id="txtRemaining" runat="server" Width="40px" CssClass="fontsmall" BorderColor="White"
													BorderStyle="None">4000</asp:textbox></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="785" border="0">
													<TR>
														<TD colSpan="2"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="40"><asp:label id="lblColor" runat="server" Height="18px" ForeColor="Cyan" BorderColor="Black"
																BorderStyle="Solid" Visible="False" BorderWidth="1px" BackColor="Cyan">Label</asp:label></TD>
														<TD><asp:label id="lblInfo" runat="server" Visible="False">Fields highlighted with cyan color, denote key fields. If any key field is modified, this Application will be reset to Pending Approval</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top" width="1%" height="1"></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="1%">
									<TABLE class="fontsmall" id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" width="300"><asp:button id="btnHome" runat="server" Width="75px" CssClass="fontsmall" ToolTip="Rrturn to select application"
													CausesValidation="False" Text="Home"></asp:button>&nbsp;&nbsp;
												<asp:button id="btnBack" runat="server" Width="75px" CssClass="fontsmall" ToolTip="Back to previous page"
													CausesValidation="False" Text="Back"></asp:button>&nbsp;&nbsp;
												<asp:button id="btnNext" runat="server" Width="75px" CssClass="fontsmall" ToolTip="GoTo next page"
													CausesValidation="False" Text="Next"></asp:button></TD>
											<TD><input id="htmbtnSave" runat="server" class="fontsmall" style="width: 75px"
                                                        type="button" value="Save" onclick="DoCommand(this,'DoSave')"/>&nbsp;
												<asp:button id="btnReset" runat="server" Width="200px" CssClass="fontsmall" ToolTip="Reset Data"
													CausesValidation="False" Text="Reset Current Screen Data"></asp:button><asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
									<input id="doSave" type="hidden" name="doSave" runat="server">
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
