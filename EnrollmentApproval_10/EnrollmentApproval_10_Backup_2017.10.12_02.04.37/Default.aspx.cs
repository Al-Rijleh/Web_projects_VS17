using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EnrollmentApproval
{
    public partial class Default : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region BasTemplate
            if (!IsPostBack)
            {
                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
                    Response.Redirect("/web_projects/PTemplate/index.htm");
                    return;
                }
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
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {
                dvMaster.Visible = false;
                dvLocation.Visible = false;
                dvProgramType.Visible = ViewState["User_Group_ID"].ToString().Equals("1");
                SetProgramTypes();
                if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                {
                    lblWelcome.Text = "Welcome to Verify Pending Dependents module<br/>";
                    pnlProcessingYear.Visible = false;
                    lblInstruction.Text = "To select an employee, please click on the employee’s Number.";
                }
            }


        }

        protected void rgEmployees_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                string ee_no = (e.CommandSource as LinkButton).Text.Replace("<u>", "").Replace("</u>", "");
                if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                    Response.Redirect("Profile.aspx?ee=" + ee_no + "&Verify=" + Request.Params["Verify"], true);
                else
                    Response.Redirect("Profile.aspx?ee=" + ee_no, true);
            }
        }

        private void SetProgramTypes()
        {
            DataTable tbl = Data.ProgramTypeList();
            ddlProgramType.DataSource = tbl;
            ddlProgramType.DataTextField = "text";
            ddlProgramType.DataValueField = "program_type";
            ddlProgramType.DataBind();
        }

        private void FillMasterAccount()
        {
            DataTable tbl = Data.MasterAccountsList(ddlProgramType.SelectedValue);
            ddlMasterAccounts.DataSource = tbl;
            ddlMasterAccounts.DataTextField = "text";
            ddlMasterAccounts.DataValueField = "account_number";
            ddlMasterAccounts.DataBind();
        }

        private void FillLocationst()
        {
            DataTable tbl = Data.AccountsList(ddlMasterAccounts.SelectedValue);
            ddlLocation.DataSource = tbl;
            ddlLocation.DataTextField = "text";
            ddlLocation.DataValueField = "account_number";
            ddlLocation.DataBind();            
        }

        protected void rgEmployees_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["Verify"]))
            {
                rgEmployees.DataSource = Data.PendingEmployeeList(session_id);
                return;
            }
            if (ddlProgramType.SelectedValue.Equals("-1"))
                rgEmployees.DataSource = Data.EE_Reuire_Approval(session_id);
            else
                rgEmployees.DataSource = Data.EE_Reuire_Approval_Program_Typ(session_id, ddlProgramType.SelectedValue);
        }

        protected void ddlMasterAccounts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            FillLocationst();
            SQLStatic.Sessions.SetSessionValue(session_id, "account_number", ddlMasterAccounts.SelectedValue);
            lblScript.Text = "<script language='javascript' type='text/javascript'> window.top.RefreshHeader();" +
                "window.open('/web_projects/ptemplate/top.aspx?session=YES&code=0','Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame') </script>";
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void ddlProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["Verify"]))
            {
                rgEmployees.DataSource = Data.PendingEmployeeList(session_id);
                rgEmployees.DataBind();
                return;
            }
            if (ddlProgramType.SelectedValue.Equals("-1"))
                rgEmployees.DataSource = Data.EE_Reuire_Approval(session_id);
            else
                rgEmployees.DataSource = Data.EE_Reuire_Approval_Program_Typ(session_id, ddlProgramType.SelectedValue);
            rgEmployees.DataBind();
        }
    }
}