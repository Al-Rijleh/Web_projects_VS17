using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

namespace PLA_Report
{
	public partial class Training_Request_Summary : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
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
            if (!string.IsNullOrEmpty(hidWhat.Value))
            {
                if (hidWhat.Value.Equals("1"))
                {
                    Button1_Click(null, null);
                }
                else
                    Button2_Click(null, null);
            }
            if (!IsPostBack)
            {
                
                if (String.IsNullOrEmpty(Request.Params["Skip"]))
                {
                    dvPage.Visible = false;
                }
                else
                {
                    dvwhat.Visible = false;
                }
                if ((Request.Params["hedID"] != null) && (Request.Params["hedID"].ToString() != ""))
                {
                    //hlClose.NavigateUrl = "Javascript:document.location.replace('"+BASUSA.MiscTidBit.CheckForSkipCheck(Request.Params["BackTo"])+"')";
                    set_employee_info();
                    set_vendor();
                    set_Course_Dates();
                    set_Types_Needs();
                    set_Expenses();
                    set_History();                   
                }
            }
            //string strBulidPages = "<script>Javascript:Getpage()</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strBulidPages", strBulidPages);
            //SQLStatic.Sessions.SetCLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), Request.Params["hedID"], eld1.Value);

                //Response.Redirect("/web_projects/trn/PLA_Report/ShowAllRequests.aspx?hedID=" + Request.Params["hedID"], true);
                //return;


