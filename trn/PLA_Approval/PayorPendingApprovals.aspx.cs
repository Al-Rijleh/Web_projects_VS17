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
	/// Summary description for PayorPendingApprovals.
	/// </summary>
	public class PayorPendingApprovals : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblProcessing_Year;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlWhat;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo;
		protected System.Web.UI.WebControls.DataGrid dgPending;
		protected System.Web.UI.WebControls.Label lbl_fldPLAPayorPendingApproval;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSelectEmployee;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSystemAdministrator;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
        protected System.Web.UI.WebControls.HiddenField hidReroute;
	
		bool inReadOnly=false;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				string strURL = "/Web_Projects/trn/PLA_Approval/PayorPendingApprovals.aspx";
				string strSetLeftMenu =
					"<script>window.open('/web_projects/ptemplate/left.aspx?callingurl=" + strURL + "','MyEnroll_available_programs_listing_menu_frame')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"strSetLeftMenu", strSetLeftMenu);
			}
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblError.Text = "";
			#region BasTemplate
			if (!IsPostBack)
			{
                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES", PLA_Approval.TrainingClass.ConnectionString);
                    Response.Redirect("/web_projects/PTemplate/index.htm");
                    return;
                }
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
			inReadOnly = PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString());
            if ((hidReroute.Value != "") && (hidReroute.Value == "Reroute"))
            {
                hidReroute.Value = "";
                RerouteApplication();
            }
			if (!IsPostBack)
			{
                string strWhat = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ddlWhatAdmin");
                if (!string.IsNullOrEmpty(strWhat))
                {
                    try
                    {
                        ddlWhat.SelectedIndex = Convert.ToInt16(strWhat);
                    }
                    catch { }
                }
				if ((ViewState["Employee_Number"].ToString() == "") || (ViewState["Employee_Number"].ToString() == "0"))
				{
					string strRunOut = "<script>document.location.replace('/WEB_PROJECTS/TRN/PLA/out.aspx?message=You must select an employee first');</script>";
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRunOut", strRunOut);
					return;
				}
				if (!ProductCodeNotExists())
                    Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Employer has not selected the Training Product for Processing_Year " + ViewState["Processing_Year"].ToString(), true);	

				if ((ViewState["User_ID"] == null) ||(ViewState["User_ID"].ToString() == ""))
					Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message= Failed to connect to the program. You might not have the proper authorization. Please contact MyEnroll.com at "+PLA_Approval.TrainingClass.HelpPhoneNumber(),true);						
				
				if (ViewState["User_Group_ID"].ToString()!="1")
				{
//					if (ViewState["User_Primary_Role"].ToString() != "100407")
					if (!inReadOnly)
						if (!PLA_Approval.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString()))
							if (!SetEmployeeNumber())
								Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your MyEnroll Employee Number is not defined. Please Contact MyEnroll.com @ "+
									PLA_Approval.TrainingClass.HelpPhoneNumber(),true);
				}
				
				if (ViewState["Employee_Number"].ToString() == "0")
					Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=You must select the Payor's Employee Number first",true);

				if (ViewState["User_Group_ID"].ToString()!="1")
				{
//					if (ViewState["User_Primary_Role"].ToString() != "100407")
					if (!inReadOnly)
					{
						string strMesg = PLA_Approval.TrainingClass.IsPayorDataOk(ViewState["Employee_Number"].ToString());
						if (strMesg!="")
						{
							string strRunOut = "<script>document.location.replace('/Web_Projects/trn/PLA/out.aspx?message="+strMesg+"');</script>";
							Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRunOut", strRunOut);
							return;
						}
							//Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message="+strMesg,true);
					}
				}
				if (PLA_Approval.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString()))
				{
					string strSelectedEmployeeNumber=PLA_Approval.TrainingClass.UsedEmployeeNumber(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
					if (strSelectedEmployeeNumber != ViewState["Employee_Number"].ToString())
					{
						ViewState["Employee_Number"] = strSelectedEmployeeNumber;
					}
					lnkbtnSelectEmployee.Visible = true;
					lnkbtnSystemAdministrator.Visible = true;
				}
				//--------------------------------
				if ((inReadOnly)&&(PLA_Approval.TrainingClass.isAdministrator(ViewState["Employee_Number"].ToString())))
				{
					string strSelectedEmployeeNumber=PLA_Approval.TrainingClass.UsedEmployeeNumber(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
					if (strSelectedEmployeeNumber != ViewState["Employee_Number"].ToString())
					{
						ViewState["Employee_Number"] = strSelectedEmployeeNumber;
					}					
				}
				// ---------------------------------
				SetUsersEmployeeNumber();
				//SetCurrentProcessingYear();
				SetHeaderInformation();
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_Who","Payor",PLA_Approval.TrainingClass.ConnectionString);
				ProcessesStarFunctionality();
                processes_Reroute();
			}
			lblProcessing_Year.Text = ViewState["Processing_Year"].ToString();
			DrawGrid();
			HandleContractors();
		}

        private void processes_Reroute()
        {
			if (SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", PLA_Approval.TrainingClass.ConnectionString) != "")
            {
                bool blnConfirm = false;
                if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
                    blnConfirm = true;
                else if (PLA_Approval.TrainingClass.isAdministratorByUserID(ViewState["User_ID"].ToString()))
                    blnConfirm = true;
                string strRerouteScript = "";
                if (blnConfirm)
                {
                    string strNewSupervisor = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name").Replace("'", "");
                    strRerouteScript = "<script>CheckReroute('" + strNewSupervisor + "')</script>";
                }
                else
                {
                    strRerouteScript = "<script>alert('You may not retroute application')</script>";
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRerouteScript", strRerouteScript);
            }
        }

		private bool ProductCodeNotExists()
		{
			string strSQL = "select pkg_training.accounthasproduct_id(" + ViewState["Employee_Number"].ToString() + "," + ViewState["Processing_Year"].ToString() + ") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL);
			if (ob.ToString() == "0")
				return false;
			else
				return true;
		}

		private void HandleContractors()
		{
			string strHome = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"HOME",PLA_Approval.TrainingClass.ConnectionString).Trim();
			if (strHome !="")
			{
				return;
			}										

//			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
//				return;
//			HyperLink1.NavigateUrl = "/web_projects/trn/PLA_Homes/Home1.aspx";
			//PLA_Approval.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			
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
			this.lnkbtnSystemAdministrator.Click += new System.EventHandler(this.lnkbtnSystemAdministrator_Click);
			this.lnkbtnSelectEmployee.Click += new System.EventHandler(this.lnkbtnSelectEmployee_Click);
			this.lnkbtnGo.Click += new System.EventHandler(this.lnkbtnGo_Click);
			this.dgPending.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgPending_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetSelectedIndex(DataTable tbl)
		{
			
			if (tbl == null)
				return;
			int intIndex = -1;
			foreach (DataRow dr in tbl.Rows)
			{
				intIndex++;
				if (ViewState["Request_Record_ID"].ToString()==dr["record_id"].ToString())
				{
					dgPending.SelectedIndex = intIndex;
					break;				
				}
			}
			
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void RerouteApplication()
		{
			ViewState["Administrator_Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
			saveAdmin();
			Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES",true);
		}

		private void saveAdmin()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.reRouteAdministrator",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			ViewState["Request_Record_ID"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Administrator_Employee_Number","varchar2","in",ViewState["Administrator_Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				cmd.ExecuteNonQuery();				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}

		private bool SetEmployeeNumber()
		{
			bool eeFound = true;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
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

		private void SetCurrentProcessingYear()
		{
			string strSQL="select pkg_training.ee_current_processing_year("+ViewState["Employee_Number"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob==null)
				Response.Redirect("out.aspx?message=Current Processing Year is not defined for Employee Number "+ViewState["Employee_Number"].ToString(),true);
			else
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Processing_Year",ob.ToString(),PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Processing_Year"]=ob.ToString();
				ob = null;
			}
		}

		private void SetUsersEmployeeNumber()
		{
			ViewState["Supervisor_Employee_Number"] = ViewState["Employee_Number"];
//		
//			string strSQL="select pkg_training.employee_number_from_user_id('"+ViewState["User_ID"]+"') from dual";
//			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
//			if (ob==null)
//			{
//				lblError.Text = "Your Employee Number is not defined in the internet tables.";
//				ViewState["Supervisor_Employee_Number"]="0";
//			}
//			else
//				ViewState["Supervisor_Employee_Number"]=ob.ToString();
//			ob = null;
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Supervisor_Employee_Number"].ToString());
            return;
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Supervisor_Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
//			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Supervisor_Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}

		private  DataTable GetGridTable()
		{
			bool blnIsAll = ddlWhat.SelectedValue=="1000";
			string steProcedureName = "BASDBA.pkg_training.pendig_payor_List";
			if (blnIsAll)
				steProcedureName = "BASDBA.pkg_training.payor_List";
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(steProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["Supervisor_Employee_Number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ViewState["Processing_Year"].ToString());
			if (!blnIsAll)
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "application_status_",ddlWhat.SelectedValue);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "pnding_list_","cursor","out","");

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
				if (da!=null)
					da.Dispose();
			}
			return tbl;
		}



		private void DrawGrid()
		{
			DataTable dt = GetGridTable();
			dgPending.DataSource=dt;
			dgPending.DataBind();

			if (dt.Rows.Count>0)
                lblNote.Text = "<br><font face='Arial' color='#660033'><b>Total Found:</b>" + dt.Rows.Count.ToString() + "</font><br><br>" +
                    "Applications submitted before 1/1/2007 do not have budget records";
			else
				lblNote.Text = "No Applications";
			//SetSelectedIndex(dt);
		}

		private void dgPending_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgPending.DataSource;
					string strRecid = tbl.Rows[indx]["record_id"].ToString();
					string strStatus = tbl.Rows[indx]["application_status"].ToString();
					DateTime dtAdded = Convert.ToDateTime(tbl.Rows[indx]["PededOn"].ToString());
					bool blnShowBudget = (dtAdded >= Convert.ToDateTime("01/01/2007"));
					
					Label lbl = new Label();
					lbl.ID = "lbl_id"+strRecid;
					if (tbl.Rows[indx]["course_code"].ToString().Trim()=="")
						lbl.Text = tbl.Rows[indx]["course_title"].ToString();
					else
						lbl.Text = tbl.Rows[indx]["course_code"].ToString()+" - "+tbl.Rows[indx]["course_title"].ToString();
					TableCell cell1 = e.Item.Cells[1];
					cell1.Controls.Add(lbl);

					HyperLink hpl = new HyperLink();
					hpl.Text = "show";
					if (blnShowBudget)
						hpl.NavigateUrl = "Javascript: popup('/Web_Projects/trn/PLA/BudgetDetail.aspx?ee= "+tbl.Rows[indx]["employee_number"].ToString()+"&py="+ViewState["Processing_Year"].ToString()+"',500,600);";
					else
						hpl.Text = "N/A";
					
					TableCell cellhl = e.Item.Cells[3];
					cellhl.Controls.Add(hpl);

					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="fontsmall";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(200);
					ddl.ID = "ddl_"+strRecid;	

					if ((strStatus=="5")||(strStatus=="18"))
					{
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li9 = new ListItem("View Eval.","9");
						ddl.Items.Add(li9);
						ListItem li2 = new ListItem("Communication Module","1");	
						ddl.Items.Add(li2);	
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);	
					}
					else if (strStatus=="28")
					{
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li13 = new ListItem("Expense Adjustment","13");
						ddl.Items.Add(li13);
						ListItem li2 = new ListItem("Communication Module","1");	
						ddl.Items.Add(li2);	
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);	
					}
					else if ((strStatus=="2")||(strStatus=="10")||(strStatus=="11")||(strStatus=="21")
						||(strStatus=="3")||(strStatus=="13"))
					{
						string strAction = "Process";
						if ((strStatus!="2")&&(strStatus!="13"))
							strAction = "Override";
						ListItem li = new ListItem(strAction,"0");	
						ddl.Items.Add(li);

						if (strStatus!="21")
						{
							ListItem li12 = new ListItem("Cancel This Training Request","12");
							ddl.Items.Add(li12);
						}

						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li3 = new ListItem("Reroute Administrator","3");					
						ddl.Items.Add(li3);
						ListItem li2 = new ListItem("Communication Module","1");	
						ddl.Items.Add(li2);	
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);			
					}	
					else
					{
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li2 = new ListItem("Communication Module","1");	
						ddl.Items.Add(li2);	
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);	
					}
					// create button
					Button btn2 = new Button();
					btn2.CssClass = "actbtn_go_next_button";
					btn2.ID="btn_"+strRecid;
					btn2.Text = "Go";				
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[4];						
					cell.Controls.Add(ddl);
					cell.Controls.Add(btn2);				
				}
				catch
				{
				}
			}
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

		private void DoProcess()
		{			
			Response.Redirect("PayorApprovalPage.aspx",true);
		}

		private void SetupRequestParam(string strRecordID)
		{
			DataTable tbl = (DataTable) dgPending.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString()==strRecordID)
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",dr["employee_number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",dr["record_id"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					break;
				}
			}
		}

		private void SetupRequestCommParam(string strRecordID)
		{
			DataTable tbl = (DataTable) dgPending.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString()==strRecordID)
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",dr["From_Employee_Number"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",dr["record_id"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					break;
				}
			}
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string strRecId = ((Button)sender).ID.Substring(4);	
			
			DropDownList ddl = GetDropDown(this,"ddl_"+strRecId);			
			if (ddl.SelectedValue=="0")
			{
				SetupRequestParam(strRecId);
				DoProcess();
			}					
			else if (ddl.SelectedValue=="1")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("/WEB_PROJECTS/TRN/PLA/Communication.aspx?w=/WEB_PROJECTS/TRN/PLA_APPROVAL/PayorPendingApprovals.aspx?SkipCheck=YES");
