<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="EnrollmentWizardSetup.Status" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function SaveFSA() {
            eval(document.getElementById("btnFSA")).disabled = true;
            eval(document.getElementById("hid1")).value = 'Go'
            PostBack()
        }

        function PostBack() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }     
    </script>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ddlPayCodes">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlPayCodes" />
                        <telerik:AjaxUpdatedControl ControlID="rbPayDates" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>--%>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="5px"
        Skin="Sunset" Width="75px">
        &nbsp;</telerik:RadAjaxLoadingPanel>
    <asp:HiddenField ID="hid1" runat="server" />
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
    &nbsp;
    <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
    <div class="FullPage">
        <div class="Section">
            <asp:Label ID="lblPageTitle" runat="server" Text="Status Plans Page Setup" CssClass="FontLarge"
                Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
        </div>
        <div style="width: 100%">
            <div class="Section">
        <asp:DropDownList ID="rblItem" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
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
            <asp:Panel ID="dvView" CssClass="Section" runat="server">
                <div class="Row" style="margin-top: 25px">
                    <div class="LeftRegion">
                        <asp:Label ID="lblEnrollmentType" runat="server" Text="Enrollment Type" AssociatedControlID="rblEnrollmentType"
                            CssClass="FontSmall" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="RightRegion">
                        <asp:RadioButtonList ID="rblEnrollmentType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                            Width="530px" AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
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
            </asp:Panel>
            <asp:Panel ID="dvEdit" class="Section" runat="server" Visible="false">
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
                            <asp:ListItem Value="2">This Account Only [Accnt]</asp:ListItem>
                            <asp:ListItem Value="3">This Account  [Accnt] and All its Divisions</asp:ListItem>
                        </asp:RadioButtonList>
                        <%--<asp:CheckBoxList ID="cblAccounts" runat="server" CssClass="FontSmall" RepeatColumns="2"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Default</asp:ListItem>
                                                        <asp:ListItem Value="2">This Account Only [Accnt]</asp:ListItem>
                                                        <asp:ListItem Value="3">This Account  [Accnt] and All its Divisions</asp:ListItem>
                                                    </asp:CheckBoxList>--%>
                    </div>
                </div>
                <div class="Row" style="padding-top: 5px">
                    <div class="LeftRegion">
                        <asp:Label ID="lblDiscriptionTitle" runat="server" Text="Description" CssClass="FontSmall"
                            AssociatedControlID="textDescription" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="RightRegion">
                        <asp:TextBox ID="textDescription" runat="server" CssClass="FontSmall" Width="294px"></asp:TextBox>
                    </div>
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
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Style="margin-left: 150px"
                        Text="Revert Account Message to Default Message" />
                    <br />
                    <br />
                </div>
            </asp:Panel>
            <%--Begin Show Cost --%>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Blank10">
                ggg</div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Row" style="text-align: center">
                <asp:Label ID="lblCurrentSetting" runat="server" Text="<b>Show Cost (Current Settings</b>"
                    CssClass="FontMedium"></asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Row">
                <asp:GridView ID="gvCurrentSetting" runat="server" CssClass="FontSamll" Width="752px">
                    <RowStyle HorizontalAlign="Center" CssClass="FontSmall" Width="188px" />
                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="FontSmall10" />
                    <SelectedRowStyle CssClass="FontSmall" Width="188px" />
                </asp:GridView>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Blank10">
                <hr />
            </div>
            <div class="Row" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="&lt;b&gt;Edit Parameter&lt;/b&gt;" CssClass="FontMedium"></asp:Label>
            </div>
            <div class="Row">
                <div class="LeftRegion">
                    <asp:Label ID="lblApplyEnrollmentType2" runat="server" Text="Apply To Enrollment Type"
                        CssClass="FontSmall" AssociatedControlID="cblEnrollmentType2" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:CheckBoxList ID="cblEnrollmentType2" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                        Width="458px">
                        <asp:ListItem Value="1">Open Enrollment</asp:ListItem>
                        <asp:ListItem Value="2">New Hire Enrollment</asp:ListItem>
                        <asp:ListItem Value="3">Life Event</asp:ListItem>
                        <asp:ListItem Value="4">Normal</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="Row" style="border-bottom: black 1px solid">
                <div class="LeftRegion">
                    <asp:Label ID="lblApplyToAccountpaytype2" runat="server" Text="Apply to Account(s)"
                        CssClass="FontSmall" AssociatedControlID="cblAccounts2" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:RadioButtonList ID="cblAccounts2" runat="server" CssClass="FontSmall" RepeatColumns="2"
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">This Account Only [Accnt]</asp:ListItem>
                        <asp:ListItem Value="2">This Account  [Accnt] and All its Divisions</asp:ListItem>
                        <asp:ListItem Value="5">All Reta Account</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rbtlstShowCost" runat="server" CssClass="FontSmall">
                    <asp:ListItem Selected="True" Value="M">Show ER Monthly Cost</asp:ListItem>
                    <asp:ListItem Value="P">Show Per Pay Cost</asp:ListItem>
                    <asp:ListItem Value="E">Show EE Montly Cost</asp:ListItem>
                    <asp:ListItem Value="N">Do not Show Cost</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="lblCostColumnTitle" runat="server" CssClass="FontSmall">Cost Column Title (<span style='font-size: 8pt; font-family: arial;'>This value will apply to all Enrollment Types</span>)</asp:Label>
                <asp:TextBox ID="txtCostColumnTitle" runat="server" CssClass="FontSmall" Width="300px"></asp:TextBox>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div style="padding-top: 10px" class="Row">
                <asp:Button ID="btnSave2" OnClick="btnSave_Click2" runat="server" Text="Save" Width="75px">
                </asp:Button>
            </div>
            <%--End Show Cost --%>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Blank10">
                <hr />
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <%--Begin Inclue OE --%>
            <div class="Row" style="text-align: center">
                <asp:Label ID="Label2" runat="server" Text="<b>Set up Included/Editable Benefit Plans in the Enrollment Period</b>"
                    CssClass="FontMedium"></asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <asp:Panel ID="SkipCvrgPanel" Style="padding-top: 10px" CssClass="Row" runat="server">
                <div class="Section FontSmall">
                    <asp:Label ID="lblInstruction" runat="server"></asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
                <div class="Section FontSmall">
                    <div style="width: 100px; float: left">
                        <asp:Label ID="lblSelectClass" runat="server" AssociatedControlID="ddlClass" Font-Bold="True">Select Class</asp:Label>
                    </div>
                    <div style="width: 400px; float: left">
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="FontSmall" Width="390px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                </div>
                <div class="Blank10">
                    &nbsp; &nbsp;&nbsp;
                </div>
                <div class="Section FontSmall">
                    <div style="width: 100px; float: left">
                        <asp:Label ID="lblOperation" runat="server" AssociatedControlID="rblOperation" Font-Bold="True">Select Operation</asp:Label>
                    </div>
                    <div style="width: 400px; float: left">
                        <asp:RadioButtonList ID="rblOperation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Included Coverages</asp:ListItem>
                            <asp:ListItem Value="1">Editable Coveragess</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                </div>
                <div class="Blank10">
                    &nbsp; &nbsp;&nbsp;
                </div>
                <div class="Section FontSmall">
                    <asp:Label ID="lblInstruction2" runat="server"><b>Please select the benefit plans that will be included in the upcoming open enrollment.</b></asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp; &nbsp;&nbsp;
                </div>
                <div class="Section FontSmall">
                    <asp:GridView ID="gvPlans" runat="server" AutoGenerateColumns="False" OnRowCreated="gvPlans_RowCreated"
                        Width="500px">
                        <Columns>
                            <asp:BoundField DataField="LONG_DESCRIPTION" HeaderText="Plan Name" />
                            <asp:TemplateField HeaderText="Core/Optional">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Include Plans">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblWrning" runat="server" Visible="False" ForeColor="maroon"><b>No Benfit Plans Found.</b></asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
                <div class="Section FontSmall">
                    <asp:Label ID="lblSaveTo" runat="server" Text="Save Condition" CssClass="FontSmall10"
                        Font-Bold="True"></asp:Label>
                </div>
                <div class="Section FontSmall">
                    <asp:RadioButtonList ID="rblSaveType" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                        Width="500px">
                        <asp:ListItem Value="1" Selected="True">This Account &amp; This Class Only</asp:ListItem>
                        <asp:ListItem Value="2">This Account &amp; All Classes</asp:ListItem>
                        <asp:ListItem Value="3">All Division &amp; This Class Only</asp:ListItem>
                        <asp:ListItem Value="4">All Divisions &amp; All Classes</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
            </asp:Panel>
            <div class="Section FontSmall">
                <asp:Button ID="btnSaveOE" runat="server" Text="Save" OnClick="btnSave_Click3" Width="75px" />
            </div>
            <%--End Inclue OE --%>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Blank10">
                <hr />
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <%--Begin Inclue Benefit Statement --%>
            <div class="Row" style="text-align: center">
                <asp:Label ID="Label3" runat="server" Text="<b>Set up Includede Benefit Plans in the Benefit Statement</b>"
                    CssClass="FontMedium"></asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <asp:Panel ID="SkipCvrgBenefitPanel" Style="padding-top: 10px" CssClass="Row" runat="server">
                <div class="Section FontSmall">
                    <asp:Label ID="lblInstructionBenefit" runat="server"></asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
                <div class="Section FontSmall">
                    <div style="width: 100px; float: left">
                        <asp:Label ID="lblSelectClassBeneft" runat="server" AssociatedControlID="ddlClass2" Font-Bold="True">Select Class</asp:Label>
                    </div>
                    <div style="width: 400px; float: left">
                        <asp:DropDownList ID="ddlClass2" runat="server" CssClass="FontSmall" Width="390px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlClass2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                </div>
                <div class="Blank10">
                    &nbsp; &nbsp;&nbsp;
                </div>
                <div class="Section FontSmall">
                    <asp:Label ID="lblInstruction2Benefit" runat="server"><b>Please select the benefit plans that will show in the Benefit Statement.</b></asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp; &nbsp;&nbsp;
                </div>
                <div class="Section FontSmall">
                    <asp:GridView ID="gvBenefit" runat="server" AutoGenerateColumns="False" OnRowCreated="gvBenefit_RowCreated"
                        Width="500px">
                        <Columns>
                            <asp:BoundField DataField="LONG_DESCRIPTION" HeaderText="Plan Name" />
                            <asp:TemplateField HeaderText="Include in Benefit Statement">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblWrningBebefit" runat="server" Visible="False" ForeColor="maroon"><b>No Benfit Plans Found.</b></asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
                <div class="Section FontSmall">
                    <asp:Label ID="lblSaveToBenefit" runat="server" Text="Save Condition" CssClass="FontSmall10"
                        Font-Bold="True"></asp:Label>
                </div>
                <div class="Section FontSmall">
                    <asp:RadioButtonList ID="rblSaveTypeBenefit" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                        Width="500px">
                        <asp:ListItem Value="1" Selected="True">This Account &amp; This Class Only</asp:ListItem>
                        <asp:ListItem Value="2">This Account &amp; All Classes</asp:ListItem>
                        <asp:ListItem Value="3">All Division &amp; This Class Only</asp:ListItem>
                        <asp:ListItem Value="4">All Divisions &amp; All Classes</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
            </asp:Panel>
            <div class="Section FontSmall">
                <asp:Button ID="btnSaveBenefit" runat="server" Text="Save" OnClick="btnSaveBenefit_Click"
                    Width="75px" />
            </div>
        </div>
    </div>
    <%--<div class="Section">
        <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Skin="Sunset" Width="100%">
            <Items>
            </Items>
        </telerik:RadPanelBar>
        &nbsp; &nbsp;
    </div>--%>
    <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Selected="True" Value="0">Skip Coverages</asp:ListItem>
            <asp:ListItem Value="1">View Only Coveragess</asp:ListItem>
        </asp:RadioButtonList>--%>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
