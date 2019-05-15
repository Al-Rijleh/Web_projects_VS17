using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Dependents_Maintenance
{
    public partial class Declaration_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "EMPLOYEE_NUMBER", conn);
                ViewState["Processing_Year"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PROCESSING_YEAR", conn);
                if (!Data.Employee_has_Email(ViewState["Employee_Number"].ToString(), conn))
                    btnClose.Visible = false;
                GetDocLocations(conn);
                conn.Close();
                conn.Dispose();
                ViewState["User_Name"] = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
                lblMessage.Text = Data.Declaration_Form_Send_Process(ViewState["Employee_Number"].ToString());                
            }
            
            process_Commands();

        }

        private void process_Commands()
        {
            if (hidCommand.Value == "Show")
            {
                hidCommand.Value = "";
                lblMessage.Visible = false;
                btnClose.Visible = false;

                lblEnterEmaail.Visible = true;
                txtEmail.Visible = true;
                RegularExpressionValidator1.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
                btnSaveEntrEmail.Visible = true;
                btnCloseEmail.Visible = true;
            }

            if (hidCommand.Value == "MarkDoc")
            {
                hidCommand.Value = "";
                SaveEmployeeViewedDoc();
            }
        }

        private void GetDocLocations(Oracle.DataAccess.Client.OracleConnection conn)
        {
            DataTable tbl = Data.Get_Declation_Document_Location(ViewState["Employee_Number"].ToString(), conn);
            hidFileLocation.Value = tbl.Rows[0]["send_doc_url"].ToString();
            ViewState["Send_Doc"] = tbl.Rows[0]["send_doc"].ToString();
        }

        protected void btnCloseEmail_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = true;
            btnClose.Visible = true;

            lblEnterEmaail.Visible = false;
            txtEmail.Visible = false;
            RegularExpressionValidator1.Enabled = false;
            RequiredFieldValidator1.Enabled = false;
            btnSaveEntrEmail.Visible = false;
            btnCloseEmail.Visible = false;
        }

        protected void btnSaveEntrEmail_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            Data.Save_Employee_Email(ViewState["Employee_Number"].ToString(), txtEmail.Text, ViewState["User_Name"].ToString());
            lblMessage.Text = Data.Declaration_Form_Send_Process(ViewState["Employee_Number"].ToString());
            btnCloseEmail_Click(null, null);
        }

        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();

            return ImageData; //return the byte data
        }

        private void SaveEmployeeViewedDoc()
        {
            byte[] bTheData;
            bTheData = StreamFile(ViewState["Send_Doc"].ToString());
            Data.Save_Employee_Viewed_Doc(ViewState["Employee_Number"].ToString(), ViewState["User_Name"].ToString(), bTheData);
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            byte[] bTheData;
            bTheData = StreamFile(ViewState["Send_Doc"].ToString());
            Data.Send_Email_Doc(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), ViewState["User_Name"].ToString(), bTheData);            
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }
    }
}
