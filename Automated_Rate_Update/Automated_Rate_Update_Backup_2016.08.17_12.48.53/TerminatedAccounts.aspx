<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TerminatedAccounts.aspx.cs" Inherits="Automated_Rate_Update.TerminatedAccounts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function check (msg, id) {
            if (confirm(msg+" (ID="+id+")") == true) {
                document.getElementById('hidRemove').value = id;
                //alert(document.getElementById('hidRemove').value);
                __doPostBack(null, null);

            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" CausesValidation="False" 
        ResolvedRenderMode="Classic" SelectedIndex="2">
        <Tabs>
            <telerik:RadTab runat="server" NavigateUrl="~/BASLogin.aspx" 
                Text="Process Account">
            </telerik:RadTab>
            <telerik:RadTab runat="server" NavigateUrl="~/TerminatedAccounts.aspx" 
                Text="Terminated Account">
            </telerik:RadTab>


            <telerik:RadTab runat="server" NavigateUrl="~/GenerateReports.aspx" 
                Text="Generate Reminder Emails Report" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server"  NavigateUrl="~/GenerateReports.aspx?inital=1" Text="Generate Inital Email Reports">
            </telerik:RadTab>


            <telerik:RadTab runat="server" NavigateUrl="~/ReminderEmail.aspx" 
                Text="Send Reminder Emails" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server"  NavigateUrl="~/ReminderEmail.aspx?inital=1" Text="send Inital Email">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <asp:HiddenField ID="hidRemove" runat="server" />
    <asp:Label ID="lblScript" runat="server" Text=""></asp:Label>
        
        
    <asp:Label ID="lblTerminatedAccounts" runat="server" CssClass="pageTitle" 
        Text="Terminated Accouts"></asp:Label><br /><br />

        <asp:Label ID="lblRenewalDate" runat="server" Text="Renewal Date" 
            CssClass="textFont" Width="100px"></asp:Label>

        <asp:DropDownList ID="ddlRenewalDate" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlRenewalDate_SelectedIndexChanged">
            <asp:ListItem>permanent</asp:ListItem>
            <asp:ListItem>processed</asp:ListItem>
            <asp:ListItem>Processed Manually 01/01</asp:ListItem>
            <asp:ListItem>Processed Manually 02/01</asp:ListItem>
            <asp:ListItem>Processed Manually 03/01</asp:ListItem>
            <asp:ListItem>Processed Manually 04/01</asp:ListItem>
            <asp:ListItem>Processed Manually 05/01</asp:ListItem>
            <asp:ListItem>Processed Manually 06/01</asp:ListItem>
            <asp:ListItem>Processed Manually 07/01</asp:ListItem>
            <asp:ListItem>Processed Manually 08/01</asp:ListItem>
            <asp:ListItem>Processed Manually 09/01</asp:ListItem>
            <asp:ListItem>Processed Manually 10/01</asp:ListItem>
            <asp:ListItem>Processed Manually 11/01</asp:ListItem>
            <asp:ListItem>Processed Manually 12/01</asp:ListItem>
            <asp:ListItem>01/01</asp:ListItem>
            <asp:ListItem>02/01</asp:ListItem>
            <asp:ListItem>03/01</asp:ListItem>
            <asp:ListItem>04/01</asp:ListItem>
            <asp:ListItem>05/01</asp:ListItem>
            <asp:ListItem>06/01</asp:ListItem>
            <asp:ListItem>07/01</asp:ListItem>
            <asp:ListItem>08/01</asp:ListItem>
            <asp:ListItem>09/01</asp:ListItem>
            <asp:ListItem>10/01</asp:ListItem>
            <asp:ListItem>11/01</asp:ListItem>
            <asp:ListItem>12/01</asp:ListItem>
        </asp:DropDownList><br />
        
        <asp:Label ID="lblAccount_number" runat="server" Text="Account Number" 
            CssClass="textFont" Width="100px"></asp:Label>
        <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="textFont" 
            MaxLength="16"></asp:TextBox>&nbsp;
        <asp:Button ID="btnSave" runat="server" CssClass="textFont" 
            onclick="btnSave_Click" Text="Save" Width="65px" />
        <br /><br />
        
    
    <asp:LinkButton id="lnkbtnExport" onclick="lnkbtnExport_Click" runat="server" 
            Font-Bold="True" Visible="False">Click here to export the data shown below to Excel.</asp:LinkButton>
    <br />

            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                Height="40px" Skin="Default" >
            </telerik:RadAjaxLoadingPanel>

            <br />

        <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" onneeddatasource="RadGrid1_NeedDataSource" 
            ResolvedRenderMode="Classic" Width="795px" 
            
            ondeletecommand="RadGrid1_DeleteCommand" AllowFilteringByColumn="True" 
            PageSize="50">
            
            <ExportSettings IgnorePaging="True" OpenInNewWindow="True">
            </ExportSettings>
            
            <MasterTableView DataKeyNames="record_id">
                <CommandItemSettings ShowExportToExcelButton="True"  />
                <Columns>
                    <telerik:GridButtonColumn CommandName="Delete" 
                        UniqueName="record_id" DataTextField="record_id" HeaderText="Remove" />

                    <telerik:GridAttachmentColumn DataTextField="Account No" FileName="attachment" 
                        FilterControlAltText="Filter column column" HeaderText="Account No" 
                        FilterControlWidth = "100px"
                        UniqueName="column">
                        <HeaderStyle Width="110px" />
                        <ItemStyle Width="110px" />
                    </telerik:GridAttachmentColumn>
                    <telerik:GridAttachmentColumn DataTextField="Account Name" 
                        FileName="attachment" FilterControlAltText="Filter column1 column" 
                        AllowFiltering ="false"
                        HeaderText="Account_Name" UniqueName="column1">
                        <HeaderStyle Width="310px" />
                        <ItemStyle Width="310px" />
                    </telerik:GridAttachmentColumn>
                    <telerik:GridAttachmentColumn DataTextField="Requested By" 
                        FileName="attachment" FilterControlAltText="Filter column2 column" 
                        AllowFiltering ="false"
                        HeaderText="Requested By" UniqueName="column2">
                        <HeaderStyle Width="170px" />
                        <ItemStyle Width="170px" />
                    </telerik:GridAttachmentColumn>
                    <telerik:GridAttachmentColumn DataTextField="Renewal Date" 
                        FileName="attachment" FilterControlAltText="Filter column3 column" 
                        AllowFiltering ="false"
                        HeaderText="Renewal Date" UniqueName="column3">
                        <HeaderStyle Width="90px" />
                        <ItemStyle Width="90px" />
                    </telerik:GridAttachmentColumn>
                    <telerik:GridAttachmentColumn DataTextField="Added On" FileName="attachment" 
                        FilterControlAltText="Filter column4 column" HeaderText="Added On" 
                        AllowFiltering ="false"
                        UniqueName="column4">
                        <HeaderStyle Width="90px" />
                        <ItemStyle Width="90px" />
                    </telerik:GridAttachmentColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
      
    </div>
    </form>
</body>
</html>
