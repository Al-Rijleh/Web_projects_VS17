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

namespace Documents
{
    public partial class ShowFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Params["id"]))
                ShowImage();
            else
                ShowImage2();
        }

        private void ShowImage()
        {
            try
            {
                byte[] image = SQLStatic.Sessions.GetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Image");
                string strLength = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Image_Length");
                string strType = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Image_Type");
                int intLength = Convert.ToInt32(strLength);
                this.EnableViewState = false;
                Response.Clear();
                Response.ContentType = strType;
                Response.OutputStream.Write(image, 0, intLength);
                Response.Flush();
                Response.End();
            }
            catch
            {
                lblScript.Visible = true;
                lblScript.Text = @"<p><b><font face='Arial' size='2' color='#FF0000'>
<span style='background-color: #FFFF00'>Image Not Found</span></font></b></p>";
            }
        }

        private void ShowImage2()
        {
            DataTable tbl = Data.GetDocumentImage(Request.Params["id"]);
            this.EnableViewState = false;
            Response.Clear();
            Response.ContentType = tbl.Rows[0][0].ToString().ToLower();
            int intLength = Convert.ToInt32(tbl.Rows[0][1].ToString());
            Response.OutputStream.Write((byte[])tbl.Rows[0][2], 0, intLength);
            Response.Flush();
            Response.End();
        }
    }
}
