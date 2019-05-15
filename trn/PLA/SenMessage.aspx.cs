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
	/// Summary description for SenMessage.
	/// </summary>
	public class SenMessage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtMemo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label lblPassordError;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.LinkButton lnbtnSave;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.Label lblFromPosition;
		protected System.Web.UI.WebControls.Label lblFromName;
		protected System.Web.UI.WebControls.Label lblToPosition;
		protected System.Web.UI.WebControls.Label lblToName;
		protected System.Web.UI.WebControls.CheckBoxList chklstEmailTo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblReplayFrom;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblScript;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text ="";
			lblPassordError.Text = "";
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
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);	
                //}
				
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["Loged_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"From_Employee_Number",Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();	
				SetSubject();
//				GetUserEmployeeNumber();
				GetInvolvedEmployeesData();
				
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
			this.chklstEmailTo.SelectedIndexChanged += new System.EventHandler(this.chklstEmailTo_SelectedIndexChanged);
			this.lnbtnSave.Click += new System.EventHandler(this.lnbtnSave_Click);
			this.lnkbtnCancel.Click += new System.EventHandler(this.lnkbtnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>popup('error.aspx',200,400)</script>";
		}

//		private void GetUserEmployeeNumber()
//		{
//			string strSQL="select pkg_training.employee_number_from_user_id('"+ViewState["User_ID"]+"') from dual";
//			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
//			ViewState["Loged_Employee_Number"]=ob.ToString();
//		}

		private bool PasswordOK()
		{
			string strSQL="select pkg_sessions_data.validate_password('"+Request.Cookies["Session_ID"].Value.ToString()+"','"+txtPassword.Text.Replace("'","''")+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString()=="1";
		}

		private void SetSubject()
		{
			string strSQL="select pkg_training.emailSubject("+Request.Params["indx"]+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
			if (ob != null)
				if (ob.ToString().IndexOf("RE:")==-1)
					txtSubject.Text = "RE: "+ob.ToString();
			    else
					txtSubject.Text = ob.ToString();
			ob = null;
		}

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"] = Training_Source.TrainingClass.SetHeaderInformation(ViewState["Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
			lblReplayFrom.Text = Training_Source.TrainingClass.Employee_Name(ViewState["Employee_Number"].ToString());
		}

		private void AddItemToSelection(string strPosition, string strEmployeeNumbe, string strName)
		{
			if (strEmployeeNumbe=="")
				return;
			ListItem li = new ListItem(strPosition+" - "+strName,strEmployeeNumbe);
			li.Selected = true;
			chklstEmailTo.Items.Add(li);
		}

		private void GetInvolvedEmployeesData()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.Get_Possible_CommEEs",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;		
			conn.Open();
			try
			{
				int intFileLen = txtMemo.Text.Length;	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Communication_record_id_","number","in",Request.Params["indx"]);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_employee_number_","number","in",ViewState["Employee_Number"].ToString());
				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"sprvsr_employee_number_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"sprvsr_name_","varchar2","out","");

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"payor_employee_number_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"payor_name_","varchar2","out","");

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"applicant_employee_number_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"applicant_name_","varchar2","out","");

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_employee_number_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_name_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_position_","varchar2","out","");

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_employee_number_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_name_","varchar2","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_position_","varchar2","out","");

				cmd.ExecuteNonQuery();
				
				lblFromPosition.Text = cmd.Parameters["from_position_"].Value.ToString();
				lblFromName.Text = cmd.Parameters["from_name_"].Value.ToString();

				lblToPosition.Text = cmd.Parameters["to_position_"].Value.ToString();
				lblToName.Text = cmd.Parameters["to_name_"].Value.ToString();

				chklstEmailTo.Items.Clear();
				if (cmd.Parameters["sprvsr_employee_number_"].Value != null)
					AddItemToSelection("Supervisor",cmd.Parameters["sprvsr_employee_number_"].Value.ToString(),cmd.Parameters["sprvsr_name_"].Value.ToString());
				if (cmd.Parameters["payor_employee_number_"].Value != null)
					AddItemToSelection("Administrator",cmd.Parameters["payor_employee_number_"].Value.ToString(),cmd.Parameters["payor_name_"].Value.ToString());
				if (cmd.Parameters["applicant_employee_number_"].Value != null)
					AddItemToSelection("Applicant",cmd.Parameters["applicant_employee_number_"].Value.ToString(),cmd.Parameters["applicant_name_"].Value.ToString());
			}						
			finally
			{
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			}
		}

		private void lnkbtnCancel_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>window.close()</script>";
		}

		private void SaveOne(Oracle.DataAccess.Client.OracleConnection conn, string strEmployeeNumber)
		{
			

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.add_Communication_memo",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;					
			Oracle.DataAccess.Client.OracleParameter parm=null;
			try
			{
				int intFileLen = txtMemo.Text.Length;	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"rqst_header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_employee_number_","number","in",ViewState["Loged_Employee_Number"]);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_employee_number_","number","in",strEmployeeNumber);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"subject_","varchar2","in",txtSubject.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"memo_body_","varchar2","in",txtMemo.Text);
//				parm = new Oracle.DataAccess.Client.OracleParameter(
//					"memo_body_",Oracle.DataAccess.Client.OracleDbType.Clob,intFileLen,System.Data.ParameterDirection.Input,true,
//					((System.Byte)(0)),((System.Byte)(0)),"",System.Data.DataRowVersion.Current,txtMemo.Text);
//				cmd.Parameters.Add(parm);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"add_user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"send_email","number","in",1);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				cmd.ExecuteNonQuery();				
			}
			
			finally
			{
				if (parm!=null)
					parm = null;
				cmd.Dispose();
				
			}			
		}

		private bool DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			conn.Open();
			Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
			bool blnOk = true;
			try
			{
				for (int i=0;i<chklstEmailTo.Items.Count;i++)
					if (chklstEmailTo.Items[i].Selected)
						SaveOne(conn,chklstEmailTo.Items[i].Value);
				txn.Commit();
			}
			catch
			{
				txn.Rollback();
				blnOk = false;				
				throw;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
			return blnOk;
		}

		private bool AtLeastOneChecked()
		{
			bool blnCheck = false;
			for (int i=0;i<chklstEmailTo.Items.Count;i++)
				if (chklstEmailTo.Items[i].Selected)
				{
					blnCheck = true;
					break;
				}
			return blnCheck;
		}
		private void lnbtnSave_Click(object sender, System.EventArgs e)
		{
			if (!PasswordOK())
			{
				lblPassordError.Text = "Incorrect password";
				return;
			}
			if (!AtLeastOneChecked())
			{
				ShowError("You must select at least one recipient");
				return;
			}
			if (DoSave())
				lblScript.Text = "<script>opener.window.location.href='Communication.aspx?w="+Request.Params["w"]+"';window.close()</script>";
		}

		private void chklstEmailTo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			chklstEmailTo.Enabled = false;
			txtSubject.Enabled = false;
			txtMemo.Enabled = false;
			txtPassword.Enabled = false;
			lnbtnSave.Enabled = false;
		}

	


	




	}
}
