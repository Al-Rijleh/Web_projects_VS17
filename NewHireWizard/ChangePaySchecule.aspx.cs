using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewHireWizard
{
    public partial class ChangePaySchecule : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            btnClose.Attributes.Add("onclick", "closeWindow(1);");
            if (!IsPostBack)
            {
                FillData();
            }
        }

        private void FillData()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                string strExistingCode = SQLStatic.Sessions.GetSessionValue(session_id, "PAYCODE", conn);
                DataTable tbl = Data.GetPayListSchedule(session_id,conn);
                rblPayPeriods.DataSource = tbl;
                rblPayPeriods.DataTextField = "pay_period_description";
                rblPayPeriods.DataValueField = "pay_period_code";
                rblPayPeriods.DataBind();
                try
                {
                    if (!string.IsNullOrEmpty(strExistingCode))
                        rblPayPeriods.Items.FindByValue(strExistingCode).Selected = true;
                }
                catch { }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            if (SQLStatic.Sessions.GetAccountNumber(session_id).StartsWith("0006123"))
            {
                rblPayPeriods.Items.FindByValue("2").Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "PAYCODE",rblPayPeriods.SelectedValue, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "PAYDESCRIPTION", rblPayPeriods.SelectedItem.Text, conn);                
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            string StrExit = "<script>closeWindow(4);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "StrExit", StrExit);
        }
    }
}
