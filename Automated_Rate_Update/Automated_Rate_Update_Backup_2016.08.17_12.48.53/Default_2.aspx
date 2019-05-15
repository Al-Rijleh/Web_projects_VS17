<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_2.aspx.cs" Inherits="Automated_Rate_Update.Default_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Account_Wizard.css" rel="stylesheet" type="text/css" />
    <link href="Default.css" rel="stylesheet" type="text/css" />
    <link href="/styles/main2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript">
        function remove(longdesc, classdesc, clss, id) {
            if (confirm('Are you sure you want to REMOVE ' + longdesc + ' for all continuants in class ' + clss + ' - ' + classdesc + '?')) {
                eval(document.getElementById('hidRemove')).value = clss + "~" + longdesc + "~" + id;
                PostBack();
            }
        }

        function Reactivate(longdesc, classdesc, clss, id) {
            if (confirm('Are you sure you want to REACTIVATE ' + longdesc + ' for all continuants in class ' + clss + ' - ' + classdesc + '?')) {
                eval(document.getElementById('hidReactivate')).value = clss + "~" + longdesc + "~" + id;
                PostBack();
            }
        }

        function AddCvrg(c, s, a, ret) {
            if (eval(document.getElementById('hid1')).value == '')
                window.open('Covege_Main.aspx?c=' + c + '&s=' + s + '&a=' + a + '&id=' + ret, '_self');
            else
                if (confirm('Rates were changed. Do You wish to save the rates without finalizing first') == false)
                    window.open('Covege_Main.aspx?c=' + c + '&s=' + s + '&a=' + a + '&id=' + ret, '_self');
                else {
                    eval(document.getElementById('hidSave')).value = c + '~' + s + '~' + a;
                    PostBack()
                }

        }

        function PostBack() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }

        function GetAction(param) {
            var selectedVal = "";
            var selected = $("input[type='radio'][name='" + param + "']:checked");
            if (selected.length > 0) {
                return selected.val();
            }
        }

        function htmbtAddPlan_onclick(url_) {
            window.open(url_, '_self');
        }


        function btnAdd_onclick(param) {
            window.open('Covege_Main.aspx' + param, '_self');
        }

        function btnChange__onclick(param, paramurl, ratetype, longdes, classdes, classcode, what, id) {
            var action = GetAction(param);
            if (action == 'same')
                paramurl = paramurl.replace('[actionntype]', '0');
            if (action == 'change')
                paramurl = paramurl.replace('[actionntype]', '1');
            var url_ = '';
            if (action == 'same') {
                if (ratetype == '1') {
                    url_ = "StatusRate.aspx" + paramurl;
                    window.open("StatusRate.aspx" + paramurl, '_self');
                }
                else if (ratetype == '0')
                    window.open("DoubleAgeRate.aspx" + paramurl, '_self');
                else if (ratetype == '2')
                    window.open("FamilyAgeRate.aspx" + paramurl, '_self');
            }
            else if (action == 'change') {
                window.open("NewRateType.aspx" + paramurl, '_self');
            }
            else if (action != null) {

                if (what == "A")
                    Reactivate(longdes, classdes, classcode);
                else
                    remove(longdes, classdes, classcode);
            }
            else
                alert('You must make a selection from the Radiobuttons');

        }

        function ShowSaved() {
            alert("Saved Successfully!!\n Because you accessed this program from an email, you will be redirected to Bas Home Page.");
            window.open('http://www.basusa.com', '_self');
        }

        function ShowSavedBas() {
            alert("Saved Successfully!!");
            window.open('BASLogin.aspx', '_self');
        }

        function DoSave() {
            if (confirm('Are you sure you want to finalize this update? Once you finalize you will not be able to make any changes. If you are not certain that the information you entered is correct, do not finalize and contact your account manager.') == true) {
                document.getElementById('htmImgBusy').style.visibility = "visible";
                document.getElementById('htmbtnSave').style.visibility = "hidden";
                eval(document.getElementById('hidSave')).value = 'save';
                var theForm = document.forms['form1'];
                if (!theForm) {
                    theForm = document.form1;
                }
                theForm.submit();
            }
        }

        function metal(){
              if (confirm('Are you sure you want to Update ALL Metal Rates.') == true) {
                document.getElementById('htmImgBusy').style.visibility = "visible";
                document.getElementById('htmbtnSave').style.visibility = "hidden";
                eval(document.getElementById('hidSave')).value = 'Metal';
                var theForm = document.forms['form1'];
                if (!theForm) {
                    theForm = document.form1;
                    theForm.submit();
                }
                
            }
        }

        function Rest() {
            if (confirm('Are you sure you want to Reset ALL the changes made.') == true) {
                document.getElementById('htmImgBusy').style.visibility = "visible";
                document.getElementById('htmbtnSave').style.visibility = "hidden";
                eval(document.getElementById('hidSave')).value = 'Reset';
                var theForm = document.forms['form1'];
                if (!theForm) {
                    theForm = document.form1;
                }
                theForm.submit();
            }
        }
    </script>

     <script language="javascript" type="text/javascript">         

         function OnClientclose(radWindow) {
             var retcode;

             if (radWindow.argument)
                 retcode = radWindow.argument

             if (retcode == "1") {
                 radWindow.argument = 0;
                 var hid = document.getElementById("hidAction");
                 hid.value = 'Cancel';
                 __doPostBack(null, null);
                 return;
             }

             if (retcode == "2") {
                 radWindow.argument = 0;
                 var hid = document.getElementById("hidAction");
                 hid.value = 'Reset';
                 __doPostBack(null, null);
                 return;
             }

             if (retcode == "3") {
                 radWindow.argument = 0;
                 var hid = document.getElementById("hidAction");
                 hid.value = 'Master';
                 __doPostBack(null, null);
                 return;
             }
         }

    </script>
