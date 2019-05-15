<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveDep.aspx.cs" Inherits="Dependents_Maintenance.RemoveDep" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Remove Dependent</title>
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
        <div style="width:625px; height: 230px ">
            <asp:Label ID="lblInstruction" runat="server" Text="Please enter the termination date for dependent:" CssClass="fontsmall" Font-Bold="True"></asp:Label>
            <asp:Label ID="lblDepName" runat="server" CssClass="fontsmall" Font-Bold="True"></asp:Label><br />
            <br />
            <asp:Label ID="lblOpenEnrollmentNote" runat="server" CssClass="fontsmall" Font-Bold="True"
                 Visible="False" Width="600px">If a life event has occurred within the past 60 days that results in the termination of a dependent record before 1/1/2010, return to the "Welcome Page" and click on "Submit a Permitted Election Change Due to a Life Event."</asp:Label><br />
            &nbsp;&nbsp;<br />
            &nbsp;
            <asp:Label ID="lblTerminationDate" runat="server" AssociatedControlID="txtTerminationDate"
                CssClass="fontsmall" Text="Termination Date" ToolTip="Termination Date Title"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="txtTerminationDate" runat="server" CssClass="fontsmall" ToolTip="Enter Termination Date"></asp:TextBox>&nbsp;&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTerminationDate"
                CssClass="fontsmall" Display="Dynamic" EnableClientScript="False"
                MaximumValue="01/01/2099" MinimumValue="01/01/1900" Type="Date" ErrorMessage="Incorrect Date - Date must be after  01/01/1900"></asp:RangeValidator>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTerminationDate"
                CssClass="fontsmall" Display="Dynamic" EnableClientScript="False" ErrorMessage="Required Info."></asp:RequiredFieldValidator><br />
            <br />
            &nbsp;
            <asp:Label ID="lblTerminationReason" runat="server" CssClass="fontsmall" Text="Termination Reason"></asp:Label>
            &nbsp; &nbsp;<asp:DropDownList ID="ddlReason" runat="server" CssClass="fontsmall"
                Width="347px" OnSelectedIndexChanged="ddlReason_SelectedIndexChanged">
            </asp:DropDownList>&nbsp;<br />
            &nbsp;&nbsp;<br />
            <br />
            &nbsp;
            <asp:Label ID="lblConfirm" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Maroon"
                Text="Are you sure you want to terminate {name}?"></asp:Label>&nbsp;
            <asp:Button ID="btnYes" runat="server" CssClass="fontsmall" OnClick="btnYes_Click"
                Text="Yes" Width="50px" />
            <asp:Button ID="btnNO" runat="server" CausesValidation="False" CssClass="fontsmall"
                OnClick="btnNO_Click" Text="No" Width="50px" />
            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="False"
                Mask="99/99/9999" TargetControlID="txtTerminationDate">
            </cc1:MaskedEditExtender>
       </div>
    </form>
</body>
</html>
