<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultOld.aspx.cs" Inherits="Dependents_Maintenance._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dependents</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="/styles/Main.css" type="text/css" rel="stylesheet" />

    <script src="/js/StyleSetter.js" type="text/javascript"></script>

    <script src="/js/BAS_Utility.js" type="text/javascript"></script>

    <%--<script type="text/javascript">
      function DoshowDialog()GetEE
       { 
            showDialog();return false;
       }

        function DoshowDialog3()
       { 
            showDialog3();
       }
       
        function showDialog(id,depid)
        {                    
            window.radopen("AddEditDep.aspx?id="+id+"&dep_id="+depid , "RadWindow1");
            return false; 
        }
        
        function showDialogLimited(id,depid)
        {                    
            window.radopen("AddEditDepLimited.aspx?id="+id+"&dep_id="+depid , "RadWindow7");
            return false; 
        }
        
        
        function showDialog2(id,depid)
        {                    
            window.radopen("RemoveDep.aspx?id="+id+"&dep_id="+depid  , "RadWindow2");
            return false; 
        }
        
        function showDialog4(id,depid)
        {                    
            window.radopen("ApproveDep.aspx?id="+id+"&dep_id="+depid  , "RadWindow2");
            return false; 
        }
        
        function showDialog14(id,depid)
        {     
                     
            //document.location.replace("http://localhost/TEST_PROG/testajaxpdf/Default.aspx?id="+id+"&dep_id="+depid );
            document.location.replace("/WEB_PROJECTS/Dependent_Approval/Default.aspx?id="+id+"&dep_id="+depid );
            return false; 
        }

        

        function OnClientclose(radWindow)
        {   
     
          var retcode;    
            if (radWindow.argument)
              retcode= radWindow.argument
            if (retcode == "1")   
            {                           
                radWindow.argument = 0;                    
                PostBack();
            }
            if (retcode == "2")   
            {                                          
                radWindow.argument = 0;
                showDialog3();  
            }
            if (retcode == "3")   
            {                                                   
                radWindow.argument = 0;
                showDialog5();  
            }
            if (retcode == "10")   
            {                                                   
                radWindow.argument = 0;
                document.location.replace('/web_projects/Cobra_Service/identification_dep.aspx?SkipCheck=YES');
            }
         }   
         
         function showDialog3()
         {                  
            window.radopen("Declaration_Form.aspx", "RadWindow3");
            return false; 
         }
         
         function showDialog5()
         {                          
            window.radopen("Coverage.aspx", "RadWindow5");
            return false; 
         }
         
         function showDialog6(id,depid,depnm)
         {                                  
            window.radopen("Reactivate.aspx?id="+id+"&dep_id="+depid+"&dep_nm="+depnm , "RadWindow6");
            return false; 
         }
         
         var theForm = document.forms['form1'];
        if (!theForm) {
            theForm = document.form1;
        }
        function PostBack() 
        {
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
            {                
                theForm.submit();
            }
        }     
         
         function Approve(id,depName)
         {
           var apprv= confirm('Are you sure you want to approve dependent '+depName);
           if (apprv)
           {
             eval(document.getElementById('hidCommand')).value='Approve-'+id;            
             PostBack();
           }
         }
         
         function GetEE(url)
         {
              alert('You have not selected an employee yet.\nYou will be redirected to the employee search ');
              window.open('/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/WEB_PROJECTS/DEPENDENTS_MAINTENANCE/DEFAULT.ASPX?SkipCheck=YES,'_self');
         }
         
         function showTermDep(id,depid)
        {     
//            if (depid == '-1')
//            {
//              showDialog2(id,depid);
//              return;
//            }
            document.location.replace("/WEB_PROJECTS/Dependent_Terminate/Default.aspx?id="+id+"&dep_id="+depid );
            return false; 
        }
      
          
      

    </script>--%>

    <script type="text/javascript">
        function GetEE(url) {
            alert('You have not selected an employee yet.\nYou will be redirected to the employee search ');
            window.open('/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/WEB_PROJECTS/DEPENDENTS_MAINTENANCE/DEFAULT.ASPX?SkipCheck=YES', '_self');
        }

        function DoshowDialog() {
            showDialog(); return false;
        }

        function DoshowDialog3() {
            showDialog3();
        }

        function showDialog(type) {

            window.radopen("/WEB_PROJECTS/ENROLLMENTWIZARD/AddEditDep.aspx?type=" + type, "RadWindow1");
            return false;
        }

                function showDialog100(id,depid)
        {
                    //alert(id)
                    //alert(depid)
                    window.radopen("AddEditDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow1");
                    return false; 
                }

        //       function showDialog(id, depid) {
        //           window.radopen("AddEditDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow1");
        //           return false;
        //       }

        function showDialogAdd(id, depid) {
            //            if (id < 0) {
            //                document.getElementById('hidShowTerm').value = '1';
            //                id = id * (-1);
            //            }
            //alert(document.getElementById('hidShowTerm').value + '  ' + id);
            window.radopen("AddEditDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow1");
            return false;
        }

        function showDialogAddFix(id, depid) {
            window.radopen("AddEditDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow1");
            return false;
        }

        function showDialogLimited(id, depid) {
            window.radopen("AddEditDepLimited.aspx?id=" + id + "&dep_id=" + depid, "RadWindow7");
            return false;
        }

        function showDialogLimitedSSN(id, depid) {
            window.radopen("AddEditDepLimited.aspx?id=" + id + "&dep_id=" + depid + "&SSN=1", "RadWindow7");
            return false;
        }

        function showDialog2(id, depid) {
            window.radopen("RemoveDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow2");
            return false;
        }

        function showDialog4(id, depid) {
            window.radopen("ApproveDep.aspx?id=" + id + "&dep_id=" + depid, "RadWindow2");
            return false;
        }

        function showDialog14(id, depid) {

            //document.location.replace("http://localhost/TEST_PROG/testajaxpdf/Default.aspx?id="+id+"&dep_id="+depid );
            document.location.replace("/WEB_PROJECTS/Dependent_Approval/Default.aspx?id=" + id + "&dep_id=" + depid);
            return false;
        }

        function showDialogVer(id, depid) {
            if (confirm('Are you sure you want to confirm ' + depid)){
                eval(document.getElementById('hidCommand')).value = 'Approve-' + id;
                PostBack();
            }           
            return false;
        }


        function showDialog24(id, depid) {

            //document.location.replace("http://localhost/TEST_PROG/testajaxpdf/Default.aspx?id="+id+"&dep_id="+depid );
            document.location.replace("/WEB_PROJECTS/Dependent_Terminate/Default.aspx?id=" + id + "&dep_id=" + depid);
            return false;
        }

        function OnClientclose(radWindow) {

            var retcode;
            if (radWindow.argument)
                retcode = radWindow.argument;

            if (retcode == "1") {
                radWindow.argument = 0;
                window.open('/web_projects/Dependents_Maintenance/Default.aspx?SkipCheck=YES', 'MyEnroll_users_data_display_and_edit_content_frame');
                //               __doPostBack(null, null);                   
                //                PostBack();  
            }
            if (retcode == "2") {
                radWindow.argument = 0;
                showDialog3();
            }
            if (retcode == "3") {
                radWindow.argument = 0;
                showDialog5();
            }
            if (retcode == "10") {
                radWindow.argument = 0;
                document.location.replace('/web_projects/Cobra_Service/identification_dep.aspx?SkipCheck=YES');
            }
            if (retcode == "11") {
                
                radWindow.argument = 0;
                //document.location.replace('/web_projects/Verify_Dependents/Default.aspx?SkipCheck=YES');
                document.location.replace('/web_projects/DependentsAuditGetDocuments/Default.aspx?SkipCheck=YES&frm=depmain');
            }
        }

        function showDialog3() {
            alert('OLDshowDialog3')
            window.radopen("Declaration_Form.aspx", "RadWindow3");
            return false;
        }

        function showDialog5() {
            window.radopen("Coverage.aspx", "RadWindow5");
            return false;
        }

        function showDialog6(id, depid, depnm) {
            window.radopen("Reactivate.aspx?id=" + id + "&dep_id=" + depid + "&dep_nm=" + depnm, "RadWindow6");
            return false;
        }


        function PostBack() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }

        function Approve(id, depName) {
            //alert('Hear')
            var apprv = confirm('Are you sure you want to approve dependent ' + depName)
            if (apprv) {
                eval(document.getElementById('hidCommand')).value = 'Approve-' + id;
                PostBack();
            }
        }

        function showTermDep(id, depid, backURL) {
            //            if (depid == '-1')
            //            {
            //              showDialog2(id,depid);
            //              return;
            //            }
            document.location.replace("/WEB_PROJECTS/Dependent_Terminate/Default.aspx?id=" + id + "&dep_id=" + depid + "&back=" + backURL);
            return false;
        }


        //        function GetEE(url)
        //         {
        //         
        //              alert('You have not selected an employee yet.\nYou will be redirected to the employee search ');
        //              window.open('/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/WEB_PROJECTS/DEPENDENTS_MAINTENANCE/DEFAULT.ASPX?SkipCheck=YES,'_self');
        //         } 


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hidShowTerm" runat="server" />
        <telerik:RadWindowManager ID="Singleton" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" NavigateUrl="AddEditDep.aspx" OpenerElementID="Label1"
                    Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                    Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                    VisibleStatusbar="False" Width="770px" Height="400px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow2" runat="server" NavigateUrl="RemoveDep.aspx" OpenerElementID="Label1"
                    Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                    Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                    VisibleStatusbar="False" Width="650px" Height="255px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow3" runat="server" NavigateUrl="Declaration_Form.aspx"
                    OpenerElementID="Label1" Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose"
                    ReloadOnShow="True" Style="display: none;" Behavior="Default" InitialBehavior="None"
                    Modal="True" VisibleStatusbar="False" Width="600px" Height="375px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow4" runat="server" NavigateUrl="ApproveDep.aspx" OpenerElementID="Label1"
                    Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                    Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                    VisibleStatusbar="False" Width="650px" Height="225px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow5" runat="server" NavigateUrl="Coverage.aspx" OpenerElementID="Label1"
                    Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                    Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                    VisibleStatusbar="False" Width="720px" Height="400px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow6" runat="server" NavigateUrl="Reactivate.aspx" OpenerElementID="Label1"
                    Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose" ReloadOnShow="True"
                    Style="display: none;" Behavior="Default" InitialBehavior="None" Modal="True"
                    VisibleStatusbar="False" Width="650px" Height="225px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
                <telerik:RadWindow ID="RadWindow7" runat="server" NavigateUrl="AddEditDepLimited.aspx"
                    OpenerElementID="Label1" Skin="Vista" Left="5" Top="1px" OnClientClose="OnClientclose"
                    ReloadOnShow="True" Style="display: none;" Behavior="Default" InitialBehavior="None"
                    Modal="True" VisibleStatusbar="False" Width="730px" Height="375px" ShowContentDuringLoad="False"
                    VisibleTitlebar="False">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <asp:HiddenField ID="hidCommand" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <asp:Label ID="LBL_FLD_Instruction" runat="server" CssClass="fontsmall" Font-Bold="True" Visible="False"></asp:Label><br />
        <div id="dvMaster" class="AddEditMain" runat="server" visible="true" style="width: 800px">
            <div id="dvMain" class="AddEditMain" runat="server" visible="true">
                <div style="width: 767px; float: left">
                    <asp:Label ID="lblTitle" runat="server" Text="Dependents" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Font-Underline="False"></asp:Label>
                </div>
                <div style="width: 750px; float: left; font-size: 9pt; color: #666666; padding-bottom: 10px;">
                    <asp:Label ID="lblInstucrion" runat="server">
                <span style='font-size: 9.0pt; font-family: Arial,sans-serif; color: #7F7F7F'>Listed below are your dependents, if any, recorded in MyEnroll.com. Click on 
