using System;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using xi = Telerik.Web.UI.ExportInfrastructure;
using System.Web.UI;
using System.Web;
using Telerik.Web.UI.GridExcelBuilder;
using System.Drawing;
using System.Data;

namespace FDIC_Sdmin_Setup
{
    public partial class Detal : System.Web.UI.Page
    {
        DataTable tblDivision = null;
        DataTable tblOrg = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillEmployees();
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (ViewState["Action"].ToString().Equals("null"))
                    return;
                if (ViewState["Action"].ToString().Equals("org"))
                    RadGrid1.DataSource = Data.eesAssociatedwithORGCode(txtOrg.Text);
                else
                    RadGrid1.DataSource = Data.eesAssociatedwithAdmin(ddlAdmin.SelectedValue);
                
            }
            catch { }
        }

        protected void DrawGridList()
        {
            try
            {
                if (ViewState["Action"].ToString().Equals("null"))
                    return;
                if (ViewState["Action"].ToString().Equals("org"))
                    RadGrid1.DataSource = Data.eesAssociatedwithORGCode(txtOrg.Text);
                else
                    RadGrid1.DataSource = Data.eesAssociatedwithAdmin(ddlAdmin.SelectedValue);
                RadGrid1.DataBind();
            }
            catch { }
        }

        protected void ddlAdmin_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ViewState["Action"] = "EE";
            DrawGridList();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ViewState["Action"] = "org";
            
            DrawGridList();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx",true);
        }

        

        protected void chkRemovePaging_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkRemovePaging = (CheckBox)sender;
            if (!chkRemovePaging.Checked)
            {
                RadGrid1.AllowPaging = false;
                RadGrid1.Rebind();
            }
            else
            {
                RadGrid1.AllowPaging = true;
                RadGrid1.PageSize = 15;
                RadGrid1.Rebind();

            }
        }

        protected void ddlMaterAccounts_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ViewState["Action"] = "EE";
            DrawGridList();
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
                    ddlAdmin.FindItemByValue(Request.Params["id"]).Selected = true;
                }
                catch { }
            }
            //ddlMaterAccounts_SelectedIndexChanged(null, null);
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string alternateText = (sender as ImageButton).AlternateText;
            #region [ XSLX FORMAT ]
            if (alternateText == "Xlsx" /*&& CheckBox2.Checked*/)
            {
                RadGrid1.MasterTableView.GetColumn("employee_number").HeaderStyle.BackColor = Color.LightGray;
                RadGrid1.MasterTableView.GetColumn("employee_number").ItemStyle.BackColor = Color.LightGray;
            }
            #endregion
            RadGrid1.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
            RadGrid1.ExportSettings.IgnorePaging = true/*CheckBox1.Checked*/;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.MasterTableView.ExportToExcel();
        }

        #region [ HTML FORMAT ]
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if (CheckBox2.Checked)
            {
                if (e.Item is GridDataItem || e.Item is GridHeaderItem)
                {
                    e.Item.Cells[2].CssClass = "employeeColumn";
                }
            }
        }

        protected void RadGrid1_HtmlExporting(object sender, GridHTMLExportingEventArgs e)
        {
            //if (CheckBox2.Checked)
            {
                e.Styles.Append("@page table .employeeColumn { background-color: #d3d3d3; }");
            }
        }
        #endregion

        #region [ EXCELML FORMAT ]
        protected void RadGrid1_ExcelMLWorkBookCreated(object sender, GridExcelMLWorkBookCreatedEventArgs e)
        {
            //if (CheckBox2.Checked)
            {
                foreach (RowElement row in e.WorkBook.Worksheets[0].Table.Rows)
                {
                    row.Cells[0].StyleValue = "Style1";
                }

                StyleElement style = new StyleElement("Style1");
                style.InteriorStyle.Pattern = InteriorPatternType.Solid;
                style.InteriorStyle.Color = System.Drawing.Color.LightGray;
                e.WorkBook.Styles.Add(style);
            }
        }

        #endregion

        #region [ BIFF FORMAT ]
        protected void RadGrid1_BiffExporting(object sender, GridBiffExportingEventArgs e)
        {
            //if (CheckBox2.Checked)
            {
                e.ExportStructure.Tables[0].Columns[1].Style.BackColor = System.Drawing.Color.LightGray;
            }
        }

        #endregion

        #region [ Built-in Export button configuration ]
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExportToExcelCommandName)
            {
                RadGrid1.ExportSettings.Excel.Format = GridExcelExportFormat.Biff;
                RadGrid1.ExportSettings.IgnorePaging = true; //CheckBox1.Checked;
                RadGrid1.ExportSettings.ExportOnlyData = true;
                RadGrid1.ExportSettings.OpenInNewWindow = true;
            }
        }
        #endregion
    }
}