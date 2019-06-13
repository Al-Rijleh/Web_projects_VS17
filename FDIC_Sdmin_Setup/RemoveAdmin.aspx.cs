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
    public partial class RemoveAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "admin_ee");
                lblAdminName.Text = SQLStatic.EmployeeData.employee_name_(ViewState["Employee_Number"].ToString()) + " (Employee# " + ViewState["Employee_Number"].ToString()+")";
                DrawGrid();
            }
        }

        private void DrawGrid()
        {
            DataTable tbl = Data.Get_fdic_admin_assignment_data(ViewState["Employee_Number"].ToString(), null);
            gvEmployee.DataSource = tbl;
            gvEmployee.DataBind();
        }

        protected void RadButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?SkipCheck=YES", true);
        }

        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvEmployee.DataSource;
            if (tbl == null)
                tbl = Data.Get_fdic_admin_assignment_data(ViewState["Employee_Number"].ToString());
            try
            {
                if (e.Row.RowIndex == -1)
                    return;                
                string strIndex = tbl.Rows[e.Row.RowIndex]["record_id"].ToString();
                RadComboBox ddl1 = new RadComboBox();
                ddl1.ID = "ddlOfficeDiv_" + strIndex;
                ddl1.Width=System.Web.UI.WebControls.Unit.Pixel(150);
                ddl1.MarkFirstMatch = true;
                ddl1.DropDownWidth=System.Web.UI.WebControls.Unit.Pixel(200);
                DataTable tblReplace = Data.Get_fdic_admin_Replacement(strIndex);
                ddl1.DataSource = tblReplace;
                ddl1.DataTextField = "EEName";
                ddl1.DataValueField = "record_id";
                ddl1.DataBind();

                Button btn = new Button();
                btn.ID = "btn_"+strIndex;
                btn.Text = "Go";
                btn.Enabled = !tblReplace.Rows.Count.Equals(0);
                btn.Click += new System.EventHandler(this.btnMenu_Click);

                TableCell cellcb = e.Row.Cells[3];
                cellcb.Controls.Add(ddl1);
                cellcb.Controls.Add(btn);               
            }
            catch { }  
        }

        private void btnMenu_Click(object sender, System.EventArgs e)
        {            
            string strIndex = ((Button)sender).ID.Substring(4);
            RadComboBox ddl1 = Bas_Utility.Utilities.GetRadComboBox(gvEmployee, "ddlOfficeDiv_" + strIndex);
            Data.replace_admin(Request.Cookies["Session_ID"].Value.ToString(),strIndex, ddl1.SelectedValue);
            Bas_Utility.Misc.AlertSaved(Page);
            DrawGrid();
        }

        protected void RadCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx?SkipCheck=YES", true);
        }
        
    }
}