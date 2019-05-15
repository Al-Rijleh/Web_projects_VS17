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
	/// Summary description for System_Administrator.
	/// </summary>
	public class System_Administrator : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblRerouteAdminCount;
		protected System.Web.UI.WebControls.LinkButton lnkbtnRerouteAdministrators;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblReroute2nsSupCount;
		protected System.Web.UI.WebControls.LinkButton lnkbtnReroute2ndSInlineSup;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAddBudget;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAdjustPaidRequest;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAssignSupervisor;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Table1.Visible = false;
			return;
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
				
				SetCurrentProcessingYear();
				SetHeaderInformation();
				ProcessesStarFunctionality();
				SetupItems();
				CheckForAddBudget();
			}
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;	
			Hyperlink1.NavigateUrl = "/web_projects/trn/PLA_Homes/Home1.aspx";				
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
			this.lnkbtnRerouteAdministrators.Click += new System.EventHandler(this.lnkbtnRerouteAdministrators_Click);
			this.lnkbtnReroute2ndSInlineSup.Click += new System.EventHandler(this.lnkbtnReroute2ndSInlineSup_Click);
			this.lnkbtnAddBudget.Click += new System.EventHandler(this.lnkbtnAddBudget_Click);
			this.lnkbtnAdjustPaidRequest.Click += new System.EventHandler(this.lnkbtnAdjustPaidRequest_Click);
			this.lnkbtnAssignSupervisor.Click += new System.EventHandler(this.lnkbtnAssignSupervisor_Click);
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

		private void SetupItems()
		{
			string strWork="";
			strWork = PendingRerouteAdministrators();
			lblRerouteAdminCount.Text = "("+strWork+" Pending)";
			lnkbtnRerouteAdministrators.Enabled = strWork != "0";

			strWork = PendingReroute2ndInlineSupervisor();
			lblReroute2nsSupCount.Text = "("+strWork+" Pending)";
			lnkbtnReroute2ndSInlineSup.Enabled = strWork != "0";
		}

		private string PendingRerouteAdministrators()
		{
			string strSQL= "select pkg_training.term_admin_pending_payment("+ViewState["Employee_Number"].ToString()+") from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
		}

		private string PendingReroute2ndInlineSupervisor()
		{
			string strSQL= "select pkg_training.term_2nd_sup_pending_approv("+ViewState["Employee_Number"].ToString()+") from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
		}

		private void lnkbtnRerouteAdministrators_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("system_administrator_process_Reroute.aspx?what=admin&SkipCheck=YES");
		}

		private void lnkbtnReroute2ndSInlineSup_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("system_administrator_process_Reroute.aspx?what=2nd&SkipCheck=YES");
		}

		private void lnkbtnAddBudget_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("System_Add_Extra_Budget_Money.aspx?SkipCheck=YES");
		}

		private void lnkbtnAdjustPaidRequest_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("System_Adjust_Paid_Request.aspx?SkipCheck=YES");
		}

		private void lnkbtnAssignSupervisor_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("System_Assign_Supervisor.aspx?SkipCheck=YES");
		}

		private void CheckForAddBudget()
		{
//			if (ViewState["Employee_Number"].ToString()=="120165")
//				return;
//			string dtrDivision=SQLStatic.SQL.ExecScaler("select pkg_employee_3.ee_division("+ViewState["Employee_Number"].ToString()+") from dual").ToString();
//			if (dtrDivision!="CU")
//				lnkbtnAddBudget.Enabled=false;
			lnkbtnAddBudget.Enabled= SQLStatic.SQL.ExecScaler("select pkg_training_3.can_add_extra_amount("+ViewState["Employee_Number"].ToString()+") from dual").ToString()=="1";


		}
	

	}
}
