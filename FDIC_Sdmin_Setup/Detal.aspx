<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detal.aspx.cs" Inherits="FDIC_Sdmin_Setup.Detal" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Life.css" rel="stylesheet" />
    <link href="Local.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <link href="NewSheet_No_Left.css" rel="stylesheet" />
    <style>
        a:link {
            color: #2F2F2F;
            text-decoration: underline;
            line-height: 16px;
        }

        a:visited {
            color: #2F2F2F;
            text-decoration: underline;
            line-height: 16px;
        }

        a:hover {
            color: #FFCC66;
            text-decoration: underline;
            line-height: 16px;
        }
        .auto-style1 {
            height: 37px;
        }
        .auto-style2 {
            font-weight: bold;
            color: #273473;
            height: 37px;
        }
    </style>

    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script>
            function ClientButtonClicking(sender, args) {
                <%--var commandName = args.get_item().get_commandName()
                if (commandName == "AccountSearch") {
                    args.set_cancel(true);
                    window.location = "/web_projects/Account_Number/default.aspx?SkipCheck=YES&goto=/web_projects/ReportGeneratorV1/ReportGenerator.aspx?SkipCheck=YES";
                }
                else if (commandName == "DisplayHelp") {
                    var page_id = "<%=PageHeaderID%>";
                    args.set_cancel(true);
                    MyPopUpWin('/web_projects/HelpSystem/DisplayHelp.aspx?SkipCheck=YES&page_id=' + page_id + '&from=2', 1200, 750);
                }
                else if (commandName == "PDF" || commandName == "CSV" || commandName == "XLSX" || commandName == "DOC" || commandName == "PagesAll" || commandName == "FrozenColumns" || commandName == "RemovePaging" || commandName == "Filters") {
                    document.getElementById("button_click").value = "true";
                    var ajaxManager = $find("<%=RadAjaxManager1.ClientID %>");
                    ajaxManager.set_enableAJAX(false);
                }--%>
            }
         </script>
    </telerik:RadScriptBlock>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" EnableEmbeddedSkins="False" Skin="Bootstrap"></telerik:RadSkinManager>
       
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="whirlyGig">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="Panel1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Panel1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

        <telerik:RadAjaxLoadingPanel ID="whirlyGig" runat="server" Skin="Bootstrap" Height="80%" Width="100%" Style="position: absolute; top: 92px; left: 8px;" IsSticky="true" />

      
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
        <asp:Panel ID="Panel1" runat="server">
        <table  class="LifeTable decorate" style="width: 98%;float: left;">
                                            <tr>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                                <td class=".lefTableCell">&nbsp;</td>
                                                <td class="rightTableCell">&nbsp;</td>
                                                <td class="leftRightTableCell">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="TitleLabel">
                                                    <telerik:RadLabel ID="lblMsterAccount" runat="server" Font-Bold="True">Selected Administrator </telerik:RadLabel>
                                                </td>
                                                <td>
                                                    <telerik:RadDropDownList ID="ddlAdmin" runat="server" AutoPostBack="True" CausesValidation="False" DefaultMessage="Administrators" Width="400px" CssClass="decorate" Skin="Bootstrap" OnSelectedIndexChanged="ddlMaterAccounts_SelectedIndexChanged">
                                                    </telerik:RadDropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1"></td>
                                                <td class="auto-style2">
                                                    <telerik:RadLabel ID="lblDays" runat="server" Font-Bold="True">Enter Organizational Code </telerik:RadLabel>
                                                </td>
                                                <td class="auto-style1">
                                                    <telerik:RadTextBox ID="txtOrg" Runat="server" Width="400px" CssClass="decorate" EmptyMessage="Organizational Code" Skin="Bootstrap">
                                                    </telerik:RadTextBox>
                                                    &nbsp;
                                                    <asp:Button ID="btnGo" runat="server" Text="Show List" Height="30px" OnClick="btnCreate_Click"  />
                                                </td>
                                                <td class="auto-style1"></td>
                                            </tr>
                                            
                                            
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>


        

        <%--<div style="width: 98%; height: 50px;float: left;">
            &nbsp;
        </div>--%>

        

        <div style="width: 98%; height: 20px;float: left;">
            &nbsp;
        </div>

        
        <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/Excel_HTML.png"
            OnClick="ImageButton_Click" AlternateText="Html" />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="Images/Excel_ExcelML.png"
            OnClick="ImageButton_Click" AlternateText="ExcelML" />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="Images/Excel_BIFF.png"
            OnClick="ImageButton_Click" AlternateText="Biff" />
        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="Images/Excel_XLSX.png"
            OnClick="ImageButton_Click" AlternateText="Xlsx" />
    </div>


        <div style="width: 98%; margin-top: 20px;float: left;" class="LifeTable decorate">
           <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server"  AllowPaging="True"
            PageSize="7" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated"
            OnItemCreated="RadGrid1_ItemCreated" OnHTMLExporting="RadGrid1_HtmlExporting" OnItemCommand="RadGrid1_ItemCommand"
            OnBiffExporting="RadGrid1_BiffExporting" OnNeedDataSource="RadGrid1_NeedDataSource">
               <GroupingSettings CollapseAllTooltip="Collapse all groups" />
            <MasterTableView CommandItemDisplay="Top">
               
                    <Columns>

                    </Columns>
                </MasterTableView>
                <HeaderStyle Font-Bold="True" />
               <FilterMenu RenderMode="Lightweight">
               </FilterMenu>
               <HeaderContextMenu RenderMode="Lightweight">
               </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
         <div class="Entry_Row fontsmall" style="margin-top: 15px">
            <asp:Button ID="btnBack" runat="server" text="Return" OnClick="btnBack_Click"   />
        
        </div>
</asp:Panel>
    </form>
</body>
</html>
