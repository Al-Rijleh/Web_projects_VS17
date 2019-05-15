using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLAViewFax
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PLADocFax.Report1 report = new PLADocFax.Report1();
            report.Process(Request.Params["id"]);
            ReportViewer1.Report = report;     
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/trn/Documents/Default.aspx");
        }
    }
}