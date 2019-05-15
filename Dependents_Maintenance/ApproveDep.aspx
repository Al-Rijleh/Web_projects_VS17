<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveDep.aspx.cs" Inherits="Dependents_Maintenance.ApproveDep" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Approve Dependent</title>
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
        
        

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width:625px; height: 170px ">
            &nbsp;
            <asp:Label ID="Label1" runat="server" Text="Please enter the documentation's Receive Date for dependent " CssClass="fontsmall" Font-Bold="True"></asp:Label><asp:Label ID="lblDepName" runat="server" CssClass="fontsmall" Font-Bold="True"></asp:Label><br />
            &nbsp;&nbsp;<br />
            &nbsp;
            <asp:Label ID="lblApptovalDate" runat="server" AssociatedControlID="txtApproveDate"
                CssClass="fontsmall" Text="Documentaion Receive Date" ToolTip="Documentaion Receive Date"></asp:Label>&nbsp; 
            <asp:TextBox ID="txtApproveDate" runat="server" CssClass="fontsmall" ToolTip="Enter Approve Date"></asp:TextBox>&nbsp;&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtApproveDate"
                CssClass="fontsmall" Display="Dynamic" EnableClientScript="False"
                MaximumValue="01/01/2099" MinimumValue="01/01/1900" Type="Date" ErrorMessage="Incorrect Date - Date must in fom MM/DD/YYYY"></asp:RangeValidator>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApproveDate"
                CssClass="fontsmall" Display="Dynamic" EnableClientScript="False" ErrorMessage="Required Info."></asp:RequiredFieldValidator>&nbsp;<br />
            <br />
            <br />
            &nbsp;
            <asp:Label ID="lblConfirm" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Maroon"
                Text="Are you sure you want to approve {name}?"></asp:Label>&nbsp;
            <asp:Button ID="btnYes" runat="server" CssClass="fontsmall" OnClick="btnYes_Click"
                Text="Yes" Width="50px" />
            <asp:Button ID="btnNO" runat="server" CausesValidation="False" CssClass="fontsmall"
                OnClick="btnNO_Click" Text="No" Width="50px" />
            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="False"
                Mask="99/99/9999" TargetControlID="txtApproveDate">
            </cc1:MaskedEditExtender>
       </div>
    </form>
</body>
</html>
