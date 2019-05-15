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

namespace EnrollmentWizardSetup
{
    public class Data
    {
        public static string GetText(string session_id, string cd_enrollwiz_record_id)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_enrollment_wizard.get_message('" + session_id + "'," + cd_enrollwiz_record_id + ")from dual").ToString();
            //ArrayList al = new ArrayList(2);
            //al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            //al.Add(SQLStatic.StoredProcedure.OneParamerer("cd_enrollwiz_record_id_", "in", "number", cd_enrollwiz_record_id));
            //return SQLStatic.StoredProcedure.ExecuteFunction("enrollment_wizard.get_message","clob", al).ToString();
        }

        public static DataTable GetMessageDetail(string session_id, string enrollment_type, string cd_enrollwiz_record_id, string FromTable)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("enrollment_type_", "in", "number", enrollment_type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cd_enrollwiz_record_id_", "in", "number", cd_enrollwiz_record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("from_table_", "in", "number", FromTable));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.GetMessageDetail", al);
        }

        public static DataTable WelcomePageTextDescription(string session_id, string enrollment_type, string cd_enrollwiz_record_id)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.WelcomePageTextDescription", al);
        }

        public static void SaveMessageData(string session_id, string enrollment_type, string cd_enrollwiz_record_id, string to_table,
            string title, string content, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(7);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("enrollment_type_", "in", "varchar2", enrollment_type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cd_enrollwiz_record_id_", "in", "varchar2", cd_enrollwiz_record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("to_table_", "in", "varchar2", to_table));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("title_", "in", "varchar2", title));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("content_", "in", "clob", content));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.savemessagedetail", al, conn);
        }

        public static void SaveShowCost(string session_id, string enrollment_type, string ShowCostType, string apply_to,
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("enrollment_type_", "in", "varchar2", enrollment_type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ShowCostType_", "in", "varchar2", ShowCostType));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("apply_to", "in", "varchar2", apply_to));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveShowCost", al, conn);
        }

        public static DataTable GetShowCostSetting(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.GetShowCostSetting", al);
        }

        public static DataTable GetCoveragesMarkSkip(string session_id, string class_code, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.GetCoveragesMarkSkip", al);
        }

        public static string open_nrollment_Processing_year(string account_number, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.open_nrollment_Processing_year", "varchar2", al, conn).ToString();
        }

        public static void SaveCoverageSkip(string session_id, string cvrg_id, string save_type, string doskip, string code,
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("save_type_", "in", "varchar2", save_type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("doskip_", "in", "varchar2", doskip));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveCoverageSkip", al, conn);
        }


        public static DataTable GetCoveragesMarkSkipBenefit(string session_id, string class_code, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.GetCoveragesMarkSkipBenefit", al);
        }

        public static void SaveCoverageSkipBenefit(string session_id, string cvrg_id, string save_type, string doskip,
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("save_type_", "in", "varchar2", save_type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("doskip_", "in", "varchar2", doskip));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", "0"));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveCoverageSkipBenefit", al, conn);
        }

        public static string BenefitPageRequiredForNewEE(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.BenefitPageRequiredForNewEE", "number", al).ToString();
        }

        public static string BenefitPageRequiredForAnnualOE(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.BenefitPageRequiredForAnnualOE", "number", al).ToString();
        }

        public static string BenefitPagevisible(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_2.BenefitPagevisible", "number", al).ToString();
        }

        public static void SaveBenefitPgRequiredForNewEE(string session_id, string value, string allDivisions)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("All_Divisions_", "in", "varchar2", allDivisions));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveBenefitPgRequiredForNewEE", al);
        }

        public static void SaveBenefitPgReqForAnualOE(string session_id, string value, string allDivisions)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("All_Divisions_", "in", "varchar2", allDivisions));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveBenefitPgReqForAnualOE", al);
        }
        public static void SaveShowBeneficiaries(string session_id, string value, string allDivisions)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("All_Divisions_", "in", "varchar2", allDivisions));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveShowBeneficiaries", al);
        }

        public static DataTable PayPeriodCodes(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.PayPeriodCodes", al);
        }

        public static DataTable PayDatesList(string session_id, string pay_period_code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pay_period_code_", "in", "varchar2", pay_period_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.PayDatesList", al);
        }

        public static void SaveFSALimit(string session_id, string paycode, string value, string allDivisions)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("paycode_", "in", "varchar2", paycode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("All_Divisions_", "in", "varchar2", allDivisions));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveFSALimit", al);
        }


        public static DataTable Default_enrollment_info(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Default_enrollment_info", al);
        }

        public static DataTable Last_enrollment_info(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Last_enrollment_info", al);
        }

        public static void Save_enrollment_info(string account_number, string processing_year, string start_date, string end_date, string effective_date,
            string save_to, string use_wiz)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("start_date_", "in", "Date", start_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("end_date_", "in", "Date", end_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "Date", effective_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("save_to_", "in", "number", save_to));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("use_wiz_", "in", "number", use_wiz));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.Save_enrollment_info", al);
        }

        public static void Update_enrollment_info(string record_id, string processing_year, string start_date, string end_date, string effective_date,
            string save_to, string use_wiz)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("start_date_", "in", "Date", start_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("end_date_", "in", "Date", end_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "Date", effective_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("save_to_", "in", "number", save_to));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("use_wiz_", "in", "number", use_wiz));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.Update_enrollment_info", al);
        }

        public static DataTable Get_Grouping_List(string account_number, string processing_year, string class_code)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Get_Grouping_List", al);
        }

        public static DataTable GetProcessingYears(string account_number)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_nnumber_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.getprocessingyears", ar);
        }

        public static DataTable GroupMessage(string group_record_id, string current_action)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("group_record_id_", "in", "varchar2", group_record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("current_action_", "in", "varchar2", current_action));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.GroupMessage", ar);
        }

        public static void Save_Grp_msg(string session_id, string group_record_id, string instruction, string message, string current_action,
            string SaveTo_)
        {
            ArrayList al = new ArrayList(8);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("group_record_id_", "in", "varchar2", group_record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("instruction_", "in", "varchar2", instruction));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("message_", "in", "clob", message));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("current_action_", "in", "varchar2", current_action));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("message_type_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("insturction_type_", "in", "varchar2", null));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SaveTo_", "in", "varchar2", SaveTo_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.Save_Grp_msg", al);
        }

        public static bool employee_use_enrol_wizard(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.employee_use_enrol_wizard", "number", al).ToString().Equals("0");
        }

        public static DataTable Get_Cvrg_List(string account_number, string processing_year, string class_code)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Get_Cvrg_List", al);
        }

        public static DataTable CoverageMessage(string group_record_id, string current_action)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("group_record_id_", "in", "varchar2", group_record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("current_action_", "in", "varchar2", current_action));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.CoverageMessage", ar);
        }

        public static void Save_cvr_msg(string session_id, string cvrg_record_id, string message, string current_action, string SaveTo_)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_record_id_", "in", "varchar2", cvrg_record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("message_", "in", "clob", message));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("current_action_", "in", "varchar2", current_action));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SaveTo_", "in", "varchar2", SaveTo_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.Save_cvr_msg", al);
        }

        public static string allows_pretax_posttax(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.allows_pretax_posttax", "number", al).ToString();
        }

        public static void save_pretax_posttax(string session_id, string SaveTo, string value)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SaveTo_", "in", "varchar2", SaveTo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.save_pretax_posttax", al);
        }

        public static void save_pretax_posttax_New(string session_id, string SaveTo, string value, string events)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SaveTo_", "in", "varchar2", SaveTo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("events", "in", "varchar2", events));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.save_pretax_posttax_New", al);
        }

        

        public static void save_Choice(string session_id, string SaveTo, string code, string value)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SaveTo_", "in", "varchar2", SaveTo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.save_Choice", al);
        }

        public static string Get_other(string account_number, string code, string default_value)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("default_", "in", "varchar2", default_value));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_other", "number", al).ToString();
        }

        public static void SetInitial_Processing_Year(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SetInitial_Processing_Year", al);
        }

        public static DataTable Verify_Account_Group_Type(string account_number, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Verify_Account_Group_Type", al);
        }

        public static DataTable Verify_Account_Plan_Sort(string account_number, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Verify_Account_Plan_Sort", al);
        }

        public static DataTable Verify_Account_Cutoff_Age(string account_number, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Verify_Account_Cutoff_Age", al);
        }

        public static void add_er_property_accnt(string session_id, string account_number, string code, string value)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.add_er_property_accnt", al);
        }

        public static string Extra_Page_Name(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.Extra_Page_Name", "varchar2", al).ToString();
        }

        public static void Save_Pend_dependent(string account_number, string SaveTo, string value, string user_name)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SaveTo_", "in", "varchar2", SaveTo));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.Save_Pend_dependent", al);
        }

        public static string Get_Pend_dependent(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_Pend_dependent", "varchar2", al).ToString();
        }

        public static bool Has_Account_Specific_text(string account_number, string enrollment_type, string cd_enrollwiz_record_id)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("enrollment_type_", "in", "number", enrollment_type));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cd_enrollwiz_record_id_", "in", "number", cd_enrollwiz_record_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Has_Account_Specific_text", "number", al).ToString().Equals("1");
        }

        public static string Get_er_property_accnt(string account_number, string code)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
        }

        public static void SavePeriods(string session_id_, string record_id_, string begin_date_, string end_date_,string req_date_, string save_all_)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("begin_date_", "in", "date", begin_date_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("end_date_", "in", "date", end_date_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("req_date_", "in", "date", req_date_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("save_all_", "in", "number", save_all_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_Dependent_Audit_Wizard.SavePeriods", al);
        }

        public static DataTable setupDates(string account_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependent_Audit_Wizard.setupDates", al);
        }

        public static string Get_er_property_accnt(string account_number, string code, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", code));
            if (conn == null)
                return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
            else
                return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al,conn).ToString();
        }

        public static DataTable getAlertCoverages(string account_number, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.getAlertCoverages", al);
        }

        public static void SaveAlert(string account_number_, string title_, string question_, string text_, string category_code_, string category_plan_,
            string enrollment_type_, string Save_Type_)
        {
            ArrayList al = new ArrayList(8);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("title_", "in", "varchar2", title_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("question_", "in", "varchar2", question_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("text_", "in", "varchar2", text_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("enrollment_type_", "in", "varchar2", enrollment_type_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Save_Type_", "in", "varchar2", Save_Type_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.SaveAlert", al);
        }

        public static DataTable getprocessedalertplans(string account_number, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.getprocessedalertplans", al);
        }

        public static DataTable getOneCoverageDetail(string account_number_, string category_code_, string category_plan_,string enrollment_type_)
        {
            ArrayList al = new ArrayList(8);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("enrollment_type_", "in", "varchar2", enrollment_type_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.getOneCoverageDetail", al);
        }

        public static void Save_er_property(string account_number, string code, string value, string user_name, string AllDivisions,
           Oracle.DataAccess.Client.OracleConnection conn)
        {
            if (AllDivisions.Equals("3"))
            {
                account_number = account_number.Substring(0, 7) + "-0000-000";
                AllDivisions = "1";
            }
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("AllDivisions_", "in", "varchar2", AllDivisions));
            if (conn != null)
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard.Save_er_property", al, conn);
            else
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard.Save_er_property", al);
        }

        public static DataTable Get_Class_Code_List(string account_number, string processing_year_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_list", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.Get_Class_Code_List", al);
        }


        public static void Make_All_Classes_Eligible(string account_number, string processing_year_, string All_Accounts_,
            string user_name_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("All_Accounts_", "in", "varchar2", All_Accounts_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.Make_All_Classes_Eligible", al,conn);
        }


        public static void update_one_class(string account_number, string processing_year_, string All_Accounts_, string class_code_,
            string oe_eligible_value_,  string user_name_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(6);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("All_Accounts_", "in", "varchar2", All_Accounts_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("oe_eligible_value_", "in", "varchar2", oe_eligible_value_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_enrollment_wizard_setup.update_one_class", al, conn);
        }

        public static DataTable FinalizePageItems()
        {
            ArrayList al = new ArrayList(1);          
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.FinalizePageItems", al);
        }

        public static DataTable CoveragsPageItems()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.CoveragsPageItems", al);
        }

        public static string Get_er_property_accnt(string account_number, string code, string default_value, string type)
        {
            if (type.Equals("3"))
            {
                account_number = account_number.Substring(0, 7) + "-0000-000";
            }
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            string strResult = SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
            if (string.IsNullOrEmpty(strResult))
                return default_value;
            else
                return strResult;
        }

        public static DataTable GetClassCodes(string account_number_, string processing_year_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_list", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_class_code.Get_Class_Code_List", al);
        }

        public static DataTable ExtraPageResponseType( )
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("RetResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard_setup.ExtraPageResponseType", al);
        }

    }
}
