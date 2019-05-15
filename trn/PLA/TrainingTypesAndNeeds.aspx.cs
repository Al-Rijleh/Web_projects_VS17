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
	/// Summary description for PLA_Step4.
	/// </summary>
	public class TrainingTypesAndNeeds : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Button btnSaveBack;
		protected System.Web.UI.WebControls.Button btnSaveNext;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Label lblReq;
		protected System.Web.UI.WebControls.Panel pnlAction;
		protected System.Web.UI.WebControls.Panel pnlNav;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTainingOther;
		protected System.Web.UI.WebControls.Label lbl_fldTrainingTypeNeeds;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.CheckBoxList chklstTypeofDev;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopment;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOthers;
		protected System.Web.UI.WebControls.ListBox lbTypeofDev;
		protected System.Web.UI.WebControls.TextBox txtSelectedDevelopments;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.Label lblOtherTextError;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtDepartmentID;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.RadioButtonList opnlstAccountNumber;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
		protected System.Web.UI.WebControls.Label lblProgramCode;
		protected System.Web.UI.WebControls.Label lblStarProgramCode;
		protected System.Web.UI.WebControls.Label lblMandatoryOnly;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtProgramCode;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator10;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator9;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected BASUSA.MiscTidBit misc = new BASUSA.MiscTidBit();
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.Button btnSaveandStay;
		protected Karamasoft.WebControls.UltimateMenu UltimateMenu1;
		protected System.Web.UI.WebControls.Label lblWizardError;
	
		private int FieldCounter = 0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text = "";	
			lblOtherTextError.Visible = false;
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
			
			if (!IsPostBack)
			{
				ViewState["NextStpUrl"] = "TrainingExpenses.aspx";
				ViewState["PrvStpUrl"] = "CourseDateAndTime.aspx";
				Training_Source.TrainingClass.SetValidators(Page);
				lbTypeofDev.Width=System.Web.UI.WebControls.Unit.Pixel(1);
				lbTypeofDev.Height=System.Web.UI.WebControls.Unit.Pixel(1);
				lbTypeofDev.ForeColor = System.Drawing.Color.White;
				lbTypeofDev.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);	
                //}
						
				this.LblTemplateHeader2.Text=Template.BasTemplate.Update_Header(this.LblTemplateHeader2.Text,"Edit Mode");
				btnSaveBack.Text="";
				btnSaveBack.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
				btnSaveBack.ForeColor = System.Drawing.Color.White;
				btnSaveBack.Width = System.Web.UI.WebControls.Unit.Pixel(1);
				btnSaveBack.Height = System.Web.UI.WebControls.Unit.Pixel(1);

				btnSaveNext.Text="";
				btnSaveNext.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
				btnSaveNext.ForeColor = System.Drawing.Color.White;
				btnSaveNext.Width = System.Web.UI.WebControls.Unit.Pixel(1);
				btnSaveNext.Height = System.Web.UI.WebControls.Unit.Pixel(1);

				txtSelectedDevelopments.Text="";
				txtSelectedDevelopments.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
				txtSelectedDevelopments.ForeColor = System.Drawing.Color.White;
				txtSelectedDevelopments.Width = System.Web.UI.WebControls.Unit.Pixel(1);
				txtSelectedDevelopments.Height = System.Web.UI.WebControls.Unit.Pixel(1);

				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["Mandatory_Only"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Mandatory_Only",Training_Source.TrainingClass.ConnectioString);				
				SetHeaderInformation();	
				FillDropDowns();
				FillData();
				if (txtDepartmentID.Text=="")
					GetDeptId();
				FillSelectedTypeofDevelopment();
				FillTypeofDevelopment();				
				SetInView();	
				lblScript.Text="<script>EnableNavigation()</script>";
				ProcessesStarFunctionality();
				SetInintialCheckBoxTestField();				
				string strProcessingYear= SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Training_Source.TrainingClass.ConnectioString);
				string strWarning = "The training request you are appling for is in development year \""+strProcessingYear+"\". You do not have an approved CDP for this year. You may not change the selected Account#";
				if (!Training_Source.TrainingClass.aquiredpreaproval(ViewState["Employee_Number"].ToString(),strProcessingYear))
				{
					if (TrainingTypeAndNeedsRecord_Id()=="-1")
					{
						lblMandatoryOnly.Text = strWarning;
						opnlstAccountNumber.SelectedIndex = 1;
					}
					else
					{
						lblMandatoryOnly.Text = "The training request you are appling for is in development year \""+strProcessingYear+"\". You do not have an approved CDP for this year. Your request must be for a \"Other Training (Mandatory) (5633)\" to be able to submit this training request later.";					}
					opnlstAccountNumber.Enabled = false;
					SetupWizardMenu();					
				}
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strProcessingYear);
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
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.ddlSourseTraining.SelectedIndexChanged += new System.EventHandler(this.ddlPurposeOfTraining_SelectedIndexChanged);
			this.ddlPurposeOfTraining.SelectedIndexChanged += new System.EventHandler(this.ddlPurposeOfTraining_SelectedIndexChanged);
			this.chklstTypeofDev.SelectedIndexChanged += new System.EventHandler(this.chklstTypeofDev_SelectedIndexChanged);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnSaveandStay.Click += new System.EventHandler(this.btnSaveandStay_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
			this.btnSaveBack.Click += new System.EventHandler(this.btnSaveBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void  SetupNextButton()
		{
			string strIncomplatePages=
				SQLStatic.SQL.ExecScaler("select pkg_training.incompletepages("+ViewState["Request_Record_ID"].ToString()+")from dual").ToString();
			btnNext.Enabled = Training_Source.TrainingClass.PageCompleted(Request.Path,strIncomplatePages);
		}

		private void GetDeptId()
		{
			string strSQL="select pkg_training.employee_dept_id("+ViewState["Employee_Number"].ToString()+") from dual";
			txtDepartmentID.Text = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
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
			string strInView = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"InView",Training_Source.TrainingClass.ConnectioString);

			if (strInView=="T")
			{
				this.LblTemplateHeader2.Text=Template.BasTemplate.Update_Header(this.LblTemplateHeader2.Text,"View Mode");				
				ddlSourseTraining.Enabled=false;
				ddlPurposeOfTraining.Enabled=false;
				txtPurposeOfTainingOther.Enabled = false;
			}
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private void FillOneDropDown(DropDownList ddl,string strTableName)
		{
			
			ddl.Items.Clear();
			ddl.Items.Add(new ListItem("---- Select ----","xx"));
			string strSQL="select record_id,description from "+strTableName;
			Oracle.DataAccess.Client.OracleConnection conn = 	new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strSQL,conn);
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
				reader.Dispose();
				cmd.Dispose();
				conn.Dispose();
			}
		}

		private void FillPurposeOfTraining()
		{
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.getpurposeoftraininglist",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"employee_number_",ViewState["Employee_Number"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"processing_year_",ViewState["Processing_Year"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"purpose_list_","cursor","out","");
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{
				
				da.Fill(mds,"Purpose");
				dTable = mds.Tables["Purpose"];				
				ddlPurposeOfTraining.Items.Add(new ListItem("---- Select ----","xx"));
				foreach (DataRow dr in dTable.Rows)
				{
					ListItem li = new ListItem(dr["description"].ToString(),dr["record_id"].ToString());
					ddlPurposeOfTraining.Items.Add(li);
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

//		private void FillProgramCode()
//		{
//			System.Data.DataTable dTable;
//			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
//			Oracle.DataAccess.Client.OracleCommand cmd =
//				new Oracle.DataAccess.Client.OracleCommand("pkg_training.program_code_list",conn);
//			cmd.CommandType = System.Data.CommandType.StoredProcedure;
//						
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"list_","cursor","out","");
//			Oracle.DataAccess.Client.OracleDataAdapter da = 
//				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
//			DataSet mds=new DataSet();
//			conn.Open();
//			try
//			{
//				
//				da.Fill(mds,"Purpose");
//				dTable = mds.Tables["Purpose"];	
//				ddlProgramCode.Items.Clear();
//				ddlProgramCode.Items.Add(new ListItem("---- Select ----","-1"));
//				foreach (DataRow dr in dTable.Rows)
//				{
//					ListItem li = new ListItem(dr["description"].ToString(),dr["program_code"].ToString());
//					ddlProgramCode.Items.Add(li);
//				}
//			}
//			finally
//			{
//				conn.Close();
//				conn.Dispose();
//				cmd.Dispose();
//				da.Dispose();
//				mds.Dispose();
//				dTable=null;
//			}
//			if (ddlProgramCode.Items.Count==1)
//			{
//				ddlProgramCode.Enabled =false;				
//				lblStarProgramCode.Visible = false;
//				rvProgramCode.Visible = false;
//				lblProgramCodeCommingSoon.Visible = true;
//			}
//		}

		private void FillAccountNo()
		{
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.account_no_list",conn);
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
				opnlstAccountNumber.Items.Clear();			
				foreach (DataRow dr in dTable.Rows)
				{
					ListItem li = new ListItem(dr["description"].ToString(),dr["account_no"].ToString());
					opnlstAccountNumber.Items.Add(li);
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

		private void FillDropDowns()
		{
			FillOneDropDown(ddlSourseTraining,"cd_training_source ");
			FillPurposeOfTraining();
//			FillProgramCode();
			FillAccountNo();
//			FillOneDropDown(ddlPurposeOfTraining,"cd_training_purpose ");
		}

		private void SetDropDownIndex(DropDownList ddl,string strValue)
		{
			for (int i=0; i<ddl.Items.Count;i++)
				if (ddl.Items[i].Value==strValue)
				{
					ddl.SelectedIndex = i;
					break;
				}
		}

		private void SetOpnLstIndex(RadioButtonList opn,string strValue)
		{
			for (int i=0; i<opn.Items.Count;i++)
				if (opn.Items[i].Value==strValue)
				{
					opn.SelectedIndex = i;
					break;
				}
		}

		private string TrainingTypeAndNeedsRecord_Id()
		{
			return SQLStatic.SQL.ExecScaler("select PKG_Training.training_types_needs_record_id("+ViewState["Request_Record_ID"].ToString()+") from dual",Training_Source.TrainingClass.ConnectioString).ToString();
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

		private void SetValue(RadioButtonList opt, string strValue)
		{
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
		
		private void FillData()
		{
			string strTypesAndNeeds = TrainingTypeAndNeedsRecord_Id();
			if (strTypesAndNeeds=="-1")
			{				
				ddlSourseTraining.SelectedIndex=0;
				ddlPurposeOfTraining.SelectedIndex = 0;
				txtPurposeOfTainingOther.Text = "";		
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
//				SetDropDownIndex(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
//				SetDropDownIndex(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
				SetValue(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
				SetValue(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
				SetValue(txtProgramCode,tbl.Rows[0]["program_code_description"].ToString());
				SetValue(opnlstAccountNumber,tbl.Rows[0]["account_no"].ToString());
				SetValue(txtPurposeOfTainingOther, tbl.Rows[0]["purpose_of_training_other"].ToString());
				SetValue(txtTypeofDevelopmentOthers, tbl.Rows[0]["type_of_development_other"].ToString());
				SetValue(txtDepartmentID,tbl.Rows[0]["dept_id"].ToString());
				
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

		private bool IsSelected(string strRecord_id)
		{
			foreach (ListItem li in lbTypeofDev.Items)
			{
				if (li.Text==strRecord_id)
					return true;
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
		
		private void CheckSelectedTypeOfDevelopment()
		{
			foreach (ListItem li in chklstTypeofDev.Items)
			{				
				li.Selected = IsSelected(li.Value);
			}
		}

		private void FillSelectedTypeofDevelopment()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.type_of_development_List",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;

			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				lbTypeofDev.Items.Clear();
				foreach (DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["cd_record_id"].ToString(),dr["record_id"].ToString());
					lbTypeofDev.Items.Add(li);
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

		

		private void SaveTypesAndNeeds(Oracle.DataAccess.Client.OracleConnection conn)
		{
			string strTypeOfDevelopment = "";
			if (OtherSelected())
				strTypeOfDevelopment = txtTypeofDevelopmentOthers.Text;
			
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.SaveUpdateTrainingTypesRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			string strCode = txtProgramCode.Text.Substring(0,5);
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_type_","number","in","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"mandatory_training_","varchar2","in",null);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"source_of_training_","number","in",ddlSourseTraining.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"purpose_of_training_","number","in",ddlPurposeOfTraining.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"purpose_of_training_other_","varchar2","in",txtPurposeOfTainingOther.Text);	
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Type_of_development_other_","varchar2","in",txtTypeofDevelopmentOthers.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Dept_ID_","varchar2","in",txtDepartmentID.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Program_Code_","varchar2","in",strCode);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Account_no_","varchar2","in",opnlstAccountNumber.SelectedValue);				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				conn.Open();
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

		private bool SaveData()
		{
			lblOtherTextError.Visible = OtherSelected();
			Validate();
			if ((IsValid)&&(!lblOtherTextError.Visible))
			{
				DoSave();
				lblScript.Text = "<script>popup('saved.aspx',200,400)</script>";
				SetButtonStatus(true);
				return true;
			}
//			else if (lblOtherTextError.Visible)
//				lblScript.Text = "<script>alertWait('"+lnkbtnSaveAndStay.ID+"','"+lblOtherTextError.Text+"');</script>";
			return false;
		}

		private bool DataChanged()
		{
			return false;
			if ((opnlstAccountNumber.SelectedIndex == -1)||(ddlSourseTraining.SelectedValue == "xx")||
				(ddlPurposeOfTraining.SelectedValue == "xx"))
				return false;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);

			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.PKG_Training.CourseTypeNeedsChanged",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			bool blnChanged=true;
			string strCode = txtProgramCode.Text.Substring(0,5);
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"training_type_","number","in","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"mandatory_training_","varchar2","in","");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"source_of_training_","number","in",ddlSourseTraining.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"purpose_of_training_","number","in",ddlPurposeOfTraining.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"purpose_of_training_other_","varchar2","in",txtPurposeOfTainingOther.Text);												
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Type_of_development_other_","varchar2","in",txtTypeofDevelopmentOthers.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Dept_ID_","varchar2","in",txtDepartmentID.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Program_Code_","varchar2","in",strCode);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"Account_no_","varchar2","in",opnlstAccountNumber.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"changed_","varchar2","out","");
			
				conn.Open();
				cmd.ExecuteNonQuery();
				blnChanged = cmd.Parameters["changed_"].Value.ToString()=="T";
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			if (!blnChanged)
				blnChanged = TypeOfDevelopmentChanged();
			return blnChanged;
		}
		
	

	

		private void optMandatoryTraining_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetButtonStatus(false);
		}

		private void ddlPurposeOfTraining_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetButtonStatus(false);
			lblReq.Visible = ddlPurposeOfTraining.SelectedItem.Text=="Others";
			RequiredFieldValidator9.Visible = lblReq.Visible;
		}
		
		private void SetButtonStatus(bool blnEnabled)
		{
//			pnlNav.Enabled=blnEnabled;
//			pnlAction.Enabled =!blnEnabled;
		}
		
		private void SetInintialCheckBoxTestField()
		{
			txtSelectedDevelopments.Text = "";
			foreach(ListItem li in chklstTypeofDev.Items)
				if (li.Selected)
				{
					txtSelectedDevelopments.Text = "abc";
					break;
				}
		}
		private void chklstTypeofDev_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			rvTypeofDev.Visible = OtherSelected();
//			txtSelectedDevelopments.Text = "";
//			foreach(ListItem li in chklstTypeofDev.Items)
//				if (li.Selected)
//				{
//					txtSelectedDevelopments.Text = "abc";
//				}
		}

		private bool ValueExistsInListBox(string strValue)
		{
			foreach(ListItem li in lbTypeofDev.Items)
			{
				if (li.Text==strValue)
					return true;
			}
			return false;
		}

		private bool ValueExistsInCheckBox(string strValue)
		{
			foreach(ListItem li in chklstTypeofDev.Items)
			{
				if ((li.Value==strValue)&&(li.Selected))
					return true;
			}
			return false;
		}

		private bool TypeOfDevelopmentChanged()
		{			
			foreach(ListItem lic in chklstTypeofDev.Items)
			{
				if (lic.Selected)
				{
					if (!ValueExistsInListBox(lic.Value))
						return true;
				}
			}

			foreach(ListItem li in lbTypeofDev.Items)
			{
				if (!ValueExistsInCheckBox(li.Text))
					return true;
			}

			return false;
			
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Employee_Number"].ToString());
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			string strCode;
			if (txtProgramCode.Text.Length > 5)
				strCode = txtProgramCode.Text.Substring(0,5);
			else
				strCode = "";
//			Response.Redirect("ProgramCodes.aspx?code="+strCode);
			lblScript.Text = "<script>popup('ProgramCodes.aspx?code="+strCode+"',550,750)</script>";
		}

		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			Training_Source.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			
			btnBack.Enabled = true;
			btnNext.Enabled = true;
			btnHome.Enabled = true;
			ddlBudgetYear.Enabled	= true;
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
			{
				lblScript.Text = "<script>window.location.href='"+ViewState["NextStpUrl"].ToString()+"'</script>";
				return;
			}
			lblOtherTextError.Visible = OtherSelected();			
			if (!lblOtherTextError.Visible)
			{
				if (DataChanged())
					lblScript.Text = "<script>popup('Warning.aspx?d=n',200,400)</script>";				
				else	
					lblScript.Text = "<script>window.location.href='"+ViewState["NextStpUrl"].ToString()+"'</script>";			
			}
//			else
//				lblScript.Text = "<script>alertWait('"+lnkbtnSaveAndStay.ID+"','"+lblOtherTextError.Text+"');</script>";
	
		}

		private void btnSaveandStay_Click(object sender, System.EventArgs e)
		{
			SaveData();
			SetupWizardMenu();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			FillData();
			CheckSelectedTypeOfDevelopment();
			ddlPurposeOfTraining_SelectedIndexChanged(null,null);
			SetButtonStatus(true);
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
			{
				lblScript.Text = "<script>window.location.href='CourseDateAndTime.aspx'</script>";
				return;
			}
			if (DataChanged())
				lblScript.Text = "<script>popup('Warning.aspx?d=b',200,400)</script>";				
			else	
				lblScript.Text = "<script>window.location.href='CourseDateAndTime.aspx'</script>";
		}

		private void btnSaveNext_Click(object sender, System.EventArgs e)
		{
			if (SaveData())
				Response.Redirect(ViewState["NextStpUrl"].ToString());
		}

		private void btnSaveBack_Click(object sender, System.EventArgs e)
		{
			if (SaveData())
			{
				if (ViewState["PrvStpUrl"].ToString()=="")	
					Response.Redirect("SelectApp.aspx");
				else
					Response.Redirect(ViewState["PrvStpUrl"].ToString());
			}
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SelectApp.aspx",true);
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
