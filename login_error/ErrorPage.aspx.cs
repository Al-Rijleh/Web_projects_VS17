using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace login_error
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            processes();
        }

        private void processes()
        {
            string strError = Request.Params["error"];
            if (strError.StartsWith("!!!Page="))
            {
                string url = strError.Replace("!!!Page=", string.Empty);
                Response.Redirect(UrlFromPageId(url), true);
                return;
            }

            try
            {
                string[] ar = strError.Split('!');
                string strurl = ar[1];
                string strSession = ar[2];
                filldata(strurl, strSession);
            }
            catch
            {
                dvfull.Visible = false;
                lblError.Text = strError;
            }
        }

        private string UrlFromPageId(string url)
        {
            string strSQL = "select t.url from met_internet_pages t where page_id=" + url;
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        private void filldata(string strurl, string strSession)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", strSession));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("url", "in", "varchar2", strurl));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_bas_security.Login_error_values", al);
            if (tbl.Rows.Count.Equals(0))
                return;
            lblProgramName.Text = tbl.Rows[0]["program_name"].ToString();
            lblDateTime.Text = tbl.Rows[0]["date_time"].ToString();
            lblUser.Text = tbl.Rows[0]["User_"].ToString();
            lblUserType.Text = tbl.Rows[0]["user_type"].ToString();
            lblInstruction.Text = lblInstruction.Text.Replace("[Email Address]", tbl.Rows[0]["email"].ToString());
        }
    }
}