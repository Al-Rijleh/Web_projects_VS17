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
	/// Summary description for SelectApp.
	/// </summary>
	public class SelectApp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancel;
		protected System.Web.UI.WebControls.DataGrid dgApp;
		protected System.Web.UI.WebControls.LinkButton lnkbtnNewRequest;
        protected System.Web.UI.WebControls.LinkButton lnkbtnAddBookRequest;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lbl_fldTrainingSelectApp;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblWarningNeedCDP;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Button btnBack;
        protected System.Web.UI.WebControls.Label lblNew;
        protected System.Web.UI.WebControls.Label lblCPBudget;
        protected System.Web.UI.HtmlControls.HtmlTableRow trNoAccess;
        protected System.Web.UI.WebControls.Label lblUneligible;
        //protected System.Web.UI.WebControls.LinkButton lnkbtnEESearch;
        //protected System.Web.UI.WebControls.Label lblNoAccess;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
            //if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
            //{
            //    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES", Training_Source.TrainingClass.ConnectioString);
            //    Response.Redirect("/web_projects/PTemplate/index.htm");
            //    return;
            //}
            //if (!IsPostBack)
            //{
            //    string strURL = "/Web_Projects/trn/PLA/PrivacyStatementTraining.aspx";
            //    string strSetLeftMenu =
            //        "<script>window.open('/web_projects/ptemplate/left.aspx?callingurl=" + strURL + "','MyEnroll_available_programs_listing_menu_frame')</script>";
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(),"strSetLeftMenu", strSetLeftMenu);
            //}
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text = "";
			
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView","F",Training_Source.TrainingClass.ConnectioString);
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
                    if (objBasTemplate.strUser_Group_ID.ToString() == "1")
                        objBasTemplate.ShowSelectEmployee = true;
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
			if (!IsPostBack)
			{
                LblTemplateHeader2.Text =
                    LblTemplateHeader2.Text.Replace("/web_projects/Employee_Search/default.aspx?SkipCheck=YES",
                      "/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&pc=11100");
                if (DateTime.Today >= Convert.ToDateTime("06/01/2009"))
                    lblNew.Visible = false;
				if ((ViewState["Employee_Number"].ToString() == "") || (ViewState["Employee_Number"].ToString() == "0"))
				{
					string strRunOut="<script>document.location.replace('out.aspx?message=You must select an employee first');</script>";
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRunOut", strRunOut);
					return;
					//Response.Redirect("out.aspx?message=You must select an employee first " , true);
				}
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"TRN_EMPLOYEE_NUMBER",ViewState["Employee_Number"].ToString());

                
				if (!ProductCodeNotExists())
					Response.Redirect("out.aspx?message=Your Employer has not selected the Training Product for Processing_Year " + ViewState["Processing_Year"].ToString(), true);
                
                //if (ViewState["User_Group_ID"].ToString() != "1")
                {
                    
                }
				
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
				ViewState["Product_Code"] = "11100";
				ViewState["Mandatory_Only"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Mandatory_Only",Training_Source.TrainingClass.ConnectioString);
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
                string employee_number_ = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER");
                if (!string.IsNullOrEmpty(employee_number_))
                    ViewState["Employee_Number"] = employee_number_;

                Start();
				//SetHeaderInformation();	
				ProcessesStarFunctionality();
                employee_number_ = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER");
                if (string.IsNullOrEmpty(employee_number_))
                    employee_number_ = ViewState["Employee_Number"].ToString();
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				
				
                
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
			this.ddlBudgetYear.SelectedIndexChanged += new System.EventHandler(this.ddlBudgetYear_SelectedIndexChanged);
			this.lnkbtnNewRequest.Click += new System.EventHandler(this.lnkbtnNewRequest_Click);
			this.dgApp.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApp_ItemCreated);
			this.dgApp.SelectedIndexChanged += new System.EventHandler(this.dgApp_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private bool ProductCodeNotExists()
		{
			string strSQL = "select pkg_training.accounthasproduct_id(" + ViewState["Employee_Number"].ToString() + "," + ViewState["Processing_Year"].ToString() + ") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL, Training_Source.TrainingClass.ConnectioString);
			if (ob.ToString() == "0")
				return false;
			else
				return true;
		}
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
					dgApp.SelectedIndex = intIndex;
					break;
				}
			}
			
		}

		private void ProcessesStarFunctionality()
		{
            if (ViewState["Account_Number"] == null)
                ViewState["Account_Number"] = Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void SetHeaderInformation()
		{
            string employee_number_ = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER");
            if (string.IsNullOrEmpty(employee_number_))
                employee_number_ = ViewState["Employee_Number"].ToString();
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
            string parPtemplate = Training_Source.TrainingClass.SetFullHeader(Page, employee_number_);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

        // Maher 4/25/2016
        private void setNoCDP(string strEmployeeNumber)
        {
            string strMesg = Training_Source.TrainingClass.IsEeDataOk(strEmployeeNumber);
            if (!string.IsNullOrEmpty(strMesg))
            {
                trNoAccess.Visible = true;
                lblWarningNeedCDP.Visible = false;
                lbl_fldTrainingSelectApp.Visible = false;
                lblUneligible.Text = strMesg;                
            }
            else
                trNoAccess.Visible = false;

            lnkbtnNewRequest.Visible = !trNoAccess.Visible;
            lnkbtnAddBookRequest.Visible = lnkbtnNewRequest.Visible;

            bool HasApprovedCDP = false;
            try
            {
                string strApprovalState = SQLStatic.SQL.ExecScaler(
                    "select pkg_training_cdp.approvalstatus_employee(" + strEmployeeNumber + "," + ViewState["Processing_Year"].ToString() + ") from dual").ToString();
                HasApprovedCDP = strApprovalState == "16";
            }
            catch
            {
                HasApprovedCDP = false;
            }
            if (!HasApprovedCDP)
            {
                lblWarningNeedCDP.Visible = true;
                lnkbtnNewRequest.Enabled = false;
                lnkbtnAddBookRequest.Enabled = false;
            }
        }

		private  DataTable GetGridTable()
		{
            string employee_number_ = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER");
            if (string.IsNullOrEmpty(employee_number_))
                employee_number_ = ViewState["Employee_Number"].ToString();
            employee_number_ = Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(), Request.Cookies["Session_ID"].Value.ToString());
            setNoCDP(employee_number_);// Maher 4/25/2016
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.ApplicationsList",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "product_code_",ViewState["Product_Code"].ToString());
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", employee_number_);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "AppList","cursor","out","");

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
			dgApp.DataSource=dt;
			dgApp.DataBind();
			SetSelectedIndex(dt);
//			int index = SelectedIndexOfRecordID();
//			if (index!=-1)
//				dgApp.SelectedIndex=index;
//			if (dt.Rows.Count==0)
//				lblIntruction1.Visible=true;
//			lblInstruction2.Visible = !lblIntruction1.Visible;
		}

		private void dgApp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			
			DataTable tbl = (DataTable) dgApp.DataSource;
			ViewState["Request_Record_ID"]=tbl.Rows[dgApp.SelectedIndex]["record_id"].ToString();
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",ViewState["Request_Record_ID"].ToString(),Training_Source.TrainingClass.ConnectioString);
			Response.Redirect("TrainingVendorInfo.aspx");
		}

		private void ShowError(string strMsg)
		{
//			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
//			lblScript.Text = "<script>popup('error.aspx',200,400)</script>";
			lblScript.Text = "<script>alert('"+strMsg+"')</script>";
		}

		private void lnkbtnNewRequest_Click(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.HasPendingEvaluation(ViewState["Employee_Number"].ToString()))
				ShowError("You cannot add a new training request until you have completed the pending post-training evaluation form associated with another training request.  Please find the training request with the status “Pending Evaluation”, and use the Action Drop Down Item – Review Eval. – to complete your evaluation.  Afterwards, you may click on “Add New Training Request” to add new training request.");
			else
			{
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Request_Record_ID", "-1", conn);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "BookRequest", "",conn);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "WIZARD_ID", "119",conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
				Response.Redirect(First_step_in_wizard());
			}
		}

		

		private void dgApp_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgApp.DataSource;
					string strCode = tbl.Rows[indx]["record_id"].ToString();	

								
					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="fontsmall";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(175);
					ddl.ID = "ddl_"+strCode;	

					ListItem li = new ListItem("View Summary","0");
					ddl.Items.Add(li);

					ListItem li7 = new ListItem("Summary Report","7");
					ddl.Items.Add(li7);

					

					ListItem li2 = new ListItem("Edit Request","2");
					ListItem li3 = new ListItem("Cancel Request","3");
					ListItem li4 = new ListItem("Reactivate Request","4");
					
					ListItem li6 = new ListItem("Edit/View Expenses","6");
					ListItem li9 = new ListItem("Review Eval.","9");
					ListItem li10 = new ListItem("Complete Eval.","10");
					ListItem li11 = new ListItem("Cancel Paid Request","11");
					
					switch (Convert.ToInt32(tbl.Rows[indx]["application_status"].ToString()))
					{
						case 0:
							ddl.Items.Add(li2);
							ddl.Items.Add(li3);
							break;
						case 1:
							ddl.Items.Add(li2);
							ddl.Items.Add(li3);
							break;
						case 2:
							ddl.Items.Add(li2);
							ddl.Items.Add(li3);
							break;
						case 3:
							ddl.Items.Add(li11);
							break;
						case 4:
							ddl.Items.Add(li4);
							break;
						case 23:
							ddl.Items.Add(li4);
							break;
						case 5:
							ddl.Items.Add(li9);
							break;
						case 6:
							break;
						case 10:
							break;
						case 11:
							break;
						case 12:
							ddl.Items.Add(li2);
							ddl.Items.Add(li3);
							break;
						case 13:
							ddl.Items.Add(li2);
							ddl.Items.Add(li3);
							break;
						case 17:
							ddl.Items.Add(li10);
							ddl.Items.Add(li11);
							break;
						case 18:
							ddl.Items.Add(li9);
							break;
						case 19:
							ddl.Items.Add(li10);
							ddl.Items.Add(li11);
							break;									
					}
					ListItem li5 = new ListItem("Communication Module","5");
					ddl.Items.Add(li5);
					ListItem li8 = new ListItem("View History","8");
					ddl.Items.Add(li8);
			
					// create button
					Button btn = new Button();
					btn.CssClass = "actbtn_go_next_button";
					btn.ID="btn_"+strCode;
					btn.Text = "Go";
				
					

					btn.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[5];
					cell.Controls.Add(ddl);
					cell.Controls.Add(btn);
				}
				catch{}
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

		private void ViewSummary()
		{			
			Response.Redirect("NewSummary.aspx?call="+Request.Path);
		}

		private void ViewProcessingSteps()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView","T",Training_Source.TrainingClass.ConnectioString);			

			Response.Redirect(First_step_in_wizard());
		}

		private void EditSteps(string strBookRequested)
		{
            if (strBookRequested == "1")
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "WIZARD_ID", "130");
            else
            {
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "WIZARD_ID", "119");
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "BookRequest", "");
            }
			Response.Redirect(First_step_in_wizard());
		}

		private void CancelSteps()
		{
			Response.Redirect("Confirmation.aspx?c=y");
		}
		
		private void RectivateRequest()
		{
			Response.Redirect("Confirmation.aspx?c=r");
		}

		private void CommunicationModule()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_Employee_Number",ViewState["Employee_Number"].ToString(),Training_Source.TrainingClass.ConnectioString);
			Response.Redirect("Communication.aspx?w=SelectApp");
		}

		private void ViewHistory()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Retuen_To","/web_projects/trn/pla/SelectApp.aspx",Training_Source.TrainingClass.ConnectioString);
			Response.Redirect("/web_projects/trn/pla/History.aspx");
		}

		private void ViewReviewEval()
		{			
			Response.Redirect("/Web_Projects/trn/PLA/ReviewEval.aspx?call="+Request.Path);
		}
		
		private void CompleteEval()
		{
			string strSQL = "select pkg_trn_fdic.evaluation_form_id("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strRecordId= SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			Response.Redirect("/Web_Projects/trn/PLA/TrainingAnswers3.aspx?id="+strRecordId+"_"+ViewState["Request_Record_ID"].ToString()+" &call="+Request.Path+"&role="+ViewState["User_Primary_Role"].ToString());
		}

		private void CancelPaidRequest()
		{
			string strSQL = "select pkg_trn_fdic.evaluation_form_id("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strRecordId= SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
//			Response.Redirect("/Web_Projects/trn/PLA/CancelPaidRequest.aspx?id="+strRecordId+"_"+ViewState["Request_Record_ID"].ToString()+" &call="+Request.Path);
			Response.Redirect("/Web_Projects/trn/PLA/CancelPaidRequestinsystem.aspx?call="+Request.Path+"&role="+ViewState["User_Primary_Role"].ToString());
		}

		public string First_step_in_wizard()
		{
			string FirststepinWiz = null;
			string sessID=Request.Cookies["Session_ID"].Value.ToString();
			// create the command for the function
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();
			Oracle.DataAccess.Client.OracleConnection conn = 
				new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString); 
			cmd.Connection = conn;
			cmd.CommandText = "pkg_wizard.First_step_in_wizard";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("session_id_", Oracle.DataAccess.Client.OracleDbType.Varchar2, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, sessID));
			cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("first_step_id_", Oracle.DataAccess.Client.OracleDbType.Double, 20, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("first_step_url_", Oracle.DataAccess.Client.OracleDbType.Varchar2, 255, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// execute the function
			conn.Open();
			cmd.ExecuteNonQuery();
			FirststepinWiz = Convert.ToString(cmd.Parameters[2].Value);
			cmd.Dispose();
			conn.Close();
			conn.Dispose();
			return FirststepinWiz;
		}

		private void EditExpense()
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView","T",Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Expense","T",Training_Source.TrainingClass.ConnectioString);
			Response.Redirect("TrainingExpenses.aspx",true);
		}
		
		private int SelectedIndexOfRecordID()
		{
			if (ViewState["Request_Record_ID"]==null)
				return -1;
			int index =0;
			DataTable dt = (DataTable) dgApp.DataSource;
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["record_id"].ToString()== ViewState["Request_Record_ID"].ToString())				
					break;
				index++;
			}
			if (index>=dt.Rows.Count)
				index = -1;
			return index;
		}

		private string SelectedStatus(DataTable dt, string strID)
		{
			string strStatus="";
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["record_id"].ToString()==strID)
				{
					strStatus = dr["application_status"].ToString();
					break;
				}
			}
			return strStatus;
		}

        private string BookRequest(DataTable dt, string strID)
        {
            string bookRequested = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["record_id"].ToString() == strID)
                {
                    bookRequested = dr["book_request"].ToString();
                    break;
                }
            }
            return bookRequested;
        }

		private void btnMenu_Click(object sender, System.EventArgs e)
		{			
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView","F",Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Expense","F",Training_Source.TrainingClass.ConnectioString);					
			string strIndex = ((Button)sender).ID.Substring(4);
			DataTable dt = (DataTable)dgApp.DataSource;
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Initial_Status",SelectedStatus(dt,strIndex),Training_Source.TrainingClass.ConnectioString);
			DropDownList ddl = GetDropDown(this,"ddl_"+strIndex);
			ViewState["Request_Record_ID"]=strIndex;
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",ViewState["Request_Record_ID"].ToString(),Training_Source.TrainingClass.ConnectioString);
			if (ddl.SelectedValue=="0")
				ViewSummary();
			else if (ddl.SelectedValue=="1")
				ViewProcessingSteps();
			else if (ddl.SelectedValue=="2")
                EditSteps(BookRequest(dt, strIndex));
			else if (ddl.SelectedValue=="3")
				CancelSteps();
			else if (ddl.SelectedValue=="4")
				RectivateRequest();
			else if (ddl.SelectedValue=="5")
				CommunicationModule();
			else if (ddl.SelectedValue=="6")
				EditExpense();
			else if (ddl.SelectedValue=="7")
			{
				string strURL = "/web_projects/trn/PLA_Report/Training_Request_Summary.aspx?hedID=" + strIndex +
					"&BackTo=" + Request.Path;
				Response.Redirect(strURL);
			}
			else if (ddl.SelectedValue=="8")
			{
				ViewHistory();
			}
			else if (ddl.SelectedValue=="9")
			{
				ViewReviewEval();
			}
			else if (ddl.SelectedValue=="10")
			{
				CompleteEval();
			}
			else if (ddl.SelectedValue=="11")
			{
				CancelPaidRequest();
			}
