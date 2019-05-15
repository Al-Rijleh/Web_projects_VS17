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
	/// Summary description for System_Assign_Supervisor.
	/// </summary>
	public class System_Assign_Supervisor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblTemplateHeader;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtEmployee;
		protected System.Web.UI.WebControls.TextBox txtSupervisor;
		protected System.Web.UI.WebControls.Button lnkbtnSearchEmployee;
		protected System.Web.UI.WebControls.Button lnkbtnSupervisor;
		protected System.Web.UI.WebControls.TextBox txtEmployeeClientNumber;
		protected System.Web.UI.WebControls.TextBox txtSupervisorClientNumber;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.Button btnExir;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);			
			lblScript.Text = "";
			#region BasTemplate
			if (!IsPostBack)
			{	
				if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"main_run",Request.Path+"?SkipCheck=YES",PLA_Approval.TrainingClass.ConnectionString);
					Response.Redirect("/web_projects/PTemplate/index.htm");
					return;
				}
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
			if (!IsPostBack)
			{
				PLA_Approval.TrainingClass.SetValidators(Page);
				SetCurrentProcessingYear();
				SetHeaderInformation();
				ProcessesStarFunctionality();
				TransferSelectedData();
				SetEmployee();
				SetSupervisor();
								
			}
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;	
			btnSave.Enabled = false;				
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
			this.lnkbtnSearchEmployee.Click += new System.EventHandler(this.lnkbtnSearchEmployee_Click);
			this.lnkbtnSupervisor.Click += new System.EventHandler(this.lnkbtnSupervisor_Click);
			this.btnExir.Click += new System.EventHandler(this.btnExir_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void TransferSelectedData()
		{
			string strFrom = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From",PLA_Approval.TrainingClass.ConnectionString);
			string strEENumber = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER",PLA_Approval.TrainingClass.ConnectionString);
			string strEEName = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_NAME",PLA_Approval.TrainingClass.ConnectionString);
			if (strFrom == "EE")
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"eeEmployee_Number",strEENumber,PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"eeEmployee_Name",strEEName,PLA_Approval.TrainingClass.ConnectionString);
			}
			else if (strFrom == "Sup")
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Number",strEENumber,PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Name",strEEName,PLA_Approval.TrainingClass.ConnectionString);
			}
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From","",PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER","",PLA_Approval.TrainingClass.ConnectionString);
		}

		private void SetEmployee()
		{
			ViewState["ee_number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"eeEmployee_Number",PLA_Approval.TrainingClass.ConnectionString);
			txtEmployee.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"eeEmployee_Name",PLA_Approval.TrainingClass.ConnectionString);
			if ((ViewState["ee_number"] != null)&&(ViewState["ee_number"].ToString() != ""))
				FillSupervisorInfo();
		}

		private void SetSupervisor()
		{
			string sup_number = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Number",PLA_Approval.TrainingClass.ConnectionString);
			if (sup_number !="")
			{
				ViewState["sup_number"] = sup_number;
				txtSupervisor.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Name",PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Number","",PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Name","",PLA_Approval.TrainingClass.ConnectionString);
				FillSupervisorClientNumber();
			}
		}

		private void FillSupervisorClientNumber()
		{
			txtSupervisorClientNumber.Text = SQLStatic.SQL.ExecScaler("select pkg_trn_fdic.client_employee_number("+ViewState["sup_number"].ToString()+") from dual",PLA_Approval.TrainingClass.ConnectionString).ToString();
		}

		private void FillSupervisorInfo()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.supervisor_info",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["ee_number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "supervisor_employee_number_","varchar2","out",null);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "supervisor_name_","varchar2","out",null);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "client_employee_number_","varchar2","out",null);
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["client_employee_number_"].Value != null)
				{
					try
					{
						ViewState["sup_number"] = cmd.Parameters["supervisor_employee_number_"].Value.ToString();
						txtSupervisor.Text = cmd.Parameters["supervisor_name_"].Value.ToString();
						txtSupervisorClientNumber.Text = cmd.Parameters["client_employee_number_"].Value.ToString();
					}
					catch
					{
					}
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();				
			}
		}

		private void SetCurrentProcessingYear()
		{
			string strSQL="select pkg_training.ee_current_processing_year("+ViewState["Employee_Number"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob==null)
				Response.Redirect("out.aspx?message=Current Processing Year is not defined for Employee Number "+ViewState["Employee_Number"].ToString(),true);
			else
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Processing_Year",ob.ToString(),PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Processing_Year"]=ob.ToString();
				ob = null;
			}
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
//			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}

		private void lnkbtnSearchEmployee_Click(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From","EE",PLA_Approval.TrainingClass.ConnectionString);
            string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a ";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl="+Request.Path+"&inst=4";
            //lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
		}

		private void lnkbtnSupervisor_Click(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From","Sup",PLA_Approval.TrainingClass.ConnectionString);
            string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl="+Request.Path+"&inst=4";
            //lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
//			lblScript.Text= "<script>popup('/web_projects/Employee_Search/Index.aspx?prefix=sup&retUrl="+Request.Path+"',500,600);</script>";
		}

		private void CleanUp()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"eeEmployee_Number","",PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"eeEmployee_Name","",PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Number","",PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"supEmployee_Name","",PLA_Approval.TrainingClass.ConnectionString);
		}

		private void btnExir_Click(object sender, System.EventArgs e)
		{
			CleanUp();
			lblScript.Text = "<script>Javascript:window.location.href='System_Administrator.aspx?SkipCheck=YES'</script>";
		}

		private void DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.SaveEmployeeSupervisor",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["ee_number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "supervisor_Employee_Number_",ViewState["sup_number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "supervisor_Client_Number_",txtSupervisorClientNumber.Text);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_",ViewState["User_Name"].ToString());
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
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DoSave();
			CleanUp();
			lblScript.Text = "<script>alert('Supervisor was saved'); Javascript:window.location.href='System_Administrator.aspx?SkipCheck=YES'</script>"; 
		}
	}
}
