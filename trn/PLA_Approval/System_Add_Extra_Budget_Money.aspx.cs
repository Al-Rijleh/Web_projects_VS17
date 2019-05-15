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
	/// Summary description for System_Add_Extra_Budget_Money.
	/// </summary>
	public class System_Add_Extra_Budget_Money : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtEmployeeName;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RadioButtonList opnlstBudgetYear;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtAmount;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
        protected System.Web.UI.WebControls.Button btnSaveExit;
        protected System.Web.UI.WebControls.Button btnReturn;
        protected System.Web.UI.WebControls.TextBox txtReason;
	
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
				
				ViewState["Budget_Employee"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				if (ViewState["Budget_Employee"].ToString()!="")
				{
					txtEmployeeName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Name",PLA_Approval.TrainingClass.ConnectionString);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Name", "", PLA_Approval.TrainingClass.ConnectionString);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Email", "", PLA_Approval.TrainingClass.ConnectionString);
					SetBudgetYears();
					btnSaveExit.Enabled = true;
				}
			}
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			//PLA_Approval.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			btnSaveExit.Enabled = false;			
			
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
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	

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

		private void SetBudgetYears()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.budget_years_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "default_year",ViewState["Processing_Year"]);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "budget_year_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				opnlstBudgetYear.Items.Clear();				
				foreach(DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["budget_year"].ToString(),dr["rownum"].ToString());					
					opnlstBudgetYear.Items.Add(li);
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

		private void Save()
		{
//			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.add_extra_amount", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["Budget_Employee"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",opnlstBudgetYear.SelectedItem.Text);			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "total_amount_",txtAmount.Text);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_",ViewState["User_Name"].ToString());
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "reason_", txtReason.Text);
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

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
            string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a ";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl="+Request.Path+"&inst=4";
            //lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
		}

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("System_Administrator.aspx?SkipCheck=YES");
        }

        protected void btnSaveExit_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("System_Administrator.aspx?SkipCheck=YES");
        }
	}
}
