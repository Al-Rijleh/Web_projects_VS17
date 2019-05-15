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
	/// Summary description for TrainingExpenses.
	/// </summary>
	public class TrainingExpenses : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lbl_fldTrainingExpenses;
		protected System.Web.UI.WebControls.LinkButton lnkBtnNoExpense;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAddNewExpense;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doSave;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnHome;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
		protected System.Web.UI.WebControls.Label lblNoteMark;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label Label1;
		protected BASUSA.MiscTidBit misc = new BASUSA.MiscTidBit();
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text="";            
            if (Request.Params["Admin"] != "YES")
            {
                #region BasTemplate
                if (!IsPostBack)
                {
                    Template.BasTemplate objBasTemplate = new Template.BasTemplate();
                    try
                    {
                        if (Request.Cookies["Session_ID"] == null)
                            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", true);
                        string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, true);
                        if (strResult != "")
                        {
                            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult, false);
                            return;
                        }
                        objBasTemplate.SetSeatchField(0);
                        objBasTemplate.ShowNotes = false;
                        LblTemplateHeader2.Text = objBasTemplate.Header2();
                        ViewState["AccessType"] = objBasTemplate.strAccessType;
                        ViewState["Employee_Number"] = objBasTemplate.strEmployee_Number;
                        ViewState["Processing_Year"] = objBasTemplate.strProcessingYear;
                        ViewState["Role_Restriction_Level"] = objBasTemplate.strRole_Restriction_Level;
                        ViewState["Selected_Account_Number"] = objBasTemplate.strSelected_Account_Number;
                        ViewState["Selected_Employee_Class_Code"] = objBasTemplate.strSelected_Employee_Class_Code;
                        ViewState["User_Group_ID"] = objBasTemplate.strUser_Group_ID;
                        ViewState["User_ID"] = objBasTemplate.strUser_ID;
                        ViewState["User_Name"] = objBasTemplate.strUser_Name;
                        ViewState["User_Primary_Role"] = objBasTemplate.strUser_Primary_Role;
                        // Wizard
                        string strpnlXML = objBasTemplate.PanelXML();
                        if (strpnlXML != "")
                        {
                            if (strpnlXML.IndexOf("Error:") != -1)
                            {
                                Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strpnlXML, true);
                                return;
                            }
                            ViewState["CurrGrp"] = objBasTemplate.Wizard_Value("CurrGrp");
                            ViewState["CurrGrpTtl"] = objBasTemplate.Wizard_Value("CurrGrpTtl");
                            ViewState["CurrGrpUrl"] = objBasTemplate.Wizard_Value("CurrGrpUrl");
                            ViewState["CurrStp"] = objBasTemplate.Wizard_Value("CurrStp");
                            ViewState["CurrStpTtl"] = objBasTemplate.Wizard_Value("CurrStpTtl");
                            ViewState["CurrStpUrl"] = objBasTemplate.Wizard_Value("CurrStpUrl");
                            ViewState["Is_Step_Completed"] = objBasTemplate.Wizard_Value("Is_Step_Completed");
                            ViewState["NextGrp"] = objBasTemplate.Wizard_Value("NextGrp");
                            ViewState["NextGrpTtl"] = objBasTemplate.Wizard_Value("NextGrpTtl");
                            ViewState["NextGrpUrl"] = objBasTemplate.Wizard_Value("NextGrpUrl");
                            ViewState["NextStp"] = objBasTemplate.Wizard_Value("NextStp");
                            ViewState["NextStpTtl"] = objBasTemplate.Wizard_Value("NextStpTtl");
                            ViewState["NextStpUrl"] = objBasTemplate.Wizard_Value("NextStpUrl");
                            ViewState["NoGrp"] = objBasTemplate.Wizard_Value("NoGrp");
                            ViewState["NoStpInGrp"] = objBasTemplate.Wizard_Value("NoStpInGrp");
                            ViewState["PrvGrp"] = objBasTemplate.Wizard_Value("PrvGrp");
                            ViewState["PrvGrpTtl"] = objBasTemplate.Wizard_Value("PrvGrpTtl");
                            ViewState["PrvGrpUrl"] = objBasTemplate.Wizard_Value("PrvGrpUrl");
                            ViewState["PrvStp"] = objBasTemplate.Wizard_Value("PrvStp");
                            ViewState["PrvStpTtl"] = objBasTemplate.Wizard_Value("PrvStpTtl");
                            ViewState["PrvStpUrl"] = objBasTemplate.Wizard_Value("PrvStpUrl");
                        }
                    }
                    catch (Exception ex)
                    {
                        string strError = "Error Message: " + ex.Message + "~~Application:" + ex.Source + "~~Method:" + ex.TargetSite + "~~Detail:" + ex.StackTrace;
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strError.Replace("\n", "~"));
                    }
                    finally
                    {
                        objBasTemplate.CleanUp();
                        objBasTemplate.Dispose();
                    }
                }
                #endregion
            }
            else
            {
                #region BasTemplate
                if (!IsPostBack)
                {
                    
                    Template.BasTemplate objBasTemplate = new Template.BasTemplate();
                    try
                    {
                        if (Request.Cookies["Session_ID"] == null)
                            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", true);
                        string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, false);
                        if (strResult != "")
                        {
                            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult, false);
                            return;
                        }
                        objBasTemplate.SetSeatchField(0);
                        objBasTemplate.ShowNotes = false;
                        LblTemplateHeader2.Text = objBasTemplate.Header2();
                        ViewState["AccessType"] = objBasTemplate.strAccessType;
                        ViewState["Employee_Number"] = objBasTemplate.strEmployee_Number;
                        ViewState["Processing_Year"] = objBasTemplate.strProcessingYear;
                        ViewState["Role_Restriction_Level"] = objBasTemplate.strRole_Restriction_Level;
                        ViewState["Selected_Account_Number"] = objBasTemplate.strSelected_Account_Number;
                        ViewState["Selected_Employee_Class_Code"] = objBasTemplate.strSelected_Employee_Class_Code;
                        ViewState["User_Group_ID"] = objBasTemplate.strUser_Group_ID;
                        ViewState["User_ID"] = objBasTemplate.strUser_ID;
                        ViewState["User_Name"] = objBasTemplate.strUser_Name;
                        ViewState["User_Primary_Role"] = objBasTemplate.strUser_Primary_Role;

                        // setup header information. You need to add the "2nd" and "3rd" parmeter.					
                    }
                    catch (Exception ex)
                    {
                        string strError = "Error Message: " + ex.Message + "~~Application:" + ex.Source + "~~Method:" + ex.TargetSite + "~~Detail:" + ex.StackTrace;
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strError.Replace("\n", "~"));
                    }
                    finally
                    {
                        objBasTemplate.CleanUp();
                        objBasTemplate.Dispose();
                    }
                }
                #endregion
                btnHome.Visible = false;
                btnNext.Visible = false;
            }
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
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();	
				SetInView();
				ProcessesStarFunctionality();
				string strProcessingYear = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Training_Source.TrainingClass.ConnectioString);
                if (strProcessingYear == "")
                    strProcessingYear = ViewState["Processing_Year"].ToString();
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strProcessingYear);
				if (!Training_Source.TrainingClass.Use2008Types_Needs(ViewState["Request_Record_ID"].ToString()))
					ViewState["PrvStpUrl"]="TrainingTypesAndNeeds.aspx";
                if (Request.Params["Admin"] != "YES")
				    SetupWizardMenu();
			}
			DrawGrid();
			CheckHeaderIDSet();
			HandleContractors();
			if (!(Request.Form["doSave"] == null||Request.Form["doSave"] == ""))
			{								
				DoDelete();
				doSave.Value="";
				DrawGrid();
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
			this.ddlBudgetYear.SelectedIndexChanged += new System.EventHandler(this.ddlBudgetYear_SelectedIndexChanged);
			this.lnkbtnAddNewExpense.Click += new System.EventHandler(this.lnkbtnAddNewExpense_Click);
			this.lnkBtnNoExpense.Click += new System.EventHandler(this.lnkBtnNoExpense_Click);
			this.dgExpense.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgExpense_ItemCreated);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void  SetupNextButton()
		{
			string strIncomplatePages=
				SQLStatic.SQL.ExecScaler("select pkg_training.incompletepages("+ViewState["Request_Record_ID"].ToString()+")from dual").ToString();
			btnNext.Visible = Training_Source.TrainingClass.PageCompleted(Request.Path,strIncomplatePages);
		}

		private void CheckHeaderIDSet()
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				lblScript.Text="<script>alert('Vendor Information page must be completed first');window.location.href='TrainingVendorInfo.aspx';</script>";
			}
		}

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>popup('error.aspx',200,400)</script>";
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void SetInView()
		{
			ViewState["strInView"]="F";
			string strInView = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView",Training_Source.TrainingClass.ConnectioString);
			string strEditExse = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Expense",Training_Source.TrainingClass.ConnectioString);
				
			if ((strInView=="T")&&(strEditExse!="T"))
			{
				ViewState["strInView"]="T";
				this.LblTemplateHeader2.Text=Template.BasTemplate.Update_Header(this.LblTemplateHeader2.Text,"View Mode");
				lnkbtnAddNewExpense.Enabled = false;
				btnNext.Enabled = false;
			}
			if (strEditExse=="T")
				btnNext.Enabled = false;
		}

		private void SetHeaderInformation()
		{
            
            ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
            string strLine1 = SQLStatic.AccountData.AccountName(ViewState["Account_Number"].ToString()) + "&nbsp;(" + ViewState["Account_Number"].ToString() + ")";
            string strLine2 = SQLStatic.EmployeeData.EmployeeNameHeader(ViewState["Employee_Number"].ToString());
            Bas_Utility.Utilities.SetHeaderFrame(this.Page, strLine1,strLine2);
            //string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}	

		private string GetTotalExpense()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="")
				strResult = "0";
			return Convert.ToDouble(strResult).ToString("$#,###.00");
		}

		private DataTable GetExpenseTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetEmployeeExpenses",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Expenses_List_","cursor","out","");

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
			DataTable dt= GetExpenseTable();
			if (dt.Rows.Count==0)
			{
//				lblAddNewExpense.Text = misc.Lunch_Page("Add New Expense","AddEditExpense.aspx?expid=-1","addexp",750,500,20,10);
//				lblAddNewExpense.Enabled = true;
				lnkbtnAddNewExpense.Enabled = true;
				lnkBtnNoExpense.Enabled = true;
			}
			dgExpense.DataSource = dt;
			dgExpense.DataBind();
			lblAmount.Text = GetTotalExpense();
		}

		private void dgExpense_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgExpense.DataSource;
					string strindex = tbl.Rows[indx]["record_id"].ToString();



					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="fontsmall";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(120);
					ddl.ID = "ddl_"+strindex;	
					
					if (tbl.Rows[indx]["expense_type_id"].ToString()=="2000")
					{   ListItem li;
						li = new ListItem("Delete","1");
//						lblAddNewExpense.Text = "Add New Expense";
//						lblAddNewExpense.Enabled = false;
						lnkbtnAddNewExpense.Enabled = false;
						lnkBtnNoExpense.Enabled = false;
						ddl.Items.Add(li);
					}
					else
					{
						ListItem li0 = new ListItem("Edit","0");
						ddl.Items.Add(li0);
						ListItem li1 = new ListItem("Delete","1");
						ddl.Items.Add(li1);
//						lblAddNewExpense.Text = misc.Lunch_Page("Add New Expense","AddEditExpense.aspx?expid=-1","addexp",750,500,20,10);
//						lblAddNewExpense.Enabled = true;
						lnkbtnAddNewExpense.Enabled = true;
						lnkBtnNoExpense.Enabled = true;
					}
					
										
					// create button
					Button btn2 = new Button();
					btn2.CssClass = "actbtn_go_next_button";
					btn2.ID="btn_"+strindex;
					btn2.Text = "Go";
				
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[7];
					if (ViewState["strInView"].ToString() == "T")
					{
						ddl.Enabled = false;
						btn2.Enabled = false;
						cell.Controls.Add(ddl);
					}
					else
					{
						cell.Controls.Add(ddl);
						cell.Controls.Add(btn2);
					}
				}
				catch
				{
				}
			}
		}

		private void btnNote_Click(object sender, System.EventArgs e)
		{
			string strIndex = ((Button)sender).ID.Substring(4);
			lblScript.Text="<script>popup('ViewEditNote.aspx?rid="+strIndex+"',500,600)</script>";
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

		private string ExpenseType(string strIndex)
		{
			DataTable tbl = (DataTable)dgExpense.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString() == strIndex)
					return dr["expense_type"].ToString();
			}
			return "";
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string strindex = ((Button)sender).ID.Substring(4);
			

			DropDownList ddl = GetDropDown(this,"ddl_"+strindex);
			if (ddl.SelectedValue=="0")
			{
				string strUrl = "AddEditExpense.aspx?expid="+strindex+"&Admin="+Request.Params["Admin"];
				Response.Redirect(strUrl);
//				lblScript.Text = "<script>popup('"+strUrl+"',550,750)</script>";
			}
			else
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"deleteIndex",strindex,Training_Source.TrainingClass.ConnectioString);
				string strWarning="<script>javascript:CheckDelete('"+ExpenseType(strindex)+"')</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"strWarning",strWarning);
				
			//	lblScript.Text = "<script>popup('Warning.aspx?d=l&type="+ExpenseType(strindex)+"',200,420)</script>";
			}
		}
		
		

		

		private void lnkBtnNoExpense_Click(object sender, System.EventArgs e)
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.AddFDICNoExpnsForTrn",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				conn.Open();
				cmd.ExecuteNonQuery();
				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			DrawGrid();
		}

		private void DoDelete()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
			{
                string strProcedure="basdba.PKG_Training.deleteExpense";
                if (Request.Params["Admin"]=="YES")
                    strProcedure="basdba.PKG_Training.deleteExpense_Admin";
				string strIndex = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"deleteIndex",Training_Source.TrainingClass.ConnectioString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"deleteIndex","",Training_Source.TrainingClass.ConnectioString);
				Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedure, conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;			
				try
				{
					SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",strIndex);
					SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
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
		}

		private void lnkbtnAddNewExpense_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AddEditExpense.aspx?expid=-1&Admin="+Request.Params["Admin"]);
//			lblScript.Text = "<script>popup('AddEditExpense.aspx?expid=-1',550,750);</script>";
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Employee_Number"].ToString());
		}
		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			lnkBtnNoExpense.Enabled=false;		
			btnNext.Enabled = true;
			btnBack.Enabled = true;
			ddlBudgetYear.Enabled	= true;
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SelectApp.aspx",true);
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
            if (Request.Params["Admin"] != "YES")
                Response.Redirect(ViewState["PrvStpUrl"].ToString());
            else
                Response.Redirect("/web_projects/trn/Data_maintnance/Default.aspx?SkipCheck=YES", true);
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(ViewState["NextStpUrl"].ToString());
		}

		private void SetupWizardMenu()
		{
			string retResult = "";
			string xml=Training_Source.TrainingClass.WizardMenuXML(Request.Cookies["Session_ID"].Value.ToString(),Request.Path,ViewState["Request_Record_ID"].ToString(),ref retResult);
			if (retResult!="")
			{
				lblWizardError.Text = retResult;
				return;
			}
			UltimateMenu1.MenuSourceXml =xml;
			UltimateMenu1.DataBind();
			SetupNextButton();
		}

	}
}
