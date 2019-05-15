<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Name_Identification.aspx.cs"
    Inherits="NewHireWizard.Name_Identification" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Name/Identification</title>
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
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6" Skin="Sunset" />
        <uc1:TabStrip ID="TabStrip1" runat="server" />
        <div class="Blank10">
            &nbsp;
        </div><div class="StatusInputRowTitle FontSmall10 Header2">
            <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
        <div class="Blank10">
        </div>
        <div id="dvFullPage" runat="server" class="FullPage FontSmall">
            <div>
                <div class="StatusInputRowTitle  FontSmall">
                    &nbsp;<asp:Label ID="lblTitle" runat="server" CssClass="InsideTitle">Enter information as requested below:</asp:Label>
                </div>
                <div class="Blank10">
                    &nbsp;
                </div>
                <%--First Name--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name" AssociatedControlID="txtFirstName"></asp:Label>
                        <asp:Label ID="reqFirstName" runat="server" ForeColor="Red" Text="*" AssociatedControlID="lblFirstName"></asp:Label></div>
                    <div class="InputValue">
                        <telerik:RadTextBox ID="txtFirstName" runat="server" MaxLength="15" SelectionOnFocus="CaretToBeginning"
                            Width="210px" CssClass="FontSmall">
                        </telerik:RadTextBox></div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="reqvalidFirstName" runat="server" ErrorMessage="Required First Name"
                            ControlToValidate="txtFirstName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Middle Initial--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <asp:Label ID="lblMiddle_Initial" runat="server" AssociatedControlID="txtMiddleInitial"
                            Text="Middle Initial"></asp:Label>
                    </div>
                    <div class="InputValue">
                        <telerik:RadTextBox ID="txtMiddleInitial" runat="server" MaxLength="1" Width="210px"
                            CssClass="FontSmall" Style="text-transform: uppercase;">
                        </telerik:RadTextBox>
                    </div>
                    <div class="InputValidator">
                        &nbsp;</div>
                </div>
                <%--Last Name--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label>
                        <asp:Label ID="reqLastName" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtLastName"></asp:Label></div>
                    <div class="InputValue">
                        <telerik:RadTextBox ID="txtLastName" runat="server" MaxLength="20" Width="210px"
                            CssClass="FontSmall">
                        </telerik:RadTextBox>
                    </div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="reqvaildLastName" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Required Last Name" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--DOB--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <asp:Label ID="lblDateofBirth" runat="server" Text="Date of Birth" AssociatedControlID="txtDateofBirth"></asp:Label>
                        <asp:Label ID="reqDateofBirth" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtDateofBirth"></asp:Label></div>
                    <div class="InputValue">
                        <telerik:RadMaskedTextBox ID="txtDateofBirth" runat="server" DisplayMask="##/##/####"
                            Mask="##/##/####" TextWithLiterals="//" Width="211px" CssClass="FontSmall">
                            <FocusedStyle CssClass="fontsmall" />
                            <EnabledStyle CssClass="fontsmall" />
                        </telerik:RadMaskedTextBox></div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="reqvalidDateofBirth" runat="server" ControlToValidate="txtDateofBirth"
                            ErrorMessage="Required Date of Birth" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDateofBirth"
                            Display="Dynamic" ErrorMessage="Incorrect Date of Birth" MaximumValue="01/01/2099"
                            MinimumValue="01/01/1900" Type="Date"></asp:RangeValidator></div>
                </div>
                <%--Gender--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <asp:Label ID="lblGender" runat="server" AssociatedControlID="ddlGender" Text="Gender"></asp:Label>
                        <asp:Label ID="reqGender" runat="server" ForeColor="Red" Text="*" AssociatedControlID="ddlGender"></asp:Label></div>
                    <div class="InputValue">
                        <asp:DropDownList ID="ddlGender" runat="server" Width="215px" CssClass="FontSmall">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="reqvaildGender" runat="server" ControlToValidate="ddlGender"
                            ErrorMessage="Required Gender" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Marital Status--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <asp:Label ID="lblMaritalStatus" runat="server" AssociatedControlID="ddlMaritalStatus"
                            Text="Marital Status"></asp:Label>
                        <asp:Label ID="reqMaritalStatus" runat="server" ForeColor="Red" Text="*" AssociatedControlID="ddlMaritalStatus"></asp:Label></div>
                    <div class="InputValue">
                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="215px" CssClass="FontSmall">
                        </asp:DropDownList></div>
                    <div class="InputValidator">
                        <div class="InputValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMaritalStatus"
                                ErrorMessage="Required Marital Status" Display="Dynamic" InitialValue="x"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="Blank10">
                        &nbsp;
                    </div>
                </div>
                <%--Buttons--%>
                <div class="InputRow" style="">
                    &nbsp;<asp:Button ID="btnBack" runat="server" CausesValidation="False" OnClick="btnBack_Click"
                        Style="width: 75px" Text="Back" />
                    <asp:Button ID="btnNext" runat="server" Text="Save & Next" OnClick="nextButton_Click" Width="100px" /></div>
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
