<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Coverage.aspx.cs" Inherits="Dependents_Maintenance.Coverage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Coverages</title>
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
        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="False"
                Mask="99/99/9999" TargetControlID="txtEffectiveDate">
            </cc1:MaskedEditExtender>
            <div style="z-index: 101; width: 700px; top: 5px; border-bottom: silver 1px solid; float: left;">
                <asp:Label ID="LBL_FLD_DEPENEDIT_COVERAGE_INSTRUCTION" runat="server" CssClass="fontsmall"
                    Font-Bold="True">
            You have added a Domestic Partner Dependent.  Assignment of coverage is not automatic.  To add this dependent to you Dental and/or Vision coverage click on the check box under the heading “Assign” to assign the corresponding coverage to [dependent].  Then check is made in the “Assign” box, chang the status to Self & Family.  If you want to change the option level of your coverage (e.g. from Standard to High), use the Add/Update benefits screen at the next enrollment step.

The Domestic Partner Program requires you to submit a completed Declaration of Domestic Partnership.  The declaration will be e-mailed to you.  If you fail to submit your Declaration of Domestic Partnership in the allotted time, benefits will revert to your previous election.  For example, if you are currently enrolled in Dental Standard Self Only, and you choose Dental High Self & Family, but fail to submit the Declaration of Domestic Partnership, your election will be terminated and your coverage will revert to Dental Standard Self Only.
                </asp:Label>
            </div>
            <div style="width:700px;float:left;height:15px">
            &nbsp;
            </div>
            <div style="z-index: 101; 
                height: 20px; width: 700px; float: left;">
                <asp:Label ID="lblEffectiveDate" runat="server" AssociatedControlID="txtEffectiveDate"
                    CssClass="fontsmall" Text="Effective Date" ToolTip="Effective Date Title"></asp:Label>
                <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="fontsmall" ToolTip="Benefits Effective Date"></asp:TextBox><asp:RangeValidator
                    ID="RangeValidator1" runat="server" ControlToValidate="txtEffectiveDate" CssClass="fontsmall"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Incorrect Date - Date must be in form MM/DD/YYYY"
                    MaximumValue="01/01/2099" MinimumValue="01/01/1900" Type="Date"></asp:RangeValidator><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEffectiveDate"
                        CssClass="fontsmall" Display="Dynamic" EnableClientScript="False" ErrorMessage="Required Info."></asp:RequiredFieldValidator>
            </div>
            <div style="z-index: 101;  width: 700px; height: 20px; float:left">
                <asp:Label ID="lblBenfitsTitile" runat="server" CssClass="fontsmall" Font-Bold="True"
                    Text="Benefit Plan" Width="222px"></asp:Label>
                
                <asp:Label ID="lblAssign" runat="server" CssClass="fontsmall" Font-Bold="True" Text="**Assign/Remove" Width="155px"></asp:Label>
                
                <asp:Label ID="lblStatusTitle" runat="server" CssClass="fontsmall" Font-Bold="True"
                    Text="Status"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 100px;
                height: 20px; float: left;">
                <asp:Label ID="lblBenefit1" runat="server" CssClass="fontsmall" Text="Label" Width="200px"
                    Visible="False"></asp:Label>
               
                <asp:CheckBox ID="cbselect1" runat="server" CssClass="fontsmall" Text=" " Visible="False"
                    AutoPostBack="True" OnCheckedChanged="cbselect1_CheckedChanged" Width="20px" />
               
                <asp:DropDownList ID="ddlAvailableStatus1" runat="server" Width="150px"
                    Visible="False">
                </asp:DropDownList>
                <asp:Label ID="lblAlreadyAssigned1" runat="server" CssClass="fontsmall" Text="Already Assigned"
                    Visible="False"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 120px;
                height: 20px; float: left;">
                <asp:Label ID="lblBenefit2" runat="server" CssClass="fontsmall" Text="Label" Width="200px"
                    Visible="False"></asp:Label>
              
                <asp:CheckBox ID="cbselect2" runat="server" CssClass="fontsmall" Text=" " Visible="False"
                    AutoPostBack="True" OnCheckedChanged="cbselect1_CheckedChanged" Width="20px" />
                <asp:DropDownList ID="ddlAvailableStatus2" runat="server" Width="150px"
                    Visible="False">
                </asp:DropDownList>
                <asp:Label ID="lblAlreadyAssigned2" runat="server" CssClass="fontsmall" Text="Already Assigned"
                    Visible="False"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 140px;
                height: 20px; float: left;">
                <asp:Label ID="lblBenefit3" runat="server" CssClass="fontsmall" Text="Label" Width="200px"
                    Visible="False"></asp:Label>
                
                <asp:CheckBox ID="cbselect3" runat="server" CssClass="fontsmall" Text=" " Visible="False"
                    AutoPostBack="True" OnCheckedChanged="cbselect1_CheckedChanged" Width="20px" />
                     
                <asp:DropDownList ID="ddlAvailableStatus3" runat="server" Width="150px"
                    Visible="False">
                </asp:DropDownList>
                <asp:Label ID="lblAlreadyAssigned3" runat="server" CssClass="fontsmall" Text="Already Assigned"
                    Visible="False"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 160px;
                height: 20px; float: left;">
                <asp:Label ID="lblBenefit4" runat="server" CssClass="fontsmall" Text="Label" Width="200px"
                    Visible="False"></asp:Label>
                    
                <asp:CheckBox ID="cbselect4" runat="server" CssClass="fontsmall" Text=" " Visible="False"
                    AutoPostBack="True" OnCheckedChanged="cbselect1_CheckedChanged" Width="20px" />
                     
                <asp:DropDownList ID="ddlAvailableStatus4" runat="server" Width="150px"
                    Visible="False">
                </asp:DropDownList>
                <asp:Label ID="lblAlreadyAssigned4" runat="server" CssClass="fontsmall" Text="Already Assigned"
                    Visible="False"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 180px;
                height: 20px; float: left;">
                <asp:Label ID="lblBenefit5" runat="server" CssClass="fontsmall" Text="Label" Width="200px"
                    Visible="False"></asp:Label>
                    
                <asp:CheckBox ID="cbselect5" runat="server" CssClass="fontsmall" Text=" " Visible="False"
                    AutoPostBack="True" OnCheckedChanged="cbselect1_CheckedChanged" Width="20px" />
                     
                <asp:DropDownList ID="ddlAvailableStatus5" runat="server" Width="150px"
                    Visible="False">
                </asp:DropDownList>
                <asp:Label ID="lblAlreadyAssigned5" runat="server" CssClass="fontsmall" Text="Already Assigned"
                    Visible="False"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 200px;
                height: 20px; float: left;">
                <asp:Label ID="lblBenefit6" runat="server" CssClass="fontsmall" Text="Label" Width="200px"
                    Visible="False"></asp:Label>
                    
                <asp:CheckBox ID="cbselect6" runat="server" CssClass="fontsmall" Text=" " Visible="False"
                    AutoPostBack="True" OnCheckedChanged="cbselect1_CheckedChanged" Width="20px" />
                     
                <asp:DropDownList ID="ddlAvailableStatus6" runat="server" Width="150px"
                    Visible="False">
                </asp:DropDownList>
                <asp:Label ID="lblAlreadyAssigned6" runat="server" CssClass="fontsmall" Text="Already Assigned"
                    Visible="False"></asp:Label>
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 220px;
                height: 20px">
            </div>
            <div style="z-index: 101; left: 5px; width: 700px; top: 240px;
                height: 20px">
                <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="aspxbtn_Click"
                    Text="Save & Exit" ToolTip="Save Changes and Exit" Width="85px" />
                <asp:Button ID="btnCancel" runat="server" CssClass="fontsmall" OnClick="btnCancel_Click"
                    Text="Cancel" ToolTip="Exit without saving" Width="85px" />
                </div>
            
       
    </form>
</body>
</html>
