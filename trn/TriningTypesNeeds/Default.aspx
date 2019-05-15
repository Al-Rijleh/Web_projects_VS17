<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="TriningTypesNeeds._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="UltimateMenu" Namespace="Karamasoft.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Training Types & Needs</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />

    <script src="/js/dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>


    <script type="text/javascript">
      function DoshowDialog()
       { 
            showDialog();return false;
       }
       
        function showDialog(id)
        {          
            window.radopen("Help.aspx?id="+id, "RadWindow1");
            return false; 
        }
        
        function showDialog2(id)
        {            
            window.radopen("Help.aspx?id="+id, "RadWindow1");
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
            if (retcode == "2")   
            {                                          
                radWindow.argument = 0;
                PostBack();  
            }            
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
                theForm = document.Form1;
             theForm.submit();            
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
		  function callPostBack()
          {
			    ob=document.getElementById("btnCausePostBack");
			    if (ob==null)
			      window.setTimeout("callPostBack()",200);
				ob.click();
          }
          
          function alertWait(elementToWaitFor,msg)
          {            
			    ob=document.getElementById(elementToWaitFor);
			    if (ob==null)
			      window.setTimeout("alertWait(elementToWaitFor,msg)",200);
			    alert(msg);
          }
          
		  function AddValues()
		  {
		    try
		    {
		       document.getElementById('txtCourseHoursTotal').value = 
		       parseFloat(document.getElementById('txtCourseHoursDuty').value)+parseFloat(document.getElementById('CourseHoursNonDuty').value);
		    }
		    catch (err)
		    {
				document.getElementById('txtCourseHoursTotal').value = "Error";
		    }
		  }
		  function popup(url1,height1,width1)
          {				
				tmp=window.open(url1,'','status=0,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
          } 
          
        
	      
		    function CheckListLength(checkBoxListId)
		    {
		        objCtrl = document.getElementById(checkBoxListId);
				
				for (i=0; i<100;i++)	
				{
					objItem = document.getElementById(checkBoxListId + '_' + i);
					if(objItem == null)
					{
						return (i);
					}
				}
		    }
			function test(checkBoxListId)
			{
				objCtrl = document.getElementById(checkBoxListId);
				document.getElementById('txtSelectedDevelopments').value='';
				counter = CheckListLength(checkBoxListId);
				for (i=0; i<counter;i++)	
				{
					objItem = document.getElementById(checkBoxListId + '_' + i);
					if(objItem == null)
					{
						continue;
					}

					if (objItem.checked==true)
						document.getElementById('txtSelectedDevelopments').value='abc' ; 
				}			 
					
			}
			function GoButtom()
			{
			    document.location.href = '#buttom';
			}
    </script>

    <script type="text/javascript">
        //<![CDATA[
        function HideTooltip()
        {             
           var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
           if (tooltip) tooltip.hide();
        }
        
        function ShowTooltip()
        {
            window.setTimeout(function()
            {                        
                var tooltip = $find("RadToolTip1");                  
                //API: show the tooltip
                tooltip.show();                                                 
            }, 10);
        }
        
        function CheckIfShow(sender, args)
        {
            var summaryElem = document.getElementById("ValidationSummary1");
             
            //check if summary is visible
            if (summaryElem.style.display == "none")
            {
                //API: if there are no errors, do not show the tooltip
                args.set_cancel(true);
            }
        }
        
        function BuildAddress()
        {            
            var street = (document.getElementById("txtStreet")).value;
            var streetNumber = (document.getElementById("txtStreenNum")).value;
            var city = (document.getElementById("txtCity")).value;
            var country = (document.getElementById("txtCountry")).value;
            var address = streetNumber + " " + street + ", " + city + ", " + country;
            (document.getElementById("txtAddress")).value = address;            
            
            var tooltip = $find("RadToolTip2");
            //API: hide the tooltip
            tooltip.hide();
        }
        
        function InsertLanguages()
        {        
            var tooltip = $find("RadToolTip3");
            //API: get the html element, holding the content of the tooltip
            var contentElement = tooltip.get_contentElement();
            
            var checkboxes = contentElement.getElementsByTagName("INPUT");
            var list = document.getElementById("lbSelectedLanguages");
            //empty the listBox of selected languages
            list.options.length = 0;
            
            for(var index=0; index < checkboxes.length; index++)
            {
                var checkbox = checkboxes[index];
                if (checkbox.checked)
                {
                    var content = checkbox.nextSibling.innerHTML;
                    var option = new Option(content, content);
                    //if the checkbox is checked, create and add a new option to the listBox of selected languages
                    list.options[list.options.length] = option;
                }              
            }            
            //API: hide the tooltip
            tooltip.hide();
        }
        //]]>
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="Table" style="z-index: 101; left: 0px; position: absolute; top: 0px" height="98%"
        cellspacing="0" cellpadding="0" width="795" border="0">
        <tr>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
            <td background="/karama/Images/WinSubTab.gif">
                <cc1:UltimateMenu ID="UltimateMenu1" runat="server">
                </cc1:UltimateMenu>
                <asp:Label ID="lblWizardError" runat="server" ForeColor="Maroon" CssClass="fontsmall"
                    Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></td>
        </tr>
        <tr valign="top" height="98%">
            <td valign="top">
            </td>
            <td valign="top">
                <form id="Form1" method="post" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                   <telerik:RadWindowManager ID="Singleton" runat="server" Skin="Vista" EnableEmbeddedScripts="true">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" NavigateUrl="Help.aspx"
                    OpenerElementID="Label1" Skin="Vista" Left="5px" Top="1px" OnClientClose="OnClientclose"
                    ReloadOnShow="True" Style="display: none;" Behavior="Default" InitialBehavior="None"
                    Modal="True" VisibleStatusbar="False" Width="730px" Height="375px" ShowContentDuringLoad="False">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
                    <table class="fontsmall" id="Table1" height="100%" cellspacing="0" cellpadding="0"
                        width="100%" border="0">
                        <tr>
                            <td style="border-bottom: silver thin solid" valign="top">
                                <table class="fontsmall" id="Table2" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr>
                                        <td width="220">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True"> Training Requested</asp:Label></td>
                                        <td width="570">
                                            <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True"></asp:Label><input
                                                id="doSave" type="hidden" name="doSave" runat="server"></td>
                                    </tr>
                                    <tr>
                                        <td width="220">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True">Remaining Budget For: </asp:Label><asp:DropDownList
                                                ID="ddlBudgetYear" runat="server" CssClass="fontsmall" AutoPostBack="True" Width="60px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:Label>
                                            <asp:HiddenField ID="hidCommand" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="220">
                                            &nbsp;</td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblMandatoryOnly" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                    CssClass="fontsmall"></asp:ValidationSummary>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Panel ID="pnlData" runat="server">
                                    <table class="fontsmall" id="Table3" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td colspan="4" height="1%">
                                                <asp:Label ID="lbl_fldTrainingTypeNeeds" runat="server" CssClass="fontsmall">Instruction</asp:Label>
                                                &nbsp;&nbsp; &nbsp;
                                                <asp:Label ID="lblScript" runat="server" CssClass="fontsmall"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 1%">
                                                <asp:Label ID="lblRequiredSymbol" runat="server" CssClass="fontsmall">The <font color="#800000">
															|</font> symbol before a data entry field indicates required data.</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px; height: 1%;">
                                                <asp:Label ID="lblDepartmentID" runat="server" CssClass="fontsmall" ToolTip="Label for Department ID#"
                                                    AssociatedControlID="txtDepartmentID">Department ID#</asp:Label></td>
                                            <td style="width: 30px; height: 1%;">
                                                <asp:LinkButton ID="lnkHelpDepartmentID" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ToolTip="Click For Department ID Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px; height: 1%;">
                                                <asp:Label ID="Label25" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtDepartmentID" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" MaxLength="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                    ErrorMessage="Department ID# is required" ControlToValidate="txtDepartmentID"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px; width: 150px;">
                                                <asp:Label ID="lblPositionLevel" runat="server" CssClass="fontsmall" ToolTip="Label For Position Level"
                                                    AssociatedControlID="ddlPositionLevel">Position Level</asp:Label></td>
                                            <td style="height: 20px; width: 30px;">
                                                <asp:LinkButton ID="lnkPositionLevelHelp" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ToolTip="Click For Postion Level Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label9" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlPositionLevel" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="Position Level is Required" ControlToValidate="ddlPositionLevel"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblNeedSpecialAccomodation" runat="server" CssClass="fontsmall" ToolTip="Label For Need Special Accomodation"
                                                    AssociatedControlID="txtAccomodationDescription">Need Special Accomodation</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkHelpSpecialAccmedation" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ToolTip="Click For Need Speicial Accomedation Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label27" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlAccomodation" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlAccomodation_SelectedIndexChanged2">
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblAccomodationDescription" runat="server" CssClass="fontsmall" Visible="False"
                                                    ToolTip="Label For Accomodation Description" AssociatedControlID="txtAccomodationDescription">Accomodation Description</asp:Label></td>
                                            <td style="width: 30px">
                                            </td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="req1" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtAccomodationDescription" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px" MaxLength="100" Visible="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="fontsmall"
                                                    Display="Dynamic" ErrorMessage="Accomodation Description is Required" ControlToValidate="txtAccomodationDescription"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblTypeofAppointmant" runat="server" CssClass="fontsmall" ToolTip="Type of Appointment"
                                                    AssociatedControlID="ddlTypeofAppointment">Type of Appointment</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkTypeOfAppointmentHelp" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ToolTip="Click for Type of Appointment Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label10" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlTypeofAppointment" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" Display="Dynamic"
                                                    ErrorMessage="Type of Appointment is Required" ControlToValidate="ddlTypeofAppointment"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblTrainingPurpose" runat="server" CssClass="fontsmall" ToolTip="Training Purpose Type"
                                                    AssociatedControlID="ddlPurposeOfTraining">Training Purpose Type</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnTrainingPurposeTypeHelp" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ToolTip="Click for Training Purpose Type Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label18" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlPurposeOfTraining" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                    ErrorMessage="Purpose of Training is Required" ControlToValidate="ddlPurposeOfTraining"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblDeliveryTypeCode" runat="server" CssClass="fontsmall" ToolTip="Delivery Type Code"
                                                    AssociatedControlID="ddlDelivaryTypeCode">Delivery Type Code</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnDeliveryTypeCodeHelp" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ToolTip="Click for Delivery Type Code Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label19" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlDelivaryTypeCode" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator9" runat="server" Display="Dynamic"
                                                    ErrorMessage="Delivery Type Code is Required" ControlToValidate="ddlDelivaryTypeCode"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblDesignationTypeCode" runat="server" CssClass="fontsmall" ToolTip="Designation Type Code"
                                                    AssociatedControlID="ddlDesignationTypeCode">Designation Type Code</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnDesigbationCodeHelp" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ValidationGroup="Click For Designation Type Code Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label20" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlDesignationTypeCode" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlDesignationTypeCode_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator11" runat="server" Display="Dynamic"
                                                    ErrorMessage="Designation Type Code is Required" ControlToValidate="ddlDesignationTypeCode"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblDesinationOther" runat="server" CssClass="fontsmall" Visible="False"
                                                    ToolTip="Training Designation Type Other" AssociatedControlID="txtDesignationOther">Designation Other</asp:Label></td>
                                            <td style="width: 30px">
                                            </td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="req2" runat="server" CssClass="fontsmall" ForeColor="Maroon" Visible="False">| </asp:Label>
                                                <asp:TextBox ID="txtDesignationOther" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" MaxLength="100" Visible="False" ToolTip="Text Explaining the Designation"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator7" runat="server" CssClass="fontsmall"
                                                    Display="Dynamic" ErrorMessage="Designation Other is Required" ControlToValidate="txtDesignationOther"
                                                    Visible="False"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblTrainingCreditValue" runat="server" AssociatedControlID="txtTrainingCredit"
                                                    CssClass="fontsmall" ToolTip="Training Designation Type Code">Training Credit Value</asp:Label>
                                            </td>
                                            <%-- <td>
                                                <asp:Label ID="req100" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                            </td>--%>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkHelpTrainingCode" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Training Credit Help">?</asp:LinkButton></td>
                                            <td>
                                                <asp:Label ID="req100" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtTrainingCredit" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" MaxLength="5" ToolTip="Text Explaining the Designation"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator18" runat="server" CssClass="fontsmall"
                                                    Display="Dynamic" ErrorMessage="Training Credit is Required" ControlToValidate="txtTrainingCredit"></asp:RequiredFieldValidator><asp:RangeValidator
                                                        ID="RangeValidator1" runat="server" CssClass="fontsmall" Display="Dynamic" ErrorMessage="Training Credit Must be a Positive Number"
                                                        ControlToValidate="txtTrainingCredit" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px; height: 60px;">
                                                <asp:Label ID="lblCreditTypeCode" runat="server" CssClass="fontsmall" ToolTip="Training Credit Type Code"
                                                    AssociatedControlID="ddlCreditTypeCode">Credit Type Code</asp:Label></td>
                                            <td style="width: 30px; height: 60px;">
                                                <asp:LinkButton ID="lmbtnCreditTypeCodeHelp" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Credit Type Code Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px; height: 60px;">
                                                <asp:Label ID="req3" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlCreditTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlCreditTypeCode_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator12" runat="server" Display="Dynamic"
                                                    ErrorMessage="Credit Type Code is Required" ControlToValidate="ddlCreditTypeCode"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblCreditTypeOther" runat="server" CssClass="fontsmall" Visible="False"
                                                    ToolTip="Training Code Type Other" AssociatedControlID="txtCreditTypeOther">Credit Type Other</asp:Label></td>
                                            <td style="width: 30px">
                                            </td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="req4" runat="server" CssClass="fontsmall" ForeColor="Maroon" Visible="False">| </asp:Label>
                                                <asp:TextBox ID="txtCreditTypeOther" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" MaxLength="100" Visible="False" ToolTip="Text Explaining the Designation"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator8" runat="server" CssClass="fontsmall"
                                                    Display="Dynamic" ErrorMessage="Credit Type Other is Required" ControlToValidate="txtCreditTypeOther"
                                                    Visible="False"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 29px; width: 150px;">
                                                <asp:Label ID="lblAccreditationIndicator" runat="server" CssClass="fontsmall" ToolTip="Is the Course Accredited "
                                                    AssociatedControlID="ddlAccredetionIndicator">Accreditation Indicator</asp:Label></td>
                                            <td style="height: 29px; width: 30px;">
                                                <asp:LinkButton ID="lnkbrnAccrediationIndicator" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ValidationGroup="Click ForAccreditation Indicator Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label22" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlAccredetionIndicator" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator13" runat="server" Display="Dynamic"
                                                    ErrorMessage="Accreditation Indicator is Required" ControlToValidate="ddlAccredetionIndicator"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblSourceOfTraining" runat="server" CssClass="fontsmall" AssociatedControlID="ddlSourseTraining">Source of Training</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnSourceofTraining" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Source of Training Help">?</asp:LinkButton></td>
                                            <td colspan="2" height="1%" style="width: 640px">
                                                <asp:Label ID="Label23" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:DropDownList ID="ddlSourseTraining" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                    ErrorMessage="Source of Training is Required" ControlToValidate="ddlSourseTraining"
                                                    InitialValue="xx"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblEducationLevel" runat="server" CssClass="fontsmall" ToolTip="Education Level"
                                                    AssociatedControlID="txtEducationLevel">Education Level</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnEducationLevel" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Education Level Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label36" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtEducationLevel" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" ReadOnly="True"></asp:TextBox>
                                                <asp:Button ID="btnSelectEducationLevel" runat="server" CssClass="fontsmall" Width="50px"
                                                    ToolTip="Select Education Level" Text="Select" CausesValidation="False" OnClick="btnSelectEducationLevel_Click">
                                                </asp:Button>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator16" runat="server" Display="Dynamic"
                                                    ErrorMessage="Edutation Level is Required" ControlToValidate="txtEducationLevel"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblTrainingSubTypeCode" runat="server" CssClass="fontsmall" ToolTip="Training Sub-Type Code"
                                                    AssociatedControlID="txtTrainingSubTypeCode">Training Sub-Type Code</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbrnTrainingSubTypeCode" runat="server" Font-Names="Arial"
                                                    Font-Size="Large" ValidationGroup="Click ForTraining Sub-Type Code Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label31" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtTrainingSubTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" ReadOnly="True"></asp:TextBox>
                                                <asp:Button ID="btnTrainingTypeCode" runat="server" CssClass="fontsmall" Width="50px"
                                                    ToolTip="Select Training Sub-Type Code" Text="Select" CausesValidation="False"
                                                    OnClick="btnTrainingTypeCode_Click"></asp:Button>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator15" runat="server" Display="Dynamic"
                                                    ErrorMessage="Training Sub-Type Code is Required" ControlToValidate="txtTrainingSubTypeCode"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblTrainingTypeCode" runat="server" CssClass="fontsmall" ToolTip="Training Type Code"
                                                    AssociatedControlID="txtTrainingTypeCode">Training Type Code</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnTrainingTypeCode" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Training Type Code Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label32" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtTrainingTypeCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" ReadOnly="True"></asp:TextBox>
                                                <asp:Button ID="btnTrainingTypeCode2" runat="server" CssClass="fontsmall" Width="50px"
                                                    ToolTip="Select Training Type Code" Text="Select" CausesValidation="False" OnClick="btnTrainingTypeCode2_Click">
                                                </asp:Button>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator14" runat="server" Display="Dynamic"
                                                    ErrorMessage="Training Type Code is Required" ControlToValidate="txtTrainingTypeCode"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblTypeOfDevelopment" runat="server" CssClass="fontsmall" ToolTip="Type of Development"
                                                    AssociatedControlID="txtTypeOfDevelopmentSummary">Type of Development</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnTypeofDevelopment" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Type of Development Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label39" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtTypeOfDevelopmentSummary" onblur="reset__(this)" runat="server"
                                                    CssClass="Input_Control_Small" Width="300px" ReadOnly="True"></asp:TextBox>
                                                <asp:Button ID="btnTypeOfDevelopment" runat="server" CssClass="fontsmall" Width="50px"
                                                    ToolTip="Select Type of Development" Text="Select" CausesValidation="False" OnClick="btnTypeOfDevelopment_Click1">
                                                </asp:Button>
                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator17" runat="server" Display="Dynamic"
                                                    ErrorMessage="Type of Development is Required" ControlToValidate="txtTypeOfDevelopmentSummary"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="lblProgramCode" runat="server" CssClass="fontsmall" ToolTip="Program Code">Program Code</asp:Label></td>
                                            <td style="width: 30px">
                                                <asp:LinkButton ID="lnkbtnProgramCodeHelp" runat="server" Font-Names="Arial" Font-Size="Large"
                                                    ValidationGroup="Click For Program Code Help">?</asp:LinkButton></td>
                                            <td colspan="2" style="width: 640px">
                                                <asp:Label ID="Label26" runat="server" CssClass="fontsmall" ForeColor="Maroon">| </asp:Label>
                                                <asp:TextBox ID="txtProgramCode" onblur="reset__(this)" runat="server" CssClass="Input_Control_Small"
                                                    Width="300px" ReadOnly="True">67200</asp:TextBox>
                                                <asp:Button ID="btnSelect" runat="server" CssClass="fontsmall" Width="50px" ToolTip="Select Program Code"
                                                    Text="Select" CausesValidation="False" Visible="False" OnClick="btnSelect_Click1">
                                                </asp:Button>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                                                    ErrorMessage="Program Code is Required" ControlToValidate="txtProgramCode" Visible="False"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" height="1%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4" height="1%">
                                            </td>
                                        </tr>
                                    </table>
                                    <a name="buttom"></a>
                                    <table class="fontsmall" id="Table7" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td valign="top" width="300">
                                                <asp:Button ID="btnHome" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Rrturn to select application"
                                                    Text="Home" CausesValidation="False" OnClick="btnHome_Click1"></asp:Button>
                                                <asp:Button ID="btnBack" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Back to previous page"
                                                    Text="Back" CausesValidation="False" OnClick="btnBack_Click1"></asp:Button>
                                                <asp:Button ID="btnNext" runat="server" CssClass="fontsmall" Width="75px" ToolTip="GoTo next page"
                                                    Text="Next" CausesValidation="False" OnClick="btnNext_Click1"></asp:Button></td>
                                            <td valign="top">
                                                <div id="dvSaving" style="visibility: hidden; float: right">
                                                <b><font face="Arial" color="#800000">Saving..</font></b></div>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" />
                                                <asp:Button ID="btnReset" runat="server" CssClass="fontsmall" Width="200px" ToolTip="Reset Data"
                                                    Text="Reset Current Screen Data" CausesValidation="False" OnClick="btnReset_Click1">
                                                </asp:Button></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTrainingTypeCode" runat="server" Visible="False">
                                    <table class="fontsmall" id="Table6" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label33" runat="server" Font-Bold="True" CssClass="fontsmall">Training Type Code/Training Sub-Type Code</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="right">
                                                <asp:Button ID="btnCloseTrainingType1" runat="server" CssClass="fontsmall" Width="75px"
                                                    ToolTip="Close Training Type Code/Training Sub-Type Code" Text="Close" OnClick="btnCloseTrainingType1_Click">
                                                </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DataGrid ID="dgTrainingTypeCode" runat="server" CssClass="fontsmall" Visible="False"
                                                    AutoGenerateColumns="False" OnItemCreated="dgTrainingTypeCode_ItemCreated1">
                                                    <AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
                                                    <ItemStyle BackColor="White"></ItemStyle>
                                                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="Training Code"></asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="sub_code_long_description" HeaderText="Training Description">
                                                        </asp:BoundColumn>
                                                    </Columns>
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px" align="right">
                                                <asp:Button ID="btnCloseTrainingType2" runat="server" CssClass="fontsmall" Width="75px"
                                                    ToolTip="Close Training Type Code/Training Sub-Type Code" Text="Close" OnClick="btnCloseTrainingType1_Click">
                                                </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEducationLevel" runat="server" Visible="False">
                                    <table class="fontsmall" id="Table8" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label34" runat="server" Font-Bold="True" CssClass="fontsmall">Education Level</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px" align="right">
                                                <asp:Button ID="btnEducationLevelClose1" runat="server" CssClass="fontsmall" Width="75px"
                                                    ToolTip="Close Education Level" Text="Close" OnClick="btnEducationLevelClose1_Click1">
                                                </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DataGrid ID="dgEducationLevel" runat="server" CssClass="fontsmall" Visible="False"
                                                    AutoGenerateColumns="False" OnItemCreated="dgEducationLevel_ItemCreated1">
                                                    <AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
                                                    <ItemStyle BackColor="White"></ItemStyle>
                                                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050"></HeaderStyle>
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="Education Level"></asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="long_description" HeaderText="Description"></asp:BoundColumn>
                                                    </Columns>
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px" align="right">
                                                <asp:Button ID="btnEducationLevelClose2" runat="server" CssClass="fontsmall" Width="75px"
                                                    ToolTip="Close Education Level" Text="Close" OnClick="btnEducationLevelClose1_Click1">
                                                </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlProgramCode" runat="server" Visible="False">
                                    <table class="fontsmall" id="Table4" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label29" runat="server" Font-Bold="True" CssClass="fontsmall">Program Codes</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                <asp:Button ID="btnClose1" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Program Code Page"
                                                    Text="Close" OnClick="btnClose1_Click1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="optProgramCode" runat="server" CssClass="fontsmall" AutoPostBack="True"
                                                    RepeatColumns="3">
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px" align="right">
                                                <asp:Button ID="bntnClose2" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Program Code Page"
                                                    Text="Close" OnClick="bntnClose2_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDevelopmentType" runat="server" Visible="False" ToolTip="Close Type of Development">
                                    <table class="fontsmall" id="Table5" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td align="center" style="height: 15px">
                                                <asp:Label ID="Label17" runat="server" Font-Bold="True" CssClass="fontsmall">Type of Development</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px" align="right">
                                                <asp:Button ID="btnDevClose0" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Close Type of Development"
                                                    Text="Close" OnClick="btnDevClose0_Click2"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 22px">
                                                <asp:Label ID="lblTypeofDevelopmentInstruction" runat="server" CssClass="fontsmall"
                                                    Font-Bold="True" Font-Italic="True">Select one item that is most related to this type of training.</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px" align="left">
                                                <asp:Label ID="lblTypeOfDevelopmentInstuction" runat="server" CssClass="fontsmall">Click on the Close Button to accept changes.</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="Table9" cellspacing="0" cellpadding="0" width="790" border="0">
                                                    <tr>
                                                        <td width="125">
                                                            <asp:Label ID="Label37" runat="server" CssClass="fontsmall">Type of Development</asp:Label></td>
                                                        <td width="670">
                                                            <asp:CheckBoxList ID="chklstTypeofDev" runat="server" CssClass="Input_Control_Small"
                                                                RepeatColumns="4" BorderWidth="1px" BorderStyle="Solid" BorderColor="DimGray">
                                                            </asp:CheckBoxList>
                                                            <asp:RadioButtonList ID="optlstTypeofDev" runat="server" BorderColor="DarkGray" BorderStyle="Solid"
                                                                BorderWidth="1px" CssClass="Input_Control_Small" RepeatColumns="4">
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="150">
                                                            <asp:Label ID="Label38" runat="server" CssClass="fontsmall">Type of Development (other)</asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtTypeofDevelopmentOthers" onblur="reset__(this)" runat="server"
                                                                CssClass="Input_Control_Small" Width="300px" MaxLength="100"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOtherTextError" runat="server" CssClass="fontsmall" ForeColor="Red"> Type of Development (Other) is  Required</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnResetChanges" runat="server" ToolTip="Reset Type of Development Selection"
                                                                Text="Reset Type of Development Selection" OnClick="btnResetChanges_Click1"></asp:Button></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px" align="right">
                                                <asp:Button ID="btnDevClose" runat="server" CssClass="fontsmall" Width="75px" ToolTip="Reset Type of Type of Development"
                                                    Text="Close" OnClick="btnDevClose0_Click2"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </form>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

</body>
</html>
