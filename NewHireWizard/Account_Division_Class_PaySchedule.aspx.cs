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

namespace NewHireWizard
{
    public partial class Account_Division_Class_PaySchedule : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
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
                    //objBasTemplate.SetSeatchField(0);
                    //objBasTemplate.ShowProcessingYear = true;
                    //objBasTemplate.ShowSelectEmployee = true; 
                    //objBasTemplate.ShowNotes = false;
                    //objBasTemplate.ShowFontSizeSelector = false;
                    //LblTemplateHeader2.Text = objBasTemplate.Header2();
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
                    ViewState["Page_id"] = objBasTemplate.strPageId;
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
            if (!IsPostBack)
            {
                if (ViewState["User_Group_ID"].ToString().Equals("1"))
                    lnkbtnChangeDivision.Visible = false;
                if (ViewState["User_Group_ID"].ToString().Equals("4"))
                    lnkbtnChangeDivision.Visible = false;
                hiduserGroup.Value = ViewState["User_Group_ID"].ToString();
                dvWorkersCompClass.Visible = false;
                ViewState["last_check"] = "";
                if (Request.Params.ToString().Contains("old-1"))
                {
                    ViewState["Selected_Account_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "ACCOUNT_NUMBER");
                    ViewState["Class_Code"] = SQLStatic.Sessions.GetSessionValue(session_id, "CLASS_CODE");
                }
                ddlDepartment.Items.Clear();
                SQLStatic.Sessions.SetSessionValue(session_id, "Page_id", ViewState["Page_id"].ToString());
                if (!string.IsNullOrEmpty(Request.Params["Create_Field"]))
                {
                    Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                    SQLStatic.Sessions.SetSessionValue(session_id, "Page_id", ViewState["Page_id"].ToString());
                    Fields.GetPageControls.GetFields(Page, session_id, conn);
                    SQLStatic.SQL.CloseConnection(conn);
                }
                RequiredFieldValidator2.EnableClientScript = false;
                TabStrip1.wPage = Page;
                TabStrip1.SetCurrentTab(Request.Path);

                if (SQLStatic.Web_Data.ViewOnly(session_id))
                {
                    ViewState["Error"] = "You are \"View Only\" user. You do not have access to this module.";
                    string stringNoAccess = "<script>NoAccess('" + ViewState["Error"].ToString() + "')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringNoAccess", stringNoAccess);
                    return;
                }
                if ((ViewState["Selected_Account_Number"] != null) && (ViewState["Selected_Account_Number"].ToString() != ""))
                {
                    if (Data.ShowAdditionalInfoPage(ViewState["Selected_Account_Number"].ToString()))
                        TabStrip1.ShowTab(2, true);
                    if (Data.master_account_property_accnt(ViewState["Selected_Account_Number"].ToString(), "168").Equals("1"))
                    {
                        RequiredFieldValidator16.Enabled = true;
                        RequiredFieldValidator16.Visible = true;
                        Label7.ForeColor = System.Drawing.Color.Red;
                    }
                    try
                    {
                        dvWorkersCompClass.Visible = Data.master_account_property_accnt(ViewState["Selected_Account_Number"].ToString(), "169").Equals("1");
                    }
                    catch { };
                }


                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER");
                TabStrip1.SetCurrentTab(Request.Path);
                FillDropDowns();
                Startup();
                jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), txtAccountNameNumberValues.Text, " ");
                ViewState["CheckGender"] = "T";
                RequiredFieldValidator2.EnableClientScript = false;
                //ViewState["AllowDuplicate"] = Data.account_allow_duplicate_ssn(ViewState["Selected_Account_Number"].ToString());
                txtSSN_TextChanged(null, null);
                ViewState["FTE_HRS"] = null;
                //SetDepartment();

                //txtAccountNameNumberValues.Text = ViewState["Selected_Account_Number"].ToString();
                SetAccntSpecificItems();

            }

            SQLStatic.Sessions.SetSessionValue(session_id, "PROCESSING_YEAR", ViewState["Processing_Year"].ToString());
            SQLStatic.Sessions.SetSessionValue(session_id, "LAST_URL", Request.Path);
            if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "850", "0").Equals("1"))
            {
                dvsalutation.Visible = false;
            }
            //dvsalutation.Visible = !ViewState["Selected_Account_Number"].ToString().StartsWith("0007208");
            //TabStrip1.CheckEnrrollmentKit(ViewState["Selected_Account_Number"].ToString());            
            //Requires_FTE_Hours();
            RequiredFieldValidator2.EnableClientScript = false;
            //checkLocations();

            SetupControls();
            ProcesshidDate();
            ProcesseshidDiv();
            ProcesseshidClass();

            ProcesseshidPay();
            SetGender();

            FillDropDowns();

            dvAllDataFields.Visible = (!string.IsNullOrEmpty(txtClassValue.Text)) && (!string.IsNullOrEmpty(txtPayScheduleValue.Text));
            if (dvAllDataFields.Visible)
            {
                SetDateVailators();
                SetJobTitle();
                //ActivateValidators();
            }
            DoStar();
            TabStrip1.wPage = Page;
            TabStrip1.CurrentPath = Request.Path;
            RequiredFieldValidator2.EnableClientScript = false;
            Requires_FTE_Hours();
            Fill_Workers_Comp_Class();
            try
            {
                if (!ViewState["Selected_Account_Number"].ToString().Equals("0000424-0000-000"))
                {
                    string strAccountName = SQLStatic.Sessions.GetSessionValue(session_id, "Account_Name");
                    if (!string.IsNullOrEmpty(strAccountName))
                    {
                        txtAccountNameNumberValues.Text = ViewState["Selected_Account_Number"].ToString() + " - " +
                                                         SQLStatic.Sessions.GetSessionValue(session_id, "Account_Name");
                        SQLStatic.Sessions.SetSessionValue(session_id, "PROCESSING_YEAR", SQLStatic.AccountData.Current_Processing_Year(ViewState["Selected_Account_Number"].ToString()));
                        if (Data.ShowPayPeriod(ViewState["Selected_Account_Number"].ToString()))
                        {
                            dvPayStatus.Visible = true;
                            //lblStep4.Text = "<b><font face=\"Arial\" size=\"2\" color=\"#800000\">Step 4:</font></b>";
                        }
                    }
                }
            }
            catch { }
            if (!IsPostBack)
            {
                SetAccntSpecificItems();
                if ((ViewState["Selected_Account_Number"] != null) && (ViewState["Selected_Account_Number"].ToString() != ""))
                {
                    dvSalary.Visible = !Data.Get_er_property_master_accnt(ViewState["Selected_Account_Number"].ToString(), "851", "0").Equals("1");
                    RequiredFieldValidator1.Visible = false;
                    RangeValidator2.Visible = false;
                    reqSalary.Visible = false;
                }
            }
        }

        private void SetAccntSpecificItems()
        {
            if (ViewState["Selected_Account_Number"].ToString().StartsWith("0009769"))
            {
                req3.ForeColor = System.Drawing.Color.Red;
                RequiredFieldValidator2.Enabled = true;
            }
        }

        private bool isDLLJobTitle()
        {
            return (bool)ViewState["ddljobtile"];
        }

        private void SetJobTitle()
        {
            ViewState["ddljobtile"] = Data.ShowJobTitleDDL(ViewState["Selected_Account_Number"].ToString());
            if ((isDLLJobTitle()) && ddlJobtitle.Items.Count.Equals(0))
            {
                ddlJobtitle.DataSource = Data.Job_title_list(ViewState["Selected_Account_Number"].ToString());
                ddlJobtitle.DataTextField = "value";
                ddlJobtitle.DataValueField = "value";
                ddlJobtitle.DataBind();
                ddlJobtitle.Visible = true;
                txtJobTitle.Visible = false;
                if (!string.IsNullOrEmpty(txtJobTitle.Text))
                    ddlJobtitle.Items.FindByValue(txtJobTitle.Text).Selected = true;
            }
        }

        private void Fill_Workers_Comp_Class()
        {
            if (dvWorkersCompClass.Visible)
                if (ddlWorkersCompClass.Items.Count.Equals(0))
                    if ((ViewState["Selected_Account_Number"] != null) && (ViewState["Selected_Account_Number"].ToString() != ""))
                    {
                        DataTable tbl = Data.Get_Workers_Comp_Class(ViewState["Selected_Account_Number"].ToString());
                        ddlWorkersCompClass.DataSource = tbl;
                        ddlWorkersCompClass.DataTextField = "description";
                        ddlWorkersCompClass.DataValueField = "class_code";
                        ddlWorkersCompClass.DataBind();
                    }

        }

        private bool Requires_FTE_Hours()
        {
            try
            {
                if (ViewState["FTE_HRS"] == null)
                {
                    if (!ViewState["Employee_Number"].ToString().Equals("0"))
                    {
                        ViewState["FTE_HRS"] = Data.Requires_FTE_HRS(ViewState["Employee_Number"].ToString());
                        dvFTE_HRS.Visible = Requires_FTE_Hours();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtAccountNameNumberValues.Text.Trim()))
                            if (!string.IsNullOrEmpty(txtClassValue.Text.Trim()))
                            {

                                ViewState["FTE_HRS"] = Data.Requires_FTE_HRS(ViewState["Selected_Account_Number"].ToString(), ViewState["Class_Code"].ToString());
                                dvFTE_HRS.Visible = Requires_FTE_Hours();
                            }
                    }
                }
                return ViewState["FTE_HRS"].ToString().Equals("1");
            }
            catch { }
            return false;
        }

        private void checkLocations()
        {
            if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
                return;

            string locationCount = Data.LocationsCount(ViewState["Selected_Account_Number"].ToString());
            if (Convert.ToInt16(locationCount) < 2)
            {
                dvLocation.Visible = false;
                rblLocations.Items.Clear();
                return;
            }
            else
            {
                dvLocation.Visible = true;
            }
            //if (!rblLocations.Items.Count.Equals(0))
            //    return;
            rblLocations.Items.Clear();
            DataTable tbl = Data.LocationsList(ViewState["Selected_Account_Number"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["value"].ToString() + " - " + dr["description"].ToString(), dr["value"].ToString());
                rblLocations.Items.Add(li);
            }
        }

        private void SetDepartment()
        {
            if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
                return;

            if (!ddlDepartment.Items.Count.Equals(0))
                return;

            ddlDepartment.Items.Clear();
            DataTable tbl = Data.get_department_code(ViewState["Selected_Account_Number"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["department_code"].ToString() + " - " + dr["description"].ToString(), dr["department_code"].ToString());
                ddlDepartment.Items.Add(li);
            }
        }

        private void ProcesshidDate()
        {
            if (!string.IsNullOrEmpty(hidDate.Value))
            {
                hidDate.Value = "";
                txtHireDate.Text = "";
            }
        }

        private void SetDateVailators()
        {
            if (ViewState["last_check"].ToString().Equals(ViewState["Selected_Account_Number"].ToString()))
                return;
            if (ViewState["maxYear"] != null)
                return;
            int maxDays = Convert.ToInt16(Data.maxDaysForHireDate(ViewState["Selected_Account_Number"].ToString(), ViewState["User_ID"].ToString()));
            int minDays = Convert.ToInt16(Data.minDaysForHireDate(ViewState["Selected_Account_Number"].ToString(), ViewState["User_ID"].ToString()));
            ViewState["upper"] = maxDays.ToString();
            ViewState["lower"] = minDays.ToString();
            ViewState["maxYear"] = Convert.ToDateTime(Data.Last_Date_In_Processing_Year(ViewState["Selected_Account_Number"].ToString()));
            ViewState["maxDays"] = Convert.ToDateTime(DateTime.Today.AddDays(maxDays).ToShortDateString());
            ViewState["minDays"] = Convert.ToDateTime(DateTime.Today.AddDays(minDays).ToShortDateString());
            RangeValidator1.MaximumValue = ((DateTime)ViewState["maxDays"]).ToShortDateString();
            RangeValidator1.MinimumValue = ((DateTime)ViewState["minDays"]).ToShortDateString();
            RangeValidator1.ErrorMessage = "Hire Date cannot be less than " + RangeValidator1.MinimumValue + " or more than " + RangeValidator1.MaximumValue;

            ViewState["last_check"] = ViewState["Selected_Account_Number"].ToString();

            //ViewState["maxDays"] = Convert.ToDateTime(DateTime.Today.AddDays(90).ToShortDateString());
            //ViewState["minDays"] = Convert.ToDateTime(DateTime.Today.AddDays(-90).ToShortDateString());
        }

        private void DoStar()
        {
            return;
            if (ViewState["Selected_Account_Number"] != null)
            {
                LBL_FLD_MessageAccount_Division_Class_PaySchedule.Text = "";
                BasStar.StarFunctionality star = new BasStar.StarFunctionality();
                star.ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
                star.SetLabel(this, ViewState["Selected_Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(), Convert.ToInt16(ViewState["User_Group_ID"].ToString()));
                star = null;
            }
        }

        private void SetGender()
        {
            if (!ViewState["CheckGender"].ToString().Equals("T"))
                return;
            if (string.IsNullOrEmpty(txtAccountNameNumberValues.Text))
                return;
            if (string.IsNullOrEmpty(txtClassValue.Text))
                return;
            ViewState["CheckGender"] = 'F';
            string strGender = Data.DefaultGenderFromSession(session_id);
            if (!strGender.Equals("N"))
            {
                foreach (ListItem li in ddlGender.Items)
                    li.Selected = false;

                foreach (ListItem li in ddlMaritalStatus.Items)
                    li.Selected = false;
            }
            if (strGender.Equals("M"))
            {
                ddlGender.Items[1].Selected = true;
                ddlGender.SelectedIndex = 1;
                ddlGender.Enabled = false;

                ddlMaritalStatus.Items[2].Selected = true;
                ddlMaritalStatus.SelectedIndex = 2;
                ddlMaritalStatus.Enabled = false;
            }
            else if (strGender.Equals("F"))
            {
                ddlGender.Items[2].Selected = true;
                ddlGender.SelectedIndex = 2;
                ddlGender.Enabled = false;

                ddlMaritalStatus.Items[2].Selected = true;
                ddlMaritalStatus.SelectedIndex = 2;
                ddlMaritalStatus.Enabled = false;
            }
            else if (strGender.Equals("S"))
            {
                ddlGender.Items[0].Selected = true;
                ddlGender.SelectedIndex = 0;
                ddlGender.Enabled = true;

                ddlMaritalStatus.Items[2].Selected = true;
                ddlMaritalStatus.SelectedIndex = 2;
                ddlMaritalStatus.Enabled = false;
            }
            else if (strGender.Equals("N"))
            {
                //ddlGender.Items[0].Selected = true;
                //ddlGender.SelectedIndex = 0;
                ddlGender.Enabled = true;

                //ddlMaritalStatus.Items[0].Selected = true;
                //ddlMaritalStatus.SelectedIndex = 0;
                ddlMaritalStatus.Enabled = true;
            }
        }

        private void Startup()
        {
            if (!ViewState["Employee_Number"].ToString().Equals("0"))
            {
                DataTable tbl = null;
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    tbl = Data.GetIdentification(session_id, conn);
                    txtAccountNameNumberValues.Text = SQLStatic.Sessions.GetSessionValue(session_id, "ACCOUNTNAMENUMBERVALUES", conn);
                    txtClassValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "TXTCLASSVALUE", conn);
                    //Requires_FTE_Hours();
                    txtPayScheduleValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "TXTPAYSCHEDULEVALUE", conn);
                    CheckPendingNewHire(conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                SetDepartment();
                checkLocations();
                Fill_Workers_Comp_Class(); ;
                if (!tbl.Rows.Count.Equals(0))
                {
                    txtFirstName.Text = tbl.Rows[0]["First_Name"].ToString();
                    txtMiddleInitial.Text = tbl.Rows[0]["middle_initial"].ToString();
                    txtLastName.Text = tbl.Rows[0]["Last_Name"].ToString();
                    txtDateofBirth.TextWithLiterals = tbl.Rows[0]["Birth_Date"].ToString();
                    clearDDLSelection(ddlGender);
                    try
                    {
                        ddlGender.Items.FindByValue(tbl.Rows[0]["Gender"].ToString()).Selected = true;
                    }
                    catch { }
                    clearDDLSelection(ddlMaritalStatus);
                    try
                    {
                        ddlMaritalStatus.Items.FindByValue(tbl.Rows[0]["marital_status"].ToString()).Selected = true;
                    }
                    catch { }
                    txtHireDate.TextWithLiterals = tbl.Rows[0]["fulltime_hire_date"].ToString();
                    txtSalary.Text = tbl.Rows[0]["salary"].ToString();
                    txtJobTitle.Text = tbl.Rows[0]["employee_title"].ToString();
                    txtSSN.Text = tbl.Rows[0]["social_security_number"].ToString();
                    txtClientID.Text = tbl.Rows[0]["clients_employee_number"].ToString();
                    txtNickname.Text = tbl.Rows[0]["mother_maiden_name"].ToString();
                    if (!string.IsNullOrEmpty(tbl.Rows[0]["workers_comp_class"].ToString()))
                    {
                        ddlWorkersCompClass.Items.FindByValue(tbl.Rows[0]["workers_comp_class"].ToString()).Selected = true;
                    }
                    try
                    {
                        //if (ViewState["FTE_HRS"] == null)
                        //{
                        //    ViewState["FTE_HRS"] = Data.Requires_FTE_HRS(ViewState["Selected_Account_Number"].ToString(), ViewState["Class_Code"].ToString());
                        //    dvFTE_HRS.Visible = Requires_FTE_Hours();
                        //}
                        if (Requires_FTE_Hours())
                        {
                            txtScheduledHours.Text = tbl.Rows[0]["scheduled_hours"].ToString();
                            txtFullHors.Text = tbl.Rows[0]["fte_hours"].ToString();
                        }
                    }
                    catch { }
                    try
                    {
                        rblLocations.Items.FindByValue(tbl.Rows[0]["location"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        clearDDLSelection(ddlSalutation);
                        ddlSalutation.Items.FindByValue(tbl.Rows[0]["salutation"].ToString()).Selected = true;
                    }
                    catch
                    {
                    }

                    try
                    {
                        clearDDLSelection(ddlDepartment);
                        ddlDepartment.Items.FindByValue(tbl.Rows[0]["department_code"].ToString()).Selected = true;
                    }
                    catch
                    {
                    }
                    try
                    {
                        clearDDLSelection(ddlPayrollCompanyID);
                        string strID = Data.Get_EE_exposed_company_id(ViewState["Employee_Number"].ToString());
                        foreach (ListItem li in ddlPayrollCompanyID.Items)
                        {
                            li.Selected = false;
                            if (li.Value.Equals(strID))
                                li.Selected = true;
                        }
                        //ddlPayrollCompanyID.Items.FindByValue(strID);
                    }
                    catch
                    {
                    }

                }
                ViewState["Class_Code"] = SQLStatic.Sessions.GetSessionValue(session_id, "class_code");
                tbl.Dispose();
                if (Data.ShowPayPeriod(ViewState["Selected_Account_Number"].ToString()))
                {
                    dvPayStatus.Visible = true;
                    lblStep4.Text = "<b><font face=\"Arial\" size=\"2\" color=\"#800000\">Step 4:</font></b>";
                }
                if (Data.ShowDepartment(ViewState["Selected_Account_Number"].ToString()))
                {
                    dvDepartment.Visible = true;
                }
                if (Data.CanEditCleintNo(ViewState["Selected_Account_Number"].ToString()))
                    dvClientID.Visible = true;

                //if (Data.account_has_company_id(ViewState["Selected_Account_Number"].ToString()))
                //{
                //    dvCompany.Visible = true;
                //    FillCompanyDLL();
                //}
            }

        }

        private void FillCompanyDLL()
        {
            ddlPayrollCompanyID.Items.Clear();
            DataTable tbl = Data.get_payroll_co_id(ViewState["Selected_Account_Number"].ToString());
            ListItem li0 = new ListItem("Select", "x");
            ddlPayrollCompanyID.Items.Add(li0);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["description"].ToString(), dr["companyid"].ToString());
                ddlPayrollCompanyID.Items.Add(li);
            }
            tbl.Dispose();
            if (!Data.Get_expose_company_id(ViewState["Selected_Account_Number"].ToString()))
            {
                lblReqpcid.ForeColor = System.Drawing.Color.White;
                RequiredFieldValidator17.Enabled = false;
                RequiredFieldValidator17.Visible = false;
            }

        }

        private void SetupControls()
        {
            if (!ViewState["User_Group_ID"].ToString().Equals("1"))
                lnkbtnChangeDivision.Attributes.Add("onclick", "showDialog3(); return false;");
            else
                lnkbtnChangeDivision.Attributes.Add("onclick", "showDialog3grp1(); return false;");
            lnkbtnChangeClass.Attributes.Add("onclick", "showDialog2('" + ViewState["Selected_Account_Number"].ToString() + "'); return false;");
            lnkbtnChangePaySchedule.Attributes.Add("onclick", "showDialog4(); return false;");
        }

        private void ProcesseshidDiv()
        {
            RequiredFieldValidator1.Enabled = true;
            reqSalary.ForeColor = System.Drawing.Color.Red;
            if (!string.IsNullOrEmpty(Request.Params["addhis"]))
                hidDiv.Value = "Go";
            if (hidDiv.Value.Equals("Go"))
            {

                ViewState["FTE_HRS"] = null;
                checkLocations();
                ViewState["maxYear"] = null;
                lblHireDateWarning.Text = string.Empty;
                hidDiv.Value = "";
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                ViewState["Selected_Account_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "Account_Number", conn);
                SetDepartment();
                if (Data.master_account_property_accnt(ViewState["Selected_Account_Number"].ToString(), "168").Equals("0"))
                {
                    RequiredFieldValidator16.Enabled = false;
                    RequiredFieldValidator16.Visible = false;
                    Label7.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    if (!RequiredFieldValidator16.Enabled)
                    {
                        RequiredFieldValidator16.Enabled = true;
                        RequiredFieldValidator16.Visible = true;
                        Label7.ForeColor = System.Drawing.Color.Red;
                    }
                }
                string strValue = Data.master_account_property_accnt(ViewState["Selected_Account_Number"].ToString(), "169");
                dvWorkersCompClass.Visible = strValue.Equals("1");
                txtAccountNameNumberValues.Text = ViewState["Selected_Account_Number"].ToString() + " - " +
                                                         SQLStatic.Sessions.GetSessionValue(session_id, "Account_Name", conn);
                txtAccountNameNumberValues.ToolTip = txtAccountNameNumberValues.Text;
                Data.DefaultClassCode(session_id, conn);
                Data.DefaultPaySchedule(session_id, conn);
                txtClassValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtClassValue", conn);
                if (!string.IsNullOrEmpty(txtClassValue.Text))
                    SetGender();
                //txtPayScheduleValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtPayScheduleValue", conn);
                txtPayScheduleValue.Text = string.Empty;
                SQLStatic.Sessions.SetSessionValue(session_id, "txtPayScheduleValue", "", conn);
                CheckPendingNewHire(conn);
                if (!string.IsNullOrEmpty(txtClassValue.Text))
                    CheckPendingNewHireClass(conn);
                conn.Close();
                conn.Dispose();
                jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), txtAccountNameNumberValues.Text, " ");
                lnkbtnChangeClass.Attributes.Add("onclick", "showDialog2('" + ViewState["Selected_Account_Number"].ToString() + "'); return false;");
                if (Data.ShowPayPeriod(ViewState["Selected_Account_Number"].ToString()))
                {
                    dvPayStatus.Visible = true;
                    lblStep4.Text = "<b><font face=\"Arial\" size=\"2\" color=\"#800000\">Step 4:</font></b>";
                }
                else
                {
                    dvPayStatus.Visible = false;
                    lblStep4.Text = "<b><font face=\"Arial\" size=\"2\" color=\"#800000\">Step 3:</font></b>";
                }
                if (Data.ShowDepartment(ViewState["Selected_Account_Number"].ToString()))
                {
                    dvDepartment.Visible = true;
                }
                if (Data.CanEditCleintNo(ViewState["Selected_Account_Number"].ToString()))
                    dvClientID.Visible = true;

                FillDropDowns();
                if (Data.ShowAdditionalInfoPage(ViewState["Selected_Account_Number"].ToString()))
                    TabStrip1.ShowTab(2, true);
                else
                    TabStrip1.ShowTab(2, false);
                DoStar();
                Requires_FTE_Hours();
            }

            SQLStatic.Sessions.SetSessionValue(session_id, "Page_id", Data.pg_id(Request.Path));
            Fields._Default.Start(Page);
            if (RequiredFieldValidator1.Enabled)
            {
                ViewState["Req1"] = "1";
                RequiredFieldValidator1.Enabled = false;
            }
            else
                ViewState["Req1"] = "0";
            DataTable tbl = SQLStatic.AccountData.GetProcessingYearList_LastFirst(ViewState["Selected_Account_Number"].ToString());
            string defPY = SQLStatic.AccountData.Current_Processing_Year(ViewState["Selected_Account_Number"].ToString());
            string strFirstPy = tbl.Rows[0]["processing_Year"].ToString();
            string strLastPy = tbl.Rows[tbl.Rows.Count - 1]["processing_Year"].ToString();
        }

        private void CheckPendingNewHire(Oracle.DataAccess.Client.OracleConnection conn)
        {
            if (Data.isPendingAccount(session_id, conn))
            {
                dvPendNewHire.Visible = true;
                dvNewHire.Visible = false;
                dvEmployeeWillPend.Visible = false;
                CheckPendingNewHireClass(conn);
            }
            else
            {
                dvPendNewHire.Visible = false;
                dvNewHire.Visible = true;
                dvEmployeeWillPend.Visible = false;
            }

        }

        private void CheckPendingNewHireClass(Oracle.DataAccess.Client.OracleConnection conn)
        {
            if (Data.isPendingClass(session_id, conn))
            {
                dvEmployeeWillPend.Visible = true;
            }
            else
            {
                dvEmployeeWillPend.Visible = false;
            }
        }

        private void clearDDLSelection(DropDownList ddl)
        {
            foreach (ListItem li in ddl.Items)
                li.Selected = false;
        }

        private void ProcesseshidClass()
        {
            if (hidClass.Value.Equals("Go"))
            {
                ViewState["FTE_HRS"] = null;
                hidClass.Value = "";
                checkLocations();
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    string strClass_code = SQLStatic.Sessions.GetSessionValue(session_id, "class_code", conn);
                    ViewState["Class_Code"] = strClass_code;
                    SetGender();
                    ViewState["CheckGender"] = 'T';
                    string strClassDescription = SQLStatic.AccountData.ClassDescription(ViewState["Selected_Account_Number"].ToString(),
                                     ViewState["Processing_Year"].ToString(), strClass_code, conn);
                    txtClassValue.Text = strClass_code + " - " + strClassDescription;
                    SQLStatic.Sessions.SetSessionValue(session_id, "TXTCLASSVALUE", txtClassValue.Text);
                    txtClassValue.ToolTip = txtClassValue.Text;
                    CheckPendingNewHireClass(conn);
                    if ((!strClassDescription.ToUpper().IndexOf("PRIEST").Equals(-1)) || (!strClassDescription.ToUpper().IndexOf("CLERGY").Equals(-1)))
                    {

                        try
                        {
                            clearDDLSelection(ddlSalutation);
                            ddlSalutation.Items.FindByValue("Fr.").Selected = true;
                        }
                        catch
                        {
                        }

                    }
                    ViewState["CheckGender"] = 'T';
                    SetGender();
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                Requires_FTE_Hours();
                FillDropDowns();
            }
        }

        private void ProcesseshidPay()
        {
            if (hidPay.Value.Equals("Go"))
            {
                checkLocations();
                hidPay.Value = "";
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                txtPayScheduleValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "PAYCODE", conn) + " - " +
                                           SQLStatic.Sessions.GetSessionValue(session_id, "PAYDESCRIPTION", conn); ;
                txtClassValue.ToolTip = txtClassValue.Text;
            }
        }



        private void FillDropDowns()
        {
            string strEE = SQLStatic.Sessions.GetSessionValue(session_id, "EMPLOYEE_NUMBER");
            DataTable tbl = null;
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "EMPLOYEE_NUMBER", "0");
                tbl = Data.MritalStatus(session_id);

                string strSelected = "";
                try
                {
                    strSelected = ddlMaritalStatus.SelectedValue;
                }
                catch
                {
                }
                ddlMaritalStatus.Items.Clear();
                ListItem li0 = new ListItem("Select", "x");
                ddlMaritalStatus.Items.Add(li0);
                foreach (DataRow dr in tbl.Rows)
                {
                    //if (!dr["marital_status_code"].ToString().Equals("5"))
                    {
                        ListItem li = new ListItem(dr["marital_description"].ToString(), dr["marital_status_code"].ToString());
                        ddlMaritalStatus.Items.Add(li);
                    }
                }
                if (!string.IsNullOrEmpty(strSelected))
                    ddlMaritalStatus.Items.FindByValue(strSelected).Selected = true;
            }
            finally
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "EMPLOYEE_NUMBER", strEE);
            }

            string SalSelexted = string.Empty;
            try
            {
                SalSelexted = ddlSalutation.SelectedValue;
            }
            catch
            {
            }
            if (!string.IsNullOrEmpty(SQLStatic.Sessions.GetSessionValue(session_id, "class_code")))
            {
                ddlSalutation.Items.Clear();
                tbl = Data.Salutation(session_id, ViewState["Selected_Account_Number"].ToString());
                foreach (DataRow dr in tbl.Rows)
                {
                    ListItem li = new ListItem(dr["salutation"].ToString(), dr["salutation"].ToString());
                    ddlSalutation.Items.Add(li);
                }
                tbl.Dispose();
            }
            if (!string.IsNullOrEmpty(SalSelexted))
                ddlSalutation.Items.FindByValue(SalSelexted).Selected = true;
            try
            {
                SetGender();
            }
            catch { }

            //if (Data.account_has_company_id(ViewState["Selected_Account_Number"].ToString()))
            //{
            //    dvCompany.Visible = true;
            //    FillCompanyDLL();
            //}
        }

        private bool GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                txtAccountNameNumberValues.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtAccountNameNumberValues", conn);
                txtClassValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtClassValue", conn);
                txtPayScheduleValue.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtPayScheduleValue", conn);
                txtHireDate.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtHireDate", conn);
                txtSalary.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtSalary", conn);
                txtJobTitle.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtJobTitle", conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            //if (ViewState["done"] != "1")
            //    if (!string.IsNullOrEmpty(txtAccountNameNumberValues.Text))
            //    {
            //        ViewState["done"] = "1";
            //        ProcesseshidDiv();
            //    }
            return true;
        }

        private bool DoSave()
        {
            Validate();
            if (!IsValid)
                return false;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                if (isDLLJobTitle())
                    txtJobTitle.Text = ddlJobtitle.SelectedValue;
                string depCode = "";
                if ((dvDepartment.Visible) && (ddlDepartment.Items.Count > 0))
                    depCode = ddlDepartment.SelectedValue;
                string strLocation = "x";
                if (dvLocation.Visible)
                    strLocation = rblLocations.SelectedValue;

                string EE_exposed_company_id = "x";
                if (dvCompany.Visible)
                    EE_exposed_company_id = ddlPayrollCompanyID.SelectedValue;

                string Workers_Comp_Class = string.Empty;
                if (dvWorkersCompClass.Visible)
                    Workers_Comp_Class = ddlWorkersCompClass.SelectedValue;

                string ee_number = Data.SaveIdentification(session_id, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtDateofBirth.TextWithLiterals,
                    ddlGender.SelectedValue, ddlMaritalStatus.SelectedValue, txtHireDate.TextWithLiterals, txtSalary.Text, txtJobTitle.Text, ddlSalutation.
                    SelectedValue, txtSSN.TextWithLiterals, depCode, strLocation, txtClientID.Text, EE_exposed_company_id, txtNickname.Text, Workers_Comp_Class, conn);
                if (Requires_FTE_Hours())
                {
                    Data.Save_FTE_HRS(ViewState["Selected_Account_Number"].ToString(), ee_number, txtHireDate.TextWithLiterals, txtScheduledHours.Text, txtFullHors.Text,
                        ViewState["User_Name"].ToString(), conn);
                }


                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        protected void ActivateValidators()
        {
            RequiredFieldValidator1.Enabled = true;
            //RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
            RequiredFieldValidator7.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
            RequiredFieldValidator10.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
            RequiredFieldValidator12.Enabled = true;
            RequiredFieldValidator13.Enabled = true;
            RequiredFieldValidator15.Enabled = true;
            RequiredFieldValidator17.Enabled = true;
            RequiredFieldValidator18.Enabled = true;
            RequiredFieldValidator19.Enabled = true;
            RangeValidator1.Enabled = true;
            CompareValidator1.Enabled = true;
            RequiredFieldValidator20.Enabled = dvWorkersCompClass.Visible;

        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            ActivateValidators();
            Validate();
            if (!IsValid)
                return;
            if (lblErrorSSN.Visible)
                if (!Data.account_allow_duplicate_ssn(session_id, ViewState["Selected_Account_Number"].ToString(), txtSSN.TextWithLiterals).Equals("1"))
                    return;
            if (!string.IsNullOrEmpty(lblErrorProcessingYear.Text))
                return;
            if (!string.IsNullOrEmpty(lblError60Days.Text))
                return;
            if (DoSave())
                Response.Redirect(TabStrip1.NextURL());
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect(TabStrip1.TabUrl(TabStrip1.CurrentTab() - 1));
            Response.Redirect(TabStrip1.PreviousURL());
        }

        protected void txtHireDate_TextChanged(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            lblHireDateWarning.Text = "";
            DateTime dt = DateTime.Today;
            try
            {
                dt = Convert.ToDateTime(txtHireDate.TextWithLiterals);
            }
            catch
            {
                return;
            }

            lblErrorProcessingYear.Text = "";
            if (ViewState["Class_Code"] == null)
                ViewState["Class_Code"] = SQLStatic.Sessions.GetSessionValue(session_id, "class_code");
            try
            {
                lblHireDateWarning.Text = Data.CanHaveClass(ViewState["Selected_Account_Number"].ToString(), ViewState["Class_Code"].ToString(), txtHireDate.TextWithLiterals);
            }
            catch
            {
                lblHireDateWarning.Text = "Hire Date could not be found. Please check the selected Account and Class Code ";
            }
            if (!ViewState["User_Group_ID"].ToString().Equals("1"))
            {
                if (dt > (DateTime)ViewState["maxYear"])
                {
                    lblErrorProcessingYear.Text = "Date must be within the current processing year";
                    return;
                }

                //lblError60Days.Text = "";
                //if (dt > (DateTime)ViewState["maxDays"])
                //{
                //    lblError60Days.Text = "Date must be less than or equal to " + Convert.ToDateTime(ViewState["maxDays"].ToString()).ToShortDateString();
                //    return;
                //}

                //lblError60Days.Text = "";
                //if (dt < (DateTime)ViewState["minDays"])
                //{
                //    lblError60Days.Text = "Date must be larger than or equal to " + Convert.ToDateTime(ViewState["minDays"].ToString()).ToShortDateString();
                //    return;
                //}



                //if (dt > DateTime.Today.AddDays(10))
                //{
                //    lblHireDateWarning.Text = "You have entered a hire date of " + txtHireDate.Text + " that is more than 10 days into the future (Note: you may only enter hire dates up to " + ViewState["upper"].ToString() + "-days into the future from today’s date). Are you sure you want to apply this hire date?";
                //    return;
                //    //string strMessage = "You have entered a hire date of " + txtHireDate.Text + " that is more than 10 days into the future (Note: you may only enter hire dates up to 60-days into the future from today’s date). Are you sure you want to apply this hire date?";
                //    //string ConfirmDate = "<script>ConfirmDate('" + strMessage + "')</script>";
                //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "ConfirmDate", ConfirmDate);
                //}
            }
        }

        protected void txtSSN_TextChanged(object sender, EventArgs e)
        {
            lblErrorSSN.Text = string.Empty;
            string strSSNExist = Data.SSN_Exists_Check_EE(txtSSN.TextWithLiterals, ViewState["Selected_Account_Number"].ToString(), session_id);
            if (strSSNExist.Equals("0"))
                lblErrorSSN.Visible = false;
            else if (strSSNExist.Equals("1"))
            {
                lblErrorSSN.Visible = true;
                lblErrorSSN.Text = "The Social Security Number you entered is already associated with an active employee. You may not enter this employee until their active record is terminated or you correct the social security number you entered.";
            }
            else if (strSSNExist.Equals("2"))
            {
                lblErrorSSN.Visible = true;
                lblErrorSSN.Text = "The Social Security Number you entered is already associated with a pending employee. You may not enter this employee until their pending record is terminated or you correct the social security number you entered.";
            }
            else if (strSSNExist.Equals("3"))
            {
                lblErrorSSN.Visible = true;
                lblErrorSSN.Text = "You may not add this employee into the selected benefits class because the employee is already in a class at another location that has one or more single-enrollment benefits . This control prevents a chance of employee  “double-dipping” single-enrollment benefits such as medical, dental, vision and prescription from the same class in two or more locations.";
            }
            if (!string.IsNullOrEmpty(lblErrorSSN.Text))
            {
                if (Data.account_allow_duplicate_ssn(session_id, ViewState["Selected_Account_Number"].ToString(), txtSSN.TextWithLiterals).Equals("1"))
                {
                    lblErrorSSN.Visible = true;
                    lblErrorSSN.Text = douplicateSSN.InnerHtml;
                    //"<div style='background-color: #fdeada'><span style='font-size: 10pt; background-color: #fdeada; font-family: arial; color: #c00000;'><span style='text-decoration: underline;'><strong>WARNING</strong></span> - You have entered an employee who is already active in the following location(s) listed below. [Account]Be very careful if you are truly adding this employee as a duplicate. If you did not mean to attempt to add this employee, click the Welcome Page button. </span></div>";
                    lblErrorSSN.Text = lblErrorSSN.Text.Replace("[Account]", Data.AccountsListSameSSN(ViewState["Selected_Account_Number"].ToString(), txtSSN.TextWithLiterals));
                }
            }
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            Response.Redirect(e.Tab.Value);
        }
    }
}
