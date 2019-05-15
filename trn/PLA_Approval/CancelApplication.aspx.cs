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
	/// Summary description for CancelApplication.
	/// </summary>
	public class CancelApplication : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.TextBox txtOther;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblCourceName;
		protected System.Web.UI.WebControls.Label lbl_fldPla_ApprovalSupervisorDoCancellation;
		protected System.Web.UI.WebControls.TextBox txtCounter;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Button btnSave;
	
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
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				SetHeaderInformation();					
				ProcessesStarFunctionality();
			}
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			txtOther.Enabled = false;
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
			this.txtOther.TextChanged += new System.EventHandler(this.txtOther_TextChanged);
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
            DataTable tbl = PLA_Approval.TrainingClass.Hid_CDP_into(ViewState["Request_Record_ID"].ToString());
            if (!tbl.Rows.Count.Equals(0))
            {
                lblCourseTitle.Text = "CDP - Career Development Plan " + tbl.Rows[0]["processing_year"].ToString();
                lbl_fldPla_ApprovalSupervisorDoCancellation.Text = lbl_fldPla_ApprovalSupervisorDoCancellation.Text.Replace("[ee]", tbl.Rows[0]["ee_name"].ToString());
            }
		}

		private void ShowError(string strMsg)
		{
			lblScript.Text = "<script>alert('" + strMsg + "');</script>";
		}

		private bool DoSave()
		{
            TrainingClass.HideAll_CDP_Request(ViewState["Request_Record_ID"].ToString(), ViewState["User_Name"].ToString());
            return true;

            //string strProcedureName ="basdba.PKG_Training.SupervisorCancelRequest";
            //if (Request.Params["who"]=="payor")
            //    strProcedureName ="basdba.PKG_Training.AdministratorCancelRequest";
            //Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
            //Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;		
            //conn.Open();
            //bool blnOk = true;
			
            //try
            //{				
            //    SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
            //    SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_","varchar2","in",txtOther.Text);
            //    SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
            //    SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out","");
            //    cmd.ExecuteNonQuery();
            //    if ((cmd.Parameters["error_msg_"].Value != null) && (cmd.Parameters["error_msg_"].Value.ToString() != ""))		
            //    {
            //        blnOk = false;
            //        ShowError(cmd.Parameters["error_msg_"].Value.ToString());
            //    }				
            //}			
            //finally
            //{
            //    cmd.Dispose();
            //    conn.Close();
            //    conn.Dispose();
            //}
			//return blnOk;
		}

		private void txtOther_TextChanged(object sender, System.EventArgs e)
		{
		
		}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DoSave())
            {
                if (Request.Params["who"] == "payor")
                    lblScript.Text = "<script>alert('Your decision has been saved.');document.location.replace('PayorPendingApprovals.aspx?SkipCheck=YES');</script>";
                else
                    lblScript.Text = "<script>alert('Your decision has been saved.');document.location.replace('SupervisorPendingApplications.aspx?SkipCheck=YES');</script>";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.Params["who"] == "payor")
                Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES");
            else
                Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES");
        }
	}
}
