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
    public partial class Confirmation : System.Web.UI.Page
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
                if (Data.ShowAdditionalInfoPage(ViewState["Selected_Account_Number"].ToString()))
                    TabStrip1.ShowTab(2, true);
                if (!ViewState["User_Group_ID"].ToString().Equals("1"))
                    htmbtnPend.Visible = Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000","160", "0").Equals("1");
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER");
                Template.BASPtemplate.SetHeaderPageNameByName(Page, "Account Name");
                TabStrip1.SetCurrentTab(Request.Path);
                GetDataFromSession();
                jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), "", "");
                DoStar();
                ViewState["skip"] = false;
                ViewState["AutoPended"] = false;
                if (Data.RequireVerification(ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString()).Equals("1"))
                {
                    if (Data.Get_er_property_master_accnt(ViewState["Selected_Account_Number"].ToString(),"198","0").Equals("1"))
                    {
                        btnNext_Click(null, null);
                        SQLStatic.Sessions.SetSessionValue(session_id, "NH_EMPLOYEE_NUMBER", ViewState["Employee_Number"].ToString());
                    }
                    dvVerify.Visible = true;
                    dvFullPage.Visible = false;
                    iverify.Attributes["src"] = "/web_projects/New_Hire_Verification_of_Eligibility/Default.aspx?SkipCheck=YES&EENo=" + ViewState["Employee_Number"].ToString();
                    if (ViewState["Selected_Account_Number"].ToString().Contains("0007212-"))
                        return;
                }
                else 
                {
                    dvVerify.Visible = false;
                    dvFullPage.Visible = true;
                }
                if (Data.Get_er_property_master_accnt(ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "124", "0").Equals("1"))
                {
                    btnNext_Click(null, null);
                    SQLStatic.Sessions.SetSessionValue(session_id, "NH_EMPLOYEE_NUMBER", ViewState["Employee_Number"].ToString());
                    htmbtnSave.Visible = false;
                    btnCancel.Visible = false;
                    htmbtnPend.Visible = false;
                    btnNext.Visible = false;
                    lblTitle.Text = "Pended to Trustor Administrators";
                    jscriptsFunctions.Misc.Alert(Page, "Pended to Trustor Administrators");
                    return;
                }

            }
            TabStrip1.wPage = Page;
            TabStrip1.CurrentPath = Request.Path;
            
            if (!string.IsNullOrEmpty(hidSave.Value))
            {
                if (hidSave.Value.Equals("Go"))
                {
                    ViewState["skip"] = true;
                    hidSave.Value = "";
                    if (!(bool)ViewState["AutoPended"])
                        lblTitle.Text = "Confirmation of New Hire Added to Active Employee Data";
                    else
                        lblTitle.Text = "Confirmation of New Hire Pended Until Further Editing/Approval";
                    if (!Data.isPendingEmployee(session_id, null))
                    {
                        lblStatusText.Text = "Approved and added to Active Employee Data Records";
                        dvStatus.Visible = true;
                    }
                    btnNext_Click(null, null);
                }
                else if (hidSave.Value.Equals("Pend"))
                {
                    hidSave.Value = "";
                    if (Data.isPendingEmployee(session_id, null))
                        Data.PendConfirmation(session_id);
                    lblTitle.Text = "Confirmation of New Hire Pended Until Further Editing/Approval";
                    lblStatusText.Text = "Pended for further editing/approval";
                    dvStatus.Visible = true;
                    htmbtnSave.Visible = false;
                    htmbtnPend.Visible = false;
                    TabStrip1.Disable();
                    btnAddAnotherNewHire.Visible = true;
                    btnGotoPendingNewHiresAdministration.Visible = true;
                    btnReturntoAdministrationHomepage.Visible = true;
                    btnNext.Visible = false;
                    btnCancel.Visible = false;
                    lblInstruction.Text = System.Configuration.ConfigurationManager.AppSettings["ConfirmInst2"];
                    return;
                }
                lblInstruction.Text = System.Configuration.ConfigurationManager.AppSettings["ConfirmInst2"];
            }
            if (!(bool)ViewState["skip"])
            {
                ViewState["skip"] = true;
                if (Data.isPendingEmployee(session_id, null))
                {
                    ViewState["AutoPended"] = true;
                    string strSave = "<script>Javascript:DoSave2()</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strSave", strSave);
                    return;
                }
                else
                {
                    lblTitle.Text = "Approve New Hire to Active Record";
                    lblInstruction.Text = Data.GetConfirmationTextSetup(ViewState["Selected_Account_Number"].ToString());
                    if (string.IsNullOrEmpty(lblInstruction.Text))
                        lblInstruction.Text = System.Configuration.ConfigurationManager.AppSettings["ConfirmInst1"];
                }
            }
        }

        private void DoStar()
        {
            BasStar.StarFunctionality star = new BasStar.StarFunctionality();
            star.ConnStr = System.Configuration.ConfigurationManager.AppSettings["ConnStr"];
            star.SetLabel(this, ViewState["Selected_Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(), Convert.ToInt16(ViewState["User_Group_ID"].ToString()));
            star = null;
        }

        private bool GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                lblTrustor.Text = SQLStatic.AccountData.Master_Account_Name(ViewState["Selected_Account_Number"].ToString(), conn);
                DataTable tbl = Data.AccountAndEmployeeNames(session_id,conn);
                lblEmployerName.Text = tbl.Rows[0]["account"].ToString();
                lblClass.Text = tbl.Rows[0]["description"].ToString();
                lblAddress1.Text = tbl.Rows[0]["address1"].ToString();
                if (!string.IsNullOrEmpty(tbl.Rows[0]["address2"].ToString()))
                    lblAddress1.Text += "<br />"+tbl.Rows[0]["address2"].ToString();
                lblAddress1.Text += "<br />" + tbl.Rows[0]["city"].ToString();  
                         
                lblSavedSuccessfully.Text = tbl.Rows[0]["employee_name"].ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        private bool DoSave()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "web_site", Request.Url.Authority.ToString().ToUpper(),conn);
                Data.SaveConfirmation(session_id,conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (DoSave())
            {
                htmbtnSave.Visible = false;
                htmbtnPend.Visible = false;
                TabStrip1.Disable();
                btnAddAnotherNewHire.Visible = true;
                btnGotoPendingNewHiresAdministration.Visible = true;
                btnReturntoAdministrationHomepage.Visible = true;
                btnNext.Visible = false;
                btnCancel.Visible = false;
            }
        }

        protected void btnAddAnotherNewHire_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "EMPLOYEE_NUMBER", "0",conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "2NDTITLE", "",conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Response.Redirect("/web_projects/newhirewizard/Account_Division_Class_PaySchedule.aspx?SkipCheck=YES", true);
        }

        protected void btnGotoPendingNewHiresAdministration_Click(object sender, EventArgs e)
        {
            if (Data.CanEditPending(ViewState["Selected_Account_Number"].ToString()))
                Response.Redirect("start.ASPX?SkipCheck=YES&Pend=1", true);
            else
                Response.Redirect("/web_projects/PendingNewHire/Default.aspx?SkipCheck=YES", true);
        }

        protected void btnReturntoAdministrationHomepage_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WEB_PROJECTS/ADMIPOINT/DEFAULT.ASPX?SkipCheck=YES", true);
        }
    }
}
