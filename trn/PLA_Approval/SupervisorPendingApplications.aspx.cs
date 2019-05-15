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
	/// Summary description for SupervisorPendingApplications.
	/// </summary>
	public class SupervisorPendingApplications : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid dgPending;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblProcessing_Year;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo;
		protected System.Web.UI.WebControls.DropDownList ddlWhat;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label lbl_fldPLASupervisorPendingApproval;
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
				string strURL = "/Web_Projects/trn/PLA_Approval/SupervisorPendingApplications.aspx";
				string strSetLeftMenu =
					"<script>window.open('/web_projects/ptemplate/left.aspx?callingurl=" + strURL + "','MyEnroll_available_programs_listing_menu_frame')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"strSetLeftMenu", strSetLeftMenu);
			}
            if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
            {
                Response.Redirect("/Web_Projects/trn/PLA/out.aspx?SkipCheck=YES&message=Your Session has timed out" + "&backurl=0");
                return;
            }
			lblError.Text = "";
			lblScript.Text = "";
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
            if ((hidReroute.Value != "") && (hidReroute.Value == "CancelReroute"))
            {
                hidReroute.Value = "";
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
            }
			if (!IsPostBack)
			{
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "APPLICANT_EMPLOYEE_NUMBER", "");
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PAGESTATUS", "");
                
                string strWhat = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ddlWhatSuper");
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
					//Response.Redirect("out.aspx?message=You must select an employee first " , true);
				}
				if (!ProductCodeNotExists())
                    Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Employer has not selected the Training Product for Processing_Year " + ViewState["Processing_Year"].ToString(), true);	

                hidReroute.Value = "";
				if ((ViewState["User_ID"] == null) || (ViewState["User_ID"].ToString() == ""))
					Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message= Failed to connect to the program. You might not have the proper authorization. Please contact MyEnroll.com at "+PLA_Approval.TrainingClass.HelpPhoneNumber(),true);						

				if (ViewState["User_Group_ID"].ToString()!="1")
				{
					if (!inReadOnly)
						if (!PLA_Approval.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString()))
							if (!SetEmployeeNumber())
								Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your MyEnroll Employee Number is not defined. Please Contact MyEnroll.com @ "+
									PLA_Approval.TrainingClass.HelpPhoneNumber(),true);
				}

				if (ViewState["Employee_Number"].ToString() == "0")
					Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=You must select the Supervisor's Employee Number first",true);	

				if (ViewState["User_Group_ID"].ToString()!="1")
				{
//					if (ViewState["User_Primary_Role"].ToString() != "100407")
					if (!inReadOnly)
					{
						string strMesg = PLA_Approval.TrainingClass.IsSprvsrDataOk(ViewState["Employee_Number"].ToString());
						if (strMesg!="")
							Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message="+strMesg,true);
					}
				}
				ViewState["Supervisor_No"]=ViewState["Employee_Number"].ToString();
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

                processes_Reroute();
				SetCurrentProcessingYear();
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_Who","Supervisor",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);				
				SetUsersEmployeeNumber();
				SetHeaderInformation();
				ProcessesStarFunctionality();
						
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
					string strNewSupervisor = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name");
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
			if (inReadOnly)
				if (!PLA_Approval.TrainingClass.isAdministratorByUserID(ViewState["User_ID"].ToString()))
					return;
			ViewState["Supervisor_Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Name", "", PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Reroute_Found_Employee_Email", "", PLA_Approval.TrainingClass.ConnectionString);
			saveSupervisor();
			Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES",true);
		}

		private void saveSupervisor()
		{			
			ViewState["Product_Code"]= SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
			string strProcedureName = "basdba.PKG_Training.reRouteSupervisor";
			if (ViewState["Product_Code"].ToString()=="11001")
				strProcedureName = "basdba.PKG_Training_cdp.reRouteSupervisor";
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			ViewState["Request_Record_ID"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"supervisor_employee_number_","varchar2","in",ViewState["Supervisor_Employee_Number"].ToString());
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
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
            return;
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private  DataTable GetGridTable()
		{
			bool blnIsAll = ddlWhat.SelectedValue=="1000";
			string steProcedureName = "BASDBA.pkg_training.pendig_supervisor_List";
			if (blnIsAll)
				steProcedureName = "BASDBA.pkg_training.supervisor_List";
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
				lblNote.Text = "Applications submitted before 1/1/2007 do not have budget records";
			else
				lblNote.Text = "No Applications";
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
					string strmarke = tbl.Rows[indx]["product_code"].ToString()=="11001" ? "C" : "P";
					string strPosition=tbl.Rows[indx]["Position"].ToString();
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
					
					TableCell cellhl = e.Item.Cells[5];
					cellhl.Controls.Add(hpl);

					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="fontsmall";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(100);
					ddl.ID = "ddl_"+strmarke+strRecid;	
					
					if ((strStatus=="1")||(strStatus=="2")||(strStatus=="6")||
						(strStatus=="20")||(strStatus=="10")||(strStatus=="11")||(strStatus=="12")
						||(strStatus=="13")||(strStatus=="21")) 
					{
						string strAction = "Process";
						if ((strStatus!="1")&&(strStatus!="12")&&((strStatus!="24")||(strPosition!="1")))
							strAction = "Override";
						ListItem li = new ListItem(strAction,"0");	
						ddl.Items.Add(li);	
						
						if ((strStatus!="20")&&(strmarke!="C")&&(strStatus!="24"))
						{
							ListItem li12 = new ListItem("Cancel Request","12");                           
							//ddl.Items.Add(li12);
						}
                        

						if (strmarke!="C")
						{
							ListItem li10 = new ListItem("View Summary","10");
							ddl.Items.Add(li10);
							ListItem li19 = new ListItem("Summary Report","19");
							ddl.Items.Add(li19);
						}
						
						if (strStatus!="24")
						{
							ListItem li3 = new ListItem("Reroute Supervisor","3");					
							ddl.Items.Add(li3);
						}

                        if (tbl.Rows[indx]["product_code"].ToString().Equals("11001") && ddlWhat.SelectedValue.Equals("1"))
                        {
                            ListItem li12 = new ListItem("Remove CDP", "12");
                            ddl.Items.Add(li12);
                        }

						ListItem li2 = new ListItem("Communication Module","1");					
						ddl.Items.Add(li2);
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);
					}
					else if ((strStatus=="24")||(strStatus=="25"))
					{
						ListItem li25 = null;
						if (strStatus=="25")
							li25 = new ListItem("Override","25");
						else
							li25 = new ListItem("Process","25");
						ddl.Items.Add(li25);
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li2 = new ListItem("Communication Module","1");					
						ddl.Items.Add(li2);
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);
					}
					else if (strStatus=="5")
					{
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li9 = new ListItem("Review Eval.","9");
						ddl.Items.Add(li9);
						ListItem li2 = new ListItem("Communication Module","1");					
						ddl.Items.Add(li2);
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);
					}
					else if (strStatus=="18")
					{
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
						ListItem li3 = new ListItem("Reroute Supervisor","3");					
						ddl.Items.Add(li3);
						ListItem li11 = new ListItem("Supervisor’s Acknowledgement of the Evaluation Form","11");
						ddl.Items.Add(li11);
						ListItem li2 = new ListItem("Communication Module","1");					
						ddl.Items.Add(li2);
						ListItem li8 = new ListItem("View History","2");
						ddl.Items.Add(li8);
						ddl.Width=System.Web.UI.WebControls.Unit.Pixel(300);
					}
					else if (strStatus=="26")
					{
						ListItem li = new ListItem("Override","0");	
						ddl.Items.Add(li);	
						ListItem li10 = new ListItem("View Summary","10");
						ddl.Items.Add(li10);
						ListItem li19 = new ListItem("Summary Report","19");
						ddl.Items.Add(li19);
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
					btn2.ID="btn_"+strmarke+strRecid;
					btn2.Text = "Go";
                    btn2.Width = System.Web.UI.WebControls.Unit.Pixel(30);
                    btn2.CssClass = "fontsmall";
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[6];						
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

		private bool AquiredApproval(string strHeadr_record_id)
		{
			string strSQL="select pkg_training.AquiredPrerequsit("+strHeadr_record_id+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob.ToString()=="0") 
				return false;
			else
				return true;
		}

		private void DoProcess(string strRecId)
		{			
			DataTable tbl = (DataTable)dgPending.DataSource;
			string strSupervisorNumber;
			string str2ndSupervisorNumber="-1";
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString()==strRecId)
				{
					strSupervisorNumber = dr["supervisor_employee_number"].ToString();
					str2ndSupervisorNumber = dr["supervisor_2nd_inline_ee_no"].ToString();
					break;
				}
			}


			if (ViewState["Product_Code"].ToString()=="11001") // CDP
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"PageStatus","In_Approval",PLA_Approval.TrainingClass.ConnectionString);
				Response.Redirect("/Web_Projects/trn/CDP2008/Default.aspx",true);
			}
			else 
			{
				Response.Redirect("SupervisorApproval.aspx?SkipCheck=YES",true);
				return;
			}
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
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",dr["Product_Code"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
					ViewState["Product_Code"] = dr["Product_Code"].ToString();
					ViewState["Position"]=dr["Position"].ToString();
					break;
				}
			}
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string strRecId = ((Button)sender).ID.Substring(5);	
			string strMarker = ((Button)sender).ID.Substring(4,1);

			DropDownList ddl = GetDropDown(this,"ddl_"+strMarker+strRecId);			
			if (ddl.SelectedValue=="0")
			{
				SetupRequestParam(strRecId);
				DoProcess(strRecId);
			}
			if (ddl.SelectedValue=="25")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("Supervisor2ndInLineApproval.aspx?w=SupervisorPendingApplications");
			}		
			else if (ddl.SelectedValue=="1")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("/WEB_PROJECTS/TRN/PLA/Communication.aspx?w=/WEB_PROJECTS/TRN/PLA_APPROVAL/SUPERVISORPENDINGAPPLICATIONS.ASPX?SkipCheck=YES");
			//	Response.Redirect("Communication.aspx?w=SupervisorPendingApplications");
			}
			else if (ddl.SelectedValue=="2")
			{
				SetupRequestParam(strRecId);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Retuen_To","/web_projects/trn/pla_approval/SupervisorPendingApplications.aspx?SkipCheck=YES",PLA_Approval.TrainingClass.ConnectionString);
                Response.Redirect("/web_projects/trn/History/History.aspx");
			}
			else if (ddl.SelectedValue=="3")
			{
				SetupRequestParam(strRecId);
				string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a &who=Super&UseAltName=Reroute_Found_Employee";
                Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
				
				//string strParamQuery="?returl=SupervisorPendingApplications.aspx?SkipCheck=YES&inst=2";                
                //lblScript.Text = "<script>popup('SearchEmployee.aspx"+strParamQuery+"',530,700)</script>";
			}
			else if (ddl.SelectedValue=="9")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("/Web_Projects/trn/PLA/ReviewEval.aspx?call="+Request.Path+"?SkipCheck=YES");
			}
			else if (ddl.SelectedValue=="10")
			{
				SetupRequestParam(strRecId);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","true",PLA_Approval.TrainingClass.ConnectionString);
				Response.Redirect("/Web_Projects/trn/PLA/NewSummary.aspx?call="+Request.Path+"?SkipCheck=YES");
			}
			else if (ddl.SelectedValue=="11")
			{
				SetupRequestParam(strRecId);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Acknowledge","true",PLA_Approval.TrainingClass.ConnectionString);
				Response.Redirect("/Web_Projects/trn/PLA/ReviewEval.aspx?call="+Request.Path+"?SkipCheck=YES");
			}
			else if (ddl.SelectedValue=="12")
			{
				SetupRequestParam(strRecId);
				Response.Redirect("CancelApplication.aspx");
			}
			else if (ddl.SelectedValue=="19")
			{
				string strURL = "/web_projects/trn/PLA_Report/Training_Request_Summary.aspx?hedID=" + strRecId +
					"&BackTo=" + Request.Path;
				Response.Redirect(strURL);
			//    ddl.SelectedIndex = 0;
			//    lblScript.Text= "<script>popup('rptFDICTraining.rpx?OutputFormat=pdf&RecordID="+strRecId+"',500,700)  </script>";
			}
			ddl.SelectedIndex =0;

//			lblScript.Text="<script>opener.window.location.href='SupervisorApprove.aspx';window.close()</script>";
		}

		private void lnkbtnGo_Click(object sender, System.EventArgs e)
		{
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ddlWhatSuper", ddlWhat.SelectedIndex.ToString());
			DrawGrid();
		}

		private void lnkbtnSelectEmployee_Click(object sender, System.EventArgs e)
		{
			string strUsePLAHomeMessage = "<Script>alert('Please use \"PLA Manager Home\" from the left menu to select and manage supervisors.')</script>";
			Page.ClientScript.RegisterStartupScript(Page.GetType(), "strUsePLAHomeMessage", strUsePLAHomeMessage);
			//string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a &who=Super&UseAltName=TRN_Found_Employee";
			//Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
            //string strParamQuery="?returl="+Request.Path+"&inst=5";
            //lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
		}

		private void lnkbtnSystemAdministrator_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("System_Administrator.aspx?SkipCheck=YES",true);
		}

	}
}
