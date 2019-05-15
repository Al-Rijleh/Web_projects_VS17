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

namespace Training_Source
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class TrainingVendorInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label lblColor;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label lbl_fldTrainingVendor;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.TextBox txtRemaining;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator13;
		protected System.Web.UI.WebControls.TextBox txtDescribtion;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtVendorContact;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtCourseTitle;
		protected System.Web.UI.WebControls.TextBox txtCourseCode;
		protected System.Web.UI.WebControls.Label req8;
		protected System.Web.UI.WebControls.Label req16;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.Label req100;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.Label req101;
		protected System.Web.UI.WebControls.Label Label42;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.Label Label44;		
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label req106;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator9;
		protected System.Web.UI.WebControls.Label req105;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator10;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label52;
		protected System.Web.UI.WebControls.CheckBox cbSameAddress;
		protected System.Web.UI.WebControls.TextBox txtLearningZipCode;
		protected System.Web.UI.WebControls.Label lblLearningZipCode;
		protected System.Web.UI.WebControls.DropDownList ddlLearningState;
		protected System.Web.UI.WebControls.TextBox txtLearningCity;
		protected System.Web.UI.WebControls.Label lblLearningCityState;
		protected System.Web.UI.WebControls.Label lblLearningAddress2;
		protected System.Web.UI.WebControls.TextBox txtLearningAddress1;
		protected System.Web.UI.WebControls.Label lblLearningAddress1;
		protected System.Web.UI.WebControls.TextBox txtLearningAddress2;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doSave;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.Label lblRequiredSymbol;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator11;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
		protected System.Web.UI.WebControls.Label lblEnail;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator12;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator5;
		protected System.Web.UI.WebControls.Label lblrainingEventCode;
		protected System.Web.UI.WebControls.Label lblTrainingEvent;
		protected System.Web.UI.WebControls.Label lblVendorName;
		protected System.Web.UI.WebControls.Label lblVendorContact;
		protected System.Web.UI.WebControls.Label lblVendorPhoneFax;
		protected System.Web.UI.WebControls.Label lblAddress1;
		protected System.Web.UI.WebControls.Label lblAddress2;
		protected System.Web.UI.WebControls.Label lblCityState;
		protected System.Web.UI.WebControls.Label lblZipCode;
		protected System.Web.UI.WebControls.Label lblWebSite;
		protected System.Web.UI.WebControls.Label lblPurposeofTraining;
		protected System.Web.UI.WebControls.HiddenField hidCommand;
		protected System.Web.UI.HtmlControls.HtmlInputButton htmbtnSave;
		protected System.Web.UI.WebControls.Label lblPhoneFormat;
		protected System.Web.UI.WebControls.Label lblCountry;
		protected System.Web.UI.WebControls.DropDownList ddlContries;
		protected System.Web.UI.WebControls.TextBox txtProvince;
		protected System.Web.UI.WebControls.Label req102;
		protected System.Web.UI.WebControls.Label req103;
		protected System.Web.UI.WebControls.DropDownList ddlTrainingContries;
		protected System.Web.UI.WebControls.Label req104;
		protected System.Web.UI.WebControls.TextBox txtLearningProvince;

		private int FieldCounter=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
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
 
			if ((hidCommand.Value != null) && (hidCommand.Value == "DoSave"))
			{
				hidCommand.Value = "";

				CheckSave();
				return;
			}
			lblScript.Text = "";
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
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				SetHeaderInformation();
				FillSatesDropDown();
				FillContries();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["AppStatus"]=Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",Training_Source.TrainingClass.ConnectioString);
				FillData();				
				SetInView();
				HighLightKeyFields();
				lblScript.Text="<script>EnableNavigation()</script>";
				ProcessesStarFunctionality();
				SetupWizardMenu();
				if (ViewState["Request_Record_ID"].ToString()=="-1")
				{
					string strAlert="<script>alert('REMINDER: This is a reminder to employees whose training request might involve travel – you must include your estimated travel expenses in the expense page of the training request – although it will NOT deduct from your PLA funds.')</script>";
					Page.ClientScript.RegisterStartupScript(Page.GetType(),"strAlert",strAlert);
				}
			}
			if (!(Request.Form["doSave"] == null||Request.Form["doSave"] == ""))
			{
				string strGoTo = Request.Form["doSave"].Replace("'","");
				doSave.Value="";
				this.Validate();
				if(this.IsValid)
				{
					DoSave();
					Response.Redirect(strGoTo);
				}
			}
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
			this.cbSameAddress.CheckedChanged += new System.EventHandler(this.cbSameAddress_CheckedChanged);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void  SetupNextButton()
		{
			btnNext.Enabled = ViewState["Request_Record_ID"].ToString()!="-1";			
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
				txtCourseTitle.BackColor = System.Drawing.Color.Cyan;
				lblColor.Visible=true;
				lblInfo.Visible=true;
			}
		}

		private void SetInView()
		{
			string strInView = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView",Training_Source.TrainingClass.ConnectioString);
			
			if (strInView=="T")
			{
				txtCourseCode.Enabled =false;
				txtCourseTitle.Enabled=false;
				txtVedorName.Enabled = false;
				txtPhoneNumber.Enabled=false;
				txtFaxNumber.Enabled=false;
				txtAddressLine1.Enabled=false;
				txtAddressLine2.Enabled=false;
				txtCity.Enabled=false;
				ddlStates.Enabled=false;
				txtZipCode.Enabled=false;
				txtDescribtion.Enabled=false;
				txtWebSite.Enabled=false;
				txtEmail.Enabled=false;
				txtVendorContact.Enabled=false;
				btnReset.Enabled=false;				
			}			
		}

		

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}	

		private void FillSatesDropDown()
		{
			DataTable dtStates = SQLStatic.CD_Tables.States(Training_Source.TrainingClass.ConnectioString);
			try
			{
				ListItem li0 = new ListItem("--Select--","x");
				ddlStates.Items.Add(li0);
				foreach (DataRow dr in dtStates.Rows)
				{
					ListItem li = new ListItem(dr["state_description"].ToString(),dr["state"].ToString());
					ddlStates.Items.Add(li);
				}
			}
			finally
			{
				if (dtStates != null)
					dtStates.Dispose();
			}
			foreach(ListItem li in ddlStates.Items)
			{
				ListItem li0 = new ListItem(li.Text,li.Value);
				ddlLearningState.Items.Add(li0);
			}
		}

		private void FillContries()
		{
			DataTable dtCounty = SQLStatic.CD_Tables.Countries();
			foreach (DataRow dr in dtCounty.Rows)
			{
				ListItem li = new ListItem(dr["name"].ToString(), dr["code"].ToString());
				ddlContries.Items.Add(li);
				ListItem li0 = new ListItem(dr["name"].ToString(), dr["code"].ToString());
				ddlTrainingContries.Items.Add(li0);
			}
		}

		private void SetValue(TextBox txt,string strValue)
		{
			txt.Text=strValue;
			ViewState[txt.ID]=strValue;
			ViewState["id_"+FieldCounter]=txt.ID;
			FieldCounter++;
		}

		private void SetValue(DropDownList ddl, string strValue)
		{
			foreach(ListItem li in ddl.Items)
			{
				li.Selected = (li.Value == strValue);
				if (li.Selected)
				{
					ViewState[ddl.ID]=strValue;
					ViewState["id_"+FieldCounter]=ddl.ID;
					FieldCounter++;
					break;
				}
			}
		}

		private void FillData()
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				txtCourseCode.Text = "";
				txtCourseTitle.Text = "";
				txtVedorName.Text = "";
				txtPhoneNumber.Text = "";
				txtFaxNumber.Text = "";
				txtAddressLine1.Text = "";
				txtAddressLine2.Text = "";
				txtCity.Text = "";
				ddlStates.SelectedIndex = 0;
				txtZipCode.Text = "";
				txtWebSite.Text = "";
				txtEmail.Text = "";
				txtDescribtion.Text = "";
				txtProvince.Text = "";
				txtLearningProvince.Text = "";
				SetValue(ddlContries, "USA");
				SetValue(ddlTrainingContries, "USA");
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",ViewState["Processing_Year"].ToString(),Training_Source.TrainingClass.ConnectioString);
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ddlContries_SelectedIndexChanged(null, null);
				ddlTrainingContries_SelectedIndexChanged(null, null);
				return;
			}
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.GetHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			string strPY = "";
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				SetValue(txtCourseCode, tbl.Rows[0]["course_code"].ToString());
				SetValue(txtCourseTitle, tbl.Rows[0]["course_title"].ToString());
				SetValue(txtVedorName, tbl.Rows[0]["vendor_name"].ToString());
				SetValue(txtVendorContact, tbl.Rows[0]["vendor_contact"].ToString());
				SetValue(txtPhoneNumber, tbl.Rows[0]["vendor_phone_number"].ToString());
				SetValue(txtFaxNumber, tbl.Rows[0]["vendor_fax_number"].ToString());
				SetValue(txtAddressLine1, tbl.Rows[0]["vendor_address1"].ToString());
				SetValue(txtAddressLine2, tbl.Rows[0]["vendor_address2"].ToString());
				SetValue(txtCity, tbl.Rows[0]["vendor_city"].ToString());
				SetValue(ddlStates, tbl.Rows[0]["vendor_state"].ToString());
				SetValue(txtZipCode, tbl.Rows[0]["vendor_zip_code"].ToString());
				SetValue(txtWebSite, tbl.Rows[0]["vendor_website"].ToString());
				SetValue(txtEmail, tbl.Rows[0]["vendor_email"].ToString());
				SetValue(txtDescribtion, tbl.Rows[0]["desription_of_course_value"].ToString());
				SetValue(txtLearningAddress1, tbl.Rows[0]["training_address1"].ToString());
				SetValue(txtLearningAddress2, tbl.Rows[0]["training_address2"].ToString());
				SetValue(txtLearningCity, tbl.Rows[0]["training_city"].ToString());
				SetValue(txtProvince, tbl.Rows[0]["province"].ToString());
				SetValue(ddlLearningState, tbl.Rows[0]["training_state"].ToString());
				SetValue(ddlContries, tbl.Rows[0]["country_code"].ToString());
				SetValue(ddlTrainingContries, tbl.Rows[0]["training_country_code"].ToString());
				SetValue(txtLearningZipCode, tbl.Rows[0]["training_zip"].ToString());
				SetValue(txtLearningProvince, tbl.Rows[0]["training_province"].ToString());
				ViewState["application_status"]= tbl.Rows[0]["application_status"].ToString();
				ViewState["description"]=tbl.Rows[0]["description"].ToString();
				strPY = tbl.Rows[0]["processing_year"].ToString();
				
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
			txtRemaining.Text = (4000-txtDescribtion.Text.Length).ToString();
			if (txtCourseCode.Text != "")
				lblCourseTitle.Text= txtCourseCode.Text+" - "+txtCourseTitle.Text;
			else
				lblCourseTitle.Text= txtCourseTitle.Text;
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",strPY,Training_Source.TrainingClass.ConnectioString);
			Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strPY);
			ddlContries_SelectedIndexChanged(null, null);
			ddlTrainingContries_SelectedIndexChanged(null, null);
		}

		private void SaveData ()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.SaveUpdateHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Product_Code_","number","in",ViewState["Product_Code"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"employee_number_","number","in",ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"processing_year_","varchar2","in",ViewState["Processing_Year"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_code_","varchar2","in",txtCourseCode.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"course_title_","varchar2","in",txtCourseTitle.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_name_","varchar2","in",txtVedorName.Text);				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_contact_","varchar2","in",txtVendorContact.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_address1_","varchar2","in",txtAddressLine1.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_address2_","varchar2","in",txtAddressLine2.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_city_","varchar2","in",txtCity.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_state_","varchar2","in",ddlStates.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_zip_code_","varchar2","in",txtZipCode.Text);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_phone_number_","varchar2","in",txtPhoneNumber.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_fax_number_","varchar2","in",txtFaxNumber.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_website_","varchar2","in",txtWebSite.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_email_","varchar2","in",txtEmail.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"desription_of_course_value_","varchar2","in",txtDescribtion.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"location_of_training_","varchar2","in","");

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_address1_","varchar2","in",txtLearningAddress1.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_address2_","varchar2","in",txtLearningAddress2.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_city_","varchar2","in",txtLearningCity.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_state_","varchar2","in",ddlLearningState.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_zip_","varchar2","in",txtLearningZipCode.Text);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"country_code_",ddlContries.SelectedValue);         
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"province_",txtProvince.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_province_",txtLearningProvince.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_country_code_", ddlTrainingContries.SelectedValue);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				conn.Open();
				cmd.ExecuteNonQuery();
				ViewState["Request_Record_ID"]=cmd.Parameters["new_record_id_"].Value;
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",ViewState["Request_Record_ID"].ToString(),Training_Source.TrainingClass.ConnectioString);
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}

		private bool CourseCodeExists()
		{
			string strSQL = "select pkg_training.CourseCodeExist("+ViewState["Employee_Number"].ToString()+","+ViewState["Processing_Year"]+",'"+txtCourseCode.Text.Replace("'","''")+"','"+txtCourseTitle.Text.Replace("'","''")+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString()=="T";
		}
	

		private void lnkbtnBack_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
				lblScript.Text = "<script>popup('Warning.aspx?d=b',200,400)</script>";
			else if (ViewState["PrvStpUrl"].ToString()=="")	
                Response.Redirect("SelectApp.aspx");
			else
				Response.Redirect(ViewState["PrvStpUrl"].ToString());			   
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

		private void ddlStates_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetButtonStatus(false);
		}

		private void SetButtonStatus(bool blnEnabled)
		{	
//			pnlNav.Enabled=blnEnabled;
//			pnlAction.Enabled =!blnEnabled;
		}

		private void btnSaveandBack_Click(object sender, System.EventArgs e)
		{
			Validate();
			if (!IsValid)
				return;
			if (DoSave())
			{
				if (ViewState["PrvStpUrl"].ToString()=="")	
					Response.Redirect("SelectApp.aspx");
				else
					Response.Redirect(ViewState["PrvStpUrl"].ToString());
			}
		}

		private bool DoSave()
		{
			if ((ViewState["Request_Record_ID"].ToString()=="-1")&&CourseCodeExists())
			{
				ShowError("You already have a course with the same Training Event Code and Title");
				return false;
			}
			else
			{
				SaveData();
				lblScript.Text = "<script>alert('Data Saved Successfully')</script>";
				FillData();				
				SetButtonStatus(true);
				return true;
			}
		}
	

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			FillData();
			SetButtonStatus(true);
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				Response.Redirect("SelectApp.aspx",true);
			}		
			if (DataChanged())
			{
				RegisterWarning("'SelectApp.aspx'");
				return;
			}	
			Response.Redirect("SelectApp.aspx");			
			
		}

		private void RegisterWarning(string strURL)
		{
			string strWarning="<script>javascript:CheckSave("+strURL+")</script>";
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"strWarning",strWarning);
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{			
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				if (ViewState["PrvStpUrl"].ToString()=="")	
					Response.Redirect("SelectApp.aspx");
				else
					Response.Redirect(ViewState["PrvStpUrl"].ToString());
				return;
			}
			string strBackurl = ViewState["PrvStpUrl"].ToString();
			if (strBackurl=="")
				strBackurl = "SelectApp.aspx";
			if (DataChanged())
			{
				RegisterWarning("'"+strBackurl+"'");
				return;
			}			
			Response.Redirect(strBackurl);
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{		
			if (DataChanged())
			{
				RegisterWarning("'"+ViewState["NextStpUrl"].ToString()+"'");
				return;
			}				
			else	
				Response.Redirect(ViewState["NextStpUrl"].ToString());
				
		}

		private void btnSaveandNext_Click(object sender, System.EventArgs e)
		{

			if (DoSave())
				lblScript.Text = "<script>window.location.href='"+ViewState["NextStpUrl"].ToString()+"'</script>";
				//Response.Redirect(ViewState["NextStpUrl"].ToString());
		}

		private bool CheckSave()
		{
			Validate();
			if (!IsValid)
				return false;
			if (DoSave())
			{
				SetupWizardMenu();
				return true;
			}
			return false;
		}

		private void btnSaveNext_Click(object sender, System.EventArgs e)
		{
			Validate();
			if (!IsValid)
				return;
			if (DoSave())
				Response.Redirect(ViewState["NextStpUrl"].ToString());
		}

		private void btnSaveBack_Click(object sender, System.EventArgs e)
		{
			Validate();
			if (!IsValid)
				return;
			if (DoSave())
			{
				if (ViewState["PrvStpUrl"].ToString()=="")	
					Response.Redirect("SelectApp.aspx");
				else
					Response.Redirect(ViewState["PrvStpUrl"].ToString());
			}
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
			cbSameAddress.Enabled = false;
			btnHome.Enabled = true;
			btnNext.Enabled = true;
			btnBack.Enabled = true;
			ddlBudgetYear.Enabled	= true;
			htmbtnSave.Disabled = true;
		}

		private void cbSameAddress_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbSameAddress.Checked)
			{
				txtLearningAddress1.Text = txtAddressLine1.Text;
				txtLearningAddress2.Text = txtAddressLine2.Text;
				txtLearningCity.Text = txtCity.Text;
				txtLearningZipCode.Text = txtZipCode.Text;
				ddlLearningState.SelectedIndex = ddlStates.SelectedIndex;
				ddlTrainingContries.SelectedIndex = ddlContries.SelectedIndex;
				txtLearningProvince.Text = txtProvince.Text;
				ddlTrainingContries_SelectedIndexChanged(null, null);
			}
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

		private void SetForCountry()
		{
			
		}

		protected void ddlContries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlContries.SelectedValue != "USA")
			{
				RegularExpressionValidator4.Visible = false;
				RegularExpressionValidator3.Visible = false;
				lblPhoneFormat.Visible = false;
				txtPhoneNumber.MaxLength = 30;
				txtFaxNumber.MaxLength = 30;
				lblCityState.Text = "City/Province";
				txtProvince.Visible = true;
				ddlStates.Visible = false;
				Requiredfieldvalidator13.Visible = false;
				txtZipCode.Visible = false;
				lblZipCode.Visible = false;
				RequiredFieldValidator8.Visible = false;
				req100.Visible = false;
				req101.Visible = false;
				req102.Visible = true;
				Regularexpressionvalidator5.Visible = false;
			}
			else
			{
				RegularExpressionValidator4.Visible = true;
				RegularExpressionValidator3.Visible = true;
				lblPhoneFormat.Visible = true;
				txtPhoneNumber.MaxLength = 14;
				txtFaxNumber.MaxLength = 14;
				lblCityState.Text = "City/State";
				txtProvince.Visible = false;
				ddlStates.Visible = true;
				Requiredfieldvalidator13.Visible = true;
				txtZipCode.Visible = true;
				lblZipCode.Visible = true;
				RequiredFieldValidator8.Visible = true;
				req100.Visible = true;
				req101.Visible = true;
				req102.Visible = false;
				Regularexpressionvalidator5.Visible = true;
			}
		}

		protected void ddlTrainingContries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlTrainingContries.SelectedValue != "USA")
			{
				req105.Visible = false;
				req104.Visible = true;
				ddlLearningState.Visible = false;
				txtLearningProvince.Visible = true;
				lblLearningCityState.Text = "City/Province";
				lblLearningZipCode.Visible = false;
				req106.Visible = false;
				txtLearningZipCode.Visible = false;
				Regularexpressionvalidator6.Visible = false;
                Requiredfieldvalidator2.Visible = false;
			}
			else
			{
				req105.Visible = true;
				req104.Visible = false;
				ddlLearningState.Visible = true;
				txtLearningProvince.Visible = false;
				lblLearningCityState.Text = "City/State";
				lblLearningZipCode.Visible = true;
				req106.Visible = true;
				txtLearningZipCode.Visible = true;
				Regularexpressionvalidator6.Visible = true;
                Requiredfieldvalidator2.Visible = true;
			}
		}

	

	}
}
