<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SkippedPlans.aspx.cs" Inherits="EnrollmentWizardSetup.SkippedPlans" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Setup Plans</title>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="FullPage">
            <div class="Section FontSmall">
                <asp:Label ID="lblInstruction" runat="server"></asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Section FontSmall">
                <div style="width:100px;float:left">
                <asp:Label ID="lblSelectClass" runat="server" AssociatedControlID="ddlClass" Font-Bold="True">Select Class</asp:Label>
                </div>
                <div style="width:400px;float:left">
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="FontSmall" Width="390px" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                    
                </div>
                <br />
            </div>
            <div class="Blank10">
                &nbsp;
            &nbsp;&nbsp;
                <br />
            </div>
            <div class="Section FontSmall">
                <asp:GridView ID="gvPlans" runat="server" AutoGenerateColumns="False" OnRowCreated="gvPlans_RowCreated" Width="300px">
                    <Columns>
                        <asp:BoundField DataField="LONG_DESCRIPTION" HeaderText="Plan Name" />
                        <asp:TemplateField HeaderText="Core/Optional"></asp:TemplateField>
                        <asp:TemplateField HeaderText="Include Plans">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Section FontSmall">
                <asp:Label ID="lblSaveTo" runat="server" Text="Save Condition" CssClass="FontSmall10" Font-Bold="True"></asp:Label>
            </div>
            <div class="Section FontSmall">
                <asp:RadioButtonList ID="rblSaveType" runat="server" RepeatColumns="2"
                    RepeatDirection="Horizontal" Width="500px">
                    <asp:ListItem Value="1" Selected="True">This Account &amp; This Class Only</asp:ListItem>
                    <asp:ListItem Value="2">This Account &amp; All Classes</asp:ListItem>
                    <asp:ListItem Value="3">All Division &amp; This Class Only</asp:ListItem>
                    <asp:ListItem Value="4">All Divisions &amp; All Classes</asp:ListItem>
                </asp:RadioButtonList></div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="Section FontSmall">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click3" />
            </div>
        </div>
    </form>
</body>
</html>
