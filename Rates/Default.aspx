<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Rates.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript">
        function CheckSave() {
            //alert('Please note that this procedure might take long time to process\nDO NOT Click or exit this page until you receive a message stating that the process is completed');
            document.getElementById("hidSave").value = 'Go';
            __doPostBack(null, null);
        }

        function CheckRestRate() {
            var dec = confirm('Are you sure you want to rest the rates for selected coverage? ');
            //alert(dec);
            if (dec) {
                document.getElementById("hidReset").value = 'Go';               
                __doPostBack(null, null);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <asp:HiddenField ID="hidSave" runat="server" />
        <asp:HiddenField ID="hidReset" runat="server" />
        <div class="InputRow">
            <h1>Enter Basic Rates Amounts</h1>
        </div>

        <div style="width: 700px">
            <div style="float: left">
                <asp:Button ID="btnSetup" runat="server" Text="Setup Family and Age Range" OnClick="btnSetup_Click" Visible="False" />

                <asp:Button ID="btnUseOld" runat="server" Text="Use Old" OnClick="btnUseOld_Click" />
            </div>
            <div style="float: right">
                <asp:Button ID="btnRestRates" runat="server" Text="ResetRate" />
            </div>
        </div>
        <div style="width: 700px">
            <asp:CheckBox ID="cbSelectOnFS" runat="server" Text="Save Selected Family Status Only" />
        </div>
        <div>
            &nbsp;
        </div>
        <div>

            <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server"
                EditMode="Batch" OnNeedDataSource="RadGrid1_NeedDataSource"
                OnBatchEditCommand="RadGrid1_BatchEditCommand" AutoGenerateColumns="False" GroupPanelPosition="Top" Width="700px" OnItemCommand="RadGrid1_ItemCommand" OnDeleteCommand="RadGrid1_DeleteCommand">
                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <MasterTableView CommandItemDisplay="TopAndBottom" DataKeyNames="unique_id" HorizontalAlign="NotSet" EditMode="Batch" AutoGenerateColumns="False">

                    <CommandItemSettings ShowAddNewRecordButton="False" ShowExportToExcelButton="True" />

                    <Columns>
                        <telerik:GridBoundColumn DataField="family_status_code" FilterControlAltText="Filter column3 column" HeaderText="family Status" UniqueName="column3" ReadOnly="True">
                            <HeaderStyle Width="250px" />
                            <ItemStyle Width="250px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="age_selected_code" FilterControlAltText="Filter column column" HeaderText="Age Band" UniqueName="column" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="rate_amount" DecimalDigits="2" FilterControlAltText="Filter column1 column" HeaderText="Rate Amount" UniqueName="column1"
                            MinValue="0" NumericType="Currency">
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="employer_split" DecimalDigits="2" FilterControlAltText="Filter column2 column" HeaderText="ER Split" UniqueName="column2"
                            MinValue="0" NumericType="Currency">
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="employee_split" DecimalDigits="2" FilterControlAltText="Filter column2 column" HeaderText="EE Split" UniqueName="column4" ReadOnly="True"
                            MinValue="0" NumericType="Currency">
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="rate_override1" DecimalDigits="2" FilterControlAltText="Filter column5 column" HeaderText="Tobaco" MinValue="0" UniqueName="column5" NumericType="Currency">
                        </telerik:GridNumericColumn>



                    </Columns>

                </MasterTableView>

                <FilterMenu RenderMode="Lightweight"></FilterMenu>

                <HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>

            </telerik:RadGrid>

        </div>

    </form>
</body>
</html>
