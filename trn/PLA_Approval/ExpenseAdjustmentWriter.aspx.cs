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
	/// Summary description for ExpenseAdjustmentWriter.
	/// </summary>
	public class ExpenseAdjustmentWriter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtCounter;
		protected System.Web.UI.WebControls.TextBox txtReason;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblReasonTitle;
		protected System.Web.UI.WebControls.HyperLink hlSave;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblScript.Text = "";
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
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
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				SetHeaderInformation();
			}
			if (!IsPostBack) 
			{
				lblTitle.Text = lblTitle.Text.Replace("#",Request.Params["i"].ToString());
				lblReasonTitle.Text = lblReasonTitle.Text.Replace("#",Request.Params["i"].ToString());
				GetInitialData();
							
			}
			string strFldName = "txtReason"+Request.Params["i"].ToString();	
			hlSave.NavigateUrl = "Javascript:SaveData('"+strFldName+"');window.close();";
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;	
			hlSave.NavigateUrl = "";	
			hlSave.Enabled = false;	
			txtReason.Enabled = false;
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

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Applicant_Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}

		private void GetInitialData()
		{
			string strFldName = "txtReason"+Request.Params["i"].ToString();
			lblScript.Text = "<script>GetInitialData('"+strFldName+"');</script>";
		}

	}
}
