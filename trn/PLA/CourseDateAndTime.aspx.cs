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
	/// Summary description for PLA_Step3.
	/// </summary>
	public class CourseDateAndTime : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Label lblColor;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursDuty;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursNonDuty;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursTotal;
		protected System.Web.UI.WebControls.Label lbl_fldTrainingCourseDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected RJS.Web.WebControl.PopCalendar PopCalendar1;
		protected RJS.Web.WebControl.PopCalendar PopCalendar2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label lblRequiredSymbol;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.Label req8;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doSave;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
		protected System.Web.UI.WebControls.Label lblCourseStartDate;
		protected System.Web.UI.WebControls.Label lblCourseEndDate;
		protected System.Web.UI.WebControls.Label lblCourseHourDutey;
		protected System.Web.UI.WebControls.Label lblCourseHiursNonDuty;
		protected System.Web.UI.WebControls.Label lblCourseHourTotal;
		protected System.Web.UI.WebControls.HiddenField hidCommand;
		protected System.Web.UI.HtmlControls.HtmlInputButton htmbtnSave;
        protected System.Web.UI.WebControls.Button btnSave;
	
		private int FieldCounter=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
            
			lblScript.Text="";
			#region BasTemplate
			if (!IsPostBack)
			{				
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{					
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);					
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,true);
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
			        ViewState["Page_ID"]                        = objBasTemplate.strPageId;
					// Wizard
					string strpnlXML = objBasTemplate.PanelXML();
					if (strpnlXML!="")
					{
						if (strpnlXML.IndexOf("Error:") != -1)
						{
							Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strpnlXML,true);
							return;
						}
						ViewState["CurrGrp"]			= objBasTemplate.Wizard_Value("CurrGrp");
						ViewState["CurrGrpTtl"]			= objBasTemplate.Wizard_Value("CurrGrpTtl");
						ViewState["CurrGrpUrl"]			= objBasTemplate.Wizard_Value("CurrGrpUrl");
						ViewState["CurrStp"]			= objBasTemplate.Wizard_Value("CurrStp");
						ViewState["CurrStpTtl"]			= objBasTemplate.Wizard_Value("CurrStpTtl");
						ViewState["CurrStpUrl"]			= objBasTemplate.Wizard_Value("CurrStpUrl");
						ViewState["Is_Step_Completed"]	= objBasTemplate.Wizard_Value("Is_Step_Completed");
						ViewState["NextGrp"]			= objBasTemplate.Wizard_Value("NextGrp");
						ViewState["NextGrpTtl"]			= objBasTemplate.Wizard_Value("NextGrpTtl");
						ViewState["NextGrpUrl"]			= objBasTemplate.Wizard_Value("NextGrpUrl");
						ViewState["NextStp"]			= objBasTemplate.Wizard_Value("NextStp");
						ViewState["NextStpTtl"]			= objBasTemplate.Wizard_Value("NextStpTtl");
						ViewState["NextStpUrl"]			= objBasTemplate.Wizard_Value("NextStpUrl");
						ViewState["NoGrp"]				= objBasTemplate.Wizard_Value("NoGrp");
						ViewState["NoStpInGrp"]			= objBasTemplate.Wizard_Value("NoStpInGrp");
						ViewState["PrvGrp"]				= objBasTemplate.Wizard_Value("PrvGrp");
						ViewState["PrvGrpTtl"]			= objBasTemplate.Wizard_Value("PrvGrpTtl");
						ViewState["PrvGrpUrl"]			= objBasTemplate.Wizard_Value("PrvGrpUrl");
						ViewState["PrvStp"]				= objBasTemplate.Wizard_Value("PrvStp");  
						ViewState["PrvStpTtl"]			= objBasTemplate.Wizard_Value("PrvStpTtl");
						ViewState["PrvStpUrl"]			= objBasTemplate.Wizard_Value("PrvStpUrl");
					}					
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
            //Bas_Utility.Utilities.SetPageFields(Page, ViewState["Page_ID"].ToString());
			if ((hidCommand.Value != null) && (hidCommand.Value == "DoSave"))
			{
				hidCommand.Value = "";
				CheckSave();
				//if (CheckSave())
				//    Response.Redirect(Request.Path);
				return;
			}
			if (!IsPostBack)
			{
                btnSave.Attributes.Add("onclick", "Do_Save()");
				Training_Source.TrainingClass.SetValidators(Page);
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);
                //}
				this.LblTemplateHeader2.Text=Template.BasTemplate.Update_Header(this.LblTemplateHeader2.Text,"Edit Mode");
				
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["AppStatus"]=Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());
				SetHeaderInformation();	
				FillData();
				SetInView();
				object ob = SQLStatic.SQL.ExecScaler("select pkg_training.lastdateforapplications('"+ViewState["Account_Number"].ToString()+"') from dual",Training_Source.TrainingClass.ConnectioString);				 
				DateTime dtLimit ;
				if (ob == null) 
					dtLimit = Convert.ToDateTime(ob);
				else
					dtLimit = Convert.ToDateTime(ob);
				ob = null;
				PopCalendar1.To.Date = dtLimit;
				PopCalendar2.To.Date = dtLimit;
				HighLightKeyFields();
				lblScript.Text="<script>EnableNavigation()</script>";
				ProcessesStarFunctionality();
				if (txtStartDate.Text=="")
					Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				else
					Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),Convert.ToDateTime(txtStartDate.Text).Year.ToString());
				if (!Training_Source.TrainingClass.Use2008Types_Needs(ViewState["Request_Record_ID"].ToString()))
					ViewState["NextStpUrl"]="TrainingTypesAndNeeds.aspx";
				SetupWizardMenu();
			}
			if (!(Request.Form["doSave"] == null||Request.Form["doSave"] == ""))
			{
				string strGoTo = Request.Form["doSave"].Replace("'","");
				doSave.Value="";
				this.Validate();
				if(this.IsValid)
				{					
					SaveCourseDateTime();
					Response.Redirect(strGoTo);
				}
			}
			CheckHeaderIDSet();
			HandleContractors();
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
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void ShowError(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"ErrorMsg",strMsg,Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>popup('error.aspx',200,400)</script>";
		}

		private void HighLightKeyFields()
		{
			if (Convert.ToInt32(ViewState["AppStatus"].ToString())>1)
			{
				txtStartDate.BackColor = System.Drawing.Color.Cyan;
				txtEndDate.BackColor = System.Drawing.Color.Cyan;
				txtCourseHoursDuty.BackColor = System.Drawing.Color.Cyan;
				txtCourseHoursNonDuty.BackColor = System.Drawing.Color.Cyan;
				lblColor.Visible=true;
				lblInfo.Visible=true;
			}
		}

		private void SetInView()
		{
			string strInView = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView",Training_Source.TrainingClass.ConnectioString);
			
			if (strInView=="T")
			{
				this.LblTemplateHeader2.Text=Template.BasTemplate.Update_Header(this.LblTemplateHeader2.Text,"View Mode");
				txtStartDate.Enabled=false;
				txtEndDate.Enabled=false;
				txtCourseHoursDuty.Enabled=false;
				txtCourseHoursNonDuty.Enabled=false;
			}
		}
		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private string GetCourseDateTime_Record_Id()
		{
			return SQLStatic.SQL.ExecScaler("select PKG_Training.training_course_date_time("+ViewState["Request_Record_ID"].ToString()+") from dual",Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private void SetValue(TextBox txt,string strValue)
		{
			txt.Text=strValue;
			ViewState[txt.ID]=strValue;
			ViewState["id_"+FieldCounter]=txt.ID;
			FieldCounter++;
		}

		private void FillData()
		{
			string strCourseDateTime_id = GetCourseDateTime_Record_Id();
			if (strCourseDateTime_id=="-1")
			{
				SetValue(txtStartDate,"");
				SetValue(txtEndDate,"");				
				SetValue(txtCourseHoursDuty,"0");
				SetValue(txtCourseHoursNonDuty,"0");
				SetValue(txtCourseHoursTotal,"0");				
				return;
			}
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.gettrainingcoursedatetimerec",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_3_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				SetValue(txtStartDate, tbl.Rows[0]["course_start_date"].ToString());
				SetValue(txtEndDate, tbl.Rows[0]["course_end_date"].ToString());
				string strCourseTime = tbl.Rows[0]["course_time"].ToString();
				SetValue(txtCourseHoursDuty, tbl.Rows[0]["course_hours_duty"].ToString());
				SetValue(txtCourseHoursNonDuty, tbl.Rows[0]["course_hours_non_duty"].ToString());
				SetValue(txtCourseHoursTotal, tbl.Rows[0]["course_hours_total"].ToString());				
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
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Convert.ToDateTime(txtStartDate.Text).Year.ToString(),Training_Source.TrainingClass.ConnectioString);
		}
		
		private bool CanUseStartDate()
		{
			string strSQL="select basdba.PKG_Training.CanUseStartDate ('"+ViewState["Request_Record_ID"].ToString()+"','"+Convert.ToDateTime(txtStartDate.Text).Year.ToString()+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString() == "1";
		}

		private bool SaveCourseDateTime()
		{
            if (txtCourseHoursDuty.Text.Trim().Equals("0"))
                if (txtCourseHoursNonDuty.Text.Trim().Equals("0"))
                {
                    string stringHoursError = "<script> alert('Course Hours Total, can’t equal zero')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(),"stringHoursError",stringHoursError);
                    return false;
                }
			if (!CanUseStartDate())
			{
				string strMsg="You had selected Account# PLA (5632). You do not have an approved CDP for the selected Course Start Date"; 
				lblScript.Text = BASUSA.MiscTidBit.JSAlert(strMsg);
				return false;
			}
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.updatecoursedatetimerecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			
			try
			{
				DateTime datStart=Convert.ToDateTime(txtStartDate.Text);
				DateTime datEnd = Convert.ToDateTime(txtEndDate.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_start_date_","date","in",datStart);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_end_date_","date","in",datEnd);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_time_","varchar2","in","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_hours_duty_","number","in",txtCourseHoursDuty.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_hours_non_duty_","number","in",txtCourseHoursNonDuty.Text);				
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
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Convert.ToDateTime(txtStartDate.Text).Year.ToString(),Training_Source.TrainingClass.ConnectioString);
			return true;
		}

		

		

		private void lnkbtnSaveAndStay_Click(object sender, System.EventArgs e)
		{
//			DateTime datStart=Convert.ToDateTime(txtStartDate.Text);
//			DateTime datEnd = Convert.ToDateTime(txtEndDate.Text);
//			if (datEnd < datStart)
//				ShowError("End Date cannot be smaller than Begin Date");
//			else
			{
				if (SaveCourseDateTime())
				{
					lblScript.Text = "<script>popup('saved.aspx',200,400)</script>";
					SetButtonStatus(true);
				}
			}
		}	

		private bool DataChanged()
		{
			bool blnChanged = false;
			TextBox txt = null;
			DropDownList ddl = null;
			string fldId="";
			for (int i=0;i<=100;i++)
			{
				if (ViewState["id_"+i.ToString()]!=null)
				{
					fldId=ViewState["id_"+i.ToString()].ToString();
					if (fldId.IndexOf("txt")==0)
					{
						txt = (TextBox)Page.FindControl(fldId);
						if (txt != null)
						{
							blnChanged = txt.Text!=ViewState[fldId].ToString();
							if (blnChanged)
								break;
						}
					}
					else
					{
						ddl = (DropDownList)Page.FindControl(fldId);
						if (ddl != null)
						{
							blnChanged = ddl.SelectedValue!=ViewState[fldId].ToString();
							if (blnChanged)
								break;
						}
					}
				}
			}
			return blnChanged;
		}

		private void lnkbtnCancel_Click(object sender, System.EventArgs e)
		{
			FillData();
			SetButtonStatus(true);
		}

		private void btnSaveNext_Click(object sender, System.EventArgs e)
		{
			DateTime datStart=Convert.ToDateTime(txtStartDate.Text);
			DateTime datEnd = Convert.ToDateTime(txtEndDate.Text);
			if (datEnd < datStart)
				ShowError("End Date cannot be larger than Begin Date");
			else
			{
				if (SaveCourseDateTime())
					Response.Redirect(ViewState["NextStpUrl"].ToString());
			}
			
		}

		private void btnSaveBack_Click(object sender, System.EventArgs e)
		{
			DateTime datStart=Convert.ToDateTime(txtStartDate.Text);
			DateTime datEnd = Convert.ToDateTime(txtEndDate.Text);
			if (datEnd < datStart)
				ShowError("End Date cannot be larger than Begin Date");
			else
			{
				if (SaveCourseDateTime())
				{
					if (ViewState["PrvStpUrl"].ToString()=="")	
						Response.Redirect("SelectApp.aspx");
					else
						Response.Redirect(ViewState["PrvStpUrl"].ToString());
				}
			}
			
		}

		private void lnkbtnSaveNext_Click(object sender, System.EventArgs e)
		{			

			{
				if (SaveCourseDateTime())
					Response.Redirect(ViewState["NextStpUrl"].ToString());
			}
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
			{
                if (txtCourseHoursDuty.Text.Trim().Equals("0"))
                    if (txtCourseHoursNonDuty.Text.Trim().Equals("0"))
                    {
                        Response.Redirect("SelectApp.aspx", true);
                        return;
                    }
				Training_Source.TrainingClass.RegisterWarning(Page,"'SelectApp.aspx'");
				return;
			}	
			Response.Redirect("SelectApp.aspx",true);
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
			{
                if (txtCourseHoursDuty.Text.Trim().Equals("0"))
                    if (txtCourseHoursNonDuty.Text.Trim().Equals("0"))
                    {
                        string stringHoursError = "<script> alert('Course Hours Total, can’t equal zero')</script>";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringHoursError", stringHoursError);
                        return;
                    }
				Training_Source.TrainingClass.RegisterWarning(Page,"'"+ViewState["PrvStpUrl"].ToString()+"'");
				return;
			}	
			else	
				Response.Redirect(ViewState["PrvStpUrl"].ToString());
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{            
			if (DataChanged())
			{
                if (txtCourseHoursDuty.Text.Trim().Equals("0"))
                    if (txtCourseHoursNonDuty.Text.Trim().Equals("0"))
                    {
                        string stringHoursError = "<script> alert('Course Hours Total, can’t equal zero')</script>";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringHoursError", stringHoursError);
                        return;
                    }
				Training_Source.TrainingClass.RegisterWarning(Page,"'"+ViewState["NextStpUrl"].ToString()+"'");
				return;
			}	
			else
				Response.Redirect(ViewState["NextStpUrl"].ToString());
		}

		private void SetButtonStatus(bool blnEnabled)
		{			
//			pnlNav.Enabled=blnEnabled;
//			pnlAction.Enabled =!blnEnabled;
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Employee_Number"].ToString());

		}
		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			Training_Source.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());		
			PopCalendar1.Enabled = false;
			PopCalendar2.Enabled = false;
			btnHome.Enabled = true;
			btnNext.Enabled = true;
			btnBack.Enabled = true;
			htmbtnSave.Disabled = true;
			ddlBudgetYear.Enabled	= true;
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			FillData();
			SetButtonStatus(true);
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


		private bool CheckSave()
		{
			Validate();
			if (!IsValid)
				return false;
			if (SaveCourseDateTime())
			{
				FillData();
				SetButtonStatus(true);
                SetupNextButton();
				SetupWizardMenu();
				lblScript.Text = "<script>alert('Data Saved Successfully')</script>";
				return true;
			}
			return false;
		}

        protected void vtnSave_Click(object sender, EventArgs e)
        {
            CheckSave();
        }

	}
}
