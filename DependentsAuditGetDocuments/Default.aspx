<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DependentsAuditGetDocuments.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Upload Dependents Documents</title>

    <link rel="Stylesheet" href="../../Styles/Main2.css" type="text/css" />
    <link rel="Stylesheet" href="../../Styles/Layout.css" type="text/css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS"
        crossorigin="anonymous">
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-TXfwrfuHVznxCssTxWoPZjhcss/hp38gEOH8UPZG/JcXonvBQ6SlsIF49wUzsGno"
        crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU"
        crossorigin="anonymous">

    <!-- Bootstrap CSS CDN -->


    <script src="https://code.jquery.com/jquery-3.4.0.min.js"></script>
    <!-- Popper.JS --Compiled by BAS-->

    <script src="https://www.me-content.com/mec/system/compiledResources/frameworks/bootstrap/dist/js/bootstrap.bundle.min.js"></script>

    <link rel="stylesheet" href="https://www.me-content.com/mec/system/compiledResources/UIKit/uikit/dist/css/uikit.css" />
    <script src="https://www.me-content.com/mec/system/compiledResources/UIKit/uikit/dist/js/uikit.js"></script>
    <script src="https://www.me-content.com/mec/system/compiledResources/UIKit/uikit/dist/js/uikit-icons.js"></script>
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

        .btnWidth250 {
            width: 250px;
        }

        .btnWidth115 {
            width: 400px;
        }

        .RadGrid .rgSelected{
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHovered{
            background: #7FFFD4 !important; //Try setting background to get the desired hover color
        }

        .rotateChev {
            transform: rotate(180deg);
            transition: .2s ease;
        }
    </style>
    <script>
         $(document).ready(function () {
            $('.uk-button').css({'width':'auto'})
            //GetUserTypeSession();
            //$('[id*="rgEEList"]').removeClass('RadGrid RadGrid_Default');
        })
    </script>
    
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
            window.open(
                'https://www.myenroll.com/web_projects/Library/Default.aspx?id=8St1l73lTAI56omzOCxjanemane6508247Sob348QmVkaj41i8XLP4',
                '_blank');
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

        function showTermDep(id, depid, backURL) {
            //            if (depid == '-1')
            //            {
            //              showDialog2(id,depid);
            //              return;
            //            }
            document.location.replace("/WEB_PROJECTS/Dependent_Terminate/Default.aspx?id=" + id + "&dep_id=" + depid +
                "&back=" + backURL);
            return false;
        }

        function showDialog2(id, depid) {
            window.radopen("RemoveDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow2");
            return false;
        }
    </script>

    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">
        $(function () {
            $("#accordion1").accordion({
                header: "h2",
                collapsible: true,
                active: false
            });
        });
    </script>

    <script>
        function GetUserTypeSession() {
            $.ajax({
                type: "POST",
                url: "../ProfileBootstrap/WebMethods.aspx/GetUserTypeSession",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var userType = data.d; //this is the user type
                    //alert(userType);
                    if (userType = 6) {
                        $('#homeBtn').attr("href", "/web_projects/ProfileBootstrap/Redirect.aspx")
                        $('#btnDone').hide();
                        $('#homeBtn').show();
                        
                    } else if (userType = 7) {
                        $('#homeBtn').attr("href", "/web_projects/ProfileBootstrap/Redirect.aspx")
                        $('#btnDone').hide();
                        $('#homeBtn').show();
                    } else {
                        $('#btnDone').show();
                        $('#homeBtn').hide();
                    }

                }
            });
        }
       
    </script>
</head>

