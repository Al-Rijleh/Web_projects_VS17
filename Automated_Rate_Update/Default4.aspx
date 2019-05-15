<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default4.aspx.cs" Inherits="Automated_Rate_Update.Default4" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Layout.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <style type="text/css">
        div.RadToolTip_Default table.rtWrapper td.rtWrapperContent {
            background-color: #fdfdfd !important;
        }

        .error {
            font-family: Arial, Sans-Serif;
            font-size: 10pt;
            font-weight: bold;
            color: Maroon;
            background-color: Yellow;
            border-top-width: 1px;
            border-left-width: 1px;
            border-left-color: #000000;
            border-bottom-width: 1px;
            border-bottom-color: #000000;
            border-top-color: #000000;
            border-right-width: 1px;
            border-right-color: #000000;
        }

        .InfoBKGround {
            background-color: #C6D3DA;
        }

        .style1 {
            height: 18px;
        }

        .BackG {
            background-color: #FFF4CD !important;
        }

        .style2 {
            height: 42px;
        }

        .LeftTitle {
            width: 70px;
            float: left;
        }

        .RadGrid .rgSelectedRow {
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow {
            background: #7FFFD4 !important;
            /*Try setting background to get the desired hover color;*/
        }

        .myfontx {
            font-size: 9pt !important;
            font-weight: bold !important;
            color: blue !important;
            margin-left: 3px;
            text-decoration: none;
        }
    </style>
    <script type="text/javascript">
        function remove(longdesc) {
            if (confirm('Are you sure you want to REMOVE Coverage' + longdesc + ' ?')) {
                eval(document.getElementById('hidRemove')).value = "OK";
                //__doPostBack(null, null);
                PostBack();
            }
        }

        function DoManage(id) {
            document.getElementById('hidCvrgID').value = id;

            __doPostBack(null, null);
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

        function ShowSaved() {
            alert("Saved Successfully!!\n Because you accessed this program from an email, you will be redirected to Bas Home Page.");
            window.open('http://www.basusa.com', '_self');
        }

        function ShowSavedBas() {
            alert("Saved Successfully!!");
            window.open('BASLogin.aspx', '_self');
        }

        function DoSave() {
            if (confirm('Are you sure you want to finalize this update? Once you finalize you will not be able to make any changes. If you are not certain that the information you entered is correct, do not finalize and contact your account manager.') == true) {
                document.getElementById('htmImgBusy').style.visibility = "visible";
                document.getElementById('htmbtnSave').style.visibility = "hidden";
                eval(document.getElementById('hidSave')).value = 'save';
                __doPostBack(null, null);
            }
        }

        function Rest() {
            if (confirm('Are you sure you want to Reset ALL the changes made.') == true) {
                document.getElementById('htmImgBusy').style.visibility = "visible";
                document.getElementById('htmbtnSave').style.visibility = "hidden";
                eval(document.getElementById('hidSave')).value = 'Reset';
                __doPostBack(null, null);
            }
        }

        function OnClientclose(radWindow) {

            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument;

            if (retcode == "1") {
                radWindow.argument = 0;
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
                radWindow.argument = 0;
                document.location.replace('/web_projects/Verify_Dependents/Default.aspx?SkipCheck=YES');
            }
        }

    </script>
</head>
<body>
    <script type="text/javascript">
        function UseRadWindow(sender, args) {
            var param = document.getElementById('hidPendCvrg').value;
            var oWindow = window.radopen("PendingCcvrgs.aspx" + param, null, 700, 400);


            oWindow.SetTitle("Plans");
            oWindow.SetModal(false);
            oWindow.OnClientResizeEnd = "SetWindowBehavior";
            //oWindow.Center();
        }

        function Button1_onclick() {
            //alert('here');
            UseRadWindow(null, null);
        }
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="Default" VisibleStatusbar="false"
            ShowContentDuringLoad="false">
        </telerik:RadWindowManager>
        <%--<telerik:RadWindow ID="RadWindow1" runat="server">
   </telerik:RadWindow>--%>
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidCvrgID" runat="server" />
        <asp:HiddenField ID="hidRemove" runat="server" />
        <asp:HiddenField ID="hidSave" runat="server" />
        <asp:HiddenField ID="hidPendCvrg" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <div class="Row">
            <asp:Panel ID='Panel2' runat="server" CssClass="Row marginbottom5 paddingbottomm5 bottomline "
                Style="margin-left: auto; margin-right: auto" HorizontalAlign="Right">
                <asp:Button ID="btnHelp" runat="server" Text="Help" CausesValidation="False" CssClass="fontsmall"
                    OnClick="btnHelp_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
            <asp:Panel ID='Panel1' runat="server" CssClass="Row marginbottom02   "
                Style="margin-left: auto; margin-right: auto">
                <asp:Label ID="Label1" runat="server"><span class="InstructioHeader"><strong>COBRA Insurance Premium Renewal Updates - Introduction</strong></span><br />
    <span class="Instuctiontext">Your current plans are listed below.  Use the dropdown arrow to select the Coverage Type. Click the "manage" button highlighted in grey associated with each plan to perform functions to modify or remove the corresponding plan. </span>
                </asp:Label>
            </asp:Panel>

            <asp:Panel ID='Panel4' runat="server" CssClass="Row marginbottom02 paddingbottomm5 bottomline "
                Style="margin-left: auto; margin-right: auto">
                <asp:Button ID="btnManagePendingPlans" runat="server" CssClass="fontsmall"
                    Text="xManage Pendig Plans" CausesValidation="False" Visible="False" />
                <input id="htmBtnManagePlans" type="button" runat="server"
                    value="Manage Pendig Plans" onclick="return Button1_onclick()" title="Manage pending Plans" />
            </asp:Panel>

            <asp:Panel ID="dvProcessed" CssClass="Row marginbottom02  "
                Style="margin-left: auto; margin-right: auto; padding-top: 5px; padding-bottom: 5px" runat="server" BackColor="#00FF99"
                HorizontalAlign="Center" Visible="False">
                <asp:Label ID="lblProcessed" runat="server" CssClass="fontsmall10" Font-Bold="True"
                    ForeColor="Maroon"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlMessage" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
            Style="margin-left: auto; margin-right: auto" runat="server" HorizontalAlign="Right">
            <asp:Button ID="btnAddNote" runat="server" CssClass="fontsmall" OnClick="btnAddNote_Click"
                Text="Add Note to Cobra Control Services, LLC    " />
        </asp:Panel>
            <div class="Row">
                <hr />
            </div>


            <div id="dvcvrlist" runat="server" class="Row">
                <div class="Row" id="dvStatus" runat="server">
                    <div style="margin-right: auto; margin-left: auto; width: 340px;">
                        <div style="float: left; width: 120px; text-align: left">
                            <asp:Label ID="lblCoverageTypes" runat="server" CssClass="textFont" Text="CoverageType"></asp:Label>
                        </div>
                        <div style="float: left; width: 220px; text-align: left; height: 25px;">
                            <telerik:RadComboBox ID="ddlCoverageTypes" AutoPostBack="True"
                                runat="server" EmptyMessage="Please select..." MarkFirstMatch="True"
                                Width="200px" DropDownWidth="300px" OnSelectedIndexChanged="ddlCoverageTypes_SelectedIndexChanged">

                            </telerik:RadComboBox>
                        </div>
                    </div>
                </div>


                <div class="Row marginbottom01 margintop01" style="text-align: center">
                    <asp:Button ID="btnAddMedical" runat="server" OnClick="btnAddMedical_Click" Text="Add A New Medical Plan" />
                    <asp:Button ID="btnAddDental" runat="server" OnClick="btnAddMedical_Click" Text="Add A New Dental Plan" />
                    <asp:Button ID="btnAddVistion" runat="server" Text="Add A New Vision Plan" OnClick="btnAddMedical_Click" />

                </div>

                <div class="Row">
                    <telerik:RadGrid ID="rgCvrg" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" OnNeedDataSource="rgDep_NeedDataSource" OnItemDataBound="rgDep_ItemDataBound" OnItemCommand="rgCvrg_ItemCommand" OnItemCreated="rgCvrg_ItemCreated">
                        <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                        <ClientSettings EnableRowHoverStyle="true"></ClientSettings>
                        <MasterTableView DataKeyNames="record_id">

                            <NestedViewTemplate>
                                <telerik:RadGrid ID="rgRate" runat="server">
                                </telerik:RadGrid>
                            </NestedViewTemplate>


                            <Columns>


                                <telerik:GridBoundColumn DataField="manage" FilterControlAltText="Filter column column" HeaderText="Manage Coverage" UniqueName="manage">
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>



                                <telerik:GridBoundColumn DataField="Class" FilterControlAltText="Filter column column" HeaderText="Selected Class" UniqueName="Class">
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="long_description" HeaderText="Coverage Name" UniqueName="long_description" FilterControlAltText="Filter column column">
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="rate_method_title" HeaderText="Rates Type" UniqueName="rate_method_title" FilterControlAltText="Filter column column">
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn DataField="Sta" FilterControlAltText="Filter column column" HeaderText="Status" UniqueName="Sta">
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                                </telerik:GridBoundColumn>


                            </Columns>

                        </MasterTableView>
                        <SelectedItemStyle BackColor="#FFCC99" />
                    </telerik:RadGrid>
                </div>
            </div>


        </div>
        <div id="dvManage" runat="server" class="Row">
            <div class="Row" style="text-align: center">
                <asp:Label ID="lblManageCoverage" runat="server" CssClass="FontSmall10 FontBold"></asp:Label><br />
                <asp:Label ID="lblEffectiveDate" runat="server" CssClass="FontSmall10 FontBold" ForeColor="Red"></asp:Label>
            </div>
            <div class="Row" id="dvRadBtn" runat="server">
                <asp:RadioButtonList ID="rblAction" runat="server" CssClass="textFont">
                    <asp:ListItem Value="same">KEEP this plan AND rating methodology, BUT MODIFY the Rates. </asp:ListItem>
                    <asp:ListItem Value="change">KEEP this plan BUT CHANGE THE RATING METHOD (Requires Terminating Plan and Adding a New Plan. All current plan information -- except rates -- will be copied from this plan to the new plan, automatically). </asp:ListItem>
                    <asp:ListItem Value="remove">Terminate this plan.</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Row" style="text-align: center">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Style="height: 26px" Width="120px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnMakechange" runat="server" Text="Make Change" OnClick="btnMakechange_Click" Style="height: 26px" Width="120px" />
            </div>
        </div>
        <asp:Panel ID='Panel3' runat="server" CssClass="Row margintop01 marginbottom1 bottomline "
            Style="margin-left: auto; margin-right: auto" HorizontalAlign="Center">
            <asp:Button ID="btnSaveDoNothing" runat="server" Text="Save AND NOT Finalize" Width="200px"
                OnClick="btnSaveDoNothing_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFinish" runat="server" Text="Save AND Finalizexxx" Width="200px"
                OnClick="btnFinish_Click" Visible="False" />
            &nbsp;<input id="htmbtnSave" type="button" value="Save AND Finalize" onclick="return DoSave()"
                style="width: 200px" />
            <img alt="" src="https://www.myenroll.com/images/smallbuzy.gif" id="htmImgBusy" style="visibility: hidden" />
            &nbsp;&nbsp;<input id="htmbtnReset" type="button" value="Reset" runat="server" onclick="return Rest()"
                style="width: 200px" />
            
        </asp:Panel>
        <%--Notes--%>
        <asp:Panel ID="dvNote" runat="server" CssClass="masterwidth" Style="margin-left: auto;
        margin-right: auto" Visible="false">
        <div id="Div3" runat="server" style="width: 99%">
            <asp:Label ID="lblNoteInstruction" runat="server" CssClass="FontMedium" Font-Bold="True">Please Enter a Message to be sent to Cobra Control Services, LLC</asp:Label>
        </div>
        <div id="Div4" runat="server" style="width: 99%">
            <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" Width="99%"></asp:TextBox>
        </div>
        <div id="Div5" runat="server" style="width: 99%; height: 15px">
            &nbsp;
        </div>
        <div id="Div6" runat="server" style="width: 99%; text-align: center;">
            <asp:Button ID="btnCancelMessage" runat="server" Text="Cancel Message" OnClick="btnCancelMessage_Click"
                Width="150px" />
            <asp:Button ID="btnSaveMessage" runat="server" Text="Save Message" Width="150px"
                OnClick="btnSaveMessage_Click" />
        </div>
    </asp:Panel>
    </form>
</body>
</html>
