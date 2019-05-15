using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PLA_Report
{
    public partial class ShowAllRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["eenum"]))
                  SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "eenu", Request.Params["eenum"]);
            }
            string eeno = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "eenu");
            DataTable tbl = Data.Get_HeaderRequest(eeno);
            foreach (DataRow dr in tbl.Rows)
            {
                if (string.IsNullOrEmpty(Request.Params["hedID"]))
                    Response.Redirect("/web_projects/trn/PLA_Report/Training_Request_Summary.aspx?hedID=" + dr["record_id"].ToString(), true);

                else if(!Request.Params["hedID"].Equals(dr["record_id"].ToString()))
                    if (Convert.ToInt32( Request.Params["hedID"])> Convert.ToInt32( dr["record_id"].ToString()))
                        Response.Redirect("/web_projects/trn/PLA_Report/Training_Request_Summary.aspx?hedID=" + dr["record_id"].ToString(), true);                
            }
        }
    }
}