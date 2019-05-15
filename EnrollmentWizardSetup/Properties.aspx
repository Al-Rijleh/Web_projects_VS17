<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Properties.aspx.cs" Inherits="EnrollmentWizardSetup.Properties" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
    <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
    <div class="FullPage">
        <div class="Section">
            <asp:Label ID="lblpropertiesPageTitle" runat="server" Text="Accounts Properties Setup"
                CssClass="pageTitle"></asp:Label>
        </div>
        <div class="Section">
            <div class="Section_no_padding">
                <asp:Label ID="lblShowHideFSAMEDLink" runat="server" Text="Hide Helth Care FSA Expenses Link"
                    CssClass="dataSetctionTitle"></asp:Label>
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSelectedFSA" runat="server" Width="200px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <fieldset>
                    <legend>Save To</legend>
                    <asp:RadioButtonList ID="rblFSALink" runat="server" RepeatDirection="Horizontal"
                        Width="563px" CssClass="FontSmall" Font-Bold="True">
                        <asp:ListItem Selected="True" Value="1">Save to this account only</asp:ListItem>
                        <asp:ListItem Value="2">Save to this account and all divisions</asp:ListItem>
                    </asp:RadioButtonList>
                </fieldset>
            </div>
            <div class="Section">
                <fieldset>
                    <legend>Open Enrollment Type</legend>
                    <asp:CheckBoxList ID="cblFSALink" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal">
                        <asp:ListItem Value="184">Annual Open Enrollment</asp:ListItem>
                        <asp:ListItem Value="185">New Hire Enrollment</asp:ListItem>
                        <asp:ListItem Value="186">Life event</asp:ListItem>
                    </asp:CheckBoxList>
                </fieldset>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="brnSavePrePostTax" runat="server" Text="Save" OnClick="brnSavePrePostTax_Click" />
                &nbsp;
            </div>
        </div>
        <asp:Panel ID="Panel1" runat="server" CssClass="Section">
            <div class="Section">
                <hr />
                <asp:Label ID="Label1" runat="server" CssClass="FontMedium" Font-Bold="True">Default Pre/Post Tax Selection</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblPostTax" runat="server" Width="622px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">Default Selection to Pre Tax</asp:ListItem>
                    <asp:ListItem Value="1">DO Not Default Selection</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSaveTaxTo" runat="server" CssClass="FontSmall" 
                    Font-Bold="True" RepeatDirection="Horizontal" Width="563px">
                    <asp:ListItem Selected="True" Value="1">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="2">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="btnDefaultPrePostTax" runat="server" 
                    OnClick="btnDefaultPrePostTax_Click" Text="Save" />
                &nbsp;
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" CssClass="Section">
            <div class="Section">
                <hr />
                <asp:Label ID="Label2" runat="server" CssClass="FontMedium" Font-Bold="True">Hide Running Total</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblHidRunningValue" runat="server" Width="200px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSaveHidRunningTotalTo" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="1">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="2">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="btnSaveHidRunningTotal" runat="server" Text="Save" 
                    onclick="btnSaveHidRunningTotal_Click"  />
                &nbsp;
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
