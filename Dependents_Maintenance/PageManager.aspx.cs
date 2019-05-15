using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dependents_Maintenance
{
    public partial class PageManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strAccount = SQLStatic.Sessions.GetAccountNumber(Request.Cookies["Session_ID"].Value.ToString());
            if (strAccount.StartsWith("0000699"))
                Response.Redirect("Default.aspx?SkipCheck=YES&stay=1", true);
            else
                Response.Redirect("DefaultOld.aspx?SkipCheck=YES", true);
        }
    }
}