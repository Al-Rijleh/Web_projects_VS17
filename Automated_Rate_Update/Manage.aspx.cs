using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automated_Rate_Update
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEffectiveDate.Text = Request.Params["efDare"];
            }
        }

        protected void btnMakechange_Click(object sender, EventArgs e)
        {
            string Param = "?accnt=" + Request.Params["accnt"].ToString() +
                        "&ver=" + Request.Params["ver"] +
                        "&class=" + Request.Params["class"].ToString() +
                        "&catcode=" + Request.Params["catcode"].ToString() +
                        "&catplan=" + Request.Params["catplan"].ToString() +
                        "&py=" + Request.Params["py"].ToString() +
                        "&batch=" + Request.Params["batch"].ToString() +
                        "&cvrg=" + Request.Params["cvrg"].ToString() +
                        "&ratetype=" + Request.Params["ratetype"].ToString() +
                        "&action=0" +
                        "&id=" + Request.Params["id"];
            if (rblAction.SelectedValue.Equals("same"))
            {
                if (Request.Params["ratetype"].ToString().Equals("0"))
                {
                    //lblScript.Text = "<script type='text/javascript'>alert('here');" +
                    //    "document.location.href = 'DoubleAgeRate.aspx'" + Param +
                    //    "</script>";

                    //string strparam = "'" + Param + "'";
                    //strparam = "<script type='text/javascript'>GoDouble(" + strparam + ")  </script>";
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strparam", strparam);

                    string strparam = "'DoubleAgeRate.aspx',"+ "'" + Param + "'";
                    strparam = "<script type='text/javascript'>run(" + strparam + ")  </script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strparam", strparam);
                }
                else if (Request.Params["ratetype"].ToString().Equals("1"))
                {
                    //lblScript.Text = "<script type='text/javascript'>alert('here');" +
                    //    "document.location.href = 'StatusRate.aspx'" + Param +
                    //    "</script>";

                    //string strparam = "'" + Param + "'";
                    //strparam = "<script type='text/javascript'>GoDouble(" + strparam + ")  </script>";
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strparam", strparam);

                    string strparam = "'DoubleAgeRate.aspx'," + "'" + Param + "'";
                    strparam = "<script type='text/javascript'>run(" + strparam + ")  </script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strparam", strparam);
                }
            }
            else if (rblAction.SelectedValue.Equals("remove"))
            {
                string strRemove = "'" + ViewState["cvrg_name"].ToString() + "'";
                strRemove = "<script type='text/javascript'>remove(" + strRemove + ")  </script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRemove", strRemove);

                // lblScript.Text = "<script type='text/javascript'>remove(" + strRemove + ")  </script>";                
            }
            else if (rblAction.SelectedValue.Equals("change"))
            {
                //Param = Param.Replace("&action=0", "&action=1");
                Response.Redirect("NewRateType.aspx" + Param);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}