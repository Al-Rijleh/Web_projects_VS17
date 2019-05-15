using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Automated_Rate_Update
{
    public partial class NewRateType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tbl = Data.Get_Rate_Method();
                rblRateType.DataSource = tbl;
                rblRateType.DataTextField = "title";
                rblRateType.DataValueField = "record_id";
                rblRateType.DataBind();
                rblRateType.Items.FindByValue(Request.Params["ratetype"]).Enabled = false;
                lblTitle.Text += Request.Params["cvrg"];
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string strParam = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = "?accnt=" + Request.Params["accnt"] +
                              "&ip=" + Request.Params["batch"].Substring(0, 4) +
                              "&py=" + Request.Params["py"].Substring(0, 4);
            else
                strParam = "?id=" + Request.Params["id"];

            Response.Redirect("Default_2.aspx" + strParam, true);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string strParam = "?accnt=" + Request.Params["accnt"] +
                              "&ver=" +Request.Params["ver"] +
                              "&class=" + Request.Params["class"] +
                              "&catcode=" +Request.Params["catcode"] +
                              "&catplan=" + Request.Params["catplan"] +
                              "&py=" + Request.Params["py"] +
                              "&batch=" + Request.Params["batch"] +                                                        
                              "&action=1"+
                              "&id=" + Request.Params["id"]; 
            if (rblRateType.SelectedValue.Equals("1"))
            {
                strParam += "&ratetype=" + rblRateType.SelectedValue+
                            "&cvrg=" + Server.HtmlEncode(Request.Params["cvrg"]);

                Response.Redirect("StatusRate.aspx" + strParam, true);
            }
            else if (rblRateType.SelectedValue.Equals("0"))
            {
                strParam += "&ratetype=" + rblRateType.SelectedValue +
                            "&cvrg=" + Server.HtmlEncode(Request.Params["cvrg"]);
                Response.Redirect("DoubleAgeRate.aspx" + strParam, true);
            }
            else if (rblRateType.SelectedValue.Equals("2"))
            {
                strParam += "&ratetype=" + rblRateType.SelectedValue +
                            "&cvrg=" + Server.HtmlEncode(Request.Params["cvrg"]); 
                Response.Redirect("FamilyAgeRate.aspx" + strParam, true);
            }

        }
    }
}