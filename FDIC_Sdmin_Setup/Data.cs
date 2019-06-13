using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

namespace FDIC_Sdmin_Setup
{
    public class Data
    {
        public static DataTable Administrators_List()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_","out","cursor",null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.administrators_list",al);
        }

        public static DataTable get_office_division()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.get_office_division", al);
        }

        public static DataTable get_org_code()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.get_org_code", al);
        }

        public static DataTable get_org_code(string office)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("office_", "in", "varchar2", office));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.get_org_code", al);
        }

        public static void add_fdic_admin_assignments(string employee_number, string office_division, string org_code, string is_primary, string regional_address)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("office_division_", "in", "varchar2", office_division));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("org_code_", "in", "varchar2", org_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("is_primary_", "in", "varchar2", is_primary));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("regional_address_", "in", "varchar2", regional_address));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.add_fdic_admin_assignments", al);
        }

        public static DataTable Get_fdic_admin_assignment_data(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.Get_fdic_admin_assignment_data", al);
        }

        public static DataTable Get_fdic_admin_assignment_data(string employee_number, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            if (conn == null)
                return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.Get_fdic_admin_assignment_data", al);
            else
                return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.Get_fdic_admin_assignment_data", al,conn);
        }

        public static DataTable get_office_division(Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.get_office_division", al,conn);
        }

        public static DataTable get_org_code(Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.get_org_code", al,conn);
        }

        public static void update_admin_assignments(string record_id, string office_division, string org_code, string is_primary, string regional_address,
            Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(5);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", record_id));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("office_division_", "in", "varchar2", office_division));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("org_code_", "in", "varchar2", org_code));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("is_primary_", "in", "varchar2", is_primary));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("regional_address_", "in", "varchar2", regional_address));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.update_admin_assignments", al,conn);
        }

        public static void remove_fdic_one_assignmen(string record_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "number", record_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.remove_fdic_one_assignmen", al, conn);
        }

        public static void remove_fdic_admin_assignmen(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.remove_fdic_admin_assignmen", al);
        }

        public static DataTable Super_Users_List()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.Super_Users_List", al);
        }

        public static void Remove_Super_User(string user_id, Oracle.DataAccess.Client.OracleConnection conn)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_id_", "in", "number", user_id));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.Remove_Super_User", al);
        }

        public static void Add_Super_User(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.Add_Super_User", al);
        }

        public static bool is_super_user(string employee_number)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "number", employee_number));
            return !SQLStatic.StoredProcedure.ExecuteFunction("pkg_training_3.is_super_user", "number", al).ToString().Equals("0");
        }

        public static DataTable Get_fdic_admin_Replacement(string original_record_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("original_record_id_", "in", "varchar2", original_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.Get_fdic_admin_Replacement", al);
        }

        public static void replace_admin(string session_id_, string from_record_id_, string to_record_id_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", session_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("from_record_id_", "in", "number", from_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("to_record_id_", "in", "number", to_record_id_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.replace_admin", al);
        }

        public static DataTable eesAssociatedwithAdmin(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", ""));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.eesAssociatedwithAdmin", al);
        }

        public static DataTable eesAssociatedwithORGCode(string org_code_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("org_code_", "in", "varchar2", org_code_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_", "in", "varchar2", ""));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_3.eesAssociatedwithORGCode", al);
        }
    }
}