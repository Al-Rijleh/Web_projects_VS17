<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HSA_Inf.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Layout.css" rel="stylesheet" type="text/css" />
    <link href="main2.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
        // <![CDATA[

        function htmbtnNextrdEmployeeInfo_onclick() {
            var b = document.getElementById("rdEmployeeInfo");
            alert(b);
            b.Collapsed = false;
            b.focus();
        }

        function closepage() {
            alert("Employee Does not have High Deductible Coverage");
            window.open("/WEB_PROJECTS/DEMOGRAPHICSPAGE/DEFAULT.ASPX?SkipCheck=YES", '_self');
        }

        function closepage2() {
            alert("Employee is not eligible  for HSA");
            window.open("/WEB_PROJECTS/DEMOGRAPHICSPAGE/DEFAULT.ASPX?SkipCheck=YES", '_self');
        }

        function docloseWindow(id) {
            closeWindow(id); return false;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow(id) {
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }

        function PlaincloseWindow() {
            var currentWindow = GetRadWindow();

            currentWindow.Close();
        }





        function OnClientclose(radWindow) {
            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument;
            if (retcode == "1") {
                radWindow.argument = 0;
                var btn = document.getElementById("rdHSABeneficiaryInformation_C_btnHSABeneficiaryInformation");
                btn.focus();
            }
            if (retcode == "0") {
                radWindow.argument = 0;
                var hid = document.getElementById("hid1");
                hid.value = 'ref';
                __doPostBack(null, null);
            }
        }
        function myFunction() {
            window.print();
        }

        // ]]>
    </script>
    <style type="text/css">
        #form1 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hidPayDate" runat="server" />
        <asp:HiddenField ID="hidErCont" runat="server" />
        <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnNextAdditinalIno">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnNextAdditinalIno" 
                        UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="rdHSABankingInformation" 
                        UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        
    </telerik:RadAjaxManager>--%>
        <div id="Div5" class="HSAOut" style="text-align: right; padding-right: 10px">

            <asp:HyperLink ID="hlPrint" runat="server" CssClass="FontSmall10" Font-Bold="True"
                NavigateUrl="Javascript:myFunction()" ToolTip="Print">Print</asp:HyperLink>
        </div>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"></asp:ValidationSummary>
        <div class="HSAOut">
            <div class="HSAitem">
                <div class="HSAcontent HSAcontentmarginbottom5">
                    <asp:Label ID="lblPageTitle" runat="server" Text="HSA Information" CssClass="pageTitle"></asp:Label>
                </div>
                <div class="HSAcontent HSAcontentmarginbottom5">
                    <asp:Label ID="lblInstruction" runat="server" CssClass="textFont">You must complete the information in this form to enroll in the HSA. If you do not complete the information on this form (you click the Cancel button below or do not save this form), your HSA election will be set to Waived. Beginning with the Additional Information Required by Gulf Cost Bank section below, click on the Next button to move into the next data entry section.
                    </asp:Label>
                </div>
            </div>



            <%--Blocks--%>
            <div class="HSAitem">
                <telerik:RadDockZone runat="server" ID="RadDockZone1" CssClass="HSAitemLeft zoneBoxborder RadDockZone"
                    Width="550px">
                    <telerik:RadDock runat="server" ID="rdEmployeeInfo" Title="Employee" EnableAnimation="true"
                        EnableRoundedCorners="true" AutoPostBack="true" Width="550px" EnableDrag="False"
                        DefaultCommands="None" CssClass="rdTable">
                        <ContentTemplate>
                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblFullNameTitle" runat="server" CssClass="textFont"> Full Name</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <asp:Label ID="lblName" runat="server" CssClass="textFont"> </asp:Label>
                                </div>
                            </div>
                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblEmployerTitle" runat="server" CssClass="textFont"> Employer</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <asp:Label ID="lblEmployer" runat="server" CssClass="textFont"> </asp:Label>
                                </div>
                            </div>

                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblHSA_Account_NumberTitle" runat="server" CssClass="textFont">HSA Account Number</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <asp:Label ID="lblHSA_Account_NumberValues" runat="server" CssClass="textFont"> </asp:Label>
                                </div>
                            </div>

                            <div id="dveditaccnt" runat="server" class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblHSA_Account_NumberTitleEdit" runat="server" CssClass="textFont">Add/EditHSA Account Number</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <asp:TextBox ID="txtBankAccountNumber" runat="server"></asp:TextBox>
                                    <input id="htmHtnSave" type="button" value="Save" onclick="return htmHtnSave_onclick()" />
                                </div>
                            </div>


                        </ContentTemplate>
                    </telerik:RadDock>

                    <telerik:RadDock runat="server" ID="rdBank" Title="Additional Information Required by HAS Bank" EnableAnimation="true"
                        EnableRoundedCorners="true" AutoPostBack="true" Width="550px" EnableDrag="False"
                        DefaultCommands="ExpandCollapse" Style="margin-top: 5px;">
                        <ContentTemplate>
                            <%--Home Phone--%>
                            <div class="HSAcontent " style="margin-top: 10px">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblHomePhone" runat="server" CssClass="textFont">Home Phone</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <telerik:RadMaskedTextBox ID="txtHomePhone" runat="server"
                                        Mask="(###) ###-####" Rows="1" RequireCompleteText="True">
                                    </telerik:RadMaskedTextBox>
                                    <asp:RequiredFieldValidator ID="req1" runat="server"
                                        ControlToValidate="txtHomePhone" CssClass="errorRed"
                                        ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="HSAitemLeft" style="width: 535px">
                                <hr />
                            </div>
                            <%-- Employer's Phone*--%>
                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblERPhone" runat="server" CssClass="textFont">Employer's Phone</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <telerik:RadMaskedTextBox ID="txtERPhone" runat="server"
                                        Mask="(###) ###-####" Rows="1" RequireCompleteText="True">
                                    </telerik:RadMaskedTextBox>
                                    <asp:RequiredFieldValidator ID="req2" runat="server"
                                        ControlToValidate="txtERPhone" CssClass="errorRed" ErrorMessage="Required"
                                        ValidationGroup="1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%--Length of Employment (years)*--%>
                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblLengthOfEmployment" runat="server" CssClass="textFont">Length of Employment (years)</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <asp:TextBox ID="txtLengthOfEmployment" runat="server" Width="155px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req3" runat="server"
                                        ControlToValidate="txtLengthOfEmployment" CssClass="errorRed"
                                        ErrorMessage="Required" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server"
                                        ControlToValidate="txtLengthOfEmployment" CssClass="errorRed" Display="Dynamic"
                                        ErrorMessage="Must be an  Integer" MaximumValue="99" MinimumValue="0"
                                        Type="Integer"></asp:RangeValidator>
                                </div>
                            </div>

                            <div class="HSAitemLeft" style="width: 535px">
                                <hr />
                            </div>

                            <%-- Driver's License Issuing State--%>
                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblDriversLicenseIssuingState" runat="server" CssClass="textFont">Driver's License Issuing State</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <telerik:RadComboBox ID="ddlLicState" runat="server"
                                        CheckedItemsTexts="DisplayAllInInput" MarkFirstMatch="True">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="req4" runat="server"
                                        ControlToValidate="ddlLicState" CssClass="errorRed"
                                        ErrorMessage="Required" InitialValue="-- Select --" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%-- Driver's License No.*--%>
                            <div class="HSAcontent ">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblDriverLicenseNo" runat="server" CssClass="textFont">Driver's License No.</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <telerik:RadTextBox ID="txtDriverLicenseNo" runat="server" MaxLength="10">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="req5" runat="server"
                                        ControlToValidate="txtDriverLicenseNo" CssClass="errorRed"
                                        ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <%-- Driver's License Effective Date*--%>
                            <telerik:RadAjaxPanel ID="RadAjaxPanel4" runat="server" Height="50px" Width="500px">
                                <div class="HSAcontent ">
                                    <div class="HSAlabel">
                                        <asp:Label ID="lblDriversLicenseEffectiveDate" runat="server" CssClass="textFont">Driver's License Effective Date</asp:Label>
                                    </div>
                                    <div class="HSAInput">
                                        <telerik:RadDatePicker ID="txtDriversLicenseEffectiveDate" runat="server"
                                            AutoPostBack="True"
                                            OnSelectedDateChanged="txtDriversLicenseEffectiveDate_SelectedDateChanged">
                                            <Calendar EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;"
                                                UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput AutoPostBack="True" DateFormat="M/d/yyyy"
                                                DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle Resize="None" />
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="req6" runat="server"
                                            ControlToValidate="txtDriversLicenseEffectiveDate" CssClass="errorRed"
                                            ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <%-- Driver's License Expiration Date*--%>
                                <div class="HSAcontent ">
                                    <div class="HSAlabel">
                                        <asp:Label ID="lblDriversLicenseExpirationDate" runat="server" CssClass="textFont">Driver's License Expiration Date</asp:Label>
                                    </div>
                                    <div class="HSAInput">
                                        <telerik:RadDatePicker ID="txtDriversLicenseExpirationDate" runat="server">
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="req7" runat="server"
                                            ControlToValidate="txtDriversLicenseExpirationDate" CssClass="errorRed"
                                            ErrorMessage="Required" ValidationGroup="1" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblMinDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </telerik:RadAjaxPanel>
                            <%-- Next button--%>
                            <div class="HSAcontent " style="margin-top: 10px">
                                <div style="text-align: center">
                                    <asp:Button ID="btnNextAdditinalIno" runat="server"
                                        OnClick="btnNextAdditinalIno_Click" Text="Next" ValidationGroup="1" />
                                    &nbsp;
                                </div>
                            </div>
                        </ContentTemplate>
                    </telerik:RadDock>


                    <telerik:RadDock runat="server" ID="rdHSABankingInformation" Title="<SPAN Font-size: 10pt; color:#964B4B; font-weight:bolder> HSA Banking Information</SPAN>"
                        EnableAnimation="true" EnableRoundedCorners="true" AutoPostBack="true" Width="550px"
                        EnableDrag="False" DefaultCommands="ExpandCollapse" Style="margin-top: 5px;">
                        <ContentTemplate>
                            <%-- Driver's License No.*--%>
                            <div class="HSAcontent " style="margin-top: 10px">
                                <div class="HSAlabel">
                                    <asp:Label ID="lblYourOccupation" runat="server" CssClass="textFont">Your Occupation</asp:Label>
                                </div>
                                <div class="HSAInput">
                                    <telerik:RadTextBox ID="txtYourOccupation" runat="server" MaxLength="30">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="req8" runat="server"
                                        ControlToValidate="txtYourOccupation" CssClass="errorRed"
                                        ErrorMessage="Required" ValidationGroup="2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server" Height="60px" Width="500px" Visible="False">

                                <%-- Are you the citzen of a Foreign Country?*--%>
                                <div class="HSAcontent ">
                                    <div class="HSAlabel" style="margin-top: 5px">
                                        <asp:Label ID="lblcitzenofForeignCountry" runat="server" CssClass="textFont">Are you the citzen of a Foreign Country?</asp:Label>
                                    </div>
                                    <div class="HSAInput">
                                        <div style="width: 229px">
                                            <asp:RadioButtonList ID="rblcitzenofForeignCountry" runat="server" CssClass="textFont"
                                                RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblcitzenofForeignCountry_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>

                                <%-- What Country*--%>
                                <div class="HSAcontent ">
                                    <div class="HSAlabel">
                                        <asp:Label ID="lblWhatCountry" runat="server" CssClass="textFont" Style="padding-right: 20px; float: right">If "Yes," What Country</asp:Label>
                                    </div>
                                    <div class="HSAInput">
                                        <telerik:RadComboBox ID="ddlCountry" runat="server"
                                            CheckedItemsTexts="DisplayAllInInput" MarkFirstMatch="True">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="req9" runat="server"
                                            ControlToValidate="ddlCountry" CssClass="errorRed"
                                            ErrorMessage="Required" InitialValue="-- Select --" ValidationGroup="2"
                                            Enabled="False"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </telerik:RadAjaxPanel>

                            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="90px" Width="500px" Visible="False">

                                <%-- Have you ever held any senior political, military, or judicial office with a foreign country?--%>
                                <div class="HSAcontent ">
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel" style="margin-top: 5px">
                                            <asp:Label ID="lblforeignoffice" runat="server" CssClass="textFont">Have you ever held any senior political, military, or judicial office with a foreign country?</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <div style="width: 229px">
                                                <asp:RadioButtonList ID="rblforeignoffice" runat="server" CssClass="textFont"
                                                    RepeatDirection="Horizontal" AutoPostBack="True"
                                                    OnSelectedIndexChanged="rblforeignoffice_SelectedIndexChanged" Style="margin-top: 15px">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- If "Yes," What Position*--%>
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel">
                                            <asp:Label ID="lblWhatPosition" runat="server" CssClass="textFont" Style="padding-right: 20px; float: right">If "Yes," What Position</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <telerik:RadTextBox ID="txtWhatPosition" runat="server" MaxLength="50">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="req10" runat="server"
                                                ControlToValidate="txtWhatPosition" CssClass="errorRed"
                                                ErrorMessage="Required" Enabled="False" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <%-- If "Yes," What Country*--%>
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel">
                                            <asp:Label ID="lbloreignCountry" runat="server" CssClass="textFont" Style="padding-right: 20px; float: right">If "Yes," What Country</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <telerik:RadComboBox ID="ddloreignCountry" runat="server"
                                                CheckedItemsTexts="DisplayAllInInput" MarkFirstMatch="True">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="req11" runat="server"
                                                ControlToValidate="ddloreignCountry" CssClass="errorRed"
                                                ErrorMessage="Required" InitialValue="-- Select --" ValidationGroup="2"
                                                Enabled="False"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </telerik:RadAjaxPanel>

                            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Height="175px" Width="500px" Visible="False">


                                <%--Do you have any immediate family members or close associates who has held any senior political, military, or judicial office with a foreign country?--%>

                                <div class="HSAcontent ">
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel" style="margin-top: 5px">
                                            <asp:Label ID="lblFamilyOffice" runat="server" CssClass="textFont">Do you have any immediate family members or close associates who has held any senior political, military, or judicial office with a foreign country?</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <div style="width: 229px">
                                                <asp:RadioButtonList ID="rblFamilyOffice" runat="server" CssClass="textFont"
                                                    RepeatDirection="Horizontal" AutoPostBack="True"
                                                    Style="margin-top: 25px"
                                                    OnSelectedIndexChanged="rblFamilyOffice_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- If "Yes," what is his/her First name?--%>
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel">
                                            <asp:Label ID="lblFamilyOfficeFirstName" runat="server" CssClass="textFont"
                                                Style="padding-right: 20px; float: right">If "Yes," what is the first name</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <telerik:RadTextBox ID="txtFamilyOfficeFirstName" runat="server" MaxLength="15">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="req12" runat="server"
                                                ControlToValidate="txtFamilyOfficeFirstName" CssClass="errorRed"
                                                ErrorMessage="Required" Enabled="False" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <%-- If "Yes," what is his/her Last name?--%>
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel">
                                            <asp:Label ID="lblFamilyOfficeLastName" runat="server" CssClass="textFont"
                                                Style="padding-right: 20px; float: right">If "Yes," what is the last name</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <telerik:RadTextBox ID="txtFamilyOfficeLastName" runat="server" MaxLength="20">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="req13" runat="server"
                                                ControlToValidate="txtFamilyOfficeLastName" CssClass="errorRed"
                                                ErrorMessage="Required" Enabled="False" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <%-- If "Yes," What Position*--%>
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel">
                                            <asp:Label ID="lblFamilyOfficePosition" runat="server" CssClass="textFont"
                                                Style="padding-right: 20px; float: right">If "Yes," What Position</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <telerik:RadTextBox ID="txtFamilyOffice" runat="server" MaxLength="50">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="req14" runat="server"
                                                ControlToValidate="txtFamilyOffice" CssClass="errorRed"
                                                ErrorMessage="Required" Enabled="False" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <%-- If "Yes," What Country*--%>
                                    <div class="HSAcontent ">
                                        <div class="HSAlabel">
                                            <asp:Label ID="lblFamilyOfficeCountry" runat="server" CssClass="textFont"
                                                Style="padding-right: 20px; float: right">If "Yes," What Country</asp:Label>
                                        </div>
                                        <div class="HSAInput">
                                            <telerik:RadComboBox ID="ddlFamilyOffice" runat="server"
                                                CheckedItemsTexts="DisplayAllInInput" MarkFirstMatch="True">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="req15" runat="server"
                                                ControlToValidate="ddlFamilyOffice" CssClass="errorRed"
                                                ErrorMessage="Required" InitialValue="-- Select --" ValidationGroup="2"
                                                Enabled="False"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </telerik:RadAjaxPanel>

                            <%-- Next button--%>
                            <div class="HSAcontent " style="margin-top: 10px">
                                <div style="text-align: center">
                                    <asp:Button ID="btnHSABankingInformation" runat="server"
                                        Text="Next" ValidationGroup="2" OnClick="btnHSABankingInformation_Click" />
                                    &nbsp;
                                </div>
                            </div>
                        </ContentTemplate>
                    </telerik:RadDock>


                    <telerik:RadDock runat="server" ID="rdHSABeneficiaryInformation" Title=""
                        EnableAnimation="true" EnableRoundedCorners="true" AutoPostBack="true" Width="550px"
                        EnableDrag="False" DefaultCommands="ExpandCollapse" Style="margin-top: 5px;">
                        <ContentTemplate>
                            <%-- Information--%>
                            <div class="HSAcontent ">
                                <asp:Label ID="lbHSABeneficiaryInformation" runat="server" CssClass="textFont"></asp:Label>
                            </div>
                            <div class="HSAcontent ">
                                <asp:Label ID="lblBeneficiaryError" runat="server" CssClass="errorRed"
                                    Font-Bold="True">Beneficiaries do not add up to 100%</asp:Label>
                            </div>
                            <div class="HSAcontent " style="text-align: center">
                                <asp:Button ID="btnGoToBebefiries" runat="server"
                                    OnClick="btnGoToBebefiries_Click"
                                    Text="Click this button to enter your Beneficiaries " />
                            </div>

                            <div id="dvBebefiries" runat="server" class="HSAcontent " style="text-align: center">
                                <iframe id="iBeneficiaries" runat="server" frameborder="0" name="Beneficiaries_frame"
                                    scrolling="auto"
                                    title="Beneficiaries_frame" class="HSAcontent" style="height: 400px"
                                    visible="False" src="Beneficiaries.aspx"></iframe>
                                <div class="HSAcontent " style="text-align: center">
                                    <asp:Button ID="btnDomeBenefit" runat="server"
                                        OnClick="btnDomeBenefit_Click"
                                        Text="Done Close This Page" />
                                </div>
                            </div>

                            <%-- Next button--%>
                            <div class="HSAcontent " style="margin-top: 10px">
                                <div style="text-align: center">
                                    <asp:Button ID="btnHSABeneficiaryInformation" runat="server"
                                        Text="Next" OnClick="btnHSABeneficiaryInformation_Click" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </telerik:RadDock>


                    <telerik:RadDock runat="server" ID="rdHSAInformation" Title=""
                        EnableAnimation="true" EnableRoundedCorners="true" AutoPostBack="true" Width="550px"
                        EnableDrag="False" DefaultCommands="ExpandCollapse" Style="margin-top: 5px;">
                        <ContentTemplate>
                            <%-- MONTHLY Employer Contribution--%>
                            <div class="HSAcontent ">
                                <div class="HSAlabelWide">
                                    <asp:Label ID="lblHSAInformationErContTitle" runat="server" CssClass="textFont"
                                        Font-Bold="True">MONTHLY Employer Contribution</asp:Label>
                                </div>
                                <div class="HSAInputnarrow">
                                    <asp:Label ID="lblHSAInformationErContValue" runat="server" CssClass="textFont">$9,999.00</asp:Label>
                                </div>
                            </div>
                            <%-- MONTHLY Employee Contribution--%>
                            <div class="HSAcontent ">
                                <div class="HSAlabelWide">
                                    <asp:Label ID="lblHSAInformationEeContTitle" runat="server" CssClass="textFont"
                                        Font-Bold="True">MONTHLY Employee Contribution</asp:Label>
                                </div>
                                <div class="HSAInputnarrow">

                                    <telerik:RadNumericTextBox ID="txtHSAInformationEeContTitle" runat="server" EmptyMessage="Dollar Amount"
                                        AllowOutOfRangeAutoCorrect="False" MaxValue="10000"
                                        MinValue="0" Width="100px" Type="Currency" onkeyup="cost(this)">
                                        <NegativeStyle Resize="None" />
                                        <NumberFormat DecimalDigits="2" ZeroPattern="n" />
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </telerik:RadNumericTextBox>





                                    <asp:RequiredFieldValidator ID="req16" runat="server"
                                        ControlToValidate="txtHSAInformationEeContTitle" CssClass="errorRed"
                                        ErrorMessage="Required" ValidationGroup="4" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:Label ID="lblMaxSelection" runat="server"></asp:Label>
                                </div>
                            </div>
                            <%-- TOTAL MONTHLY CONTRIBUTION*--%>
                            <div class="HSAcontent HSAcontentmarginbottom5">
                                <div class="HSAlabelWide">
                                    <asp:Label ID="lblTOTALMONTHLYCONTRIBUTIONTtile" runat="server"
                                        CssClass="textFont" Font-Bold="True">TOTAL MONTHLY CONTRIBUTION</asp:Label>
                                </div>
                                <div class="HSAInputnarrow">
                                    <asp:TextBox ID="txtTOTALMONTHLYCONTRIBUTIONTValue" runat="server"
                                        BorderStyle="None" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <%-- Information sec 1--%>
                            <div class="HSAcontent HSAcontentmarginbottom5">
                                <asp:Label ID="lblHSAInformationSec1" runat="server" CssClass="textFont"></asp:Label>
                            </div>
                            <%-- Information sec 2--%>
                            <div class="HSAcontent HSAcontentmarginbottom5">
                                <asp:Label ID="lblHSAInformationSec2" runat="server" CssClass="textFont"></asp:Label>
                            </div>
                            <%-- Information sec 3--%>
                            <div class="HSAcontent ">
                                <asp:Label ID="lblHSAInformationSec3" runat="server" CssClass="textFont"></asp:Label>
                            </div>

                        </ContentTemplate>
                    </telerik:RadDock>

                </telerik:RadDockZone>




            </div>

            <div class="HSAitem HSAcontentmargintop10">
                <div class="HSAcontent HSAcontentmarginbottom5">
                    <asp:Label ID="lblEmployeeSignature" runat="server" CssClass="dataSetctionTitle"
                        Font-Bold="True">Employee Signature</asp:Label>
                </div>
                <%-- Password--%>
                <div class="HSAcontent ">
                    <div class="HSAlabel">
                        <asp:Label ID="lblPassword" runat="server" CssClass="textFont" Font-Bold="True">MyEnroll Password</asp:Label>
                    </div>
                    <div class="HSAInput">
                        <telerik:RadTextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password">
                        </telerik:RadTextBox>
                        <asp:Label ID="lblIncorrectPassword" runat="server" CssClass="errorRed"
                            Font-Bold="True">Incorrect Password</asp:Label>
                    </div>

                    <div class="HSAcontent HSAcontentmargintop10">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px"
                            CausesValidation="False" OnClick="btnCancel_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px"
                        OnClick="btnSave_Click" />
                    </div>
                </div>


            </div>
        </div>
        <asp:HiddenField ID="hidSaveAccount" runat="server" />
    </form>
    <script type="text/javascript">
        function cost(radText) {
            //alert('here');
            var numberofpays = document.getElementById("<%= hidPayDate.ClientID %>").value;
            var erCont = document.getElementById("<%= hidErCont.ClientID %>").value;
            //alert(numberofpays);
            var amount = radText.value
            //alert(amount);
            amount = amount.replace(',', '');
            var perpaycost = parseFloat(amount) + parseFloat(erCont);
            perpaycost = parseFloat(perpaycost).toFixed(2);
            //alert(perpaycost);
            document.getElementById("<%= txtTOTALMONTHLYCONTRIBUTIONTValue.ClientID %>").value = '$' + perpaycost;

        }
        function htmHtnSave_onclick() {
            var accntNum = document.getElementById("<%= txtBankAccountNumber.ClientID %>").value;
            var ok = confirm('Are you sure you want save this Bank Account Number (' + accntNum + ')');
            if (ok) {
                document.getElementById("<%= hidSaveAccount.ClientID %>").value = 'Go';
                __doPostBack(null, null)
            }
        }

    </script>
</body>
</html>
