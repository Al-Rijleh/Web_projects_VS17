<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgeRate.aspx.cs" Inherits="Automated_Rate_Update.AgeRate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="Default.css" rel="stylesheet" type="text/css" />
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
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hidcomVales" runat="server" />
    <asp:Panel ID='pnMaster' runat="server" Style="text-align: left; margin-left: auto;
        margin-right: auto" CssClass="masterwidth">
        <asp:Panel ID='pnlTitle' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
            <asp:Label ID="lblTitle" runat="server" class="dataSetctionTitle">Edit Staus Rates</asp:Label>
        </asp:Panel>
        <asp:Panel ID='Panel1' runat="server" class="masterwidth marginbottom5 paddingbottomm5 bottomline">
           
            
                <asp:CheckBox ID="cbOe" runat="server" Text="COBRA continuants should have the right to participate in open enrollment. Check here if you want CCS to send COBRA continuants an enrollment form to make open enrollment elections."
                    Visible="true" />
            
        </asp:Panel>
        <table width="500px" id='tblparamenters' runat="server">
            <tr>
                <td class="style1" width="275">
                    &nbsp;&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblMinAge" runat="server" CssClass="Label_Font">What is the oldest age in the first age band</asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Maroon" 
                        Text="*"></asp:Label>
                </td>
                <td>
                   <telerik:RadNumericTextBox ID="txtMinAge" runat="server" MinValue="0" Width="150px" MaxValue="200">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" class="error"
                        ErrorMessage="Required" ControlToValidate="txtMinAge"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                <asp:Label ID="lblStep" runat="server" CssClass="Label_Font">How many years in an age-band</asp:Label>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="*"></asp:Label>
                </td>
                <td>
                    <telerik:RadNumericTextBox ID="txtStep" runat="server" MinValue="0" Width="150px" MaxValue="200">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Required" CssClass="error" ControlToValidate="txtStep"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                <asp:Label ID="lblLastAge" runat="server" CssClass="Label_Font">What is the last age in your last age-band</asp:Label>
                <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="Maroon" Text="*"></asp:Label>
                </td>
                <td>
                    <telerik:RadNumericTextBox ID="txtLastAge" runat="server" MinValue="50" Width="150px" MaxValue="200">
                <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
                </td>
                <td class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Required" CssClass="error" ControlToValidate="txtLastAge"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    &nbsp;&nbsp;<asp:Button ID="btnGenerate" runat="server" Text="Generate" 
                        onclick="btnGenerate_Click" />
                </td>
            </tr>
        </table>


        <table class="masterwidth">
            <tr>
                <td class="cvrgrow marginbottom5 paddingbottomm5 bottomline">
                    <asp:GridView ID="gvRates" runat="server" AutoGenerateColumns="False" CssClass="gridwidth"
                        OnRowCreated="gvRates_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="Age_Band" HeaderText="Age Band" />
                            <asp:BoundField DataField="AGE_RATE_DESCRIPTION" HeaderText="Age Band" />
                            <asp:BoundField DataField="Rate" HeaderText="Existing Rate" />
                            <asp:TemplateField HeaderText="New Rate"></asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="cvrgrow marginbottom5 paddingbottomm5 bottomline">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        Width="75px" CausesValidation="False" />
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="75px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
