using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Rates
{
    public partial class BuildFSAge : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            #region BasTemplate
            if (!IsPostBack)
            {
                Template.BasTemplate objBasTemplate = new Template.BasTemplate();
                try
                {
                    if (Request.Cookies["Session_ID"] == null)
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", true);
                    string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, false);
                    if (strResult != "")
                    {
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult, false);
                        return;
                    }
                    objBasTemplate.SetSeatchField(0);
                    objBasTemplate.ShowFontSizeSelector = false;
                    objBasTemplate.ShowNotes = false;
                    objBasTemplate.ShowProcessingYear = true;
                    ViewState["AccessType"] = objBasTemplate.strAccessType;
                    ViewState["Employee_Number"] = objBasTemplate.strEmployee_Number;
                    ViewState["Processing_Year"] = objBasTemplate.strProcessingYear;
                    ViewState["Role_Restriction_Level"] = objBasTemplate.strRole_Restriction_Level;
                    ViewState["Selected_Account_Number"] = objBasTemplate.strSelected_Account_Number;
                    ViewState["Selected_Employee_Class_Code"] = objBasTemplate.strSelected_Employee_Class_Code;
                    ViewState["User_Group_ID"] = objBasTemplate.strUser_Group_ID;
                    ViewState["User_ID"] = objBasTemplate.strUser_ID;
                    ViewState["User_Name"] = objBasTemplate.strUser_Name;
                    ViewState["User_Primary_Role"] = objBasTemplate.strUser_Primary_Role;
                }
                catch (Exception ex)
                {
                    string strError = "Error Message: " + ex.Message + "~~Application:" + ex.Source + "~~Method:" + ex.TargetSite + "~~Detail:" + ex.StackTrace;
                    Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strError.Replace("\n", "~"));
                }
                finally
                {
                    objBasTemplate.CleanUp();
                    objBasTemplate.Dispose();
                }
            }
            #endregion

            if (!IsPostBack)
            {

                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    ViewState["Account_number"] = SQLStatic.Sessions.GetSessionValue(session_id, "ACCOUNT_NUMBER", conn);
                    ViewState["Version"] = SQLStatic.Sessions.GetSessionValue(session_id, "Version", conn);
                    ViewState["class_code"] = SQLStatic.Sessions.GetSessionValue(session_id, "class_code", conn);

                    ViewState["category_code"] = SQLStatic.Sessions.GetSessionValue(session_id, "category_code", conn);
                    ViewState["category_plan"] = SQLStatic.Sessions.GetSessionValue(session_id, "category_plan", conn);
                    ViewState["PROCESSING_YEAR"] = SQLStatic.Sessions.GetSessionValue(session_id, "PROCESSING_YEAR", conn);
                }

                finally
                {
                    SQLStatic.SQL.CloseConnection(conn);
                }
                FillFs();
            }
        }

        private void FillFs()
        {
            DataTable tbl = Data.Family_Status_List();
            cblFs.DataSource = tbl;
            cblFs.DataTextField = "description";
            cblFs.DataValueField = "family_status_code";
            cblFs.DataBind();
        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();

            DataColumn col0 = new DataColumn("Family_status");
            DataColumn col1 = new DataColumn("Age_Band");
            DataColumn col2 = new DataColumn("Rate_amount");
            DataColumn col3 = new DataColumn("rate_override1");           
            DataColumn col4 = new DataColumn("AGE_RATE_DESCRIPTION");
            DataColumn col5 = new DataColumn("Er_Rate");
            DataColumn col6 = new DataColumn("EE_Rate");

            col0.DataType = System.Type.GetType("System.String");
            col1.DataType = System.Type.GetType("System.String");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.String");
            col4.DataType = System.Type.GetType("System.String");
            col5.DataType = System.Type.GetType("System.String");
            col6.DataType = System.Type.GetType("System.String");

            table.Columns.Add(col0);
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            table.Columns.Add(col4);
            table.Columns.Add(col5);
            table.Columns.Add(col6);

            Int16 inStart = Convert.ToInt16(txtMinAge.Value);
            Int16 instep = Convert.ToInt16(txtStep.Value);
            Int16 inLast = Convert.ToInt16(txtLastAge.Value);

            foreach (ListItem li in cblFs.Items)
            {
                if (li.Selected)
                {
                    DataRow rowstatus = table.NewRow();
                    rowstatus[col0] = li.Value + " - " + li.Text;
                    rowstatus[col1] = "";
                    rowstatus[col2] = "";
                    table.Rows.Add(rowstatus);

                    DataRow row0 = table.NewRow();
                    row0[col0] = "";
                    row0[col1] = "0 - " + (inStart - 1).ToString();
                    row0[col2] = "";
                    table.Rows.Add(row0);



                    for (int i = inStart; i <= inLast; i += instep)
                    {
                        DataRow row = table.NewRow();
                        if (i.Equals(inLast))
                            row[col1] = i.ToString() + " + ";
                        else
                            row[col1] = i.ToString() + " - " + (i + instep - 1).ToString();
                        row[col2] = "";
                        row[col0] = "";
                        table.Rows.Add(row);
                    }
                }
            }

            return table;
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            DrawGrid();
        }

        private void DrawGrid()
        {
            DataTable tbl = CreateTable();
            gvList.DataSource = tbl;
            gvList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = CreateTable();
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                string last_fs = string.Empty;
                foreach(DataRow dr in tbl.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["Family_status"].ToString()))
                    {
                        if (!dr["Family_status"].ToString().Equals(last_fs))
                            last_fs = dr["Family_status"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["Age_Band"].ToString()))
                    {
                        Data.addOneRate(ViewState["Account_number"].ToString(),
                                        ViewState["Version"].ToString(),
                                        ViewState["class_code"].ToString(),
                                        ViewState["Processing_Year"].ToString(),
                                        ViewState["category_code"].ToString(),
                                        ViewState["category_plan"].ToString(),
                                        last_fs.Substring(0, 3),
                                        dr["Age_Band"].ToString().Substring(0, 2).Replace("-", "").Trim(),
                                        txtEffectiveDate.SelectedDate.Value.ToShortDateString(),
                                        ViewState["User_Name"].ToString());

                    }
                }
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
            Response.Redirect("Default.aspx",true);
        }
    }
}