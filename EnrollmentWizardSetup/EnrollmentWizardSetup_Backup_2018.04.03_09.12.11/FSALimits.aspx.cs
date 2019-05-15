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
    public partial class FSALimits : System.Web.UI.Page
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
            btnFSA.Attributes.Add("OnClick", "JavaScript:SaveFSA()");
            if (!IsPostBack)
            {
                SetupTabStrip1.SetTabIndex(7);
                FillPayPeriodCodes();
            }
            if (!string.IsNullOrEmpty(hid1.Value))
            {
                hid1.Value = "";
                SaveFSALimit();
            }

        }
        private void FillPayPeriodCodes()
        {
            DataTable tbl = Data.PayPeriodCodes(ViewState["Selected_Account_Number"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["pay_period_code"].ToString(), dr["pay_period_code"].ToString());
                ddlPayCodes.Items.Add(li);
            }
            ddlPayCodes_SelectedIndexChanged(null, null);
        }

        protected void ddlPayCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPayDates(ddlPayCodes.SelectedValue);
        }

        private void FillPayDates(string PayCode)
        {
            rbPayDates.Items.Clear();
            DataTable tbl = Data.PayDatesList(session_id, PayCode);
            int i = 1;
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["paydate"].ToString(), i.ToString());
                li.Selected = dr["selected"].ToString().Equals("1");
                rbPayDates.Items.Add(li);
                i++;
            }

        }

        private void SaveFSALimit()
        {
            Validate();
            if (!IsValid)
                return;
            Data.SaveFSALimit(session_id, ddlPayCodes.SelectedValue, rbPayDates.SelectedValue, rblPageSave.SelectedValue);
        }
    }
}
