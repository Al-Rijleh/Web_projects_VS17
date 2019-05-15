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
using Telerik.Web.UI;

namespace EnrollmentWizardSetup
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            GetText();
        }

        private void GetText()
        {
            RadEditor RadEditor1 = Bas_Utility.Utilities.GetRadEditor(Page, "RadEditor1");
            RadEditor1.Content = Data.GetText(session_id, "1");
        }
    }
}
