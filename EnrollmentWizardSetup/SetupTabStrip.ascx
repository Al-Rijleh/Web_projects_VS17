<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SetupTabStrip.ascx.cs"
    Inherits="EnrollmentWizardSetup.SetupTabStrip" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="EnrollmentWizardSetup.css" rel="stylesheet" type="text/css" />
<div class="FullPage">
        <asp:Button ID="btnSelectAccount" runat="server" Text="Select Account" OnClick="btnSelectAccount_Click" />   
    <asp:Label ID="lblSelectedPY" runat="server" CssClass="fontsmall" Font-Bold="True"
        Text="Selected Processing Year:"></asp:Label>
    <asp:Label ID="lblProcessingYear" runat="server"></asp:Label></div>
<div class="FullPage">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" OnTabClick="RadTabStrip1_TabClick"
        SelectedIndex="2" Skin="Telerik" CausesValidation="False">
        <Tabs>
            <telerik:RadTab runat="server" Text="Welcome" Value="Welcome.aspx?SkipCheck=YES">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Instructions" Value="Instructions.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Personal Information" Value="Personal_Information.aspx" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Dependent Information" Value="DependentInfo.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Coverage Plans" Value="Status.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Beneficiaries" Value="Beneficiaries.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Summary &amp; Signature" Value="Summary_Authorization.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="FSA" Value="/web_projects/EnrollmentWizardSetup/FSALimits.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Annual Enrollment" Value="/web_projects/EnrollmentWizardSetup/Setup_open_Enrollment.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Group Messages" Value="/web_projects/EnrollmentWizardSetup/Cvrg_Grp_Msgs.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Coverage Messages" Value="/web_projects/EnrollmentWizardSetup/cvrg_msg.aspx">
            </telerik:RadTab>
            
            <telerik:RadTab runat="server" Text="Extra Page" Value="/web_projects/EnrollmentWizardSetup/Extra.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Pre/Post Tax Page" Value="/web_projects/EnrollmentWizardSetup/PrePost.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Verify Accnt. Setup" Value="/web_projects/EnrollmentWizardSetup/verify.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Dep Audit Wiz Setup" Value="/web_projects/EnrollmentWizardSetup/DepAuditWizSetup.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Account Properties"  Value="/web_projects/EnrollmentWizardSetup/Properties.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Classes"  Value="/web_projects/EnrollmentWizardSetup/Classes.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Wellness plans" Value="/web_projects/EnrollmentWizardSetup/Wellnessplan.aspx">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="SPN/HSA" Value="/web_projects/EnrollmentWizardSetup/SPN.aspx">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
</div>
