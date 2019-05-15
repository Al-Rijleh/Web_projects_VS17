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
    public partial class verify : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(13);
                lblInstruction.Text = "Verify Account <b>" + ViewState["Selected_Account_Number"].ToString() + " / " +
                    SQLStatic.AccountData.AccountName(ViewState["Selected_Account_Number"].ToString()) +
                    "</b> Data For Processing Year <b>" + ViewState["Processing_Year"].ToString() + "</B>";                
            }
            DrawMissingGroupingTypeGrid();
            DrawMissingSortPlanGrid();
            DrawMissingCutoffAgeGrid();
        }

        private void DrawMissingGroupingTypeGrid()
        {
            DataTable tbl = Data.Verify_Account_Group_Type(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                lblMissingGroupType.Visible = true;
                grdMissingGroupType.Visible = false;
                lnkbtnMissingGroupType.Visible = false;
                return;
            }
            grdMissingGroupType.DataSource = tbl;
            grdMissingGroupType.DataBind();            
        }

        private void DrawMissingSortPlanGrid()
        {
            DataTable tbl = Data.Verify_Account_Plan_Sort(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                lblMissingSortPlan.Visible = true;
                gvMissingSortPlan.Visible = false;
                lnkbtnMissingSortPlan.Visible = false;
                return;
            }
            gvMissingSortPlan.DataSource = tbl;
            gvMissingSortPlan.DataBind();
        }

        private void DrawMissingCutoffAgeGrid()
        {
            DataTable tbl = Data.Verify_Account_Cutoff_Age(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                lblMissingCutOffAge.Visible = true;
                gvMissingCutOffAge.Visible = false;
                lnkbtnMissingCutoff.Visible = false;
                return;
            }
            gvMissingCutOffAge.DataSource = tbl;
            gvMissingCutOffAge.DataBind();
        }

        protected void lnkbtnMissingGroupType_Click(object sender, EventArgs e)
        {
            grdMissingGroupType.ExportSettings.ExportOnlyData = true;
            grdMissingGroupType.ExportSettings.IgnorePaging = true;
            grdMissingGroupType.MasterTableView.ExportToExcel();
        }

        protected void lnkbtnMissingSortPlan_Click(object sender, EventArgs e)
        {
            gvMissingSortPlan.ExportSettings.ExportOnlyData = true;
            gvMissingSortPlan.ExportSettings.IgnorePaging = true;
            gvMissingSortPlan.MasterTableView.ExportToExcel();
        }

        protected void lnkbtnMissingCutoff_Click(object sender, EventArgs e)
        {
            gvMissingCutOffAge.ExportSettings.ExportOnlyData = true;
            gvMissingCutOffAge.ExportSettings.IgnorePaging = true;
            gvMissingCutOffAge.MasterTableView.ExportToExcel();
        }
    }
}
