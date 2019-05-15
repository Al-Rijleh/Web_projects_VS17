using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewPageOverlay
{
    public partial class Default : System.Web.UI.Page
    {
        string session_ = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_ = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {
                string strPageeId = SQLStatic.Sessions.GetSessionValue(session_, "OVERLAYPAGE");
                
                ViewState["strPageeId"] = strPageeId;
                if (Data.page_has_overalay(session_, strPageeId).Equals("0"))
                {
                    string strURL = Data.UrlFromPageId(strPageeId);
                    Response.Redirect(strURL, true);
                    return;
                }
                string image = string.Empty;
                if (strPageeId.Equals("540"))
                    image = Data.overalay_page(strPageeId, "2", "66");
                else
                    image = Data.overalay_pagenot540(session_, strPageeId);
                ViewState["image"] = image;
                lblType.Text = lblType.Text.Replace("[top]", "255");
                string []  twoImages  = image.Split('~');
                FullPage.Style.Add("background-image",twoImages[0]);
                imgGotit.ImageUrl = twoImages[1];
            }
        }
        

        protected void imgGotit_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["strPageeId"].ToString().Equals("540"))
                Data.Viewed_overalay(session_, ViewState["strPageeId"].ToString());
            else
                Data.Viewed_overalay(session_, ViewState["strPageeId"].ToString(), ViewState["image"].ToString());

            string strURL = Data.UrlFromPageId(ViewState["strPageeId"].ToString());
            Response.Redirect(strURL + "?SkipCheck=YES", true);
        }
    }
}