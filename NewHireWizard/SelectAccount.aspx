<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectAccount.aspx.cs" Inherits="NewHireWizard.SelectAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="InputRow" id="dvLocation" runat="server">
                <div class="InputLabel" style="width: 170px">
                    <asp:Label ID="lblSelectedacctchecl" runat="server" CssClass="FontSmall" Text="Currently Selected Account"></asp:Label>
                </div>
                <div class="InputValue" style="width: 400px">
                    <asp:Label ID="lblSelectedaaccount" runat="server" CssClass="FontSmall10" Font-Bold="True"></asp:Label>
                </div>
                 <div class="InputValue" style="width: 320px; margin-top: 15px;">
                    <asp:Button ID="btnGo" runat="server" Text="Good Continue" OnClick="btnGo_Click" />
                    &nbsp;
                    <asp:Button ID="btnSelectAccount" runat="server" Text="Select New Account" OnClick="btnSelectAccount_Click" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
