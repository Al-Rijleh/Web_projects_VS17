<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PLAViewFax.Default" %>

<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=6.1.12.820, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="700px" 
            Width="725px"></telerik:ReportViewer>
        
        <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back" 
            Width="80px" />
        
    </div>
    </form>
</body>
</html>
