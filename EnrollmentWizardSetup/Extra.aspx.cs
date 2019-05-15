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
    public partial class Extra : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(11);
                SetAccountName();
                ViewState["rbAccount"] = rblAccounts.Items[1].Text;
                GetText();
                SetResponse();
                ddlResponseType.DataSource = Data.ExtraPageResponseType();
                ddlResponseType.DataTextField = "text";
                ddlResponseType.DataValueField = "value";
                ddlResponseType.DataBind();
                string ResponseType = Data.Get_other(BASUSA.MiscTidBit.MasterAccount(ViewState["Selected_Account_Number"].ToString()), "833", "0");
                if (!string.IsNullOrEmpty(ResponseType))
                    ddlResponseType.Items.FindByValue(ResponseType).Selected = true;
            }
        }

        private void SetResponse()
        {
            ddlResponseType.DataSource = Data.ExtraPageResponseType();
            ddlResponseType.DataTextField = "text";
            ddlResponseType.DataValueField = "value";
            ddlResponseType.DataBind();
            string ResponseType = Data.Get_other(BASUSA.MiscTidBit.MasterAccount(ViewState["Selected_Account_Number"].ToString()), "833", "0");
            if (!string.IsNullOrEmpty(ResponseType))
                ddlResponseType.Items.FindByValue(ResponseType).Selected = true;

            ddlResponseTypeOE.DataSource = Data.ExtraPageResponseType();
            ddlResponseTypeOE.DataTextField = "text";
            ddlResponseTypeOE.DataValueField = "value";
            ddlResponseTypeOE.DataBind();
            string ResponseTypeOE = Data.Get_other(BASUSA.MiscTidBit.MasterAccount(ViewState["Selected_Account_Number"].ToString()), "834", "0");
            if (!string.IsNullOrEmpty(ResponseType))
                ddlResponseTypeOE.Items.FindByValue(ResponseTypeOE).Selected = true;

            ddlResponseTypeLE.DataSource = Data.ExtraPageResponseType();
            ddlResponseTypeLE.DataTextField = "text";
            ddlResponseTypeLE.DataValueField = "value";
            ddlResponseTypeLE.DataBind();
            string ResponseTypeLE = Data.Get_other(BASUSA.MiscTidBit.MasterAccount(ViewState["Selected_Account_Number"].ToString()), "835", "0");
            if (!string.IsNullOrEmpty(ResponseType))
                ddlResponseTypeLE.Items.FindByValue(ResponseTypeLE).Selected = true;
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
            cblAccountss.Items[2].Text = cblAccountss.Items[2].Text.Replace("[Accnt]", strAccountName);
        }

        private void GetText()
        {
            txtPageName.Text = Data.Extra_Page_Name(ViewState["Selected_Account_Number"].ToString());
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
            Welcome.ClearRadioButtonList(cblAccountss);
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
                        foreach (ListItem lia in cblAccountss.Items)
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

        protected void cblAccountss_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblAccountss.SelectedValue.Equals("1"))
            {
                btnClear.Visible = false;
                Bas_Utility.Misc.Alert(Page, Welcome.stAlertMessage);
            }
            else
                btnClear.Visible = true;
        }

        protected void SaveTitle_Click(object sender, EventArgs e)
        {
            Data.add_er_property_accnt(session_id, ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "118", txtPageName.Text);
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            RadEditor1.Content = string.Empty;
            btnSave_Click(null, null);
        }

        protected void btnSaveResponseType_Click(object sender, EventArgs e)
        {
            Data.add_er_property_accnt(session_id, ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "833", ddlResponseType.SelectedValue);
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void btnSaveResponseTypeOE_Click(object sender, EventArgs e)
        {
            Data.add_er_property_accnt(session_id, ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "834", ddlResponseTypeOE.SelectedValue);
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void btnSaveResponseTypeLE_Click(object sender, EventArgs e)
        {
            Data.add_er_property_accnt(session_id, ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "835", ddlResponseTypeLE.SelectedValue);
            Bas_Utility.Misc.AlertSaved(Page);
        }
    }
}
