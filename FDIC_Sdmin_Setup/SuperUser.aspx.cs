using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FDIC_Sdmin_Setup
{
    public partial class SuperUser : System.Web.UI.Page
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
                strip.Tabs[2].Selected = true;
                GetEmployee();
                DrawGrid();
            }
            
        }

        private void GetEmployee()
        {
            lblEmployeeName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_NAME");
            ViewState["Found_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER");
            if (string.IsNullOrEmpty(lblEmployeeName.Text))
                return;
            if (!Data.is_super_user(ViewState["Found_Number"].ToString()))
                btnSave.Visible = true;
            else
            {
                btnSave.Visible = false;
                string strName = lblEmployeeName.Text;
                lblEmployeeName.Text = "";
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_NAME", "");
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER", "");
                Bas_Utility.Misc.Alert(Page, "Employee " + strName + " is already super user");
            }

        }

   

        private void DrawGrid()
        {
            gvEmployee.DataSource = Data.Super_Users_List();
            gvEmployee.DataBind();
        }

        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvEmployee.DataSource;
            if (tbl == null)
                tbl = Data.Super_Users_List();
            try
            {
                if (e.Row.RowIndex == -1)
                    return;
                string strIndex = tbl.Rows[e.Row.RowIndex]["user_id"].ToString();
                CheckBox cb = new CheckBox();
                cb.ID = "cb_" + strIndex;
                cb.CssClass = "fontsmall";
                TableCell cellcbr = e.Row.Cells[2];
                cellcbr.Controls.Add(cb);

            }
            catch { }  
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (strip.SelectedIndex)
            {
                case 0:
                    Response.Redirect("Default.aspx?SkipCheck=YES", true);
                    break;
                case 1:
                    Response.Redirect("NewAdmin.aspx?SkipCheck=YES", true);
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strParamQuery = "&SkipCheck=YES&inst=4&AllowApplicant=YES&start=&returl=" + Request.Path;

            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Data.Add_Super_User(ViewState["Found_Number"].ToString());
            btnSave.Visible = false;
            lblEmployeeName.Text = "";
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_NAME","");
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "FOUND_EMPLOYEE_NUMBER","");
            DrawGrid();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            DataTable tbl = Data.Super_Users_List();
            try
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    string strIndex = dr["user_id"].ToString();
                    if (Bas_Utility.Utilities.GetCheckBox(gvEmployee, "cb_" + strIndex).Checked)
                    {
                        Data.Remove_Super_User(strIndex, conn);
                    }
                }
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                 throw;
            }
            DrawGrid();
        }
    }
}