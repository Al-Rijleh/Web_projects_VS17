<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="login_error.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Access Denied</title>
    <style type="text/css">
        .fullpage
        {
            width:702px;
            font-family: Arial, Helvetica, sans-serif;
            margin-left:15px;
            margin-top:50px;
            margin-left:auto;
            margin-right:auto;
        }
        .row
        {
            width:700px;
            margin-top:10px;            
            float:left;
        }
        .label
        {
            width:150px;         
            float:left;
            font-weight: bold
        }
        .input
        {
            width:550px;         
            float:left;
        }
        .dataSetctionTitle
        {
            font-size: 10pt; 
            color:#964B4B; 
            font-weight:bolder; 
            padding-top:4px; 
            padding-bottom:4px;}
        .maincontenet
        {
            font-family:Arial; 
            font-size:9pt; 
            color:#2F2F2F;}
        
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div class="fullpage" 
        style="border-style: solid; border-width: 1px; border-color: #cccccc" id = "dvfull" runat="server">
        <div class="row dataSetctionTitle">
            <asp:Label ID="Label1" runat="server" Text="Access Denied"></asp:Label>
        </div>

        <div class="row maincontenet">
            <asp:Label ID="Label2" runat="server" Text="We are very sorry, but you do not have the access rights for this program."></asp:Label>
        </div>

        <div class="row maincontenet">
            <asp:Label ID="Label3" runat="server" >If you think you are receiving this message in error and you should be able to access 
            the program, please check the box below and submit your request. </asp:Label>
        </div>

        <div class="row maincontenet">
            <asp:Label ID="Label4" runat="server" >We will review your submission during regular office hours and respond to you accordingly. </asp:Label>
        </div>

        <div class="row maincontenet">
            <div class="label">
                <asp:Label ID="Label5" runat="server" >Program Name </asp:Label>
            </div>
            <div class="input">
                <asp:Label ID="lblProgramName" runat="server" > </asp:Label>
            </div>

            <div class="label">
                <asp:Label ID="Label8" runat="server" >Date & Time </asp:Label>
            </div>
            <div class="input">
                <asp:Label ID="lblDateTime" runat="server" >&nbsp; </asp:Label>
            </div>

            <div class="label">
                <asp:Label ID="Label6" runat="server" >User </asp:Label>
            </div>
            <div class="input">
                <asp:Label ID="lblUser" runat="server" >&nbsp; </asp:Label>
            </div>

            <div class="label">
                <asp:Label ID="Label7" runat="server" >User Type </asp:Label>
            </div>
            <div class="input">
                <asp:Label ID="lblUserType" runat="server" >&nbsp; </asp:Label>
            </div>

        </div>

        <div class="row maincontenet">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Please review my access rights for the above captioned program and contact me." />
        </div>

        <div class="row maincontenet">
            <asp:Label ID="lblInstruction" runat="server" >Upon our reviewing your access rights, we will contact about our findings by sending you an email to your address on record:<br /> <span style='color: rgb(0, 176, 80);'>[Email Address]</span>. </asp:Label>
        </div>

        <div class="row maincontenet">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" />
        </div>
    </div>
    <asp:Label ID="lblError" runat="server" Font-Bold="True" 
        Font-Names="Arial Black" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
