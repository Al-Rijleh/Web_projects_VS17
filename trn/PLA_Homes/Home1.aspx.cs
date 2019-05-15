// Upload to production on 08-17-2011 because the error handler was showing errors when user were tring to connect to this page

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace PLA_Homes
{
	/// <summary>
	/// Summary description for Home1.
	/// </summary>
	public class Home1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSupervisorApproval;
		protected System.Web.UI.WebControls.Button btnAdministratorApproval;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.HyperLink hlInstruction;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblEEName;
		protected System.Web.UI.WebControls.Label lblWorkPh;
		protected System.Web.UI.WebControls.Label lblHomePh;
		protected System.Web.UI.WebControls.Label lblMobilePh;
		protected System.Web.UI.WebControls.Label lblHomeEmail;
		protected System.Web.UI.WebControls.Label lblWorkEmail;
		protected System.Web.UI.WebControls.Label lblEmployer;
		protected System.Web.UI.WebControls.Label lblEmployeNo;
		protected System.Web.UI.WebControls.Label lblEENumber;
		protected System.Web.UI.WebControls.Label lblBenefitClass;
		protected System.Web.UI.WebControls.Label lblPaySchedule;
		protected System.Web.UI.WebControls.Label lblProcessingYear;
		protected System.Web.UI.WebControls.Label lblSpecicalMessage;
		protected System.Web.UI.WebControls.LinkButton lnkbtnsurvey_non_respond;
		protected System.Web.UI.WebControls.LinkButton lnkbtnRequestNotReviewed;
		protected System.Web.UI.WebControls.Label lblMessageFromBas;
		protected System.Web.UI.WebControls.LinkButton lnkbtnRequestinLast7Days;
		protected System.Web.UI.WebControls.LinkButton lnkbtnPaidInLast7Days;
		protected System.Web.UI.WebControls.LinkButton lnkbtnDeclinedInLastSevenDays;
		protected System.Web.UI.WebControls.LinkButton lnkbtnEmployeeOverBudget;
		protected System.Web.UI.WebControls.TextBox txtEmployeeSearch;
		protected System.Web.UI.WebControls.Label lblMore;
		protected System.Web.UI.WebControls.Button btnManagmentPage;
		protected System.Web.UI.WebControls.RadioButtonList opnWho;
		protected System.Web.UI.WebControls.Label lblLastSelected;
		protected System.Web.UI.WebControls.Label lblEmployeeIfo;
		protected System.Web.UI.WebControls.Button btnPLA;
        protected System.Web.UI.WebControls.Button btnCareerDevll;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        
		bool isReadOnly = false;
		bool isAdministrator = false;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label LblTemplateHeader0;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblWPhoneTitle;
		protected System.Web.UI.WebControls.Label lblHPhoneTitle;
		protected System.Web.UI.WebControls.Label lblMPhoneTitle;
		protected System.Web.UI.WebControls.Label lblEmailTitle;
		protected System.Web.UI.WebControls.Label lblWEmailTitle;
		protected System.Web.UI.WebControls.Label lblEmployerTitle;
		protected System.Web.UI.WebControls.Label lblEmployerNoTitle;
		protected System.Web.UI.WebControls.Label lblMyEnrollNoTitle;
		protected System.Web.UI.WebControls.Label lblEmployeeClassCodeTitle;
		protected System.Web.UI.WebControls.Label lblEmployeePayScheduleTitle;
		protected System.Web.UI.WebControls.Label lblCurrentPYTitle;
		protected System.Web.UI.WebControls.Label lblHeadingForAttenstionRequired;
		protected System.Web.UI.WebControls.Label lblHeadingFotTrainingFacts;
		protected System.Web.UI.WebControls.Label lblHeadingForMessageFromBAS;
		bool isTrainer	=false;
		bool isSuperContractor = false;
		string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblScript.Text ="";
			#region BasTemplate
			if (!IsPostBack)
			{
                //if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                //{
                //    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES", ConnectionString);
                //    Response.Redirect("/web_projects/PTemplate/index.htm");
                //    return;
                //}
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{					
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);					
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,false);
					if (strResult!="")
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult,false);
						return;
					}
					objBasTemplate.SetSeatchField(0);
					objBasTemplate.ShowNotes = false;
					LblTemplateHeader2.Text = objBasTemplate.Header2();		
					ViewState["AccessType"]						= objBasTemplate.strAccessType;
					ViewState["Employee_Number"]				= objBasTemplate.strEmployee_Number;
					ViewState["Processing_Year"]				= objBasTemplate.strProcessingYear;
					ViewState["Role_Restriction_Level"]			= objBasTemplate.strRole_Restriction_Level;
					ViewState["Selected_Account_Number"]		= objBasTemplate.strSelected_Account_Number;
					ViewState["Selected_Employee_Class_Code"]	= objBasTemplate.strSelected_Employee_Class_Code;
					ViewState["User_Group_ID"]					= objBasTemplate.strUser_Group_ID;
					ViewState["User_ID"]						= objBasTemplate.strUser_ID;
					ViewState["User_Name"]						= objBasTemplate.strUser_Name;
					ViewState["User_Primary_Role"]				= objBasTemplate.strUser_Primary_Role;				
				
					// setup header information. You need to add the "2nd" and "3rd" parmeter.					
				}
				catch (Exception ex)
				{
					string strError = "Error Message: "+ex.Message+"~~Application:"+ex.Source+"~~Method:"+ex.TargetSite+"~~Detail:"+ex.StackTrace;
					Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strError.Replace("\n","~"));
				}
				finally
				{
					objBasTemplate.CleanUp();
					objBasTemplate.Dispose();
				}
			}
			#endregion
			ViewState["Logged_Employee_Number"]=ViewState["Employee_Number"].ToString();
			SetUserType();            
			if (!IsPostBack)
			{

                if (isSuperContractor || isTrainer)
                {
                    LinkButton1.Visible = false;
                    if (string.IsNullOrEmpty(SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER")))
                    {
                        if (string.IsNullOrEmpty(SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "TRN_FOUND_EMPLOYEE_NUMBER")))
                        {
                            string strGetEmployee = "<script>GetEE('/Web_Projects/trn/EESearch/Default.aspx?retUrl=" + Request.Path + "?SkipCheck=YES&AllowApplicant=YES&samePage=y&start= ')</Script>";
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGetEmployee", strGetEmployee);
                            return;
                        }
                        else
                            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER",
                                SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "TRN_FOUND_EMPLOYEE_NUMBER"));
                    }
                }
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Adjust_Employee","");				
				SetupFrame();				

				string strIsAdmin="F";
				if (isAdministrator)
				{
					strIsAdmin="T";
					lnkbtnsurvey_non_respond.Enabled = false;
					lnkbtnRequestNotReviewed.Enabled= false;
					
					//opnWho.SelectedIndex=2;	// 4-10-2008
					//opnWho.Enabled = false;	// 4-10-2008
					//lblLastSelected.Text = "Last Selected Administrator";	// 4-10-2008
					//lblEmployeeIfo.Text = "Administrator Information";	// 4-10-2008

				}
				// Set the return page for reports
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ReportReturnTo", Request.Path,conn);
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PAGESTATUS", "",conn);
				lblMore.Text = BASUSA.MiscTidBit.href("More...", "_self", "MoreReports.aspx?isadmin=" + strIsAdmin);
				ViewState["Session_Record_Id"]=SQLStatic.Sessions.GetSessionRecordId(Request.Cookies["Session_ID"].Value.ToString(),ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"HOME",Request.Path+"?SkipCheck=YES",conn);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "APPLICANT_EMPLOYEE_NUMBER", "", conn); // 4/10/2008
                
				string strSelectedEmployee = "";
				//if (ViewState["User_Primary_Role"].ToString() != "100407") // apply to super usersonly
				{
					strSelectedEmployee=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER",ConnectionString);

					if (strSelectedEmployee != "")
					{
						ViewState["Employee_Number"] = strSelectedEmployee;						
					}
					else
					{
						strSelectedEmployee=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"PLA_EMPLOYEE_NUMBER",ConnectionString);
						if (strSelectedEmployee != "")
						{
							ViewState["Employee_Number"] = strSelectedEmployee;							
						}
					}
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "APPLICANT_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "TRN_FOUND_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "TRN_EMPLOYEE_NUMBER", strSelectedEmployee);
					if ((ViewState["User_Primary_Role"].ToString() == "100408") && (ViewState["User_Group_ID"].ToString() == "7"))
					{
						ViewState["Employee_Number"] = strSelectedEmployee;
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "EMPLOYEE_NUMBER", strSelectedEmployee);
					}
                    if (isTrainer)
                    {
                        ViewState["Employee_Number"] = strSelectedEmployee;
                        SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "EMPLOYEE_NUMBER", strSelectedEmployee);
                    }


					string strWho=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Who",ConnectionString);
					if (strWho != "")
					{
						opnWho.SelectedIndex = Convert.ToInt32(strWho);
						lblLastSelected.Text = lblLastSelected.Text.Replace("Employee",opnWho.SelectedItem.Text);
						lblEmployeeIfo.Text = lblEmployeeIfo.Text.Replace("Employee",opnWho.SelectedItem.Text);
					}
				}
                conn.Close();
                conn.Dispose();
				if (ViewState["User_Primary_Role"].ToString() == "100407")
				{
					SetUpAccountNumber();
					//if (ViewState["Employee_Number"].ToString()=="0")
					{
						btnAdministratorApproval.Visible = false;
                        btnPLA.Visible = false;
                        btnSupervisorApproval.Visible = false;
                        btnCareerDevll.Visible = false;
					}
					DisableReports();
				}
                if (isSuperContractor)
                {
                    SetUpAccountNumber();
                    //if (ViewState["Employee_Number"].ToString() == "0")
                    {
                        btnAdministratorApproval.Visible = false;
                        btnPLA.Visible = false;
                        btnSupervisorApproval.Visible = false;
                        btnCareerDevll.Visible = false;
                    }
                    DisableReports();
                }
				SetReadOnly();
				SetupPage();
				//SetHeaderInformation();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPLA.Click += new System.EventHandler(this.btnPLA_Click);
			this.btnSupervisorApproval.Click += new System.EventHandler(this.btnSupervisorApproval_Click);
			this.btnAdministratorApproval.Click += new System.EventHandler(this.btnAdministratorApproval_Click);
			this.btnManagmentPage.Click += new System.EventHandler(this.btnManagmentPage_Click);
			this.lnkbtnsurvey_non_respond.Click += new System.EventHandler(this.lnkbtnsurvey_non_respond_Click);
			this.lnkbtnRequestNotReviewed.Click += new System.EventHandler(this.lnkbtnRequestNotReviewed_Click);
			this.lnkbtnRequestinLast7Days.Click += new System.EventHandler(this.lnkbtnRequestinLast7Days_Click);
			this.lnkbtnPaidInLast7Days.Click += new System.EventHandler(this.lnkbtnPaidInLast7Days_Click);
			this.lnkbtnDeclinedInLastSevenDays.Click += new System.EventHandler(this.lnkbtnDeclinedInLastSevenDays_Click);
			this.lnkbtnEmployeeOverBudget.Click += new System.EventHandler(this.lnkbtnEmployeeOverBudget_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Page Setup

		private void SetupFrame()
		{
			string strParentCode = SQLStatic.Web_Data.ParentCode(Request.Path);
			string strMenuId = SQLStatic.Web_Data.MenuId(Request.Path);
			if (strParentCode != "-1")
			{
				strMenuId = "/web_projects/ptemplate/left.aspx?parentid="+strParentCode+"&menuid="+strMenuId;
				strParentCode = "/web_projects/ptemplate/Active_Top.aspx?parentid="+strParentCode;					
				string strSetupFrame = "<script>processreload('"+strParentCode+"','"+strMenuId+"','"+Request.Path+"')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"strSetupFrame",strSetupFrame);
			}			
		}

		private void SetUpAccountNumber()
		{
			object ob = SQLStatic.SQL.ExecScaler("select pkg_web.default_account_number('"+ViewState["User_Name"].ToString()+"') from dual",ConnectionString);
			if (ob != null)
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ACCOUNT_NUMBER",ob.ToString(),ConnectionString);
				ViewState["Selected_Account_Number"] = ob.ToString();
			}
		}

		private string SetFullHeader()
		{
            return string.Empty;
			DataTable tbl=null;
			string eeinfo="";
			string erinfo="";
			string strEmployee_number = ViewState["Logged_Employee_Number"].ToString();
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					ConnectionString);
				eeinfo = "Employee:&nbsp;&nbsp;&nbsp;"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
					"  -  MyEnroll#: "+strEmployee_number+
					"  Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
				erinfo = "Employer:&nbsp;&nbsp;&nbsp;"+tbl.Rows[0]["account_name"].ToString()+" (Acct# "+tbl.Rows[0]["account_number"].ToString()+")";
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"2ndTitle",eeinfo,ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"3rdTitle",erinfo,ConnectionString);
			if (!SQLStatic.Web_Data.Has_Role(strEmployee_number,"100400"))
			{
				SQLStatic.Sessions.SetSessionValue(Page.Request.Cookies["Session_ID"].Value.ToString(),"HPA","",ConnectionString);
			}
			else
				SQLStatic.Sessions.SetSessionValue(Page.Request.Cookies["Session_ID"].Value.ToString(),"HPA","PLA",ConnectionString);
			string setPTemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/header.aspx?callingurl="+Request.Path+"','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			return setPTemplate;
		}

		private void SetHeaderInformation()
		{
			string eeinfo = "";
			string erinfo = "";
			string setPTemplate = "";
			if (ViewState["User_Primary_Role"].ToString() == "100407")
			{
				eeinfo = "Training Contractor:&nbsp;&nbsp;&nbsp;"+SQLStatic.SQL.ExecScaler("select pkg_training_3.user_name_from_inter_table("+ViewState["User_ID"].ToString()+") from dual").ToString();
				erinfo = "Working For:&nbsp;&nbsp;&nbsp;Federal Deposit Insurance Corporation";
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "2ndTitle", eeinfo, ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "3rdTitle", erinfo, ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"HPA","",ConnectionString);
				setPTemplate = "<script language='javascript'>" +
					"window.open('/web_projects/ptemplate/header.aspx?callingurl="+Request.Path+"','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			}
			else if ((ViewState["User_Primary_Role"].ToString() == "100408") && (ViewState["User_Group_ID"].ToString() == "7"))
			{
				eeinfo = "Training Contractor:&nbsp;&nbsp;&nbsp;" + SQLStatic.SQL.ExecScaler("select pkg_training_3.user_name_from_inter_table(" + ViewState["User_ID"].ToString() + ") from dual").ToString();
				erinfo = "Working For:&nbsp;&nbsp;&nbsp;Federal Deposit Insurance Corporation";
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "2ndTitle", eeinfo, ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "3rdTitle", erinfo, ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "HPA", "", ConnectionString);
				setPTemplate = "<script language='javascript'>" +
					"window.open('/web_projects/ptemplate/header.aspx?callingurl=" + Request.Path + "','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			}
			else
			{
				//setPTemplate = SetFullHeader();
			}			
			Page.ClientScript.RegisterStartupScript(Page.GetType(), "setPTemplate",setPTemplate);
		} 


		private void SetupPage()
		{
			object ob=null;
			hlInstruction.NavigateUrl="javascript:popup('viewer.aspx?SessionId="+Request.Cookies["Session_ID"].Value.ToString()+"&path="+Request.Path+"&ID=1&type=ins',320,565)";
			ob = SQLStatic.SQL.ExecScaler("select pkg_web.get_page_special_msg('"+Request.Cookies["Session_ID"].Value.ToString()+"','"+Request.Path+"','1','0','viewer.aspx?SessionId="+Request.Cookies["Session_ID"].Value.ToString()+"&path="+Request.Path+"&ID=1&type=spe+') from dual",ConnectionString);
            if (ob != null)
                lblSpecicalMessage.Text = ob.ToString();
            if (string.IsNullOrEmpty(lblSpecicalMessage.Text))
                lblSpecicalMessage.Text = "No messages at this time";
			ob = null;
			SetEmployeeInfo();
			SetupMessages();
		}

		private void SetEmployeeInfo()
		{
			if (ViewState["Employee_Number"].ToString() != "0")
			{
				Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
				Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_employee_3.employee_profile",conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"emplouee_number","number","in",ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"result_list_","cursor","out",null);
				Oracle.DataAccess.Client.OracleDataReader reader = null;
				try
				{
					conn.Open();
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						lblEEName.Text = reader.GetValue(0).ToString();
						lblWorkPh.Text = reader.GetValue(1).ToString();
						lblHomePh.Text = reader.GetValue(2).ToString();
						lblMobilePh.Text = reader.GetValue(3).ToString();
						lblHomeEmail.Text = reader.GetValue(4).ToString();
						lblWorkEmail.Text = reader.GetValue(5).ToString();
						lblEmployer.Text = reader.GetValue(6).ToString();
						lblEmployeNo.Text = reader.GetValue(7).ToString();
						lblEENumber.Text = reader.GetValue(8).ToString();
						lblBenefitClass.Text = reader.GetValue(9).ToString();
						lblPaySchedule.Text = reader.GetValue(10).ToString();
						lblProcessingYear.Text = reader.GetValue(11).ToString();

					}
				}
				finally
				{
					if (reader != null)
						reader.Dispose();
					if (cmd != null)
						cmd.Dispose();
					if (conn!= null)
						conn.Dispose();
				}
			}
			
		}

