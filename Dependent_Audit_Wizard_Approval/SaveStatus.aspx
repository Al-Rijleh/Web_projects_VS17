<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveStatus.aspx.cs" Inherits="Dependent_Audit_Wizard_Approval.SaveStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Main.css" rel="stylesheet" type="text/css" />
    <link href="/styles/Main2.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        function docloseWindow(id) {
            closeWindow(id); return false;
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

        function ViewDoc(id) {
            var url = '/web_projects/DocumentViwer/viewer.aspx?id=[id]&skip=1&type=application/pdf';
            url = url.replace('[id]', id)
            window.open(url, '_blank');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 360px;">
        <div style="width: 350px; text-align: left; border-bottom-style: solid; border-bottom-width: 1px;
            border-bottom-color: #666666; margin-bottom: 20px;">
            <asp:Label ID="lblTitle" runat="server" CssClass="pageTitle"></asp:Label>
        </div>
        <div class="marginbuttom10" style="width: 350px;">
            
            <div style="width: 250px; float: left;">
                <asp:Label ID="lblDependentName" runat="server" CssClass="textFont" 
                    Font-Bold="True"></asp:Label>
            </div>
            <div style="width: 100px; float: right">
                <asp:HyperLink ID="hlDocLink" runat="server" Font-Bold="True" 
                    CssClass="textFont" ForeColor="#0000CC">View Document</asp:HyperLink>
            </div>
        </div>
        <div  style="width: 350px;">
        &nbsp;
        </div>
        <div class="marginbuttom10" style="width: 350px; text-align: left;">
            <asp:Label ID="lblInformation" runat="server" CssClass="textFont"></asp:Label>
        </div>
        <div id="dvReason" class="marginbuttom10" runat="server" style="width: 350px; float: left">
            <div  style="width: 350px;">
            <asp:Label ID="lblResonTitle" runat="server" CssClass="textFont"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReason"
                CssClass="errorRed" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div  style="width: 350px;">
            <asp:TextBox ID="txtReason" runat="server" Height="100px" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </div>
        </div>
        <div id="dvApproveInfo" class="marginbuttom10" runat="server" style="width: 350px; float: left">
            <div  style="width: 350px;">
            <asp:Label ID="lblReqDoc" runat="server" CssClass="textFont"></asp:Label>
            </div>
            <div  style="width: 345px; float:left; text-align: right;">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDocCountRad"
                CssClass="errorRed" ErrorMessage="Required" Font-Bold="True"></asp:RequiredFieldValidator>
            </div>
            <div  style="width: 350px;" id="dvDocCount" runat="server">
            <asp:Label ID="lblNumberOfDoc" runat="server" CssClass="textFont">Number of Approved Document included in This PDF:</asp:Label>
            &nbsp;<telerik:RadNumericTextBox ID="txtDocCountRad" Runat="server" Culture="en-US" 
                    DbValueFactor="1" LabelWidth="64px" MinValue="0" ResolvedRenderMode="Classic" 
                    Width="50px">
                </telerik:RadNumericTextBox>
            
            </div>
                
            <div  style="width: 350px;  background-color: #339933; color: #FFFFFF; font-weight: bold;" 
                id="dvConfirmSave" runat = "server">
                <asp:Label ID="lblConfirmSave" runat="server" cssclass="FontSmall10">All Documents for all dependents have been approved. The Request will  be finalized upon clicking the “Finalize” button.</asp:Label>
            </div>


            <div  style="width: 350px; background-color: #FF0000; color: #FFFFFF; font-weight: bold;" 
                id="dvApproveWarning" runat = "server">
                <asp:Label ID="lblApproveWarning" runat="server" cssclass="FontSmall10">There are not enough documents for this dependent. You may not approve this document. </asp:Label>
            </div>

            

        </div>
        <div id="dvDDIC" class="marginbuttom10" runat="server" style="width: 350px; float: left">
            <div id='dvDes' runat="server" class=" margintop10" style="width: 350px;">
                    <%--<div class="PDFSide" style="font-size: 12px">
                        <asp:Label ID="lblNoEmail" runat="server" Text="No Email Address for this Employee"
                            Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                        <asp:Label ID="lblEmail" runat="server" Font-Bold="True" ForeColor="#006600" Visible="False"></asp:Label>
                    </div>--%>
                    <div style="float: left; margin-top: 5px" class="FontSmall10 FontBold">
                        <asp:Label ID="lblSelectApprovalStatus" runat="server" Text="Select Status"></asp:Label>
                    </div>
                    <div style=" float: left; width: 200px;">
                        <asp:CheckBoxList ID="rblApproval" runat="server" CssClass="textFont" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblApproval_SelectedIndexChanged">
                            <asp:ListItem Value="1">Student</asp:ListItem>
                            <asp:ListItem Value="2">Disabled </asp:ListItem>
                        </asp:CheckBoxList>

                    </div>
                    <div style="float: left;">
                        <asp:Button ID="btApply" runat="server" Text="Apply" OnClick="btApply_Click" Visible="False" />
                    </div>
                </div>
        </div>
        <div style="width: 350px;float:left; height: 15px;margin-bottom: 10px;" id="dvDepStatus" runat="server">
                        <asp:Label ID="lblDepStatus" runat="server" CssClass="FontSmall10">Status: </asp:Label>
                    </div>
        <div style="width: 350px;float:left; ">
            <hr />
        </div>
        <div  style="width: 350px; float:left; margin-top: 10px;">
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                CausesValidation="False" Width="75px" />
            &nbsp;
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="75px" Visible="False" />
        &nbsp;<asp:Button ID="btnFinalize" runat="server" OnClick="btnFinalize_Click" 
                Text="Finalize" Width="75px" Visible="False" />
        </div>
    </div>
    </form>
</body>
</html>
