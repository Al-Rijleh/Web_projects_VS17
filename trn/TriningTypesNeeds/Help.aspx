<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="TriningTypesNeeds.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Help Window</title>
    <script type="text/javascript">
    
        function docloseWindow(id)
        {    
        closeWindow(id); return false;
        }
        
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblHelp" runat="server" CssClass="fontsmall"></asp:Label><br />
        &nbsp;</div>
        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="fontsmall" OnClick="btnClose_Click"  />
    </form>
</body>
</html>
