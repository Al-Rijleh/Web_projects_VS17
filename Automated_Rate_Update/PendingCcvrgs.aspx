<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingCcvrgs.aspx.cs"
    Inherits="Automated_Rate_Update.PendingCcvrgs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function docloseWindow(id) {
            closeWindow(id); return false;
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

        function remove(id) {
            if (confirm('Are you sure you want to remove this coverage?')) {
                document.getElementById('hidcmd').value = id;
                PostBack();
            }
        }


        function PostBack() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }

            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }  
    </script>
    <link href="main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidcmd" runat="server" />
    <div style="width: 650px;">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvCoverages" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvCoverages_RowDataBound"
                        GridLines="None" Width="600px">
                        <Columns>
                            <asp:BoundField DataField="long_description" HeaderText="long description"></asp:BoundField>
                            <asp:BoundField DataField="processing_year" HeaderText="processing year">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="catcodeplan" HeaderText="Code/Plan">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="add_userid" HeaderText="Added By" />
                            <asp:BoundField DataField="Remove" HtmlEncode="False" />
                        </Columns>
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnClose" runat="server" Text="Close" CausesValidation="False" Width="75px"
                        OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
