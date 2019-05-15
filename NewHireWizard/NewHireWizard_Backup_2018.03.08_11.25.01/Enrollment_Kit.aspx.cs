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
    public partial class Enrollment_Kit : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
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
                TabStrip1.SetCurrentTab(Request.Path);
                if (Data.ShowAdditionalInfoPage(ViewState["Selected_Account_Number"].ToString()))
                    TabStrip1.ShowTab(2, true);
                cbGentateToUser.Text = Data.User_Name_Email_Address(session_id);
                GetDataFromSession();
                jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), "", "");               
                if (Data.isPendingEmployee(session_id,null))
                {
                    if (!Data.AllowCreationOfEnrollmentKit(ViewState["Selected_Account_Number"].ToString()))
                    {
                        rblGenerateEnrollment.Enabled = false;
                        rblGenerateEnrollment.SelectedIndex = 1;
                    }
                }
                CheckKit();
            }
            TabStrip1.wPage = Page;
            TabStrip1.CurrentPath = Request.Path;
        }

        private void CheckKit()
        {
            //try
            {
                if (Data.App_form_approved_Accnt(ViewState["Selected_Account_Number"].ToString()).Equals("0"))
                {
                    lblIstruction.Text = @"<span style='color: #990000;'><strong><span style='font-size: 10pt; font-family: arial;'>The Enrollment Form is not Approved for Your Organization. If you
believe you should have access to the Enrollment Form, please contact
your BAS account manager. Thank you.</span></strong></span>";
                    dvSelect.Visible = false;
                    rblGenerateEnrollment.SelectedValue = "0";
                }
            }
            //catch { }
        }

        private bool GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER",conn);
                txtEEEmail.Text = Data.Employee_Email(ViewState["Employee_Number"].ToString(), conn);

                DataTable tbl = Data.AccountAndEmployeeNames(session_id, conn);
                lblDivisionValue.Text = tbl.Rows[0]["account"].ToString();
                lblEmployeeValue.Text = tbl.Rows[0]["employee_name"].ToString();
                cbGentateToEE.Text = lblEmployeeValue.Text;
                cbGentateToEE.Text += @"&nbsp;<font color='#FF0000'>Note:</font> The Enrollment Kit will only be sent to 
the employee once the employee verifies his/her email address that you entered 
in their contact information. This pending process is for security purposes and 
assures that only the employee controls the email address you entered.";
                tbl = Data.GetEnrollmentKit(session_id, conn);
                if (tbl.Rows.Count > 0)
                {
                    rblGenerateEnrollment.Items.FindByValue(tbl.Rows[0]["do_enrollment_kit"].ToString()).Selected = true;
                    cbGentateToUser.Checked = tbl.Rows[0]["send_kit_to_user"].ToString().Equals("1");
                    cbAdditionReciepient.Checked = tbl.Rows[0]["send_kit_to_other"].ToString().Equals("1");

                    txtRecepientName.Text = tbl.Rows[0]["other_name"].ToString();
                    txtRecipientEmail.Text = tbl.Rows[0]["other_email"].ToString();
                    cbGentateToEE.Checked = tbl.Rows[0]["send_kit_to_employee"].ToString().Equals("1");
                }
                rblGenerateEnrollment_SelectedIndexChanged(null, null);
                cbAdditionReciepient_CheckedChanged(null, null);
                cbGentateToEE_CheckedChanged(null, null);
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
                Data.SaveEnrollmentKit(session_id, rblGenerateEnrollment.SelectedValue, cbGentateToUser.Checked ? "1" : "0",
                    cbAdditionReciepient.Checked ? "1" : "0", txtRecepientName.Text, txtRecipientEmail.Text, cbGentateToEE.Checked ? "1" : "0");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        protected void cbAdditionReciepient_CheckedChanged(object sender, EventArgs e)
        {
            dvRecipeintEmail.Visible = cbAdditionReciepient.Checked;
            dvRecipeintName.Visible = cbAdditionReciepient.Checked;
        }

        protected void rblGenerateEnrollment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvGenerateRecipeint.Visible = rblGenerateEnrollment.SelectedValue.Equals("1");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabStrip1.PreviousURL());
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            if (!CheckData())
                return;
            Validate();
            if (!IsValid)
                return;
            if (DoSave())
                Response.Redirect(TabStrip1.NextURL());
        }

        private bool CheckData()
        {
            if (rblGenerateEnrollment.SelectedValue.Equals("0"))
                return true;
            if (!cbGentateToUser.Checked && !cbGentateToEE.Checked & !cbAdditionReciepient.Checked)
            {
                lblError.Text = "You must select at lease on recipient.";
                return false;
            }
            return true;
        }

        protected void cbGentateToEE_CheckedChanged(object sender, EventArgs e)
        {
            divEERecieve.Visible = cbGentateToEE.Checked;
            divEEEmailNote.Visible = cbGentateToEE.Checked;
            RequiredFieldValidator5.Enabled = true;
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactInformation.aspx", true);
        }
    }
}
