<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Documents._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="UltimateMenu" Namespace="Karamasoft.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Documents</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <link href="style.css" type="text/css" rel="stylesheet" />

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Do_Load()
			{
			    document.getElementById('btnLoad').style.visibility='hidden';
			    document.getElementById('dvLoading').style.visibility='visible';
			    eval(document.getElementById('hidCommand')).value='DoLoad';
			    postBack();
			}
	    function Do_Save()
			{
			    document.getElementById('btnSave').style.visibility='hidden';
			    document.getElementById('dvSaving').style.visibility='visible';
			    eval(document.getElementById('hidCommand')).value='DoSave';
			    postBack();
			}
	    function postBack()
			{
			 var theForm = document.forms['form1'];
             if (!theForm) 
                theForm = document.Form1;
             theForm.submit();            
			}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="Vista" EnableEmbeddedScripts="true">
        </telerik:RadWindowManager>
        <div id="wrapper" class="wrapper">
            <div id="dvMenu1" class="menuholder">
                <cc1:UltimateMenu ID="UltimateMenu1" runat="server">
                </cc1:UltimateMenu>
            </div>
            <div id="dvMenu2" class="menuholder" style="background-image: url(/karama/Images/WinSubTab.gif)">
                <asp:Label ID="lblWizardError" runat="server" CssClass="fontsmall" Font-Bold="True"
                    ForeColor="Maroon"></asp:Label>&nbsp;</div>
            <div id="dvTemplateHeader" class="GenralRow">
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label></div>
            <br />
            <div id="dvContentHeader1" class="fontsmall GenralRow">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="220px"> Training Requested</asp:Label>
                <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True">ssssss</asp:Label>
            </div>
            <div id="dvContentHeader2" class="fontsmall GenralRow">
                <asp:Label ID="Label28" runat="server" Font-Bold="True" Width="220px">Remaining Budget For: </asp:Label><asp:DropDownList
                    ID="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall"
                    OnSelectedIndexChanged="ddlBudgetYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:Label>
                <asp:HiddenField ID="hidCommand" runat="server" />
                <br />
                <br />
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" AutoPostBack="True" CausesValidation="False"
                    SelectedIndex="2" Skin="Outlook" OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="Upload Document">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Fax Document">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Hand Deliver Document" Selected="True">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </div>
            <div id="dvInstruction" class="GenralRow" style="border-top: silver 1px solid">
                <asp:Label ID="lbl_fldTrainingDocuments" runat="server" CssClass="fontsmall">Instruction</asp:Label>
            </div>
            <div style="height: 10px">
                <asp:HiddenField ID="hidcmnd" runat="server" />
                &nbsp;</div>
            <div id="Div1" class="GenralRow">
                <div style="width: 200px; float: left">
                    <asp:Label ID="lblDocumentName" runat="server" Text="Document Name" CssClass="fontsmall"></asp:Label>
                </div>
                <div style="width: 550px; float: left">
                    <asp:TextBox ID="txtDocumentName" runat="server" CssClass="fontsmall" MaxLength="100"
                        Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDocumentName"
                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="Document Name Required"></asp:RequiredFieldValidator></div>
                <div style="width: 200px; float: left">
                    <asp:Label ID="lblDocumentDescription" runat="server" Text="Document Description"
                        CssClass="fontsmall"></asp:Label>
                </div>
                <div style="width: 580px; float: left">
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="fontsmall" MaxLength="4000"
                        Width="500px" Height="80px" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                        CssClass="fontsmall" Display="Dynamic" ErrorMessage="Document Description Required"></asp:RequiredFieldValidator></div>
                <asp:Panel ID="pnlImage" runat="server" Width="785px">
                    <div style="width: 200px; float: left; padding-top: 10px">
                        <asp:Label ID="lblDocument" runat="server" Text="Select Document File" CssClass="fontsmall"></asp:Label>
                    </div>
                    <div style="width: 580px; float: left; padding-top: 10px">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fontsmall" Width="500px" />&nbsp;&nbsp;<br />
                        <asp:Label ID="lblCurrentSelected" runat="server" CssClass="fontsmall" Text="Currently Selected File"></asp:Label>&nbsp;
                        <asp:Label ID="lblFileName" runat="server" CssClass="fontsmall" Font-Bold="True"
                            Font-Italic="True" Text="Not Selected"></asp:Label><br />
                        <div style="width: 570px; float: left">
                        <div id="dvLoading" style="visibility: hidden; float: left"><b><font face="Arial" color="#800000">Loading..</font></b></div>
                            <div style="float: left">
                                <asp:Button ID="btnLoad" runat="server" CssClass="fontsmall"
                                    Text="Load / View Selected File" CausesValidation="False" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlFax" runat="server" Width="785px">
                    <div style="width: 580; float: left; padding-top: 10px">
                        <asp:Label ID="lblFax" runat="server" Text='Click the "Create Cover Page" button which is located below this message to create a coversheet for the fax. Please note that the name and description of the document which you entered above will be saved as well.'
                            CssClass="fontsmall" Width="627px"></asp:Label>
                    </div>
                    <div style="width: 580px; float: left; padding-top: 10px">
                        <asp:Button ID="btnCoverPage" runat="server" CssClass="fontsmall" OnClick="btnCoverPage_Click"
                            Text="Create Cover Page" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlHand" runat="server" Width="785px">
                    <div style="width: 580; float: left; padding-top: 10px">
                        <asp:CheckBox ID="cbVerify" runat="server" CssClass="fontsmall" Font-Bold="True"
                            Font-Italic="False" Text="To verify that you submitted the document to your administrator, Please click the checkbox to the left"
                            Width="636px" AutoPostBack="True" OnCheckedChanged="cbVerify_CheckedChanged" />
                    </div>
                </asp:Panel>
            </div>
            <div id="Div2" class="GenralRow" style="padding-top: 25px; padding-left: 10px">
                <div style="width: 575px; float: left">
                    <div style="float:left">
                    <asp:Button ID="btnHome" runat="server" CausesValidation="False" CssClass="fontsmall"
                        OnClick="btnHome_Click" Text="Home" ToolTip="Rrturn to select application" Width="75px" /><asp:Button
                            ID="btnBack" runat="server" CausesValidation="False" CssClass="fontsmall" Text="Back"
                            ToolTip="Back to previous page" Width="75px" OnClick="btnBack_Click" /><asp:Button
                                ID="btnNext" runat="server" CausesValidation="False" CssClass="fontsmall" Text="Next"
                                ToolTip="GoTo next page" Width="75px" OnClick="btnNext_Click" />
                    </div>
                    <div id="dvSaving" style="visibility: hidden; float: right"><b><font face="Arial" color="#800000">Saving..</font></b></div>

                    <div style="float:right">
                    <asp:Button ID="btnSave" runat="server" CssClass="fontsmall"
                        Text="Save" Width="75px" />
                    <asp:Label ID="lblVerifyCheckBox" runat="server" CssClass="fontsmall" Text="Must check the Verify checkbox"></asp:Label>
                    </div>
                </div>
                <div style="width: 200px; float: right">
                    <asp:Button ID="btnViewDocument" runat="server" CausesValidation="False" CssClass="fontsmall"
                        OnClick="btnViewDocument_Click" Text="View Uploaded Documents" ToolTip="View Uploaded Documents for this application"
                        Width="200px" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
