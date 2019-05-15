<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DependentsAuditGetDocuments.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload Dependents Documents</title>

    <link rel="Stylesheet" href="../../Styles/Main2.css" type="text/css" />
    <link rel="Stylesheet" href="../../Styles/Layout.css" type="text/css" />
    <style type="text/css">
        .LeftArea {
            width: 450px;
        }

        .TopEdge {
            border-top-style: solid;
            border-top-width: 1px;
            border-top-color: #D6DEEB;
        }

        .BottomEdge {
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: #D6DEEB;
        }

        .CenterText {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function showfax(dpno) {
            var nonResta = document.getElementById("hidNonReta").value;
            //window.open('/web_projects/ViewFax/Default.aspx?DpNo=' + dpno, '_blank');
            window.open('/web_projects/DependentAuditDocFax/ViewFax.aspx?DpNo=' + dpno, '_blank');
            __doPostBack(null, null);
        }


        function Remove(ee) {
            if (confirm('Are you sure you want to remove this document')) {
                document.getElementById('hidRemove').value = ee;
                __doPostBack(null, null);
            }
        }


        function RemoveFax(id) {
            if (confirm('Are you sure you want to remove this Fax')) {
                document.getElementById('hidRemoveFax').value = id;
                __doPostBack(null, null);
            }
        }

        function btnHTMViewImage_onclick() {
            window.open('ViewDoc.aspx', '_blank');
        }

        function ShowDocs() {
            window.open('https://www.myenroll.com/web_projects/Library/Default.aspx?id=8St1l73lTAI56omzOCxjanemane6508247Sob348QmVkaj41i8XLP4', '_blank');
        }

        function OnClientclose(radWindow) {
            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument
            if (retcode == "1") {
                radWindow.argument = 0;
                var hid = document.getElementById("hid1");
                hid.value = 'Go';
                __doPostBack(null, null);
            }
            if (retcode == "0") {
                radWindow.argument = 0;
                var hid = document.getElementById("hid1");
                hid.value = 'ref';
                __doPostBack(null, null);
            }
        }

    </script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">
        $(function () {
            $("#accordion").accordion({ header: "h2", collapsible: true, active: false });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidNonReta" runat="server" />
        <asp:HiddenField ID="hidRemove" runat="server" />
        <asp:HiddenField ID="hidRemoveFax" runat="server" />
        <asp:HiddenField ID="hid1" runat="server" />
        <asp:HiddenField ID="hidUpload" runat="server" />
        <asp:HiddenField ID="hidFax" runat="server" />
        <asp:HiddenField ID="hid2" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <div class='Row'>
            <div class='Row marginbottom02'>
                <asp:Label ID="lblPageTitle" runat="server" CssClass="pageTitle">Dependents Requiring Verification Documentation</asp:Label>
            </div>
            <%--Instruction--%>
            <div class='Row marginbottom02 textFont'>
                <div id="accordion">
                    <h2>Instructions for Validating Your Dependents</h2>
                    <div style="font-size: 11pt; font-family: Arial, sans-serif;">
                        <ol>
                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">Click on the &ldquo;Click to See Eligible Documents&rdquo; to see a list of the required validation documents.</span></li>
                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">Gather the necessary documents.</span></li>
                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">If opting to upload your documents you first need to scan them into your computer in PDF format. You can then use the &ldquo;Upload&rdquo; button below to elect your PDF documents from your computer and upload them to the system for review.</span></li>
                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">If opting to fax or mail your documents you must include our cover page with your fax or mailing, so the system can properly identify your documents and assign them to your account. A separate cover page is required for each dependent&rsquo;s documents being submitted.</span></li>
                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">Once your documents are uploaded you can review them by clicking the arrow [ &gt; ] to the left of the dependent&rsquo;s name.</span></li>
                        </ol>
                    </div>
                </div>
            </div>
            <%--Notes--%>
            <div class='Row marginbottom02 textFont'>
                <asp:Label ID="lblInstruction" runat="server">
        <span style='color: #00b050;'><strong>If you are not ready to upload your documents or to print the fax cover page now, you can return to
this page by selecting 'Manage Dependents Verifications' from the Employees menu under the Tools group.<br/><br /></strong></span></asp:Label>

                <asp:Label ID="lblInstruction2" runat="server">
        <span style='color: maroon;'><strong>You have until <u>[effectiv]</u> to finish this process.  Failure to submit correct documentation by this date 
    may result in your dependent(s) not receiving coverage.</strong></span></asp:Label>

                <asp:Label ID="lblWarning" runat="server" Visible="False">
        <span style='color: red;'><strong>If there are no dependents listed below to validate – please click on Next at the bottom of this page to continue 
            through the enrollment wizard.<br /><br /> </strong></span></asp:Label>
            </div>
            <%--Employee Name--%>
            <div class='Row marginbottom02 textFont'>
                <asp:Label ID="lblEEName" runat="server"></asp:Label>
            </div>
            <%--Grid--%>
            <div class='Row marginbottom02 textFont'>
                <telerik:RadGrid ID="rgEEList" runat="server" AutoGenerateColumns="False"
                    OnNeedDataSource="RadGrid1_NeedDataSource"
                    OnItemCommand="rgEEList_ItemCommand"
                    Width="750px" Skin="Default">
                    <MasterTableView DataKeyNames="dependent_sequence_no" AllowMultiColumnSorting="True" GroupLoadMode="Server"
                        NoDetailRecordsText="No records to display." Width="750">
                        <NestedViewTemplate>
                            <telerik:RadGrid ID="rgDetal" runat="server" AutoGenerateColumns="False">
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="record_id"
                                            HeaderText="Record ID" UniqueName="column100">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FILE_NAME"
                                            HeaderText="File Name" UniqueName="column101">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px"/>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="STATUS"
                                            HeaderText="Status" UniqueName="column102">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="190px"/>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ACTION"
                                            HeaderText="Action" UniqueName="column103">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                    </Columns>

                                </MasterTableView>
                            </telerik:RadGrid>
                        </NestedViewTemplate>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Dependent" FilterControlAltText="Filter column column"
                                HeaderText="Dependent" UniqueName="column" FilterControlWidth="100px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOB" FilterControlAltText="Filter column1 column"
                                HeaderText="Birth Date" UniqueName="column1" FilterControlWidth="100px">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="doc_count_type"
                                FilterControlAltText="Filter column3 column"
                                HeaderText="Number &amp; Type of&lt;/br&gt;Documents Needed"
                                UniqueName="column3">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UploadFaxButtons"
                                FilterControlAltText="Filter column2 column"
                                HeaderText="Documents&lt;/br&gt;Upload or Fax" UniqueName="column2">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>

            <div class='Row marginbottom02 textFont' id="dvFaxSent" runat="server">
                <asp:Label ID="lblGeneratedFaxws" runat="server" Text="Generated Faxes</br>" CssClass="FontSmall10 FontBold"></asp:Label>
                <telerik:RadGrid ID="rgFax" runat="server" AutoGenerateColumns="False"
                    OnNeedDataSource="rgFax_NeedDataSource"
                    OnItemCommand="rgFax_ItemCommand"
                    Width="750px" GroupPanelPosition="Top">
                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                    <MasterTableView DataKeyNames="dependent_sequence_no" AllowMultiColumnSorting="True" GroupLoadMode="Server"
                        NoDetailRecordsText="No records to display." Width="750">
                        <NestedViewTemplate>
                            <telerik:RadGrid ID="rgDetal" runat="server" AutoGenerateColumns="False">

                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="record_id"
                                            HeaderText="Record ID" UniqueName="column100">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FILE_NAME"
                                            HeaderText="File Name" UniqueName="column101">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px"/>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="STATUS"
                                            HeaderText="Status" UniqueName="column102">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="190px"/>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ACTION"
                                            HeaderText="Action" UniqueName="column103">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                    </Columns>

                                </MasterTableView>


                            </telerik:RadGrid>
                        </NestedViewTemplate>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Dependent" FilterControlAltText="Filter column column"
                                HeaderText="Dependent" UniqueName="column" FilterControlWidth="100px">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="270px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="270px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DOB" FilterControlAltText="Filter column1 column"
                                HeaderText="Birth Date" UniqueName="column1" FilterControlWidth="100px">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="320px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="320px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>



            <%--Fax Section--%>
            <div id='dvFax' runat="server" class='Row  floatleft'>
                <div class='Row dataSubSetctionTitle BottomEdge '>
                    <asp:Label ID="lblFaxOptionTitle" runat="server" Text="Fax or Mail Option"></asp:Label>
                </div>

                <div class='Row textFont paddingtop01'>
                    <asp:Label ID="lblFaxInstruction" runat="server">
                    <p><strong>Use this Option to print and mail/fax your supporting documents</strong></p>
<ol>
    <li>Generate a personalized, bar-coded Fax/Mailing Coversheet</li>
    <li>Print the personalized, bar-coded Fax/Mailing Coversheet</li>
    <li>Mail or fax the supporting documents, along with the Coversheet. Faxing and mailing instructions are located on the Coversheet you print.</li>
</ol>
                    </asp:Label>
                </div>
                <div class='Row'
                    style="font-family: Arial; font-size: 14pt; color: #FF0000; font-weight: bold;">
                    If you are submitting documentation for more than one dependent, you MUST use a separate fax cover sheet for each dependent and fax them separately. Make sure to use the correct personalized cover sheet for each fax transmission.
                </div>
                <div class='RightArea textFont margintopxx CenterText'>
                    <asp:Button ID="btnPrintCoverSheet" runat="server" Text="Print Coversheet"
                        Width="115px" />
                </div>
            </div>
            <div class='RightArea textFont margintopxx ' style="margin-top: 50px">
                <asp:Button ID="btnDone" runat="server" Text="Done"
                    Width="115px" Visible="False" OnClick="btnDone_Click" />
            </div>
        </div>
        <script language="javascript" type="text/javascript">
            // <![CDATA[

            function htmbtnUpload_onclick(id) {
                document.getElementById('hidUpload').value = id;
                __doPostBack(null, null);
            }

            function htmbtnFax_onclick(id) {
                document.getElementById('hidFax').value = id;
                __doPostBack(null, null);

            }

            // ]]>
        </script>

    </form>
</body>
</html>
