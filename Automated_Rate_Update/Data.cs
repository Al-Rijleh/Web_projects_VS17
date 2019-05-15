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

namespace Automated_Rate_Update
{
    public class Data
    {
        public static DataTable GetTable(string account_number, string batch, string rate_renewal)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_", "in", "varchar2", rate_renewal));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.getnewestrateversion", ar);
        }

        public static string Get_processing_year(string account_number)
        {
            return SQLStatic.SQL.ExecScaler("select  max(processing_year) from erprocessingyears where account_number='" + account_number + "'").ToString();
        }

        public static int DaysInMonth(string mon, string day, string year)
        {
            DateTime dateTime = Convert.ToDateTime(mon + "/" + day + "/" + year);
            TimeSpan ts = (dateTime.AddMonths(1) - dateTime);
            return ts.Days;
        }

        public static void Save_cvrg(string record_id,string account_number, string class_code, string Categorycode, string Nameofmedicalplan,
            string Insurername, string Policynumber, string Originaleffdate, string RateRenewalMonth, string RateRenewalDay, string Hmo,
            string Issued_state, string user_id, string selef_insured)
        {
            ArrayList al = new ArrayList(12);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", Categorycode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("long_desc_", "in", "varchar2", Nameofmedicalplan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("insurer_name_", "in", "varchar2", Insurername));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("policy_number_", "in", "varchar2", Policynumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", Originaleffdate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_month_", "in", "varchar2", RateRenewalMonth ));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_day_", "in", "varchar2", RateRenewalDay));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("hmo_benefit_", "in", "varchar2", Hmo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("issued_state_", "in", "varchar2", Issued_state));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("selef_insured_", "in", "number", selef_insured));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Save_cvrg", al);
        }


        public static void remove(string account_number, string class_code, string Nameofmedicalplan,string Processing_Year, string strBatch)
        {
            ArrayList al = new ArrayList(4);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("long_desc_", "in", "varchar2", Nameofmedicalplan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));            
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Processing_Year", "in", "varchar2", Processing_Year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", strBatch));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.remove", al);
        }

        public static void reactivate(string account_number, string class_code, string Nameofmedicalplan, string Processing_Year, string strBatch)
        {
            ArrayList al = new ArrayList(4);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("long_desc_", "in", "varchar2", Nameofmedicalplan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Processing_Year", "in", "varchar2", Processing_Year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", strBatch));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.reactivate", al);
        }

        public static DataTable Default_EffectiveDate(string Record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("Record_id_", "in", "varchar2", Record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Default_EffectiveDate", ar);
        }

        public static DataTable Default_EffectiveDate_2(string account_number, string rate_renewal_date, string processing_year)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_date_+", "in", "varchar2", rate_renewal_date));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Default_EffectiveDate_2", ar);
        }

        public static DataTable EfectiveDateList(string account_number)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.EfectiveDateList", ar);
        }

        public static void finalize(string account_number, string effective_date, string user_id,string processing_year, string strBatch)
        {
            ArrayList al = new ArrayList(3);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", effective_date));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", strBatch));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.finalize", al);
        }

        public static string BeginingOfNextMonth()
        {
            return SQLStatic.SQL.ExecScaler("select replace(to_char(add_months(sysdate,1),'mm/dd/yyyy'),'/'||to_char(add_months(sysdate,1),'dd')||'/','/01/') from dual").ToString();
        }

        public static string user_name_from_email(string email)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("email_", "in", "varchar2", email));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.user_name_from_email", "varchar2", ar).ToString();
        }

        public static DataTable processedby(string account_number, string batch)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.processedby", ar);
        }

        public static DataTable get_parameters(string record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.get_parameters", ar);
        }

        public static DataTable Class_list(string record_id,string category_code)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Class_list", ar);
        }

        public static string Cvrg_Count(string account_number, string batch, string category_code)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Cvrg_Count", "number", ar).ToString();
        }

        public static DataTable Get_In_OE(string account_number, string batch)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Get_In_OE", ar);
        }


        public static void Save_Comments(string message, string account_number, string Batch_id)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("message_", "in", "varchar2", message));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", Batch_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Save_Comments", ar);
        }

        public static string Get_Comments(string account_number, string Batch_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", Batch_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Get_Comments", "varchar2", ar).ToString();
        }

        public static DataTable GetAccountEntries(string account_number)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetAccountEntries", ar);
        }

        public static DataTable Class_list2(string account_number, string processing_year, string category_code)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));           
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Class_list2", ar);
        }

        public static void Save_cvrg_2(string processing_year,string batch_id, string account_number, string class_code, string Categorycode, string Nameofmedicalplan,
            string Insurername, string Policynumber, string Originaleffdate, string RateRenewalMonth, string RateRenewalDay, string Hmo,
            string Issued_state, string user_id, string selef_insured)
        {
            ArrayList al = new ArrayList(12);
           
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", Categorycode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("long_desc_", "in", "varchar2", Nameofmedicalplan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("insurer_name_", "in", "varchar2", Insurername));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("policy_number_", "in", "varchar2", Policynumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", Originaleffdate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_month_", "in", "varchar2", RateRenewalMonth));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_day_", "in", "varchar2", RateRenewalDay));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("hmo_benefit_", "in", "varchar2", Hmo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("issued_state_", "in", "varchar2", Issued_state));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("selef_insured_", "in", "number", selef_insured));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Save_cvrg_2", al);
        }

        public static void Reset(string batch_id, string account_number)
        {
            ArrayList al = new ArrayList(2);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Reset", al);
        }

        public static DataTable Get_Accounts_List(string status)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("status_", "in", "varchar2", status));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Get_Accounts_List", ar);
        }

        public static DataTable GetClasses(string account_number_, string processing_year_, string rate_renewal_, string user_name_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_", "in", "varchar2", rate_renewal_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetClasses", ar);
        }


        public static DataTable GetPlanTypes(string account_number_, string version_number_, string calss_code_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetPlanTypes", ar);
        }

        public static DataTable GetCoverages(string account_number_, string version_number_, string calss_code_, string category_code_, string batch_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetCoverages", ar);
        }

        public static DataTable GetRates(string account_number_, string version_number_, string calss_code_
            , string category_code_, string category_plan_, string processing_year, string batch_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year", "in", "varchar2", processing_year));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetRates", ar);
        }

        public static DataTable GetRatesFrmRateTbl(string account_number_, string version_number_, string calss_code_
            , string category_code_, string category_plan_, string processing_year)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year", "in", "varchar2", processing_year));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetRatesFrmRateTbl", ar);
        }

        public static DataTable GetRatesForEdit(string account_number_, string version_number_, string calss_code_, string category_code_, string category_plan_,
            string processing_year_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetRatesForEdit", ar);
        }

        public static void SaveRate_ver1(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
            string family_status_, string processing_year_, string batch_, string rates_, string age_selected_code_, string TobacoRate_, string user_name_,
            string long_description_,string age_rate_desc_,string column_id_,  Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_", "in", "varchar2", family_status_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", batch_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rates_", "in", "varchar2", rates_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_selected_code_", "in", "varchar2", age_selected_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("TobacoRate_", "in", "varchar2", TobacoRate_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("long_description_", "in", "varchar2", long_description_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_rate_desc_", "in", "varchar2", age_rate_desc_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("column_id_", "in", "varchar2", column_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.SaveRate_ver1", ar,conn);
        }

        public static void Save_In_OE(string account_number_, string processing_year_,string in_open_enrollment_, string category_code_, string category_plan_,
             string class_code_, string batch_id_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(7);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("in_open_enrollment_", "in", "varchar2", in_open_enrollment_));            
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            if (conn!=null)
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Save_In_OE", ar, conn);
            else
                SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Save_In_OE", ar);
        }


        public static string Cvrg_in_OE(string account_number_, string processing_year_,  string category_code_, string category_plan_,
             string class_code_, string batch_id_)
        {
            ArrayList ar = new ArrayList(7);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Cvrg_in_OE", "number", ar).ToString();
        }

        public static string Replace_coverage(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
            string processing_year_, string batch_,string new_rate_type_,  Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", batch_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("new_rate_type_", "in", "varchar2", new_rate_type_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("new_catPlan_", "out", "varchar2", ""));
            ArrayList al = SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Replace_coverage", ar, conn);
            string[] str = al[0].ToString().Split('=');
            return str[1];
        }

        public static string GetRateType(string account_number_, string version_number_, string calss_code_
            , string category_code_, string category_plan_, string processing_year)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year", "in", "varchar2", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.GetRateType","number", ar).ToString();
        }

        public static DataTable  Family_Status_List(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
            string processing_year_, string batch_)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", batch_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Family_Status_List", ar);
        }

        public static DataTable Get_Rate_Method()
        {
            ArrayList ar = new ArrayList(2);        
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Get_Rate_Method", ar);
        }

        public static void remove_ver1(string account_number, string class_code, string Nameofmedicalplan,
            string category_code_, string category_plan_, string Processing_Year, string strBatch)
        {
            ArrayList al = new ArrayList(7);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("long_desc_", "in", "varchar2", Nameofmedicalplan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("Processing_Year", "in", "varchar2", Processing_Year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", strBatch));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.remove_ver1", al);
        }

        public static string GetHelpText()
        {
            return SQLStatic.SQL.ExecScaler("select t.description from bas_system t where t.code = 'AUTOMATED_RATE_UPDATE_HELP'").ToString();
        }

        //public static void UpdateRates(string account_number, string user_id_, string Processing_Year, string strBatch, Oracle.DataAccess.Client.OracleConnection conn)
        //{
        //    ArrayList al = new ArrayList(7);

        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id_));
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("Processing_Year", "in", "varchar2", Processing_Year));
        //    al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", strBatch));
        //    SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.UpdateRates", al,conn);
        //}


        public static void UpdateRates_One_Cvrg(string account_number, string cvrg_rec_, string strBatch, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(7);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_rec_", "in", "varchar2", cvrg_rec_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));            
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", strBatch));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.UpdateRates_One_Cvrg", al, conn);
        }

        public static DataTable Family_Status_Generic(string session_id_, string account_number_, string cvrg_id_, string class_code_, string category_code_, string category_plan_,
           string processing_year_)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", cvrg_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Family_Status_Generic", ar);
        }

        public static void SaveRate_ver2(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
            string family_status_, string processing_year_, string batch_, string rates_, string age_selected_code_, string TobacoRate_, string user_name_,
            string long_description_, string age_rate_desc_,  string column_id_, string ratetype_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_", "in", "varchar2", family_status_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", batch_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rates_", "in", "varchar2", rates_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_selected_code_", "in", "varchar2", age_selected_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("TobacoRate_", "in", "varchar2", TobacoRate_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("long_description_", "in", "varchar2", long_description_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_rate_desc_", "in", "varchar2", age_rate_desc_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("column_id_", "in", "varchar2", column_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("ratetype_", "in", "varchar2", ratetype_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.SaveRate_ver2", ar, conn);
        }

        public static void add_formulas_for_COBRA_Setup(string account_number, string coverage_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", coverage_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.add_formulas_for_COBRA_Setup", al, conn);
        }

        public static string user_name_from_id(string id)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("id_", "in", "varchar2", id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.user_name_from_id", "varchar2", ar).ToString();
        }

        public static void DeteteRates(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_, 
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.DeteteRates", ar, conn);
        }

        public static DataTable MetalTires()
        {
            ArrayList ar = new ArrayList(1);            
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.MetalTires", ar);
        }

        public static DataTable MetalCoveragesList(string metal_tier_, string batch_id)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("metal_tier_", "in", "varchar2", metal_tier_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id", "in", "date", batch_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.MetalCoveragesList", ar);
        }

        public static DataTable MetalRatesList(string record_id_, string effective_date_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", effective_date_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.MetalRatesList", ar);
        }

        public static void Save_Metal_cvrg(string processing_year, string batch_id, string account_number, string class_code, string Categorycode, string Nameofmedicalplan,
            string Insurername, string Policynumber, string Originaleffdate, string RateRenewalMonth, string RateRenewalDay, string Hmo,
            string Issued_state, string user_id, string selef_insured,string batch_, string cvrg_id, string in_open_enrollment_)
        {
            ArrayList al = new ArrayList(12);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", Categorycode));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("long_desc_", "in", "varchar2", Nameofmedicalplan));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("insurer_name_", "in", "varchar2", Insurername));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("policy_number_", "in", "varchar2", Policynumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", Originaleffdate));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_month_", "in", "varchar2", RateRenewalMonth));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_day_", "in", "varchar2", RateRenewalDay));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("hmo_benefit_", "in", "varchar2", Hmo));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", user_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("issued_state_", "in", "varchar2", Issued_state));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("selef_insured_", "in", "number", selef_insured));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", batch_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "number", cvrg_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("in_open_enrollment_", "in", "varchar2", in_open_enrollment_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Save_Metal_cvrg", al);
        }

        public static DataTable Terminated_accounts(string RenewalDate_)
        {
            string rate_renewal_date_ = string.Empty;
            string origRenewalDate_ = RenewalDate_;
            if (RenewalDate_.StartsWith("Processed Manually"))
            {
                RenewalDate_ = "Processed Manually";
                rate_renewal_date_ = origRenewalDate_.Replace(RenewalDate_,"").Trim();
            }
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("RenewalDate_", "in", "varchar2", RenewalDate_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_date_", "in", "varchar2", rate_renewal_date_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Terminated_accounts", ar);
        }

        public static string Check_Account(string account_number_)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Check_Account", "varchar2", ar).ToString();
        }

        public static void Do_Terminate_Account(string account_number_, string user_name_, string rate_renewal_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_", "in", "varchar2", rate_renewal_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.Do_Terminate_Account", ar);
        }

        public static DataTable SendReminder(string month__)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("month__", "in", "varchar2", month__));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.SendReminder", ar);
        }

        public static void remove_from_v_automatedt_skip_(string record_id_)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.remove_from_v_automatedt_skip_", ar);
        }

        public static DataTable Send_Initial_email_to_all(string month__)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("month__", "in", "varchar2", month__));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Send_Initial_email_to_all", ar);
        }

        public static DataTable WillReciveReminder(string month__)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("month__", "in", "varchar2", month__));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.WillReciveReminder", ar);
        }


        public static DataTable WillReciveInital(string month__)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("month__", "in", "varchar2", month__));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.WillReciveInital", ar);
        }

        public static DataTable GetMetalCoverageRow(string category_plan_, string year_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("year_", "in", "varchar2", year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetMetalCoverageRow", ar);
        }

        public static void UpdateOneMetalCoverage(string account_number_,string processing_year_, string category_plan_,string class_code_, 
            string batch_id_,string in_open_enrollment_, string user_name_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("in_open_enrollment_", "in", "varchar2", in_open_enrollment_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.UpdateOneMetalCoverage", ar);
        }

        public static void SetFrameHeader(Page wPage, string strAccountNumber, string strURL)
        {
            string strAccountName = "";
            if ((strAccountNumber != "null") && (strAccountNumber != ""))
                strAccountName = "Account: " + strAccountNumber + " - " + SQLStatic.AccountData.AccountName(strAccountNumber);
            string strHeader = "<script language='javascript'>" + "window.open('/web_projects/ptemplate/header.aspx?callingurl=" + strURL + "&2nd=" + strAccountName + "','" + Template.BASPtemplate.HeaderFrameName + "');</Script>";
            wPage.ClientScript.RegisterStartupScript(wPage.GetType(), "strHeader", strHeader);
        }

        public static void UpdateOneRateMetalCoverage(string account_number_, string category_plan_, string batch_id_,string version_number_, string user_name_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.UpdateOneRateMetalCoverage", ar);
        }

        public static DataTable GetPendingCoverages(string account_number_, string processing_year_, string batch_id_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetPendingCoverages", ar);
        }

        public static void remove(string id)
        {
            string strSQL = "delete from auto_pend_coverages where record_id = " + id;
            SQLStatic.SQL.ExecNonQuery(strSQL);
        }

        public static string Category_Plan_Exist(string batch, string category_plan_ )
        {
            ArrayList ar = new ArrayList(2);            
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", category_plan_));
            
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Category_Plan_Exist","varchar2", ar).ToString();
        }

        public static DataTable Get_Class_Code_List(string account_number, string processing_year_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("class_list", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_class_code.Get_Class_Code_List", ar);
        }

        public static DataTable GeteAllCoverage(string account_number, string processing_year_, string category_code_, string rate_renewal_, string batch_id_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rate_renewal_", "in", "varchar2", rate_renewal_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GeteAllCoverage", ar);
        }

        public static DataTable GetCoverageDetail(string cvrg_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_id_", "in", "varchar2", cvrg_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetCoverageDetail", ar);
        }

        public static DataTable RateStatus(string account_number_, string version_number_, string calss_code_
            , string category_code_, string category_plan_, string processing_year, string batch_id_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", calss_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year", "in", "varchar2", processing_year));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.RateStatus", ar);
        }

        public static string hasCoverage(string account_number, string batch, string category_code)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number", "in", "varchar2", account_number));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.hasCoverage", "number", ar).ToString();
        }

    }
}
