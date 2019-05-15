using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Automated_Rate_Update
{
    public partial class Default3 : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try { session_id = Request.Cookies["Session_ID"].Value.ToString(); }
                catch { session_id = string.Empty; }
                if (!string.IsNullOrEmpty(session_id))
                {
                    string userGroup = SQLStatic.Sessions.GetUserGroupID(session_id);
                    if (!userGroup.Equals("1"))
                    {
                        session_id = string.Empty;
                    }
                }
                if (ViewState["accnt"] == null)
                {
                    if (!string.IsNullOrEmpty(session_id))
                        GetParametersBas();
                    else
                        GetParameters(Request.Params["id"]);
                }
            }
            GetClassCodes();
        }

        private void GetClassCodes()
        {
           
        }

        private void GetParametersBas()
        {
            ViewState["accnt"] = SQLStatic.Sessions.GetAccountNumber(session_id);
            ViewState["email"] = SQLStatic.Sessions.GetUserName(session_id);
            ViewState["user_id"] = SQLStatic.Sessions.GetUserName(session_id);
            ViewState["batch"] = SQLStatic.Sessions.GetSessionValue(session_id, "batchid");
            ViewState["py"] = SQLStatic.Sessions.GetSessionValue(session_id, "processing_year");
            ViewState["renewal"] = ViewState["batch"].ToString().Substring(0, 5);
            //btnReset.Visible = true;
        }

        private void GetParameters(string param)
        {
            //btnReset.Visible = false;
            DataTable tbl = Data.get_parameters(param);
            if (tbl.Rows.Count.Equals(0))
            {
                throw new Exception(param + " was not found");
            }
            hidId.Value = param;            
            ViewState["accnt"] = tbl.Rows[0]["account_number"].ToString();
            ViewState["email"] = tbl.Rows[0]["email"].ToString();
            ViewState["user_id"] = tbl.Rows[0]["user_name_"].ToString();
            ViewState["batch"] = tbl.Rows[0]["batch_id"].ToString();
            ViewState["py"] = tbl.Rows[0]["processing_year"].ToString();
            ViewState["renewal"] = tbl.Rows[0]["rate_renewal"].ToString();
        }
        
    }
}