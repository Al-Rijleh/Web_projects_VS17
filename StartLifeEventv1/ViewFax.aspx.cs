using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Telerik.Reporting;
using Telerik.Reporting.Processing;
using System.IO;

namespace StartLifeEventv1
{
    public partial class ViewFax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string employee_number =SQLStatic.Sessions.GetEmployeeNumber(HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString());
            string id = SQLStatic.Sessions.GetSessionValue(HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString(), "LE_EE_ID");
            while (id == null)
                id = SQLStatic.Sessions.GetSessionValue(HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString(), "LE_EE_ID");

            GetLifeFax.Report1 reportx = new GetLifeFax.Report1();
            reportx.Process(Request.Params["DpNo"]);

            string filename = SaveToDatabase(GenerateReportByteArray(reportx),id);

            
            string emails = SQLStatic.Sessions.GetSessionValue(HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString(), "EMAIL");
            string[] email = emails.Split('~');
            for (int i = 0; i < email.Length; i++)
            {
                string s = email[i];
                if (s.Equals(" "))
                    s = string.Empty;
                if (!string.IsNullOrEmpty(s))
                    Data.SendFaxEmail(employee_number, s, filename);
            }

            string code = SQLStatic.Sessions.GetSessionValue(HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString(), "CODE");
            string strClose = string.Empty;
            if (code.Substring(0, 1).Equals("1"))
                ReportViewer1.Report = reportx;
            else
                strClose = "<script>Javescript:closewin()</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);

               
        }

        private void Send_email(string s)
        {
            
        }

        private byte[] GenerateReportByteArray(GetLifeFax.Report1 report)
        {
            InstanceReportSource instanceReportSource = new InstanceReportSource();

            instanceReportSource.ReportDocument = report;

            ReportProcessor reportProcessor = new ReportProcessor();
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            //reportToExport.Dispose();

            return result.DocumentBytes;
        }

        private string SaveToDatabase(byte[] btReport,string id)
        {
            // Write to J Drive
            string filepath = "";
            string timestamp = DateTime.Now.ToString("MMddHHmmssfff");
            string filename = "fax" + id +"_"+ timestamp + ".pdf";
            string credentials = Data.getJCredential();
            String[] credentialsArray = credentials.Split("|".ToCharArray());
            string COMPUTER_IP = credentialsArray[0].ToString().Split(':')[1];
            string DOMAIN = credentialsArray[1].ToString().Split(':')[1];
            string USER_NAME = credentialsArray[2].ToString().Split(':')[1];
            string PASSWORD = credentialsArray[3].ToString().Split(':')[1];
            try
            {
                
                using (NetworkShareAccesser.Access(COMPUTER_IP, DOMAIN, USER_NAME, PASSWORD))
                {
                    filepath = "\\\\" + COMPUTER_IP + "\\j_drive\\Clients\\LifeEvent\\" + filename;

                    File.WriteAllBytes(filepath, btReport);

                    filepath = filepath.Replace("\\\\" + COMPUTER_IP + "\\j_drive\\", "J:\\");

                }
            }
             catch
            {
            }
            // Save to Database
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_Enrollment_Wizard_LE.SaveFaxImage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "doc_record_id", Request.Params["DpNo"]);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_", SQLStatic.Sessions.GetUserName(HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString()));
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
            return filename; 
        }

        private void SaveToDatabase2(byte[] btReport)
        {
            // SQLStatic.SQL.ExecScaler("select max(record_id) from ee_dependent_verify_docs v where v.dep_pending_id = " + Request.Params["DpNo"]).ToString();

            //string reccord_id = Data.newFaxDocRecordID(Request.Params["DpNo"]);

            //if (reccord_id.Equals("-1"))
            //    return;

            //SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "reprt", reccord_id);

            //SQLStatic.Sessions.SetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "reprt", btReport);

            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_Dependents_Audit.SaveFaxImage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "doc_record_id", Request.Params["DpNo"]);
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

        }
    }
}