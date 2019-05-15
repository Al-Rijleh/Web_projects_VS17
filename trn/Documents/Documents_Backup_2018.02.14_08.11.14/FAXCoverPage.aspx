<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAXCoverPage.aspx.cs" Inherits="Documents.FAXCoverPage" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=6.1.12.820, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="770px" 
            Width="950px"></telerik:ReportViewer>
        <br />
        <asp:Button ID="btnBaxk" runat="server" Text="Back" ToolTip="Return to Documents Page" CssClass="fontsmall" OnClick="btnBaxk_Click" Width="75px"  />
    </form>
</body>
</html>
