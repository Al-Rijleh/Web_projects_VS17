<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AdditionalInformation.aspx.cs"
    Inherits="NewHireWizard.AdditionalInformation" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Additional Information</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ddlunion_member">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlunion_member" />
                        <telerik:AjaxUpdatedControl ControlID="pnlunion_number" />
                        <telerik:AjaxUpdatedControl ControlID="txtunion_number" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlpaid_hourly">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlpaid_hourly" />
                        <telerik:AjaxUpdatedControl ControlID="pnlhourly_rate" />
                        <telerik:AjaxUpdatedControl ControlID="txthourly_rate" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlpartner_in_business">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlpartner_in_business" />
                        <telerik:AjaxUpdatedControl ControlID="pnlown_what_percent" />
                        <telerik:AjaxUpdatedControl ControlID="txtown_what_percent" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlofficer_of_business">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlofficer_of_business" />
                        <telerik:AjaxUpdatedControl ControlID="pnltitle_of_officer" />
                        <telerik:AjaxUpdatedControl ControlID="txttitle_of_officer" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <uc1:TabStrip ID="TabStrip1" runat="server" />
        <div id="dvFullPage" runat="server" class="FullPage">
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="StatusInputRowTitle FontSmall10 Header2">
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
            <div class="Blank10">
                &nbsp;
            </div>
        </div>
        <div id="dvNormal" runat="server" class="FullPage">    
            <div class="StatusInputRowTitle">
                <asp:Label ID="lblTitle1" runat="server" CssClass="InsideTitle">Enter information as requested below. </asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="StatusInputRowTitle">
                <asp:Label ID="LBL_FLD_MessageAdditionalInformation" runat="server" CssClass="FontSmall"></asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>

            <asp:Panel ID="pnlBackGround" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel26" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblBackground" runat="server" Text="Background Check Date"
                        AssociatedControlID="txtBackground" Width="126px"></asp:Label>
                    <asp:Label ID="Label18" runat="server" 
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel27" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtBackground" runat="server" MaxLength="10" 
                        Width="210px">
                    </telerik:RadTextBox></asp:Panel>
                <asp:Panel ID="Panel29" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBackground"
                        Display="Dynamic" ErrorMessage="Required Background Check Date" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtBackground" Display="Dynamic" 
                        ErrorMessage="Incorrect Date" MaximumValue="01/01/2100" 
                        MinimumValue="01/01/2000" Type="Date"></asp:RangeValidator>
                </asp:Panel>
            </asp:Panel>


            <asp:Panel ID="pnlfull_or_part_time" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel2" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblfull_or_part_time" runat="server" Text="Full or Part Time" AssociatedControlID="ddlfull_or_part_time"></asp:Label>
                    <asp:Label ID="Label8" runat="server" ForeColor="White" Text="*" AssociatedControlID="ddlfull_or_part_time"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel3" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlfull_or_part_time" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="F">Full Time</asp:ListItem>
                        <asp:ListItem Value="P">Part Time</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required Full or Part Time"
                        ControlToValidate="ddlfull_or_part_time" Display="Dynamic" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>

            


            <asp:Panel ID="pnlhours_worked_per_week" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel6" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblhours_worked_per_week" runat="server" Text="Hours Worked Per Week"
                        AssociatedControlID="txthours_worked_per_week" Width="126px"></asp:Label>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txthours_worked_per_week"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel7" runat="server" CssClass="InputValue">
                    <telerik:RadNumericTextBox ID="txthours_worked_per_week" runat="server" MaxValue="1000"
                        MinValue="0" Width="210px" CssClass="FontSmall">
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel8" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txthours_worked_per_week"
                        Display="Dynamic" ErrorMessage="Required Hours Worked Per Week" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlis_employee_leased" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel14" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblis_employee_leased" runat="server" Text="Is Employee Leased" AssociatedControlID="ddlis_employee_leased"></asp:Label>
                    <asp:Label ID="Label11" runat="server" ForeColor="White" Text="*" AssociatedControlID="ddlis_employee_leased"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel15" runat="server" CssClass="InputValue">
                    
                    <asp:DropDownList ID="ddlis_employee_leased" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel16" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required Is Employee Leased"
                        ControlToValidate="ddlis_employee_leased" Display="Dynamic" InitialValue="Select"
                        Enabled="False"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlstate_resident" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel18" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblstate_resident" runat="server" Text="State Resident" AssociatedControlID="ddlstate_resident"></asp:Label>
                    <asp:Label ID="Label13" runat="server" ForeColor="White" Text="*" AssociatedControlID="ddlstate_resident"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel19" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlstate_resident" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel20" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required State Resident"
                        ControlToValidate="ddlstate_resident" Display="Dynamic" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlunion_member" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel33" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblunion_member" runat="server" Text="Union Member" AssociatedControlID="ddlunion_member"></asp:Label>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="ddlunion_member" ForeColor="White"
                        Text="*" Visible="False"></asp:Label>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="ddlunion_member" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel34" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlunion_member" runat="server" Width="214px" CssClass="FontSmall"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlunion_member_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel35" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlunion_member"
                        Display="Dynamic" ErrorMessage="Required Union Member" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlunion_number" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel75" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblunion_number" runat="server" Text="Union Number" AssociatedControlID="txtunion_number"></asp:Label>
                    <asp:Label ID="Label31" runat="server" AssociatedControlID="txtunion_number" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel76" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtunion_number" runat="server" MaxLength="5" Width="210px">
                    </telerik:RadTextBox></asp:Panel>
                <asp:Panel ID="Panel77" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtunion_number"
                        Display="Dynamic" ErrorMessage="Required Union Number" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlpaid_commission" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel37" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblpaid_commission" runat="server" Text="Paid Commission" AssociatedControlID="ddlpaid_commission"></asp:Label>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="ddlpaid_commission" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel38" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlpaid_commission" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel39" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlpaid_commission"
                        Display="Dynamic" ErrorMessage="Required Paid Commission" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnleligible_to_participate" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel42" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbleligible_to_participate" runat="server" AssociatedControlID="ddleligible_to_participate"
                        Text="Eligible To Participate"></asp:Label>
                    <asp:Label ID="Label5" runat="server" AssociatedControlID="ddleligible_to_participate"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel43" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddleligible_to_participate" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel44" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddleligible_to_participate"
                        Display="Dynamic" ErrorMessage="Required Eligible To Participate" Enabled="False"
                        InitialValue="Select"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlpaid_salary" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel46" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblpaid_salary" runat="server" AssociatedControlID="ddlpaid_salary"
                        Text="Paid Salary"></asp:Label>
                    <asp:Label ID="Label6" runat="server" AssociatedControlID="ddlpaid_salary" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel47" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlpaid_salary" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel48" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlpaid_salary"
                        Display="Dynamic" ErrorMessage="Required Paid Salary" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
        

        


        <div id="Div1" runat="server" class="FullPage">
            <asp:Panel ID="pnlpaid_hourly" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel5" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblpaid_hourly" runat="server" AssociatedControlID="ddlpaid_hourly"
                        Text="Paid Hourly"></asp:Label>
                    <asp:Label ID="Label10" runat="server" AssociatedControlID="ddlpaid_hourly" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel9" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlpaid_hourly" runat="server" Width="214px" CssClass="FontSmall"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlpaid_hourly_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel13" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlpaid_hourly"
                        Display="Dynamic" ErrorMessage="Required Paid Hourly" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlhourly_rate" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel21" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblhourly_rate" runat="server" AssociatedControlID="txthourly_rate"
                        Text="Hourly Rate"></asp:Label>
                    <asp:Label ID="Label15" runat="server" AssociatedControlID="txthourly_rate" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel22" runat="server" CssClass="InputValue">
                    <telerik:RadNumericTextBox ID="txthourly_rate" runat="server" MaxValue="1000" MinValue="0"
                        Width="210px" Culture="English (United States)" Type="Currency" CssClass="FontSmall">
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel28" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txthourly_rate"
                        Display="Dynamic" ErrorMessage="Required Hourly Rate" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlowner_of_business" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel36" runat="server" CssClass="InputLabel">
                    <asp:Label ID="LBL_FLD_lblowner_of_business" runat="server" AssociatedControlID="ddlowner_of_business"
                        Text="Owner Of Business"></asp:Label>
                    <asp:Label ID="Label17" runat="server" AssociatedControlID="ddlowner_of_business"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel40" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlowner_of_business" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem Value="N">No</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel41" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlowner_of_business"
                        Display="Dynamic" ErrorMessage="Required Owner Of Business" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnldirector_of_business" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel53" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbldirector_of_business" runat="server" AssociatedControlID="ddldirector_of_business"
                        Text="Director Of Business"></asp:Label>
                    <asp:Label ID="Label21" runat="server" AssociatedControlID="ddldirector_of_business"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel54" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddldirector_of_business" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel55" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddldirector_of_business"
                        Display="Dynamic" ErrorMessage="Required Director Of Business" Enabled="False"
                        InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlpartner_in_business" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel57" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblpartner_in_business" runat="server" AssociatedControlID="lblpartner_in_business"
                        Text="Partner In Business"></asp:Label>
                    <asp:Label ID="Label23" runat="server" ForeColor="White" Text="*" AssociatedControlID="lblpartner_in_business"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel58" runat="server" CssClass="InputValue">
                    <asp:Panel ID="Panel59" runat="server" CssClass="InputValue" Style="width: 147px">
                        <asp:DropDownList ID="ddlpartner_in_business" runat="server" Width="214px" CssClass="FontSmall"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlpartner_in_business_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList></asp:Panel>
                </asp:Panel>
                <asp:Panel ID="Panel61" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlpartner_in_business"
                        Display="Dynamic" ErrorMessage="Required Partner in Business" Enabled="False"
                        InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlown_what_percent" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel49" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblown_what_percent" runat="server" AssociatedControlID="txtown_what_percent"
                        Text="Own What Percent"></asp:Label>
                    <asp:Label ID="Label19" runat="server" AssociatedControlID="txtown_what_percent"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel50" runat="server" CssClass="InputValue">
                    <telerik:RadNumericTextBox ID="txtown_what_percent" runat="server" MaxValue="100"
                        MinValue="0" Width="210px" Culture="English (United States)" Type="Percent" CssClass="FontSmall">
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel51" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtown_what_percent"
                        Display="Dynamic" ErrorMessage="Required Own What Percent" Enabled="False"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlofficer_of_business" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel63" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblofficer_of_business" runat="server" AssociatedControlID="ddlofficer_of_business"
                        Text="Officer Of Business"></asp:Label>
                    <asp:Label ID="Label25" runat="server" AssociatedControlID="ddlofficer_of_business"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel64" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlofficer_of_business" runat="server" Width="214px" CssClass="FontSmall"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlofficer_of_business_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel65" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlofficer_of_business"
                        Display="Dynamic" ErrorMessage="Required Officer Of Business" Enabled="False"
                        InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnltitle_of_officer" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel67" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbltitle_of_officer" runat="server" AssociatedControlID="txttitle_of_officer"
                        Text="Title Of Officer"></asp:Label>
                    <asp:Label ID="Label27" runat="server" AssociatedControlID="txttitle_of_officer"
                        ForeColor="White" Text="*" Visible="False"></asp:Label>
                    <asp:Label ID="Label7" runat="server" AssociatedControlID="txttitle_of_officer" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel68" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txttitle_of_officer" runat="server" MaxLength="15" Width="210px"
                        CssClass="FontSmall">
                    </telerik:RadTextBox></asp:Panel>
                <asp:Panel ID="Panel69" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txttitle_of_officer"
                        Display="Dynamic" ErrorMessage="Required Title Of Officer" Enabled="False"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlnon_participating" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel71" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblnon_participating" runat="server" AssociatedControlID="ddllnon_participating"
                        Text="Non Participating"></asp:Label>
                    <asp:Label ID="Label29" runat="server" AssociatedControlID="ddllnon_participating"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel72" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddllnon_participating" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel73" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddllnon_participating"
                        Display="Dynamic" ErrorMessage="Required Non Participating" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnljob_status_code" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel79" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbljob_status_code" runat="server" Text="Job Status Code" AssociatedControlID="txtjob_status_code"></asp:Label>
                    <asp:Label ID="Label33" runat="server" AssociatedControlID="txtjob_status_code" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel80" runat="server" CssClass="InputValue">
                    <telerik:RadNumericTextBox ID="txtjob_status_code" runat="server" MaxValue="99999"
                        MinValue="0" Width="210px" Culture="English (United States)">
                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel81" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtjob_status_code"
                        Display="Dynamic" ErrorMessage="Required Job Status Code" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <div class="ButtonRow" style="">
            </div>
        </div>
        <div id="Div2" runat="server" class="FullPage">
            <asp:Panel ID="pnlfulltime_equivalent" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel56" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblfulltime_equivalent" runat="server" AssociatedControlID="txtfulltime_equivalent"
                        Text="Fulltime Equivalent"></asp:Label>
                    <asp:Label ID="Label37" runat="server" AssociatedControlID="txtfulltime_equivalent"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel62" runat="server" CssClass="InputValue">
                    <telerik:RadNumericTextBox ID="txtfulltime_equivalent" runat="server" MaxValue="99999"
                        MinValue="0" Width="210px" Culture="English (United States)" CssClass="FontSmall">
                        <NumberFormat DecimalDigits="4" GroupSeparator="" />
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel66" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtfulltime_equivalent"
                        Display="Dynamic" ErrorMessage="Required Fulltime Equivalent" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlannual_hours_worked" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel98" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblannual_hours_worked" runat="server" AssociatedControlID="txtannual_hours_worked"
                        Text="Annual Hours Worked"></asp:Label>
                    <asp:Label ID="Label47" runat="server" AssociatedControlID="txtannual_hours_worked"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel99" runat="server" CssClass="InputValue">
                    <telerik:RadNumericTextBox ID="txtannual_hours_worked" runat="server" MaxValue="99999"
                        MinValue="0" Width="210px" Culture="English (United States)" CssClass="FontSmall">
                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                    </telerik:RadNumericTextBox></asp:Panel>
                <asp:Panel ID="Panel100" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtannual_hours_worked"
                        Display="Dynamic" ErrorMessage="Required Annual Hours Worked" Enabled="False"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlworkgroup_code" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel106" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblworkgroup_code" runat="server" AssociatedControlID="txtworkgroup_code"
                        Text="Workgroup Code"></asp:Label>
                    <asp:Label ID="Label51" runat="server" AssociatedControlID="txtworkgroup_code" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel107" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="txtworkgroup_code" runat="server" CssClass="FontSmall" 
                        Width="214px">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="Panel108" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtworkgroup_code"
                        Display="Dynamic" ErrorMessage="Required Workgroup Code" Enabled="False"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnldepartment_code" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel110" runat="server" CssClass="InputLabel">
                    <asp:Label ID="LBL_FLD_lbldepartment_code" runat="server" AssociatedControlID="txtdepartment_code"
                        Text="Department Code"></asp:Label>
                    <asp:Label ID="Label53" runat="server" AssociatedControlID="txtdepartment_code" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel111" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtdepartment_code" runat="server" MaxLength="3" Width="210px"
                        CssClass="FontSmall">
                    </telerik:RadTextBox>
                    <asp:DropDownList ID="ddlSCEP_CEP" runat="server" CssClass="FontSmall" Width="214px"
                        OnSelectedIndexChanged="ddlofficer_of_business_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">N/A</asp:ListItem>
                        <asp:ListItem Value="1">SCEP</asp:ListItem>
                        <asp:ListItem Value="1">CEP</asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="Panel112" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtdepartment_code"
                        Display="Dynamic" ErrorMessage="Required Department Code" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnldivision_code" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel114" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbldivision_code" runat="server" AssociatedControlID="txtdivision_code"
                        Text="Division Code"></asp:Label>
                    <asp:Label ID="Label55" runat="server" AssociatedControlID="txtdivision_code" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel115" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="txtdivision_code" runat="server" CssClass="FontSmall" 
                        Width="214px">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="Panel116" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtdivision_code"
                        Display="Dynamic" ErrorMessage="Required Division Code" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlimport_ssno" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel1" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblimport_ssno" runat="server" AssociatedControlID="txtimport_ssno"
                        Text="Import SSN"></asp:Label>
                    <asp:Label ID="Label12" runat="server" AssociatedControlID="txtimport_ssno" Text="*"
                        ForeColor="White"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel97" runat="server" CssClass="InputValue">
                    <telerik:RadMaskedTextBox ID="txtimport_ssno" runat="server" Mask="###-##-####" Width="210px"
                        CssClass="FontSmall">
                    </telerik:RadMaskedTextBox></asp:Panel>
                <asp:Panel ID="Panel101" runat="server" CssClass="InputValidator">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                        ControlToValidate="txtimport_ssno" Display="Dynamic" ErrorMessage="Incorrect SSN"
                        ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtimport_ssno"
                            Display="Dynamic" ErrorMessage="Required SSN" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnloccupation" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel109" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbloccupation" runat="server" AssociatedControlID="txtoccupation"
                        Text="Occupation"></asp:Label>
                    <asp:Label ID="Label60" runat="server" AssociatedControlID="txtoccupation" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel113" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtoccupation" runat="server" MaxLength="25" Width="210px"
                        CssClass="FontSmall">
                    </telerik:RadTextBox></asp:Panel>
                <asp:Panel ID="Panel117" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtoccupation"
                        Display="Dynamic" ErrorMessage="Required Occupation" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnllocation_code" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel119" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lbllocation_code" runat="server" AssociatedControlID="txtlocation_code"
                        Text="Location Code"></asp:Label>
                    <asp:Label ID="Label62" runat="server" AssociatedControlID="txtlocation_code" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel120" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="txtlocation_code" runat="server" CssClass="FontSmall" 
                        Width="214px">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="Panel121" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtlocation_code"
                        Display="Dynamic" ErrorMessage="Required Location Code" Enabled="False"></asp:RequiredFieldValidator></asp:Panel>
            </asp:Panel>
            
            <asp:Panel id="pnlTransfer" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel11" runat="server" CssClass="InputLabel">
                    <asp:Label ID="LblTransfer" runat="server" AssociatedControlID="ddlTransfer"
                        Text="Transfer From Another Federal Agency"></asp:Label>
                    <asp:Label ID="Label14" runat="server" AssociatedControlID="ddlTransfer"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel12" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlTransfer" runat="server" Width="214px" CssClass="FontSmall" AutoPostBack="True" OnSelectedIndexChanged="ddlTransfer_SelectedIndexChanged">
                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                    </asp:DropDownList></asp:Panel>
                <asp:Panel ID="Panel17" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTransfer"
                        Display="Dynamic" ErrorMessage="Required Transfer from another federal agency" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            
            <asp:Panel id="pnlFEGLI" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel23" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblFEGLI" runat="server" AssociatedControlID="ddlFEGLI"
                        Text="Is FEGLI Elected "></asp:Label>
                    <asp:Label ID="Label16" runat="server" AssociatedControlID="ddlFEGLI"
                        ForeColor="White" Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel24" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlFEGLI" runat="server" Width="214px" CssClass="FontSmall">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                    </asp:Panel>
                <asp:Panel ID="Panel25" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlFEGLI"
                        Display="Dynamic" ErrorMessage="Required FEGLI Status" Enabled="False" InitialValue="Select"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            </div>
            <div class="ButtonRow" style="">
               </div>
        </div>

        <div id="dvAternate" runat="server" class="FullPage">
         <iframe id="iverify" runat="server" frameborder="0" name="Verify Documents" scrolling="auto"
                        title="Verify Documents" style="width: 790px; height: 540px"                                        
                src="/Web_Projects/HR_Information/hr_info.aspx?SkipCheck=YES&EENo=-48915"></iframe>
        </div>



        <div class="Blank10" style="">
            &nbsp;
        </div>
        <div class="InputRow FontSmall" style="float: left">
            <input id="htmbtnHome" runat="server" onclick="window.open('start.aspx?SkipCheck=YES','_self');"
                style="width: 110px" type="button" value="Welcome Page" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="BackButton_Click" CausesValidation="False"
                Width="110px" />
            <asp:Button ID="btnNext" runat="server" Text="Save & Next" Width="110px" OnClick="nextButton_Click" />
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
