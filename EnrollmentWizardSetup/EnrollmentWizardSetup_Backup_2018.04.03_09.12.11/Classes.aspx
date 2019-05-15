<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="EnrollmentWizardSetup.Classes" %>

<%@ Register Src="SetupTabStrip.ascx" TagName="SetupTabStrip" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-store" />
    <meta http-equiv="Expires" content="-1" />
    <link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
    <link href="main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:SetupTabStrip ID="SetupTabStrip1" runat="server" />
    <div class="FullPage">
        <div class="Section">
            <asp:Label ID="lblpropertiesPageTitle" runat="server" Text="Accounts Properties Setup"
                CssClass="pageTitle"></asp:Label>
        </div>
        <div class="Section">
            <div class="Section_no_padding">
                <asp:Label ID="lblShowHideFSAMEDLink" runat="server" Text="Class Code Eligibility"
                    CssClass="dataSetctionTitle"></asp:Label>
            </div>
        </div>

        <div class="Section">
            <div class="Section_no_padding">
                <asp:Label ID="Label1" runat="server" Text="Check the box"
                    CssClass="dataSubSetctionTitle"></asp:Label>
            </div>
        </div>

         <div class="Section">
            <div class="Section_no_padding">
                <asp:CheckBoxList ID="cbEligible" runat="server" CssClass="textFont">
                </asp:CheckBoxList>
            </div>
        </div>
        <div class="Section">
                <asp:RadioButtonList ID="rblSaveTaxTo" runat="server" RepeatDirection="Horizontal"
                    Width="563px" CssClass="FontSmall" Font-Bold="True">
                    <asp:ListItem Selected="True" Value="0">Save to this account only</asp:ListItem>
                    <asp:ListItem Value="1">Save to this account and all divisions</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="SectionNoTop">
                <asp:Button ID="btnClassSave" runat="server" Text="Save" 
                    onclick="btnClassSave_Click" />
                &nbsp;
            </div>
    </div>
    </form>
</body>
</html>
<%--
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None"
        EditMode="Batch" onneeddatasource="RadGrid1_NeedDataSource" 
            onbatcheditcommand="RadGrid1_BatchEditCommand" 
            onitemupdated="RadGrid1_ItemUpdated" Width="790px">
             <MasterTableView CommandItemDisplay="TopAndBottom"  DataKeyNames="class_code" Width="790px"
                EditMode="Batch" AutoGenerateColumns="False">
            <CommandItemSettings ShowAddNewRecordButton="false" />
                <Columns>
                    <telerik:GridBoundColumn DataField="class_code" 
                        FilterControlAltText="Filter column column" HeaderText="Class Code" ReadOnly="true"
                        UniqueName="class_code">
                        <HeaderStyle Width="400px" />
                        <ItemStyle Width="400px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="description" 
                        FilterControlAltText="Filter column column" HeaderText="Class Description" 
                        UniqueName="description">
                        <HeaderStyle Width="130px" />
                        <ItemStyle Width="130px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Elig_description" 
                        FilterControlAltText="Filter column1 column" 
                        HeaderText="Current Eligibility" ReadOnly="true"
                        UniqueName="Elig_description">
                        <HeaderStyle HorizontalAlign="Right" Width="75px" />
                        <ItemStyle HorizontalAlign="Right" Width="75px" />
                    </telerik:GridBoundColumn>
               
                    <telerik:GridCheckBoxColumn DataField="oe_eligible" HeaderStyle-Width="80px" HeaderText="Eligible" SortExpression="oe_eligible"
                        UniqueName="oe_eligible">
                    </telerik:GridCheckBoxColumn>

                </Columns>
            </MasterTableView>
        </telerik:RadGrid> 
        
--%>
