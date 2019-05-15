<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChangeClass.aspx.cs" Inherits="NewHireWizard.ChangeClass" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    
        function GetRadWindow()
        {
          var oWindow = null;
          if (window.radWindow)
             oWindow = window.radWindow;
          else if (window.frameElement.radWindow)
             oWindow = window.frameElement.radWindow;
          return oWindow;
        }  
        
        function closeWindow(id)
        {       
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6"
            Skin="Sunset" />
        <div>
            <div style="width: 580px">
                <asp:Label ID="Label3" runat="server" Text="Choose Class" Font-Bold="True" Font-Size="Medium"
                    Font-Names="Arial"></asp:Label><br />
                <asp:Label ID="lblInstruction2" runat="server" CssClass="FontSmall">Click on the + sign or title corresponding with the grouping containing the class you want to assign. You may review any grouping’s list of classes simply by single clicking the corresponding + sign or title. </asp:Label>
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Currently Selected Class:" CssClass="FontSmall"
                    Font-Bold="True"></asp:Label>
                &nbsp;
                <asp:Label ID="lblSelectedClass" runat="server" CssClass="FontSmall" Visible="False"></asp:Label>
                &nbsp;<asp:Label ID="lblSelectedDescription" runat="server" CssClass="FontSmall"
                    ForeColor="Red">None</asp:Label>
                <asp:Label ID="lblClassTitle" runat="server" BackColor="#FFFFC0" CssClass="FontSmall"
                    Visible="False"></asp:Label></div>
            <div>
                <div style="width: 580px">
                    <asp:Label ID="lblInstruction" runat="server" CssClass="FontSmall" Visible="False">To save your selection shown above, click the Save button below. To revise your class selection, click another class option below.</asp:Label>
                    <div id="dvtopButtons" runat="server" style="width: 300px" visible="false"> 
                        &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            Width="80px" CssClass="FontSmall" />&nbsp;
                        <asp:Button ID="Button3" runat="server" CssClass="FontSmall" OnClick="btnSave_Click"
                            Text="Save" Width="80px" /></div>
                </div>
                <asp:TreeView ID="tvClass" runat="server" OnSelectedNodeChanged="tvClass_SelectedNodeChanged"
                    ImageSet="XPFileExplorer" NodeIndent="15">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                        NodeSpacing="0px" VerticalPadding="2px" />
                </asp:TreeView>
            </div>
            <div style="height: 10px; width: 515px;">
                &nbsp; &nbsp;</div>
            <div>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                    Width="80px" CssClass="FontSmall" />&nbsp;
                <asp:Button ID="btnSave" runat="server" CssClass="FontSmall" OnClick="btnSave_Click"
                    Text="Save" Width="80px" Enabled="False" /></div>
        </div>
    </form>
</body>
</html>
