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

namespace TriningTypesNeeds
{
    public partial class _Default : System.Web.UI.Page
    {
        private DataTable tblTypeOfDevelopment = null;
        private int FieldCounter = 0;
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Data.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
                Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out" + "&backurl=0", true);
            lblScript.Text = "";

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
                    ViewState["Page"] = objBasTemplate.strPageId;
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
                ViewState["Employee_Number"] = Data.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(), Request.Cookies["Session_ID"].Value.ToString());
                btnSave.Attributes.Add("onclick", "Do_Save()");
                setHelp();
                Data.SetValidators(Page);
                lblBalance.Text = Data.AvailableAmount(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());
                ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Request_Record_ID", Data.ConnectioString);
                ViewState["Mandatory_Only"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Mandatory_Only", Data.ConnectioString);
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "HelpPage", ViewState["Page"].ToString());
                SetHeaderInformation();
                FillDropDowns();
                FillData();
                if (txtDepartmentID.Text == "")
                    GetDeptId();
                ProcessesStarFunctionality(); ;
                string strProcessingYear = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "CoursePY", Data.ConnectioString);
                string strWarning = "The training request you are appling for is in development year \"" + strProcessingYear + "\". You do not have an approved CDP for this year. You may not change the selected Account#";
                Data.FillBudgetYears(ddlBudgetYear, lblBalance, ViewState["Employee_Number"].ToString(), strProcessingYear);
                FillTypeOfDevelopmentTextBox(true);
                SetupWizardMenu();
                ddlDesignationTypeCode_SelectedIndexChanged1(null, null);
                ddlCreditTypeCode_SelectedIndexChanged1(null, null);
                ddlAccomodation_SelectedIndexChanged2(null, null);
            }
            CheckHeaderIDSet();
            HandleContractors();
            FillTypeOfDevelopmentTextBox(false);
            if (dgTrainingTypeCode.Visible)
                DrawTrainingTypeCode();
            if (dgEducationLevel.Visible)
                DrawEducationLevel();
            if (!(Request.Form["doSave"] == null || Request.Form["doSave"] == ""))
            {
                string strGoTo = Request.Form["doSave"].Replace("'", "");
                doSave.Value = "";
                this.Validate();
                if (this.IsValid)
                {
                    DoSave();
                    Response.Redirect(strGoTo);
                }
            }
        }

        private void SetupNextButton()
        {
            string strIncomplatePages =
                SQLStatic.SQL.ExecScaler("select pkg_training.incompletepages(" + ViewState["Request_Record_ID"].ToString() + ")from dual").ToString();
            btnNext.Visible = Data.PageCompleted(Request.Path, strIncomplatePages);
        }

        private void SetHeaderInformation()
        {
            ViewState["Account_Number"] = Data.GetAccountNumber(ViewState["Employee_Number"].ToString());
            lblCourseTitle.Text = Data.CourseName(ViewState["Request_Record_ID"].ToString());
            string parPtemplate = Data.SetHeader(Page);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "parPtemplate", parPtemplate);
        }

        private void FillDropDowns()
        {
            //			FillOneDropDown(ddlAccountNumber,"pkg_training_3.get_account_number",true);
            FillOneDropDown(ddlPositionLevel, "pkg_training_3.Get_cd_trn_position_level", true);
            FillOneDropDown(ddlPurposeOfTraining, "pkg_training_3.Get_cd_training_purpose_182", true);
            FillOneDropDown(ddlSourseTraining, "pkg_training_3.Get_cd_training_source_182", true);
            FillOneDropDown(ddlAccredetionIndicator, "pkg_training_3.Get_cd_accredetion_indicator", true);
            FillOneDropDown(ddlTypeofAppointment, "pkg_training_3.Get_cd_trn_Type_of_appointment", true);
            FillOneDropDown(ddlDelivaryTypeCode, "pkg_training_3.Get_cd_training_delivery_code", true);
            FillOneDropDown(ddlDesignationTypeCode, "pkg_training_3.Get_cd_training_designation_cd", true);
            FillOneDropDown(ddlCreditTypeCode, "pkg_training_3.Get_cd_training_credit_code", true);
        }

        private void FillData()
        {
            string strTypesAndNeeds = TrainingTypeAndNeedsRecord_Id();
            if (strTypesAndNeeds == "-1")
            {
                FillNewRecordData();
                return;
            }
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.TrainingTypesNeedsRecord", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", ViewState["Request_Record_ID"].ToString());
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_4_record", "cursor", "out", "");

            DataSet mds = new DataSet();
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            DataTable tbl = null;
            try
            {
                conn.Open();
                da.Fill(mds);
                tbl = mds.Tables[0];
                SetValue(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
                SetValue(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
                if (string.IsNullOrEmpty(tbl.Rows[0]["program_code_description"].ToString()))
                    SetValue(txtProgramCode, tbl.Rows[0]["program_code"].ToString());
                else
                    SetValue(txtProgramCode, tbl.Rows[0]["program_code_description"].ToString());
                //				SetValue(ddlAccountNumber,tbl.Rows[0]["account_no"].ToString());
                SetValue(txtDepartmentID, tbl.Rows[0]["dept_id"].ToString());
                SetValue(ddlAccomodation, tbl.Rows[0]["ee_need_accomodation"].ToString());
                SetValue(txtAccomodationDescription, tbl.Rows[0]["accomodation_description"].ToString());
                SetValue(ddlPositionLevel, tbl.Rows[0]["position_level"].ToString());
                SetValue(ddlTypeofAppointment, tbl.Rows[0]["type_of_appointment"].ToString());
                SetValue(txtEducationLevel, tbl.Rows[0]["frm_education_level"].ToString());
                SetValue(txtTrainingTypeCode, tbl.Rows[0]["frm_training_type_code"].ToString());
                SetValue(txtTrainingSubTypeCode, tbl.Rows[0]["frm_training_sub_type_code"].ToString());
                SetValue(ddlDelivaryTypeCode, tbl.Rows[0]["training_delivery_type_code"].ToString());
                SetValue(ddlDesignationTypeCode, tbl.Rows[0]["training_designation_code"].ToString());
                SetValue(ddlCreditTypeCode, tbl.Rows[0]["training_credit_type_code"].ToString());
                SetValue(ddlAccredetionIndicator, tbl.Rows[0]["accredetion_indicator"].ToString());            
                SetValue(txtTrainingCredit, tbl.Rows[0]["training_credit"].ToString());

                SetValue(txtTypeofDevelopmentOthers, tbl.Rows[0]["Type_Of_Development_Other"].ToString());
                SetValue(txtDesignationOther, tbl.Rows[0]["training_designation_other"].ToString());
                SetValue(txtCreditTypeOther, tbl.Rows[0]["training_credit_type_other"].ToString());

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
            ddlAccomodation_SelectedIndexChanged2(null, null);
            FillTypeOfDevelopmentTextBox(true);
            SetValue(txtTypeOfDevelopmentSummary, txtTypeOfDevelopmentSummary.Text);
        }

        private void FillNewRecordData()
        {
            ddlSourseTraining.SelectedIndex = 0;
            ddlPurposeOfTraining.SelectedIndex = 0;
            ddlAccomodation.SelectedIndex = 1;

            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training.defaulttypeandneeds", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", ViewState["Employee_Number"].ToString());
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_", "cursor", "out", "");
            DataSet mds = new DataSet();
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            DataTable tbl = null;
            try
            {
                conn.Open();
                da.Fill(mds);
                tbl = mds.Tables[0];
                SetValue(ddlPositionLevel, tbl.Rows[0]["position_level"].ToString());
                SetValue(ddlAccomodation, tbl.Rows[0]["ee_need_accomodation"].ToString());
                SetValue(txtAccomodationDescription, tbl.Rows[0]["accomodation_description"].ToString());
                SetValue(ddlTypeofAppointment, tbl.Rows[0]["type_of_appointment"].ToString());
                SetValue(txtEducationLevel, tbl.Rows[0]["Education_Level_desc"].ToString());
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
            ddlAccomodation_SelectedIndexChanged2(null, null);
            ClearTypeOfDevelopment();
            SetValue(txtTypeOfDevelopmentSummary, "");

        }

        private void ClearTypeOfDevelopment()
        {
            foreach (ListItem li in chklstTypeofDev.Items)
                li.Selected = false;
        }

        private void FillTypeOfDevelopmentTextBox(bool blnInintal)
        {
            if (blnInintal)
            {
                pnlDevelopmentType.Visible = true;
                ProcessTypeOfDevelopment();
                pnlDevelopmentType.Visible = false;
            }
            txtTypeOfDevelopmentSummary.Text = "";
            if (chklstTypeofDev.Visible)
            {
                foreach (ListItem li in chklstTypeofDev.Items)
                {
                    if (li.Selected)
                        txtTypeOfDevelopmentSummary.Text += li.Text + ", ";
                }
                int txtLength = txtTypeOfDevelopmentSummary.Text.Length;
                if (txtLength > 2)
                    txtTypeOfDevelopmentSummary.Text = txtTypeOfDevelopmentSummary.Text.Substring(0, txtLength - 2);
            }
            else
            {
                foreach (ListItem li in optlstTypeofDev.Items)
                {
                    if (li.Selected)
                    {
                        txtTypeOfDevelopmentSummary.Text = li.Text;
                        break;
                    }
                }
            }
        }

        private void GetDeptId()
        {
            string strSQL = "select pkg_training.employee_dept_id(" + ViewState["Employee_Number"].ToString() + ") from dual";
            txtDepartmentID.Text = SQLStatic.SQL.ExecScaler(strSQL, Data.ConnectioString).ToString();
        }

        private void ProcessesStarFunctionality()
        {
            BasStar2009.StarFunctionality star = new BasStar2009.StarFunctionality();
            //star.ConnStr = Data.ConnectioString;
            star.SetLabel(this, ViewState["Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(),
                Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
            star = null;
        }

        private string TrainingTypeAndNeedsRecord_Id()
        {
            return SQLStatic.SQL.ExecScaler("select PKG_Training.training_types_needs_record_id(" + ViewState["Request_Record_ID"].ToString() + ") from dual", Data.ConnectioString).ToString();
        }

        private void CheckHeaderIDSet()
        {
            if (ViewState["Request_Record_ID"].ToString() == "-1")
            {
                lblScript.Text = "<script>alert('Vendor Information page must be completed first');window.location.href='TrainingVendorInfo.aspx';</script>";
            }
        }

        private void HandleContractors()
        {
            if (!Data.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
                return;
            Data.DisableAll(this, ViewState["User_Primary_Role"].ToString());
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            //htmbtnSave.Disabled = true;
            btnSave.Visible = false;
            ddlBudgetYear.Enabled = true;
        }

        private void SetValue(TextBox txt, string strValue)
        {
            if (strValue == null)
                return;
            txt.Text = strValue;
            ViewState[txt.ID] = strValue;
            ViewState["id_" + FieldCounter] = txt.ID;
            FieldCounter++;
        }

        private void SetValue(DropDownList ddl, string strValue)
        {
            if (strValue == null)
                return;
            ddl.SelectedIndex = -1;
            foreach (ListItem li in ddl.Items)
            {
                if ((li.Value == strValue) && (!li.Selected))
                    li.Selected = true;
                if (li.Selected)
                {
                    ViewState[ddl.ID] = strValue;
                    ViewState["id_" + FieldCounter] = ddl.ID;
                    FieldCounter++;
                    break;
                }
            }
        }

        private void SetValue(RadioButtonList opt, string strValue)
        {
            if (strValue == null)
                return;
            foreach (ListItem li in opt.Items)
            {
                li.Selected = (li.Value == strValue);
                if (li.Selected)
                {
                    ViewState[opt.ID] = strValue;
                    ViewState["id_" + FieldCounter] = opt.ID;
                    FieldCounter++;
                    break;
                }
            }
        }
        private void FillOneDropDown(DropDownList ddl, string function_name, bool blnHasSelect)
        {

            ddl.Items.Clear();
            if (blnHasSelect)
                ddl.Items.Add(new ListItem("---- Select ----", "xx"));

            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(function_name, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retResult_", "cursor", "out", null);
            conn.Open();
            Oracle.DataAccess.Client.OracleDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem li = new ListItem(reader.GetValue(1).ToString(), reader.GetValue(0).ToString());
                    ddl.Items.Add(li);
                }
            }
            finally
            {
                reader = null;
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private bool DataChanged()
        {
            bool blnChanged = false;
            TextBox txt = null;
            DropDownList ddl = null;
            string fldId = "";
            for (int i = 0; i <= 100; i++)
            {
                if (ViewState["id_" + i.ToString()] != null)
                {
                    fldId = ViewState["id_" + i.ToString()].ToString();
                    if (fldId.IndexOf("txt") == 0)
                    {
                        txt = (TextBox)Page.FindControl(fldId);
                        if (txt != null)
                        {
                            blnChanged = txt.Text != ViewState[fldId].ToString();
                            if (blnChanged)
                                break;
                        }
                    }
                    else
                    {
                        ddl = (DropDownList)Page.FindControl(fldId);
                        if (ddl != null)
                        {
                            blnChanged = ddl.SelectedValue != ViewState[fldId].ToString();
                            if (blnChanged)
                                break;
                        }
                    }
                }
            }
            return blnChanged;
        }

        private void DoSave()
        {
            Validate();
            if (!IsValid)
            {
                return;
            }
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
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
            string strCode = txtProgramCode.Text.Substring(0, 5);



            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "header_record_id_", ViewState["Request_Record_ID"].ToString());
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_type_", null);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "mandatory_training_", null);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "source_of_training_", ddlSourseTraining.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "purpose_of_training_", ddlPurposeOfTraining.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Dept_ID_", txtDepartmentID.Text);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Program_Code_", strCode);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Account_no_", "5632");

            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ee_need_accomodation_", ddlAccomodation.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "accomodation_description_", txtAccomodationDescription.Text);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "position_level_", ddlPositionLevel.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "type_of_appointment_", ddlTypeofAppointment.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "education_level_", txtEducationLevel.Text.Substring(0, 2));
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_type_code_", txtTrainingTypeCode.Text.Substring(0, 2));
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_sub_type_code_", txtTrainingSubTypeCode.Text.Substring(0, 2));
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_delivery_type_code_", ddlDelivaryTypeCode.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_designation_code_", ddlDesignationTypeCode.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_credit_type_code_", ddlCreditTypeCode.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "accredetion_indicator_", ddlAccredetionIndicator.SelectedValue);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Type_of_development_other_", txtTypeofDevelopmentOthers.Text);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "txtTypeOfDevelopmentSummary", txtTypeOfDevelopmentSummary.Text);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_credit_", txtTrainingCredit.Text);

            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_designation_other_", txtDesignationOther.Text);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "training_credit_type_other", txtCreditTypeOther.Text);

            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "user_id_", ViewState["User_Name"].ToString());





            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
                "basdba.PKG_Training.SaveUpdateTrainingTypesRecord", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            try
            {
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", "number", "in", ViewState["Request_Record_ID"].ToString());
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_type_", "number", "in", null);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "mandatory_training_", "varchar2", "in", null);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "source_of_training_", "number", "in", ddlSourseTraining.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "purpose_of_training_", "number", "in", ddlPurposeOfTraining.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Dept_ID_", "varchar2", "in", txtDepartmentID.Text);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Program_Code_", "varchar2", "in", strCode);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Account_no_", "varchar2", "in", "5632");

                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "ee_need_accomodation_", "number", "in", ddlAccomodation.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "accomodation_description_", "varchar2", "in", txtAccomodationDescription.Text);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "position_level_", "varchar2", "in", ddlPositionLevel.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "type_of_appointment_", "varchar2", "in", ddlTypeofAppointment.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "education_level_", "number", "in", txtEducationLevel.Text.Substring(0, 2));
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_type_code_", "number", "in", txtTrainingTypeCode.Text.Substring(0, 2));
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_sub_type_code_", "number", "in", txtTrainingSubTypeCode.Text.Substring(0, 2));
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_delivery_type_code_", "number", "in", ddlDelivaryTypeCode.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_designation_code_", "number", "in", ddlDesignationTypeCode.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_credit_type_code_", "number", "in", ddlCreditTypeCode.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "accredetion_indicator_", "number", "in", ddlAccredetionIndicator.SelectedValue);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Type_of_development_other_", "varchar2", "in", txtTypeofDevelopmentOthers.Text);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_credit_", "varchar2", "in", txtTrainingCredit.Text);

                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_designation_other_", "varchar2", "in", txtDesignationOther.Text);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "training_credit_type_other", "varchar2", "in", txtCreditTypeOther.Text);

                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_id_", "varchar2", "in", ViewState["User_Name"].ToString());
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "new_record_id_", "number", "out", "");

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
                "basdba.PKG_Training.clear_type_of_development", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", "number", "in", ViewState["Request_Record_ID"].ToString());
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
                "basdba.PKG_Training.add_type_of_development", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;

            try
            {
                if (chklstTypeofDev.Visible)
                {
                    foreach (ListItem li in chklstTypeofDev.Items)
                    {
                        if (li.Selected)
                        {
                            cmd.Parameters.Clear();
                            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", "number", "in", ViewState["Request_Record_ID"].ToString());
                            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "type_of_development_", "number", "in", li.Value);
                            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", "varchar2", "in", ViewState["User_Name"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    foreach (ListItem li in optlstTypeofDev.Items)
                    {
                        if (li.Selected)
                        {
                            cmd.Parameters.Clear();
                            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", "number", "in", ViewState["Request_Record_ID"].ToString());
                            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "type_of_development_", "number", "in", li.Value);
                            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", "varchar2", "in", ViewState["User_Name"].ToString());
                            cmd.ExecuteNonQuery();
                        }
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








    
        // =======================================Program Code Panel Start
        private void btnClose1_Click(object sender, System.EventArgs e)
        {
            pnlData.Visible = true;
            pnlProgramCode.Visible = false;
        }

        private void FillProgramCode()
        {
            string strCode = "";
            if (txtProgramCode.Text.Length > 5)
                strCode = txtProgramCode.Text.Substring(0, 5);
            System.Data.DataTable dTable;
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd =
                new Oracle.DataAccess.Client.OracleCommand("pkg_training.program_code_list", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_", "cursor", "out", "");
            Oracle.DataAccess.Client.OracleDataAdapter da =
                new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            DataSet mds = new DataSet();
            conn.Open();
            try
            {
                da.Fill(mds, "Purpose");
                dTable = mds.Tables["Purpose"];
                optProgramCode.Items.Clear();

                foreach (DataRow dr in dTable.Rows)
                {
                    ListItem li = new ListItem(dr["program_code"].ToString() + " - " + dr["description"].ToString(), dr["program_code"].ToString() + " - " + dr["description"].ToString());
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
                dTable = null;
            }
        }

        private void optProgramCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtProgramCode.Text = optProgramCode.SelectedValue;
            btnClose1_Click(null, null);
        }

        // =======================================Training Type Code Start

        private DataTable GetTraingTypeCodeData()
        {
            string strCode = "";
            if (txtProgramCode.Text.Length > 5)
                strCode = txtProgramCode.Text.Substring(0, 5);
            System.Data.DataTable dTable;
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd =
                new Oracle.DataAccess.Client.OracleCommand("pkg_training_3.Get_cd_training_type_code", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retResult_", "cursor", "out", null);
            Oracle.DataAccess.Client.OracleDataAdapter da =
                new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            DataSet mds = new DataSet();
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
            dgTrainingTypeCode.DataSource = GetTraingTypeCodeData();
            dgTrainingTypeCode.DataBind();
        }


     
        private void btnMenu_Click(object sender, System.EventArgs e)
        {

            DataTable dt = (DataTable)dgTrainingTypeCode.DataSource;
            string strSelectedSubCode = ((LinkButton)sender).ID.Substring(4);
            foreach (DataRow dw in dt.Rows)
            {
                if (dw["sub_code"].ToString() == strSelectedSubCode)
                {
                    txtTrainingTypeCode.Text = dw["code"].ToString().PadLeft(2, '0') + " - " + dw["code_description"].ToString();
                    txtTrainingSubTypeCode.Text = dw["sub_code"].ToString().PadLeft(2, '0') + " - " + dw["sub_code_description"].ToString();
                    break;
                }
            }
            btnCloseTrainingType1_Click(null, null);
        }

        private void dgTrainingTypeCode_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataTable dt = (DataTable)dgTrainingTypeCode.DataSource;
            string strCode = "";
            if (txtTrainingSubTypeCode.Text.Length >= 2)
                strCode = Convert.ToInt32(txtTrainingSubTypeCode.Text.Substring(0, 2)).ToString();
            try
            {
                if (dt.Rows[e.Item.ItemIndex]["sub_code"].ToString() == strCode)
                    e.Item.BackColor = System.Drawing.Color.Gold;
            }
            catch
            {
            }
        }

        // =======================================Education Level Start

        private DataTable GetEducationLevelData()
        {
            string strCode = "";
            if (txtProgramCode.Text.Length > 5)
                strCode = txtProgramCode.Text.Substring(0, 5);
            System.Data.DataTable dTable;
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd =
                new Oracle.DataAccess.Client.OracleCommand("pkg_training_3.Get_cd_trn_education_level", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retResult_", "cursor", "out", null);
            Oracle.DataAccess.Client.OracleDataAdapter da =
                new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            DataSet mds = new DataSet();
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
            dgEducationLevel.DataSource = GetEducationLevelData();
            dgEducationLevel.DataBind();
        }

        protected void dgEducationLevel_ItemCreated1(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                (e.Item.ItemType == ListItemType.AlternatingItem) ||
                (e.Item.ItemType == ListItemType.SelectedItem))
            {
                int itemIndex = e.Item.ItemIndex;
                DataTable dt = (DataTable)dgEducationLevel.DataSource;
                try
                {
                    string recid = dt.Rows[itemIndex]["code"].ToString();

                    LinkButton lnk = new LinkButton();
                    lnk.ID = "lnk_" + recid;
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
            string strCode = ((LinkButton)sender).ID.Substring(4);
            foreach (DataRow dw in dt.Rows)
            {
                if (dw["code"].ToString() == strCode)
                {
                    txtEducationLevel.Text = dw["code"].ToString().PadLeft(2, '0') + " - " + dw["short_description"].ToString();
                    break;
                }
            }
            btnEducationLevelClose1_Click1(null, null);
        }

        private void dgEducationLevel_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataTable dt = (DataTable)dgEducationLevel.DataSource;
            string strCode = "";
            if (txtEducationLevel.Text.Length >= 2)
                strCode = Convert.ToInt32(txtEducationLevel.Text.Substring(0, 2)).ToString();
            try
            {
                if (dt.Rows[e.Item.ItemIndex]["code"].ToString() == strCode)
                    e.Item.BackColor = System.Drawing.Color.Gold;
            }
            catch
            {
            }
        }

        private void SetupWizardMenu()
        {
            string retResult = "";
            string xml = Data.WizardMenuXML(Request.Cookies["Session_ID"].Value.ToString(), Request.Path, ViewState["Request_Record_ID"].ToString(), ref retResult);
            if (retResult != "")
            {
                lblWizardError.Text = retResult;
                return;
            }
            UltimateMenu1.MenuSourceXml = xml;
            UltimateMenu1.DataBind();
            SetupNextButton();
        }



        // =======================================training type of development

        private void btnDevClose0_Click(object sender, System.EventArgs e)
        {
            pnlData.Visible = true;
            pnlDevelopmentType.Visible = false;
        }

        private void ProcessTypeOfDevelopment()
        {
            FillSelectedTypeofDevelopment();
            FillTypeofDevelopment();
        }       

              

        private void FillSelectedTypeofDevelopment()
        {
            if (tblTypeOfDevelopment != null)
                return;
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.type_of_development_List", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", ViewState["Request_Record_ID"].ToString());
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_", "cursor", "out", "");

            DataSet mds = new DataSet();
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(mds);
                tblTypeOfDevelopment = mds.Tables[0];
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
            foreach (DataRow dr in tblTypeOfDevelopment.Rows)
            {
                if (dr["cd_record_id"].ToString() == strRecord_id)
                    return true;
            }
            return false;
        }

        private bool OtherSelected()
        {
            bool blnTxtFilled = txtTypeofDevelopmentOthers.Text.Trim() != "";
            if (chklstTypeofDev.Visible)
            {
                foreach (ListItem li in chklstTypeofDev.Items)
                {
                    if ((li.Value == "100") && li.Selected)
                        return true && (!blnTxtFilled);
                }
            }
            else
            {
                foreach (ListItem li in optlstTypeofDev.Items)
                {
                    if ((li.Value == "100") && li.Selected)
                        return true && (!blnTxtFilled);
                }
            }
            return false;
        }


        private void FillTypeofDevelopment()
        {
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.type_of_development_List", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "list_", "cursor", "out", "");

            DataSet mds = new DataSet();
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            DataTable tbl = null;

            try
            {
                conn.Open();
                da.Fill(mds);
                tbl = mds.Tables[0];
                chklstTypeofDev.Items.Clear();
                optlstTypeofDev.Items.Clear();
                foreach (DataRow dr in tbl.Rows)
                {
                    ListItem li = new ListItem(dr["description"].ToString(), dr["record_id"].ToString());
                    optlstTypeofDev.Items.Add(li);
                    li.Selected = IsSelected(li.Value);
                    chklstTypeofDev.Items.Add(li);
                }
                optlstTypeofDev.Visible = tbl.Rows.Count <= 1;
                chklstTypeofDev.Visible = !optlstTypeofDev.Visible;
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

        protected void btnTrainingTypeCode_Click(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            pnlTrainingTypeCode.Visible = true;
            DrawTrainingTypeCode();
        }

        protected void btnTrainingTypeCode2_Click(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            pnlTrainingTypeCode.Visible = true;
            DrawTrainingTypeCode();
        }

        protected void btnTypeOfDevelopment_Click1(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            pnlDevelopmentType.Visible = true;
            lblOtherTextError.Visible = false;
            chklstTypeofDev.Visible = true;
            int icounter = 0;
            foreach (ListItem li in chklstTypeofDev.Items)
            {
                if (li.Selected)
                    icounter++;
            }
            optlstTypeofDev.Visible = icounter <= 1;
            chklstTypeofDev.Visible = !optlstTypeofDev.Visible;
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            pnlProgramCode.Visible = true;
            FillProgramCode();
        }

        protected void btnHome_Click1(object sender, EventArgs e)
        {
            if (DataChanged())
            {
                Data.RegisterWarning(Page, "'/web_projects/trn/pla/SelectApp.aspx'");
                return;
            }
            Response.Redirect("/web_projects/trn/pla/SelectApp.aspx");
        }

        protected void btnBack_Click1(object sender, EventArgs e)
        {
            if (DataChanged())
            {
                Data.RegisterWarning(Page, "'" + ViewState["PrvStpUrl"].ToString() + "'");
                return;
            }
            else
                Response.Redirect(ViewState["PrvStpUrl"].ToString());
        }

        protected void btnNext_Click1(object sender, EventArgs e)
        {
            if (DataChanged())
            {
                Data.RegisterWarning(Page, "'" + ViewState["NextStpUrl"].ToString() + "'");
                return;
            }
            else
                Response.Redirect(ViewState["NextStpUrl"].ToString());
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {
            FillData();
        }

        protected void btnSelectEducationLevel_Click(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            pnlEducationLevel.Visible = true;
            DrawEducationLevel();
        }

        protected void dgTrainingTypeCode_ItemCreated1(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
               (e.Item.ItemType == ListItemType.AlternatingItem) ||
               (e.Item.ItemType == ListItemType.SelectedItem))
            {
                int itemIndex = e.Item.ItemIndex;
                DataTable dt = (DataTable)dgTrainingTypeCode.DataSource;
                try
                {
                    string recid = dt.Rows[itemIndex]["sub_code"].ToString();

                    LinkButton lnk = new LinkButton();
                    lnk.ID = "lnk_" + recid;
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

        protected void btnResetChanges_Click1(object sender, EventArgs e)
        {
            ProcessTypeOfDevelopment();
        }

        protected void btnDevClose0_Click2(object sender, EventArgs e)
        {
            //string strGoBottom = "<Sctipt>Javascript:GoButtom()</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGoBottom", strGoBottom);
            pnlData.Visible = true;
            pnlDevelopmentType.Visible = false;            
        }

        protected void btnEducationLevelClose1_Click1(object sender, EventArgs e)
        {
            //string strGoBottom = "<Sctipt>Javascript:GoButtom()</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGoBottom", strGoBottom);
            pnlData.Visible = true;
            pnlEducationLevel.Visible = false;            
        }

        protected void btnCloseTrainingType1_Click(object sender, EventArgs e)
        {
            //string strGoBottom = "<Sctipt>Javascript:GoButtom()</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGoBottom", strGoBottom);
            pnlData.Visible = true;
            pnlTrainingTypeCode.Visible = false;            
        }

     

        protected void ddlDesignationTypeCode_SelectedIndexChanged1(object sender, EventArgs e)
        {
            lblDesinationOther.Visible = ddlDesignationTypeCode.SelectedValue == "100";
            req2.Visible = lblDesinationOther.Visible;
            txtDesignationOther.Visible = lblDesinationOther.Visible;
            Requiredfieldvalidator7.Visible = lblDesinationOther.Visible;
        }       

        protected void ddlCreditTypeCode_SelectedIndexChanged1(object sender, EventArgs e)
        {
            lblCreditTypeOther.Visible = ddlCreditTypeCode.SelectedValue == "100";
            req4.Visible = lblCreditTypeOther.Visible;
            txtCreditTypeOther.Visible = lblCreditTypeOther.Visible;
            Requiredfieldvalidator8.Visible = lblCreditTypeOther.Visible;
        }

        protected void ddlAccomodation_SelectedIndexChanged2(object sender, EventArgs e)
        {
            lblAccomodationDescription.Visible = ddlAccomodation.SelectedValue == "1";
            txtAccomodationDescription.Visible = lblAccomodationDescription.Visible;
            req1.Visible = lblAccomodationDescription.Visible;
            RequiredFieldValidator6.Enabled = lblAccomodationDescription.Visible;
        }

        private void setHelp()
        {
            lnkHelpDepartmentID.Attributes.Add("onclick", "showDialog('0');return false;");
            lnkPositionLevelHelp.Attributes.Add("onclick", "showDialog('1');return false;");
            lnkHelpSpecialAccmedation.Attributes.Add("onclick", "showDialog('2');return false;");
            lnkTypeOfAppointmentHelp.Attributes.Add("onclick", "showDialog('3');return false;");
            lnkbtnTrainingPurposeTypeHelp.Attributes.Add("onclick", "showDialog('4');return false;");
            lnkbtnDeliveryTypeCodeHelp.Attributes.Add("onclick", "showDialog('5');return false;");
            lnkbtnDesigbationCodeHelp.Attributes.Add("onclick", "showDialog('6');return false;");
            lnkHelpTrainingCode.Attributes.Add("onclick", "showDialog('7');return false;");
            lmbtnCreditTypeCodeHelp.Attributes.Add("onclick", "showDialog('8');return false;");
            lnkbrnAccrediationIndicator.Attributes.Add("onclick", "showDialog('9');return false;");
            lnkbtnSourceofTraining.Attributes.Add("onclick", "showDialog('10');return false;");
            lnkbtnEducationLevel.Attributes.Add("onclick", "showDialog('11');return false;");
            lnkbrnTrainingSubTypeCode.Attributes.Add("onclick", "showDialog('12');return false;");
            lnkbtnTrainingTypeCode.Attributes.Add("onclick", "showDialog('13');return false;");
            lnkbtnTypeofDevelopment.Attributes.Add("onclick", "showDialog('14');return false;");
            lnkbtnProgramCodeHelp.Attributes.Add("onclick", "showDialog('15');return false;");
        }

        protected void btnClose1_Click1(object sender, EventArgs e)
        {

        }

        protected void bntnClose2_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CheckSave();
        }
    }
}
