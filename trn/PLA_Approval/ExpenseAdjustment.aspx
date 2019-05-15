<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Page language="c#" Codebehind="ExpenseAdjustment.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.ExpenseAdjustment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExpenseAdjustment</title>
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
		function popup(url1,height1,width1)
		{				
		    tmp=window.open(url1,'expadj','status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
		}
		function formatCurrency(num) {
			num = num.toString().replace(/\$|\,/g,'');
			if(isNaN(num))
			num = "0";
			sign = (num == (num = Math.abs(num)));
			num = Math.floor(num*100+0.50000000001);
			cents = num%100;
			num = Math.floor(num/100).toString();
			if(cents<10)
			cents = "0" + cents;
			for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
			num = num.substring(0,num.length-(4*i+3))+','+
			num.substring(num.length-(4*i+3));
			return (((sign)?'':'-') + '$' + num + '.' + cents);
		}
		function AddValues()
		  {
		    try
		    {
		       document.getElementById('txtCourseHoursTotal').value = 
		       parseFloat(document.getElementById('txtCourseHoursDuty').value)+parseFloat(document.getElementById('txtCourseHoursNonDuty').value);
		    }
		    catch (err)
		    {
				document.getElementById('txtCourseHoursTotal').value = "Error";
		    }
		  }
		
		function Totals()
		{ 
		    var totalAdjutment = 0;
			for(var i=1; i<11;i++)
			{
				try
				{
					adjst = parseFloat(document.getElementById('txtAdjustment'+i.toString()).value);
					if(!isNaN(adjst))
						totalAdjutment = totalAdjutment + adjst;
				}
				catch(e)
				{
				}
				document.getElementById('txtAdjustmentTotal').value = formatCurrency(totalAdjutment);
			  
				paidID = 'txtPaidTotal';	
				paidValue = document.getElementById(paidID).value;
				paidValue = paidValue.toString().replace(/\$|\,/g,'');
							
				newID = 'txtNewAmountTotal';
				newValue = parseFloat(paidValue) + parseFloat(totalAdjutment);
				document.getElementById(newID).value = formatCurrency(newValue);
			} 
		}  
		
		function CalcNewAmount(txtbox)
		{
			adjID = txtbox.id;
			adjValue = txtbox.value;
			if(isNaN(adjValue))
				adjValue=0;
				
			paidID = adjID.replace('txtAdjustment','txtPaid');	
			paidValue = document.getElementById(paidID).value;
			paidValue = paidValue.toString().replace(/\$|\,/g,'');
							
			newID = adjID.replace('txtAdjustment','txtNewAmount');
			newValue = parseFloat(paidValue) + parseFloat(adjValue);
			document.getElementById(newID).value = formatCurrency(newValue);
			Totals();
		}
				 
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<TABLE id="Table" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 0px" height="98%"
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
						<TABLE class="fontsmall" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="220"><asp:label id="Label3" runat="server" Font-Bold="True">Training Requested</asp:label></TD>
											<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
											<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label><asp:label id="lblScript" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD style="BORDER-BOTTOM: silver 1px solid" colSpan="2"></TD>
										</TR>
									</TABLE>
									&nbsp;<asp:hyperlink id="HyperLink1" runat="server" Visible="False" CssClass="actbtn_go_next_button"
														NavigateUrl="Javascript:popup('ExpenseAdjustmentWriter.aspx?i=1',450,550);">Writer</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="fontsmall" id="Table3" style="BORDER-TOP: black 1px solid" cellSpacing="0"
										cellPadding="10" width="100%" border="0">
										<TBODY>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													align="left" width="15%" bgColor="#505050"><asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050">Expense<br>Type</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													width="10%" bgColor="#505050"><STRONG><FONT color="white">Paid<BR>
															Amount</FONT></STRONG></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													width="15%" bgColor="#505050"><asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050">Adjusment<br>Amount</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													width="10%" bgColor="#505050"><STRONG><FONT color="white">New<BR>
															Amount</FONT></STRONG></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#505050" colSpan="2"><asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050">Reason For<br>Adjustment</asp:label>&nbsp;
												</TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													width="20%" bgColor="#505050"><asp:label id="Label8" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050">Action</asp:label></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													height="1"><asp:label id="lblType1" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													height="1"><asp:textbox id="txtPaid1" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtAdjustment1" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment1"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtNewAmount1" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" width="25%" height="1"><asp:textbox id="txtReason1" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError1" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter1" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:dropdownlist id="DropDownList1" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo1" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													bgColor="#f0f0f0" height="1"><asp:label id="lblType2" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtPaid2" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtAdjustment2" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment2"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtNewAmount2" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" bgColor="#f0f0f0" height="1"><asp:textbox id="txtReason2" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError2" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgColor="#f0f0f0"
													height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter2" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:dropdownlist id="DropDownList2" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo2" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													height="1"><asp:label id="lblType3" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													height="1"><asp:textbox id="txtPaid3" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtAdjustment3" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator3" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment3"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtNewAmount3" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" height="1"><asp:textbox id="txtReason3" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError3" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter3" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:dropdownlist id="DropDownList3" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo3" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													bgColor="#f0f0f0" height="1"><asp:label id="lblType4" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtPaid4" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtAdjustment4" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator4" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment4"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtNewAmount4" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD class="fontsmall" style="BORDER-BOTTOM: black 1px solid" align="center" bgColor="#f0f0f0"
													height="1"><asp:textbox id="txtReason4" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError4" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgColor="#f0f0f0"
													height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter4" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:dropdownlist id="DropDownList4" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo4" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													height="1"><asp:label id="lblType5" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													height="1"><asp:textbox id="txtPaid5" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtAdjustment5" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator5" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment5"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtNewAmount5" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" height="1"><asp:textbox id="txtReason5" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError5" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter5" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:dropdownlist id="DropDownList5" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo5" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													bgColor="#f0f0f0" height="1"><asp:label id="lblType6" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtPaid6" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtAdjustment6" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator6" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment6"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtNewAmount6" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" bgColor="#f0f0f0" height="1"><asp:textbox id="txtReason6" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError6" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgColor="#f0f0f0"
													height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter6" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:dropdownlist id="DropDownList6" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo6" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													height="1"><asp:label id="lblType7" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													height="1"><asp:textbox id="txtPaid7" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtAdjustment7" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator7" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment7"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtNewAmount7" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD class="fontsmall" style="BORDER-BOTTOM: black 1px solid" align="center" height="1"><asp:textbox id="txtReason7" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError7" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter7" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:dropdownlist id="DropDownList7" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo7" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													bgColor="#f0f0f0" height="1"><asp:label id="lblType8" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtPaid8" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtAdjustment8" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator8" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment8"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtNewAmount8" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" bgColor="#f0f0f0" height="1"><asp:textbox id="txtReason8" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError8" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgColor="#f0f0f0"
													height="1">
                                                    <asp:LinkButton ID="lnkbtnWriter8" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:dropdownlist id="DropDownList8" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo8" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													height="1"><asp:label id="lblType9" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													height="1"><asp:textbox id="txtPaid9" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtAdjustment9" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator9" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment9"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:textbox id="txtNewAmount9" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD class="fontsmall" style="BORDER-BOTTOM: black 1px solid" align="center" height="1"><asp:textbox id="txtReason9" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError9" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" height="1">
                                                    <asp:LinkButton ID="LinkButton9" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													height="1"><asp:dropdownlist id="DropDownList9" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo9" runat="server" Visible="False" CssClass="actbtn_go_next_button" CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													bgColor="#f0f0f0" height="1"><asp:label id="lblType010" runat="server" Visible="False"></asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtPaid10" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtAdjustment10" onkeyup="CalcNewAmount(this);" runat="server" Visible="False"
														Width="75px" CssClass="fontsmall"></asp:textbox><asp:rangevalidator id="RangeValidator10" runat="server" Visible="False" CssClass="fontsmall" ControlToValidate="txtAdjustment10"
														EnableClientScript="False" Type="Double" MaximumValue="999999999" Display="Dynamic" ErrorMessage="Error"></asp:rangevalidator></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:textbox id="txtNewAmount10" runat="server" Visible="False" BackColor="Gainsboro" ReadOnly="True"
														Width="75px" CssClass="fontsmall"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" bgColor="#f0f0f0" height="1"><asp:textbox id="txtReason10" runat="server" Visible="False" Width="90%" CssClass="fontsmall"></asp:textbox><asp:label id="lblError10" runat="server" Visible="False" ForeColor="Red">**</asp:label></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgColor="#f0f0f0"
													height="1">
                                                    <asp:LinkButton ID="LinkButton10" runat="server" OnClick="lnkbtnWriter_Click" Visible="False" CssClass="fontsmall">writer</asp:LinkButton></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#f0f0f0" height="1"><asp:dropdownlist id="DropDownList10" runat="server" Visible="False" Width="75px" CssClass="fontsmall">
														<asp:ListItem Value="1">History</asp:ListItem>
													</asp:dropdownlist><asp:linkbutton id="lnkbtnGo10" runat="server" Visible="False" CssClass="actbtn_go_next_button"
														CausesValidation="False">Go</asp:linkbutton></TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
													align="right" bgColor="#505050"><asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050">Totals</asp:label>&nbsp;&nbsp;</TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="right"
													bgColor="#505050"><asp:textbox id="txtPaidTotal" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050"
														ReadOnly="True" Width="75px" CssClass="fontsmall" BorderColor="#0066CC" BorderWidth="0px" BorderStyle="None"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#505050"><asp:textbox id="txtAdjustmentTotal" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050"
														ReadOnly="True" Width="75px" CssClass="fontsmall" BorderColor="#0066CC" BorderWidth="0px" BorderStyle="None"></asp:textbox></TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#505050"><asp:textbox id="txtNewAmountTotal" runat="server" Font-Bold="True" ForeColor="White" BackColor="#505050"
														ReadOnly="True" Width="75px" CssClass="fontsmall" BorderColor="#0066CC" BorderWidth="0px" BorderStyle="None"></asp:textbox></TD>
												<TD style="BORDER-BOTTOM: black 1px solid" align="center" bgColor="#505050">&nbsp;</TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgColor="#505050">&nbsp;</TD>
												<TD style="BORDER-RIGHT: black 1px solid; BORDER-BOTTOM: black 1px solid" align="center"
													bgColor="#505050">&nbsp;</TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<P><asp:label id="lblErrorMark" runat="server" Visible="False" ForeColor="Red">** </asp:label>&nbsp;
										<asp:label id="lblErrorText" runat="server" Visible="False" CssClass="fontsmall">Denotes Required Information</asp:label><BR>
										<asp:label id="lblErrorMark2" runat="server" Visible="False" ForeColor="Red">Error</asp:label><asp:label id="lblErrorText2" runat="server" Visible="False" CssClass="fontsmall">Denote Adjustment Amount is not a number, or the amount  caused the Paid Amount to be less than zero.</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
                                    <asp:Button ID="btnSave" runat="server" Text="Save and Back" CssClass="fontsmall" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnBack" runat="server" CssClass="fontsmall" Text="Back without Saving" CausesValidation="False" OnClick="btnBack_Click" /></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
		<SCRIPT>setLocalElementsStyleClass (Get_Cookie('ClassName'));</SCRIPT>
	</body>
</HTML>
