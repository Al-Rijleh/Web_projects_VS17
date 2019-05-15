<%@ Page language="c#" Codebehind="SignaturBlock.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.SignaturBlock" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SignaturBlock</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" onblur="window.focus()">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fontsmall" id="TableSignature" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="0" cellPadding="0" width="100%" bgColor="navajowhite" border="0">
				<TR>
					<TD bgColor="brown">
						<asp:label id="Label40" runat="server" BackColor="Brown" ForeColor="White" Font-Bold="True">Signature Block</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label36" runat="server">Your Approval Signature:</asp:label>&nbsp;
						<asp:label id="Label37" runat="server">Type in your MyEnroll Password:</asp:label>
						<asp:label id="Label41" runat="server" ForeColor="Red">*</asp:label>&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtPassword" runat="server" TextMode="Password" Width="100px" CssClass="fontsmall"></asp:textbox>&nbsp;
						<asp:label id="lblErrorPassword" runat="server" ForeColor="Red"></asp:label>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="txtPassword"
							Display="Dynamic" EnableClientScript="False"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label38" runat="server">Type the characters  you  see below: </asp:label>
						<asp:label id="Label39" runat="server" ForeColor="Red">*</asp:label>&nbsp;&nbsp;
						<asp:textbox id="txtCode" runat="server" Width="100px" CssClass="fontsmall"></asp:textbox>&nbsp;
						<asp:label id="lblErrorCode" runat="server" ForeColor="Red"></asp:label>
						<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field" ControlToValidate="txtCode"
							Display="Dynamic" EnableClientScript="False"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD>
						<asp:image id="ImgSecImg" runat="server"></asp:image>&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
