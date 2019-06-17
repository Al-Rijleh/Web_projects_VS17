using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0011172_0000_000_Portland
{
    public partial class PayrollDecation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string session_id = Request.Cookies["Session_ID"].Value.ToString();
                ViewState["EENumber"] = SQLStatic.Sessions.GetEmployeeNumber(session_id);
                ViewState["PY"] = SQLStatic.Sessions.GetSessionValue(session_id, "PROCESSING_YEAR");

            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = Data.PortlandPayrollDeduction(ViewState["EENumber"].ToString(), ViewState["PY"].ToString());
        }
    }
}