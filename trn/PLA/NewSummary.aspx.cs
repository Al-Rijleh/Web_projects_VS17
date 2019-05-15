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
using System.Xml;

namespace PLA_Source
{
	/// <summary>
	/// Summary description for NewSummary.
	/// </summary>
	public class NewSummary : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Panel pnlVendor;
		protected System.Web.UI.WebControls.Panel pnlDateTime;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursTotal;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursNonDuty;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursDuty;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Panel pnlTypesNeeds;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.Panel pnlExpenses;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblTotalPaid;
		protected System.Web.UI.WebControls.Label lblApprovedAmount;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.TextBox txtLearningZipCode;
		protected System.Web.UI.WebControls.Label lblLearningZipCode;
		protected System.Web.UI.WebControls.TextBox txtLearningCity;
		protected System.Web.UI.WebControls.Label lblLearningCityState;
		protected System.Web.UI.WebControls.TextBox txtLearningAddress2;
		protected System.Web.UI.WebControls.TextBox txtLearningAddress1;
		protected System.Web.UI.WebControls.Label Label52;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtVendorContact;
		protected System.Web.UI.WebControls.Label Label50;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCourseTitle;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCourseCode;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lblLearningAddress2;
		protected System.Web.UI.WebControls.Label lblLearningAddress1;
		protected System.Web.UI.WebControls.TextBox txtDescribtion;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtLearningState;
		protected System.Web.UI.WebControls.Label lblVendor;
		protected System.Web.UI.WebControls.TextBox txtProgramCode;
		protected System.Web.UI.WebControls.Label lblProgramCode;
		protected System.Web.UI.WebControls.TextBox txtTrainingSubTypeCode;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.TextBox txtTrainingTypeCode;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.TextBox txtEducationLevel;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.Label Label41;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label47;
		protected System.Web.UI.WebControls.Label Label48;
		protected System.Web.UI.WebControls.Label Label49;
		protected System.Web.UI.WebControls.TextBox txtAccomodationDescription;
		protected System.Web.UI.WebControls.Label lblAccomodationDescription;
		protected System.Web.UI.WebControls.Label Label53;
		protected System.Web.UI.WebControls.Label Label55;
		protected System.Web.UI.WebControls.TextBox txtDepartmentID;
		protected System.Web.UI.WebControls.Label Label57;
		protected System.Web.UI.WebControls.TextBox txtPositionLevel;
		protected System.Web.UI.WebControls.TextBox txTypeofAppointment;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTraining;
		protected System.Web.UI.WebControls.TextBox txtDelivaryTypeCode;
		protected System.Web.UI.WebControls.TextBox txtDesignationTypeCode;
		protected System.Web.UI.WebControls.TextBox txtSourseTraining;
		protected System.Web.UI.WebControls.TextBox txtAccountNumber;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtCreditTypeCode;
		protected System.Web.UI.WebControls.TextBox txtAccredetionIndicator;
		protected System.Web.UI.WebControls.TextBox txtAccomodation;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected Karamasoft.WebControls.UltimateTabstrip.UltimateTabstrip uts;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RadioButton rbAccountNo;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.TextBox txtSource;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.TextBox txtPurpose;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTainingOther;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Table tblTypeofDeve;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOther;
		protected System.Web.UI.WebControls.Panel pnlTypesNeeds2007;
		protected System.Web.UI.WebControls.TextBox txtDepartmentID2007;
		protected System.Web.UI.WebControls.TextBox txtProgramCode2007;
		protected System.Web.UI.WebControls.TextBox txtTypeOfDevelopmentSummary;
		protected System.Web.UI.WebControls.Label lblTypeOfDevelopment;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOthers;
		protected System.Web.UI.WebControls.Label lblTrainingCredit;
		protected System.Web.UI.WebControls.TextBox txtTrainingCredit;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOther182;
		protected System.Web.UI.WebControls.Label lblNoteMark;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label lblNoteMarkDetail;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
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
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);
                //}				
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());				
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["Use_App_ee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number",Training_Source.TrainingClass.ConnectioString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",Training_Source.TrainingClass.ConnectioString);
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","",Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();
				if (Training_Source.TrainingClass.Use2008Types_Needs(ViewState["Request_Record_ID"].ToString()))
					ViewState["Use_2008"]="1";
				else
					ViewState["Use_2008"]="0";
				FillData();
				FillDataDateTimes();
				if (ViewState["Use_2008"].ToString()=="1")
					FillDataTypesNeeds();
				else
				{
					FillSelectedTypeofDevelopment();
					FillDataTypesNeeds2007();
				}
				DrawGrid();	
				SetInView();
				SetVisibility(pnlVendor);
				if ((ddlSourseTraining.SelectedIndex != -1)&&(ddlSourseTraining.Items.Count > 0))
					txtSource.Text = ddlSourseTraining.SelectedItem.Text;
				if ((ddlPurposeOfTraining.SelectedIndex != -1)&&(ddlPurposeOfTraining.Items.Count > 0))
				txtPurpose.Text = ddlPurposeOfTraining.SelectedItem.Text;
//				SetVisibility(pnlVendor, btnVendor);
//				txtSate.Text = ddlStates.SelectedItem.Text;			
				try
				{
					int intProcessing = Convert.ToInt16(ViewState["Application_Processing_Year"]);
					if (intProcessing <2008)
					{
						lblNoteMark.Visible=false;
						lblNote.Visible=false;
						lblNoteMarkDetail.Visible = false;
					}
				}
				catch
				{
				}
				if ((Request.Params["Tab"] != null) && (Request.Params["Tab"] == "3"))
				{
					uts.ActiveTabIndex = 3;
					uts_ActiveTabChanged(null, null);
				}
				if ((Request.Params["call"] != null) && (Request.Params["Tab"] != ""))
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Return_to", Request.Params["call"]);
			}
			if (pnlExpenses.Visible)
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
			this.uts.ActiveTabChanged += new System.EventHandler(this.uts_ActiveTabChanged);
			this.dgExpense.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgExpense_ItemCreated);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		// Navigation
		private void SetVisibility(Panel pnl, LinkButton btn)
		{
//			btnVendor.Enabled=true;
//			btnDateTime.Enabled=true;
//			btnTypesNeeds.Enabled=true;
//			btnExpenses.Enabled=true;

			pnlVendor.Visible = false;
			pnlDateTime.Visible = false;
			pnlTypesNeeds.Visible = false;
			pnlExpenses.Visible = false;			

			pnl.Visible = true;
			btn.Enabled = false;
		}

		private void SetVisibility(Panel pnl)
		{
			
			pnlVendor.Visible = false;
			pnlDateTime.Visible = false;
			pnlTypesNeeds.Visible = false;
			pnlExpenses.Visible = false;
			pnlTypesNeeds2007.Visible = false;

			if ((pnl.ID==pnlTypesNeeds.ID)&&(ViewState["Use_2008"].ToString()=="0"))
				pnlTypesNeeds2007.Visible = true;
			else
				pnl.Visible = true;
		}

