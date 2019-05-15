<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebForm1.aspx.cs" Inherits="NewHireWizard.WebForm1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="FullPage" style="border-left-color: black; border-bottom-color: black; border-top-style: solid; border-top-color: black; border-right-style: solid; border-left-style: solid; border-right-color: black; border-bottom-style: solid">
            <asp:Panel ID="pnlfull_or_part_time" runat="server" CssClass="InputRow">
                <asp:Panel ID="Panel2" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblfull_or_part_time" runat="server" Text="Full or Part Time" AssociatedControlID="ddlfull_or_part_time"></asp:Label>
                    <asp:Label ID="Label8" runat="server" ForeColor="White" Text="*" AssociatedControlID="ddlfull_or_part_time"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel3" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlfull_or_part_time" runat="server" CssClass="fontsmall" Width="210px" ValidationGroup="grp4">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required Full / Part Time"
                        ControlToValidate="ddlfull_or_part_time" Display="Dynamic" ValidationGroup="grp4" Enabled="False"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
        </div>
        <div class="FullPage" style="border-left-color: black; border-bottom-color: black; border-top-style: solid; border-top-color: black; border-right-style: solid; border-left-style: solid; border-right-color: black; border-bottom-style: solid">
            <asp:Panel ID="Panel1" runat="server" CssClass="InputRow">
                <asp:Panel ID="Panel5" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblhours_worked_per_week" runat="server" Text="Hours Worked per Week" AssociatedControlID="txthours_worked_per_week"></asp:Label>
                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="*" AssociatedControlID="txthours_worked_per_week"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel6" runat="server" CssClass="InputValue">
                    &nbsp;<telerik:RadNumericTextBox ID="txthours_worked_per_week" runat="server" MinValue="0"
                        ValidationGroup="grp4" Width="210px">
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel7" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txthours_worked_per_week"
                        Display="Dynamic" ErrorMessage="Required Hours Worked per Week" ValidationGroup="grp4"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
        </div>
        <div class="FullPage" style="border-left-color: black; border-bottom-color: black; border-top-style: solid; border-top-color: black; border-right-style: solid; border-left-style: solid; border-right-color: black; border-bottom-style: solid">
            <asp:Panel ID="Panel8" runat="server" CssClass="InputRow">
                <asp:Panel ID="Panel9" runat="server" CssClass="InputLabel">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txthours_worked_per_week"
                        Text="Hours Worked per Week"></asp:Label>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txthours_worked_per_week"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel10" runat="server" CssClass="InputValue">
                    &nbsp;<telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" MinValue="0"
                        ValidationGroup="grp4" Width="210px">
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel11" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Hours Worked per Week"
                        ControlToValidate="txthours_worked_per_week" Display="Dynamic" ValidationGroup="grp4"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
