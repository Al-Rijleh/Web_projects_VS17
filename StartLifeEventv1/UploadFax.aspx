<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFax.aspx.cs" Inherits="StartLifeEventv1.UploadFax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div id="dvupload" runat="server" style="float:left; padding-top:25px; padding-bottom:15px; Width:780px"> 
               
           <telerik:RadAsyncUpload ID="RadAsyncUpload1"  runat="server" HideFileInput="true" RenderMode="Lightweight"
                 MultipleFileSelection="Disabled" EnableViewState="true" UploadedFilesRendering ="BelowFileInput"
            Width="150px"
            CssClass="textFont"              
            MaxFileInputsCount="1"              
            EnablePermissionsCheck="false"
            ToolTip="File selection tool: Click Browse to choose one or more files from your computer. Once files are chosen, click Remove File to delete a selection." 
            UseApplicationPoolImpersonation="true" 
             InitialFileInputsCount="1" AllowedFileExtensions=".csv" TemporaryFolder="~/App_Data">
            <Localization Remove="Remove File" Select="Find File" />               
            </telerik:RadAsyncUpload>           
               </div>
        <div id="dvUploadBtns" runat="server" style=" float:left; padding-left:2px; padding-top:25px; padding-bottom:15px; Width:780px">                
                 <%--  <div id="Div3" runat="server" style="float:left; width:150px">--%>
                   <telerik:RadButton runat="server" ID="btnSubmit" AutoPostBack="true" Text="Submit" Width="74px" CssClass="textFont"  
                    OnClick="btnSubmit_Click" Visible="false"></telerik:RadButton>
                <%--    </div>--%>
                 <%--  <div id="Div1" runat="server" style=" float:left; width:100px">
                 <telerik:RadButton runat="server" ID="RadButton2" AutoPostBack="true" CssClass="fontSmall"
                 Text="Cancel" OnClientClicked="removeFiles" Visible ="false" OnClick="RadButton2_Click"></telerik:RadButton>
                   </div>--%>
             </div>

    </div>
    </form>
</body>
</html>
