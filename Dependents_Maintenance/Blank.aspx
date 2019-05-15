<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blank.aspx.cs" Inherits="Dependents_Maintenance.Blank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            window.parent.location.href = "/web_projects/EnrollmentWizard/DependentInfo.aspx";
        </script>
    <div>
    <asp:Panel ID="pnlimg" runat="server" CssClass="floatMid" style="position: absolute; top: 208px; left: 318px;
            right: 916px; width: 150px; z-index: 1000; width:90px;height:00px" >
           <asp:Image ID="Image2" runat="server" Style="margin-left: auto; margin-right: auto"
                ImageUrl="https://www.myenroll.com/images/busy.gif" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
