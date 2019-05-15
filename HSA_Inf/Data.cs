using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections;
namespace HSA_Inf
{
    public class Data
    {
        public static bool SessionHasTimeOut(string strSessionId)
        {
            string strSQL = "select pkg_sessions_data.validate_session_2('" + strSessionId + "') from dual";
            return
                SQLStatic.SQL.ExecScaler(strSQL).ToString() == "0";
        }

        public static string Have_HSA(string session_id_, string account_number_, string category_code, string category_plan)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.Have_HSA", "varchar2", al).ToString();
        }

        public static DataTable HSA_Employee_Employer_Info(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_HSA_Information.HSA_Employee_Employer_Info", al);
        }

        public static string HSA_Beneficiary_Information(string id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("id_", "in", "varchar2", id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.HSA_Beneficiary_Information", "varchar2", al).ToString();
        }

        public static DataTable HSA_Information(string id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("id_", "in", "varchar2", id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_HSA_Information.HSA_Information", al);
        }

        public static DataTable HSA_Values(string session_id_, string employee_number_, string Processing_year_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Processing_year_", "in", "varchar2", Processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_HSA_Information.HSA_Values", al);
        }

        public static void SaveStatusCoverage(string Session_id_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.SaveStatusCoverage", al,conn);
        }

        public static void SaveStatusCoverage(string Session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.SaveStatusCoverage", al);
        }


        public static void SaveSPNCoverage(string Session_id_, string er_electiion_amount_, string ee_electiion_amount_, 
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("er_electiion_amount_", "in", "varchar2", er_electiion_amount_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_electiion_amount_", "in", "varchar2", ee_electiion_amount_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_2.SaveSPNCoverage", al,conn);
        }

        public static string Create_New_EE(string session_id_, string employee_number_, string user_name_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.Create_New_EE","varchar2", al).ToString();
        }


        public static void save_one_control(string session_id_, string employee_number_, string RecIDfromHDR_, string control_name_, string control_value_,
            string user_name_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("RecIDfromHDR_", "in", "varchar2", RecIDfromHDR_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("control_name_", "in", "varchar2", control_name_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("control_value_", "in", "varchar2", control_value_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_HSA_Information.save_one_control", al, conn);
        }

        public static DataTable Get_Answers(string session_id_, string employee_number_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_HSA_Information.Get_Answers",al);
        }

        public static string Has_Beneficiaries(string session_id_, string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.Has_Beneficiaries", "varchar2", al).ToString();
        }

        public static string Good_Password(string user_id_, string password_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("password_", "in", "varchar2", password_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.Good_Password", "varchar2", al).ToString();
        }

        public static string EE_Has_HSA(string session_id_, string employee_number_, string processing_year_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.EE_Has_HSA", "varchar2", al).ToString();
        }


        public static void saveHSANammount(string Session_id_, string er_electiion_amount_, string ee_electiion_amount_, string from_oe_,
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("er_electiion_amount_", "in", "varchar2", er_electiion_amount_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_electiion_amount_", "in", "varchar2", ee_electiion_amount_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("from_oe_", "in", "varchar2", from_oe_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_HSA_Information.saveHSANammount", al, conn);
        }

        public static void SaveAccountNumber(string account_number_, string employee_number_,string bankccoumt_,string user_name_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("bankccoumt_", "in", "varchar2", bankccoumt_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_HSA_Information.SaveAccountNumber",  al);
        }

        public static string GetSPN_HSA(string session_id_, string employee_number_, string processing_year_, string category_code_, string category_plan_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.GetSPN_HSA", "varchar2", al).ToString();
        }


        public static DataTable HSA_constatnts(string account_number_, string fs_,string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("fs_", "in", "varchar2", fs_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_HSA_Information.HSA_constatnts", al);
        }

        public static void SaveSPN_HSA(string session_id_, string employee_number_, string processing_year_, string category_code_, string category_plan_,
            string ee_electiion_amount_, string er_electiion_amount_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_electiion_amount_", "in", "varchar2", ee_electiion_amount_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("er_electiion_amount_", "in", "varchar2", er_electiion_amount_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_HSA_Information.SaveSPN_HSA", al,conn);
        }

        public static string CanAddEditHSAacct(string session_id_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_HSA_Information.CanAddEditHSAacct", "varchar2", al).ToString();
        }

    }
}