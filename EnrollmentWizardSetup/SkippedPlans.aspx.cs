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

namespace EnrollmentWizardSetup
{
    public partial class SkippedPlans : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {
                FillClassCode();
            }
            DrawGrid();
        }

        private void FillClassCode()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                string strAccountNumber = SQLStatic.Sessions.GetSessionValue(session_id, "Account_Number", conn);
                string strProcessing_year = Data.open_nrollment_Processing_year(strAccountNumber, conn);
                DataTable tbl = SQLStatic.AccountData.GetClassCodes(strAccountNumber, strProcessing_year, conn);
                foreach (DataRow dr in tbl.Rows)
                {
                    ListItem li = new ListItem(dr["Description"].ToString(), dr["Class_Code"].ToString());
                    ddlClass.Items.Add(li);
                }
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
        }

        private DataTable GetData()
        {
            RadioButtonList rblOperation_ = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblOperation");
            return Data.GetCoveragesMarkSkip(session_id, "I", rblOperation_.SelectedValue);
        }

        private void DrawGrid()
        {
            DataTable tbl = GetData();
            gvPlans.DataSource = tbl;
            gvPlans.DataBind();
        }

        protected void gvPlans_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvPlans.DataSource;
            if (tbl == null)
                tbl = GetData();
            if (e.Row.RowIndex < 0)
                return;
            if (e.Row.RowIndex > tbl.Rows.Count)
                return;
            try
            {
                string strIndex = tbl.Rows[e.Row.RowIndex]["RECORD_ID"].ToString();
                CheckBox cbl = new CheckBox();
                cbl.ID = "cbl_" + strIndex;
                cbl.Checked = tbl.Rows[e.Row.RowIndex]["SKIP_CVRG"].ToString().Equals("0");
                TableCell cell = e.Row.Cells[1];
                cell.Controls.Add(cbl);
            }
            catch
            {
            }

        }



        protected void btnSave_Click3(object sender, EventArgs e)
        {
            DoSave();
        }

        private void DoSave()
        {
            DataTable tbl = (DataTable)gvPlans.DataSource;
            if (tbl == null)
                tbl = GetData();
            string strIndex = null;
            CheckBox cb = null;
            int DoSkip = 0;

            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            RadioButtonList rblOperation_ = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblOperation");
            try
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    strIndex = dr["RECORD_ID"].ToString();
                    cb = Bas_Utility.Utilities.GetCheckBox(Page, "cbl_" + strIndex);
                    if (cb.Checked)
                        DoSkip = 0;
                    else
                        DoSkip = 1;
                    Data.SaveCoverageSkip(session_id, strIndex, rblSaveType.SelectedValue, DoSkip.ToString(), rblOperation_.SelectedValue, conn);
                }
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGrid();
        }
        

    }   
}
