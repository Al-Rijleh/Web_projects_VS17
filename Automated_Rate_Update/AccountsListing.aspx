<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsListing.aspx.cs"
    Inherits="Automated_Rate_Update.AccountsListing" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Default.css" rel="stylesheet" type="text/css" />
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server">
        <Tabs>
            <telerik:RadTab runat="server" NavigateUrl="~/BASLogin.aspx" 
                Text="Process Account">
            </telerik:RadTab>
            <telerik:RadTab runat="server" NavigateUrl="~/AccountsListing.aspx" 
                Text="View Accounts List">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager runat="server" 
        DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rblstatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="FullPageNoMargin">
        <div class="InputRow fontSmall" style="margin-top: 20px">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 154px">
                    <asp:Label ID="lblStatus" runat="server" Text="Select Staus" CssClass="fontsmall"></asp:Label>
                </div>
            </div>
            <div class="InputValueNoValidator">
                <asp:RadioButtonList ID="rblstatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblRateRewal_SelectedIndexChanged"
                    RepeatDirection="Horizontal" CssClass="fontsmall">
                    <asp:ListItem Value="2">Not Completed</asp:ListItem>
                    <asp:ListItem Value="1">Completed</asp:ListItem>
                    <asp:ListItem Value="0">All</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="InputRow fontSmall" style="margin-top: 20px">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 154px">
                    <asp:Label ID="lblRateRenewal" runat="server" Text="Select Rate Renewal" 
                        CssClass="fontsmall" Visible="False"></asp:Label>
                </div>
                
            </div>
            <div class="InputValueNoValidator">
                <asp:DropDownList ID="ddlRateRenewal" runat="server" CssClass="fontsmall" 
                    Width="100px" Visible="False">
                </asp:DropDownList>
            </div>
        </div>
        <div class="InputRow fontSmall" style="margin-top: 20px">
        <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" 
                    Text="Export to Excel" />
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                AllowPaging="True" AllowSorting="True" CellSpacing="0" GridLines="None" 
                onneeddatasource="RadGrid1_NeedDataSource">
            </telerik:RadGrid>
        </div>
    </div>
    
    </form>
</body>
</html>
