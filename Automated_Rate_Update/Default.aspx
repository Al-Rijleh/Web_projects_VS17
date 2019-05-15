<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Automated_Rate_Update._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Automated Rates Renewal</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="Default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .BadNumber
        {
            color: White;
            background-color: Red;
        }
    </style>
    <script src="/js/StyleSetter.js" type="text/javascript"></script>
    <script src="/js/BAS_Utility.js" type="text/javascript"></script>
    <script type="text/javascript">
        function cb(chk) {
//            alert(chk.checked + ' ' + chk.id);
            if (chk.checked)
                eval(document.getElementById('hidCB')).value += '~1' + chk.id;
            else
                eval(document.getElementById('hidCB')).value += '~0' + chk.id;                                    
        }

        function changedDate(txtbox, txtid) {
            alert(txtid + " " + txtbox.value);
            alert(txtbox.id);
            var fntx = eval(document.getElementById('gvRates_ctl04_txt_1063211'));
            alert(fntx);
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


        function ShowSaved() {
            alert("Saves Successfully!!\n Because you accessed this program from an email, you will be redirected to Bas Home Page.");
            window.open('http://www.basusa.com', '_self');
        }

        function ShowSavedBas() {
            alert("Saves Successfully!!\n Because you accessed this program from an email, you will be redirected to Bas Home Page.");
            window.open('BASLogin.aspx', '_self');
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode == 46)
                return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function IsNumeric(sText) {
            if (sText == '')
                return false;
            var ValidChars = "0123456789.";
            var IsNumber = true;
            var Char;
            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;
        }

        function round_decimals(original_number, decimals) {
            var result1 = original_number * Math.pow(10, decimals);
            var result2 = Math.round(result1);
            var result3 = result2 / Math.pow(10, decimals);
            return result3;
        }

        function calc(ob) {
            var indx = ob.id.substring(9);
            if (parseFloat(ob.value) == 0) {
                ob.focus();
                ob.style.background = 'Red';
                ob.style.color = 'white';
                eval(document.getElementById('btnSavePend')).disabled = true;
                eval(document.getElementById('btnSave')).disabled = true;
                alert('Rate value may not be Zero');
                return false;
            }
            ob.style.background = 'white';
            ob.style.color = 'black';
            eval(document.getElementById('btnSavePend')).disabled = false;
            eval(document.getElementById('btnSave')).disabled = false;


            eval(document.getElementById('hid1')).value += '[' + ob.id + '=' + ob.value + ']';


            obmainrate = eval(document.getElementById('txtmarate' + indx))
            oberrate = eval(document.getElementById('txterrate' + indx))
            obeerate = eval(document.getElementById('txteerate' + indx))


            mainrate = eval(document.getElementById('txtmarate' + indx)).value;
            errate = eval(document.getElementById('txterrate' + indx)).value;
            eerate = eval(document.getElementById('txteerate' + indx)).value;

            if (!IsNumeric(mainrate)) mainrate = 0; else mainrate = round_decimals(parseFloat(mainrate), 2)
            if (!IsNumeric(errate)) errate = 0; else errate = round_decimals(parseFloat(errate), 2)
            if (!IsNumeric(eerate)) eerate = 0; else eerate = round_decimals(parseFloat(eerate), 2)

            //if (obeerate.disabled)
            {
                eerate = mainrate - errate;
                obeerate.value = round_decimals(eerate, 2);
                eval(document.getElementById('hid1')).value += '[' + obeerate.id + '=' + obeerate.value + ']';
            }


            //		var dif = Math.abs(mainrate -errate - eerate);


            //		if (dif > 0.0001)
            //		{
            //			obmainrate.style.backgroundColor = "#FF0000";		
            //			oberrate .style.backgroundColor = "#FF0000";
            //			obeerate .style.backgroundColor = "#FF0000";
            //			
            //			obmainrate.style.color = "#FFFFFF";	
            //			oberrate .style.color = "#FFFFFF";
            //			obeerate .style.color = "#FFFFFF";	
            //			eval(document.getElementById('hidError')).value += "["+obmainrate.id+"=1]";
            //		}		
            //		else
            //		{
            //			obmainrate.style.backgroundColor = "#FFFFFF";		
            //			oberrate .style.backgroundColor = "#FFFFFF";
            //			obeerate .style.backgroundColor = "#FFFFFF";
            //			
            //			obmainrate.style.color = "#000000";	
            //			oberrate .style.color = "#000000";
            //			obeerate .style.color = "#000000";
            //            eval(document.getElementById('hidError')).value += "["+obmainrate.id+"=0]";
            //		}
        }

        function forceClac(obName) {
            var ob = eval(document.getElementById(obName));
            if (ob == null)
                setTimeout(forceClac(obName), 1000);
            calc(ob);
        }

        function remove(longdesc, classdesc, clss) {
            if (confirm('Are you sure you want to REMOVE ' + longdesc + ' for all continuants in class ' + clss + ' - ' + classdesc + '?')) {
                eval(document.getElementById('hidRemove')).value = clss + "~" + longdesc;
                PostBack();
            }
        }

        function Reactivate(longdesc, classdesc, clss) {
            if (confirm('Are you sure you want to REACTIVATE ' + longdesc + ' for all continuants in class ' + clss + ' - ' + classdesc + '?')) {
                eval(document.getElementById('hidReactivate')).value = clss + "~" + longdesc;
                PostBack();
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

        function Button1_onclick() {

        }

    </script>
    <style>

 p.MsoNormal
	{mso-style-parent:"";
	margin-bottom:.0001pt;
	font-size:10.0pt;
	font-family:"Arial","serif";
	margin-left:0in; margin-right:0in; margin-top:0in}

</style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:HiddenField ID="hidError" runat="server" />
    <asp:HiddenField ID="hid1" runat="server" />
    <asp:HiddenField ID="hid2" runat="server" />
    <asp:HiddenField ID="hidRemove" runat="server" />
    <asp:HiddenField ID="hidReactivate" runat="server" />
    <asp:HiddenField ID="hidSave" runat="server" />
    <asp:HiddenField ID="hidParam" runat="server" />
    <asp:HiddenField ID="hidCB" runat="server" />
    <table id="tbMain" border="0" width="100%" cellspacing="0" cellpadding="0" runat="server">
    <tr>
    <td>
    <div style="text-align: left; margin-left: auto; margin-right: auto; width: 600px">
    <table border="0" width="600px" cellspacing="0" cellpadding="0" >
     <tr>
    <td>
        <asp:Image ID="Image1" runat="server" 
            ImageUrl="~/Img/BAS-Cobra-Logo-RGB (2).jpg" Width="120px" />
    </td>
     <td style="text-align: right">
         <asp:Image ID="Image2" runat="server" 
             ImageUrl="~/Img/BAS-MyEnroll-Logo-RGB.jpg" Width="120px" />
    </td>
    </tr>
    </table>
    </div>
    </td>
    </tr>
        <tr>
            <td align="center" style="padding: 10px; height: 110px">
                <div style="text-align: left; margin-left: auto; margin-right: auto; width: 600px">
                    <asp:Label ID="lblInstuction" runat="server" BorderColor="Black" BorderStyle="Solid"
                        BorderWidth="1px" Width="600px">
                       



<p class="MsoNormal"><strong>Welcome to the COBRA Control Plans and Rates Update
Program for [Account Name]</strong></p>
<p class="MsoNormal"><strong>&nbsp;</strong></p>
<p class="MsoNormal"><strong><span style="text-decoration: underline; color: red;">Please Read these
Instructions Carefully</span></strong></p>
<p class="MsoNormal"> </p>
<p class="MsoNormal"><strong>1.</strong>&nbsp; The <strong>Default effective date</strong> for updates
you make on this page will be effective<strong><span style="color: red;"> [Date].
</span></strong>To change the effective date, please contact us at
<a href="mailto:Service@CobraControl.com" style="color: blue; text-decoration: underline;">
<span style="color: blue;">Service@CobraControl.com</span></a><strong><span style="color: red;">
</span></strong></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><strong>2.</strong>&nbsp; All rate/premium entries <b>
<font color="#FF0000">SHOULD EXCLUDE the 2% </font></b>COBRA administration Fee.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><strong>3.</strong>&nbsp; To <strong>Add a New Plan</strong> to your plan offerings
shown below, click the button below titled "Add a New Dental Plan" or "Add a
Medical Plan" etc. When you choose to add a plan, it will appear on the screen
highlighted in yellow.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><strong>4.</strong>&nbsp; To <strong>Remove a plan</strong> from your plan offerings
shown below, click the "Remove" button located at the right of the plan&rsquo;s name
shown in red. When you choose to remove a plan, it will remain on the screen but
highlighted in light pink</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><b>5</b>.&nbsp; You can <strong>Add a note</strong> for our service team by
clicking the button titled "Add Note to COBRA Control Services, LLC."</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><b>6</b>. If you decide to do some work now and return later to
continue your editing, click the "Save Do NOT Finalize" button at the bottom of
this screen. You editing will be saved and you can return later. </p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><b>7</b>.&nbsp; If you have completed your updates and want to finalize
your data, click the "Save AND Finalize" button at the bottom of this screen.</p>

                        
                        </asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="dvProcessed" style="width: 600px; background-color: #00FF99; padding-bottom: 10px;margin-top:10px"
                    runat="server">
                    <asp:Label ID="lblProcessed" runat="server" CssClass="fontsmall10" Font-Bold="True"
                        ForeColor="Maroon"></asp:Label>
                </div>
                <div id="dvEffectiveDate" style="width: 600px; background-color: #ffffcc;">
                    <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date of Rate Change:"
                        CssClass="fontsmall10"></asp:Label>
                    <asp:DropDownList ID="ddlEffectiveDate" runat="server" CssClass="fontsmall10" Width="290px">
                    </asp:DropDownList>
                </div>
                <div style="width: 600px; border-right: black 1px solid; border-top: black 1px solid;
                    border-left: black 1px solid; border-bottom: black 1px solid;">
                    <div id="Div1" style="width: 525px;">
                        <asp:HyperLink ID="hlAddMedical" runat="server" Font-Bold="True" 
                            Visible="False">Add A New Medical Plan</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="hlAddDental" runat="server" Font-Bold="True" Visible="False">Add A New Dental Plan</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="hlAddVision" runat="server" Font-Bold="True" Visible="False">Add A New Vision Plan</asp:HyperLink>
                    </div>
                    <div id="Div2" style="width: 600px; text-align: center; ">
                        <asp:Button ID="btnAddNote" runat="server" CssClass="fontsmall" 
                            onclick="btnAddNote_Click" Text="Add Note to Cobra Control Services, LLC    " />
                        </div>
                    <asp:GridView ID="gvRates" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CellPadding="0" OnRowCreated="gvRates_RowCreated" Width="595px">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="fontsmall" Font-Bold="True" BorderStyle="None" />
                                <ItemStyle CssClass="fontsmall" Font-Bold="False" VerticalAlign="Bottom" BorderStyle="None" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnSavePend" runat="server" OnClick="btnSavePend_Click" Text="Save Do NOT Finalize"
                        Width="175px" />
                    <asp:Button ID="btnSave" runat="server" Text="Save AND Finalize" Width="175px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset All Data" Width="175px" 
                        OnClick="btnReset_Click" />
                    <br />&nbsp;
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="Repeater1_ItemCreated">
                    </asp:Repeater>
                    &nbsp;<asp:CheckBox ID="cbAutoCalcEERate" runat="server" AutoPostBack="True" OnCheckedChanged="cbAutoCalcEERate_CheckedChanged"
                        Visible="False" />
                </div>
            </td>
        </tr>
    </table>
    <div id="dvNote" runat="server"  style="width: 100%; margin-left:auto; margin-right:auto">
        <div id="Div3" runat="server"  style="width: 99%">
            <asp:Label ID="lblNoteInstruction" runat="server" CssClass="FontMedium" 
                Font-Bold="True">Please Enter a Message to be sent to Cobra Control Services, LLC</asp:Label>
        </div>
        <div id="Div4" runat="server"  style="width: 99%">
            <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" 
                Width="99%"></asp:TextBox>
        </div>
        <div id="Div5" runat="server"  style="width: 99%; height:15px">
        &nbsp;
        </div>
        <div id="Div6" runat="server"  style="width: 99%; text-align: center;">
            <asp:Button ID="btnCancelMessage" runat="server" Text="Cancel Message" 
                onclick="btnCancelMessage_Click" Width="150px" />
            <asp:Button ID="btnSaveMessage" runat="server" Text="Save Message" 
                Width="150px" onclick="btnSaveMessage_Click" />
        </div>
    </div>
    </form>
 <span ></span>
</body>
</html>
