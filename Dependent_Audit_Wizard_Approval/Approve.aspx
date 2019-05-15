<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="Dependent_Audit_Wizard_Approval.Approve" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Main.css" rel="stylesheet" type="text/css" />
    <link href="/styles/Main2.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">        try { window.top.hidleft(); } catch (err) { } window.open('/web_projects/PTemplate/Alert_Notes.aspx?hide=3', 'MyEnroll_Alert_Notes_Menu_frame')</script>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="CheckBoxes, Buttons, Scrollbars, Textbox, Textarea, Fieldset, Label, H4H5H6"
        Skin="Web20" />
    <script type="text/javascript">        parent.document.getElementById('middle').cols = '0,*';</script>
    <div class="FullPage1000 FontSmall">
        <%--Header--%>
        <div class="FullPage1000" id="dvHeader" runat="server" style="border-bottom-style: solid;
            border-bottom-width: 1px; border-bottom-color: #CCE8F9">
            <iframe name="Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame"
                style="width: 1002px; height: 95px" src="http://localhost/web_projects/PTemplate/top.aspx"
                frameborder="0" scrolling="no"></iframe>
        </div>
        <%--Message--%>
        <div class="FullPage1000" style="margin-bottom: 10px">
            <asp:Label ID="lblMessage" runat="server" Text="Dependent Audit - Approval" CssClass="pageTitle"></asp:Label>
        </div>
        <%--Data--%>
        <div class="FullPage1000">
            <%--PDF Viewer--%>
            <div class="PDFSide">
                <div class="PDFSide" id="dvimage" runat="server" style="text-align: center">
                    <asp:Button ID="btnPrevImage" runat="server" Text="Previous" OnClick="btnPrevImage_Click"
                        Width="75px" />
                    <asp:Button ID="btnNextImage" runat="server" Text="Next" OnClick="btnNextImage_Click"
                        Width="75px" />
                </div>
                <div class="PDFSide" style="text-align: center">
                    <asp:Label ID="lblWrning" runat="server" CssClass="warningColor" Font-Bold="True"
                        Font-Size="Small" BackColor="Yellow" Font-Italic="True" ForeColor="Red"></asp:Label>
                </div>
                <div class="PDFSide" runat="server" style="height: 480px" id="dvDoc">
                    <iframe id='Viewer' runat="server" width="640px" height="480px" name="Viewer" />
                </div>
            </div>
            <%--Input--%>
            <div class="DateSide" >
                <div class="DateSide" id='dvSelection' runat="server">
                    <%--Select Account--%>
                    <div class="DataSideLabel">
                        <asp:Label ID="lblSelectAccount" runat="server" Text="Select Employer"></asp:Label>
                    </div>
                    <div class="DataSideInput">
                        <telerik:RadComboBox ID="ddlAccounts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAccounts_SelectedIndexChanged"
                            Width="200px" Skin="Windows7">
                        </telerik:RadComboBox>
                    </div>
                    <%--Select Employee--%>
                    <div class="DataSideLabel">
                        <asp:Label ID="lblSelectEmployee" runat="server" Text="Select Employee"></asp:Label>
                    </div>
                    <div class="DataSideInput" style="margin-bottom: 10px">
                        <telerik:RadComboBox ID="ddlSelectEmployee" runat="server" Width="200px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSelectEmployee_SelectedIndexChanged" Skin="Windows7">
                        </telerik:RadComboBox>
                    </div>
                </div>

                <div class="DateSide" id='dvEmployeeInfo' runat="server">
                    <%--Select Account--%>
                    <div class="DataSideLabel" style="width:130px">
                        <asp:Label ID="lblSelectedEmployerTitle" runat="server" Text="Selected Employer"></asp:Label>
                    </div>
                    <div class="DataSideInput" style="width:230px">
                        <asp:Label ID="lblSelectedEmployer" runat="server"></asp:Label>
                    </div>
                    <%--Select Employee--%>
                    <div class="DataSideLabel" style="width:130px">
                        <asp:Label ID="lblSelectedEmployeeTitle" runat="server" Text="Selected Employee"></asp:Label>
                    </div>
                    <div class="DataSideInput" style="width:230px">
                        <asp:Label ID="lblSelectedEmployee" runat="server"></asp:Label>
                    </div>
                </div>

                <%--Dependent Grid--%>
                <div class="DateSide" style="margin-bottom: 10px">
                    <div class="DataPage FontSmall">
                        <asp:GridView ID="gvDependent" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                            Width="350px" OnRowCreated="gvDependent_RowCreated" CellPadding="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Action">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="100PX" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FullName" HeaderText="Dependent Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="100PX" />
                                </asp:BoundField>
                                <asp:BoundField DataField="relation_desc" HeaderText="Relationship">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle BackColor="#DFE9F5" Font-Bold="True" />
                            <RowStyle Height="30px" />
                        </asp:GridView>
                    </div>
                </div>
                <%--Dependent Data--%>
                <div class="DateSide" id="dvDepData" runat="server" style="margin-bottom: 10px">
                    <%--Dependent Data Label--%>
                    <div class="DateSide" style="margin-bottom: 10px">
                        <asp:Label ID="lblDependentData" runat="server" CssClass="dataSetctionTitle"></asp:Label>
                    </div>
                    <%--Dependent SSN --%>
                    <div class="DataSideLabel">
                        <asp:Label ID="lblSSNTitle" runat="server" Text="Soc. Sec. No."></asp:Label>
                    </div>
                    <div class="DataSideInput">
                        <asp:Label ID="lblSSN" runat="server"></asp:Label>
                    </div>
                    <%--Dependent Relation --%>
                    <div class="DataSideLabel">
                        <asp:Label ID="lblRelationTitle" runat="server" Text="Relationship"></asp:Label>
                    </div>
                    <div class="DataSideInput">
                        <asp:Label ID="lblRelation" runat="server"></asp:Label>
                    </div>
                    <%--Dependent DOB --%>
                    <div class="DataSideLabel">
                        <asp:Label ID="lblDOBTitle" runat="server" Text="Birthdate"></asp:Label>
                    </div>
                    <div class="DataSideInput">
                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                    </div>
                    <%--Dependent Effective --%>
                    <div class="DataSideLabel">
                        <asp:Label ID="lblEffectiveTitle" runat="server" Text="Efective Date" Visible="False"></asp:Label>
                    </div>
                    <div class="DataSideInput">
                        <asp:Label ID="lblEffective" runat="server" Visible="False"></asp:Label>
                    </div>
                </div>
                <%-- Decision --%>
                <div class="DateSide" id="dvDecision" runat="server" style="margin-bottom: 10px">
                    <div class="DateSide FontSmall" style="float: left; margin-bottom: 10px;">
                        <asp:Label ID="lblDecided" runat="server" CssClass="dataSetctionTitle"></asp:Label>
                    </div>
                    <div class="DateSide FontSmall" style="float: left; margin-top: 10px;" id="dvReson"
                        runat="server">
                        <div class="DataSideLabel">
                            <asp:Label ID="Label2" runat="server">Reason</asp:Label>
                        </div>
                        <div class="DataSideInput" style="margin-bottom: 10px">
                            <telerik:RadComboBox ID="ddlReson" runat="server" Width="250px" Skin="Windows7">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="Wrong Document" Value="Wrong Document" />
                                    <telerik:RadComboBoxItem runat="server" Text="Document Not Clear" Value="Document Not Clear" />
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                        <asp:LinkButton ID="lnkbtnAddReason" runat="server" OnClick="lnkbtnAddReason_Click">Add New Reason</asp:LinkButton>
                    </div>
                    <div class="DateSide FontSmall" style="float: left; margin-top: 10px;" id="Div1"
                        runat="server">
                        <asp:Label ID="Label3" runat="server" Visible="False">Please enter any text you want to communicate to the employe</asp:Label>
                    </div>
                    <div class="DateSide" style="text-align: center; margin-top: 10px;">
                        <telerik:RadButton ID="btnHome0" runat="server" Text="Home" Skin="Web20" Width="75px"
                            CausesValidation="False" onclick="btnHome_Click">
                        </telerik:RadButton>
                    &nbsp;
                        <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="Web20" Width="75px"
                            CausesValidation="False" OnClick="btnCancel_Click">
                        </telerik:RadButton>
                        &nbsp;
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="Web20" Width="75px"
                            CausesValidation="False" OnClick="btnSave_Click">
                        </telerik:RadButton>
                    </div>
                </div>
                <%-- Home Button --%>
                <div class="DateSide" id="dvHome" runat="server" style="margin-bottom: 10px">
                    <div class="DateSide" style="text-align: center; margin-top: 10px;">
                        <telerik:RadButton ID="btnHome" runat="server" Text="Home" Skin="Web20" Width="75px"
                            CausesValidation="False" onclick="btnHome_Click">
                        </telerik:RadButton>
                    </div>
                </div>
                <%-- Add Decision Item --%>
                <div class="DateSide" id="dvAddItem" runat="server" style="margin-bottom: 10px">
                    <div class="DateSide FontSmall" style="float: left; margin-bottom: 10px;">
                    </div>
                    <div class="DateSide FontSmall" style="float: left; margin-top: 10px;" id="Div3"
                        runat="server">
                        <div class="DataSideLabel">
                            <asp:Label ID="Label5" runat="server">New Reason</asp:Label>
                        </div>
                        <div class="DataSideInput" style="margin-bottom: 10px">
                            <asp:TextBox ID="txtReason" runat="server" MaxLength="60" Width="249px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="DateSide FontSmall" style="float: left; margin-top: 10px;" id="Div4"
                        runat="server">
                        <asp:Label ID="Label6" runat="server" Visible="False">Please enter any text you want to communicate to the employe</asp:Label>
                    </div>
                    <div class="DateSide" style="text-align: center; margin-top: 10px;">
                        <telerik:RadButton ID="btnReasonCance" runat="server" Text="Cancel" Skin="Web20"
                            Width="75px" CausesValidation="False" OnClick="btnReasonCance_Click">
                        </telerik:RadButton>
                        &nbsp;
                        <telerik:RadButton ID="btnReasonSave" runat="server" Text="Save" Skin="Web20" Width="75px"
                            CausesValidation="False" OnClick="btnReasonSave_Click">
                        </telerik:RadButton>
                    </div>
                </div>
                <%--Existing Document--%><%--Dependent Approval--%>
                <div class="DateSide" id="dvApproval" runat="server" style="margin-bottom: 10px">
                    <%--Dependent Approvar Label--%>
                    <div class="DateSide" style="margin-bottom: 10px">
                        <asp:Label ID="Label1" runat="server" CssClass="dataSetctionTitle">Approval Section</asp:Label>
                    </div>
                    <div class="DateSide" style="margin-bottom: 10px; text-align: center;">
                        <asp:Label ID="lblWrning2" runat="server" CssClass="warningColor" Font-Bold="True"
                        Font-Size="Small"></asp:Label>
                    </div>
                    <%--Dependent Approvar Radio Buttons--%>
                    <div class="DateSide" style="margin-bottom: 10px">
                        <asp:RadioButtonList ID="rblDecision" runat="server" RepeatDirection="Horizontal"
                            Width="345px" AutoPostBack="True" OnSelectedIndexChanged="rblDecision_SelectedIndexChanged">
                            <asp:ListItem Value="2">Approve</asp:ListItem>
                            <asp:ListItem Value="3">Disapprove</asp:ListItem>
                            <asp:ListItem Value="0">Require More Info.</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <telerik:RadPanelBar ID="RadPanelBar1" Runat="server">
                </telerik:RadPanelBar>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
