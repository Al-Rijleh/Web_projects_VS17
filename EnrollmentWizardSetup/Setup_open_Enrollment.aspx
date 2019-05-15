<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Setup_open_Enrollment.aspx.cs"
    Inherits="EnrollmentWizardSetup.Setup_open_Enrollment" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        s<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
        <div class="FullPage">
            <div class="Section">
                <asp:Label ID="lblPageTitle" runat="server" Text="Annual Open Enrollment Setup" CssClass="FontLarge"
                    Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section FontSmall">
                <asp:Label ID="lblSelectCoverages" runat="server">To set up included benefit plans in the enrollment period, click the Coverage Plan tab above and then select panel "Set up Included Benefit Plans in the Enrollment Period".</asp:Label>
            </div>
            <div class="Section">
                &nbsp;
            </div>
            <div class="Section FontSmall">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblEnrollmentType" runat="server" Text="Enrollment Type" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:RadioButtonList ID="rblEnrollmentType" runat="server" RepeatDirection="Horizontal"
                        Width="471px" AutoPostBack="True" OnSelectedIndexChanged="rblEnrollmentType_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Annual Open Enrollment</asp:ListItem>
                        <asp:ListItem Value="1">Mid-Year Open Enrollment</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="Section">
                &nbsp;
            </div>
            <div class="SectionNoTop">
                <asp:Label ID="lblPreviuosSetup" runat="server" Text="Last Enrollment Setup" Font-Bold="True"
                    CssClass="FontSmall"></asp:Label>
                <asp:Button ID="BtnEdit" runat="server" OnClick="BtnEdit_Click" Text="Edit Last Enrollment Setup"
                    CausesValidation="False" />
                <asp:Button ID="btnNew" runat="server" Text="New Enrollment Period" OnClick="btnNew_Click" CausesValidation="False" />
                <asp:GridView ID="rvLastEnrollment" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="FontSmall" ForeColor="#333333" GridLines="None" Width="600px">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Processing_Year" HeaderText="Processing Year">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="start_date" HeaderText="Start Date">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="end_date" HeaderText="Last Date">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="effective_date" HeaderText="Eff. Date">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblProcessingYear" runat="server" Text="Processing Year" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadNumericTextBox ID="txtProcessingYear" runat="server" MaxValue="2099"
                        MinValue="2008" Enabled="False">
                        <NumberFormat DecimalDigits="0" GroupSeparator="" />
                        <DisabledStyle BackColor="LightGray" ForeColor="Black" />
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProcessingYear"
                        CssClass="FontSmall" EnableClientScript="False" ErrorMessage="Required Information"
                        ForeColor="Maroon"></asp:RequiredFieldValidator></div>
            </div>
            <%--Begin Date--%>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lbBeginDate" runat="server" Text="Begin Date" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadDatePicker ID="txtBeginDate" runat="server" MinDate="1998-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBeginDate"
                        CssClass="FontSmall" EnableClientScript="False" ErrorMessage="Required Information"
                        ForeColor="Maroon" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtEffectiveDate"
                        ControlToValidate="txtBeginDate" CssClass="FontSmall" EnableClientScript="False"
                        ErrorMessage="This Date must be Less than effective Date" ForeColor="Maroon"
                        Operator="LessThan" Type="Date" Display="Dynamic"></asp:CompareValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtBeginDate"
                        CssClass="FontSmall" Display="Dynamic" EnableClientScript="False" ErrorMessage="Begin Enrollment must be greater the today's date"
                        ForeColor="Maroon" MaximumValue="12/31/2099" Type="Date"></asp:RangeValidator></div>
            </div>
            <%--Begin Date--%>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date (inclusive)" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadDatePicker ID="txtLastDate" runat="server" MinDate="1998-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastDate"
                        CssClass="FontSmall" EnableClientScript="False" ErrorMessage="Required Information"
                        ForeColor="Maroon" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBeginDate"
                        ControlToValidate="txtLastDate" CssClass="fontsmall" EnableClientScript="False"
                        ErrorMessage="This Date must be Larger than Begin Date" ForeColor="Maroon" Operator="GreaterThan"
                        Type="Date" Display="Dynamic"></asp:CompareValidator></div>
            </div>
            <%--Begin Date--%>
            <div class="SectionNoTop">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <telerik:RadDatePicker ID="txtEffectiveDate" runat="server" MinDate="1998-01-01">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <telerik:RadDateInput ID="txtEffDate" runat="server" Enabled="False" Visible="False">
                        <DisabledStyle BackColor="LightGray" ForeColor="Black" />
                    </telerik:RadDateInput>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEffectiveDate"
                        CssClass="FontSmall" EnableClientScript="False" ErrorMessage="Required Information"
                        ForeColor="Maroon"></asp:RequiredFieldValidator></div>
            </div>
            <%--Buttons--%>
            <div class="Section" style="height: 20px">
                &nbsp; &nbsp;&nbsp;
                <br />
                <br />
            </div>
            <div class="Section">
                <hr />
                <asp:Label ID="lblUseWizard" runat="server" CssClass="FontMedium" Font-Bold="True">this account</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblUseEnrollWizard" runat="server" RepeatDirection="Horizontal"
                    Width="622px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="1">Make Employees Use The Enrollment Wizard Program</asp:ListItem>
                    <asp:ListItem Value="0">DO Not Make Employees Use The Enrollment Wizard Program</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSaveTo" runat="server" RepeatDirection="Horizontal" Width="563px"
                    CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            &nbsp;
            <div class="SectionNoTop">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><asp:Button
                    ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="False" />&nbsp;
                <asp:Label ID="lblError" runat="server" CssClass="FontSmall" Font-Bold="False" ForeColor="Maroon"></asp:Label>
            </div>
            <div class="Section" style="height: 20px">
                &nbsp; &nbsp;&nbsp;
                <br />
                <br />
            </div>
            <div class="Section">
                <hr />
                <asp:Label ID="Label1" runat="server" CssClass="FontMedium" Font-Bold="True">Pre/Post Tax setting</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblPostTax" runat="server" Width="622px" CssClass="FontSmall"
                    Font-Bold="True">
                    <asp:ListItem Value="1">Allow Employees to choose to Pay for Benefit Plans per or post Tax</asp:ListItem>
                    <asp:ListItem Value="0">DO Not Allow Employees to choose to Pay for Benefit Plans per or post Tax</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSaveTaxTo" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                &nbsp;
            </div>
            <div style="height: 20px" class="Section">
                <br />
                <br />
            </div>
            <div class="Section">
                <hr />
                <asp:Label ID="Label2" runat="server" CssClass="FontMedium" Font-Bold="True">Show Extra Summary & Signature Page</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblExtraPage" runat="server" Width="200px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSaveToExtraPage" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="Button2" runat="server" Text="Save" OnClick="Button2_Click" />
                &nbsp;
            </div>
            <div style="height: 20px" class="Section">
                <br />
                <br />
            </div>
            <div class="Section">
                <hr />
                <asp:Label ID="Label3" runat="server" CssClass="FontMedium" Font-Bold="True">Show Core/Optional Benefit Column in Summary & Signature Page</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblShowCoreBenefit" runat="server" Width="200px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="rblSaveCoreBenefit" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rbSaveToShowCore" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="Button3" runat="server" Text="Save" OnClick="Button3_Click" />
                &nbsp;
            </div>
            
            
            <div class="Section">
                <hr />
                <asp:Label ID="Label4" runat="server" CssClass="FontMedium" Font-Bold="True">Pend New Dependents</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblPendNewDependents" runat="server" Width="200px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="rblSaveCoreBenefit" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rbSavePendDep" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="btnPendDep" runat="server" Text="Save" OnClick="btnPendDep_Click" />
                &nbsp;
            </div>
            
            <div class="Section">
                <hr />
                <asp:Label ID="Label5" runat="server" CssClass="FontMedium" Font-Bold="True">Allow Same Gender Dom. Par. Only</asp:Label></div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSameGender" runat="server" Width="200px" CssClass="FontSmall"
                    Font-Bold="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="rblSaveCoreBenefit" style="height: 10px">
                &nbsp;
            </div>
            <div class="Section">
                <asp:RadioButtonList ID="rblSameGenderSave" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="btnSaveSameGender" runat="server" Text="Save" OnClick="btnSaveSameGender_Click" />
                &nbsp;
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
