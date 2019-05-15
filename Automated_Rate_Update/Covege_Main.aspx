<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Covege_Main.aspx.cs" Inherits="Automated_Rate_Update.Covege_Main" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="main2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function DoSave(btn, txt) {
            btn.disabled = true;
            btn.className = 'Input_Control_Small_btn_disable';
            var hid = document.getElementById("hidSave");
            hid.value = txt;
            PostBack()
        }

        function ConfirmBack() {
            if (confirm('You are in Edit mode. Are you sure you want to navigate out of this page?')) {
                var hid = document.getElementById("hidSave");
                hid.value = 'Move';
                PostBack()
            }
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

//        function DoSave() {
//            alert('here');
//            document.getElementById('htmImgBusy').style.visibility = "visible";
//            document.getElementById('btnSave').style.visibility = "hidden";
//            eval(document.getElementById('hidSave')).value = 'save';
//            var theForm = document.forms['form1'];
//            if (!theForm) {
//                theForm = document.form1;
//            }
//            theForm.submit();
//        }

        function Button1_onclick() {
            document.getElementById('htmImgBusy').style.visibility = "visible";
            document.getElementById('Button1').style.visibility = "hidden";
            eval(document.getElementById('hidSave')).value = 'save';
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            theForm.submit();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
<div class="container fontsmall" style="text-align: center; width: 920px; margin-left: auto;
            margin-right: auto">
            <asp:Label ID="lblPlanName" runat="server" CssClass="SectionTitleSmall" Text=" [Plan] Plan Information"></asp:Label></div><div 
                class="CvrgRow" 
                style="text-align: center; margin-left: auto; margin-right: auto"><asp:Label ID="lblInstruction" runat="server" CssClass="textFont">Complete the Information below. The <font color="#780000"><b>*</b></font> symbol before a data entry field indicates required data entry.<br /><br />            
            </asp:Label><asp:Label ID="lblMedInstruction" runat="server" Visible="False" cssclass="FontMedium">
                <b><span style="color: #c00000;">
                Click the "Select IBC Plan" button to choose an age banded tobacco/non-tobacco plan and applicable rates.<br />Please note at this time, this feature is only available for IBC plans.
                </span></b> 
            </asp:Label></div><div class="Blank_Row" style="width: 910px">
            &nbsp; </div><div class="master_main">
            <div class="CvrgRow " style="text-align: left; margin-bottom: 20px;">
            <asp:CheckBox ID="cbOe" runat="server" 
                    Text="COBRA continuants should have the right to participate in open enrollment. Check here if you want CCS to send COBRA continuants an enrollment form to make open enrollment elections." />
            </div>
                <div class="CvrgRow">
                    <div class="cvgLabel">
                        <asp:Label ID="lblmedicalplan" CssClass="textFont" runat="server" Text=" This [Plan] Plan will be Assigned to the Class"
                            AssociatedControlID="ddlClass"></asp:Label></div><div class="sreq">
                        <asp:Label ID="lblReq" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                        <telerik:RadComboBox 
                            ID="ddlClass" runat="server" Width="306px"
                            CausesValidation="False"><CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                    </div>
                    <div class="cvrgVails">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlClass"
                            CssClass="error" ErrorMessage="Required Information" InitialValue="-- Select Class --"
                            ForeColor=""></asp:RequiredFieldValidator></div></div>
                     <div id="dvInsurerName" class="CvrgRow" runat="server" visible="false">
                    <div class="cvgLabel">
                        <asp:Label ID="lbl_insurername" CssClass="textFont" runat="server" Text="Insurer Name"
                            AssociatedControlID="txtInsuranceName"></asp:Label></div><div class="sreq">
                        <asp:Label ID="Label3" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                        <telerik:RadTextBox ID="txtInsuranceName" runat="server" Width="300px">
                        </telerik:RadTextBox>
                    </div>
                    <div class="cvrgVails" style="width: 1px">
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="error" runat="server"
                        ErrorMessage="Required Information" ControlToValidate="txtInsuranceName" ForeColor=""></asp:RequiredFieldValidator></div><div class="CvrgRow">
                    <div class="cvgLabel">
                        <asp:Label ID="lbl_planname" CssClass="textFont" runat="server" AssociatedControlID="txtPlanName"> What is the Name of this [Page_Name] plan?</asp:Label></div><div class="sreq">
                        <asp:Label ID="Label4" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput" style="width: 500px">
                        <telerik:RadTextBox ID="txtPlanName" runat="server" Width="300px" MaxLength="40">
                        </telerik:RadTextBox>
                        <asp:Button ID="btnAddPredefindMetalPlan" runat="server" Text="Select IBC Plan"
                            CausesValidation="False" OnClick="btnAddPredefindMetalPlan_Click" Width="120px"
                            
                            ToolTip="Use this button to select the prepopulated plans and applicable rates" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="error" runat="server"
                            ErrorMessage="Required Information" ControlToValidate="txtPlanName" ForeColor=""
                            Display="Dynamic"></asp:RequiredFieldValidator></div><div class="cvrgVails" style="width: 1px">
                    </div>
                </div>
                <div class="CvrgRow">
                    <div class="cvgLabel">
                        <asp:Label ID="lbl_policy" CssClass="textFont" runat="server" Text="Policy Number"
                            AssociatedControlID="txtPolicyNumber"></asp:Label></div><div class="sreq">
                        <asp:Label ID="Label5" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                        <telerik:RadTextBox ID="txtPolicyNumber" runat="server" Width="300px">
                        </telerik:RadTextBox>
                    </div>
                    <div class="cvrgVails">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="error" runat="server"
                            ErrorMessage="Required Information" ControlToValidate="txtPolicyNumber" ForeColor=""
                            InitialValue="-- Select State --"></asp:RequiredFieldValidator></div></div><div class="CvrgRow">
                    <div class="cvgLabel">
                        <asp:Label ID="Lbl_State" CssClass="textFont" runat="server" Width="230px" ToolTip="Issue State"
                            Text="Policy Issuance State" AssociatedControlID="ddlState"></asp:Label></div><div class="sreq">
                        <asp:Label ID="Label6" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                        <telerik:RadComboBox 
                            ID="ddlState" CssClass="Input_Control_Small" runat="server"
                            Width="306px"><CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                    </div>
                    <div class="cvrgVails">
                        <asp:CompareValidator ID="Comparevalidator6" CssClass="error" runat="server" ErrorMessage="Required Information"
                            ControlToValidate="ddlState" Operator="NotEqual" ValueToCompare="Select a State"
                            ForeColor=""></asp:CompareValidator></div></div><div class="CvrgRow">
                    <div class="cvgLabel">
                        <asp:Label ID="lbl_original" CssClass="textFont" runat="server" Text="Effective Date (MM/DD/YYYY)"
                            AssociatedControlID="txtEfectiveDate"></asp:Label></div><div class="sreq">
                        <asp:Label ID="Label7" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                        <telerik:RadDatePicker ID="txtEfectiveDate" CssClass="Input_Control_Small" runat="server"
                            Width="302px" Skin="Sunset">
                            <DateInput>
                            </DateInput>
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ShowRowHeaders="False"
                                ViewSelectorText="x" Skin="Sunset">
                            </Calendar>
                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </div>
                    <div class="cvrgVails">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="error" runat="server"
                            ErrorMessage="Required Information" ControlToValidate="txtEfectiveDate" ForeColor=""></asp:RequiredFieldValidator></div></div><div class="CvrgRow">
                    <div class="cvgLabel">
                        <asp:Label ID="lbl_renewal" CssClass="textFont" runat="server" Text="Rate Renewal On (MM/DD)"></asp:Label></div><div class="sreq">
                        <asp:Label ID="Label8" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                        <div style="float: left; width: 66px">
                            <telerik:RadComboBox ID="ddlMoth" 
                                CssClass="Input_Control_Small" runat="server" Width="65px" AutoPostBack="True" OnSelectedIndexChanged="ddlMoth_SelectedIndexChanged"
                                CausesValidation="False"><CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Month" Value="00" />
                                    <telerik:RadComboBoxItem runat="server" Text="01" Value="01" />
                                    <telerik:RadComboBoxItem runat="server" Text="02" Value="02" />
                                    <telerik:RadComboBoxItem runat="server" Text="03" Value="03" />
                                    <telerik:RadComboBoxItem runat="server" Text="04" Value="04" />
                                    <telerik:RadComboBoxItem runat="server" Text="05" Value="05" />
                                    <telerik:RadComboBoxItem runat="server" Text="06" Value="06" />
                                    <telerik:RadComboBoxItem runat="server" Text="07" Value="07" />
                                    <telerik:RadComboBoxItem runat="server" Text="08" Value="08" />
                                    <telerik:RadComboBoxItem runat="server" Text="09" Value="09" />
                                    <telerik:RadComboBoxItem runat="server" Text="10" Value="10" />
                                    <telerik:RadComboBoxItem runat="server" Text="11" Value="11" />
                                    <telerik:RadComboBoxItem runat="server" Text="12" Value="12" />
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                        <div class="sreq">
                            <asp:Label ID="Label2" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div style="float: left; width: 66px">
                            <telerik:RadComboBox 
                                ID="ddlDay" CssClass="Input_Control_Small" runat="server" Width="70px" 
                                CausesValidation="False"><CollapseAnimation Duration="400" Type="OutQuint" />
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Day" Value="00" />
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="cvrgVails">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlMoth"
                            CssClass="error" Display="Dynamic" ErrorMessage="Required Moth" ForeColor=""
                            InitialValue="Month"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDay"
                            CssClass="error" Display="Dynamic" ErrorMessage="Required Day" ForeColor="" InitialValue="Day"></asp:RequiredFieldValidator></div><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlMoth"
                        CssClass="error" Display="Dynamic" ErrorMessage="Required Moth" ForeColor=""
                        InitialValue="00"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlDay"
                        CssClass="error" Display="Dynamic" ErrorMessage="Required Day" ForeColor="" InitialValue="00"></asp:RequiredFieldValidator></div></div><div class="CvrgRow">
                <div class="cvgLabel" style="padding-top: 5px">
                    <asp:Label ID="Lbl_hmo" CssClass="textFont" runat="server" Text="Is this Plan an HMO?"
                        AssociatedControlID="rblHMO"></asp:Label></div><div class="sreq">
                    <asp:Label ID="Label10" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                    <asp:RadioButtonList ID="rblHMO" CssClass="fontsmall" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="T">Yes</asp:ListItem><asp:ListItem Value="F">No</asp:ListItem></asp:RadioButtonList></div><div class="cvrgVails">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="error" runat="server"
                        ErrorMessage="Required Information" ControlToValidate="rblHMO" ForeColor=""></asp:RequiredFieldValidator></div></div><div class="CvrgRow">
                <div class="cvgLabel" style="padding-top: 5px">
                    <asp:Label ID="lbl_Self_Insured" CssClass="textFont" runat="server" Text="Is this Plan Self Insured?"
                        AssociatedControlID="rblSelf_Insured"></asp:Label></div><div class="sreq">
                    <asp:Label ID="Label9" CssClass="fontsmall" runat="server" Text="*" ForeColor="Maroon"></asp:Label></div><div class="cvgInput">
                    <asp:RadioButtonList ID="rblSelf_Insured" CssClass="fontsmall" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Self Insured</asp:ListItem><asp:ListItem Value="0">Fully Insured</asp:ListItem></asp:RadioButtonList></div><div class="cvrgVails">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="error" runat="server"
                        ErrorMessage="Required Information" ControlToValidate="rblSelf_Insured" ForeColor=""></asp:RequiredFieldValidator></div></div><div class="CvrgRow" id='dvOE' runat="server">
                
            <div style="float: left" class="CvrgRow">
            </div>
            <div style="float: left" class="CvrgRow">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </div></div></div><div class="Entry_Row">
        <asp:HiddenField ID="hidSave" runat="server" />
        <asp:HiddenField ID="hidProcessing_Year" runat="server" />
        <div id="dvEditButton" runat="server">
            <asp:Button ID="btnBack" runat="server" CssClass="Input_Control_Small_btn" Text="Back"
                Width="75px" CausesValidation="False" OnClick="btnBack_Click" />&nbsp; <asp:Button ID="btnSave" runat="server" CssClass="Input_Control_Small_btn" Text="Savexxx"
                Width="75px" CausesValidation="False" OnClick="btnSave_Click" 
                Visible="False" />
            <input id="Button1" name="Save" type="button" value="Save" class="Input_Control_Small_btn"
                onclick="return Button1_onclick()" style="width: 75px" /> <img alt="" src="https://www.myenroll.com/images/smallbuzy.gif" id="htmImgBusy" style="visibility: hidden" /> </div></div></form></body></html>