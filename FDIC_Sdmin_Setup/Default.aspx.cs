using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace FDIC_Sdmin_Setup
{
    public partial class Default : System.Web.UI.Page
    {
        DataTable tblDivision = null;
        DataTable tblOrg = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region BasTemplate
            if (!IsPostBack)
            {
                //if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                //{
                //    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
                //    Response.Redirect("/web_projects/PTemplate/index.htm");
                //    return;
                //}
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
                Bas_Utility.Utilities.SetHeaderFrame(Page, "Administrator Setup", " ", " ");
                strip.Tabs[0].Selected = true;
                ViewState["skip"] = false;
                FillEmployees();                                
            }
            
        }

        private void FillEmployees()
        {
            DataTable tbl = Data.Administrators_List();
            ddlAdmin.DataSource = tbl;
            ddlAdmin.DataTextField = "ee_name";
            ddlAdmin.DataValueField = "employee_number";
            ddlAdmin.DataBind();
            string strSelectedAdmin = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "admin_ee");
            if (!string.IsNullOrEmpty(strSelectedAdmin))
            {
                try
                {
                    ddlAdmin.FindItemByValue(strSelectedAdmin).Selected = true;
                }
                catch { }
            }
            ddlAdmin_SelectedIndexChanged(null, null);
        }

       

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (strip.SelectedIndex)
            {
                case 1:
                    Response.Redirect("NewAdmin.aspx?SkipCheck=YES", true);
                    break;
                case 2:
                    Response.Redirect("SuperUser.aspx?SkipCheck=YES", true);
                    break;
            }
        }
        

        protected void ddlAdmin_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ViewState["skip"] = false;
            //btnShowEEE.Text = "Show Employees whose Administrator Selectd " /*+ ddlAdmin.SelectedItem.Text*/;
            DrawGrid();
        }

       

        private void DrawGrid()
        {
            DataTable tbl = null;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                tblDivision = Data.get_office_division(conn);
                tblOrg = Data.get_org_code(conn);
                tbl = Data.Get_fdic_admin_assignment_data(ddlAdmin.SelectedValue,conn);
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
            gvEmployee.DataSource = tbl;
            gvEmployee.DataBind();
            if ( !(bool)ViewState["skip"])
                SetDefaults(tbl);
            ViewState["skip"] = true;
        }

        private void SetDefaults(DataTable tbl)
        {
            RadComboBox ddl1 = null;
            foreach (DataRow dr in tbl.Rows)
            {
                ddl1 = Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlOfficeDiv_" + dr["record_id"].ToString());
                //ddl1.Items.FindItemByValue(dr["office_division"].ToString()).Selected = true;
            }
            foreach (DataRow dr in tbl.Rows)
            {
                ddl1 = Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlOrganizationCode_" + dr["record_id"].ToString());
                ddl1.Items.FindItemByValue(dr["org_code"].ToString()).Selected = true;
            }
            foreach (DataRow dr in tbl.Rows)
            {
                ddl1 = Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlIsPrimary_" + dr["record_id"].ToString());
                ddl1.Items.FindItemByValue(dr["Is_Primary"].ToString()).Selected = true;
            }
        }

        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvEmployee.DataSource;
            if (tbl == null)
                tbl = Data.Get_fdic_admin_assignment_data(ddlAdmin.SelectedValue);
            try
            {
                if (e.Row.RowIndex == -1)
                    return;
                string strIndex = tbl.Rows[e.Row.RowIndex]["record_id"].ToString();
                //RadComboBox ddl1 = new RadComboBox();
                //ddl1.ID = "ddlOfficeDiv_" + strIndex;
                //ddl1.Width=System.Web.UI.WebControls.Unit.Pixel(350);
                //ddl1.MarkFirstMatch = true;
                //ddl1.DropDownWidth=System.Web.UI.WebControls.Unit.Pixel(500);
                //ddl1.DataSource = tblDivision;
                //ddl1.DataTextField = "office_division";
                //ddl1.DataValueField = "office_division";
                //ddl1.DataBind();
                //TableCell cellcb = e.Row.Cells[0];
                //cellcb.Controls.Add(ddl1);

                RadComboBox ddl2 = new RadComboBox();
                ddl2.ID = "ddlOrganizationCode_" + strIndex;
                ddl2.Width = System.Web.UI.WebControls.Unit.Pixel(350);
                ddl2.MarkFirstMatch = true;
                ddl2.DropDownWidth = System.Web.UI.WebControls.Unit.Pixel(450);
                ddl2.DataSource = tblOrg;
                ddl2.DataTextField = "org_code";
                ddl2.DataValueField = "org_code";
                ddl2.DataBind();
                TableCell cell2 = e.Row.Cells[0];
                cell2.Controls.Add(ddl2);

                RadComboBox ddl3 = new RadComboBox();
                ddl3.ID = "ddlIsPrimary_" + strIndex;
                ddl3.Width = System.Web.UI.WebControls.Unit.Pixel(50);
                ddl3.MarkFirstMatch = true;
                ddl3.DropDownWidth = System.Web.UI.WebControls.Unit.Pixel(50);
                RadComboBoxItem li = new RadComboBoxItem("Yes", "T");
                ddl3.Items.Add(li);
                RadComboBoxItem lin = new RadComboBoxItem("No", "F");
                ddl3.Items.Add(lin);               
                TableCell cell3 = e.Row.Cells[1];
                cell3.Controls.Add(ddl3);

                RadNumericTextBox txt = new RadNumericTextBox();
                txt.ID = "txtRegional_Address_" + strIndex;
                txt.Width = System.Web.UI.WebControls.Unit.Pixel(50);
                //txt.DataType=System.Int16;
                txt.MaxLength=2;
                txt.MaxValue=99;
                txt.MinValue=0;
                txt.NumberFormat.DecimalDigits=0;
                txt.Text = tbl.Rows[e.Row.RowIndex]["regional_address"].ToString();
                TableCell cell4 = e.Row.Cells[2];
                cell4.Controls.Add(txt);

                CheckBox cb = new CheckBox();
                cb.ID = "cb_" + strIndex;                
                cb.CssClass = "fontsmall";                                
                TableCell cellcbr = e.Row.Cells[3];
                cellcbr.Controls.Add(cb);

            }
            catch { }  
        }

  
    

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            DataTable tbl =  Data.Get_fdic_admin_assignment_data(ddlAdmin.SelectedValue, conn);
            try
            {
                Process_Modify(tbl,conn);
                process_remove(tbl, conn);
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
            ViewState["skip"] = false;
            DrawGrid();
            Bas_Utility.Misc.AlertSaved(Page);
        }

        private void process_remove(DataTable tbl, Oracle.DataAccess.Client.OracleConnection conn)
        {
            foreach (DataRow dr in tbl.Rows)
            {
                string strIndex = dr["record_id"].ToString();
                if (Bas_Utility.Utilities.GetCheckBox(gvEmployee, "cb_" + strIndex).Checked)
                {
                    Data.remove_fdic_one_assignmen(strIndex, conn);
                }
            }            
        }

        private void Process_Modify(DataTable tbl, Oracle.DataAccess.Client.OracleConnection conn)
        {
            foreach (DataRow dr in tbl.Rows)
            {
                string strIndex = dr["record_id"].ToString();
                if (!Bas_Utility.Utilities.GetCheckBox(gvEmployee, "cb_" + strIndex).Checked)
                {
                    Data.update_admin_assignments(strIndex,
                        Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlOrganizationCode_" + strIndex).SelectedValue.Remove(0, 5),
                        Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlOrganizationCode_" + strIndex).SelectedValue.Substring(0,4),
                        Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlIsPrimary_" + strIndex).SelectedValue,
                        Bas_Utility.Utilities.GetRadNumericTextBox(gvEmployee, "txtRegional_Address_" + strIndex).Text, conn);                        
                }
            }
            
        }

        protected void btnRemoveAdministrator_Click(object sender, EventArgs e)
        {
            string ee_name = ddlAdmin.SelectedItem.Text;
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "admin_ee", ddlAdmin.SelectedValue);
            Response.Redirect("RemoveAdmin.aspx",true);
            //Data.remove_fdic_admin_assignmen(ddlAdmin.SelectedValue);            
            //ViewState["skip"] = false;
            //FillEmployees();
            //Bas_Utility.Misc.Alert(Page, "Administraor " + ee_name + " was removed");
        }

        protected void btnShowEEE_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detal.aspx?type=" + "EE" + "&id=" + ddlAdmin.SelectedValue,true);
        }

        protected void btShowOrgan_Click(object sender, EventArgs e)
        {

        }
    }
}