<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageDocs.aspx.cs" Inherits="StartLifeEventv1.ManageDocs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Remove(docid) {
            if (confirm('Are you sure you want to remove this documnet?')) {
                document.getElementById('hidRemove').value = docid;
                __doPostBack(null, null);
            }
            else
                return;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow(id) {
            var currentWindow = GetRadWindow();            
            currentWindow.argument = id;
            currentWindow.Close();
        }
    </script>
</head>
<body onblur="self.focus();">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidRemove" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="margin-top: 15px; width: 100%;">
            <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" Skin="Default">
                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                <HeaderStyle Font-Bold="True" />
            </telerik:RadGrid>
        </div>
        <div style="margin-top: 15px; width: 100%;">
            <div style="width: 100px; margin-right: auto; margin-left: auto">
                <telerik:RadButton ID="btnClose" runat="server" Text="Close" Primary="true" RenderMode="Lightweight"
                    Style="top: 14px; left: 0px;width:100px" OnClick="btnClose_Click">
                </telerik:RadButton>
            </div>
        </div>
    </form>
</body>
</html>
