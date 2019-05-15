<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabStrip.ascx.cs" Inherits="NewHireWizard.TabStrip" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="Stylesheet1.css" rel="stylesheet" type="text/css" />

<div class="FullPage">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" OnTabClick="RadTabStrip1_TabClick"
        SelectedIndex="0" Skin="Office2010Blue">
        <Tabs>            
            <telerik:RadTab runat="server" Text="Account Information" 
                Value="/web_projects/newhirewizard/account_division_class_payschedule.aspx?SkipCheck=YES" 
                ToolTip="Setup Account/Division/Class/Pay Schedule" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Contact Information" Value="/web_projects/newhirewizard/contactinformation.aspx"  ToolTip="Setup Contact Information">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Additional Information" Value="/web_projects/newhirewizard/additionalinformation.aspx" ToolTip="Setup Additional Information" Visible="False">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Pending" Value="/web_projects/newhirewizard/pending.aspx" ToolTip="Pending" Visible="False">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Enrollment Kit" Value="/web_projects/newhirewizard/Enrollment_kit.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Confirmation" 
                Value="/web_projects/newhirewizard/confirmation.aspx" ToolTip="Confirmation">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    
</div>
