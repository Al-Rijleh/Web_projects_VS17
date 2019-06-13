<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAdmin.aspx.cs" Inherits="FDIC_Sdmin_Setup.NewAdmin" %>

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
        ontabclick="RadTabStrip1_TabClick" SelectedIndex="1">
        <Tabs>
            <telerik:RadTab runat="server" Text="Edit Existing Administrator">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Selected="True" Text="New Administrator">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Super Users">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <div class="master_main">
        <div class="Entry_Row">
            <asp:Label ID="lblTitle" runat="server" Text="Add New Administrator" 
                CssClass="FontMedium"></asp:Label>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <%--Employees--%>
        <div class="Entry_Row fontsmall">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblSelectEmployee" runat="server" Text="Select Administrator"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <asp:Label ID="lblEmployeeName" runat="server" Width="350px" 
                    BorderStyle="Solid" BorderWidth="1px" Visible="False"></asp:Label>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="Input_Control_Small_btn" 
                    Text="Select Employee" Width="108px" onclick="Button1_Click" />
            </div>
        </div>

         <%--Office / Division--%>
        <div class="Entry_Row fontsmall" id ="dvOfficrdiv" runat="server" visible="false">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblOfficeDivision" runat="server" Text="Select Office/Division"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <telerik:RadComboBox ID="ddlOfficeDiv" Runat="server" Width="350px" MarkFirstMatch="True" 
                    DropDownWidth="500px">
                </telerik:RadComboBox>
            
            </div>
        </div>

        <%--Organization Code--%>
        <div class="Entry_Row fontsmall">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblOrganizationCode" runat="server" Text="Organization Code"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <telerik:RadComboBox ID="ddlOrganizationCode" Runat="server" Width="350px" 
                    MarkFirstMatch="True" >
                </telerik:RadComboBox>
            </div>
        </div>

        <%-- Is Primary --%>
        <div class="Entry_Row fontsmall">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblIsPrimary" runat="server" Text="Is Primary"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <telerik:RadComboBox ID="ddlIsPrimary" Runat="server" Width="350px" 
                    MarkFirstMatch="True" >
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Yes" Value="T" />
                        <telerik:RadComboBoxItem runat="server" Text="No" Value="F" />
                    </Items>
                </telerik:RadComboBox>
            </div>
        </div>

        <%-- Reginal Address --%>
        <div class="Entry_Row fontsmall">
            <div class="LeftColumninput" style="text-align: right">
                <asp:Label ID="lblReginolAddress" runat="server" Text="Regional Address"></asp:Label>
            </div>
            <div class="RightColumn2" style="text-align: left; text-indent: 5px;">
                <telerik:RadNumericTextBox ID="txtRegional_Address" runat="server" 
                    DataType="System.Int16" MaxLength="2" MaxValue="99" MinValue="0" Width="350px">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </div>
        </div>
        <div class="Blank">
            &nbsp;</div>
        <div class="Blank">
            &nbsp;</div>
        <%-- Save Buttom --%>
        <div class="Entry_Row fontsmall">
            <asp:Button ID="btnSave" runat="server" CssClass="Input_Control_Small_btn" 
                onclick="btnSave_Click" Text="Save" />
        </div>

    </div>
    </form>
</body>
</html>
