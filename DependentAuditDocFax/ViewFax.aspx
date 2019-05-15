<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFax.aspx.cs" Inherits="DependentAuditDocFax.ViewFax" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.2.16.914, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="750px" Width="650px"></telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
