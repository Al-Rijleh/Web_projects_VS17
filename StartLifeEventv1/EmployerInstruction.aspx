<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployerInstruction.aspx.cs" Inherits="StartLifeEventv1.EmployerInstruction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="overflow:hidden">
<head runat="server">
    <title></title>
    <script type ="text/javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow() {            
            var currentWindow = GetRadWindow();
            currentWindow.argument = '0';
            currentWindow.Close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <span style="font-family:helvetica neue,roboto,arial; font-size:14pt;color:rgb(40,54,113)">Terms & Conditions</span>
    </div>
    <div style="height: 370px; overflow: auto; width: 100%;">
        <asp:Label ID="lblInstruction" runat="server" ></asp:Label>
    </div>
        <div style="margin-top: 15px; width: 100%;">
            <div style="width: 100px; margin-right: auto; margin-left: auto">
                <telerik:RadButton ID="btnClose" runat="server" Text="Close" Primary="true" RenderMode="Lightweight"
                    Style="top: 14px; left: 0px;width:100px;font-family: helvetica neue, roboto,arial;" OnClick="btnClose_Click">
                </telerik:RadButton>
            </div>
        </div>
    
    </form>
</body>
</html>
