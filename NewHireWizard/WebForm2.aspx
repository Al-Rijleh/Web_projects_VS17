<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebForm2.aspx.cs" Inherits="NewHireWizard.WebForm2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Full3Cpolumn">
            <div class="Column_left">
                <div class="Column_left">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="Column_left">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="Column_left">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="Column_left">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="Column_left">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>
