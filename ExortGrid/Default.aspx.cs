using System;
using Telerik.Web.UI;
using System;
using System.Web.UI.WebControls;
using xi = Telerik.Web.UI.ExportInfrastructure;
using System.Web.UI;
using System.Web;
using Telerik.Web.UI.GridExcelBuilder;
using System.Drawing;
namespace ExortGrid
{
    
    public partial class Default : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            string strSQL = "select * from eeprofile_ p where p.account_number = '0000699-0001-000' and p.termination_date is null and p.employee_number <118609";
            RadGrid1.DataSource = SQLStatic.SQL.ExecTable(strSQL);
        }
    }
}
    