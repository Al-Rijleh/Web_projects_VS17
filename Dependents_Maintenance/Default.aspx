<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dependents_Maintenance.Default2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            /* height: 100px;
            background: red;*/ /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(#9eb4c0, #ffffff); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(#9eb4c0, #ffffff); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(#9eb4c0, #ffffff); /* For Firefox 3.6 to 15 */
            background: linear-gradient(#9eb4c0, #ffffff); /* Standard syntax (must be last) */
            background-repeat: no-repeat;
            background-size: 100% 100px;
        }

        .RadGrid .rgSelectedRow {
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow {
            background: #7FFFD4 !important;
        }
    </style>
    <script type="text/javascript">
        function GetEE(url) {
            alert('You have not selected an employee yet.\nYou will be redirected to the employee search ');
            window.open('/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/WEB_PROJECTS/DEPENDENTS_MAINTENANCE/DEFAULT.ASPX?SkipCheck=YES', '_self');
        }

        function DoshowDialog() {
            showDialog(); return false;
        }

        function DoshowDialog3() {
            showDialog3();
        }

        function showDialog(type) {
            window.radopen("/WEB_PROJECTS/ENROLLMENTWIZARD/AddEditDep.aspx?type=" + type, "RadWindow1");
            return false;
        }



        function showDialogAdd(id, depid) {
            window.radopen("AddEditDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow1");
            return false;
        }

        function showDialogAddFix(id, depid) {
            window.radopen("AddEditDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow1");
            return false;
        }

        function showDialogLimited(id, depid) {
            window.radopen("AddEditDepLimited.aspx?id=" + id + "&dep_id=" + depid, "RadWindow7");
            return false;
        }

        function showDialogLimitedSSN(id, depid) {
            window.radopen("AddEditDepLimited.aspx?id=" + id + "&dep_id=" + depid + "&SSN=1", "RadWindow7");
            return false;
        }

        function showDialog2(id, depid) {
            window.radopen("RemoveDepnew.aspx?id=" + id + "&dep_id=" + depid, "RadWindow2");
            return false;
        }

        function showDialog4(id, depid) {
            window.radopen("ApproveDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow2");
            return false;
        }

        function showDialog14(id, depid) {

            //document.location.replace("http://localhost/TEST_PROG/testajaxpdf/Default.aspx?id="+id+"&dep_id="+depid );
            document.location.replace("/WEB_PROJECTS/Dependent_Approval/Default.aspx?id=" + id + "&dep_id=" + depid);
            return false;
        }

        function showDialogVer(id, depid) {
            if (confirm('Are you sure you want to all Coverages from Coverages' + depid)) {
                eval(document.getElementById('hidCommand')).value = 'Approve-' + id;
                PostBack();
            }
            return false;
        }

        

        function showDialog24(id, depid) {

            //document.location.replace("http://localhost/TEST_PROG/testajaxpdf/Default.aspx?id="+id+"&dep_id="+depid );
            document.location.replace("/WEB_PROJECTS/Dependent_Terminate/Default.aspx?id=" + id + "&dep_id=" + depid);
            return false;
        }

        function OnClientclose(radWindow) {

            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument;

            if (retcode == "1") {
                radWindow.argument = 0;
                window.open('/web_projects/Dependents_Maintenance/Default.aspx?SkipCheck=YES', 'MyEnroll_users_data_display_and_edit_content_frame');
                //               __doPostBack(null, null);                   
                //                PostBack();  
            }
            if (retcode == "2") {
                radWindow.argument = 0;
                showDialog3();
            }
            if (retcode == "3") {
                radWindow.argument = 0;
                showDialog5();
            }
            if (retcode == "10") {
                radWindow.argument = 0;
                document.location.replace('/web_projects/Cobra_Service/identification_dep.aspx?SkipCheck=YES');
            }
            if (retcode == "11") {
                alert('11');
                radWindow.argument = 0;
                document.location.replace('/web_projects/Verify_Dependents/Default.aspx?SkipCheck=YES');
            }
        }

        function showDialog3() {
            alert('showDialog3')
            window.radopen("Declaration_Form.aspx", "RadWindow3");
            return false;
        }

        function showDialog5() {
            window.radopen("Coverage.aspx", "RadWindow5");
            return false;
        }

        function showDialog6(id, depid, depnm) {
            window.radopen("Reactivate.aspx?id=" + id + "&dep_id=" + depid + "&dep_nm=" + depnm, "RadWindow6");
            return false;
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

        function Approve(id, depName) {
            alert('Hear')
            var apprv = confirm('Are you sure you want to approve dependent ' + depName)
            if (apprv) {
                eval(document.getElementById('hidCommand')).value = 'Approve-' + id;
                PostBack();
            }
        }

        function showTermDep(id, depid, backURL) {

            document.location.replace("/WEB_PROJECTS/Dependent_Terminate/Default.aspx?id=" + id + "&dep_id=" + depid + "&back=" + backURL);
            return false;
        }

        function Select(dep_No) {
            var oe = eval(document.getElementById('HidOE')).value;
            //alert(oe);
            window.open('/web_projects/ptemplate/top.aspx?dep=' + dep_No, 'MyEnroll_Alert_Notes_Menu_frame');
            if ((oe == 'O') || (oe == 'A')) {
                document.getElementById("HidDeoID").value = dep_No;
                __doPostBack(null, null);
                //parent.location.href = "/web_projects/EnrollmentWizard/DepAuditDoc.aspx?dep=1&depNo=" + dep_No;
                //window.open("/web_projects/EnrollmentWizard/DepAuditDoc.aspx","_self");
            }
            else
                window.open("/web_projects/DependentsAuditGetDocuments/Default.aspx?SkipCheck=YES&dep_id=" + dep_No);
        }

        function Process(dep_No) {

            var oe = eval(document.getElementById('HidOE')).value;

            if ((oe == 'O')||(oe== 'A'))
                parent.location.href = "/web_projects/EnrollmentWizard/DepAuditDoc.aspx?dep=1&depNo=" + dep_No;
            else
                window.open("/web_projects/DependentsAuditGetDocuments/Default.aspx?SkipCheck=YES&dep_id=" + dep_No);
        }

        function RemoveDepCvrg(dep_No) {
            if (confirm('Are you sure you like to remove all Coverages from this Dependent?')) {
                document.getElementById("hiRemove").value = dep_No
                __doPostBack(null, null);
            }
        }

    </script>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/main2.css" rel="stylesheet" />
    <link href="Dep_Main.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        g<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="HidOE" runat="server" />
        <asp:HiddenField ID="HidDeoID" runat="server" />
        <asp:HiddenField ID="hiRemove" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <div class="fullWidth" id="dvAll" runat="server" style="width: 100%">
            <div class="fullWidth" id="dvTop" runat="server">
                <div class="fullWidth">
                    <asp:Label ID="lblTitle" runat="server" Text="Dependents Listing" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Font-Underline="False"></asp:Label>
                </div>
                <div class="textFont fullWidth" id="dvHeaderText" runat="server">
                    <asp:Label ID="lblInstucrion" runat="server">
                <span style='font-size: 9.0pt; font-family: Arial,sans-serif; color: #7F7F7F'>Listed below are your dependents, if any, recorded in MyEnroll.com. Click on 
the Add New Dependent link below to enter data for a dependent not currently 
listed and 
<a target='_blank' href='WhoIsEligible2009 OEMyEnroll.pdf'>Who is Eligible</a> to be covered under a Self & Family plan or a Flexible 
Spending Account (FSA) enrollment.</span>
                    </asp:Label>
                </div>
                <div class="margintop10 fullWidth">
                    <asp:Label ID="lblInstuction" runat="server"></asp:Label>
                </div>
            </div>

            <div class="margintop10 fullWidth">
                <div style="width: 200px; float: left">
                    <asp:Button ID="btnAddDependent" runat="server" Text="Add New Dependent" ToolTip="Click this button to Add New Dependent"
                        BackColor="White" BorderStyle="None" Font-Underline="True" ForeColor="Blue" Width="150px" OnClick="btnAddDependent_Click" />
                </div>
                <div style="width: 616px; float: left">
                    <asp:CheckBox ID="cbShowActiveOnly" runat="server" AutoPostBack="True" Checked="True"
                        CssClass="fontsmall" Text="Show Active Dependents Only (uncheck box to show active and terminated dependents)"
                        ToolTip="Show Active Dependents Only when checked" OnCheckedChanged="cbShowActiveOnly_CheckedChanged" />
                </div>
            </div>

            <div class="fullWidth" id="dvnoDoc" runat="server" style="margin-bottom: 20px">
                <div class="fullWidth">
                    <asp:Label ID="lblGridTitle" runat="server" Text="Dependents" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Font-Underline="False"></asp:Label>
                </div>
                <telerik:RadGrid ID="rgDep" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" OnNeedDataSource="rgDep_NeedDataSource" OnItemDataBound="rgDep_ItemDataBound">
                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                    <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                    <MasterTableView DataKeyNames="dependent_sequence_no">



                        <Columns>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter Action column" HeaderText="Action" UniqueName="Action">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>





                            <telerik:GridBoundColumn DataField="FullName" FilterControlAltText="Filter column column" HeaderText="Full Name" UniqueName="FullName">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Left" Width="175px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Relation" HeaderText="Relation" UniqueName="Relation" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOB" HeaderText="DOB" UniqueName="DOB" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Gender" HeaderText="Gender" UniqueName="Gender" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="75px"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Status" HeaderText="Status" UniqueName="Status" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="110px"></ItemStyle>
                            </telerik:GridBoundColumn>
                        </Columns>

                    </MasterTableView>
                </telerik:RadGrid>
            </div>

            <div class="fullWidth margintop10" id="dvDoc" runat="server" visible="false">
                <div class="fullWidth">
                    <asp:Label ID="lblGridTitleDoc" runat="server" Text="Dependents Requiring Verification" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Font-Underline="False"></asp:Label>
                </div>
                <telerik:RadGrid ID="rgNeedDoc" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" OnNeedDataSource="rgNeedDoc_NeedDataSource">
                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                    <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                    <MasterTableView DataKeyNames="dependent_sequence_no">



                        <Columns>
                            <telerik:GridBoundColumn DataField="Submit_doc_link" FilterControlAltText="Filter column column" HeaderText="Action" UniqueName="Submit_doc_link">
                                <ItemStyle ForeColor="Blue" />
                            </telerik:GridBoundColumn>





                            <telerik:GridBoundColumn DataField="FullName" FilterControlAltText="Filter column column" HeaderText="Full Name" UniqueName="FullName">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True" />
                                <ItemStyle HorizontalAlign="Left" Width="175px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Relation" HeaderText="Relation" UniqueName="Relation" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOB" HeaderText="DOB" UniqueName="DOB" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Gender" HeaderText="Gender" UniqueName="Gender" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="75px"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Status" HeaderText="Status" UniqueName="Status" FilterControlAltText="Filter column column">
                                <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Width="110px"></ItemStyle>
                            </telerik:GridBoundColumn>
                        </Columns>

                    </MasterTableView>
                </telerik:RadGrid>
            </div>

        </div>
        <div class="fullWidth" id="dvChoise" runat="server">
            <div class="pageTitle margintop10">
                <asp:Label ID="lblDeoName" runat="server" CssClass="dataSetctionTitle">Dependent 
                    <span class="dataSetctionTitle OrangeColor">[detail]</span></asp:Label>
            </div>
            <div style="padding-left: 10px; padding-top: 30px;">
                <div>
                    <div>
                         <asp:Label ID="lblRemove1" runat="server" CssClass="dataSetctionTitle" ForeColor="Black">Remove Coverages from Dependen</asp:Label><br />
                         <asp:Label ID="lblRemove2" runat="server" CssClass="textFont">By Clicking the "Remove Coverages" button below, you will remove all coverages from your Dependent and your Dependent will remain active in MyEnroll for Spending Account purposes.</asp:Label>
                    </div>
                    <div style="margin-top: 10px">
                        <div style="float:left">
                        <asp:Button ID="btnTerm" runat="server" Text="Remove Coverages" Width="150px" OnClick="btnTerm_Click" />
                        </div>
                        <div id="dvRemoveCvrg" runat="server" style="float:left">
                        <asp:Label ID="lblCheck" runat="server" Text="Are you sure you like to remove all Coverages from this Dependent?" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                        &nbsp;&nbsp;<asp:Button ID="btnYes" runat="server" Text="Yes" Width="35px" OnClick="btnYes_Click" />
                        <asp:Button ID="btnNo" runat="server" Text="No" Width="35px" OnClick="btnNo_Click" />
                        </div>
                        <br />
                    </div>
                    <div style="margin-top: 10px; margin-bottom: 10px;">
                        <hr />
                    </div>
                </div>

                <div>
                    <div>
                         <asp:Label ID="lblSubmit1" runat="server" CssClass="dataSetctionTitle" ForeColor="Black">Submit Verification Docs</asp:Label><br />
                         <asp:Label ID="lblSubmit2" runat="server" CssClass="textFont">By Clicking the "Submit Docs" button below, you will be taken to the page where you can upload or fax your documentation for Dependents requiring verification."</asp:Label>
                    </div>
                    <div style="margin-top: 10px">
                        <asp:Button ID="btnGetDocs" runat="server" Text="Submit Docs" Width="150px" OnClick="btnGetDocs_Click" />
                    </div>
                    <div style="margin-top: 10px; margin-bottom: 10px">
                        <hr />
                    </div>
                </div>
                
                <br />
                <br />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="150px" OnClick="btnCancel_Click" />
            </div>
        </div>

    </form>

</body>
</html>
