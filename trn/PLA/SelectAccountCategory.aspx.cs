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

namespace Training_Source
{
	/// <summary>
	/// Summary description for SelectAccountCategory.
	/// </summary>
	public class SelectAccountCategory : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		//protected System.Web.UI.WebControls.DataGrid dgCat;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblScript;
//		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Label lblWelcomeInstruction;
		protected System.Web.UI.WebControls.Label lblWeclome;
		protected System.Web.UI.WebControls.Label lblHelpForOptionNeedAssessments;
		protected System.Web.UI.WebControls.LinkButton lnkbtnHelpOptionNeedsAssessmsnts;
		protected System.Web.UI.WebControls.LinkButton lnlHelpCreerDevelopmentPlan;
		protected System.Web.UI.WebControls.Label lblHelpForCarrerDevelopmentPlan;
		protected System.Web.UI.WebControls.LinkButton lnkbtnHelpTrainingRequest;
		protected System.Web.UI.WebControls.Label lblHelpFotTrainingRequest;
		protected System.Web.UI.HtmlControls.HtmlTable TableData;
		protected System.Web.UI.WebControls.Button btnReturnToDataPage;
		protected System.Web.UI.WebControls.Label lblHelp;
		protected System.Web.UI.HtmlControls.HtmlTable TableHelp;
		protected System.Web.UI.WebControls.Label lblHelpText;
		protected System.Web.UI.WebControls.HyperLink hlCreerCounselorList;
		protected System.Web.UI.WebControls.Label lblISelectEmployee;
		protected System.Web.UI.HtmlControls.HtmlTable TableSelectEmployee;
		protected System.Web.UI.WebControls.Button btnSelectEmployee;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            //if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
            //    Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text = "";
			#region BasTemplate
			if (!IsPostBack)
			{
                //if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                //{
                //    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES", Training_Source.TrainingClass.ConnectioString);
                //    Response.Redirect("/web_projects/PTemplate/index.htm");
                //    return;
                //}
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{					
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);					
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,false);
					if (strResult.Trim()!="")
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult,false);
						return;
					}
					objBasTemplate.SetSeatchField(0);
					objBasTemplate.ShowNotes = false;	
					if (objBasTemplate.strUser_Group_ID.ToString()=="1")
						objBasTemplate.ShowSelectEmployee=true;
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
					ViewState["Page_ID"]						= objBasTemplate.strPageId;
				
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
                LblTemplateHeader2.Text =
                    LblTemplateHeader2.Text.Replace("/web_projects/Employee_Search/default.aspx?SkipCheck=YES",
                      "/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&pc=11100");
				if ((ViewState["Employee_Number"].ToString() == "") || (ViewState["Employee_Number"].ToString() == "0"))
				{
					Response.Redirect("out.aspx?message=You must select an employee first " , true);
				}
				TableHelp.Visible=false;
				ShowHideSelectEmployee();
				if ((ViewState["User_ID"] == null) ||(ViewState["User_ID"].ToString() == ""))
					Response.Redirect("out.aspx?message= Request and Manage Training failed to connect to the program. You might not have the proper authorization. Please contact MyEnroll.com at "+Training_Source.TrainingClass.HelpPhoneNumber(),true);						
				
				if (ViewState["User_Group_ID"].ToString()!="1")
				{
//					if (ViewState["User_Primary_Role"].ToString() != "100407")
					if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
						if (!Training_Source.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString())) //not super user
							if (!SetEmployeeNumber())
								Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your MyEnroll Employee Number is not defined. Please Contact MyEnroll.com @ "+
									Training_Source.TrainingClass.HelpPhoneNumber(),true);
				}
				
				if (ViewState["Employee_Number"].ToString() == "0")
					Response.Redirect("out.aspx?message=You must select an employee first",true);								  

				if (ViewState["User_Group_ID"].ToString()!="1")
				{
//					if (ViewState["User_Primary_Role"].ToString() != "100407")
					if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
					{
						string strMesg="";
						ViewState["FOUND_EMPLOYEE_NUMBER"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER",Training_Source.TrainingClass.ConnectioString);
                        //if (Training_Source.TrainingClass.IsSuperUser(Request.Cookies["Session_ID"].Value.ToString(),ViewState["User_ID"].ToString(),ViewState["Employee_Number"].ToString()))
                        //  strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["FOUND_EMPLOYEE_NUMBER"].ToString());
                        //else
                        //    strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                        //if (strMesg.Trim()!="")
                        //    Response.Redirect("out.aspx?message="+strMesg,true);
					}
				}	
				string strPLAEmployeeNumber = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"PLA_Employee_Number",Training_Source.TrainingClass.ConnectioString);
				if (strPLAEmployeeNumber != "")
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER",strPLAEmployeeNumber,Training_Source.TrainingClass.ConnectioString);
				string strSelectedEmployeeNumber=Training_Source.TrainingClass.UsedEmployeeNumber(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
				if (strSelectedEmployeeNumber != ViewState["Employee_Number"].ToString())
				{
					ViewState["Employee_Number"] = strSelectedEmployeeNumber;
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_Employee_Number",strSelectedEmployeeNumber,Training_Source.TrainingClass.ConnectioString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"APPLICANT_Employee_Number",strSelectedEmployeeNumber,Training_Source.TrainingClass.ConnectioString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER","",Training_Source.TrainingClass.ConnectioString);
				}
				else
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_Employee_Number",ViewState["Employee_Number"].ToString(),Training_Source.TrainingClass.ConnectioString);
				}
				SetCurrentProcessingYear();
				SetHeaderInformation();		
				if (!ProductCodeNotExists())
					Response.Redirect("out.aspx?message=Your Employer has not selected the Training Product for Processing_Year "+ViewState["Processing_Year"].ToString(),true);	
				ProcessesStarFunctionality();
				CheckBudget();
				ResetCDPStatus();
			}
			DrawGrid();
			HandleContractors();
		}
		private void HandleContractors()
		{
//			string strHome = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"HOME",Training_Source.TrainingClass.ConnectioString).Trim();
//			if (strHome !="")
//			{
//				HyperLink1.NavigateUrl =strHome;
//				return;
//			}										
//			HyperLink1.NavigateUrl = "/scripts/basweb.exe/view?Module=N";
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
			//this.dgCat.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgCat_ItemCreated);
			//this.dgCat.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgCat_ItemDataBound);
			this.btnReturnToDataPage.Click += new System.EventHandler(this.btnReturnToDataPage_Click);
			this.lnkbtnHelpOptionNeedsAssessmsnts.Click += new System.EventHandler(this.lnkbtnHelpOptionNeedsAssessmsnts_Click);
			this.lnlHelpCreerDevelopmentPlan.Click += new System.EventHandler(this.lnlHelpCreerDevelopmentPlan_Click);
			this.lnkbtnHelpTrainingRequest.Click += new System.EventHandler(this.lnkbtnHelpTrainingRequest_Click);
			this.btnSelectEmployee.Click += new System.EventHandler(this.btnSelectEmployee_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ShowHideSelectEmployee()
		{
			if (SQLStatic.SQL.ExecScaler("select pkg_training_2.issuperuser("+ViewState["User_ID"].ToString()+") from dual").ToString() != "0")
				TableSelectEmployee.Visible=true;
			else
				TableSelectEmployee.Visible=false;
		}

		private void CheckBudget()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_trn_budget.update_initial_budjet",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["Employee_Number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_",ViewState["User_Name"].ToString());			
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();				
			}
			catch{}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();				
			}
		}

		private void ResetCDPStatus()
		{
			string strEmployee_Number = ViewState["Employee_Number"].ToString();			
			string strSQL = "select pkg_training_cdp.headerRecordID('"+strEmployee_Number+"')  from dual";
			string cdp_Header_id = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training_cdp.set_application_status",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",cdp_Header_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_",ViewState["User_Name"].ToString());			
			try
			{
				conn.Open();				
				cmd.ExecuteNonQuery();				
			}
			catch{}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();				
			}
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private bool SetEmployeeNumber()
		{
			bool eeFound = true;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training.set_employee_number",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "User_id_",ViewState["User_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Session_id_",Request.Cookies["Session_ID"].Value.ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_","varchar2","out",null,20);
			
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["employee_number_"].Value == null)
					eeFound = false;
				else
					ViewState["Employee_Number"]= cmd.Parameters["employee_number_"].Value.ToString();
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();				
			}
			return eeFound;
		}

		private bool ProductCodeNotExists()
		{
			string strSQL="select pkg_training.accounthasproduct_id("+ViewState["Employee_Number"].ToString()+","+ViewState["Processing_Year"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
			if (ob.ToString()=="0")
				return false;
			else
				return true;
		}

		private void SetCurrentProcessingYear()
		{
			string strSQL="select pkg_training.ee_current_processing_year("+ViewState["Employee_Number"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
			if (ob==null)
				Response.Redirect("out.aspx?message=Current Processing Year is not defined for Employee Number "+ViewState["Employee_Number"].ToString(),true);
			else
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Processing_Year",ob.ToString(),Training_Source.TrainingClass.ConnectioString);
				ViewState["Processing_Year"]=ob.ToString();
				ob = null;
			}
		}

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>popup('error.aspx',200,400)</script>";
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
		//	string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			string setPTemplate = Training_Source.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString()); 
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"setPTemplate",setPTemplate);
		}

		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.getlearningcategories",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["Employee_Number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "learningcategorylist_","cursor","out","");

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
		
		private void ShowNewAdd()
		{
			if (CreateEEAccount())
				Response.Redirect("SelectAccountCategory.aspx");
		}

		private void DrawGrid()
		{
			DataTable dt = GetGridTable();
			//dgCat.DataSource=dt;
			//dgCat.DataBind();
			if (dt.Rows.Count==0)
				ShowNewAdd();
			
		}

