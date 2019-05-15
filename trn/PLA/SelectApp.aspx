<%@ Page Language="c#" Codebehind="SelectApp.aspx.cs" AutoEventWireup="false" Inherits="Training_Source.SelectApp" %>

<%@ Register TagPrefix="cc1" Namespace="Karamasoft.WebControls" Assembly="UltimateMenu" %>
<%@ Register TagPrefix="cc2" Namespace="Karamasoft.WebControls" Assembly="UltimatePanel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Select Application</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />

    <script src="/js/dFilter.js" type="text/javascript"></script>

    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <script type="text/javascript">
			function popup(url1,height1,width1)
            {				
				tmp=window.open(url1,'','status=0,scrollbars=0,resizable=1, toolbar=0,location=0,height=' + height1 + ',width=' + width1);
            }
            function GoBack()
            {
				window.location.href='SelectAccountCategory.aspx';
            }
            function mandatoryOnly(msg)
            {
            //  alert(msg);
              window.location.href='SelectApp.aspx';
            }
            function FDICEESearch()
            {
              alert('FDICEESearch');
            }
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <table id="Table" style="z-index: 100; left: 0px; position: absolute; top: 0px" height="98%"
        cellspacing="0" cellpadding="0" width="795" border="0">
        <tr>
            <td background="/karama/Images/WinSubTab.gif">
            </td>
            <td background="/karama/Images/WinSubTab.gif" style="width: 786px">
            </td>
        </tr>
        <tr valign="top" height="1%">
            <td>
            </td>
            <td style="width: 786px">
            </td>
            <tr>
                <td width="10">
                    &nbsp;</td>
                <td style="width: 786px">
                    <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></td>
            </tr>
        <tr valign="top" height="98%">
            <td valign="top">
            </td>
            <td valign="top" style="width: 786px">
                <form id="Form1" method="post" runat="server">
                    <table class="fontsmall" id="Table1" height="100%" cellspacing="0" cellpadding="0"
                        width="100%" border="0">
                        <tr>
                            <td style="border-bottom: silver thin solid" valign="top" height="1%">
                                <table class="fontsmall" id="Table2" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tr>
                                        <td width="220" height="1">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True">Remaining Budget For: </asp:Label>:
                                            <asp:DropDownList ID="ddlBudgetYear" runat="server" Width="60px" CssClass="fontsmall"
                                                AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td height="1">
                                            <asp:Label ID="lblBalance" runat="server" Font-Bold="True"></asp:Label>
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblCPBudget" runat="server" Font-Bold="True" Visible="False">View Competitive Program Budget</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" height="60%">
                                <table class="fontsmall" id="Table3" height="100%" cellspacing="0" cellpadding="0"
                                    width="100%" border="0">
                                    <tr>
                                        <td width="20%" style="height: 5%">
                                            <asp:Label ID="lbl_fldTrainingSelectApp" runat="server">To add a new training request, click on the 
<b>Add New Training Request</b> link below.  To Select a training, choose an option in the Action column drop down and click on the 
<b>Go</b> button</asp:Label></td>
                                    </tr>
                                    <tr id="trNoAccess" runat="server" visible ="false">
                                        <td style="border-right: maroon 1px solid; padding-right: 10px; border-top: maroon 1px solid;
                                            padding-left: 10px; padding-bottom: 10px; border-left: maroon 1px solid; color: maroon;
                                            padding-top: 10px; border-bottom: maroon 1px solid; background-color: White;
                                            height: 137px;">
                                            
                                            <asp:Label ID="lblUneligible" runat="server" ></asp:Label>
                                            
                                            <asp:Button ID="btnPlaEligible" runat="server" OnClick="btnPlaEligible_Click" Style="margin-left: auto;
                                                margin-right: auto" Text="Click here if you believe you are PLA eligible " /></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="5%" align="center">
                                            &nbsp;<asp:Label ID="lblWarningNeedCDP" runat="server" Font-Bold="True" CssClass="fontsmall"
                                                ForeColor="Maroon" Visible="False">You can’t apply for any request until you have an approved CDP.</asp:Label>
                                            <asp:Label ID="lblScript" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="5%">
                                            <asp:LinkButton ID="lnkbtnNewRequest" runat="server" CssClass="fontsmall">(Add New Training Request)</asp:LinkButton>&nbsp;&nbsp;
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkbtnAddBookRequest" runat="server" CssClass="fontsmall" OnClick="lnkbtnAddBookRequest_Click">(New TRAINING Book and/or Study  Materials )</asp:LinkButton>
                                            <asp:Label ID="lblNew" runat="server" BackColor="Yellow" CssClass="fontsmall" Font-Bold="True"
                                                Font-Italic="True" ForeColor="Red" Text="(New)"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td width="20%" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <asp:DataGrid ID="dgApp" runat="server" CellPadding="3" CssClass="fontsmall" AutoGenerateColumns="False"
                                                Width="100%">
                                                <SelectedItemStyle BackColor="Khaki"></SelectedItemStyle>
                                                <AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
                                                <ItemStyle BackColor="White"></ItemStyle>
                                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#505050"></HeaderStyle>
                                                <Columns>
                                                    <asp:BoundColumn DataField="course_code" HeaderText="Course&lt;br&gt;Code"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="course_title" HeaderText="Title"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="begin_date" HeaderText="Start Date"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="end_date" HeaderText="End Date"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="description" HeaderText="Status"></asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Action">
                                                        <HeaderStyle Width="250px" />
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10%">
                                <asp:Button ID="btnBack" runat="server" CssClass="fontsmall" OnClick="btnBack_Click"
                                    Text="Return to PLA Home" Visible="False" /></td>
                        </tr>
                    </table>
                </form>
            </td>
        </tr>
    </table>

    <script>setLocalElementsStyleClass (Get_Cookie('ClassName'));</script>

    </body>
<%--<HEAD>
     <META HTTP-EQUIV="PRAGMA" CONTENT="NO-CACHE">
   </HEAD>	--%>
</html>
