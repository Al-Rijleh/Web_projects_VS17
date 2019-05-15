<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipOfTheDay.aspx.cs" Inherits="StartLifeEventv1.TipOfTheDay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Life.css" rel="stylesheet" />
    <link href="NewSheet_No_Left.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="TipMasterWidth">
            <div class="TipMasterWidth FontMedium FontBold " style="text-align: center; border: 1px solid #000000; background-color: #000099;">
                <asp:Label ID="Label10" runat="server" Text="Tip of The Day" ForeColor="White"></asp:Label>
            </div>
            <div class="TipDivWidth  FontBold " style="height: 500px; overflow: auto; border-right-style: solid; border-left-style: solid; border-right-width: 1px; border-left-width: 1px; border-top-color: #000000; border-bottom-color: #000000; background-color: #f0f0f0;">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>                
            </div>
            <div class="TipMasterWidth FontSmall FontBold " style=" border: 1px solid #000000; background-color: #000099;">
                <div class="TipDivButtom LeftFloat">
                    <asp:CheckBox ID="cbDontShowAgain" runat="server" Text="Don't Show Again" ForeColor="White" /> 
                </div>
                <div class="TipDivButtom RightFloat" style=" text-align: right">
                    <div style="width:20px; height:20px" class="RightFloat">
                        <asp:ImageButton ID="imgBtnRight" runat="server" ToolTip="Right Button" />
                    </div>
                    <div style="width:50px; height:20px; text-align: center;" class="RightFloat">
                        <asp:Label ID="lblCounter" runat="server" Text="Label" ForeColor="White"></asp:Label>
                    </div>
                    <div style="width:20px; height:20px" class="RightFloat">
                        <asp:ImageButton ID="imgLeftButton" runat="server" ToolTip="Left Button" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
