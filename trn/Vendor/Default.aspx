<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Vendor._Default" %>

<%@ Register Assembly="UltimateMenu" Namespace="Karamasoft.WebControls" TagPrefix="cc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendor Information</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <link href="Vendor.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    var changed;
			function MarkChanged()
			{
			  changed = true;  
			}
			
			function CheckSave(url_)
			{
				var chk = confirm("The data was changed. Do you wish to save the data first? If Yes click Ok otherwise click Cancel")
				if (!chk)
					document.location.href=url_;
				else
				{
					document.Form1.doSave.value=url_;
					__doPostBack('','');
				}

			}
			
		    var name = null;
		    function Message(msg,btnOk,btnCancel)
		    {
		        if (window.document.getElementById(btnOk) == null)
		        {
		          window.setTimeout("Message(msg,btnOk,btnCancel)",500);
		        }
		        if (name != null)
		          return;
				name = confirm(msg);
				if (name==true)
				{
					window.document.getElementById(btnOk).click();									
				}
				else
				{
					tourl = document.getElementById(btnCancel).value;
					window.location.href=tourl;
				}				
		    }
		    
			function RemainingLetters()
			{
			   currentStr = document.getElementById('txtDescribtion').value;
			   currentLength = currentStr.length;			   
			   document.getElementById('txtRemaining').value=4000-currentLength;
			}
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
         		
			function SavedMessage()
			{
			    alert('Data Saved Successfully');
			    document.location.replace('TrainingVendorInfo.aspx');
			}
			
			function DisableSaveButton()
			{
			    eval(document.getElementById('htmbtnSave')).Disabled=true;
			}
			
			function Do_Save()
			{
			    document.getElementById('btnSave').style.visibility='hidden';
			    document.getElementById('dvSaving').style.visibility='visible';
			    
			    eval(document.getElementById('hidCommand')).value='DoSave';
			    postBack();
			}
			
			function postBack()
			{
			 var theForm = document.forms['form1'];
             if (!theForm) 
                theForm = document.form1;
             theForm.submit();            
			}
			
			function DoLocalCommand(cntrl,commandName)
            {	
	            eval(document.getElementById('hidCommand')).value=commandName;
	           
	            cntrl.disabled = true;
	             var theForm = document.forms['form1'];
         if (!theForm) 
            theForm = document.form1;
         theForm.submit();
            }
			
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <%--<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="False" Mask="(999)999-9999" TargetControlID="txtPhoneNumber">
        </cc1:MaskedEditExtender>
        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="False" Mask="(999)999-9999" TargetControlID="txtFaxNumber">
        </cc1:MaskedEditExtender>--%>
        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="False"
            Mask="(999) 999-9999" TargetControlID="txtPhoneNumber">
        </cc1:MaskedEditExtender>
        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="False"
            Mask="(999) 999-9999" TargetControlID="txtFaxNumber">
        </cc1:MaskedEditExtender>
        <div id="wrapper" class="wrapper">
            <div id="dvMenu1" class="menuholder" style="background-image: url(/karama/Images/WinSubTab.gif)">
                <cc2:UltimateMenu ID="UltimateMenu1" runat="server">
                </cc2:UltimateMenu>
            </div>
            <div id="dvMenu2" class="menuholder" style="background-image: url(/karama/Images/WinSubTab.gif)">
                <asp:Label ID="lblWizardError" runat="server" CssClass="fontsmall" Font-Bold="True"
                    ForeColor="Maroon"></asp:Label>&nbsp;</div>
            <div id="dvTemplateHeader" class="GenralRow">
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
            <br />
            <div id="dvContentHeader1" class="fontsmall GenralRow">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="220px"> Training Requested</asp:Label>
                <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True"></asp:Label>
            </div>
            <div id="dvContentHeader2" class="fontsmall GenralRow bottom_border">
                <asp:Label ID="Label28" runat="server" Font-Bold="True" Width="220px">Remaining Budget For: </asp:Label><asp:DropDownList
                    ID="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall">
                </asp:DropDownList>
                <asp:Label ID="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:Label>
                <asp:HiddenField ID="hidCommand" runat="server" />
                <br />
                <br />
            </div>
            <div id="dvInstruction" class="GenralRow">
                <asp:Label ID="lbl_fldTrainingVendor" runat="server" CssClass="fontsmall">Instruction</asp:Label>
                <asp:Label ID="lbl_fldTrainingVendorBook" runat="server" CssClass="fontsmall" Font-Bold="True"
                    Font-Italic="True" Text="Enter the training books, software and/or study materials and the vendor information."></asp:Label></div>
            <div id="dvWarning" class="GenralRow">
                <asp:Label ID="lblBookWarning" runat="server" Font-Bold="True" Font-Underline="True"
                    Visible="False"></asp:Label>
            </div>
            <div id="dvDatawraper" class="GenralRow">
                <div id="dvDataLeft" class="LeftDataSection">
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblrainingEventCode" runat="server" CssClass="fontsmall" AssociatedControlID="txtCourseCode"
                                ToolTip="Learning Event Code">Training Event Code</asp:Label>
                        </div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req16" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:TextBox
                                ID="txtCourseCode" runat="server" Width="220px" CssClass="Input_Control_Small"
                                MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblTrainingEvent" runat="server" AssociatedControlID="txtCourseTitle"
                                CssClass="fontsmall" ToolTip="Training Title">Training Event Title</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req8" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtCourseTitle" runat="server" CssClass="Input_Control_Small" MaxLength="50"
                                Width="220px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCourseTitle"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="Event Title Required Information"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="Label5" runat="server" CssClass="fontsmall" Font-Bold="True" Font-Underline="True">Vendor</asp:Label></div>
                        <div class="LeftDataSectionBox">
                        </div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblVendorName" runat="server" AssociatedControlID="txtVedorName" CssClass="fontsmall"
                                ToolTip="Vendor Name">Name</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label1" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtVedorName" runat="server" CssClass="Input_Control_Small" MaxLength="50"
                                Width="220px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVedorName"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="Vendor Name Required Information"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblVendorContact" runat="server" AssociatedControlID="txtVendorContact"
                                CssClass="fontsmall" ToolTip="Vendor Contact">Contact</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label43" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:TextBox
                                ID="txtVendorContact" runat="server" CssClass="Input_Control_Small" MaxLength="50"
                                Width="220px"></asp:TextBox></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblEnail" runat="server" AssociatedControlID="txtEmail" CssClass="fontsmall"
                                ToolTip="Vendor Email">Email</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label10" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:TextBox
                                ID="txtEmail" runat="server" CssClass="Input_Control_Small" MaxLength="255" ToolTip="Vendor Email"
                                Width="220px"></asp:TextBox><asp:RegularExpressionValidator ID="Regularexpressionvalidator5"
                                    runat="server" ControlToValidate="txtEmail" CssClass="fontsmall" Display="Dynamic"
                                    ErrorMessage="<br />Invalid Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Width="202px"></asp:RegularExpressionValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlContries" CssClass="fontsmall"
                                Text="Country"></asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label4" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:DropDownList
                                ID="ddlContries" runat="server" AutoPostBack="True" CssClass="Input_Control_Small"
                                OnSelectedIndexChanged="ddlContries_SelectedIndexChanged" Width="225px">
                            </asp:DropDownList></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblVendorPhoneFax" runat="server" AssociatedControlID="txtPhoneNumber"
                                CssClass="fontsmall" ToolTip="Vendor Phone Number and Fax Number">Telephone & Fax</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label2" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" Width="100px" CssClass="Input_Control_Small"
                                MaxLength="50"></asp:TextBox>&nbsp;
                            <asp:Label ID="Label37" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                            <asp:TextBox ID="txtFaxNumber" runat="server" Width="100px" CssClass="Input_Control_Small"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="fontsmall"
                                Display="Dynamic" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Required Information<br />"
                                InitialValue="(___) ___-____"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                    ID="Requiredfieldvalidator11" runat="server" CssClass="fontsmall" Display="Dynamic"
                                    ControlToValidate="txtFaxNumber" ErrorMessage="Fax Required Information<br />"
                                    InitialValue="(___) ___-____"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="fontsmall"
                                Display="Dynamic" ControlToValidate="txtFaxNumber" ErrorMessage="Invalid Fax Number<br />"
                                ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\b\d{3}-\d{4}"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="fontsmall"
                                Display="Dynamic" ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Phone Number<br />"
                                ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\b\d{3}-\d{4}"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblAddress1" runat="server" AssociatedControlID="txtAddressLine1"
                                CssClass="fontsmall" ToolTip="Vendor Address Line 1">Address Line 1</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req100" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtAddressLine1" runat="server" CssClass="Input_Control_Small" MaxLength="30"
                                Width="220px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddressLine1"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="Address Line 1 Required Information"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblAddress2" runat="server" AssociatedControlID="txtAddressLine2"
                                CssClass="fontsmall" ToolTip="Vendor Address Line 2">Address Line 2</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label44" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:TextBox
                                ID="txtAddressLine2" runat="server" CssClass="Input_Control_Small" MaxLength="30"
                                Width="220px"></asp:TextBox></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="fontsmall"
                                ToolTip="Vendor City">City</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req200" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtCity" runat="server" CssClass="Input_Control_Small" MaxLength="20" Width="220px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="City Required Information"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblState" runat="server" AssociatedControlID="ddlStates" CssClass="fontsmall"
                                ToolTip="Vendor State">State</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req102" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:DropDownList
                                ID="ddlStates" runat="server" CssClass="Input_Control_Small" Width="225px">
                            </asp:DropDownList><asp:TextBox ID="txtProvince" runat="server" CssClass="input_control_small"
                                Width="220px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator13" runat="server" ControlToValidate="ddlStates"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="State Required Information"
                                InitialValue="x"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblZipCode" runat="server" AssociatedControlID="txtZipCode" CssClass="fontsmall"
                                ToolTip="Vendor Zip Code">Zip Code</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req101" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtZipCode" runat="server" CssClass="Input_Control_Small" MaxLength="10"
                                onblur="reset__(this)" Width="220px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                    runat="server" ControlToValidate="txtZipCode" CssClass="fontsmall" Display="Dynamic"
                                    ErrorMessage="<br />Zip Required Information<br />"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtZipCode"
                                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="<br />Invalid Zipcode" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblWebSite" runat="server" AssociatedControlID="txtWebSite" CssClass="fontsmall"
                                ToolTip="Vendor Web Site">Vendor Web Site</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label45" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:TextBox
                                ID="txtWebSite" runat="server" CssClass="Input_Control_Small" MaxLength="100"
                                Width="220px"></asp:TextBox><asp:RegularExpressionValidator ID="Regularexpressionvalidator2"
                                    runat="server" ControlToValidate="txtWebSite" CssClass="fontsmall" Display="Dynamic"
                                    ErrorMessage="<br />Invalid Web URL (http(s)://www.basusa.com)" ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"
                                    Width="220px"></asp:RegularExpressionValidator></div>
                    </div>
                </div>
                <div id="dvDataRight" class="RightDataSection" runat="server">
                    <div class="LeftDataSection">
                        <div class="FullDataRow">
                            &nbsp;
                        </div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="FullDataRow">
                            &nbsp;
                        </div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="FullDataRow">
                            <asp:CheckBox ID="cbSameAddress" runat="server" AutoPostBack="True" CssClass="fontsmall"
                                ToolTip="Check this box if the vendor address is the same as the location of training"
                                OnCheckedChanged="cbSameAddress_CheckedChanged1" /><asp:Label ID="Label6" runat="server"
                                    CssClass="fontsmall" Font-Bold="True" Font-Underline="True">Location of Training Site </asp:Label><asp:Label
                                        ID="Label52" runat="server" Font-Bold="True" Font-Underline="True"><b><font face="Arial" size="1">(if same as vendor, check box)</font></b></asp:Label>&nbsp;</div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblTrainingCountry" runat="server" CssClass="fontsmall" Text="Country"></asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label7" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:DropDownList
                                ID="ddlTrainingContries" runat="server" AutoPostBack="True" CssClass="Input_Control_Small"
                                OnSelectedIndexChanged="ddlTrainingContries_SelectedIndexChanged" Width="225px">
                            </asp:DropDownList></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblLearningAddress1" runat="server" AssociatedControlID="txtLearningAddress1"
                                CssClass="fontsmall">Address Line 1</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req103" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtLearningAddress1" runat="server" CssClass="Input_Control_Small" MaxLength="30"
                                onblur="reset__(this)" Width="220px"></asp:TextBox><asp:RequiredFieldValidator ID="Requiredfieldvalidator10"
                                    runat="server" ControlToValidate="txtLearningAddress1" CssClass="fontsmall" Display="Dynamic"
                                    ErrorMessage="<br />Address Line 1 Required Information"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblLearningAddress2" runat="server" AssociatedControlID="txtLearningAddress2"
                                CssClass="fontsmall">Address Line 2</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label19" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:TextBox
                                ID="txtLearningAddress2" runat="server" CssClass="Input_Control_Small" MaxLength="30"
                                onblur="reset__(this)" Width="220px"></asp:TextBox></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblLearningCity" runat="server" AssociatedControlID="txtLearningCity"
                                CssClass="fontsmall">City</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="Label17" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtLearningCity" runat="server" CssClass="Input_Control_Small" MaxLength="20"
                                onblur="reset__(this)" Width="220px"></asp:TextBox><asp:RequiredFieldValidator ID="Requiredfieldvalidator9"
                                    runat="server" ControlToValidate="txtLearningCity" CssClass="fontsmall" Display="Dynamic"
                                    ErrorMessage="<br />City Required Information"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblLearningState" runat="server" AssociatedControlID="ddlLearningState"
                                CssClass="fontsmall">State</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req105" runat="server" CssClass="fontsmall" ForeColor="White">| </asp:Label><asp:DropDownList
                                ID="ddlLearningState" runat="server" CssClass="Input_Control_Small" Width="225px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlLearningState"
                                CssClass="fontsmall" Display="Dynamic" ErrorMessage="<br />Sate Required Information<br />"
                                InitialValue="x"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtLearningProvince" runat="server" CssClass="input_control_small"
                                Visible="False" Width="220px"></asp:TextBox></div>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext">
                            <asp:Label ID="lblLearningZipCode" runat="server" AssociatedControlID="txtLearningZipCode"
                                CssClass="fontsmall">Zip Code</asp:Label></div>
                        <div class="LeftDataSectionBox">
                            <asp:Label ID="req106" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label><asp:TextBox
                                ID="txtLearningZipCode" runat="server" CssClass="<br />Input_Control_Small" MaxLength="10"
                                onblur="reset__(this)" Width="220px"></asp:TextBox><asp:RequiredFieldValidator ID="Requiredfieldvalidator2"
                                    runat="server" ControlToValidate="txtLearningZipCode" CssClass="fontsmall" Display="Dynamic"
                                    ErrorMessage="<br />Zip Required Information<br />"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="Regularexpressionvalidator6" runat="server" ControlToValidate="txtLearningZipCode"
                                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="<br />Invalid Zipcode" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator></div>
                    </div>
                </div>
                <div id="BookExpense" class="RightDataSection" runat="server" visible="false">
                    <div class="LeftDataSection">
                        <p align="center">
                            <asp:Label ID="lblExpenseTitle" runat="server" Text="Expenses" CssClass="fontmedium"
                                Font-Bold="True"></asp:Label>
                        </p>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext" style="width: 209px">
                            <asp:Label ID="lblBookCost" runat="server" CssClass="fontsmall" Text="Cost of book and/or study materials"
                                Width="205px" ToolTip="Cost of book and/or study materials."></asp:Label></div>
                        <div class="LeftDataSectionBox" style="width: 175px; float: left">
                            <asp:Label ID="Label9" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                            <telerik:RadNumericTextBox ID="txtBookCost" Runat="server" CssClass="fontsmall" 
                                Culture="en-US" DbValueFactor="1" LabelWidth="48px" MinValue="0" 
                                Type="Currency" Width="120px">
