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
	/// Summary description for CancelPaidRequestinsystem.
	/// </summary>
	public class CancelPaidRequestinsystem : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtReasonCounter;
		protected System.Web.UI.WebControls.TextBox txtReason;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Cookies["Session_ID"] != null)
				if (Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
					btnSave.Enabled = false;
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text ="";
			if (!IsPostBack)
			{
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
				Training_Source.TrainingClass.SetValidators(Page);
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());				
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["AppStatus"]=Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());				
				SetHeaderInformation();	
			}				
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private string TransferedParam(string stridParam0)
		{
			string strSQL= "select pkg_trn_fdic.get_trnsfered_completed_id('"+stridParam0+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private void CanAccess()
		{
			string strSQL="select pkg_trn_fdic.canaccessevaluation("+ViewState["Record_ID"].ToString()+","+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="1")
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Unknown Application"+"&backurl=0" ,true);
			else if (strResult=="2")
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Evaluation already completed"+"&backurl=0" ,true);
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private void DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.CancelPaidRequest",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;								
			try
			{		
				string strUserID ="";
				if (ViewState["User_Name"]!=null)
					strUserID = ViewState["User_Name"].ToString();
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_","varchar2","in",txtReason.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",strUserID);				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out",null);
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

		private void lnkbtnSave_Click(object sender, System.EventArgs e)
		{
			DoSave();
			string UrlTo="";
			if ((Request.Params["call"]==null)||(Request.Params["call"].ToString()==""))
				UrlTo = "http://www.myenroll.com";
			else
				UrlTo = Request.Params["call"].ToString();
						
			lblScript.Text ="<script>alert('Your cancellation were saved and applied successfully.');;window.location.href ='"+UrlTo+"'</script>";
		}

		private void lnkbtnCancel_Click(object sender, System.EventArgs e)
		{
			if ((Request.Params["call"]==null)||(Request.Params["call"].ToString()==""))
				lblScript.Text = "<script>window.location.href='http://www.myenroll.com'</script>";
			else
				lblScript.Text = "<script>window.location.href='"+Request.Params["call"].ToString()+"'</script>";
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DoSave();
			string UrlTo="";
			if ((Request.Params["call"]==null)||(Request.Params["call"].ToString()==""))
				UrlTo = "http://www.myenroll.com";
			else
				UrlTo = Request.Params["call"].ToString();
						
			lblScript.Text ="<script>alert('Your cancellation were saved and applied successfully.');;window.location.href ='"+UrlTo+"'</script>";
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if ((Request.Params["call"]==null)||(Request.Params["call"].ToString()==""))
				lblScript.Text = "<script>window.location.href='http://www.myenroll.com'</script>";
			else
				lblScript.Text = "<script>window.location.href='"+Request.Params["call"].ToString()+"'</script>";
		}
	}
}
