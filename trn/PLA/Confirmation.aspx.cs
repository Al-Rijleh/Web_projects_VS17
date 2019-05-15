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
using System.Net;
using System.IO;

namespace PLA_Source
{
	/// <summary>
	/// Summary description for Confirmation.
	/// </summary>
	public class Confirmation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Image ImgSecImg;
		protected System.Web.UI.WebControls.Label Label40;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.TextBox txtCode;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblErrorPassword;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Label42;
		protected System.Web.UI.WebControls.Label lblDescription;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblLine2;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.TextBox txtSupervisorName;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.Label lblLine1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblNotEnoughBudgetThisYear;
		protected System.Web.UI.WebControls.RadioButtonList opnSubmitedForm;
		protected System.Web.UI.WebControls.Label lblHaveYouSubmitedForm;
		protected System.Web.UI.WebControls.Label lblsubmitNote;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label req8;
		protected System.Web.UI.WebControls.Label lblerrorbadPassword;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
        protected System.Web.UI.WebControls.HyperLink hlServiceAgreement;
		string strConfirmationNotice ="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);

			#region BasTemplate
			if (!IsPostBack)
			{				
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{					
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);					
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,true);
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
					// Wizard
					string strpnlXML = objBasTemplate.PanelXML();
					if (strpnlXML!="")
					{
						if (strpnlXML.IndexOf("Error:") != -1)
						{
							Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strpnlXML,true);
							return;
						}
						ViewState["CurrGrp"]			= objBasTemplate.Wizard_Value("CurrGrp");
						ViewState["CurrGrpTtl"]			= objBasTemplate.Wizard_Value("CurrGrpTtl");
						ViewState["CurrGrpUrl"]			= objBasTemplate.Wizard_Value("CurrGrpUrl");
						ViewState["CurrStp"]			= objBasTemplate.Wizard_Value("CurrStp");
						ViewState["CurrStpTtl"]			= objBasTemplate.Wizard_Value("CurrStpTtl");
						ViewState["CurrStpUrl"]			= objBasTemplate.Wizard_Value("CurrStpUrl");
						ViewState["Is_Step_Completed"]	= objBasTemplate.Wizard_Value("Is_Step_Completed");
						ViewState["NextGrp"]			= objBasTemplate.Wizard_Value("NextGrp");
						ViewState["NextGrpTtl"]			= objBasTemplate.Wizard_Value("NextGrpTtl");
						ViewState["NextGrpUrl"]			= objBasTemplate.Wizard_Value("NextGrpUrl");
						ViewState["NextStp"]			= objBasTemplate.Wizard_Value("NextStp");
						ViewState["NextStpTtl"]			= objBasTemplate.Wizard_Value("NextStpTtl");
						ViewState["NextStpUrl"]			= objBasTemplate.Wizard_Value("NextStpUrl");
						ViewState["NoGrp"]				= objBasTemplate.Wizard_Value("NoGrp");
						ViewState["NoStpInGrp"]			= objBasTemplate.Wizard_Value("NoStpInGrp");
						ViewState["PrvGrp"]				= objBasTemplate.Wizard_Value("PrvGrp");
						ViewState["PrvGrpTtl"]			= objBasTemplate.Wizard_Value("PrvGrpTtl");
						ViewState["PrvGrpUrl"]			= objBasTemplate.Wizard_Value("PrvGrpUrl");
						ViewState["PrvStp"]				= objBasTemplate.Wizard_Value("PrvStp");  
						ViewState["PrvStpTtl"]			= objBasTemplate.Wizard_Value("PrvStpTtl");
						ViewState["PrvStpUrl"]			= objBasTemplate.Wizard_Value("PrvStpUrl");
					}					
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
			
			lblErrorPassword.Visible = false;
			lblScript.Text= "";
			if (!IsPostBack)
			{				
				Training_Source.TrainingClass.SetValidators(Page);
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                ViewState["Book"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "BookRequest");
				if (ViewState["User_Group_ID"].ToString()=="2")
				{
					Response.Redirect("out.aspx?message="+"You are currently logged in as Benefit Administrator. You must logon as an Employee to access this program.",true);
					return;
				}
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);	
                //}
				
				

				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",ViewState["Employee_Number"].ToString(),Training_Source.TrainingClass.ConnectioString);

				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				if ((Request.Params["action"]!=null)&&(Request.Params["action"]=="PLA"))
				{
					ProcessChangeAccountNumber();
				}
				if (ViewState["Request_Record_ID"].ToString()=="-1")
				{
					lblScript.Text="<script>alert('Vendor Information page must be completed first');window.location.href='TrainingVendorInfo.aspx';</script>";
					return;
				}
				if ((Request.Params["c"]!="y")&&(Training_Source.TrainingClass.HasPendingEvaluation(ViewState["Employee_Number"].ToString())))
				{
					lblScript.Text="<script>alert('You cannot submit a new training request until you have completed the pending post-training evaluation form associated with another training request.  Please find the training request with the status “Pending Evaluation”, and use the Action Drop Down Item – Review Eval. – to complete your evaluation.  Afterwards, you may choose “Edit Request” from the Action Drop Down Box for this new training request and process your submission.');window.location.href='SelectApp.aspx';</script>";
					return;
				}
				if ((Request.Params["c"]!="y")&&(Request.Params["c"]!="r"))
				{
					PLA_AccountNo();
					if (ViewState["AccountNo"].ToString()=="5633")
					{
						string strResetAccountNo="<script>CheckResetAccountNumber();</script>";
						Page.ClientScript.RegisterStartupScript(Page.GetType(),"strResetAccountNo",strResetAccountNo);
						return;
					}
				}
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();												
				ViewState["AppStatus"]=Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());
				ShowCurrentSupervisor();
				string strProcessingYear = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Training_Source.TrainingClass.ConnectioString);
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strProcessingYear);
//				check if there is enough budget to submit the application in the budget year of the tapplication
				Check_budget(ViewState["Employee_Number"].ToString(),strProcessingYear);

				if (txtSupervisorName.Text.Trim()=="")
				{
					lblScript.Text="<script>alert('You must select your supervisor first');window.location.href='ManageSupervisor.aspx';</script>";
					return;
				}
				if (!CDPAquired())
				{
					lblScript.Text="<script>alert('You cannot submit this training request. You must have an approved CDP application first.');window.location.href='SelectApp.aspx';</script>";
					return;
				}
				if (SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", Training_Source.TrainingClass.ConnectioString) != "")
					ReadNameAndNumber();
				if ((Request.Params["c"]!="y")&&(Request.Params["c"]!="r"))
					SetupWizardMenu();
			}
			strConfirmationNotice="Immediately upon your Supervisor’s decision to approve or decline your training request, MyEnroll.com will send you an email confirmation notice.";
			
			if (Request.Params["c"]=="y")
			{
				lblLine1.Text = "Confirm Cancellation";
				strConfirmationNotice="Training request has been canceled";
				btnSave.Text = "Save & Cancel Request";
			}
			if (Request.Params["c"]=="r")
			{
				lblLine1.Text = "Reactivate Request";
				strConfirmationNotice="Training request has been reactivated";
				btnSave.Text = "Save & Activate Request";
			}
			if ((Request.Params["c"]=="y") || (Request.Params["c"]=="r"))
			{
				btnSave.Text = "Save & Apply Request";
			}
			else
			{
				if (ViewState["Supervisor_Employee_Number"].ToString()=="")
				{
					lblLine1.Text = "Your Supervisor is unkown, you cannot submit your application";
					btnSave.Enabled = false;
				}
				string strCanAccess = CanAccess();
				if (strCanAccess!="T")
				{
					if (strCanAccess=="SCH")
						lblScript.Text="<script>alert('You must Fill The Course Dates & Times Page First');window.location.href='CourseDateAndTime.aspx';</script>";
					else if (strCanAccess=="TYP")
						lblScript.Text="<script>alert('You must Fill The Training Types & Needs Page First');window.location.href='TrainingTypesAndNeeds.aspx';</script>";
					else if (strCanAccess=="EXP")
						lblScript.Text="<script>alert('You must Fill The Training Expenses Page First');window.location.href='TrainingExpenses.aspx';</script>";
					else
					{
						lblLine1.Text = "Error:";
						lblLine2.Text="You must complete all the application pages before you can submit it for approval";
					}
				}
				else
				{
					if (Convert.ToInt32(ViewState["AppStatus"].ToString())==0)
					{
                        if (ViewState["Book"].ToString() == "1")
                        {
                            lblLine1.Text = "Your training book request is ready to be sent to your supervisor for review.";
                            lblLine2.Text = "Complete the \"Signature Block\" below and click the ‘Save’ button to submit your book request.";
                        }
                        else
                        {
                            lblLine1.Text = "Your training request is ready to be sent to your supervisor for review.";
                            lblLine2.Text = "Complete the \"Signature Block\" below and click the ‘Save’ button to submit your request.";
                        }
					}
					if (Convert.ToInt32(ViewState["AppStatus"].ToString())==1)
					{
						string strInitialStatus = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Initial_Status",Training_Source.TrainingClass.ConnectioString);
						if (strInitialStatus=="2")
						{
							lblLine1.Text = "Your edits have been saved.";
							btnSave.Enabled=false;
							lblLine2.Text="Your changes are material; therefore, the system has automatically removed your request from “Pending Payment” status and resubmitted it to your supervisor for review.";
					
						}
						else
						{
							lblLine1.Text = "Your edits have been saved and are pending your supervisor’s review.";
							btnSave.Enabled=false;
							lblLine2.Text="";
						}
					}
					if (Convert.ToInt32(ViewState["AppStatus"].ToString())==2)
					{
						lblLine1.Text = "Your edits have been saved.";
						lblLine2.Text="Your changes were not material; therefore, your training request will remain in \"Pending Payment\" status.";
						btnSave.Enabled=false;
				
					}
				}				
			}
			HandleContractors();
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
			this.opnSubmitedForm.SelectedIndexChanged += new System.EventHandler(this.opnSubmitedForm_SelectedIndexChanged);
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ProcessChangeAccountNumber()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training_2.setrequesttononmandatory",conn);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_",ViewState["User_Name"].ToString());
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			Response.Redirect("Confirmation.aspx");
		}

		private string CanAccess()
		{
			return SQLStatic.SQL.ExecScaler("Select pkg_training.isrequestcomplete("+ViewState["Request_Record_ID"].ToString()+") from dual",Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private bool CDPAquired()
		{
            if (Request.Params["c"] == "y")
                return true;
            if (Request.Params["c"] == "r")
                return true;

			string strProcessing_Year = Training_Source.TrainingClass.application_Processing_Year(ViewState["Request_Record_ID"].ToString());
			return Training_Source.TrainingClass.aquiredpreaproval(ViewState["Employee_Number"].ToString(),strProcessing_Year);

			
		}

		private void PLA_AccountNo()
		{
			string strSQL = "select account_no  from trn_ee_rqst_types t where header_record_id="+ViewState["Request_Record_ID"];
			ViewState["AccountNo"] = SQLStatic.SQL.ExecScaler(strSQL);
		}

		private string GetTotalExpense()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="")
				strResult="0";
			ViewState["expense"] = strResult;
			return Convert.ToDouble(strResult).ToString("$#,###.00");
		}

		private void Check_budget(string strEmployeeNumber,string strProcessingYear)
		{
			GetTotalExpense();
			if ((Request.Params["c"]=="y")||(Request.Params["c"]=="r"))
				return;
			if (Convert.ToInt32(ViewState["AppStatus"].ToString())!=0)
				return;
			string return_condition = "";
			string return_text = "";
            string strmsge = string.Empty;
			Training_Source.TrainingClass.CheckBudgetForApproval(ViewState["Request_Record_ID"].ToString(),ViewState["expense"].ToString(),ref return_condition,ref return_text);
			if (return_condition == "1")
				return;
			if (return_condition == "2")
			{				
				lblNotEnoughBudgetThisYear.Visible = true;
				string strReturnText = BASUSA.MiscTidBit.href("Continued Service Agreement","blank_","/Continued_Service_Agreement_FDIC_2600_25B.pdf");
				strReturnText = return_text.Replace("Continued Service Agreement",strReturnText).Replace("\n","<BR>");
                strReturnText = return_text.Replace("Tara Green", "PLA Helpdesk");
                strmsge = strReturnText;
				lblNotEnoughBudgetThisYear.Text = strReturnText;
//				lblNotEnoughBudgetThisYear.Text = return_text.Replace("\n","<BR>");
				btnSave.Enabled =opnSubmitedForm.SelectedValue == "1";
				opnSubmitedForm.Visible = true;
				lblHaveYouSubmitedForm.Visible = true;
                hlServiceAgreement.Visible = true;

				lblsubmitNote.Visible=true;
				lblScript.Text="<script>alert('"+return_text.Replace("\n","\\n")+"');</script>";
				return;
			}
			else
			{
				//lblScript.Text="<script>alert('"+return_text.Replace("\n","\\n")+"');window.location.href='TrainingExpenses.aspx';</script>";
                lblScript.Text = "<script>alert('" + strmsge.Replace("\n", "\\n") + "');window.location.href='TrainingExpenses.aspx';</script>";
				return;
			}

		}

		private void ShowCurrentSupervisor()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);

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

		private void ReadNameAndNumber()
		{
			ViewState["Supervisor_Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", Training_Source.TrainingClass.ConnectioString);
			txtSupervisorName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", Training_Source.TrainingClass.ConnectioString);

			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", Training_Source.TrainingClass.ConnectioString);
		}

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>popup('error.aspx',200,400)</script>";
		}

		private void ShowSaved(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"SavedMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>popup('saved.aspx',200,400)</script>";
		}
		
		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			string parPtemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/header.aspx?callingurl="+Page.Request.Path+"','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			if (Request.Params["c"]=="y")
				parPtemplate = "<script language='javascript'>" +
					"window.open('/web_projects/ptemplate/header.aspx?pagename=Training Request Confirm Cancellation ','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			if (Request.Params["c"]=="r")
				parPtemplate = "<script language='javascript'>" +
					"window.open('/web_projects/ptemplate/header.aspx?pagename=Training Request Confirm Reactivation ','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}	

		
		private void FillOneDropDown(DropDownList ddl,string strTableName)
		{
			
			ddl.Items.Clear();
			ddl.Items.Add(new ListItem("---- Select ----","xx"));
			string strSQL="select record_id,description from "+strTableName;
			Oracle.DataAccess.Client.OracleConnection conn = 	new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
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

		private void SetDropDownIndex(DropDownList ddl,string strValue)
		{
			for (int i=0; i<ddl.Items.Count;i++)
				if (ddl.Items[i].Value==strValue)
				{
					ddl.SelectedIndex = i;
					break;
				}
		}

		private bool PasswordOK()
		{
			string strSQL="select pkg_sessions_data.validate_password('"+Request.Cookies["Session_ID"].Value.ToString()+"','"+txtPassword.Text.Replace("'","''")+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString()=="1";
		}

		private void saveSupervisor()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.Add_Supervisor",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"supervisor_employee_number_","varchar2","in",ViewState["Supervisor_Employee_Number"].ToString());
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

		private bool DoSave()
		{
			string strProcedureName = "basdba.PKG_Training.submitForApproval";
			if (Request.Params["c"]=="y")
				strProcedureName = "basdba.PKG_Training.CancelRequest";
			if (Request.Params["c"]=="r")
				strProcedureName = "basdba.PKG_Training.ReactivateRequest";

			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			bool blnResult = false;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				if (strProcedureName == "basdba.PKG_Training.submitForApproval") 
				{
					if (opnSubmitedForm.Visible)
						SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"require_continuation_","varchar2","in","1");
					else
						SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"require_continuation_","varchar2","in","0");
				}
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out",null);
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
//			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),txt.ID,txt.Text,Training_Source.TrainingClass.ConnectioString);
			if (strQuery=="")
				strQuery ="?"+txt.ID+"="+txt.Text;
			else
				strQuery +="&"+txt.ID+"="+txt.Text;
		}		

		private void CaptureImage()
		{
			WebRequest mywebReq=null ; 
			WebResponse mywebResp = null ; 
			StreamReader sr ; 
			string strHTML ;
//			mywebReq = WebRequest.Create("http://localhost/Web_Projects/PLA/TrainingTypesAndNeeds.aspx");
			mywebReq = WebRequest.Create("http://localhost/Web_Projects/PLA/SaveConfirmation.aspx"+strQuery);
			mywebResp = mywebReq.GetResponse();
			sr = new StreamReader(mywebResp.GetResponseStream());			
			strHTML =sr.ReadToEnd();
			SaveFile(strHTML);
		}

		private void SaveFile ( string buffer)
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_temp_maher.SaveBlob",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			Oracle.DataAccess.Client.OracleParameter parm = new Oracle.DataAccess.Client.OracleParameter(
				"readFile",Oracle.DataAccess.Client.OracleDbType.Blob,buffer.Length,System.Data.ParameterDirection.Input,true,
				((System.Byte)(0)),((System.Byte)(0)),"",System.Data.DataRowVersion.Current,buffer);
			cmd.Parameters.Add(parm);
			conn.Open();
			try
			{
				cmd.ExecuteNonQuery();
			}
			finally
			{
				conn.Close();
				cmd.Dispose();
				conn.Dispose();
			}
		}

		private void lnkbtnRestart_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SelectApp.aspx");
		}

		

	

		private void lnkbtnViewDescripeValue_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>popup('ViewAdditionInfo.aspx',500,600)</script>";
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.Validate();
			if (!this.IsValid)
				return;
			
			if (!PasswordOK())
			{
				lblErrorPassword.Visible = true;
				lblerrorbadPassword.Visible = true;
				lblScript.Text = BASUSA.MiscTidBit.JSAlert("Incorrect Password, Please Try Again");
			}
			
			if (!lblErrorPassword.Visible)				
			{
				saveSupervisor();
				DoSave();
				lblScript.Text ="<script>ConfirmaSave('"+strConfirmationNotice+"')</script>";
			}
			if (Request.Params["c"]=="y")
				lblLine1.Text = "Confirm Cancelation";
			if (Request.Params["c"]=="r")
				lblLine1.Text = "Reactivate Request";
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a &who=Super&UseAltName=Reroute_Found_Employee";
			Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
			//string strParamQuery="?returl="+Request.Path+"&inst=1";
			//lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Employee_Number"].ToString());
		}

		private void opnSubmitedForm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnSave.Enabled = opnSubmitedForm.SelectedValue == "1";
		}
		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			opnSubmitedForm.Enabled = false;
			btnSelect.Enabled = false;
			txtPassword.Enabled = false;
			btnSave.Enabled = false;
		}

		private void SetupWizardMenu()
		{
			string retResult = "";
			string xml=Training_Source.TrainingClass.WizardMenuXML(Request.Cookies["Session_ID"].Value.ToString(),Request.Path,ViewState["Request_Record_ID"].ToString(),ref retResult);
			if (retResult!="")
			{
				lblWizardError.Text = retResult;
				return;
			}
			UltimateMenu1.MenuSourceXml =xml;
			UltimateMenu1.DataBind();
		}
	}
}
