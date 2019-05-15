using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Automated_Rate_Update
{
    public partial class AccountsListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadTabStrip1.Tabs[1].Selected = true;
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (rblstatus.SelectedIndex.Equals(-1))
                return;
            DataTable tbl = Data.Get_Accounts_List(rblstatus.SelectedValue);
            RadGrid1.DataSource = tbl;
        }

        protected void rblRateRewal_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tbl = Data.Get_Accounts_List(rblstatus.SelectedValue);
            RadGrid1.DataSource = tbl;
            RadGrid1.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {            
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.MasterTableView.ExportToExcel();            
        }

       
    }
}