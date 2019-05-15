<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveDepNew.aspx.cs" Inherits="Dependents_Maintenance.RemoveDep1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/main2.css" rel="stylesheet" />
    <link href="Dep_Main.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>

    <style type="text/css">
        .OrangeColor {
            color: #EA836B;
        }

        .fontweight {
            font-weight: 600;
        }

        .RadGrid .rgSelectedRow {
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow {
            background: #7FFFD4 !important;
            //Try setting background to get the desired hover color;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 380px;
        }
    </style>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow(id) {
            //alert("closeWindow");
            var currentWindow = GetRadWindow();
            //alert(currentWindow);
            currentWindow.argument = id;
            currentWindow.Close();
        }

        function closeWindowcloseWindowOE(id) {
            //alert(" closeWindowcloseWindowOE");
            closing();
            try {
                window.location.href = "/web_projects/Dependents_Maintenance/Blank.aspx";
//window.parent.location.href = "/web_projects/EnrollmentWizard/DependentInfo.aspx";
                return;
            }
            catch (e) { };
        }

        function checkTermDep(depName) {
            var msg = 'Are you sure your Dependent ' + depName + ' and the  bebefits will be terminated?';
            var res = "";
            var ok = confirm(msg);
            //var hidTerm = ; //ocument.getElementById('hidTerminatde');   

            if (ok)
                res = 'yes'
            else
                res = 'No';
            if (res == 'yes)') {
                closing();
            }

            window.location.href = "/web_projects/Dependents_Maintenance/RemoveDepNew.aspx?sessom=1&hidTerm=" + res;
            //__doPostBack(null, null);
        }

        function closing() {
            $("#dvTop").hide();
        }

        function checkTermcvr(depName,cvrgName,id) {
            var msg = 'Your Dependent ' + depName + ' will have ' + cvrgName + ' coverage removed. Do you want to remove ' + cvrgName + ' coverage from this dependent?';
            var res = "";
            var ok = confirm(msg);
            //var hidTerm = ; //ocument.getElementById('hidTerminatde');   

            if (ok)
                res = id
            else
                res = '0';
            if (res == 'yes)') {
                closing();
            }

            window.location.href = "/web_projects/Dependents_Maintenance/RemoveDepNew.aspx?sessom=1&recid=" + res;
            //__doPostBack(null, null);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="lblScript" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hidTerminatde" runat="server" />

        <div style="width: 100%" id="dvTop">
            <div style="width: 100%">
                <div class="pageTitle">
                    <asp:Label ID="lblWarning" runat="server" Text="Alert!" CssClass="pageTitle OrangeColor"></asp:Label>
                </div>
                <div id="dvTopVutton" runat ="server">
                    <input type="submit" name="btnButton1" value="Button1" id="btnButton1" style="height: 60px; width: 60px;" />
                    <input type="submit" name="btnButton2" value="Button2" id="btnButton2" style="height: 60px; width: 60px;" />
                    <input type="submit" name="btnButton3" value="Button3" id="btnButton3" style="height: 60px; width: 60px;" />
                    <input type="submit" name="btnButton4" value="Button4" id="btnButton4" style="height: 60px; width: 60px;" />
                </div>
                <div style="width: 100%; float: left;" id="dvParam" runat="server">
                    <div class="pageTitle margintop10">
                        <asp:Label ID="lblTitle" runat="server" CssClass="dataSetctionTitle">Dependent 
                    <span class="dataSetctionTitle OrangeColor">[detail]</span></asp:Label>
                    </div>
                    <div class="pageTitle margintop5" style="width: 100%; float: left;">
                        <div style="float: left; margin-top: 2px; margin-right: 10px; width: 130px;">
                            <asp:Label ID="lblTerminationDate" runat="server" CssClass="textFont">Termination Date</asp:Label>
                        </div>
                        <div style="float: left">
                            <asp:TextBox ID="txtTerminationDate" runat="server" CssClass="fontsmall" ToolTip="Enter Termination Date"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTerminationDate"
                                CssClass="errorRed" Display="Dynamic" EnableClientScript="False"
                                MaximumValue="01/01/2099" MinimumValue="01/01/1900" Type="Date" ErrorMessage="Incorrect Date - Date must be after  01/01/1900" ForeColor=""></asp:RangeValidator>
                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTerminationDate"
                                CssClass="errorRed" Display="Dynamic" EnableClientScript="False" ErrorMessage="Required Info."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="pageTitle margintop5" style="width: 100%; float: left;">
                    <div style="float: left; margin-top: 2px; margin-right: 10px; width: 130px;">
                        <asp:Label ID="lblReson" runat="server" CssClass="textFont">Termination Reason</asp:Label>
                    </div>
                    <div style="float: left">
                        <asp:DropDownList ID="ddlReason" runat="server" CssClass="textFont"
                            Width="347px" OnSelectedIndexChanged="ddlReason_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="dvStep1" runat="server" style="width: 100%">

                <div class="pageTitle margintop5" style="width: 100%">
                    <div style="float: left; margin-top: 2px; margin-right: 10px">
                        <asp:Label ID="lblNoCoverage" runat="server" CssClass="textFont">Your Dependent <span class="OrangeColor">{name}</span> does not have any coverage. Do you want to terminate this dependent? </asp:Label>
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="Input_Control" Width="35px" OnClick="btnYes_Click" />
                        &nbsp;<asp:Button ID="btnNo" runat="server" Text="No" CssClass="Input_Control" Width="35px" OnClick="btnNo_Click" />
                    </div>
                </div>
            </div>
            <div id="dvTermDep" runat="server" style="width: 100%">
                <div class="pageTitle margintop10">
                    <asp:Label ID="lblDependentTerinate" runat="server" CssClass="dataSetctionTitle">Dependent will be terinated<br />
                    <span class="dataSetctionTitle OrangeColor">[detail]</span></asp:Label>
                </div>
                <div class="pageTitle margintop5" style="width: 100%">
                    <div style="float: left; margin-top: 2px;">
                        <asp:Label ID="lblConfirmDepTerm" runat="server" CssClass="textFont">Are you sure you want to terminate {name}?</asp:Label>
                    </div>
                    <div style="float: left">
                        <asp:RadioButtonList ID="rblTermDep" runat="server" CssClass="textFont" AutoPostBack="True" OnSelectedIndexChanged="rblTermDep_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="pageTitle margintop5" style="width: 100%; float: left;">
                    <hr />
                </div>
            </div>

            <div style="width: 100%; float: left;" id="dvReson" runat="server">

                <div class="pageTitle margintop5" style="width: 100%; float: left;">
                    <hr />
                </div>
                <div style="width: 100%" id="dvTermCov" runat="server">
                    <div style="width: 100%" id="dvWillClose" runat="server">
                        <div class="pageTitle margintop5" style="width: 100%; float: left;">
                            <asp:Label ID="lblDepRemoveCoverage" runat="server" CssClass="dataSetctionTitle">Dependent will be removed from the Coverage<br />
                    <span class="dataSetctionTitle OrangeColor">[detail2]</span></asp:Label>

                        </div>
                        <div class="Width75 pageTitle margintop05">
                            <telerik:RadGrid ID="rgTem" runat="server" OnNeedDataSource="rgTem_NeedDataSource" AutoGenerateColumns="False" GroupPanelPosition="Top">
                                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                <MasterTableView DataKeyNames="record_id">
                                    <Columns>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Remove&lt;br&gt;Coverage" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkWillRemove" runat="server" Checked="True" Enabled="False" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Long_des" FilterControlAltText="Filter column column" HeaderText="Removal from Coveage" UniqueName="column">
                                            <HeaderStyle VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="effective_date" FilterControlAltText="Filter column1 column" HeaderText="Removal&lt;br&gt;Effective" UniqueName="column1">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div style="width: 100%" id="dvCouldTemCov" runat="server">
                        <div class="fullWidth pageTitle ">
                            <div class="Width75  ">
                                <asp:Label ID="lblCanKeepCoverage2" runat="server" CssClass="dataSetctionTitle fontweight">Your Dependent will have the below coverages removed and will be terminated in MyEnroll. Do you wish to continue?
                                </asp:Label>
                            </div>
                               <div class="fullWidth margintop10" id="dvcheckBox" runat ="server">
                                   <table cellpadding="0" class="auto-style1">
                                       <tr>
                                           <td class="auto-style2">
                                <asp:Label ID="lblTermDep" runat="server" CssClass="textFont">Terminate Dependent <span class="dataSetctionTitle OrangeColor">[detail2]</span>
                      if all coverags are removed ?</asp:Label>
                                           </td>
                                           <td>
                                               <asp:RadioButtonList ID="rblTermdependent" runat="server" RepeatDirection="Horizontal">
                                                   <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                   <asp:ListItem Value="0">No</asp:ListItem>
                                               </asp:RadioButtonList></td>
                                       </tr>
                                   </table>
                               </div>

                        </div>

                        <div class="Width75 pageTitle">
                            <telerik:RadGrid ID="rdKeep" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top" OnNeedDataSource="rdKeep_NeedDataSource" >
                                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                <MasterTableView DataKeyNames="record_id" >
                                    <Columns>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Keep&lt;br&gt;Coverage" UniqueName="TemplateColumn2" Visible="False">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkWillRemove2" runat="server" Checked="True" Enabled="false"/>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Long_des" FilterControlAltText="Filter column column" HeaderText="Currently Selected Coverage" UniqueName="column">
                                            <HeaderStyle VerticalAlign="Top" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="effective_date" FilterControlAltText="Filter column1 column" HeaderText="Removal&lt;br&gt;Effective" UniqueName="column1" Visible="False">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div style="width: 100%; float: left;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>

            </div>
        </div>
    </form>

</body>
</html>
