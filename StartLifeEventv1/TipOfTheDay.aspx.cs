using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StartLifeEventv1
{
    public partial class TipOfTheDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateoneDiv(1, "uyduhuqe uwe UICultureuwj");
        }

        protected void CreateoneDiv(int id,string txt)
        {
            lblMessage.Text = " <div class='TipDivWidth ' >" + txt + "</div>";
        }
    }
}