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

namespace NewHireWizard
{
    public partial class PendClasses : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            btnClose.Attributes.Add("onclick", "closeWindow(1);");
            ShowPeningClasaes();
        }

        private void ShowPeningClasaes()
        {
            DataTable tbl = Data.PendedClasses(session_id);
            lblClasses.Text = "<ul>";
            foreach (DataRow dr in tbl.Rows)
            {
                lblClasses.Text += "<li>" + dr["description"].ToString() + "</li>";
            }
            lblClasses.Text += "</ul>";
        }

    }
}
