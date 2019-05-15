<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddEditDep.aspx.cs" Inherits="Dependents_Maintenance.AddEditDep" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add/Edit Dependents</title>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <link href="Dep_Main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">                
         function showDialog1()
         {                  
            window.radopen("Message.aspx", "RadWindow1");
            return false; 
         }                 
         
         
        function PostBack() 
        {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
            {                
                theForm.submit();
            }
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
            if (retcode == "2")   
            {                                     
                radWindow.argument = 0;
                var hid = eval(document.getElementById('hidRelation'));           
                hid.value = '1';
                PostBack();                                                                  
                return;
            }
        }
               
        function docloseWindow(id)
        {           
        closeWindow(id); return false;
        }
        
        function GetRadWindow()
        {
          var oWindow = null;
          if (window.radWindow)
             oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
             oWindow = window.frameElement.radWindow;
          return oWindow;
        }  
        
        function closeWindow(id)
        {

            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }

        function closeWindowcloseWindowOE(id)
        {
            //alert(id);
            
            try {
                //window.parent.location.href = "/web_projects/EnrollmentWizard/DependentInfo.aspx";
                window.location.href = "/web_projects/Dependents_Maintenance/Blank.aspx";
                //window.parent.location.reload(false);
                return;
            }
            catch (e) {};
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }    
        function confimemail()
        {
            var ok = confirm('Do you wish to send the retiree an email?');
            var hid = eval(document.getElementById('hidRetSave'));
            if (ok)
              hid.value = 'yes'
            else
              hid.value = 'No';
            PostBack();
        }   
        
        function ErrorDP()
        {
            alert('You cannot declare a domestic partner as an Open Enrollment election.  For details about eligibility related to the Domestic Partner Program, please contact the Benefits Hotline.\nThe Benefits Hotline may be reached at 877-334-2111.\n\nPlease click on “OK” to close this window, and then click on “Cancel” to continue the Open Enrollment process');

        } 
        
        function SpouseError()
        {
            alert('You have more than one spouse. You may not continue. You have to remove all but one spouse to be able to Add or Edit');
            closeWindow(1);
        } 
        
         
                
        function Button2_onclick(ctrl) 
        {
            ctrl.disabled = true;
            document.getElementById('hidSave').value='ok';
            PostBack();
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadWindowManager ID="Singleton" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" NavigateUrl="Message.aspx" OpenerElementID="Label1"
                Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                VisibleStatusbar="False" Width="700px" Height="250px" ShowContentDuringLoad="False"
                VisibleTitlebar="False">
            </telerik:RadWindow>
            <telerik:RadWindow ID="RadWindow2" runat="server" NavigateUrl="RelationNote.aspx" OpenerElementID="Label1"
                Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                VisibleStatusbar="False" Width="700px" Height="290px" ShowContentDuringLoad="False"
                VisibleTitlebar="False">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
        <asp:HiddenField ID="hidRetSave" runat="server" />
        <asp:HiddenField ID="hidRelation" runat="server" />
        
        
        &nbsp;      
        <asp:Panel ID="Panel1" runat="server">
        <div id="dvMain" class="AddEditMain" runat="server">
            <div id="Div2" class="AddEditMain" style="text-align: center; height: 25px;">
                <asp:Label ID="lblTitle" runat="server" Text="Edit Dependent" CssClass="fontsmall"
                    Font-Bold="True"></asp:Label>
            </div>
            <div id="divInstuction" class="AddEditMain" style="text-align: center; height: 25px;">
                <asp:LinkButton ID="lnkbtnDependentEligibilityRules" runat="server" CssClass="fontsmall" Font-Bold="True" Font-Underline="True" CausesValidation="False">Dependent Eligibility Rules</asp:LinkButton>
            </div>
            <div id="dvOpenEnrollNote" class="AddEditMain" style="text-align: left; height: 45px;"
                runat="server" visible="false">
                <asp:Label ID="OpenEnrollNote" runat="server" CssClass="fontsmall" Font-Bold="True"
                    Width="704px">If a life event has occurred within the past 60 days that results in the addition of a dependent record before 1/1/2010, return to the "Welcome Page" and click on "Submit a Permitted Election Change Due to a Life Event."</asp:Label>&nbsp;
            </div>
            <div id="dvLeftPanel" class="AddEditLeft">
                <%--RelationShip--%>
                <div class="AddEditRowLeft">
                <asp:HiddenField ID="hidSave" runat="server" />
                    <div class="AddEditLabel">
                        <asp:Label ID="lblRelatio" runat="server" CssClass="fontsmall" Text="Relationship"
                            ToolTip="Relation Title" AssociatedControlID="ddlRelation"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label14" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:DropDownList ID="ddlRelation" runat="server" CssClass="fontsmall" Width="166px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlRelation_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlRelation"
                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="Required Info." InitialValue="x"></asp:RequiredFieldValidator></div>
                <%--FirstName--%>
                <div id="dvData" runat="server">
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" CssClass="fontsmall"
                                Text="First Name" ToolTip="First Name Title"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label12" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="fontsmall" Width="160px"
                                MaxLength="15"></asp:TextBox>
                        </div>
                        <div class="AddEditValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--MI--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblMI" runat="server" CssClass="fontsmall" Text="Middle Initial"
                                ToolTip="Middle Initial Title" AssociatedControlID="txtMI"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label4" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:TextBox ID="txtMI" runat="server" CssClass="fontsmall" Width="160px" MaxLength="1"></asp:TextBox>
                        </div>
                        <div class="AddEditValidator">
                            &nbsp;
                        </div>
                    </div>
                    <%--Last Name--%>
                    <div id="dvRow3" class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblLastName" runat="server" CssClass="fontsmall" Text="Last Name"
                                ToolTip="Last Name Title" AssociatedControlID="txtLastName"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label3" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="fontsmall" Width="160px" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="AddEditValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
                    <%--SSN--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblSSN" runat="server" CssClass="fontsmall" Text="SSN" ToolTip="Social Security Number Title"
                                AssociatedControlID="txtSSN"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label5" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <telerik:RadMaskedTextBox ID="txtSSN" runat="server" Mask="###-##-####" 
                                CssClass="FontSmall" Width="167px">
                            </telerik:RadMaskedTextBox>
                        </div>
                        <div class="AddEditValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSSN"
                                CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSSN"
                                CssClass="fontsmall" ErrorMessage="Incorrect SSN" ValidationExpression="\d{3}-\d{2}-\d{4}"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <%--DOB--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblDOB" runat="server" CssClass="fontsmall" Text="DOB" ToolTip="Sate of Birth Title"
                                AssociatedControlID="txtDOB"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label6" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <telerik:RadDateInput ID="txtDOB" runat="server" AutoPostBack="True" 
                                DisplayDateFormat="MM/dd/yyyy" MinDate="1900-01-01" 
                                ontextchanged="txtDOB_TextChanged" Width="167px">
                            </telerik:RadDateInput>
                        </div>
                        <div class="AddEditValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB"
                                CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDOB"
                                CssClass="fontsmall" ErrorMessage="Incorrect Date" MaximumValue="01/01/2099"
                                MinimumValue="01/01/1920" Type="Date" Display="Dynamic" Enabled="False"></asp:RangeValidator>
                            <asp:Label ID="lblIncorrectDate" runat="server" CssClass="fontsmall" ForeColor="Red"
                                Text="Incorrect Birth Date" Visible="False"></asp:Label></div>
                    </div>
                    <%--Gender--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblGender" runat="server" CssClass="fontsmall" Text="Gender" ToolTip="Gender Title"
                                AssociatedControlID="ddlGender"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label7" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="fontsmall" Width="166px">
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                                <asp:ListItem Selected="True" Value="xx">Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="AddEditValidator">
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="fontsmall"
                                ErrorMessage="Required Info." InitialValue="xx" ControlToValidate="ddlGender"></asp:RequiredFieldValidator></div>
                    </div>
                    <%--Disabled--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblHndicap" runat="server" CssClass="fontsmall" Text="Disabled" ToolTip="Disabled Title"
                                AssociatedControlID="ddlHandiCap"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label9" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:DropDownList ID="ddlHandiCap" runat="server" CssClass="fontsmall" Width="166px" AutoPostBack="True" OnSelectedIndexChanged="ddlHandiCap_SelectedIndexChanged">
                                <asp:ListItem Value="T">Yes</asp:ListItem>
                                <asp:ListItem Value="F" Selected="True">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="AddEditValidator">
                            &nbsp;
                        </div>
                    </div>
                    <%--EffectiveDate--%>
                    <div id="divEffectiveDate" class="AddEditRowLeft" runat="server" visible="true">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblEffectiveDate" runat="server" CssClass="fontsmall" Text="Effective Date"
                                ToolTip="Effective Date Title" AssociatedControlID="txtEffDate"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label10" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <telerik:RadDateInput ID="txtEffDate" runat="server" AutoPostBack="True" 
                                DisplayDateFormat="MM/dd/yyyy" MinDate="1900-01-01" 
                                ontextchanged="txtDOB_TextChanged" CssClass="fontsmall" Width="167px">
                            </telerik:RadDateInput>
                        </div>
                        <div class="AddEditValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEffDate"
                                CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtEffDate"
                                CssClass="fontsmall" ErrorMessage="Incorrect Date" MaximumValue="01/01/2099"
                                MinimumValue="01/01/1900" Type="Date" Display="Dynamic" Enabled="False"></asp:RangeValidator>
                        </div>
                    </div>
                    <%--Student--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblStudent" runat="server" CssClass="fontsmall" Text="Student" ToolTip="Full Time Student Title"
                                AssociatedControlID="ddlStudent"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="lblReqStudent" runat="server" CssClass="fontsmall" ForeColor="Maroon"
                                Text="* " ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="fontsmall" Width="166px"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                <asp:ListItem Value="T">Yes</asp:ListItem>
                                <asp:ListItem Value="F" Selected="True">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="AddEditValidator" style="width: 83px">
                            &nbsp;
                        </div>
                    </div>
                    <%--School Name--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblSchool" runat="server" CssClass="fontsmall" Text="School Name"
                                ToolTip="School Name Title" AssociatedControlID="txtSchool"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="lblReqSchoolName" runat="server" CssClass="fontsmall" ForeColor="White"
                                Text="* " ToolTip="Required Field" Visible="False"></asp:Label>
                            <asp:Label ID="Label2" runat="server" CssClass="fontsmall" ForeColor="White">&NBSP;</asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <asp:TextBox ID="txtSchool" runat="server" CssClass="fontsmall" Width="160px" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="AddEditValidator">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSchool"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="Required Info." Visible="False"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--Graduation Date--%>
                    <div class="AddEditRowLeft">
                        <div class="AddEditLabel">
                            <asp:Label ID="lblGraduation" runat="server" CssClass="fontsmall" Text="Graduation Date"
                                ToolTip="Graduation Date Title" AssociatedControlID="ddlMonth"></asp:Label>
                        </div>
                        <div class="AddEditReq">
                            <asp:Label ID="Label13" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                                ToolTip="Required Field"></asp:Label>
                        </div>
                        <div class="AddEditTextBox">
                            <div style="width: 83px; float: left">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="fontsmall" Width="83px">
                                    <asp:ListItem Value="0">Month</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style="width: 83px; float: left">
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="fontsmall" Width="82px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="AddEditValidator">
                            &nbsp;
                        </div>
                    </div>
                </div>
                <%--Space--%>
                <div class="AddEditRowLeft" style="height: 10px">
                    &nbsp;
                </div>
                <div class="AddEditRowLeft">
                    <asp:Label ID="lblReqiuedFieldsIndicators" runat="server" CssClass="fontsmall" ToolTip="Required Field Indicator Note"><font color="#800000">*</font> Indicates Required Field</asp:Label>&nbsp;
                </div>
                <div class="AddEditRowLeft" style="height: 10px">
                    &nbsp;
                </div>
                <div class="AddEditRowLeft">
                    <input id="htmbtnSave" type="button" runat="server" value="Save & Exit" language="javascript" onclick="return Button2_onclick(this)" class="FontSmall" />
                    <input id="Button1" type="button" value="Cancelxxx" runat="server" onclick="closeWindow(1); return false;"
                        class="fontsmall" />
                    <input id="htmbtnInOE" type="button" value="Cancel" runat="server" onclick="closeWindowcloseWindowOE(1); return false;"
                        class="fontsmall" />
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancelxxxxxxxxx" OnClick="btnCancel_Click1" Visible="False" />&nbsp;
                    <asp:Button ID="btnSave" runat="server" OnClick="aspxbtn_Click" Text="Save &amp; Exitxxxx"
                        CssClass="fontsmall" ToolTip="Save Changes and Exit" Visible="False" /></div>
            </div>
            <%--Right Panel--%>
            <div id="dvRightPanel" class="AddEditRight">
                <div id="Div1" class="AddEditRowRight">
                    <asp:Label ID="lblInfo" runat="server" CssClass="fontsmall" Font-Bold="True" Text="Dependent’s home address, if different from employee’s "
                        Width="329px"></asp:Label>
                </div>
                <%--Street Address--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblStreet" runat="server" CssClass="fontsmall" Text="Street" ToolTip="Street title"
                            AssociatedControlID="txtStreet"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label1" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="fontsmall" ToolTip="Enter Street"
                            Width="120px" MaxLength="30"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                <%--PO Box Apt--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblApt" runat="server" Text="Apt# / P.O.Box" CssClass="fontsmall" AssociatedControlID="txtApt"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label15" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtApt" runat="server" CssClass="fontsmall" ToolTip="Enter Apartment Number or P.O. Box"
                            Width="120px" MaxLength="30"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                <%--City--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblCity" runat="server" CssClass="fontsmall" Text="City" ToolTip="City Title"
                            AssociatedControlID="txtCity"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label16" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="fontsmall" ToolTip="Enter City"
                            Width="120px" MaxLength="36"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                <%--State--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblState" runat="server" CssClass="fontsmall" Text="State" ToolTip="State Title"
                            AssociatedControlID="ddlState"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label17" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="fontsmall" Width="126px"
                            ToolTip="Select State">
                        </asp:DropDownList>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                <%--Zip--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblZipCode" runat="server" CssClass="fontsmall" Text="Zip Code" ToolTip="Zip Code Title"
                            AssociatedControlID="txtZip"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label18" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtZip" runat="server" CssClass="fontsmall" ToolTip="Enter Zip Code"
                            Width="120px" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtZip"
                            CssClass="fontsmall" ErrorMessage="Incorrect Zip Code" ValidationExpression="\d{5}(-\d{4})?"
                            Width="100px"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <%--Phone--%>
                <div class="AddEditRowRight" id="dvPhone" runat="server">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblHomePhonr" runat="server" CssClass="fontsmall" Text="Phone #" ToolTip="Home Phonr Number Title"
                            AssociatedControlID="txtHomePhone"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label19" runat="server" CssClass="fontsmall" ForeColor="White" Text="* "
                            ToolTip="Required Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <telerik:RadMaskedTextBox ID="txtHomePhone" runat="server" CssClass="fontsmall" ToolTip="EnterHomePhoneNumber"
                            Width="127px" AutoPostBack="True" OnTextChanged="txtHomePhone_TextChanged" 
                            Mask="(###) ###-####">
                         </telerik:RadMaskedTextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="txtHomePhone" CssClass="fontsmall" Display="Dynamic" ErrorMessage="Incorrect Phone#"
                            ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></div>
                </div>
                <%--Warning--%>
                <div class="AddEditRowRight">
                    <asp:Label ID="lblWarning" runat="server" CssClass="fontsmall"></asp:Label>
                </div>
            </div>
        </div>
            </asp:Panel>
    </form>
</body>
</html>
