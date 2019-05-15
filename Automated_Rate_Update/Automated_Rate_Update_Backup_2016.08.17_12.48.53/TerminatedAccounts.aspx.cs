using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Automated_Rate_Update
{
    public partial class TerminatedAccounts : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            lblScript.Text = string.Empty;
            if (!IsPostBack)
            {
                RadTabStrip1.Tabs[1].Selected = true; 
                ViewState["user_name"] = SQLStatic.Sessions.GetUserName(session_id);
            }
            if (!string.IsNullOrEmpty(hidRemove.Value))
            {
                Data.remove_from_v_automatedt_skip_(hidRemove.Value);
                hidRemove.Value = string.Empty;
            }
            DrawGrid();
        }

        private void DrawGrid()
        {
            //grdTerm.DataSource = Data.Terminated_accounts(ddlRenewalDate.SelectedValue);
            //grdTerm.DataBind();

            RadGrid1.DataSource = Data.Terminated_accounts(ddlRenewalDate.SelectedValue);
            RadGrid1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strcheckAccount = Data.Check_Account(txtAccountNumber.Text);
            if (!string.IsNullOrEmpty(strcheckAccount))
            {
                jscriptsFunctions.Misc.Alert(Page, strcheckAccount);
                return;
            }

            Data.Do_Terminate_Account(txtAccountNumber.Text, ViewState["user_name"].ToString(), ddlRenewalDate.SelectedValue);
            txtAccountNumber.Text = string.Empty;
            DrawGrid();
        }

        protected void ddlRenewalDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGrid();
            if (ddlRenewalDate.SelectedValue.Equals("processed"))
            {
                btnSave.Visible = false;
                txtAccountNumber.Text = "You cannot add Processed Account";
                txtAccountNumber.Enabled = false;
            }
            else
            {
                btnSave.Visible = true;
                txtAccountNumber.Text = string.Empty; ;
                txtAccountNumber.Enabled = true;
            }
            lblTerminatedAccounts.Text = "Terminated Accouts " + "<span style='color:  	#E00000 ;'>" + ddlRenewalDate.SelectedValue + "</span>";
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = Data.Terminated_accounts(ddlRenewalDate.SelectedValue);
            
        }

        protected void RadGrid1_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
     
            GridDataItem item = (GridDataItem)e.Item;
            string record_id = item.GetDataKeyValue("record_id").ToString();
            string accountName = string.Empty;
            string accountnumber = string.Empty;
            DataTable tbl = (DataTable)RadGrid1.DataSource;

            foreach (DataRow dr in tbl.Rows)
            {
                if (dr["record_id"].ToString().Equals(record_id))
                {
                    accountName = dr["Account Name"].ToString();
                    accountnumber = dr["Account No"].ToString();
                    break;
                }
            }
            //accountName = accountName +"\\n D = "+record_id;
            tbl.Rows[e.Item.ItemIndex]["record_id"].ToString();
            string strmsg = "'Are you sure you want to remove Account " + accountnumber + " / " + accountName + " '";

            lblScript.Text = "<Script>check(" + strmsg + "," + record_id + ");</script>";

            
        }

        protected void lnkbtnExport_Click(object sender, EventArgs e)
        {
            RadGrid1.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), "Html");
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.MasterTableView.ExportToExcel();
        }
        
    }
}