using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckLifeEvent
{
    public partial class Default : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {
                dvMain.Visible = false;
                checkOpen();
            }
        }

        private void checkOpen()
        {
            string strEmployee = SQLStatic.Sessions.GetEmployeeNumber(session_id);
            string strPy = SQLStatic.EmployeeData.Current_Processing_Year(strEmployee);
            string strSQL = "select pkg_enrollment_wizard_special.is_NH_SPC("+strEmployee+","+strPy+") from dual";
            string strResult = SQLStatic.SQL.ExecScaler(strSQL).ToString();
            if (strResult.Equals("1"))
                dvMain.Visible = true;
            else
                Response.Redirect("/WEB_PROJECTS/ENROLLMENTWIZARD/LE_START.ASPX?SkipCheck=YES", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/request_bar_code_claim/Service_Request_Entry_Screen.aspx?noCancel=Y", true);
        }
    }
}