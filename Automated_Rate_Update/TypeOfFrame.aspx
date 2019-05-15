<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeOfFrame.aspx.cs" Inherits="Automated_Rate_Update.TypeOfFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="Default.css" rel="stylesheet" type="text/css" />
    <link href="/styles/main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID='pnMaster' runat="server" Style="text-align: left; margin-left: auto;
        margin-right: auto" CssClass="masterwidth">
        <asp:Panel ID='pnlTitle' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
            <asp:Label ID="lblTitle" runat="server" class="dataSetctionTitle">Edit Staus Rates</asp:Label>
        </asp:Panel>
        <asp:Panel ID='Panel1' runat="server" class="cvrgrow marginbottom5 paddingbottomm5 bottomline fontsmall10">
            <asp:RadioButtonList ID="rblRateTrpe" runat="server">
                <asp:ListItem Value="0">Status</asp:ListItem>
                <asp:ListItem Value="1">Age RATE</asp:ListItem>
                <asp:ListItem Value="2">Age Rate Tobacco /Non Tobacco</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
    </asp:Panel>
    </form>
</body>
</html>
