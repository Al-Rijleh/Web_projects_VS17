<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dependent_Audit_Wizard_Approval.Default" %>

<%@ Register assembly="PdfViewerAspNet" namespace="PdfViewer4AspNet" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="/styles/Main2.css" type="text/css" rel="stylesheet">
    <link href="Main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px; margin-left: auto; margin-right: auto">
        <div style="width: 1000px; height: 100px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCE8F9;">
            <iframe name="Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame"
                style="width: 1002px; height: 95px" src="http://localhost/web_projects/PTemplate/top.aspx"
                frameborder="0" scrolling="no"></iframe>
        </div>
        <div class="FullPage" style="width: 990px">
            <div class="DataPagFullPagee" style="margin-bottom: 4px">
                <asp:Label ID="lblMessage" runat="server" Text="Dependent Audit - Approval" 
                    CssClass="pageTitle"></asp:Label>
            </div>
            <div class="FullPage" style="margin-bottom: 10px">
                <asp:Label ID="Label1" runat="server" CssClass="textFont">Please complete this survey below. Click the "Complete" Button when you are finished</asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="FullPage" style="width: 1000px;">
                <div style="width:600px; float:left">
                <cc1:PdfViewer ID="PdfViewer1" runat="server" Width="600px">
                </cc1:PdfViewer>
                </div>
                <div style="width:395px; float:right">
                &nbsp;
                <asp:Label ID="Label2" runat="server" CssClass="textFont">Please complete this survey below. Click the "Complete" Button when you are finished</asp:Label>
                </div>
            </div>

        </div>
        <div>
        </div>
    </div>
    </form>
</body>
</html>
