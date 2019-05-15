using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dependent_Audit_Wizard_Approval
{
    public partial class Viewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowImage();
        }

        private void ShowImage()
        {
            //byte[] bValue = Data.Get_Location_Billing_PDF_rec(Request.Cookies["Session_ID"].Value.ToString(), Request.Params["recid"]);
            byte[] bValue = Data.Get_Location_Billing_PDF_rec(Request.Cookies["Session_ID"].Value.ToString(), "4723079");
            int intLength = 0;
            intLength = bValue.Length;
            if (intLength.Equals(0))
            {
                lblNoData.Text = "Could not find billing record " + Request.Params["recid"];
                return;
            }
            this.EnableViewState = false;
            string filename = "Aetna 2012 PPO 80 60 $750 Ded $15 Copay $2000 oop ADSA SOB.pdf";
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename= " + filename);
            Response.ContentType = "application/pdf";
            Response.OutputStream.Write(bValue, 0, intLength);
            Response.Flush();
            Response.End();
        }
    }
}