<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaxPage.aspx.cs" Inherits="StartLifeEventv1.FaxPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Local.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <script type="text/javascript">
        function showfax(dpno) {
            $(function () {
                try { window.parent.refreshDoc(strLE_EE_ID); } catch (err) { }
                window.open('ViewFax.aspx?DpNo=' + dpno, '_blank');
            })
        }

        function finish() {
            window.open("/WEB_PROJECTS/NEWHIREWIZARD/START.ASPX?SkipCheck=YES", 'self');
        }

        function Remove(ee) {
            if (confirm('Are you sure you want to remove this document')) {
                document.getElementById('hidRemove').value = ee;
                __doPostBack(null, null);
            }
        }

        function btnHTMViewImage_onclick() {
            window.open('ViewDoc.aspx', '_blank');
        }

        function OnClientclose(radWindow) {
            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument

            if (retcode == "1") {
                radWindow.argument = 0;
                return;
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadSkinManager runat="server" ShowChooser="false" EnableEmbeddedSkins="False"></telerik:RadSkinManager>
        <asp:HiddenField ID="hidRemove" runat="server" />
        <div class='LeftArea floatleft' id='dvFaxSection' runat='server' style="width: 100%">
            <div class='LeftArea' style="margin-top: 25px">
                <telerik:RadComboBox ID="dllSentTo" runat="server" EnableCheckAllItemsCheckBox="false" CheckBoxes="True" EmptyMessage="Send to ..." Width="130" AutoPostBack="True" OnItemChecked="dllSentTo_ItemChecked" DropDownAutoWidth="Enabled">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Send to PC" Value="0" />
                        <telerik:RadComboBoxItem runat="server" Text="Send to Email" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Send to Email" Value="2" />
                    </Items>
                </telerik:RadComboBox>
            </div>

            <div class='LeftArea' style="margin-top: 23px">
                <asp:Label ID="lblUploadComments" runat="server" Text="Comments" CssClass="FontBold"></asp:Label>
            </div>

            <div id="Div1" runat="server" style="float: left; margin-bottom: 40px;" class="LeftArea">
                <telerik:RadTextBox ID="txtmsgFax" runat="server" Height="100px" TextMode="MultiLine" Width="200px" AutoPostBack="True" OnTextChanged="txtmsgFax_TextChanged">
                </telerik:RadTextBox>
            </div>

            <div class='LeftArea' style="margin-top: 15px">
                <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Enabled="False">
                </telerik:RadButton>
            </div>
            <div id="Div2" runat="server" style="float: left; margin-top: 15px;" class="LeftArea">
                <telerik:RadGrid ID="rgDoc" runat="server" class="LeftArea" OnNeedDataSource="rgDoc_NeedDataSource"
                    Width="220px"
                    GridLines="None" CssClass="NoBorder">

                    <MasterTableView NoMasterRecordsText="">
                    </MasterTableView>

                </telerik:RadGrid>
            </div>

        </div>
    </form>
</body>
</html>
