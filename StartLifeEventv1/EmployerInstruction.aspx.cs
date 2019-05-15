using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StartLifeEventv1
{
    public partial class EmployerInstruction : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (string.IsNullOrEmpty( Request.Params["ack"]))
                lblInstruction.Text = Data.Get_message(Request.Cookies["Session_ID"].Value.ToString(), "5");
            else
            {
                string Py = SQLStatic.Sessions.GetSessionValue(session_id, "PROCESSING_YEAR");
                DataTable tbl = Data.Get_ER_Setup(session_id, SQLStatic.Sessions.GetAccountNumber(session_id), Py, DateTime.Today.ToShortDateString());
                lblInstruction.Text = tbl.Rows[0]["certification_text"].ToString().Replace("\n", "<br>");
                tbl.Dispose();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            string strCallCloseWindow = "<script>closeWindow()</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }
    }
}