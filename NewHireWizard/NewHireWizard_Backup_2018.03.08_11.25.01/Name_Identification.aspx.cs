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
    public partial class Name_Identification : System.Web.UI.Page
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
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER");
                TabStrip1.SetTabIndex(1);                
                FillDropDowns();
                GetDataFromSession();
            }           
        }


        private void FillDropDowns()
        {
            DataTable tbl = Data.MritalStatus(session_id);
            ddlMaritalStatus.Items.Clear();
            ListItem li0 = new ListItem("Select", "x");
            ddlMaritalStatus.Items.Add(li0);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["marital_description"].ToString(), dr["marital_status_code"].ToString());
                ddlMaritalStatus.Items.Add(li);
            }
            tbl.Dispose();
        }

        private void GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                txtFirstName.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtFirstName", conn);
                txtMiddleInitial.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtMiddleInitial", conn);
                txtLastName.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtLastName", conn);
                txtDateofBirth.Text = SQLStatic.Sessions.GetSessionValue(session_id, "txtDateofBirth", conn);
                string strGender = SQLStatic.Sessions.GetSessionValue(session_id, "ddlGender", conn);
                string strMarital = SQLStatic.Sessions.GetSessionValue(session_id, "ddlMaritalStatus", conn);
                if (!string.IsNullOrEmpty(strGender))
                    ddlGender.Items.FindByValue(strGender).Selected = true;
                 if (!string.IsNullOrEmpty(strMarital))
                    ddlMaritalStatus.Items.FindByValue(strMarital).Selected = true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private bool DoSave()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "txtFirstName", txtFirstName.Text, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "txtMiddleInitial", txtMiddleInitial.Text, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "txtLastName", txtLastName.Text, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "txtDateofBirth", txtDateofBirth.Text, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "ddlGender", ddlGender.SelectedValue, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "ddlMaritalStatus", ddlMaritalStatus.SelectedValue, conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            if (DoSave())
                Response.Redirect(TabStrip1.TabUrl(TabStrip1.CurrentTab() + 1));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

    }
}
