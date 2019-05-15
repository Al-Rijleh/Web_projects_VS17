<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UploadPLAFax.aspx.cs" Inherits="Documents.UploadPLAFax" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Document</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />
    <link href="style.css" type="text/css" rel="stylesheet" />

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="Vista" EnableEmbeddedScripts="true">
        </telerik:RadWindowManager>
        <div id="wrapper" class="wrapper">
            <div id="Div1" class="GenralRow" style="padding-bottom: 10px; padding-top: 20px;
                text-align: center;">
                <asp:Label ID="lblTitle" runat="server" Text="Upload Fax" CssClass="fontmedium" Font-Bold="True"></asp:Label></div>
            <div id="Contenet" class="GenralRow" style="height: 30px">
                <div id="left" class="LeftDataSectiontext" style="width: 140px">
                    <asp:Label ID="lblImageIDTitle" runat="server" Text="PLA ID:" CssClass="fontsmall" Font-Bold="True"></asp:Label>
                </div>
                <div id="right" class="LeftDataSectiontext2" style="width: 400px">
                    &nbsp;<telerik:RadNumericTextBox ID="txtHederID" runat="server" MinValue="0" Width="100px">
                        <NumberFormat DecimalDigits="0" />
                    </telerik:RadNumericTextBox>
                    -
                    <telerik:RadNumericTextBox ID="txtRecordID" runat="server" MinValue="0" Width="100px">
                        <NumberFormat DecimalDigits="0" />
                    </telerik:RadNumericTextBox>&nbsp; &nbsp;<asp:Button ID="btnRetriveRecord" runat="server"
                        CssClass="fontsmall" Text="Retrive Record" OnClick="btnRetriveRecord_Click" /></div>
            </div>
            <div id="dvAppName" class="GenralRow" style="height: 30px" runat="server">
                <div id="Div3" class="LeftDataSectiontext" style="width: 140px">
                    <asp:Label ID="lblApplicationNameTitle" runat="server" Text="Application Title:"
                        CssClass="fontsmall" Font-Bold="True"></asp:Label>
                </div>
                <div id="Div4" class="LeftDataSectiontext2" style="width: 600px">
                    <asp:Label ID="lblApplicationTitle" runat="server" CssClass="fontsmall" Font-Bold="False" Width="550px"></asp:Label>
                </div>
            </div>
            <div id="dvDescription" class="GenralRow" runat="server">
                <div id="Div6" class="LeftDataSectiontext" style="width: 140px">
                    <asp:Label ID="lblApplicationDescTitle" runat="server" Text="Application Description:"
                        CssClass="fontsmall" Font-Bold="True"></asp:Label>
                </div>
                <div id="Div7" class="LeftDataSectiontext2" style="width: 600px">
                    <asp:Label ID="lblApplicationDesc" runat="server" CssClass="fontsmall" Font-Bold="False" Width="550px"></asp:Label>
                </div>
            </div>
             <asp:Panel ID="pnlImage" runat="server" Width="785px" style="padding-left: 10px" > 
                    <div style="width: 140px; float: left; padding-top: 10px">
                        <asp:Label ID="lblDocument" runat="server" Text="Select Document File" CssClass="fontsmall" Font-Bold="True"></asp:Label>
                    </div>
                    <div style="width: 580px; float: left; padding-top: 10px">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fontsmall" Width="500px" />&nbsp;&nbsp;<br />
                        <asp:Label ID="lblCurrentSelected" runat="server" CssClass="fontsmall" Text="Currently Selected File"></asp:Label>&nbsp;
                        <asp:Label ID="lblFileName" runat="server" CssClass="fontsmall" Font-Bold="True"
                            Font-Italic="True" Text="Not Selected"></asp:Label><br />
                        <asp:Button ID="btnLoad" runat="server" CssClass="fontsmall" OnClick="btnLoad_Click"
                            Text="Load / View Selected File" CausesValidation="False" />
                    </div>
                </asp:Panel>
        </div>
        <div id="dvbtn" class="GenralRow" runat="server" style="padding-left: 10px; padding-top: 25px">
            <div style="float: left; width: 575px">
                <asp:Button ID="btnSave" runat="server" CssClass="fontsmall" OnClick="btnSave_Click"
                    Text="Save" Width="75px" /></div>
            <div style="float: right; width: 200px">
                &nbsp;</div>
        </div>
    </form>
</body>
</html>
