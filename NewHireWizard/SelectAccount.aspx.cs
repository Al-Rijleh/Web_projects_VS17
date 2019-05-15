using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewHireWizard
{
    public partial class SelectAccount : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            string ser_Group = SQLStatic.Sessions.GetUserGroupID(session_id);
            lblSelectedaaccount.Text = SQLStatic.Sessions.GetAccountNumber(session_id);
            if (!string.IsNullOrEmpty(lblSelectedaaccount.Text))
                lblSelectedaaccount.Text =   SQLStatic.AccountData.AccountName(lblSelectedaaccount.Text) +"   "+ lblSelectedaaccount.Text;
            string user_Group = SQLStatic.Sessions.GetUserGroupID(session_id);
            btnGo.Enabled = !lblSelectedaaccount.Text.EndsWith("0000424-0000-000");
            if (ser_Group.Equals("2"))
            {
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    SQLStatic.Sessions.SetSessionValue(session_id, "NH_EMPLOYEE_NUMBER", "0", conn);
                    SQLStatic.Sessions.SetSessionValue(session_id, "2NDTITLE", "", conn);
                    Data.Clear_Session_Data(session_id, conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                Response.Redirect("Account_Division_Class_PaySchedule.aspx", true);                
            }
            else if (ser_Group.Equals("4"))
            {
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    SQLStatic.Sessions.SetSessionValue(session_id, "NH_EMPLOYEE_NUMBER", "0", conn);
                    SQLStatic.Sessions.SetSessionValue(session_id, "2NDTITLE", "", conn);
                    Data.Clear_Session_Data(session_id, conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                
            }
            else
            {
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    SQLStatic.Sessions.SetSessionValue(session_id, "NH_EMPLOYEE_NUMBER", "0", conn);
                    SQLStatic.Sessions.SetSessionValue(session_id, "2NDTITLE", "", conn);
                    Data.Clear_Session_Data(session_id, conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }                
                
            }
        }

        protected void btnSelectAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/account_number/Default.aspx?SkipCheck=YES&goto=/web_projects/NewHireWizard/SelectAccount.aspx?addhis=1");
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account_Division_Class_PaySchedule.aspx?old-1", true);
        }
    }
}