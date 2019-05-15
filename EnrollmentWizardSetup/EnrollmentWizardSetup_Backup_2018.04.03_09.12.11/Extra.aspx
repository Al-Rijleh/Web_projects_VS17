<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Extra.aspx.cs" Inherits="EnrollmentWizardSetup.Extra" %>

<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server"></uc1:SetupTabStrip>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <div class="Section">
            <asp:Label ID="lblPageTitle" runat="server" Text="Extra Page" CssClass="FontLarge"
                Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
        </div>
        <div class="Section">
            &nbsp;<asp:Label ID="lblPageName" runat="server" Text="Page Name:"></asp:Label>
            <asp:TextBox ID="txtPageName" runat="server" Width="497px"></asp:TextBox>
            <asp:Button ID="SaveTitle" runat="server" Text="Save" Width="75px" OnClick="SaveTitle_Click" /></div>
        <div class="Section">
            <asp:RadioButtonList ID="rblItem" runat="server" CssClass="FontSmall10" Font-Bold="True"
                AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="18">Message</asp:ListItem>
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
                        AssociatedControlID="cblAccountss" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:RadioButtonList ID="cblAccountss" runat="server" CssClass="FontSmall" RepeatColumns="2"
                        RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="cblAccountss_SelectedIndexChanged">
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
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" 
                    style="margin-left:150px" Text="Revert Account Message to Default Message" />
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
