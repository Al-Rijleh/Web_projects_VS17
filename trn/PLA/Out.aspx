<%@ Page Language="c#" Codebehind="Out.aspx.cs" AutoEventWireup="false" Inherits="PLA_Source.Out"
    ValidateRequest="false" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Out</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="/styles/Main.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <asp:Panel id="dvMsg" runat="server" style="z-index: 102; left: 94px; width: 770px;">
            <asp:Label ID="Label1" Style="z-index: 100; left: 125px; top: 28px" runat="server"
                Font-Size="Small" ForeColor="Red" Font-Names="Arial">Label</asp:Label>
        </asp:Panel>
        <asp:Panel id="dvbtn" runat="server" style="z-index: 102; left: 94px; width: 500px;">
            <asp:LinkButton ID="lnkbtnHome" Style="z-index: 101; left: 24px; top: 112px" runat="server"
                Visible="False">Home</asp:LinkButton>
        </asp:Panel>
        <asp:Panel id="dvBadData" runat="server" style="z-index: 102; left: 94px; width: 770px; margin:0 auto; " visible="false">
            <asp:Label ID="Label2" Style="z-index: 100; left: 125px; top: 28px" runat="server" Font-Names="Arial" Width="769px"><font face='Arial' size='2'><b><u>According to your MyEnroll record, you are not 
currently eligible to participate in the PLA program.</u></b></font>
<p class='MsoNormal'><font face='Arial' size='2'>
If you believe you are eligible to participate, please click on the button below 
to notify the appropriate parties at the FDIC.&nbsp; Your record will then be 
reviewed for accuracy regarding PLA eligibility.&nbsp; You will receive a response by 
e-mail within two business days informing you of the status of your request.
</font></asp:Label><br />
            <asp:Button ID="btnPlaEligible" runat="server" Text="Click here if you believe you are PLA eligible " style="margin-left: auto; margin-right: auto" OnClick="btnPlaEligible_Click" />
            <asp:Button ID="brnHome" runat="server" Text="Home" OnClick="brnHome_Click" /></asp:Panel>
    </form>
</body>
</html>
