<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deo_RemoveCoverages_Request_Doc.aspx.cs" Inherits="Dependents_Maintenance.Deo_RemoveCoverages_Request_Doc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script type="text/javascript">
        function closeWindowcloseWindowOE() {           
            closing();
            try {
                window.location.href = "/web_projects/Dependents_Maintenance/Blank.aspx";               
                return;
            }
            catch (e) { };
        }
    </script>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblScript" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hidAction" runat="server" />
    <div style="width: 100%" id="dvTop">
        <asp:Button ID="btnTerm" runat="server" Text="Terminate All Dependents’’ Befit Plans. Keep Dependent Action For Spending Account" Width="540px" OnClick="btnTerm_Click" /><br />
        <asp:Button ID="btnGetDocs" runat="server" Text="Submit Documents for Approval" Width="540px"/>

    </div>
    </form>
</body>
</html>
