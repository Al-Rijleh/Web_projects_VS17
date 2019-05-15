using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StartLifeEventv1
{
    public partial class ManageDocs : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();

            if (!string.IsNullOrEmpty(hidRemove.Value))
            {
                Data.Remove_Document(session_id, hidRemove.Value);
                hidRemove.Value = string.Empty;
                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable tbl = Data.uploaded_Fax_Doc_Cursor(SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID"));
            RadGrid1.DataSource = tbl;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            string strCallCloseWindow = "<script>closeWindow('" + SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID") + "')</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }
    }
}