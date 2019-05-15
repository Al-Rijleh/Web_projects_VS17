<%@ Page Language="c#" CodeBehind="SupervisorDecline.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.SupervisorDecline" ValidateRequest="false" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Supervisor Decline Request</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Expires" content="-1">
    <script src="/js/dFilter.js" type="text/javascript"></script>
    <link href="/styles/Main.css" type="text/css" rel="stylesheet">
    <script src="/js/StyleSetter.js" type="text/javascript"></script>
    <script src="/js/BAS_Utility.js" type="text/javascript"></script>
    <script>
        function RemainingLetters(txtfld, countername) {
            currentStr = txtfld.value;
            currentLength = currentStr.length;
            document.getElementById(countername).value = 3000 - currentLength;
        }
        function popup(url1, height1, width1) {
            tmp = window.open(url1, '', 'status=1,scrollbars=1,toolbar=0,location=0,height=' + height1 + ',width=' + width1);
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table class="fontsmall" id="Table1" style="z-index: 101; left: 5px; position: absolute; top: 5px"
            cellspacing="0" cellpadding="0" width="790" border="0">
            <tr>
                <td valign="top">
                    <table class="fontsmall" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">


                        <tr>
                            <td width="150">
                                <asp:Label ID="lblCourceName" runat="server" Font-Bold="True">Training Requested</asp:Label></td>
                            <td>
                                <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="txtMemo" runat="server" Width="56px" Height="20px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-top: silver thin solid" valign="top" id="q">&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lbl_fldPla_ApprovalSupervisorDoDecline" runat="server">To finalize your declining payment of the expenses for the above captioned training, click
									<b>Save</b>; otherwise, 
								click <b>Cancel</b><br><br></asp:Label></td>
                <tr>
                    <td height="1%">
                        <table class="fontsmall" id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td valign="top" width="20%" height="15"></td>
                                <td valign="top" height="15">
                                    <asp:LinkButton ID="lnkbtnManageReasons" runat="server" CssClass="actbtn_go_next_button">Manage Reasons</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td valign="top" width="20%" height="5"></td>
                                <td valign="top" height="5"></td>
                            </tr>
                            <tr>
                                <td valign="top" width="20%" height="170">
                                    <asp:Label ID="Label4" runat="server">Reason for Denial</asp:Label></td>
                                <td height="170" valign="top">
                                    <div style="overflow: auto; width: 100%; position: relative; height: 100%; text_aligh: left"
                                        align="left">
                                        <asp:CheckBoxList ID="chklstReasons" runat="server" CssClass="fontsmall" Width="100%" Height="100%"
                                            BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label26" runat="server">Maximum 3000 Character</asp:Label>
                                    <asp:Label ID="Label27" runat="server">Remaining</asp:Label>
                                    <asp:TextBox ID="txtCounter" runat="server" Width="40px" BorderStyle="None" BorderColor="White">3000</asp:TextBox>
                                    <asp:Label ID="lblScript" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label5" runat="server">Other Reason for Denial</asp:Label><br>
                                    &nbsp;<br>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOther" runat="server" onkeyup="RemainingLetters(this,'txtCounter')" CssClass="fontsmall"
                                        Width="98%" TextMode="MultiLine" Height="40px" MaxLength="3000"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            <tr>
                <td height="1%">
                    <div>
                        <div style="float: left">
                            <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="btnSave_Click"
                                Text="Save" ToolTip="Save decision  and exit" Width="75px" />&nbsp;<asp:Button ID="btnCancel"
                                    runat="server" CssClass="fontsmall" OnClick="btnCancel_Click" Text="Cancel" ToolTip="Exit without saving"
                                    Width="75px" CausesValidation="False" />
                        </div>
                        <div style="float: right; margin-right: 10px">
                            <asp:Button ID="Button1" runat="server" Text="Override Denial and Approve Application " OnClick="Button1_Click" />
                        </div>

                    </div>
                </td>
            </tr>
        </table>
        &nbsp;
    </form>
    <p>
        g</p>
</body>
</html>