//		private void btnExpenses_Click(object sender, System.EventArgs e)
//		{
//			SetVisibility(pnlExpenses, btnExpenses);						
//			lnkbtnBack.Enabled = true;
//			lnkbtnNext.Enabled = false;
//			DrawGrid();
//		}

//		private void btnDateTime_Click(object sender, System.EventArgs e)
//		{
//			SetVisibility(pnlDateTime, btnDateTime);
//			lnkbtnBack.Enabled = true;
//			lnkbtnNext.Enabled = true;
//		}

//		private void btnTypesNeeds_Click(object sender, System.EventArgs e)
//		{
//			SetVisibility(pnlTypesNeeds, btnTypesNeeds);
//			lnkbtnBack.Enabled = true;
//			lnkbtnNext.Enabled = true;
//		}

//		private void btnVendor_Click(object sender, System.EventArgs e)
//		{
//			SetVisibility(pnlVendor, btnVendor);
//			lnkbtnBack.Enabled = false;
//			lnkbtnNext.Enabled = true;
//		}
		
		// Fill Data
		private void SetInView()
		{			
//			txtCourseCode.Enabled =false;
//			txtCourseTitle.Enabled=false;
//			txtLocation.Enabled = false;
//			txtVedorName.Enabled = false;
//			txtVendorContact.Enabled = false;
//			txtPhoneNumber.Enabled=false;
//			txtFaxNumber.Enabled=false;
//			txtAddressLine1.Enabled=false;
//			txtAddressLine2.Enabled=false;
//			txtCity.Enabled=false;
//			ddlStates.Enabled=false;
//			txtZipCode.Enabled=false;
//			txtDescribtion.Enabled=false;
//			txtWebSite.Enabled=false;
//			txtStartDate.Enabled=false;
//			txtEndDate.Enabled=false;
//			txtCourseHoursDuty.Enabled=false;
//			txtCourseHoursNonDuty.Enabled=false;
//			optMandatoryTraining.Enabled=false;
//			ddlSourseTraining.Enabled=false;
//			ddlPurposeOfTraining.Enabled=false;
//			txtPurposeOfTainingOther.Enabled = false;			
		}
		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			if (ViewState["Use_App_ee_Number"].ToString()=="true")
				ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Applicant_Employee_Number"].ToString());				
			else  
				ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());				
			string parPtemplate = Training_Source.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
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

		private void SetDropDownIndex(DropDownList ddl,string strValue)
		{
			for (int i=0; i<ddl.Items.Count;i++)
				if (ddl.Items[i].Value==strValue)
				{
					ddl.SelectedIndex = i;
					break;
				}
		}

		private void SetValue(TextBox txt,string strValue)
		{
			txt.Text=strValue;			
		}

		private void FillData()
		{			
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
				if (tbl.Rows.Count!= 0)
				{
					SetValue(txtCourseCode, tbl.Rows[0]["course_code"].ToString());
					SetValue(txtCourseTitle, tbl.Rows[0]["course_title"].ToString());
					SetValue(txtVedorName, tbl.Rows[0]["vendor_name"].ToString());
					SetValue(txtVendorContact, tbl.Rows[0]["vendor_contact"].ToString());
					SetValue(txtPhoneNumber, tbl.Rows[0]["vendor_phone_number"].ToString());
					SetValue(txtFaxNumber, tbl.Rows[0]["vendor_fax_number"].ToString());
					SetValue(txtAddressLine1, tbl.Rows[0]["vendor_address1"].ToString());
					SetValue(txtAddressLine2, tbl.Rows[0]["vendor_address2"].ToString());
					SetValue(txtCity, tbl.Rows[0]["vendor_city"].ToString());
					txtState.Text = tbl.Rows[0]["vendor_state"].ToString();
					SetValue(txtZipCode, tbl.Rows[0]["vendor_zip_code"].ToString());
					SetValue(txtWebSite, tbl.Rows[0]["vendor_website"].ToString());
					SetValue(txtDescribtion, tbl.Rows[0]["desription_of_course_value"].ToString());
					SetValue(txtLearningAddress1, tbl.Rows[0]["training_address1"].ToString());
					SetValue(txtLearningAddress2, tbl.Rows[0]["training_address2"].ToString());
					SetValue(txtLearningCity, tbl.Rows[0]["training_city"].ToString());
					txtLearningState.Text= tbl.Rows[0]["training_state"].ToString();
					SetValue(txtLearningZipCode, tbl.Rows[0]["training_zip"].ToString());
					ViewState["application_status"]= tbl.Rows[0]["application_status"].ToString();
					ViewState["description"]=tbl.Rows[0]["description"].ToString();
					strPY = tbl.Rows[0]["processing_year"].ToString();
					ViewState["Application_Processing_Year"]= strPY;
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

		private void FillDataDateTimes()
		{
			
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
				if (tbl.Rows.Count!=0)
				{
					txtStartDate.Text = tbl.Rows[0]["course_start_date"].ToString();
					txtEndDate.Text = tbl.Rows[0]["course_end_date"].ToString();					
					txtCourseHoursDuty.Text = tbl.Rows[0]["course_hours_duty"].ToString();
					txtCourseHoursNonDuty.Text = tbl.Rows[0]["course_hours_non_duty"].ToString();
					txtCourseHoursTotal.Text = tbl.Rows[0]["course_hours_total"].ToString();
					
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

		private void FillDataTypesNeeds()
		{
		
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.TrainingTypesNeedsRecordDesc",conn);
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
				if (tbl.Rows.Count>0)
				{
					SetValue(txtSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
					SetValue(txtPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
					SetValue(txtProgramCode,tbl.Rows[0]["program_code_description"].ToString());
					SetValue(txtAccountNumber,tbl.Rows[0]["account_no"].ToString());
					SetValue(txtDepartmentID,tbl.Rows[0]["dept_id"].ToString());
					SetValue(txtAccomodation,tbl.Rows[0]["ee_need_accomodation"].ToString());
					SetValue(txtAccomodationDescription,tbl.Rows[0]["accomodation_description"].ToString());
					SetValue(txtAccomodationDescription,tbl.Rows[0]["accomodation_description"].ToString());
					SetValue(txtPositionLevel,tbl.Rows[0]["position_level"].ToString()); 
					SetValue(txTypeofAppointment,tbl.Rows[0]["type_of_appointment"].ToString()); 
					SetValue(txtEducationLevel,tbl.Rows[0]["frm_education_level"].ToString()); 
					SetValue(txtTrainingTypeCode,tbl.Rows[0]["frm_training_type_code"].ToString()); 
					SetValue(txtTrainingSubTypeCode,tbl.Rows[0]["frm_training_sub_type_code"].ToString()); 
					SetValue(txtDelivaryTypeCode,tbl.Rows[0]["training_delivery_type_code"].ToString()); 
					SetValue(txtDesignationTypeCode,tbl.Rows[0]["training_designation_code"].ToString()); 
					SetValue(txtCreditTypeCode,tbl.Rows[0]["training_credit_type_code"].ToString()); 
					SetValue(txtAccredetionIndicator,tbl.Rows[0]["accredetion_indicator"].ToString());
					SetValue(txtTrainingCredit,tbl.Rows[0]["training_credit"].ToString());
					SetValue(txtTypeofDevelopmentOther182,tbl.Rows[0]["Type_Of_Development_Other"].ToString());
					SetValue(txtTypeOfDevelopmentSummary,tbl.Rows[0]["TypeofDevelopment"].ToString());
					if (txtTypeOfDevelopmentSummary.Text.Length>2)
						txtTypeOfDevelopmentSummary.Text=txtTypeOfDevelopmentSummary.Text.Substring(2);

					txtAccomodationDescription.Visible= (txtAccomodation.Text=="Yes");
					lblAccomodationDescription.Visible = txtAccomodationDescription.Visible;
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

		private string GetTotalExpense()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="")
				strResult = "0";
			return Convert.ToDouble(strResult).ToString("$#,###.00");
		}

		private void DrawGrid()
		{
			DataTable dt= GetExpenseTable();
			dgExpense.DataSource = dt;
			dgExpense.DataBind();
			lblAmount.Text = GetTotalExpense();
			double dblApprovedAmount = TotalApprovedFromDatabase();			
			lblApprovedAmount.Text = dblApprovedAmount.ToString("$#,##0.00");
			double dblPaidAmount = TotalPaidFromDatabase();			
			lblTotalPaid.Text = dblPaidAmount.ToString("$#,##0.00");
//			SetTotalPaidField();
		}

		private double TotalApprovedFromDatabase()
		{
			string strSQL="select pkg_training.CalcTotalApprovedAmount("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="")
				strResult="0";	
			ViewState["expense"] = strResult;
			return Convert.ToDouble(strResult);
//			double dblTotalApproved = 0;
//			DataTable tbl = (DataTable) dgExpense.DataSource;
//			foreach(DataRow dr in tbl.Rows)
//			{
//				if (dr["approved_amount"].ToString() != "")
//					dblTotalApproved += Convert.ToDouble(dr["approved_amount"].ToString());
//			}
//			return dblTotalApproved;
		}

		private double TotalPaidFromDatabase()
		{
			string strSQL="select pkg_training.CalcTotalPaidAmount("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="")
				strResult="0";			
			return Convert.ToDouble(strResult);
//			double dblTotalpaid = 0;
//			DataTable tbl = (DataTable) dgExpense.DataSource;
//			foreach(DataRow dr in tbl.Rows)
//			{
//				if (dr["paid_amount"].ToString() != "")
//					dblTotalpaid += Convert.ToDouble(dr["paid_amount"].ToString());
//			}
//			return dblTotalpaid;
		}

		private void dgExpense_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
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
						string strStatus = tbl.Rows[indx]["approved"].ToString();
						string strPaidAmount;

//						Label lbl = new Label();
//						lbl.ID = "lbl_"+strindex;
//						strPaidAmount = tbl.Rows[indx]["paid_amount"].ToString();
//						if (strPaidAmount!="")
//							lbl.Text = Convert.ToDouble(strPaidAmount).ToString("$#,###,##0.00");
//						if ((ViewState["Application_Status"].ToString()!="0")&&(ViewState["Application_Status"].ToString()!="1")&&(ViewState["Application_Status"].ToString()!="2"))
//							if (tbl.Rows[indx]["pay_to"].ToString()=="2")
//								lbl.Text = "TBD/ETV";
//						TableCell cell3 = e.Item.Cells[3];
//						cell3.Controls.Add(lbl);
						
						// create drop down
						DropDownList ddl = new DropDownList();
						ddl.CssClass="fontsmall";
						ddl.Width=System.Web.UI.WebControls.Unit.Pixel(75);
						ddl.ID = "ddl_"+strindex;					
						ListItem li = new ListItem("View","0");
						ddl.Items.Add(li);
										
						// create button
						Button btn2 = new Button();
						btn2.CssClass = "actbtn_go_next_button";
						btn2.ID="btn_"+strindex;
						btn2.Text = "Go";
				
						btn2.Click += new System.EventHandler(this.btnMenu_Click);
						TableCell cell = e.Item.Cells[7];						
						cell.Controls.Add(ddl);
						cell.Controls.Add(btn2);

//						System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
//						img.ImageUrl = "";
//						if (strStatus=="A")
//							img.ImageUrl = "Img/Check.GIF";
//						else if (strStatus=="D")
//							img.ImageUrl = "Img/Xcancel.GIF";
//						if (img.ImageUrl!="")
//						{
//							TableCell cell2 = e.Item.Cells[6];						
//							cell2.Controls.Add(img);
//						}
						
					}
					catch
					{
					}
				}
			}
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string strindex = ((Button)sender).ID.Substring(4);
			string strUrl = "AddEditExpense.aspx?expid="+strindex+"&s=v";
			Response.Redirect(strUrl);
			//lblScript.Text = "<script>popup('"+strUrl+"',500,750)</script>";
		}

