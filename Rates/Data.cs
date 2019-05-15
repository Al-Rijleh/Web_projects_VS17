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

namespace Rates
{
    public class Data
    {
        public static DataTable GetNewRatesFrmRateTbl(string account_number_, string version_number_, string calss_code_
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
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetNewRatesFrmRateTbl", ar);
        }

        public static void SaveOneErRate(string unique_id_, string NonTobacco_, string Tobacco_, string rate_override1_,
            string user_name_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("unique_id_", "in", "varchar2", unique_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_amount", "in", "varchar2", NonTobacco_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employer_split", "in", "varchar2", Tobacco_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_override1_", "in", "varchar2", rate_override1_));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.SaveOneErRate", al,conn);
        }

        public static DataTable Family_Status_List()
        {
            ArrayList ar = new ArrayList(8);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.Family_Status_List", ar);
        }

        public static DataTable family_status_errate()
        {
            ArrayList ar = new ArrayList(8);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", null));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.family_status_errate", ar);
        }

        public static string Coverage_Rate_methode(string cvr_id_)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("cvr_id_", "in", "varchar2", cvr_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Coverage_Rate_methode","number", ar).ToString();
        }

        public static void addOneRate(string account_number_, string version_number_, string class_code_, string processing_year_, string category_code_, string category_plan_, 
            string family_status_code_,string age_selected_code_, string effective_date_, string add_userid_)
        {
            ArrayList ar = new ArrayList(9);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_code_", "in", "varchar2", family_status_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_selected_code_", "in", "varchar2", age_selected_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", effective_date_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("add_userid_", "in", "varchar2", add_userid_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.addOneRate", ar);
        }

        public static void UpdateOneMetalCoverage(string account_number_, string processing_year_, string category_plan_, string class_code_,
            string batch_id_, string in_open_enrollment_, string user_name_)
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

        public static void UpdateOneRateMetalCoverage(string account_number_, string category_plan_, string batch_id_, string version_number_, string user_name_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.UpdateOneRateMetalCoverage", ar);
        }

        public static DataTable MetalTires()
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.MetalTires", ar);
        }

        public static DataTable MetalRatesList(string record_id_, string effective_date_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("effective_date_", "in", "date", effective_date_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.MetalRatesList", ar);
        }

        public static DataTable MetalCoveragesList(string metal_tier_, string batch_id)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("metal_tier_", "in", "varchar2", metal_tier_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id", "in", "date", batch_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.MetalCoveragesList", ar);
        }

        public static DataTable GetMetalCoverageRow(string category_plan_, string year_)
        {
            ArrayList ar = new ArrayList(3);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("year_", "in", "varchar2", year_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.GetMetalCoverageRow", ar);
        }

        public static DataTable get_parameters(string record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_automated_rate_update.get_parameters", ar);
        }

        public static string Cvrg_in_OE(string account_number_, string processing_year_, string category_code_, string category_plan_,
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

        public static string Category_Plan_Exist(string batch, string category_plan_)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", batch));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_Number_", "in", "varchar2", category_plan_));

            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_automated_rate_update.Category_Plan_Exist", "varchar2", ar).ToString();
        }

        public static DataTable Family_Status_List(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
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

        public static void SaveRate_ver2_tbl(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
            string family_status_, string processing_year_, string batch_, string rates_, string age_selected_code_, string TobacoRate_, string user_name_,
            string long_description_, string age_rate_desc_, string column_id_, string ratetype_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList ar = new ArrayList(12);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("family_status_", "in", "varchar2", family_status_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", processing_year_));           
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("rates_", "in", "varchar2", rates_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_selected_code_", "in", "varchar2", age_selected_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("TobacoRate_", "in", "varchar2", TobacoRate_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("long_description_", "in", "varchar2", long_description_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("age_rate_desc_", "in", "varchar2", age_rate_desc_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("column_id_", "in", "varchar2", column_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.SaveRate_ver2_tbl", ar, conn);
        }

        public static void UpdateRates_One_Cvrg(string account_number, string cvrg_rec_, string strBatch, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(7);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("cvrg_rec_", "in", "varchar2", cvrg_rec_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("batch_id_", "in", "varchar2", strBatch));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.UpdateRates_One_Cvrg", al, conn);
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

        public static void add_formulas_for_COBRA_Setup(string account_number, string coverage_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "varchar2", coverage_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.add_formulas_for_COBRA_Setup", al, conn);
        }

        public static void ResetRateForCoverage(string account_number_, string version_number_, string class_code_, string category_code_, string category_plan_,
             string user_name_)
        {
            ArrayList ar = new ArrayList(6);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("version_number_", "in", "varchar2", version_number_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("calss_code_", "in", "varchar2", class_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_code_", "in", "varchar2", category_code_));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("category_plan_", "in", "varchar2", category_plan_));            
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.ResetRateForCoverage", ar);
        }

        public static void SAVEONEERRATE_OneFS(string unique_id_, string NonTobacco_, string Tobacco_, string rate_override1_,
            string user_name_, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(4);

            al.Add(SQLStatic.StoredProcedure.OneParamerer("unique_id_", "in", "varchar2", unique_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_amount", "in", "varchar2", NonTobacco_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employer_split", "in", "varchar2", Tobacco_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("rate_override1_", "in", "varchar2", rate_override1_));

            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_automated_rate_update.SAVEONEERRATE_OneFS", al, conn);
        }


    }
}