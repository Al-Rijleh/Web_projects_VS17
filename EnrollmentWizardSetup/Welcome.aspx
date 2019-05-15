<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Codebehind="Welcome.aspx.cs"
    Inherits="EnrollmentWizardSetup.Welcome" Title="Untitled Page" %>

<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
  function GetAccount(strURL)
  {
     alert('You must select an account first');
     window.open(strURL,'_self');
  }
    </script>

    <div class="StatusInputRowTitle FontSmall10 Header2" style="visibility: hidden">
        <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label>
    </div>
    <div class="Blank10">
    &nbsp;
    </div>
    <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
    <div class="Section">
        <asp:Label ID="lblPageTitle" runat="server" Text="Welcome Page Setup" CssClass="FontLarge"
            Font-Bold="True" ForeColor="Green" Style="margin-left: auto; margin-right: auto;"></asp:Label>
    </div>
    <div class="Section">
        <asp:RadioButtonList ID="rblItem" runat="server" CssClass="FontSmall10" Font-Bold="True"
            AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="1">Top Message</asp:ListItem>
            <asp:ListItem Value="3">Middle Message</asp:ListItem>
            <asp:ListItem Value="2">Bottom Message</asp:ListItem>
            <asp:ListItem Value="21">Life Event/ Open Enrollment</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div id="Div1" class="Section" runat="server" style="text-align: center; border-top: black 1px solid;
        border-bottom: black 1px solid;">
        <asp:RadioButtonList ID="rblMode" runat="server" AutoPostBack="True" CssClass="FontSmall10"
            Style="margin-left: auto; margin-right: auto" Font-Bold="True" RepeatDirection="Horizontal"
            OnSelectedIndexChanged="rblMode_SelectedIndexChanged">
            <asp:ListItem Value="0" Selected="True">View Mode</asp:ListItem>
            <asp:ListItem Value="1">Edit Mode</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div id="dvView" class="Section" runat="server">
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblEnrollmentType" runat="server" Text="Enrollment Type" AssociatedControlID="rblEnrollmentType"
                    CssClass="FontSmall" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:RadioButtonList ID="rblEnrollmentType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                    Width="510px" AutoPostBack="True" 
                    OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Open Enrollment</asp:ListItem>
                    <asp:ListItem Value="2">New Hire Enrollment</asp:ListItem>
                    <asp:ListItem Value="3">Life Event</asp:ListItem>
                    <asp:ListItem Value="5">Special OE</asp:ListItem>
                    <asp:ListItem Value="4">Normal</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="Row" style="border-bottom: black 1px solid">
            <div class="LeftRegion">
                <asp:Label ID="lblAccount" runat="server" Text="View From Account" AssociatedControlID="rblAccounts"
                    CssClass="FontSmall" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:RadioButtonList ID="rblAccounts" runat="server" CssClass="FontSmall" RepeatColumns="2"
                    RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblItem_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Default</asp:ListItem>
                    <asp:ListItem Value="2">Account [Accnt]</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblDescriptionTitle" runat="server" Text="Description" CssClass="FontSmall"
                    Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                &nbsp;<asp:Label ID="lblDescription" runat="server" CssClass="FontSmall"></asp:Label></div>
        </div>
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblTextTitle" runat="server" Text="Text" CssClass="FontSmall" Font-Bold="True"></asp:Label>
            </div>
        </div>
        <div class="Row">
            <asp:Label ID="lblText" runat="server" CssClass="FontSmall"></asp:Label>
        </div>
    </div>
    <div id="dvEdit" class="Section" runat="server" visible="false">
        <div class="Row">
            <div class="LeftRegion">
                <asp:Label ID="lblApplyEnrollmentType" runat="server" Text="Apply To Enrollment Type"
                    CssClass="FontSmall" AssociatedControlID="cblEnrollmentType" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:CheckBoxList ID="cblEnrollmentType" runat="server" CssClass="FontSmall" RepeatDirection="Horizontal"
                    Width="510px">
                    <asp:ListItem Value="1">Open Enrollment</asp:ListItem>
                    <asp:ListItem Value="2">New Hire Enrollment</asp:ListItem>
                    <asp:ListItem Value="3">Life Event</asp:ListItem>
                    <asp:ListItem Value="5">Special OE</asp:ListItem>
                    <asp:ListItem Value="4">Normal</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
        <div class="Row" style="border-bottom: black 1px solid">
            <div class="LeftRegion">
                <asp:Label ID="lblApplyToAccount" runat="server" Text="Apply to Account(s)" CssClass="FontSmall"
                    AssociatedControlID="cblAccounts" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
            <asp:RadioButtonList ID="cblAccounts" runat="server" CssClass="FontSmall" RepeatColumns="2"
                        RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="cblAccounts_SelectedIndexChanged">
                        <asp:ListItem Value="1">Default</asp:ListItem>
                        <asp:ListItem Value="2">This Account Only [Accnt]</asp:ListItem>
                        <asp:ListItem Value="3">This Account  [Accnt] and All its Divisions</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
        </div>
        <div class="Row" style="padding-top: 5px">
            <div class="LeftRegion">
                <asp:Label ID="lblDiscriptionTitle" runat="server" Text="Description" CssClass="FontSmall"
                    AssociatedControlID="textDescription" Font-Bold="True"></asp:Label>
            </div>
            <div class="RightRegion">
                <asp:TextBox ID="textDescription" runat="server" CssClass="FontSmall" Width="294px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textDescription"
                    CssClass="FontSmall" Display="Dynamic" ErrorMessage="Required Info"></asp:RequiredFieldValidator></div>
        </div>
        <div class="Row">
            <div class="LeftRegion" style="width: 347px">
                <asp:Label ID="lblTextEditTitle" runat="server" Text="Text" CssClass="FontSmall"
                    Font-Bold="True"></asp:Label>&nbsp;
                </div>
        </div>
        <div class="Row">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <telerik:RadEditor ID="RadEditor1" runat="server" Skin="Sunset" Width="748px" ToolsFile="FullSetOfTools.xml"
                            Height="300px">
                            <Content>
                            </Content>
                        </telerik:RadEditor>
                    </td>
                </tr>
            </table>
        </div>
        <div class="Row" style="padding-top: 10px">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" 
                        Text="Revert Account Message to Default Message" 
                        style="margin-left:150px"/>
        </div>
    </div>
</asp:Content>
