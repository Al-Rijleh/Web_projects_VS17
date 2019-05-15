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

namespace PLA_Report
{
	public class Data
	{
		public static string ConnectioString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		
		public static DataTable FillData(string strRecord_id)
		{			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.GetHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_", strRecord_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];								
			}
			finally
			{
				cmd.Dispose();
				mds.Dispose();	
				conn.Close();
				conn.Dispose();
						
			}
			return tbl;
		}

		public static DataTable employee_info(string strHeader_id)
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_employee_3.ee_info_for_pla_report",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", strHeader_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			string strPY = "";
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];								
			}
			finally
			{
				cmd.Dispose();
				mds.Dispose();	
				conn.Close();
				conn.Dispose();
						
			}
			return tbl;
		}

		public static DataTable FillDataDateTimes(string strRecord_id)
		{

			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.gettrainingcoursedatetimerec", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", strRecord_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_3_record", "cursor", "out", "");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl = null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl = mds.Tables[0];				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();				
			}
			return tbl;
		}

		public static bool Use2008Types_Needs(string header_record_id)
		{
			return SQLStatic.SQL.ExecScaler(
				"select  pkg_training_3.use2008typeneeds(" + header_record_id + ") from dual",
				PLA_Report.Data.ConnectioString).ToString() == "1";
		}

		public static DataTable FillDataTypesNeeds(string strRecord_id)
		{

			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.TrainingTypesNeedsRecordDesc", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", strRecord_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_4_record", "cursor", "out", "");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl = null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl = mds.Tables[0];				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();				
			}
			return tbl;
		}

		public static DataTable GetExpenseTable(string strRecord_id)
		{
			DataTable tbl = null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetEmployeeExpenses", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", strRecord_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Expenses_List_", "cursor", "out", "");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl = mds.Tables[0];
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
			}
			return tbl;
		}

		public static string GetTotalExpense(string strRecord_id)
		{
			string strSQL = "select pkg_training.calctotalrequestexpense(" + strRecord_id + ") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL, PLA_Report.Data.ConnectioString).ToString();
			if (strResult == "")
				strResult = "0";
			return string.Format("{0:c}", Convert.ToDouble(strResult));
		}

		public static double TotalApprovedFromDatabase(string strRecord_id)
		{
			string strSQL = "select pkg_training.CalcTotalApprovedAmount(" + strRecord_id + ") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL, PLA_Report.Data.ConnectioString).ToString();
			if (strResult == "")
				strResult = "0";
			return Convert.ToDouble(strResult);		
		}

		public static double TotalPaidFromDatabase(string strRecord_id)
		{
			string strSQL = "select pkg_training.CalcTotalPaidAmount(" + strRecord_id + ") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL, PLA_Report.Data.ConnectioString).ToString();
			if (strResult == "")
				strResult = "0";
			return Convert.ToDouble(strResult);			
		}

		public static DataTable GetHistoryTable(string strRecord_id)
		{
			DataTable tbl = null;
			string strProcedureName = "BASDBA.pkg_training.History_List";
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName, conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", strRecord_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "hstList_", "cursor", "out", "");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl = mds.Tables[0];
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
			}
			return tbl;
		}

		public static DataTable FillDataTypesNeeds2007(string strRecord_id)
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Report.Data.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.trntypesneedsrecorddesc2007", conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", strRecord_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_4_record", "cursor", "out", "");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl = null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl = mds.Tables[0];				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();				
			}
			return tbl;
		}

        public static DataTable Get_HeaderRequest(string employee_number_)
        {
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", employee_number_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("PKG_TRAINING.Get_HeaderRequest", al);
        }

        public static string employee_number_from_Record_id(string record_id_)
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("account_number", "in", "varchar2", record_id_));
            return SQLStatic.StoredProcedure.ExecuteFunction("pkg_training.employee_number_from_Record_id", "varchar2", al).ToString();
        }
	}
}
