<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BASLogin.aspx.cs" Inherits="Automated_Rate_Update.BASLogin" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="BASLogin.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
<script type="text/javascript">
    function UseRadWindow() {
        var oWnd = $find("<%= RadWindow1.ClientID %>");
        oWnd.show();
        oWnd.setSize(700, 400);
        oWnd.Center();
        oWnd.setUrl("PendingCcvrgs.aspx");
        oWnd.maximize();
        oWnd.restore();
    }
    function Button1_onclick() {
        UseRadWindow();
    }

</script>
    <form id="form1" runat="server">

    
    <telerik:RadWindow ID="RadWindow1" runat="server">

   </telerik:RadWindow>
    <telerik:RadScriptManager runat="server">
    </telerik:RadScriptManager>
  <telerik:RadTabStrip ID="RadTabStrip1" runat="server" CausesValidation="False" 
        ResolvedRenderMode="Classic" SelectedIndex="2">
        <Tabs>
            <telerik:RadTab runat="server" NavigateUrl="~/BASLogin.aspx" 
                Text="Process Account">
            </telerik:RadTab>
            <telerik:RadTab runat="server" NavigateUrl="~/TerminatedAccounts.aspx" 
                Text="Terminated Account">
            </telerik:RadTab>


            <telerik:RadTab runat="server" NavigateUrl="~/GenerateReports.aspx" 
                Text="Generate Reminder Emails Report" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server"  NavigateUrl="~/GenerateReports.aspx?inital=1" Text="Generate Inital Email Reports">
            </telerik:RadTab>


            <telerik:RadTab runat="server" NavigateUrl="~/ReminderEmail.aspx" 
                Text="Send Reminder Emails" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server"  NavigateUrl="~/ReminderEmail.aspx?inital=1" Text="send Inital Email">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <div class="FullPage">
        <div class="InputRow FontSmall">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 100px">
                    <asp:Label ID="lblAccount" runat="server" Text="Account/Location" CssClass="fontsmall"></asp:Label>
                </div>
            </div>
            <div class="ChangeCommand">
                <asp:Button ID="btnAccount" runat="server" CausesValidation="False" OnClick="btnAccount_Click"
                    Text="Get Account" Width="90px" CssClass="fontsmall" />
            </div>
            <div class="Validator">
                <asp:TextBox ID="txtAccountNameNumberValues" runat="server" ReadOnly="true" CssClass="FontSmall"
                    Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountNameNumberValues"
                    CssClass="fontsmall" Display="Dynamic" ErrorMessage="Required Account" ForeColor="Maroon"></asp:RequiredFieldValidator></div>
        </div>
        <div class="InputRow fontSmall" style="margin-top: 20px">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 154px">
                    <asp:Label ID="lblRenewal" runat="server" Text="Select Rate Renewal" CssClass="fontsmall"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblRateRewal"
                    CssClass="fontsmall" Display="Dynamic" ErrorMessage="Required Selection" ForeColor="Maroon"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:RadioButtonList ID="rblRateRewal" runat="server" CssClass="fontsmall" 
                    AutoPostBack="True" onselectedindexchanged="rblRateRewal_SelectedIndexChanged">
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="InputRow fontSmall" style="margin-top: 20px">
             <input id="htmBtnManagePlans" type="button" runat="server"
    value="Manage Pendig Plans" onclick="return Button1_onclick()" 
                 title="Manage pending Plans" visible="False" /></div>

         <div class="InputRow fontSmall" style="margin-top: 20px">
             <asp:Button ID="btnConnect" runat="server" Text="Go to" 
                 onclick="btnConnect_Click" Visible="False" />
         </div>
    </div>
    </form>
</body>
</html>
