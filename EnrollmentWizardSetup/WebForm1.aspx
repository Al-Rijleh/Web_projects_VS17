<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EnrollmentWizardSetup.WebForm1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <div class="Section">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="100%">
            <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Skin="Sunset" Width="100%" ExpandMode="SingleExpandedItem">
                <Items>
                    <telerik:RadPanelItem runat="server" Text="Homepage Welcome Text" Value="Section1">
                        <Items>
                            <telerik:RadPanelItem runat="server" Text="Test">
                                 <ItemTemplate>
                                     <telerik:RadEditor ID="RadEditor1" runat="server">
                                     </telerik:RadEditor>   
                                  </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                        
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Homepage Message from HR">
                        
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem runat="server" Text="Homepage Start and Stop Text">
                      
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>
        </telerik:RadAjaxPanel>
    </div>
    </form>
</body>
</html>
