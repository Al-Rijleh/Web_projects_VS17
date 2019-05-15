<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebForm1.aspx.cs" Inherits="Dependents_Maintenance.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <link href="Dep_Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  
        <div id="dvMain" class="AddEditMain">            
            <div id="Div2" class="AddEditMain" style="text-align: center">
            <asp:Label ID="lblTitle" runat="server" Text="Edit Dependent" CssClass="fontsmall"
                    Font-Bold="True"></asp:Label>
            </div>
            <div id="dvLeftPanel" class="AddEditLeft">
                <%--RelationShip--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblRelatio" runat="server" CssClass="fontsmall" Text="Relation" ToolTip="Relation Title"
                            AssociatedControlID="ddlRelation"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label14" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:DropDownList ID="ddlRelation" runat="server" CssClass="fontsmall" Width="166px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlRelation_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                </div>
                <%--FirstName--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" CssClass="fontsmall"
                            Text="First Name" ToolTip="First Name Title"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label12" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
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
                <%--Last Name--%>
                <div id="dvRow3" class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblLastName" runat="server" CssClass="fontsmall" Text="Last Name"
                            ToolTip="Last Name Title" AssociatedControlID="txtLastName"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label3" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="fontsmall" Width="160px" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="AddEditValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                            CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--MI--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblMI" runat="server" CssClass="fontsmall" Text="Miiddle Initial"
                            ToolTip="Miiddle Initial Title" AssociatedControlID="txtMI"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label4" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:TextBox ID="txtMI" runat="server" CssClass="fontsmall" Width="160px" MaxLength="1"></asp:TextBox>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                </div>
                <%--SSN--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblSSN" runat="server" CssClass="fontsmall" Text="SSN" ToolTip="Social Security Number Title"
                            AssociatedControlID="txtSSN"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label5" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:TextBox ID="txtSSN" runat="server" CssClass="fontsmall" Width="160px" MaxLength="11"></asp:TextBox>
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
                        <asp:Label ID="Label6" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="fontsmall" Width="160px" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="AddEditValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB"
                            CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDOB"
                            CssClass="fontsmall" ErrorMessage="Incorrect Date" MaximumValue="01/01/2099"
                            MinimumValue="01/01/1900" Type="Date" Display="Dynamic"></asp:RangeValidator>
                    </div>
                </div>
                <%--Gender--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblGender" runat="server" CssClass="fontsmall" Text="Gender" ToolTip="Gender Title"
                            AssociatedControlID="ddlGender"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label7" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="fontsmall" Width="166px">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                </div>
                <%--Student--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblStudent" runat="server" CssClass="fontsmall" Text="Student" ToolTip="Full Time Student Title"
                            AssociatedControlID="ddlStudent"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label8" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:DropDownList ID="ddlStudent" runat="server" CssClass="fontsmall" Width="166px">
                            <asp:ListItem Value="T">Yes</asp:ListItem>
                            <asp:ListItem Value="F">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                </div>
                <%--Disabled--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblHndicap" runat="server" CssClass="fontsmall" Text="Disabled" ToolTip="Disabled Title"
                            AssociatedControlID="ddlHandiCap"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label9" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:DropDownList ID="ddlHandiCap" runat="server" CssClass="fontsmall" Width="166px">
                            <asp:ListItem Value="T">Yes</asp:ListItem>
                            <asp:ListItem Value="F">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                </div>
                <%--EffectiveDate--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblEffectiveDate" runat="server" CssClass="fontsmall" Text="Effective Date"
                            ToolTip="Effective Date Title" AssociatedControlID="txtEffDate"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label10" runat="server" CssClass="fontsmall" ForeColor="Maroon" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:TextBox ID="txtEffDate" runat="server" CssClass="fontsmall" Width="160px" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="AddEditValidator">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEffDate"
                            CssClass="fontsmall" ErrorMessage="Required Info." Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtEffDate"
                            CssClass="fontsmall" ErrorMessage="Incorrect Date" MaximumValue="01/01/2099"
                            MinimumValue="01/01/1900" Type="Date" Display="Dynamic"></asp:RangeValidator>
                    </div>
                </div>
                <%--School Name--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblSchool" runat="server" CssClass="fontsmall" Text="School Name"
                            ToolTip="School Name Title" AssociatedControlID="txtSchool"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label11" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditTextBox">
                        <asp:TextBox ID="txtSchool" runat="server" CssClass="fontsmall" Width="160px" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="AddEditValidator">
                        &nbsp;
                    </div>
                </div>
                <%--Graduation Date--%>
                <div class="AddEditRowLeft">
                    <div class="AddEditLabel">
                        <asp:Label ID="lblGraduation" runat="server" CssClass="fontsmall" Text="Graduation Date"
                            ToolTip="Graduation Date Title" AssociatedControlID="ddlMonth"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label13" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
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
                <%--Space--%>
                <div class="AddEditRowLeft" style="height:10px">
                    &nbsp;
                </div>
                <div class="AddEditRowLeft">
                    <asp:Label ID="lblReqiuedFieldsIndicators" runat="server" CssClass="fontsmall" 
                ToolTip="Required Field Indicator Note"><font color="#800000">|</font> Indicates Required Field</asp:Label>
                </div>
                <div class="AddEditRowLeft" style="height:10px">
                    &nbsp;
                </div>
                <div class="AddEditRowLeft" >
                    <asp:Button ID="btnSave" runat="server" OnClick="aspxbtn_Click" Text="Save & Exit"
                                        CssClass="fontsmall" ToolTip="Save Changes and Exit" />
            <input id="Button1"
                                            type="button" value="Cancel" onclick="closeWindow(); return false;" class="fontsmall" />
                </div>
                
                
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
                        <asp:Label ID="Label1" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="fontsmall" ToolTip="Enter Street"
                            Width="120px"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                <%--PO Box Apt--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblApt" runat="server" Text="Apt#/ P.O.Box" CssClass="fontsmall"  AssociatedControlID="txtApt"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label15" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtApt" runat="server" CssClass="fontsmall" ToolTip="Enter Apartment Number or P.O. Box"
                                        Width="120px"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                
                <%--City--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblCity" runat="server" CssClass="fontsmall" Text="City" ToolTip="City Title"  AssociatedControlID="txtCity"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label16" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                       <asp:TextBox ID="txtCity" runat="server" CssClass="fontsmall" ToolTip="Enter City"
                                        Width="120px" ></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>
                <%--State--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblState" runat="server" CssClass="fontsmall" Text="State" ToolTip="State Title" AssociatedControlID="ddlState"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label17" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                       <asp:DropDownList ID="ddlState" runat="server" CssClass="fontsmall" Width="126px" ToolTip="Select State" >
                                    </asp:DropDownList>
                    </div>
                    <div class="AddEditRValidator">
                        &nbsp;
                    </div>
                </div>                
                <%--Zip--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                        <asp:Label ID="lblZipCode" runat="server" CssClass="fontsmall" Text="Zip Code" ToolTip="Zip Code Title"  AssociatedControlID="txtZip"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label18" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                       <asp:TextBox ID="txtZip" runat="server" CssClass="fontsmall" ToolTip="Enter Zip Code"
                                        Width="120px"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtZip"
                                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="Incorrect Zip Code" ValidationExpression="\d{5}(-\d{4})?"  Width="100px"></asp:RegularExpressionValidator>
                    </div>
                </div>    
                <%--Phone--%>
                <div class="AddEditRowRight">
                    <div class="AddEditRLabel">
                         <asp:Label ID="lblHomePhonr" runat="server" CssClass="fontsmall" Text="Home Phonr#"
                                        ToolTip="Home Phonr Number Title"  AssociatedControlID="txtHomePhone"></asp:Label>
                    </div>
                    <div class="AddEditReq">
                        <asp:Label ID="Label19" runat="server" CssClass="fontsmall" ForeColor="White" Text="| "
                            ToolTip="Reuired Field"></asp:Label>
                    </div>
                    <div class="AddEditRTextBox">
                        <asp:TextBox ID="txtHomePhone" runat="server" CssClass="fontsmall" ToolTip="EnterHomePhoneNumber"
                                        Width="120px"></asp:TextBox>
                    </div>
                    <div class="AddEditRValidator">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone"
                                        CssClass="fontsmall" ErrorMessage="Incorrect Phone#" Display="Dynamic" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"  Width="97px"></asp:RegularExpressionValidator>
                    </div>
                </div>    
                <%--Warning--%>
                <div class="AddEditRowRight">
                    <asp:Label ID="lblWarning" runat="server" CssClass="fontsmall">Bla Bla</asp:Label>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
