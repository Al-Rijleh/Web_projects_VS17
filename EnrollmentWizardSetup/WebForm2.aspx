<%@ Register TagPrefix="qsf" Namespace="Telerik.QuickStart" %>
<%@ Register TagPrefix="qsf" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="qsf" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="qsf" TagName="Footer" Src="~/Common/Footer.ascx" %>

<%@ Page Language="c#" CodeFile="DefaultCS.aspx.cs" AutoEventWireup="true" Inherits="Telerik.Web.Examples.PanelBar.ApplicationScenarios.AccessingNestedControls.DefaultCS" %>

<%@ Register Src="PreviewCS.ascx" TagName="PreviewCS" TagPrefix="uc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <qsf:HeadTag ID="Headtag1" runat="server"></qsf:HeadTag>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body class="BODY">    
    <form id="mainForm" method="post" runat="server">
        <telerik:RadScriptManager ID="ScriptManager" runat="server" />
        <qsf:Header ID="Header1" runat="server" NavigationLanguage="C#"></qsf:Header>
        
        <img src="images/registration-header.gif" alt="Registration" />
        
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            <telerik:RadPanelBar runat="server" ID="RadPanelBar1" ExpandMode="SingleExpandedItem" Width="740px">
                <Items>
                    <telerik:RadPanelItem Expanded="True" Text="Step 1: Account Information" runat="server" Selected="true">
                        <Items>
                            <telerik:RadPanelItem Value="AccountInformation" runat="server">
                                <ItemTemplate>
                                    <div class="text" style="background-color: #edf9fe">
                                        <ul class="formList" id="accountInfo">
                                            <li>
                                                <asp:Label runat="server" ID="nameLabel" AssociatedControlID="accountName">Account Name:</asp:Label>
<asp:TextBox ID="accountName" CssClass="textInput" runat="server" ValidationGroup="accountValidation"
Width="200px"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ID="accountValidator" ValidationGroup="accountValidation"
ControlToValidate="accountName" ErrorMessage="Account name is required" Text="*"></asp:RequiredFieldValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="Label1" AssociatedControlID="Password">Password:</asp:Label>
<asp:TextBox ID="password" CssClass="textInput" TextMode="Password" ValidationGroup="accountValidation"
runat="server" Width="140px"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ValidationGroup="accountValidation" ID="passwordValidator"
ControlToValidate="password" ErrorMessage="Password is required" Text="*"></asp:RequiredFieldValidator>
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="Label2" AssociatedControlID="cPassword">Confirm Password:</asp:Label>
<asp:TextBox TextMode="Password" CssClass="textInput" ValidationGroup="accountValidation" ID="cPassword"
runat="server" Width="140px"></asp:TextBox>
<asp:RequiredFieldValidator runat="server" ValidationGroup="accountValidation" ID="RequiredFieldValidator2"
ControlToValidate="cPassword" ErrorMessage="Password is required" Text="*"></asp:RequiredFieldValidator>
                                            </li>
                                            <li class="lastListItem">
                                                <asp:Label runat="server" ID="Label3" AssociatedControlID="email">Email:</asp:Label>
                                                <asp:TextBox ID="email" ValidationGroup="accountValidation" CssClass="textInput" runat="server" Width="200px"></asp:TextBox>
<asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
ErrorMessage="Please enter a valid e-mail address." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
ControlToValidate="Email" ValidationGroup="accountValidation">
                                                </asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
ControlToValidate="Email" ErrorMessage="E-mail is required" Text="*" ValidationGroup="accountValidation" />
                                            </li>
                                        </ul>
                                        <br />
                                        <asp:ValidationSummary runat="server" ID="validationSummary" CssClass="validationSummary" />
<asp:Button runat="server" ID="nextButton" OnClick="nextButton_Click" Text="Next"
CssClass="nextButton" ValidationGroup="accountValidation" /><br />
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Enabled="False" Text="Step 2: Newsletter options" runat="server">
                        <Items>
                            <telerik:RadPanelItem Value="NewsletterOptions" runat="server">
                                    <ItemTemplate>
                                    <div class="text" style="background-color: #edf9fe">
                                        <ul class="formList" id="newsletterOptions">
                                            <li>Receive email notification for:</li>
                                            <li>
                                                <asp:CheckBox runat="server" ID="productUpdates" /><asp:Label ID="Label5" CssClass="checkboxLabel" runat="server" AssociatedControlID="productUpdates">Product Updates</asp:Label>
                                            </li>
                                            <li>
                                                <asp:CheckBox runat="server" ID="promotions" /><asp:Label ID="Label4" CssClass="checkboxLabel" runat="server" AssociatedControlID="promotions">Promotions</asp:Label>
                                            </li>
                                            <li class="lastListItem">
                                                <asp:CheckBox runat="server" ID="corporateNews" /><asp:Label ID="Label6" CssClass="checkboxLabel" runat="server" AssociatedControlID="corporateNews">Corporate News</asp:Label>
                                            </li>
                                        </ul>
                                        <br />
<asp:Button runat="server" ID="nextButton" OnClick="nextButton_Click" Text="Next"
CssClass="nextButton" /><br /><br />
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Enabled="False" Text="Step 3: Terms of use" runat="server">
                        <Items>
                            <telerik:RadPanelItem Value="Register" runat="server">
                                <ItemTemplate>
                                    <div class="text" style="background-color: #edf9fe">
                                        <ul class="formList" id="termsOfUse">
                                            <li class="lastListItem">
                                                <img src="Images/terms.gif" alt="sample terms" width="550" height="224" />
                                                <br /><br />
                                                <asp:CheckBox runat="server" ID="termsCheckBox" /><asp:Label ID="Label7" runat="server" CssClass="checkboxLabel" AssociatedControlID="termsCheckBox">I agree to the Terms &amp; Conditions</asp:Label>
                                                <asp:CustomValidator runat="server" ValidationGroup="registerGroup" ErrorMessage="You should agree with the terms and conditions.!" ClientValidationFunction="validateTerms" ID="termsValidator" Text="*" />
                                                <br />
<asp:Button runat="server" ID="registerButton" ValidationGroup="registerGroup" OnClick="registerButton_Click"
Text="Register" CssClass="nextButton" />
                                                <br /><br />
                                            </li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
                <CollapseAnimation Duration="100" Type="None" />
                <ExpandAnimation Duration="100" Type="None" />
            </telerik:RadPanelBar>
            <br />
            <uc1:PreviewCS ID="previewControl" runat="server" Visible="false" />
            
            <asp:Button runat="server" ID="backButton" Visible="false" CssClass="qsfButton" Text="Back" OnClick="backButton_Click" style="margin: 10px 0 30px 25px" />
        </telerik:RadAjaxPanel>
        
        <qsf:Footer ID="Footer1" runat="server"></qsf:Footer>
    </form>

    <script type="text/javascript">
        
        function validateTerms(source, args)
        {
            var checkbox = '<%=((CheckBox)RadPanelBar1.Items[2].Items[0].FindControl("termsCheckBox")).ClientID%>';
            args.IsValid = $get(checkbox).checked;
        }
    </script>
</body>
</html>
