using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HSA_Inf
{
    public partial class CommingSoon : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();    
            if (!IsPostBack)
            {
                iBeneficiaries.Attributes["src"] = "/Web_Projects/BeneficiaryNew/BeneficiaryHome.aspx?SkipCheck=YES";
                iBeneficiaries.Visible = true;
            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(session_id, "HSACateCode", "");
            SQLStatic.Sessions.SetSessionValue(session_id, "HSACatePlan", "");

            lblScript.Text = "<script language='javascript' type='text/javascript'>"+"javascript:htmbtnColse_onclick()"+"</script>";

        }

        
    }
}