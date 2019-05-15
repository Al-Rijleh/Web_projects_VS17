<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildFSAge.aspx.cs" Inherits="Rates.BuildFSAge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <link href="main2.css" rel="stylesheet" />
    <style type="text/css">
        .style1 {
            width: 250px;
            float:left
        }
        .style2 {
            width: 60px;
            float:left
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="FullPage textFont" >
        <%--Heading--%>
      <div class="InputRow">
          <h1>Enter Basic Rates Informationgg</h1>
      </div>
      <div class="InputRow">
          &nbsp;
      </div>
      <%--Effective Date--%>
      <div class="InputRow">
          <div class="InputLabel"><asp:Label ID="lblEffectiveDate" runat="server" Text="Enter Effective Date"></asp:Label></div>
          <telerik:RadDateInput ID="txtEffectiveDate" runat="server"></telerik:RadDateInput>
      &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" class="error"
                        ErrorMessage="Required" CondivolToValidate="txtMinAge" ControlToValidate="txtEffectiveDate" CssClass="errorRed"></asp:RequiredFieldValidator>
      </div>

      <%--Family Status--%>
      <div class="InputRow">
          <div class="InputLabel"><asp:Label ID="lblSelectFS" runat="server" Text="Select Family Statuses"></asp:Label></div>
          <div class="InputValue" ><asp:CheckBoxList ID="cblFs" runat="server" ></asp:CheckBoxList></div>
      </div>

     <div width="500px" id='tblparamenters' runat="server">
            <div>
                <div class="style1">
                    &nbsp;&nbsp;</div>
            </div>
            <div id='divstatus' runat="server">
                <div class="style4">
                    &nbsp;</div>
            </div>
            <div>
                <div class="style4" >
                    &nbsp;&nbsp;</div>
                <div class="style3">
                    &nbsp;</div>
                <div class="style4">
                </div>
            </div>
            <div class="InputRow">
                <div class="style1">
                    <asp:Label ID="lblMinAge" runat="server" CssClass="Label_Font">What is the oldest age in the first age band</asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="Maroon" 
                        Text="*"></asp:Label>
                </div>
                <div class="style1">
                   <telerik:RadNumericTextBox ID="txtMinAge" runat="server" MinValue="0" Width="150px" MaxValue="200"><NumberFormat DecimalDigits="0" /></telerik:RadNumericTextBox>
            
                </div>
                <div class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" class="error"
                        ErrorMessage="Required" CondivolToValidate="txtMinAge" ControlToValidate="txtMinAge" CssClass="errorRed"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="InputRow">
                <div class="style1">
                <asp:Label ID="lblStep" runat="server" CssClass="Label_Font">How many years in an age-band</asp:Label>
                <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="Maroon" Text="*"></asp:Label>
                </div>
                <div class="style1">
                    <telerik:RadNumericTextBox ID="txtStep" runat="server" MinValue="0" Width="150px" MaxValue="200"><NumberFormat DecimalDigits="0" /></telerik:RadNumericTextBox>
            
                </div>
                <div class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Required" CssClass="errorRed" CondivolToValidate="txtStep" ControlToValidate="txtStep"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="InputRow">
                <div class="style1">
                <asp:Label ID="lblLastAge" runat="server" CssClass="Label_Font">What is the last age in your last age-band</asp:Label>
                <asp:Label ID="Label11" runat="server" Font-Bold="true" ForeColor="Maroon" Text="*"></asp:Label>
                </div>
                <div class="style1">
                    <telerik:RadNumericTextBox ID="txtLastAge" runat="server" MinValue="0" Width="150px" MaxValue="200"><NumberFormat DecimalDigits="0" /></telerik:RadNumericTextBox>
                </div>
                <div class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Required" CssClass="errorRed" CondivolToValidate="txtLastAge" ControlToValidate="txtLastAge"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div  class="InputRow">
                <div >
                    &nbsp;&nbsp;<asp:Button ID="btnGenerate" runat="server" Text="Generate" 
                        onclick="btnGenerate_Click" />
                </div>
            </div>
             <div  class="InputRow">
                 &nbsp;
             </div>
            <div  class="InputRow">
                <asp:GridView ID="gvList" runat="server"></asp:GridView>
            </div>
         <div  class="InputRow">
                 &nbsp;
             </div>
            <div  class="InputRow">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Rates Layout" />
            </div>
        </div>

    </div>
    </form>
</body>
</html>
