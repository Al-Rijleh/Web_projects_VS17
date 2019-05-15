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

namespace Employee_Search
{
    public class Data
    {
        public static DataTable GetSearchList(string strSession_id, string strSearchFor, string strSearchLevel, Oracle.DataAccess.Client.OracleConnection conn)
        { 
            ArrayList ar = new ArrayList(4);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", strSession_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_for_", "in", "varchar2", strSearchFor));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_level_", "in", "varchar2", strSearchLevel));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_search.search_employee", ar, conn);

        }

        public static bool CallCenterUser(string strUsserID)
        {
            return SQLStatic.SQL.ExecScaler("select  pkg_employee_3.user_has_role(" + strUsserID + ",115) from dual").ToString() != "0";
        }

        public static bool Is_COBRA(string Account_number, string processing_year)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", Account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employer.is_cobra_account_s", "varchar2", ar).ToString().Equals('T');
        }

        public static string ee_class_code(string employee_number, string processing_year, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_class_code.ee_class_code", "varchar2", ar, conn).ToString();
        }

        public static string EE_Current_Processing_Year(string employee_number, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee.EE_Current_Processing_Year", "number", ar, conn).ToString();
        }

        public static string EE_Current_Processing_Year(string employee_number)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee.EE_Current_Processing_Year", "number", ar).ToString();
        }

        public static DataTable search_employee_pc(string strSession_id, string strSearchFor, string strSearchLevel,string product_code, 
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(5);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", strSession_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_for_", "in", "varchar2", strSearchFor));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_level_", "in", "varchar2", strSearchLevel));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("product_code_", "in", "varchar2", product_code));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_search.search_employee_pc", ar, conn);
        }


        public static DataTable search_Employee_pc_2(string strSession_id, string strSearchFor, string strSearchLevel, 
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(5);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", strSession_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_for_", "in", "varchar2", strSearchFor));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_level_", "in", "varchar2", strSearchLevel));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_search.search_Employee_PC_2", ar, conn);
        }

        public static DataTable Get_Detail(string session_, int record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_", "in", "varchar2", session_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", record_id.ToString()));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_search.get_detail", ar);
        }

        public static void setup_rocessing_year_class(string session_, string employee_number_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_", "in", "varchar2", session_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_search.setup_rocessing_year_class", ar);
        }

        public static DataTable GetSearchList(string user_id_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("searchfor_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_account_search.search_accounts_admin", ar);

        }

        public static DataTable GetClassListByUser(string user_id_)
        {
            ArrayList ar = new ArrayList(3);            
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_class_code.GetClassListByUser", ar);
        }

        public static DataTable search_Employee_new(string strSession_id, string strSearchFor, string strSearchLevel,
            string account_number_, string class_code_, string Eligibility_)
        {
            ArrayList ar = new ArrayList(6);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", strSession_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_for_", "in", "varchar2", strSearchFor));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("search_level_", "in", "varchar2", strSearchLevel));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("Eligibility_", "in", "varchar2", Eligibility_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_search.search_Employee_new", ar);
        }

        public static DataTable get_Instruction_for_search(string page_id_, string scheme_id_,string property_id_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("page_id_", "in", "varchar2", page_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("scheme_id_", "in", "varchar2", scheme_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("property_id_", "in", "varchar2", property_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("PKG_SCHEMES.get_Instruction_for_search", ar);
        }

        public static void add_laat_search_contols(string user_id_, string status_, string account_, string class_,string eligible_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("status_", "in", "varchar2", status_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_", "in", "varchar2", account_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("class_", "in", "varchar2", class_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("eligible_", "in", "varchar2", eligible_));  
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_search.add_laat_search_contols", ar);
        }

        public static string get_laat_search_contols(string user_id_)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "number", user_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_search.get_laat_search_contols", "varchar2", ar).ToString();
        }

        public static void add_last_selected_ee(string user_id_, string employee_number_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_search.add_last_selected_ee", ar);
        }

        public static DataTable Get_last_selected_ee(string user_id_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_search.Get_last_selected_ee", ar);
        }

        public static string toolbarbtnEEName(string session_)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_", "in", "varchar2", session_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_schemes.Employee_name", "varchar2", ar).ToString();
        }

        public static string HasEnrollment(string session_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_", "in", "varchar2", session_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_web_2.HasEnrollment", "varchar2", al).ToString();
        }

    }
}