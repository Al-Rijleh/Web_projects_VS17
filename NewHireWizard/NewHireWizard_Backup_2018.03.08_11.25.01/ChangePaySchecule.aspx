<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePaySchecule.aspx.cs" Inherits="NewHireWizard.ChangePaySchecule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
</head>
<body>
    <form id="form1" runat="server">
        <div ID="pnlFullPage" runat="server" class="TeleriksWindow">
            <div ID="pnlTitle" runat="server" class="TeleriksWindowRow FontSmall10">
                <asp:Label ID="lblTitle" runat="server" Text="Change Pay Scedule" Font-Bold="True"></asp:Label>
            </div>
            <div ID="pnlBlank1" runat="server" class="TeleriksWindowBlank5">
              &nbsp;
            </div>
            <div ID="pnlPayPeriodInstruction" runat="server" class="TeleriksWindowRow FontSmall">
                <asp:Label ID="lblPayPeriodInstruction" runat="server" Text="You may use this page to select the Employee’s Pay Period schedule. Select from the list below, then click the 'Save' button. "></asp:Label>
            </div>
            <div ID="pnlBlank2" runat="server" class="TeleriksWindowRow">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Pay Period is Required" ControlToValidate="rblPayPeriods" 
                    CssClass="FontSmall"></asp:RequiredFieldValidator>
            </div>
            <div ID="Panel2" runat="server" class="TeleriksWindowRow FontSmall">
                <asp:RadioButtonList ID="rblPayPeriods" runat="server" CssClass="fontsmall">
                </asp:RadioButtonList></div>            
            <div ID="Div1" runat="server" class="TeleriksWindowBlank5">
              &nbsp;
            &nbsp;&nbsp;</div>
            <div ID="Div2" runat="server" class="TeleriksWindowBlank5">
              &nbsp;
            &nbsp;&nbsp;</div>
            <div ID="pnlButton" runat="server" class="TeleriksWindowRow FontSmall">
                <asp:Button ID="btnClose" runat="server" Text="Close" Width="75px" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></div>
        </div>
    </form>
</body>
</html>