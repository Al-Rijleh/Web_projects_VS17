<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepAuditWizSetup.aspx.cs" Inherits="EnrollmentWizardSetup.DepAuditWizSetup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="SetupTabStrip.ascx" tagname="SetupTabStrip" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
    <div class="Section">
        <asp:Label ID="lblPageTitle" runat="server" Text="Welcome Page Setup" CssClass="FontLarge"
            Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
    </div>
    <div class="Section">
        <%--Begin Date--%>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lbBeginDate" runat="server" Text="Period Statrt (inclusive)" 
                        Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadDatePicker ID="txtBeginDate" runat="server" MinDate="1998-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBeginDate"
                        CssClass="FontSmall" ErrorMessage="Required Information"
                        ForeColor="Maroon" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
            </div>
        <%--Begin Date--%>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblEndDate" runat="server" Text="Perid End (inclusive)" 
                        Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadDatePicker ID="txtLastDate" runat="server" MinDate="1998-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastDate"
                        CssClass="FontSmall" ErrorMessage="Required Information"
                        ForeColor="Maroon" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBeginDate"
                        ControlToValidate="txtLastDate" CssClass="fontsmall"
                        ErrorMessage="This Date must be Larger than Begin Date" ForeColor="Maroon" Operator="GreaterThan"
                        Type="Date" Display="Dynamic"></asp:CompareValidator></div>
            </div>

            <%--Reuired Document Date--%>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="Label2" runat="server" Text="Documents Required By" 
                        Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadDatePicker ID="txtDocBy" runat="server" MinDate="1998-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDocBy"
                        CssClass="FontSmall" ErrorMessage="Required Information"
                        ForeColor="Maroon" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtBeginDate"
                        ControlToValidate="txtDocBy" CssClass="fontsmall"
                        ErrorMessage="This Date must be Larger than Begin Date" ForeColor="Maroon" Operator="GreaterThan"
                        Type="Date" Display="Dynamic"></asp:CompareValidator></div>
            </div>

            <div class="Row" style="border-bottom: black 1px solid">
            <div class="LeftRegion">
                <asp:Label ID="Label1" runat="server" Text="Apply to Account(s)" CssClass="FontSmall"
                    AssociatedControlID="cblAccounts" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
            <asp:RadioButtonList ID="rblSaveTo" runat="server" CssClass="FontSmall" RepeatColumns="2"
                        RepeatDirection="Horizontal">                        
                        <asp:ListItem Value="0">This Account Only [Accnt]</asp:ListItem>
                        <asp:ListItem Value="1">This Account  [Accnt] and All its Divisions</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
        </div>
        <%--Begin Date--%><%--Buttons--%>
        <div class="Section" style="text-align: center;">
            <asp:Button ID="btnSaveNewDate" runat="server" Text="Save Period Information" 
                    OnClick="btnDates_Click" />          
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdateDates" runat="server" 
                Text="Update Existing Period Information" onclick="btnUpdateDates_Click" />          
            </div>
            <div class="Section">
                <hr />
            </div>
    </div>
    <div class="Section">
     
            <asp:RadioButtonList ID="rblItem" runat="server" CssClass="FontSmall10" Font-Bold="True"
                AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="22">Dep Audit Wiz Welcome</asp:ListItem>
                <asp:ListItem Value="23">Dep Audit Wiz Instruction</asp:ListItem>
                <asp:ListItem Value="29">Dep Audit Wiz Dependent Status</asp:ListItem>
                <asp:ListItem Value="24">Dep Audit Wiz Scan/Fax/Mail Options</asp:ListItem>
                <asp:ListItem Value="25">Dep Audit Wiz employee info</asp:ListItem>
                <asp:ListItem Value="26">Dep Audit Wiz Email - Dependent Approved</asp:ListItem>
                <asp:ListItem Value="27">Dep Audit Wiz Email - Dependent Declined</asp:ListItem>
                <asp:ListItem Value="28">Dep Audit Wiz Email - Require Information</asp:ListItem>
            </asp:RadioButtonList>
       
    </div>    
    <div id="Div1" class="Section" runat="server" style="text-align: center; border-top: black 1px solid;
        border-bottom: black 1px solid;">
        <asp:RadioButtonList ID="rblMode" runat="server" AutoPostBack="True" CssClass="FontSmall10"
            Style="margin-left: auto; margin-right: auto" Font-Bold="True" RepeatDirection="Horizontal"
            OnSelectedIndexChanged="rblMode_SelectedIndexChanged">
            <asp:ListItem Value="0" Selected="True">View Mode</asp:ListItem>
            <asp:ListItem Value="1">Edit Mode</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div id="dvView" class="Section" runat="server">
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblEnrollmentType" runat="server" Text="Enrollment Type" AssociatedControlID="rblEnrollmentType"
                    CssClass="FontSmall" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:RadioButtonList ID="rblEnrollmentType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                    Width="510px" 
                    OnSelectedIndexChanged="rblItem_SelectedIndexChanged">                    
                    <asp:ListItem Value="4" Selected="True">Normal</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="Row" style="border-bottom: black 1px solid">
            <div class="LeftRegion">
                <asp:Label ID="lblAccount" runat="server" Text="View From Account" AssociatedControlID="rblAccounts"
                    CssClass="FontSmall" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:RadioButtonList ID="rblAccounts" runat="server" CssClass="FontSmall" RepeatColumns="2"
                    RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Default</asp:ListItem>
                    <asp:ListItem Value="2">Account [Accnt]</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblDescriptionTitle" runat="server" Text="Description" CssClass="FontSmall"
                    Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                &nbsp;<asp:Label ID="lblDescription" runat="server" CssClass="FontSmall"></asp:Label></div>
        </div>
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblTextTitle" runat="server" Text="Text" CssClass="FontSmall" Font-Bold="True"></asp:Label>
            </div>
        </div>
        <div class="Row">
            <asp:Label ID="lblText" runat="server" CssClass="FontSmall"></asp:Label>
        </div>
    </div>
    <div id="dvEdit" class="Section" runat="server" visible="false">
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblApplyEnrollmentType" runat="server" Text="Apply To Enrollment Type"
                    CssClass="FontSmall" AssociatedControlID="cblEnrollmentType" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:CheckBoxList ID="cblEnrollmentType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                    Width="510px">                   
                    <asp:ListItem Value="4" Selected="True">Normal</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
        <div class="Row" style="border-bottom: black 1px solid">
            <div class="LeftRegion">
                <asp:Label ID="lblApplyToAccount" runat="server" Text="Apply to Account(s)" CssClass="FontSmall"
                    AssociatedControlID="cblAccounts" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
            <asp:RadioButtonList ID="cblAccounts" runat="server" CssClass="FontSmall" RepeatColumns="2"
                        RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="cblAccounts_SelectedIndexChanged">
                        <asp:ListItem Value="1">Default</asp:ListItem>
                        <asp:ListItem Value="2">This Account Only [Accnt]</asp:ListItem>
                        <asp:ListItem Value="3">This Account  [Accnt] and All its Divisions</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
        </div>
        <div class="Row" style="padding-top: 5px">
            <div class="LeftRegion">
                <asp:Label ID="lblDiscriptionTitle" runat="server" Text="Description" CssClass="FontSmall"
                    AssociatedControlID="textDescription" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:TextBox ID="textDescription" runat="server" CssClass="FontSmall" Width="294px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textDescription"
                    CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Info"></asp:RequiredFieldValidator></div>
        </div>
        <div class="Row">
            <div class="LeftRegion" style="width: 347px">
                <asp:Label ID="lblTextEditTitle" runat="server" Text="Text" CssClass="FontSmall"
                    Font-Bold="True"></asp:Label>&nbsp;
                </div>
        </div>
        <div class="Row">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <telerik:radeditor ID="RadEditor1" runat="server" Skin="Sunset" Width="748px" ToolsFile="FullSetOfTools.xml"
                            Height="300px">
                            <Content>
                            </Content>
                        </telerik:radeditor>
                    </td>
                </tr>
            </table>
        </div>
        <div class="Row" style="padding-top: 10px">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" 
                        Text="Revert Account Message to Default Message" 
                        style="margin-left:150px"/>
        </div>
    </div>
    </form>
</body>
</html>
