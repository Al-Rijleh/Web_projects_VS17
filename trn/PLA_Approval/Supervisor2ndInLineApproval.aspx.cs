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
	/// Summary description for Supervisor2ndInLineApproval.
	/// </summary>
	public class Supervisor2ndInLineApproval : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lbl_fldPLA_ApproSupervisorApproval;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtCourseCode;
		protected System.Web.UI.WebControls.TextBox txtCourseTitle;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.TextBox txtLocation;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.TextBox txtVendorContact;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblDescribtion;
		protected System.Web.UI.WebControls.LinkButton lnkbtnViewDescripeValue;
		protected System.Web.UI.WebControls.Panel pnlVendor;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursDuty;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursNonDuty;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursTotal;
		protected System.Web.UI.WebControls.Panel pnlDateTime;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.RadioButtonList optMandatoryTraining;
		protected System.Web.UI.WebControls.RadioButton rbMandatory;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.TextBox txtSource;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.TextBox txtPurpose;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTainingOther;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.Table tblTypeofDeve;
		protected System.Web.UI.WebControls.Label Label44;
		protected System.Web.UI.WebControls.TextBox txtTypeofDevelopmentOther;
		protected System.Web.UI.WebControls.Panel pnlTypesNeeds;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label lblApprovedAmount;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label lblApprovalStatus;
		protected System.Web.UI.WebControls.Label lblPaidExceedApproved;
		protected System.Web.UI.WebControls.Panel pnlExpenses;
		protected System.Web.UI.WebControls.LinkButton lnkbtnBack;
		protected System.Web.UI.WebControls.LinkButton lnkbtnNext;
		protected System.Web.UI.WebControls.Label lbl_FldPLA_ApprovalSuperVisorAbbprovalOptions;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtTrainingType;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.Label Label47;
		protected System.Web.UI.WebControls.TextBox txtDepartmentID;
		protected System.Web.UI.WebControls.TextBox txtProgramCode;
		protected System.Web.UI.WebControls.RadioButton rbAccountNo;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblNotEnoughBudgetThisYear;
		protected System.Web.UI.WebControls.Button btnNoMoneyPeriod;
		protected System.Web.UI.WebControls.Button btnInformee;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.LinkButton lnkbtnViewSummary;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.LinkButton btnExpenses;
		protected System.Web.UI.WebControls.LinkButton btnTypesNeeds;
		protected System.Web.UI.WebControls.LinkButton btnDateTime;
		protected System.Web.UI.WebControls.LinkButton btnVendor;
		protected System.Web.UI.WebControls.Label lblNoteMark;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label lblNoteMarkDetail;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
        protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.Button btnDecline;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
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
			
			
			lblScript.Text= "";
			if (!IsPostBack)
			{
				BASUSA.MiscTidBit.Hide(btnInformee);
				BASUSA.MiscTidBit.Hide(btnNoMoneyPeriod);
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);				
//				lblBalance.Text = AvailableAmount(ViewState["Applicant_Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				SetHeaderInformation();
				FillSatesDropDown();
				FillData();
				FillDataDateTimes();
				FillDropDowns();
				FillDataTypesNeeds();	
				FillSelectedTypeofDevelopment();
				DrawGrid();				
				SetVisibility(pnlExpenses, btnExpenses);
				ProcessesStarFunctionality();
				PLA_Approval.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
				Check_budget(ViewState["Applicant_Employee_Number"].ToString(),ViewState["Application_Processing_Year"].ToString());
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
			}
			if (pnlExpenses.Visible)
			{
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
			this.lnkbtnViewSummary.Click += new System.EventHandler(this.lnkbtnViewSummary_Click_1);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.lnkbtnBack.Click += new System.EventHandler(this.lnkbtnBack_Click);
			this.lnkbtnNext.Click += new System.EventHandler(this.lnkbtnNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Applicant_Employee_Number"].ToString());
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Applicant_Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private void Check_budget(string strEmployeeNumber,string strProcessingYear)
		{
			string return_condition = "";
			string return_text = "";
			PLA_Approval.TrainingClass.CheckBudgetForApproval(ViewState["Request_Record_ID"].ToString(),ViewState["expense"].ToString(),ref return_condition, ref return_text);
			if (return_condition == "1")
				return;
			string labelText = return_text;
			if (return_condition == "2")
			{
				if (PLA_Approval.TrainingClass.SubmitedContinuedServiceAgreement(strEmployeeNumber,strProcessingYear))
					labelText += "\n\nEmployee indicates that he/she has completed the Continued Service Agreement" ;
				else
					labelText += "\n\nEmployee has not completed the Continued Service Agreement Form. Click on this "+
						BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnInformee')")
						+", to inform the applicant (by e-mail) that he/she must complete Continued Service Agreement Form before they can borrow from other years. "+
						"Clicking the link will also reset this application approval status to incomplete.";
			}
			else
			{
				labelText += "\n\nClick this "+
					BASUSA.MiscTidBit.href( "Link","","javascript:Inform('btnNoMoneyPeriod')")
					+", to inform the applicant (by e-mail) that he/she needs to request more money from the Office/Division Director.\n"+
					"Clicking the link will also reset this application approval status to incomplete.";
			}
			lblNotEnoughBudgetThisYear.Text = labelText.Replace("\n","<br>"); 
			lblScript.Text = BASUSA.MiscTidBit.JSAlert(return_text.Replace("\n","\\n"));

		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void FillSatesDropDown()
		{
			DataTable dtStates = SQLStatic.CD_Tables.States(PLA_Approval.TrainingClass.ConnectionString);
			try
			{
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

		private double TotalApprovedFromDatabase()
		{
            //double dblTotalApproved = 0;
            //DataTable tbl = (DataTable) dgExpense.DataSource;
            //foreach(DataRow dr in tbl.Rows)
            //{
            //    if (dr["approved_amount"].ToString() != "")
            //        dblTotalApproved += Convert.ToDouble(dr["approved_amount"].ToString());
            //}
            //return dblTotalApproved;
            string strSQL = "select pkg_training.CalcTotalApprovedAmount(" + ViewState["Request_Record_ID"].ToString() + ") from dual";
            string strResult = SQLStatic.SQL.ExecScaler(strSQL, PLA_Approval.TrainingClass.ConnectionString).ToString();
            if (strResult == "")
                strResult = "0";
            return Convert.ToDouble(strResult);
		}	
	
		private double TotalEstimatedFromDatabase()
		{
			double dblTotalEstimated = 0;
			DataTable tbl = (DataTable) dgExpense.DataSource;
			foreach(DataRow dr in tbl.Rows)
			{
				if (dr["amount"].ToString() != "")
					dblTotalEstimated += Convert.ToDouble(dr["amount"].ToString());
			}
			return dblTotalEstimated;
		}		

		private void FillData()
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				txtCourseCode.Text = "";
				txtCourseTitle.Text = "";
				txtLocation.Text = "";
				txtVedorName.Text = "";
				txtPhoneNumber.Text = "";
				txtFaxNumber.Text = "";
				txtAddressLine1.Text = "";
				txtAddressLine2.Text = "";
				txtCity.Text = "";
				ddlStates.SelectedIndex = 0;
				txtZipCode.Text = "";
				txtWebSite.Text = "";
				lblDescribtion.Text = "";
				return;
			}
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.GetHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				txtCourseCode.Text = tbl.Rows[0]["course_code"].ToString();
				txtCourseTitle.Text = tbl.Rows[0]["course_title"].ToString();
				txtLocation.Text = tbl.Rows[0]["location_of_training"].ToString();
				txtVedorName.Text = tbl.Rows[0]["vendor_name"].ToString();
				txtVendorContact.Text = tbl.Rows[0]["vendor_contact"].ToString();
				txtPhoneNumber.Text = tbl.Rows[0]["vendor_phone_number"].ToString();
				txtFaxNumber.Text = tbl.Rows[0]["vendor_fax_number"].ToString();
				txtAddressLine1.Text = tbl.Rows[0]["vendor_address1"].ToString();
				txtAddressLine2.Text = tbl.Rows[0]["vendor_address2"].ToString();
				txtCity.Text = tbl.Rows[0]["vendor_city"].ToString();
				string strState = tbl.Rows[0]["vendor_state"].ToString();
				txtZipCode.Text = tbl.Rows[0]["vendor_zip_code"].ToString();
				txtWebSite.Text = tbl.Rows[0]["vendor_website"].ToString();
				if (tbl.Rows[0]["desription_of_course_value"].ToString().Length >100)
					lblDescribtion.Text = tbl.Rows[0]["desription_of_course_value"].ToString().Substring(0,95)+"...";
				else
					lblDescribtion.Text = tbl.Rows[0]["desription_of_course_value"].ToString();
				ViewState["application_status"]= tbl.Rows[0]["application_status"].ToString();
				ViewState["description"]=tbl.Rows[0]["description"].ToString();
				ViewState["Application_Processing_Year"]=tbl.Rows[0]["processing_year"].ToString();
				for (int i=0;i<ddlStates.Items.Count;i++)
					if (ddlStates.Items[i].Value==strState)
					{
						ddlStates.SelectedIndex = i;
						break;
					}
				txtState.Text=ddlStates.SelectedItem.Text;
				txtTrainingType.Text = tbl.Rows[0]["training_type"].ToString()=="1" ? "Within Employee’s Occupation" : "Outside Employee’s Occupation";
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
			if (txtCourseCode.Text!="")
				lblCourseTitle.Text= txtCourseCode.Text+" - "+txtCourseTitle.Text;
			else
				lblCourseTitle.Text=txtCourseTitle.Text;
		}
		private void FillDataDateTimes()
		{
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
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
				if (tbl.Rows.Count>0)
				{
					txtStartDate.Text = tbl.Rows[0]["course_start_date"].ToString();
					txtEndDate.Text = tbl.Rows[0]["course_end_date"].ToString();
					string strCourseTime = tbl.Rows[0]["course_time"].ToString();
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

		private void FillOneDropDown(DropDownList ddl,string strTableName)
		{
			
			ddl.Items.Clear();
			ddl.Items.Add(new ListItem("---- Select ----","xx"));
			string strSQL="select record_id,description from "+strTableName;
			Oracle.DataAccess.Client.OracleConnection conn = 	new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
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

		private void FillDropDowns()
		{
			FillOneDropDown(ddlSourseTraining,"cd_training_source ");
			FillOneDropDown(ddlPurposeOfTraining,"cd_training_purpose ");
		}

		private void FillDataTypesNeeds()
		{
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
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
				if (tbl.Rows.Count>0)
				{
					rbMandatory.Text= tbl.Rows[0]["mandatory_training"].ToString()=="T" ? "Mandatory" : "Non-Mandatory";
					SetDropDownIndex(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
					SetDropDownIndex(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
					txtPurpose.Text =ddlPurposeOfTraining.SelectedItem.Text;
					txtSource.Text = ddlSourseTraining.SelectedItem.Text;
					txtPurposeOfTainingOther.Text = tbl.Rows[0]["purpose_of_training_other"].ToString();
					txtTypeofDevelopmentOther.Text = tbl.Rows[0]["type_of_development_other"].ToString();
					rbAccountNo.Text = tbl.Rows[0]["account_no_description"].ToString();
					txtDepartmentID.Text = tbl.Rows[0]["dept_id"].ToString();
					txtProgramCode.Text = tbl.Rows[0]["program_code_description"].ToString();
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
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
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
		private DataTable GetExpenseTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
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

		private double GetTotalExpenseDouble()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strResult=="")
				strResult="0";
			ViewState["expense"] = strResult;
			return Convert.ToDouble(strResult);
		}

		private string GetTotalExpense()
		{
			return GetTotalExpenseDouble().ToString("$#,###.00");
		}

		private void DrawGrid()
		{
			DataTable dt= GetExpenseTable();
			dgExpense.DataSource = dt;
			dgExpense.DataBind();
			lblAmount.Text = GetTotalExpense();
			double dblApprovedAmount = TotalApprovedFromDatabase();
			double dblEstimatedAmount = GetTotalExpenseDouble();
			if ((Math.Abs(dblApprovedAmount)<0.01)&&(dblEstimatedAmount>0.01))
			{
				lblApprovalStatus.Text = "Declined All Expenses";
				ViewState["App_Status"] = "6";
			} 
			else if (Math.Abs(dblApprovedAmount-dblEstimatedAmount)<0.01)
			{
				lblApprovalStatus.Text = "Paid in Full";
				ViewState["App_Status"] = "4";
			}
			else
			{
				lblApprovalStatus.Text = "Paid Partial Expenses";
				ViewState["App_Status"] = "5";
			}
			  
			if ((dblApprovedAmount-dblEstimatedAmount)>0.01)
			{
				lblPaidExceedApproved.Text = "(Approved Amount Exceed Estimated Amount)";
			}
			else
			{
				lblPaidExceedApproved.Text="";
			}

			lblAmount.Text = dblEstimatedAmount.ToString("$#,##0.00");
			lblApprovedAmount.Text = dblApprovedAmount.ToString("$#,##0.00");
		
		}

		private void dgExpense_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			
		}
		
		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string btnID = ((Button)sender).ID;
			string strindex = btnID.Substring(4);
			if (btnID.IndexOf("btn_")!=-1)
			{
				string strUrl = "AddEditExpense.aspx?expid="+strindex+"&s=v&w=s";
				lblScript.Text = "<script>popup('"+strUrl+"',500,750)</script>";
			}
			
		}

		private void SetApproveColumnStatus()
		{
			bool inEdit = ViewState["inEdit"].ToString()=="T";
				
			dgExpense.Columns[2].Visible=inEdit;
			dgExpense.Columns[3].Visible=!inEdit;
			btnDateTime.Enabled = !inEdit;
			btnTypesNeeds.Enabled = !inEdit;
			btnVendor.Enabled = !inEdit;
			lnkbtnBack.Enabled = !inEdit;
			btnSave.Enabled = !inEdit;
			btnDecline.Enabled = !inEdit;
			lblApprovedAmount.Visible = !inEdit;
            if (btnSave.Enabled)
			{
				double dblApprovedAmount = TotalApprovedFromDatabase();
				double dblEstimatedAmount = GetTotalExpenseDouble();
                btnSave.Enabled = (dblApprovedAmount > 0.01) || (dblEstimatedAmount < 0.01);					
			}			
		}

		private void SetVisibility(Panel pnl, LinkButton btn)
		{
			btnVendor.Enabled=true;
			btnDateTime.Enabled=true;
			btnTypesNeeds.Enabled=true;
			btnExpenses.Enabled=true;

			pnlVendor.Visible = false;
			pnlDateTime.Visible = false;
			pnlTypesNeeds.Visible = false;
			pnlExpenses.Visible = false;

			pnl.Visible = true;
			btn.Enabled = false;
		}

		private void btnExpenses_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlExpenses, btnExpenses);
			lnkbtnBack.Enabled = true;
			lnkbtnNext.Enabled = false;			
			DrawGrid();
			ViewState["inEdit"]="F";
			SetApproveColumnStatus();
		}

		private void btnDateTime_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlDateTime, btnDateTime);
			lnkbtnBack.Enabled = true;
			lnkbtnNext.Enabled = true;
		}

		private void btnTypesNeeds_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlTypesNeeds, btnTypesNeeds);
			lnkbtnBack.Enabled = true;
			lnkbtnNext.Enabled = true;
		}

		private void btnVendor_Click(object sender, System.EventArgs e)
		{
			SetVisibility(pnlVendor, btnVendor);
			lnkbtnBack.Enabled = false;
			lnkbtnNext.Enabled = true;
		}

		

		private void lnkbtnBack_Click(object sender, System.EventArgs e)
		{
			if (pnlDateTime.Visible)
				btnVendor_Click(null,null);
			if (pnlTypesNeeds.Visible)
				btnDateTime_Click(null,null);
			if (pnlExpenses.Visible)
				btnTypesNeeds_Click(null,null);
		}

		private void lnkbtnNext_Click(object sender, System.EventArgs e)
		{
			if (pnlVendor.Visible)
			{
				btnDateTime_Click(null,null);
				return;
			}
			if (pnlDateTime.Visible)
			{
				btnTypesNeeds_Click(null,null);
				return;
			}
			if (pnlTypesNeeds.Visible)
			{
				btnExpenses_Click(null,null);
				return;
			}
		}

		private void lnkbtnViewDescripeValue_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>popup('ViewAdditionInfo.aspx',500,700)</script>";
		}				

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = PLA_Approval.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Applicant_Employee_Number"].ToString());
		}

		private void SubmitNoMoney(string straction)
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_trn_budget.HandelBudgetEmail",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"pla_header_record_id_","varchar2","in",ViewState["Request_Record_ID"].ToString());				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"action_","varchar2","in",straction);								
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reset_approval_","varchar2","in","1");
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			}
			Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES");
		}

		private void btnInformee_Click(object sender, System.EventArgs e)
		{
			SubmitNoMoney("29");
		}

		private void btnNoMoneyPeriod_Click(object sender, System.EventArgs e)
		{
			SubmitNoMoney("30");
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SupervisorPendingApplications.aspx?SkipCheck=YES");
		}

		private void lnkbtnViewSummary_Click(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","true",PLA_Approval.TrainingClass.ConnectionString);
			Response.Redirect("/Web_Projects/trn/PLA/NewSummary.aspx?call="+Request.Path+"?SkipCheck=YES");
		}

		private void lnkbtnViewSummary_Click_1(object sender, System.EventArgs e)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Use_App_ee_Number","true",PLA_Approval.TrainingClass.ConnectionString);
			Response.Redirect("/Web_Projects/trn/PLA/NewSummary.aspx?call="+Request.Path+"?SkipCheck=YES");
		}

        protected void dgExpense_ItemCreated1(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                (e.Item.ItemType == ListItemType.AlternatingItem) ||
                (e.Item.ItemType == ListItemType.SelectedItem))
            {
                if ((e.Item.ItemType == ListItemType.Item) ||
                    (e.Item.ItemType == ListItemType.AlternatingItem) ||
                    (e.Item.ItemType == ListItemType.SelectedItem))
                {
                    try
                    {
                        int indx = e.Item.ItemIndex;
                        DataTable tbl = (DataTable)dgExpense.DataSource;
                        string strindex = tbl.Rows[indx]["record_id"].ToString();
                        ViewState["est_" + strindex] = tbl.Rows[indx]["amount"].ToString();

                        // create drop down
                        DropDownList ddl = new DropDownList();
                        ddl.CssClass = "fontsmall";
                        ddl.Width = System.Web.UI.WebControls.Unit.Pixel(75);
                        ddl.ID = "ddl_" + strindex;
                        ListItem li = new ListItem("View", "0");
                        ddl.Items.Add(li);
                        // create button
                        Button btn2 = new Button();
                        btn2.CssClass = "actbtn_go_next_button";
                        btn2.ID = "btn_" + strindex;
                        btn2.Text = "Go";
                        btn2.CausesValidation = false;
                        btn2.Click += new System.EventHandler(this.btnMenu_Click);
                        TableCell cell = e.Item.Cells[8];
                        cell.Controls.Add(ddl);
                        cell.Controls.Add(btn2);

                        TextBox txtapp = new TextBox();
                        txtapp.ID = "txt_app_" + strindex;
                        txtapp.Text = tbl.Rows[indx]["approved_amount"].ToString();
                        txtapp.CssClass = "fontsmall";
                        txtapp.Width = System.Web.UI.WebControls.Unit.Pixel(50);



                        TableCell cellApp = e.Item.Cells[2];
                        cellApp.Controls.Add(txtapp);
                        //						cellApp.Controls.Add(btn3);		

                        Button btn3 = new Button();
                        btn3.CssClass = "act_savenext_button";
                        btn3.ID = "cpy_" + strindex;
                        btn3.Text = "";
                        btn3.Width = System.Web.UI.WebControls.Unit.Pixel(20);
                        btn3.CausesValidation = false;
                        btn3.ToolTip = "Copy To Approved Amount";
                        btn3.Click += new System.EventHandler(this.btnMenu_Click);

                        Label lbl = new Label();
                        lbl.ID = "lbl_" + strindex;
                        double dbl = Convert.ToDouble(tbl.Rows[indx]["amount"].ToString());
                        lbl.Text = dbl.ToString("$#,##0.00") + "  ";
                        lbl.CssClass = "fontsmall";
                        TableCell cellApp1 = e.Item.Cells[1];
                        cellApp1.Controls.Add(lbl);
                        if (ViewState["inEdit"].ToString() == "T")
                            cellApp1.Controls.Add(btn3);
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "From_2nd_supervisor", "T", PLA_Approval.TrainingClass.ConnectionString);
            Response.Redirect("SupervisorApprove.aspx");
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "From_2nd_supervisor", "T", PLA_Approval.TrainingClass.ConnectionString);
            Response.Redirect("SupervisorDecline.aspx");
        }

	


	}
}