//		private void SetupRollingPanel()
//		{
//			upnl.PanelSourceXml = GetRollXML();
//			upnl.DataBind();
//		}

//		private void SetupRightPanel()
//		{
//			string strXML = GetRightXML();
//			if (GetRightXML() != "")
//			{
//				upRTab.PanelSourceXml = strXML;
//				upRTab.DataBind();
//			}
//		}

		private void SetupMessages()
		{
            return;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_web.get_home_page_bas_msg",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"ps_session_id",Request.Cookies["Session_ID"].Value.ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"ps_page_url",Request.Path);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"pn_detail_id","number","in",1);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"cr","cursor","out",null);
			Oracle.DataAccess.Client.OracleDataReader reader = null;
			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();
				reader.Read();
				lblMessageFromBas.Text = reader.GetValue(0).ToString();
				
			}
			catch {}
			finally
			{
				if (reader != null)
					reader.Dispose();
				if (cmd != null)
					cmd.Dispose();
				if (conn!= null)
					conn.Dispose();
			}

//			lblMessageFromBas.Text = SQLStatic.SQL.ExecScaler(
//				"select ('"+Request.Cookies["Session_ID"].Value.ToString()+"','"+Request.Path+"',1) from dual",ConnectionString).ToString();

		}

		#endregion

		#region XML Gerator