//        private void dgCat_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
//        {
//            if ((e.Item.ItemType==ListItemType.Item)||
//                (e.Item.ItemType==ListItemType.AlternatingItem)||
//                (e.Item.ItemType==ListItemType.SelectedItem))
//            {
//                try
//                {
//                    int indx = e.Item.ItemIndex;
//                    DataTable tbl = (DataTable) dgCat.DataSource;
//                    string strCode = tbl.Rows[indx]["product_code"].ToString();	

								
//                    // create drop down
//                    DropDownList ddl = new DropDownList();
//                    ddl.CssClass="fontsmall";
//                    ddl.Width=System.Web.UI.WebControls.Unit.Pixel(120);
//                    ddl.ID = "ddl_"+strCode;					
//                    ListItem li = new ListItem("Select","0");
//                    ddl.Items.Add(li);
////					if ((strCode=="11100")&&
////						Training_Source.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString()))
////					{
////						ListItem li2 = new ListItem("Select Employee","1");
////						ddl.Items.Add(li2);
////					}
//                    if (Training_Source.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString()))
//                    {
//                        ListItem li2 = new ListItem("Select Employee","1");
//                        ddl.Items.Add(li2);
//                    }
//                    // create button
//                    Button btn = new Button();
//                    btn.CssClass = "actbtn_go_next_button";
//                    btn.ID="btn_"+strCode;
//                    btn.Text = "Go";
				