//			lnkbtnSaveAndNext_Click(null,null);
		}

		

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string employee_number_ = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PLA_EMPLOYEE_NUMBER");
            if (string.IsNullOrEmpty(employee_number_))
                employee_number_ = ViewState["Employee_Number"].ToString();
            lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem, employee_number_);
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SelectAccountCategory.aspx");
		}
// --------------------------------------- From Select Category -----------
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

		private bool CreateEEAccount()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_trn_fdic.add_ee_to_pla", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			bool isOk = true;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", "number", "in", ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_", "varchar2", "in", ViewState["Processing_Year"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", "varchar2", "in", ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "new_record_id_", "number", "out", "");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "error_message_", "varchar2", "out", "");
				conn.Open();
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["error_message_"].Value != null)
				{
					if (cmd.Parameters["error_message_"].Value.ToString().Trim() != "")
					{
						string strErrorMessage = cmd.Parameters["error_message_"].Value.ToString();
						isOk = false;
						Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=" + strErrorMessage + "&backurl=0", true);
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

		private void Start()
		{
			string strCode = "11100";
			string strCanContnue = CanContinue("11100");
			if ((strCanContnue != "") && (strCanContnue.IndexOf("Warning:") == -1))
			{
				if (CreateEEAccount())
				{
					Response.Redirect("SelectApp.aspx");
					return;
				}
			}
			else if ((strCanContnue == "") || (strCanContnue.IndexOf("Warning:") != -1))
			{
				string strCanContnue2 = Set_Wizard_id_for_session(strCode);
				if (strCanContnue2 == "")
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Product_Code", strCode, Training_Source.TrainingClass.ConnectioString);
					if (strCanContnue == "")
					{
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Mandatory_Only", "F", Training_Source.TrainingClass.ConnectioString);
					}
					else
					{
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Mandatory_Only", "T", Training_Source.TrainingClass.ConnectioString);
					}
				}
				else
					ShowError(strCanContnue);
			}
			else
				ShowError(strCanContnue);
		}

		protected void btnBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("/web_projects/trn/PLA_Homes/Home1.aspx?SkipCheck=YES");
		}

        protected void lnkbtnAddBookRequest_Click(object sender, EventArgs e)
        {
            if (Training_Source.TrainingClass.HasPendingEvaluation(ViewState["Employee_Number"].ToString()))
                ShowError("You cannot add a new Book Training Request until you have completed the pending post-training evaluation form associated with another training request.  Please find the training request with the status “Pending Evaluation”, and use the Action Drop Down Item – Review Eval. – to complete your evaluation.  Afterwards, you may click on “Add New Training Request” to add new training request.");
            else
            {
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Request_Record_ID", "-1", conn);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "BookRequest", "1", conn);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "WIZARD_ID", "130",conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                Response.Redirect(First_step_in_wizard());
            }            
        }

        protected void btnPlaEligible_Click(object sender, EventArgs e)
        {
            SendEmail();
            Response.Redirect("/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES", true);
        }

        private void SendEmail()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", Request.Cookies["Session_ID"].Value.ToString()));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.email_not_eligible_pla", al);
        }

        protected void lnkbtnEESearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/Employee_Search/default.aspx?SkipCheck=YES&start='+txt+'&goto=/WEB_PROJECTS/TRN/PLA/SELECTAPP.ASPX?SkipCheck=YES", true);
        }

    

		
		
	}
}
