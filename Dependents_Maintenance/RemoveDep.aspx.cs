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
    public partial class RemoveDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                string strDepName = SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.get_dependent_name(" + Request.Params["id"] + ") from dual", conn).ToString();
                ViewState["Is_COBRA"] = SQLStatic.SQL.ExecScaler(
                "select pkg_employee_maintenance.has_cobra(" + ViewState["Employee_Number"].ToString() + "," + ViewState["Processing_Year"].ToString() + ") from dual", conn).ToString();
                ViewState["Account_Number"] = SQLStatic.SQL.ExecScaler("select pkg_employee.ee_account_number(" + ViewState["Employee_Number"].ToString() + ") from dual", conn).ToString();
                ViewState["SESSION_CALLING_MODULE"] = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
                conn.Close();
                conn.Dispose();
                lblConfirm.Text = lblConfirm.Text.Replace("{name}", strDepName);
                lblDepName.Text = strDepName;
                FillReason();
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

        private void FillReason()
        {
            ddlReason.Items.Clear();
            if (InOpenEnrollment())
            {
                ListItem lio = new ListItem("Open Enrollment", "1000");
                lio.Selected = true;
                ddlReason.Items.Add(lio);
                ddlReason.AutoPostBack = true;
                ddlReason.Enabled = false;
                txtTerminationDate.Text = Data.LastDayInCurrentYear(ViewState["Selected_Account_Number"].ToString());
                txtTerminationDate.Enabled = false;
                lblOpenEnrollmentNote.Visible = true;
                lblInstruction.Visible = false;
            }

            string current_action = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
            if (current_action.Equals("L"))
            {
                txtTerminationDate.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LIFE_EVENT_DATE");
                txtTerminationDate.Enabled = false;
                lblInstruction.Visible = false;
            }
            DataTable tbl = Data.GetTermReason(Request.Cookies["Session_ID"].Value.ToString());
            string strDescription;
            foreach (DataRow dr in tbl.Rows)
            {
                strDescription = dr["description"].ToString();
                if (ViewState["Is_COBRA"].ToString() == "T")
                {
                    if (dr["generate_cobra"].ToString() == "T")
                        strDescription = strDescription + " (COBRA)";
                }
                ListItem li = new ListItem(strDescription, dr["record_id"].ToString());
                ddlReason.Items.Add(li);
            }
            tbl.Dispose();
            
        }

        private string stripDate(string str)
        {
            str = str.Replace("_", "");
            if (str == "//")
                str = "";
            return str;
        }

        private void DoSave()
        {
            if (Request.Params["dep_id"].ToString() != "-1")
            {
                string current_action = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
                if (current_action.Equals("L"))
                    Data.Pend_Terminate_Dependent(Request.Cookies["Session_ID"].Value.ToString(), Request.Params["id"], txtTerminationDate.Text, ddlReason.SelectedValue);
                else
                    Data.Terminate_Dependent(Request.Params["id"], txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString(),null);
            }
            else
                Data.Terminate_Request_Dependent(Request.Params["id"].ToString().Replace("-",""), ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString());
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            txtTerminationDate.Text = stripDate(txtTerminationDate.Text);
            Validate();
            if (!IsValid)
                return;
            DoSave();
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            string strSession = Request.Cookies["Session_ID"].Value.ToString();
            if ((ViewState["Is_COBRA"].ToString() == "T") && (ddlReason.SelectedItem.Text.IndexOf("COBRA") != -1) && (Request.Params["dep_id"].ToString() != "-1"))
            {
                strCallCloseWindow = "<script>docloseWindow(10)</script>";
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                SQLStatic.Sessions.SetSessionValue(strSession, "TYPE", "QELD_2");
                SQLStatic.Sessions.SetSessionValue(strSession, "GO_URL", "/web_projects/Dependents_Maintenance/Default.aspx?SkipCheck=YES");
                SQLStatic.Sessions.SetSessionValue(strSession, "ACCOUNT_NUMBER", ViewState["Account_Number"].ToString());
                SQLStatic.Sessions.SetSessionValue(strSession, "EMPLOYEE_NUMBER", ViewState["Employee_Number"].ToString());
                SQLStatic.Sessions.SetSessionValue(strSession, "DEPENDENT_NUMBER", Request.Params["dep_id"].ToString());
                conn.Close();
                conn.Dispose();
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        protected void btnNO_Click(object sender, EventArgs e)
        {
            string strCallCloseWindow = "<script>docloseWindow(0)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }      

        protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlReason.SelectedValue.Equals("1000"))
            {
                txtTerminationDate.Text = Data.LastDayInCurrentYear(ViewState["Selected_Account_Number"].ToString());
                txtTerminationDate.Enabled = false;
            }
            else
            {
                txtTerminationDate.Text = "";
                txtTerminationDate.Enabled = true;
            }
            string current_action = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
            if (current_action.Equals("L"))
            {
                txtTerminationDate.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LIFE_EVENT_DATE");
                txtTerminationDate.Enabled = false;
                lblInstruction.Visible = false;
            }
        }
    }
}
