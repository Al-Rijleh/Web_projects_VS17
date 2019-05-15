using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace ViewPageOverlay
{
    public class Data
    {
        public static string page_has_overalay(string session_id_, string page_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("page_id_", "in", "varchar2", page_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_web_2.page_has_overalay", "number", ar).ToString();
        }

        public static string UrlFromPageId(string page_id)
        {
            string strSQL = "select t.url from met_internet_pages t where page_id=" + page_id;
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static string overalay_page(string page_id_, string scheme_id_, string propeerty_id_)
        {
            ArrayList ar = new ArrayList(2);            
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("page_id_", "in", "varchar2", page_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("scheme_id_", "in", "varchar2", scheme_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("propeerty_id_", "in", "varchar2", propeerty_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_schemes.get_screenvalue", "varchar2", ar).ToString();
        }

        public static string overalay_pagenot540(string session_id_, string page_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("page_id_", "in", "varchar2", page_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_web_2.overalay_page", "varchar2", ar).ToString();
        }

        public static void Viewed_overalay(string session_id_, string page_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("page_id_", "in", "varchar2", page_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_web_2.Viewed_overalay", ar);
        }

        public static void Viewed_overalay(string session_id_, string page_id_, string URL_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("page_id_", "in", "varchar2", page_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("URL_", "in", "varchar2", URL_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_web_2.Viewed_overalay", ar);
        }
    }
}