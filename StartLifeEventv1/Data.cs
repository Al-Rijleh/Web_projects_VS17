using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;


namespace StartLifeEventv1
{
    public class Data
    {
        public static DataTable Get_ER_Setup(string session_id_, string account_number, string processing_year, string LE_Date_)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("LE_Date_", "in", "date", LE_Date_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.Get_ER_Setup_ver_2", al);
        }

        public static DataTable Get_le_ee_session_info(string account_number, string processing_year, string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.Get_le_ee_session_info", al);
        }

        public static DataTable Get_Group_Life_Event(string account_number, string employee_number_, string session_id_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.Get_Group_Life_Event", al);
        }

        public static DataTable Get_Life_Events(string account_number, string employee_number_, string session_id_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.Get_Life_Events", al);
        }


        public static DataTable Get_Life_Events_For_Group(string account_number, string employee_number_, string group_, string session_id_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("group_", "in", "varchar2", group_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.Get_Life_Events_For_Group", al);
        }

        public static void SavePDF(string session_id_, string strName, byte[] bValue)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_Enrollment_Wizard_LE.save_LE_Doc_upload", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "session_id_", session_id_);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "doc_name_", strName);

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

        public static void save_le_ee_session_info(string session_id, string account_number, string employee_number, string action_date, string notes, string life_event_code,
            string certificate_text, string user_name)
        {
            ArrayList al = new ArrayList(7);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("action_date_", "in", "date", action_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("notes_", "in", "varchar2", notes));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("life_event_code_", "in", "varchar2", life_event_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("certificate_text_", "in", "varchar2", certificate_text));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.save_le_ee_session_info", al);

        }


        public static void save_le_ee_session_info_2(string session_id, string action_date,string life_event_code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));            
            al.Add(SQLStatic.StoredProcedure.OneParamerer("action_date_", "in", "date", action_date));           
            al.Add(SQLStatic.StoredProcedure.OneParamerer("life_event_code_", "in", "varchar2", life_event_code));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.save_le_ee_session_info_2", al);

        }

        public static void updatele_ee_session_info(string session_id, string action_date, string notes)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("action_date__", "in", "date", action_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("notes_", "in", "varchar2", notes));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.updatele_ee_session_info", al);
        }

        public static string Get_er_property_accnt(string account_number, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
        }

        public static void updatele_ee_session_info_date(string session_id, string action_date)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("action_date__", "in", "date", action_date));            
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.updatele_ee_session_info_date", al);
        }

        public static void updatele_ee_sess_info_Effdate(string session_id, string EffectiveDate_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("EffectiveDate_", "in", "date", EffectiveDate_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.updatele_ee_sess_info_Effdate", al);
        }

        public static string MaxCoverageEffectiveDate(string session_, string account_number, string employee_number_, string processing_year_,
            string class_code_, string life_event_, string Life_Event_Date_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_", "in", "varchar2", session_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("life_event_", "in", "varchar2", life_event_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Life_Event_Date_", "in", "date", Life_Event_Date_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Enrollment_Wizard_LE.MaxCoverageEffectiveDate", "varchar2", al).ToString();
        }


        public static string getJCredential()
        {
            ArrayList al = new ArrayList(1);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_scheduler.get_jdrive_credentials", al);
            string strCredention = tbl.Rows[0][0].ToString();
            return strCredention;
        }

        public static DataTable SendFaxTo(string employee_number_)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.SendFaxTo", al);
        }

        public static string LifeEventProoftabInstruction()
        {
            ArrayList al = new ArrayList(1);            
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Enrollment_Wizard_LE.LifeEventProoftabInstruction", "varchar2", al).ToString();
        }

        public static void SendFaxEmail(string employee_number_, string email_, string file_name)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("email_", "in", "varchar2", email_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("file_name", "in", "varchar2", file_name));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.SendFaxEmail", al);
        }

        public static string uploaded_Fax_Doc(string ee_life_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_life_id", "in", "varchar2", ee_life_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Enrollment_Wizard_LE.uploaded_Fax_Doc", "varchar2", al).ToString();
        }

        public static string ee_property_value(string employee_number_, string code_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_utility.ee_property_value", "varchar2", al).ToString();
        }

        public static void add_ee_property_code(string employee_number_, string code_, string value_,string user_name_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_utility.add_ee_property_code", al);
        }

        public static DataTable uploaded_Fax_Doc_Cursor(string ee_life_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_life_id", "in", "varchar2", ee_life_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.uploaded_Fax_Doc_Cursor", al);
        }

        public static DataTable uploaded_Doc_Cursor(string ee_life_id, string doc_type_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ee_life_id", "in", "varchar2", ee_life_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("doc_type_", "in", "varchar2", doc_type_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_LE.uploaded_Doc_Cursor", al);
        }

        public static void Remove_Document(string session_id_, string drecid_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("drecid_", "in", "varchar2", drecid_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.Remove_Document", al);
        }

        public static string is_EE_in_New_Open_Enrollment(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_3.is_EE_in_New_Open_Enrollment", "number", al).ToString();
        }

        public static string ee_eligible_for_life(string employee_number_,string session_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_", "in", "varchar2", session_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_le.ee_eligible_for_life", "number", al).ToString();
        }

        public static string Block_in_OE(string session_id_, string account_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_Enrollment_Wizard_LE.Block_in_OE", "varchar2", al).ToString();
        }

        public static string Get_message(string session_id_, string cd_enrollwiz_record_id_)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_enrollment_wizard.get_message('" + session_id_ + "'," + cd_enrollwiz_record_id_ + ")from dual").ToString();
            //ArrayList al = new ArrayList(2);
            //al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            //al.Add(SQLStatic.StoredProcedure.OneParamerer("cd_enrollwiz_record_id_", "in", "varchar2", cd_enrollwiz_record_id_));
            //return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Get_message", "varchar2", al).ToString();
        }

        public static string is_currently_retiree(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_class_code.is_currently_retiree", "number", al).ToString();
        }

        public static void SetLifeEventProcessing_year(string session_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Enrollment_Wizard_LE.SetLifeEventProcessing_year", al);
        }

    }
}