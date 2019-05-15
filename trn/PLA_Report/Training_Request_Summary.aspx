<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Training_Request_Summary.aspx.cs" Inherits="PLA_Report.Training_Request_Summary" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Professional Learning Account - Training Request Summary</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <script src="/js/dFilter.js" type="text/javascript"></script>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <script src="/js/StyleSetter.js" type="text/javascript"></script>
    <script src="/js/BAS_Utility.js" type="text/javascript"></script>
    <style type='text/css'>
        P.pagebreakhere {
            page-break-before: always;
        }
    </style>
    <script type="text/javascript">
        function Getpage() {
            var txt = eval(document.getElementById("test")).innerHTML;
            alert(txt);
            var txt2 = txt.replace(/</g, '&lt;');
            txt2 = txt2.replace('>', '&gt;');
            eval(document.getElementById("eld1")).value = eval + (document.getElementById("eld1")).value + txt2;
            alert(eval(document.getElementById("eld1")).value);
            PostBack();
        }
        function PostBack() {
            var theForm = document.forms['aspnetForm'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="eld1" runat="server" />
        <asp:HiddenField ID="hidGo" runat="server" />
        <asp:HiddenField ID="hidWhat" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <div id="dvPage" runat="server">
            <asp:Panel ID="Panel1" runat="server">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 600px" id="tbl">
                    <tr id="trCommand" runat="server"> 
                        <td align="right" style="width: 602px">&nbsp;&nbsp;
                    <asp:HyperLink ID="hlPrint" runat="server" CssClass="fontsmall" NavigateUrl="javascript:window.print()">Print</asp:HyperLink>
                            &nbsp; &nbsp;&nbsp; &nbsp;<asp:HyperLink ID="hlClose" runat="server" CssClass="fontsmall"
                                NavigateUrl="javascript:document.location.replace('/Web_Projects/trn/PLA/SelectApp.aspx?SkipCheck=YES')">Close the Print Page</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table style="width: 600px">
                                <tr>
                                    <td align="left" style="height: 80px">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/FDIC CU Logo.jpg" Width="125px" /></td>
                                    <td align="right" style="height: 80px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="myenroll_For_WhiteBackground.jpg" Width="200px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:Label ID="lblTitle" runat="server" CssClass="FontSmallTitle" Font-Bold="True"
                                Text="Professional Learning Account - Training Request Summary"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table style="width: 600px">
                                <tr>
                                    <td width="110">
                                        <asp:Label ID="Label1" runat="server" CssClass="fontsmall" Font-Bold="True" Text="Employee:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEmployeeName" runat="server" CssClass="fontsmall" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="110">
                                        <asp:Label ID="Label2" runat="server" CssClass="fontsmall" Font-Bold="True" Text="MyEnroll #:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEmployeeInfo" runat="server" CssClass="fontsmall" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="110">
                                        <asp:Label ID="Label3" runat="server" CssClass="fontsmall" Font-Bold="True" Text="Duty Station:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEmployeeDutyStation" runat="server" CssClass="fontsmall" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="110">
                                        <asp:Label ID="Label28" runat="server" CssClass="fontsmall" Font-Bold="True" Text="Header ID:"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblHeaderID" runat="server" CssClass="fontsmall" Text="Label"></asp:Label></td>
                                </tr>
                            </table>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:Label ID="lblVendorTitle" runat="server" CssClass="fontmedium" Font-Underline="True"
                                Text="Vendor Information" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table id="Table12" border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr>
                                    <td style="width: 790px">
                                        <table id="Table11" border="0" cellpadding="0" cellspacing="0" width="600">
                                            <tr>
                                                <td width="250" style="height: 18px">
                                                    <asp:Label ID="Label20" runat="server" CssClass="fontsmall">Training Event Code</asp:Label></td>
                                                <td width="530" style="height: 18px">
                                                    <asp:Label ID="lbltxtCourseCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250" style="height: 18px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="fontsmall">Training Event Title</asp:Label></td>
                                                <td width="530" style="height: 18px">
                                                    <asp:Label ID="lbltxtCourseTitle" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label22" runat="server" CssClass="fontsmall">Vendor Name</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtVedorName" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label50" runat="server" CssClass="fontsmall">Vendor Contact</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtVendorContact" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label6" runat="server" CssClass="fontsmall">Vendor Telephone & Fax</asp:Label></td>
                                                <td style="height: 19px" width="530">
                                                    <asp:Label ID="lbltxtPhoneNumber" runat="server" Height="19px" CssClass="fontsmall"></asp:Label>
                                                    &nbsp;
                                            <asp:Label ID="lbltxtFaxNumber" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label7" runat="server" CssClass="fontsmall">Vendor Address Line 1</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtAddressLine1" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label8" runat="server" CssClass="fontsmall">Vendor Address Line 2</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtAddressLine2" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label9" runat="server" CssClass="fontsmall">Vendor City / State / Zip Code</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtCity" runat="server" CssClass="fontsmall"></asp:Label>
                                                    &nbsp;
                                            <asp:Label ID="lbltxtState" runat="server" CssClass="fontsmall"></asp:Label>
                                                    &nbsp;
                                            <asp:Label ID="lbltxtZipCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="Label24" runat="server" CssClass="fontsmall">Vendor Web Site</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtWebSite" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250" style="height: 18px">
                                                    <asp:Label ID="Label5" runat="server" CssClass="fontsmall">Vendor Email</asp:Label></td>
                                                <td width="530" style="height: 18px">
                                                    <asp:Label ID="lblEmail" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td height="10" width="250"></td>
                                                <td height="10" width="530"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label52" runat="server" CssClass="fontmedium" Font-Bold="True"
                                                        Font-Underline="True">Location of Training Site</asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="lblLearningAddress1" runat="server" CssClass="fontsmall">Address Line 1</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtLearningAddress1" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="lblLearningAddress2" runat="server" CssClass="fontsmall">Address Line 2</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtLearningAddress2" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <asp:Label ID="lblLearningCityState" runat="server" CssClass="fontsmall">City / State / Zip Code</asp:Label></td>
                                                <td width="530">
                                                    <asp:Label ID="lbltxtLearningCity" runat="server" CssClass="fontsmall"></asp:Label>
                                                    &nbsp;
                                            <asp:Label ID="lbltxtLearningState" runat="server" CssClass="fontsmall"></asp:Label>
                                                    &nbsp;
                                            <asp:Label ID="lbltxtLearningZipCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td height="10" width="250"></td>
                                                <td height="10" width="530"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblTitlePurposeoftraining" runat="server" CssClass="fontmedium"
                                                        Font-Bold="True" Font-Underline="True">Purpose of Training:</asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblPurposeofTraining" runat="server" Text="Label" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="10"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" width="250">
                                                    <asp:Label ID="lblTitleTrainingDateTime" runat="server" CssClass="fontmedium" Font-Bold="True"
                                                        Font-Underline="True">Training Dates & Times</asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" width="250">
                                                    <asp:Label ID="Label11" runat="server" CssClass="fontsmall">Training Starts</asp:Label></td>
                                                <td colspan="1" width="530">
                                                    <asp:Label ID="lblStratDate" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" style="height: 18px" width="250">
                                                    <asp:Label ID="Label12" runat="server" CssClass="fontsmall">Training Ends</asp:Label></td>
                                                <td colspan="1" style="height: 18px" width="530">
                                                    <asp:Label ID="lblEndDate" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" height="5" width="250"></td>
                                                <td colspan="1" width="530" height="5"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" width="250">
                                                    <asp:Label ID="Label13" runat="server" CssClass="fontsmall">Duty Hours</asp:Label></td>
                                                <td colspan="1" width="530">
                                                    <asp:Label ID="lblHourDuty" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" width="250">
                                                    <asp:Label ID="lbl" runat="server" CssClass="fontsmall">Non-Duty Hours</asp:Label></td>
                                                <td colspan="1" width="530">
                                                    <asp:Label ID="lblhournonduty" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" align="right" width="250">
                                                    <asp:Label ID="lbl2" runat="server" Text="Total" CssClass="fontsmall"></asp:Label>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td colspan="1" width="530">
                                                    <asp:Label ID="lblHourtotal" runat="server" CssClass="fontsmall"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" height="10" width="250"></td>
                                                <td colspan="1" width="530" style="height: 18px"></td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table id="tableType2008" border="0" cellpadding="0" cellspacing="0" style="width: 600px" runat="server">
                                <tr>
                                    <td colspan="2">
                                        <p class="pagebreakhere">
                                            <asp:Label ID="lblTitleTypesNeeds" runat="server" CssClass="fontmedium" Font-Bold="True"
                                                Font-Underline="True">Training Types & Needs</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label57" runat="server" CssClass="fontsmall">Department ID#</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtDepartmentID" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label55" runat="server" CssClass="fontsmall">Position Level</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtPositionLevel" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label53" runat="server" CssClass="fontsmall">Need Special Accomodation</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtAccomodation" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="lblAccomodationDescription" runat="server" CssClass="fontsmall">Accomodation Description</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtAccomodationDescription" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label49" runat="server" CssClass="fontsmall">Type of Appointment</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxTypeofAppointment" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label48" runat="server" CssClass="fontsmall">Training Purpose Type</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtPurposeOfTraining" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label47" runat="server" CssClass="fontsmall">Delivery Type Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtDelivaryTypeCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label15" runat="server" CssClass="fontsmall" ToolTip="Training Designation Type Code">Designation Type Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtDesignationTypeCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="lblTrainingCredit" runat="server" CssClass="fontsmall" ToolTip="Training Designation Type Code">Training Credit</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtTrainingCredit" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label45" runat="server" CssClass="fontsmall" ToolTip="Training Credit Type Code">Credit Type Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtCreditTypeCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label43" runat="server" CssClass="fontsmall" ToolTip="Is the Course Accredited ">Accreditation Indicator</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtAccredetionIndicator" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label41" runat="server" CssClass="fontsmall">Source of Training</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtSourseTraining" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label39" runat="server" CssClass="fontsmall">Account #</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtAccountNumber" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 18px; width: 250px;">
                                        <asp:Label ID="Label16" runat="server" CssClass="fontsmall">Education Level</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtEducationLevel" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label37" runat="server" CssClass="fontsmall" ToolTip="Training Type Code">Training Type Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtTrainingTypeCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label30" runat="server" CssClass="fontsmall" ToolTip="Training Sub-Type Code">Training Sub-Type Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtTrainingSubTypeCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 18px; width: 250px;">
                                        <asp:Label ID="lblTypeOfDevelopment" runat="server" CssClass="fontsmall" ToolTip="Type of Development">Type of Development</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtTypeOfDevelopmentSummary" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label38" runat="server" CssClass="fontsmall">Type of Development (other)</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtTypeofDevelopmentOther182" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="lblProgramCode" runat="server" CssClass="fontsmall">Program Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtProgramCode" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table id="TableTraining2007" border="0" cellpadding="0" cellspacing="0" runat="server" style="width: 600px">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label21" runat="server" CssClass="fontmedium" Font-Bold="True" Font-Underline="True">Training Types & Needs</asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px;">
                                        <asp:Label ID="Label10" runat="server" CssClass="fontsmall">Department ID#</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtDepartmentID2007" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label46" runat="server" CssClass="fontsmall">Program Code</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtProgramCode2007" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label19" runat="server" CssClass="fontsmall">Account #</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lblrbAccountNo" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label31" runat="server" CssClass="fontsmall">Source of Training</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtSource" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label23" runat="server" CssClass="fontsmall">Purpose of Training </asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtPurpose" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label25" runat="server" CssClass="fontsmall">Purpose of Training (other)</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtPurposeOfTainingOther" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 250px">
                                        <asp:Label ID="Label27" runat="server" CssClass="fontsmall">Type of Development</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lblTypeOdDevelopment2007" runat="server" CssClass="fontsmall"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 250px">
                                        <asp:Label ID="Label33" runat="server" CssClass="fontsmall">Type of Development (other)</asp:Label></td>
                                    <td width="530">
                                        <asp:Label ID="lbltxtTypeofDevelopmentOther" runat="server" CssClass="fontsmall"></asp:Label>
                                        <p class="pagebreakhere">
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10" style="width: 602px"></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:Label ID="Label14" runat="server" CssClass="fontmedium" Font-Bold="True"
                                Font-Underline="True">Training Expenses</asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:DataGrid ID="dgExpense" runat="server" AutoGenerateColumns="False" BorderColor="White"
                                CellPadding="3" CssClass="fontsmall" Width="600px">
                                <SelectedItemStyle BackColor="Yellow" />
                                <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" />
                                <Columns>
                                    <asp:BoundColumn DataField="expense_type" HeaderText="Expense Type">
                                        <HeaderStyle Width="225px" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="amount" DataFormatString="{0:C}" HeaderText="Estimated Amout">
                                        <HeaderStyle Width="125px" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="approved_amount" DataFormatString="{0:C}" HeaderText="Approved Amount">
                                        <HeaderStyle Width="125px" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="paid_amount" DataFormatString="{0:C}" HeaderText="Paid Amount">
                                        <HeaderStyle Width="125px" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                </Columns>
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                <tr>
                                    <td align="right" width="225">
                                        <asp:Label ID="Label17" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black">Total</asp:Label>
                                        &nbsp; &nbsp;
                                    </td>
                                    <td align="right" width="125">
                                        <asp:Label ID="lblAmount" runat="server" CssClass="fontsmall" Font-Bold="True" ForeColor="Black"></asp:Label></td>
                                    <td align="right" width="125">
                                        <asp:Label ID="lblApprovedAmount" runat="server" CssClass="fontsmall" Font-Bold="True"
                                            ForeColor="Black"></asp:Label></td>
                                    <td align="right" width="125">
                                        <asp:Label ID="lblTotalPaid" runat="server" CssClass="fontsmall" Font-Bold="True"
                                            ForeColor="Black"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:Label ID="lblExpenseNote" runat="server" CssClass="fontsmall" Text="Total excludes Travel Expense because such expenses are not deducted from PLA Balances."></asp:Label></td>
                    </tr>
                    <tr>
                        <td height="10" style="width: 602px"></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:Label ID="Label26" runat="server" CssClass="fontmedium" Font-Bold="True" Font-Underline="True">Training Expenses Notes</asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:DataGrid ID="dgExpenseNotes" runat="server" AutoGenerateColumns="False"
                                CellPadding="3" CssClass="fontsmall" Width="600px">
                                <SelectedItemStyle BackColor="Yellow" />
                                <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" />
                                <Columns>
                                    <asp:BoundColumn DataField="expense_type" HeaderText="Expense Type">
                                        <HeaderStyle Width="100px" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="note" HeaderText="Notes"></asp:BoundColumn>
                                </Columns>
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td height="10" style="width: 602px"></td>
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 602px;">
                            <asp:Label ID="Label18" runat="server" CssClass="fontmedium" Font-Bold="True"
                                Font-Underline="True">Training History</asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <asp:DataGrid ID="dgHistory" runat="server" AutoGenerateColumns="False" BorderColor="White"
                                CellPadding="3" CssClass="fontsmall" Width="600px">
                                <SelectedItemStyle BackColor="Yellow" />
                                <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" />
                                <Columns>
                                    <asp:BoundColumn DataField="Created_By" HeaderText="Created By"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Created_on" HeaderText="Created On"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Status_Changed_To" HeaderText="Status Changed To"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="ee_subject" HeaderText="E-Mail Sent to Employee"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="assg_subject" HeaderText="E-Mail Sent to Supervisor"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="msg_subject" HeaderText="Communication Message"></asp:BoundColumn>
                                </Columns>
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Center" />
                            </asp:DataGrid></td>
                    </tr>

                </table>
                <asp:Label ID="Label58" runat="server" ></asp:Label>
            </asp:Panel>
            </div>
            <div id="dvViewer" style="width: 600px; float: left;" runat="server" visible="False">
                <div style="height: 18px; width: 602px;">
                    <%--<input id="Button2" type="button" value="button" onclick="Getpage()" />--%>
                    <asp:Label ID="Label29" runat="server" ></asp:Label>
                    
                </div>
            </div>
        <br />
        <div id="dvwhat" style="width: 600px; float: left;" runat="server" >
                <div style="height: 18px; width: 602px;">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show This Request Only" Width="200px" Visible="False" />
&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Show All Requests" Width="200px" OnClick="Button2_Click" Visible="False" />
                &nbsp;<input id="htmbttnOne" type="button" value="Show This Request Only" onclick="Show1()" />&nbsp;&nbsp;
                    <input id="htmbtnAll" type="button" value="Show All Requests" onclick="Showall()" /></div>
            </div>
        <div class="floatMid" id="dvimg" style="position: absolute; top: 150px; left: 320px; right: 783px; width: 150px; z-index: 1000; visibility: hidden;">
            <asp:Image ID="Image3" runat="server" Style="margin-left: auto; margin-right: auto"
                ImageUrl="https://www.myenroll.com/images/busy.gif" />
        </div>
        <script type="text/javascript">
            function Show1() {                
                eval(document.getElementById("hidWhat")).value = '1';
                document.getElementById('dvimg').style.visibility = "visible";
                PostBack();
            }

            function Showall() {
                document.getElementById('dvimg').style.visibility = "visible";
                //alert(document.getElementById('trCommand').style.visibility);
                //document.getElementById('trCommand').style.visibility = "hidden";
                
                eval(document.getElementById("hidWhat")).value = '2';
                PostBack();
            }
        </script>
    </form>
</body>
</html>
