<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EnrollmentApproval.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <asp:Label ID="lblScript" runat="server"></asp:Label>
    <div class="FullPage">
        <asp:Label ID="lblWelcome" runat="server" 
            Text="Welcome to Open Enrollment approval module" Font-Bold="True" 
            Font-Names="Arial" Font-Size="Medium"></asp:Label><br />

        <%--===================--%>
        <asp:Panel ID="pnlProcessingYear" runat="server" CssClass="shortpnlRow">
        <div class="shortRow">
                <div id='dvProgramType' runat="server" class="shortRow marginbottom01">
                     <asp:Label ID="lblSelectProgramType" runat="server" Text="Program Type" CssClass="textFont"
                    Width="110px"></asp:Label>
                <asp:DropDownList ID="ddlProgramType" runat="server" CssClass="textFont" Width="300px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlProgramType_SelectedIndexChanged">
                </asp:DropDownList>
                </div>
                <div id='dvMaster' runat="server" class="shortRow marginbottom01">
                    <asp:Label ID="lblSelectMasterAccountTitle" runat="server" Text="Master Account"
                        CssClass="textFont" Width="110px"></asp:Label>
                    <telerik:RadComboBox ID="ddlMasterAccounts" runat="server" MarkFirstMatch="True"
                        Width="300px" AutoPostBack="True" DropDownWidth="500px" OnSelectedIndexChanged="ddlMasterAccounts_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </div>
                <div id='dvLocation' runat="server" class="shortRow marginbottom01">
                    <asp:Label ID="Location" runat="server" Text="Division/Location" CssClass="textFont"
                        Width="110px"></asp:Label>
                    <telerik:RadComboBox ID="ddlLocation" runat="server" MarkFirstMatch="True" Width="300px"
                        AutoPostBack="True" DropDownWidth="500px" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </div>
            </div>
            </asp:Panel>

        <%--==========================--%>
        <asp:Panel ID="Panel1" runat="server" CssClass="shortpnlRow">
        <asp:Label ID="lblInstruction" runat="server" Font-Names="Arial" 
            Font-Size="Small" ForeColor="Maroon" Width="450px" >Please process the Open Enrollment Pending for the Employee(s) shown below. To select an employee, please click on the employee’s Number. </asp:Label><br /><br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="shortpnlRow">
        <telerik:RadGrid ID="rgEmployees" runat="server" AllowFilteringByColumn="True" AllowSorting="True"
                    AutoGenerateColumns="False" OnItemCommand="rgEmployees_ItemCommand"
                    OnNeedDataSource="rgEmployees_NeedDataSource" Skin="Sunset" 
                Width="600px" ResolvedRenderMode="Classic">
                    <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" DataTextField="employee_number" HeaderText="BAS #"
                                UniqueName="column1">
                                <HeaderStyle Width="150px" />
                                <ItemStyle Font-Underline="True" Width="150px" />
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Employee Name" UniqueName="column">
                                <HeaderStyle Width="300px" />
                                <ItemStyle Width="300px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridImageColumn AllowFiltering="false" DataImageUrlFields="profile" 
                                FilterControlAltText="Filter column2 column" HeaderText="Pending Profile" 
                                ImageHeight="" ImageWidth="" UniqueName="column2" Visible="False">
                            </telerik:GridImageColumn>                           
                            <telerik:GridImageColumn AllowFiltering="false" DataImageUrlFields="Coverage" 
                                FilterControlAltText="Filter column4 column" HeaderText="Pending Coverage" 
                                ImageHeight="" ImageWidth="" UniqueName="column4" Visible="False">
                            </telerik:GridImageColumn>
                            <telerik:GridImageColumn AllowFiltering="false" DataImageUrlFields="Dependent" 
                                FilterControlAltText="Filter column3 column" HeaderText="Pending Dependents" 
                                ImageHeight="" ImageWidth="" UniqueName="column3" Visible="False">
                            </telerik:GridImageColumn>
                            <telerik:GridBoundColumn DataField="add_date_time" HeaderText="Add Date" UniqueName="column5" AllowFiltering="false">
                                <HeaderStyle Width="100" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            
                        </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
                    </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Sunset"></HeaderContextMenu>
                </telerik:RadGrid>
                </asp:Panel>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        // window.top.Revertleft();
        try { window.top.Revertleft(); }
        catch (err) { }
    </script>
</body>
</html>
