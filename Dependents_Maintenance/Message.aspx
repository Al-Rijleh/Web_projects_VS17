<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="Dependents_Maintenance.Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
<!--
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
    function htmbtnClose_onclick() 
        {
           closeWindow(1);
        }
     
// -->
</script>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <link href="Dep_Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 650px">
        <div style="width: 630px; text-align: right; padding-top: 10px; padding-right: 10px;" >
          <input id="Button1" name="Close" title="Close" type="button" value="Close" language="javascript" onclick="return htmbtnClose_onclick()" />
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="FontSmall" ></asp:Label><br />
        <br />
        <input id="htmbtnClose" name="Close" title="Close" type="button" value="Close" language="javascript" onclick="return htmbtnClose_onclick()" />&nbsp;</div>
    </form>
</body>
</html>