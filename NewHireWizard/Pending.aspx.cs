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
    public partial class Pending : System.Web.UI.Page
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
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER");
                TabStrip1.SetCurrentTab(Request.Path);
                
                GetDataFromSession();
                jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), "", "");
            }
            TabStrip1.wPage = Page;
            TabStrip1.CurrentPath = Request.Path;
        }

        private bool GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                DataTable tbl = Data.AccountAndEmployeeNames(session_id,conn);
                lblDivisionValue.Text = tbl.Rows[0]["account"].ToString();
                lblEmployeeValue.Text = tbl.Rows[0]["employee_name"].ToString();     
           
                lblPendingRequired.Visible = Data.isPendingEmployee(session_id,conn);
                lblNoPending.Visible = !lblPendingRequired.Visible;
                dvPendRequied.Visible = lblPendingRequired.Visible;                               
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }        

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabStrip1.PreviousURL());
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabStrip1.NextURL());
        }
    }
}
