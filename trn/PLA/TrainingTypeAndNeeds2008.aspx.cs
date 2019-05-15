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
	/// Summary description for TrainingTypeAndNeeds2008.
	/// </summary>
	public class TrainingTypeAndNeeds2008 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblMandatoryOnly;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lbl_fldTrainingTypeNeeds;
		protected System.Web.UI.WebControls.TextBox txtDepartmentID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblProgramCode;
		protected System.Web.UI.WebControls.TextBox txtProgramCode;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator10;
		protected System.Web.UI.WebControls.Label lblAccomodationDescription;
		protected System.Web.UI.WebControls.TextBox txtAccomodationDescription;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doSave;
		protected System.Web.UI.WebControls.DropDownList ddlAccomodation;
		protected System.Web.UI.WebControls.DropDownList ddlPositionLevel;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.DropDownList ddlTypeofAppointment;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator9;
		protected System.Web.UI.WebControls.DropDownList ddlDelivaryTypeCode;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator11;
		protected System.Web.UI.WebControls.DropDownList ddlDesignationTypeCode;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator12;
		protected System.Web.UI.WebControls.DropDownList ddlCreditTypeCode;
		protected System.Web.UI.WebControls.DropDownList ddlAccredetionIndicator;
		protected System.Web.UI.WebControls.Label lblRequiredSymbol;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label req1;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator13;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Panel pnlData;
		protected System.Web.UI.WebControls.Panel pnlProgramCode;
		protected System.Web.UI.WebControls.RadioButtonList optProgramCode;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Button btnClose1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator14;
		protected System.Web.UI.WebControls.TextBox txtTrainingTypeCode;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.TextBox txtTrainingSubTypeCode;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Panel pnlTrainingTypeCode;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.Button bntnClose2;
		protected System.Web.UI.WebControls.Button btnTrainingTypeCode;
		protected System.Web.UI.WebControls.Button btnTrainingTypeCode2;
		protected System.Web.UI.WebControls.DataGrid dgTrainingTypeCode;
		protected System.Web.UI.WebControls.Button btnCloseTrainingType2;
		protected System.Web.UI.WebControls.Button btnCloseTrainingType1;
		protected System.Web.UI.WebControls.Button btnEducationLevelClose2;
		protected System.Web.UI.WebControls.Button btnEducationLevelClose1;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.DataGrid dgEducationLevel;
		protected System.Web.UI.WebControls.Panel pnlEducationLevel;
		protected System.Web.UI.WebControls.TextBox txtEducationLevel;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator16;
		protected System.Web.UI.WebControls.Button btnSelectEducationLevel;
		protected System.Web.UI.WebControls.Button btnReset;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
		protected System.Web.UI.WebControls.Label lblTrainingCredit;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnDevClose;
		protected System.Web.UI.WebControls.Button btnDevClose0;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Panel pnlDevelopmentType;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.CheckBoxList chklstTypeofDev;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.Label lblOtherTextError;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOthers;
		protected System.Web.UI.WebControls.Label lblTypeOfDevelopment;
		protected System.Web.UI.WebControls.TextBox txtTypeOfDevelopmentSummary;
		protected System.Web.UI.WebControls.Button btnTypeOfDevelopment;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.HtmlControls.HtmlInputButton htmbtnSave;
	
		private int FieldCounter = 0;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator15;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator17;
		protected System.Web.UI.WebControls.Label lblTypeOfDevelopmentInstuction;
		protected System.Web.UI.WebControls.Button btnResetChanges;
		protected System.Web.UI.WebControls.Label lblDesinationOther;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
		protected System.Web.UI.WebControls.TextBox txtDesignationOther;
		protected System.Web.UI.WebControls.Label req2;
		protected System.Web.UI.WebControls.Label req3;
		protected System.Web.UI.WebControls.Label lblCreditTypeOther;
		protected System.Web.UI.WebControls.Label req4;
		protected System.Web.UI.WebControls.TextBox txtCreditTypeOther;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
		protected System.Web.UI.WebControls.TextBox txtTrainingCredit;
		protected System.Web.UI.WebControls.CheckBox cbTrainingCredit;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator18;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.Label lblDepartmentID;
		protected System.Web.UI.WebControls.Label lblPositionLevel;
		protected System.Web.UI.WebControls.Label lblNeedSpecialAccomodation;
		protected System.Web.UI.WebControls.Label lblTypeofAppointmant;
		protected System.Web.UI.WebControls.Label lblTrainingPurpose;
		protected System.Web.UI.WebControls.Label lblDeliveryTypeCode;
		protected System.Web.UI.WebControls.Label lblDesignationTypeCode;
		protected System.Web.UI.WebControls.Label lblCreditTypeCode;
		protected System.Web.UI.WebControls.Label lblAccreditationIndicator;
		protected System.Web.UI.WebControls.Label lblSourceOfTraining;
		protected System.Web.UI.WebControls.Label lblEducationLevel;
		protected System.Web.UI.WebControls.Label lblTrainingSubTypeCode;
		protected System.Web.UI.WebControls.Label lblTrainingTypeCode;
		protected System.Web.UI.WebControls.HiddenField hidCommand;

		private DataTable tblTypeOfDevelopment=null;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text = "";	
			
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
				//if (CheckSave())
				//    Response.Redirect(Request.Path);
				return;
			}
			if (!IsPostBack)
			{
				
				Training_Source.TrainingClass.SetValidators(Page);
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["Mandatory_Only"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Mandatory_Only",Training_Source.TrainingClass.ConnectioString);				
				SetHeaderInformation();	
				FillDropDowns();
				FillData();
				if (txtDepartmentID.Text=="")
					GetDeptId();					
				ProcessesStarFunctionality();;				
				string strProcessingYear= SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Training_Source.TrainingClass.ConnectioString);
				string strWarning = "The training request you are appling for is in development year \""+strProcessingYear+"\". You do not have an approved CDP for this year. You may not change the selected Account#";
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strProcessingYear);
				FillTypeOfDevelopmentTextBox(true);
				SetupWizardMenu();
				ddlDesignationTypeCode_SelectedIndexChanged(null,null);
				ddlCreditTypeCode_SelectedIndexChanged(null,null);
				cbTrainingCredit_CheckedChanged(null,null);
			}	
			CheckHeaderIDSet();
			HandleContractors();
			FillTypeOfDevelopmentTextBox(false);
			if (dgTrainingTypeCode.Visible)
				DrawTrainingTypeCode();
			if (dgEducationLevel.Visible)
				DrawEducationLevel();
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
			this.ddlAccomodation.SelectedIndexChanged += new System.EventHandler(this.ddlAccomodation_SelectedIndexChanged);
			this.ddlDesignationTypeCode.SelectedIndexChanged += new System.EventHandler(this.ddlDesignationTypeCode_SelectedIndexChanged);
			this.cbTrainingCredit.CheckedChanged += new System.EventHandler(this.cbTrainingCredit_CheckedChanged);
			this.ddlCreditTypeCode.SelectedIndexChanged += new System.EventHandler(this.ddlCreditTypeCode_SelectedIndexChanged);
			this.btnSelectEducationLevel.Click += new System.EventHandler(this.btnSelectEducationLevel_Click);
			this.btnTrainingTypeCode.Click += new System.EventHandler(this.btnTrainingTypeCode2_Click);
			this.btnTrainingTypeCode2.Click += new System.EventHandler(this.btnTrainingTypeCode2_Click);
			this.btnTypeOfDevelopment.Click += new System.EventHandler(this.btnTypeOfDevelopment_Click);
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.btnCloseTrainingType1.Click += new System.EventHandler(this.btnCloseTrainingType2_Click);
			this.dgTrainingTypeCode.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTrainingTypeCode_ItemCreated);
			this.dgTrainingTypeCode.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTrainingTypeCode_ItemDataBound);
			this.btnCloseTrainingType2.Click += new System.EventHandler(this.btnCloseTrainingType2_Click);
			this.btnEducationLevelClose1.Click += new System.EventHandler(this.btnEducationLevelClose1_Click);
			this.dgEducationLevel.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgEducationLevel_ItemCreated);
			this.dgEducationLevel.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgEducationLevel_ItemDataBound);
			this.btnEducationLevelClose2.Click += new System.EventHandler(this.btnEducationLevelClose1_Click);
			this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
			this.optProgramCode.SelectedIndexChanged += new System.EventHandler(this.optProgramCode_SelectedIndexChanged);
			this.bntnClose2.Click += new System.EventHandler(this.btnClose1_Click);
			this.btnDevClose0.Click += new System.EventHandler(this.btnDevClose0_Click);
			this.btnResetChanges.Click += new System.EventHandler(this.btnResetChanges_Click);
			this.btnDevClose.Click += new System.EventHandler(this.btnDevClose0_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void  SetupNextButton()
		{
			string strIncomplatePages=
				SQLStatic.SQL.ExecScaler("select pkg_training.incompletepages("+ViewState["Request_Record_ID"].ToString()+")from dual").ToString();
			btnNext.Enabled = Training_Source.TrainingClass.PageCompleted(Request.Path,strIncomplatePages);
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private void FillDropDowns()
		{
//			FillOneDropDown(ddlAccountNumber,"pkg_training_3.get_account_number",true);
			FillOneDropDown(ddlPositionLevel,"pkg_training_3.Get_cd_trn_position_level",true);
			FillOneDropDown(ddlPurposeOfTraining,"pkg_training_3.Get_cd_training_purpose_182",true);
			FillOneDropDown(ddlSourseTraining,"pkg_training_3.Get_cd_training_source_182",true);
			FillOneDropDown(ddlAccredetionIndicator,"pkg_training_3.Get_cd_accredetion_indicator",true);
			FillOneDropDown(ddlTypeofAppointment,"pkg_training_3.Get_cd_trn_Type_of_appointment",true);			
			FillOneDropDown(ddlDelivaryTypeCode,"pkg_training_3.Get_cd_training_delivery_code",true);
			FillOneDropDown(ddlDesignationTypeCode,"pkg_training_3.Get_cd_training_designation_cd",true);
			FillOneDropDown(ddlCreditTypeCode,"pkg_training_3.Get_cd_training_credit_code",true);
		}

		private void FillData()
		{
			string strTypesAndNeeds = TrainingTypeAndNeedsRecord_Id();
			if (strTypesAndNeeds=="-1")
			{	
				FillNewRecordData();				
				return;
			}
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.TrainingTypesNeedsRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_4_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];								
				SetValue(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
				SetValue(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
                if (string.IsNullOrEmpty(tbl.Rows[0]["program_code_description"].ToString()))
                    SetValue(txtProgramCode,tbl.Rows[0]["program_code"].ToString());
                else
				    SetValue(txtProgramCode,tbl.Rows[0]["program_code_description"].ToString());
//				SetValue(ddlAccountNumber,tbl.Rows[0]["account_no"].ToString());
				SetValue(txtDepartmentID,tbl.Rows[0]["dept_id"].ToString());
				SetValue(ddlAccomodation,tbl.Rows[0]["ee_need_accomodation"].ToString());
				SetValue(txtAccomodationDescription,tbl.Rows[0]["accomodation_description"].ToString());
				SetValue(ddlPositionLevel,tbl.Rows[0]["position_level"].ToString()); 
				SetValue(ddlTypeofAppointment,tbl.Rows[0]["type_of_appointment"].ToString()); 
				SetValue(txtEducationLevel,tbl.Rows[0]["frm_education_level"].ToString()); 
				SetValue(txtTrainingTypeCode,tbl.Rows[0]["frm_training_type_code"].ToString()); 
				SetValue(txtTrainingSubTypeCode,tbl.Rows[0]["frm_training_sub_type_code"].ToString()); 
				SetValue(ddlDelivaryTypeCode,tbl.Rows[0]["training_delivery_type_code"].ToString()); 
				SetValue(ddlDesignationTypeCode,tbl.Rows[0]["training_designation_code"].ToString()); 
				SetValue(ddlCreditTypeCode,tbl.Rows[0]["training_credit_type_code"].ToString()); 
				SetValue(ddlAccredetionIndicator,tbl.Rows[0]["accredetion_indicator"].ToString());

				cbTrainingCredit.Checked = tbl.Rows[0]["training_credit"].ToString()=="-1";
				if (cbTrainingCredit.Checked)
					SetValue(txtTrainingCredit,"");
				else
					SetValue(txtTrainingCredit,tbl.Rows[0]["training_credit"].ToString());

				SetValue(txtTypeofDevelopmentOthers,tbl.Rows[0]["Type_Of_Development_Other"].ToString());
				SetValue(txtDesignationOther,tbl.Rows[0]["training_designation_other"].ToString());
				SetValue(txtCreditTypeOther,tbl.Rows[0]["training_credit_type_other"].ToString());
			
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
			ddlAccomodation_SelectedIndexChanged(null,null);
			FillTypeOfDevelopmentTextBox(true);
			SetValue(txtTypeOfDevelopmentSummary,txtTypeOfDevelopmentSummary.Text);
		}

		private void FillNewRecordData()
		{
			ddlSourseTraining.SelectedIndex=0;
			ddlPurposeOfTraining.SelectedIndex = 0;				
			ddlAccomodation.SelectedIndex = 1;

			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training.defaulttypeandneeds",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["Employee_Number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_","cursor","out","");
			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				SetValue(ddlPositionLevel,tbl.Rows[0]["position_level"].ToString()); 
				SetValue(ddlAccomodation,tbl.Rows[0]["ee_need_accomodation"].ToString());
				SetValue(txtAccomodationDescription,tbl.Rows[0]["accomodation_description"].ToString());
				SetValue(ddlTypeofAppointment,tbl.Rows[0]["type_of_appointment"].ToString()); 
				SetValue(txtEducationLevel,tbl.Rows[0]["Education_Level_desc"].ToString());
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
			ddlAccomodation_SelectedIndexChanged(null,null);
			ClearTypeOfDevelopment();
			SetValue(txtTypeOfDevelopmentSummary,"");

		}

		private void ClearTypeOfDevelopment()
		{
			foreach(ListItem li in chklstTypeofDev.Items)
				li.Selected = false;
		}

		private void FillTypeOfDevelopmentTextBox(bool blnInintal)
		{
			if (blnInintal)
			{
				pnlDevelopmentType.Visible=true;
				ProcessTypeOfDevelopment();
				pnlDevelopmentType.Visible=false;
			}
			txtTypeOfDevelopmentSummary.Text = "";
			foreach (ListItem li in chklstTypeofDev.Items)
			{
				if (li.Selected)
					txtTypeOfDevelopmentSummary.Text += li.Text+", ";
			}
			int txtLength = txtTypeOfDevelopmentSummary.Text.Length;
			if (txtLength>2)
				txtTypeOfDevelopmentSummary.Text = txtTypeOfDevelopmentSummary.Text.Substring(0,txtLength-2);
				
		}

		private void GetDeptId()
		{
			string strSQL="select pkg_training.employee_dept_id("+ViewState["Employee_Number"].ToString()+") from dual";
			txtDepartmentID.Text = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private string TrainingTypeAndNeedsRecord_Id()
		{
			return SQLStatic.SQL.ExecScaler("select PKG_Training.training_types_needs_record_id("+ViewState["Request_Record_ID"].ToString()+") from dual",Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private void CheckHeaderIDSet()
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				lblScript.Text="<script>alert('Vendor Information page must be completed first');window.location.href='TrainingVendorInfo.aspx';</script>";
			}
		}

		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			Training_Source.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());
			cbTrainingCredit.Enabled = false;
			btnBack.Enabled = true;
			btnNext.Enabled = true;
			htmbtnSave.Disabled = true;
			ddlBudgetYear.Enabled	= true;
		}

		private void SetValue(TextBox txt,string strValue)
		{
			if (strValue==null)
				return;
			txt.Text=strValue;
			ViewState[txt.ID]=strValue;
			ViewState["id_"+FieldCounter]=txt.ID;
			FieldCounter++;
		}

		private void SetValue(DropDownList ddl, string strValue)
		{
			if (strValue==null)
				return;
			ddl.SelectedIndex = -1;
			foreach(ListItem li in ddl.Items)
			{
				if ((li.Value == strValue)&&(!li.Selected))
					li.Selected = true;
				if (li.Selected)
				{
					ViewState[ddl.ID]=strValue;
					ViewState["id_"+FieldCounter]=ddl.ID;
					FieldCounter++;
					break;
				}
			}
		}

		private void SetValue(RadioButtonList opt, string strValue)
		{
			if (strValue==null)
				return;
			foreach(ListItem li in opt.Items)
			{
				li.Selected = (li.Value == strValue);
				if (li.Selected)
				{
					ViewState[opt.ID]=strValue;
					ViewState["id_"+FieldCounter]=opt.ID;
					FieldCounter++;
					break;
				}
			}			
		}
		private void FillOneDropDown(DropDownList ddl,string function_name,bool blnHasSelect)
		{
			
			ddl.Items.Clear();
			if (blnHasSelect)
				ddl.Items.Add(new ListItem("---- Select ----","xx"));
				
			Oracle.DataAccess.Client.OracleConnection conn = 	new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(function_name,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"retResult_","cursor","out",null);
			conn.Open();			
			Oracle.DataAccess.Client.OracleDataReader reader =null;
			try
			{
				reader = cmd.ExecuteReader();
				
				while (reader.Read())
				{
					ListItem li = new ListItem(reader.GetValue(1).ToString(),reader.GetValue(0).ToString());
					ddl.Items.Add(li);
				}
			}
			finally
			{
				reader=null;
				cmd.Dispose();
				conn.Dispose();
			}
		}

		private void ddlAccomodation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblAccomodationDescription.Visible=ddlAccomodation.SelectedValue=="1";
			txtAccomodationDescription.Visible = lblAccomodationDescription.Visible;
			req1.Visible = lblAccomodationDescription.Visible;
			RequiredFieldValidator6.Enabled = lblAccomodationDescription.Visible;
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

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
			{
				Training_Source.TrainingClass.RegisterWarning(Page,"'"+ViewState["PrvStpUrl"].ToString()+"'");
				return;
			}	
			else	
				Response.Redirect(ViewState["PrvStpUrl"].ToString());
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
			{
				Training_Source.TrainingClass.RegisterWarning(Page,"'SelectApp.aspx'");
				return;
			}	
			Response.Redirect("SelectApp.aspx",true);
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (DataChanged())
			{
				Training_Source.TrainingClass.RegisterWarning(Page,"'"+ViewState["NextStpUrl"].ToString()+"'");
				return;
			}	
			else
				Response.Redirect(ViewState["NextStpUrl"].ToString());
		}

		private void DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
            conn.Open();
            Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
            try
			{
				SaveTypesAndNeeds(conn);
				ClearTypesofDevelopment(conn);
				SaveTypesofDevelopment(conn);
				txn.Commit();
			}
			catch
			{
				txn.Rollback();
				throw;
			}
			finally
			{
				conn.Close();
				conn.Dispose();				
			}
		}

		private void SaveTypesAndNeeds(Oracle.DataAccess.Client.OracleConnection conn)
		{
			string strTypeOfDevelopment = "";
			if (OtherSelected())
				strTypeOfDevelopment = txtTypeofDevelopmentOthers.Text;
			string strCode = txtProgramCode.Text.Substring(0,5);
			if (cbTrainingCredit.Checked)
				txtTrainingCredit.Text="0";
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.SaveUpdateTrainingTypesRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_type_","number","in",null);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"mandatory_training_","varchar2","in",null);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"source_of_training_","number","in",ddlSourseTraining.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"purpose_of_training_","number","in",ddlPurposeOfTraining.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Dept_ID_","varchar2","in",txtDepartmentID.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Program_Code_","varchar2","in",strCode);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Account_no_","varchar2","in","5632");				
				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"ee_need_accomodation_","number","in",ddlAccomodation.SelectedValue);								
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"accomodation_description_","varchar2","in",txtAccomodationDescription.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"position_level_","varchar2","in",ddlPositionLevel.SelectedValue);	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"type_of_appointment_","varchar2","in",ddlTypeofAppointment.SelectedValue);	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"education_level_","number","in",txtEducationLevel.Text.Substring(0,2));	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_type_code_","number","in",txtTrainingTypeCode.Text.Substring(0,2));	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_sub_type_code_","number","in",txtTrainingSubTypeCode.Text.Substring(0,2));	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_delivery_type_code_","number","in",ddlDelivaryTypeCode.SelectedValue);	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_designation_code_","number","in",ddlDesignationTypeCode.SelectedValue);	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_credit_type_code_","number","in",ddlCreditTypeCode.SelectedValue);	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"accredetion_indicator_","number","in",ddlAccredetionIndicator.SelectedValue);					
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Type_of_development_other_","varchar2","in",txtTypeofDevelopmentOthers.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_credit_","varchar2","in",txtTrainingCredit.Text);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_designation_other_","varchar2","in",txtDesignationOther.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_credit_type_other","varchar2","in",txtCreditTypeOther.Text);

				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());								
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				
				cmd.ExecuteNonQuery();				
			}
			finally
			{
				cmd.Dispose();				
			}
		}

		private void ClearTypesofDevelopment(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.clear_type_of_development",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
			try
			{
				cmd.ExecuteNonQuery();
			}
			finally
			{
				cmd.Dispose();
			}			
		}

		private void SaveTypesofDevelopment(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.add_type_of_development",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			
			try
			{
				foreach(ListItem li in chklstTypeofDev.Items)
				{
					if (li.Selected)
					{
						cmd.Parameters.Clear();
						SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
						SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"type_of_development_","number","in",li.Value);
						SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());						
						cmd.ExecuteNonQuery();
					}
				}
			}
			finally
			{
				cmd.Dispose();
			}
			
		}

		private void CheckSave()
		{
			Validate();
			if (!IsValid)
				return;
			DoSave();
			{
				FillData();
				SetupWizardMenu();
				lblScript.Text = "<script>alert('Data Saved Successfully')</script>";
			}
		}		

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			FillData();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=false;
			pnlProgramCode.Visible= true;
			FillProgramCode();
		}

		private void btnTrainingTypeCode2_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=false;
			pnlTrainingTypeCode.Visible= true;
			DrawTrainingTypeCode();
		}

		private void btnSelectEducationLevel_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=false;
			pnlEducationLevel.Visible= true;
			DrawEducationLevel();
		}

		private void btnTypeOfDevelopment_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=false;
			pnlDevelopmentType.Visible= true;
			lblOtherTextError.Visible = false;
			chklstTypeofDev.Visible=true;
			//			ProcessTypeOfDevelopment();
		}
		// =======================================Program Code Panel Start
		private void btnClose1_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible= true;
			pnlProgramCode.Visible=false;
		}

		private void FillProgramCode()
		{
			string strCode = "";
			if(txtProgramCode.Text.Length>5)
				strCode = txtProgramCode.Text.Substring(0,5);
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.program_code_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
						
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"list_","cursor","out","");
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{				
				da.Fill(mds,"Purpose");
				dTable = mds.Tables["Purpose"];	
				optProgramCode.Items.Clear();
				
				foreach (DataRow dr in dTable.Rows)
				{
					ListItem li = new ListItem(dr["program_code"].ToString()+" - "+dr["description"].ToString(),dr["program_code"].ToString()+" - "+dr["description"].ToString());
					if (dr["program_code"].ToString() == strCode)
						li.Selected = true;
					optProgramCode.Items.Add(li);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();
				dTable=null;
			}			
		}

		private void optProgramCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtProgramCode.Text = optProgramCode.SelectedValue;
			btnClose1_Click(null,null);
		}

		// =======================================Training Type Code Start

		private DataTable GetTraingTypeCodeData()
		{
			string strCode = "";
			if(txtProgramCode.Text.Length>5)
				strCode = txtProgramCode.Text.Substring(0,5);
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training_3.Get_cd_training_type_code",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
						
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"retResult_","cursor","out",null);
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{				
				da.Fill(mds);
				dTable = mds.Tables[0];					
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();
			}	
			return dTable;
		}

		private void DrawTrainingTypeCode()
		{
			dgTrainingTypeCode.Visible = true;
			dgTrainingTypeCode.DataSource=GetTraingTypeCodeData();
			dgTrainingTypeCode.DataBind();
		}		

		private void btnCloseTrainingType2_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=true;
			pnlTrainingTypeCode.Visible= false;
		}		

		private void dgTrainingTypeCode_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item)||
				(e.Item.ItemType == ListItemType.AlternatingItem)||
				(e.Item.ItemType == ListItemType.SelectedItem))
			{
				int itemIndex=e.Item.ItemIndex;
				DataTable dt = (DataTable)dgTrainingTypeCode.DataSource;
				try
				{
					string recid=dt.Rows[itemIndex]["sub_code"].ToString();

					LinkButton lnk = new LinkButton();
					lnk.ID = "lnk_"+recid;
					lnk.Text = dt.Rows[itemIndex]["sub_code_description"].ToString();
					lnk.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell0 = e.Item.Cells[0];
					cell0.Controls.Add(lnk);	
				}
				catch
				{
				}
			}
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			
			DataTable dt = (DataTable)dgTrainingTypeCode.DataSource;
			string strSelectedSubCode= ((LinkButton)sender).ID.Substring(4);
			foreach(DataRow dw in dt.Rows)
			{
				if (dw["sub_code"].ToString()== strSelectedSubCode)
				{
					txtTrainingTypeCode.Text = dw["code"].ToString().PadLeft(2,'0')+" - "+dw["code_description"].ToString();
					txtTrainingSubTypeCode.Text = dw["sub_code"].ToString().PadLeft(2,'0')+" - "+dw["sub_code_description"].ToString();
					break;
				}
			}
			btnCloseTrainingType2_Click(null,null);
		}

		private void dgTrainingTypeCode_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataTable dt = (DataTable)dgTrainingTypeCode.DataSource;
			string strCode= "";
			if (txtTrainingSubTypeCode.Text.Length>=2)
				strCode= Convert.ToInt32(txtTrainingSubTypeCode.Text.Substring(0,2)).ToString();
			try
			{
				if (dt.Rows[e.Item.ItemIndex]["sub_code"].ToString()==strCode)					
					e.Item.BackColor=System.Drawing.Color.Gold;
			}
			catch
			{
			}
		}

		// =======================================Education Level Start
		
		private DataTable GetEducationLevelData()
		{			
			string strCode = "";
			if(txtProgramCode.Text.Length>5)
				strCode = txtProgramCode.Text.Substring(0,5);
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training_3.Get_cd_trn_education_level",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
						
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"retResult_","cursor","out",null);
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{				
				da.Fill(mds);
				dTable = mds.Tables[0];					
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();
			}	
			return dTable;
		}

		private void DrawEducationLevel()
		{
			dgEducationLevel.Visible = true;
			dgEducationLevel.DataSource=GetEducationLevelData();
			dgEducationLevel.DataBind();
		}

		private void btnEducationLevelClose1_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=true;
			pnlEducationLevel.Visible= false;
		}

		private void dgEducationLevel_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item)||
				(e.Item.ItemType == ListItemType.AlternatingItem)||
				(e.Item.ItemType == ListItemType.SelectedItem))
			{
				int itemIndex=e.Item.ItemIndex;
				DataTable dt = (DataTable)dgEducationLevel.DataSource;
				try
				{
					string recid=dt.Rows[itemIndex]["code"].ToString();

					LinkButton lnk = new LinkButton();
					lnk.ID = "lnk_"+recid;
					lnk.Text = dt.Rows[itemIndex]["short_description"].ToString();
					lnk.Click += new System.EventHandler(this.btnMenu2_Click);
					TableCell cell0 = e.Item.Cells[0];
					cell0.Controls.Add(lnk);	
				}
				catch
				{
				}
			}
		}

		private void btnMenu2_Click(object sender, System.EventArgs e)
		{
			
			DataTable dt = (DataTable)dgEducationLevel.DataSource;
			string strCode= ((LinkButton)sender).ID.Substring(4);
			foreach(DataRow dw in dt.Rows)
			{
				if (dw["code"].ToString()== strCode)
				{
					txtEducationLevel.Text = dw["code"].ToString().PadLeft(2,'0')+" - "+dw["short_description"].ToString();
					break;
				}
			}
			btnEducationLevelClose1_Click(null,null);
		}

		private void dgEducationLevel_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataTable dt = (DataTable)dgEducationLevel.DataSource;
			string strCode= "";
			if (txtEducationLevel.Text.Length>=2)
				strCode= Convert.ToInt32(txtEducationLevel.Text.Substring(0,2)).ToString();
			try
			{
				if (dt.Rows[e.Item.ItemIndex]["code"].ToString()==strCode)					
					e.Item.BackColor=System.Drawing.Color.Gold;
			}
			catch
			{
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

		

		// =======================================training type of development

		private void btnDevClose0_Click(object sender, System.EventArgs e)
		{
			pnlData.Visible=true;
			pnlDevelopmentType.Visible= false;
		}

		private void ProcessTypeOfDevelopment()
		{
			FillSelectedTypeofDevelopment();
			FillTypeofDevelopment();
		}

		private void btnResetChanges_Click(object sender, System.EventArgs e)
		{
			ProcessTypeOfDevelopment();
		}

		private void FillSelectedTypeofDevelopment()
		{
			if (tblTypeOfDevelopment != null)
				return;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.type_of_development_List",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tblTypeOfDevelopment=mds.Tables[0];
				//				lbTypeofDev.Items.Clear();
				//				foreach (DataRow dr in tbl.Rows)
				//				{
				//					ViewState["
				//					ListItem li = new ListItem(dr["cd_record_id"].ToString(),dr["record_id"].ToString());
				//					lbTypeofDev.Items.Add(li);
				//				}
				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();				
			}			
		}

		private bool IsSelected(string strRecord_id)
		{
			if (tblTypeOfDevelopment == null)
				FillSelectedTypeofDevelopment();
			foreach(DataRow dr in tblTypeOfDevelopment.Rows)
			{
				if (dr["cd_record_id"].ToString()==strRecord_id)
					return true;
			}
			return false;
		}

		private bool OtherSelected()
		{
			bool blnTxtFilled = txtTypeofDevelopmentOthers.Text.Trim()!="";
			foreach(ListItem li in chklstTypeofDev.Items)
			{
				if ((li.Value=="100")&&li.Selected)
					return true&&(!blnTxtFilled);
			}
			return false;
		}
		

		private void FillTypeofDevelopment()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.type_of_development_List",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;

			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				chklstTypeofDev.Items.Clear();
				foreach (DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["description"].ToString(),dr["record_id"].ToString());
					li.Selected = IsSelected(li.Value);
					chklstTypeofDev.Items.Add(li);
				}
				
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

		private void ddlDesignationTypeCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblDesinationOther.Visible = ddlDesignationTypeCode.SelectedValue=="100";
			req2.Visible = lblDesinationOther.Visible;
			txtDesignationOther.Visible=lblDesinationOther.Visible;
			Requiredfieldvalidator7.Visible = lblDesinationOther.Visible;
		}

		private void ddlCreditTypeCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblCreditTypeOther.Visible = ddlCreditTypeCode.SelectedValue=="100";
			req4.Visible = lblCreditTypeOther.Visible;
			txtCreditTypeOther.Visible = lblCreditTypeOther.Visible;
			Requiredfieldvalidator8.Visible = lblCreditTypeOther.Visible;
		}

		private void cbTrainingCredit_CheckedChanged(object sender, System.EventArgs e)
		{
			txtTrainingCredit.Visible = !cbTrainingCredit.Checked;
			Requiredfieldvalidator18.Visible = txtTrainingCredit.Visible;
			RangeValidator1.Visible = txtTrainingCredit.Visible;
		}

		

		
		
		
		
	}
}
