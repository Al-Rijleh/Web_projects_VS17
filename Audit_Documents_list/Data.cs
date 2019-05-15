using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

namespace Audit_Documents_list
{
    public class Data
    {
        public static DataTable GetEEDocuments(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.GetEEDocuments", al);
        }

        public static DataTable Pending_Master_AccountsForList(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Master_AccountsForList", al);

        }

        public static DataTable pending_dependents560(string seesion_id_, string account_number_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("seesion_id_", "in", "varchar2", seesion_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.pending_dependents560", al);
        }

        public static DataTable Pending_Dependents_List(string session_id_,string account_number_,string days_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("days_", "in", "varchar2", days_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Dependents_List", al);
        }

        public static DataTable Pending_Dependents()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Dependents", al);
        }

        public static string Get_er_property_accnt(string account_number, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
        }

        public static DataTable Pending_AccountsForList(string session_id_, string master_accont_, string days_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("master_accont_", "in", "varchar2", master_accont_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("days_", "in", "varchar2", days_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_AccountsForList", al);
        }
    }
}