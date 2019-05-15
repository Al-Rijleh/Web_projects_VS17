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
    public partial class Cvrg_Grp_Msgs : System.Web.UI.Page
    {
        string session_id = "";
        string strGridTitle = "Existing Groups for [py] Plan Year";
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
                //dvInstruction.Visible = false;
                SetupTabStrip1.SetTabIndex(9);
                FillProcessingYear();
            }
            btnSave.Attributes.Add("onClick", "Save()");
            rblEnrollType.Enabled = gvGroups.SelectedIndex >= 0;

            if (hidSave.Value.Equals("Go"))
            {
                hidSave.Value = "";
                DoSave();
            }
        }

        private void FillProcessingYear()
        {
            DataTable tbl = Data.GetProcessingYears(ViewState["Selected_Account_Number"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["processing_year"].ToString(), dr["processing_year"].ToString());
                ddlProcessingYear.Items.Add(li);
            }
            ddlProcessingYear.SelectedIndex = 0;
            lblPreviuosSetup.Text = strGridTitle.Replace("[py]", ddlProcessingYear.SelectedValue);
            FillClass();
        }

        private void FillClass()
        {
            DataTable tbl = SQLStatic.AccountData.GetClassCodes(ViewState["Selected_Account_Number"].ToString(), ddlProcessingYear.SelectedValue);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["class_code"].ToString()+" - "+dr["Description"].ToString(), dr["class_code"].ToString());
                ddlClass.Items.Add(li);
            }
            DrawGrid();
        }

        private void DrawGrid()
        {
            DataTable tbl = Data.Get_Grouping_List(ViewState["Selected_Account_Number"].ToString(), ddlProcessingYear.SelectedValue, ddlClass.SelectedValue);
            gvGroups.DataSource = tbl;
            gvGroups.DataBind();
            gvGroups_SelectedIndexChanged(gvGroups, null);
        }

        protected void rblEnrollmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEnrollmentType.SelectedIndex.Equals(0))
            {                
                lblMessage.Visible = true;               
                reMessage.Visible = false;
                btnSave.Enabled = false;
            }
            else
            {                
                lblMessage.Visible = false;               
                reMessage.Visible = true;
                btnSave.Enabled = true;
            }
        }

        protected void DoSave()
        {
            //reInstruction.Content = "";
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                foreach (ListItem li in cbEnrommentType.Items)
                {
                    if (li.Selected)
                        Data.Save_Grp_msg(session_id, ViewState["record_id"].ToString(), null, reMessage.Content, li.Value, rblSaveTo.SelectedValue);
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
                SQLStatic.SQL.CloseConnection(conn);
            }
            rblEnrollmentType.SelectedIndex = 0;
            rblEnrollType.SelectedIndex = 0;
            gvGroups_SelectedIndexChanged(gvGroups, null);
            rblEnrollmentType_SelectedIndexChanged(null, null);
        }

        protected void ddlProcessingYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPreviuosSetup.Text = strGridTitle.Replace("[py]", ddlProcessingYear.SelectedValue);
            FillClass();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGrid();
        }  

        protected void gvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvGroups.SelectedIndex < 0)
            {
                lblMessage.Text = "";
                reMessage.Content = "";
                return;
            }
            rblEnrollType.Enabled = gvGroups.SelectedIndex >= 0;
            DataTable tbl = gvGroups.DataSource as DataTable;
            if (tbl == null)
                tbl = Data.Get_Grouping_List(ViewState["Selected_Account_Number"].ToString(), ddlProcessingYear.SelectedValue, ddlClass.SelectedValue);
            if (gvGroups.SelectedIndex > tbl.Rows.Count)
            {
                gvGroups.SelectedIndex = 0;
            }

            string strid = tbl.Rows[gvGroups.SelectedIndex]["record_id"].ToString();
            ViewState["record_id"] = strid;
            tbl = Data.GroupMessage(strid, rblEnrollType.SelectedValue);
            lblMessage.Text = tbl.Rows[0]["Message"].ToString();
            reMessage.Content = lblMessage.Text;
            tbl.Dispose();
        }

        protected void rblEnrollType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable tbl = Data.GroupMessage(ViewState["record_id"].ToString(), rblEnrollType.SelectedValue);
            lblMessage.Text = tbl.Rows[0]["Message"].ToString();
            reMessage.Content = lblMessage.Text;
            tbl.Dispose();
        }

        

        
        
    }
}
