<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cvrg_msg.aspx.cs" Inherits="EnrollmentWizardSetup.cvrg_msg" %>
<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript"">
     function Save()
     {
        eval(document.getElementById('btnSave')).disabled = true;
        eval(document.getElementById('hidSave')).value ='Go';
     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ddlProcessingYear">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlProcessingYear" />
                        <telerik:AjaxUpdatedControl ControlID="ddlClass" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="gvGroups" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlClass">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ddlClass" />
                        <telerik:AjaxUpdatedControl ControlID="gvGroups" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                        <telerik:AjaxUpdatedControl ControlID="reMessage" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="rblEnrollmentType">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                        <telerik:AjaxUpdatedControl ControlID="reMessage" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="gvGroups">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rblEnrollType" />
                        <telerik:AjaxUpdatedControl ControlID="gvGroups" />
                        <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                        <telerik:AjaxUpdatedControl ControlID="reMessage" />
                        <telerik:AjaxUpdatedControl ControlID="lblInstruction" />
                        <telerik:AjaxUpdatedControl ControlID="reInstruction" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>--%>
        <%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="75px"
            Skin="Sunset" Width="75px">
            &nbsp;</telerik:RadAjaxLoadingPanel>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />--%>
        <asp:HiddenField ID="hidSave" runat="server" />
        <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
        <div class="FullPage">
            <div class="Section">
                <asp:Label ID="lblPageTitle" runat="server" Text="Coverage Messsages"
                    CssClass="FontLarge" Font-Bold="True" ForeColor="Green" Style="margin-left: auto;
                    margin-right: auto;"></asp:Label></div>
                &nbsp;
            <div class="Section">
                &nbsp;
            </div>
            <div class="Section FontSmall">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblPy" runat="server" Font-Bold="True" Text="Select Processing Year"></asp:Label>&nbsp;</div>
                <div class="RightRegion">
                    <asp:DropDownList ID="ddlProcessingYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProcessingYear_SelectedIndexChanged">
                    </asp:DropDownList></div>
            </div>
            <div class="Section FontSmall">
                <div class="LeftRegion FontSmall">
                    <asp:Label ID="lblClass" runat="server" Font-Bold="True" Text="Select Class Code"></asp:Label>&nbsp;</div>
                <div class="RightRegion">
                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList></div>
            </div>
            <div class="Section FontSmall">
                <div class="LeftRegion FontSmall">
                    &nbsp;</div>
                <div class="RightRegion">
                    <asp:RadioButtonList ID="rblEnrollmentType" runat="server" RepeatDirection="Horizontal"
                        Width="259px" AutoPostBack="True" OnSelectedIndexChanged="rblEnrollmentType_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">View</asp:ListItem>
                        <asp:ListItem Value="1">Edit</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="Row">
                <div class="LeftRegion">
                    <asp:Label ID="Label2" runat="server" Text="Enrollment Type" AssociatedControlID="rblEnrollmentType"
                        CssClass="FontSmall" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:RadioButtonList ID="rblEnrollType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                        Width="530px" AutoPostBack="True" OnSelectedIndexChanged="rblEnrollType_SelectedIndexChanged"
                        Enabled="False">
                        <asp:ListItem Selected="True" Value="O">Open Enrollment</asp:ListItem>
                        <asp:ListItem Value="A">New Hire Enrollment</asp:ListItem>
                        <asp:ListItem Value="L">Life Event</asp:ListItem>
                        <asp:ListItem Value="S">Special OE</asp:ListItem>
                        <asp:ListItem Value="N">Normal</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
           
            <div class="SectionNoTop">             
                <div class="leftGrid">
                <asp:Label ID="lblPreviuosSetup" runat="server" Text="Existing Plans for [py] Plan Year"
                    Font-Bold="True" CssClass="FontSmall"></asp:Label>
                    <asp:GridView ID="gvGroups" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CssClass="FontSmall" ForeColor="#333333" GridLines="None" Width="270px" OnSelectedIndexChanged="gvGroups_SelectedIndexChanged">
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="long_description" HeaderText="Plan Name">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="Select" ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
                <div class="RighGrid">
                    <asp:Label ID="lblMessageTitle" runat="server" CssClass="FontMedium" Font-Bold="True">Message<br></asp:Label>
                    <asp:Label ID="lblMessage" runat="server">Message not specified<br></asp:Label>
                    <telerik:RadEditor ID="reMessage" runat="server" Skin="Sunset" Width="468px" ToolsFile="FullSetOfTools.xml"
                        Height="500px" Visible="False">
                        <Content>
</Content>
                    </telerik:RadEditor>
                </div>
            </div>
            <div class="Section" style="height: 10px">
                &nbsp;
            </div>
            <div class="Row">
                <div class="LeftRegion">
                    <asp:Label ID="lblEnrollmentType" runat="server" Text="Enrollment Type" AssociatedControlID="rblEnrollmentType"
                        CssClass="FontSmall" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:CheckBoxList ID="cbEnrommentType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                        Width="530px">
                        <asp:ListItem Selected="True" Value="O">Open Enrollment</asp:ListItem>
                        <asp:ListItem Value="A">New Hire Enrollment</asp:ListItem>
                        <asp:ListItem Value="L">Life Event</asp:ListItem>
                        <asp:ListItem Value="S">Special OE</asp:ListItem>
                        <asp:ListItem Value="N">Normal</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="Row">
                <div class="LeftRegion">
                    <asp:Label ID="Label1" runat="server" Text="Save To" AssociatedControlID="rblEnrollmentType"
                        CssClass="FontSmall" Font-Bold="True"></asp:Label>
                </div>
                <div class="RightRegion">
                    <asp:RadioButtonList ID="rblSaveTo" runat="server" CssClass="FontSmall" Width="469px"
                        RepeatColumns="2">
                        <asp:ListItem Selected="True" Value="0">This Account Selected Class</asp:ListItem>
                        <asp:ListItem Value="1">This Account All Classes</asp:ListItem>
                        <asp:ListItem Value="2">This Account and All Divisions Selected Class</asp:ListItem>
                        <asp:ListItem Value="3">This Account and All Divisions All Classs</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="btnSave" runat="server" Text="Save" Enabled="False"
                    Width="256px" />&nbsp;
                <asp:Label ID="lblError" runat="server" CssClass="FontSmall" Font-Bold="False" ForeColor="Maroon"></asp:Label>
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>