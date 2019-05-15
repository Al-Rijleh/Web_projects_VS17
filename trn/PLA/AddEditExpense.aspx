<%@ Page language="c#" Codebehind="AddEditExpense.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.AddEditExpense" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add/Edit Expenses</title>
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
		  function SaveClick(btn)
		  {
				//btn.disabled=true;
				btn.style.visibility='hidden';
				document.getElementById('dvSaving').style.visibility='visible';
				document.Form1.doSave.value="Save";
					__doPostBack('','');
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
		  function RemainingLetters()
			{
			   currentStr = document.getElementById('txtDescription').value;
			   currentLength = currentStr.length;			   
			   document.getElementById('txtRemaining').value=4000-currentLength;
			}
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" >
		<TABLE id="Table" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
			cellSpacing="0" cellPadding="0" width="795" border="0">
			<TR>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
				<TD background="/karama/Images/WinSubTab.gif"></TD>
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
								<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top" height="10%">
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True"> Training Requested</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label><input id="doSave" type="hidden" name="doSave" runat="server"></TD>
										</TR>
										<TR>
											<TD width="220"><asp:label id="Label15" runat="server" Font-Bold="True">Remaining Budget For: </asp:label><asp:dropdownlist id="ddlBudgetYear" runat="server" Width="60px" CssClass="fontsmall" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="2">&nbsp;
												<asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="List" Height="1px"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:label id="lblWarning" runat="server" Visible="False" BackColor="Cyan"><b>Waring:</b> Saving this expense will cause your Application to be reset to Pending Approval</asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="2"><asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD width="20%" colSpan="2" height="1%"><asp:label id="lblRequiredSymbol" runat="server" CssClass="fontsmall">The <font color="#800000">
														|</font> symbol before a data entry field indicates required data.</asp:label></TD>
										</TR>
										<TR>
											<TD width="25%"><asp:label id="lblExpenseType" runat="server" CssClass="fontsmall" ToolTip="Please select the Expense Category Type from the Dropdown field. If you cannot see the category type, please select other.">Expense Type</asp:label></TD>
											<TD><asp:label id="req1" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:dropdownlist id="ddlExpenseType" onblur="reset__(this)" runat="server" Width="300px" CssClass="Input_Control_Small"
													AutoPostBack="True"></asp:dropdownlist><asp:textbox id="txtExpenseType" onblur="reset__(this)" runat="server" Width="300px" CssClass="fontsmall"
													Visible="False" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="ddlExpenseType" ErrorMessage="Expense Type is Required Field" InitialValue=" "></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%"><asp:label id="lblExpenseName" runat="server" CssClass="fontsmall" Visible="False">Expense Name</asp:label></TD>
											<TD height="1%"><asp:label id="req2" runat="server" CssClass="fontsmall" Visible="False" ForeColor="White">| </asp:label>
                                                <asp:textbox id="txtExpenseName" onblur="reset__(this)" runat="server" 
                                                    Width="300px" CssClass="Input_Control_Small"
													Visible="False" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 35px" width="20%" height="35"><asp:label id="lblEstimatedAmount" runat="server" CssClass="fontsmall">Estimate Amount</asp:label></TD>
											<TD style="HEIGHT: 35px" height="35"><asp:label id="req3" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtAmount" onblur="reset__(this)" runat="server" Width="300px" CssClass="Input_Control_Small"></asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" CssClass="fontsmall" Display="Dynamic" ControlToValidate="txtAmount"
													ErrorMessage="Numeric Value Required" MaximumValue="1000000" MinimumValue="0" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtAmount" ErrorMessage="Estimated Amount is Required" InitialValue=" "></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD width="20%" height="1%"></TD>
											<TD height="1%"></TD>
										</TR>
										<TR>
											<TD style="height: 1%"><asp:label id="Label31" runat="server" Font-Bold="True" CssClass="fontsmall" Font-Underline="True">Vendor</asp:label></TD>
											<TD style="height: 1%"><asp:radiobuttonlist id="optlstVendor" runat="server" Width="550px" CssClass="Input_Radio_Button_Small"
													AutoPostBack="True" RepeatDirection="Horizontal">
													<asp:ListItem Value="1" Selected="True">Pay To Vendor</asp:ListItem>
													<asp:ListItem Value="2">Pay to Other than Vendor</asp:ListItem>
													<asp:ListItem Value="3">Pay by ETV</asp:ListItem>
													<asp:ListItem Value="4">Employee Contribution</asp:ListItem>
												</asp:radiobuttonlist><asp:radiobutton id="rbVendor" runat="server" CssClass="fontsmall" Visible="False" Checked="True"></asp:radiobutton></TD>
										</TR>
										<TR id="r1" runat="server">
											<TD style="height: 1%"><asp:label id="lblVendorName" runat="server" CssClass="fontsmall">Name</asp:label></TD>
											<TD style="height: 1%"><asp:label id="req4" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtVedorName" onblur="reset__(this)" runat="server" Width="300px" CssClass="Input_Control_Small"
													MaxLength="50"></asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtVedorName" ErrorMessage="Vendor Name Required "></asp:requiredfieldvalidator></TD>
										</TR>
										<TR id="r2" runat="server">
											<TD height="1%"><asp:label id="lblVendorContact" runat="server" CssClass="fontsmall">Contact</asp:label></TD>
											<TD height="1%"><asp:label id="req5" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtVendorContact" onblur="reset__(this)" runat="server" Width="300px" CssClass="Input_Control_Small"
													MaxLength="50"></asp:textbox></TD>
										</TR>
                                        <tr id="r3" runat="server">
                                            <td height="1%">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="fontsmall" Text="Country"></asp:Label></td>
                                            <td height="1%">
                                                <asp:Label ID="Label1" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label>
                                                <asp:DropDownList ID="ddlContries" runat="server" AutoPostBack="True" CssClass="Input_Control_Small"
                                                    OnSelectedIndexChanged="ddlContries_SelectedIndexChanged" Width="300px">
                                                </asp:DropDownList></td>
                                        </tr>
										<TR id="r4" runat="server">
											<TD height="1%"><asp:label id="lblVedorTelephoneandFax" runat="server" CssClass="fontsmall">Telephone & Fax</asp:label>
                                                <asp:Label ID="lblPhoneFormat" runat="server" Text='<font face="Arial" size="1">(###) ###-####</font>'></asp:Label></TD>
											<TD height="1%"><asp:label id="req6" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox  id="txtPhoneNumber"
													onblur="reset__(this)" runat="server" Width="149px" CssClass="Input_Control_Small" MaxLength="14"></asp:textbox><asp:textbox  id="txtFaxNumber"
													onblur="reset__(this)" runat="server" Width="149px" CssClass="Input_Control_Small" MaxLength="14"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number Required"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\b\d{3}-\d{4}"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtFaxNumber" ErrorMessage="Invalid Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\b\d{3}-\d{4}"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR id="r5" runat="server">
											<TD height="1%"><asp:label id="lblAddressLine1AndAddressLine2" runat="server" CssClass="fontsmall">Address Line 1 / Line 2</asp:label></TD>
											<TD height="1%"><asp:label id="req7" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtAddressLine1" onblur="reset__(this)" runat="server" Width="149px" CssClass="Input_Control_Small"
													MaxLength="30"></asp:textbox><asp:textbox id="txtAddressLine2" onblur="reset__(this)" runat="server" Width="149px" CssClass="Input_Control_Small"
													MaxLength="30"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtAddressLine1" ErrorMessage="Address Line 1 Required"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR id="r6" runat="server">
											<TD height="1%">
                                                <asp:Label ID="lblCityState" runat="server" Text="City/State/Zip"></asp:Label></TD>
											<TD height="1%"><asp:label id="req8" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtCity" onblur="reset__(this)" runat="server" Width="94px" CssClass="Input_Control_Small"
													MaxLength="20"></asp:textbox>&nbsp;
												<asp:label id="Label20" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:dropdownlist id="ddlStates" onblur="reset__(this)" runat="server" Width="114px" CssClass="Input_Control_Small"></asp:dropdownlist><asp:textbox id="txtState" onblur="reset__(this)" runat="server" Width="116px" CssClass="Input_Control_Small"
													Visible="False" ReadOnly="True"></asp:textbox>&nbsp;
												<asp:label id="Label19" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:label><asp:textbox id="txtZipCode" onblur="reset__(this)" runat="server" Width="65px" CssClass="Input_Control_Small"
													MaxLength="10"></asp:textbox>&nbsp;<asp:TextBox ID="txtProvince" runat="server" CssClass="Input_Control_Small"
                                                        Width="116px"></asp:TextBox>
												<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtZipCode" ErrorMessage="Invalid Zipcode" ValidationExpression="\d{5}(-\d{4})?"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtCity" ErrorMessage="City Required"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="ddlStates" ErrorMessage="State Requied" InitialValue="x"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtZipCode" ErrorMessage="Zip Requied"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR id="r7" runat="server"> 
											<TD height="1%"><asp:label id="lblVendorEmail" runat="server" CssClass="fontsmall">e-mail</asp:label><asp:label id="Label25" runat="server" CssClass="fontsmall" Font-Size="XX-Small"> (info@myenrll.com)</asp:label></TD>
											<TD height="1%"><asp:label id="req9" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtemail" onblur="reset__(this)" runat="server" Width="300px" CssClass="Input_Control_Small"
													MaxLength="100"></asp:textbox>&nbsp;
												<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="fontsmall" Display="Dynamic"
													ControlToValidate="txtemail" ErrorMessage="Invalid e-mail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR id="r8" runat="server">
											<TD vAlign="top">
												<P><asp:label id="lblAdditionInformation" runat="server" CssClass="fontsmall">Additional Information</asp:label><BR>
													<BR>
													<asp:label id="lblTextLimit" runat="server" CssClass="fontsmall">Max 4000 Character</asp:label><BR>
													<asp:label id="Label27" runat="server">Remaining</asp:label>&nbsp;
													<asp:textbox id="txtRemaining" onblur="reset__(this)" runat="server" Width="40px" CssClass="fontsmall"
														BorderStyle="None" BorderColor="White">4000</asp:textbox></P>
											</TD>
											<TD vAlign="top"><asp:label id="req10" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:label><asp:textbox id="txtDescription" onblur="reset__(this)" onkeyup="RemainingLetters()" runat="server"
													Width="400px" CssClass="Input_Control_Small" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD vAlign="top" colSpan="2">&nbsp;</TD>
										</TR>
										<TR>
											<TD vAlign="top" colSpan="2">
												<TABLE class="fontsmall" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD colSpan="2"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="40" style="height: 38px"><asp:label id="lblColor" runat="server" Height="18px" Visible="False" BackColor="Cyan" ForeColor="Cyan"
																BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">Label</asp:label></TD>
														<TD style="height: 38px"><asp:label id="lblInfo" runat="server" CssClass="fontsmall" Visible="False">Fields highlighted with cyan color, denote key fields. If any key field is modified, this Application will be reset to Pending Approval</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top">&nbsp;</TD>
											<TD vAlign="top"></TD>
										</TR>
										<TR>
										    <TD vAlign="top">
										        <div id="dvSaving" style="visibility: hidden; float: right"><b><font face="Arial" color="#800000">Saving..</font></b></div>
										    </TD>
											<TD vAlign="top"><INPUT class="fontsmall" id="htmBtnSave" title="Save Entered Data" style="WIDTH: 75px" onclick="SaveClick(this)"
													type="button" value="Save" runat="server">
												<asp:button id="btnClose" runat="server" Width="75px" CssClass="fontsmall" Text="Cancel" CausesValidation="False"></asp:button><asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
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
