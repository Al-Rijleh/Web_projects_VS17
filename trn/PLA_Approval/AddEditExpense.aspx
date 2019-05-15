<%@ Page language="c#" Codebehind="AddEditExpense.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.AddEditExpense" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add/Edit Expenses</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="-1"> 
		<script src="/js/dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
		<script src="/js/BAS_Utility.js" type="text/javascript"></script>
		<script>
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 5px; POSITION: absolute; TOP: 5px; border-right: silver thin solid; border-top: silver thin solid; border-left: silver thin solid; border-bottom: silver thin solid;"
				height="95%" cellSpacing="0" cellPadding="0" width="790" border="0">
				<TR>
					<TD style="BORDER-BOTTOM: silver thin solid" vAlign="top">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="150">
									<asp:label id="Label3" runat="server" Font-Bold="False" CssClass="fontsmall"> Training Requested</asp:label></TD>
								<TD>
									<asp:label id="lblCourseTitle" runat="server" Font-Bold="True" CssClass="fontsmall"></asp:label>
									<asp:Label id="lblScript" runat="server"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE class="fontsmall" id="Table6" cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD width="160" height="1%">&nbsp;</TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD width="160" height="16" style="HEIGHT: 16px">
									<asp:Label id="lblExpenseType" runat="server" ToolTip="Please select the Expense Category Type from the Dropdown field. If you cannot see the category type, please select other." CssClass="fontsmall">Expense Type</asp:Label></TD>
								<TD style="HEIGHT: 16px">
									<asp:DropDownList id="ddlExpenseType" runat="server" CssClass="input_control_small" Width="350px" AutoPostBack="True"
										Visible="False"></asp:DropDownList>
									<asp:TextBox id="txtExpenseType" runat="server" Width="350px" CssClass="input_control_small" ReadOnly="True"
										BackColor="Gainsboro"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="160" height="1%">
									<asp:Label id="lblExpenseName" runat="server" Visible="False" CssClass="fontsmall">Expense Name</asp:Label></TD>
								<TD height="1%">
									<asp:TextBox id="txtExpenseName" runat="server" CssClass="input_control_small" Width="350px" Visible="False"
										ReadOnly="True" BackColor="Gainsboro"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="160" height="1%"></TD>
								<TD height="1%"></TD>
							</TR>
							<TR>
								<TD style="height: 1%">
									<asp:label id="Label31" runat="server" Font-Bold="True" Font-Underline="True" CssClass="fontsmall">Vendor</asp:label></TD>
								<TD style="height: 1%"></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label22" runat="server" CssClass="fontsmall">Name</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtVedorName" runat="server" Width="350px" CssClass="input_control_small" MaxLength="50"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:Label id="Label21" runat="server" CssClass="fontsmall">Contact</asp:Label></TD>
								<TD height="1%">
									<asp:textbox id="txtVendorContact" runat="server" Width="350px" CssClass="input_control_small" MaxLength="50"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
							</TR>
                            <tr>
                                <td height="1%">
                                    <asp:Label ID="lblCountry" runat="server" CssClass="fontsmall" Text="Country"></asp:Label></td>
                                <td height="1%">
                                    <asp:DropDownList ID="ddlContries" runat="server" AutoPostBack="True" CssClass="Input_Control_Small"
                                        Enabled="False" Width="350px">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD height="1%">
									<asp:label id="Label6" runat="server" CssClass="fontsmall">Telephone & Fax</asp:label></TD>
								<TD height="1%">
									<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtPhoneNumber"
										runat="server" Width="171px" CssClass="input_control_small" MaxLength="14" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
									<asp:textbox onkeypress="javascript:return dFilter(event.keyCode, this, '(###) ###-####');" id="txtFaxNumber"
										runat="server" Width="171px" CssClass="input_control_small" MaxLength="14" ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label7" runat="server" CssClass="fontsmall">Address Line 1</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtAddressLine1" runat="server" Width="350px" CssClass="input_control_small" MaxLength="30"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label8" runat="server" CssClass="fontsmall">Address Line 2</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtAddressLine2" runat="server" Width="350px" CssClass="input_control_small" MaxLength="30"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="1%">
                                    <asp:Label ID="lblCityState" runat="server" Text="City/State/Zip"></asp:Label></TD>
								<TD height="1%">
									<asp:textbox id="txtCity" runat="server" Width="119px" CssClass="input_control_small" MaxLength="20" ReadOnly="True"
										BackColor="Gainsboro"></asp:textbox>&nbsp;
									<asp:dropdownlist id="ddlStates" runat="server" Width="118px" CssClass="input_control_small" Visible="False"></asp:dropdownlist>
									<asp:TextBox id="txtState" runat="server" Width="116px" CssClass="input_control_small" ReadOnly="True"
										BackColor="Gainsboro"></asp:TextBox>&nbsp;
									<asp:textbox id="txtZipCode" runat="server" Width="97px" CssClass="input_control_small" MaxLength="10"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;<asp:TextBox ID="txtProvince"
                                            runat="server" BackColor="Gainsboro" CssClass="Input_Control_Small" ReadOnly="True"
                                            Width="116px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD height="1%">
									<asp:label id="Label24" runat="server">e-mail</asp:label>
									<asp:label id="Label25" runat="server" Font-Size="XX-Small" CssClass="fontsmall"> (info@myenrll.com)</asp:label></TD>
								<TD height="1%">
									<asp:textbox id="txtemail" runat="server" Width="350px" CssClass="input_control_small" MaxLength="100"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox>&nbsp;</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<P>
										<asp:Label id="Label5" runat="server" CssClass="fontsmall">Additional Information</asp:Label><BR>
										<BR>
										<asp:label id="Label26" runat="server" CssClass="fontsmall">Max 4000 Character</asp:label><BR>
										<asp:label id="Label27" runat="server" CssClass="fontsmall">Remaining</asp:label>&nbsp;
										<asp:textbox id="txtRemaining" runat="server" Width="40px" BorderStyle="None" BorderColor="White" CssClass="fontsmall">4000</asp:textbox></P>
								</TD>
								<TD vAlign="top">
									<asp:TextBox id="txtDescription" onkeyup="RemainingLetters()" runat="server" Width="630px" Height="60px"
										TextMode="MultiLine" ReadOnly="True" BackColor="Gainsboro" CssClass="input_control_small"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD vAlign="top" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<TD vAlign="top" colSpan="2">
									<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="BORDER-RIGHT: white thin solid; BORDER-BOTTOM: white thin solid" align="center"
												width="33%" bgColor="#50505">
												<asp:Label id="Label13" runat="server" Font-Bold="True" ForeColor="White" CssClass="fontsmall">Estimated Amount</asp:Label></TD>
											<TD style="BORDER-RIGHT: white thin solid; BORDER-BOTTOM: white thin solid" align="center"
												width="33%" bgColor="#50505">
												<asp:Label id="Label15" runat="server" Font-Bold="True" ForeColor="White" CssClass="fontsmall">Approved Amount</asp:Label></TD>
											<TD style="BORDER-RIGHT: white thin solid; BORDER-BOTTOM: white thin solid" align="center"
												bgColor="#50505">
												<asp:Label id="Label14" runat="server" Font-Bold="True" ForeColor="White" CssClass="fontsmall">Paid Amount</asp:Label></TD>
										</TR>
										<TR>
											<TD style="BORDER-RIGHT: white thin solid; BORDER-BOTTOM: white thin solid" align="center"
												bgColor="#f0f0f0">
												<asp:Label id="lblAmount" runat="server" CssClass="fontsmall"></asp:Label></TD>
											<TD style="BORDER-RIGHT: white thin solid; BORDER-BOTTOM: white thin solid" align="center"
												bgColor="#f0f0f0">
												<asp:Label id="lblApprovedAmount" runat="server" CssClass="fontsmall"></asp:Label>
												<asp:TextBox id="txtApprovedAmount" runat="server" Visible="False" Width="100px" CssClass="fontsmall">0</asp:TextBox>
												<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Number Only" MaximumValue="1000000"
													MinimumValue="0" Type="Double" ControlToValidate="txtApprovedAmount" CssClass="fontsmall"></asp:RangeValidator></TD>
											<TD style="BORDER-RIGHT: white thin solid; BORDER-BOTTOM: white thin solid" align="center"
												bgColor="#f0f0f0">
												<asp:Label id="lblPaidAmount" runat="server" CssClass="fontsmall"></asp:Label>
												<asp:TextBox id="txtPaidAmount" runat="server" Visible="False" Width="100px" CssClass="fontsmall">0</asp:TextBox>
												<asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="Number Only" MaximumValue="1000000"
													MinimumValue="0" Type="Double" ControlToValidate="txtPaidAmount" CssClass="fontsmall"></asp:RangeValidator></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top">&nbsp;</TD>
								<TD vAlign="top"></TD>
							</TR>
							<TR>
								<TD vAlign="top" colSpan="2" style="height: 21px">
									<asp:LinkButton id="lnkbtnSaveAndStay" runat="server" CssClass="act_save_button"> Save</asp:LinkButton>&nbsp;
									<asp:LinkButton id="lnkbtnCancel" runat="server" CssClass="act_close_button" CausesValidation="False">Close</asp:LinkButton>
                                    &nbsp;
                                </TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
