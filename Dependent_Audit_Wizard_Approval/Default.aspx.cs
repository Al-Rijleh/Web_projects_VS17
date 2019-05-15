using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dependent_Audit_Wizard_Approval
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPDF();
        }

        private void ShowPDF()
        {
            PdfViewer1.LicenseKey = "QGtyYHF3YHNzd2BzbnBgc3FucXJueXl5eQ==";
            byte[] bValue = Data.Get_Location_Billing_PDF_rec(Request.Cookies["Session_ID"].Value.ToString(), "4723079");
            PdfViewer1.PdfSourceBytes = bValue;
            PdfViewer1.DataBind();
            PdfViewer1.Visible = true;

        }
    }
}