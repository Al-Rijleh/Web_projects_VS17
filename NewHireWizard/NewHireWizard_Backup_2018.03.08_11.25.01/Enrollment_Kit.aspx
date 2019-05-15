<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enrollment_Kit.aspx.cs"
    Inherits="NewHireWizard.Enrollment_Kit" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enrollment Kit</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
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
    <div class="FullPage">
        <div class="StatusInputRowTitle FontSmall10 Header2">
            <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
        <div class="Blank10">
            &nbsp;
        </div>
        <div class="StatusInputRowTitle">
            <asp:Label ID="lblEnrollmentKit" runat="server" CssClass="FontSmall10" Font-Bold="True">Enrollment Kit Preparations</asp:Label>
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
                Width="100px">Employee</asp:Label><asp:Label ID="lblEmployeeValue" runat="server"
                    CssClass="FontSmall"></asp:Label>
        </div>
        <div class="Blank10">
            &nbsp;
        </div>
        <div class="StatusInputRowTitle">
            <asp:Label ID="lblIstruction" runat="server" CssClass="FontSmall" Font-Bold="False">If you would like to generate an enrollment kit and send it to yourself, another administrator(s) and/or the employee, click the "Yes" radio button below and then select the appropriate recipient.</asp:Label>
        </div>
        <div class="Blank10">
            &nbsp;
        </div>
        <div id="dvSelect" class="StatusInputRowTitle" runat="server">
            <div class="InputValue" style="width: 200px">
                <asp:Label ID="lblGenerateKit" runat="server" CssClass="FontSmall" Font-Bold="True">Generate Enrollment Kit Now</asp:Label>
            </div>
            <div class="InputValue" style="width: 119px">
                <asp:RadioButtonList ID="rblGenerateEnrollment" runat="server" CssClass="FontSmall"
                    RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblGenerateEnrollment_SelectedIndexChanged">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="InputValue">
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblGenerateEnrollment"
                    CssClass="fontsmall" Display="Dynamic" ErrorMessage="Required Generate Enrollment Kit"></asp:RequiredFieldValidator></div>
        </div>
        <div id="dvGenerateRecipeint" runat="server" class="FullPage" visible="false">
            <div class="StatusInputRowTitle">
                <asp:Label ID="Label1" runat="server" CssClass="FontSmall" Font-Bold="True" Font-Underline="False">Deliver Email Kit to the following Email Addresses:</asp:Label>
                <asp:Label ID="lblError" runat="server" CssClass="FontSmall" Font-Bold="True" ForeColor="Maroon"></asp:Label></div>
            <div class="StatusInputRowTitle">
                <asp:CheckBox ID="cbGentateToUser" runat="server" CssClass="FontSmall" />
            </div>
            <div class="StatusInputRowTitle">
                <div class="InputValue">
                    <asp:CheckBox ID="cbAdditionReciepient" runat="server" CssClass="FontSmall" Text="Additional/Alternative Recipients"
                        AutoPostBack="True" OnCheckedChanged="cbAdditionReciepient_CheckedChanged" />
                </div>
                <div id="dvRecipeintName" runat="server" class="InputValue" style="width: 400px"
                    visible="false">
                    <asp:Label ID="lblOtherRecipientName" runat="server" Text="Name" Width="50px" CssClass="FontSmall"></asp:Label>
                    <telerik:RadTextBox ID="txtRecepientName" runat="server" CssClass="FontSmall" Width="150px">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRecepientName"
                        CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Recipient Name"></asp:RequiredFieldValidator></div>
                <div class="InputValue">
                    &nbsp;</div>
                <div id="dvRecipeintEmail" runat="server" class="InputValue" style="width: 400px"
                    visible="false">
                    <asp:Label ID="lblOtherRecipientEmail" runat="server" Text="Email" Width="50px" CssClass="FontSmall"></asp:Label>
                    <telerik:RadTextBox ID="txtRecipientEmail" runat="server" CssClass="FontSmall" Width="150px">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRecipientEmail"
                        CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Recipient Email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRecipientEmail"
                        CssClass="FontSmall" Display="Dynamic" ErrorMessage="Incorrect Recipient Email"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
            </div>
            <div class="StatusInputRowTitle">
                <div class="InputValue">
                    <asp:CheckBox ID="cbGentateToEE" runat="server" CssClass="FontSmall" AutoPostBack="True"
                        OnCheckedChanged="cbGentateToEE_CheckedChanged" />
                </div>
                <div id="divEERecieve" runat="server" class="InputValue" style="width: 400px" visible="false">
                    <asp:Label ID="Label3" runat="server" Text="Email" Width="50px" CssClass="FontSmall"></asp:Label>
                    <telerik:RadTextBox ID="txtEEEmail" runat="server" CssClass="FontSmall" Width="150px"
                        ReadOnly="True">
                        <ReadOnlyStyle BackColor="#E0E0E0" />
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEEEmail"
                        CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Recipient Email"></asp:RequiredFieldValidator>
                </div>
                <div class="InputValue">
                    &nbsp;</div>
                <div id="divEEEmailNote" runat="server" class="InputValue" style="width: 400px" visible="false">
                    <asp:LinkButton ID="lnkbtnEdit" runat="server" CssClass="FontSmall" CausesValidation="False"
                        OnClick="lnkbtnEdit_Click">Please click this link to add or edit the email above </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="Blank10">
            &nbsp;
        </div>
        <div class="ButtonRow" id="DIV1" language="javascript" onclick="return DIV1_onclick()">
            <input id="htmbtnHome" runat="server" onclick="window.open('start.aspx?SkipCheck=YES','_self');"
                style="width: 110px" type="button" value="Welcome Page" />
            <asp:Button ID="btnBack" runat="server" CausesValidation="False" OnClick="BackButton_Click"
                Text="Back" Width="110px" />
            <asp:Button ID="btnNext" runat="server" OnClick="nextButton_Click" Text="Save & Next"
                Width="110px" />
        </div>
    </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
