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

namespace PLA_Approval
{
	/// <summary>
	/// Summary description for SupervisorApproval.
	/// </summary>
	public class SupervisorApproval : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.TextBox Blinker;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RadioButtonList opnlstType;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancelChanges;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSaveApprovedAmount;
		protected System.Web.UI.WebControls.LinkButton lnkbtnEdit;
		protected System.Web.UI.WebControls.Label lblApprovedAmount;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label lblApprovalStatus;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label lblPaidExceedApproved;
		protected System.Web.UI.WebControls.Label lbl_fldPLA_ApproSupervisorApproval;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCopyAll;
		protected System.Web.UI.WebControls.Label lbl_FldPLA_ApprovalSuperVisorAbbprovalOptions;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.TextBox txtSupervisorName;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RadioButtonList opnlst2ndSupervisor;
		protected System.Web.UI.WebControls.Label lbl2ndSupervisorName;
		protected System.Web.UI.WebControls.TextBox txt2ndSupervisorName;
		protected System.Web.UI.WebControls.Button btnSelect2ndAdvisor;
		protected System.Web.UI.WebControls.RequiredFieldValidator rf2ndSupervisor;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RadioButtonList opnlstAccountNo;
		protected System.Web.UI.WebControls.Label lblNoCreereDevelopmentPlan;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblNotEnoughBudgetThisYear;
		protected System.Web.UI.WebControls.Button btnInformee;
		protected System.Web.UI.WebControls.Button btnNoMoneyPeriod;
		protected System.Web.UI.WebControls.Label lblScript2;
		protected System.Web.UI.WebControls.Label lblNOCDP;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.LinkButton lnkbtnViewSummary;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblNoteMark;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label lblNoteMarkDetail;
        protected System.Web.UI.WebControls.HiddenField hidReroute;
        protected System.Web.UI.WebControls.Button btnApprove;
        protected System.Web.UI.WebControls.Button btnDecline;
        protected System.Web.UI.WebControls.Button btnRequestInfo;
        protected System.Web.UI.WebControls.Label lblNew;
        protected System.Web.UI.WebControls.Button btnViewDocuments; 

