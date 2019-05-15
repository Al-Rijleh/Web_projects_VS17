<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ViewDocument.aspx.cs" Inherits="Documents.ViewDocument" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Documents Viewer</title>
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
            <div id="dvTemplateHeader" class="GenralRow">
                &nbsp;
                <br />
                <div id="dvContentHeader1" class="fontsmall GenralRow">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="220px"> Training Requested</asp:Label>
                    <asp:Label ID="lblCourseTitle" runat="server" Font-Bold="True">ssssss</asp:Label>
                </div>
                <div id="dvContentHeader2" class="fontsmall GenralRow bottom_border">
                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Width="220px">Remaining Budget For: </asp:Label><asp:DropDownList
                        ID="ddlBudgetYear" runat="server" AutoPostBack="True" Width="60px" CssClass="fontsmall"
                        OnSelectedIndexChanged="ddlBudgetYear_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="lblBalance" runat="server" Font-Bold="True">$2,500.00</asp:Label>
                    <asp:HiddenField ID="hidCommand" runat="server" />
                    <br />
                    <br />
                </div>
                <div id="dvInstruction" class="GenralRow" style="border-top: silver 1px solid">
                    <asp:Label ID="lbl_fldTrainingDocumentsViewDocType" runat="server" CssClass="fontsmall">Instruction</asp:Label>
                </div>
                <div style="height: 10px">
                    <asp:HiddenField ID="hidcmnd" runat="server" />
                    &nbsp;</div>
                <div id="Div4" class="GenralRow">
                    <div id="Div2" class="GenralRow" style="padding-top: 10px; padding-left: 10px; width: 257px">
                        <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" CssClass="fontsmall"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCreated="gvDocuments_RowCreated">
                            <Columns>
                                <asp:TemplateField HeaderText="Select Document">
                                    <HeaderStyle CssClass="fontsmall" Font-Bold="True" />
                                    <ItemStyle CssClass="fontsmall" Width="150px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="type_desc" HeaderText="Type of Submission" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                    <div id="Div3" class="GenralRow" style="padding-top: 10px; padding-left: 5px; padding-bottom: 10px;
                        width: 495px">
                        <asp:Label ID="lblDocumentName" runat="server" CssClass="fontsmall" Font-Bold="False"
                            Style="margin-left: auto; margin-right: auto" BackColor="#333333" ForeColor="White"
                            Height="21px" Width="100%" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                        <asp:TextBox ID="txtDocumentDescription" runat="server" Height="150px" Width="490px"
                            CssClass="fontsmall" TextMode="MultiLine"></asp:TextBox><br />
                        <asp:Button ID="btnViewDocument" Style="float: right" runat="server" Text="Show Image"
                            CausesValidation="False" CssClass="fontsmall" EnableTheming="False" OnClick="btnViewDocument_Click"
                            Enabled="False" />
                    </div>
                </div>
                <div id="Div1" class="GenralRow" style="padding-top: 10px; padding-left: 10px; border-top: silver 1px solid;">
                    <asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="fontsmall"
                        Text="Back" ToolTip="Back to previous page" Width="75px" OnClick="btnBack_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
