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
	/// Summary description for SearchEmployee.
	/// </summary>
	public class SearchEmployee : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSearch;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.DataGrid dgEEs;
		protected System.Web.UI.WebControls.LinkButton lmkbtnCancel;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Label lblHeading;
		protected System.Web.UI.WebControls.Label lblCourceName;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo;
	
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
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				if (ViewState["Applicant_Employee_Number"].ToString()=="")
					ViewState["Applicant_Employee_Number"]=ViewState["Employee_Number"].ToString();
				if (Request.Params["Inst"] != "4")
					lblBalance.Text = PLA_Approval.TrainingClass.AvailableAmount(ViewState["Applicant_Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				
				ViewState["List_Type"]="0";
				if (Request.Params["Inst"] != null)
				{
					if (Request.Params["Inst"] == "1")
					{
						lblInstruction.Text ="Type in your supervisor’s name in the search field below to find your supervisor’s "
							+"email address and to make your supervisor assignment.  Type your supervisors’ name "
							+"in the order Last Name, First Name (i.e., Smith, Jane).  The more you type, the more accurate the "
							+"search results (capitalization does not affect the search results).";
						lblTitle.Text = "Select a Supervisor";
						lblHeading.Text ="Find a supervisor (last, first):";
						ViewState["List_Type"]="1";
					}
					if (Request.Params["Inst"] == "2")
					{
						lblInstruction.Text ="To route the training request to another supervisor, type the supervisor’s name in "
							+"the search field below to find and select a different supervisor.  Type the "
							+"supervisor’s name in the order Last Name, First Name (i.e., Smith, Jane).  The "
							+"more you type, the more accurate the search results (capitalization does not affect the search results)."
							+" <font color=\"#FF0000\">Please note once you change the supervisor you will not be able to see this application</font>";
						lblTitle.Text = "Select a Supervisor";
						lblHeading.Text ="Route to a Supervisor Search:";
						ViewState["List_Type"]="1";
					}
					if (Request.Params["Inst"] == "3")
					{
						lblInstruction.Text ="To route the training request to another administrator, type the administrator’s "
							+"name in the search field below to find and select a different administrator.  Type the "
							+"administrator’s name in the order Last Name, First Name (i.e., Smith, Jane).  The more you "
							+"type, the more accurate the search results (capitalization does not affect the search results)."
							+" <font color=\"#FF0000\">Please note once you change the administrator you will not be able to see this application</font>";;						
						lblHeading.Text ="Route to an Administrator Search:";
						ViewState["List_Type"]="0";
					}
					if ((Request.Params["Inst"] == "4")||(Request.Params["Inst"] == "7"))
					{
						lblInstruction.Text ="To select an employee, type the employee’s "
							+"name in the search field below. Type the "
							+"employee’s name in the order Last Name, First Name (i.e., Smith, Jane).  The more you "
							+"type, the more accurate the search results (capitalization does not affect the search results).";						
						lblHeading.Text ="Employee Search:";
						ViewState["List_Type"]="4";
					}
					if (Request.Params["Inst"] == "5")
					{
						lblInstruction.Text ="To select a supervisor, type the supervisor’s "
							+"name in the search field below. Type the "
							+"supervisor’s name in the order Last Name, First Name (i.e., Smith, Jane).  The more you "
							+"type, the more accurate the search results (capitalization does not affect the search results).";						
						lblHeading.Text ="Supervisor Search:";
						ViewState["List_Type"]="5";
					}
					if (Request.Params["Inst"] == "6")
					{
						lblInstruction.Text ="To select an administrator, type the administrator’s "
							+"name in the search field below. Type the "
							+"administrator’s name in the order Last Name, First Name (i.e., Smith, Jane).  The more you "
							+"type, the more accurate the search results (capitalization does not affect the search results).";						
						lblHeading.Text ="Administrator Search:";
						ViewState["List_Type"]="6";
					}
					if (Request.Params["Inst"] == "8")
					{
						lblInstruction.Text ="To route Career Development Plan to another supervisor, type the supervisor’s name in "
							+"the search field below to find and select a different supervisor.  Type the "
							+"supervisor’s name in the order Last Name, First Name (i.e., Smith, Jane).  The "
							+"more you type, the more accurate the search results (capitalization does not affect the search results).";
						lblTitle.Text = "Select a Supervisor";
						lblHeading.Text ="Route to a Supervisor Search:";
						ViewState["List_Type"]="1";
					}					
				}				
				SetHeaderInformation();	
				if (Request.Params["start"]!=null)
				{
					if (Request.Params["start"].Trim()!="")
					{
						DrawGrid();
						txtSearch.Text = Request.Params["start"];
						lnkbtnGo_Click(null,null);
						return;
					}
				}
				
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
			this.lnkbtnGo.Click += new System.EventHandler(this.lnkbtnGo_Click);
			this.dgEEs.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgEEs_ItemCreated);
			this.lmkbtnCancel.Click += new System.EventHandler(this.lmkbtnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			DataTable tbl=null;
			try
			{
				if (ViewState["Product_Code"].ToString() == "11001")
				{
					lblCourseTitle.Text="Career Development Plan";
					lblCourceName.Text ="Application For";
				}
				else if ((Request.Params["Inst"] != "4") && (Request.Params["Inst"] != "5")&& 
					     (Request.Params["Inst"] != "6"))
					lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
				ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Applicant_Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
//				lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
		}

		private DataTable GetTable()
		{
			DataTable tbl=null;
			if ((Request.Params["Inst"] == "4")||(Request.Params["Inst"] == "6")||(Request.Params["Inst"] == "7"))
			{
				return GetTable2();
			}
			if (Request.Params["Inst"] == "5")
			{
				return GetTable3();
			}
			string strProcedureName = "BASDBA.PKG_Training.employee_Number_List";
			if (ViewState["Product_Code"].ToString() == "11001")
				strProcedureName = "BASDBA.PKG_Training_cdp.employee_Number_List";
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_type_",ViewState["List_Type"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "search_name_",txtSearch.Text.Replace("'","''"));
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "emails_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				RemoveSupervisor(tbl);
				if (ViewState["List_Type"].ToString()!="0") 
					CleanUpTable(tbl);
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
		
		private DataTable GetTable2()
		{
			DataTable tbl=null;
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.employee_Number_List2",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Employee_Number"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "search_name_",txtSearch.Text.Replace("'","''"));
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "emails_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];	
				RemoveSupervisor(tbl);
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

		private DataTable GetTable3()
		{
			DataTable tbl=null;
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.employee_Number_List3",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Employee_Number"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "search_name_",txtSearch.Text.Replace("'","''"));
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "emails_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];	
				RemoveSupervisor(tbl);
				CleanUpTable(tbl);
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

		private string SkippedClasses()
		{
			object ob=SQLStatic.SQL.ExecScaler("select pkg_training.skipedclasses('"+ViewState["Account_Number"]+"') from dual",PLA_Approval.TrainingClass.ConnectionString);
			if (ob != null)
				return ob.ToString();
			else
				return null;
		}

		private void RemoveSupervisor(DataTable tbl)
		{
			if ((Request.Params["Inst"] == "1")||(Request.Params["Inst"] == "2")||(Request.Params["Inst"] == "5"))
			{
				for (int i=tbl.Rows.Count-1;i>=0;i--)
				{
					if (tbl.Rows[i]["employee_number"].ToString()== ViewState["Employee_Number"].ToString())
						tbl.Rows[i].Delete();
				}
				tbl.AcceptChanges();
			}
		}

		private void CleanUpTable(DataTable tbl)
		{
			string strSkippedClasses = SkippedClasses();
			string strClassCode;
			for (int i=tbl.Rows.Count-1;i>=0;i--)
			{
				strClassCode = "<"+tbl.Rows[i]["class_code"].ToString()+">";
				if (strSkippedClasses.IndexOf(strClassCode)!=-1)
					tbl.Rows[i].Delete();
			}
			for (int i=tbl.Rows.Count-1;i>9;i--)
				tbl.Rows[i].Delete();
		}

		private void DrawGrid()
		{
			DataTable tbl = GetTable();

			
			dgEEs.DataSource = tbl;
			dgEEs.DataBind();
		}

		private void lnkbtnGo_Click(object sender, System.EventArgs e)
		{
			DrawGrid();
		}

		private void dgEEs_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				int indx = e.Item.ItemIndex;
				DataTable tbl = (DataTable) dgEEs.DataSource;				
//				DataView dv =tbl.DefaultView;
//				dv.Sort = "name";
				try
				{
					
					string strEmployee_Number = tbl.Rows[indx]["employee_number"].ToString();						
					
					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="smallsize";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(120);
					ddl.ID = "ddl_"+strEmployee_Number;					
					ListItem li = new ListItem("Select","0");						
					ddl.Items.Add(li);						
																
					// create button
					Button btn2 = new Button();
					btn2.CssClass = "actbtn_go_next_button";
					btn2.ID="btn_"+strEmployee_Number;
					btn2.Text = "Go";				
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[2];						
					cell.Controls.Add(ddl);
					cell.Controls.Add(btn2);

					LinkButton lnk1 = new LinkButton();
					lnk1.ID = "lnk1_"+strEmployee_Number;
					lnk1.CssClass = "smallsize";
					lnk1.Text = tbl.Rows[indx]["name"].ToString();
					lnk1.Click += new System.EventHandler(this.lnkMenu_Click);
					TableCell cell1 = e.Item.Cells[0];						
					cell1.Controls.Add(lnk1);

					LinkButton lnk2 = new LinkButton();
					lnk2.ID = "lnk2_"+strEmployee_Number;
					lnk2.CssClass = "smallsize";
					lnk2.Text = tbl.Rows[indx]["email_number"].ToString();
					lnk2.Click += new System.EventHandler(this.lnkMenu_Click);
					TableCell cell2 = e.Item.Cells[1];						
					cell2.Controls.Add(lnk2);						
				}
				catch
				{
				}
			}
		}

//		private void dgEEs_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
//		{
//			
//			if ((e.Item.ItemType==ListItemType.Item)||
//				(e.Item.ItemType==ListItemType.AlternatingItem)||
//				(e.Item.ItemType==ListItemType.SelectedItem))
//			{
//				try
//				{
//					int indx = e.Item.ItemIndex;
//					DataTable tbl = (DataTable) dgEEs.DataSource;
//					DataView dv = tbl.DefaultView;
//					dv.Sort="email_number";
//					string strEmployee_Number = dv[0].ToString();						
//					
//					// create drop down
//					DropDownList ddl = new DropDownList();
//					ddl.CssClass="smallsize";
//					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(120);
//					ddl.ID = "ddl_"+strEmployee_Number;					
//					ListItem li = new ListItem("Select","0");						
//					ddl.Items.Add(li);						
//																
//					// create button
//					Button btn2 = new Button();
//					btn2.CssClass = "actbtn_go_next_button";
//					btn2.ID="btn_"+strEmployee_Number;
//					btn2.Text = "Go";				
//					btn2.Click += new System.EventHandler(this.btnMenu_Click);
//					TableCell cell = e.Item.Cells[2];						
//					cell.Controls.Add(ddl);
//					cell.Controls.Add(btn2);
//
//					LinkButton lnk1 = new LinkButton();
//					lnk1.ID = "lnk1_"+strEmployee_Number;
//					lnk1.CssClass = "smallsize";
//					lnk1.Text = dv[1].ToString();
//					lnk1.Click += new System.EventHandler(this.lnkMenu_Click);
//					TableCell cell1 = e.Item.Cells[0];						
//					cell1.Controls.Add(lnk1);
//
//					LinkButton lnk2 = new LinkButton();
//					lnk2.ID = "lnk2_"+strEmployee_Number;
//					lnk2.CssClass = "smallsize";
//					lnk2.Text = dv[2].ToString();
//					lnk2.Click += new System.EventHandler(this.lnkMenu_Click);
//					TableCell cell2 = e.Item.Cells[1];						
//					cell2.Controls.Add(lnk2);						
//				}
//				catch
//				{
//				}
//			}
//		}

		private void ProcessClick(string strEmployee_Number)
		{
			DataTable dt=(DataTable) dgEEs.DataSource;
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["employee_number"].ToString()==strEmployee_Number)
				{
					if ((Request.Params["Inst"] == "5")||(Request.Params["Inst"] == "6"))
					{
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_Found_Employee_Number",dr["employee_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_Found_Name",dr["name"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_Found_Email",dr["email_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					}
					else if (Request.Params["Inst"] == "7")
					{
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Number",dr["employee_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Name",dr["name"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_2nd_Line_Supervisor_Email",dr["email_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					}
					else
					{
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number",dr["employee_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Name",dr["name"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Email",dr["email_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					}
					break;
				}
			}
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			ProcessClick(((Button)sender).ID.Substring(4));	
			string strURL = "SupervisorApprove.aspx?SkipCheck=YES";
			if (Request.Params["returl"] != null)
				strURL = Request.Params["returl"];
			strURL = BASUSA.MiscTidBit.CheckForSkipCheck(strURL);
			lblScript.Text="<script>opener.window.location.href='"+strURL+"';window.close()</script>";
		}

		private void lnkMenu_Click(object sender, System.EventArgs e)
		{
			ProcessClick(((LinkButton)sender).ID.Substring(5));	
			string strURL = "SupervisorApprove.aspx?SkipCheck=YES";
			if (Request.Params["returl"]!=null)
				strURL = Request.Params["returl"];
			strURL = BASUSA.MiscTidBit.CheckForSkipCheck(strURL);
			lblScript.Text="<script>opener.window.location.href='"+strURL+"';window.close()</script>";
		}

		private void btnlink_Click(object sender, System.EventArgs e)
		{
			string strEmployee_Number = ((Button)sender).ID.Substring(4);			
		}

		private void lmkbtnCancel_Click(object sender, System.EventArgs e)
		{
			lblScript.Text="<script>window.close()</script>";
		}

		
		
	}
}
