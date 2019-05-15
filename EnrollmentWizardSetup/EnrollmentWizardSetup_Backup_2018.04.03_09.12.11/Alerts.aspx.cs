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

// Usere
// Tables cd_ee_select_cvg_alerts_setup

namespace EnrollmentWizardSetup
{
    public partial class Alerts : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(15);
                SetAccountName();
                ViewState["rbAccount"] = rblAccounts.Items[1].Text;
                GetText();
                FillCoverages();
                FillDetail();

            }
        }

        

        private void FillCoverages()
        {
            DataTable tbl = Data.getAlertCoverages(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
            cblPlans.DataSource = tbl;
            cblPlans.Items.Clear();
            cblPlans.DataTextField = "long_description";
            cblPlans.DataValueField = "catcodeplan";
            cblPlans.DataBind();
            foreach (DataRow dr in tbl.Rows)
            {
                if (!dr["count"].ToString().Equals("0"))
                    cblPlans.Items.FindByValue(dr["catcodeplan"].ToString()).Selected = true;
            }

            tbl = Data.getprocessedalertplans(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
            if (!tbl.Rows.Count.Equals(0))
            {
                ddlViewCoverages.DataSource = tbl;
                ddlViewCoverages.DataTextField = "long_description";
                ddlViewCoverages.DataValueField = "catcodeplan";
                ddlViewCoverages.DataBind();
            }
        }

        private void SetAccountName()
        {
            string strAccountName = "";
            if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
            {
                rblAccounts.Items[1].Enabled = false;
                cblAccountss.Items[1].Enabled = false;
                cblAccountss.Items[2].Enabled = false;
            }
            else
            {
                strAccountName = "(" + SQLStatic.AccountData.AccountName(ViewState["Selected_Account_Number"].ToString()) + ")";
            }
            rblAccounts.Items[1].Text = rblAccounts.Items[1].Text.Replace("[Accnt]", strAccountName);
            cblAccountss.Items[1].Text = cblAccountss.Items[1].Text.Replace("[Accnt]", strAccountName);
        }

        private void GetText()
        {
            txtTitle.Text = lblPageTitle.Text;
            DataTable tbl = Data.GetMessageDetail(session_id, rblEnrollmentType.SelectedValue, rblItem.SelectedValue, rblAccounts.SelectedValue);
            lblText.Text = tbl.Rows[0]["page_display_value"].ToString();
            lblDescription.Text = tbl.Rows[0]["description"].ToString();
            textDescription.Text = lblDescription.Text;
            txtNote.Content = tbl.Rows[0]["page_display_value"].ToString();
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
            Welcome.ClearRadioButtonList(cblAccountss);
            cblEnrollmentType.SelectedIndex = rblEnrollmentType.SelectedIndex;
            dvEdit.Visible = rblMode.SelectedValue.Equals("1");
            dvView.Visible = !dvEdit.Visible;
            dvEditPlans.Visible = dvEdit.Visible;
            dvViewPlans.Visible = dvView.Visible;
            
        }

        protected void rblItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetText();
        }

        private void FillDetail()
        {
            if (!string.IsNullOrEmpty(ddlViewCoverages.SelectedValue))
            {
                DataTable tbl = Data.getOneCoverageDetail(ViewState["Selected_Account_Number"].ToString(), ddlViewCoverages.SelectedValue.Substring(0, 7),
                     ddlViewCoverages.SelectedValue.Substring(7), rblEnrollmentType.SelectedValue);
                txtTitle.Text = tbl.Rows[0]["title_"].ToString();
                txtQuestion.Text = tbl.Rows[0]["question_"].ToString();
                txtNote.Content = tbl.Rows[0]["text_"].ToString();
                lblTextEditTitle.Text = txtNote.Content;
                lblText.Text = txtNote.Content;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();

            try
            {
                foreach (ListItem li in cblEnrollmentType.Items)
                {
                    if (li.Selected)
                    {
                        foreach (ListItem lia in cblPlans.Items)
                            if (lia.Selected)
                            {
                                Data.SaveAlert(ViewState["Selected_Account_Number"].ToString(), lia.Text, txtQuestion.Text, txtNote.Content,
                                    lia.Value.Substring(0, 7), lia.Value.Substring(7), li.Value, cblAccountss.SelectedValue);
                            }


                    }
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

            rblMode.SelectedIndex = 0;
            dvEdit.Visible = rblMode.SelectedValue.Equals("1");
            dvView.Visible = !dvEdit.Visible;
            GetText();
        }

        protected void ddlViewCoverages_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            FillDetail();
        }             

       
    }
}