//		private DataTable GetRollData()
//		{
//			DataTable tbl=null;
//			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
//			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_web_home_page.get_page_news",conn);
//			cmd.CommandType = System.Data.CommandType.StoredProcedure;
//			cmd.CommandTimeout = 30;			
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "ps_session_id",Request.Cookies["Session_ID"].Value.ToString());
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "ps_page_url",Request.Path);
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "pn_detail_id","number","in",1);
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "cr","cursor","out",null);			
//			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
//			DataSet mds = new DataSet();
//			try
//			{
//				conn.Open();
//				da.Fill(mds);
//				tbl=mds.Tables[0];
//			}
//			finally
//			{
//				conn.Close();
//				conn.Dispose();
//				cmd.Dispose();
//				if (da != null)
//					da.Dispose();
//				if (mds != null)
//					mds.Dispose();
//			}
//			return tbl;
//		}
//
//		private string GetRollXML()
//		{
//			
//			System.Data.DataTable dTable= GetRollData();;
//			
//			StringBuilder sb = new StringBuilder();
//			sb.Append("<?xml version='1.0' encoding='utf-8'?>\n");
//			sb.Append("<Panel xmlns='http://schemas.karamasoft.com/WebControls/UltimatePanel' CssFile='PLA_Homes.css' ScriptPath='~/Scripts' ImagePath='~/Marquee' PanelWidth='140'  GroupHeight='200' DefaultLeftIcon='Item_LeftIcon.gif' DefaultLeftIconOver='Item_LeftIcon.gif' GroupHeaderRightIcon='~/Images/UltimatePanel/GroupHeaderRightIcon.gif' GroupHeaderRightIconOpen='~/Images/UltimatePanel/GroupHeaderRightIconOpen.gif' GroupHeaderWidth='164' DefaultItemNowrap='False'>\n");
////			sb.Append("<Panel xmlns='http://schemas.karamasoft.com/WebControls/UltimatePanel' CssFile='MarqueeVer.css' ScriptPath='~/Scripts' ImagePath='~/Marquee' PanelWidth='180' GroupHeight='200' DefaultLeftIcon='Item_LeftIcon.gif' DefaultLeftIconOver='Item_LeftIcon.gif' GroupHeaderRightIcon='~/Images/UltimatePanel/GroupHeaderRightIcon.gif' GroupHeaderRightIconOpen='~/Images/UltimatePanel/GroupHeaderRightIconOpen.gif' GroupHeaderWidth='164' DefaultItemNowrap='False'>\n");
////			sb.Append("<Panel xmlns='http://schemas.karamasoft.com/WebControls/UltimatePanel' CssFile='MarqueeVer.css' ScriptPath='~/Scripts' ImagePath='~/Marquee' PanelWidth='120' GroupHeight='200'   GroupHeaderRightIcon='~/Images/UltimatePanel/GroupHeaderRightIcon.gif' GroupHeaderRightIconOpen='~/Images/UltimatePanel/GroupHeaderRightIconOpenClear.gif' GroupHeaderWidth='120' DefaultItemNowrap='False'>\n");
//
//			sb.Append("<Group xmlns=''>\n");
//			sb.Append("<Item ID='Itemx' Caption='NEWS!' ItemAlign='Center'>\n");
//			sb.Append("<Group Marquee='True' Marquee_Direction='Up' Marquee_Height='196' Marquee_ScrollAmount='1' Marquee_Vspace='1'>\n");
//
//			int cnt = 0;
//			string strTitle;
//			foreach (DataRow dr in dTable.Rows)
//			{
//				strTitle = dr["instruction"].ToString().Replace("<","&lt;").Replace(">","&gt;").Replace("'","`").Replace("&","&amp;");
//				sb.Append("<Item ID='Item"+cnt+"' Caption='"+strTitle+"' />\n");
//				cnt++;
//			}
//			sb.Append("</Group>\n");
//			sb.Append("</Item>\n");
//			sb.Append("</Group>\n");
//			sb.Append("</Panel>");
//			dTable=null;
//			return sb.ToString();
//		}
//
//		private DataTable GetRightData()
//		{
//			DataTable tbl=null;
//			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
//			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_reporting.pla_reports",conn);
//			cmd.CommandType = System.Data.CommandType.StoredProcedure;
//			cmd.CommandTimeout = 30;
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "group_record_id_","number","in",1100);
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "account_number_",ViewState["Selected_Account_Number"].ToString());
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_id_","number","in",ViewState["User_ID"].ToString());
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "result_list_","cursor","out",null);
//			
//			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
//			DataSet mds = new DataSet();
//			try
//			{
//				conn.Open();
//				da.Fill(mds);
//				tbl=mds.Tables[0];
//			}
//			finally
//			{
//				conn.Close();
//				conn.Dispose();
//				cmd.Dispose();
//				if (da != null)
//					da.Dispose();
//				if (mds != null)
//					mds.Dispose();
//			}
//			return tbl;
//		}



