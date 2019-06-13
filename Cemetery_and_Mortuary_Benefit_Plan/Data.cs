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

namespace Cemetery_and_Mortuary_Benefit_Plan
{
    public class Data
    {
        public static string GetFuneralClob(string class_code, String employee_number)
        {
            DataTable tbl = null;
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("class_code_", "in", "varchar2", class_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_enrollment_wizard.GetFuneralClob", al);

            return tbl.Rows[0][0].ToString();


            //string strSQL = "select t.page_display_value_override from er_enrollwiz_textitems t where t.account_number = '0007208-0000-000' and t.enrollment_type = 0 and t.class_code ='" + class_code + "'";
            //return SQLStatic.SQL.ExecScaler(strSQL).ToString();
        }

        public static string ee_Class_Code(string employee_number, string processing_year)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_class_code.ee_Class_Code", "varchar2", al).ToString();
        }

        public static string ShowFunralBenefitPage(string account_number, string employee_number, string processing_year)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard.ShowFunralBenefitPage", "number", al).ToString();
        }
    }
}