<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddEditDepLimited.aspx.cs"
    Inherits="Dependents_Maintenance.AddEditDepLimited" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add/Edit Dependents</title>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
    
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
        
         var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        function PostBack() 
        {
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
            {                
                theForm.submit();
            }
        }   
                
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="False"
            InputDirection="RightToLeft" Mask="99/99/9999" TargetControlID="txtDOB">
        </cc1:MaskedEditExtender>
        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" ClearMaskOnLostFocus="False"
            Mask="(999) 999-9999" TargetControlID="txtHomePhone">
        </cc1:MaskedEditExtender>
        <div style="z-index: 101; left: 0px; width: 675px; height: 240px;">
            <div style="z-index: 101; width: 675; height: 30px; vertical-align: top; text-align: center;">
                <asp:Label ID="lblTitle" runat="server" Text="Edit Dependent" CssClass="fontsmall"
                    Font-Bold="True"></asp:Label>
            </div>
            <div style="width: 340px; float: left">
                <div style="width: 338px">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblSSN" runat="server" AssociatedControlID="txtSSN" CssClass="fontsmall"
                            ToolTip="Social Security Number Title">SSN<span style="font-size: 7pt;">&nbsp;(###-##-####)</span></asp:Label>
                    </div>
                    <asp:Label ID="Label12" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                        Style="left: 97px;" ToolTip="Reuired Field"></asp:Label>
                    <asp:TextBox ID="txtSSN" runat="server" CssClass="fontsmall" MaxLength="11" Style="left: 106px;"
                        Width="160px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSSN"
                        CssClass="fontsmall" Display="Dynamic" 
                        ErrorMessage="Incorrect SSN (###-##-####)" Style="left: 275px;"
                        ValidationExpression="\d{3}-\d{2}-\d{4}" Width="89px"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSSN"
                        CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic" EnableClientScript="False"
                        Style="left: 275px;"></asp:RequiredFieldValidator>
                </div>


                <asp:Panel ID="pnlSSNOnly" runat="server">
               

                <div style="width: 338px; padding-top: 5px">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblDOB" runat="server" CssClass="fontsmall" Text="DOB" ToolTip="Sate of Birth Title"
                            AssociatedControlID="txtDOB"></asp:Label>
                    </div>
                    <asp:Label ID="Label1" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                        Style="left: 97px;" ToolTip="Reuired Field"></asp:Label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="fontsmall" Width="160px" MaxLength="10"
                        Style="left: 106px;"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDOB"
                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="Incorrect Date" MaximumValue="01/01/2099"
                        MinimumValue="01/01/1900" Style="left: 275px;" Type="Date" Width="81px"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDOB"
                        CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic" EnableClientScript="False"
                        Style="left: 275px;"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 338px; padding-top: 5px">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblSchool" runat="server" CssClass="fontsmall" Text="School Name"
                            ToolTip="School Name Title" AssociatedControlID="txtSchool"></asp:Label>
                    </div>
                    <asp:Label ID="Label2" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                        Style="left: 97px;" ToolTip="Reuired Field"></asp:Label>
                    <asp:TextBox ID="txtSchool" runat="server" CssClass="fontsmall" Width="160px" MaxLength="50"
                        Style="left: 106px; "></asp:TextBox>
                </div>
                <div style="width: 338px; padding-top: 5px">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblGraduation" runat="server" AssociatedControlID="ddlMonth" CssClass="fontsmall"
                            Text="Graduation Date" ToolTip="Graduation Date Title" Width="90px"></asp:Label>
                    </div>
                    <asp:Label ID="Label3" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                        Style="left: 97px;" ToolTip="Reuired Field"></asp:Label>
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="fontsmall" Style="left: 106px;
                        " Width="83px">
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
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="fontsmall" Style="left: 190px;" Width="82px">
                    </asp:DropDownList>
                </div>

                 </asp:Panel>














            </div>
            <asp:Panel ID="pnlSSNOnly2" runat="server">
            
            <div style="width: 334px; float: right">
                <div style="width: 330px;">
                    <asp:Label ID="lblInfo" runat="server" CssClass="fontsmall" Font-Bold="True" Text="Dependent’s home address, if different from employee’s "
                        Style="left: 365px;" Width="329px"></asp:Label>
                </div>
                <div style="width: 330px;">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblStreet" runat="server" CssClass="fontsmall" Text="Street" ToolTip="Street title"
                            AssociatedControlID="txtStreet"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtStreet" runat="server" CssClass="fontsmall" ToolTip="Enter Street"
                        Width="120px" MaxLength="30"></asp:TextBox>
                </div>
                <div style="width: 330px;">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblApt" runat="server" Text="Apt#/ P.O.Box" CssClass="fontsmall" Style="left: 365px;"
                            AssociatedControlID="txtApt" Width="90px"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtApt" runat="server" CssClass="fontsmall" ToolTip="Enter Apartment Number or P.O. Box"
                        Width="120px" Style="left: 465px;" MaxLength="30"></asp:TextBox>
                </div>
                <div style="width: 330px;">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblCity" runat="server" CssClass="fontsmall" Text="City" ToolTip="City Title"
                            Style="left: 365px;" AssociatedControlID="txtCity"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="fontsmall" ToolTip="Enter City"
                        Width="120px" Style="left: 465px;" MaxLength="20"></asp:TextBox>
                </div>
                <div style="width: 330px;">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblState" runat="server" CssClass="fontsmall" Text="State" ToolTip="State Title"
                            Style="left: 365px;" AssociatedControlID="ddlState"></asp:Label>
                    </div>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="fontsmall" Width="126px"
                        ToolTip="Select State" Style="left: 465px;">
                    </asp:DropDownList>
                </div>
                <div style="width: 330px;">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblZipCode" runat="server" CssClass="fontsmall" Text="Zip Code" ToolTip="Zip Code Title"
                            Style="left: 365px;" AssociatedControlID="txtZip" Width="90px"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="fontsmall" ToolTip="Enter Zip Code"
                        Width="120px" Style="left: 465px;" MaxLength="10"></asp:TextBox>
                </div>
                <div style="width: 330px;">
                    <div style="width: 90px; float: left">
                        <asp:Label ID="lblHomePhonr" runat="server" CssClass="fontsmall" Text="Home Phonr#"
                            ToolTip="Home Phonr Number Title" Style="left: 365px;" AssociatedControlID="txtHomePhone"
                            Width="90px"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="fontsmall" ToolTip="EnterHomePhoneNumber"
                        Width="120px" Style="left: 465px;"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone"
                        CssClass="fontsmall" ErrorMessage="Incorrect Phone#" Display="Dynamic" EnableClientScript="False"
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Style="left: 594px;"
                        Width="97px"></asp:RegularExpressionValidator>
                </div>
            </div>
            </asp:Panel>
            <div style="z-index: 101; left: 0px; width: 675px;">
                <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="aspxbtn_Click"
                    Text="Save & Exit" ToolTip="Save Changes and Exit" /><input id="Button1" class="fontsmall"
                        onclick="closeWindow(); return false;" type="button" value="Cancel" />
            </div>
        </div>
    </form>
</body>
</html>
