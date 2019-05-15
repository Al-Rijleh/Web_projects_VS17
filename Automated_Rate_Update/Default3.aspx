<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default3.aspx.cs" Inherits="Automated_Rate_Update.Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Layout.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <style type="text/css">
        div.RadToolTip_Default table.rtWrapper td.rtWrapperContent {
            background-color: #fdfdfd !important;
        }

        .error {
            font-family: Arial, Sans-Serif;
            font-size: 10pt;
            font-weight: bold;
            color: Maroon;
            background-color: Yellow;
            border-top-width: 1px;
            border-left-width: 1px;
            border-left-color: #000000;
            border-bottom-width: 1px;
            border-bottom-color: #000000;
            border-top-color: #000000;
            border-right-width: 1px;
            border-right-color: #000000;
        }

        .InfoBKGround {
            background-color: #C6D3DA;
        }

        .style1 {
            height: 18px;
        }

        .BackG {
            background-color: #FFF4CD !important;
        }

        .style2 {
            height: 42px;
        }

        .LeftTitle {
            width: 70px;
            float: left;
        }

        .RadGrid .rgSelectedRow {
            background-image: none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow {
            background: #7FFFD4 !important;
            /*Try setting background to get the desired hover color;*/
        }

        .myfontx {
        font-size: 9pt !important;
        font-weight:bold !important;
        color:blue !important;
        margin-left:3px;
        text-decoration: none;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hidId" runat="server" />
    <div>
       <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="105px" Width="805px" LoadingPanelID="RadAjaxLoadingPanel1">
                <div class="Row marginbottom02" id="dvfilter" runat ="server" >
                    <div class="Row" style="margin-top: 10px; margin-bottom:10px">
                 <hr />
             </div>
                    <%--Selectin Criteria Titles--%>
                    <div class="Row">
                        <div class="LeftTitle" id="dvFilter">
                        </div>
                    </div>

                    <div class="Row" id="dvStatus" runat="server" >
                        <div class="LeftTitle">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 120px; text-align: left">
                            <asp:Label ID="lblClassess" runat="server" CssClass="textFont" Text="Class Codes"></asp:Label>
                        </div>
                        <div style="float: left; width: 220px; text-align: left; height: 25px;">
                            <telerik:RadComboBox ID="ddlClassCodes" AutoPostBack="True"
                                runat="server" EmptyMessage="Please select..." MarkFirstMatch="True"
                                Width="200px" DropDownWidth="300px" Enabled="False">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="Active" Value="1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Terminated" Value="2" />
                                    <telerik:RadComboBoxItem runat="server" Text="All" Value="0" />
                                </Items>

                            </telerik:RadComboBox>
                        </div>
                    </div>

                    <div class="Row" id="dvProgramType" runat="server">
                        <div class="LeftTitle">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 120px; text-align: left">
                            <asp:Label ID="ddlVoverageTypes" runat="server" CssClass="textFont" Text="Coverage Types"></asp:Label>
                        </div>
                        <div style="float: left; width: 220px; text-align: left; height: 25px;">
                            <telerik:RadComboBox ID="ddlProgramType"
                                runat="server" EmptyMessage="Please select..." MarkFirstMatch="True"
                                Width="200px" AutoPostBack="True">
                            </telerik:RadComboBox>
                        </div>
                    </div>

                    








                    <div class="Row" id="dvMaster" runat="server">
                        <div class="LeftTitle">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 120px; text-align: left">
                            <asp:Label ID="tbCoveragePlans" runat="server" CssClass="textFont" Text="Coverage Plans"></asp:Label>
                        </div>
                        <div style="float: left; width: 220px; text-align: left; height: 25px;">
                            <telerik:RadComboBox ID="ddlMasterAccount" AutoPostBack="True"
                                runat="server" EmptyMessage="Please select..." MarkFirstMatch="True" Skin="Default"
                                Width="200px" DropDownWidth="300px">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    





                </div>

            </telerik:RadAjaxPanel> 
    </div>
    </form>
</body>
</html>
