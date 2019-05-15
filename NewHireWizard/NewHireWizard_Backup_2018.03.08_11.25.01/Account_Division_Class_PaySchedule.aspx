<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account_Division_Class_PaySchedule.aspx.cs"
    Inherits="NewHireWizard.Account_Division_Class_PaySchedule" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account/Division/Class/Pay Schedule</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
<!--

        function showDialog1() {
            window.radopen("PendClasses.aspx", "RadWindow1");
            return false;
        }

        function showDialog2(txt) {
            if (txt == '') {
                alert('You must select complete Step 1 first');
                return;
            }
            window.radopen("ChangeClass.aspx", "RadWindow2");
            return false;
        }

        // Use the New select account Number
        //function showDialog3() {
        //    window.radopen("/web_projects/Account_Number/Default.aspx?SkipCheck=YES"+
        //        "&goto=/web_projects/NewHireWizard/Account_Division_Class_PaySchedule.aspx", "RadWindow3");
        //    return false;
        //}

        function showDialog3() {
            window.radopen("/web_projects/Account_number_small/Default.aspx", "RadWindow3");
            return false;
        }

        function showDialog4() {
            window.radopen("ChangePaySchecule.aspx", "RadWindow2");
            return false;
        }

        function OnClientclose(radWindow) {

            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument

            if (retcode == "1") {
                radWindow.argument = 0;
                return;
            }

            if (retcode == "2") // Coming From Change Class  
            {
                radWindow.argument = 0;
                eval(document.getElementById('hidClass')).value = 'Go';
                // when Use the New select account Number
                //eval(document.getElementById('hidDiv')).value = 'Go';
                PostBack();
                return;
            }

            if (retcode == "3") // Coming From Change Division  
            {
                radWindow.argument = 0;
                eval(document.getElementById('hidDiv')).value = 'Go';
                updateTemplate();
                PostBack();
                return;
            }

            function updateTemplate() {
                //alert('here')
                window.top.setEEDef();
                //try { window.top.setOrgEE(); } catch (err) { };
            }

            if (retcode == "4") // Coming From Change PaySchedule  
            {
                radWindow.argument = 0;
                eval(document.getElementById('hidPay')).value = 'Go';
                PostBack();
                return;
            }
        }

        function NoAccess(msg) {
            alert(msg);
            window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        }

        function ConfirmDate(msg) {
            if (confirm(msg)) {
                eval(document.getElementById('hidDate')).value = 'Go';
                PostBack();
                return;
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
                  


// -->         
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6"
        Skin="Sunset" />
    <telerik:RadWindowManager ID="Singleton" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" NavigateUrl="PendClasses.aspx"
                OpenerElementID="lnkbtnShowPendClass" Skin="Sunset" Left="5" Top="1px" OnClientClose="OnClientclose"
                ReloadOnShow="True" Style="display: none;" Behavior="Default" InitialBehavior="None"
                Modal="True" VisibleStatusbar="False" Width="570px" Height="300px" ShowContentDuringLoad="False"
                VisibleTitlebar="False">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="RadWindow2" runat="server" NavigateUrl="ChangeClass.aspx"
                Skin="Sunset" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                VisibleStatusbar="False" Width="600px" Height="350px" ShowContentDuringLoad="False"
                VisibleTitlebar="False">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="RadWindow3" runat="server" NavigateUrl="/web_projects/Account_number_small/Default.aspx"
                Skin="Sunset" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                VisibleStatusbar="False" Width="600px" Height="350px" ShowContentDuringLoad="False"
                VisibleTitlebar="False">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    &nbsp;
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="txtSSN">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtSSN" />
                    <telerik:AjaxUpdatedControl ControlID="lblErrorSSN" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtHireDate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtHireDate" />
                    <telerik:AjaxUpdatedControl ControlID="RangeValidator1" />
                    <telerik:AjaxUpdatedControl ControlID="lblErrorProcessingYear" />
                    <telerik:AjaxUpdatedControl ControlID="lblError60Days" />
                    <telerik:AjaxUpdatedControl ControlID="lblHireDateWarning" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="75px"
        Skin="Sunset" Width="75px">
        &nbsp;</telerik:RadAjaxLoadingPanel>
    <asp:HiddenField ID="hidClass" runat="server" />
    <asp:HiddenField ID="hidDiv" runat="server" />
    <asp:HiddenField ID="hidPay" runat="server" />
    <asp:HiddenField ID="hidDate" runat="server" />
    <%--<div class="Blank10">
            &nbsp;
        </div>
        <div class="Blank10">
            &nbsp;
        </div>--%><%--<div class="StatusInputRowTitle FontSmall10 Header2">
            <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label>
        </div>--%><%-- <div class="Blank10">
            &nbsp;
        </div>--%>
    <uc1:TabStrip ID="TabStrip1" runat="server" />
    <div id="dvFullPage" runat="server" class="FullPage">
        <div id="Div2" runat="server" class="FullPage">
            <div id="dvPendNewHire" runat="server" class="InputRow FontSmall" visible="false">
                <span id="lblInstruction" runat="server">Your organization requires this system to pend
                    new hires in certain classes. Once you enter the employee’s class in step 2, we
                    will tell you whether or not the employee’s record will be pended. </span>
                <asp:LinkButton ID="lnkbtnShowPendClass" runat="server" Font-Bold="True" Font-Underline="True">Click here to see all classes requiring pending.</asp:LinkButton>
            </div>
            <div id="dvNewHire" runat="server" class="InputRow FontSmall" visible="false">
                <asp:Label ID="lblNewHireInstruction" runat="server" Text="Your organization does not require this system to pend new hires"></asp:Label>
            </div>
            <div id="dvEmployeeWillPend" runat="server" class="InputRow FontSmall" visible="false">
                <asp:Label ID="lblEmployeeWillPend" runat="server" Font-Bold="True" ForeColor="Maroon">The employee you are entering will be pended</asp:Label>
            </div>
        </div>
        <div class="Blank10">
            &nbsp;
        </div>
        <%--Account/Division--%>
        <div class="InputRow">
            &nbsp;<asp:Label ID="lblTitle1" runat="server" CssClass="InsideTitle">Enter information as requested below. Click "Change" hyperlinks to view options:</asp:Label>
        </div>
        <div class="Statusblank10">
            &nbsp;
        </div>
        <%--Division--%>
        <div class="InputRow FontSmall">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 50px">
                    <b><font face="Arial" size="2" color="#800000">Step 1:</font></b>
                </div>
                <div class="InputLabel" style="width: 100px">
                    <asp:Label ID="lblAccount" runat="server" Text="Account/Location"></asp:Label>
                </div>
            </div>
            <div class="ChangeCommand">
                <asp:LinkButton ID="lnkbtnChangeDivision" runat="server">Change</asp:LinkButton>
            </div>
            <div class="Validator">
                <asp:TextBox ID="txtAccountNameNumberValues" runat="server" ReadOnly="true" CssClass="NoBorder FontSmall"
                    Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountNameNumberValues"
                    CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Account"></asp:RequiredFieldValidator></div>
        </div>
        <%--Class--%>
        <div class="InputRow FontSmall">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 50px">
                    <b><font face="Arial" size="2" color="#800000">Step 2:</font></b>
                </div>
                <div class="InputLabel" style="width: 100px">
                    <asp:Label ID="lblClass" runat="server" Text="Class Code"></asp:Label>
                </div>
            </div>
            <div class="ChangeCommand">
                <asp:LinkButton ID="lnkbtnChangeClass" runat="server">Change</asp:LinkButton>
            </div>
            <div class="Validator">
                <asp:TextBox ID="txtClassValue" runat="server" ReadOnly="true" CssClass="NoBorder FontSmall"
                    Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtClassValue"
                    CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Class Code" Enabled="False"></asp:RequiredFieldValidator></div>
        </div>
        <%--Pay Schedule--%>
        <div class="InputRow FontSmall" runat="server" visible="false" id="dvPayStatus">
            <div class="InputLabel">
                <div class="InputLabel" style="width: 50px">
                    <b><font face="Arial" size="2" color="#800000">Step 3:</font></b>
                </div>
                <div class="InputLabel" style="width: 100px">
                    <asp:Label ID="lblPaySchedule" runat="server" Text="Pay Schedule"></asp:Label>
                </div>
            </div>
            <div class="ChangeCommand">
                <asp:LinkButton ID="lnkbtnChangePaySchedule" runat="server">Change</asp:LinkButton>
            </div>
            <div class="Validator">
                <asp:TextBox ID="txtPayScheduleValue" runat="server" ReadOnly="true" CssClass="NoBorder FontSmall"
                    Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPayScheduleValue"
                    CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Pay Schedule" Enabled="False"></asp:RequiredFieldValidator></div>
        </div>
        <div id="dvAllDataFields" class="FullPage FontSmall" runat="server" visible="true">
            <div id="divData">
                <div class="Blank10">
                </div>
                <div class="InputRow FontSmall">
                    <asp:Label ID="lblStep4" runat="server"><b><font face="Arial" size="2" color="#800000">Step 3:</font></b></asp:Label>
                </div>
                <%--POI --%>
                <div class="InputRow" id="dvLocation" runat="server">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblLocation" runat="server" AssociatedControlID="rblLocations" Text="Location"></asp:Label>
                            <asp:Label ID="Label6" runat="server" AssociatedControlID="rblLocations" Text="*"
                                ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue" style="width: 320px">
                        <asp:RadioButtonList ID="rblLocations" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </div>
                    <div class="InputValidator" style="width: 158px; padding-top: 5px;" id="DIV3" language="javascript">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic"
                            ControlToValidate="rblLocations" ErrorMessage="Required Location" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Salutation--%>
                <div class="InputRow" id="dvsalutation" runat="server" >
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblSalutation" runat="server" AssociatedControlID="ddlSalutation"
                                Text="Salutation"></asp:Label>
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="lblFirstName" Text="*"
                                ForeColor="White"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="FontSmall" Width="215px">
                        </asp:DropDownList>
                    </div>
                    <div class="InputValidator" style="width: 297px" id="DIV1" language="javascript">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                            ControlToValidate="txtFirstName" ErrorMessage="Required First Name" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--First Name--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" Text="First Name"></asp:Label>
                            <asp:Label ID="reqFirstName" runat="server" AssociatedControlID="lblFirstName" Text="*"
                                ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadTextBox ID="txtFirstName" runat="server" CssClass="FontSmall" Width="210px"
                            SelectionOnFocus="CaretToBeginning" MaxLength="15">
                        </telerik:RadTextBox></div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                            ControlToValidate="txtFirstName" ErrorMessage="Required First Name" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Middle Initial--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblMiddle_Initial" runat="server" AssociatedControlID="txtMiddleInitial"
                                Text="Middle Initial"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadTextBox Style="text-transform: uppercase" ID="txtMiddleInitial" runat="server"
                            CssClass="FontSmall" Width="210px" MaxLength="1">
                        </telerik:RadTextBox>
                    </div>
                    <div class="InputValidator">
                    </div>
                </div>
                <%--Last Name--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label>
                            <asp:Label ID="reqLastName" runat="server" AssociatedControlID="txtLastName" Text="*"
                                ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadTextBox ID="txtLastName" runat="server" CssClass="FontSmall" Width="210px"
                            MaxLength="20">
                        </telerik:RadTextBox>
                    </div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                            ControlToValidate="txtLastName" ErrorMessage="Required Last Name" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Nick Name--%>
                <div class="InputRow">
                    <div class="InputLabel ">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblNickname" runat="server" AssociatedControlID="txtNickname" Text="Nickname"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadTextBox ID="txtNickname" runat="server" CssClass="FontSmall" Width="210px"
                            MaxLength="10">
                        </telerik:RadTextBox>
                    </div>
                </div>
                <%--SSN--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblSSN" runat="server" AssociatedControlID="txtSSN" Text="Soc. Sec. No."></asp:Label>
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="txtSSN" Text="*" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadMaskedTextBox ID="txtSSN" runat="server" CssClass="FontSmall" Width="211px"
                            TextWithLiterals="//" Mask="###-##-####" DisplayMask="###-##-####" AutoPostBack="True"
                            OnTextChanged="txtSSN_TextChanged">
                            <FocusedStyle CssClass="fontsmall" />
                            <EnabledStyle CssClass="fontsmall" />
                        </telerik:RadMaskedTextBox></div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic"
                            ControlToValidate="txtSSN" ErrorMessage="Required SSN" Enabled="False"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSSN"
                            CssClass="FontSmall" ErrorMessage="Incorrect SSN" ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblErrorSSN" runat="server" CssClass="FontSmall" ForeColor="Red" 
                            Visible="False"></asp:Label></div>
                </div>
                <div class="Blank10">
                    &nbsp;</div>
                <%--DOB--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblDateofBirth" runat="server" AssociatedControlID="txtDateofBirth"
                                Text="Date of Birth"></asp:Label>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtDateofBirth" Text="*"
                                ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadMaskedTextBox ID="txtDateofBirth" runat="server" CssClass="FontSmall"
                            Width="211px" TextWithLiterals="//" Mask="##/##/####" DisplayMask="##/##/####">
                            <FocusedStyle CssClass="fontsmall" />
                            <EnabledStyle CssClass="fontsmall" />
                        </telerik:RadMaskedTextBox></div>
                    <div class="InputValidator">
                        &nbsp;<asp:RangeValidator ID="RangeValidator3" runat="server" Display="Dynamic" ControlToValidate="txtDateofBirth"
                            ErrorMessage="Incorrect Date of Birth" Type="Date" MinimumValue="01/01/1900"
                            MaximumValue="01/01/2099"></asp:RangeValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                runat="server" Display="Dynamic" ControlToValidate="txtDateofBirth" ErrorMessage="Required Date of Birth"
                                Enabled="False"></asp:RequiredFieldValidator></div>
                </div>
                <%--Gender--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblGender" runat="server" AssociatedControlID="ddlGender" Text="Gender"></asp:Label>
                            <asp:Label ID="reqGender" runat="server" AssociatedControlID="ddlGender" Text="*"
                                ForeColor="Red"></asp:Label></div>
                    </div>
                    <div class="InputValue">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="FontSmall" Width="215px">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                            ControlToValidate="ddlGender" ErrorMessage="Required Gender" InitialValue="0"
                            Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Marital Status--%>
                <div class="InputRow">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblMaritalStatus" runat="server" AssociatedControlID="ddlMaritalStatus"
                                Text="Marital Status"></asp:Label>
                            <asp:Label ID="reqMaritalStatus" runat="server" AssociatedControlID="ddlMaritalStatus"
                                Text="*" ForeColor="Red"></asp:Label></div>
                    </div>
                    <div class="InputValue">
                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="FontSmall" Width="215px">
                        </asp:DropDownList>
                    </div>
                    <div class="InputValidator">
                        <div class="InputValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                ControlToValidate="ddlMaritalStatus" ErrorMessage="Required Marital Status" InitialValue="x"
                                Enabled="False"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="Blank10">
                    </div>
                </div>
                <%--Buttons--%>
            </div>
            <%--Hire Date--%>
            <div class="InputRow FontSmall">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblHireDate" runat="server" AssociatedControlID="txtHireDate" Text="Hire Date"
                            ToolTip="Hire Date"></asp:Label>
                        <asp:Label ID="reqDateofBirth" runat="server" AssociatedControlID="txtHireDate" Text="*"
                            ForeColor="Red"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <telerik:RadMaskedTextBox ID="txtHireDate" runat="server" Width="211px" CssClass="FontSmall"
                        TextWithLiterals="//" Mask="##/##/####" DisplayMask="##/##/####" ToolTip="Hire Date"
                        OnTextChanged="txtHireDate_TextChanged" RoundNumericRanges="False" AutoPostBack="True">
                        <FocusedStyle CssClass="fontsmall" />
                        <EnabledStyle CssClass="fontsmall" />
                    </telerik:RadMaskedTextBox></div>
                <div class="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                        ControlToValidate="txtHireDate" ErrorMessage="Required Hire Date" CssClass="FontSmall"
                        Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtHireDate"
                        ErrorMessage="Incorrect Hire Date" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2099"></asp:RangeValidator>
                    <asp:Label ID="lblErrorProcessingYear" runat="server" CssClass="FontSmall" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblError60Days" runat="server" CssClass="FontSmall" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblHireDateWarning" runat="server" ForeColor="Maroon"></asp:Label></div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDateofBirth"
                    ControlToValidate="txtHireDate" ErrorMessage="Hire Date Must Larger than Birth Date"
                    Type="Date" Operator="GreaterThan" Display="Dynamic" Enabled="False"></asp:CompareValidator></div>
            <%--Salary--%>
            <div class="InputRow FontSmall">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblSalary" runat="server" AssociatedControlID="txtSalary" Text="Salary"
                            ToolTip="Salary"></asp:Label>
                        <asp:Label ID="reqSalary" runat="server" AssociatedControlID="txtSalary" Text="*"
                            ForeColor="Red"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <telerik:RadNumericTextBox ID="txtSalary" runat="server" Culture="English (United States)"
                        Type="Currency" Width="211px" MaxValue="100000000" MinValue="0" ToolTip="Salary"
                        CssClass="FontSmall">
                    </telerik:RadNumericTextBox></div>
                <div class="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="txtSalary" ErrorMessage="Required Salary" CssClass="FontSmall"
                        Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" Display="Dynamic" ControlToValidate="txtSalary"
                        ErrorMessage="Incorrect Salary" Type="Double" MinimumValue="0" MaximumValue="10000000"></asp:RangeValidator></div>
            </div>
            <%--Job Title--%>
            <div class="InputRow FontSmall">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblJobTitle" runat="server" AssociatedControlID="txtJobTitle" Text="Job Title"
                            ToolTip="Job Title"></asp:Label>
                        <asp:Label ID="req3" runat="server" AssociatedControlID="txtJobTitle" Text="*" ForeColor="White"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <telerik:RadTextBox ID="txtJobTitle" runat="server" Width="211px" ToolTip="Job Title"
                        CssClass="FontSmall">
                    </telerik:RadTextBox>
                        <asp:DropDownList ID="ddlJobtitle" runat="server" CssClass="FontSmall" 
                        Width="215px" Visible="False">
                        </asp:DropDownList>
                    </div>
                <div class="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ControlToValidate="txtJobTitle" ErrorMessage="Required JobTitle" CssClass="FontSmall"
                        Enabled="False" EnableClientScript="False"></asp:RequiredFieldValidator>
                </div>
            </div>
            <%--Department--%>
            <div id="dvDepartment" runat="server" class="InputRow" visible="false">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblDepartmentCode" runat="server" AssociatedControlID="ddlDepartment"
                            Text="Department"></asp:Label>
                        <asp:Label ID="Label5" runat="server" AssociatedControlID="ddlDepartment" Text="*"
                            ForeColor="Red"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="FontSmall" Width="215px">
                    </asp:DropDownList>
                </div>
                <div class="InputValidator">
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic"
                            ControlToValidate="ddlDepartment" ErrorMessage="Required Department" InitialValue="x"
                            Enabled="False"></asp:RequiredFieldValidator></div>
                </div>
                <div class="Blank10">
                </div>
            </div>
            <%--Client ID--%>
            <div id="dvClientID" runat="server" class="InputRow" visible="false">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblClientID" runat="server" AssociatedControlID="txtClientID" Text="Client ID"></asp:Label>
                        <asp:Label ID="Label7" runat="server" AssociatedControlID="txtClientID" Text="*"
                            ForeColor="White"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <telerik:RadTextBox ID="txtClientID" runat="server" CssClass="FontSmall" Width="210px"
                        SelectionOnFocus="CaretToBeginning" MaxLength="15">
                    </telerik:RadTextBox>
                </div>
                <div class="InputValidator">
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic"
                            ControlToValidate="txtClientID" ErrorMessage="Required Client ID" Enabled="False"
                            Visible="False" EnableClientScript="False" EnableTheming="True"></asp:RequiredFieldValidator></div>
                </div>
            </div>
            <%--Company ID--%>
            <div id="dvCompany" runat="server" class="InputRow" visible="false">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblPayrollCompanyID" runat="server" AssociatedControlID="txtClientID"
                            Text="Payroll Company ID"></asp:Label>
                        <asp:Label ID="lblReqpcid" runat="server" AssociatedControlID="txtClientID" Text="*"
                            ForeColor="Red"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <asp:DropDownList ID="ddlPayrollCompanyID" runat="server" CssClass="FontSmall" Width="215px">
                    </asp:DropDownList>
                </div>
                <div class="InputValidator">
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic"
                            ControlToValidate="ddlPayrollCompanyID" ErrorMessage="Required Payroll Company ID"
                            InitialValue="x" Enabled="False"></asp:RequiredFieldValidator></div>
                </div>
            </div>
            <%--FTE_HRS--%>
            <div id="dvFTE_HRS" runat="server" class="InputRow" visible="false">
                <div class="InputRowNoPadding">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblFullHors" runat="server" AssociatedControlID="txtFullHors" Text="Full Hours"></asp:Label>
                            <asp:Label ID="lblreqFullHors" runat="server" AssociatedControlID="txtFullHors" Text="*"
                                ForeColor="Red"></asp:Label></div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadNumericTextBox ID="txtFullHors" runat="server" Culture="en-US" Width="211px"
                            MaxValue="100000000" MinValue="1" ToolTip="Full Hours" CssClass="FontSmall" DbValueFactor="1"
                            LabelWidth="84px">
                            <NumberFormat ZeroPattern="n" DecimalDigits="1"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="InputValidator">
                        <div class="InputValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic"
                                ControlToValidate="txtFullHors" ErrorMessage="Required Full Hours" Enabled="False"></asp:RequiredFieldValidator></div>
                    </div>
                </div>
                <div class="InputRowNoPadding">
                    <div class="InputLabel">
                        <div class="InputLabel" style="width: 25px">
                            &nbsp;
                        </div>
                        <div class="InputLabel" style="width: 125px">
                            <asp:Label ID="lblScheduledHours" runat="server" AssociatedControlID="txtScheduledHours"
                                Text="Scheduled Hours"></asp:Label>
                            <asp:Label ID="lblreqScheduledHours" runat="server" AssociatedControlID="txtScheduledHours"
                                Text="*" ForeColor="Red"></asp:Label></div>
                    </div>
                    <div class="InputValue">
                        <telerik:RadNumericTextBox ID="txtScheduledHours" runat="server" Culture="en-US"
                            Width="211px" MaxValue="100000000" MinValue="0" ToolTip="Scheduled Hours" CssClass="FontSmall"
                            DbValueFactor="1" LabelWidth="84px">
                            <NumberFormat ZeroPattern="n" DecimalDigits="1"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="InputValidator">
                        <div class="InputValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic"
                                ControlToValidate="txtScheduledHours" ErrorMessage="Required Scheduled Hours"
                                Enabled="False"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFullHors"
                                ControlToValidate="txtScheduledHours" Display="Dynamic" ErrorMessage="Scheduled hours cannot be more than Full Time hours"
                                Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
            </div>
            <%--Workers Comp Class--%>
            <div id='dvWorkersCompClass' runat="server" class="InputRow">
                <div class="InputLabel">
                    <div class="InputLabel" style="width: 25px">
                        &nbsp;
                    </div>
                    <div class="InputLabel" style="width: 125px">
                        <asp:Label ID="lblWorkersCompClass" runat="server" AssociatedControlID="ddlWorkersCompClass"
                            Text="Workers Comp Class"></asp:Label>
                        <asp:Label ID="reqWorkersCompClass" runat="server" AssociatedControlID="ddlWorkersCompClass"
                            Text="*" ForeColor="Red"></asp:Label></div>
                </div>
                <div class="InputValue">
                    <asp:DropDownList ID="ddlWorkersCompClass" runat="server" CssClass="FontSmall" Width="215px">
                    </asp:DropDownList>
                </div>
                <div class="InputValidator">
                    <div class="InputValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Display="Dynamic"
                            ControlToValidate="ddlWorkersCompClass" ErrorMessage="Required Workers Comp Class"
                            Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Blank10">
            </div>
            <div class="InputRow" style="">
                <asp:Label ID="LBL_FLD_MessageAccount_Division_Class_PaySchedule" runat="server"
                    Text=""></asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <%--Buttons--%>
            <div class="InputRow" style="">
                <input id="htmbtnHome" style="width: 110px" runat="server" type="button" value="Welcome Page"
                    onclick="window.open('start.aspx?SkipCheck=YES','_self');" />&nbsp;
                <asp:Button ID="btnNext" runat="server" Text="Save & Next" OnClick="nextButton_Click"
                    Width="110px" />
                <%--<asp:Button ID="btnNext" runat="server" Text="Next" Style="float: right; width: 75px"
                                                OnClick="nextButton_Click" CausesValidation="False" />--%>
            </div>
        </div>
    </div>
        <div id = "douplicateSSN" runat="server" style="visibility: collapse"><span style='font-size: 10pt; font-family: arial;'><span style='text-decoration: underline;'><strong>WARNING</strong></span><span style='color: #c00000; background-color: #fdeada;'> - You have entered an employee who is already active in the following location(s) listed below. [Account]Be very careful if you are truly adding this employee as a duplicate. If you did not mean to attempt to add this employee, click the Welcome Page button. </span><br />
<strong></strong><strong><span style='color: #ff0000; background-color: #ffff00;'>Please make sure to select NON-BENEFIT class for this employee to prevents a chance of employee &nbsp;&ldquo;double-dipping&rdquo; single-enrollment benefits such as medical, dental, vision and prescription from the same class in two or more locations.</span></strong><br />
</span></div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
