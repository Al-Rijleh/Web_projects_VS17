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
using Telerik.Web.UI;
namespace EnrollmentWizardSetup
{
    public partial class Wellnessplan : System.Web.UI.Page
    {
        string session_id = "";
        public static string stAlertMessage = "You selected the Default option. The default data will be replaced with the new data from this page";
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
                if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
                {
                    string strURL = "'/web_projects/Account_Number/Default.aspx?SkipCheck=YES&goto=/web_projects/EnrollmentWizardSetup/Welcome.aspx?SkipCheck=YES'";
                    string strSelectAccount = "<script>GetAccount(" + strURL + ");</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strSelectAccount", strSelectAccount);
                }
                //Data.SetInitial_Processing_Year(session_id);
                ViewState["Processing_Year"] = SQLStatic.Sessions.GetSessionValue(session_id, "Processing_Year");
                Bas_Utility.Utilities.SetHeaderFrame(Page, "Enrollment Wizard Setup", "ACCOUNT_INFO", " ");
                SetupTabStrip1.SetTabIndex(17);
                SetAccountName();
                ViewState["rbAccount"] = rblAccounts.Items[1].Text;
                GetText();

            }
        }

        private void SetAccountName()
        {
            string strAccountName = "";
            if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
            {
                rblAccounts.Items[1].Enabled = false;
                cblAccounts.Items[1].Enabled = false;
                cblAccounts.Items[2].Enabled = false;
            }
            else
            {
                strAccountName = "(" + SQLStatic.AccountData.AccountName(ViewState["Selected_Account_Number"].ToString()) + ")";
            }
            rblAccounts.Items[1].Text = rblAccounts.Items[1].Text.Replace("[Accnt]", strAccountName);
            cblAccounts.Items[1].Text = cblAccounts.Items[1].Text.Replace("[Accnt]", strAccountName);
            cblAccounts.Items[2].Text = cblAccounts.Items[2].Text.Replace("[Accnt]", strAccountName);
        }

        private void GetText()
        {
            DataTable tbl = Data.GetMessageDetail(session_id, rblEnrollmentType.SelectedValue, rblItem.SelectedValue, rblAccounts.SelectedValue);
            lblText.Text = tbl.Rows[0]["page_display_value"].ToString();
            lblDescription.Text = tbl.Rows[0]["description"].ToString();
            textDescription.Text = lblDescription.Text;
            RadEditor1.Content = tbl.Rows[0]["page_display_value"].ToString();
            tbl.Dispose();

            bool has_acc = Data.Has_Account_Specific_text(ViewState["Selected_Account_Number"].ToString(), rblEnrollmentType.SelectedValue, rblItem.SelectedValue);
            if (!has_acc)
            {
                if (rblAccounts.SelectedIndex.Equals(1))
                    lblText.Text = "<span style='font-size: 26px; font-family: arial; color: #c00000;'><strong><span style='font-size: 20px;'>Using Default Text</span></strong></span>";
                rblAccounts.Items[1].Text = ViewState["rbAccount"].ToString() + "  <strong style='background-color: #ffff00;'><span style='font-family: arial; font-size: 13px; color: #c00000;'>Using Default</span></strong>";
            }
            else
            {
                rblAccounts.Items[1].Text = ViewState["rbAccount"].ToString() + "  <strong style='background-color: #ebf1dd;'><span style='font-family: arial; font-size: 13px; color: #567a31;'>Using Account Specific</span></strong>";
            }
        }



        protected void rblMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cblAccounts.SelectedIndex = rblAccounts.SelectedIndex;
            ClearRadioButtonList(cblAccounts);
            cblEnrollmentType.SelectedIndex = rblEnrollmentType.SelectedIndex;
            dvEdit.Visible = rblMode.SelectedValue.Equals("1");
            dvView.Visible = !dvEdit.Visible;
        }

        protected void rblItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetText();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                foreach (ListItem li in cblEnrollmentType.Items)
                {
                    if (li.Selected)
                    {
                        foreach (ListItem lia in cblAccounts.Items)
                            if (lia.Selected)
                            {
                                Data.SaveMessageData(session_id, li.Value, rblItem.SelectedValue, lia.Value, textDescription.Text, RadEditor1.Content, conn);
                            }
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            rblMode.SelectedIndex = 0;
            dvEdit.Visible = rblMode.SelectedValue.Equals("1");
            dvView.Visible = !dvEdit.Visible;
            GetText();
        }

        protected void cblAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblAccounts.SelectedValue.Equals("1"))
            {
                btnClear.Visible = false;
                string strWarning = BASUSA.MiscTidBit.JSAlert(stAlertMessage);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strWarning", strWarning);
            }
            else
                btnClear.Visible = true;
        }

        public static void ClearRadioButtonList(RadioButtonList rbl)
        {
            foreach (ListItem li in rbl.Items)
                li.Selected = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            RadEditor1.Content = string.Empty;
            btnSave_Click(null, null);
        }
    }
}