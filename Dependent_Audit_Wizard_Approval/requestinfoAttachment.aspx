<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requestinfoAttachment.aspx.cs" Inherits="Dependent_Audit_Wizard_Approval.requestinfoAttachment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="/styles/Main2.css" type="text/css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            width: 600px;
        }
        .class500
        {
            width: 400PX;
        }
               
        .style2
        {
            width: 300px;
        }
               
        .style3
        {
            width: 94px;
        }
        .style4
        {
            font-family: Arial;
            font-size: 9pt;
            color: #2F2F2F;
            height: 19px;
        }
               
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <table class="style1">
        <tr>
            <td class="textFont">
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="/images/BAS_Logo_ClearBkgrnd.jpg" />
            </td>
        </tr>
        <tr>
            <td align="center" 
                
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #666666" 
                class="textFont">
                <asp:Label ID="lblTitle" runat="server" 
                    Text="Dependent Audit Services - Request Information" CssClass="pageTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="textFont">
                <table class="style1">
                    <tr>
                        <td width="300">
                            <asp:Image ID="Image2" runat="server" 
                                ImageUrl="http://192.168.20.242/imgbc.aspx?bs=6&amp;bd=DEP-AUDIT-475047-5" />
                        </td>
                        <td align="left" valign="top">
                            <table class="style2">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Fax To:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="1 (888) 265-2144"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Mail To:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" >Benefit Allocation Systems, Inc.<br />Dependent Audit Department<br />PO Box 62407<br />King of Prussia, PA 19406</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textFont">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="textFont">
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Employer:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblErName" runat="server" Text="Highland Homes"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Date:"></asp:Label>
&nbsp;
                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Employee:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEE" runat="server" Text="Alcorn, Dennis (475047"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="lblDependentTitle" runat="server" Text="Dependent"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDep" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Audit ID:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAuditId" runat="server" Text="DEP-AUDIT-475047-5"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textFont">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="textFont">
                &nbsp;</td>
        </tr>
    </table>
    
    </form>
</body>
</html>

