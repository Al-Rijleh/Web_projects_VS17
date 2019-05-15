<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreDefindMetalCoverage.aspx.cs" Inherits="Rates.PreDefindMetalCoverage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="BASLogin.css" rel="stylesheet" type="text/css" />
    <link href="Default.css" rel="stylesheet" type="text/css" />
    <link href="main2.css" rel="stylesheet" type="text/css" />
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.3/jquery.min.js"></script>
    <script type="text/javascript">
        function docloseWindow(id) {
            //closeWindow(id); return false;
            window.open(id, "MyEnroll_users_data_display_and_edit_content_frame");
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow(id) {
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }

        
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hidSave" runat="server" />
    <asp:Label ID="lblScript" runat="server"></asp:Label>
    <div class="FullPageMenu" runat="server" id="dvSelectReport">
        <div class="FullRowMenu margingbottom BordrBottom">
            <asp:Label ID="lblTitle" runat="server" CssClass="pageTitle" Font-Bold="True">Pre Defined Plans</asp:Label>
        </div>
        <asp:Panel ID='Panel1' runat="server" class="FullPageMenu bottomline" style="float:left">
        
                     
    </asp:Panel>
    </div>
    
    <%--Effective Date--%>
    <div class="FullRowMenu " id="Div5" runat="server">
        <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date" MarkFirstMatch="True"
            CssClass="textFont" Width="216px"></asp:Label>
        <telerik:RadDatePicker ID="txtEffectiveDates" runat="server" Width="300px" Culture="en-US"
            OnSelectedDateChanged="txtEffectiveDates_SelectedDateChanged">
            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True">
            </Calendar>
            <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                <FocusedStyle Resize="None"></FocusedStyle>
                <DisabledStyle Resize="None"></DisabledStyle>
                <InvalidStyle Resize="None"></InvalidStyle>
                <HoveredStyle Resize="None"></HoveredStyle>
                <EnabledStyle Resize="None"></EnabledStyle>
            </DateInput>
            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
        <telerik:RadButton ID="btnGo" runat="server" CausesValidation="False" Text="Go" OnClick="btnGo_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="btnChangedate" runat="server" OnClick="btnChangedate_Click"
            Text="Change Effective Date" Visible="False" Width="150px">
        </telerik:RadButton>
    </div>
        <%--Metal Tiers--%>
    <div class="FullRowMenu " id="dvProgramType" runat="server">
        <asp:Label ID="lblSelectMetalTier" runat="server" Text="Metal Tier" MarkFirstMatch="True"
            CssClass="textFont" Width="216px"></asp:Label>
        <telerik:RadComboBox ID="ddlMetalTier" runat="server" AutoPostBack="True" Width="300px"
            CausesValidation="False" OnSelectedIndexChanged="ddlMetalTier_SelectedIndexChanged"
            Enabled="False">
        </telerik:RadComboBox>
    </div>
        <%--Coverage List--%>
    <div class="FullRowMenu " id="Div1" runat="server">
        <asp:Label ID="lblSelectCoverageList" runat="server" Text="Plans List" MarkFirstMatch="True"
            CssClass="textFont" Width="216px"></asp:Label>
        <telerik:RadComboBox ID="ddlPlansList" runat="server" AutoPostBack="True" Width="300px"
            CausesValidation="False" DropDownWidth="400px" OnSelectedIndexChanged="ddlPlansList_SelectedIndexChanged"
            Enabled="False">
        </telerik:RadComboBox>
    </div>
        <%--Rates List--%>
    <div class="FullRowMenu margintop20 marginbottom10" id="dvRatelbl" runat="server"
        visible="False">
        <asp:Label ID="lblRates" runat="server" Text="Tobacco/non-Tobacco Rates" MarkFirstMatch="True"
            CssClass="dataSubSetctionTitle"></asp:Label>
        <asp:Label ID="lblCategory" runat="server"></asp:Label>
    </div>
        <%--Rates List--%>
    <div class="FullRowMenu " id="dvRatesList" runat="server" visible="False">
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource"
            Height="200px">
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
        <%--Button--%>
    <div class="FullRowMenu margintop20 " id="Div4" runat="server">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
            Width="100px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click"
            Visible="False" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="100px" Visible="False" OnClientClick="DoSave()" OnClick="btnUpdate_Click" />
        <img alt="" src="https://www.myenroll.com/images/smallbuzy.gif" id="htmImgBusy" style="visibility: hidden" />
    </div>
    <div class="FullRowMenu  margintop20 FontMedium" id="dvError" runat="server">
        CCS has been informed that Independence Blue Cross ("IBC") has not renewed this plan for 2016. To select a 2016 IBC Age/Tobacco plan, click the back button below to return to the main page. Once on the main page, click "Add Another Medical" and follow the prompts. Please terminate the 2015 plan(s) by clicking the third option in the yellow box titled “Terminate This Plan." If you have any questions, please contact your account manager.
    </div>

    <div class="FullRowMenu margintop20 " id="dvErrorbtn" runat="server">
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnCancel_Click"
            Width="100px" />
    </div>
    </form>
    <script type="text/javascript">

        function Cancel(url) {
            alert(url);
            window.open(url, '_top');
        }

        function GoBack(url_) {
            window.open(url_, '_top');
        }

        function DoSave() {
            document.getElementById('htmImgBusy').style.visibility = "visible";
            document.getElementById('btnUpdate').style.visibility = "hidden";
            try { document.getElementById('btnCancel').style.visibility = "hidden" } catch (err) { };
            eval(document.getElementById('hidSave')).value = 'update';
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            theForm.submit();
        }

    </script>
</body>
</html>
