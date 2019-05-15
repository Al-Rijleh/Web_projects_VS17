<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Automated_Rate_Update.Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="Layout.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow(id) {
            var currentWindow = GetRadWindow();
            
            currentWindow.argument = id;
            currentWindow.Close();
        }

        
        function GoDouble(Param) {
            parent.document.location.href = "DoubleAgeRate.aspx" + Param
        }

        function run(strURL,Param) {
            parent.document.location.href = strURL + Param
        }

        function GoStatus(Param) {
            alert('here');
            parent.document.location.href = "StatusRate.aspx" + Param;
        }

        function close() {
            alert('here');
            window.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblScript" runat="server" ></asp:Label>
    <div id="dvManage" runat="server" class="Row">
            <div class="Row" style="text-align: center">
                <asp:Label ID="lblManageCoverage" runat="server" CssClass="FontSmall10 FontBold"></asp:Label><br />
                <asp:Label ID="lblEffectiveDate" runat="server" CssClass="FontSmall10 FontBold" ForeColor="Red"></asp:Label>
            </div>
            <div class="Row" id="dvRadBtn" runat="server">
                <asp:RadioButtonList ID="rblAction" runat="server" CssClass="textFont">
                    <asp:ListItem Value="same">KEEP this plan AND rating methodology, BUT MODIFY the Rates. </asp:ListItem>
                    <asp:ListItem Value="change">KEEP this plan BUT CHANGE THE RATING METHOD (Requires Terminating Plan and Adding a New Plan. All current plan information -- except rates -- will be copied from this plan to the new plan, automatically). </asp:ListItem>
                    <asp:ListItem Value="remove">Terminate this plan.</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Row" style="text-align: center">
                <input id="htmbtnCancel" type="button" value="Cancel" style="width: 120px" runat="server" onclick="closeWindow(1)"/>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnMakechange" runat="server" Text="Make Change" OnClick="btnMakechange_Click" style="height: 26px" Width="120px" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
