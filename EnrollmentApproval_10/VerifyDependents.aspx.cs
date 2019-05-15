using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnrollmentApproval
{
    public partial class VerifyDependents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("DEFAULT.ASPX?SkipCheck=YES&Verify=1");
        }
    }
}