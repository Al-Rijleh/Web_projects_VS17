<%@ Page language="c#" Codebehind="SelectSupervisor.aspx.cs" AutoEventWireup="false" Inherits="PLA_Homes.SelectSupervisor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD id="Head1">
		<title>Supervisor Selection</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<script>
        function GoBack()
        {
            strURL = document.getElementById("lblHidden").value;
            alert(document.getElementById('lblHidden').value);
            alert(document.getElementById("lblHidden").Value);
            window.location.href=strURL;
        }
		</script>
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<div>
				<table style="LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%" cellSpacing="0"
					cellPadding="0" border="0">
					<tr>
						<td vAlign="middle" align="center">
							<table style="BORDER-RIGHT: #d8d8d8 1px solid; BORDER-TOP: #d8d8d8 1px solid; BORDER-LEFT: #d8d8d8 1px solid; WIDTH: 550px; BORDER-BOTTOM: #d8d8d8 1px solid; HEIGHT: 1px"
								cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<td class="header_cell" width="11"></td>
									<td class="Header_cell"><asp:label id="lblTitle" runat="server" Text="Generate Personalized, Bar Coded Flexible Spending Account Claim Forms"> Supervisor Selection</asp:label></td>
								</tr>
								<tr>
									<td class="Instruction_cell" width="11" height="60"></td>
									<td class="Instruction_cell" height="60"><asp:label id="lblInstruction" runat="server" Text="Choose to generate a PDF of your personalized, bar coded claim form. Your selection will appear in a separate browser window. Within your browser window that pops up you can use the browser’s print and save functions to print and save your PDF."> Choose the supervisor you wish to view his/her Request applications</asp:label></td>
								</tr>
								<tr>
									<td class="Body_cell" width="11"></td>
									<td class="Body_cell">
										<table class="body_cell" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td height="5"></td>
											</tr>
											<tr>
												<td><asp:label id="lblSupervisorListTitle" runat="server" CssClass="body_cell" Font-Underline="True">Supervisors List</asp:label></td>
											</tr>
											<tr>
												<td height="5"></td>
											</tr>
											<tr>
												<td>
													<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 150px; text_aligh: left" align="left"><asp:datagrid id="dgEEs" runat="server" CssClass="body_cell" BorderWidth="2px" BorderColor="White"
															Width="100%" AutoGenerateColumns="False">
															<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
															<ItemStyle BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" BackColor="#505050"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="Name"></asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Emal"></asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Action"></asp:TemplateColumn>
															</Columns>
														</asp:datagrid></DIV>
												</td>
											</tr>
											<tr>
												<td height="5"></td>
											</tr>
											<tr>
												<td><asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="General_button" CausesValidation="False"></asp:button></td>
											</tr>
											<tr>
												<td height="5"></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td class="Footer_cell" width="11"></td>
									<td class="Footer_cell"><asp:label id="lblHidden" runat="server" CssClass="footer_cell"></asp:label><asp:label id="lblScript" runat="server"></asp:label></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
