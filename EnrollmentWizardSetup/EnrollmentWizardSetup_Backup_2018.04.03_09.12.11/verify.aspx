<%@ Page Language="C#" AutoEventWireup="true" Codebehind="verify.aspx.cs" Inherits="EnrollmentWizardSetup.verify" EnableEventValidation="false" %>

<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server"></uc1:SetupTabStrip>
        <div class="FullPage">
            <div class="Section">
                <asp:Label ID="lblPageTitle" runat="server" Text="Verify Account Data" CssClass="FontLarge"
                    Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
            </div>
            
            <div class="SectionNoTop FontSmall">
                <asp:Label ID="lblInstruction" runat="server">Check Account Data</asp:Label>
            </div>
                <div class="Section">
                &nbsp;
                </div>
            <div class="SectionNoTop  FontSmall">
                <asp:Label ID="lblMissingGroupTypeTitle" runat="server" Text="Missing Group Type in Coverage Grouping" CssClass="fontsmall10" Font-Bold="True" Font-Underline="True"></asp:Label><br />
                <asp:Label ID="lblMissingGroupType" runat="server" Text="All Groups are assigned Group Type in Coverage Grouping" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>
                <asp:LinkButton ID="lnkbtnMissingGroupType" runat="server" CssClass="fontsmall" Font-Bold="True"
                    OnClick="lnkbtnMissingGroupType_Click">Click Here to Export to Excel</asp:LinkButton></div>
            
            <div class="SectionNoTop">
                <telerik:RadGrid ID="grdMissingGroupType" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False" GridLines="None" Skin="Sunset" AllowPaging="True" Width="755px">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="account_number" HeaderText="Account #" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="account_name" HeaderText="Account Name" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="class" HeaderText="Class" UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Group Name" UniqueName="column" DataField="description">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            
            <%--Sort Plan--%>
            <div class="SectionNoTop  FontSmall">
                <asp:Label ID="lblMissingSortPlanTitle" runat="server" Text="Missing Coverages' Sort Plan" CssClass="fontsmall10" Font-Bold="True" Font-Underline="True"></asp:Label><br />
                <asp:Label ID="lblMissingSortPlan" runat="server" Text="All Coverages are assigned Sort Plan" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>
                <asp:LinkButton ID="lnkbtnMissingSortPlan" runat="server" CssClass="fontsmall" Font-Bold="True"
                    OnClick="lnkbtnMissingSortPlan_Click">Click Here to Export to Excel</asp:LinkButton></div>
            
            <div class="SectionNoTop">
                <telerik:RadGrid ID="gvMissingSortPlan" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False" GridLines="None" Skin="Sunset" AllowPaging="True" Width="755px">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="account_number" HeaderText="Account #" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="account_name" HeaderText="Account Name" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="class" HeaderText="Class" UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Cat. Code" UniqueName="column4" DataField="category_code">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Category_plan" HeaderText="Cat. Plan" UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="long_description" HeaderText="Description" UniqueName="column">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            
            <%--Cut off Age--%>
            <div class="SectionNoTop  FontSmall">
                <asp:Label ID="lblMissingCutOffAgeTitle" runat="server" Text="Missing Coverages' Student / non Student Cutoff Age" CssClass="fontsmall10" Font-Bold="True" Font-Underline="True"></asp:Label><br />
                <asp:Label ID="lblMissingCutOffAge" runat="server" Text="All Coverages are assigned Student / non Student Cutoff Age" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>
                <asp:LinkButton ID="lnkbtnMissingCutoff" runat="server" CssClass="fontsmall" Font-Bold="True"
                    OnClick="lnkbtnMissingCutoff_Click">Click Here to Export to Excel</asp:LinkButton></div>
            
            <div class="SectionNoTop">
                <telerik:RadGrid ID="gvMissingCutOffAge" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False" GridLines="None" Skin="Sunset" AllowPaging="True" Width="755px">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="account_number" HeaderText="Account #" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="account_name" HeaderText="Account Name" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="class" HeaderText="Class" UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Cat. Code" UniqueName="column4" DataField="category_code">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Category_plan" HeaderText="Cat. Plan" UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="long_description" HeaderText="Description" UniqueName="column">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
