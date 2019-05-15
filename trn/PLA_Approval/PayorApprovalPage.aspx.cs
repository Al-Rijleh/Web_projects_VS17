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
	/// Summary description for PayorApprovalPage.
	/// </summary>
	public class PayorApprovalPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtCourseCode;
		protected System.Web.UI.WebControls.TextBox txtCourseTitle;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.TextBox txtVendorContact;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblDescribtion;
		protected System.Web.UI.WebControls.LinkButton lnkbtnViewDescripeValue;
		protected System.Web.UI.WebControls.Panel pnlVendor;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursDuty;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursNonDuty;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursTotal;
		protected System.Web.UI.WebControls.Panel pnlDateTime;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTainingOther;
		protected System.Web.UI.WebControls.Panel pnlTypesNeeds;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Panel pnlExpenses;
		protected System.Web.UI.WebControls.LinkButton lnkbtnBack;
		protected System.Web.UI.WebControls.LinkButton lnkbtnNext;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancelChanges;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSaveApprovedAmount;
		protected System.Web.UI.WebControls.LinkButton lnkbtnEdit;
		protected System.Web.UI.WebControls.Label lblApprovedAmount;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label lblTotalPaid;
		protected System.Web.UI.WebControls.Label lblApprovalStatus;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label lblPaidExceedApproved;
		protected System.Web.UI.WebControls.TextBox Blinker;
		protected System.Web.UI.WebControls.Label lbl_fldPLA_ApproPayorApproval;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCopyAll;
		protected System.Web.UI.WebControls.Label lbl_fld_pla_approval_payorApplrovalPage_Option;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtLocation;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.TextBox txtSupervisorName;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtSource;
		protected System.Web.UI.WebControls.TextBox txtPurpose;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.Label Label44;
		protected System.Web.UI.WebControls.Table tblTypeofDeve;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOther;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.Label Label47;
		protected System.Web.UI.WebControls.TextBox txtDepartmentID;
		protected System.Web.UI.WebControls.TextBox txtProgramCode;
		protected System.Web.UI.WebControls.RadioButton rbAccountNo;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblNotEnoughBudgetThisYear;
		protected System.Web.UI.WebControls.Button btnNoMoneyPeriod;
		protected System.Web.UI.WebControls.Button btnInformee;
		protected System.Web.UI.WebControls.Button btnCannotVerify;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.CheckBox cbEEFilledServiceAgreement;
		protected System.Web.UI.WebControls.TextBox txtrequisitionnumber;
		protected System.Web.UI.WebControls.LinkButton lnkbtnViewSummary;
		protected System.Web.UI.WebControls.LinkButton btnExpenses;
		protected System.Web.UI.WebControls.LinkButton btnTypesNeeds;
		protected System.Web.UI.WebControls.LinkButton btnDateTime;
		protected System.Web.UI.WebControls.LinkButton btnVendor;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblRequisitionNumber;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblNoteMark;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label lblNoteMarkDetail;
		protected System.Web.UI.WebControls.Label lblNoCreereDevelopmentPlan;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
        protected System.Web.UI.WebControls.HiddenField hidReroute;
        protected System.Web.UI.WebControls.Button btnFinalize;
        protected System.Web.UI.WebControls.Button btnRequestMoreInfo;
        protected System.Web.UI.WebControls.Label lblNew;
        protected System.Web.UI.WebControls.Button btnViewDocuments;
	
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
			lblScript.Text= "";
            if ((hidReroute.Value != "") && (hidReroute.Value == "Reroute"))
            {
                hidReroute.Value = "";
                RerouteApplication();
            }
			if (!IsPostBack)
			{                
				if (ViewState["User_Group_ID"].ToString()!="1")
				{
					string strMesg = PLA_Approval.TrainingClass.IsPayorDataOk(ViewState["Employee_Number"].ToString());
					if (strMesg!="")
						Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message="+strMesg,true);
				}

				BASUSA.MiscTidBit.Hide(btnInformee);
				BASUSA.MiscTidBit.Hide(btnNoMoneyPeriod);
				BASUSA.MiscTidBit.Hide(btnCannotVerify);

				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
								
				FillSatesDropDown();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);

                if (PLA_Approval.TrainingClass.HasDocuments(ViewState["Request_Record_ID"].ToString()))
                {
                    btnViewDocuments.Visible = true;
                    lblNew.Visible = true;
                }

                if (DateTime.Today >= Convert.ToDateTime("06/01/2009"))
                    lblNew.Visible = false;
				SetHeaderInformation();
				CDPAquired();
				PLA_AccountNo();
				FillData();
				DrawGrid();
				SetInView();
				btnExpenses_Click(null,null);
				Blinker.Text ="";	
				ProcessesStarFunctionality();
				ShowCurrentAdministrator();
				txtState.Text = ddlStates.SelectedItem.Text;
				ViewState["Application_Processing_Year"]=PLA_Approval.TrainingClass.Application_Processing_Year(ViewState["Request_Record_ID"].ToString());
				ViewState["inEdit"]="F";				
				PLA_Approval.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
				Check_budget(ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
				SetApproveColumnStatus();
                processes_Reroute();
			}
			if (pnlExpenses.Visible)
			{
				DrawGrid();
				
			}
			if (Request.Params["c"]=="y")
				lblScript.Text="<script>Blink('Confirm Cancellation')</script>";
			if (Request.Params["c"]=="r")
				lblScript.Text="<script>Blink('Reactivate Request')</script>";
			HandleContractors();
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
			ViewState["Administrator_Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
            saveAdmin();
            Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES", true);
        }

        private void saveAdmin()
        {
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
                "basdba.PKG_Training.reRouteAdministrator", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Request_Record_ID", PLA_Approval.TrainingClass.ConnectionString);
            try
            {
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_", "number", "in", ViewState["Request_Record_ID"].ToString());
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Administrator_Employee_Number", "varchar2", "in", ViewState["Administrator_Employee_Number"].ToString());
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

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			//PLA_Approval.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			lnkbtnEdit.Enabled = false;
			lnkbtnCopyAll.Enabled = false;
			btnSelect.Enabled = false;
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
			this.ddlBudgetYear.SelectedIndexChanged += new System.EventHandler(this.ddlBudgetYear_SelectedIndexChanged);
			this.lnkbtnViewSummary.Click += new System.EventHandler(this.lnkbtnViewSummary_Click);
			this.lnkbtnViewDescripeValue.Click += new System.EventHandler(this.lnkbtnViewDescripeValue_Click_1);
			this.dgExpense.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgExpense_ItemCreated);
			this.lnkbtnCopyAll.Click += new System.EventHandler(this.lnkbtnCopyAll_Click);
			this.lnkbtnEdit.Click += new System.EventHandler(this.lnkbtnEdit_Click);
			this.lnkbtnSaveApprovedAmount.Click += new System.EventHandler(this.lnkbtnSaveApprovedAmount_Click);
			this.lnkbtnCancelChanges.Click += new System.EventHandler(this.lnkbtnCancelChanges_Click);
			this.lnkbtnBack.Click += new System.EventHandler(this.lnkbtnBack_Click);
			this.lnkbtnNext.Click += new System.EventHandler(this.lnkbtnNext_Click);
			this.cbEEFilledServiceAgreement.CheckedChanged += new System.EventHandler(this.cbEEFilledServiceAgreement_CheckedChanged);
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.btnInformee.Click += new System.EventHandler(this.btnInformee_Click);
			this.btnNoMoneyPeriod.Click += new System.EventHandler(this.btnNoMoneyPeriod_Click);
			this.btnCannotVerify.Click += new System.EventHandler(this.btnCannotVerify_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Check_budget(string strEmployeeNumber,string strProcessingYear)
		{
			string return_condition = "";
			string return_text = "";
			ViewState["lnkbtnFinalize"] = "T";
			PLA_Approval.TrainingClass.CheckBudgetForApproval(ViewState["Request_Record_ID"].ToString(),ViewState["expense"].ToString(),ref return_condition, ref return_text);
			if (return_condition == "1")
				return;
			string labelText = return_text;
			if (return_condition == "2")
			{
				if (PLA_Approval.TrainingClass.SubmitedContinuedServiceAgreement(strEmployeeNumber,strProcessingYear))
				{
					labelText += "\n\nEmployee indicates that he/she has completed the Continued Service Agreement Form. "+
						"If you cannot verify that the employee submited the Form,click this "+
						BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnCannotVerify')")
						+" to inform the employee (by e-mail) that you cannot verify that he/she "+
						"submitted the Continued Service Agreement form. The e-mail will also request from the employee "+
						"to provide you with a copy of the Form.";
					
				}
				else
				{
					labelText += "\n\nEmployee has not completed the Continued Service Agreement Form. Click on this "+
						BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnInformee')")
						+", to inform the applicant (by e-mail) that he/she must complete Continued Service Agreement Form before they can borrow from other years. "+
						"Clicking the link will also reset this application approval status to incomplete.";
					btnFinalize.Enabled = false;
					ViewState["lnkbtnFinalize"] = "F";
					cbEEFilledServiceAgreement.Visible=true;
				}
			}
			else
			{
				labelText += "\n\nClick this "+
					BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnNoMoneyPeriod')")
					+", to inform the applicant (by e-mail) that he/she needs to request more money from the Office/Division Director.\n"+
					"Clicking the link will also reset this application approval status to incomplete.";
                btnFinalize.Enabled = false;
				ViewState["lnkbtnFinalize"] = "F";
			}
			lblNotEnoughBudgetThisYear.Text = labelText.Replace("\n","<br>"); 
			lblScript.Text = BASUSA.MiscTidBit.JSAlert(return_text.Replace("\n","\\n"));

		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
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

		private void SetVisibility(Panel pnl, LinkButton btn)
		{
			btnVendor.Enabled=true;
			btnDateTime.Enabled=true;
			btnTypesNeeds.Enabled=true;
			btnExpenses.Enabled=true;

			pnlVendor.Visible = false;
			pnlDateTime.Visible = false;
			pnlTypesNeeds.Visible = false;
			pnlExpenses.Visible = false;

			pnl.Visible = true;
			btn.Enabled = false;
		}

		private void ShowCurrentAdministrator()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.getadminnumbername",conn);
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

		private void btnExpenses_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlExpenses, btnExpenses);
			lnkbtnBack.Enabled = true;
			lnkbtnNext.Enabled = false;
			DrawGrid();
		}

		private void btnDateTime_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlDateTime, btnDateTime);
			lnkbtnBack.Enabled = true;
			lnkbtnNext.Enabled = true;
		}

		private void btnTypesNeeds_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlTypesNeeds, btnTypesNeeds);
			lnkbtnBack.Enabled = true;
			lnkbtnNext.Enabled = true;
		}

		private void btnVendor_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlVendor, btnVendor);
			lnkbtnBack.Enabled = false;
			lnkbtnNext.Enabled = true;
		}

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,PLA_Approval.TrainingClass.ConnectionString);
			lblScript.Text = "<script>popup('/web_projects/trn/pla/error.aspx',200,400)</script>";
		}

