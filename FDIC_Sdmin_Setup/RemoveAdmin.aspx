<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveAdmin.aspx.cs" Inherits="FDIC_Sdmin_Setup.RemoveAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="master_main">
            <div class="Entry_Row FontMedium" style="text-align: left">
                <asp:Label ID="Label1" runat="server" CssClass="FontMedium Link-Button">Instruction</asp:Label>
            </div>
            <div class="Blank">
                &nbsp;
            </div>
            <div class="Entry_Row FontMedium" >
                <asp:Label ID="lblAdminName" runat="server" CssClass="FontMedium Link-Button"></asp:Label>
            </div>
            <div class="Blank">
                &nbsp;
            </div>

            <%--Grid--%>
            <div class="Entry_Row fontsmall Link-Button">
                <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" OnRowCreated="gvEmployee_RowCreated"
                    Width="100%">
                    <Columns>
                        
                        <asp:BoundField DataField="org_code" HeaderText="Organization Code" />
                        <asp:BoundField DataField="is_primary" HeaderText="Is Primary" />
                        <asp:BoundField DataField="regional_address" HeaderText="Regional Address" />
                        <asp:TemplateField HeaderText="Replace By">
                            <HeaderStyle Width="190px" />
                            <ItemStyle Width="190px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="Blank">
                &nbsp;
            </div>
            <div class="Blank">
                &nbsp;
            </div>
            <div class="Entry_Row fontsmall">
                <%--<telerik:RadButton RenderMode="Lightweight" ID="RadCancel" runat="server" Text="Cancel" style="top: 0px; left: -352px" OnClick="RadCancel_Click" >
                    <Icon PrimaryIconCssClass="rbPrevious"></Icon>
                </telerik:RadButton>--%>

                <telerik:RadButton RenderMode="Lightweight" ID="RadButton13" runat="server" Text="Done" OnClick="RadButton13_Click" style="top: 0px; left: -262px; right: 356px;" ToolTip="Done, Leave this Page">
                    <Icon PrimaryIconCssClass="rbOk"></Icon>
                </telerik:RadButton>

                
            </div>
        </div>
    </form>
</body>
</html>
