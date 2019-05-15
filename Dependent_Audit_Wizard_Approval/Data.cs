using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace Dependent_Audit_Wizard_Approval
{
//Packages Used
//pkg_Billing_Display
//pkg_Dependent_Audit_Wizard
//pkg_Dependents_Audit
//pkg_enrollment_wizard
//pkg_enrollment_wizard_setup

    public class Data
    {
        public static byte[] Get_Location_Billing_PDF_rec(string session_id, string record_id)
        {
            string sql = "select pkg_Billing_Display.Get_Location_Billing_PDF_rec('" + session_id + "'," + record_id + ") from dual";
            object ob = SQLStatic.SQL.ExecScaler(sql);

            byte[] retResult = (byte[])ob;
            return retResult;
        }

        public static byte[] Get_Dependent_PDF_rec(string Dependent_No_)
        {
            string sql = "select pkg_Dependent_Audit_Wizard.Get_Dependent_PDF_rec(" + Dependent_No_ + ") from dual";
            object ob = SQLStatic.SQL.ExecScaler(sql);

            byte[] retResult = (byte[])ob;
            return retResult;
        }


        public static byte[] Get_PDF_rec(string record_id)
        {
            string sql = "select pkg_Dependent_Audit_Wizard.Get_PDF_rec(" + record_id + ") from dual";
            object ob = SQLStatic.SQL.ExecScaler(sql);

            byte[] retResult = (byte[])ob;
            return retResult;
        }
        

        public static DataTable AccountsList()
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.AccountsList", ar);
        }

        public static DataTable EmployeesList(string account_number_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.EmployeesList", ar);
        }

        public static DataTable Get_Approval_Dep_Listing(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.Get_Approval_Dep_Listing", al);
        }

        public static DataTable Get_Approval_Dep_Listing_sty_2(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.Get_Approval_Dep_Listing_sty_2", al);
        }

        public static DataTable Get_Dependent_Data(string dependent_no_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_no_", "in", "number", dependent_no_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.Get_Dependent_Data", al);

        }

        public static DataTable Get_Dep_Doc_List(string strEmployeeNumber, string strDepend_number)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depend_number_", "in", "number", strDepend_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.Get_Dep_Doc_List", al);
        }

        public static void Approve_Dependent(string session_id, string strDepend_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_number_", "in", "number", strDepend_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.Approve_Dependent", al);
        }

        public static void DisApprove_Dependent(string session_id, string strDepend_number, string reason)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_number_", "in", "number", strDepend_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("reason_", "in", "varchar2", reason));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.DisApprove_Dependent", al);
        }

        public static DataTable DeclineResons()
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.DeclineResons", ar);
        }

        public static DataTable RequestResons()
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.RequestResons", ar);
        }

        public static void Approve_doc(string session_id, string r_log_id_, string log_user_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("r_log_id_", "in", "number", r_log_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("log_user_id_", "in", "varchar2", log_user_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.Approve_doc", al);
        }

        public static void DisApprove_doc(string session_id, string r_log_id_, string log_user_id, string reason)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("r_log_id_", "in", "number", r_log_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("log_user_id_", "in", "varchar2", log_user_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("reason_", "in", "varchar2", reason));            
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.DisApprove_doc", al);
        }

        public static DataTable FaxDepReportInformation(string Dependent_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Dependent_number_", "in", "number", Dependent_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.FaxDepReportInformation", al);
        }

        public static void Request_info_doc(string employee_number_, string account_number_, string log_user_name_, string r_log_id_,
           string reason_, string doc_name_, byte[] bValue)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_Dependent_Audit_Wizard.Request_info_doc",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", employee_number_);

            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "account_number_", account_number_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "log_user_name_", log_user_name_);
           

            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "r_log_id_", r_log_id_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "reason_", reason_); 
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
                SQLStatic.SQL.CloseConnection(conn);
                cmd.Dispose();
            }
        }

        public static string PendingDependentCount(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependent_Audit_Wizard.PendingDependentCount", "number", al).ToString();

        }

        public static string FirstDependent(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependent_Audit_Wizard.FirstDependent", "number", al).ToString();

        }

        public static void Add_Reason(string grouping_, string description_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("grouping_", "in", "number", grouping_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("description_", "in", "varchar2", description_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.Add_Reason", al);
        }

        public static DataTable Get_Dep_Doc_List_sty_2(string strEmployeeNumber, string strDepend_number)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depend_number_", "in", "number", strDepend_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.Get_Dep_Doc_List_sty_2", al);
        }

        public static DataTable Get_Dependent_Data_sty_2(string dependent_no_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_no_", "in", "number", dependent_no_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.Get_Dependent_Data_sty_2", al);

        }

        public static void Request_info_doc_sty_2(string employee_number_, string log_user_id_, string request_dep_id_, string reason_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("log_user_id_", "in", "varchar2", log_user_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("request_dep_id_", "in", "varchar2", request_dep_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("reason_", "in", "varchar2", reason_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.Request_info_doc_sty_2", al);
        }

        public static void move_out_of_pending_sty_2(string session_id,string employee_number_, string strRecordID, string strUserName, string send_email)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_email_", "in", "varchar2", send_email));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.move_out_of_pending_sty_2", al);
        }

        public static void Deney_pending_Dep_sty_2(string session_id, string employee_number_, string strRecordID, string strUserName,
            string reason_,string send_email)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("reason_", "in", "varchar2", reason_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_email_", "in", "varchar2", send_email));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.Deney_pending_Dep_sty_2", al);
        }

        public static string remaining_depend_count(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependent_Audit_Wizard.remaining_depend_count", "number", al).ToString();

        }

        //-------------------Approve Depent Audit
        public static DataTable Pending_Master_Accounts(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Master_Accounts", al);

        }
        
        
        public static DataTable Pending_Dependents()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Dependents", al);            
        }

        public static DataTable Pending_Dependents(string account_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Dependents", al);
        }

        public static DataTable pending_dependents560(string seesion_id_, string account_number_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("seesion_id_", "in", "varchar2", seesion_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.pending_dependents560", al);
        }


        public static DataTable processed_dependents560(string seesion_id_, string account_number_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("seesion_id_", "in", "varchar2", seesion_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.processed_dependents560", al);
        }

        public static DataTable GetDependents(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.GetDependents", al);
        }

        public static DataTable GetDependentsForStatus(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.GetDependentsForStatus", al);
        }

        public static DataTable GetDepDocuments(string Dependents)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Dependents", "in", "varchar2", Dependents));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.GetDepDocuments", al);
        }

        public static void Approve_Documnent(string seesion_id, string Doc_record_id_,string Doc_Count_in_PDF_, string user_name_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("seesion_id", "in", "varchar2", seesion_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Doc_record_id_", "in", "number", Doc_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Doc_Count_in_PDF_", "in", "number", Doc_Count_in_PDF_));            
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependents_Audit.Approve_Documnent", al);
        }

        public static void Decline_Documnent(string Doc_record_id_,string reason_, string user_name_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Doc_record_id_", "in", "number", Doc_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("reason_", "in", "varchar2", reason_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependents_Audit.Decline_Documnent", al);
        }

        public static void Require_Info(string Doc_record_id_, string reason_, string user_name_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Doc_record_id_", "in", "number", Doc_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("reason_", "in", "varchar2", reason_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependents_Audit.Require_Info", al);
        }

        public static DataTable DepNameFromDocID(string doc_reciid_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("doc_reciid_", "in", "number", doc_reciid_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.DepNameFromDocID", al);
        }

        public static string ExistDocumentCount(string DepNum_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DepNum_", "in", "number", DepNum_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependents_Audit.ExistDocumentCount", "number", al).ToString();
        }


        public static string IsEEReadyForApproval(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependents_Audit.IsEEReadyForApproval", "number", al).ToString();
        }

        public static void Apporve_employee(string employee_number_, string user_name_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependents_Audit.Apporve_employee", al);
        }

        public static string ee_Email(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependents_Audit.ee_Email", "varchar2", al).ToString();
        }

        public static DataTable Pending_Dependents_No_doc()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Dependents_No_doc", al);
        }

        public static DataTable Pending_Dependents_No_doc(string account_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.Pending_Dependents_No_doc", al);
        }

        public static string PendCvrgNHOE(string session_id, string account_number_)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_code_", "in", "varchar2", null));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.PendCvrgNHOE", "number", al).ToString();
        }

        public static void Approve_Documnent_Dependent(string session_id_, string Doc_record_id_, string Doc_Count_in_PDF_, string user_name_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Doc_record_id_", "in", "number", Doc_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Doc_Count_in_PDF_", "in", "number", Doc_Count_in_PDF_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependents_Audit.Approve_Documnent_Dependent", al);
        }

        public static string approve_depndent_only(string employee_number_, string account_number_)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependents_Audit.approve_depndent_only", "number", al).ToString();
        }

        public static string FinalizedMessageNHOE(string session_id, string account_number_, string employee_number_, string processing_year_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.FinalizedMessageNHOE", "number", al).ToString();
        }

        public static string is_allow_EE_Releae(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.is_allow_EE_Releae", "number", al).ToString();
        }

        public static void relese_All_Dep_verified(string session_id, string account_number_, string employee_number_, string processing_year_, string user_name_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.relese_All_Dep_verified", al);
        }

        public static DataTable DocumentStatus(string record_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.DocumentStatus", al);
        }

        public static string Get_er_property_accnt(string account_number, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
        }

        public static DataTable DocumentStatusForStatus(string record_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.DocumentStatusForStatus", al);
        }

        public static void ModifyDependentStatu(string DepNu_, string Student_, string Disable_, string user_name_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DepNu_", "in", "varchar2", DepNu_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Student_", "in", "varchar2", Student_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Disable_", "in", "varchar2", Disable_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependents_Audit.ModifyDependentStatu", al);
        }

        public static string GetRequiredReasonText(string doc_record_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("doc_record_id_", "in", "number", doc_record_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents_audit.GetRequiredReasonText", "varchar2", al).ToString();
        }

        public static string ViewOnlyFDICSependentApproval(string Session_id_, string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents_audit.ViewOnlyFDICSependentApproval", "varchar2", al).ToString();
        }

        public static string Dependent_Name(string employee_number_,string Dependents)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Dependents", "in", "number", Dependents));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Dependents_Audit.Dependent_Name", "varchar2", al).ToString();
        }

    }
}