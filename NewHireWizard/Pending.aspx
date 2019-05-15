<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Pending.aspx.cs" Inherits="NewHireWizard.Pending" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pending</title> 
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6"
            Skin="Sunset" />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="rblGenerateEnrollment">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rblGenerateEnrollment" />
                        <telerik:AjaxUpdatedControl ControlID="dvGenerateRecipeint" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="cbAdditionReciepient">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cbAdditionReciepient" />
                        <telerik:AjaxUpdatedControl ControlID="dvRecipeintName" />
                        <telerik:AjaxUpdatedControl ControlID="dvRecipeintEmail" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <uc1:TabStrip ID="TabStrip1" runat="server" />
        <div class="Blank10">
            &nbsp;
        </div>
        <div class="StatusInputRowTitle FontSmall10 Header2">
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
            <div class="Blank10">
                &nbsp;
            </div>
        <div id="dvFullPage" runat="server" class="FullPage FontSmall">
            <div class="StatusInputRowTitle">
                <asp:Label ID="lblTitle" runat="server" CssClass="InsideTitle" Visible="False">The following controls the required pending of this new hire:</asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div id="dvPendRequied" runat="server" class="StatusInputRowTitle" style="border-bottom: black 1px solid">
                <asp:Label ID="lblPendingStatus" runat="server" CssClass="FontSmall10" Font-Bold="True">Pending Status</asp:Label>&nbsp;
                <asp:Label ID="lblNoPending" runat="server" CssClass="FontSmall10" Font-Bold="True"
                    ForeColor="Green">No Pending Required</asp:Label>
                <asp:Label ID="lblPendingRequired" runat="server" CssClass="FontSmall10" Font-Bold="True"
                    ForeColor="Red" Visible="False">Pending Required</asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="StatusInputRowTitle">
                <asp:Label ID="lblDivision" runat="server" CssClass="FontSmall" Font-Bold="True"
                    Width="100px">Division</asp:Label>
                <asp:Label ID="lblDivisionValue" runat="server" CssClass="FontSmall"></asp:Label>
            </div> 
            <div class="StatusInputRowTitle">
            <asp:Label ID="lblEmployee" runat="server" CssClass="FontSmall" Font-Bold="True"
                Width="100px">Employee</asp:Label><asp:Label ID="lblEmployeeValue" runat="server" CssClass="FontSmall"></asp:Label>
        </div>
        </div>
       
        <div class="Blank10">
            &nbsp;
        </div>
        <div class="Blank10">
        &nbsp;
        </div>
        <div class="StatusInputRowTitle">
            <input id="htmbtnHome" runat="server" onclick="window.open('start.aspx?SkipCheck=YES','_self');"
                style="width: 110px" type="button" value="Welcome Page" />
            <asp:Button ID="btnBack" runat="server" CausesValidation="False" OnClick="BackButton_Click"
                Text="Back" Width="110px" />
            <asp:Button ID="btnNext" runat="server" OnClick="nextButton_Click" Text="Save & Next"
                Width="110px" />
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
