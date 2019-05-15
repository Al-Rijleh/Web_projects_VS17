using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using   Oracle.DataAccess.Client;
using Telerik.Reporting;
using Telerik.Reporting.Processing;


namespace DependentAuditDocFax
{
    public partial class ViewFax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string account_number = SQLStatic.Sessions.GetAccountNumber(Request.Cookies["Session_ID"].Value.ToString());
            string employee_number = SQLStatic.Sessions.GetEmployeeNumber(Request.Cookies["Session_ID"].Value.ToString());
            ViewState["EE"] = employee_number;
            account_number = account_number.Substring(0, 7) + "-0000-000";

            string faxtype = "0";

            if (Data.Get_er_property_accnt(account_number, "167").Equals("1"))
                faxtype = "1";

            if (Data.is_employee_in_Dep_Audit(employee_number).Equals("1"))
                faxtype = "2";

            FaxGenerator.Report1 report = new FaxGenerator.Report1();
            string depNo = SQLStatic.Sessions.get_guid(Request.Cookies["Session_ID"].Value.ToString(), "depNo", Request.Params["DpNo"]);

            report.Process(Request.Cookies["Session_ID"].Value.ToString(), faxtype);

            if (account_number.Equals("0000699-0000-000"))
            {
                SaveToDatabase(GenerateReportByteArray(report));
                //SQLStatic.Sessions.SetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Test", GenerateReportByteArray(report));
                Response.Redirect("/web_projects/DependentsAuditGetDocuments/Default.aspx?SkipCheck=YES", true);
                return;
            }
            ReportViewer1.Report = report;
        }

        private byte[] GenerateReportByteArray(FaxGenerator.Report1 report)
        {
            InstanceReportSource instanceReportSource = new InstanceReportSource();
           
            instanceReportSource.ReportDocument = report;
            
            ReportProcessor reportProcessor = new ReportProcessor();
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            //reportToExport.Dispose();

            return result.DocumentBytes;
        }

   private void SaveToDatabase(byte[] btReport)
   {
       // SQLStatic.SQL.ExecScaler("select max(record_id) from ee_dependent_verify_docs v where v.dep_pending_id = " + Request.Params["DpNo"]).ToString();

       string reccord_id = Data.newFaxDocRecordID(Request.Params["DpNo"]);

       if (reccord_id.Equals("-1"))
           return;

       SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"reprt", reccord_id);

       SQLStatic.Sessions.SetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), ViewState["EE"].ToString() + "  " + Request.Params["DpNo"], btReport);

        Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
        try
        {
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_Dependents_Audit.SaveFaxImage",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "doc_record_id", reccord_id);
            Oracle.DataAccess.Client.OracleParameter parm;
            parm = new Oracle.DataAccess.Client.OracleParameter(
                    "value_", Oracle.DataAccess.Client.OracleDbType.Blob, btReport.Length, System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, btReport);
            cmd.Parameters.Add(parm);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
            }
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }





       // Here you save bytes to the database
       //using (OracleConnection con = new OracleConnection(ConnStr))
       //{           
       //  using (OracleCommand cmd = new OracleCommand("PKG_Name.Procedure_Save_PDF", con))
       //  {
       //     con.Open();
       //     try
       //     {
       //        foreach (ReportParameters p in parameters)
       //        {                            
       //          try
       //          {
       //            // GenerateReportByteArray will return byte array for the database
       //            cmd.Parameters.Add("file_blob_", OracleDbType.Blob, ParameterDirection.Input);                                
       //            cmd.Parameters["file_blob_"].Value = btReport;
       //            cmd.ExecuteNonQuery();
       //          }
       //          catch (Exception ex)
       //          {                                
       //            Message = ex.Message;
       //          }
       //     }
       //     Message = "Insert done";
       //  }
       //  catch (Exception ex)
       //  {                        
       //                     Message = ex.Message;
       //  }
       //  finally
       //  {
       //    if (con.State != ConnectionState.Closed) con.Close();                        
       //  }
       //}
     //}
   

    }


   
    }
}