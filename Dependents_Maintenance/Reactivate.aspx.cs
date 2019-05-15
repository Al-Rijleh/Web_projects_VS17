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

namespace Dependents_Maintenance
{
    public partial class Reactivate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                string DepeName = Data.get_dep_name(ViewState["Employee_Number"].ToString(),Request.Params["dep_id"]);
                lblDepName.Text = DepeName;
                lblConfirm.Text = lblConfirm.Text.Replace("{name}",DepeName)  ;
                txtReactiveDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
                ViewState["SESSION_CALLING_MODULE"] = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
            }
            SetForOpenEnrollment();
        }

        private void SetForOpenEnrollment()
        {
            if (InOpenEnrollment())
            {
                Label1.Visible = false;
                lblDepName.Visible = false;
                txtReactiveDate.Text = Data.BeginOfNextYear(ViewState["Selected_Account_Number"].ToString());
                txtReactiveDate.Visible = false;
                lblReactivateDate.Visible = false;
                RangeValidator1.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
            }
        }

        

        private bool InOpenEnrollment()
        {
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "O")
                return true;
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "A")
                return true;
            return false;
        }

        private string stripDate(string str)
        {
            str = str.Replace("_", "");
            if (str == "//")
                str = "";
            return str;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            txtReactiveDate.Text = stripDate(txtReactiveDate.Text);
            Validate();
            if (!IsValid)
                return;
            if (Request.Params["dep_id"] != "-1")
                Data.ReactivateDependent(Request.Params["id"], txtReactiveDate.Text, ViewState["User_Name"].ToString());
            else
                Data.ReactivatePendingDependent(Request.Params["id"], txtReactiveDate.Text, ViewState["User_Name"].ToString());
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        protected void btnNO_Click(object sender, EventArgs e)
        {
            string strCallCloseWindow = "<script>docloseWindow(0)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }
    }
}
