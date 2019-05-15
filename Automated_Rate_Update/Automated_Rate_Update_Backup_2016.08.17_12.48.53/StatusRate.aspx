<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusRate.aspx.cs" Inherits="Automated_Rate_Update.StatusRate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="BASLogin.css" rel="stylesheet" type="text/css" />
    <link href="/styles/main2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript">
        function isNumber(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        function GetTextBox(strID) {
            var all = document.all ? document.all : document.getElementsByTagName('*');
            for (var e = 0; e < all.length; e++) {
                var fldName = all[e].id;
                if (fldName.indexOf(strID) != -1)
                    return fldName;

            }
        }



        function change(id, name) {

            var comName = GetTextBox(id);

            var strvalue = eval(document.getElementById(comName)).value;
            eval(document.getElementById(comName)).className = "colorred";

            if (!isNumber(strvalue)) {
                $(function () {
                    alert(strvalue + ' ' + 'is not a valid number');
                })

                return;
            }
            else {
                eval(document.getElementById(comName)).className = "colowhite";
                var alldata = eval(document.getElementById("hidcomVales")).value;
                alldata = alldata + '!' + id + '=' + strvalue;
                eval(document.getElementById("hidcomVales")).value = alldata;
            }
        }

        function htmBtnSave_onclick() {

            document.getElementById('dvimg').style.visibility = "visible";
            document.getElementById('dvTotalGrid').style.visibility = "hidden";
            //alert(eval(document.getElementById('hidcomVales')).value);
            eval(document.getElementById('hidAction')).value = 'save';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hidcomVales" runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbOe">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cbOe" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:Panel ID='pnMaster' runat="server" Style="text-align: left; margin-left: auto;
        margin-right: auto" CssClass="masterwidth">
        <asp:Panel ID='pnlTitle' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
            <asp:Label ID="lblTitle" runat="server" class="dataSetctionTitle">Edit Staus Rates</asp:Label>
        </asp:Panel>
        <asp:Panel ID='Panel1' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
           
            
                <asp:CheckBox ID="cbOe" runat="server" Text="Check here if you need us to send COBRA continuants open enrollment information about this plan"
                    Visible="true" />
            
        </asp:Panel>

<asp:Panel ID='Pan' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
           
    <table width="500px" id='tblparamenters' runat="server">
            <tr>
                <td class="style3" width="275">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" valign="top" width="275">
                    <asp:Label ID="lblSelectStatus" runat="server" CssClass="Label_Font">Select Status Code for This Coverage</asp:Label>
                </td>
                <td class="style3">
                    <asp:CheckBoxList ID="cblStatus" runat="server">
                    </asp:CheckBoxList>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" width="275">
                    &nbsp;&nbsp;</td>
                <td class="style3">
                </td>
                <td class="style4">
                </td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    &nbsp;&nbsp;<asp:Button ID="btnGenerate" runat="server" Text="Generate" 
                        onclick="btnGenerate_Click" />
                </td>
            </tr>
            </table>

     
        </asp:Panel>






        <table class="masterwidth">
            <tr>
                <td class="cvrgrow marginbottom5 paddingbottomm5 bottomline">
                    <asp:GridView ID="gvRates" runat="server" AutoGenerateColumns="False" CssClass="gridwidth"
                        OnRowCreated="gvRates_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="FAMILY_STATUS" HeaderText="Family Status" />
                            <asp:BoundField DataField="Rate" HeaderText="Existing Rate" />
                            <asp:TemplateField HeaderText="New Rate"></asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="cvrgrow marginbottom5 paddingbottomm5 bottomline">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        Width="75px" />
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="75px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
