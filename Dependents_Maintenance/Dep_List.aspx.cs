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

namespace Dependents_Maintenance
{
    public partial class Dep_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DrawGrid();
        }

        protected void DrawGrid ()
        {
            DataTable tbl = Data.GetDependentsList("120165","0");
            RadGrid1.DataSource = tbl;
            RadGrid1.DataBind();
        }

    }
}
