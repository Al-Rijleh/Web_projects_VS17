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

namespace Dependents_Maintenance
{
    public class Data
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnStr"];

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
            if (string.IsNullOrEmpty(strAction))
            {
                strAction = SQLStatic.Sessions.GetSessionValue(session_id, "LIFE_EVENT_DATE");
                if (!string.IsNullOrEmpty(strAction))
                    strAction="L";
            }
            return strAction;
        }

        public static string Current_Action2(string session_id)
        {
            //string strAction = SQLStatic.SQL.ExecScaler("select pkg_add_update_benefit.get_current_action('" + session_id + "') from dual").ToString();
            string strAction = SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE");            
            if (string.IsNullOrEmpty(strAction))
            {
                strAction = SQLStatic.Sessions.GetSessionValue(session_id, "LIFE_EVENT_DATE");
                if (!string.IsNullOrEmpty(strAction))
                    strAction = "L";
            }
            return strAction;
        }

        //public static DataTable GetDependentsList(string strEmployeeNumber)
        //{
        //    ArrayList al = new ArrayList(2);
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
        //    DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Dependent_ListingFull", al);
        //    return tbl;
        //}

        public static DataTable GetDependentsList(string strEmployeeNumber, string certify_flag_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("certify_flag_", "in", "number", certify_flag_));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Dependent_Listing", al);
            return tbl;
        }

        public static DataTable GetDependentsListActive(string strEmployeeNumber, string certify_flag_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("certify_flag_", "in", "number", certify_flag_));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Dep_Listing_Full_Active", al);
            //DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Dep_Listing_Full_Active", al);
            return tbl;
        }

        public static string Show_Declara_Form_Send_Processess(string strEmployeeNumber)
        {
            return SQLStatic.SQL.ExecScaler("Select pkg_employee_maintenance.show_declara_form_send_process(" + strEmployeeNumber + ") from dual)").ToString() ;
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

        public static DataTable GetRelationships(string strRmployeeNumber, string lift_code)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strRmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("lift_code_", "in", "varchar2", lift_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_le.get_relationship_list", al);
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

        public static string SaveDependents(string session_id, string strRecordID, string strEmployeeNumber, string strDependentNumber, string strProcessingYear,
           string strLastName, string strFirstName, string strMI, string strRelation,
           string strSSN, string strDOB, string strEffectiveDate, string strSex, string strStudent, string strHandicapped, string strSchool, string strGradDate,
           string strIsOpenEnrollmanr, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
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
            al.Add(SQLStatic.StoredProcedure.OneParamerer("life_event_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("return_record_id", "out", "varchar2", null));
            ArrayList alRet = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Dependent3", al, conn);
            string strReturn = alRet[0].ToString();
            return strReturn.ToLower().Replace("return_record_id=", "");
        }

        public static string SaveDependents(string session_id_, string strRecordID, string strEmployeeNumber, string strDependentNumber, string strProcessingYear,
            string strLastName, string strFirstName, string strMI, string strRelation,
            string strSSN, string strDOB, string strEffectiveDate, string strSex, string strStudent, string strHandicapped, string strSchool, string strGradDate,
            string strIsOpenEnrollmanr, string strUserName, string Life_Event, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
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
            al.Add(SQLStatic.StoredProcedure.OneParamerer("life_event_", "in", "varchar2", Life_Event));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("return_record_id", "out", "varchar2", null));
            ArrayList alRet = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Dependent3", al, conn);
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

        public static void MoveToPending(string strEmployeeNumber, string strDependentNumber,string strProcessingYear, string strUserName, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dep_no_", "in", "varchar2", strDependentNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.move_to_pending", al, conn);
        }

        public static void MoveOutOfPending(string strRecordID,string strProcessingYear, string strApproveDate, string strClassCode, string strUserName)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rqst_dep_no_record_id_", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DocRecvDate", "in", "varchar2", strApproveDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", strUserName));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.move_out_of_pending", al);
        }

        public static void Terminate_Dependent(string strRecordID, string strTermDate, string strReason, string strUserName,Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_date_", "in", "varchar2", strTermDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_reason_code_", "in", "varchar2", strReason));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id", "in", "varchar2", strUserName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("result_", "out", "varchar2", " "));
            if (conn == null)
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Terminate_Dependent", al);
            else
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Terminate_Dependent", al,conn);
        }

        public static void Pend_Terminate_Dependent(string session_id, string strRecordID, string strTermDate, string strReason)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eedependents_record_id", "in", "varchar2", strRecordID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_date_", "in", "date", strTermDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("termination_reason_code_", "in", "varchar2", strReason));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.PendTerminiateDependent", al);
        }

        public static void Terminate_Request_Dependent(string strRecordID,string strEmployeeNumber, string strprocessingYear,string strTermDate, string strReason, string strUserName)
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

        public static void Send_Email_Doc(string strEmployeeNumber,string strProccessingYear, string strUserName, byte[] buffer)
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
            return SQLStatic.SQL.ExecScaler("select  pkg_employee_maintenance.show_coverage_window("+strEmployeeNumber+","+strProcessingYear+") from dual").ToString() != "0";
        }

        public static DataTable GetEleigibleCoverages(string strEmployeeNumber, string strProcessingYear, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Eleigible_Coverages", al,conn);
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

        public static void SaveCoverage(string strCvrgID, string strEmployeeNumber, string strReqstID, string strFamilyStatus, string strEffectiveDate, string strUserName,Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", strCvrgID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("request_record_id_", "in", "varchar2", strReqstID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_", "in", "varchar2",strFamilyStatus ));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "varchar2",strEffectiveDate ));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2",strUserName ));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_maintenance.Save_Request_Coverage", al, conn);
        }

        public static string GetEffectiveDate(string strSession, string strCatCode, string strCatPlan)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.get_open_enroll_effectivedate('" + strSession + "', '" + strCatCode + "', '" + strCatPlan + "') from dual;").ToString();

        }

        public static bool DependentIsActive(string strEmployeeNumber, string Dependent_D)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.dependent_in_eedepenents_("+strEmployeeNumber+","+Dependent_D+") from dual;").ToString() == "1";
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

        public static bool SkipRetiree(String strEemployeeNumber,string UserName)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.skipretiree(" + strEemployeeNumber + ",'" + UserName + "') from dual").ToString() == "1";
        }

        public static string NextPayDate(string strEmployeeNumber)
        {
            return SQLStatic.SQL.ExecScaler("select TO_CHAR(pkg_employee_2.next_pay_date("+strEmployeeNumber+",sysdate),'MM/DD/YYYY') from dual").ToString();
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
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.canadddompartner('" + session_id + "') from dual").ToString()=="1";
        }

        public static bool EmployeeIsDependentEligible(string employee_number, string processing_year)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction(" pkg_class_code.employee_is_dependent_eligible", "number", al).ToString().Equals("1");
        }

        public static string DependentEligibility(string session_id )
        {
            string strSQL = "select pkg_enrollment_wizard.get_message('" + session_id + "'," + "19" + ")from dual";
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static string Employee_Gender(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Employee_Gender", "varchar2", al).ToString();
        }

        public static string dep_realtion_has_note(string account_number, string relation_code)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relation_code_", "in", "varchar2", relation_code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.dep_realtion_has_note", "number", al).ToString();
        }

        public static string MaxEligibleDate(string employee_number, string processing_year)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year", "in", "number", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_maintenance.maxeligibledate", "number", al).ToString();
        }

        public static string IsEETerminated(string employee_number)
        {
            return SQLStatic.SQL.ExecScaler("select count(*) from eeprofile_ p where p.termination_date is not null and employee_number=" + employee_number).ToString();
        }

        public static DataTable Get_Pending_Dependents(string strEmployeeNumber)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Employee_Number_", "in", "number", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard.Get_Pending_Dependents", al);
            return tbl;
        }

        public static DataTable NoDep()
        {
            return SQLStatic.SQL.ExecTable("Select 'There are no active dependents recorded in the system' FullName from dual");
        }

        public static string GetText(string session_id, string cd_enrollwiz_record_id)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_enrollment_wizard.get_message('" + session_id + "'," + cd_enrollwiz_record_id + ")from dual").ToString();            
        }

        public static void CheckSetProcessing_Year_ee(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_misc_functions.CheckSetProcessing_Year_ee", al);
        }

        public static void VerifyDependentElig(string session_id, string depe_no)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depe_no_", "in", "varchar2", depe_no));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_2.VerifyDependentElig", al);
        }

        public static string requires_dep_verify(string employee_number_)
        {
            string strSQL = "select pkg_dependent_audit_wizard.requires_dep_verify(" + employee_number_ + ")from dual";
            return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static string CanHaveSameSexSpouse(string employee_number_, string relation_ship_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relation_ship_", "in", "varchar2", relation_ship_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents.canhavesamesexspouse", "number", al).ToString();
        }

        public static string get_dep_name(string employee_number_, string depid)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pn_employee_number", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pn_dep_id", "in", "varchar2", depid));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents.get_dep_name", "varchar2", al).ToString();
        }

        public static string Get_other(string account_number, string code, string default_value)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("default_", "in", "varchar2", default_value));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_other", "number", al).ToString();
        }

        public static string Class_Effective_Date(string session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.ee_class_effective_date", "varchar2", al).ToString();
        }

        public static string CurrentSpousePendingTerm(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents.CurrentSpousePendingTerm", "number", al).ToString();
        }

        public static string Get_er_property_accnt(string account_number, string code)
        {
            ArrayList al = new ArrayList(3);
            account_number = account_number.Substring(0, 7) + "-0000-000";
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
        }

        public static string account_need_dep_audit(string account_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents_audit.account_need_dep_audit", "varchar2", al).ToString();
        }

        //public static DataTable GetRelationships(string strRmployeeNumber)
        //{
        //    ArrayList al = new ArrayList(2);
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strRmployeeNumber));
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
        //    DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_employee_maintenance.Get_Relationship_List", al);
        //    return tbl;
        //}

        public static void ManualDenedentApproval(string session_id, string depe_no)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depe_no_", "in", "varchar2", depe_no));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_dependents_audit.ManualDenedentApproval", al);
        }

        public static string CanUseManualApproval(string session_id_, string dep_no_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dep_no_", "in", "varchar2", dep_no_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_dependents_audit.CanUseManualApproval", "number", al).ToString();
        }

        public static string Rec_Id_From_Dep_no(string dependent_sequence_no_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", dependent_sequence_no_));
            return SQLStatic.StoredProcedure.ExecuteFunction("PKG_Employee_Maintenance.Rec_Id_From_Dep_no", "number", al).ToString();
        }

        public static DataTable Dependents_cvrg_will_remove(string session_id_, string record_id_, string employee_number_, string dependent_sequence_no_, string processing_year_)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "number", dependent_sequence_no_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("PKG_Employee_Maintenance.Dependents_cvrg_will_remove", al);
            return tbl;
        }

        public static DataTable Dependents_cvrg_will_Keep(string session_id_, string record_id_, string employee_number_, string dependent_sequence_no_, string processing_year_)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "number", dependent_sequence_no_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("PKG_Employee_Maintenance.Dependents_cvrg_will_Keep", al);
            return tbl;
        }

        public static string SpuseTypeRelationship(string retlation_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retlation_", "in", "varchar2", retlation_));
            return SQLStatic.StoredProcedure.ExecuteFunction(" pkg_enrollment_wizard.SpuseTypeRelationship", "number", al).ToString();
        }

        public static string Save_DependentLE(string session_id, string strRecordID, string strEmployeeNumber, string strDependentNumber, string strProcessingYear, string strLastName, string strFirstName, string strMI, string strRelation,
            string strSSN, string strDOB, string strEffectiveDate, string strSex, string strStudent, string strHandicapped, string strSchool, string strGradDate,
            string strIsOpenEnrollmanr, string strUserName, string Operation, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(20);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
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
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Operation_", "in", "varchar2", Operation));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("return_record_id", "out", "varchar2", null));
            ArrayList alRet = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_le.Save_DependentLE", al, conn);
            string strReturn = alRet[0].ToString();
            return strReturn.ToLower().Replace("return_record_id=", "");
        }

        public static void terminate_dep_cvrg_from_web(string pn_record_id, string pd_rm_date, string pn_rm_reason_code, string ps_user_id,
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pn_record_id", "in", "varchar2", pn_record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pd_rm_date", "in", "Date", pd_rm_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pn_rm_reason_code", "in", "varchar2", pn_rm_reason_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ps_user_id", "in", "varchar2", ps_user_id));
            if (conn != null)
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("PKG_Employee_Maintenance.terminate_dep_cvrg_from_web", al,conn);
            else
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("PKG_Employee_Maintenance.terminate_dep_cvrg_from_web", al);
        }

        public static string DepCoverageCount(string depNo, string processing_year_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depNo", "in", "varchar2", depNo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            return SQLStatic.StoredProcedure.ExecuteFunction("PKG_Employee_Maintenance.DepCoverageCount", "number", al).ToString();
        }

        public static string Has_COBRA(string employee_number_, string processing_year_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            return SQLStatic.StoredProcedure.ExecuteFunction("PKG_Employee_Maintenance.Has_COBRA", "varchar2", al).ToString();
        }

        public static string GetCoverageNamefromid(string id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("id", "in", "varchar2", id));
            return SQLStatic.StoredProcedure.ExecuteFunction("PKG_Employee_Maintenance.GetCoverageNamefromid", "varchar2", al).ToString();
        }

        public static DataTable get_dependent(string record_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_beneficiaries.get_dependent", al);
            return tbl;
        }

        public static void terminate_All_dep_cvrg(string DepNo_, string processing_year_, string pd_rm_date, string pn_rm_reason_code, string ps_user_id)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DepNo_", "in", "varchar2", DepNo_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pd_rm_date", "in", "Date", pd_rm_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pn_rm_reason_code", "in", "varchar2", pn_rm_reason_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ps_user_id", "in", "varchar2", ps_user_id));           
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("PKG_Employee_Maintenance.terminate_All_dep_cvrg", al);
        }

        public static string check_duplicate_dependent(string employee_number_, string ssn_, string first_, string last_, string dob_, string relationship_code_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ssn_", "in", "varchar2", ssn_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("first_", "in", "varchar2", first_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("last_", "in", "varchar2", last_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("dob_", "in", "varchar2", dob_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("relationship_code_", "in", "varchar2", relationship_code_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_maintenance.check_duplicate_dependent", "varchar2", al).ToString();
        }

    }
}
