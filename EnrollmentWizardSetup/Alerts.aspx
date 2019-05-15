<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alerts.aspx.cs" Inherits="EnrollmentWizardSetup.Alerts" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="SetupTabStrip.ascx" tagname="SetupTabStrip" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>

    <script type="text/javascript">
        function ShowPanel(t) {
            $(document).ready(function () {
                $("#dvCoverages").show("slow");
            })
        }

        function HidePanel() {
            $(document).ready(function () {
                $("#dvCoverages").hide("slow");
            })
        }

        function Clickbtn(btn) {
            if (btn.value == 'Show')
            {
                btn.value = 'Hide';
                ShowPanel();
            }
            else
            {
                btn.value = 'Show';
                HidePanel();
            }
        }
    </script>
<meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-family: Arial, Sans-Serif;
            font-size: 9pt;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
        <div class="Section">
            <asp:Label ID="lblPageTitle" runat="server" Text="Popup Alerts" CssClass="FontLarge"
                Font-Bold="True" ForeColor="Green" 
                Style="margin-left: auto; margin-right: auto;"></asp:Label>
        </div>
        <div class="Section">
            <asp:Label ID="lblPageName" runat="server" Text="Title" 
                Width="100px" CssClass="style1"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Width="497px"></asp:TextBox>
        </div>
        <%-- New --%>
        <div class="Section">
            <asp:Label ID="lblQuestion" runat="server" Text="Question" 
                Width="100px" CssClass="style1"></asp:Label>
            <asp:TextBox ID="txtQuestion" runat="server" Width="497px"></asp:TextBox>
            &nbsp;</div>




    <div id='dvEditPlans' runat="server" class="Section" visible="False">
        <div class="InnerSection">
            <asp:Label ID="lblPlans" runat="server" Text="Select Plans" Width="100px" 
                CssClass="style1"></asp:Label>
            <input id="htmbtnOpenClose" type="button" value="Show" onclick="Clickbtn(this)" class="FontSmall" />
        </div>
        <div id='dvCoverages' class="InnerSection " 
            style="background-color: #FFFFCC; ">
            <asp:CheckBoxList ID="cblPlans" runat="server" RepeatColumns="4" 
                RepeatDirection="Horizontal">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:CheckBoxList>
        </div>
    </div>

    <div id='dvViewPlans' runat="server" class="Section" >
        <div style="float:left">
            <asp:Label ID="lblViewPlan" runat="server" Text="Select Plans" Width="105px" 
                CssClass="style1"></asp:Label>            
        </div>
        <div style="float:left">
            <telerik:RadComboBox ID="ddlViewCoverages" runat="server" Width="500px" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlViewCoverages_SelectedIndexChanged">
            </telerik:RadComboBox>
        </div>
    </div>
        <div class="Section">
            &nbsp;<asp:RadioButtonList ID="rblItem" runat="server" CssClass="FontSmall10" Font-Bold="True"
                AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="32">Message</asp:ListItem>
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
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="ALL" Selected="True">This Account  [Accnt] and All its Divisions</asp:ListItem>
                        <asp:ListItem Value="ONE">This Account Only [Accnt]</asp:ListItem>
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
                            <telerik:RadEditor ID="txtNote" runat="server" Skin="Sunset" Width="748px" ToolsFile="FullSetOfTools.xml"
                                Height="300px">
                                <Content>
                                
</Content>

<TrackChangesSettings CanAcceptTrackChanges="False"></TrackChangesSettings>
                            </telerik:RadEditor>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="Row" style="padding-top: 10px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
