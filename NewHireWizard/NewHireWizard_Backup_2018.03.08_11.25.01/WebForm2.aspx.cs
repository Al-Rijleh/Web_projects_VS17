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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rgClassCodesList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["Account_Number"] = "0000699-0001-000";
            string strClass_code = "I";
            Label1.Text = SQLStatic.AccountData.ClassDescription(ViewState["Account_Number"].ToString(),
                SQLStatic.AccountData.Current_Processing_Year(ViewState["Account_Number"].ToString()),
                strClass_code);
        }
    }
}
