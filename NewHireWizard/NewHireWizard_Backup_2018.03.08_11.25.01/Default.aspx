<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="NewHireWizard._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
<!--

        function showDialog1()
        {                    
            window.radopen("PendClasses.aspx" , "RadWindow1");
            return false; 
        }
        
        function showDialog2()
        {                    
            window.radopen("ChangeClass.aspx" , "RadWindow2");
            return false; 
        }
        
        function showDialog3()
        {                    
            window.radopen("/web_projects/Account_number_small/Default.aspx" , "RadWindow3");
            return false; 
        }
        
        function showDialog4()
        {                    
            window.radopen("ChangePaySchecule.aspx" , "RadWindow2");
            return false; 
        }
        
        function OnClientclose(radWindow)
        {   
     
          var retcode;    
            if (radWindow.argument)
              retcode= radWindow.argument
            
            if (retcode == "1")   
            {                                     
                radWindow.argument = 0;                  
                return;
            }   
                        
            if (retcode == "2") // Coming From Change Class  
            {                                     
                radWindow.argument = 0;    
                eval(document.getElementById('hidClass')).value='Go'; 
                PostBack();             
                return;
            }     
            
            if (retcode == "3") // Coming From Change Division  
            {                                     
                radWindow.argument = 0;    
                eval(document.getElementById('hidDiv')).value='Go'; 
                PostBack();             
                return;
            }
            
            if (retcode == "4") // Coming From Change PaySchedule  
            {                                     
                radWindow.argument = 0;    
                eval(document.getElementById('hidPay')).value='Go'; 
                PostBack();             
                return;
            }      
         }   
         
        function PostBack() 
        {
            var theForm = document.forms['aspnetForm'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
            {                
                theForm.submit();
            }
        }     
                  
// -->         
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadPanelBar1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadPanelBar1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
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
                    VisibleStatusbar="False" Width="600px" Height="400px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
            </Windows>
            <Windows>
                <telerik:RadWindow ID="RadWindow3" runat="server" NavigateUrl="/web_projects/Account_number_small/Default.aspx"
                    Skin="Sunset" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                    Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                    VisibleStatusbar="False" Width="600px" Height="390px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <asp:HiddenField ID="hidClass" runat="server" />
        <asp:HiddenField ID="hidDiv" runat="server" />
        <asp:HiddenField ID="hidPay" runat="server" />
        <div id="dvFullPage" runat="server" class="FullPage">
            <div id="Div2" runat="server" class="FullPage" style="height: 70px">
                <div id="InputRow" runat="server" class="InputRow FontSmall">
                    <span id="lblInstruction" runat="server"><b>Add New Hire</b><br>
                        Your organization requires this system to pend new hires in certain classes. Once
                        you enter the employee’s class in step 2, we will tell you whether or not the employee’s
                        record will be pended. </span>
                    <asp:LinkButton ID="lnkbtnShowPendClass" runat="server">Click here to see all classes requiring pending.</asp:LinkButton>
                </div>
            </div>
            <div id="Div3" runat="server" class="FullPage">
                <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Skin="Sunset" Width="770px"
                    ExpandMode="SingleExpandedItem">
                    <Items>
                        <telerik:RadPanelItem runat="server" Text="Account/Division/Class/Pay Schedule" Value="Section1"
                            Font-Bold="True" Font-Size="Small">
                            <Items>
                                <%--Account/Division--%>
                                <telerik:RadPanelItem runat="server" Value="i0">
                                    <ItemTemplate>
                                        <div class="StatusInputRowTitle">
                                            &nbsp;<asp:Label ID="lblTitle1" runat="server" CssClass="InsideTitle">Enter information as requested below. Click "Change" hyperlinks to view options:</asp:Label>
                                        </div>
                                        <div class="Statusblank10">
                                            &nbsp;
                                        </div>
                                        <%--Division--%>
                                        <div class="StatusInputRowTitleLeftPad FontSmall">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblAccount" runat="server" Text="Account/Division"></asp:Label>
                                            </div>
                                            <div class="ChangeCommand">
                                                <asp:LinkButton ID="lnkbtnChangeDivision" runat="server">Change</asp:LinkButton>
                                            </div>
                                            <div class="Validator">
                                                <asp:TextBox ID="txtAccountNameNumberValues" runat="server" ReadOnly="true" CssClass="NoBorder" Width="350px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--Class--%>
                                        <div class="StatusInputRowTitleLeftPad FontSmall">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblClass" runat="server" Text="Class Code"></asp:Label>
                                            </div>
                                            <div class="ChangeCommand">
                                                <asp:LinkButton ID="lnkbtnChangeClass" runat="server">Change</asp:LinkButton>
                                            </div>
                                            <div class="Validator">
                                                <asp:TextBox ID="txtClassValue" runat="server" ReadOnly="true" CssClass="NoBorder" Width="350px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--Pay Schedule--%>
                                        <div class="StatusInputRowTitleLeftPad FontSmall">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblPaySchedule" runat="server" Text="Pay Schedule"></asp:Label>
                                            </div>
                                            <div class="ChangeCommand">
                                                <asp:LinkButton ID="lnkbtnChangePaySchedule" runat="server">Change</asp:LinkButton>
                                            </div>
                                            <div class="Validator">
                                                <asp:TextBox ID="txtPayScheduleValue" runat="server" ReadOnly="true" CssClass="NoBorder" Width="350px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--Buttons--%>
                                        <div class="ButtonRow" style="">
                                            <asp:Button ID="btnNext" runat="server" Text="Next" Style="float: right; width: 75px"
                                                OnClick="nextButton_Click" />
                                            <%--<asp:Button ID="btnNext" runat="server" Text="Next" Style="float: right; width: 75px"
                                                OnClick="nextButton_Click" CausesValidation="False" />--%>
                                        </div>
                                    </ItemTemplate>
                                </telerik:RadPanelItem>
                            </Items>
                        </telerik:RadPanelItem>
                        <%--Name/Identification--%>
                        <telerik:RadPanelItem runat="server" Text="Name/Identification" Value="Section2"
                            Font-Bold="True" Font-Size="Small">
                            <Items>
                                <telerik:RadPanelItem runat="server" Value="i0">
                                    <ItemTemplate>
                                        <div class="StatusInputRowTitle">
                                            &nbsp;<asp:Label ID="lblTitle2" runat="server" CssClass="InsideTitle">Enter information as requested below:</asp:Label>
                                        </div>
                                        <div class="Statusblank10">
                                            &nbsp;
                                        </div>
                                        <%--First Name--%>
                                        <div class="InputRow">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblFirstName" runat="server" Text="First Name" AssociatedControlID="txtFirstName"></asp:Label>
                                                <asp:Label ID="reqFirstName" runat="server" ForeColor="Red" Text="*" AssociatedControlID="lblFirstName"></asp:Label></div>
                                            <div class="InputValue">
                                                <telerik:RadTextBox ID="txtFirstName" runat="server" MaxLength="15" SelectionOnFocus="CaretToBeginning"
                                                    Width="210px" ValidationGroup="grp2">
                                                </telerik:RadTextBox></div>
                                            <div class="InputValidator">
                                                <asp:RequiredFieldValidator ID="reqvalidFirstName" runat="server" ErrorMessage="Required First Name"
                                                    ControlToValidate="txtFirstName" Display="Dynamic" ValidationGroup="grp2"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <%--Middle Initial--%>
                                        <div class="InputRow">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblMiddle_Initial" runat="server" AssociatedControlID="txtMiddleInitial"
                                                    Text="Middle Initial"></asp:Label>
                                            </div>
                                            <div class="InputValue">
                                                <telerik:RadTextBox ID="txtMiddleInitial" runat="server" MaxLength="1" Width="210px"
                                                    CssClass="fontsmall">
                                                </telerik:RadTextBox>
                                            </div>
                                            <div class="InputValidator">
                                                &nbsp;</div>
                                        </div>
                                        <%--Last Name--%>
                                        <div class="InputRow">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label>
                                                <asp:Label ID="reqLastName" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtLastName"></asp:Label></div>
                                            <div class="InputValue">
                                                <telerik:RadTextBox ID="txtLastName" runat="server" MaxLength="20" Width="210px"
                                                    CssClass="fontsmall" ValidationGroup="grp2">
                                                </telerik:RadTextBox>
                                            </div>
                                            <div class="InputValidator">
                                                <asp:RequiredFieldValidator ID="reqvaildLastName" runat="server" ControlToValidate="txtLastName"
                                                    ErrorMessage="Required Last Name" Display="Dynamic" ValidationGroup="grp2"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <%--DOB--%>
                                        <div class="InputRow">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblDateofBirth" runat="server" Text="Date of Birth" AssociatedControlID="txtDateofBirth"></asp:Label>
                                                <asp:Label ID="reqDateofBirth" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtDateofBirth"></asp:Label></div>
                                            <div class="InputValue">
                                                <telerik:RadMaskedTextBox ID="txtDateofBirth" runat="server" DisplayMask="##/##/####"
                                                    ValidationGroup="grp2" Mask="##/##/####" TextWithLiterals="//" Width="211px">
                                                    <FocusedStyle CssClass="fontsmall" />
                                                    <EnabledStyle CssClass="fontsmall" />
                                                </telerik:RadMaskedTextBox></div>
                                            <div class="InputValidator">
                                                <asp:RequiredFieldValidator ID="reqvalidDateofBirth" runat="server" ControlToValidate="txtDateofBirth"
                                                    ErrorMessage="Required Date of Birth" Display="Dynamic" ValidationGroup="grp2"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDateofBirth"
                                                    Display="Dynamic" ErrorMessage="Incorrect Date of Birth" MaximumValue="01/01/2099"
                                                    MinimumValue="01/01/1900" Type="Date" ValidationGroup="grp2"></asp:RangeValidator></div>
                                        </div>
                                        <%--Gender--%>
                                        <div class="InputRow">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblGender" runat="server" AssociatedControlID="ddlGender" Text="Gender"></asp:Label>
                                                <asp:Label ID="reqGender" runat="server" ForeColor="Red" Text="*" AssociatedControlID="ddlGender"></asp:Label></div>
                                            <div class="InputValue">
                                                <asp:DropDownList ID="ddlGender" runat="server" Width="215px" CssClass="fontsmall"
                                                    ValidationGroup="grp2">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                </asp:DropDownList></div>
                                            <div class="InputValidator">
                                                <asp:RequiredFieldValidator ID="reqvaildGender" runat="server" ControlToValidate="ddlGender"
                                                    ErrorMessage="Required Gender" Display="Dynamic" InitialValue="0" ValidationGroup="grp2"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <%--Marital Status--%>
                                        <div class="InputRow">
                                            <div class="InputLabel">
                                                <asp:Label ID="lblMaritalStatus" runat="server" AssociatedControlID="ddlMaritalStatus"
                                                    Text="Marital Status"></asp:Label>
                                                <asp:Label ID="reqMaritalStatus" runat="server" ForeColor="Red" Text="*" AssociatedControlID="ddlMaritalStatus"></asp:Label></div>
                                            <div class="InputValue">
                                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="215px" CssClass="fontsmall"
                                                    ValidationGroup="grp2">
                                                </asp:DropDownList></div>
                                            <div class="InputValidator">
                                                <div class="InputValidator">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMaritalStatus"
                                                        ErrorMessage="Required Marital Status" Display="Dynamic" InitialValue="x" ValidationGroup="grp2"></asp:RequiredFieldValidator></div>
                                            </div>
                                            <%--Buttons--%>
                                            <div class="ButtonRow" style="">
                                                <asp:Button ID="btnNext" runat="server" Text="Next" Style="float: right; width: 75px"
                                                    OnClick="nextButton_Click" />
                                                <asp:Button ID="btnBack" runat="server" Text="Back" Style="float: right; width: 75px"
                                                    OnClick="BackButton_Click" />
                                            </div>
                                    </ItemTemplate>
                                </telerik:RadPanelItem>
                            </Items>
                        </telerik:RadPanelItem>
                        <%--Contact Information--%>
                        <telerik:RadPanelItem runat="server" Text="Contact Information" Value="Section3"
                            Font-Bold="True" Font-Size="Small">
                            <Items>
                                <telerik:RadPanelItem runat="server" Value="i0">
                                    <ItemTemplate>
                                        <div class="StatusInputRowTitle">
                                            &nbsp;<asp:Label ID="lblTitle3" runat="server" CssClass="InsideTitle">Enter information as requested below:</asp:Label>
                                        </div>
                                        <div class="Statusblank10">
                                            &nbsp;
                                        </div>
                                        <%--Home Address--%>
                                        <asp:Panel ID="pnlAddress1" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel2" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1" AssociatedControlID="txtAddressLine1"></asp:Label>
                                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtAddressLine1"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel3" runat="server" CssClass="InputValue">
                                                <telerik:RadTextBox ID="txtAddressLine1" runat="server" MaxLength="30" Width="210px"
                                                    CssClass="fontsmall" ValidationGroup="grp3">
                                                </telerik:RadTextBox>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel4" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required Address Line 1"
                                                    ControlToValidate="txtAddressLine1" Display="Dynamic" ValidationGroup="grp3"></asp:RequiredFieldValidator>
                                            </asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="PnlAddress2" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel6" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2" AssociatedControlID="txtAddressLine2"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtAddressLine2" ForeColor="White"
                                                    Text="*"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel7" runat="server" CssClass="InputValue">
                                                <telerik:RadTextBox ID="txtAddressLine2" runat="server" MaxLength="30" Width="210px"
                                                    CssClass="fontsmall" ValidationGroup="grp3">
                                                </telerik:RadTextBox>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel8" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddressLine2"
                                                    Display="Dynamic" Enabled="False" ErrorMessage="Required Address Line 2" ValidationGroup="grp3"></asp:RequiredFieldValidator>&nbsp;</asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlCity" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel10" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="txtCity"></asp:Label>
                                                <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtCity"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel11" runat="server" CssClass="InputValue">
                                                <telerik:RadTextBox ID="txtCity" runat="server" MaxLength="20" Width="210px" CssClass="fontsmall"
                                                    ValidationGroup="grp3">
                                                </telerik:RadTextBox>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel12" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required City"
                                                    ControlToValidate="txtCity" Display="Dynamic" ValidationGroup="grp3"></asp:RequiredFieldValidator>
                                            </asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlState" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel14" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="ddlState"></asp:Label>
                                                <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*" AssociatedControlID="ddlState"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel15" runat="server" CssClass="InputValue">
                                                <asp:DropDownList ID="ddlState" runat="server" Width="215px" CssClass="fontsmall"
                                                    ValidationGroup="grp3">
                                                </asp:DropDownList></asp:Panel>
                                            <asp:Panel ID="Panel16" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required State"
                                                    ControlToValidate="ddlState" Display="Dynamic" InitialValue="0" ValidationGroup="grp3"></asp:RequiredFieldValidator>
                                            </asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlZipCode" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel18" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" AssociatedControlID="txtZipCode"></asp:Label>
                                                <asp:Label ID="Label13" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtZipCode"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel19" runat="server" CssClass="InputValue">
                                                <telerik:RadTextBox ID="txtZipCode" runat="server" CssClass="fontsmall" Width="210px"
                                                    ValidationGroup="grp3">
                                                </telerik:RadTextBox></asp:Panel>
                                            <asp:Panel ID="Panel20" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required Zip Code"
                                                    ControlToValidate="txtZipCode" Display="Dynamic" ValidationGroup="grp3"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtZipCode"
                                                    Display="Dynamic" ErrorMessage="Incorrect Zip Code" ValidationExpression="\d{5}(-\d{4})?"
                                                    EnableClientScript="False" ValidationGroup="grp3"></asp:RegularExpressionValidator></asp:Panel>
                                        </asp:Panel>
                                        <%--Phone Numbers--%>
                                        <asp:Panel ID="Panel21" runat="server" CssClass="Blank10">
                                            &nbsp;
                                        </asp:Panel>
                                        <asp:Panel ID="pnlWorkPhone" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel23" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblWorkPhone" runat="server" Text="Work Phone / Ext" AssociatedControlID="txtWorkPhone"></asp:Label>
                                                <asp:Label ID="Label14" runat="server" ForeColor="Red" Text="*"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel24" runat="server" CssClass="InputValue">
                                                <asp:Panel ID="Panel25" runat="server" CssClass="InputValue" Style="width: 147px">
                                                    <telerik:RadMaskedTextBox ID="txtWorkPhone" runat="server" Mask="(###) ###-####"
                                                        Width="140px" ValidationGroup="grp3">
                                                    </telerik:RadMaskedTextBox>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel26" runat="server" CssClass="InputValue" Style="width: 66px">
                                                    &nbsp;<telerik:RadMaskedTextBox ID="txtExtension" runat="server" Mask="##########"
                                                        Width="66px" PromptChar=" " SelectionOnFocus="CaretToBeginning" ValidationGroup="grp3">
                                                    </telerik:RadMaskedTextBox></asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel27" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required Work Phone"
                                                    ControlToValidate="txtWorkPhone" Display="Dynamic" ValidationGroup="grp3"></asp:RequiredFieldValidator>
                                            </asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlHomePhone" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel29" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone" AssociatedControlID="txtHomePhone"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" AssociatedControlID="txtHomePhone" ForeColor="White"
                                                    Text="*"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel30" runat="server" CssClass="InputValue">
                                                <telerik:RadMaskedTextBox ID="txtHomePhone" runat="server" Mask="(###) ###-####"
                                                    Width="215px" ValidationGroup="grp3">
                                                </telerik:RadMaskedTextBox></asp:Panel>
                                            <asp:Panel ID="Panel31" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHomePhone"
                                                    Display="Dynamic" Enabled="False" ErrorMessage="Required Home Phone" ValidationGroup="grp3"></asp:RequiredFieldValidator>&nbsp;</asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlMobilePhone" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel33" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblMobilePhone" runat="server" Text="Mobile Phone" AssociatedControlID="txtMobilePhone"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtMobilePhone" ForeColor="White"
                                                    Text="*" Visible="False"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel34" runat="server" CssClass="InputValue">
                                                <telerik:RadMaskedTextBox ID="txtMobilePhone" runat="server" Mask="(###) ###-####"
                                                    Width="215px" ValidationGroup="grp3">
                                                </telerik:RadMaskedTextBox></asp:Panel>
                                            <asp:Panel ID="Panel35" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobilePhone"
                                                    Display="Dynamic" Enabled="False" ErrorMessage="Required Mobile Phone" ValidationGroup="grp3"></asp:RequiredFieldValidator></asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlFaxNumber" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel37" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblFaxNumber" runat="server" Text="Fax Number" AssociatedControlID="txtFaxNumber"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" AssociatedControlID="txtFaxNumber" ForeColor="White"
                                                    Text="*"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel38" runat="server" CssClass="InputValue">
                                                <telerik:RadMaskedTextBox ID="txtFaxNumber" runat="server" Mask="(###) ###-####"
                                                    Width="215px" ValidationGroup="grp3">
                                                </telerik:RadMaskedTextBox></asp:Panel>
                                            <asp:Panel ID="Panel39" runat="server" CssClass="InputValidator">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFaxNumber"
                                                    Display="Dynamic" Enabled="False" ErrorMessage="Required Fax Phone" ValidationGroup="grp3"></asp:RequiredFieldValidator>&nbsp;</asp:Panel>
                                        </asp:Panel>
                                        <%--Email Addresses--%>
                                        <asp:Panel ID="Panel40" runat="server" CssClass="Blank10">
                                            &nbsp;
                                        </asp:Panel>
                                        <asp:Panel ID="pnlWorkEmail" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel42" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblEmailWork" runat="server" Text="Work Email" AssociatedControlID="txtEmailWork"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" AssociatedControlID="txtEmailWork" ForeColor="Red"
                                                    Text="*"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel43" runat="server" CssClass="InputValue">
                                                <telerik:RadTextBox ID="txtEmailWork" runat="server" MaxLength="100" Width="210px"
                                                    CssClass="fontsmall" ValidationGroup="grp3">
                                                </telerik:RadTextBox></asp:Panel>
                                            <asp:Panel ID="Panel44" runat="server" CssClass="InputValidator">
                                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="txtEmailWork" Display="Dynamic" ErrorMessage="Incorrect Work Email Format"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grp3"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailWork"
                                                    Display="Dynamic" ErrorMessage="Required Fax Phone" ValidationGroup="grp3"></asp:RequiredFieldValidator></asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlAltenateEmail" runat="server" CssClass="InputRow">
                                            <asp:Panel ID="Panel46" runat="server" CssClass="InputLabel">
                                                <asp:Label ID="lblemailPersonal" runat="server" Text="Alternate Email" AssociatedControlID="txtAlternateEmail"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" AssociatedControlID="txtAlternateEmail" ForeColor="White"
                                                    Text="*"></asp:Label></asp:Panel>
                                            <asp:Panel ID="Panel47" runat="server" CssClass="InputValue">
                                                <telerik:RadTextBox ID="txtAlternateEmail" runat="server" MaxLength="100" Width="210px"
                                                    CssClass="fontsmall" ValidationGroup="grp3">
                                                </telerik:RadTextBox></asp:Panel>
                                            <asp:Panel ID="Panel48" runat="server" CssClass="InputValidator">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAlternateEmail"
                                                    Display="Dynamic" ErrorMessage="Incorrect Personal Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="grp3"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAlternateEmail"
                                                        Display="Dynamic" Enabled="False" ErrorMessage="Required Personal Email" ValidationGroup="grp3"></asp:RequiredFieldValidator>&nbsp;</asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel49" runat="server" CssClass="Blank10" Style="width: 521px">
                                            &nbsp;
                                        </asp:Panel>
                                        <%--Buttons--%>
                                        <div class="ButtonRow" style="">
                                            <asp:Button ID="btnNext" runat="server" Text="Next" Style="float: right; width: 75px"
                                                OnClick="nextButton_Click" />
                                            <asp:Button ID="btnBack" runat="server" Text="Back" Style="float: right; width: 75px"
                                                OnClick="BackButton_Click" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:RadPanelItem>
                            </Items>
                        </telerik:RadPanelItem>
                    </Items>
                </telerik:RadPanelBar>
            </div>
        </div>
        <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Button" OnClick="Button1_Click" />
    </form>
</body>
</html>