            if ((Request.Params["eenum"] != null) && (Request.Params["eenum"].ToString() != ""))
            {
                dvViewer.Visible = true;
                DataTable tbl = Data.Get_HeaderRequest(Request.Params["eenum"]);
                foreach (DataRow dr in tbl.Rows)
                {
                   // Response.Redirect("/web_projects/trn/PLA_Report/Training_Request_Summary.aspx?hedID=" + dr["record_id"].ToString(), true);
                    set_employee_info(dr["record_id"].ToString(),dr["course_title"].ToString());
                    set_vendor(dr["record_id"].ToString());
                    set_Course_Dates(dr["record_id"].ToString());
                    set_Types_Needs(dr["record_id"].ToString());
                    set_Expenses(dr["record_id"].ToString());
                    set_History(dr["record_id"].ToString());

                    var sb = new StringBuilder();
                    dvPage.RenderControl(new HtmlTextWriter(new StringWriter(sb)));

                    string s = sb.ToString();
                    Label58.Text = s;// InnerHtml.ToString();                    
                }
                SQLStatic.Sessions.SetCLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), Request.Params["eenum"], Label58.Text);
                //Label58.Text = string.Empty;   
                Label29.Text = Label58.Text;  
             
                dvPage.Visible = false;
            }
            
            
        }

        private void set_employee_info()
		{			
			DataTable tbl= PLA_Report.Data.employee_info(Request.Params["hedID"].ToString());
			lblEmployeeName.Text = tbl.Rows[0]["Name"].ToString();
			lblEmployeeInfo.Text = tbl.Rows[0]["employee_number"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;<b>Soc Sec. No.:</b>&nbsp;" +
								   tbl.Rows[0]["SSN"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;<b>Phone # :</b>&nbsp;" +
								   tbl.Rows[0]["Phone"].ToString();
			lblEmployeeDutyStation.Text = tbl.Rows[0]["DutyStation"].ToString();
            lblHeaderID.Text = Request.Params["hedID"].ToString();
			tbl.Dispose();
		}

		private string Check(string strValue)
		{
			if (strValue != "")
				return strValue;
			else
				return "Unknown";
		}

		private void set_vendor()
		{
			DataTable tbl = PLA_Report.Data.FillData(Request.Params["hedID"].ToString());
			if (tbl.Rows.Count == 0)
				return;
			lblPurposeofTraining.Text = tbl.Rows[0]["desription_of_course_value"].ToString();
			lbltxtCourseCode.Text = Check(tbl.Rows[0]["course_code"].ToString());
			lbltxtCourseTitle.Text = Check(tbl.Rows[0]["course_title"].ToString());
			lbltxtVedorName.Text = Check(tbl.Rows[0]["vendor_name"].ToString());
			lbltxtVendorContact.Text = Check(tbl.Rows[0]["vendor_contact"].ToString());
			lbltxtPhoneNumber.Text = Check(tbl.Rows[0]["vendor_phone_number"].ToString());
			lbltxtFaxNumber.Text = Check(tbl.Rows[0]["vendor_fax_number"].ToString());
			lbltxtAddressLine1.Text = Check(tbl.Rows[0]["vendor_address1"].ToString());
			lbltxtAddressLine2.Text = Check(tbl.Rows[0]["vendor_address2"].ToString());
			lbltxtCity.Text = Check(tbl.Rows[0]["vendor_city"].ToString());
			lbltxtState.Text = Check(tbl.Rows[0]["vendor_state"].ToString());
			lbltxtZipCode.Text = Check(tbl.Rows[0]["vendor_zip_code"].ToString());
			lbltxtWebSite.Text = Check(tbl.Rows[0]["vendor_website"].ToString());
			lblEmail.Text = Check(tbl.Rows[0]["vendor_email"].ToString()); 
			lblPurposeofTraining.Text = Check(tbl.Rows[0]["desription_of_course_value"].ToString());
			lbltxtLearningAddress1.Text = Check(tbl.Rows[0]["training_address1"].ToString());
			lbltxtLearningAddress2.Text = Check(tbl.Rows[0]["training_address2"].ToString());
			lbltxtLearningCity.Text = Check(tbl.Rows[0]["training_city"].ToString());
			lbltxtLearningState.Text = Check(tbl.Rows[0]["training_state"].ToString());
			lbltxtLearningZipCode.Text = Check(tbl.Rows[0]["training_zip"].ToString());
			ViewState["Application_Processing_Year"]= tbl.Rows[0]["processing_year"].ToString();
			tbl.Dispose();
		}

		private void set_Course_Dates()
		{

			DataTable tbl = PLA_Report.Data.FillDataDateTimes(Request.Params["hedID"].ToString());
			if (tbl.Rows.Count == 0)
				return;
			lblStratDate.Text = tbl.Rows[0]["course_start_date"].ToString();
			lblEndDate.Text = tbl.Rows[0]["course_end_date"].ToString();
			lblHourDuty.Text = tbl.Rows[0]["course_hours_duty"].ToString();
			lblhournonduty.Text = tbl.Rows[0]["course_hours_non_duty"].ToString();
			lblHourtotal.Text = tbl.Rows[0]["course_hours_total"].ToString();
			tbl.Dispose();
		}

		private void SetValue(Label lbl, string strValue)
		{
			lbl.Text = strValue;
		}

		private void set_Types_Needs()
		{

			
			bool blnUses2008TypeNeed = PLA_Report.Data.Use2008Types_Needs(Request.Params["hedID"].ToString());
			if (!blnUses2008TypeNeed)
			{
				tableType2008.Visible = false;
				TableTraining2007.Visible = true;
				set_Types_Needs_2007();
			}
			else
			{
				tableType2008.Visible = true;
				TableTraining2007.Visible= false;
			}
			DataTable tbl = PLA_Report.Data.FillDataTypesNeeds(Request.Params["hedID"].ToString());
			if (tbl.Rows.Count == 0)
				return;
				//lblTitleTypesNeeds.Text = lblTitleTypesNeeds.Text + "&nbsp;<i>(Pre-Section 182 implementation)</i>";
			SetValue(lbltxtSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
			SetValue(lbltxtPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
			SetValue(lbltxtProgramCode, tbl.Rows[0]["program_code_description"].ToString());
			SetValue(lbltxtAccountNumber, tbl.Rows[0]["account_no"].ToString());
			SetValue(lbltxtDepartmentID, tbl.Rows[0]["dept_id"].ToString());
			SetValue(lbltxtAccomodation, tbl.Rows[0]["ee_need_accomodation"].ToString());
			SetValue(lbltxtAccomodationDescription, tbl.Rows[0]["accomodation_description"].ToString());
			SetValue(lbltxtAccomodationDescription, tbl.Rows[0]["accomodation_description"].ToString());
			SetValue(lbltxtPositionLevel, tbl.Rows[0]["position_level"].ToString());
			SetValue(lbltxTypeofAppointment, tbl.Rows[0]["type_of_appointment"].ToString());
			SetValue(lbltxtEducationLevel, tbl.Rows[0]["frm_education_level"].ToString());
			SetValue(lbltxtTrainingTypeCode, tbl.Rows[0]["frm_training_type_code"].ToString());
			SetValue(lbltxtTrainingSubTypeCode, tbl.Rows[0]["frm_training_sub_type_code"].ToString());
			SetValue(lbltxtDelivaryTypeCode, tbl.Rows[0]["training_delivery_type_code"].ToString());
			SetValue(lbltxtDesignationTypeCode, tbl.Rows[0]["training_designation_code"].ToString());
			SetValue(lbltxtCreditTypeCode, tbl.Rows[0]["training_credit_type_code"].ToString());
			SetValue(lbltxtAccredetionIndicator, tbl.Rows[0]["accredetion_indicator"].ToString());
			SetValue(lbltxtTrainingCredit, tbl.Rows[0]["training_credit"].ToString());
			SetValue(lbltxtTypeofDevelopmentOther182, tbl.Rows[0]["Type_Of_Development_Other"].ToString());
			SetValue(lbltxtTypeOfDevelopmentSummary, tbl.Rows[0]["TypeofDevelopment"].ToString());
			if (lbltxtTypeOfDevelopmentSummary.Text.Length > 2)
			    lbltxtTypeOfDevelopmentSummary.Text = lbltxtTypeOfDevelopmentSummary.Text.Substring(2);

			lbltxtAccomodationDescription.Visible = (lbltxtAccomodation.Text == "Yes");
			lblAccomodationDescription.Visible = lbltxtAccomodationDescription.Visible;
			tbl.Dispose();
		}

		

		private void set_Types_Needs_2007()
		{
			DataTable tbl = PLA_Report.Data.FillDataTypesNeeds2007(Request.Params["hedID"].ToString());
			if (tbl.Rows.Count == 0)
				return;
			lbltxtPurposeOfTainingOther.Text = tbl.Rows[0]["purpose_of_training_other"].ToString();
			lbltxtTypeofDevelopmentOther.Text = tbl.Rows[0]["type_of_development_other"].ToString();
			lblrbAccountNo.Text = tbl.Rows[0]["account_no_description"].ToString();
			lbltxtDepartmentID2007.Text = tbl.Rows[0]["dept_id"].ToString();
			lbltxtProgramCode2007.Text = tbl.Rows[0]["program_code_description"].ToString();
			lbltxtSource.Text = tbl.Rows[0]["source_of_training"].ToString();
			lbltxtPurpose.Text = tbl.Rows[0]["purpose_of_training"].ToString();
			lblTypeOdDevelopment2007.Text = tbl.Rows[0]["TypeofDevelopment"].ToString();
			if (lblTypeOdDevelopment2007.Text.Length > 2)
				lblTypeOdDevelopment2007.Text = lblTypeOdDevelopment2007.Text.Substring(2);
		}

		private void set_Expenses()
		{
			DataTable tbl = PLA_Report.Data.GetExpenseTable(Request.Params["hedID"].ToString());
			if (tbl.Rows.Count == 0)
				return;
			dgExpense.DataSource = tbl;
			dgExpense.DataBind();
			lblAmount.Text = PLA_Report.Data.GetTotalExpense(Request.Params["hedID"].ToString());
			double dblamount = PLA_Report.Data.TotalApprovedFromDatabase(Request.Params["hedID"].ToString());
			lblApprovedAmount.Text = string.Format("{0:c}", dblamount);
			dblamount = PLA_Report.Data.TotalPaidFromDatabase(Request.Params["hedID"].ToString());
			lblTotalPaid.Text = string.Format("{0:c}",dblamount );
			if (ViewState["Application_Processing_Year"] != null)
				lblExpenseNote.Visible= Convert.ToInt16(ViewState["Application_Processing_Year"].ToString())>=2008;
			dgExpenseNotes.DataSource = tbl;
			dgExpenseNotes.DataBind();
		}

		private void set_History()
		{
			DataTable tbl = PLA_Report.Data.GetHistoryTable(Request.Params["hedID"].ToString());
			if (tbl.Rows.Count == 0)
				return;
			dgHistory.DataSource = tbl;
			dgHistory.DataBind();
		}

        private void set_employee_info(string hedID, string strTitle)
        {
            DataTable tbl = PLA_Report.Data.employee_info(hedID);
            lblEmployeeName.Text = tbl.Rows[0]["Name"].ToString();
            lblEmployeeInfo.Text = tbl.Rows[0]["employee_number"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;<b>Soc Sec. No.:</b>&nbsp;" +
                                   tbl.Rows[0]["SSN"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;<b>Phone # :</b>&nbsp;" +
                                   tbl.Rows[0]["Phone"].ToString();
            lblEmployeeDutyStation.Text = tbl.Rows[0]["DutyStation"].ToString();
            lblHeaderID.Text = hedID + " - " + strTitle;
            tbl.Dispose();
        }


        private void set_vendor(string hedID)
        {
            DataTable tbl = PLA_Report.Data.FillData(hedID);
            if (tbl.Rows.Count == 0)
                return;
            lblPurposeofTraining.Text = tbl.Rows[0]["desription_of_course_value"].ToString();
            lbltxtCourseCode.Text = Check(tbl.Rows[0]["course_code"].ToString());
            lbltxtCourseTitle.Text = Check(tbl.Rows[0]["course_title"].ToString());
            lbltxtVedorName.Text = Check(tbl.Rows[0]["vendor_name"].ToString());
            lbltxtVendorContact.Text = Check(tbl.Rows[0]["vendor_contact"].ToString());
            lbltxtPhoneNumber.Text = Check(tbl.Rows[0]["vendor_phone_number"].ToString());
            lbltxtFaxNumber.Text = Check(tbl.Rows[0]["vendor_fax_number"].ToString());
            lbltxtAddressLine1.Text = Check(tbl.Rows[0]["vendor_address1"].ToString());
            lbltxtAddressLine2.Text = Check(tbl.Rows[0]["vendor_address2"].ToString());
            lbltxtCity.Text = Check(tbl.Rows[0]["vendor_city"].ToString());
            lbltxtState.Text = Check(tbl.Rows[0]["vendor_state"].ToString());
            lbltxtZipCode.Text = Check(tbl.Rows[0]["vendor_zip_code"].ToString());
            lbltxtWebSite.Text = Check(tbl.Rows[0]["vendor_website"].ToString());
            lblEmail.Text = Check(tbl.Rows[0]["vendor_email"].ToString());
            lblPurposeofTraining.Text = Check(tbl.Rows[0]["desription_of_course_value"].ToString());
            lbltxtLearningAddress1.Text = Check(tbl.Rows[0]["training_address1"].ToString());
            lbltxtLearningAddress2.Text = Check(tbl.Rows[0]["training_address2"].ToString());
            lbltxtLearningCity.Text = Check(tbl.Rows[0]["training_city"].ToString());
            lbltxtLearningState.Text = Check(tbl.Rows[0]["training_state"].ToString());
            lbltxtLearningZipCode.Text = Check(tbl.Rows[0]["training_zip"].ToString());
            ViewState["Application_Processing_Year"] = tbl.Rows[0]["processing_year"].ToString();
            tbl.Dispose();
        }

        private void set_Course_Dates(string hedID)
        {

            DataTable tbl = PLA_Report.Data.FillDataDateTimes(hedID);
            if (tbl.Rows.Count == 0)
                return;
            lblStratDate.Text = tbl.Rows[0]["course_start_date"].ToString();
            lblEndDate.Text = tbl.Rows[0]["course_end_date"].ToString();
            lblHourDuty.Text = tbl.Rows[0]["course_hours_duty"].ToString();
            lblhournonduty.Text = tbl.Rows[0]["course_hours_non_duty"].ToString();
            lblHourtotal.Text = tbl.Rows[0]["course_hours_total"].ToString();
            tbl.Dispose();
        }



        private void set_Types_Needs(string hedID)
        {


            bool blnUses2008TypeNeed = PLA_Report.Data.Use2008Types_Needs(hedID);
            if (!blnUses2008TypeNeed)
            {
                tableType2008.Visible = false;
                TableTraining2007.Visible = true;
                set_Types_Needs_2007(hedID);
            }
            else
            {
                tableType2008.Visible = true;
                TableTraining2007.Visible = false;
            }
            DataTable tbl = PLA_Report.Data.FillDataTypesNeeds(hedID);
            if (tbl.Rows.Count == 0)
                return;
            //lblTitleTypesNeeds.Text = lblTitleTypesNeeds.Text + "&nbsp;<i>(Pre-Section 182 implementation)</i>";
            SetValue(lbltxtSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
            SetValue(lbltxtPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
            SetValue(lbltxtProgramCode, tbl.Rows[0]["program_code_description"].ToString());
            SetValue(lbltxtAccountNumber, tbl.Rows[0]["account_no"].ToString());
            SetValue(lbltxtDepartmentID, tbl.Rows[0]["dept_id"].ToString());
            SetValue(lbltxtAccomodation, tbl.Rows[0]["ee_need_accomodation"].ToString());
            SetValue(lbltxtAccomodationDescription, tbl.Rows[0]["accomodation_description"].ToString());
            SetValue(lbltxtAccomodationDescription, tbl.Rows[0]["accomodation_description"].ToString());
            SetValue(lbltxtPositionLevel, tbl.Rows[0]["position_level"].ToString());
            SetValue(lbltxTypeofAppointment, tbl.Rows[0]["type_of_appointment"].ToString());
            SetValue(lbltxtEducationLevel, tbl.Rows[0]["frm_education_level"].ToString());
            SetValue(lbltxtTrainingTypeCode, tbl.Rows[0]["frm_training_type_code"].ToString());
            SetValue(lbltxtTrainingSubTypeCode, tbl.Rows[0]["frm_training_sub_type_code"].ToString());
            SetValue(lbltxtDelivaryTypeCode, tbl.Rows[0]["training_delivery_type_code"].ToString());
            SetValue(lbltxtDesignationTypeCode, tbl.Rows[0]["training_designation_code"].ToString());
            SetValue(lbltxtCreditTypeCode, tbl.Rows[0]["training_credit_type_code"].ToString());
            SetValue(lbltxtAccredetionIndicator, tbl.Rows[0]["accredetion_indicator"].ToString());
            SetValue(lbltxtTrainingCredit, tbl.Rows[0]["training_credit"].ToString());
            SetValue(lbltxtTypeofDevelopmentOther182, tbl.Rows[0]["Type_Of_Development_Other"].ToString());
            SetValue(lbltxtTypeOfDevelopmentSummary, tbl.Rows[0]["TypeofDevelopment"].ToString());
            if (lbltxtTypeOfDevelopmentSummary.Text.Length > 2)
                lbltxtTypeOfDevelopmentSummary.Text = lbltxtTypeOfDevelopmentSummary.Text.Substring(2);

            lbltxtAccomodationDescription.Visible = (lbltxtAccomodation.Text == "Yes");
            lblAccomodationDescription.Visible = lbltxtAccomodationDescription.Visible;
            tbl.Dispose();
        }



        private void set_Types_Needs_2007(string hedID)
        {
            DataTable tbl = PLA_Report.Data.FillDataTypesNeeds2007(hedID);
            if (tbl.Rows.Count == 0)
                return;
            lbltxtPurposeOfTainingOther.Text = tbl.Rows[0]["purpose_of_training_other"].ToString();
            lbltxtTypeofDevelopmentOther.Text = tbl.Rows[0]["type_of_development_other"].ToString();
            lblrbAccountNo.Text = tbl.Rows[0]["account_no_description"].ToString();
            lbltxtDepartmentID2007.Text = tbl.Rows[0]["dept_id"].ToString();
            lbltxtProgramCode2007.Text = tbl.Rows[0]["program_code_description"].ToString();
            lbltxtSource.Text = tbl.Rows[0]["source_of_training"].ToString();
            lbltxtPurpose.Text = tbl.Rows[0]["purpose_of_training"].ToString();
            lblTypeOdDevelopment2007.Text = tbl.Rows[0]["TypeofDevelopment"].ToString();
            if (lblTypeOdDevelopment2007.Text.Length > 2)
                lblTypeOdDevelopment2007.Text = lblTypeOdDevelopment2007.Text.Substring(2);
        }

        private void set_Expenses(string hedID)
        {
            DataTable tbl = PLA_Report.Data.GetExpenseTable(hedID);
            if (tbl.Rows.Count == 0)
                return;
            dgExpense.DataSource = tbl;
            dgExpense.DataBind();
            lblAmount.Text = PLA_Report.Data.GetTotalExpense(hedID);
            double dblamount = PLA_Report.Data.TotalApprovedFromDatabase(hedID);
            lblApprovedAmount.Text = string.Format("{0:c}", dblamount);
            dblamount = PLA_Report.Data.TotalPaidFromDatabase(hedID);
            lblTotalPaid.Text = string.Format("{0:c}", dblamount);
            if (ViewState["Application_Processing_Year"] != null)
                lblExpenseNote.Visible = Convert.ToInt16(ViewState["Application_Processing_Year"].ToString()) >= 2008;
            dgExpenseNotes.DataSource = tbl;
            dgExpenseNotes.DataBind();
        }

        private void set_History(string hedID)
        {
            DataTable tbl = PLA_Report.Data.GetHistoryTable(hedID);
            if (tbl.Rows.Count == 0)
                return;
            dgHistory.DataSource = tbl;
            dgHistory.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Training_Request_Summary.aspx?hedID=" + Request.Params["hedID"] + "&Skip=1", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
             Response.Redirect("Training_Request_Summary.aspx?eenum=" + 
                 Data.employee_number_from_Record_id(Request.Params["hedID"]) + "&Skip=1", true);
        }

        


	}
}
