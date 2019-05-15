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
    public partial class Personal_Information : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(2);
                SetAccountName();
                ViewState["rbAccount"] = rblAccounts.Items[1].Text;
                GetText();
            }
        }

        private RadioButtonList GetRadioButtonList(string id)
        {
            return Bas_Utility.Utilities.GetRadioButtonList(Page, id);
        }

        private CheckBoxList GetCheckBoxList(string id)
        {
            return Bas_Utility.Utilities.GetCheckBoxList(Page, id);
        }

        private Label GetLabel(string id)
        {
            return Bas_Utility.Utilities.GetLabel(Page, id);
        }

        private Panel GetPanel(string id)
        {
            return Bas_Utility.Utilities.GetPanel(Page, id);
        }

        private TextBox GetTextBox(string id)
        {
            return Bas_Utility.Utilities.GetTextBox(Page, id);
        }

        private RadEditor GetRaEditor(string id)
        {
            return (Telerik.Web.UI.RadEditor)Page.FindControl(id);
            //return Bas_Utility.Utilities.GetRadEditor(Page, id);
        }

        private void SetAccountName()
        {
            string strAccountName = "";
            if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
            {
                GetRadioButtonList("rblAccounts").Items[1].Enabled = false;
                GetRadioButtonList("cblAccounts").Items[1].Enabled = false;
                GetRadioButtonList("cblAccounts").Items[2].Enabled = false;
            }
            else
            {
                strAccountName = "(" + SQLStatic.AccountData.AccountName(ViewState["Selected_Account_Number"].ToString()) + ")";
            }
            GetRadioButtonList("rblAccounts").Items[1].Text = GetRadioButtonList("rblAccounts").Items[1].Text.Replace("[Accnt]", strAccountName);
            GetRadioButtonList("cblAccounts").Items[1].Text = GetRadioButtonList("cblAccounts").Items[1].Text.Replace("[Accnt]", strAccountName);
            GetRadioButtonList("cblAccounts").Items[2].Text = GetRadioButtonList("cblAccounts").Items[2].Text.Replace("[Accnt]", strAccountName);
        }

        private void GetText()
        {
            DataTable tbl = Data.GetMessageDetail(session_id, GetRadioButtonList("rblEnrollmentType").SelectedValue, GetRadioButtonList("rblItem").SelectedValue, 
                GetRadioButtonList("rblAccounts").SelectedValue);
            GetLabel("lblText").Text = tbl.Rows[0]["page_display_value"].ToString();
            GetLabel("lblDescription").Text = tbl.Rows[0]["description"].ToString();
            GetTextBox("textDescription").Text = GetLabel("lblDescription").Text;
            GetRaEditor("RadEditor1").Content = tbl.Rows[0]["page_display_value"].ToString();
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
            //GetRadioButtonList("cblAccounts").SelectedIndex = GetRadioButtonList("rblAccounts").SelectedIndex;
            Welcome.ClearRadioButtonList(GetRadioButtonList("cblAccounts"));
            GetCheckBoxList("cblEnrollmentType").SelectedIndex = GetRadioButtonList("rblEnrollmentType").SelectedIndex;
            GetPanel("dvEdit").Visible = GetRadioButtonList("rblMode").SelectedValue.Equals("1");
            GetPanel("dvView").Visible = !GetPanel("dvEdit").Visible;
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
                foreach (ListItem li in GetCheckBoxList("cblEnrollmentType").Items)
                {
                    if (li.Selected)
                    {
                        foreach (ListItem lia in GetRadioButtonList("cblAccounts").Items)
                            if (lia.Selected)
                            {
                                Data.SaveMessageData(session_id, li.Value, GetRadioButtonList("rblItem").SelectedValue, lia.Value,
                                    GetTextBox("textDescription").Text, GetRaEditor("RadEditor1").Content, conn);
                            }
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            GetRadioButtonList("rblMode").SelectedIndex = 0;
            GetPanel("dvEdit").Visible = GetRadioButtonList("rblMode").SelectedValue.Equals("1");
            GetPanel("dvView").Visible = !GetPanel("dvEdit").Visible;
            GetText();
        }

        protected void btnManage_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(session_id, "backto", Request.Path);
            Response.Redirect("/web_projects/Page_Manager/Default.aspx?SkipCheck=YES&Page=/web_projects/EnrollmentWizard/Personal_Information.aspx", true);
        }

        protected void cblAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblAccounts.SelectedValue.Equals("1"))
            {
                btnClear.Visible = false;
                Bas_Utility.Misc.Alert(Page, Welcome.stAlertMessage);
            }
            else
                btnClear.Visible = true;   
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            RadEditor1.Content = string.Empty;
            btnSave_Click(null, null);
        }
    }
}
