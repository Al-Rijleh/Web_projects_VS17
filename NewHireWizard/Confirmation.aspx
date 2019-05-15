<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Confirmation.aspx.cs" Inherits="NewHireWizard.Confirmation" %>

<%@ Register Src="TabStrip.ascx" TagName="TabStrip" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
      function DoSave(btn) {
        eval(document.getElementById('hidSave')).value='Go';
        btn.disabled = true;
        try { eval(document.getElementById('htmbtnPend')).disabled = true; }
        catch (err) { }
        //PostBack();
       
        __doPostBack(null, null);
      }
      
      function DoPend(btn)
      {
        eval(document.getElementById('hidSave')).value='Pend';
        btn.disabled = true;
        try{
        eval(document.getElementById('htmbtnSave')).disabled = true;
        }
        catch (err) { }
        //PostBack();
        __doPostBack(null, null);  
      }
      
      
      function DoSave2()
      {
        eval(document.getElementById('hidSave')).value='Go'; 
        eval(document.getElementById('htmbtnSave')).visible = false;
        eval(document.getElementById('htmbtnPend')).visible = false;
        
        PostBack();  
        
        //__doPostBack(null, null);
      }


      var theForm = document.forms['form1'];
      if (!theForm) {
          theForm = document.form1;
      }
      function PostBack() {
          if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
              theForm.__EVENTTARGET.value = eventTarget;
              theForm.__EVENTARGUMENT.value = eventArgument;
              theForm.submit();
          }
      }

    </script>

    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="Default, Textbox, Textarea, Fieldset, Label, H4H5H6"
            Skin="Sunset" />
        <uc1:TabStrip ID="TabStrip1" runat="server" />
        <div class="Blank10">
            &nbsp;
        </div>
        <div id="dvFullPage" runat="server" class="FullPage FontSmall" visible="True">
            <div class="StatusInputRowTitle">
                <asp:Label ID="lblTitle" runat="server" CssClass="InsideTitle">Confirmation of New Hire</asp:Label>
            </div>
            <div class="Blank10">
                &nbsp;
            </div>
            
            <div class="StatusInputRowTitle">
                <asp:Label ID="lblInstruction" runat="server" CssClass="FontSmall" ></asp:Label>
            </div>
            
            <div class="Blank10">
                &nbsp;
            </div>
            
            <div class="StatusInputRowTitle">
                <div class="InputLabel" style="width: 120px">
                    <asp:Label ID="lblAccount" runat="server" Text="Account/Location" Font-Bold="True"></asp:Label>
                </div>
                <div class="InputValidator" style="width: 470px">
                    <asp:Label ID="lblEmployerName" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="StatusInputRowTitle">
                <div class="InputLabel" style="width: 120px">
                    <asp:Label ID="LBL_FLDTrustorTitle" runat="server" Text="Trustor" Font-Bold="True"></asp:Label>
                </div>
                <div class="InputValidator">
                    <asp:Label ID="lblTrustor" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="StatusInputRowTitle">
                <div class="InputLabel" style="width: 120px">
                    <asp:Label ID="lblEmployee" runat="server" Text="Employee" Font-Bold="True"></asp:Label>
                </div>
                <div class="InputValidator">
                    <asp:Label ID="lblSavedSuccessfully" runat="server" CssClass="FontSmall" Font-Bold="False">New Hire [Name] Created Successfully!</asp:Label>
                </div>
            </div>
            <div id="dvStatus" runat="server" class="StatusInputRowTitle" visible="false">
                <div class="InputLabel" style="width: 120px">
                    <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Bold="True"></asp:Label>
                </div>
                <div class="InputValidator">
                    <asp:Label ID="lblStatusText" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="StatusInputRowTitle">
                <div class="InputLabel" style="width: 120px">
                    <asp:Label ID="lblClasscode" runat="server" Text="Class Code" Font-Bold="True"></asp:Label>
                </div>
                <div class="InputValidator">
                    <asp:Label ID="lblClass" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="StatusInputRowTitle">
                <div class="InputLabel" style="width: 120px">
                    <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="True"></asp:Label>
                </div>
                <div class="InputValidator">
                    <asp:Label ID="lblAddress1" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="StatusInputRowTitle">
                &nbsp;</div>
            <div class="Blank10">
            </div>
            <div class="Blank10">
            </div>
            <div class="Blank10">
            </div>
            <div class="ButtonRow">
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel"
                    Width="75px" Visible="False" />
                <asp:Button ID="btnNext" runat="server" Text="Save" Width="75px" OnClick="btnNext_Click" Visible="False" />&nbsp;
                <input id="htmbtnPend" style="width: 75px" type="button" value="Pend" runat="server" onclick="DoPend(this)" visible="true" />
                <input id="htmbtnSave" style="width: 75px" type="button" value="Approve" runat="server" onclick="DoSave(this)"/>
                <asp:HiddenField ID="hidSave" runat="server" />
            </div>
            <div class="Blank10">
            </div>
            <div class="ButtonRow">
                <asp:Button ID="btnAddAnotherNewHire" runat="server" Text="Add Another New Hire"
                    Width="280px" Visible="False" OnClick="btnAddAnotherNewHire_Click" />
            </div>
            <div class="ButtonRow">
                <asp:Button ID="btnGotoPendingNewHiresAdministration" runat="server" Text="Go to Pending New Hires Administration "
                    Width="280px" Visible="False" OnClick="btnGotoPendingNewHiresAdministration_Click" />
            </div>
            <div class="ButtonRow">
                <asp:Button ID="btnReturntoAdministrationHomepage" runat="server" Text="Return to Administration Homepage"
                    Width="280px" Visible="False" OnClick="btnReturntoAdministrationHomepage_Click" />
            </div>
        </div>

        <div id='dvVerify' class="FullPage" runat ="server">
        <iframe id="iverify" runat="server" frameborder="0" name="Verify Documents" scrolling="auto"
                        title="Verify Documents" style="width: 790px; height: 850px" 
                        
                
                src="/web_projects/New_Hire_Verification_of_Eligibility/Default.aspx?SkipCheck=YES&EENo=-48915"></iframe>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%>
<% Response.Expires = -1; %>
</html>
