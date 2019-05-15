<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Audit_Documents_list.Default" %>

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
                                                    <telerik:RadLabel ID="lblMsterAccount" runat="server" Font-Bold="True">Selected Master Account </telerik:RadLabel>
                                                </td>
                                                <td>
                                                    <telerik:RadDropDownList ID="ddlMaterAccounts" runat="server" AutoPostBack="True" CausesValidation="False" DefaultMessage="Master Account" Width="400px" CssClass="decorate" Skin="Bootstrap" OnSelectedIndexChanged="ddlMaterAccounts_SelectedIndexChanged">
                                                    </telerik:RadDropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1"></td>
                                                <td class="auto-style2">
                                                    <telerik:RadLabel ID="lblDays" runat="server" Font-Bold="True">Selected No Days Prio yp today </telerik:RadLabel>
                                                </td>
                                                <td class="auto-style1">
                                                    <telerik:RadDropDownList ID="ddlDays" runat="server" AutoPostBack="True" CausesValidation="False" DefaultMessage="Daus" Width="400px" CssClass="decorate" Skin="Bootstrap" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
                                                        <Items>
                                                            <telerik:DropDownListItem runat="server" Text="1  Day" Value="1" />
                                                            <telerik:DropDownListItem runat="server" Text="2  Days" Value="2" />
                                                            <telerik:DropDownListItem runat="server" Text="3  Days" Value="3" />
                                                            <telerik:DropDownListItem runat="server" Text="4  Days" Value="4" />
                                                            <telerik:DropDownListItem runat="server" Text="5  Days" Value="5" />
                                                            <telerik:DropDownListItem runat="server" Text="6  Days" Value="6" />
                                                            <telerik:DropDownListItem runat="server" Text="7  Days" Value="7" />
                                                            <telerik:DropDownListItem runat="server" Text="8  Days" Value="8" />
                                                            <telerik:DropDownListItem runat="server" Text="9  Days" Value="6" />
                                                            <telerik:DropDownListItem runat="server" Text="10  Days" Value="10" />
                                                            <telerik:DropDownListItem runat="server" Text="11  Days" Value="11" />
                                                            <telerik:DropDownListItem runat="server" Text="12  Days" Value="12" />
                                                            <telerik:DropDownListItem runat="server" Text="13  Days" Value="13" />
                                                            <telerik:DropDownListItem runat="server" Text="14  Days" Value="14" />
                                                            <telerik:DropDownListItem runat="server" Text="15  Days" Value="15" />
                                                            <telerik:DropDownListItem runat="server" Text="16  Days" Value="16" />

                                                            <telerik:DropDownListItem runat="server" Text="17  Days" Value="17" />
                                                            <telerik:DropDownListItem runat="server" Text="18  Days" Value="18" />
                                                            <telerik:DropDownListItem runat="server" Text="19  Days" Value="19" />
                                                            <telerik:DropDownListItem runat="server" Text="20  Days" Value="20" />
                                                            <telerik:DropDownListItem runat="server" Text="21  Days" Value="21" />
                                                            <telerik:DropDownListItem runat="server" Text="22  Days" Value="22" />
                                                            <telerik:DropDownListItem runat="server" Text="23  Days" Value="23" />

                                                            <telerik:DropDownListItem runat="server" Text="24  Days" Value="24" />
                                                            <telerik:DropDownListItem runat="server" Text="25  Days" Value="25" />
                                                            <telerik:DropDownListItem runat="server" Text="26  Days" Value="26" />
                                                            <telerik:DropDownListItem runat="server" Text="27  Days" Value="27" />
                                                            <telerik:DropDownListItem runat="server" Text="28  Days" Value="28" />
                                                            <telerik:DropDownListItem runat="server" Text="29  Days" Value="29" />
                                                            <telerik:DropDownListItem runat="server" Text="30  Days" Value="2" />
                                                        </Items>
                                                    </telerik:RadDropDownList>&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnGo" runat="server" Text="Show List" Height="30px" OnClick="btnGetEEs_Click" Visible="False"  />
                                                </td>
                                                <td class="auto-style1"></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="TitleLabel">
                                                    <telerik:RadLabel ID="blDivision" runat="server" Font-Bold="True">Selected Division </telerik:RadLabel>
                                                </td>
                                                <td>
                                                    <telerik:RadDropDownList ID="ddlItem" runat="server" AutoPostBack="true" CausesValidation="False" DefaultMessage="Division" Width="400px" CssClass="decorate" Skin="Bootstrap">
                                                    </telerik:RadDropDownList>&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnGetEEs" runat="server" Text="Show List" Height="30px" OnClick="btnGetEEs_Click"  />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            
                                            
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>


        <div style="width: 98%; height:40px; text-align: center; vertical-align: middle;float: left;" >
           <div style="margin-top: 15px">
           <telerik:RadLabel ID="lblOR" runat="server" Font-Bold="True" CssClass="pageTitle">OR </telerik:RadLabel>

              
           </div>
        </div>

        <%--<div style="width: 98%; height: 50px;float: left;">
            &nbsp;
        </div>--%>

        <div style="width: 98%; height:40px; margin-top: 20px;float: left;" class="LifeTable decorate">
            <div id="dvgetee" style="width: 150px; float: left;margin-top: 15px;margin-left:5px" runat="server">
                <telerik:RadLabel ID="lbGetEmployeeNumber" runat="server" Font-Bold="True">Selected Employee </telerik:RadLabel>
            </div>
            <div id="dvee" style="width: 250px; float: left;margin-top: 15px;" runat="server">
                <telerik:RadLabel ID="lblSelectedEmployee" runat="server"></telerik:RadLabel>
            </div>
            <div id="dvbtn" style="width: 100px; float: left;margin-top: 10px;" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Get Employee" OnClick="Button1_Click" />
            </div>
        </div>

        <div style="width: 98%; height: 20px;float: left;">
            &nbsp;
        </div>

        <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" Height="35px" OnButtonClick="RadToolBar1_ButtonClick" OnClientButtonClicking="ClientButtonClicking" Skin="MyEnrollStylesLite" EnableEmbeddedSkins="false" RenderMode="Lightweight">
                        <Items>
                            <telerik:RadToolBarButton CommandName="DOC" CheckOnClick="true" ImageUrl="Images/docx.png" BorderStyle="None" Enabled="false" Value="DOC" ToolTip="Export to DOC">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="CSV" CheckOnClick="true" ImageUrl="Images/csv.png" Enabled="false" Value="CSV" ToolTip="Export to CSV">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="XLSX" CheckOnClick="true" ImageUrl="Images/xlsx.png" Enabled="false" Value="XLSX" ToolTip="Export to XLSX">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="PDF" CheckOnClick="true" ImageUrl="Images/PDF-icon.png" Enabled="false" Value="PDF" ToolTip="Export to PDF">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="PagesAll" CheckOnClick="true" Visible="true" Value="PagesAll" Enabled="false">
                                <ItemTemplate>
                                    <div style="padding-right: 10px;">
                                        <asp:CheckBox ID="chkPagesAll" runat="server" Text="Export All Pages" Font-Size="XX-Small" Checked="true"></asp:CheckBox>
                                    </div>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true" Visible="true" Value="PagesSeparator">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="FrozenColumns" Text="FrozenColumns" Value="FrozenColumns">
                                <ItemTemplate>
                                    <div style="padding-left: 10px">
                                        <telerik:RadComboBox ID="cmbFrozenColumns" runat="server" AllowCustomText="true" AutoPostBack="true" Enabled="true" Width="120px"
                                            EmptyMessage="# of frozen columns..." OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                                        </telerik:RadComboBox>
                                        &nbsp;
                                    </div>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true" Visible="true" Value="RemovePagingSeparator">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="RemovePaging" CheckOnClick="true" Visible="true" Value="RemovePaging" Enabled="true">
                                <ItemTemplate>
                                    <div style="padding-right: 10px; padding-top: 5px">
                                        <asp:CheckBox ID="chkRemovePaging" runat="server" Text="Paging On" Font-Size="XX-Small" Height="5px"
                                            Checked="true" AutoPostBack="true" OnCheckedChanged="chkRemovePaging_CheckedChanged"></asp:CheckBox>
                                        &nbsp;
                                    </div>
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true" Visible="true" Value="ClearFilterSeparator">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton CommandName="ClearFilter" Enabled="false" Value="ClearFilter" ToolTip="Clear All Grid Filters" Width="16" Height="16">
                                <ItemTemplate>
                                    <div style="padding-left: 3px">
                                        <asp:ImageButton ID="btnClearFilter" runat="server" ImageUrl="Images/filter-delete-16x16.gif" Width="14px" Height="14px" OnClick="btnClearFilter_Click" Enabled="false" Visible="false"></asp:ImageButton>
                                        <telerik:RadToolTip RenderMode="Lightweight" ID="RadToolTip1" runat="server" TargetControlID="btnClearFilter" RelativeTo="Element" Text="Clear All Grid Filters" CssClass="tooltip"
                                            Position="BottomCenter" RenderInPageRoot="true" ManualClose="true">
                                        </telerik:RadToolTip>
                                    &nbsp;
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            
                            <telerik:RadToolBarButton IsSeparator="true" Visible="false">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Visible="false" Value="SelectedFilter">
                                <ItemTemplate>
                                    <div style="padding-left: 3px">
                                        <asp:Label runat="server" ID="lblSelectedFilter" Text="<font color='blue'><u>Selected Filter: </u></font>"></asp:Label>
                                        <telerik:RadToolTip RenderMode="Lightweight" ID="RadToolTipSelectedFilter" runat="server" TargetControlID="lblSelectedFilter" RelativeTo="Element" Text="Selected Filter Expression" CssClass="tooltip"
                                            Position="BottomCenter" RenderInPageRoot="true" ManualClose="true">
                                        </telerik:RadToolTip>
                                    &nbsp;
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true" Visible="false">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Visible="true" Value="DisplayHelp" ImageUrl="images/help_resized.png" OuterCssClass="rightButton" CommandName="DisplayHelp">
                            </telerik:RadToolBarButton>
                        </Items>
                    </telerik:RadToolBar>



        <div style="width: 98%; margin-top: 20px;float: left;" class="LifeTable decorate">
            <telerik:RadGrid ID="rgEEDoc" runat="server" OnNeedDataSource="rgEEDoc_NeedDataSource" Skin="Bootstrap" AutoGenerateColumns="False">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="View Document" 
                            FilterControlAltText="Filter column Add Date" 
                            HeaderText="Document" UniqueName="View_Document" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="employee_number" 
                            FilterControlAltText="Filter column column" 
                            HeaderText="ID No" UniqueName="column">
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Employee Name" 
                            FilterControlAltText="Filter column Employee Name" 
                            HeaderText="Employee" UniqueName="Employee">
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Dependent Name" 
                            FilterControlAltText="Filter column Dependent Name" 
                            HeaderText="Dependent" UniqueName="Dependent">
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Add By" 
                            FilterControlAltText="Filter column Add By" 
                            HeaderText="Received By" UniqueName="Add_By">
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Add Date" 
                            FilterControlAltText="Filter column Add Date" 
                            HeaderText="Received On" UniqueName="Add_Date">
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Status" 
                            FilterControlAltText="Filter column Add Date" 
                            HeaderText="Status" UniqueName="Status">
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </telerik:GridBoundColumn>

                        

                    </Columns>
                </MasterTableView>
                <HeaderStyle Font-Bold="True" />
            </telerik:RadGrid>
        </div>
         

    </form>
</body>
</html>
