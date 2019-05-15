using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Automated_Rate_Update
{
    public partial class GenerateReports : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {
                if (is_inital())
                {
                    RadTabStrip1.Tabs[3].Selected = true;
                    lblTitle.Text = "Generate Initial Emails Report";
                }
                else
                {
                    RadTabStrip1.Tabs[2].Selected = true;
                    lblTitle.Text = "Generate Reminder Emails Report";
                }
                ViewState["user_name"] = SQLStatic.Sessions.GetUserName(session_id);
            }

        }

        private bool is_inital()
        {
            if (string.IsNullOrEmpty(Request.Params["inital"]))
                return false;
            else
                return true;
        }

        protected void ddlRenewalDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlRenewalDate.SelectedValue.Equals("Select"))
            {
                if (is_inital())
                    btnSendEmails.Text = "Click here to generate Inital emails Report for Renewal Date " + ddlRenewalDate.SelectedValue + "/01";
                else
                    btnSendEmails.Text = "Click here to generate Reminder emails Report for Renewal Date " + ddlRenewalDate.SelectedValue + "/01";
                btnSendEmails.Visible = true;
            }
            else
                btnSendEmails.Visible = false;
        }

        protected void btnSendEmails_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                if (is_inital())
                    RadGrid1.DataSource = Data.WillReciveInital(ddlRenewalDate.SelectedValue);
                else
                    RadGrid1.DataSource = Data.WillReciveReminder(ddlRenewalDate.SelectedValue);
                RadGrid1.DataBind();
                tx.Rollback();
            }
            catch
            {
                tx.Rollback();
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
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