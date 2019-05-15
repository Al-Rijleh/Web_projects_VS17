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

namespace EnrollmentWizardSetup
{
    public partial class Setup_open_Enrollment : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = DateTime.Today.ToShortDateString();
                SetupTabStrip1.SetTabIndex(8);                
                FilDefault();
                SetTax();
                if (Data.employee_use_enrol_wizard(ViewState["Selected_Account_Number"].ToString()))
                    lblUseWizard.Text = "This account uses the new Enrollment Wizard program";
                else
                    lblUseWizard.Text = "This account DOES NOT uses the new Enrollment Wizard program ";
            }
            DrawGrid();

        }

        private void SetTax()
        {
            rblPostTax.Items.FindByValue(Data.allows_pretax_posttax(ViewState["Selected_Account_Number"].ToString())).Selected = true;
            rblExtraPage.Items.FindByValue(Data.Get_other(ViewState["Selected_Account_Number"].ToString(),"95","0")).Selected = true;
            rblShowCoreBenefit.Items.FindByValue(Data.Get_other(ViewState["Selected_Account_Number"].ToString(), "94", "1")).Selected = true;
            rblPendNewDependents.Items.FindByValue(Data.Get_Pend_dependent(ViewState["Selected_Account_Number"].ToString()));
            rblSameGender.Items.FindByValue(Data.Get_other(ViewState["Selected_Account_Number"].ToString(), "122", "0")).Selected = true;
        }

        private void DrawGrid()
        {
            DataTable tbl= Data.Last_enrollment_info(ViewState["Selected_Account_Number"].ToString());
            if (tbl.Rows.Count.Equals(0))
                return;
            rvLastEnrollment.DataSource = tbl;
            rvLastEnrollment.DataBind();
        }

        private void FilDefault()
        {
            DataTable tbl = Data.Default_enrollment_info(ViewState["Selected_Account_Number"].ToString());
            if (tbl.Rows.Count.Equals(0))
                return;
            txtProcessingYear.Text = tbl.Rows[0]["processing_year"].ToString();
            txtEffectiveDate.SelectedDate = Convert.ToDateTime(tbl.Rows[0]["effective_date"].ToString());
            txtEffDate.SelectedDate = txtEffectiveDate.SelectedDate.Value;
        }       

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            DataTable tbl = rvLastEnrollment.DataSource as DataTable;

            if (tbl == null)
                tbl = Data.Last_enrollment_info(ViewState["Selected_Account_Number"].ToString());
            txtProcessingYear.Text = tbl.Rows[0]["processing_year"].ToString();

            try { txtEffectiveDate.SelectedDate = Convert.ToDateTime(tbl.Rows[0]["effective_date"].ToString()); }
            catch { txtEffectiveDate.SelectedDate = null; }
            try {txtBeginDate.SelectedDate = Convert.ToDateTime(tbl.Rows[0]["start_date"].ToString());}
            catch { txtBeginDate.SelectedDate = null; }
            try { txtLastDate.SelectedDate = Convert.ToDateTime(tbl.Rows[0]["end_date"].ToString()); }
            catch { txtLastDate.SelectedDate = null; }
            try { txtEffDate.SelectedDate = txtEffectiveDate.SelectedDate.Value; }
            catch { txtEffDate.SelectedDate = null; }
            RangeValidator1.MinimumValue = "01/01/2000"; //tbl.Rows[0]["start_date"].ToString();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnNew.Visible = true;
            ViewState["Record_ID"] = tbl.Rows[0]["record_id"].ToString();
            rblSaveTo.Visible = true;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnNew.Visible = false;
            txtProcessingYear.Text = "";
            txtEffectiveDate.SelectedDate = null;
            txtBeginDate.SelectedDate = null;
            txtLastDate.SelectedDate = null;
            FilDefault();
            rblSaveTo.Visible = true;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Data.Save_enrollment_info(ViewState["Selected_Account_Number"].ToString(),
                                          txtProcessingYear.Text,
                                          txtBeginDate.SelectedDate.Value.ToShortDateString(),
                                          txtLastDate.SelectedDate.Value.ToShortDateString(),
                                          txtEffectiveDate.SelectedDate.Value.ToShortDateString(),rblSaveTo.SelectedValue,rblUseEnrollWizard.SelectedValue);
                DrawGrid();
                string strSaved = "<script>alert('Saved')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strSaved", strSaved);
            }
            catch { }
            if (Data.employee_use_enrol_wizard(ViewState["Selected_Account_Number"].ToString()))
                lblUseWizard.Text = "This account uses the new Enrollment Wizard program";
            else
                lblUseWizard.Text = "This account DOES NOT uses the new Enrollment Wizard program ";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Data.Update_enrollment_info(ViewState["Record_ID"].ToString(),
                                          txtProcessingYear.Text,
                                          txtBeginDate.SelectedDate.Value.ToShortDateString(),
                                          txtLastDate.SelectedDate.Value.ToShortDateString(),
                                          txtEffectiveDate.SelectedDate.Value.ToShortDateString(),
                                          rblSaveTo.SelectedValue,
                                          rblUseEnrollWizard.SelectedValue);
                DrawGrid();
            }
            catch { }
            if (Data.employee_use_enrol_wizard(ViewState["Selected_Account_Number"].ToString()))
                lblUseWizard.Text = "This account uses the new Enrollment Wizard program";
            else
                lblUseWizard.Text = "This account DOES NOT uses the new Enrollment Wizard program ";
        }

        protected void rblEnrollmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rblEnrollmentType.SelectedIndex.Equals(0))
            //{
            //    txtEffectiveDate.Visible = false;
            //    txtEffDate.Visible = true;
            //}
            //else
            {
                txtEffectiveDate.Visible = true;
                txtEffDate.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Data.save_pretax_posttax(session_id, rblSaveTaxTo.SelectedValue, rblPostTax.SelectedValue);
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Data.save_Choice(session_id, rblSaveToExtraPage.SelectedValue, "95", rblExtraPage.SelectedValue);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Data.save_Choice(session_id, rbSaveToShowCore.SelectedValue, "94", rblShowCoreBenefit.SelectedValue);
        }

        protected void btnPendDep_Click(object sender, EventArgs e)
        {
            Data.Save_Pend_dependent(ViewState["Selected_Account_Number"].ToString(),rbSavePendDep.SelectedValue, rblPendNewDependents.SelectedValue,  ViewState["User_Name"].ToString());
        }

        protected void btnSaveSameGender_Click(object sender, EventArgs e)
        {
            Data.save_Choice(session_id, rblSameGenderSave.SelectedValue, "122", rblSameGender.SelectedValue);
        }

        

        
    }
}
