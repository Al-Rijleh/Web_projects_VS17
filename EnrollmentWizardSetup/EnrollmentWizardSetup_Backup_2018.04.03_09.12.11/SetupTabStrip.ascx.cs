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

namespace EnrollmentWizardSetup
{
    public partial class SetupTabStrip : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProcessingYear.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PROCESSING_YEAR");
        }

        public void SetTabIndex(int id)
        {
            RadTabStrip1.SelectedIndex = id;
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            Response.Redirect(e.Tab.Value); 
        }

        protected void btnSelectAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/Account_Number/Default.aspx?SkipCheck=YES&goto=/web_projects/EnrollmentWizardSetup/Welcome.aspx?SkipCheck=YES", true);
        }
    }
}