<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFax.aspx.cs" Inherits="StartLifeEventv1.ViewFax" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.2.16.914, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function closewin() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblScript" runat="server" Text=""></asp:Label>
    <div>
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="700" Width="900"></telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
