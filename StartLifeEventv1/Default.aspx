<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StartLifeEventv1.Default" EnableEventValidation="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Life Event</title>
    <link href="Life.css" rel="stylesheet" />
    <link href="NewSheet_No_Left.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script type="text/javascript">
        function GetEE(url) {
            alert('You have not selected an employee yet.\nYou will be redirected to the employee search ');
            window.open('/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/web_projects/EnrollmentWizard/le_start.aspx?SkipCheck=YES', '_self');
        }

        function NoAccess(msg) {
            alert(msg);
            window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        }

        function GotoOE() {
            alert('You have not completed your Open Enrollment. You will redirected to the Enrollment Wizard Module');
            window.open('/web_projects/EnrollmentWizard/Welcome.aspx?SkipCheck=YES&skip=1', '_self');
        }

        function InNewOE() {
            alert('Because you are currently in you new hire enrollment period, you may not enter a life event. ');
            window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        }

        function InOE(msg) {
            alert(msg);
            window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        }
    </script>

    <script type="text/javascript">

        function dateInput_OnError(sender, e) {
            var errormessage = document.getElementById('hidErrorDate').value;
            alert(errormessage);

        }

        function EffdateInput_OnError(sender, e) {
            var errormessage = document.getElementById('hidEffErrorDate').value;
            alert(errormessage);

        }
        function GetRadioButtonListSelectedValue(radioButtonList) {

            for (var i = 0; i < radioButtonList.rows.length; ++i) {

                if (radioButtonList.rows[i].cells[1].firstChild.checked) {
                    eval(document.getElementById('dvimg')).style.visibility = "visible";
                    location.replace("/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES");
                }
            }
        }

        function OnClientClicked(sender, args) {
            alert('Got it');
        }

        function OnClientButtonClicking(sender, args) {
            //if (eval(document.getElementById('hidTab1')).value = '1')

            //if (sender.get_activeWizardStep().get_index() == 4) {
            //    document.getElementById('hidSaveCoo').value = 'Go';
            //    __doPostBack(null, null);
            //}
            //alert('step'+sender.get_activeWizardStep().get_index());
            //hidfax(0)
            //alert(document.getElementById('hidtab3').value);
            //alert(sender.get_activeWizardStep().get_index())
            //if (sender.get_activeWizardStep().get_index() == 2) {                
            //    if (document.getElementById('hidtab3').value == '1') {

            //    }
            //}

        }

        function OnClientLoad(sender, args) {
            sender.get_wizardSteps().getWizardStep(0)
            //for (var i = 1; i < sender.get_wizardSteps().get_count() ; i++) {
            //    sender.get_wizardSteps().getWizardStep(i).set_enabled(false);
        }



        function Test() {
            alert('in test');
        }

        function GetFormattedDate(todayTime) {
            alert('GetFormattedDate');
            alert(todayTime);
            var month = format(todayTime.getMonth() + 1);
            alter(month);
            var day = format(todayTime.getDate());
            var year = format(todayTime.getFullYear());
            return month + "/" + day + "/" + year;

        }

        function OnDateSelectedOld(sender, args) {

            alert(here);
            //var myDate = new Date(sender.get_selectedDate().format("MM/dd/yyyy"));
            //alert(myDate);
            return;
            //eval(document.getElementById('dvimg')).style.visibility = "visible";
            //var dt = sender.get_selectedDate();
            //var myDate = new Date(sender.get_selectedDate().format("MM/dd/yyyy"));
            ////var dt = GetFormattedDate(sender.get_selectedDate());
            ////alert(dt);
            //myDate = myDate + '~' + document.getElementById('hidLifeEvent').value;
            //updatele(myDate);
            ////document.getElementById('hidSaveLife').value = 'Go';
            ////__doPostBack(null, null);

        }
        //function NoAccess(msg) {
        //    alert(msg);
        //    window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        //}

        function hidfax(hid) {

            if (hid == '0') {
                $('#dvFax').hide();
                $('#dvUpload').show()
                $('#htmbtnFax').show()
                $('#htmbtnUpload').hide()
            }
            else {
                $('#dvUpload').hide();
                $('#dvFax').show()
                $('#htmbtnFax').hide()
                $('#htmbtnUpload').show()
            }

        }

        function updatelex(param) {
            alert('here');
            $.ajax({
                type: "POST",
                url: "Default.aspx/SetLifeEvent",
                    <%-- data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',--%>
                data: '{name: " ' + param + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d);
        }


    </script>
    <script type="text/javascript" id="telerikClientEvents1">
        //<![CDATA[

        function NewRegistrationButton_Clicked(sender, args) {
            eval(document.getElementById('dvimg2')).style.visibility = "visible";
            document.getElementById('hidGotoWizard').value = 'Go';
            __doPostBack(null, null);

        }
        //]]>
    </script>
    <script type="text/javascript" id="telerikClientEvents2">
        //<![CDATA[

        function btnAgree_Clicked(sender, args) {
            args.set_cancel(true);
            document.getElementById('txtVal').value = 'abc';
        }


        //]]>
    </script>
    <script type="text/javascript" id="telerikClientEvents3">
        //<![CDATA[

        function updatele(param) {
            //alert('here');
            //alert(param);
            $.ajax({
                type: "POST",
                url: "Default.aspx/SetLifeEvent",
                <%-- data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',--%>
                data: '{name: " ' + param + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {

            if (response.d != "0") {
                var retValue = response.d;
                var res = retValue.split("~");
                document.getElementById("lblDocumentation1").innerHTML = res[0];
                document.getElementById("lblDocumentation1").setAttribute('title', res[1]);
            }

        }
        function btnDisagree_Clicking(sender, args) {

            eval(document.getElementById('dvimg')).style.visibility = "visible";
            eval(document.getElementById('hidGoToDemgraohic')).value = 'Go';
            __doPostBack(null, null);

            // window.open("/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES",'_self');
        }

        function OnClientLoad(sender, args) {
            var activeStep = sender.get_activeWizardStep();
            if (activeStep.get_cssClass().indexOf("hide-next-button") >= 0) {
                $telerik.$('.rwzNav .rwzPrevious').hide();
            }
        }

        function Remove(docid) {
            if (confirm('Are you sure you want to remove this documnet?'))
                updatele("-" + docid)
            else
                return;
        }

        function OnClientButtonClicked(sender, args) {
            var command = args.get_command();
            // Finish Button
            if (command == "2") {
                window.open('GoToEntollment.aspx', '_self');
                return;
            }
            // if cancel button is clicked
            if (command == "3") {
                if (confirm('Are you sure you want to exit Life Event program') == true) {
                    eval(document.getElementById('dvimg')).style.visibility = "visible";
                    window.open('/WEB_PROJECTS/DEMOGRAPHICSPAGE/DEFAULT.ASPX?SkipCheck=YES', '_self');
                    return;
                }
            }
            // if Next button clicked
            if (command == "1") {
                //document.getElementById("pnlimg").style.visibility='visible';
                var activeIndex = sender.get_activeIndex();
                //alert(""+activeIndex);
                updatele("" + activeIndex)
                return;
                if (activeIndex > 0) {
                    sender.set_activeIndex(activeIndex + 1)
                }
            }

            // if Previous button clicked
            if (command == "0") {
                //document.getElementById("pnlimg").style.visibility='visible';
                var activeIndex = sender.get_activeIndex();
                //alert(activeIndex);
                updatele("" + activeIndex)
                return;
                if (activeIndex > 0) {
                    sender.set_activeIndex(activeIndex + 1)
                }
            }

            // if Tab clicked
            if (command == "4") {
                //document.getElementById("pnlimg").style.visibility='visible';
                var activeIndex = sender.get_activeIndex();
                //alert(activeIndex);
                updatele("" + activeIndex)
                return;
                if (activeIndex > 0) {
                    sender.set_activeIndex(activeIndex + 1)
                }
            }

            var activeStep = sender.get_activeWizardStep();
            if (activeStep.get_cssClass().indexOf("hide-next-button") >= 0) {
                $telerik.$('.rwzNav .rwzNext').hide();
            } else {
                $telerik.$('.rwzNav .rwzNext').show();
            }

        }

        function refreshDoc(strLE_EE_ID) {
            //alert('refreshDoc')
            //updatele("" + strLE_EE_ID)
            updatele(strLE_EE_ID)
            //document.getElementById('hidRefrehDoc').value='Go';
            //__doPostBack(null,null);
            //alert('in refreshDoc '+strLE_EE_ID);
        }

        function cbHandel(cb) {
            if (cb.checked)
                document.getElementById('txtVal').value = 'abc';
            else
                document.getElementById('txtVal').value = '';
            //alert (cb.checked);
        }
        //]]>
    </script>

    <style type="text/css">
        .rwzContentWrapper {
            width: 85% !important;
            margin-right: auto !important;
            margin-left: auto !important;
            background: #ffffff !important;
            min-width: 700px !important;
            box-shadow: 0px 0px 2px #d1d1d1, 0px 2px 9px #d1d1d1 !important;
            padding: 10px !important;
            margin-bottom: 20px;
        }

        .rwzContent {
            width: 95% !important;
            margin-right: auto !important;
            margin-left: auto !important;
        }

        .RadWizard_Bootstrap {
            box-shadow: 0px 0px 5px, 0px 2px 9px;
            padding: 15px;
        }

        .RadWizard_Bootstrap {
            background: #f0f0f0 !important;
        }

        .auto-style2 {
            width: 70%;
            text-align: left;
            height: 21px;
        }

        .auto-style3 {
            width: 50%;
            text-align: left;
            font-weight: bold;
            color: #273473;
            height: 21px;
        }

        .auto-style4 {
            width: 1%;
            height: 22px;
        }

        .auto-style5 {
            height: 22px;
        }

        .auto-style8 {
            height: 21px;
        }

        .auto-style9 {
            width: 12%;
            text-align: left;
            font-weight: bold;
            color: #273473;
            vertical-align: top;
            height: 21px;
        }

        .auto-style10 {
            width: 88%;
            text-align: left;
            height: 21px;
        }

        .RadGrid .rgSelectedRow {
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow {
            background: #7FFFD4 !important;
            //Try setting background to get the desired hover color;
        }

        html .RadWizard {
            line-height: 1.4em !important;
            overflow: hidden !important;
        }

        .RadWizard .rwzContent {
            overflow: hidden !important;
        }
        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 10px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            position: relative;
            top: 200px;
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            border: 1px solid #888;
            width: 80%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.4s;
            animation-name: animatetop;
            animation-duration: 0.4s;
        }

        /* Add Animation */
        @-webkit-keyframes animatetop {
            from {
                middle: -300px;
                opacity: 0;
            }

            to {
                middle: 0;
                opacity: 1;
            }
        }

        @keyframes animatetop {
            from {
                middle: -300px;
                opacity: 0;
            }

            to {
                middle: 0;
                opacity: 1;
            }
        }

        /* The Close Button */
        .close {
            color: white;
            font-size: 28px;
            font-weight: bold;
            display: inline-block;
            float: right;
            padding-right: 10px;
            padding-top: 5px;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .modal-header {
            background-color: #5cb85c;
            color: white;
        }

        .modal-body {
            padding: 2px 2px;
        }

        .modal-footer {
            padding: 2px 16px;
            background-color: #5cb85c;
            color: white;
        }
    </style>

    <script type="text/javascript" id="telerikClientEvents4">
        //<![CDATA[

        function NewRegistrationButton_Clickedbtn(sender, args) {
            openRadWindow(null, null);
        }
        //]]>
    </script>

    <script type="text/javascript" id="telerikClientEvents5">
        //<![CDATA[

        //function openRadWindow(sender, args) {
        //    alert('openRadWindow');
        //    var oWindow = window.radopen("ManageDocs.aspx", null, 700, 550, 300, 220);
        //    alert('oWindow');
        //    oWindow.SetSize(700, 550);
        //    oWindow.top = 180;
        //    oWindow.SetTitle("Help");
        //    oWindow.SetModal(false);
        //    oWindow.OnClientResizeEnd = "SetWindowBehavior";
        //    //oWindow.Center();
        //}

        //function btnManageDocument_Clicked(sender,args)
        //{
        //    //alert('btnManageDocument_Clicked');
        //    //openRadWindow(null, null);
        //    window.open('ManageDocs.aspx?SkipCheck=YES', 'window', 'toolbar=no, menubar=no, resizable=yes, width=700px, height=500px ', '_blank');
        //}

        function OnClientclose(radWindow) {
            //aler('here');
            var retcode = radWindow.argument;
            var strLE_EE_ID = "" + retcode;
            //alert('strLE_EE_ID ' + strLE_EE_ID);

            refreshDoc("" + strLE_EE_ID)
            radWindow.argument = 0;
            return;

            //if (radWindow.argument)
            //    retcode = radWindow.argument
            //aler(retcode)
            //if (retcode != '0') {

            //}
        }
        //]]>
    </script>

    <script type="text/javascript" id="telerikClientEvents6">
        //<![CDATA[

        function btnManageDocument_Clicked(sender, args) {
            //alert('here')
            var oWindow = window.radopen("ManageDocs.aspx", null);
            oWindow.SetSize(730, 375);
            oWindow.SetModal(true);
            //oWindow.OnClientClose = "OnClientclose";


        }

        function ERInstuctio_Clicked(sender, args) {
            //alert('here')
            var oWindow = window.radopen("EmployerInstruction.aspx", null);
            oWindow.SetSize(730, 470);
            oWindow.SetModal(true);
            //oWindow.OnClientClose = "OnClientclose";


        }

        function Acknowledgment_Clicked(sender, args) {

            var oWindow = window.radopen("EmployerInstruction.aspx?ack=1", null);
            oWindow.SetSize(730, 470);
            oWindow.SetModal(true);
            //oWindow.OnClientClose = "OnClientclose";
        }

        function lnkAcknowledgment_Clicked() {
            alert('here1');
            Acknowledgment_Clicked(null, null)
        }
        //]]>

        // Get the modal
        var modal = document.getElementById('myModal');

        // Get the button that opens the modal
        var btn = document.getElementById("myBtn");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal 
        btn.onclick = function () {
            modal.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="whirlyGig">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="Panel1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadSkinManager runat="server" EnableEmbeddedSkins="False" Skin="Bootstrap"></telerik:RadSkinManager>
        <telerik:RadAjaxLoadingPanel ID="whirlyGig" runat="server" Skin="Bootstrap" Height="80%" Width="100%" Style="position: absolute; top: 88px; left: 10px;" IsSticky="true" />

        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" HideEvent="ManualClose" Position="BottomRight" BackColor="#CCCCCC" Height="150px"
            Width="350px" ContentScrolling="Auto" ManualClose="false" Skin="Default">
            <TargetControls>
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblDocumentation" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblDocumentation0" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblDocumentation1" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblDocumentation2" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblDocumentation3" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblDocumentation4" Value="" />

                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblComments" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblComments0" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblComments1" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblComments2" Value="" />
                <telerik:ToolTipTargetControl IsClientID="true" TargetControlID="lblComments3" Value="" />
            </TargetControls>

        </telerik:RadToolTipManager>

        <telerik:RadWindowManager ID="RadWindowManager1"
            runat="server"
            VisibleStatusbar="false"
            VisibleTitlebar="false"
            ShowContentDuringLoad="false"
            OnClientClose="OnClientclose"
            Style="z-index: 1000000">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server"
                    NavigateUrl="ManageDocs_xx.aspx"
                    OpenerElementID="btnManageDocument_xx"
                    Left="5" Top="1px"
                    OnClientClose="OnClientclose"
                    ReloadOnShow="True"
                    Style="display: none;"
                    Behavior="Default"
                    InitialBehavior="None"
                    Modal="True"
                    VisibleStatusbar="False"
                    Width="730px"
                    Height="375px"
                    ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script>

                function CallHelp() {
                    openRadWindow(null, null);
                }
            </script>
        </telerik:RadScriptBlock>
        <asp:HiddenField ID="hidSaveLife" runat="server" />
        <asp:HiddenField ID="hidSaveCoo" runat="server" />
        <asp:HiddenField ID="hidGotoWizard" runat="server" />
        <asp:HiddenField ID="hidLifeEvent" runat="server" />
        <asp:HiddenField ID="hidtab3" runat="server" />
        <asp:HiddenField ID="hidGoToDemgraohic" runat="server" />
        <asp:HiddenField ID="hidRefrehDoc" runat="server" />
        <asp:HiddenField ID="hidErrorDate" runat="server" />
        <asp:HiddenField ID="hidEffErrorDate" runat="server" />
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="16px" Skin="Default">
        </telerik:RadAjaxLoadingPanel>

        <div class="floatMid" id="dvimg" style="position: absolute; top: 300px; left: 320px; right: 783px; width: 150px; z-index: 1000; visibility: hidden; background-color: #FFFFFF;">
            <%--<asp:Image ID="Image5" runat="server" Style="margin-left: auto; margin-right: auto"
                ImageUrl="https://www.myenroll.com/images/busy.gif" />--%>
            <span style="font-size: 12pt; font-weight: bold; color: #993300; font-family: Arial, Helvetica, sans-serif;">Redirecting Please Wait</span>
        </div>
        <asp:Panel ID="Panel1" runat="server">

            <div style="width: 99%; margin: auto; min-width: 750px;">
                <div class="pageTitle" style="margin-bottom: 5px">Life Event</div>
                <telerik:RadWizard ID="RadWizard1" runat="server" Width="100%" OnPreviousButtonClick="RadWizard1_PreviousButtonClick"
                    OnNextButtonClick="RadWizard1_NextButtonClick" RenderMode="Lightweight" Skin="Bootstrap"
                    OnClientLoad="OnClientLoad" OnClientButtonClicked="OnClientButtonClicked" DisplayCancelButton="true">
                    <WizardSteps>

                        <telerik:RadWizardStep ID="Instruction" runat="server" ValidationGroup="valAgree">
                            <div class="FullPage marginBottom10">
                                <asp:Label ID="Label6" runat="server" CssClass="FontLarge FontBold">Instruction</asp:Label>
                            </div>
                            <div class="FullPage">
                                <div style="width: 98%">
                                    <div class="FontSmall10 mnwidth decorate" style="width: 100%; margin: 5px;">
                                        <telerik:RadPanelBar ID="RadPanelBar2" runat="server" Width="100%" ExpandMode="FullExpandedItem" Skin="Default">


                                            <Items>

                                                <telerik:RadPanelItem runat="server" Text="<span class='pageTitle'>F.A.Q.</span>" Value="Instruction">
                                                    <Items>
                                                        <telerik:RadPanelItem runat="server" Value="i0">
                                                            <ItemTemplate>
                                                                <div style="overflow: auto; height: 300px; padding-left: 5px; padding-right: 5px;">
                                                                    <asp:Label ID="lblFAQ" runat="server">Insert Text Here (CALL FROM DB)</asp:Label>
                                                                </div>

                                                            </ItemTemplate>
                                                        </telerik:RadPanelItem>
                                                    </Items>
                                                </telerik:RadPanelItem>

                                                <telerik:RadPanelItem runat="server" Text="<span class='pageTitle'>What Documents do I Need?</span>" Value="UloadFax">
                                                    <Items>
                                                        <telerik:RadPanelItem runat="server" Value="frames">
                                                            <ItemTemplate>
                                                                <div style="overflow: auto; height: 300px; padding-left: 5px; padding-right: 5px;">
                                                                    <asp:Label ID="lblWhatINeed" runat="server">Insert Text Here (CALL FROM DB)</asp:Label>
                                                                </div>
                                                            </ItemTemplate>

                                                        </telerik:RadPanelItem>
                                                    </Items>
                                                </telerik:RadPanelItem>
                                            </Items>
                                        </telerik:RadPanelBar>
                                    </div>
                                </div>
                            </div>

                        </telerik:RadWizardStep>

                        <telerik:RadWizardStep ID="Acknowledge" runat="server" ValidationGroup="valAgree" CssClass="hide-next-button">


                            <div class="centerWiz" style="height: 220px; width: 100%;">

                                <div class="FullPage70 centerDiv LeftFloat" style="height: 220px; width: 45%; display: none">
                                    <div class="FullPage70 marginBottom10">
                                        <asp:Label ID="Label2" runat="server" CssClass="FontLarge FontBold">Acknowledgment</asp:Label>
                                    </div>
                                    <div class="FontSmall10" style="width: 100%; height: 350px; margin: 5px;">



                                        <table class="LifeTable decorate" style="width: 100%;">
                                            <tr>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                                <td class=".lefTableCell">
                                                    <asp:Label ID="Label4" runat="server" CssClass="FontMedium FontBold marginBottom10">Employee Acknowledgment and Certification</asp:Label>
                                                </td>


                                            </tr>
                                            <tr>
                                                <td class="auto-style4"></td>
                                                <td class="auto-style5">
                                                    <div style="overflow: auto; width: 100%; height: 200px; text-align: left;">
                                                        <asp:Label ID="lblAcknowledgeText" runat="server" CssClass="FontSmall10 "></asp:Label>
                                                    </div>
                                                </td>

                                            </tr>


                                        </table>
                                        <div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVal" CssClass="Fonterror" ErrorMessage="You must scroll to the bottom of the Employee Acknowledgment and Certification and Check the I Agree Box first" ValidationGroup="valAgree"></asp:RequiredFieldValidator>
                                        </div>
                                        <div style="display: none">
                                            <asp:TextBox ID="txtVal" runat="server"></asp:TextBox>
                                        </div>

                                        <table class="LifeTable " style="visibility: hidden">
                                            <tr>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                                <td class=".lefTableCell">&nbsp;</td>
                                                <td class="rightTableCell">&nbsp;</td>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2" style="text-align: center">
                                                    <telerik:RadButton ID="RadButton4" runat="server" Text="Back" CssClass="buttonblue" Skin="Default" Width="150px" OnClick="btnBack_Click" ValidationGroup="valWhat" CausesValidation="False"></telerik:RadButton>
                                                    &nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButton5" runat="server" Text="Next" CssClass="buttonblue" Skin="Default" Width="150px" OnClick="btnAgree_Click" ValidationGroup="valWhat"></telerik:RadButton>

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>


                                    </div>
                                </div>
                                <div class="FullPage30 centerDiv" style="height: 200px; width: 90%; margin: 10px; display: block; margin: auto">
                                    <div class="FullPage73 marginBottom10">
                                        <asp:Label runat="server" CssClass="FontLarge FontBold">Instructions from your Employer</asp:Label>
                                    </div>
                                    <div class="FullPage centerTavkeVertally" style="height: 220px; vertical-align: top; float: right; padding: 0 !important; margin-right: 10px">
                                        <%-- start--%>

                                        <table class="LifeTable decorate" style="width: 100%">
                                            <tr style="display: none">
                                                <td class="leftRightTableCell">&nbsp;</td>
                                                <td class="lefTableCell">
                                                    <asp:Label ID="Label7" Style="color: black; display: none" runat="server" CssClass="FontMedium FontBold marginBottom10">Employer Instructions</asp:Label>
                                                </td>


                                            </tr>
                                            <tr>
                                                <td class="auto-style4" style="display: none"></td>
                                                <td class="leftRightTableCell">
                                                    <div style="overflow: auto; width: 100%; height: 200px; text-align: left;">
                                                        <div style="width: 95%; margin: auto">
                                                            <asp:Label ID="lblEmployerInstruction" runat="server" CssClass="FontSmall10 "></asp:Label>
                                                        </div>
                                                    </div>
                                                </td>

                                            </tr>


                                        </table>


                                        <%-- end --%>











                                        <table class="infotable decorate" style="float: right; width: 95%; visibility: hidden;">
                                            <tr>
                                                <td class="auto-style3">
                                                    <asp:Label ID="Label9" runat="server" Text="Life Event"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblLifeEvent" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">
                                                    <asp:Label ID="Label11" runat="server" Text="Event Date"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblEventDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lefTableCell">
                                                    <asp:Label ID="Label13" runat="server" Text="Documentation"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblDocumentation" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lefTableCell">
                                                    <asp:Label ID="Label15" runat="server" Text="Comments"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblComments" runat="server"></asp:Label>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </div>
                            </div>



                            <%-- Acknowledgment--%>
                            <div id="ackbutton" style="width: 90%; margin: auto">
                                <div class="FullPage" style="width: 90%">
                                </div>
                                <table>
                                    <tr>
                                        <td>

                                            <telerik:RadCheckBox ID="cbAcknowledgment" runat="server" Text="I Accept the" OnClick="cbAcknowledgment_Click"></telerik:RadCheckBox>
                                        </td>
                                        <td>
                                            <telerik:RadButton RenderMode="Lightweight" Style="background-color: transparent !important; background-image: none !important; border: none !important; color: blue !important; text-decoration: underline; padding: 0 !important; margin-top: 2px" runat="server" ID="btnAcknowledgment"
                                                OnClientClicked="Acknowledgment_Clicked" Text="Terms & Conditions" Skin="Bootstrap" />
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVal" CssClass="Fonterror" ErrorMessage="You must Check the I Agree Box first" ValidationGroup="valAgree"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                </table>

                            </div>
            </div>

            </telerik:RadWizardStep>
                        
                        <telerik:RadWizardStep ID="Type" runat="server" ValidationGroup="valWhat">
                            <div class="FullPage" style="height: 350px">

                                <div class="FullPage70 centerDiv LeftFloat" style="display: inline-block !important">

                                    <div class="FontSmall10" style="width: 100%; height: 255px; margin: 5px;">

                                        <div class="FullPage70 marginBottom10">
                                            <asp:Label ID="lblLifevent" runat="server" CssClass="FontLarge FontBold">Life Event</asp:Label>
                                        </div>

                                        <table align="left" class="LifeTable decorate" style="width: 100%">
                                            <tr>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                                <td class=".lefTableCell">&nbsp;</td>
                                                <td class="rightTableCell">&nbsp;</td>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="TitleLabel">
                                                    <asp:Label ID="lblEventGrouo" runat="server" Text="Event Group"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadDropDownList ID="ddlGroup" runat="server" AutoPostBack="True" CausesValidation="False" DefaultMessage="Event Group" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" Width="300px" CssClass="decorate" Skin="Bootstrap">
                                                    </telerik:RadDropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlGroup" CssClass="Fonterror" Display="Dynamic" ErrorMessage="Please select an Event Group" ValidationGroup="valWhat"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="TitleLabel">
                                                    <asp:Label ID="lblLifeEven" runat="server" Text="Life Event"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadDropDownList ID="ddlItem" runat="server" AutoPostBack="true" CausesValidation="False" DefaultMessage="Life Events" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Width="300px" CssClass="decorate" Skin="Bootstrap">
                                                    </telerik:RadDropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8"></td>
                                                <td class="auto-style8"></td>
                                                <td class="auto-style8">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlItem" CssClass="Fonterror" Display="Dynamic" ErrorMessage="Please select an Event Item" ValidationGroup="valWhat"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="auto-style8"></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="TitleLabel">
                                                    <asp:Label ID="lblLifeEven0" runat="server" Text="Life Event Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="txtLifeEventDate" runat="server" Culture="en-US" AutoPostBack="false" CssClass="decorate"
                                                        Skin="Bootstrap" Width="300px" OnSelectedDateChanged="txtLifeEventDate_SelectedDateChanged">

                                                        <Calendar EnableWeekends="True" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" Skin="Bootstrap">
                                                        </Calendar>
                                                        <DateInput runat="server" AutoPostBack="True" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" EmptyMessage="Life Event Date" LabelWidth="40%">
                                                            <ClientEvents OnError="dateInput_OnError" />
                                                            <EmptyMessageStyle Resize="None" />
                                                            <ReadOnlyStyle Resize="None" />
                                                            <FocusedStyle Resize="None" />
                                                            <DisabledStyle Resize="None" />
                                                            <InvalidStyle Resize="None" BackColor="#CC3300" ForeColor="White" />
                                                            <HoveredStyle Resize="None" />
                                                            <EnabledStyle Resize="None" />

                                                        </DateInput>


                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLifeEventDate" CssClass="Fonterror" Display="Dynamic" EnableTheming="True" ErrorMessage="Required Information" ValidationGroup="valWhat"></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtLifeEventDate" CssClass="Fonterror" Display="Dynamic"
                                                        ErrorMessage="RangeValidator" MaximumValue="1/1/2050" MinimumValue="1/1/1950" Type="Date" ValidationGroup="valWhat"></asp:RangeValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="TitleLabel" id="tdText" runat="server">
                                                    <asp:Label ID="Label1" runat="server" Text="New Cvrg. Effective Date"></asp:Label>
                                                </td>
                                                <td class="TitleLabel" id="tdContol" runat="server">
                                                    <asp:TextBox ID="txtNetEffectiveDate" runat="server" ReadOnly="True" Width="130px" BorderColor="White" BorderStyle="None" BorderWidth="0px" Font-Bold="True" ForeColor="#97D340"></asp:TextBox>
                                                    <telerik:RadDatePicker ID="txtEffectiveDate" runat="server" Culture="en-US" AutoPostBack="True"
                                                        CssClass="decorate" Skin="Bootstrap" Visible="False" Width="300px" OnSelectedDateChanged="txtEffectiveDate_SelectedDateChanged">

                                                        <Calendar EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" Skin="Bootstrap">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" EmptyMessage="Life Event Effective Date" LabelWidth="40%">
                                                            <ClientEvents OnError="EffdateInput_OnError" />
                                                            <EmptyMessageStyle Resize="None" />
                                                            <ReadOnlyStyle Resize="None" />
                                                            <FocusedStyle Resize="None" />
                                                            <DisabledStyle Resize="None" />
                                                            <InvalidStyle Resize="None" BackColor="#CC3300" ForeColor="White" />
                                                            <HoveredStyle Resize="None" />
                                                            <EnabledStyle Resize="None" />
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEffectiveDate" CssClass="Fonterror" Display="Dynamic" EnableTheming="True" ErrorMessage="Required Information" ValidationGroup="valWhat" Enabled="False"></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtEffectiveDate" CssClass="Fonterror" Display="Dynamic" ErrorMessage="RangeValidator" MaximumValue="1/1/2050" MinimumValue="1/1/1950" Type="Date" ValidationGroup="valWhat" Enabled="False"></asp:RangeValidator>
                                                </td>

                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">
                                                    <asp:Label ID="lblDateRange" runat="server" CssClass="dataSubSetctionTitle"></asp:Label><br />
                                                    <asp:Label ID="lblEddDateRange" runat="server" CssClass="dataSubSetctionTitle"></asp:Label>

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>

                                        <table class="LifeTable " style="visibility: hidden">
                                            <tr>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                                <td class=".lefTableCell">&nbsp;</td>
                                                <td class="rightTableCell">&nbsp;</td>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2" style="text-align: center">
                                                    <telerik:RadButton ID="RadButton2" runat="server" Text="Back" CssClass="buttonblue" Skin="Default" Width="150px" OnClick="btnBack_Click" ValidationGroup="valWhat" CausesValidation="False"></telerik:RadButton>
                                                    &nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButton1" runat="server" Text="Next" CssClass="buttonblue" Skin="Default" Width="150px" OnClick="btnAgree_Click" ValidationGroup="valWhat"></telerik:RadButton>

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>


                                    </div>
                                </div>
                                <div class="FullPage30 centerDiv RightFloat Paddingright10" style="display: inline-block !important">
                                    <div class="FullPage73 marginBottom10" style="margin-bottom: 15px">
                                        &nbsp;
                                    </div>
                                    <div class="FullPage centerTavkeVertally Paddingright10" style="height: 200px; vertical-align: top; padding-top: 5px">
                                        <table class="infotable decorate" style="float: right;">
                                            <tr>
                                                <td class="lefTableCell">
                                                    <asp:Label ID="lblLifeEventTitle0" runat="server" Text="Life Event"></asp:Label>
                                                </td>
                                                <td class="rightTableCell">
                                                    <asp:Label ID="lblLifeEvent0" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">
                                                    <asp:Label ID="lblEventDateTitlr0" runat="server" Text="Event Date"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblEventDate0" runat="server"> </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lefTableCell">
                                                    <asp:Label ID="lblDocumentationTitle0" runat="server" Text="Documentation"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblDocumentation0" runat="server"> </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">
                                                    <asp:Label ID="lblCommentsTitle0" runat="server" Text="Comments"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="lblComments0" runat="server"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>

                        </telerik:RadWizardStep>



            <telerik:RadWizardStep ID="Proof" runat="server">
                <div class="FullPage " style="height: 490px">

                    <div class="FullPage70 centerDiv LeftFloat ">
                        <div class="FullPage70 marginBottom10" style="width: 100%;">
                            <asp:Label ID="lbDocumentation" runat="server" CssClass="FontLarge FontBold">Documentation</asp:Label>
                            
                        </div>

                        <div class="FontSmall10 mnwidth decorate" style="width: 100%; margin: 5px;">

                            <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Width="100%" ExpandMode="FullExpandedItem" Skin="Default">


                                <Items>

                                    <telerik:RadPanelItem runat="server" Text="<span class='pageTitle'>Instruction</span?" Value="Instruction" Expanded="true">
                                        <Items>
                                            <telerik:RadPanelItem runat="server" Value="i0">
                                                <ItemTemplate>
                                                    <div style="padding-left: 5px; padding-right: 5px;">

                                                        <telerik:RadButton RenderMode="Lightweight" runat="server" ID="RadButton3"
                                                            OnClientClicked="ERInstuctio_Clicked" Text="Employer Instruction" Skin="Silk" Visible="False" />

                                                    </div>
                                                    <div style="overflow: auto; height: 300px; padding-left: 5px; padding-right: 5px;">
                                                        <asp:Label ID="lblInstruction" runat="server">Insert Text Here (CALL FROM DB)</asp:Label>
                                                    </div>
                                                    <div style="padding-left: 5px; padding-right: 5px;">
                                                        <%--<telerik:RadButton ID="btnGotIt" runat="server" Text="Got It" Primary="true" RenderMode="Lightweight"
                                                                        Style="top: 14px; left: 0px" OnClientClicked="OnClientClicked">
                                                                    </telerik:RadButton>--%>

                                                        <telerik:RadButton RenderMode="Lightweight" runat="server" ID="nextButton"
                                                            OnClick="nextButton_Click" Text="Got It" Skin="Silk" />

                                                    </div>
                                                </ItemTemplate>
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>

                                    <telerik:RadPanelItem runat="server" Text="<span class='pageTitle'>Upload or Fax</span>" Value="UloadFax">
                                        <Items>
                                            <telerik:RadPanelItem runat="server" Value="frames">
                                                <ItemTemplate>
                                                    <table class="FullPage" cellspacing="0" cellpadding="2" style="width: 100%; margin-top: 10px; margin-bottom: 10px; float: left;">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td style="border-right: 1px solid #f2f2f2;" class="auto-style3">
                                                                <asp:Label ID="lblUploadTitle" runat="server" Text="Upload  " CssClass="dataSubSetctionTitle"></asp:Label>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="JavaScript:expandItem('Instruction')">
                                                                    <span style="text-decoration: underline; color: navy;">Open Instruction</span></asp:HyperLink>                                                                
                                                            </td>
                                                            <td>
                                                                <div style="z-index: 10000; top: 150px; position: relative; left: -15px; font-family: Arial, Helvetica, sans-serif; font-size: 12pt; font-weight: bold;">OR</div>
                                                            </td>
                                                            <td style="width: 50%;">

                                                                <asp:Label ID="lblFaxTitle" runat="server" Text="Fax" CssClass="dataSubSetctionTitle"></asp:Label>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td style="border-right: 1px solid #f2f2f2;" class="auto-style3">
                                                                <iframe id="iUpload" runat="server" frameborder="0" name="Upload Frame"
                                                                    scrolling="no"
                                                                    title="Upload Frame"
                                                                    visible="true"
                                                                    height="300"
                                                                    width="250"
                                                                    src="ProofPage.aspx"></iframe>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td style="width: 50%; text-align: center;">

                                                                <iframe id="iFax" runat="server" frameborder="0" name="Create Fax"
                                                                    scrolling="no"
                                                                    title="Create Fax"
                                                                    visible="true"
                                                                    height="300"
                                                                    width="250"
                                                                    src="FaxPage.aspx"></iframe>
                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td class="auto-style3">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>


                                                </ItemTemplate>

                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelBar>

                        </div>
                        <div style="width: 100%;">
                            <div style="width: 247px; margin-right: auto; margin-left: auto">
                                <telerik:RadButton ID="btnManageDocument" runat="server" Text="Manage My Documents" Primary="true" RenderMode="Lightweight"
                                    Style="top: 14px; left: 0px" OnClientClicked="btnManageDocument_Clicked" Visible="False">
                                </telerik:RadButton>
                            </div>

                        </div>

                    </div>

                    <%-- ----------------%>
                    <div class="FullPage30 centerDiv RightFloat Paddingright10">
                        <div class="FullPage73 marginBottom10" style="margin-bottom: 14px">
                            &nbsp;
                        </div>
                        <div class="FullPage centerTavkeVertally Paddingright10" style="height: 250px; vertical-align: top; padding-top: 5px">
                            <table class="infotable decorate" style="float: right; width: 95%;">
                                <tr>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblLifeEventTitle1" runat="server" Text="Life Event"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblLifeEvent1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lefTableCell">
                                        <asp:Label ID="lblEventDateTitlr1" runat="server" Text="Event Date"></asp:Label>
                                    </td>
                                    <td class="rightTableCell">
                                        <asp:Label ID="lblEventDate1" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblDocumentationTitle1" runat="server" Text="Documentation"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblDocumentation1" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lefTableCell">
                                        <asp:Label ID="lblCommentsTitle1" runat="server" Text="Comments"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblComments1" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <%-- -------------------%>
                </div>



            </telerik:RadWizardStep>


            <telerik:RadWizardStep ID="Comments" runat="server">
                <div class="FullPage ">


                    <div class="FullPage70 centerDiv LeftFloat " style="width: 60%">
                        <div class="FullPage70 marginBottom10">
                            <asp:Label ID="Label3" runat="server" CssClass="FontLarge FontBold">Comments to your Administrator</asp:Label>
                        </div>
                        <div class="FontSmall10 decorate" style="width: 100%; margin: 5px;">
                            <asp:TextBox ID="txtNote" runat="server" Height="200px" OnTextChanged="txtNote_TextChanged" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="FullPage30 centerDiv RightFloat Paddingright10" style="width: 35%">
                        <div class="FullPage73 marginBottom10" style="margin-bottom: 14px">
                            &nbsp;
                        </div>
                        <div class="FullPage centerTavkeVertally Paddingright10" style="height: 250px; vertical-align: top; padding-top: 5px">
                            <table class="infotable decorate" style="float: right;">
                                <tr>
                                    <td class="lefTableCell">
                                        <asp:Label ID="lblLifeEventTitle2" runat="server" Text="Life Event"></asp:Label>
                                    </td>
                                    <td class="rightTableCell">
                                        <asp:Label ID="lblLifeEvent2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblEventDateTitlr2" runat="server" Text="Event Date"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblEventDate2" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lefTableCell">
                                        <asp:Label ID="lblDocumentationTitle2" runat="server" Text="Documentation"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblDocumentation2" runat="server">Document Attached</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lefTableCell">
                                        <asp:Label ID="lblCommentsTitle2" runat="server" Text="Comments"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblComments2" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
            </telerik:RadWizardStep>

            <telerik:RadWizardStep ID="Confirmation" runat="server">
                <div class="FullPage">

                    <div class="centerDiv" style="width: 90%; margin: auto">
                        <div class="marginBottom10" style="width: 95%">
                            <asp:Label ID="Label5" runat="server" CssClass="FontLarge FontBold">Confirmation</asp:Label>
                        </div>
                        <div class="FontSmall10" style="width: 100%; height: 150px; margin: 5px;">



                            <table class="infotable decorate" style="float: right; width: 100%;">
                                <tr>
                                    <td class="lefTableCellConfirm" style="vertical-align: top;">
                                        <asp:Label ID="lblLifeEventTitle4" runat="server" Text="Life Event" CssClass="Font"></asp:Label>
                                    </td>
                                    <td class="rightTableCellConfirm" style="height: 30px; vertical-align: top;">
                                        <asp:Label ID="lblLifeEvent4" runat="server" CssClass="FontMeduim"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lefTableCellConfirm" style="vertical-align: top;">
                                        <asp:Label ID="lblEventDateTitlr4" runat="server" Text="Event Date" CssClass="Font"></asp:Label>
                                    </td>
                                    <td class="rightTableCellConfirm" style="height: 30px; vertical-align: top;">
                                        <asp:Label ID="lblEventDate4" runat="server" CssClass="FontMeduim"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style9" style="vertical-align: top;">
                                        <asp:Label ID="lblDocumentationTitle4" runat="server" Text="Documentation" CssClass="Font"></asp:Label>
                                    </td>
                                    <td class="auto-style10" style="height: 30px; vertical-align: top;">
                                        <asp:Label ID="lblDocumentation4" runat="server" CssClass="FontMeduim">Document Attached</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lefTableCellConfirm" style="vertical-align: top;">
                                        <asp:Label ID="lblCommentsTitle4" runat="server" Text="Comments" CssClass="Font"></asp:Label>
                                    </td>
                                    <td class="rightTableCellConfirm" style="height: 30px; vertical-align: top;">
                                        <asp:Label ID="lblComments4" runat="server" CssClass="FontMeduim"></asp:Label>
                                    </td>
                                </tr>
                            </table>


                        </div>
                    </div>

                    <%-- <div class="FullPage30 centerDiv RightFloat Paddingright10" style="width: 50%" runat="server" visible="false">
                                <div class="FullPage73 marginBottom10">
                                    &nbsp;
                                </div>
                                <div class="FullPage centerTavkeVertally Paddingright10" style="height: 250px; vertical-align: top; padding-top: 5px">


                                    <table class="infotable decorate" style="float: right;">
                                        <tr>
                                            <td class="lefTableCell">
                                                <asp:Label ID="lblLifeEventTitle3" runat="server" Text="Life Event"></asp:Label>
                                            </td>
                                            <td class="rightTableCell">
                                                <asp:Label ID="lblLifeEvent3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style3">
                                                <asp:Label ID="lblEventDateTitlr3" runat="server" Text="Event Date"></asp:Label>
                                            </td>
                                            <td class="rightTableCell">
                                                <asp:Label ID="lblEventDate3" runat="server"> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lefTableCell">
                                                <asp:Label ID="lblDocumentationTitle3" runat="server" Text="Documentation"></asp:Label>
                                            </td>
                                            <td class="rightTableCell">
                                                <asp:Label ID="lblDocumentation3" runat="server">Document Attached</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lefTableCell">
                                                <asp:Label ID="lblCommentsTitle3" runat="server" Text="Comments"></asp:Label>
                                            </td>
                                            <td class="rightTableCell">
                                                <asp:Label ID="lblComments3" runat="server">Comments .....</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>--%>
                </div>
            </telerik:RadWizardStep>

            <telerik:RadWizardStep ID="Enrollment" StepType="Complete" runat="server">

                <p style="text-align: center">Congratulations, you have completed the initial setup successfully!</p>
                <div style="text-align: center; width: 100%">
                    <telerik:RadButton RenderMode="Lightweight" ID="NewRegistrationButton" runat="server" Text="Continue with Life Event" OnClientClicked="NewRegistrationButton_Clickedbtn"></telerik:RadButton>
                </div>
                <div class="floatMid" id="dvimg2" style="width: 400px; z-index: 100000; visibility: hidden; background-color: #FFFFFF; margin-right: auto; margin-left: auto;">
                    <asp:Image ID="Image1" runat="server" Style="margin-left: auto; margin-right: auto"
                        ImageUrl="~/img/progress_notext.gif" />
                    <%--<span style="font-size: 12pt; font-weight: bold; color: #993300; font-family: Arial, Helvetica, sans-serif;">Redirecting Please Wait</span>--%>
                </div>


            </telerik:RadWizardStep>


            </WizardSteps>
                </telerik:RadWizard>
            </div>
        </asp:Panel>
        <div id="pnlimg" class="floatMid" style="position: absolute; top: 200px; left: 320px; right: 783px; width: 150px; z-index: 1000; visibility: hidden;">

            <img id="Image2" src="~/img/progress_notext.gif" style="margin-left: auto; margin-right: auto" />

        </div>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function expandItem(text) {
                    var panelBar = $find("<%= RadPanelBar1.ClientID %>");
                var item = panelBar.findItemByText(text);
                if (item) {
                    item.expand();
                }
                else {
                    alert("Item with text '" + text + "' not found.");
                }
            }
            </script>
        </telerik:RadCodeBlock>
    </form>

</body>
</html>
