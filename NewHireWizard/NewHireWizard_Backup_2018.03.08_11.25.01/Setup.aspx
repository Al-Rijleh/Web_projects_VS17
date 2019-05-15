<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="NewHireWizard.Setup" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvFullPage" runat="server" class="FullPage">
        <div class="InputRow FontSmall">
          <div class="InputLabel">
              <asp:Label ID="lblShowPayPeriod" runat="server" Text="Show Pay Schedule"></asp:Label>
          </div>
          <div class="InputValue">
              <asp:RadioButtonList ID="tblShoePayPeriod" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                  <asp:ListItem Value="0">No</asp:ListItem>
              </asp:RadioButtonList> 
          </div>
          
        </div>
        <div class="InputRow FontSmall">
          <div class="InputLabel">
              <asp:Label ID="lblOtherInfoPage" runat="server" Text="Show Additional Info Page"></asp:Label>
          </div>
          <div class="InputValue">
              <asp:RadioButtonList ID="rblOtherInfoPage" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                  <asp:ListItem Value="0">No</asp:ListItem>
              </asp:RadioButtonList> 
          </div>
          
        </div>
        
        <div class="InputRow FontSmall">
          <div class="InputLabel">
              <asp:Label ID="lblAllowEnrollmentKit" runat="server" Text="Allow Creation of Enrollment Kit for Pending Employees"></asp:Label>
          </div>
          <div class="InputValue">
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                  <asp:ListItem Value="0">No</asp:ListItem>
              </asp:RadioButtonList> 
          </div>
          
        </div>
        <div class="InputRow FontSmall" style="height:10px">
          &nbsp;
        </div>
        <div class="InputRow FontSmall">
            <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div>
    </div>
    </form>
</body>
</html>
