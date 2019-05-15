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

namespace NewHireWizard
{
    public class Data
    {
        public static DataTable GetPendingList(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure(" pkg_newhirewizard.getpendinglist", al);
        }

        public static DataTable MritalStatus(string session_id)
        {
            ArrayList al = new ArrayList();
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.get_cdmaritalstatus", al);
            //return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.get_cdmaritalstatusNewHire", al);
        }

        public static DataTable States()
        {
            ArrayList al = new ArrayList();
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cr", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_home_web.States_List", al);
        }

        public static string Get_Account_Info(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_info.get_account_info","varchar2", al).ToString();
        }

        public static string HeaderText(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.HeaderText", "varchar2", al).ToString();
        }

        public static DataTable AccountAndEmployeeNames(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.accountandemployeenames", al, conn);
        }

        public static string EE_Class_Code_Details(string EmployeeNumber)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", EmployeeNumber));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_employee_info.ee_Class_Code_Details", "varchar2", al).ToString();
        }

        public static string User_Name_Email_Address(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.usernameemailaddress", "varchar2", al).ToString();
        }

        public static void SaverData(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.Saver_Data", al).ToString();
        }

        public static void DefaultPaySchedule(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.defaultpayschedule", al,conn);
        }

        public static void DefaultClassCode(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure(" pkg_newhirewizard2.defaultclasscode", al, conn);
        }

        public static DataTable GetPayListSchedule(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", session_id));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetPayListSchedule", al,conn);
        }

        public static bool isPendingAccount(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.isPendingAccount", "varchar2", al, conn).ToString().Equals("1");
        }

        public static bool isPendingClass(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.isPendingClass", "varchar2", al,conn).ToString().Equals("1");
        }

        public static bool isPendingEmployee(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id", "in", "varchar2", session_id));
            if (conn != null)
                return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.isPendingEmployee", "varchar2", al,conn).ToString().Equals("1");
            else
                return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.isPendingEmployee", "varchar2", al).ToString().Equals("1");
        }

        public static DataTable PendedClasses(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", session_id));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.PendedClasses", al);
        }

        public static DataTable GetIdentification(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(11);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetIdentification", al,conn);
        }

        public static DataTable GetContactInformation(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(11);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetContactInformation", al, conn);
        }

        public static DataTable GetAdditionalInformation(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(11);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetAdditionalInformation", al, conn);
        }

        public static DataTable GetEnrollmentKit(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(11);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetEnrollmentKit", al, conn);
        }

        public static string SaveIdentification(string session_id, string FirstName, string MidInitial, string LastName, string DateofBirth, string Gender,
                string MaritalStatus, string HireDate, string Salary, string JobTitle, string Salutation, string SSN, string depCode, string location,
                string clien_number, string EE_exposed_company_id, string Nickname_,string Workers_Comp_Class_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(18);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("FirstName_", "in", "varchar2", FirstName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("MidInitial_", "in", "varchar2", MidInitial));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("LastName_", "in", "varchar2", LastName));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("DateofBirth_", "in", "date", DateofBirth));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Gender_", "in", "varchar2", Gender));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("MaritalStatus_", "in", "varchar2", MaritalStatus));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("HireDate_", "in", "date", HireDate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Salary_", "in", "number", Salary));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("JobTitle_", "in", "varchar2", JobTitle));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Salutation_", "in", "varchar2", Salutation));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("SSN_", "in", "varchar2", SSN));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("depCode_", "in", "varchar2", depCode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("location_", "in", "varchar2", location));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("clien_number_", "in", "varchar2", clien_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Nickname_", "in", "varchar2", Nickname_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Workers_Comp_Class_", "in", "varchar2", Workers_Comp_Class_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "out", "number", null));
            ArrayList alRet = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.SaveIdentification", al,conn);
            string strReturn = alRet[0].ToString();
            return strReturn.ToLower().Replace("employee_number_=", "");
        }

        public static void SaveContactInformation(string session_id,string address1, string address2, string city, string state, string zip_code, 
            string office_number, string work_phone_ext, string phone_number, string mobile_number, string fax_number, string work_email,
            string personal_email, string country_code, string province, string foreign_phone_number)
        {
            ArrayList al = new ArrayList(13);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address1_", "in", "varchar2", address1));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("address2_", "in", "varchar2", address2));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("city_", "in", "varchar2", city));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("state_", "in", "varchar2", state));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("zip_code_", "in", "varchar2", zip_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("office_number_", "in", "varchar2", office_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("work_phone_ext_", "in", "varchar2", work_phone_ext));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("phone_number_", "in", "varchar2", phone_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("mobile_number_", "in", "varchar2", mobile_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("fax_number_", "in", "varchar2", fax_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("work_email_", "in", "varchar2", work_email));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("personal_email_", "in", "varchar2", personal_email));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("country_code_", "in", "varchar2", country_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("province_", "in", "varchar2", province));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("foreign_phone_number_", "in", "varchar2", foreign_phone_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.SaveContactInformation", al);
        }

        public static void UpdateAdditionalInformation(string session_id,string full_or_part_time,string hours_worked_per_week,string is_employee_leased,
            string state_resident,string union_member,string paid_commission,string eligible_to_participate,string paid_salary,string paid_hourly,
            string hourly_rate,string owner_of_business,string own_what_percent,string director_of_business,string partner_in_business,
            string officer_of_business,string title_of_officer,string non_participating,string union_number,string job_status_code,
            string fulltime_equivalent,string annual_hours_worked,string workgroup_code,string department_code,string division_code,string import_ssno,
            string occupation, string location_code, string Transfer_From_Federal_Agency, string Has_FEGLI,string background)
        {
            ArrayList al = new ArrayList(28);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("full_or_part_time_", "in", "varchar2", full_or_part_time));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("hours_worked_per_week_", "in", "varchar2", hours_worked_per_week));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("is_employee_leased_", "in", "varchar2", is_employee_leased));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("state_resident_", "in", "varchar2", state_resident));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("union_member_", "in", "varchar2", union_member));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("paid_commission_", "in", "varchar2", paid_commission));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("eligible_to_participate_", "in", "varchar2", eligible_to_participate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("paid_salary_", "in", "varchar2", paid_salary));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("paid_hourly_", "in", "varchar2", paid_hourly));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("hourly_rate_", "in", "varchar2", hourly_rate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("owner_of_business_", "in", "varchar2", owner_of_business));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("own_what_percent_", "in", "varchar2", own_what_percent));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("director_of_business_", "in", "varchar2", director_of_business));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("partner_in_business_", "in", "varchar2", partner_in_business));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("officer_of_business_", "in", "varchar2", officer_of_business));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("title_of_officer_", "in", "varchar2", title_of_officer));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("non_participating_", "in", "varchar2", non_participating));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("union_number_", "in", "varchar2", union_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("job_status_code_", "in", "varchar2", job_status_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("fulltime_equivalent_", "in", "varchar2", fulltime_equivalent));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("annual_hours_worked_", "in", "varchar2", annual_hours_worked));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("workgroup_code_", "in", "varchar2", workgroup_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("department_code_", "in", "varchar2", department_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("division_code_", "in", "varchar2", division_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("import_ssno_", "in", "varchar2", import_ssno));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("occupation_", "in", "varchar2", occupation));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("location_code_", "in", "varchar2", location_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Transfer_From_Federal_Agency_", "in", "varchar2", Transfer_From_Federal_Agency));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Has_FEGLI_", "in", "varchar2", Has_FEGLI));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("background_", "in", "varchar2", background));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.UpdateAdditionalInformation", al);
        }

        public static void SaveEnrollmentKit(string session_id,string do_enrollment_kit,string send_kit_to_user, string send_kit_to_other,
            string other_name, string other_email, string send_kit_to_ee)
        {
            ArrayList al = new ArrayList(7);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("do_enrollment_kit_", "in", "number", do_enrollment_kit));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_kit_to_user_", "in", "number", send_kit_to_user));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_kit_to_other_", "in", "number", send_kit_to_other));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("other_name_", "in", "varchar2", other_name));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("other_email_", "in", "varchar2", other_email));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("send_kit_to_ee_", "in", "number", send_kit_to_ee));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.SaveEnrollmentKit", al);
        }

        public static void SaveConfirmation(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.SaveConfirmation", al,conn);
        }

        public static void PendConfirmation(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.PendConfirmation", al);
        }

        public static DataSet IncompleteNewHire(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteDataSetProcedure("pkg_newhirewizard2.IncompleteNewHire", al);
        }

        public static DataTable IncompleteNewHireTable(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.IncompleteNewHire", al);
        }

        public static DataSet PendingNewHire(string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteDataSetProcedure("pkg_newhirewizard2.PendingNewHire", al);
        }

        public static void SetProcessIncompleteNewHire(string session_id, string employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.SetProcessIncompleteNewHire", al);
        }

        public static void Clear_Session_Data(string session_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.Clear_Session_Data", al,conn);
        }

        public static string DefaultGender(string account_number, string class_code, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.defaultgender", "varchar2", al).ToString();
        }

        public static string DefaultGenderFromSession(string session_id)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.DefaultGenderFromSession", "varchar2", al).ToString();
        }

        public static string Employee_Email(string Employee_number, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", Employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Employee_Email", "varchar2", al).ToString();
        }

        public static string Employee_Name(string Employee_number, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", Employee_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Employee_Name", "varchar2", al).ToString();
        }

        public static DataTable Salutation(string session_id_, string account_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number__", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard.GetSalutation", al);


            //string strSQL = "select t.salutation from salutation t";
            //return SQLStatic.SQL.ExecTable(strSQL);
        }

        public static bool ShowPayPeriod(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.ShowPayPeriod", "varchar2", al).ToString().Equals("1");
        }

        public static bool ShowDepartment(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.ShowDepartment", "varchar2", al).ToString().Equals("1");
        }

        public static bool CanEditCleintNo(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.CanEditCleintNo", "number", al).ToString().Equals("1");
        }

        public static bool ShowAdditionalInfoPage(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.ShowAdditionalInfoPage", "varchar2", al).ToString().Equals("1");
        }

        public static bool AllowCreationOfEnrollmentKit(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.AllowCreationOfEnrollmentKit", "varchar2", al).ToString().Equals("1");
        }

        public static bool CanEditPending(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.CanEditPending", "varchar2", al).ToString().Equals("1");
        }

        public static DataTable GetClassGrouping(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetClassGrouping", al);
        }

        public static DataTable Get_Class_Code_List2(string account_number, string processing_year)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_list", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Employee_Info.Get_Class_Code_List2", al);
        }

        public static void ApprovePending(string session_id, string pend_employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pend_employee_number_", "in", "varchar2", pend_employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure(" pkg_newhirewizard2.ApprovePending", al);
        }

        public static void DisapprovePending(string session_id, string pend_employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pend_employee_number_", "in", "varchar2", pend_employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure(" pkg_newhirewizard.DisapprovePending", al);
        }

        public static string pg_id(string url)
        {
            return SQLStatic.SQL.ExecScaler("select replace(pkg_web.get_popup_pr_id('" + url + "'),'PR-','') from dual").ToString();
        }

        public static void RemoveInComplete(string session_id, string pend_employee_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pend_employee_number_", "in", "varchar2", pend_employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure(" pkg_newhirewizard2.RemoveInComplete", al);
        }

        public static DataTable get_department_code(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.get_department_code", al);
        }

        public static string Current_Processing_Year(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_accounts_data_out.Current_Processing_Year", "varchar2", al).ToString();
        }

        public static string Last_Date_In_Processing_Year(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Last_Date_In_Processing_Year", "varchar2", al).ToString();
        }

        public static string SSN_Exists_Check_EE(string SSN, string account_number, string session_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ssn_", "in", "varchar2", SSN));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.SSN_Exists_Check_EE", "varchar2", al).ToString();
        }

        public static DataTable LocationsList(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.LocationsList", al);
        }

        public static string LocationsCount(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.LocationsCount", "number", al).ToString();
        }

        public static string CanHaveClass(string account_number, string class_code, string HireDate)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("HireDate_", "in", "date", HireDate));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.CanHaveClass", "varchar2", al).ToString();
        }

        public static string Default_Email_Domain_from_acct(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Default_Email_Domain_from_acct", "varchar2", al).ToString();
        }


        public static string Get_er_property_accnt(string account_number,string code, string default_value)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            string strResult = SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
            if (string.IsNullOrEmpty(strResult))
                return default_value;
            else
                return strResult;
        }


        public static string Get_er_property_master_accnt(string account_number, string code, string default_value)
        {
            ArrayList al = new ArrayList(2);
            account_number = account_number.Substring(0,7)+"-0000-000";
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            string strResult = SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", al).ToString();
            if (string.IsNullOrEmpty(strResult))
                return default_value;
            else
                return strResult;
        }

        public static string maxDaysForHireDate(string account_number, string user_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "number", user_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.maxDaysForHireDate", "number", al).ToString();
        }

        public static string minDaysForHireDate(string account_number, string user_id)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "number", user_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.minDaysForHireDate", "number", al).ToString();
        }

        public static string App_form_approved_Accnt(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_er_oe_package.App_form_approved_Accnt", "number", al).ToString();
        }

        public static string account_allow_duplicate_ssn(string session_id_,string account_number, string ssno)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ssno_", "in", "varchar2", ssno));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.account_allow_duplicate_ssn", "number", al).ToString();
        }


        public static string AccountsListSameSSN(string account_number, string ssno)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("ssno_", "in", "varchar2", ssno));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.AccountsListSameSSN", "varchar2", al).ToString();
        }

        public static DataTable Get_ErWorkgroups(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.Get_ErWorkgroups", al);
        }

        public static DataTable Get_ERLocations(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.Get_ERLocations", al);
        }

        public static DataTable Get_ERDivisions(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.Get_ERDivisions", al);
        }

        public static bool account_has_company_id(string account_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            return !SQLStatic.StoredProcedure.ExecuteFunction("Pkg_Pay_Vendor.account_has_company_id", "number", al).ToString().Equals(0);
        }

        public static DataTable get_payroll_co_id(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_pay_vendor.get_payroll_co_id", al);
        }

        public static bool Get_expose_company_id(string account_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            return !SQLStatic.StoredProcedure.ExecuteFunction("Pkg_Pay_Vendor.Get_expose_company_id", "number", al).ToString().Equals(0);
        }

        public static void save_EE_exposed_company_id(string account_number_,string employee_number_,string value_, string user_name_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_pay_vendor.save_EE_exposed_company_id", al);
        }

        public static string Get_EE_exposed_company_id(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("Pkg_Pay_Vendor.Get_EE_exposed_company_id_NH", "number", al).ToString();
        }

        public static string RequireVerification(string account_number, string pend_employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("pend_employee_number_", "in", "varchar2", pend_employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard.RequireVerification", "number", al).ToString();
        }

        public static void add_update_ee_property(string employee_number_, string code_, string value_, string user_id_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("value_", "in", "varchar2", value_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_employee_2.add_update_ee_property", al);
        }

        public static string Requires_FTE_HRS(string account_number, string class_code_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Requires_FTE_HRS", "number", al).ToString();
        }

        public static string Requires_FTE_HRS(string employee_number_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Requires_FTE_HRS", "number", al).ToString();
        }

        public static void Save_FTE_HRS(string account_number_, string employee_number_, string begin_date_, string scheduled_hours_,string fte_hours_,
            string user_name_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("begin_date_", "in", "date", begin_date_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("scheduled_hours_", "in", "varchar2", scheduled_hours_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("fte_hours_", "in", "varchar2", fte_hours_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_newhirewizard2.Save_FTE_HRS", al,conn);
        }

        public static string master_account_property_accnt(string account_number, string code)
        {
            
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.master_account_property_accnt", "varchar2", al).ToString();
        }

        public static DataTable Get_Workers_Comp_Class(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.Get_Workers_Comp_Class", al);
        }

        public static string GetConfirmationTextSetup(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.GetConfirmationTextSetup", "varchar2", al).ToString();
        }

        public static bool ShowJobTitleDDL(string account_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_newhirewizard2.Job_title_count", "varchar2", al).ToString().Equals("0");
        }

        public static DataTable Job_title_list(string account_number)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.Job_title_list", al);
        }

        public static DataTable GetClassGroupingPy(string account_number, string processing_year_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_newhirewizard2.GetClassGroupingPy", al);
        }
    }
}
