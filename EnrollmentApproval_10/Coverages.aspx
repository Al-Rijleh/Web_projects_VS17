<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Coverages.aspx.cs" Inherits="EnrollmentApproval.Coverages" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Stylesheet1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript"">
        function ShowGrid(id) {
            var hidControl = eval(document.getElementById('hidIDLast')).value
            if (hidControl == id)
                return;
            eval(document.getElementById('hidID')).value = id;
            alert(eval(document.getElementById('hidID')).value);
            PostBack();

        }

        function verify(msg, id) {
            if (confirm(msg)) {
                document.getElementById('hidDecline').value = id;
                PostBack();
            }
        }

        function PostBack() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" skin="Bootstrap"/> 
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
            <div class="FullPage" style="border-bottom: silver 1px solid; text-align: left">
                <asp:Label ID="lblTitle" runat="server" Text="Process Pending Coverages" CssClass="FontMedium"
                    Font-Bold="True"></asp:Label>
                <asp:Label ID="lblRemaining" runat="server" Text="Remaining:"></asp:Label>
                <asp:Label ID="lblNo" runat="server"></asp:Label>
                <asp:HiddenField ID="hidDecline" runat="server" />
            </div>

        <div class="FullPage" style="border-bottom: silver 1px solid; text-align: left">

            <div id='dvLeft' runat="server" class="LeftColumn decorate" style="border-right: silver 1px solid; z-index:10000" align="left">
                <%--<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px; text-align: left" align="left">--%>
                <telerik:RadGrid ID="rgEmployees" runat="server" AllowFilteringByColumn="True" AllowSorting="True"
                    AutoGenerateColumns="False" GridLines="None" OnItemCommand="rgEmployees_ItemCommand"
                    OnNeedDataSource="rgEmployees_NeedDataSource" Skin="">
                    <MasterTableView>
                        
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" DataTextField="employee_number" HeaderText="BAS #"
                                UniqueName="column1">
                                <ItemStyle Font-Underline="True" />
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Employee Name" UniqueName="column">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                </telerik:RadGrid>
                
                <div class="LeftColumn" >
                    <asp:Label ID="lblNoRecords" runat="server" Text="There is no pending records to process. " CssClass="FontSmall" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>                
                </div>
                
                </div>
            <%-- </div>--%>
            <div id='dvRight' runat="server" class="RightColumn">
                <div class="RightColumnin">
                    <asp:Label ID="lblName" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>                    
                </div>
                <div class="RightColumnin">
                    <asp:GridView ID="gvCvrg" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        OnRowCreated="gvCvrg_RowCreated" Width="500px" CellPadding="4" ForeColor="#333333"
                        GridLines="None" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="long_description" HeaderText="Plan Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Benefit Level">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Effective Date"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
                <div class="RightColumnin">
                    <asp:Label ID="lblDenentsList" runat="server" Text="List of depenednt(s) who will be assigned the selected coverage"
                        CssClass="FontSmall" Font-Bold="True" ForeColor="#804040" Visible="False"></asp:Label>
                </div>
                <div class="RightColumnin">
                    <asp:GridView ID="gvDepCvrg" runat="server" Width="500px" AutoGenerateColumns="False"
                        CssClass="FontSmall" CellPadding="4" ForeColor="#333333" GridLines="None"
                        BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="long_description" HeaderText="Benefit Name">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dep_name" HeaderText="Dependent">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="relation" HeaderText="Relationship">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="eligible" HeaderText="Eligible for Coverage">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Remove" Visible="False"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" Visible="False"></asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </div>
                <div class="RightColumnin" style="height: 10px">
                    &nbsp;
                </div>
                <div class="RightColumnin">
                    <asp:Label ID="lblStrike" runat="server" CssClass="FontSmall" Font-Bold="False" Visible="False">Disabled and Struck through employee names, indicate that these employees have pending   dependents. You have to processes the pending dependents of these employees before you can process their coverages. </asp:Label>
                </div>
                <div class="RightColumnin" style="height: 10px">
                    &nbsp; &nbsp;&nbsp;</div>
                <div class="RightColumnin">
                    <asp:Button 
                        ID="btnBack" runat="server" CssClass="FontSmall" Text="Home" Width="75px" 
                        onclick="btnBack_Click" Visible="False" />
                    <asp:Button ID="btnNext" runat="server" CssClass="FontSmall" Enabled="False" 
                        Text="Next" Width="75px" onclick="btnNext_Click" Visible="False" />
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>