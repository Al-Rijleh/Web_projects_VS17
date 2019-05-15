using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace DependentsAuditGetDocuments
{
    public class Data
    {
        public static DataTable DepRequiringVerifications(string employee_number_, string category_code_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependents_audit.deprequiringverifications", al);
        }



        public static void SavePDF(string account_number_, string employee_number_, string dependent_sequence_no_, string user_name_,
            string doc_name_, byte[] bValue)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_dependents_audit.save_Verify_Doc_upload", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "account_number_", account_number_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", employee_number_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "dependent_sequence_no_", dependent_sequence_no_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", user_name_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "doc_name_", doc_name_);

            Oracle.DataAccess.Client.OracleParameter parm;
            parm = new Oracle.DataAccess.Client.OracleParameter(
                    "value_", Oracle.DataAccess.Client.OracleDbType.Blob, bValue.Length, System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, bValue);
            cmd.Parameters.Add(parm);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Clone();
                conn.Dispose();
            }
        }

        public static DataTable GetDocuments(string dependent_sequence_no_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", dependent_sequence_no_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependents_audit.GetDocuments", al);
        }


        public static DataTable GetDocumentsNonReta(string dependent_sequence_no_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", dependent_sequence_no_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependents_audit.GetDocumentsNonReta", al);
        }


        public static void RemoveDocument(string record_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_dependent_audit_wizard.RemoveDocument", al);
        }

        public static string RequiredSubmissionDate(string employee_number_, string processing_year_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents_audit.RequiredSubmissionDate", "varchar2", al).ToString();
        }

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

        public static DataTable uploadedFaxes(string dependent_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_number_", "in", "varchar2", dependent_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("RetResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependents_audit.uploadedFaxes", al);
        }

        public static string showuploadedFaxes(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents_audit.showuploadedFaxes", "number", al).ToString();
        }

        public static void RemoveFax(string record_id_, string user_name_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_dependents_audit.RemoveFax", al);
        }


    }
}