//				Response.Redirect("Communication.aspx?w=PayorPendingApprovals");
			}
			else if (ddl.SelectedValue=="2")
			{
				SetupRequestParam(strRecId);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Retuen_To","/web_projects/trn/pla_approval/PayorPendingApprovals.aspx?SkipCheck=YES",PLA_Approval.TrainingClass.ConnectionString);
                Response.Redirect("/web_projects/trn/History/History.aspx");
			}
			else if (ddl.SelectedValue=="3")
			{
				SetupRequestParam(strRecId);
				string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a&UseAltName=Reroute_Found_Employee";
                Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
			}
			else if (ddl.SelectedValue=="9")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("/Web_Projects/trn/PLA/ReviewEval.aspx?call="+Request.Path);
			}
			else if (ddl.SelectedValue=="10")
			{
				SetupRequestParam(strRecId);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","true",PLA_Approval.TrainingClass.ConnectionString);
				Response.Redirect("/Web_Projects/trn/PLA/NewSummary.aspx?call="+Request.Path+"?SkipCheck=YES");
			}
			else if (ddl.SelectedValue=="12")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("CancelApplication2.aspx?who=payor");
			}
			else if (ddl.SelectedValue=="13")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("ExpenseAdjustment.aspx?call="+Request.Path);
			}
			else if (ddl.SelectedValue=="19")
			{
				string strURL = "/web_projects/trn/PLA_Report/Training_Request_Summary.aspx?hedID=" + strRecId +
					"&BackTo=" + Request.Path;
				Response.Redirect(strURL);
			}
			ddl.SelectedIndex = 0;
			//			lblScript.Text="<script>opener.window.location.href='SupervisorApprove.aspx';window.close()</script>";
		}

		private void lnkbtnGo_Click(object sender, System.EventArgs e)
		{
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ddlWhatAdmin", ddlWhat.SelectedIndex.ToString());
			DrawGrid();
		}

		private void lnkbtnSelectEmployee_Click(object sender, System.EventArgs e)
		{
			string strUsePLAHomeMessage = "<Script>alert('Please use \"PLA Manager Home\" from the left menu to select and manage admininstrators.')</script>";
			Page.ClientScript.RegisterStartupScript(Page.GetType(), "strUsePLAHomeMessage", strUsePLAHomeMessage);
			//string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a&UseAltName=TRN_Found_Employee";
			//Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);		
		}

		private void lnkbtnSystemAdministrator_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("System_Administrator.aspx?SkipCheck=YES",true);
		}

     

	}
}
