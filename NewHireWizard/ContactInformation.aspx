<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ContactInformation.aspx.cs"
    Inherits="NewHireWizard.ContactInformation" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Information</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function No_EE() {
            alert('Could not find the new hire employee.please, try again.');
            window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        }
        function validateDomain(oSrc, args) {
//            alert('here');
            var domain_ = document.getElementById('hidDomain').value;
//            alert('domain ' + domain_);
            if (domain_ == '') {
                args.IsValid = true;
                return;
            }
            var email_ = document.getElementById('txtEmailWork').value;
//            alert(email_);
            var index_ = email_.toString().indexOf('@')+1;
//            alert(index_);
            var email_domain_ = email_.toString().substring(index_);
//            alert(email_domain_);
            if (email_domain_.toUpperCase() == domain_.toString())
                args.IsValid = true;
            else
                args.IsValid = false; 
//            args.IsValid = (args.Value.length >= 8);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6"
            Skin="Sunset" />
        <asp:HiddenField ID="hidDomain" runat="server" />
        <asp:HiddenField ID="hidErrorMsg" runat="server" />
        <div id="Div1" class="FullPage">
        <uc1:TabStrip ID="TabStrip1" runat="server" />
        <div class="Blank20">
            &nbsp;
        </div>
        <div class="StatusInputRowTitle FontSmall10 Header2">
            <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
        <div class="Blank10">
        &nbsp;
        </div>
        <div class="StatusInputRowTitle">
            &nbsp;<asp:Label ID="lblTitle3" runat="server" CssClass="InsideTitle">Enter information as requested below:</asp:Label>
        </div>
        <div class="Blank10">
            &nbsp;
        </div>
        </div>
        <div id="dvFullPage" runat="server" class="FullPage">
            <%--Home Address--%>
            
            <asp:Panel ID="pnlCountry" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel22" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblCountry" runat="server" Text="Country" AssociatedControlID="ddlCountry"></asp:Label>
                    <asp:Label ID="Label12" runat="server" ForeColor="White" Text="*" AssociatedControlID="ddlCountry"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel28" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="FontSmall" Width="210px" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="Panel32" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Required Address Line 1"
                        ControlToValidate="txtAddressLine1" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            
            <asp:Panel ID="pnlAddress1" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel2" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1" AssociatedControlID="txtAddressLine1"></asp:Label>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtAddressLine1"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel3" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtAddressLine1" runat="server" MaxLength="30" Width="210px"
                        CssClass="FontSmall">
                    </telerik:RadTextBox>
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required Address Line 1"
                        ControlToValidate="txtAddressLine1" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="PnlAddress2" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel6" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2" AssociatedControlID="txtAddressLine2"></asp:Label>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtAddressLine2" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel7" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtAddressLine2" runat="server" MaxLength="30" Width="210px"
                        CssClass="FontSmall">
                    </telerik:RadTextBox>
                </asp:Panel>
                <asp:Panel ID="Panel8" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddressLine2"
                        Display="Dynamic" ErrorMessage="Required Address Line 2" Enabled="False"></asp:RequiredFieldValidator>&nbsp;</asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlCity" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel10" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="txtCity"></asp:Label>
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtCity"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel11" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtCity" runat="server" MaxLength="20" Width="210px" CssClass="FontSmall">
                    </telerik:RadTextBox>
                </asp:Panel>
                <asp:Panel ID="Panel12" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required City"
                        ControlToValidate="txtCity" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlState" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel14" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="ddlState"></asp:Label>
                    <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*" AssociatedControlID="ddlState"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel15" runat="server" CssClass="InputValue">
                    <asp:DropDownList ID="ddlState" runat="server" Width="215px" CssClass="FontSmall"
                        ValidationGroup="grp3">                        
                    </asp:DropDownList></asp:Panel>
                    <telerik:RadTextBox ID="txtprovince" runat="server" MaxLength="20" Width="210px" CssClass="FontSmall">
                    </telerik:RadTextBox>
                    
                <asp:Panel ID="Panel16" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required State"
                        ControlToValidate="ddlState" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlZipCode" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel18" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" AssociatedControlID="txtZipCode"></asp:Label>
                    <asp:Label ID="Label13" runat="server" ForeColor="Red" Text="*" AssociatedControlID="txtZipCode"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel19" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtZipCode" runat="server" MaxLength="10" Width="210px" CssClass="FontSmall" EmptyMessage="_____-____" SelectionOnFocus="CaretToBeginning">
                    </telerik:RadTextBox>
                </asp:Panel>
                <asp:Panel ID="Panel20" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required Zip Code"
                        ControlToValidate="txtZipCode" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtZipCode"
                        Display="Dynamic" ErrorMessage="Incorrect Zip Code" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator></asp:Panel>
            </asp:Panel>
            <%--Phone Numbers--%>
            <asp:Panel ID="Panel21" runat="server" CssClass="Blank10">
                &nbsp;
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" CssClass="InputRow FontSmall">
                <asp:Label ID="LBL_FLD_Message" runat="server" CssClass="FonSmall"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" CssClass="Blank10">
                &nbsp;
            </asp:Panel>
            <asp:Panel ID="pnlWorkPhone" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel23" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblWorkPhone" runat="server" Text="Work Phone / Ext" AssociatedControlID="txtWorkPhone"></asp:Label>
                    <asp:Label ID="Label14" runat="server" ForeColor="Red" Text="*" 
                        AssociatedControlID="txtWorkPhone"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel24" runat="server" CssClass="InputValue">
                    <asp:Panel ID="Panel25" runat="server" CssClass="InputValue" Style="width: 147px">
                        <telerik:RadMaskedTextBox ID="txtWorkPhone" runat="server" Mask="(###) ###-####"
                            Width="140px" ValidationGroup="grp3" CssClass="FontSmall">
                        </telerik:RadMaskedTextBox>
                       
                        <telerik:RadTextBox ID="txtforeign_phone_number" runat="server" MaxLength="30" Width="210px" >
                        </telerik:RadTextBox>  
                        
                        
                    </asp:Panel>
                    <asp:Panel ID="Panel26" runat="server" CssClass="InputValue" Style="width: 66px">
                        <telerik:RadMaskedTextBox ID="txtExtension" runat="server" Mask="##########"
                            Width="66px" PromptChar=" " SelectionOnFocus="CaretToBeginning"
                            CssClass="FontSmall">
                        </telerik:RadMaskedTextBox></asp:Panel>
                </asp:Panel>
                <asp:Panel ID="Panel27" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Required Work Phone"
                        ControlToValidate="txtWorkPhone" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtWorkPhone"
                        Display="Dynamic" ErrorMessage="Incorrect Work Phone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlHomePhone" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel29" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone" AssociatedControlID="txtHomePhone"></asp:Label>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtHomePhone" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel30" runat="server" CssClass="InputValue">
                    <telerik:RadMaskedTextBox ID="txtHomePhone" runat="server" Mask="(###) ###-####"
                        Width="210px" ValidationGroup="grp3" CssClass="FontSmall">
                    </telerik:RadMaskedTextBox></asp:Panel>
                <asp:Panel ID="Panel31" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHomePhone"
                        Display="Dynamic" Enabled="False" ErrorMessage="Required Home Phone"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtHomePhone"
                            Display="Dynamic" ErrorMessage="Incorrect Home Phone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlMobilePhone" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel33" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblMobilePhone" runat="server" Text="Mobile Phone" AssociatedControlID="txtMobilePhone"></asp:Label>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtMobilePhone" ForeColor="White"
                        Text="*" Visible="False"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel34" runat="server" CssClass="InputValue">
                    <telerik:RadMaskedTextBox ID="txtMobilePhone" runat="server" Mask="(###) ###-####"
                        Width="210px" ValidationGroup="grp3" CssClass="FontSmall">
                    </telerik:RadMaskedTextBox></asp:Panel>
                <asp:Panel ID="Panel35" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobilePhone"
                        Display="Dynamic" ErrorMessage="Required Mobile Phone" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMobilePhone"
                        Display="Dynamic" ErrorMessage="Incorrect Mobile Phone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlFaxNumber" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel37" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblFaxNumber" runat="server" Text="Fax Number" AssociatedControlID="txtFaxNumber"></asp:Label>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtFaxNumber" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel38" runat="server" CssClass="InputValue">
                    <telerik:RadMaskedTextBox ID="txtFaxNumber" runat="server" Mask="(###) ###-####"
                        Width="210px" ValidationGroup="grp3" CssClass="FontSmall">
                    </telerik:RadMaskedTextBox></asp:Panel>
                <asp:Panel ID="Panel39" runat="server" CssClass="InputValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFaxNumber"
                        Display="Dynamic" ErrorMessage="Required Fax Number" Enabled="False"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFaxNumber"
                            Display="Dynamic" ErrorMessage="Incorrect Fax Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator></asp:Panel>
            </asp:Panel>
            <%--Email Addresses--%>
            
            <asp:Panel ID="Panel40" runat="server" CssClass="Blank20">
                &nbsp;
            </asp:Panel>
            <asp:Panel ID="Panel9" runat="server" CssClass="InputRow FontSmall">
                <asp:Label ID="Label7" runat="server" >For security purposes, the email address(es) you enter below will be pended until the employee confirms the accuracy of the email address(es) you entered.</asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel13" runat="server" CssClass="Blank10">
                &nbsp;
            </asp:Panel>
            <asp:Panel ID="pnlWorkEmail" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel42" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblEmailWork" runat="server" Text="Work Email" AssociatedControlID="txtEmailWork"></asp:Label>
                    <asp:Label ID="Label5" runat="server" AssociatedControlID="txtEmailWork" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel43" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtEmailWork" runat="server" MaxLength="100" Width="210px"
                        CssClass="FontSmall" ValidationGroup="grp3">
                    </telerik:RadTextBox></asp:Panel>
                <asp:Panel ID="Panel44" runat="server" CssClass="InputValidator">
                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="txtEmailWork" Display="Dynamic" ErrorMessage="Incorrect Work Email Format"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailWork"
                        Display="Dynamic" ErrorMessage="Required Work Email" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        OnServerValidate = "GoodDomain"
                        ControlToValidate="txtEmailWork"                         
                        ErrorMessage="no good" Display="Dynamic" 
                        ClientValidationFunction="validateDomain" ></asp:CustomValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnlAltenateEmail" runat="server" CssClass="InputRow FontSmall">
                <asp:Panel ID="Panel46" runat="server" CssClass="InputLabel">
                    <asp:Label ID="lblemailPersonal" runat="server" Text="Alternate Email" AssociatedControlID="txtAlternateEmail"></asp:Label>
                    <asp:Label ID="Label6" runat="server" AssociatedControlID="txtAlternateEmail" ForeColor="White"
                        Text="*"></asp:Label></asp:Panel>
                <asp:Panel ID="Panel47" runat="server" CssClass="InputValue">
                    <telerik:RadTextBox ID="txtAlternateEmail" runat="server" MaxLength="100" Width="210px"
                        CssClass="FontSmall" ValidationGroup="grp3">
                    </telerik:RadTextBox></asp:Panel>
                <asp:Panel ID="Panel48" runat="server" CssClass="InputValidator">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAlternateEmail"
                        Display="Dynamic" ErrorMessage="Incorrect Alternate Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtAlternateEmail"
                        ControlToValidate="txtEmailWork" ErrorMessage="Work Email cannot be the same as Alternate Email"
                        Operator="NotEqual"></asp:CompareValidator>&nbsp;
                    <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAlternateEmail"
                            Display="Dynamic" ErrorMessage="Required Alternate Email" Enabled="False"></asp:RequiredFieldValidator>&nbsp;</asp:Panel>
            </asp:Panel>
            <asp:Panel ID="Panel49" runat="server" CssClass="Blank20" Style="width: 521px">
                &nbsp;
            </asp:Panel>
            <%--Buttons--%>
            <div class="ButtonRow" style="">
                <input id="htmbtnHome" runat="server" onclick="window.open('start.aspx?SkipCheck=YES','_self');"
                    style="width: 110px" type="button" value="Welcome Page" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="BackButton_Click" CausesValidation="False"
                    Width="110px" />
                <asp:Button ID="btnNext" runat="server" Text="Save & Next" Width="110px" OnClick="nextButton_Click" />
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
