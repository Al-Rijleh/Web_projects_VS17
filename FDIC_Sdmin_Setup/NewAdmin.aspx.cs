using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FDIC_Sdmin_Setup
{
    public partial class NewAdmin : System.Web.UI.Page
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
                    // setup logo
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
                dvOfficrdiv.Visible = false;
                strip.Tabs[1].Selected = true;
                GetEmployee();
                FillOfficeDiv();
                FillOrganizationCode();                
            }
        }

        private void GetEmployee()
        {
            lblEmployeeName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_NAME");
            if (!string.IsNullOrEmpty(lblEmployeeName.Text))
                lblEmployeeName.Visible = true;
            ViewState["Found_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER");
        }

        

        private void FillOfficeDiv()
        {
            DataTable tbl = Data.get_office_division();
            ddlOfficeDiv.DataSource = tbl;
            ddlOfficeDiv.DataTextField = "office_division";
            ddlOfficeDiv.DataValueField = "office_division";
            ddlOfficeDiv.DataBind();
            
        }

        private void FillOrganizationCode()
        {
            DataTable tbl = Data.get_org_code();
            ddlOrganizationCode.DataSource = tbl;
            ddlOrganizationCode.DataTextField = "org_code";
            ddlOrganizationCode.DataValueField = "org_code";
            ddlOrganizationCode.DataBind();

        }



        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (strip.SelectedIndex)
            {
                case 0:
                    Response.Redirect("Default.aspx?SkipCheck=YES", true);
                    break;
                case 2:
                    Response.Redirect("SuperUser.aspx?SkipCheck=YES", true);
                    break;
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string strParamQuery ="&SkipCheck=YES&inst=4&AllowApplicant=YES&start=&returl=" + Request.Path ;
            
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Data.add_fdic_admin_assignments(ViewState["Found_Number"].ToString(), ddlOrganizationCode.SelectedValue.Remove(0, 5), 
                ddlOrganizationCode.SelectedValue.Substring(0,4), ddlIsPrimary.SelectedValue, txtRegional_Address.Text);
            Bas_Utility.Misc.AlertSaved(Page);
        }
    }
}