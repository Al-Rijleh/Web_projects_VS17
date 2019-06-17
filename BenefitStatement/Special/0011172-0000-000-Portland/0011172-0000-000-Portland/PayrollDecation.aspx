<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayrollDecation.aspx.cs" Inherits="_0011172_0000_000_Portland.PayrollDecation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <telerik:RadGrid ID="RadGrid1" runat="server" 
            onneeddatasource="RadGrid1_NeedDataSource" Width="670px">
        </telerik:RadGrid>
    </div>
    </form>
</body>
</html>
