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
	/// Summary description for PayorApprovePayment.
	/// </summary>
	public class PayorApprovePayment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lbl_fldPla_Approval_PayorPayFulllPayment;
		protected System.Web.UI.WebControls.Label lblWarning;
		protected System.Web.UI.WebControls.Label lblScript;
        protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.Button btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text ="";
			#region PopUp BasTemplate
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
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult.Replace("\n","~"),false);
						return;
					}
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
                Template.BASPtemplate.SetHeaderPageNameByURL(Page, Request.Path);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				SetHeaderInformation();	
				ProcessesStarFunctionality();
				CheckZeroApproved();
			}
			HandleContractors();
		}

		private void CheckZeroApproved()
		{
			string PaidAmount=SQLStatic.SQL.ExecScaler(
				"select pkg_training.calctotalpaidamount("+ViewState["Request_Record_ID"].ToString()+") from dual").ToString();
			lblWarning.Visible = PaidAmount=="0";

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
            star.SetLabel(this, ViewState["Selected_Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
		}

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,PLA_Approval.TrainingClass.ConnectionString);
			lblScript.Text = "<script>popup('/Web_Projects/trn/PLA/error.aspx',200,400)</script>";
		}

		private void SaveApproval(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.req_apprvd_by_Payor",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out","");
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["error_msg_"].Value!=null)					
					ShowError(cmd.Parameters["error_msg_"].Value.ToString());
			}
			finally
			{				
				cmd.Dispose();
			}
		}

		private void SaveCSA(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training_2.continuation_form_aproved_",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"requisition_number_","varchar2","in",Request.Params["reqno"]);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				cmd.ExecuteNonQuery();				
			}
			finally
			{				
				cmd.Dispose();
			}
		}

		private bool DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			conn.Open();
			bool blnOk = true;
            Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
            try
            {
                SaveApproval(conn);
                SaveCSA(conn);
                txn.Commit();
            }
            catch
            {
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

		protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DoSave())
                lblScript.Text = "<script>alert('Your decision has been saved.');document.location.replace('PayorPendingApprovals.aspx?SkipCheck=YES');</script>";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayorApprovalPage.aspx?SkipCheck=YES");
        }
	}
}
