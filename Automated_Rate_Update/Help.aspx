<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Automated_Rate_Update.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="Default.css" rel="stylesheet" type="text/css" />
    <link href="/styles/main2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="pnMaster">
        <asp:Label ID="lblHelp" runat="server" Width="650px"></asp:Label>
    </div>
    <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" 
        Width="66px" />
    </form>
</body>
</html>
