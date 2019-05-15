<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRateType.aspx.cs" Inherits="Automated_Rate_Update.NewRateType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="BASLogin.css" rel="stylesheet" type="text/css" />
    <link href="/styles/main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID='pnMaster' runat="server" Style="text-align: left; margin-left: auto;
        margin-right: auto" CssClass="masterwidth">
        
         <asp:Panel ID='pnlTitle' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
            <asp:Label ID="lblTitle" runat="server" class="dataSetctionTitle">Select New Rate Type For:&nbsp; </asp:Label>
         </asp:Panel>

         <asp:Panel ID='Panel1' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
             <asp:RadioButtonList ID="rblRateType" runat="server">
             </asp:RadioButtonList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="rblRateType" CssClass="error" 
                 ErrorMessage="Require Selection"></asp:RequiredFieldValidator>
         </asp:Panel>

         <asp:Panel ID='Panel2' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        Width="75px" CausesValidation="False" />
                    &nbsp;
                    <asp:Button ID="btnGo" runat="server" Text="Go" Width="75px" 
                 onclick="btnGo_Click" />
         </asp:Panel>
    </asp:Panel>
    </form>
</body>
</html>