//		private void lnkbtnBack_Click(object sender, System.EventArgs e)
//		{
//			if (pnlDateTime.Visible)
//				btnVendor_Click(null,null);
//			if (pnlTypesNeeds.Visible)
//				btnDateTime_Click(null,null);
//			if (pnlExpenses.Visible)
//				btnTypesNeeds_Click(null,null);
//		}

//		private void SetTotalPaidField()
//		{
//			string strSQL="select pkg_training.total_paid_amount("+ViewState["Request_Record_ID"].ToString()+") from dual";
//			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
//			if (ob==null)
//				lblPaidAmount.Text = "$0.00";
//			else
//				lblPaidAmount.Text = Convert.ToDouble(ob.ToString()).ToString("$##,0.00") ;
//		}

		private void lnkbtnrestart_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(Request.Params["call"]);
		}

//		private void lnkbtnNext_Click(object sender, System.EventArgs e)
//		{
//			if (pnlVendor.Visible)
//			{
//				btnDateTime_Click(null,null);
//				return;
//			}
//			if (pnlDateTime.Visible)
//			{
//				btnTypesNeeds_Click(null,null);
//				return;
//			}
//			if (pnlTypesNeeds.Visible)
//			{
//				btnExpenses_Click(null,null);
//				return;
//			}
//		}

		private void uts_ActiveTabChanged(object sender, System.EventArgs e)
		{
			switch (uts.ActiveTabIndex)
			{
				case 0 :
					SetVisibility(pnlVendor);
					break;
				case 1 :
					SetVisibility(pnlDateTime);
					break;
				case 2 :
					SetVisibility(pnlTypesNeeds);
					break;
				case 3 :
					DrawGrid();
					SetVisibility(pnlExpenses);
					break;
			}
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			if ((Request.Params["call"] != null) && (Request.Params["Tab"] != ""))
				Response.Redirect(Request.Params["call"]);
			else
				Response.Redirect(SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Return_to"));
		}	
		
		// --------------------2007 Type and needs

		

		private void FillDropDowns()
		{			
			FillOneDropDown(ddlSourseTraining,"cd_training_source ");
			FillOneDropDown(ddlPurposeOfTraining,"cd_training_purpose ");
		}

		private void FillDataTypesNeeds2007()
		{
			FillDropDowns();
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
				if (tbl.Rows.Count!=0)
				{					
					
					SetDropDownIndex(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
					SetDropDownIndex(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
					txtPurposeOfTainingOther.Text = tbl.Rows[0]["purpose_of_training_other"].ToString();
					txtTypeofDevelopmentOther.Text = tbl.Rows[0]["type_of_development_other"].ToString();
					rbAccountNo.Text = tbl.Rows[0]["account_no_description"].ToString();
					txtDepartmentID2007.Text = tbl.Rows[0]["dept_id"].ToString();
					txtProgramCode2007.Text = tbl.Rows[0]["program_code_description"].ToString();
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
				
				int intColPos = 0;
				int intRowPos =0;
				foreach (DataRow dr in tbl.Rows)
				{					
					if (intColPos==1)
					{
						tblTypeofDeve.Rows[intRowPos].Cells[1].Text=dr["description"].ToString();
						intColPos=0;
						intRowPos++;
						
					}
					else
					{
						intColPos=1;
						tblTypeofDeve.Rows[intRowPos].Cells[0].Text=dr["description"].ToString();						
					}
					
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
	}
}
