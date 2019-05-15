<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProofPage.aspx.cs" Inherits="StartLifeEventv1.ProofPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scan Documents</title>
    <link href="Local.css" rel="stylesheet" />
    <link href="main2.css" rel="stylesheet" />
    <link href="Life.css" rel="stylesheet" />
    <script src="js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="js/FSACommon.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function FileTimedOut() {
            alert('Your File Timed out');
            window.open('ProofPage.aspx', '_self');
        }
        var invalidFiles = [];
        var erreored
        function DoUpload() {
            //try { document.getElementById('btnSubmit').disabled = true; } catch (e) { }
            try { document.getElementById('btnCancel').disabled = true; } catch (e) { }
            document.getElementById('htmImgBusy').style.visibility = "visible";
            document.getElementById('dvprocess').style.visibility = "visible";
            __doPostBack(null, null);
        }

        function docloseWindow(id) {
            closeWindow(id); return false;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function closeWindow(id) {
            var currentWindow = GetRadWindow();
            currentWindow.argument = id;
            currentWindow.Close();
        }

        function htmbtnColse_onclick() {
            var id = document.getElementById('hidUpload').value;
            closeWindow(id)
        }

        function Go(strLE_EE_ID) {
            //alert('Go'+ strLE_EE_ID)
            try { window.parent.refreshDoc(strLE_EE_ID); } catch (err) { }

        }
        function Remove(docid) {
            if (confirm('Are you sure you want to remove this documnet?')) {
                document.getElementById('hidRemove').value = docid;

                __doPostBack(null, null);
            }
            else
                return;
        }
    </script>
    <link rel="Stylesheet" href="../../Styles/Main2.css" type="text/css" />
    <style type="text/css">
        /** Validation error */
        .ruError {
            padding: 5px 5px 5px 20px;
            border: 1px solid #ef0000;
            background: #f9e8e8;
        }

            .ruError .ruFileWrap {
                height: auto;
                overflow: visible !important;
                display: block;
            }

            .ruError .ruUploadProgress {
                margin-left: -18px;
                display: block;
            }

            .ruError .ruUploadFailure {
                background-position: 2px 80%;
            }
            /* Error */
            .ruError .ruErrorMessage {
                display: block;
                color: #ef0000;
                font-variant: small-caps;
                text-transform: lowercase;
                padding-bottom: 0;
            }
    </style>
    <style type="text/css">
        .pageTitle {
            font-size: 12pt;
            font-weight: bolder;
            padding-bottom: 3px;
            padding-top: 3px;
        }

        .separatedSpace {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .textFont {
            font-family: Arial;
            font-size: 9pt;
            color: #2F2F2F;
        }

        .NoBorder {
            border-width: 0 0 1px 0;
        }
    </style>
    <style type="text/css">
        div.RadUpload .ruFakeInput {
            visibility: hidden;
            width: 0;
            padding: 0;
        }

        div.RadUpload .ruFileInput {
            width: 1;
        }
    </style>
    <script type="text/javascript" id="telerikClientEvents1">
        //<![CDATA[

        function RadAsyncUpload1_ValidationFailed(sender, args) {

            //                //This event happens client-side and is only fired when the file is the wrong extension or the wrong size.
            //                //alert("Validation Failed event before:\nInvalid Files: " + invalidFiles.length);
            //                invalidFiles.push(eventArgs.get_fileName());
            //                //alert("Validation Failed event after:\nInvalid Files: " + invalidFiles.length + "\nFile added: " + eventArgs.get_fileName());
            //                var errorMessage = 'File is not a valid file type. Please refer to the list above for valid file types.';
            //                DisplayFileError(radUpload, eventArgs, errorMessage);
            //                PopulateErrorLabelAndButtons(radUpload);

            var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
            if (args.get_fileName().lastIndexOf('.') != -1) {//this checks if the extension is correct
                if (sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                    //alert("Wrong Extension!");
                    var error = document.getElementById('lblFileErr').innerHTML;
                    if (error != null) {
                        error = error;  //+ '<br />';
                    }
                    alert(error + "Wrong Extension! " + args.get_fileName() + " will not be uploaded");
                    //document.getElementById('lblFileErr').innerHTML =error+ "Wrong Extension! <b>" + args.get_fileName() + "</b> will not be uploaded";
                }
                else {
                    //alert("Wrong file size!");
                    document.getElementById('lblFileErr').innerHTML = document.getElementById('lblFileErr').innerHTML +
                     "<br />Wrong file size! " + args.get_fileName() + " will not be uploaded";
                }
            }
            else {
                //alert("not correct extension!");
                document.getElementById('lblFileErr').innerHTML = "not correct extension! " + args.get_fileName() + " will not be uploaded";
            }
            erreored = true;
            DeleteInvalidFiles();
        }


        //]]>
    </script>
    <script type="text/javascript" id="telerikClientEvents2">
        //<![CDATA[

        function RadAsyncUpload1_FileUploadFailed(sender, args) {
            //alert('here');
            DeleteInvalidFiles();
        }
        //]]>
    </script>
    <script type="text/javascript" id="telerikClientEvents3">
        //<![CDATA[

        function RadAsyncUpload1_FileUploaded(sender, args) {
            var hidcnt = document.getElementById('hidcount');
            hidcnt.value = hidcnt.value + "1";
            //alert(hidcnt.value);
        }

        function RadAsyncUpload1_FilesUploaded(sender, args) {

            //document.getElementById('RadAsyncUpload1').style.visibility = 'hidden';
            //alert(document.getElementById('hidcount').value);
            //alert('here');
            var dv = document.getElementById('dvSavemessg');
            dv.style.visibility = 'visible';
            var btn = document.getElementById('btnSubmit');
            //alert(btn.disabled);
            btn.disabled = false;
            //alert(btn.disabled);
            btn.style.visibility = 'visible';
        }

        function DisableObj(id) {
            //alert(id);
            //$('#btnSubmit').prop('disabled', true);
            //alert(document.getElementById(btnSubmit).disabled);
        }
        //]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI"
                    Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI"
                    Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI"
                    Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>


        <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
        <asp:HiddenField ID="hidUpload" runat="server" />
        <asp:HiddenField ID="hidcount" runat="server" />
        <asp:HiddenField ID="hidRemove" runat="server" />
        <%--<asp:Label ID="lblScript" runat="server"></asp:Label>--%>        <%--<div class="textFont LeftArea" >
        <div class='LeftArea dataSubSetctionTitle BottomEdge '>
                    <asp:Label ID="lblUploadOptioTitle" runat="server" Text="Upload Option"></asp:Label>
                </div>
    </div>--%>      <%--  <div class="LeftArea">
            &nbsp;
        </div>--%>

        <div class="LeftArea" style="width: 100%">
            <%--<div class="separatedSpace LeftArea">
            </div>--%>
            <div class="LeftArea">
                <asp:Label ID="lblFileErr" runat="server" CssClass="errMsgLabel" />
            </div>

            <div id="dvupload" runat="server" style="float: left; padding-top: 25px; padding-bottom: 15px;" class="LeftArea">
                <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" OnFileUploaded="RadAsyncUpload1_FileUploaded"
                    AllowedMimeTypes="application/pdf" AllowedFileExtensions=".pdf"
                    MultipleFileSelection="Disabled"
                    MaxFileSize="1073741824"
                    ToolTip="File selection tool: Click Browse to choose one or more files from your computer. Once files are chosen, click Remove File to delete a selection."
                    OnClientValidationFailed="validationFailed"
                    OnClientFilesUploaded="RadAsyncUpload1_FilesUploaded"
                    OnClientFileUploaded="RadAsyncUpload1_FileUploaded"
                    TemporaryFolder="~/App_Data"
                    TemporaryFileExpiration="00:55:00" ResolvedRenderMode="Classic" Width="300px"
                    MaxFileInputsCount="1"
                    InitialFileInputsCount="1">
                </telerik:RadAsyncUpload>
            </div>
            <%--<div class="separatedSpace LeftArea">
    </div>--%>

            <%--<div id="Div5" runat="server" style="float: left; padding-left: 7px;" class="LeftArea">
                <asp:Label ID="lblTime" runat="server"  CssClass="FontSmall" ForeColor="Red"></asp:Label>
            </div>--%>

            <div id="Div3" runat="server" style="float: left; padding-left: 7px;" class="LeftArea">
                <asp:Label ID="lblUploadComments" runat="server" Text="Comments" CssClass="FontBold"></asp:Label>
            </div>
            <div id="Div1" runat="server" style="float: left; padding-left: 7px; margin-bottom: 5px;" class="LeftArea">
                <telerik:RadTextBox ID="txtmsgUpload" runat="server" Height="100px" TextMode="MultiLine" Width="200px">
                </telerik:RadTextBox>
            </div>

            <div id='dvSavemessg' style="visibility: hidden; margin-top: 5px; margin-bottom: 5px;">
                <asp:Label ID="lblSaveMsg" runat="server" CssClass="fontsmallbold"
                    Text="Save your file by clicking the Submit button below"
                    Font-Bold="True" ForeColor="Maroon" />
            </div>
            <div id="Div4" runat="server" style="float: left; padding-left: 7px;" class="LeftArea">
                <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit"></telerik:RadButton>
                <%--<asp:Button ID="btnUpload" runat="server" Text="Submitxxxxx" Style="visibility: hidden"  />--%>
            </div>
            <div id="Div2" runat="server" style="float: left; margin-top: 15px; width: 220px; height: 100px;" class="LeftArea">
                <telerik:RadGrid ID="rgDoc" runat="server" class="LeftArea" OnNeedDataSource="rgDoc_NeedDataSource"
                    Width="220px" CssClass="NoBorder" Height="61px">

<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                    <MasterTableView NoMasterRecordsText="">
                    </MasterTableView>

                </telerik:RadGrid>
            </div>
        </div>


        <div class="LeftArea" style="padding-left: 150px;">
            <asp:Label ID="lblProcessing" runat="server" Text="Processing" Visible="False"></asp:Label>
        </div>

        <button style="width: 75px; visibility: hidden;"
            onclick="radconfirm('Are you sure you want to cancel the document upload process?', confirmCallBackFn, 330, 180, null, 'Confirm Cancel', null); return false;"
            id="btnCancel">
            cancel</button>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <img
        alt="" src="https://www.myenroll.com/images/smallbuzy.gif" id="htmImgBusy" style="visibility: hidden" />
        <div id='dvprocess' style="left: 240px; position: absolute; width: 250px; visibility: hidden;">
            <span id="spnProcessing" class="bold10obscuregreen" runat="server">&nbsp;&nbsp;Processing
            ...</span>
        </div>



        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script type="text/javascript">
                //<![CDATA[
                var $ = $telerik.$;
                function validationFailed(radAsyncUpload, args) {
                    var $row = $(args.get_row());
                    var erorMessage = getErrorMessage(radAsyncUpload, args);
                    var span = createError(erorMessage);
                    $row.addClass("ruError");
                    $row.append(span);
                }

                function getErrorMessage(sender, args) {
                    var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
                    if (args.get_fileName().lastIndexOf('.') != -1) {//this checks if the extension is correct
                        if (sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                            return ("This file type is not supported.");
                        }
                        else {
                            return ("This file exceeds the maximum allowed size of 1,024 MB.");
                        }
                    }
                    else {
                        return ("not correct extension.");
                    }
                }

                function createError(erorMessage) {
                    var input = '<span class="ruErrorMessage">' + erorMessage + ' </span>';
                    return input;
                }


                function Button1_onclick() {
                    htmbtnColse_onclick();
                }

                //]]>
            </script>
        </telerik:RadScriptBlock>
    </form>
    <script language="javascript" type="text/javascript">
        function DeleteInvalidFiles() {

            var upload = document.getElementById("<%= RadAsyncUpload1.ClientID %>");
            //            document.getElementById('lblFileErr').innerHTML = '';           
            var inputs = upload.getUploadedFiles();
            alert(inputs);
            for (i = inputs.length - 1; i >= 0; i--) {
                if (!upload.isExtensionValid(inputs[i].value))
                    upload.deleteFileInputAt(i);
            }
        }

        function confirmCallBackFn(arg) {
            if (arg == true)
                htmbtnColse_onclick();

        }

    </script>
</body>
</html>
