<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="Employee_Search.Finish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidbtndName" runat="server" />
        <asp:HiddenField ID="Hidstrpy1" runat="server" />
        <asp:HiddenField ID="Hidstrpy2" runat="server" />
        <asp:HiddenField ID="Hidstrpy3" runat="server" />
        <asp:HiddenField ID="HidretURL" runat="server" />
        <asp:HiddenField ID="HidEnroll" runat="server" />
        <asp:HiddenField ID="HidRun" runat="server" />
        <div>
        </div>

        <script type="text/javascript">            

            function Go() {

                var stBarName = document.getElementById('hidbtndName').value;
                var strEnroll = document.getElementById('HidEnroll').value;
                var strpy1 = document.getElementById('Hidstrpy1').value;
                var strpy2 = document.getElementById('Hidstrpy2').value;
                var strpy3 = document.getElementById('Hidstrpy3').value;
                var retURL = document.getElementById('HidretURL').value;
                
                try { window.top.setSearch(stBarName,strEnroll,strpy1, strpy2, strpy3, retURL); } catch (err) { }

                //try { window.top.setSearch(retURL); } catch (err) { }
            }

            

            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            function PostBack() {

                if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                    theForm.submit();
                }
            }
        </script>

    </form>
</body>
</html>
