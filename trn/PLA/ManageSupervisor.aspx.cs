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

namespace PLA_Source
{
	/// <summary>
	/// Summary description for ManageSupervisor.
	/// </summary>
	public class ManageSupervisor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
        protected System.Web.UI.WebControls.Label lblTrainingRequest;
		protected System.Web.UI.WebControls.Label lbl_fldTraing_source_ManageSupervisorInstruction;
        protected System.Web.UI.WebControls.Label lblAssignSupervisor;
		protected System.Web.UI.WebControls.TextBox txtSupervisorName;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doSave;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
        protected System.Web.UI.WebControls.HiddenField hidReroute;
        protected System.Web.UI.WebControls.Label lblifo;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblError.Text = "";
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
            
			if (!IsPostBack)
			{
				
				Training_Source.TrainingClass.SetValidators(Page);
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);
                //}				
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				if (ViewState["Request_Record_ID"].ToString()=="-1")
				{
					lblScript.Text="<script>alert('Vendor Information page must be completed first');window.location.href='TrainingVendorInfo.aspx';</script>";
					return;
				}
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",ViewState["Employee_Number"].ToString(),Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();				
				ProcessesStarFunctionality();
				ShowCurrentSupervisor();
				if (SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", Training_Source.TrainingClass.ConnectioString) != "")
					ReadNameAndNumber();
				SetNavigation();
				string strProcessingYear = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Training_Source.TrainingClass.ConnectioString);
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strProcessingYear);
                SetupWizardMenu(); 
                string strStatus = Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());
                if (Convert.ToInt16(strStatus) > 0)
                    lblifo.Visible = true;
                else
                    lblifo.Visible = false;

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
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
     

		private void  SetupNextButton()
		{
			string strIncomplatePages=
				SQLStatic.SQL.ExecScaler("select pkg_training.incompletepages("+ViewState["Request_Record_ID"].ToString()+")from dual").ToString();
			btnNext.Enabled = Training_Source.TrainingClass.PageCompleted(Request.Path,strIncomplatePages);
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}
		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
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
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "supervisor_employee_number_", "varchar2", "out", null,20);
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
				{
					txtSupervisorName.Text = ob.ToString();
					ViewState["SupervisorName"] = txtSupervisorName.Text;
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}
		
		private bool DataChanged()
		{
			return ViewState["SupervisorName"].ToString()!=txtSupervisorName.Text;			
		}

		private void SetNavigation()
		{
			btnNext.Enabled = ViewState["Supervisor_Employee_Number"].ToString() != "-1";
			btnBack.Enabled = btnNext.Enabled;
			btnSave.Enabled = btnNext.Enabled;
			btnSelect.Text = "Replace";
			if (!btnNext.Enabled)
			{
				lblError.Text = "You must select a Supervisor before you can continue.";
				btnSelect.Text = "Select";
			}
		}

		private void ReadNameAndNumber()
		{
			ViewState["Supervisor_Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", Training_Source.TrainingClass.ConnectioString);
			txtSupervisorName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", Training_Source.TrainingClass.ConnectioString);
			ViewState["SupervisorName"]=txtSupervisorName.Text;
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", Training_Source.TrainingClass.ConnectioString);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a &who=Super&UseAltName=Reroute_Found_Employee";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl="+Request.Path+"&inst=1";
            //lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
		}

		private bool DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.Select_New_Supervisor",conn);
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
            string strStatus = Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());
            if (Convert.ToInt16(strStatus) > 0)
                lblifo.Visible = true;
            else
                lblifo.Visible = false;
			return true;
		}

		private void btnSaveandBack_Click(object sender, System.EventArgs e)
		{
			if (DoSave())
			{
				if (ViewState["PrvStpUrl"].ToString()=="")	
					Response.Redirect("SelectApp.aspx");
				else
					Response.Redirect(ViewState["PrvStpUrl"].ToString());
			}
		}

		private void btnSaveandStay_Click(object sender, System.EventArgs e)
		{
			DoSave();
			lblScript.Text = "<script>popup('saved.aspx',200,400)</script>";
		}

		private void btnSaveandNext_Click(object sender, System.EventArgs e)
		{
			if (DoSave())
			{
				Response.Redirect(ViewState["NextStpUrl"].ToString());
			}
		}

		

		private void btnNext_Click(object sender, System.EventArgs e)
		{
				if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
			{
				if (DataChanged())
					lblScript.Text = "<script>popup('Warning.aspx?d=n',200,400)</script>";				
				else	
					lblScript.Text = "<script>window.location.href='"+ViewState["NextStpUrl"].ToString()+"'</script>";
			}
			else	
				lblScript.Text = "<script>window.location.href='"+ViewState["NextStpUrl"].ToString()+"'</script>";
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
				lblScript.Text = "<script>popup('Warning.aspx?d=b',200,400)</script>";				
			else	
				lblScript.Text = "<script>window.location.href='"+ViewState["PrvStpUrl"].ToString()+"'</script>";
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SelectApp.aspx");
		}

		

		

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Employee_Number"].ToString());
		}
		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			Training_Source.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());			
			btnHome.Enabled = true;
			btnNext.Enabled = true;
			btnBack.Enabled = true;
			ddlBudgetYear.Enabled	= true;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DoSave();
			SetupWizardMenu();
			lblScript.Text = "<script>alert('Data Saved Successfully')</script>";
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			ShowCurrentSupervisor();
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
			SetupNextButton();
		}

		
	}
}
