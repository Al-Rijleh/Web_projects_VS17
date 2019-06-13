<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FDIC_Sdmin_Setup.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadTabStrip ID="strip" runat="server" AutoPostBack="True" 
        ontabclick="RadTabStrip1_TabClick" SelectedIndex="0">
        <Tabs>
            <telerik:RadTab runat="server" Text="Edit Existing Administrator" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="New Administrator">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Super Users">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlAdmin">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlAdmin" UpdatePanelHeight="" />
                    <telerik:AjaxUpdatedControl ControlID="gvEmployee" 
                        LoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelHeight="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <div class="master_main">
        <div class="Entry_Row">
            <asp:Label ID="lblTitle" runat="server" Text="Edit Existing Administrator" CssClass="FontMedium"></asp:Label>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <%--Employees--%>
        <div class="Entry_Row fontsmall">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblSelectEmployee" runat="server" Text="Select Administrator"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <telerik:RadComboBox ID="ddlAdmin" runat="server" Width="350px" AutoPostBack="True"
                    MarkFirstMatch="True" OnSelectedIndexChanged="ddlAdmin_SelectedIndexChanged">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <%--Grid--%>
        <div class="Entry_Row fontsmall">
            <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" OnRowCreated="gvEmployee_RowCreated"
                Width="100%">
                <Columns>
                   
                    <asp:TemplateField HeaderText="Organization Code" ></asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Primary"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Regional Address"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Remove"></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Entry_Row fontsmall">
            <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" />
        &nbsp;<asp:Button ID="btnRemoveAdministrator" runat="server" 
                Text="Remove Administrator" OnClick="btnRemoveAdministrator_Click" />
        </div>

          <div class="Entry_Row fontsmall" style="margin: 10px">
            <asp:Button ID="btnShowEEE" runat="server" OnClick="btnShowEEE_Click" Text="Show Employees Associated with Administrators and Organization Codes"   />
        &nbsp;<%--<asp:Button ID="btShowOrgan" runat="server" 
                 OnClick="btnRemoveAdministrator_Click" />--%></div>

        <div class="Entry_Row fontsmall" style="margin: 5px">            
          <asp:Button ID="btShowOrgan" runat="server" 
                 OnClick="btShowOrgan_Click" Text="Show Employees by Organizational Code " Visible="False" />
        </div>
    </div>
    </form>
</body>
</html>
