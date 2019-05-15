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
	/// Summary description for SupervisorApprove.
	/// </summary>
	public class SupervisorApprove : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblCourse;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSearch;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label lblNoteTitle;
		protected System.Web.UI.WebControls.Label lbl_fldPla_ApprovalSupervisorDoApprove;
		protected System.Web.UI.WebControls.CheckBoxList chklstReasons;
		protected System.Web.UI.WebControls.TextBox txtOther;
		protected System.Web.UI.WebControls.TextBox txtMemo;
		protected System.Web.UI.WebControls.Label lblReasonMain;
		protected System.Web.UI.WebControls.LinkButton lnkbtnManageReasons;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblStar;
		protected System.Web.UI.WebControls.Label lbl_fldPla_ApprovalSupervisorDoApproveCDP;
		protected System.Web.UI.WebControls.Label lblStar2;
		protected System.Web.UI.WebControls.Label lblStarDescription;
		protected System.Web.UI.WebControls.Label lblCourceName;
		protected System.Web.UI.WebControls.TextBox txtCounter;
		protected System.Web.UI.WebControls.Label lblnumofchar;
		protected System.Web.UI.WebControls.Label lblRemainingText;
		protected System.Web.UI.WebControls.Label lblWarning;
        protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.Button btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text ="";