</head>
<body>

<script type="text/javascript">
    function UseRadWindow() {
        var oWnd = $find("<%= RadWindow1.ClientID %>");
        var param = document.getElementById('hidPendCvrg').value;
        var url = "PendingCcvrgs.aspx"+param
        //alert(param);
        oWnd.show();
        oWnd.setSize(700, 400);
        oWnd.Center();
        oWnd.setUrl(url);        
        oWnd.maximize();
        oWnd.restore();
    }
    function Button1_onclick() {
        //alert('here');
        UseRadWindow();
    }

</script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
<telerik:RadWindow ID="RadWindow1" runat="server">
   </telerik:RadWindow>


    <asp:HiddenField ID="hidParam" runat="server" />
    <asp:HiddenField ID="hidRemove" runat="server" />
    <asp:HiddenField ID="hidReactivate" runat="server" />
    <asp:HiddenField ID="hidAction" runat="server" />
    <asp:HiddenField ID="hidSave" runat="server" />
    <asp:HiddenField ID="hidId" runat="server" />
    <asp:HiddenField ID="hidPendCvrg" runat="server" />
    <asp:Panel ID='Panel2' runat="server" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
        Style="margin-left: auto; margin-right: auto" HorizontalAlign="Right">
        <asp:Button ID="btnHelp" runat="server" Text="Help" CausesValidation="False" CssClass="fontsmall"
            OnClick="btnHelp_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>
    <asp:Panel ID='Panel1' runat="server" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
        Style="margin-left: auto; margin-right: auto">
        <asp:Label ID="Label1" runat="server"><span class="InstructioHeader"><strong>COBRA Insurance Premium Renewal Updates - Introduction</strong></span><br />
    <span class="Instuctiontext">Your current medical plans are listed below in sections separated by light gray horizontal lines and the benefit plan name in bold. Use the radio buttons in the yellow highlighted sections associated with each plan to perform functions to modify or remove the corresponding medical plan.</span>
        </asp:Label>
    </asp:Panel>

 <asp:Panel ID='Panel4' runat="server" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
        Style="margin-left: auto; margin-right: auto">
        <asp:Button ID="btnManagePendingPlans" runat="server" CssClass="fontsmall"
                Text="xManage Pendig Plans" CausesValidation="False" Visible="False" />
        <input id="htmBtnManagePlans" type="button" runat="server"
    value="Manage Pendig Plans" onclick="return Button1_onclick()" title="Manage pending Plans" />
        </asp:Panel>

    <asp:Panel ID="dvProcessed" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
        Style="margin-left: auto; margin-right: auto" runat="server" BackColor="#00FF99"
        HorizontalAlign="Center" Visible="False">
        <asp:Label ID="lblProcessed" runat="server" CssClass="fontsmall10" Font-Bold="True"
            ForeColor="Maroon"></asp:Label>
    </asp:Panel>
    <asp:Panel ID='pnlData' runat="server" Style="text-align: left; margin-left: auto;
        margin-right: auto" CssClass="masterwidth">
        <asp:Panel ID="pnlMessage" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
            Style="margin-left: auto; margin-right: auto" runat="server" HorizontalAlign="Right">
            <asp:Button ID="btnAddNote" runat="server" CssClass="fontsmall" OnClick="btnAddNote_Click"
                Text="Add Note to Cobra Control Services, LLC    " />
        </asp:Panel>
        <asp:Label ID="lblForm" runat="server"></asp:Label>
        <asp:Panel ID='Panel3' runat="server" CssClass="masterwidth marginbottom5 paddingbottomm5 bottomline "
            Style="margin-left: auto; margin-right: auto" HorizontalAlign="Center">
            <asp:Button ID="btnSaveDoNothing" runat="server" Text="Save AND NOT Finalize" Width="200px"
                OnClick="btnSaveDoNothing_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFinish" runat="server" Text="Save AND Finalizexxx" Width="200px"
                OnClick="btnFinish_Click" Visible="False" />
            &nbsp;<input id="htmbtnSave" type="button" value="Save AND Finalize" onclick="return DoSave()"
                style="width: 200px" />
            <img alt="" src="https://www.myenroll.com/images/smallbuzy.gif" id="htmImgBusy" style="visibility: hidden" />
            &nbsp;&nbsp;<input id="htmbtnReset" type="button" value="Reset" runat="server" onclick="return Rest()"
                style="width: 200px" />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="dvNote" runat="server" CssClass="masterwidth" Style="margin-left: auto;
        margin-right: auto" Visible="false">
        <div id="Div3" runat="server" style="width: 99%">
            <asp:Label ID="lblNoteInstruction" runat="server" CssClass="FontMedium" Font-Bold="True">Please Enter a Message to be sent to Cobra Control Services, LLC</asp:Label>
        </div>
        <div id="Div4" runat="server" style="width: 99%">
            <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" Width="99%"></asp:TextBox>
        </div>
        <div id="Div5" runat="server" style="width: 99%; height: 15px">
            &nbsp;
        </div>
        <div id="Div6" runat="server" style="width: 99%; text-align: center;">
            <asp:Button ID="btnCancelMessage" runat="server" Text="Cancel Message" OnClick="btnCancelMessage_Click"
                Width="150px" />
            <asp:Button ID="btnSaveMessage" runat="server" Text="Save Message" Width="150px"
                OnClick="btnSaveMessage_Click" />
        </div>
    </asp:Panel>
    </form>
</body>
</html>
