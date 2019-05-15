<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Declaration_Form.aspx.cs" Inherits="Dependents_Maintenance.Declaration_Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Declaration Form Send Process</title>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    
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
        
        function ShowEnterEmail()
        {        
          eval(document.getElementById('hidCommand')).value = 'Show';  
          PostBack();
        }
        
        function ShowOpenDoc()
        {   
          var loc = eval(document.getElementById('hidFileLocation')).value;
          window.open(loc);
          var loc = eval(document.getElementById('hidCommand')).value = 'MarkDoc'
          __doPostBack(null,null);
        }
        
         
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript">
      var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        function PostBack() 
        {
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
            {                
                theForm.submit();
            }
        }     
    </script>
    
        <asp:HiddenField ID="hidCommand" runat="server" />
        <br />
        <asp:Label ID="lblMessage" runat="server" CssClass="fontsmall"></asp:Label>
        <asp:Label ID="lblEnterEmaail" runat="server" AssociatedControlID="txtEmail" CssClass="fontsmall"
            Text="Enter Email:" ToolTip="Enter your Email Title" Visible="False"></asp:Label>&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" CssClass="fontsmall" ToolTip="Enter you Email"
            Visible="False"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            CssClass="fontsmall" Display="Dynamic" EnableClientScript="False" Enabled="False"
            ErrorMessage="Incorrect Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
            CssClass="fontsmall" Display="Dynamic" EnableClientScript="False" Enabled="False"
            ErrorMessage="Email Requied Field"></asp:RequiredFieldValidator><br />
        <asp:HiddenField ID="hidFileLocation" runat="server" />
        <br />
        <br />
        
        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="fontsmall" ToolTip="Close this window" Width="75px" OnClick="btnClose_Click" /><asp:Button ID="btnCloseEmail" runat="server" Text="Close" CausesValidation="False" CssClass="fontsmall" OnClick="btnCloseEmail_Click" ToolTip="Close this page without saving any email" Visible="False" Width="75px" />
        <asp:Button ID="btnSaveEntrEmail" runat="server" Text="Save" CssClass="fontsmall" OnClick="btnSaveEntrEmail_Click" ToolTip="Save Entered Email and go back to the message section" Visible="False" Width="75px" /></div>
    </form>
</body>
</html>