//			lblPassordError.Text = "";
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
                Template.BASPtemplate.SetHeaderPageNameByName(Page, "Supervisor Approval");
				lnkbtnManageReasons.Visible = (ViewState["User_Group_ID"].ToString()=="1");
				txtMemo.Width = System.Web.UI.WebControls.Unit.Pixel(1);
				txtMemo.Height = System.Web.UI.WebControls.Unit.Pixel(1);
				txtMemo.BorderColor = System.Drawing.Color.White;
				txtMemo.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
				txtMemo.ForeColor = System.Drawing.Color.White;

				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Training_Type"]=SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Training_Type",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["AccountNo"]=SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"AccountNo",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["App_Status"]=SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"App_Status",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Second_Supervisor"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Second_Supervisor",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["From_2nd_supervisor"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_2nd_supervisor",PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_2nd_supervisor","",PLA_Approval.TrainingClass.ConnectionString);
                lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
				if (ViewState["Product_Code"].ToString()=="11001")
				{                    
					lblName.Visible = false;
					lblAddress.Visible = false;
					RequiredFieldValidator1.Visible = false;
					txtEmail.Visible=false;
					txtName.Visible=false;
					lnkbtnSearch.Visible=false;
					lblStar.Visible=false;
					lblStar2.Visible = false;
					lblStarDescription.Visible = false;
					lbl_fldPla_ApprovalSupervisorDoApprove.Visible=false;
					lbl_fldPla_ApprovalSupervisorDoApproveCDP.Visible = true;
				}
                //SetHeaderInformation();	
				txtMemo.Visible = ViewState["App_Status"].ToString()=="5"&&(ViewState["From_2nd_supervisor"].ToString()!="T");
				lblNoteTitle.Visible = txtMemo.Visible;
				chklstReasons.Visible = txtMemo.Visible;
				lblReasonMain.Visible = txtMemo.Visible;
				txtOther.Visible = txtMemo.Visible;
				txtCounter.Visible = txtMemo.Visible;
				lblRemainingText.Visible = txtMemo.Visible;
				lblnumofchar.Visible = txtMemo.Visible;;
				lnkbtnManageReasons.Visible = txtMemo.Visible&&(ViewState["User_Group_ID"].ToString()=="1") ;
				GetPayorFromEEProperty();
				if (SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number",PLA_Approval.TrainingClass.ConnectionString)!="")
				  ReadNameAndEmail();
				FillReasonCheckBoxList();
				ProcessesStarFunctionality();
				CheckZeroApproved();
			}
			HandleContractors();
		}

		private void CheckZeroApproved()
		{
			string PaidAmount=SQLStatic.SQL.ExecScaler(
				"select pkg_training.calctotalapprovedamount("+ViewState["Request_Record_ID"].ToString()+") from dual").ToString();
			lblWarning.Visible = PaidAmount=="0";

		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			//PLA_Approval.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			btnSave.Enabled = false;
			chklstReasons.Enabled = false;
			txtOther.Enabled = false;
			lnkbtnSearch.Enabled = false;			
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
			this.lnkbtnSearch.Click += new System.EventHandler(this.lnkbtnSearch_Click);
			this.lnkbtnManageReasons.Click += new System.EventHandler(this.lnkbtnManageReasons_Click);
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
		
		private void FillReasonCheckBoxList()
		{			
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.reason_for_supr_partial_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_list_","cursor","out","");
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{
				
				da.Fill(mds,"Purpose");
				dTable = mds.Tables["Purpose"];				
				chklstReasons.Items.Clear();
				foreach (DataRow dr in dTable.Rows)
				{
					ListItem li = new ListItem(dr["description"].ToString(),dr["record_id"].ToString());
					chklstReasons.Items.Add(li);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();
				dTable=null;
			}
		}
		private void ReadNameAndEmail()
		{
			ViewState["Payor_EE_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
			txtName.Text=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Name",PLA_Approval.TrainingClass.ConnectionString);
			txtEmail.Text=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Email",PLA_Approval.TrainingClass.ConnectionString);

			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number","",PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Name","",PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Email","",PLA_Approval.TrainingClass.ConnectionString);
		}

		private void GetPayorFromEEProperty()
		{
			string strSQL="Select pkg_training.Payor_employee_number_from_ID("+ViewState["Request_Record_ID"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if ((ob != null) && (ob.ToString() != ""))
			{
				ViewState["Payor_EE_Number"] = ob.ToString();
				strSQL="Select pkg_training.employee_email_address("+ViewState["Payor_EE_Number"].ToString()+") from dual";
				ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
				if (ob != null)
					txtEmail.Text = ob.ToString();
				strSQL="Select pkg_training.employee_name("+ViewState["Payor_EE_Number"].ToString()+") from dual";
				ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
				if (ob != null)
					txtName.Text = ob.ToString();

			}
			ob = null;
		}
        
		private void ShowError(string strMsg)
		{
            lblScript.Text = "<script>alert('" + strMsg + "');</script>";
		}

		
        private void SavePayorNumber(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.save_payor_ee_no",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","varchar2","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Pyor_employee_number_","varchar2","in",ViewState["Payor_EE_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();
			}
		}

		private void SaveApproval(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.req_apprvd_by_sprvsor",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;	
			Oracle.DataAccess.Client.OracleParameter parm=null;
			try
			{
				int intFileLen = txtMemo.Text.Length;
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_type_","number","in",ViewState["Training_Type"].ToString());											
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"account_no_","varchar2","in",ViewState["AccountNo"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"supervisor_2nd_inline_","varchar2","in",ViewState["Second_Supervisor"].ToString());
				if (intFileLen!=0)
					SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_","varchar2","in",txtMemo.Text);
				else
					SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_","varchar2","in",null);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out","");
				ViewState["Saved"]="";
				cmd.ExecuteNonQuery();
				if ((cmd.Parameters["error_msg_"].Value!=null)&&(cmd.Parameters["error_msg_"].Value.ToString()!=""))
				{
					ShowError(cmd.Parameters["error_msg_"].Value.ToString());
					ViewState["Saved"]="F";
				}
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "APPLICANT_EMPLOYEE_NUMBER", "");
			}

			finally
			{		
				if (parm != null)
					parm = null;
				cmd.Dispose();
			}
		}

		private void Save2ndApproval(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.req_apprvd_by_2nd_sprvsor",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;	
			Oracle.DataAccess.Client.OracleParameter parm=null;
			try
			{
				int intFileLen = txtMemo.Text.Length;
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());											
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out","");
				ViewState["Saved"]="";
				cmd.ExecuteNonQuery();
                if ((cmd.Parameters["error_msg_"].Value != null) && (cmd.Parameters["error_msg_"].Value.ToString() != ""))
                {
					ShowError(cmd.Parameters["error_msg_"].Value.ToString());
					ViewState["Saved"]="F";
				}
			}				
			finally
			{		
				if (parm != null)
					parm = null;
				cmd.Dispose();
			}
		}

		private bool DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			conn.Open();
			Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
			bool blnOk = true;
			try
			{
				SavePayorNumber(conn);
				if (ViewState["From_2nd_supervisor"].ToString()!="T")
					SaveApproval(conn);
				else
					Save2ndApproval(conn);
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
			blnOk = blnOk && (ViewState["Saved"].ToString()!="F");
			return blnOk;
		}

		private bool DoSave_cdp()
		{
			bool blnSaved=true;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);			
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training_cdp.req_apprvd_by_sprvsor",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;	
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());							
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out","");
				ViewState["Saved"]="";
				conn.Open();
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["error_msg_"].Value!=null)	
				{
					ShowError(cmd.Parameters["error_msg_"].Value.ToString());
					ViewState["Saved"]="F";
				}
			}
			catch
			{
				blnSaved=false;
			}
			finally
			{		
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			}
			return blnSaved;
		}

		private void lnkbtnSearch_Click(object sender, System.EventArgs e)
		{
            string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
		}

		private bool SaveData()
		{
			if (ViewState["Product_Code"].ToString()=="11001")
				return DoSave_cdp();
			else
				return DoSave();
		}
		
		private void reasonMessage()
		{
			string strResult="";
			for (int i=0;i<chklstReasons.Items.Count;i++)
				if (chklstReasons.Items[i].Selected)
					strResult += chklstReasons.Items[i].Text+"\n\n";
			strResult += txtOther.Text;
			txtMemo.Text =  strResult;
		}

		private void lnkbtnManageReasons_Click(object sender, System.EventArgs e)
		{
			string strURL=Request.Path;
			lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/ManageReasons.aspx?type=2&surl="+strURL+"',500,700)</script>";
		}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            reasonMessage();
            if ((txtMemo.Visible) && (txtMemo.Text == ""))
            {
                ShowError("You must fill the reason for partial aprroval of the expenses.");
                return;
            }
            if (SaveData())
                if (ViewState["Product_Code"].ToString() == "11001")
                {
                    string cdpUrl = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(), "Retuen_To", PLA_Approval.TrainingClass.ConnectionString);
                    lblScript.Text = "<script>alert('Your decision has been saved..');document.location.replace('" + cdpUrl + "')</script>";
                }
                else
                    lblScript.Text = "<script>alert('Your decision has been saved.');document.location.replace('SupervisorPendingApplications.aspx?SkipCheck=YES')</script>";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES");
        }

		
		
	}
}
