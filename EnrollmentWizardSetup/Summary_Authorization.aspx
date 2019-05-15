<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary_Authorization.aspx.cs" Inherits="EnrollmentWizardSetup.Summary_Authorization" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Summary & Signature</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
        <div class="FullPage">
    <div class="Section">
        <asp:Label ID="lblPageTitle" runat="server" Text="Summary & Signature Page Setup" CssClass="FontLarge" Font-Bold="True" ForeColor="Green" style="margin-left:auto;margin-right:auto;"></asp:Label>
    </div>
    <div class="Section">
        <asp:DropDownList ID="rblItem" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="10">Summary Authorization (Top the Screen Text)</asp:ListItem>
            <asp:ListItem Value="17">Pending Election Message (Above Pending Election Grid)</asp:ListItem>
            <asp:ListItem Value="37">Covered Dependents (Above Covered Dependents Grid)</asp:ListItem>
            <asp:ListItem Value="11">Authorization Text (Text above"Accept" and "I do not Accept" Buttons </asp:ListItem>
            <asp:ListItem Value="42">Finalize Button Text (Text to the Right of the Finalize Button)  </asp:ListItem>
            <asp:ListItem Value="43">Congratulation Page Text  </asp:ListItem>            
            <asp:ListItem Value="12">Do not Accept Summary &amp; Authorization</asp:ListItem>
            <asp:ListItem Value="13">Administrator Accept Summary &amp; Authorization</asp:ListItem>
            <asp:ListItem Value="39">Finalize Closes NH Enr. Single Coverage - No Dependents</asp:ListItem>
            <asp:ListItem Value="40">Finalize Closes NH Enr. Non-Single Coverage Dep(s). ARE Validated </asp:ListItem>
            <asp:ListItem Value="41">Finalize Closes NH Enr. Non-Single Coverage Dep(s) ARE Not Validated </asp:ListItem>            
        </asp:DropDownList>
        <%--<asp:RadioButtonList ID="rblItem_x" runat="server" CssClass="FontSmall10" Font-Bold="True"
            AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged" 
            RepeatColumns="2" Visible="False">
            <asp:ListItem Selected="True" Value="10">Summary Authorization</asp:ListItem>
            <asp:ListItem Value="17">Pending Election Message</asp:ListItem>
            <asp:ListItem Value="37">Covered Dependents</asp:ListItem>
            <asp:ListItem Value="11">Authorization Text</asp:ListItem>
            <asp:ListItem Value="12">Do not Accept Summary &amp; Authorization</asp:ListItem>
            <asp:ListItem Value="13">Administrator Accept Summary &amp; Authorization</asp:ListItem>
            <asp:ListItem Value="39">Finalize Closes NH Enr. Single Coverage - No Dependents</asp:ListItem>
            <asp:ListItem Value="40">Finalize Closes NH Enr. Non-Single Coverage Dep(s). ARE Validated </asp:ListItem>
            <asp:ListItem Value="41">Finalize Closes NH Enr. Non-Single Coverage Dep(s) ARE Not Validated </asp:ListItem>
        </asp:RadioButtonList>--%>
    </div>
    <div id="Div1" class="Section" runat="server" style="text-align: center; border-top: black 1px solid;
        border-bottom: black 1px solid;">
        <asp:RadioButtonList ID="rblMode" runat="server" AutoPostBack="True" CssClass="FontSmall10" style="margin-left:auto;margin-right:auto"
            Font-Bold="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMode_SelectedIndexChanged">
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
                    Width="530px" AutoPostBack="True" 
                    OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Open Enrollment</asp:ListItem>
                    <asp:ListItem Value="2">New Hire Enrollment</asp:ListItem>
                    <asp:ListItem Value="3">Life Event</asp:ListItem>
                    <asp:ListItem Value="5">Special OE</asp:ListItem>
                    <asp:ListItem Value="4">Normal</asp:ListItem>
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
                    Width="530px">
                    <asp:ListItem Value="1">Open Enrollment</asp:ListItem>
                    <asp:ListItem Value="2">New Hire Enrollment</asp:ListItem>
                    <asp:ListItem Value="3">Life Event</asp:ListItem>
                    <asp:ListItem Value="5">Special OE</asp:ListItem>
                    <asp:ListItem Value="4">Normal</asp:ListItem>
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
                    <asp:ListItem Value="2" Selected="True">This Account Only [Accnt]</asp:ListItem>
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
                        <telerik:RadEditor ID="RadEditor1" runat="server" Skin="Sunset" Width="748px" ToolsFile="FullSetOfTools.xml"
                            Height="300px">
                            <Content>
                            </Content>
                        </telerik:RadEditor>
                    </td>
                </tr>
            </table>
        </div>
        <div class="Row" style="padding-top: 10px">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" 
                style="margin-left:150px" Text="Revert Account Message to Default Message" />
        </div>
    </div></div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
