<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tab.ascx.cs" Inherits="ReusableRadTab.Tab" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadTabStrip ID="tabstrip" runat="server" AutoPostBack="True" 
    ontabclick="tabstrip_TabClick" SelectedIndex="1" CausesValidation="False">
    <Tabs>
        <telerik:RadTab runat="server" Owner="tabstrip" Text="Root RadTab1">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Owner="tabstrip" Text="Root RadTab2" 
            Selected="True">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
