<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dependents.aspx.cs" Inherits="EnrollmentApproval.Dependents" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="dvMain" runat="server" class="FullPage">
            <div class="FullPage" style="border-bottom: silver 1px solid; ">
                <asp:Label ID="lblTitle" runat="server" Text="Process Pending Dependents" CssClass="FontMedium"
                    Font-Bold="True"></asp:Label>
            </div>
            <div id='dveelist' runat="server" class="LeftColumn" style="border-right: silver 1px solid; border-top-width: 1px;
                border-left: silver 1px solid; border-top-color: silver; border-bottom: silver 1px solid;">
                <div class="LeftColumn" style="border-bottom: silver 1px solid">
                    <asp:Label ID="lblEEWithPendDep" runat="server" Text="Employees List" CssClass="FontSmall10"
                        Font-Bold="True"></asp:Label>
                </div>
                <asp:RadioButtonList ID="rblstEmployees" runat="server" AutoPostBack="True" CssClass="FontSmall"
                    OnSelectedIndexChanged="rblstEmployees_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:RadioButtonList>&nbsp;</div>
            <div id='dvGrid' runat ="server" class="RightColumn">
                <div class="RightColumnin">
                    <div class="RightColumnin">
                        <asp:Label ID="lblPendingCvrgs" runat="server" Text="List of pending Dependents For:"
                            CssClass="FontSmall" Font-Bold="True" ForeColor="#804040"></asp:Label>
                        <asp:Label ID="lblName" runat="server" CssClass="FontSmall" Font-Bold="True"></asp:Label></div>
                    <div class="RightColumnin">
                        <asp:GridView ID="gvCvrg" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                            OnRowCreated="gvCvrg_RowCreated" Width="500px" CellPadding="4" ForeColor="#333333"
                            GridLines="None" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                            <Columns>
                                <asp:BoundField DataField="dep_name" HeaderText="Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Relation" HeaderText="Relationship">
                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="birth_date" HeaderText="DOB">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="operation" HeaderText="Request">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemStyle Width="160px" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                    <asp:Label ID="lblNoPending" runat="server" CssClass="FontSmall10" Font-Bold="True"
                        ForeColor="Maroon" Text="There is no pending dependent to process. " Visible="False"></asp:Label></div>
                <div class="RightColumnin">
                    &nbsp;</div>
                
                <div id = 'dvButtons' runat="server" class="RightColumnin">
                    <asp:Button ID="btnShowApprove" runat="server" Text="Click This Button to See the Subject and Memo of the Approved Email"
                        OnClick="btnShowApprove_Click" Width="500px" />
                    <br />
                    <asp:Button ID="btnShowDecline" runat="server" Text="Click This Button to See the Subject and Memo of the Disapproved Email"
                        OnClick="btnShowDecline_Click" Width="500px" />
                </div>
                <div class="RightColumnin">
                    &nbsp;</div>
                <div id="dvSendEmail" runat="server" class="RightColumnin" visible="false">
                    <div class="RightColumnin">
                        <div style="width: 100px; float: left;">
                            <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                        </div>
                        <div style="width: 399px; float: left;" id="DIV1" language="javascript" onclick="return DIV1_onclick()">
                            <asp:Label ID="txtEmailAddress" runat="server" CssClass="FontSmall"></asp:Label></div>
                    </div>
                    <div class="RightColumnin">
                        <div style="width: 100px; float: left;">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                        </div>
                        <asp:Label ID="txtSubject" runat="server" CssClass="FontSmall" Width="385px"></asp:Label></div>
                    <div class="RightColumnin">
                        <div style="width: 100px; float: left;">
                            <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                        </div>
                        <asp:Label ID="txtMassage" runat="server" Height="100px" Width="395px"></asp:Label>
                    </div>
                    <div class="RightColumnin">
                        <asp:Button ID="btnEditEmail" runat="server" Text="Edit" Style="margin-left: 100px"
                            OnClick="btnEditEmail_Click" Width="77px" />
                    </div>
                </div>
                <div class="RightColumnin">
                    &nbsp;</div>
                <div class="RightColumnin">
                    <asp:Button 
                        ID="btnBack" runat="server" CssClass="FontSmall" Text="Home" Width="75px" 
                        onclick="btnBack_Click" Visible="False" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" style="margin-left:200px" OnClick="btnSave_Click" 
                        Width="75px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp; &nbsp;
                </div>
            </div>
        </div>
        <div id="dvEditMail" runat="server" class="RightColumnin" visible="false">
        <div class="RightColumnin">
            <asp:Label ID="lblEditEmailTitle" runat="server" CssClass="FontMedium" Font-Bold="True" ></asp:Label>
        </div>
        <div class="RightColumnin">
        &nbsp;
        </div>
            <div class="RightColumnin">
                <div style="width: 100px; float: left;">
                    <asp:Label ID="Label1" runat="server" Text="Email Address" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                </div>
                <div style="width: 399px; float: left;">
                    <asp:TextBox ID="txtEditEmail" runat="server" CssClass="FontSmall" Width="395px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEditEmail"
                        CssClass="FontSmall" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="RightColumnin">
                <div style="width: 100px; float: left;">
                    <asp:Label ID="Label2" runat="server" Text="Subject" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                </div>
                <asp:TextBox ID="txtEditSubject" runat="server" CssClass="FontSmall" Width="395px"></asp:TextBox></div>
            <div class="RightColumnin" style="width: 780px; height: 370px">
                <div style="width: 100px; float: left;">
                    <asp:Label ID="Label4" runat="server" Text="Message" CssClass="FontSmall" Font-Bold="True"></asp:Label>
                </div>
                <telerik:radeditor id="txtEditMessage" runat="server" width="770px" Height="300px">
                    <Content>
</Content>
</telerik:radeditor>
               
            </div>
            <div class="RightColumnin" style="width: 770px; text-align: center">
                &nbsp;
                <asp:Button ID="btnSaveEmail" runat="server" Text="Save" OnClick="btnSaveEmail_Click"
                    Width="75px" />
                <asp:Button ID="btnRest" runat="server" OnClick="btnRest_Click" Text="Reset" Width="75px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                    Width="75px" /></div>
        </div>
        <asp:Label ID="lblNodep" runat="server" CssClass="FontSmall10" Font-Bold="True" ForeColor="Maroon"
            Text="There is no pending dependent to process. " Visible="False"></asp:Label></form>
</body>
</html>