//                    btn.Click += new System.EventHandler(this.btnMenu_Click);
//                    TableCell cell = e.Item.Cells[7];
//                    cell.Controls.Add(ddl);
//                    cell.Controls.Add(btn);
//                }
//                catch{}
//            }
//        }

		public string Set_Wizard_id_for_session(string strCode)
		{
			string session_id=Request.Cookies["Session_ID"].Value.ToString();
			string strResult = "";
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();
			Oracle.DataAccess.Client.OracleConnection conn = 
				new Oracle.DataAccess.Client.OracleConnection(
				Training_Source.TrainingClass.ConnectioString); 
			cmd.Connection = conn;
			cmd.CommandText = "pkg_Training.SetPLAWizardID";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"session_id_",session_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"employee_number_",ViewState["Employee_Number"].ToString() );
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"product_code_",strCode);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out",null);
			// execute the function
			conn.Open();
			try
			{
				cmd.ExecuteNonQuery(); 
				if (cmd.Parameters["error_msg_"].Value==null)
					strResult = "";
				else
					strResult = cmd.Parameters["error_msg_"].Value.ToString();
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			return strResult;
		}

		public string First_step_in_wizard()
		{
			string sessID = Request.Cookies["Session_ID"].Value.ToString();
			string FirststepinWiz = null;
			// create the command for the function
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();
			Oracle.DataAccess.Client.OracleConnection conn = 
				new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString); 
			cmd.Connection = conn;
			cmd.CommandText = "pkg_wizard.First_step_in_wizard";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("session_id_", Oracle.DataAccess.Client.OracleDbType.Varchar2, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, sessID));
			cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("first_step_id_", Oracle.DataAccess.Client.OracleDbType.Double, 0, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("first_step_url_", Oracle.DataAccess.Client.OracleDbType.Varchar2, 0, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// execute the function
			conn.Open();
			cmd.ExecuteNonQuery();
			FirststepinWiz = Convert.ToString(cmd.Parameters[2].Value);
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return FirststepinWiz;
		}

		public string Set_Req_App_Wizard_id_for_session(string strCode)
		{
			string session_id=Request.Cookies["Session_ID"].Value.ToString();
			string strResult = "";
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();
			Oracle.DataAccess.Client.OracleConnection conn = 
				new Oracle.DataAccess.Client.OracleConnection(
				Training_Source.TrainingClass.ConnectioString); 
			cmd.Connection = conn;
			cmd.CommandText = "pkg_Training.SetReqApprWizardID";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"session_id_",session_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"employee_number_",ViewState["Employee_Number"].ToString() );
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"product_code_",strCode);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_msg_","varchar2","out",null);
			// execute the function
			conn.Open();
			try
			{
				cmd.ExecuteNonQuery(); 
				if (cmd.Parameters["error_msg_"].Value==null)
					strResult = "";
				else
					strResult = cmd.Parameters["error_msg_"].Value.ToString();
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			return strResult;
		}

		private bool HasGaolOrPorsition()
		{
			string strSQL = "select pkg_training_cdp.HasGoalsorPosition('"+ViewState["Employee_Number"].ToString()+"',"
				+ViewState["Processing_Year"].ToString()+")  from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString()=="T";
		}

		private void GotoCDP()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"PageStatus","In_Edit",Training_Source.TrainingClass.ConnectioString);
				Response.Redirect("/Web_Projects/trn/FDIC_CDP/Main.aspx");
		}

		private void GotoCDP_SAW()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"PageStatus","In_Edit",Training_Source.TrainingClass.ConnectioString);
			Response.Redirect("/Web_Projects/trn/FDIC_CDP/QsntsAnswrs.aspx");
		}

		private DropDownList GetDropDown(Control oMe,string txtName)
		{
			int cnt = oMe.Controls.Count;
			DropDownList ddl = null;
			for(int i=0; i<cnt; i++)
			{
				string s =oMe.Controls[i].GetType().ToString();				
				if ((oMe.Controls[i].GetType().ToString()==
					"System.Web.UI.WebControls.DropDownList"))
				{					
					ddl =(DropDownList)oMe.Controls[i];					
					if ((ddl.ID == txtName))
					{
						s = ddl.SelectedValue;
						break;
					}
					else
						ddl = null;
				}
				else 
					if (oMe.Controls[i].HasControls())
				{
					ddl = GetDropDown(oMe.Controls[i],txtName);
					if (ddl != null)
						break;
				}
			}
			return ddl;
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string strCode = ((Button)sender).ID.Substring(4);
			DropDownList ddl = GetDropDown(this,"ddl_"+strCode);
			string strCanContnue = CanContinue(strCode);
			if (ddl.SelectedValue == "1")
			{
				string strParamQuery="?returl="+Request.Path+"&inst=4";
				lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
			}
			else
			{
				if (strCode == "11000")
				{
					GotoCDP_SAW();
				}
				if (strCode == "11001")
				{
					GotoCDP();
				}
				else if ((strCanContnue=="")||(strCanContnue.IndexOf("Warning:")!=-1))
				{   
					string strCanContnue2 = Set_Wizard_id_for_session(strCode);
					if (strCanContnue2=="")
					{						
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",strCode,Training_Source.TrainingClass.ConnectioString);
						if (strCanContnue=="")
						{
							SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Mandatory_Only","F",Training_Source.TrainingClass.ConnectioString);
							Response.Redirect("SelectApp.aspx");
						}
						else
						{
							SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Mandatory_Only","T",Training_Source.TrainingClass.ConnectioString);
							lblScript.Text = "<script> mandatoryOnly('"+strCanContnue+"');</script>";
						}
					}
					else
						ShowError(strCanContnue);
				}
				else
					ShowError(strCanContnue);
					
			}
		}

		//private void dgCat_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		//{
		//    try
		//    {		
		//        DataTable tbl = (DataTable) dgCat.DataSource;
				
		//        if (tbl.Rows[e.Item.ItemIndex]["product_code"].ToString()=="11001")
		//        {
		//            e.Item.Cells[4].Text="N/A";
		//            e.Item.Cells[6].Text="N/A";										
		//        }	
		//        if (tbl.Rows[e.Item.ItemIndex]["product_code"].ToString()=="11100")
		//        {
		//            e.Item.Cells[5].Text="N/A";														
		//        }	
		//        if (tbl.Rows[e.Item.ItemIndex]["product_code"].ToString()=="11000")
		//        {
		//            e.Item.Cells[5].Text="N/A";
		//            e.Item.Cells[6].Text="N/A";										
		//        }
		//    }
		//    catch {}
		//}
		
		private string CanContinue(string strProductCode)
		{
			string strSQL= "select pkg_training.CanContinue ("+ViewState["Employee_Number"].ToString()+", "
                        +ViewState["Processing_Year"].ToString()+","+strProductCode+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
			if (ob == null)
				strProductCode = "";
			else
				strProductCode = ob.ToString();
			ob = null;
			return strProductCode;
		}

		private bool CreateEEAccount()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_trn_fdic.add_ee_to_pla",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			bool isOk = true;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"employee_number_","number","in",ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"processing_year_","varchar2","in",ViewState["Processing_Year"].ToString());	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"error_message_","varchar2","out","");
				conn.Open();
				cmd.ExecuteNonQuery();	
				if (cmd.Parameters["error_message_"].Value != null)
				{
					if (cmd.Parameters["error_message_"].Value.ToString().Trim() != "")
					{
						string strErrorMessage = cmd.Parameters["error_message_"].Value.ToString();
						isOk = false;
						Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=" + strErrorMessage + "&backurl=0", true);
						lblTitle.Text = strErrorMessage;
						lblTitle.ForeColor = System.Drawing.Color.Red;
						lblTitle.Font.Bold = true;
					}
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			return isOk;
		}

	

		private void Button1_Click(object sender, System.EventArgs e)
		{
//			Response.Redirect("rptFDICTraining.rpx?OutputFormat=pdf&EmployeeID=118400&PlanYear=2005");
			Response.Redirect("rptFDICTraining.rpx?OutputFormat=pdf&RecordID=22");
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			string strHome = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"HOME",Training_Source.TrainingClass.ConnectioString).Trim();
			if (strHome !="")
			{
				strHome = strHome;
				return;
			}										
