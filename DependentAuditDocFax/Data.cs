using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace DependentAuditDocFax
{
    public class Data
    {
        public static string Get_er_property_accnt(string account_number, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
        }

        public static string is_employee_in_Dep_Audit(string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependent_Audit_Wizard.is_employee_in_Dep_Audit", "number", al).ToString();
        }

        public static string newFaxDocRecordID(string dependent_no_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_no_", "in", "number", dependent_no_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependents_Audit.newFaxDocRecordID", "varchar2", al).ToString();
        }

        public static DataTable getblob(string session_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", string.Empty));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependents_audit.getblob", al);
        }

    }
}