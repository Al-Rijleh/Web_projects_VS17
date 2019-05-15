<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PLA_Report.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Panel1"&gt;
	
                <table border="0" cellpadding="0" cellspacing="0" style="width: 600px" id="tbl">
                    <tbody><tr>
                        <td align="right" style="width: 602px">&nbsp;&nbsp;
                    <a id="hlPrint" class="fontsmall" href="javascript:window.print()">Print</a>
                            &nbsp; &nbsp;&nbsp; &nbsp;<a id="hlClose" class="fontsmall" href="javascript:document.location.replace('Default.aspx?SkipCheck=YES')">Close the Print Page</a></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table style="width: 600px">
                                <tbody><tr>
                                    <td align="left" style="height: 80px">
                                        <img id="Image1" src="FDIC%20CU%20Logo.jpg" style="width:125px;border-width:0px;"></td>
                                    <td align="right" style="height: 80px">
                                        <img id="Image2" src="myenroll_For_WhiteBackground.jpg" style="width:200px;border-width:0px;"></td>
                                </tr>
                            </tbody></table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <span id="lblTitle" class="FontSmallTitle" style="font-weight:bold;">Professional Learning Account - Training Request Summary</span></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table style="width: 600px">
                                <tbody><tr>
                                    <td width="110">
                                        <span id="Label1" class="fontsmall" style="font-weight:bold;">Employee:</span></td>
                                    <td>
                                        <span id="lblEmployeeName" class="fontsmall">Bbldrlh, Ramzi Maher</span></td>
                                </tr>
                                <tr>
                                    <td width="110">
                                        <span id="Label2" class="fontsmall" style="font-weight:bold;">MyEnroll #:</span></td>
                                    <td>
                                        <span id="lblEmployeeInfo" class="fontsmall">471537&nbsp;&nbsp;&nbsp;&nbsp;<b>Soc Sec. No.:</b>&nbsp;***-**-7111&nbsp;&nbsp;&nbsp;&nbsp;<b>Phone # :</b>&nbsp;(610)992-0000</span></td>
                                </tr>
                                <tr>
                                    <td width="110">
                                        <span id="Label3" class="fontsmall" style="font-weight:bold;">Duty Station:</span></td>
                                    <td>
                                        <span id="lblEmployeeDutyStation" class="fontsmall">Washington, DC</span></td>
                                </tr>
                            </tbody></table>
                            <hr>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <span id="lblVendorTitle" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Vendor Information</span></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table id="Table12" border="0" cellpadding="0" cellspacing="0" width="600">
                                <tbody><tr>
                                    <td style="width: 790px">
                                        <table id="Table11" border="0" cellpadding="0" cellspacing="0" width="600">
                                            <tbody><tr>
                                                <td width="250" style="height: 18px">
                                                    <span id="Label20" class="fontsmall">Training Event Code</span></td>
                                                <td width="530" style="height: 18px">
                                                    <span id="lbltxtCourseCode" class="fontsmall">Unknown</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250" style="height: 18px">
                                                    <span id="Label4" class="fontsmall">Training Event Title</span></td>
                                                <td width="530" style="height: 18px">
                                                    <span id="lbltxtCourseTitle" class="fontsmall">Introduction to Computer Science 200</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label22" class="fontsmall">Vendor Name</span></td>
                                                <td width="530">
                                                    <span id="lbltxtVedorName" class="fontsmall">CSC-200</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label50" class="fontsmall">Vendor Contact</span></td>
                                                <td width="530">
                                                    <span id="lbltxtVendorContact" class="fontsmall">NVCC</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label6" class="fontsmall">Vendor Telephone &amp; Fax</span></td>
                                                <td style="height: 19px" width="530">
                                                    <span id="lbltxtPhoneNumber" class="fontsmall" style="display:inline-block;height:19px;">(703) 323-3000</span>
                                                    &nbsp;
                                            <span id="lbltxtFaxNumber" class="fontsmall">(703) 323-3000</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label7" class="fontsmall">Vendor Address Line 1</span></td>
                                                <td width="530">
                                                    <span id="lbltxtAddressLine1" class="fontsmall">3926 Pender Drive Suite 150</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label8" class="fontsmall">Vendor Address Line 2</span></td>
                                                <td width="530">
                                                    <span id="lbltxtAddressLine2" class="fontsmall">Unknown</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label9" class="fontsmall">Vendor City / State / Zip Code</span></td>
                                                <td width="530">
                                                    <span id="lbltxtCity" class="fontsmall">Fairfax</span>
                                                    &nbsp;
                                            <span id="lbltxtState" class="fontsmall">VA</span>
                                                    &nbsp;
                                            <span id="lbltxtZipCode" class="fontsmall">22030</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="Label24" class="fontsmall">Vendor Web Site</span></td>
                                                <td width="530">
                                                    <span id="lbltxtWebSite" class="fontsmall">http://nvcc.edu</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250" style="height: 18px">
                                                    <span id="Label5" class="fontsmall">Vendor Email</span></td>
                                                <td width="530" style="height: 18px">
                                                    <span id="lblEmail" class="fontsmall">Information@nvcc.edu</span></td>
                                            </tr>
                                            <tr>
                                                <td height="10" width="250"></td>
                                                <td height="10" width="530"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span id="Label52" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Location of Training Site</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="lblLearningAddress1" class="fontsmall">Address Line 1</span></td>
                                                <td width="530">
                                                    <span id="lbltxtLearningAddress1" class="fontsmall">8333 Little River Turnpike</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="lblLearningAddress2" class="fontsmall">Address Line 2</span></td>
                                                <td width="530">
                                                    <span id="lbltxtLearningAddress2" class="fontsmall">Unknown</span></td>
                                            </tr>
                                            <tr>
                                                <td width="250">
                                                    <span id="lblLearningCityState" class="fontsmall">City / State / Zip Code</span></td>
                                                <td width="530">
                                                    <span id="lbltxtLearningCity" class="fontsmall">Annandale</span>
                                                    &nbsp;
                                            <span id="lbltxtLearningState" class="fontsmall">VA</span>
                                                    &nbsp;
                                            <span id="lbltxtLearningZipCode" class="fontsmall">22003</span></td>
                                            </tr>
                                            <tr>
                                                <td height="10" width="250"></td>
                                                <td height="10" width="530"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span id="lblTitlePurposeoftraining" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Purpose of Training:</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span id="lblPurposeofTraining" class="fontsmall">To enhance my IT background </span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="10"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" width="250">
                                                    <span id="lblTitleTrainingDateTime" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Training Dates &amp; Times</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" width="250">
                                                    <span id="Label11" class="fontsmall">Training Starts</span></td>
                                                <td colspan="1" width="530">
                                                    <span id="lblStratDate" class="fontsmall">09/08/2015</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" style="height: 18px" width="250">
                                                    <span id="Label12" class="fontsmall">Training Ends</span></td>
                                                <td colspan="1" style="height: 18px" width="530">
                                                    <span id="lblEndDate" class="fontsmall">12/20/2015</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" height="5" width="250"></td>
                                                <td colspan="1" width="530" height="5"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" width="250">
                                                    <span id="Label13" class="fontsmall">Duty Hours</span></td>
                                                <td colspan="1" width="530">
                                                    <span id="lblHourDuty" class="fontsmall">2</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" width="250">
                                                    <span id="lbl" class="fontsmall">Non-Duty Hours</span></td>
                                                <td colspan="1" width="530">
                                                    <span id="lblhournonduty" class="fontsmall">0</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" align="right" width="250">
                                                    <span id="lbl2" class="fontsmall">Total</span>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td colspan="1" width="530">
                                                    <span id="lblHourtotal" class="fontsmall">2</span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" height="10" width="250"></td>
                                                <td colspan="1" width="530" style="height: 18px"></td>
                                            </tr>

                                        </tbody></table>
                                    </td>
                                </tr>
                            </tbody></table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table id="tableType2008" border="0" cellpadding="0" cellspacing="0" style="width: 600px">
		<tbody><tr>
			<td colspan="2">
                                        <p class="pagebreakhere">
                                            <span id="lblTitleTypesNeeds" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Training Types &amp; Needs</span>
                                    </p></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label57" class="fontsmall">Department ID#</span></td>
			<td width="530">
                                        <span id="lbltxtDepartmentID" class="fontsmall">1650</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label55" class="fontsmall">Position Level</span></td>
			<td width="530">
                                        <span id="lbltxtPositionLevel" class="fontsmall">Non-supervisory</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label53" class="fontsmall">Need Special Accomodation</span></td>
			<td width="530">
                                        <span id="lbltxtAccomodation" class="fontsmall">No</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        </td>
			<td width="530">
                                        </td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label49" class="fontsmall">Type of Appointment</span></td>
			<td width="530">
                                        <span id="lbltxTypeofAppointment" class="fontsmall">Career</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label48" class="fontsmall">Training Purpose Type</span></td>
			<td width="530">
                                        <span id="lbltxtPurposeOfTraining" class="fontsmall">Improve/Maintain Present Performance</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label47" class="fontsmall">Delivery Type Code</span></td>
			<td width="530">
                                        <span id="lbltxtDelivaryTypeCode" class="fontsmall">Traditional Classroom (no technology)</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label15" title="Training Designation Type Code" class="fontsmall">Designation Type Code</span></td>
			<td width="530">
                                        <span id="lbltxtDesignationTypeCode" class="fontsmall">Undergraduate Credit</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="lblTrainingCredit" title="Training Designation Type Code" class="fontsmall">Training Credit</span></td>
			<td width="530">
                                        <span id="lbltxtTrainingCredit" class="fontsmall"></span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label45" title="Training Credit Type Code" class="fontsmall">Credit Type Code</span></td>
			<td width="530">
                                        <span id="lbltxtCreditTypeCode" class="fontsmall">Semester Hours</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label43" title="Is the Course Accredited " class="fontsmall">Accreditation Indicator</span></td>
			<td width="530">
                                        <span id="lbltxtAccredetionIndicator" class="fontsmall">N/A</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label41" class="fontsmall">Source of Training</span></td>
			<td width="530">
                                        <span id="lbltxtSourseTraining" class="fontsmall">Non-government</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label39" class="fontsmall">Account #</span></td>
			<td width="530">
                                        <span id="lbltxtAccountNumber" class="fontsmall">5632</span></td>
		</tr>
		<tr>
			<td style="height: 18px; width: 250px;">
                                        <span id="Label16" class="fontsmall">Education Level</span></td>
			<td width="530">
                                        <span id="lbltxtEducationLevel" class="fontsmall">10 - Associate Degree</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label37" title="Training Type Code" class="fontsmall">Training Type Code</span></td>
			<td width="530">
                                        <span id="lbltxtTrainingTypeCode" class="fontsmall">01 - Training Program Area</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label30" title="Training Sub-Type Code" class="fontsmall">Training Sub-Type Code</span></td>
			<td width="530">
                                        <span id="lbltxtTrainingSubTypeCode" class="fontsmall">08 - Information Technology</span></td>
		</tr>
		<tr>
			<td style="height: 18px; width: 250px;">
                                        <span id="lblTypeOfDevelopment" title="Type of Development" class="fontsmall">Type of Development</span></td>
			<td width="530">
                                        <span id="lbltxtTypeOfDevelopmentSummary" class="fontsmall">Technology</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="Label38" class="fontsmall">Type of Development (other)</span></td>
			<td width="530">
                                        <span id="lbltxtTypeofDevelopmentOther182" class="fontsmall">Introduction to Computer Science</span></td>
		</tr>
		<tr>
			<td style="width: 250px">
                                        <span id="lblProgramCode" class="fontsmall">Program Code</span></td>
			<td width="530">
                                        <span id="lbltxtProgramCode" class="fontsmall">67200</span></td>
		</tr>
	</tbody></table>
	
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            
                        </td>
                    </tr>
                    <tr>
                        <td height="10" style="width: 602px"></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <span id="Label14" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Training Expenses</span></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table class="fontsmall" cellspacing="0" cellpadding="3" rules="all" border="1" id="dgExpense" style="border-color:White;width:600px;border-collapse:collapse;">
		<tbody><tr align="center" style="font-weight:bold;font-style:normal;text-decoration:none;">
			<td align="left" style="font-weight:bold;font-style:normal;text-decoration:none;width:225px;">Expense Type</td><td align="right" style="font-weight:bold;font-style:normal;text-decoration:none;width:125px;">Estimated Amout</td><td align="right" style="font-weight:bold;font-style:normal;text-decoration:none;width:125px;">Approved Amount</td><td align="right" style="font-weight:bold;font-style:normal;text-decoration:none;width:125px;">Paid Amount</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Tuition</td><td align="right">$550.00</td><td align="right">$550.00</td><td align="right">$685.00</td>
		</tr>
	</tbody></table></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                <tbody><tr>
                                    <td align="right" width="225">
                                        <span id="Label17" class="fontsmall" style="color:Black;font-weight:bold;">Total</span>
                                        &nbsp; &nbsp;
                                    </td>
                                    <td align="right" width="125">
                                        <span id="lblAmount" class="fontsmall" style="color:Black;font-weight:bold;">$550.00</span></td>
                                    <td align="right" width="125">
                                        <span id="lblApprovedAmount" class="fontsmall" style="color:Black;font-weight:bold;">$550.00</span></td>
                                    <td align="right" width="125">
                                        <span id="lblTotalPaid" class="fontsmall" style="color:Black;font-weight:bold;">$685.00</span></td>
                                </tr>
                            </tbody></table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <span id="lblExpenseNote" class="fontsmall">Total excludes Travel Expense because such expenses are not deducted from PLA Balances.</span></td>
                    </tr>
                    <tr>
                        <td height="10" style="width: 602px"></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <span id="Label26" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Training Expenses Notes</span></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table class="fontsmall" cellspacing="0" cellpadding="3" rules="all" border="1" id="dgExpenseNotes" style="width:600px;border-collapse:collapse;">
		<tbody><tr align="center" style="font-weight:bold;font-style:normal;text-decoration:none;">
			<td align="left" style="font-weight:bold;font-style:normal;text-decoration:none;width:100px;">Expense Type</td><td>Notes</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Tuition</td><td>&nbsp;</td>
		</tr>
	</tbody></table></td>
                    </tr>
                    <tr>
                        <td height="10" style="width: 602px"></td>
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 602px;">
                            <span id="Label18" class="fontmedium" style="font-weight:bold;text-decoration:underline;">Training History</span></td>
                    </tr>
                    <tr>
                        <td style="width: 602px">
                            <table class="fontsmall" cellspacing="0" cellpadding="3" rules="all" border="1" id="dgHistory" style="border-color:White;width:600px;border-collapse:collapse;">
		<tbody><tr align="center" style="font-weight:bold;font-style:normal;text-decoration:none;">
			<td>Created By</td><td>Created On</td><td>Status Changed To</td><td>E-Mail Sent to Employee</td><td>E-Mail Sent to Supervisor</td><td>Communication Message</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Splvrxd, Gary B</td><td>01/15/2016 : 08.04 am</td><td>Completed</td><td>Your Supervisor Has Reviewed Your Training Evaluation Form.</td><td>Supervisor Has Reviewed Employee's Training Evaluation Form</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Bbldrlh, Ramzi Maher</td><td>01/14/2016 : 04.21 pm</td><td>Pending Supervisor's Acknowledgement of the Training Evaluation Form</td><td>&nbsp;</td><td>Employee Has Completed Their Training Evaluation Form</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Bbldrlh, Ramzi Maher</td><td>01/14/2016 : 04.21 pm</td><td>Pending Supervisor's Acknowledgement of the Training Evaluation Form</td><td>&nbsp;</td><td>Employee Has Completed Their Training Evaluation Form</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>&nbsp;</td><td>01/11/2016 : 01.00 am</td><td>Pending Evaluation Second Notice</td><td>SECOND REQUEST: Complete Online Training Evaluation Form</td><td>Notice of Employee's Second Request to Complete Their Online Training Evaluation Form</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>&nbsp;</td><td>12/21/2015 : 01.00 am</td><td>Pending Evaluation</td><td>Request to Complete Online Training Evaluation Form</td><td>&nbsp;</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Pieokmc, Michael D</td><td>10/27/2015 : 04.36 pm</td><td>Paid</td><td>Administrator Fully Pays Approved Training Expenses</td><td>&nbsp;</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Pieokmc, Michael D</td><td>07/16/2015 : 08.28 am</td><td>Pending-Payment</td><td>Super User Changed Request Dates</td><td>&nbsp;</td><td>Super User Changed Request Dates</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Splvrxd, Gary B</td><td>07/09/2015 : 10.03 am</td><td>Pending-Payment</td><td>Supervisor Approves Training - Request for Payment to Administrator</td><td>Supervisor Approves Training - Request for Payment to Administrator</td><td>&nbsp;</td>
		</tr><tr style="font-weight:normal;font-style:normal;text-decoration:none;">
			<td>Bbldrlh, Ramzi Maher</td><td>07/09/2015 : 09.42 am</td><td>Pending Supervisor Approval</td><td>&nbsp;</td><td>Employee Requests Training</td><td>&nbsp;</td>
		</tr>
	</tbody></table></td>
                    </tr>

                </tbody></table>
            
</div>
            <dv>
                <dv style="height: 18px; width: 602px;">
                    &nbsp;<span id="Label58"><style type="text/css">
                                                                .fontsmall {
                                                                    font-family: Arial, Sans-Serif;
                                                                    font-size: 9pt;
                                                                }

                                                                .FontMedium {
                                                                    font-family: Arial, Sans-Serif;
                                                                    font-size: 11pt;
                                                                }

                                                                .FontLarge {
                                                                    font-family: Arial, Sans-Serif;
                                                                    font-size: 13pt;
                                                                }

                                                                .FontTitle {
                                                                    font-family: Arial, Sans-Serif;
                                                                    font-size: 20pt;
                                                                }

                                                                .FontSmallTitle {
                                                                    font-family: Arial, Sans-Serif;
                                                                    font-size: 14pt;
                                                                }
                                                            </style></span></dv></dv></form>
    </form>
</body>
</html>
