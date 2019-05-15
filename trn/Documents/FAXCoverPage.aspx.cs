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

namespace Documents
{
    public partial class FAXCoverPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PLADocFax.Report1 report = new PLADocFax.Report1();
            report.Process(Request.Params["id"]);
            ReportViewer1.Report = report;          
        }

        protected void btnBaxk_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", true);
        }
    }
}