the Add New Dependent link below to enter data for a dependent not currently 
listed and 
<a target='_blank' href='WhoIsEligible2009 OEMyEnroll.pdf'>Who is Eligible</a> to be covered under a Self & Family plan or a Flexible 
Spending Account (FSA) enrollment.</span>
                    </asp:Label>
                </div>
                <%--<div style="width: 765px; float: left; height: 10px" runat="server" id="divBlank"
                visible="true">
                &nbsp;
            </div>--%>
                <div style="width: 765px; float: left; padding-top: 10px; padding-bottom: 10px" runat="server"
                    id="dvOpenEnrollmentNote" visible="false">
                    <asp:Label ID="lblOpenEnrollmentNote" runat="server" CssClass="fontsmall" Font-Bold="True">All additions or terminations of dependents will be effective 1/1/2010.  If a life event has occurred within the past 60 days that results in the addition or termination of a dependent record before 1/1/2010, return to the "Welcome Page" and click on "Submit a Permitted Election Change Due to a Life Event."
                    </asp:Label>
                </div>
                <div style="width: 767px; float: left">
                    <div style="width: 150px; float: left">
                        <asp:Button ID="btnAddDependent" runat="server" Text="Add New Dependent" ToolTip="Click this button to Add New Dependent"
                            BackColor="White" BorderStyle="None" Font-Underline="True" ForeColor="Blue" Width="120px" />
                    </div>
                    <div style="width: 616px; float: left">
                        <asp:CheckBox ID="cbShowActiveOnly" runat="server" AutoPostBack="True" Checked="True"
                            CssClass="fontsmall" Text="Show Active Dependents Only (uncheck box to show active and terminated dependents)"
                            ToolTip="Show Active Dependents Only when checked" />
                    </div>
                </div>
                <br />
                <div style="width: 765px; float: left">
                    <asp:GridView ID="gvEmpty" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        CssClass="fontsmall" BorderColor="Silver" BorderWidth="1px" OnRowCreated="gvEmpty_RowCreated"
                        Width="775px">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="width: 765px; float: left">
                    <asp:GridView ID="gvDep" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                        CssClass="fontsmall" BorderColor="Silver" BorderWidth="1px" OnRowCreated="gvDep_RowCreated"
                        Width="775px">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemStyle Width="10px" />
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="FullName" HeaderText="Full Name">
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" HorizontalAlign="Left" />
                                <ItemStyle Width="175px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Relation" HeaderText="Relation">
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" HorizontalAlign="Left" />
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOB" HeaderText="DOB">
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" HorizontalAlign="Left" />
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" />
                                <ItemStyle Width="75" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status">
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" HorizontalAlign="Left" />
                                <ItemStyle Width="75" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Verify" HeaderText="Verify Status">
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" HorizontalAlign="Left" />
                                <ItemStyle Width="75" />
                            </asp:BoundField>


                            <asp:BoundField DataField="termination_date" HeaderText="Term Date">
                                <HeaderStyle BackColor="#880000" ForeColor="White" HorizontalAlign="Left" />
                                <ItemStyle Width="75px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Action">
                                <HeaderStyle BackColor="#880000" BorderColor="#880000" ForeColor="White" HorizontalAlign="Left" Width="125px" />
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="width: 765px; float: left">
                    <asp:Label ID="lblPendingDependents" runat="server" Text="<br /><br />Pending Dependents"
                        Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" CssClass="fontsmall"
                        OnRowCreated="gvPending_RowCreated" Width="775px">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="10px" />
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="FullName" HeaderText="Full Name">
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Relation" HeaderText="Relation">
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOB" HeaderText="DOB">
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                <ItemStyle HorizontalAlign="Center" Width="55px" />
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status">
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="termination_date" HeaderText="Term Date" Visible="False">
                                <HeaderStyle BackColor="Maroon" ForeColor="White" HorizontalAlign="Left" BorderColor="Maroon" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Action">
                                <HeaderStyle BackColor="Maroon" BorderColor="Maroon" ForeColor="White" HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="width: 765px; float: left; height: 10px">
                    &nbsp; &nbsp;
                </div>
                <div style="width: 765px; float: left">
                    <asp:Button ID="btnNextEnrollmentStep" runat="server" CssClass="fontsmall" Text="Next Enrollment Step"
                        Width="150px" OnClick="btnNextEnrollmentStep_Click" Visible="False" />&nbsp;<asp:Button ID="btnBackToLiveEvent"
                            runat="server" CssClass="fontsmall" Text="Next Life Event Step" Width="172px"
                            OnClick="btnBackToLiveEvent_Click" Visible="False" />
                    <asp:Label ID="Label7" runat="server" CssClass="fontsmall" Width="10px"></asp:Label>
                </div>
                <br />
                <br />
                &nbsp;
            </div>
            <div id="dvMessage" style="width: 765px; float: left; padding-top: 10px; padding-bottom: 10px"
                runat="server" visible="false">
                <asp:Label ID="lblWarning" runat="server" CssClass="fontsmall" Font-Bold="True"><b>
<span style="font-size: 11.0pt; font-family: Calibri,sans-serif; color: #FF3F05">
Warning<br>
</span></b><span style="font-size: 11.0pt; font-family: Calibri,sans-serif">The 
assigned class for [Name] (MyEnroll ID# [Number]) is 
not permitted to enroll dependents. Please click the &quot;Close&quot; button to close 
this program and return to your MyEnroll.com home page.</span>
                </asp:Label>
                <div style="width: 765px; float: left; height: 10px">
                    &nbsp; &nbsp;
                </div>
                <div style="width: 765px; float: left">
                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="fontsmall" OnClick="btnClose_Click"
                        Width="75px" />
                </div>
            </div>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="cbShowActiveOnly">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="gvDep" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <%-- <div style='font-size: 10pt; color: red'>
        hsdjdkdkdkdk sdldsldldldl
        </div>--%>
        </div>
    </form>
</body>
<% Response.CacheControl = "no-cache";%><% Response.Expires = -1; %>
</html>
