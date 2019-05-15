<%@ Page language="c#" Codebehind="SenMessage.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.SenMessage" validateRequest=false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Message Response</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="dFilter.js" type="text/javascript"></script>
		<LINK href="/styles/Main.css" type="text/css" rel="stylesheet">
		<style type="text/css">A:link { COLOR: blue; TEXT-DECORATION: underline }
	A:visited { COLOR: blue; TEXT-DECORATION: underline }
	A:hover { CURSOR: default; COLOR: blue; TEXT-DECORATION: underline }
		</style>
		<script>
			function popup(url1,height1,width1)
            {				
		    	tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" height="10%">
						<TABLE class="fontsmall" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="gold" colSpan="2"><asp:label id="lblTitle" runat="server" Font-Size="Small" Font-Bold="True">New Message</asp:label></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="200"><asp:label id="Label1" runat="server" Font-Bold="True">Employee</asp:label></TD>
								<TD><asp:label id="lblEmployeeInfo" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Bold="True">Employer</asp:label></TD>
								<TD><asp:label id="lblDivision" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label3" runat="server" Font-Bold="True">Title of Code & Course</asp:label></TD>
								<TD><asp:label id="lblCourseTitle" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label28" runat="server" Font-Bold="True" Visible="False">Current Available Balance</asp:label></TD>
								<TD><asp:label id="lblBalance" runat="server" Font-Bold="True" Visible="False">$2,500.00</asp:label></TD>
							</TR>
							<TR>
								<TD width="100">&nbsp;</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="BORDER-TOP: silver thin solid" vAlign="top">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top"></TD>
				</TR>
				<TR>
					<TD vAlign="top"></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE class="fontsmall" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="200">
									<asp:Label id="Label12" runat="server" Font-Bold="True">Original Message  From:</asp:Label></TD>
								<TD>&nbsp;
									<asp:Label id="lblFromPosition" runat="server"></asp:Label>&nbsp;-
									<asp:Label id="lblFromName" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="185">
									<asp:Label id="Label13" runat="server" Font-Bold="True">Original Message To:</asp:Label></TD>
								<TD>&nbsp;
									<asp:Label id="lblToPosition" runat="server"></asp:Label>&nbsp;-
									<asp:Label id="lblToName" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="BORDER-TOP: silver thin solid">
									<asp:Label id="Label6" runat="server" Font-Bold="True">Reply From</asp:Label></TD>
								<TD style="BORDER-TOP: silver thin solid">&nbsp;
									<asp:Label id="lblReplayFrom" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:Label id="Label9" runat="server" Font-Bold="True">Reply To</asp:Label></TD>
								<TD>
									<asp:CheckBoxList id="chklstEmailTo" runat="server" CssClass="fontsmall" Width="100%"></asp:CheckBoxList></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">&nbsp;</TD>
				</TR>
				<TR>
					<TD height="1%">
						<TABLE class="fontsmall" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="200" style="WIDTH: 200px"><asp:label id="Label4" runat="server">Message Subject</asp:label></TD>
								<TD><asp:textbox id="txtSubject" runat="server" MaxLength="255" CssClass="fontsmall" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD vAlign="top" style="WIDTH: 200px"><asp:label id="Label5" runat="server"> Message Body</asp:label>
									<asp:Label id="Label10" runat="server" ForeColor="Red">*</asp:Label><BR>
									&nbsp;<BR>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtMemo" ErrorMessage="Required Field"
										Display="Dynamic"></asp:requiredfieldvalidator></TD>
								<TD><asp:textbox id="txtMemo" runat="server" CssClass="fontsmall" Width="300px" Height="100px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 200px">&nbsp;</TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 200px"><asp:label id="Label8" runat="server">Enter Your MyEnroll.com Password</asp:label>
									<asp:Label id="Label11" runat="server" ForeColor="Red">*</asp:Label></TD>
								<TD vAlign="top"><asp:textbox id="txtPassword" runat="server" CssClass="fontsmall" Width="300px" TextMode="Password"></asp:textbox><asp:label id="lblPassordError" runat="server" ForeColor="Red"></asp:label><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Required Field"
										ControlToValidate="txtPassword"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 200px">&nbsp;</TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="1%"><asp:linkbutton id="lnbtnSave" runat="server" CssClass="act_save_button">Save</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lnkbtnCancel" runat="server" CssClass="act_close_button" CausesValidation="False">Cancel</asp:linkbutton><asp:label id="lblScript" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