<body onload="HidDoneBtn()">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="Panel1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="95%" Style="margin: auto;">
            
            <asp:HiddenField ID="hidNonReta" runat="server" />
            <asp:HiddenField ID="hidRemove" runat="server" />
            <asp:HiddenField ID="hidRemoveFax" runat="server" />
            <asp:HiddenField ID="hid1" runat="server" />
            <asp:HiddenField ID="hidUpload" runat="server" />
            <asp:HiddenField ID="hidFax" runat="server" />
            <asp:HiddenField ID="hid2" runat="server" />
            <asp:Label ID="lblScript" runat="server"></asp:Label>
            <div >
                <div class='marginbottom02'>
                    <asp:Label ID="lblPageTitle" runat="server" CssClass="pageTitle">Dependents Requiring Verification
                        Documentation</asp:Label>
                </div>
                <%--Instruction--%>
                <div class='marginbottom02 textFont'>
                    <div id="accordion1">
                        <div class="accordion" id="instructionsCollapse">
                            <div class="card">
                                <h4 style="padding: 5px 20px;margin: 2px 0px;border-bottom: 1px solid #d2d2d2;">Instructions
                                    for Validating Your Dependents</h4>
                                <div class="card-body" style="padding-top: 0">
                                    <h5 style="font-weight:700">
                                        Option 1 - UPLOAD DOCUMENTS
                                    </h5>
                                    <p>
                                        If you are uploading your dependent verification documents from your computer,
                                        click the Upload button on a dependent’s row in the grid below, in order to
                                        open the document upload window.
                                    </p>
                                    <p>
                                        To see your uploaded documents for each dependent after upload, click on the >
                                        to the left of a dependent’s name in the grid below.
                                    </p>
                                    <p>
                                        <u>You must upload each dependent’s documents separately.</u>
                                    </p>

                                    <script>
                                            $('#option2').on('show.bs.collapse', function () {
                                                alert('test');
                                                
                                            })
                                        </script>
                                    <div style="font-size: 11pt; font-family: Arial, sans-serif;display:none">
                                        <ol>
                                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">Click on
                                                    the &ldquo;Click to See Eligible Documents&rdquo; to see a list of
                                                    the required validation documents.</span></li>
                                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">Gather
                                                    the necessary documents.</span></li>
                                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">If
                                                    opting to upload your documents you first need to scan them into
                                                    your computer in PDF format. You can then use the
                                                    &ldquo;Upload&rdquo; button below to elect your PDF documents from
                                                    your computer and upload them to the system for review.</span></li>
                                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">If
                                                    opting to fax or mail your documents you must include our cover
                                                    page with your fax or mailing, so the system can properly identify
                                                    your documents and assign them to your account. A separate cover
                                                    page is required for each dependent&rsquo;s documents being
                                                    submitted.</span></li>
                                            <li><span style="font-size: 11pt; font-family: Arial, sans-serif;">Once
                                                    your documents are uploaded you can review them by clicking the
                                                    arrow [ &gt; ] to the left of the dependent&rsquo;s name.</span></li>
                                        </ol>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-header" id="headingTwo">
                                    <h5 class="mb-0">
                                        <div style="display:flex;justify-content: flex-start;align-items: center">

                                            <div class="collapsed" style="cursor: pointer;font-weight: 700;padding-right: 10px" data-toggle="collapse"
                                                data-target="#option2" aria-expanded="false" aria-controls="option2">
                                                OPTION 2 - FAX DOCUMENTS
                                            </div>
                                            <div>
                                                <i class="fal fa-chevron-down"></i>
                                            </div>
                                        </div>
                                        <h5></h5>
                                        <h5></h5>
                                    </h5>
                                </div>
                                <div id="option2" class="collapse" aria-labelledby="headingTwo" data-parent="#instructionsCollapse">
                                    <div class="card-body">
                                        <div>
                                            <p>
                                                If you want to fax your dependent verification documents to us instead
                                                of uploading them, click the Fax button to open the window for
                                                generating & printing your personalized Fax coversheet (required for
                                                faxing).
                                            </p>
                                            <p>
                                                <u>You must print out one fax coversheet for EACH of your dependents
                                                    and submit each dependent’s documents with their own fax
                                                    coversheet.</u>
                                            </p>
                                            <p>
                                                To see your faxed documents applied to each dependent, wait about 15-30
                                                minutes after you fax your documents to us then click on the > to the
                                                left of a dependent’s name in the grid below.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <%--Notes--%>
                    <div class='marginbottom02 textFont'>
                        <asp:Label ID="lblInstruction" runat="server">
                            <span style='color: #00b050;'><strong>If you are not ready to upload your documents or to
                                    print the fax cover page now, you can return to
                                    this page by selecting 'Manage Dependents Verifications' from the Employees menu
                                    under the Tools group.<br /><br /></strong></span></asp:Label>

                        <asp:Label ID="lblInstruction2" runat="server">
                            <span style='color: maroon;'><strong>You have until <u>[effectiv]</u> to finish this
                                    process. Failure to submit correct documentation by this date
                                    may result in your dependent(s) not receiving coverage.</strong></span></asp:Label>

                        <asp:Label ID="lblWarning" runat="server" Visible="False">
                            <span style='color: red;'><strong>If there are no dependents listed below to validate –
                                    please click on Next at the bottom of this page to continue
                                    through the enrollment wizard.<br /><br /> </strong></span></asp:Label>
                    </div>
                    <div class="card">
                        <%--Employee Name--%>
                        <div class="card-header">
                            <h4 class='textFont' style="margin-bottom: 0;font-size: .9rem;">
                                <asp:Label ID="lblEEName" runat="server"></asp:Label>
                            </h4>
                        </div>

                        <div>


                            <%--Grid--%>
                            <div class='marginbottom02 textFont'>
                                <telerik:RadGrid ID="rgEEList" runat="server" AutoGenerateColumns="False"
                                    OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="rgEEList_ItemCommand">
                                    <MasterTableView DataKeyNames="dependent_sequence_no" AllowMultiColumnSorting="True"
                                        GroupLoadMode="Server" NoDetailRecordsText="No records to display." >
                                        <NestedViewTemplate>
                                            <telerik:RadGrid ID="rgDetal" runat="server" AutoGenerateColumns="False">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="record_id" HeaderText="Record ID"
                                                            UniqueName="column100">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"
                                                                Width="150px" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FILE_NAME" HeaderText="File Name"
                                                            UniqueName="column101">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"
                                                                Width="180px" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status"
                                                            UniqueName="column102">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"
                                                                Width="190px" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ACTION" HeaderText="Action"
                                                            UniqueName="column103">
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
                                            <telerik:GridBoundColumn DataField="doc_count_type" FilterControlAltText="Filter column3 column"
                                                HeaderText="Number &amp; Type of&lt;/br&gt;Documents Needed" UniqueName="column3">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UploadFaxButtons" FilterControlAltText="Filter column2 column"
                                                HeaderText="Documents&lt;/br&gt;Upload or Fax" UniqueName="column2">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            









                                            <%--<telerik:GridBoundColumn DataField=""
                                FilterControlAltText="Filter column2 column"
                                HeaderText="Remove&lt;/br&gt;Dependent" UniqueName="column2">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>--%>
                                            <%-- <telerik:GridBoundColumn DataField="dependent_sequence_no" Visible="false"
                                FilterControlAltText="Filter column2 column"
                                HeaderText="Remove&lt;/br&gt;Dependent" UniqueName="colDepSequenceNum">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>--%>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </div>

                            <div class='marginbottom02 textFont' id="dvFaxSent" runat="server">
                                <asp:Label ID="lblGeneratedFaxws" runat="server" Text="Generated Faxes</br>" CssClass="FontSmall10 FontBold"></asp:Label>
                                <telerik:RadGrid ID="rgFax" runat="server" AutoGenerateColumns="False" OnNeedDataSource="rgFax_NeedDataSource"
                                    OnItemCommand="rgFax_ItemCommand" GroupPanelPosition="Top" RenderMode="Lightweight">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                                    <MasterTableView DataKeyNames="dependent_sequence_no" AllowMultiColumnSorting="True"
                                        GroupLoadMode="Server" NoDetailRecordsText="No records to display." >
                                        <NestedViewTemplate>
                                            <telerik:RadGrid ID="rgDetal" runat="server" AutoGenerateColumns="False"  RenderMode="Lightweight">

                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="record_id" HeaderText="Record ID"
                                                            UniqueName="column100">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"
                                                                Width="150px" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FILE_NAME" HeaderText="File Name"
                                                            UniqueName="column101">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"
                                                                Width="180px" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status"
                                                            UniqueName="column102">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"
                                                                Width="190px" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ACTION" HeaderText="Action"
                                                            UniqueName="column103">
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
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column"
                                                UniqueName="TemplateColumn">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="320px" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="320px" />
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </div>



                            <%--Fax Section--%>
                            <div id='dvFax' runat="server" class=' floatleft'>
                                <div class='dataSubSetctionTitle BottomEdge '>
                                    <asp:Label ID="lblFaxOptionTitle" runat="server" Text="Fax or Mail Option"></asp:Label>
                                </div>

                                <div class='textFont paddingtop01'>
                                    <asp:Label ID="lblFaxInstruction" runat="server">
                                        <p><strong>Use this Option to print and mail/fax your supporting documents</strong></p>
                                        <ol>
                                            <li>Generate a personalized, bar-coded Fax/Mailing Coversheet</li>
                                            <li>Print the personalized, bar-coded Fax/Mailing Coversheet</li>
                                            <li>Mail or fax the supporting documents, along with the Coversheet. Faxing
                                                and
                                                mailing instructions are located on the Coversheet you print.</li>
                                        </ol>
                                    </asp:Label>
                                </div>
                                <div  style="font-family: Arial; font-size: 14pt; color: #FF0000; font-weight: bold;">
                                    If you are submitting documentation for more than one dependent, you MUST use a
                                    separate
                                    fax cover sheet for each dependent and fax them separately. Make sure to use the
                                    correct
                                    personalized cover sheet for each fax transmission.
                                </div>
                                <div class='RightArea textFont margintopxx CenterText'>
                                    <asp:Button ID="btnPrintCoverSheet" runat="server" Text="Print Coversheet" Width="115px" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='RightArea textFont margintopxx ' style="margin:50px 0px;">
                        <asp:Button ID="btnDone" runat="server" Text="Done" CssClass="uk-button uk-button-primary uk-border-pill" visible="false" OnClientClick="javascript:GotoDepMain()"   />
                        <!-- <a id="homeBtn" class="btn btn-primary" style="color: white;text-decoration: none">
                            Return to Home Page
                       </a> -->
                    </div>
                </div>
                <p>
                    &nbsp;
                </p>
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

                    function GotoDepMain() {
                        
                        var parURL = parent.window.location;
                        //alert(parURL); 
                        parURL =  parURL.toString();
                        var parurlUo = parURL.toUpperCase();
                        //alert(parurlUo);
                        var indx = parurlUo.indexOf('ENROLLMENTWIZARD');
                        //alert(indx);
                        

                        if (indx == -1)
                             document.location.href = "/WEB_PROJECTS/DEPENDENTS_MAINTENANCE/DefaultOld.aspx?SkipCheck=YES";
                        if (indx != -1)
                           parent.document.location.href = "/web_projects/EnrollmentWizard/DependentInfo.aspx?SkipCheck=YES";

                    }

                    function HidDoneBtn() {
                        var parURL = parent.window.location;                        
                        parURL =  parURL.toString();
                        var parurlUo = parURL.toUpperCase();                        
                        var indx = parurlUo.indexOf('ENROLLMENTWIZARD');                        
                        if (indx != -1)
                            document.getElementById("btnDone").style.display = "none";
                    }


                    
                    // ]]>
                </script>
        </asp:Panel>
        
    </form>

    
</body>

</html>