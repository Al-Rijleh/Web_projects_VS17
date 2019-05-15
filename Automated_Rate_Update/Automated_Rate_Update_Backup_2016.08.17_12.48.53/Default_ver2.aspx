<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_ver2.aspx.cs" Inherits="Automated_Rate_Update.Default_ver2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
            if (confirm('Are you sure you want to REMOVE ' + longdesc + ' for all continuants in class ' + clss + ' - ' + classdesc + '?' + id)) {
                eval(document.getElementById('hidRemove')).value = clss + "~" + longdesc + "~" + id;
                PostBack();
            }
        }

        function Reactivate(longdesc, classdesc, clss, id) {
            if (confirm('Are you sure you want to REACTIVATE ' + longdesc + ' for all continuants in class ' + clss + ' - ' + classdesc + '?' + id)) {
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

        function btnChange__onclick(param, paramurl, ratetype) {           
            var action = GetAction(param);
            if (action == 'same')
                paramurl = paramurl.replace('[actionntype]', '0');
            if (action == 'change')
                paramurl = paramurl.replace('[actionntype]', '1');
            var url_ = '';
            if (action == 'same') {
                if (ratetype=='1') {
                    url_ = "StatusRate.aspx" + paramurl;
                    window.open("StatusRate.aspx" + paramurl, '_self');
                }
                else if (ratetype== '0')
                    window.open("DoubleAgeRate.aspx" + paramurl, '_self');
                else if (ratetype=='2')
                    window.open("FamilyAgeRate.aspx" + paramurl, '_self');
            }
            if (action == 'change') {                
                window.open("NewRateType.aspx" + paramurl, '_self');
            }
            
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidParam" runat="server" />
    <asp:Label ID="lblForm" runat="server"></asp:Label>

    </form>
</body>
</html>
