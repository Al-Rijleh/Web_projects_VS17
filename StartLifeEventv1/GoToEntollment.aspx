<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoToEntollment.aspx.cs" Inherits="StartLifeEventv1.GoToEntollment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Life.css" rel="stylesheet" />
    <link href="NewSheet_No_Left.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="FullPage" style="margin-bottom: 50px">
            <div class="FullPage70 FontBold FontMedium" style="margin-right: auto; margin-left: auto; text-align: center;margin-bottom: 20px">
                <asp:Label ID="Label1" runat="server">Preparing your Enrollment Options... Hang Tight!</asp:Label>
            </div>
            <div class="FullPage70 FontBold FontMedium" style="margin-right: auto; margin-left: auto; text-align: center;">
                <asp:Image ID="Image1" runat="server" Style="margin-left: auto; margin-right: auto"
                                ImageUrl="~/img/progress_notext.gif" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        window.open("/web_projects/ENROLLMENTWIZARD/DependentInfo.aspx","_self")
    </script>
</body>
</html>
