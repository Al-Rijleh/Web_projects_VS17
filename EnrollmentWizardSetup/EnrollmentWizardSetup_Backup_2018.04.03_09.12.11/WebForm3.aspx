<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="EnrollmentWizardSetup.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px; border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid;">
            <tr>
                <td style="width: 150px; height: 19px; border-right: silver 1px solid;" align="center">
                    <strong><span style="font-size: 10pt; font-family: Arial">
                Open Enrollment</span> </strong>
                </td>
                <td style="width: 150px; height: 19px; border-right: silver 1px solid;" align="center">
                    <span style="font-size: 10pt; font-family: Arial"><strong>
                New Hire</strong></span>
                </td>
                <td style="width: 150px; height: 19px; border-right: silver 1px solid;" align="center">
                    <strong><span style="font-size: 10pt; font-family: Arial">
                Life Event </span></strong>
                </td>
                <td style="width: 150px; height: 19px; " align="center">
                    <strong><span style="font-size: 10pt; font-family: Arial">
                Normal Use</span> </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 150px; height: 19px; border-right: silver 1px solid;" align="center">
                    <asp:Label ID="lblOpenEnrollment" runat="server" CssClass="FontSamll" Text="Label"></asp:Label></td>
                <td style="width: 150px; height: 19px; border-right: silver 1px solid;" align="center">
                    <asp:Label ID="lblNewHire" runat="server" CssClass="FontSamll" Text="Label"></asp:Label></td>
                <td style="width: 150px; height: 19px; border-right: silver 1px solid;" align="center">
                    <asp:Label ID="lblLifeEvent" runat="server" CssClass="FontSmall" Text="Label"></asp:Label></td>
                <td style="width: 150px; height: 19px; " align="center">
                    <asp:Label ID="NormalUse" runat="server" CssClass="FontSmall" Text="Label"></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
