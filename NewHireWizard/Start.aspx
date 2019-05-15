<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Start.aspx.cs" Inherits="NewHireWizard.Start" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
      function Approve(eeNo,eename)
      {
          var bln = confirm("Are you sure you want to approve employee "+eename);
          if (bln)
          {
            document.getElementById('hid1').value = eeNo;
            PostBack();
          }
      }

      function Missing(eeNo) {
          alert('Please navigate to the Administrator tab above, and click "Manage Pending New Hires" in the Tasks Block');
      }

      function Verify(eeNo) {
          window.open("/web_projects/New_Hire_Verification_of_Eligibility_Approval/Approve.aspx?from=ee&EENo=" + eeNo, '_top');
      }
      
      function DisApprove(eeNo,eename)
      {
          var bln = confirm('Are you sure you want to Decline employee '+eename);
          if (bln)
          {
            document.getElementById('hid2').value = eeNo;
            PostBack();
          }
      }
      
      function RemovePend(eeNo)
      {
          var bln = confirm('Are you sure you want to Remove this employee ');
          if (bln)
          {
            document.getElementById('hid3').value = eeNo;
            PostBack();
          }
      }
      
      function PostBack() 
      {
           var theForm = document.forms['form1'];
           if (!theForm) 
           {
               theForm = document.form1;
           }
          if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
           {                
               theForm.submit();
           }
      }  
      
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6"
            Skin="Sunset" />
        <div class="FullPage">
            <div class="InputRow">
                <asp:Label ID="lblInstruction" runat="server" CssClass="FontSmall"><b>Welcome to New Hire Wizard Program</b><br>Please select the action you wish to perform from the options&nbsp; below</asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="InputRow FontSmall">
                <asp:Button ID="btnStartNewEmployee" runat="server" Text="Add New Employee" 
                    OnClick="btnStartNewEmployee_Click" Width="140px" />
                <asp:Button ID="btnIncompleteNewHire" runat="server" Text="Access Incomplete New Hire Records"
                    OnClick="btnIncompleteNewHire_Click" Width="240px" />
                <asp:Button ID="btnPendingNewHireRecords" runat="server" Text="Access Complete but Pending New Hire Records"
                    OnClick="btnPendingNewHireRecords_Click" Width="300px" />
                <asp:HiddenField ID="hid1" runat="server" />
                <asp:HiddenField ID="hid2" runat="server" />
                <asp:HiddenField ID="hid3" runat="server" />
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            <div class="InputRow FontSmall" id="dvMessage" runat="server" visible="false">
                <asp:Label ID="lblInst" runat="server" Visible="False"><p class="MsoNormalCxSpMiddle" style="line-height: normal">
When it is confirmed that a prospective employee has reported to duty, click APPROVE to move the 
employee from PENDING to ACTIVE.&nbsp; If you approve an employee in error, you will 
not be able to move the employee back into pending status and will need to 
contact BAS.</p>
<p class="MsoNormalCxSpMiddle" style="line-height: normal">If 
a prospective employee does not report to work and will not become an active 
employee, click DECLINE.&nbsp; This will terminate the pending record.&nbsp; If you 
decline an employee in error, the terminated record cannot be recovered and you 
will need to reenter the employee in the New Hire Wizard.</p>
                </asp:Label>
            </div>
            <div class="InputRow FontSmall" runat="server" id="dvGrid" visible="false">
                &nbsp;<asp:GridView ID="gvIncomp" runat="server" AutoGenerateColumns="False" Width="740px"
                    OnRowCreated="gvIncomp_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <HeaderStyle CssClass="BackColor" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="account_name" HeaderText="Account Name" />
                        <asp:BoundField DataField="ee_name" HeaderText="Employee Name" />
                        <asp:BoundField DataField="effective_date" HeaderText="Effective Date" />
                        <asp:BoundField DataField="description" HeaderText="Class Description" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblNoIncomplete" runat="server" CssClass="FontSmall10" Font-Bold="True"
                    ForeColor="Maroon" Text="There is no incomplete employee to process. " Visible="False"></asp:Label>
            </div>
            <div class="InputRow FontSmall" id="dvGridPend" runat="server" visible="false">
                <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" Width="740px"
                    OnRowCreated="gvPending_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <HeaderStyle CssClass="BackColor" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="account_name" HeaderText="Account Name" />
                        <asp:BoundField DataField="ee_name" HeaderText="Employee Name" />
                        <asp:BoundField DataField="effective_date" HeaderText="Effective Date" />
                        <asp:BoundField DataField="description" HeaderText="Class Description" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblNoPending" runat="server" CssClass="FontSmall10" Font-Bold="True"
                    ForeColor="Maroon" Text="There is no pending employee to process. " Visible="False"></asp:Label>
            </div>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
