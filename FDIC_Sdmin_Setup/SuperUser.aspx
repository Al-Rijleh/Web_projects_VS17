<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperUser.aspx.cs" Inherits="FDIC_Sdmin_Setup.SuperUser" %>

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
    <telerik:RadTabStrip ID="strip" runat="server" AutoPostBack="True" OnTabClick="RadTabStrip1_TabClick"
        SelectedIndex="2" ResolvedRenderMode="Classic">
        <Tabs>
            <telerik:RadTab runat="server" Text="Edit Existing Administrator">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="New Administrator">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Super Users" Selected="True">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <div class="master_main">
        <div class="Entry_Row">
            <asp:Label ID="lblTitle" runat="server" Text="Manage Super Users" CssClass="FontMedium"></asp:Label>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Entry_Row">
            <asp:Label ID="Label1" runat="server" Text="Add New Super User" CssClass="FontMedium"></asp:Label>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <%--Employees--%>
        <div class="Entry_Row fontsmall">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblSelectEmployee" runat="server" Text="Select New Super User"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <asp:Label ID="lblEmployeeName" runat="server" Width="350px" BorderStyle="Solid"
                    BorderWidth="1px"></asp:Label>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="Input_Control_Small_btn"
                    Text="Select Employee" Width="108px" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Entry_Row fontsmall">
            <asp:Button ID="btnSave" runat="server" CssClass="Input_Control_Small_btn" OnClick="btnSave_Click"
                Text="Save" Visible="False" />
        </div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Blank">
            <hr />
            &nbsp;</div>
        <div class="Blank">
            &nbsp;<asp:Label ID="Label2" runat="server" Text="Remove Super User(s)" CssClass="FontMedium"></asp:Label>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <%--Grid--%>
        <div class="Entry_Row fontsmall">
            <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" OnRowCreated="gvEmployee_RowCreated"
                Width="100%">
                <Columns>
                    <asp:BoundField DataField="Employee_number" HeaderText="Employee #" />
                    <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" />
                    <asp:TemplateField HeaderText="Remove"></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Entry_Row fontsmall">
            <asp:Button ID="btnRemove" runat="server" CssClass="Input_Control_Small_btn" 
                Text="Remove" onclick="btnRemove_Click"  />
        </div>
    </div>
    </form>
</body>
</html>
