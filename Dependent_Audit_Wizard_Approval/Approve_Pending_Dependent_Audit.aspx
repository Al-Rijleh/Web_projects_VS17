<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approve_Pending_Dependent_Audit.aspx.cs"
    Inherits="Dependent_Audit_Wizard_Approval.Approve_Pending_Dependent_Audit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Main.css" rel="stylesheet" type="text/css" />
    <link href="/styles/Main2.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        function Select(ee) {
            document.getElementById('hid3').value = ee;
            __doPostBack(null, null);

        }

        function Selectlog(rlogId, depID, status) {
            document.getElementById('hid560').value = rlogId;
            document.getElementById('Hid560id').value = depID;
            document.getElementById('hid560sta').value = status;
            //var txt = document.getElementById('txtFocus');
            //alert(txt);
            //txt.focus();
            __doPostBack(null, null);

        }
        function OnClientclose(radWindow) {
            var retcode;

            if (radWindow.argument)
                retcode = radWindow.argument

            if (retcode == "1") {
                radWindow.argument = 0;
                var hid = document.getElementById("hidAction");
                hid.value = 'Cancel';
                __doPostBack(null, null);
                return;
            }

            if (retcode == "2") {
                radWindow.argument = 0;
                var hid = document.getElementById("hidAction");
                hid.value = 'Reset';
                __doPostBack(null, null);
                return;
            }

            if (retcode == "3") {
                radWindow.argument = 0;
                var hid = document.getElementById("hidAction");
                hid.value = 'Master';
                __doPostBack(null, null);
                return;
            }
        }
    </script>

    <style type="text/css">
        .RadGrid .rgSelectedRow {
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow {
            background: #7FFFD4 !important;
            //Try setting background to get the desired hover color;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <script language="javascript" type="text/javascript">        try { window.top.hidleft(); } catch (err) { }</script>
        <asp:HiddenField ID="hid2" runat="server" />
        <asp:HiddenField ID="hid3" runat="server" />
        <asp:HiddenField ID="hidAction" runat="server" />
        <asp:HiddenField ID="hid560" runat="server" />
        <asp:HiddenField ID="Hid560id" runat="server" />
        <asp:HiddenField ID="hid560sta" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <telerik:RadToolTip ID="RadToolTip1" runat="server" HideEvent="ManualClose" Position="TopCenter"
            Skin="Web20" Width="450px" Style="z-index: 6000">
        </telerik:RadToolTip>
        <%--<script type="text/javascript">        parent.document.getElementById('middle').cols = '0,*';</script>--%>
        <div class="FullPage1000 FontSmall" id="dvPage">
            <%--Header--%>
            <div class="FullPage1000" id="dvHeader" runat="server" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCE8F9">
                <iframe name="Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame"
                    style="width: 1000px; height: 95px" src="http://localhost/web_projects/PTemplate/top.aspx"
                    frameborder="0" scrolling="no"></iframe>
            </div>
            <%--Message--%>
            <div class="FullPage1000" style="margin-bottom: 1px">
                <asp:Label ID="lblMessage" runat="server" Text="Pending Dependent Audit - Approval"
                    CssClass="pageTitle"></asp:Label>                
            </div>
            <%--Input--%>
            <div class="DateSide">
                <div class="DateSide marginbuttom10">
                    <asp:Label ID="lblMasterAccount" runat="server" CssClass="FontSmall10 FontBold">Select Master Account:</asp:Label><br />
                    <telerik:RadDropDownList ID="ddlMaterAccounts" runat="server" Skin="Vista" Width="350"
                        DropDownWidth="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterAccounts_SelectedIndexChanged">
                        <Items>
                            <telerik:DropDownListItem runat="server" DropDownList="ddlMaterAccounts" />
                            <telerik:DropDownListItem runat="server" DropDownList="ddlMaterAccounts" />
                        </Items>
                    </telerik:RadDropDownList>
                </div>
                <div class="DateSide">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                        ResolvedRenderMode="Classic" SelectedIndex="0" AutoPostBack="True"
                        OnTabClick="RadTabStrip1_TabClick">
                        <Tabs>
                            <telerik:RadTab runat="server" Text="Pending Approval" Value="1"
                                Selected="True">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Pending Documents"
                                Value="2" Visible="False">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                </div>
                <div class="DateSide" id="dvReady" runat="server">
                    <telerik:RadGrid ID="rgEEList" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False"
                        OnNeedDataSource="RadGrid1_NeedDataSource" ResolvedRenderMode="Classic" OnItemCommand="rgEEList_ItemCommand"
                        Width="350px">
                        <MasterTableView DataKeyNames="employee_number" AllowMultiColumnSorting="True" GroupLoadMode="Server"
                            NoDetailRecordsText="No records to display." Width="350px">
                            <NestedViewTemplate>
                                <telerik:RadGrid ID="rgDetal" runat="server" Skin="Sunset">
                                </telerik:RadGrid>
                            </NestedViewTemplate>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Location" FilterControlAltText="Filter column column"
                                    HeaderText="Location" UniqueName="column" FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Employee" FilterControlAltText="Filter column1 column"
                                    HeaderText="Employee" UniqueName="column1" FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div class="DateSide" id="dvPending" runat="server">
                    g<telerik:RadGrid ID="rgPending" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False"
                        ResolvedRenderMode="Classic"
                        Width="350px" Skin="Vista" OnItemCommand="rgPending_ItemCommand"
                        OnNeedDataSource="rgPending_NeedDataSource">
                        <MasterTableView DataKeyNames="employee_number" AllowMultiColumnSorting="True" GroupLoadMode="Server"
                            NoDetailRecordsText="No records to display." Width="350px">
                            <NestedViewTemplate>
                                <telerik:RadGrid ID="rgpendDetal" runat="server" Skin="Sunset">
                                </telerik:RadGrid>
                            </NestedViewTemplate>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Location" FilterControlAltText="Filter column column"
                                    HeaderText="Location" UniqueName="column" FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Employee" FilterControlAltText="Filter column1 column"
                                    HeaderText="Employee" UniqueName="column1" FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
            <%--Data--%>
            <div class="PDFSide">
                <div class="PDFSide  marginbuttom10" id="dvFullPage">
                    

                    <div class="PDFSide" style="text-align: left" id="dvWarning" runat="server">
                        <div style="border-color: 0; border-width: 1px; float: left; width: 210px; margin-bottom: 5px; margin-top: 5px;">
                            <%--<asp:Label ID="lblWrning" runat="server" CssClass="FontSmall10 FontBold">Status: </asp:Label>--%>


                            <asp:Label ID="lblEEDEP" runat="server" CssClass="FontSmall10">

                                <table style="width: 650px">
                                    <tbody>
                                        <tr>
                                            <td style="width: 150px; font-weight: bold">Employee:</td>
                                            <td style="width: 500px; padding-left: 5px">
                                                <asp:Label ID="lblEEInfo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px; font-weight: bold">Dependent:</td>
                                            <td style="width: 500px; padding-left: 5px">
                                                <asp:Label ID="lblDepInfo" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr id="trFDIC" runat="server">
                                            <td style="width: 150px; font-weight: bold" valign="middle">Dependent Status:</td>
                                            <td style="width: 500px" valign="middle">
                                                <asp:CheckBoxList ID="cblStatus" runat="server"  RepeatDirection="Horizontal" Width="199" Enabled="False">
                                                    <asp:ListItem Value="1">Student</asp:ListItem>
                                                    <asp:ListItem Value="2">Disabled </asp:ListItem>
                                                </asp:CheckBoxList></td>
                                        </tr>

                                    </tbody>
                                </table>

                            </asp:Label>

                        </div>
                    </div>
                    <div class="PDFSide" id="dvimage" runat="server" style="text-align: center; margin-top: 10px;">
                        <asp:Button ID="btnPrevImage" runat="server" Text="Previous" OnClick="btnPrevImage_Click"
                            Width="75px" />
                        <asp:Button ID="btnNextImage" runat="server" Text="Next" OnClick="btnNextImage_Click"
                            Width="75px" />
                        &nbsp;
                    
                    </div>
                    <div class="PDFSide" id="dvDropDown" runat="server" style="text-align: center; margin-top: 10px;">
                        <asp:DropDownList ID="ddlPDF" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPDF_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label ID="lblDocName" runat="server"></asp:Label>
                    </div>
                    <div id='dvDes' runat="server" class="PDFSide " style="margin-top: 10px">
                        <%--<div class="PDFSide" style="font-size: 12px">
                            <asp:Label ID="lblNoEmail" runat="server" Text="No Email Address for this Employee"
                                Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                            <asp:Label ID="lblEmail" runat="server" Font-Bold="True" ForeColor="#006600" Visible="False"></asp:Label>
                        </div>--%>
                        <div style="float: left; margin-top: 5px" class="FontSmall10 FontBold">
                            <asp:Label ID="lblSelectApprovalStatus" runat="server" Text="Select Approval Status"></asp:Label>
                        </div>
                        <div style="width: 310px; float: left">
                            <asp:RadioButtonList ID="rblApproval" runat="server" CssClass="textFont" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="rblApproval_SelectedIndexChanged">
                                <asp:ListItem Value="1">Approve</asp:ListItem>
                                <asp:ListItem Value="2">Decline</asp:ListItem>
                                <asp:ListItem Value="3">Request More Information</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div style="float: left;">
                            <asp:Button ID="btApply" runat="server" Text="Apply" OnClick="btApply_Click" Visible="False" />
                        </div>
                    </div>
                    <div  class="PDFSide"  >
                        <div style="width: 102px; font-weight: bold; float: left;">
                            <b>Approval Status:</b>
                        </div>
                        <div style="width: 400px; padding-left: 5px; float: left;">
                            <asp:Label ID="lblStatusValue" runat="server" CssClass="FontSmall10"></asp:Label>
                        </div>
                    </div>
                    <div class="PDFSide" style="text-align: center">
                        <asp:Label ID="lblDependentInfo" runat="server" CssClass="textFont" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="PDFSide" runat="server" style="height: 480px" id="dvDoc">
                        <iframe id='Viewer' runat="server" width="640px" height="480px" name="Viewer" />
                    </div>
                    <%--<div style="position: static; width: 300px; height: 300px; top: 100px; right: 400px; background-color: #FFCC66; bottom: 200px;"></div>--%>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
