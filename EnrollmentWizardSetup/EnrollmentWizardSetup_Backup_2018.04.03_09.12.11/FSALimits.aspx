<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FSALimits.aspx.cs" Inherits="EnrollmentWizardSetup.FSALimits" %>

<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
      function SaveFSA()
      {
        eval(document.getElementById("btnFSA")).disabled = true;
        eval(document.getElementById("hid1")).value = 'Go'                
        PostBack() 
      }
      
      function PostBack() 
      {
          var theForm = document.forms['form1'];
          if (!theForm) {
              theForm = document.form1;
          }
          if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
          {                
              theForm.submit();
          }
      }     
    </script>

    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ddlPayCodes">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlPayCodes" />
                        <telerik:AjaxUpdatedControl ControlID="rbPayDates" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>--%>
        
        <asp:HiddenField ID="hid1" runat="server" />
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
        <div class="FullPage">
            <div class="Section">
                <asp:Label ID="lblPageTitle" runat="server" Text="FSA Plans Page Setup" CssClass="FontLarge"
                    Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
            </div>
            
            
            
            <div class="Section">
                <asp:Label ID="lblPayDateLimit" runat="server" CssClass="FontSmall10" Font-Bold="True"
                    Font-Underline="True">No FSA After Pay Date</asp:Label>
                <div>
                    <asp:Label ID="lblPayCodes" runat="server" CssClass="FontSmall" Text="Select PayCode"></asp:Label>
                    <asp:DropDownList ID="ddlPayCodes" runat="server" CssClass="FontSmall" AutoPostBack="True" OnSelectedIndexChanged="ddlPayCodes_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="Section" style="height:10px">
                &nbsp;
                </div>
                <asp:Label ID="lblLimitPayDate" runat="server" CssClass="FontSmall" Text="Select Limit Pay Date" Font-Underline="True"></asp:Label>&nbsp;
                <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="(Starting from this date the employee will not be able to elect FSA when they are in New Hire Enrollment or Life Event.)"></asp:Label>
                <asp:RadioButtonList ID="rbPayDates" runat="server" CssClass="FontSmall10" Font-Bold="True" RepeatDirection="Horizontal" RepeatColumns="4" Width="658px">
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rbPayDates"
                    CssClass="FontSmall" Display="Dynamic" ErrorMessage="Must Select a Date"></asp:RequiredFieldValidator>
                <div class="Section" style="height:10px">
                &nbsp;
                </div>
                <div class="Row">
                    <div class="LeftRegion">
                        <asp:Label ID="Label9" runat="server" Text="Apply to Account(s)" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="RightRegion">
                        <asp:RadioButtonList ID="rblPageSave" runat="server" CssClass="FontSmall" RepeatColumns="2"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">This Account Only [Accnt]</asp:ListItem>
                            <asp:ListItem Value="2">This Account  [Accnt] and All its Divisions</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="Row" style="padding-top: 10px">
                        &nbsp;<asp:Button ID="btnFSA" runat="server" Text="Save No FSA After Pay Date"
                            Width="526px" />
                    </div>
                </div>
            </div>
            
            
           
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
