<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee_Search.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Search</title>
    <link href="Layout.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <style type="text/css">
        div.RadToolTip_Default table.rtWrapper td.rtWrapperContent
    {
        background-color: #fdfdfd !important;
    }
        .error
        {
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
        .style1
        {
            height: 18px;
        }
        .BackG
        {
            background-color: #FFF4CD !important;
        }
        
        .style2
        {
            height: 42px;
        } 
        .LeftTitle
        {
            width:70px;
            float: left; 
        }    
          
        .RadGrid .rgSelectedRow
        {
            background-image : none !important;
            background-color: lightgreen !important;
        }

        .RadGrid .rgHoveredRow
         {
           background:#7FFFD4 !important;/*/Try setting background to get the desired hover color*/
         }

    </style>

    <%--<style type="text/css" >
        body{
            background-image: url('https://www.myenroll.com/img/MyEnrollBlueGradient2.png'); 
            background-repeat: repeat-x;                        
        }
    </style>--%>

    <style type="text/css" >
        body{            
           /* height: 100px;
            background: red;*/ /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(#9eb4c0, #ffffff); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(#9eb4c0, #ffffff); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(#9eb4c0, #ffffff); /* For Firefox 3.6 to 15 */
            background: linear-gradient(#9eb4c0, #ffffff); /* Standard syntax (must be last) */    
            background-repeat:no-repeat;  
            background-size:100% 100px;            
        }
 </style>

    <script type="text/javascript">
        function RunBack(surl) {
            //alert(surl);
            window.open(surl, "_top");
            //window.top.open(surl);
            //window.open(surl);
        }

        function OpenHeader(url) {
            try { url } catch (err) { }
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />

        <telerik:RadToolTip ID="RadToolTip2" runat="server" HideEvent="ManualClose" Position="BottomRight"
            Skin="Default" TargetControlID="lblInstruction" BackColor="#CCCCCC" Height="300px" Width="500px" ContentScrolling="Auto">
        </telerik:RadToolTip>

        <%--<telerik:RadToolTip ID="RadToolTip1" runat="server" HideEvent="ManualClose" Position="BottomRight"
            Skin="Default" TargetControlID="imgInstruction" BackColor="#CCCCCC" Height="300px" Width="500px" ContentScrolling="Auto">
        </telerik:RadToolTip>--%>

        <telerik:RadToolTip ID="RadToolTip3" runat="server" HideEvent="ManualClose" Position="BottomRight"
            Skin="Default" TargetControlID="imgDefaultSearchHelp" BackColor="#CCCCCC" Height="350px" Width="500px" ContentScrolling="Auto">
        </telerik:RadToolTip>



        <asp:HiddenField ID="hid2" runat="server" />
         <asp:HiddenField ID="hid3" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <div class="outRow ">
            <%--Title--%>
            <div class="Row marginbottom02">
                <div style="float: left; width: 140px;">
                    <asp:Label ID="lblTitle" runat="server" Text="Employee Search" CssClass="pageTitle"> </asp:Label>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                

                <div style="float: left; width: 70px;">
                       <asp:Image ID="imgDefaultSearchHelp" runat="server" ImageUrl="~/img/question_icon.png" />
                    <asp:Label ID="lblInstruction" runat="server" Text="Instruction" CssClass="FontSmall10 FontBold" ForeColor="#336699" ToolTip="Coming Soon" Font-Underline="False" Visible="False"></asp:Label>
                </div>

                <div style="float: left; margin-top: 2px;">
                </div>
            </div>
            
            <div class="Row marginbottom02">
                <%--Selectin Criteria Titles--%>
                <div class="Row">
                    <div class="LeftTitle">
                        &nbsp;
                    </div>
                    <div style="float: left; width: 120px; text-align: left">
                        <asp:Label ID="lblEEStatus" runat="server" CssClass="textFont" Text="Employee Status"></asp:Label>
                    </div>
                    <div style="float: left; width: 120px; text-align: left">
                        <asp:Label ID="lblaccount_location" runat="server" CssClass="textFont" Text="Account/Locations"></asp:Label>
                    </div>
                    <div style="float: left; width: 120px; text-align: left">
                        <asp:Label ID="lblBenefitsClass" runat="server" CssClass="textFont" Text="Benefits Class"></asp:Label>
                    </div>

                    <div style="float: left; width: 131px; text-align: left">
                       

                        <asp:Label ID="lblBenefitEligibility" runat="server" CssClass="textFont" Text="Benefits Eligibility (B.E.)"></asp:Label>

                    </div>

                </div>


                <telerik:radpagelayout id="RadPageLayout1" runat="server" gridtype="Fluid">
                    <Rows>
                <telerik:LayoutRow>
                    <Content>
                <div class="Row marginbottom01">
                    <div class="LeftTitle">
                        <asp:Label ID="lblEESearch" runat="server" CssClass="lblTitleText" Text="Filter"></asp:Label>
                    </div>
                    <div style="float: left; width: 120px; text-align: left">
                        <telerik:RadComboBox ID="ddlEmployeeStatus"
                            runat="server" EmptyMessage="Please select..." MarkFirstMatch="True"
                            Width="110px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="All" Value="1" Selected="True"/>
                                <telerik:RadComboBoxItem runat="server" Text="Active" Value="0" />                               
                                <telerik:RadComboBoxItem runat="server" Text="COBRA/COC" Value="3" />
                                <telerik:RadComboBoxItem runat="server" Text="Terminated" Value="2" />
                            </Items>
                        </telerik:RadComboBox>
                    </div>
                    <div style="float: left; width: 120px; text-align: left">
                        <telerik:RadComboBox ID="ddlaccount_location" AutoPostBack="false"
                            runat="server" EmptyMessage="Please select..." MarkFirstMatch="True" Skin="Default"
                            Width="110px" DropDownWidth="300px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="All" Value="0" />                                
                            </Items>
                        </telerik:RadComboBox>
                    </div>
                    <div style="float: left; width: 120px; text-align: left">
                        <telerik:RadComboBox ID="ddlBenefitsClass" AutoPostBack="false"
                            runat="server" EmptyMessage="Please select..." MarkFirstMatch="True" Skin="Default"
                            Width="110px" DropDownWidth="300px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="All" Value="0" />                                
                            </Items>
                        </telerik:RadComboBox>
                    </div>

                    <div style="float: left; width: 120px; text-align: left">
                        <telerik:RadComboBox ID="ddlEligibility"
                            runat="server" EmptyMessage="Please select..." MarkFirstMatch="True"
                            Width="110px" DropDownWidth="300px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="All" Value="2" Selected="True" />                                
                                <telerik:RadComboBoxItem runat="server" Text="Benefit Eligible" Value="1" />
                                <telerik:RadComboBoxItem runat="server" Text="Benefit Ineligible " Value="0" />
                            </Items>
                        </telerik:RadComboBox>
                    </div>







                    <div style="float: left; width: 139px; text-align: left">
                        
                        <table>
                            <tr>
                                <td>&nbsp;
                                    <asp:CheckBox ID="cbDefaultSearch" runat="server" Enabled="False" />
                                </td>
                                <td>
                                    <asp:Label ID="cbLabel" runat="server" Text="My Default Search"></asp:Label>
                                </td>

                            </tr>
                        </table>
                  </div>
                    <div style="margin-top: 5px">
                    </div>
                </div>

</Content>
                </telerik:LayoutRow>
            </Rows>
 </telerik:radpagelayout>








                <%--Saved Selections--%>
                <div class="Row marginbottom01" id="dvEEs" runat="server">
                    <div class="LeftTitle">
                            <asp:Label ID="lblRecent" runat="server" CssClass="lblTitleText" Text="Recent"></asp:Label>
                    </div>
                    <div style="float: left; width: 640px; text-align: left">
                        <asp:RadioButtonList ID="rblSelectedEEs" runat="server" RepeatDirection="Horizontal" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="rblSelectedEEs_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Don&#39;t Use</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--Search Button--%>
                <div class="Row marginbottom02">
                    <div class="LeftTitle">
                        <asp:Label ID="lblEmployee" runat="server" CssClass="lblTitleText" Text="Employee"></asp:Label>
                    </div>
                    <div style="float: left; width: 640px; text-align: left">
                        <div style="float: left; width: 240px; text-align: left">
                            <telerik:RadTextBox ID="txtSearch" runat="server" Width="230px" EmptyMessage="Options: Last Name, First Name; Soc. Sec. No.; MyEnroll ID#; or Email"></telerik:RadTextBox>
                        </div>
                        <div style="float: left; width: 120px; text-align: left;margin-left:3px">
                            <telerik:RadButton ID="btnSearch" runat="server" Text="Search" Width="100px" Style="top: 0px; left: 1px" OnClick="btnSearch_Click"></telerik:RadButton>
                        </div>
                    </div>
                </div>
                <div class="Row marginbottom02">
                    <telerik:RadGrid ID="dgEEs" runat="server" OnNeedDataSource="RadGrid1_NeedDataSource"
                    AutoGenerateColumns="False" OnItemCommand="rgHeader_ItemCommand" GroupPanelPosition="Top" AllowSorting="True" AllowFilteringByColumn="True" AllowPaging="True" >
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                        
<ClientSettings EnableRowHoverStyle="true">
</ClientSettings>

                    <MasterTableView DataKeyNames="Record_Id" AllowMultiColumnSorting="True" GroupLoadMode="Server"
                        NoDetailRecordsText="No records to display." ShowHeader="true" AllowSorting="False">
                        <NestedViewTemplate>
                            <telerik:RadGrid ID="rgDetal" runat="server" Skin="Default" ShowHeader="False">
                                <ItemStyle CssClass="BackG" />
                            </telerik:RadGrid>
                        </NestedViewTemplate>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="record_id" FilterControlAltText="Filter column column"
                                HeaderText="record_id" UniqueName="column" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Benefit Eligible" FilterControlAltText="Filter column5 column" 
                                HeaderText="B.E." UniqueName="column5" FilterControlWidth="50px">
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="employee_name_link" FilterControlAltText="Filter column1 column"
                                HeaderText="Employee" UniqueName="column1">
                                <HeaderStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EmployerOnly" FilterControlAltText="Filter column2 column"
                                HeaderText="Location" UniqueName="column2">
                                <HeaderStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Client ID" FilterControlAltText="Filter column6 column" 
                                HeaderText="Client ID" UniqueName="column6" FilterControlWidth="50px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CityState" FilterControlAltText="Filter column3 column"
                                HeaderText="City, State" UniqueName="column3" FilterControlWidth="100px">
                                <HeaderStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Formated_Status" FilterControlAltText="Filter column4 column"
                                HeaderText="Status" UniqueName="column4" FilterControlWidth="100px">
                                <HeaderStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <HeaderStyle HorizontalAlign="Center" />
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                </div>

                <div class="Row marginbottom02">
                    <telerik:RadButton ID="btnClose" runat="server" Text="Close" CausesValidation="False" OnClick="btnClose_Click"></telerik:RadButton>
                </div>

            </div>
        </div>
    </form>
    <script  type="text/javascript">
        function Select(ee) {
            document.getElementById('hid3').value = ee;
            document.getElementById('dgEEs').style.display = "none";            
            __doPostBack(null, null);

        }


        function Highlight(row) {
            row.style.backgroundColor = '#FFFFCC';
        }
        function UnHighlight(row) {
            row.style.backgroundColor = 'white';
        }

        function Finish(stBarName, strpy, retURL) {
            $(document).ready(function () {                
                try { window.open('/web_projects/ptemplate/top.aspx?session=YES&code=0', 'Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame'); } catch (err) { }
                try { window.open('/web_projects/ptemplate/Alert_Notes.aspx', 'MyEnroll_Alert_Notes_Menu_frame'); } catch (err) { }
                try { window.top.setactivemenu(1); } catch (err) { }
                try { window.top.setToolButtonText("'" + stBarName + "'"); } catch (err) { }
                try { window.top.restProcessingYear('2017','2015','2017'); } catch (err) { }               
                window.open(retURL, '_self');
                // window.location.href = retURL;
            })

            
        }
       
    </script>
</body>
</html>
