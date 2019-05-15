<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dep_List.aspx.cs" Inherits="Dependents_Maintenance.Dep_List" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadGrid ID="RadGrid1" runat="server"  GridLines="None" AutoGenerateColumns="False"
            Skin="Sunset">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="fullname" HeaderText="Full Name" UniqueName="column1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Relation" HeaderText="Relation" UniqueName="column2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DOB" HeaderText="D.O.B." UniqueName="column3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="effective_date" HeaderText="Effective Date" UniqueName="column4">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="termination_date" HeaderText="Term Date" UniqueName="column">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>&nbsp;
    </form>
</body>
</html>
