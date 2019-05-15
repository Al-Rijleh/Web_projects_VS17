using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Collections;

namespace ReusableRadTab
{
    public partial class Tab : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ClearTabs()
        {
            tabstrip.Tabs.Clear();
        }

        public void BuildTabs(string procedure_Name)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", Request.Cookies["Session_ID"].Value.ToString()));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "Cursor",null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure(procedure_Name, ar);
            foreach (DataRow dr in tbl.Rows)
            {
                AddTab(dr["name"].ToString(), dr["url"].ToString());
            }
            tbl.Dispose();
        }

        public void AddTab(string strName, string strURL)
        {
            RadTab tab = new RadTab(strName);
            tab.Target = strURL;
            tabstrip.Tabs.Add(tab);
        }

        public void SetTab(string URL)
        {
            foreach (RadTab tab in tabstrip.Tabs)
            {
                //if (!URL.ToUpper().IndexOf(tab.Target.ToUpper()).Equals(-1))
                if (URL.ToUpper().Equals(tab.Target.ToUpper()))
                {
                    tab.Selected = true;
                    break;
                }
            }
        }

        protected void tabstrip_TabClick(object sender, RadTabStripEventArgs e)
        {
            Response.Redirect(e.Tab.Target, true);
        }
    }
}