//			HyperLink1.NavigateUrl = "/scripts/basweb.exe/view?Module=N";
		
		}

		private void lnkbtnHelpOptionNeedsAssessmsnts_Click(object sender, System.EventArgs e)
		{
			TableHelp.Visible=true;
			TableData.Visible=false;
			lblHelp.Text =  SQLStatic.SQL.ExecScaler("select pkg_system_pages_help.getpagehelp("+ViewState["Page_ID"].ToString()+",0) from dual").ToString();
		}

		private void btnReturnToDataPage_Click(object sender, System.EventArgs e)
		{
			TableHelp.Visible=false;
			TableData.Visible=true;
		}

		private void lnlHelpCreerDevelopmentPlan_Click(object sender, System.EventArgs e)
		{
			TableHelp.Visible=true;
			TableData.Visible=false;
			lblHelp.Text =  SQLStatic.SQL.ExecScaler("select pkg_system_pages_help.getpagehelp("+ViewState["Page_ID"].ToString()+",1) from dual").ToString();
		}

		private void lnkbtnHelpTrainingRequest_Click(object sender, System.EventArgs e)
		{
			TableHelp.Visible=true;
			TableData.Visible=false;
			lblHelp.Text =  SQLStatic.SQL.ExecScaler("select pkg_system_pages_help.getpagehelp("+ViewState["Page_ID"].ToString()+",2) from dual").ToString();
		}

		private void btnSelectEmployee_Click(object sender, System.EventArgs e)
		{
			string strParamQuery="&returl="+Request.Path+"?SkipCheck=YES&start=A";
			Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y"+strParamQuery);
		}

		protected void lnkbtnHelpOptionNeedsAssessmsnts_Click1(object sender, EventArgs e)
		{
			Response.Redirect("/web_projects/trn/CDP2008/PrivacyStatementQuestion.aspx");
		}

		protected void lnlHelpCreerDevelopmentPlan_Click1(object sender, EventArgs e)
		{
			Response.Redirect("/web_projects/trn/CDP2008/PrivacyStatementMain.aspx");
		}

		protected void lnkbtnHelpTrainingRequest_Click1(object sender, EventArgs e)
		{
			Response.Redirect("/Web_Projects/trn/PLA/PrivacyStatementTraining.aspx");
		}

	}
}
