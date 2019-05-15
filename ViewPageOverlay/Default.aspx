<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewPageOverlay.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="FullPage" runat="server" style="height: 500px; width: 770px; background-repeat: no-repeat;">

        <asp:Label ID="lblType" runat="server" ><style type="text/css">
        .btnPos
        {
            position: absolute; 
            top: [top]px; 
            left: 12px;
        }
    </style></asp:Label>



    </div>
        <div style="text-align: center; width: 770px;" class ="btnPos">
            <div style="width: 65px; height: 65px; ">
            <asp:ImageButton ID="imgGotit" runat="server" ImageUrl="https://www.myenroll.com/images/Separate_Button2.png" OnClick="imgGotit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
