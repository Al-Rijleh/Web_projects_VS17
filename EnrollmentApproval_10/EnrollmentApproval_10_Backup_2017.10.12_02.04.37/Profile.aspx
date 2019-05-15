<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EnrollmentApproval.Profile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="Tab.ascx" tagname="Tab" tagprefix="uc1" %>

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

    function PostBack() {
        var theForm = document.forms['aspnetForm'];
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
        
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    
        <div class="FullPage">
            <div class="FullPage" style="border-bottom: silver 1px solid; text-align: left">
                <asp:Label ID="lblTitle" runat="server" Text="Process Pending Profile / Address" CssClass="FontMedium"
                    Font-Bold="True"></asp:Label>
                <asp:Label ID="lblRemaining" runat="server" Text="Remaining:"></asp:Label><asp:Label
                    ID="lblNo" runat="server"></asp:Label></div>
            <div id='dveelist' runat="server" class="LeftColumn" style="border-right: silver 1px solid;">
                <%--<div style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 300px; text-align: left" align="left">--%>
                <telerik:RadGrid ID="rgEmployees" runat="server" AllowFilteringByColumn="True" AllowSorting="True"
                    AutoGenerateColumns="False" GridLines="None" OnItemCommand="rgEmployees_ItemCommand"
                    OnNeedDataSource="rgEmployees_NeedDataSource" Skin="Sunset">
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
                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                </telerik:RadGrid>
                <div class="LeftColumn" >
                    <asp:Label ID="lblNoRecords" runat="server" Text="There is no pending records to process. " CssClass="FontSmall" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>                
                </div>
                </div>
            <%-- </div>--%>
            <div id='dvProfile' runat="server" class="RightColumn">
                <div class="RightColumnin">
                    <asp:Label ID="lblName" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>                    
                </div>
                <div class="RightColumnin">
                    <asp:GridView ID="gvProfile" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        OnRowCreated="gvCvrg_RowCreated" Width="500px" CellPadding="4" ForeColor="#333333"
                        GridLines="None" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="fld_description" HeaderText="Field Name">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Existing Value">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="proposed" HeaderText="Requested Value">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
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
                    &nbsp;<asp:Label ID="lblNoRecords0" runat="server" 
                        Text="There is no pending records to process. " CssClass="FontSmall" 
                        Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>                
                </div>
                <div id='dvButton' runat="server" class="RightColumnin">
                    &nbsp;<asp:Button 
                        ID="btnBack" runat="server" CssClass="FontSmall" Text="Home" Width="75px" 
                        onclick="btnBack_Click" Visible="False" />
                    <asp:Button ID="btnNext" runat="server" CssClass="FontSmall" Enabled="False" 
                        Text="Next" Width="75px" onclick="btnNext_Click" Visible="False" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" style="margin-left:200px" OnClick="btnSave_Click" 
                        Width="75px" />
                </div>
                <div class="RightColumnin" style="height: 10px">
                    &nbsp;
                </div>
                <div class="RightColumnin">
                    &nbsp;</div>
                <div class="RightColumnin" style="height: 10px">
                    &nbsp; &nbsp;&nbsp;</div>
                <div class="RightColumnin">
                    &nbsp; &nbsp;
                </div>
            </div>
        </div>
    </form>
</body>
</html>
