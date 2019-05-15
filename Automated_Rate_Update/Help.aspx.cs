using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automated_Rate_Update
{
    public partial class Help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHelp.Text = Data.GetHelpText();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string strParam = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = "?accnt=" + Request.Params["accnt"] + "&ip=" + Request.Params["ip"] + "&py=" + Request.Params["py"];
            else
                strParam = "?id=" + Request.Params["id"];
            Response.Redirect("Default4.aspx" + strParam, true);
        }
    }
}