//		private string GetRightXML()
//		{
//			
//			System.Data.DataTable dTable= GetRightData();;
//			if (dTable.Rows.Count==0)
//			{
//				dTable.Dispose();
//				return "";
//			}
//			StringBuilder sb = new StringBuilder();
//			sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
//			sb.Append("<Panel xmlns=\"\" CssFile=\"/karama/styles/PanelOverlay.css\" ScriptPath=\"/karama/Panel_Scripts\" ImagePath=\"/karama/Images\" PanelCssClass=\"PanelOverlayPanel\" GroupHeaderCssClass=\"PanelOverlayGroupHeader\" GroupHeaderOpenCssClass=\"PanelOverlayGroupHeaderOpen\" DefaultItemCssClass=\"PanelOverlayItem\" DefaultGroupCssClass=\"PanelOverlayGroup\" DefaultItemOverCssClass=\"PanelOverlayItemOver\" PanelWidth=\"300\" GroupSpacing=\"4\" GroupHeaderWidth=\"300\" DefaultItemOver=\"Item\" GroupHeaderLeftIcon=\"GroupHeader_LeftIcon.gif\" GroupHeaderLeftIconOpen=\"GroupHeader_LeftIconOpen.gif\" GroupHeaderRightIcon=\"GroupHeader_RightIcon.gif\" GroupHeaderRightIconOpen=\"GroupHeader_RightIconOpen.gif\" DefaultLeftIcon=\"Item_LeftIcon.gif\" DefaultLeftIconOver=\"Item_LeftIcon.gif\" AutoScrollVertical=\"True\" AutoScrollHorizontal=\"True\" DefaultItemNowrap=\"False\" ShowHide=\"True\"  PanelSlip=\"True\" ShowHideItemImage=\"ShowHideLeftOver2.gif\" ShowHideItemImageOver=\"ShowHideLeftOver2.gif\" ShowHideItemCssClass=\"PanelOverlayGroupHeaderOpen\" ShowHideItemOverCssClass=\"PanelOverlayGroupHeaderOpen\" PanelOverlay=\"True\" MultiGroupOpen=\"False\" SmoothTimeout=\"0\">\n");
//			sb.Append("<Group xmlns=\"\" >\n");
//			
//			
//			int cnt = 0;
//			string strTitle;
//			string straction;
//			string strParent="-1";
//			foreach (DataRow dr in dTable.Rows)
//			{
//				if (dr["rpt_sub_group"].ToString()!= strParent)
//				{
//					if (strParent != "-1")
//					{
//						sb.Append("</Group>\n");
//						sb.Append("</Item>\n");
//					}
//
//					sb.Append("<Item ID=\"Itemh+"+cnt.ToString()+"\" Caption=\""+dr["Title"].ToString()+"\">\n");
//					sb.Append("<Group>\n");
//					strParent = dr["rpt_sub_group"].ToString(); 
//				}
//				straction = "popup('/web_projects/Reporting/FillParameters.aspx?recid="+dr["record_id"].ToString()+"&rep=DisplayExcel.aspx&accnt=',500,600)";
//				straction = straction.Replace("<","&lt;").Replace(">","&gt;").Replace("&","&amp;");
//				strTitle = dr["rpt_name"].ToString().Replace("<","&lt;").Replace(">","&gt;").Replace("'","`").Replace("&","&amp;");
//				sb.Append("<Item ID=\"Item"+cnt+"\" Caption=\""+strTitle+"\"  ClientCall=\""+straction+"\"/>\n");
//				cnt++;
//			}
//			if (strParent != "-1")
//			{
//				sb.Append("</Group>\n");
//				sb.Append("</Item>\n");
//			}
//			sb.Append("</Group>\n");
//			sb.Append("</Panel>");
//			dTable=null;
//			return sb.ToString();
//		}

		#endregion

		#region Buttons Action
		private void btnPLA_Click(object sender, System.EventArgs e)
		{
			//Bas_Utility.Utilities.Redirect(Page, "/WEB_PROJECTS/TRN/PLA/SELECTAPP.ASPX?SkipCheck=YES");
			Response.Redirect("/WEB_PROJECTS/TRN/PLA/SELECTAPP.ASPX?SkipCheck=YES",true);
		}

        protected void btnCareerDevll_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnCareerDevll_Click1(object sender, EventArgs e)
        {
            //Bas_Utility.Utilities.Redirect(Page, "/web_projects/trn/CDP2008/Default.aspx?SkipCheck=YES");
            Response.Redirect("/web_projects/trn/CDP2008/Default.aspx?SkipCheck=YES", true);
        }

		private void btnSupervisorApproval_Click(object sender, System.EventArgs e)
		{
//			if (ViewState["User_Primary_Role"].ToString() != "100407") // apply to super usersonly
			if (!isTrainer)
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_FOUND_EMPLOYEE_NUMBER",ViewState["Employee_Number"].ToString(),ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER","",ConnectionString);
			}
			//if (isAdministrator) // 4/10/2008
			//    lblScript.Text= "<script>window.open('SelectSupervisor.aspx?admin="+ViewState["Employee_Number"].ToString()+"','_blank','width=550,height=285,left=100,top=100')</script>"; // 4/10/2008
			//else // 4/10/2008
			//Bas_Utility.Utilities.Redirect(Page, "/Web_Projects/trn/PLA_Approval/SupervisorPendingApplications.aspx?SkipCheck=YES");
			Response.Redirect("/Web_Projects/trn/PLA_Approval/SupervisorPendingApplications.aspx?SkipCheck=YES",true);
		}

		private void btnAdministratorApproval_Click(object sender, System.EventArgs e)
		{
//			if (ViewState["User_Primary_Role"].ToString() != "100407") // apply to super usersonly
			if (!isTrainer)
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_FOUND_EMPLOYEE_NUMBER",ViewState["Employee_Number"].ToString(),ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER","",ConnectionString);
			}
			//Bas_Utility.Utilities.Redirect(Page, "/Web_Projects/trn/PLA_Approval/PayorPendingApprovals.aspx?SkipCheck=YES");
			Response.Redirect("/Web_Projects/trn/PLA_Approval/PayorPendingApprovals.aspx?SkipCheck=YES",true);
		}
		

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Who",opnWho.SelectedIndex.ToString(),ConnectionString);
			
			{

				string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&inst=4&AllowApplicant=YES&start=" + txtEmployeeSearch.Text+
                    "&who=" + opnWho.SelectedValue;
                
				Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y"+strParamQuery);
			}
            //else
            //    Bas_Utility.Utilities.Redirect(Page, "/web_projects/Employee_Search/Index.aspx?retUrl=" + Request.Path + "?SkipCheck=YES&AllowApplicant=YES&samePage=y&start=" + txtEmployeeSearch.Text);
				//Response.Redirect("/web_projects/Employee_Search/Index.aspx?retUrl="+Request.Path+"?SkipCheck=YES&samePage=y&start="+txtEmployeeSearch.Text);
		}

		private string setReportURL(int intID)
		{
			return "javascript:open('/web_projects/Reporting/FillParameters.aspx?recid="+intID.ToString()+"&rep=DisplayExcel.aspx&accnt=','Param','width=600,title=no,resizable,scrollbars,height=500,left=50,screenX=50,top=50,screenY=50')";
		}

		private void lnkbtnsurvey_non_respond_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				lblScript.Text = "<script>alert('This report is not available at this time it will be Coming Soon');</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=541&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(541)+"</script>";
		}

		private void lnkbtnRequestNotReviewed_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				lblScript.Text = "<script>alert('This report is not available at this time it will be Coming Soon');</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=542&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(542)+"</script>";
		}

		private void lnkbtnRequestinLast7Days_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=721&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(721)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=543&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(543)+"</script>";
		}

		private void lnkbtnPaidInLast7Days_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=722&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(722)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=544&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(544)+"</script>";
		}

		private void lnkbtnDeclinedInLastSevenDays_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=723&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(723)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=545&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(545)+"</script>";
		}
		
		private void lnkbtnEmployeeOverBudget_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=724&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(724)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=546&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(546)+"</script>";
		}
		#endregion

		private void btnManagmentPage_Click(object sender, System.EventArgs e)
		{			
			Response.Redirect("/Web_Projects/trn/Data_maintnance/Default.aspx?SkipCheck=YES&ret="+Request.Path+"?SkipCheck=Yes",true);
		}

		private void DisableReports()
		{
            lnkbtnsurvey_non_respond.Visible = false;
            lnkbtnRequestNotReviewed.Visible = false;
            lnkbtnRequestinLast7Days.Visible = false;
            lnkbtnPaidInLast7Days.Visible = false;
            lnkbtnDeclinedInLastSevenDays.Visible = false;
            lnkbtnEmployeeOverBudget.Visible = false;
			lblMore.Text = "";
            lblMore.Visible = false;
            btnManagmentPage.Visible = false;
            lblHeadingForAttenstionRequired.Text = "";
            lblHeadingFotTrainingFacts.Text = "";
            lblHeadingForMessageFromBAS.Text = "";
		}

		private void SetUserType()
		{
			isTrainer = ViewState["User_Primary_Role"].ToString() == "100407";
			isSuperContractor = (ViewState["User_Primary_Role"].ToString() == "100408") && (ViewState["User_Group_ID"].ToString() == "7");
			isAdministrator = (SQLStatic.SQL.ExecScaler("select pkg_user_access.user_has_role(" + ViewState["User_ID"].ToString() + ",100408) from dual", ConnectionString).ToString() == "1") && (ViewState["User_Group_ID"].ToString() != "7");
			isAdministrator = isAdministrator &&(SQLStatic.SQL.ExecScaler("select pkg_user_access.user_has_role("+ViewState["User_ID"].ToString()+",100400) from dual",ConnectionString).ToString()=="0");

		}

		private void SetReadOnly()
		{
			//isReadOnly = isTrainer || isAdministrator; //4/10/2008
			isReadOnly = isTrainer; //4/10/2008
			if (isReadOnly)
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_ReadOnly","T",ConnectionString);
			}
		}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"EMPLOYEE_NUMBER");
            string strSelectedEmployee = ViewState["Employee_Number"].ToString();
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "APPLICANT_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "TRN_FOUND_EMPLOYEE_NUMBER", strSelectedEmployee, ConnectionString);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "TRN_EMPLOYEE_NUMBER", strSelectedEmployee);
            Response.Redirect(Request.Path + "?SkipCheck=YES");
        }

        protected void btnCompetitiveProgram_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/trn/competitive_program/Default.aspx?SkipCheck=YES", true);
        }

        protected void lnkbtnCDPEnrolleeList_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=6143&rep=DisplayExcel.aspx");//
            Response.Redirect("/web_projects/ReportGeneratorV1/ReportFrame.aspx?recid=6143&SkipCheck=YES");
        }

        protected void lnkbtnEmployeew_noCDP_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=6144&rep=DisplayExcel.aspx");//
            Response.Redirect("/web_projects/ReportGeneratorV1/ReportFrame.aspx?recid=6144&SkipCheck=YES");
        }

        protected void lnkbtnPLAActivityBetweenDates_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=6145&rep=DisplayExcel.aspx");//
            Response.Redirect("/web_projects/ReportGeneratorV1/ReportFrame.aspx?recid=6145&SkipCheck=YES");
        }

        protected void lnkbtnPLAActivityBetweenDatesCOM_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=8863&rep=DisplayExcel.aspx");//
            Response.Redirect("/web_projects/ReportGeneratorV1/ReportFrame.aspx?recid=8863&SkipCheck=YES");
        }

        protected void lnkbtnPLANoActivityBetweenDates_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=6146&rep=DisplayExcel.aspx");//
            Response.Redirect("/web_projects/ReportGeneratorV1/ReportFrame.aspx?recid=6146&SkipCheck=YES");
        }

        protected void lnkbtnStatisticsReport_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=6203&rep=DisplayExcel.aspx");//
            Response.Redirect("/web_projects/ReportGeneratorV1/ReportFrame.aspx?recid= 6203&SkipCheck=YES");
        }


        

	}
}
