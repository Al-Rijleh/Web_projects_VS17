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
	/// Summary description for Communication.
	/// </summary>
	public class Communication : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgComm;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Panel pnlView;
		protected System.Web.UI.WebControls.Panel pnlReply;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblPassordError;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtMemo;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.CheckBoxList chklstEmailTo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblReplayFrom;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblToName;
		protected System.Web.UI.WebControls.Label lblToPosition;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblFromName;
		protected System.Web.UI.WebControls.Label lblFromPosition;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnReply;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblPassordError2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label req8;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblError.Text = "";
			lblScript.Text = "";
			#region BasTemplate
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
			lblPassordError.Visible = false;
			lblPassordError2.Visible = false;	
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
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",Training_Source.TrainingClass.ConnectioString);
				ViewState["Loged_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_Employee_Number",Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();					
			}
			DrawGrid();
			
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
			this.dgComm.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgCommunucation_ItemCreated);
			this.btnBack.Click += new System.EventHandler(this.Button1_Click);
			this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());				
			string parPtemplate = Training_Source.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}
	
		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.CommunicationList",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",-1);			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "msg_list","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
			}
			return tbl;
		}
		private void DrawGrid()
		{			
			DataTable dt = GetGridTable();
			if (dt.Rows.Count==0)
			{
				lblError.Text = "There are no messages for this request.";
			}
			else
			{
				dgComm.DataSource=dt;
				dgComm.DataBind();
				if (ViewState["New_Comm_ID"]!=null)
				{
					dgComm.SelectedIndex=0;
					DoMenu(ViewState["New_Comm_ID"].ToString());
				}
				ViewState["New_Comm_ID"]=null;
				
			}
		}

		private void dgCommunucation_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgComm.DataSource;
					string strRecordId = tbl.Rows[indx]["record_id"].ToString();	
					
					LinkButton lnk=new LinkButton();
					lnk.ID="lnk_"+strRecordId;
					lnk.Text="<B>"+tbl.Rows[indx]["subject"].ToString()+"</B>";
					lnk.CssClass = "fontsmall";
					lnk.Click += new System.EventHandler(this.lnkMenu_Click);

					Label lbl = new Label();
					lbl.ID = "lbl_"+strRecordId;
					lbl.Text = "<BR>From: " +tbl.Rows[indx]["from_person"].ToString()+
						"<BR>To: " +tbl.Rows[indx]["To_person"].ToString()+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+tbl.Rows[indx]["Add_Date_Time"].ToString();
					lbl.Font.Size = System.Web.UI.WebControls.FontUnit.XXSmall;
					

					TableCell cell = e.Item.Cells[0];
					cell.Controls.Add(lnk);
					cell.Controls.Add(lbl);
				}
				catch{}
			}
		}

		private void DoMenu(string strIndex)
		{
			DataTable tbl = (DataTable) dgComm.DataSource;			
			int intGridIndex=0;
			foreach (DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString()==strIndex)
				{
					txtMessage.Text = dr["memo_body"].ToString();
					ViewState["from_employee_number"]=dr["from_employee_number"].ToString();
					ViewState["to_employee_number"]=dr["to_employee_number"].ToString();
					ViewState["comm_record_id"]=strIndex;
					break;
				}
				intGridIndex ++;
			}
			dgComm.SelectedIndex = intGridIndex;
			btnReply.Enabled=true;
		}

		private void lnkMenu_Click(object sender, System.EventArgs e)
		{
			string strIndex = ((LinkButton)sender).ID.Substring(4);
			DoMenu(strIndex);
//			DataTable tbl = (DataTable) dgComm.DataSource;			
//			int intGridIndex=0;
//			foreach (DataRow dr in tbl.Rows)
//			{
//				if (dr["record_id"].ToString()==strIndex)
//				{
//					txtMessage.Text = dr["memo_body"].ToString();
//					ViewState["from_employee_number"]=dr["from_employee_number"].ToString();
//					ViewState["to_employee_number"]=dr["to_employee_number"].ToString();
//					ViewState["comm_record_id"]=strIndex;
//					break;
//				}
//				intGridIndex ++;
//			}
//			dgComm.SelectedIndex = intGridIndex;
//			btnReply.Enabled=true;
		}

		

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["w"].ToUpper().IndexOf(".ASPX")==-1)
				Response.Redirect(Request.Params["w"]+".aspx");
			else
				Response.Redirect(Request.Params["w"]);
		}

		private void btnReply_Click(object sender, System.EventArgs e)
		{
			pnlView.Visible=false;
			pnlReply.Visible=true;
			SetSubject();
			GetInvolvedEmployeesData();
		}

		//-----------------------------------SendMessage


		private void AddItemToSelection(string strPosition, string strEmployeeNumbe, string strName)
		{
			if (strEmployeeNumbe=="")
				return;
			ListItem li = new ListItem(strPosition+" - "+strName,strEmployeeNumbe);
			li.Selected = true;
			chklstEmailTo.Items.Add(li);
		}

		private void SetSubject()
		{
			string strSQL="select pkg_training.emailSubject("+ViewState["comm_record_id"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
			if (ob != null)
				if (ob.ToString().IndexOf("RE:")==-1)
					txtSubject.Text = "RE: "+ob.ToString();
				else
					txtSubject.Text = ob.ToString();
			ob = null;
		}

		private void GetInvolvedEmployeesData()
		{
			txtMemo.Text="";
			lblReplayFrom.Text = Training_Source.TrainingClass.Employee_Name(ViewState["Employee_Number"].ToString());
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("basdba.PKG_Training.Get_Possible_CommEEs",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;		
			conn.Open();
			try
			{
				int intFileLen = txtMemo.Text.Length;	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Communication_record_id_","number","in",ViewState["comm_record_id"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_employee_number_","number","in",ViewState["Employee_Number"].ToString());
				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"sprvsr_employee_number_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"sprvsr_name_","varchar2","out","",100);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"payor_employee_number_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"payor_name_","varchar2","out","",100);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"applicant_employee_number_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"applicant_name_","varchar2","out","",100);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_employee_number_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_name_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"from_position_","varchar2","out","",100);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_employee_number_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_name_","varchar2","out","",100);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"to_position_","varchar2","out","",100);

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
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"add_user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"send_email","number","in",1);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				cmd.ExecuteNonQuery();		
				ViewState["New_Comm_ID"]=cmd.Parameters["new_record_id_"].Value.ToString();
			}
			
			finally
			{
				if (parm!=null)
					parm = null;
				cmd.Dispose();
				
			}			
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			pnlView.Visible=true;
			pnlReply.Visible=false;
		}

		private bool PasswordOK()
		{
			string strSQL="select pkg_sessions_data.validate_password('"+Request.Cookies["Session_ID"].Value.ToString()+"','"+txtPassword.Text.Replace("'","''")+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString()=="1";
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

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!PasswordOK())
			{
				lblPassordError.Visible = true;
				lblPassordError2.Visible = true;
				return;
			}
			if (!AtLeastOneChecked())
			{
				string strError="<script>alert('You must select at least one recipient')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"strError",strError);
				return;
			}
			if (DoSave())
			{
				pnlView.Visible=true;
				pnlReply.Visible=false;				
				DrawGrid();
			}
		}

		

		

	}
}
