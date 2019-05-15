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

namespace EnrollmentApproval
{
    public class Data
    {
        public static DataTable Pending_Employee_Cvrg(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_","out","cursor",null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.pending_employee_cvrg",al);
        }

        public static DataTable GetPendingCvrgs(String employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.GetPendingCvrgs", al);
        }

        public static DataTable GetPendingDepCvrgs(string session_id, string cvrg_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.GetPendingDepCvrgs", al);
        }

        public static DataTable GetPendingDepCvrgsForEE(string session_id, string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.GetPendingDepCvrgsForEE", al);
        }

        public static bool hasPendingDepCvrgs(string session_id, string cvrg_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", cvrg_id));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.hasPendingDepCvrgs", "number", al).ToString().Equals("0");
        }

        public static DataTable Get_Pending_Dep_list(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.Get_Pending_Dep_list2", al);
        }

        public static DataTable GetPendingDependents(string session_id, String employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.get_dependents_for_ee", al);
        }

        public static void SaveStausCoverage(string Session_id_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.savestatuscoverage", al, conn);
        }

        public static void SaveLifeCoverage(string Session_id_,Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.SaveLifeCoverage", al,conn);
        }

        public static void ProcessPendCoverages(string session_id, string cvrg_group_id, string status,Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("status_", "in", "varchar2", status));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.ProcessPendCoverages", al,conn);
        }

        public static void SaveEffectiveDate(string strRecID, string strEffectiveDate, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "varchar2", strEffectiveDate));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.update_effective_date", al, conn);
        }

        public static void MoveOutOfPending(string session_id, string strRecordID, string strUserName, string send_email)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecordID));            
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_email_", "in", "varchar2", send_email));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.move_out_of_pending", al);
        }

        public static void Deney_pending_Dep(string session_id, string strRecordID, string strUserName, string send_email)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_email_", "in", "varchar2", send_email));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.Deney_pending_Dep", al);
        }

        public static void CheckEnrollmentType(string session_id, string cvrg_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "number", cvrg_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.CheckEnrollmentType", al).ToString();
        }

        public static void ProcessDependentCoverages(string Session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.processDependentCoverages", al);
        }

        public static bool HasMorePendingCvrg(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.GetPendingCvrgCount", "number", al).ToString().Equals("0");
        }

        public static void process_dependents(string session_id, string cvrg_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrgid_", "in", "varchar2", cvrg_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.process_dependents", al);
        }

        public static DataTable ee_detail(string session_id, string employee_number)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.ee_detail", al);
        }

        public static DataTable GetPendingProfileEEList(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.GetPendingProfileEEList", al);
        }

        public static DataTable get_modified_profile(string session_id, string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.Get_Modified_Profile", al);
        }

        public static DataTable get_modified_address(string session_id, string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.get_modified_address", al);
        }

        public static bool HasMorePendingProfileAddress(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.GetPendingProfile_address", "number", al).ToString().Equals("0");
        }

        public static void processes_profile_address(string employee_number, string user_name)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.processes_profile_address", al);
        }

        public static void update_marital_status(string employee_number,string marital_status_description, string user_name)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("marital_status_description_", "in", "varchar2", marital_status_description));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.update_marital_status", al);
        }

        public static void update_DOB(string employee_number, string DOB, string user_name)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DOB", "in", "varchar2", DOB));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.update_DOB", al);
        }

        public static string employee_email(string employee_number_)
        {
            return SQLStatic.SQL.ExecScaler("select a.work_email from eeaddress a where employee_number="+employee_number_).ToString();
        }

        public static void send_Dep_email(string employee_number, string email_address, string subject,
            string message, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("email_address_", "in", "varchar2", email_address));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("subject_", "in", "varchar2", subject));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("message_", "in", "clob", message));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.send_Dep_email", al,conn);
        }

        public static DataTable GetDepedenApprovalEmail(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.GetDepedenApprovalEmail", al);
        }


        public static void SaveCoverage(string session_id, string record_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.SaveCoverage", al);
        }

        public static void DeclineCoverage(string session_id, string record_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.DeclineCoverage", al);
        }

        public static DataTable EE_Reuire_Approval(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.EE_Reuire_Approval", al);
            foreach (DataRow dr in tbl.Rows)
            {
                if ((dr["profile"].ToString().Contains("xcancel")) &&
                    (dr["Dependent"].ToString().Contains("xcancel")) &&
                    (dr["Coverage"].ToString().Contains("xcancel")))
                {
                    dr.Delete();
                }

            }
            tbl.AcceptChanges();
            return tbl;
        }

        public static DataTable EE_Reuire_Approval_Program_Typ(string session_id, string program_type_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("program_type_", "in", "varchar2", program_type_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_approvals.EE_Reuire_Approval_Program_Typ", al);
        }

        public static void Close_pending_ee_profile_addrs(string session_id, string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_approvals.Close_pending_ee_profile_addrs", al);
        }

        public static string PeningCoverageLongDespription(string recotd_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("recotd_id_", "in", "varchar2", recotd_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.PeningCoverageLongDespription", "varchar2", al).ToString();
        }


        public static bool Has_Pend_Dep_cvrg_count(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.Get_Pend_Dep_cvrg_count", "number", al).ToString().Equals("0");
        }

        public static string PeningCoverageFamilyStatus(string recotd_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("recotd_id_", "in", "varchar2", recotd_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.PeningCoverageFamilyStatus", "varchar2", al).ToString();
        }

        public static bool HasMorePendingDep(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_approvals.GetPendingDepCount", "number", al).ToString().Equals("0");
        }

        public static string requires_dep_verify(string employee_number_)
        {
            string strSQL = "select pkg_dependent_audit_wizard.requires_dep_verify(" + employee_number_ + ")from dual";
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static DataTable ProgramTypeList()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_rates_components.ProgramTypeList", al);
        }


        public static DataTable MasterAccountsList(string program_type_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("program_type_", "in", "varchar2", program_type_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_rates_components.MasterAccountsList", al);
        }

        public static DataTable AccountsList(string masteraccount)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("masteraccount", "in", "varchar2", masteraccount));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_rates_components.AccountsList", al);
        }

        public static DataTable PendingEmployeeList(string session_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.PendingEmployeeList", al);
        }

        
    }
}
