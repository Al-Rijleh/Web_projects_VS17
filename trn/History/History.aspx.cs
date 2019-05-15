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
using System.Text;

namespace History
{
	/// <summary>
	/// Summary description for History.
	/// </summary>
	public class History : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label lblCourseName;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgHistory;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.HyperLink hlBack;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblTo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblSent;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.Panel pnlViewer;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doShow;

        private string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		private void Page_Load(object sender, System.EventArgs e)
		{
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
				
			if (!IsPostBack)
			{	
				ViewState["Employee_Number"]=UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",ConnectionString);
				SetHeaderInformation();	
				ViewState["Show_Email_ID"]="";
				ViewState["Show_Msg_ID"]="";
				if ((Request.Params["email_id"]!=null)&&(Request.Params["email_id"]!=""))
				{
					pnlViewer.Visible=true;
					ShowEmail(Request.Params["email_id"]);
					ViewState["Show_Email_ID"]=Request.Params["email_id"];
				}
				if ((Request.Params["msg_id"]!=null)&&(Request.Params["msg_id"]!=""))
				{
					pnlViewer.Visible=true;
					ShowCommunication(Request.Params["msg_id"]);
					ViewState["Show_Msg_ID"]=Request.Params["msg_id"];
				}
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Applicant_Employee_Number", "");
				
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
			this.dgHistory.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgHistory_ItemCreated);
			this.dgHistory.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgHistory_ItemDataBound);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			if (ViewState["Product_Code"].ToString()=="11001")
			{
				lblCourseTitle.Text ="Career Development Plan";
				lblCourseName.Text = "Application For:";
				string parPtemplate = SetFullHeader(Page,ViewState["Employee_Number"].ToString());
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
			}
			else
			{
				
				lblCourseTitle.Text = CourseName(ViewState["Request_Record_ID"].ToString());
				string parPtemplate = SetFullHeader(Page,ViewState["Employee_Number"].ToString());
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
			}
			ViewState["Account_Number"]=GetAccountNumber(ViewState["Employee_Number"].ToString());
		}

		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			string strProcedureName = "BASDBA.pkg_training.History_List";
			if (ViewState["Product_Code"].ToString()=="11001")
				strProcedureName = "BASDBA.pkg_training_cdp.History_List";
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());		
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "hstList_","cursor","out","");

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

		private void SetSelectedIndex(DataTable tbl)
		{
			
			if (tbl == null)
				return;
			int intIndex = -1;
			bool emailCheck;
			bool msgCheck;
			foreach (DataRow dr in tbl.Rows)
			{
				intIndex++;
				emailCheck = false;
				if (ViewState["Show_Email_ID"]!=null)
				{
					emailCheck = ViewState["Show_Email_ID"].ToString()==dr["ee_email_record_id"].ToString();
					emailCheck = emailCheck && (ViewState["Show_Email_ID"].ToString()!="");
					if (!emailCheck)
					{
						emailCheck = ViewState["Show_Email_ID"].ToString()==dr["assignee_email_record_id"].ToString();
						emailCheck = emailCheck && (ViewState["Show_Email_ID"].ToString()!="");
					}
				}
				msgCheck = false;
				if (ViewState["Show_Msg_ID"]!=null)
				{
					msgCheck = ViewState["Show_Msg_ID"].ToString()==dr["message_record_id"].ToString();
					msgCheck = msgCheck && (ViewState["Show_Msg_ID"].ToString()!="");
				}

				if (emailCheck||msgCheck)
				{
					dgHistory.SelectedIndex = intIndex;
					break;
				}
			}
			
		}

		private void DrawGrid()
		{
			DataTable dt = GetGridTable();
			if (dt.Rows.Count==0)
			{
				lblError.Text = "There are no history records for this request.";
			}
			else
			{
				dgHistory.DataSource=dt;
				dgHistory.DataBind();
				SetSelectedIndex(dt);				
			}
		}

		private void dgHistory_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgHistory.DataSource;				
					string strRecordId = tbl.Rows[indx]["record_id"].ToString();

					string CreatedBy = "";
					if (tbl.Rows[indx]["Created_By"].ToString().Trim()==",")
						CreatedBy = tbl.Rows[indx]["user_id"].ToString();
					else
						CreatedBy = tbl.Rows[indx]["Created_By"].ToString();

					string ee_email = BASUSA.MiscTidBit.href(tbl.Rows[indx]["ee_subject"].ToString(),"Javascript: ShowEmail("+tbl.Rows[indx]["ee_email_record_id"].ToString()+")");
					string as_email = BASUSA.MiscTidBit.href(tbl.Rows[indx]["assg_subject"].ToString(),"Javascript: ShowEmail("+tbl.Rows[indx]["assignee_email_record_id"].ToString()+")");
					string msg = BASUSA.MiscTidBit.href(tbl.Rows[indx]["msg_subject"].ToString(),"Javascript: ShowMsg("+tbl.Rows[indx]["message_record_id"].ToString()+")");

					StringBuilder sb = new StringBuilder();
					sb.Append("<table border='0' cellspacing='0' cellpadding='0'>");
					sb.Append("<tr vAlign='top'>");
					sb.Append("<td width=150><span class='fontsmall'>Created By</td>");
					sb.Append("<td><span class='fontsmall'>"+CreatedBy+"</td>");
					sb.Append("</tr>");
					sb.Append("<tr vAlign='top'>");
					sb.Append("<td><span class='fontsmall'>Created On</span></td>");
					sb.Append("<td><span class='fontsmall'>"+tbl.Rows[indx]["Created_on"].ToString()+"</span></td>");
					sb.Append("</tr>");
					sb.Append("<tr vAlign='top'><td><span class='fontsmall'>Status Changed To</span></td>");
					sb.Append("<td><span class='fontsmall'>"+tbl.Rows[indx]["Status_Changed_To"].ToString()+"</span></td>");
					sb.Append("</tr><tr vAlign='top'><td><span class='fontsmall'>E-Mail Sent to Employee</span></td>");
					sb.Append("<td><span class='fontsmall'>"+ee_email+"</span></td>");
					sb.Append("</tr><tr vAlign='top'><td><span class='fontsmall'>E-Mail Sent to Supervisor</span></td>");
					sb.Append("<td><span class='fontsmall'>"+as_email+"</span></td>");
					sb.Append("</tr><tr vAlign='top'><td><span class='fontsmall'>Communication Message</span></td>");
					sb.Append("<td><span class='fontsmall'>"+msg+"</span></td></tr></table>");
					Label lblAll=new Label();
					lblAll.ID = "lblAll_"+strRecordId;
					lblAll.Text = sb.ToString();
					
					TableCell CellAll = e.Item.Cells[0];
					CellAll.Controls.Add(lblAll);

				}
				catch{}
			}
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Retuen_To",ConnectionString));
		}

		private void ShowEmail(string email_id)
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.email_record",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "email_record_id_",email_id);		
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "email_rec_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				lblSubject.Text = tbl.Rows[0][0].ToString();
				lblMemo.Text = tbl.Rows[0][1].ToString();
				lblTo.Text = tbl.Rows[0]["to_list"].ToString();				
				lblSent.Text = tbl.Rows[0]["sent_on"].ToString();
				

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

		private void ShowCommunication(string msg_id)
		{
			string strProcedureName = "BASDBA.pkg_training.Comm_record";
			if (ViewState["Product_Code"].ToString() == "11001")
				strProcedureName = "BASDBA.pkg_training_cdp.Comm_record";
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "comm_record_id_",msg_id);		
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "comm_rec_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				lblSubject.Text = tbl.Rows[0][0].ToString();
				lblMemo.Text = tbl.Rows[0][1].ToString();

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

		private void dgHistory_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				string strRecord_id = "";
				if ((Request.Params["email_id"]!=null)&&(Request.Params["email_id"]!=""))
					strRecord_id = (Request.Params["email_id"]);
				if ((Request.Params["msg_id"]!=null)&&(Request.Params["msg_id"]!=""))
					strRecord_id=(Request.Params["msg_id"]);
				DataTable dt = (DataTable)dgHistory.DataSource;
				if (dt.Rows[e.Item.ItemIndex]["record_id"].ToString()==strRecord_id)
					e.Item.Cells[e.Item.ItemIndex].BackColor = System.Drawing.Color.Gold;						
			}
			catch {}
		}

		private string UsedEmployeeNumber2(string strDefaulrEmployeeNumber,string strSessionID)
		{
			string strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID,"TRN_EMPLOYEE_NUMBER",ConnectionString);
			if (strEmployeeNumber=="")
				return strDefaulrEmployeeNumber;
			else
				return strEmployeeNumber;
		}

		private string SetFullHeader(Page wpage,string strEmployee_number)
		{
				SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"HPA","PLA",ConnectionString);
			string setPTemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/header.aspx?callingurl="+wpage.Request.Path+"','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			return setPTemplate;
		}

		private  string CourseName(string record_id)
		{
			return SQLStatic.SQL.ExecScaler("select PKG_Training.CourseCodeTitle("+record_id+") from dual",
				ConnectionString).ToString();
		}	

		private string GetAccountNumber(string employee_number)
		{
			string strAccountNumber="";
			try
			{
				strAccountNumber=SQLStatic.SQL.ExecScaler(" select pkg_employee.ee_account_number("+employee_number+") from dual",ConnectionString).ToString();
			}
			catch
			{
				return "";
			}
			return strAccountNumber;
		}

		

	}
}
