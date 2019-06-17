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


namespace _0011172_0000_000_Portland
{
    public class Data
    {
        public static DataTable PortlandPayrollDeduction(string employee_number_, string processing_year_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "number", processing_year_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("CR_Dependents_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Enrollment_Wizard_3.PortlandPayrollDeduction", al);
            return tbl;
        }

    }
}