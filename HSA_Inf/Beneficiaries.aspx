<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beneficiaries.aspx.cs" Inherits="HSA_Inf.CommingSoon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
       

        function docloseWindow(id) {
            closeWindow(id); return false;
        }

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

        function htmbtnColse_onclick() {            
            closeWindow(1)
        }
    
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblScript" runat="server" Text=""></asp:Label>
    <div>
        <iframe id="iBeneficiaries" runat="server" frameborder="0" name="Beneficiaries_frame"
                scrolling="auto" 
                title="Beneficiaries_frame" style="width: 570px;
                height: 400px" visible="False"></iframe>
        <br />
        <br />
        <div style="width: 570px; text-align: center">
        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Done Close This Page" 
                onclick="btnCancel_Click" />
        </div>
&nbsp;<asp:Button ID="btnCompled" runat="server" Text="Completed" Visible="False" />
    </div>
    </form>
</body>
</html>
