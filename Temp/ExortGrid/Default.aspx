<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExortGrid.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/Excel_HTML.png"
            OnClick="ImageButton_Click" AlternateText="Html" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="Images/Excel_ExcelML.png"
            OnClick="ImageButton_Click" AlternateText="ExcelML" />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="Images/Excel_BIFF.png"
            OnClick="ImageButton_Click" AlternateText="Biff" />
        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="Images/Excel_XLSX.png"
            OnClick="ImageButton_Click" AlternateText="Xlsx" />
    </div>
    <div class="demo-container no-bg">
        <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server"  AllowPaging="true"
            PageSize="7" AutoGenerateColumns="false" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated"
            OnItemCreated="RadGrid1_ItemCreated" OnHTMLExporting="RadGrid1_HtmlExporting" OnItemCommand="RadGrid1_ItemCommand"
            OnBiffExporting="RadGrid1_BiffExporting" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView CommandItemDisplay="Top">
                <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                <Columns>
                    <telerik:GridBoundColumn DataField="employee_number" HeaderText="Employee ID" HeaderStyle-Width="100px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Las_tName" HeaderText="Last Name" HeaderStyle-Width="130px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Firs_tName" HeaderText="First Name" HeaderStyle-Width="130px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Birth_Date" HeaderText="Birth Date" DataFormatString="{0:MM-dd-yy}"
                        HeaderStyle-Width="140px">
                   </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <%--<asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT * FROM [Employees]" runat="server"></asp:SqlDataSource>--%>
  
    </form>
</body>
</html>
