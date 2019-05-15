<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherHSAPage.aspx.cs" Inherits="HSA_Inf.OtherHSAPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main2.css" rel="stylesheet" type="text/css" />
    <link href="Layout.css" rel="stylesheet" type="text/css" />
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
 

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="HSAitem">
            <div class="HSAcontent HSAcontentmarginbottom5">
                <asp:Label ID="lblPageTitle" runat="server" Text="HSA Information" CssClass="pageTitle"></asp:Label>
            </div>
            <div class="HSAcontent HSAcontentmarginbottom5">
                <asp:Label ID="lblInstruction" runat="server" CssClass="textFont">
                        <p>You have selected the High Deductible Insurance option, and with this
election you can choose to contribute to a Health Savings Account (HSA).
This allows pre-tax dollars to be used for any qualified medical, dental or vision unreimbursed expenses. </p>

<p>For [py] the IRS has set contribution limits at [sng] for Employee Only and [fm] for Employee + Dependent(s). 
If you are age 55 or older at any time during [py], you can contribute an additional $1,000. 
Contributions made to this account roll over from year to year without losing the funds.</p>  

                </asp:Label>
            </div>
            <div class="HSAitem HSAcontentmarginbottom5">
            <asp:Label ID="lblContribution" runat="server" Text="Enter Annual Contribution" 
                    Width="145px"></asp:Label>
                <telerik:RadNumericTextBox ID="txtContribution" runat="server" 
                    LabelWidth="" MinValue="1" Width="90px" EmptyMessage="Enter Contribution">
                </telerik:RadNumericTextBox>
                &nbsp;&nbsp;<asp:Label ID="lblNaxContiution" runat="server" Text="Label" Font-Bold="True" 
                    ForeColor="#990033"></asp:Label>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtContribution" CssClass="errorRed" Display="Dynamic" 
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
            <div class="HSAcontent HSAcontentmarginbottom5">
                <asp:Label ID="lblInstruction2" runat="server" >
                If you are interested in this option, please select below and the Bern 
and Pugh Rep will contact you for further instructions.
                </asp:Label>
            </div>
            <div class="HSAcontent HSAcontentmarginbottom5">
                <asp:LinkButton ID="lnkbtnYes" runat="server" Font-Bold="True" ForeColor="Navy" 
                    onclick="lnkbtnYes_Click">Yes - I wish to enroll in the HSA (Health Savings Account)</asp:LinkButton>
            </div>
            <div class="HSAcontent HSAcontentmarginbottom5">
                <asp:LinkButton ID="lnkbtnNo" runat="server" Font-Bold="True" ForeColor="Navy" 
                    onclick="lnkbtnNo_Click" CausesValidation="False">No  - I do not wish to contribute to the HSA (Health Savings Account)</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
