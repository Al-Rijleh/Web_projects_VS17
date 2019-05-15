<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee_Search.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<meta http-equiv="Pragma" content="no-cache" />
		<link href="/styles/Main.css" type="text/css" rel="stylesheet" />
		<script src="/js/StyleSetter.js" type="text/javascript"></script>
        <style type="text/css">
        .error
            {
                font-family: Arial, Sans-Serif;
	            font-size: 10pt;
                font-weight:bold;
                color:Maroon;
                background-color: Yellow;
	            BORDER-TOP-WIDTH: 1px; 
	            BORDER-LEFT-WIDTH: 1px; 
	            BORDER-LEFT-COLOR: #000000; 
	            BORDER-BOTTOM-WIDTH: 1px; 
	            BORDER-BOTTOM-COLOR: #000000; 
	            BORDER-TOP-COLOR: #000000; 
	            BORDER-RIGHT-WIDTH: 1px; 
	            BORDER-RIGHT-COLOR: #000000;
            }
        </style>
</head>
<body>
    <table id="Table" style="z-index: 100; left: 2px; position: absolute; top: 2px" height="100%"
            cellspacing="0" cellpadding="0" width="790" border="0">
			<tr valign="top" height="1%">
				<td>
					<table id="Table1head" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td><asp:label id="LblTemplateHeader2" runat="server"></asp:label>
                                <asp:Label ID="lblScript" runat="server"></asp:Label></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr valign="top" height="98%">
				<td valign="top">
					<form id="Form2" method="post" runat="server">
						<table class="body_cell" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" style="background-color: white" runat="server">
							<tr>
								<td class="Instruction_cell">
									<asp:label id="lbl_fld_Employee_Search_Instruction" runat="server" CssClass="fontsmall">
						You may search for an employee on (1) Name, (2) MyEnroll Employee Number, (3) Social Security Number or (4) Employee’s email address. When using name, type any portion of the name in Last, first order; the more you type of name, the more exacting results will appear. When using social-security number, enter in the format ###-##-####; hyphens must be included. When searching on an email address, you must enter at least the portion of the address up to and including the ‘@’ symbol. MyEnroll employee number searches require exact matches.<br><br>
							</asp:label></td>
							</tr>
							<tr>
								<td style="height: 16px">
                                    <asp:Label ID="lblCurrentlySelected" runat="server" CssClass="fontsmall" Font-Bold="True"
                                        Text="Currently Selected Employee: "></asp:Label>&nbsp;
                                    <asp:Label ID="lblEmployeeSelected" runat="server" CssClass="fontsmall" Font-Bold="True"
                                        ForeColor="Maroon"></asp:Label></td>
								</tr>
							<&nbsp;
								</td>
								</tr>
								<tr>
								<td style="height: 42px">
									<asp:RadioButtonList id="opnlstFilter" runat="server" RepeatDirection="Horizontal" CssClass="Input_Radio_Button"
										AutoPostBack="True" OnSelectedIndexChanged="opnlstFilter_SelectedIndexChanged">
										<asp:ListItem Value="1" Selected="True">All Employees</asp:ListItem>
										<asp:ListItem Value="0">Active Employees Only</asp:ListItem>
										<asp:ListItem Value="2">Terminated Only</asp:ListItem>
                                        <asp:ListItem Value="4">Retiree Only</asp:ListItem>
									</asp:RadioButtonList>
                                    </td>
							</tr>
							<tr>
								<td style="height: 23px">
									<asp:Label id="Label1" runat="server" CssClass="fontsmall">Search For:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:TextBox id="txtSearch" runat="server" CssClass="Input_Control" Width="300px"></asp:TextBox>&nbsp;
									<asp:Button id="btnGo" runat="server" CssClass="General_button" Width="30px" Text="Go" OnClick="btnGo_Click1" ></asp:Button>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtSearch" CssClass="error" 
                                        ErrorMessage="Please Enter Seach Text"></asp:RequiredFieldValidator>
                                </td>
							</tr>
							
							<tr>
								<td>
									<asp:DataGrid id="dgEEs" runat="server" CssClass="fontsmall" AutoGenerateColumns="False" Width="100%" OnItemCreated="dgEEs_ItemCreated">
										<AlternatingItemStyle VerticalAlign="Top" BackColor="#F0F0F0"></AlternatingItemStyle>
										<ItemStyle VerticalAlign="Top" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A5A5A5"></HeaderStyle>
										<Columns>
                                            <asp:TemplateColumn HeaderText="Employee Name"></asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="MyEnroll#"></asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Employer"></asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Home City/Zip"></asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="E-Mail"></asp:TemplateColumn>
                                            <asp:BoundColumn DataField="status" HeaderText="Status"></asp:BoundColumn>
										</Columns>
									</asp:DataGrid></td>
							</tr>
							<tr>
								<td style="HEIGHT: 9px" align="right">
									<table class="body_cell" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td style="height: 18px">
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            </td>
											<td align="right" style="height: 18px">
												&nbsp;&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="height: 24px">
									<asp:button id="btnClose" runat="server" CssClass="General_button" Width="75px" Text="Close" OnClick="btnClose_Click"></asp:button></td>
							</tr>
						</table>
					</form><table class="body_cell" id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0" style="background-color: white" runat="server" bgcolor="yellow">
                        <tr>
                            <td class="Instruction_cell">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 16px">
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 42px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 23px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="HEIGHT: 9px" align="right">
                                <table class="body_cell" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                    <tr>
                                        <td style="height: 18px">
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        </td>
                                        <td align="right" style="height: 18px">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
				</td>
			</tr>
			<tr valign="top" height="1%">
				<td><asp:label id="LblTemplateFooter" runat="server"></asp:label></td>
			</tr>
		</table>
</body>
</html>
