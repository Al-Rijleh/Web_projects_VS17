using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Automated_Rate_Update
{
    public partial class PendingCcvrgs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            if (!string.IsNullOrEmpty(hidcmd.Value))
            {
                Data.remove(hidcmd.Value);
                DrawGrid();
                hidcmd.Value = string.Empty;
                return;
            }
            DrawGrid();
        }

        private void DrawGrid()
        {
            gvCoverages.DataSource = Data.GetPendingCoverages(SQLStatic.Sessions.GetAccountNumber(Request.Cookies["Session_ID"].Value.ToString()), Request.Params["py"], Request.Params["batch"]);
            gvCoverages.DataBind();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            string strClose = "<script>Javascript:closeWindow(1);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
        }

        protected void gvCoverages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "cvr_exist")) == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.LightSalmon;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }                


            }
        }

    }
}