<NumberFormat ZeroPattern="$n"></NumberFormat>
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtBookCost"
                                CssClass="fontsmall" ErrorMessage="<br />Cost of book and/or study materials. Required Information"
                                Width="163px"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="LeftDataSection">
                        <p align="center">
                            <asp:Label ID="lblDeptIDTitle" runat="server" Text="Department ID" CssClass="fontmedium"
                                Font-Bold="True"></asp:Label>
                        </p>
                    </div>
                    <div class="LeftDataSection">
                        <div class="LeftDataSectiontext" style="width: 209px; text-align: right;">
                            <asp:Label ID="lblDeptID" runat="server" CssClass="fontsmall" Text="Department ID#"
                                Width="113px" ToolTip="Label for Department ID#"></asp:Label>
                            &nbsp; &nbsp;</div>
                        <div class="LeftDataSectionBox" style="width: 175px; float: left">
                            <asp:Label ID="Label12" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                            <telerik:RadNumericTextBox ID="txtDeptID" Runat="server" CssClass="fontsmall" 
                                DataType="System.Int16" MaxLength="4" MinValue="0" Width="120px">
<NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDeptID"
                                CssClass="fontsmall" ErrorMessage="Department ID# is required" Width="113px"></asp:RequiredFieldValidator></div>
                    </div>
                </div>
            </div>
            <div id="dvPurposeofTraining" class="GenralRow">
                <div style="width: 90px; float: left">
                    <asp:Label ID="lblPurposeofTraining" runat="server" AssociatedControlID="txtDescribtion"
                        CssClass="fontsmall" ToolTip="Purpose of Training" Width="73px">Purpose of Training</asp:Label>
                    &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="Label42" runat="server" CssClass="fontsmall"
                        ForeColor="Maroon">| </asp:Label>
                </div>
                <div style="width: 505px; float: left">
                    <asp:TextBox ID="txtDescribtion" runat="server" CssClass="Input_Control_Small" Height="70px"
                        MaxLength="4000" onkeyup="RemainingLetters()" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </div>
                <div style="width: 185px; float: right">
                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator7" runat="server" ControlToValidate="txtDescribtion"
                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="Purpose of Training Required Information<br />"></asp:RequiredFieldValidator><asp:Label
                            ID="Label26" runat="server" CssClass="fontsmall">Maximum 4000 Character</asp:Label><asp:Label
                                ID="Label27" runat="server" CssClass="fontsmall">Remaining</asp:Label><asp:TextBox
                                    ID="txtRemaining" runat="server" BorderColor="White" BorderStyle="None" CssClass="fontsmall"
                                    Width="40px">4000</asp:TextBox></div>
            </div>
            <div id="dvWariningOverwrite" class="GenralRow">
                <asp:Label ID="lblColor" runat="server" BackColor="Cyan" BorderColor="Black" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="fontsmall" ForeColor="Cyan" Height="18px" Visible="False">Label</asp:Label>&nbsp;
                <asp:Label ID="lblInfo" runat="server" CssClass="fontsmall" Visible="False">Fields highlighted with cyan color, denote key fields. If any key field is modified, this Application will be reset to Pending Approval</asp:Label></div>
            <div id="divCommandButtons" class="GenralRow">
                <div style="float: left">
                    <asp:Button ID="btnHome" runat="server" CausesValidation="False" CssClass="fontsmall"
                        Text="Home" ToolTip="Rrturn to select application" Width="75px" OnClick="btnHome_Click1" /><asp:Button
                            ID="btnBack" runat="server" CausesValidation="False" CssClass="fontsmall" Text="Back"
                            ToolTip="Back to previous page" Width="75px" OnClick="btnBack_Click1" /><asp:Button
                                ID="btnNext" runat="server" CausesValidation="False" CssClass="fontsmall" Text="Next"
                                ToolTip="GoTo next page" Width="75px" OnClick="btnNext_Click1" />
                </div>
                
                <div style="float: right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" /><asp:Button ID="btnReset"
                        runat="server" CausesValidation="False" CssClass="fontsmall" Text="Reset Current Screen Data"
                        ToolTip="Reset Data" Width="200px" OnClick="btnReset_Click1" /><asp:Label ID="lblScript"
                            runat="server"></asp:Label>
                </div>
                <div id="dvSaving" style="visibility: hidden; float: right">
                    <b><font face="Arial" color="#800000">Saving..</font></b></div>
                <asp:HiddenField ID="doSave" runat="server" />
            </div>
        &nbsp;
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