//		private void ShowSaved(string strMsg)
//		{
//			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"SavedMsg",strMsg,PLA_Approval.TrainingClass.ConnectionString);
//			lblScript.Text = "<script>popup('saved.aspx',200,400)</script>";
//		}

		

		private void SetInView()
		{			
//			txtCourseCode.Enabled =false;
//			txtCourseTitle.Enabled=false;
//			txtLocation.Enabled=false;
//			txtVedorName.Enabled = false;
//			txtVendorContact.Enabled = false;
//			txtPhoneNumber.Enabled=false;
//			txtFaxNumber.Enabled=false;
//			txtAddressLine1.Enabled=false;
//			txtAddressLine2.Enabled=false;
//			txtCity.Enabled=false;
//			ddlStates.Enabled=false;
//			txtZipCode.Enabled=false;
//			lblDescribtion.Enabled=false;
//			txtWebSite.Enabled=false;
//			txtStartDate.Enabled=false;
//			txtEndDate.Enabled=false;
//			txtCourseHoursDuty.Enabled=false;
//			txtCourseHoursNonDuty.Enabled=false;
//			optMandatoryTraining.Enabled=false;
//			ddlSourseTraining.Enabled=false;
//			ddlPurposeOfTraining.Enabled=false;
//			txtPurposeOfTainingOther.Enabled = false;
			
		}

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Applicant_Employee_Number"].ToString());
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Applicant_Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
//			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Applicant_Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}	

		private void FillSatesDropDown()
		{
			DataTable dtStates = SQLStatic.CD_Tables.States(PLA_Approval.TrainingClass.ConnectionString);
			try
			{
				foreach (DataRow dr in dtStates.Rows)
				{
					ListItem li = new ListItem(dr["state_description"].ToString(),dr["state"].ToString());
					ddlStates.Items.Add(li);
				}
			}
			finally
			{
				if (dtStates != null)
					dtStates.Dispose();
			}
		}
		private void FillOneDropDown(DropDownList ddl,string strTableName)
		{
			
			ddl.Items.Clear();
			ddl.Items.Add(new ListItem("---- Select ----","xx"));
			string strSQL="select record_id,description from "+strTableName;
			Oracle.DataAccess.Client.OracleConnection conn = 	new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strSQL,conn);
			conn.Open();			
			Oracle.DataAccess.Client.OracleDataReader reader =null;
			try
			{
				reader = cmd.ExecuteReader();
				
				while (reader.Read())
				{
					ListItem li = new ListItem(reader.GetValue(1).ToString(),reader.GetValue(0).ToString());
					ddl.Items.Add(li);
				}
			}
			finally
			{
				reader.Dispose();
				cmd.Dispose();
				conn.Dispose();
			}
		}

		private void FillDropDowns()
		{
			FillOneDropDown(ddlSourseTraining,"cd_training_source ");
			FillOneDropDown(ddlPurposeOfTraining,"cd_training_purpose ");
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

		private void FillData()
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				txtCourseCode.Text = "";
				txtCourseTitle.Text = "";
				txtLocation.Text = "";
				txtVedorName.Text = "";
				txtPhoneNumber.Text = "";
				txtFaxNumber.Text = "";
				txtAddressLine1.Text = "";
				txtAddressLine2.Text = "";
				txtCity.Text = "";
				ddlStates.SelectedIndex = 0;
				txtZipCode.Text = "";
				txtWebSite.Text = "";
				lblDescribtion.Text = "";
				return;
			}
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.GetHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			string strAppProcessingYear = "";
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				txtCourseCode.Text = tbl.Rows[0]["course_code"].ToString();
				txtCourseTitle.Text = tbl.Rows[0]["course_title"].ToString();
				txtLocation.Text = tbl.Rows[0]["location_of_training"].ToString();
				txtVedorName.Text = tbl.Rows[0]["vendor_name"].ToString();
				txtVendorContact.Text = tbl.Rows[0]["vendor_contact"].ToString();
				txtPhoneNumber.Text = tbl.Rows[0]["vendor_phone_number"].ToString();
				txtFaxNumber.Text = tbl.Rows[0]["vendor_fax_number"].ToString();
				txtAddressLine1.Text = tbl.Rows[0]["vendor_address1"].ToString();
				txtAddressLine2.Text = tbl.Rows[0]["vendor_address2"].ToString();
				txtCity.Text = tbl.Rows[0]["vendor_city"].ToString();
				string strState = tbl.Rows[0]["vendor_state"].ToString();
				txtZipCode.Text = tbl.Rows[0]["vendor_zip_code"].ToString();
				txtWebSite.Text = tbl.Rows[0]["vendor_website"].ToString();
				strAppProcessingYear = tbl.Rows[0]["processing_year"].ToString();
				if (tbl.Rows[0]["desription_of_course_value"].ToString().Length >100)
					lblDescribtion.Text = tbl.Rows[0]["desription_of_course_value"].ToString().Substring(0,95)+"...";
				else
					lblDescribtion.Text = tbl.Rows[0]["desription_of_course_value"].ToString();
				ViewState["application_status"]= tbl.Rows[0]["application_status"].ToString();
				ViewState["description"]=tbl.Rows[0]["description"].ToString();
				ViewState["Application_Processing_Year"]=tbl.Rows[0]["processing_year"].ToString();
				for (int i=0;i<ddlStates.Items.Count;i++)
					if (ddlStates.Items[i].Value==strState)
					{
						ddlStates.SelectedIndex = i;
						break;
					}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				if (tbl != null)
					tbl.Dispose();
			}
			if (txtCourseCode.Text!="")
				lblCourseTitle.Text= txtCourseCode.Text+" - "+txtCourseTitle.Text;
			else
				lblCourseTitle.Text=txtCourseTitle.Text;
			
			lblBalance.Text = AvailableAmount(ViewState["Applicant_Employee_Number"].ToString(),strAppProcessingYear);
		}

		private void FillDataDateTimes()
		{
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.gettrainingcoursedatetimerec",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_3_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				if (tbl.Rows.Count>0)
				{
					txtStartDate.Text = tbl.Rows[0]["course_start_date"].ToString();
					txtEndDate.Text = tbl.Rows[0]["course_end_date"].ToString();
					string strCourseTime = tbl.Rows[0]["course_time"].ToString();
					txtCourseHoursDuty.Text = tbl.Rows[0]["course_hours_duty"].ToString();
					txtCourseHoursNonDuty.Text = tbl.Rows[0]["course_hours_non_duty"].ToString();
					txtCourseHoursTotal.Text = tbl.Rows[0]["course_hours_total"].ToString();					
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				if (tbl != null)
					tbl.Dispose();
			}			
		}

		private void FillDataTypesNeeds()
		{
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.TrainingTypesNeedsRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_4_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				if (tbl.Rows.Count>0)
				{
//					optMandatoryTraining.SelectedIndex = tbl.Rows[0]["mandatory_training"].ToString()=="T" ? 0 : 1;
					SetDropDownIndex(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
					SetDropDownIndex(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
					txtPurposeOfTainingOther.Text = tbl.Rows[0]["purpose_of_training_other"].ToString();
					txtTypeofDevelopmentOther.Text = tbl.Rows[0]["type_of_development_other"].ToString();
					rbAccountNo.Text = tbl.Rows[0]["account_no_description"].ToString();
					txtDepartmentID.Text = tbl.Rows[0]["dept_id"].ToString();
					txtProgramCode.Text = tbl.Rows[0]["program_code_description"].ToString();
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				if (tbl != null)
					tbl.Dispose();
			}			
		}

		private void FillSelectedTypeofDevelopment()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.type_of_development_List",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;

			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				
				int intColPos = 0;
				int intRowPos =0;
				foreach (DataRow dr in tbl.Rows)
				{					
					if (intColPos==1)
					{
						tblTypeofDeve.Rows[intRowPos].Cells[1].Text=dr["description"].ToString();
						intColPos=0;
						intRowPos++;
						
					}
					else
					{
						intColPos=1;
						tblTypeofDeve.Rows[intRowPos].Cells[0].Text=dr["description"].ToString();						
					}
					
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				if (tbl != null)
					tbl.Dispose();

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

		private string GetTotalExpense()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strResult=="")
				strResult="0";
			return Convert.ToDouble(strResult).ToString("$#,###.00");
		}

		private void DrawGrid()
		{
			DataTable dt= GetExpenseTable();
			dgExpense.DataSource = dt;
			dgExpense.DataBind();
			lblAmount.Text = GetTotalExpense();
			double dblApprovedAmount = TotalApprovedFromDatabase();			
			lblApprovedAmount.Text = dblApprovedAmount.ToString("$#,##0.00");
			dblApprovedAmount = TotalApprovedFromDatabaseSkipUnaditable();	
			double dblPaidAmount = TotalPaidFromDatabase();			
			lblTotalPaid.Text = dblPaidAmount.ToString("$#,##0.00");		
			
			if ((Math.Abs(dblPaidAmount)<0.01)&&(dblApprovedAmount>0.01))
			{
				lblApprovalStatus.Text = "Declined All Expenses";
				ViewState["Approval_Status"] = "6";
			} 
			else if ((dblApprovedAmount-dblPaidAmount)<0.01)
			{
				lblApprovalStatus.Text = "Paid in Full";
				ViewState["Approval_Status"] = "4";
			}
			else
			{
				lblApprovalStatus.Text = "Paid Partial Expenses";
				ViewState["Approval_Status"] = "5";
			}
				
			
			if ((dblPaidAmount-dblApprovedAmount)>0.01)
			{
				lblPaidExceedApproved.Text = "(Paid Amount Exceed Approved Amount)";
//				lblScript.Text="<script>Blink('Paid Amount Exceed Approved Amount')</script>";
			}
			else
			{
//				lblScript.Text="<script>Blink('end')</script>";
				lblPaidExceedApproved.Text="";
			}
			
		}

		private void dgExpense_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{					
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					double dbl = 0;
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgExpense.DataSource;
					string strindex = tbl.Rows[indx]["record_id"].ToString();						
					string strStatus = tbl.Rows[indx]["approved"].ToString();
					bool blnEditable = tbl.Rows[indx]["pay_to"].ToString() != "2";
					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="smallsize";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(75);
					ddl.ID = "ddl_"+strindex;					
					ListItem li = new ListItem("View","0");						
					ddl.Items.Add(li);						
						
					// create button
					Button btn2 = new Button();
					btn2.CssClass = "actbtn_go_next_button";
					btn2.ID="btn_"+strindex;
					btn2.Text = "Go";				
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[8];						
					cell.Controls.Add(ddl);
					cell.Controls.Add(btn2);

					if (blnEditable)
					{
						TextBox txtapp = new TextBox();
						txtapp.ID = "txt_app_"+strindex;
						txtapp.Text = tbl.Rows[indx]["paid_amount"].ToString();
						txtapp.CssClass = "smallsize";
						txtapp.Width = System.Web.UI.WebControls.Unit.Pixel(50);						
						TableCell cellApp = e.Item.Cells[3];
						cellApp.Controls.Add(txtapp);
					}
					else
					{
						Label lbl5 = new Label();
						lbl5.ID = "lbl5_"+strindex;						
						lbl5.Text = "TBD";
						lbl5.CssClass = "smallsize";
						TableCell cellApp15 = e.Item.Cells[3];
						cellApp15.Controls.Add(lbl5);
					}

					Label lbl4 = new Label();
					lbl4.ID = "lbl4_"+strindex;
					if (tbl.Rows[indx]["paid_amount"].ToString()!="")
						dbl=Convert.ToDouble(tbl.Rows[indx]["paid_amount"].ToString());
					if (blnEditable)
						lbl4.Text = dbl.ToString("$#,##0.00")+"  ";
					else
						lbl4.Text = "TBD";
					lbl4.CssClass = "smallsize";
					TableCell cellApp14 = e.Item.Cells[4];
					cellApp14.Controls.Add(lbl4);

					Button btn3 = new Button();
					btn3.CssClass = "act_savenext_button";
					btn3.ID="cpy_"+strindex;
					btn3.Text = "";
					btn3.Width = System.Web.UI.WebControls.Unit.Pixel(20);
					btn3.CausesValidation = false;
					btn3.ToolTip = "Copy To Paid Amount";
					btn3.Click += new System.EventHandler(this.btnMenu_Click);


					Label lbl = new Label();
					lbl.ID = "lbl_"+strindex;
					dbl=Convert.ToDouble(tbl.Rows[indx]["approved_amount"].ToString());
					lbl.Text = dbl.ToString("$#,##0.00")+"  ";
					lbl.CssClass = "smallsize";
					TableCell cellApp1 = e.Item.Cells[2];
					cellApp1.Controls.Add(lbl);
					if ((ViewState["inEdit"].ToString()=="T")&&(blnEditable))
						cellApp1.Controls.Add(btn3);	
				}
				catch
				{
				}
				
			}
		}
		

		private DropDownList GetDropDown(Control oMe,string txtName)
		{
			int cnt = oMe.Controls.Count;
			DropDownList ddl = null;
			for(int i=0; i<cnt; i++)
			{
				string s =oMe.Controls[i].GetType().ToString();				
				if ((oMe.Controls[i].GetType().ToString()==
					"System.Web.UI.WebControls.DropDownList"))
				{					
					ddl =(DropDownList)oMe.Controls[i];					
					if ((ddl.ID == txtName))
					{
						s = ddl.SelectedValue;
						break;
					}
					else
						ddl = null;
				}
				else 
					if (oMe.Controls[i].HasControls())
				{
					ddl = GetDropDown(oMe.Controls[i],txtName);
					if (ddl != null)
						break;
				}
			}
			return ddl;
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

		private void CopyApprovedAmount(string strIndex)
		{
			
			DataTable tbl = (DataTable) dgExpense.DataSource;
			TextBox txt;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString() == strIndex)
				{
					txt = GetTextBox(this.Page,"txt_app_"+strIndex);
					if (txt != null)
					{
						txt.Text = dr["approved_amount"].ToString();
						break;
					}
				}					
			}			
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string btnID = ((Button)sender).ID;
			string strindex = ((Button)sender).ID.Substring(4);
			if (btnID.IndexOf("btn_")!=-1)
			{
				string strUrl = "AddEditExpense.aspx?expid="+strindex+"&s=v&w=p";
				Response.Redirect(strUrl);
			}
			else
			{
				CopyApprovedAmount(strindex);
			}
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

		

		string strQuery = "";
		private void SaveField(TextBox txt)
		{
			//			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),txt.ID,txt.Text,PLA_Approval.TrainingClass.ConnectionString);
			if (strQuery=="")
				strQuery ="?"+txt.ID+"="+txt.Text;
			else
				strQuery +="&"+txt.ID+"="+txt.Text;
		}

		private void Build_Fields()
		{
			
			SaveField(txtAddressLine1);
			SaveField(txtAddressLine2);
			SaveField(txtCity);
			SaveField(txtCourseCode);
			SaveField(txtCourseHoursNonDuty);
			SaveField(txtCourseHoursNonDuty);
			SaveField(txtCourseHoursTotal);
			SaveField(txtCourseTitle);
			//			SaveField(txtDescribtion);
			SaveField(txtEndDate);
			SaveField(txtFaxNumber);
			SaveField(txtPhoneNumber);
			SaveField(txtPurposeOfTainingOther);
			SaveField(txtStartDate);
			SaveField(txtVedorName);
			SaveField(txtWebSite);
			SaveField(txtZipCode);
		}

		private void lnkbtnBack_Click(object sender, System.EventArgs e)
		{
			if (pnlDateTime.Visible)
				btnVendor_Click(null,null);
			if (pnlTypesNeeds.Visible)
				btnDateTime_Click(null,null);
			if (pnlExpenses.Visible)
				btnTypesNeeds_Click(null,null);
		}

		private void lnkbtnNext_Click(object sender, System.EventArgs e)
		{
			if (pnlVendor.Visible)
			{
				btnDateTime_Click(null,null);
				return;
			}
			if (pnlDateTime.Visible)
			{
				btnTypesNeeds_Click(null,null);
				return;
			}
			if (pnlTypesNeeds.Visible)
			{
				btnExpenses_Click(null,null);
				return;
			}
		}

		private void lnkbtnViewDescripeValue_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>popup('ViewAdditionInfo.aspx',500,700)</script>";
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>popup('SupervisorApprove.aspx',500,700)</script>";
		}
				
		private bool isGoodDataColumn()
		{
			if (!pnlExpenses.Visible)
				DrawGrid();
			DataTable tbl = (DataTable) dgExpense.DataSource;
			bool isGood = true;
			string strindex;
			TextBox txt;
			foreach(DataRow dr in tbl.Rows)
			{
				strindex = dr["record_id"].ToString();
				txt = GetTextBox(this.Page,"txt_app_"+strindex);
				if (txt != null)
				{
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
			}
			return isGood;
		}
		
		private double TotalApprovedFromDatabase()
		{
			string strSQL="select pkg_training.CalcTotalApprovedAmount("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strResult=="")
				strResult="0";	
			ViewState["expense"] = strResult;
			return Convert.ToDouble(strResult);
//			double dblTotalApproved = 0;
//			DataTable tbl = (DataTable) dgExpense.DataSource;
//			foreach(DataRow dr in tbl.Rows)
//			{
//				if (dr["approved_amount"].ToString() != "")
//					dblTotalApproved += Convert.ToDouble(dr["approved_amount"].ToString());
//			}
//			ViewState["expense"] = dblTotalApproved.ToString();
//			return dblTotalApproved;
		}

		private double TotalApprovedFromDatabaseSkipUnaditable()
		{
			double dblTotalApproved = 0;
			DataTable tbl = (DataTable) dgExpense.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["pay_to"].ToString()!="2")
				{
					if (dr["approved_amount"].ToString() != "")
						dblTotalApproved += Convert.ToDouble(dr["approved_amount"].ToString());
				}
			}
			return dblTotalApproved;
		}

		private double TotalPaidFromDatabase()
		{
			string strSQL="select pkg_training.CalcTotalPaidAmount("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strResult=="")
				strResult="0";			
			return Convert.ToDouble(strResult);
