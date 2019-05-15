<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckLifeEvent.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id='dvMain' style="border: 1px solid #666666; width: 500px; margin-right: auto; margin-left: auto; margin-top: 100px;background-color:  #F5F8F8;" 
        runat="server" >
        <asp:Label ID="lblMessage" runat="server" ><span style='font-family: arial;'><strong>Have a Life Event Recently?</strong><br />
<br />
<span style='font-size: 13px;'>If you experience a permissible Life Event between June 1, 2012 and July 28, 2012, please contact the Benefits Hotline at 877-334-2111,&nbsp;<span style='font-size: 10pt; font-family: arial,sans-serif; color: black;'><a href='mailto:FDIC@basusa.com'>FDIC@basusa.com</a></span> or click on button below. <br />
<br />
</span></span></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Service Request" 
            onclick="Button1_Click" />
        <br />
    </div>
    </form>
</body>
</html>
