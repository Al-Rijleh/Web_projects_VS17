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

namespace BenefitStatement
{
    public class Data
    {

        public static DataTable Header_Info(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.header_info", al);
        }

        public static string GetText(string session_id, string cd_enrollwiz_record_id)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_enrollment_wizard.get_message('" + session_id + "'," + cd_enrollwiz_record_id + ")from dual").ToString();
            //ArrayList al = new ArrayList(2);
            //al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            //al.Add(SQLStatic.StoredProcedure.OneParamerer("cd_enrollwiz_record_id_", "in", "number", cd_enrollwiz_record_id));
            //return SQLStatic.StoredProcedure.ExecuteFunction("enrollment_wizard.get_message","clob", al).ToString();
        }

        public static string BenefitStatemaneText(string account_number)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_enrollment_wizard_3.benefitstatemanetext('"+account_number+"')from dual").ToString();
        }

        public static DataTable Pages_List(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.get_pages_list", al);
        }

        public static void Set_Step_Completed(string session_id, string step_name)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("step_name_", "in", "varchar2", step_name));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.Set_Step_Completed", al);
        }

        public static DataTable MritalStatus()
        {
            ArrayList al = new ArrayList();
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.get_cdmaritalstatus", al);
        }

        public static DataTable States()
        {
            ArrayList al = new ArrayList();
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_home_web.States_List", al);
        }

        public static DataTable Personal_Information(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.Personal_information", al);
        }

        public static DataTable GetDependentsList(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard.Get_Dependent_ListingFull", al);
            return tbl;
        }

        public static DataTable Get_Pending_Dependents(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard.Get_Pending_Dependents", al);
            return tbl;
        }

        public static DataTable GetDependentsListActive(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard.Get_Dep_Listing_Full_Active", al);
            return tbl;
        }

        // From Dependent Maintenance
        public static string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];

        public static string EEActionLevel(string session_id_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            return SQLStatic.SQL.ExecScaler(
                "select pkg_employee_maintenance.eelevelaction('" + session_id_ + "') from dual", conn).ToString();
        }

        public static string Current_Action(string session_id)
        {
            //string strAction = SQLStatic.SQL.ExecScaler("select pkg_add_update_benefit.get_current_action('" + session_id + "') from dual").ToString();
            string strAction = SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE");
            if (strAction == "A")
                strAction = "O";
            return strAction;
        }

        public static string Show_Declara_Form_Send_Processess(string strEmployeeNumber)
        {
            return SQLStatic.SQL.ExecScaler("Select pkg_employee_maintenance.show_declara_form_send_process(" + strEmployeeNumber + ") from dual)").ToString();
        }

        public static bool Employee_has_Email(string strEmployeeNumber, Oracle.DataAccess.Client.OracleConnection conn)
        {
            return SQLStatic.SQL.ExecScaler("Select pkg_employee_3.employee_email_work(" + strEmployeeNumber + ") from dual)", conn).ToString() != "";
        }

        public static DataTable Get_Declation_Document_Location(string strEmployeeNumber, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.get_declation_document_loc", al, conn);
            return tbl;
        }

        public static DataTable GetDependentsInfoFromID(string stRecordID, string strDepID)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", stRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_number_", "in", "number", strDepID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Dependent_Info_From_ID", al);
            return tbl;
        }

        public static DataTable GetDependentsAddress(string stRecordID, string strDepID)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "number", stRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_number_", "in", "number", strDepID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Dependent_Address", al);
            return tbl;
        }

        public static DataTable GetRelationships(string strRmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strRmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Relationship_List", al);
            return tbl;
        }

        public static DataTable GetTermReason(string strSessionID)
        {
            ArrayList al = new ArrayList();
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", strSessionID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Termination_Reason", al);
            return tbl;
        }

        public static string SaveDependents(string strRecordID, string strEmployeeNumber, string strDependentNumber, string strProcessingYear, string strLastName, string strFirstName, string strMI, string strRelation,
            string strSSN, string strDOB, string strEffectiveDate, string strSex, string strStudent, string strHandicapped, string strSchool, string strGradDate,
            string strIsOpenEnrollmanr, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            if (strRecordID == "-1")
                al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", null));
            else
                al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", strDependentNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("last_name_", "in", "varchar2", strLastName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("first_name_", "in", "varchar2", strFirstName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("middle_initial_", "in", "varchar2", strMI));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relationship_code_", "in", "varchar2", strRelation));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("social_security_number_", "in", "varchar2", strSSN));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("birth_date_", "in", "varchar2", strDOB));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "varchar2", strEffectiveDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("sex_", "in", "varchar2", strSex));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("full_time_student_", "in", "varchar2", strStudent));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("handicapped_", "in", "varchar2", strHandicapped));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("school_name_", "in", "varchar2", strSchool));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("graduation_date_", "in", "varchar2", strGradDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("is_open_enrollment_", "in", "number", strIsOpenEnrollmanr));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("return_record_id", "out", "varchar2", null));
            ArrayList alRet = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Dependent2", al, conn);
            string strReturn = alRet[0].ToString();
            return strReturn.ToLower().Replace("return_record_id=", "");
        }

        public static void SaveDependentsLimited(string strRecordID, string strEmployeeNumber, string strDependentNumber, string strProcessingYear,
            string strSSN, string strDOB, string strSchool, string strGradDate,
            string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            if (strRecordID == "-1")
                al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", null));
            else
                al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", strDependentNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("social_security_number_", "in", "varchar2", strSSN));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("birth_date_", "in", "varchar2", strDOB));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("school_name_", "in", "varchar2", strSchool));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("graduation_date_", "in", "varchar2", strGradDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_DependentLimited", al, conn);
        }



        public static void SaveDependentsAddress(string strEmployeeNumber, string strDependentNumber, string strAddress1, string strAddress2, string strCity, string strState, string strZipCode,
            string strHomePhone, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", strDependentNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address_line_1_", "in", "varchar2", strAddress1));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address_line_2_", "in", "varchar2", strAddress2));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("city_", "in", "varchar2", strCity));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("state_", "in", "varchar2", strState));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("zipcode_", "in", "varchar2", strZipCode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("home_phone_", "in", "varchar2", strHomePhone));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Dependent_Address", al, conn);
        }

        public static void SaveDependentAddressByEE(string strEmployeeNumber, string strDependentNumber, string strAddress1, string strAddress2, string strCity, string strState, string strZipCode,
            string strHomePhone, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", strDependentNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address_line_1_", "in", "varchar2", strAddress1));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address_line_2_", "in", "varchar2", strAddress2));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("city_", "in", "varchar2", strCity));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("state_", "in", "varchar2", strState));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("zipcode_", "in", "varchar2", strZipCode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("home_phone_", "in", "varchar2", strHomePhone));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Dependent_Address", al, conn);
        }

        public static void SaveRequestDependentsAddress(string strEmployeeNumber, string strRequestID, string strAddress1, string strAddress2, string strCity, string strState, string strZipCode,
            string strHomePhone, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("request_record_id_", "in", "varchar2", strRequestID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address_line_1_", "in", "varchar2", strAddress1));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address_line_2_", "in", "varchar2", strAddress2));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("city_", "in", "varchar2", strCity));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("state_", "in", "varchar2", strState));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("zipcode_", "in", "varchar2", strZipCode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("home_phone_", "in", "varchar2", strHomePhone));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Dependent_Address_Pending", al, conn);
        }

        public static void MoveToPending(string strEmployeeNumber, string strDependentNumber, string strProcessingYear, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dep_no_", "in", "varchar2", strDependentNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.move_to_pending", al, conn);
        }

        public static void MoveOutOfPending(string strRecordID, string strProcessingYear, string strApproveDate, string strClassCode, string strUserName)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DocRecvDate", "in", "varchar2", strApproveDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.move_out_of_pending", al);
        }

        public static void Terminate_Dependent(string strRecordID, string strTermDate, string strReason, string strUserName)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_date_", "in", "varchar2", strTermDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_reason_code_", "in", "varchar2", strReason));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("result_", "out", "varchar2", " "));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Terminate_Dependent", al);
        }

        public static void Terminate_Request_Dependent(string strRecordID, string strEmployeeNumber, string strprocessingYear, string strTermDate, string strReason, string strUserName)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strprocessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_date_", "in", "varchar2", strTermDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_reason_code_", "in", "varchar2", strReason));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("result_", "out", "varchar2", " "));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Terminate_Request_Dependent", al);
        }


        public static string Declaration_Form_Send_Process(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "varchar2", ""));
            ArrayList ab = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Get_Declarat_Form_Send_Process", al);
            return ab[0].ToString().Replace("retResult_=", "");
        }
        public static void Save_Employee_Email(string strEmployeeNumber, string strEmail, string strUserName)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("work_email_", "in", "varchar2", strEmail));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.save_employee_email", al);
        }

        public static void Save_Employee_Viewed_Doc(string strEmployeeNumber, string strUserName, byte[] buffer)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_employee_maintenance.Save_Employee_Viewed_Doc", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", strEmployeeNumber);
            Oracle.DataAccess.Client.OracleParameter parm;
            parm = new Oracle.DataAccess.Client.OracleParameter(
                    "ViewedFile_", Oracle.DataAccess.Client.OracleDbType.Blob, buffer.Length, System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, buffer);
            cmd.Parameters.Add(parm);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", strUserName);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public static void Send_Email_Doc(string strEmployeeNumber, string strProccessingYear, string strUserName, byte[] buffer)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_employee_maintenance.Send_Email_Doc", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", strEmployeeNumber);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_", strProccessingYear);
            Oracle.DataAccess.Client.OracleParameter parm;
            parm = new Oracle.DataAccess.Client.OracleParameter(
                    "ViewedFile_", Oracle.DataAccess.Client.OracleDbType.Blob, buffer.Length, System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, buffer);
            cmd.Parameters.Add(parm);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", strUserName);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public static void Send_Email_Doc_Retiree(string strEmployeeNumber, string strProccessingYear, string strUserName, byte[] buffer)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_employee_maintenance.Send_Email_Doc_Retiress", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", strEmployeeNumber);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_", strProccessingYear);
            Oracle.DataAccess.Client.OracleParameter parm;
            parm = new Oracle.DataAccess.Client.OracleParameter(
                    "ViewedFile_", Oracle.DataAccess.Client.OracleDbType.Blob, buffer.Length, System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, buffer);
            cmd.Parameters.Add(parm);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", strUserName);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public static bool ShowCoveragePage(string strEmployeeNumber, string strProcessingYear)
        {
            return SQLStatic.SQL.ExecScaler("select  pkg_employee_maintenance.show_coverage_window(" + strEmployeeNumber + "," + strProcessingYear + ") from dual").ToString() != "0";
        }

        public static DataTable GetEleigibleCoverages(string strEmployeeNumber, string strProcessingYear, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Eleigible_Coverages", al, conn);
            return tbl;
        }

        public static DataTable GetFamilyStatus(string strCvrgID, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", strCvrgID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.get_fs_used_for_Dom_Parnt", al, conn);
            return tbl;
        }

        public static void SaveCoverage(string strCvrgID, string strEmployeeNumber, string strReqstID, string strFamilyStatus, string strEffectiveDate, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", strCvrgID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("request_record_id_", "in", "varchar2", strReqstID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_", "in", "varchar2", strFamilyStatus));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "varchar2", strEffectiveDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Request_Coverage", al, conn);
        }

        public static string GetEffectiveDate(string strSession, string strCatCode, string strCatPlan)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.get_open_enroll_effectivedate('" + strSession + "', '" + strCatCode + "', '" + strCatPlan + "') from dual;").ToString();

        }

        public static bool DependentIsActive(string strEmployeeNumber, string Dependent_D)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.dependent_in_eedepenents_(" + strEmployeeNumber + "," + Dependent_D + ") from dual;").ToString() == "1";
        }

        public static void ReactivateDependent(string strRecordID, string stEffectiveDate, string strUserName)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "varchar2", stEffectiveDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.reactivate_dependents", al);
        }

        public static void ReactivatePendingDependent(string strRecordID, string stEffectiveDate, string strUserName)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "varchar2", stEffectiveDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.reactivate_request_dependent", al);
        }

        public static bool SkipRetiree(String strEemployeeNumber, string UserName)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.skipretiree(" + strEemployeeNumber + ",'" + UserName + "') from dual").ToString() == "1";
        }

        public static string NextPayDate(string strEmployeeNumber)
        {
            return SQLStatic.SQL.ExecScaler("select TO_CHAR(pkg_employee_2.next_pay_date(" + strEmployeeNumber + ",sysdate),'MM/DD/YYYY') from dual").ToString();
        }

        public static string BeginOfNextYear(string strAccountNumber_)
        {
            return SQLStatic.SQL.ExecScaler("select  TO_CHAR(max(t.begin_date),'MM/DD/YYYY') from erprocessingyears t where account_number='" + strAccountNumber_ + "'").ToString();
        }

        public static string LastDayInCurrentYear(string strAccountNumber_)
        {
            string strBeginOfNextYear = BeginOfNextYear(strAccountNumber_);
            DateTime dt = Convert.ToDateTime(strBeginOfNextYear).AddDays(-1);
            return dt.ToString("MM/dd/yyyy");
        }

        public static string DependentName(string session_id_)
        {
            return SQLStatic.SQL.ExecScaler("select  pkg_employee_maintenance.dependent_name('" + session_id_ + "') from dual").ToString();
        }

        public static bool CanAddDOMPartner(string session_id)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.canadddompartner('" + session_id + "') from dual").ToString() == "1";
        }

        public static DataTable GetCoverages(string session_id, string group_id)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("group_id_", "in", "varchar2", group_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.ee_group_detail_full", al);
        }

        public static DataTable GetCoveragesLife(string session_id, string group_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("group_id_", "in", "varchar2", group_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.ee_group_detail_full_lif", al, conn);
        }


        public static void Save_Personal_Information(string session_id_, string first_name_, string middle_initial_, string last_name_, string birth_date_,
                    string gender_, string marital_status_, string address1_, string address2_, string city_, string state_, string zip_code_,
                    string phone_number_, string mobile_number_, string fax_number_, string work_email_, string office_number_,
                    string personal_email_, string work_phone_ext_)
        {
            ArrayList al = new ArrayList(18);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("first_name_", "in", "varchar2", first_name_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("middle_initial_", "in", "varchar2", middle_initial_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("last_name_", "in", "varchar2", last_name_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("birth_date_", "in", "varchar2", birth_date_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("gender_", "in", "varchar2", gender_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("marital_status_", "in", "varchar2", marital_status_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address1_", "in", "varchar2", address1_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address2_", "in", "varchar2", address2_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("city_", "in", "varchar2", city_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("state_", "in", "varchar2", state_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("zip_code_", "in", "varchar2", zip_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("phone_number_", "in", "varchar2", phone_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("mobile_number_", "in", "varchar2", mobile_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("fax_number_", "in", "varchar2", fax_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("work_email_", "in", "varchar2", work_email_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("office_number_", "in", "varchar2", office_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("personal_email_", "in", "varchar2", personal_email_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("work_phone_ext_", "in", "varchar2", work_phone_ext_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.Save_Personal_Information", al);
        }

        public static string Class_Effective_Date(string session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.ee_class_effective_date", "varchar2", al).ToString();
        }

        public static DataTable OptionalBenefits(string session_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_3.current_ee_coverages_session", al);

            //return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.ee_optionalbenefits", al);
        }

        public static DataTable Dependent_CVRGS(string session_id_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.depndents_covered", al, conn);
        }

        public static string ChildsCount(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.childcount", "number", al).ToString();
        }

        public static string DependentsCount(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.dependentcount", "number", al).ToString();
        }

        public static DataTable GetEligableDependents(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr_dependents_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.get_eligable_dependents", al);
        }

        public static DataTable GetEligableDependents2(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr_dependents_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.get_eligable_dependents2", al);
        }

        public static string GetEligableDependentsCount(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.get_eligable_dependents_count", "number", al).ToString();
        }

        public static void SaveStatusCoverage(string Session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.SaveStatusCoverage", al);
        }


        public static void ProcessDependentCoverages(string Session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.processDependentCoverages", al);
        }


        public static void SaveLifeCoverage(string Session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.SaveLifeCoverage", al);
        }

        public static string UserName(string logUserID)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("log_user_id_", "in", "varchar2", logUserID));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_3.employee_namr_from_log_user_id", "varchar2", al).ToString();
        }

        public static void Finalize(string Session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", Session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.Finalize", al);
        }

        public static bool DependentsCoverageEligible(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.dependentscoverageeligible", "number", al).ToString().Equals("1");
        }

        public static DataTable Multipler_List(string session_id, string category_code, string category_plan, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.Multipler_List", al, conn);
        }

        public static string CurrentCoverageName(string session_id, string cvrg_group_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.currentCoverageName", "varchar2", al, conn).ToString();
        }

        public static string PendingCoverageName(string session_id, string cvrg_group_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.PendingCoverageName", "varchar2", al, conn).ToString();
        }

        public static string PendingLifeCoverageName(string session_id, string cvrg_group_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.PendingLifeCoverageName", "varchar2", al, conn).ToString();
        }

        public static DataTable GetLifeCoverages(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.getlifecoverages", al);
        }

        public static DataTable GetCDBeneficiaryRelations()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.GetCDBeneficiaryRelations", al);
        }

        public static void SaveBeneficiary(string session_id, string cvrg_id, string first_name, string mi, string last_name, string DOB, string relation,
            string percentage, string type, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(9);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_cvrg_id_", "in", "number", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("first_name_", "in", "varchar2", first_name));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("MI_", "in", "varchar2", mi));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("last_name_", "in", "varchar2", last_name));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DOB_", "in", "Date", DOB));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relation_", "in", "varchar2", relation));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("percentage_", "in", "varchar2", percentage));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("type_", "in", "varchar2", type));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.saveBeneficiary", al, conn);
        }

        public static DataTable GetBeneficiary(string session_id, string cvrg_id, string type)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_cvrg_id_", "in", "number", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("type_", "in", "varchar2", type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.GetBeneficiary", al);
        }

        public static void DeleteBeneficiary(string session_id, string cvrg_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_cvrg_id_", "in", "number", cvrg_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.DeleteBeneficiary", al, conn);
        }

        public static void DeleteBeneficiary(string session_id, string cvrg_id, string type, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_cvrg_id_", "in", "number", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("type_", "in", "varchar2", type));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.DeleteBeneficiary", al, conn);
        }

        public static string GetShowCost(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.GetShowCost", "varchar2", al).ToString();
        }

        public static void SetOpenEnrollment(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.SetOpenEnrollment", al, conn);
        }

        public static string Enrollment_type(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Enrollment_type", "varchar2", al, conn).ToString();
        }

        public static string DependentEligibility()
        {
            string strSQL = "select description from bas_system where code='DependentEligibility'";
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static string Employee_Gender(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Employee_Gender", "varchar2", al).ToString();
        }

        public static string CountSelectedCvrgInGroup(string employee_number, string grp_rec_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("grp_rec_id_", "in", "varchar2", grp_rec_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.CountSelectedCvrgInGroup", "varchar2", al).ToString();
        }

        public static string Personal_information_message(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Personal_information_message", "varchar2", al).ToString();
        }

        public static DataTable Get_pended_Profile_Data(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.Get_pended_Profile_Data", al);
        }

        public static DataTable Get_pended_address_Data(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.Get_pended_address_Data", al);
        }

        public static void Delete_Pending_profile(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard.Delete_Pending_profile", al);
        }

        public static bool ShouldPend(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.ShouldPend", "varchar2", al).ToString().Equals("1");
        }

        public static string Get_pended_Prof_Add_Count(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Get_pended_Prof_Add_Count", "varchar2", al).ToString();
        }

        public static DataTable PendingDependentCoverageName(string session_id, string cvrg_group_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_2.PendingDependentCoverageName", al, conn);
        }

        public static void DeletePendCoverages(string session_id, string cvrg_group_id)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_2.DeletePendCoverages", al);
        }

        public static string Packaged_Pending_Coverage(string session_id, string cvrg_group_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_group_id_", "in", "varchar2", cvrg_group_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.Packaged_Pending_Coverage", "varchar2", al, conn).ToString();
        }

        public static bool is_HMO_benefit(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.is_HMO_benefit", "number", al).ToString().Equals("1");
        }


        public static DataTable Get_Pending_EOI_List(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_2.Get_Pending_EOI_List", al);
        }

        public static DataTable GetBenefitStatmentPendingList(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_2.GetBenefitStatmentPendingList", al, conn);
        }

        public static DataTable GetBeneficiary(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_2.GetBeneficiary", al);
        }
        public static void VerifyDependentElig(string session_id, string depe_no)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depe_no_", "in", "varchar2", depe_no));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_2.VerifyDependentElig", al);
        }

        public static bool all_life_cvrg_assgnd_Benefcars(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.all_life_cvrg_assgnd_Benefcars", "number", al).ToString().Equals("1");
        }

        public static string dep_realtion_note(string account_number, string relation_code)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relation_code_", "in", "varchar2", relation_code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.dep_realtion_note", "varchar2", al).ToString();
        }

        public static string dep_realtion_has_note(string account_number, string relation_code)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relation_code_", "in", "varchar2", relation_code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.dep_realtion_has_note", "number", al).ToString();
        }

        public static DataTable GetBenefitStatmentHeader(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_2.GetBenefitStatmentHeader", al);
        }

        public static string Current_Processing_Year(string account_number, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_accounts_data_out.Current_Processing_Year", "number", al, conn).ToString();
        }

        public static string ee_using_pretax(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.ee_using_pretax", "number", al).ToString();
        }

        public static bool allows_pretax_posttax(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.allows_pretax_posttax", "number", al).ToString().Equals("1");
        }

        public static bool GoodProcessingYear(string account_number, string processing_year, Oracle.DataAccess.Client.OracleConnection conn)
        {
            string SQL = "select count(*) from erprocessingyears s where s.account_number = '" + account_number + "' and s.processing_year=" + processing_year;
            return !SQLStatic.SQL.ExecScaler(SQL, conn).ToString().Equals("0");
        }

        public static string ee_pre_post_value(string employee_number, string processing_year)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.ee_pre_post_value", "varchar2", al).ToString();
        }

        public static bool benefitpagevisible(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.benefitpagevisible", "number", al).ToString().Equals("1");
        }

        public static bool HasCoverage(string employee_number, string processing_year)
        {
            string strSQL = "select count(*) from ee_selected_coverages_ tt where tt.employee_number= " + employee_number + " and tt.processing_year= " + processing_year;
            string strResult = SQLStatic.SQL.ExecScaler(strSQL).ToString();
            return !strResult.Equals("0");
        }

        public static string Enrollment_type(string account_number)
        {
            account_number = account_number.Substring(0, 7) + "-0000-000";
            string strSQL = "select nvl(pkg_enrollment_wizard_setup.Get_er_property_accnt('" + account_number + "',135),0) from dual";
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static DataTable get_warning_data(string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("emplouee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_3.get_warning_data", al);
        }

        public static string PerpayText(string account_number)
        {
            account_number = account_number.Substring(0, 7) + "-0000-000";
            string strSQL = "select pkg_enrollment_wizard_setup.Get_er_property_accnt('" + account_number + "',537) from dual";
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static DataTable get_screen_scheme_iframe(string page_id_,string scheme_id_, string account_number_)
        {
            account_number_ = account_number_.Substring(0,7)+"-0000-000";
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("emplouee_number_", "in", "number", page_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("scheme_id_", "in", "number", scheme_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("basdba.PKG_SCHEMES.get_screen_scheme_iframe", al);
        }

        
    }
}