//			double dblTotalpaid = 0;
//			DataTable tbl = (DataTable) dgExpense.DataSource;
//			foreach(DataRow dr in tbl.Rows)
//			{
//				if (dr["paid_amount"].ToString() != "")
//					dblTotalpaid += Convert.ToDouble(dr["paid_amount"].ToString());
//			}
//			return dblTotalpaid;
		}

		private void SetApproveColumnStatus()
		{
			bool inEdit = ViewState["inEdit"].ToString()=="T";
			{
				dgExpense.Columns[3].Visible=inEdit;
				dgExpense.Columns[4].Visible=!inEdit;
				btnDateTime.Enabled = !inEdit;
				btnTypesNeeds.Enabled = !inEdit;
				btnVendor.Enabled = !inEdit;
				lnkbtnBack.Enabled = !inEdit;				
				btnRequestMoreInfo.Enabled = !inEdit;
				lnkbtnEdit.Enabled = !inEdit;
				lnkbtnCancelChanges.Enabled = inEdit;
				lnkbtnSaveApprovedAmount.Enabled = inEdit;
				btnFinalize.Enabled = !inEdit;
				lblTotalPaid.Visible = !inEdit;
				lnkbtnCopyAll.Enabled = !inEdit;
                if (btnFinalize.Enabled)
				{
					if (ViewState["lnkbtnFinalize"].ToString() == "F")
                        btnFinalize.Enabled = false;
				
				}
			}
		}

		private void lnkbtnEdit_Click(object sender, System.EventArgs e)
		{
			
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

		private void SaveOne(Oracle.DataAccess.Client.OracleConnection conn,string strIndex,string strValue)
		{
			
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.SaveApprovedPaidAmount",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"expns_record_id_","varchar2","in",strIndex);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"is_approved_amount_","varchar2","in","0");
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
					if (txt != null)
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
			
		}

		private void lnkbtnCancelChanges_Click(object sender, System.EventArgs e)
		{			
			
		}

		private void lnkbtnViewDescripeValue_Click_1(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>popup('ViewAdditionInfo.aspx',500,700)</script>";
		}

		private void PayAllAprovedAmounts()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.admin_pay_all_apprvd_amnt",conn);
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

		private void lnkbtnCopyAll_Click(object sender, System.EventArgs e)
		{
            PayAllAprovedAmounts();
            DrawGrid();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a&UseAltName=Reroute_Found_Employee";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
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
			Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES");
		}

		private void SubmitCanntVerify(string straction)
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
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reset_approval_","varchar2","in","0");
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
			Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES");
		}

		private void btnInformee_Click(object sender, System.EventArgs e)
		{
			SubmitNoMoney("29");
		}

		private void btnNoMoneyPeriod_Click(object sender, System.EventArgs e)
		{
			SubmitNoMoney("30");
		}

		private void btnCannotVerify_Click(object sender, System.EventArgs e)
		{
		  SubmitCanntVerify("31");
		}

		private void cbEEFilledServiceAgreement_CheckedChanged(object sender, System.EventArgs e)
		{
            btnFinalize.Enabled = cbEEFilledServiceAgreement.Checked;
		}

		private void lnkbtnViewSummary_Click(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","true",PLA_Approval.TrainingClass.ConnectionString);
			Response.Redirect("/Web_Projects/trn/PLA/NewSummary.aspx?call="+Request.Path+"?SkipCheck=YES");
		}

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES");
        }

        protected void btnFinalize_Click(object sender, EventArgs e)
        {
            if (!isGoodDataColumn())
            {
                btnExpenses_Click(null, null);
                ViewState["inEdit"] = "T";
                SetApproveColumnStatus();
                isGoodDataColumn();
                ShowError("The Paid Amount Column must be filled completely");
                return;
            }
            string strMarkCSA = "?reqno=" + txtrequisitionnumber.Text + "";
            if ((cbEEFilledServiceAgreement.Visible) && (cbEEFilledServiceAgreement.Checked))
                strMarkCSA = "?CSA=Y&reqno=" + txtrequisitionnumber.Text;



            switch (ViewState["Approval_Status"].ToString())
            {
                case "6":
                    Response.Redirect("SupervisorDecline.aspx"+ strMarkCSA+"&who=payor");
                    break;
                case "5":
                    Response.Redirect("PartialPayment.aspx" + strMarkCSA);
                    break;
                case "4":
                    Response.Redirect("PayorApprovePayment.aspx" + strMarkCSA);
                    break;
            }
        }

        protected void btnRequestMoreInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SprvsrRqstInfo.aspx?who=payor");
        }

        protected void lnkbtnCopyAll_Click1(object sender, EventArgs e)
        {
            PayAllAprovedAmounts();
            DrawGrid();
        }

        protected void lnkbtnEdit_Click1(object sender, EventArgs e)
        {
            ViewState["inEdit"] = "T";
            SetApproveColumnStatus();
            DrawGrid();
        }

        protected void lnkbtnSaveApprovedAmount_Click1(object sender, EventArgs e)
        {
            if (isGoodDataColumn())
            {
                DoSaveAmounts();
                ViewState["inEdit"] = "F";
                SetApproveColumnStatus();
                DrawGrid();
            }
            else
            {
                ViewState["inEdit"] = "T";
                SetApproveColumnStatus();
            }
            if (cbEEFilledServiceAgreement.Visible)
                cbEEFilledServiceAgreement_CheckedChanged(null, null);
        }

        protected void lnkbtnCancelChanges_Click1(object sender, EventArgs e)
        {
            ViewState["inEdit"] = "F";
            SetApproveColumnStatus();
            DrawGrid();
        }

        protected void btnViewDocuments_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/trn/Documents/ViewDocument.aspx?Back=" + Request.Path, true);
        }

   


	}
}
