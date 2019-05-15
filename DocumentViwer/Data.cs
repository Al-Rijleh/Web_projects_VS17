using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;


namespace DocumentViwer
{
    public class Data
    {
        public static string ResolveID(string code)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "varchar2", code));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_on_line_library.resolveid", "number", ar).ToString();
        }


        public static string GenerateID(string record_id)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_on_line_library.GenerateID", "varchar2", ar).ToString();
        }

        public static DataTable GetRetaDocument(string record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_on_line_library.getretadocument", ar);
        }


        public static DataTable GetActualDocument(string record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_on_line_library.GetActualDocument", ar);
        }

        public static string GetActualDocumentSize(string record_id)
        {
            ArrayList ar = new ArrayList(1);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_on_line_library.GetActualDocumentSize", "number", ar).ToString();
        }

        public static DataTable GetActualFacDocument(string record_id)
        {
            ArrayList ar = new ArrayList(2);
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            ar.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.GetActualFacDocument", ar);
        }
    }
}