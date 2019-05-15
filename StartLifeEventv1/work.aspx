<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="work.aspx.cs" Inherits="StartLifeEventv1.work" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Life.css" rel="stylesheet" />
    <link href="NewSheet_No_Left.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

       <%--<telerik:RadToolTip ID="RadToolTip2" runat="server" HideEvent="ManualClose" Position="BottomRight"
            Skin="Default"  BackColor="#CCCCCC" Height="150px" Width="100" ContentScrolling="Auto" TargetControlID="Label1, Label2">
        </telerik:RadToolTip>--%>

        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" HideEvent="ManualClose" Position="BottomRight"  BackColor="#CCCCCC" Height="300px" 
            Width="300px" ContentScrolling="Auto" ManualClose="True">
            <TargetControls>
                <telerik:ToolTipTargetControl IsClientID="False" TargetControlID="Label1" Value="" />
                <telerik:ToolTipTargetControl IsClientID="False" TargetControlID="Label2" Value="" />
            </TargetControls>

        </telerik:RadToolTipManager>

        <asp:Label ID="Label1" runat="server" Text="ample Test Sample Test Sample"
            ToolTip="	Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test "></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="ample Test Sample Test Sample"
            ToolTip="	Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test Sample Test "></asp:Label>
        <table class="FullPage" cellspacing="0" cellpadding="2" style="width: 800px; margin-top: 10px; margin-bottom: 10px;" runat="server" visible="false">
                                                                <%--<tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td style="border-style: solid; border-width: 1px; width: 399px; border-color: #000000">
                                                                        <asp:Label ID="lblUploadTitle" runat="server" Text="Upload" CssClass="dataSubSetctionTitle"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 399px; border-top-style: solid; border-top-width: 1px; border-right-style: solid; border-bottom-style: solid; border-top-color: #000000; border-right-color: #000000; border-bottom-color: #000000; border-right-width: 1px; border-bottom-width: 1px;">
                                                                        <asp:Label ID="lblFaxTitle" runat="server" Text="Fax" CssClass="dataSubSetctionTitle"></asp:Label>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td style="width: 399px; border-bottom-style: solid; border-bottom-width: 1px; border-color: #000000; border-right-style: solid; border-right-width: 1px; border-color: #000000; border-left-style: solid; border-left-width: 1px; border-color: #000000">
                                                                       &nbsp;
                                                                    </td>
                                                                    <td style="width: 399px; border-bottom-style: solid; border-bottom-width: 1px; border-color: #000000; border-right-style: solid; border-right-width: 1px; border-color: #000000;">

                                                                        &nbsp;
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>

                                                                <%--<tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>--%>
                                                            </table>
                               
                                
    </form>
</body>
</html>
