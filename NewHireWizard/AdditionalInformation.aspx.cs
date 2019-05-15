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
    public partial class AdditionalInformation : System.Web.UI.Page
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
                    objBasTemplate.SetSeatchField(0);
                    objBasTemplate.ShowProcessingYear = true;
                    objBasTemplate.ShowNotes = false;
                    objBasTemplate.ShowFontSizeSelector = false;
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
            TabStrip1.wPage = Page;
            TabStrip1.CurrentPath = Request.Path;
            if (!IsPostBack)
            {
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER");
                if (Data.master_account_property_accnt(ViewState["Selected_Account_Number"].ToString(), "166").Equals("1"))
                {
                    dvNormal.Visible = false;
                    dvAternate.Visible = true;
                    iverify.Attributes["src"] = "/Web_Projects/HR_Information/hr_info.aspx?SkipCheck=YES&EENo=" + ViewState["Employee_Number"].ToString();
                }
                else
                {
                    dvNormal.Visible = true;
                    dvAternate.Visible = false;
                    if (Data.ShowAdditionalInfoPage(ViewState["Selected_Account_Number"].ToString()))
                    {
                        TabStrip1.ShowTab(2, true);
                        FillDropDown();
                    }
                    


                    if (!string.IsNullOrEmpty(Request.Params["Create_Field"]))
                    {
                        Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                        SQLStatic.Sessions.SetSessionValue(session_id, "Page_id", ViewState["Page_id"].ToString());
                        Fields.GetPageControls.GetFields(Page, session_id, conn);
                        SQLStatic.SQL.CloseConnection(conn);
                        return;
                    }

                    Fields._Default.Start(Page);
                    TabStrip1.SetCurrentTab(Request.Path);
                    //ddlSCEP_CEP.Visible = (!txtdepartment_code.Visible) && (pnldepartment_code.Visible);
                    if (ddlSCEP_CEP.Visible)
                    {
                        FillddlSCEP_CEP();
                        txtdepartment_code.Visible = false;
                    }

                    jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), "", "");
                    GetDataFromSession();
                    DoStar();
                    RequiredFieldValidator14.ErrorMessage = "Required " + LBL_FLD_lblowner_of_business.Text;
                    txthourly_rate.Enabled = true;
                }
               
            }
            
        }

        private void AddEmptySelection(DropDownList ddl)
        {
            ListItem li = new ListItem("None Exists", "x");
            ddl.Items.Add(li);
        }

        private void FillDropDown()
        {
            DataTable tbl = Data.Get_ErWorkgroups(ViewState["Selected_Account_Number"].ToString());
            if (!tbl.Rows.Count.Equals(0))
            {
                txtworkgroup_code.DataSource = tbl;
                txtworkgroup_code.DataTextField = "description";
                txtworkgroup_code.DataValueField = "workgroup_code";
                txtworkgroup_code.DataBind();
            }
            else AddEmptySelection(txtworkgroup_code);

            tbl = Data.Get_ERLocations(ViewState["Selected_Account_Number"].ToString());
            if (!tbl.Rows.Count.Equals(0))
            {
                txtlocation_code.DataSource = tbl;
                txtlocation_code.DataTextField = "description";
                txtlocation_code.DataValueField = "value";
                txtlocation_code.DataBind();
            }
            else AddEmptySelection(txtlocation_code);

            tbl = Data.Get_ERDivisions(ViewState["Selected_Account_Number"].ToString());
            if (!tbl.Rows.Count.Equals(0))
            {
                txtdivision_code.DataSource = tbl;
                txtdivision_code.DataTextField = "description";
                txtdivision_code.DataValueField = "division_code";
                txtdivision_code.DataBind();
            }
            else AddEmptySelection(txtdivision_code);
        }

        private void FillddlSCEP_CEP()
        {
            ddlSCEP_CEP.Items.Clear();
            DataTable tbl = Data.get_department_code(ViewState["Selected_Account_Number"].ToString());
            ddlSCEP_CEP.DataSource = tbl;
            ddlSCEP_CEP.DataTextField = "description";
            ddlSCEP_CEP.DataValueField = "department_code";
            ddlSCEP_CEP.DataBind();
        }

        private void DoStar()
        {
            LBL_FLD_MessageAdditionalInformation.Text = "";
            BasStar.StarFunctionality star = new BasStar.StarFunctionality();
            star.ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            star.SetLabel(this, ViewState["Selected_Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(), Convert.ToInt16(ViewState["User_Group_ID"].ToString()));
            star = null;          
        }

        private void UnselectAll(DropDownList ddl)
        {
            foreach (ListItem li in ddl.Items)
                li.Selected = false;
        }

        private bool GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                DataTable tbl = Data.GetAdditionalInformation(session_id,conn);
                if (!tbl.Rows.Count.Equals(0))
                {
                    txthours_worked_per_week.Text = tbl.Rows[0]["hours_worked_per_week"].ToString();
                    txthourly_rate.Text = tbl.Rows[0]["hourly_rate"].ToString();
                    txtown_what_percent.Text = tbl.Rows[0]["own_what_percent"].ToString();
                    txttitle_of_officer.Text = tbl.Rows[0]["title_of_officer"].ToString();
                    txtunion_number.Text = tbl.Rows[0]["union_number"].ToString();
                    txtjob_status_code.Text = tbl.Rows[0]["job_status_code"].ToString();
                    txtfulltime_equivalent.Text = tbl.Rows[0]["fulltime_equivalent"].ToString();
                    txtannual_hours_worked.Text = tbl.Rows[0]["annual_hours_worked"].ToString();
                    txtBackground.Text = tbl.Rows[0]["employee_title"].ToString();
                    try
                    {
                        txtworkgroup_code.Items.FindByValue(tbl.Rows[0]["workgroup_code"].ToString()).Selected=true;
                    }
                    catch { }
                    txtdepartment_code.Text = tbl.Rows[0]["department_code"].ToString();
                    try
                    {
                        txtdivision_code.Items.FindByValue(tbl.Rows[0]["division_code"].ToString()).Selected = true;
                    }
                    catch { }
                    txtimport_ssno.Text = tbl.Rows[0]["import_ssno"].ToString();
                    txtoccupation.Text = tbl.Rows[0]["occupation"].ToString();

                    try
                    {
                        txtlocation_code.Items.FindByValue(tbl.Rows[0]["location_code"].ToString()).Selected = true;
                    }
                    catch { }
                    
                    string strddlstate_resident = tbl.Rows[0]["state_resident"].ToString();
                    string strddlfull_or_part_time = tbl.Rows[0]["full_or_part_time"].ToString();
                    string strddlis_employee_leased = tbl.Rows[0]["is_employee_leased"].ToString();
                    string strddlunion_member = tbl.Rows[0]["union_member"].ToString();
                    string strddlpaid_commission = tbl.Rows[0]["paid_commission"].ToString();
                    string strddleligible_to_participate = tbl.Rows[0]["eligible_to_participate"].ToString();
                    string strddlpaid_salary = tbl.Rows[0]["paid_salary"].ToString();
                    string strddlpaid_hourly = tbl.Rows[0]["paid_hourly"].ToString();
                    string strddlowner_of_business = tbl.Rows[0]["owner_of_business"].ToString();
                    string strddldirector_of_business = tbl.Rows[0]["director_of_business"].ToString();
                    string strddlpartner_in_business = tbl.Rows[0]["partner_in_business"].ToString();
                    string strddlofficer_of_business = tbl.Rows[0]["officer_of_business"].ToString();
                    string strddllnon_participating = tbl.Rows[0]["non_participating"].ToString();
                    string strTransfer = tbl.Rows[0]["Transfer_From_Federal_Agency"].ToString();
                    string strFEGLI = tbl.Rows[0]["Has_FEGLI"].ToString();
                    UnselectAll(ddlstate_resident);
                    UnselectAll(ddlfull_or_part_time);
                    UnselectAll(ddlis_employee_leased);
                    UnselectAll(ddlunion_member);
                    UnselectAll(ddleligible_to_participate);
                    UnselectAll(ddlpaid_salary);
                    UnselectAll(ddlpaid_hourly);
                    UnselectAll(ddlowner_of_business);
                    UnselectAll(ddldirector_of_business);
                    UnselectAll(ddlofficer_of_business);
                    UnselectAll(ddlpartner_in_business);
                    UnselectAll(ddllnon_participating);
                    UnselectAll(ddlTransfer);
                    UnselectAll(ddlFEGLI);


                    if (ddlSCEP_CEP.Visible)
                    {
                        UnselectAll(ddlSCEP_CEP);
                        try { ddlSCEP_CEP.Items.FindByValue(txtdepartment_code.Text).Selected = true; } catch { }
                    }

                    try{if (!string.IsNullOrEmpty(strTransfer)) ddlTransfer.Items.FindByValue(strTransfer).Selected = true; }  catch { }
                    try{if (!string.IsNullOrEmpty(strFEGLI)) ddlFEGLI.Items.FindByValue(strFEGLI).Selected = true; } catch { }
                    try{if (!string.IsNullOrEmpty(strddlstate_resident)) ddlstate_resident.Items.FindByValue(strddlstate_resident).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlfull_or_part_time)) ddlfull_or_part_time.Items.FindByValue(strddlfull_or_part_time).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlis_employee_leased)) ddlis_employee_leased.Items.FindByValue(strddlis_employee_leased).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlunion_member)) ddlunion_member.Items.FindByValue(strddlunion_member).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlpaid_commission)) ddlpaid_commission.Items.FindByValue(strddlpaid_commission).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddleligible_to_participate)) ddleligible_to_participate.Items.FindByValue(strddleligible_to_participate).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlpaid_salary)) ddlpaid_salary.Items.FindByValue(strddlpaid_salary).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlpaid_hourly)) ddlpaid_hourly.Items.FindByValue(strddlpaid_hourly).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlowner_of_business)) ddlowner_of_business.Items.FindByValue(strddlowner_of_business).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddldirector_of_business)) ddldirector_of_business.Items.FindByValue(strddldirector_of_business).Selected = true;}catch{}
                    try{if (!string.IsNullOrEmpty(strddlpartner_in_business)) ddlpartner_in_business.Items.FindByValue(strddlpartner_in_business).Selected = true;}catch{}
                    try { if (!string.IsNullOrEmpty(strddlofficer_of_business)) ddlofficer_of_business.Items.FindByValue(strddlofficer_of_business).Selected = true; } catch { }
                    try{if (!string.IsNullOrEmpty(strddllnon_participating)) ddllnon_participating.Items.FindByValue(strddllnon_participating).Selected = true;}catch{}
                }
                tbl.Dispose();                
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            ddlTransfer_SelectedIndexChanged(null, null);
            return true;
        }


        private bool DoSave()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                if (ddlSCEP_CEP.Visible)
                    txtdepartment_code.Text = ddlSCEP_CEP.SelectedValue;
                string strHasFEGLI = ddlFEGLI.SelectedValue;
                if (ddlTransfer.SelectedValue.Equals("N"))
                    strHasFEGLI = "";
                Data.UpdateAdditionalInformation(session_id, ddlfull_or_part_time.SelectedValue == "Select" ? "" : ddlfull_or_part_time.SelectedValue,
                        txthours_worked_per_week.Text,
                        ddlis_employee_leased.SelectedValue == "Select" ? "" : ddlis_employee_leased.SelectedValue,
                        ddlstate_resident.SelectedValue == "Select" ? "" : ddlstate_resident.SelectedValue,
                        ddlunion_member.SelectedValue == "Select" ? "" : ddlunion_member.SelectedValue,
                        ddlpaid_commission.SelectedValue == "Select" ? "" : ddlpaid_commission.SelectedValue,
                        ddleligible_to_participate.SelectedValue == "Select" ? "" : ddleligible_to_participate.SelectedValue,
                        ddlpaid_salary.SelectedValue == "Select" ? "" : ddlpaid_salary.SelectedValue,
                        ddlpaid_hourly.SelectedValue == "Select" ? "" : ddlpaid_hourly.SelectedValue,
                        txthourly_rate.Text,
                        ddlowner_of_business.SelectedValue == "Select" ? "" : ddlowner_of_business.SelectedValue,
                        txtown_what_percent.Text,
                        ddldirector_of_business.SelectedValue == "Select" ? "" : ddldirector_of_business.SelectedValue,
                        ddlpartner_in_business.SelectedValue == "Select" ? "" : ddlpartner_in_business.SelectedValue,
                        ddlofficer_of_business.SelectedValue == "Select" ? "" : ddlofficer_of_business.SelectedValue,
                        txttitle_of_officer.Text,
                        ddllnon_participating.SelectedValue == "Select" ? "" : ddllnon_participating.SelectedValue,
                        txtunion_number.Text,
                        txtjob_status_code.Text,
                        txtfulltime_equivalent.Text,
                        txtannual_hours_worked.Text,
                        txtworkgroup_code.SelectedValue == "x" ? "" : txtworkgroup_code.SelectedValue,
                        txtdepartment_code.Text,
                        txtdivision_code.SelectedValue == "x" ? "" : txtdivision_code.SelectedValue,
                        txtimport_ssno.Text,
                        txtoccupation.Text,
                        txtlocation_code.SelectedValue == "x" ? "" : txtlocation_code.SelectedValue,
                        ddlTransfer.SelectedValue,
                        strHasFEGLI,
                        txtBackground.Text);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            if (DoSave())
                Response.Redirect(TabStrip1.NextURL());

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabStrip1.PreviousURL());
        }

        protected void ddlunion_member_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlunion_number.Visible = ddlunion_member.SelectedValue.Equals("Y");
            if (!pnlunion_number.Visible)
                txtunion_number.Text = string.Empty;
        }

        protected void ddlpaid_hourly_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlhourly_rate.Visible = ddlpaid_hourly.SelectedValue.Equals("Y");
            pnlhourly_rate.Enabled = pnlhourly_rate.Visible;
            if (pnlhourly_rate.Visible)
            {
                txthourly_rate.Text = string.Empty;
                txthourly_rate.Visible = true;
                txthourly_rate.Enabled = true;
            }
        }

        protected void ddlpartner_in_business_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlown_what_percent.Visible = ddlpartner_in_business.SelectedValue.Equals("Y");
            if (!pnlown_what_percent.Visible)
                txtown_what_percent.Text = string.Empty;
        }

        protected void ddlofficer_of_business_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnltitle_of_officer.Visible = ddlofficer_of_business.SelectedValue.Equals("Y");
            if (!pnltitle_of_officer.Visible)
                txttitle_of_officer.Text = string.Empty;
        }

        protected void ddlTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFEGLI.Visible = ddlTransfer.SelectedValue.Equals("Y");
            pnlFEGLI.Enabled = pnlFEGLI.Visible;
            ddlFEGLI.Visible = pnlFEGLI.Visible;
            ddlFEGLI.Enabled = pnlFEGLI.Visible;
        }
    }
}
