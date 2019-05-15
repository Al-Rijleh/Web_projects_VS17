<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_old.aspx.cs" Inherits="Employee_Search.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Search</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Pragma" content="no-cache" />
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <script src="/js/StyleSetter.js" type="text/javascript"></script>
    <style type="text/css">
        .error
        {
            font-family: Arial, Sans-Serif;
            font-size: 10pt;
            font-weight: bold;
            color: Maroon;
            background-color: Yellow;
            border-top-width: 1px;
            border-left-width: 1px;
            border-left-color: #000000;
            border-bottom-width: 1px;
            border-bottom-color: #000000;
            border-top-color: #000000;
            border-right-width: 1px;
            border-right-color: #000000;
        }
        .style1
        {
            height: 18px;
        }
        .BackG
        {
            background-color: #FFF4CD !important;
        }
        .header_
        {
            background: #DFE9F5 !important;
            font-weight: normal !important;
        }
        .grid_
        {
            border: 1px solid #cccccc !important;
        }
        div.RadGrid_Vista .SelectedItem
        {
            background: #CCCCCC;
        }
        div.RadGrid_Vista .SelectedItem td
        {
            border-color: #CCCCCC;
        }
        .style2
        {
            height: 42px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Select(ee) {
            document.getElementById('hid3').value = ee;
            document.getElementById('dgEEs').style.display = "none";
            document.getElementById('Table').style.display = "none";
            __doPostBack(null, null);

        }


        function Highlight(row) {
            row.style.backgroundColor = '#FFFFCC';
        }
        function UnHighlight(row) {
            row.style.backgroundColor = 'white';
        }

    </script>
    <link href="EE_Search.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
    </telerik:RadScriptManager>
    <telerik:RadToolTip ID="RadToolTip1" runat="server" HideEvent="LeaveToolTip" Position="BottomRight"
        Skin="Web20">
    </telerik:RadToolTip>
    <div class="BackG" style="width: 790px; background-color: #DFE9F5;" id='dvHeder'
        runat="server">
        <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label>
    </div>
    <table id="Table" cellspacing="0" cellpadding="0" width="790" border="0">
        <tr>
            <td style="padding-bottom: 5px">
                <asp:Label ID="lblScript" runat="server"></asp:Label>
                <asp:Label ID="lblTitle" runat="server"><p style="margin: 2.25pt 0in;"><strong><span style="font-family: arial,sans-serif; color: black;">Employee Search</span></strong></p></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="fontsmall">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="margin-bottom: 10px">
                <asp:Label ID="lblCurrentlySelected" runat="server" CssClass="fontsmall" Font-Bold="True"
                    Text="Selected Employee - "></asp:Label>
                &nbsp;<asp:Label ID="lblEmployeeSelected" runat="server" CssClass="fontsmall" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px;">
                <asp:Label ID="Label1" runat="server" CssClass="fontsmall" AssociatedControlID="txtSearch"
                    Font-Bold="True">Search</asp:Label>&nbsp;<asp:Label ID="lblInstruction" runat="server"
                        CssClass="fontsmall">(<span style="color: #0070c0;">How?</span>)</asp:Label>&nbsp;
                <asp:TextBox ID="txtSearch" runat="server" CssClass="Input_Control" Width="300px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnGo" runat="server" CssClass="General_button" Width="30px" Text="Go"
                    OnClick="btnGo_Click1"></asp:Button>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearch"
                    CssClass="error" ErrorMessage="Please enter search text"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Filter: " CssClass="fontsmall" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="opnlstFilter" runat="server" RepeatDirection="Horizontal"
                                CssClass="fontsmall" AutoPostBack="True" OnSelectedIndexChanged="opnlstFilter_SelectedIndexChanged">
                                <asp:ListItem Value="1" Selected="True">All Employees</asp:ListItem>
                                <asp:ListItem Value="0">Active Employees Only</asp:ListItem>
                                <asp:ListItem Value="2">Terminated Only</asp:ListItem>
                                <asp:ListItem Value="4">Retiree Only</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:HiddenField ID="hid2" runat="server" />
                <asp:HiddenField ID="hid3" runat="server" />
                <telerik:RadGrid ID="dgEEs" runat="server" CellSpacing="0" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource"
                    AutoGenerateColumns="False" OnItemCommand="rgHeader_ItemCommand" Skin="Outlook"
                    ShowHeader="False">
                    <MasterTableView DataKeyNames="Record_Id" AllowMultiColumnSorting="True" GroupLoadMode="Server"
                        NoDetailRecordsText="No records to display.">
                        <NestedViewTemplate>
                            <telerik:RadGrid ID="rgDetal" runat="server" Skin="Default" ShowHeader="False">
                                <ItemStyle CssClass="BackG" />
                            </telerik:RadGrid>
                        </NestedViewTemplate>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="record_id" FilterControlAltText="Filter column column"
                                HeaderText="record_id" UniqueName="column" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="employee_name_link" FilterControlAltText="Filter column1 column"
                                HeaderText="employee_name" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EmployerOnly" FilterControlAltText="Filter column2 column"
                                HeaderText="EmployerOnly" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CityState" FilterControlAltText="Filter column3 column"
                                HeaderText="CityState" UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Formated_Status" FilterControlAltText="Filter column4 column"
                                HeaderText="Status" UniqueName="column4">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <HeaderStyle HorizontalAlign="Center" />
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnClose" runat="server" CssClass="General_button" Width="75px" Text="Close"
                    OnClick="btnClose_Click" CausesValidation="False"></asp:Button>
            &nbsp;New Version</td>
        </tr>
    </table>
    </form>
</body>
</html>