        bool inReadOnly = false;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			#region BasTemplate
			if (!IsPostBack)
			{					
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
            inReadOnly = PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString());
			lblScript.Text= "";
			lblScript2.Text = "";
            if ((hidReroute.Value != "") && (hidReroute.Value == "Reroute"))
            {
                hidReroute.Value = "";
                RerouteApplication();
            }
            if ((hidReroute.Value != "") && (hidReroute.Value == "CancelReroute"))
            {
                hidReroute.Value = "";
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
            }
			if (!IsPostBack)
			{
				BASUSA.MiscTidBit.Hide(btnInformee);
				BASUSA.MiscTidBit.Hide(btnNoMoneyPeriod);
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
                ViewState["Application_Processing_Year"] = SQLStatic.SQL.ExecScaler("select pkg_training.application_processing_year(" + ViewState["Request_Record_ID"].ToString() + ") from dual").ToString();

                if (PLA_Approval.TrainingClass.HasDocuments(ViewState["Request_Record_ID"].ToString()))
                {
                    btnViewDocuments.Visible = true;
                    lblNew.Visible = true;
                }

                if (DateTime.Today >= Convert.ToDateTime("06/01/2009"))
                    lblNew.Visible = false;
                
                SetHeaderInformation();
				FillAccountNo();
				process2ndLineSupervisor();
				DrawGrid();				
				Blinker.Text ="";
				
				ProcessesStarFunctionality();
				ShowCurrentSupervisor();				
				PLA_Approval.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
				opnlstAccountNo_SelectedIndexChanged(null,null);
				
				CDPAquired();
				PLA_AccountNo();
				check_cdp();
                processes_Reroute();
				try
				{
					int intProcessing = Convert.ToInt16(ViewState["Application_Processing_Year"]);
					if (intProcessing <2008)
					{
						lblNoteMark.Visible=false;
						lblNote.Visible=false;
						lblNoteMarkDetail.Visible = false;
					}
				}
				catch
				{
				}
					
			}						
			DrawGrid();
			if (Request.Params["c"]=="y")
				lblScript.Text="<script>Blink('Confirm Cancellation')</script>";
			if (Request.Params["c"]=="r")
				lblScript.Text="<script>Blink('Reactivate Request')</script>";
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			//PLA_Approval.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			lnkbtnEdit.Enabled = false;
			lnkbtnCopyAll.Enabled = false;
			btnSelect.Enabled = false;
			opnlst2ndSupervisor.Enabled = false;
			opnlst2ndSupervisor.Enabled = false;
			opnlstAccountNo.Enabled = false;
			btnSelect2ndAdvisor.Enabled = false;
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
			this.lnkbtnViewSummary.Click += new System.EventHandler(this.lnkbtnViewSummary_Click);
			this.dgExpense.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgExpense_ItemCreated);
			this.lnkbtnCopyAll.Click += new System.EventHandler(this.lnkbtnCopyAll_Click);
			this.lnkbtnEdit.Click += new System.EventHandler(this.lnkbtnEdit_Click);
			this.lnkbtnSaveApprovedAmount.Click += new System.EventHandler(this.lnkbtnSaveApprovedAmount_Click);
			this.lnkbtnCancelChanges.Click += new System.EventHandler(this.lnkbtnCancelChanges_Click);
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.opnlst2ndSupervisor.SelectedIndexChanged += new System.EventHandler(this.opnlst2ndSupervisor_SelectedIndexChanged);
			this.btnSelect2ndAdvisor.Click += new System.EventHandler(this.btnSelect2ndAdvisor_Click);
			this.btnInformee.Click += new System.EventHandler(this.btnInformee_Click);
			this.btnNoMoneyPeriod.Click += new System.EventHandler(this.btnNoMoneyPeriod_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        private void processes_Reroute()
        {
			if (SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", PLA_Approval.TrainingClass.ConnectionString) != "")
            {
                bool blnConfirm = false;
                if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
                    blnConfirm = true;
                else if (PLA_Approval.TrainingClass.isAdministratorByUserID(ViewState["User_ID"].ToString()))
                    blnConfirm = true;
                string strRerouteScript = "";
                if (blnConfirm)
                {
                    string strNewSupervisor = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Name");
                    strRerouteScript = "<script>CheckReroute('" + strNewSupervisor + "')</script>";
                }
                else
                {
                    strRerouteScript = "<script>alert('You may not retroute application')</script>";
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRerouteScript", strRerouteScript);
            }
        }

        private void RerouteApplication()
        {
            if (inReadOnly)
                if (!PLA_Approval.TrainingClass.isAdministratorByUserID(ViewState["User_ID"].ToString()))
                    return;
			ViewState["Supervisor_Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
            saveSupervisor();
            Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES", true);
        }

        private void saveSupervisor()
        {
            ViewState["Product_Code"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Product_Code", PLA_Approval.TrainingClass.ConnectionString);
            string strProcedureName = "basdba.PKG_Training.reRouteSupervisor";
            if (ViewState["Product_Code"].ToString() == "11001")
                strProcedureName = "basdba.PKG_Training_cdp.reRouteSupervisor";
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Request_Record_ID", PLA_Approval.TrainingClass.ConnectionString);
            try
            {
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_", "number", "in", ViewState["Request_Record_ID"].ToString());
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "supervisor_employee_number_", "varchar2", "in", ViewState["Supervisor_Employee_Number"].ToString());
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", "varchar2", "in", ViewState["User_Name"].ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }

		private void CDPAquired()
		{
			if(lblNoCreereDevelopmentPlan.Visible)
				return;
			
			string strSQL= "select pkg_training.aquiredprerequsit("+ViewState["Request_Record_ID"].ToString()+")from dual";
			if (SQLStatic.SQL.ExecScaler(strSQL).ToString()=="0")
			{
				string stringAlertNoCDP="<script>alert('This employee does not have an approved CDP')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"stringAlertNoCDP",stringAlertNoCDP);
				lblNoCreereDevelopmentPlan.Visible=true;
			}
		}

		private void PLA_AccountNo()
		{
//			if(lblNoCreereDevelopmentPlan.Visible)
//				return;
			string strSQL = "select account_no  from trn_ee_rqst_types t where header_record_id="+ViewState["Request_Record_ID"];
			if (SQLStatic.SQL.ExecScaler(strSQL).ToString()=="5633")
			{
				string stringAlertMandatory="<script>alert('This request is assigned account# 5633 (Mandatory). All request after 1/23/2008 should be assigned account# 5632 (PLA).')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"stringAlertMandatory",stringAlertMandatory);
				if (lblNoCreereDevelopmentPlan.Visible==true)
					lblNoCreereDevelopmentPlan.Text=lblNoCreereDevelopmentPlan.Text+"<br>This request is assigned account# 5633 (Mandatory). All requests after 1/23/2008 should be assigned account# 5632 (PLA).";
				else
					lblNoCreereDevelopmentPlan.Text="This request is assigned account# 5633 (Mandatory). All requests after 1/23/2008 should be assigned account# 5632 (PLA).";
				lblNoCreereDevelopmentPlan.Visible=true;
			}
		}

		private void check_cdp()
		{

//			string strSQL = "select pkg_training_cdp.ApprovalStatus_Employee("+ViewState["Applicant_Employee_Number"].ToString()+","+ViewState["Processing_Year"].ToString()+") from dual";
//			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
//			if (strResult != "16")
//			{
//				lblNOCDP.Visible=true;
//				opnlstAccountNo.Enabled=false;
//				opnlstAccountNo.BackColor = System.Drawing.Color.Red;
//			}
		}

		private void AquiredApproval()
		{
			string strSQL="select pkg_training.AquiredPrerequsit("+ViewState["Request_Record_ID"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob.ToString()=="0") 
			{
				lblNoCreereDevelopmentPlan.Text=" Note: Employee does not  have an approved Career Development Plan for budget year "+ViewState["Application_Processing_Year"].ToString();
				lblNoCreereDevelopmentPlan.Visible = true;
				lblScript2.Text = BASUSA.MiscTidBit.JSAlert(lblNoCreereDevelopmentPlan.Text);
			}
			else
				lblNoCreereDevelopmentPlan.Visible = false;
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void Check_budget(string strEmployeeNumber,string strProcessingYear)
		{
			string return_condition = "";
			string return_text = "";
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			conn.Open();
			try
			{
				PLA_Approval.TrainingClass.CheckBudgetForApproval(conn,ViewState["Request_Record_ID"].ToString(),ViewState["expense"].ToString(),ref return_condition, ref return_text);
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		private void Check_budget(Oracle.DataAccess.Client.OracleConnection conn,string strEmployeeNumber,string strProcessingYear)
		{
			string return_condition = "";
			string return_text = "";
			PLA_Approval.TrainingClass.CheckBudgetForApproval(conn,ViewState["Request_Record_ID"].ToString(),ViewState["expense"].ToString(),ref return_condition, ref return_text);
			if (return_condition == "1")
			{
				btnApprove.Enabled =true;
				return;
			}
			string labelText = return_text;
			if (return_condition == "2")
			{
				if (PLA_Approval.TrainingClass.SubmitedContinuedServiceAgreement(strEmployeeNumber,strProcessingYear))
				{
                    btnApprove.Enabled = true;
					labelText += "\n\nEmployee indicates that he/she has completed the Continued Service Agreement" ;
				}
				else
				{
					labelText += "\n\nEmployee has not completed the Continued Service Agreement Form. Click on this "+
						BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnInformee')")
						+", to inform the applicant (by e-mail) that he/she must complete Continued Service Agreement Form before they can borrow from other years. "+
						"Clicking the link will also reset this application approval status to incomplete.";
                    btnApprove.Enabled = false;
				}
			}
			else
			{
				labelText += "\n\nClick this "+
					BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnNoMoneyPeriod')")
					+", to inform the applicant (by e-mail) that he/she needs to request more money from the Office/Division Director.\n"+
					"Clicking the link will also reset this application approval status to incomplete.";
                btnApprove.Enabled = false;
			}
			lblNotEnoughBudgetThisYear.Text = labelText.Replace("\n","<br>"); 
			lblScript.Text = BASUSA.MiscTidBit.JSAlert(return_text.Replace("\n","\\n"));

		}

		private void Check_budget()
		{
			// Save the training type into database temperoraly
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.updateAccountNo_skip_email",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;	
			try
			{				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());											
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"account_no_","varchar2","in","5632");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
				cmd.ExecuteNonQuery();
				Check_budget(conn,ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
				txn.Rollback();
			}
			finally
			{		
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}

		private void SaveAccntNo()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.updateAccountNo",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;	
			try
			{				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());											
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"account_no_","varchar2","in","5632");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				cmd.ExecuteNonQuery();				
			}
			finally
			{		
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}

		private void process2ndLineSupervisor()
		{
			ViewState["Second_Supervisor"]= SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Number",PLA_Approval.TrainingClass.ConnectionString);
			
			if (ViewState["Second_Supervisor"].ToString() != "")
			{
				txt2ndSupervisorName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Name",PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Number","",PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Name","",PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Email","",PLA_Approval.TrainingClass.ConnectionString);
				opnlst2ndSupervisor.SelectedIndex = 0;
			}
			else
				opnlst2ndSupervisor.SelectedIndex = 1;
			opnlst2ndSupervisor_SelectedIndexChanged(null,null);
		}

		private void ShowCurrentSupervisor()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.GetSupervisorNumberName",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"save_it","varchar2","in","T");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"supervisor_employee_number_","varchar2","out",null,20);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"supervisor_name_","varchar2","out",null,100);
				conn.Open();
				cmd.ExecuteNonQuery();
				object ob = cmd.Parameters["supervisor_employee_number_"].Value;
				if (ob != null)
					ViewState["Supervisor_Employee_Number"]= ob.ToString();
				else
					ViewState["Supervisor_Employee_Number"]= "-1";
				ob = cmd.Parameters["supervisor_name_"].Value;
				if (ob != null) 
					txtSupervisorName.Text = ob.ToString();
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}

		

		private  string CourseName(string record_id)
		{
			return SQLStatic.SQL.ExecScaler("select PKG_Training.CourseCodeTitle("+record_id+") from dual",
				PLA_Approval.TrainingClass.ConnectionString).ToString();
		}	
		
		private  string AvailableAmount(string employee_number,string processing_year)
		{

			string strAmount = SQLStatic.SQL.ExecScaler("select pkg_training.availablebalance("+employee_number+","+processing_year+") from dual",
				PLA_Approval.TrainingClass.ConnectionString).ToString();
			return Convert.ToDouble(strAmount).ToString("$##,0.00");
		}


		private void ShowError(string strMsg)
		{
			lblScript.Text = "<script>alert('"+strMsg+"')</script>";
		}		

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Applicant_Employee_Number"].ToString());
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Applicant_Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}	

		
		

		private void FillAccountNo()
		{
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.account_no_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
						
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"list_","cursor","out","");
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{
				
				da.Fill(mds,"Purpose");
				dTable = mds.Tables["Purpose"];	
				opnlstAccountNo.Items.Clear();			
				foreach (DataRow dr in dTable.Rows)
				{
					ListItem li = new ListItem(dr["description"].ToString(),dr["account_no"].ToString());
					opnlstAccountNo.Items.Add(li);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();
				dTable=null;
			}
			opnlstAccountNo.SelectedIndex = 0;
		}


		

		private void SetDropDownIndex(DropDownList ddl,string strValue)
		{
			for (int i=0; i<ddl.Items.Count;i++)
				if (ddl.Items[i].Value==strValue)
				{
					ddl.SelectedIndex = i;
					break;
				}
		}

		private DataTable GetExpenseTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetEmployeeExpenses",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Expenses_List_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
			}
			return tbl;
		}

		private double GetTotalExpenseDouble()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strResult=="")
				strResult="0";
			ViewState["expense"] = strResult;
			return Convert.ToDouble(strResult);
		}

		private string GetTotalExpense()
		{
			return GetTotalExpenseDouble().ToString("$#,###.00");
		}

		private void DrawGrid()
		{
			DataTable dt= GetExpenseTable();
			dgExpense.DataSource = dt;
			dgExpense.DataBind();
			lblAmount.Text = GetTotalExpense();
			double dblApprovedAmount = TotalApprovedFromDatabase();
			double dblEstimatedAmount = GetTotalExpenseDouble();
			ViewState["Approved"]=dblApprovedAmount.ToString();
			ViewState["Estimated"] = dblEstimatedAmount.ToString();
			if ((Math.Abs(dblApprovedAmount)<0.01)&&(dblEstimatedAmount>0.01))
			{
				lblApprovalStatus.Text = "Declined All Expenses";
				ViewState["App_Status"] = "6";
			} 
			else if (Math.Abs(dblApprovedAmount-dblEstimatedAmount)<0.01)
			{
				lblApprovalStatus.Text = "Paid in Full";
				ViewState["App_Status"] = "4";
			}
			else
			{
				lblApprovalStatus.Text = "Paid Partial Expenses";
				ViewState["App_Status"] = "5";
			}
			  
			if ((dblApprovedAmount-dblEstimatedAmount)>0.01)
			{
				lblPaidExceedApproved.Text = "(Approved Amount Exceed Estimated Amount)";
			}
			else
			{
				lblPaidExceedApproved.Text="";
			}

			lblAmount.Text = dblEstimatedAmount.ToString("$#,##0.00");
			lblApprovedAmount.Text = dblApprovedAmount.ToString("$#,##0.00");
		
		}

		private void dgExpense_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				if ((e.Item.ItemType==ListItemType.Item)||
					(e.Item.ItemType==ListItemType.AlternatingItem)||
					(e.Item.ItemType==ListItemType.SelectedItem))
				{
					try
					{
						int indx = e.Item.ItemIndex;
						DataTable tbl = (DataTable) dgExpense.DataSource;
						string strindex = tbl.Rows[indx]["record_id"].ToString();	
						ViewState["est_"+strindex] = tbl.Rows[indx]["amount"].ToString();						

						// create drop down
						DropDownList ddl = new DropDownList();
						ddl.CssClass="fontsmall";
						ddl.Width=System.Web.UI.WebControls.Unit.Pixel(75);
						ddl.ID = "ddl_"+strindex;					
						ListItem li = new ListItem("View","0");
						ddl.Items.Add(li);										
						// create button
						Button btn2 = new Button();
						btn2.CssClass = "actbtn_go_next_button";
						btn2.ID="btn_"+strindex;
						btn2.Text = "Go";
						btn2.CausesValidation = false;
						btn2.Click += new System.EventHandler(this.btnMenu_Click);
						TableCell cell = e.Item.Cells[8];						
						cell.Controls.Add(ddl);
						cell.Controls.Add(btn2);

						TextBox txtapp = new TextBox();
						txtapp.ID = "txt_app_"+strindex;
						txtapp.Text = tbl.Rows[indx]["approved_amount"].ToString();
						txtapp.CssClass = "fontsmall";
						txtapp.Width = System.Web.UI.WebControls.Unit.Pixel(50);
						
						

						TableCell cellApp = e.Item.Cells[2];
						cellApp.Controls.Add(txtapp);
//						cellApp.Controls.Add(btn3);		
				
						Button btn3 = new Button();
						btn3.CssClass = "act_savenext_button";
						btn3.ID="cpy_"+strindex;
						btn3.Text = "";
						btn3.Width = System.Web.UI.WebControls.Unit.Pixel(20);
						btn3.CausesValidation = false;
						btn3.ToolTip = "Copy To Approved Amount";
						btn3.Click += new System.EventHandler(this.btnMenu_Click);

//						ImageButton btn3 = new ImageButton();
//						btn3.ID="cpy_"+strindex;						
//						btn3.Width = System.Web.UI.WebControls.Unit.Pixel(20);
//						btn3.CausesValidation = false;
//						btn3.ToolTip = "Copy From Estimated Amount";
//						btn3.ImageUrl = "Act_SaveNext_Button.gif.gif";
//						btn3.Click += new System.EventHandler(this.btnMenuImage_Click);

						Label lbl = new Label();
						lbl.ID = "lbl_"+strindex;
						double dbl=Convert.ToDouble(tbl.Rows[indx]["amount"].ToString());
						lbl.Text = dbl.ToString("$#,##0.00")+"  ";
						lbl.CssClass = "fontsmall";
						TableCell cellApp1 = e.Item.Cells[1];
						cellApp1.Controls.Add(lbl);
						if (ViewState["inEdit"].ToString()=="T")
							cellApp1.Controls.Add(btn3);		
					}
					catch
					{
					}
				}
			}
		}

		private void CopyEstimatedAmount(string strIndex)
		{
			TextBox txt =  GetTextBox(this.Page,"txt_app_"+strIndex);
			txt.Text = ViewState["est_"+strIndex].ToString();
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string btnID = ((Button)sender).ID;
			string strindex = btnID.Substring(4);
			if (btnID.IndexOf("btn_")!=-1)
			{
				string strUrl = "AddEditExpense.aspx?expid="+strindex+"&s=v&w=s";
				Response.Redirect(strUrl);
			}
			else
			{
				CopyEstimatedAmount(strindex);
			}
		}

		private TextBox GetTextBox(Control oMe,string txtName)
		{
			int cnt = oMe.Controls.Count;
			TextBox txt = null;
			for(int i=0; i<cnt; i++)
			{
				string s =oMe.Controls[i].GetType().ToString();
				if ((oMe.Controls[i].GetType().ToString()==
					"System.Web.UI.WebControls.TextBox"))
				{
					txt =(TextBox)oMe.Controls[i];
					if ((txt.ID == txtName))
					{
						s = txt.Text;
						break;
					}
					else
						txt = null;
				}
				else 
					if (oMe.Controls[i].HasControls())
				{
					txt = GetTextBox(oMe.Controls[i],txtName);
					if (txt != null)
						break;
				}
			}
			return txt;
		}
		

		private bool DoSave()
		{
			string strProcedureName = "basdba.PKG_Training.submitForApproval";
			if (Request.Params["c"]=="y")
				strProcedureName = "basdba.PKG_Training.CancelRequest";
			if (Request.Params["c"]=="r")
				strProcedureName = "basdba.PKG_Training.ReactivateRequest";

			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			bool blnResult = false;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out","");
				conn.Open();
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["error_msg_"].Value==null)
					blnResult = true;
				else
					ShowError(cmd.Parameters["error_msg_"].Value.ToString());
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			return blnResult;
		}


	

		private void lnkbtnViewDescripeValue_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>popup('ViewAdditionInfo.aspx',500,700)</script>";
		}		

		

		private double TotalApprovedFromDatabase()
		{
			string strSQL="select pkg_training.CalcTotalApprovedAmount("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strResult=="")
				strResult="0";			
			return Convert.ToDouble(strResult);
		}	
	
		private double TotalEstimatedFromDatabase()
		{
			double dblTotalEstimated = 0;
			DataTable tbl = (DataTable) dgExpense.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["amount"].ToString() != "")
					dblTotalEstimated += Convert.ToDouble(dr["amount"].ToString());
			}
			return dblTotalEstimated;
		}		

		private bool IsGoodDouble(string strNumber)
		{
			try
			{
				double dbl = Convert.ToDouble(strNumber);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private bool isGoodDataColumn()
		{
			DataTable tbl = (DataTable) dgExpense.DataSource;
			bool isGood = true;
			string strindex;
			TextBox txt;
			foreach(DataRow dr in tbl.Rows)
			{
				strindex = dr["record_id"].ToString();
				txt = GetTextBox(this.Page,"txt_app_"+strindex);

				if (txt.Text == "")
				{
					txt.Text = "Req";
					txt.ForeColor=System.Drawing.Color.Red;
					isGood = false;
				}
				else if (! IsGoodDouble(txt.Text))
				{
					txt.Text = "Number Only";
					txt.ForeColor=System.Drawing.Color.Red;
					isGood = false;
				}
				else
					txt.ForeColor=System.Drawing.Color.Black;
			}
			return isGood;
		}

		private double TotalFromGrid()
		{
			double dblTotalApproved = 0; 
			string strindex;
			TextBox txt;
			DataTable tbl = (DataTable) dgExpense.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				strindex = dr["record_id"].ToString();
				txt = GetTextBox(this.Page,"txt_app_"+strindex);

				if (txt.Text != "")
					dblTotalApproved += Convert.ToDouble(txt.Text);
			}
			return dblTotalApproved;
		}

		private void SaveOne(Oracle.DataAccess.Client.OracleConnection conn,string strIndex,string strValue)
		{
			
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.SaveApprovedPaidAmount",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"expns_record_id_","varchar2","in",strIndex);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"is_approved_amount_","varchar2","in","1");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"amount_","varchar2","in",strValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();
			}

		}

		private bool DoSaveAmounts()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			conn.Open();
			Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
			bool blnOk = true;
			try
			{				
				string strindex;
				TextBox txt;
				DataTable tbl = (DataTable) dgExpense.DataSource;
				foreach(DataRow dr in tbl.Rows)
				{
					strindex = dr["record_id"].ToString();
					txt = GetTextBox(this.Page,"txt_app_"+strindex);
					SaveOne(conn,strindex,txt.Text);					
				}
				txn.Commit();
			}
			catch
			{
				blnOk = false;
				txn.Rollback();
				throw;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
			return blnOk;
		}

		private void lnkbtnSaveApprovedAmount_Click(object sender, System.EventArgs e)
		{
			if (isGoodDataColumn())
			{
				DoSaveAmounts();				
				ViewState["inEdit"]="F";
				SetApproveColumnStatus();
                btnApprove.Enabled = true;
				DrawGrid();
				PLA_Approval.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
			} 
			else
			{
				ViewState["inEdit"]="T";
				SetApproveColumnStatus();
			}

		}

		private void SetApproveColumnStatus()
		{
			bool inEdit = ViewState["inEdit"].ToString()=="T";
				
			dgExpense.Columns[2].Visible=inEdit;
			dgExpense.Columns[3].Visible=!inEdit;
			
			opnlstType.Enabled = !inEdit;
			btnRequestInfo.Enabled = !inEdit;
			lnkbtnEdit.Enabled = !inEdit;
			lnkbtnCancelChanges.Enabled = inEdit;
			lnkbtnSaveApprovedAmount.Enabled = inEdit;
            btnApprove.Enabled = !inEdit;
			btnDecline.Enabled = !inEdit;
			lnkbtnCopyAll.Enabled = !inEdit;
			lblApprovedAmount.Visible = !inEdit;
            if (btnApprove.Enabled)
			{
				double dblApprovedAmount = TotalApprovedFromDatabase();
				double dblEstimatedAmount = GetTotalExpenseDouble();
                btnApprove.Enabled = (dblApprovedAmount > 0.01) || (dblEstimatedAmount < 0.01);					
			}			
		}
		private void lnkbtnEdit_Click(object sender, System.EventArgs e)
		{
			ViewState["inEdit"]="T";
			SetApproveColumnStatus();	
			DrawGrid();
		}


		private void lnkbtnCancelChanges_Click(object sender, System.EventArgs e)
		{			
			ViewState["inEdit"]="F";
			SetApproveColumnStatus();	
			DrawGrid();
		}

		private bool AllowApproval()
		{
			if ((ViewState["Estimated"].ToString()!="0")&&(ViewState["Approved"].ToString()=="0"))
				return false;
			else
				return true;
		}		

		private void ApproveAllEstimate()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.sprvsr_approve_all_est_amnt",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","varchar2","in",ViewState["Request_Record_ID"].ToString());				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			}
		}

		private void lnkbtn_Click(object sender, System.EventArgs e)
		{
			ApproveAllEstimate();
			ViewState["inEdit"]="F";
			SetApproveColumnStatus();
			btnApprove.Enabled = true;
			DrawGrid();
			PLA_Approval.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
		}

		private void btnMenuImage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			CopyEstimatedAmount(strindex);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a&who=Super&UseAltName=Reroute_Found_Employee";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl=SupervisorPendingApplications.aspx?SkipCheck=YES&inst=2";
            //lblScript.Text = "<script>popup('SearchEmployee.aspx"+strParamQuery+"',530,700)</script>";
		}

		private void lnkbtnCopyAll_Click(object sender, System.EventArgs e)
		{
			ApproveAllEstimate();
			ViewState["inEdit"]="F";
			SetApproveColumnStatus();
			btnApprove.Enabled = true;
			DrawGrid();
		}

		private void opnlst2ndSupervisor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lbl2ndSupervisorName.Visible = opnlst2ndSupervisor.SelectedValue=="T";
			txt2ndSupervisorName.Visible = opnlst2ndSupervisor.SelectedValue=="T";
			btnSelect2ndAdvisor.Visible = opnlst2ndSupervisor.SelectedValue=="T";
			rf2ndSupervisor.Visible = opnlst2ndSupervisor.SelectedValue=="T";
		}

		private void btnSelect2ndAdvisor_Click(object sender, System.EventArgs e)
		{
            string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a&UseAltName=TRN_2nd_Line_Supervisor";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl=SupervisorApproval.aspx?SkipCheck=YES&inst=7";
            //lblScript.Text = "<script>popup('SearchEmployee.aspx"+strParamQuery+"',530,700)</script>";
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = PLA_Approval.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Applicant_Employee_Number"].ToString());
		}

		private void SubmitNoMoney(string straction)
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_trn_budget.HandelBudgetEmail",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"pla_header_record_id_","varchar2","in",ViewState["Request_Record_ID"].ToString());				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"action_","varchar2","in",straction);								
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reset_approval_","varchar2","in","1");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			}
			Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES");
			
		}

		private void btnInformee_Click(object sender, System.EventArgs e)
		{
			SaveAccntNo();
			SubmitNoMoney("29");
		}

		private void btnNoMoneyPeriod_Click(object sender, System.EventArgs e)
		{
			SaveAccntNo();
			SubmitNoMoney("30");
		}

		private void opnlstAccountNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			if (opnlstAccountNo.SelectedValue == "5632")			
			{
				AquiredApproval();
				if (lblNotEnoughBudgetThisYear.Text == "")
				{
					Check_budget();
					if (lblNotEnoughBudgetThisYear.Text != "")
						return;
				}
			}
			else
			{
				lblNotEnoughBudgetThisYear.Text = "";
				lblNoCreereDevelopmentPlan.Visible = false;
                btnApprove.Enabled = true;
			}
		}

		private void lnkbtnViewSummary_Click(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","true",PLA_Approval.TrainingClass.ConnectionString);
			Response.Redirect("/Web_Projects/trn/PLA/NewSummary.aspx?call="+Request.Path+"?SkipCheck=YES");
		}

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            DrawGrid();
            if (!AllowApproval())
            {
                ShowError("The total approved amount is zero. Please enter the approved amounts first");
                return;
            }

            if (isGoodDataColumn())
            {
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Training_Type", opnlstType.SelectedValue, PLA_Approval.TrainingClass.ConnectionString);
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "AccountNo", "5632", PLA_Approval.TrainingClass.ConnectionString);
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "App_Status", ViewState["App_Status"].ToString(), PLA_Approval.TrainingClass.ConnectionString);
                if (opnlst2ndSupervisor.SelectedValue == "T")
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Second_Supervisor", ViewState["Second_Supervisor"].ToString(), PLA_Approval.TrainingClass.ConnectionString);
                else
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Second_Supervisor", "", PLA_Approval.TrainingClass.ConnectionString);
                Response.Redirect("SupervisorApprove.aspx?backto=" + Request.Path);
                //lblScript.Text = "<script>popup('SupervisorApprove.aspx',500,700)</script>";
            }
            else
            {                
                ViewState["inEdit"] = "T";
                SetApproveColumnStatus();
                isGoodDataColumn();
                ShowError("The Approved Amount Column must be filled completely");
            }
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorDecline.aspx");
        }


        protected void btnRequestInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SprvsrRqstInfo.aspx");
        }

        protected void btnViewDocuments_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/trn/Documents/ViewDocument.aspx?Back=" + Request.Path, true);
        }
	
	}
}
