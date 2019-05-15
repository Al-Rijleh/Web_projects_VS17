<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PendClasses.aspx.cs" Inherits="NewHireWizard.PendClasses" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
        function GetRadWindow()
        {
          var oWindow = null;
          if (window.radWindow)
             oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
             oWindow = window.frameElement.radWindow;
          return oWindow;
        }  
        
        function closeWindow(id)
        {       
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }
    </script>

    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6" Skin="Sunset" />
        <div ID="pnlFullPage" runat="server" Class="TeleriksWindow">
            <div ID="pnlTitle" runat="server" Class="TeleriksWindowRow FontSmall10">
                <asp:Label ID="lblTitle" runat="server" Text="Your organization requires this system to pend new hires who belnog these classes." Font-Bold="True"></asp:Label>
            </div>
            <div ID="pnlBlank1" runat="server" Class="TeleriksWindowBlank5">
              &nbsp;
            </div>
            <div ID="pnClasses" runat="server" Class="TeleriksWindowRow FontSmall">
                <asp:Label ID="lblClasses" runat="server"></asp:Label>
            </div>
            <div ID="pnlBlank2" runat="server" Class="TeleriksWindowBlank5">
              &nbsp;
            </div>
            <div ID="pnlButton" runat="server" Class="TeleriksWindowRow FontSmall">
                <asp:Button ID="btnClose" runat="server" Text="Close" Width="75px" />
            </div>
        </div>
    </form>
</body>
</html>
