<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReminderEmail.aspx.cs" Inherits="Automated_Rate_Update.ReminderEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <telerik:RadTabStrip ID="RadTabStrip1" runat="server" CausesValidation="False" 
        ResolvedRenderMode="Classic" SelectedIndex="3">
        <Tabs>
            <telerik:RadTab runat="server" NavigateUrl="~/BASLogin.aspx" 
                Text="Process Account">
            </telerik:RadTab>
            <telerik:RadTab runat="server" NavigateUrl="~/TerminatedAccounts.aspx" 
                Text="Terminated Account">
            </telerik:RadTab>


            <telerik:RadTab runat="server" NavigateUrl="~/GenerateReports.aspx" 
                Text="Generate Reminder Emails Report">
            </telerik:RadTab>

            <telerik:RadTab runat="server"  NavigateUrl="~/GenerateReports.aspx?inital=1" 
                Text="Generate Inital Email Reports" Selected="True">
            </telerik:RadTab>


            <telerik:RadTab runat="server" NavigateUrl="~/ReminderEmail.aspx" 
                Text="Send Reminder Emails" Selected="True">
            </telerik:RadTab>

            <telerik:RadTab runat="server"  NavigateUrl="~/ReminderEmail.aspx?inital=1" Text="Send Inital Emails">
            </telerik:RadTab>

        </Tabs>
    </telerik:RadTabStrip>
    <div>
       <asp:Label ID="lblTitle" runat="server" CssClass="pageTitle" 
        Text="Send Reminder Emails"></asp:Label><br /><br />

        <asp:Label ID="lblRenewalDate" runat="server" Text="Select Month" 
            CssClass="textFont" Width="100px"></asp:Label>

        <asp:DropDownList ID="ddlRenewalDate" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlRenewalDate_SelectedIndexChanged" Width="90px">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>&nbsp;
        <asp:Button ID="btnSendEmails" runat="server" onclick="btnSendEmails_Click" 
            Visible="False" />
        <br /><br />
    
    <asp:LinkButton id="lnkbtnExport" onclick="lnkbtnExport_Click" runat="server" Font-Bold="True">Click here to export the data shown below to Excel.</asp:LinkButton>
    <br /><br />

        <telerik:RadGrid ID="RadGrid1" runat="server">
        </telerik:RadGrid>
    </div>
    
    </form>
</body>
</html>
