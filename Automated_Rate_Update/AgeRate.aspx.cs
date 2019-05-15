using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Automated_Rate_Update
{
    public partial class AgeRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetUsage();
            }
        }

        private void SetUsage()
        {
            if (Request.Params["action"].Equals("0"))
            {
                tblparamenters.Visible = false;
                DrawGrid();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string strParam = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = "?accnt=" + Request.Params["accnt"] +
                              "&ip=" + Request.Params["batch"].Substring(0, 4) +
                              "&py=" + Request.Params["py"].Substring(0, 4);
            else
                strParam = "?id=" + Request.Params["id"];

            Response.Redirect("Default_2.aspx" + strParam, true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                string strInOPenEE = "0";
                if (cbOe.Checked)
                    strInOPenEE = "1";
                Data.Save_In_OE(Request.Params["accnt"], Request.Params["py"], strInOPenEE, Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["class"], Request.Params["batch"], conn);

                string newCatePlN = Data.Replace_coverage(Request.Params["accnt"],  Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                        Request.Params["catplan"], Request.Params["py"], Request.Params["batch"], Request.Params["ratetype"], conn);

                if (!string.IsNullOrEmpty(hidcomVales.Value))
                {
                    // remove first seperatoe
                    hidcomVales.Value = hidcomVales.Value.Remove(0, 1);
                    ArrayList ar = new ArrayList(hidcomVales.Value.Split(new char[] { '!' }));
                    string long_description = Request.Params["cvrg"].Substring(0, Request.Params["cvrg"].IndexOf(" - "));
                    foreach (string str in ar)
                    {
                        string[] fs = str.Split('=');
                        string[] age = fs[0].Split('-');
                        age[0] = age[0].Replace(" + ","");
                        Data.SaveRate_ver1(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                        newCatePlN, "010", Request.Params["py"], Request.Params["batch"], fs[1], age[0].Trim(), "", "", long_description, fs[0], "1", conn);
                    }
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
            btnCancel_Click(null, null);
        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();

            DataColumn col1 = new DataColumn("Age_Band");
            DataColumn col2 = new DataColumn("Rate_amount");
            DataColumn col3 = new DataColumn("rate");
            DataColumn col4 = new DataColumn("AGE_RATE_DESCRIPTION");

            col1.DataType = System.Type.GetType("System.String");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.String");
            col4.DataType = System.Type.GetType("System.String");


            table.Columns.Add(col1);
            table.Columns.Add(col2);
             table.Columns.Add(col3);
            table.Columns.Add(col4);

            Int16 inStart = Convert.ToInt16(txtMinAge.Value);
            Int16 instep = Convert.ToInt16(txtStep.Value);
            Int16 inLast = Convert.ToInt16(txtLastAge.Value);

            DataRow row0 = table.NewRow();
            row0[col1] = "0 - " + (inStart -1).ToString();
            row0[col2] = "";
            table.Rows.Add(row0);
            
            for (int i = inStart; i <= inLast; i += instep)
            {
                DataRow row = table.NewRow();
                if (i.Equals(inLast))
                    row[col1] = i.ToString()+" + ";
                else
                    row[col1] = i.ToString() + " - " + (i+instep-1).ToString();
                row[col2] = "";
                table.Rows.Add(row);
            }
            return table;
        }

        private void DrawGrid()
        {
            DataTable tbl = null;
            if (Request.Params["action"].Equals("0"))
            {
                tbl = Data.GetRates(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["py"], Request.Params["batch"]);
                tbl.Columns.Add("Age_Band", typeof(string));
                foreach (DataRow dr in tbl.Rows)
                {
                    string str = dr["age_rate_description"].ToString();
                    string[] values = str.Split('-');
                    string strAge_Band = values[0].Trim();
                    dr["Age_Band"] = strAge_Band;
                }
                tbl.AcceptChanges();
                gvRates.Columns[0].Visible = false;
            }
            else
            {
                tbl = CreateTable();
                gvRates.Columns[1].Visible = false;
                gvRates.Columns[2].Visible = false;
            }
            gvRates.DataSource = tbl;
            gvRates.DataBind();
        }

        protected void gvRates_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvRates.DataSource;
            if (dt == null)
                return;
            if (e.Row.RowIndex < 0)
                return;
            //try
            {
                if (dt.Rows.Count < e.Row.RowIndex)
                    return;
                string strIndex = dt.Rows[e.Row.RowIndex]["Age_Band"].ToString();

                TextBox txt = new TextBox();
                txt.ID = "txt_" + strIndex;
                txt.Width = Unit.Pixel(100);                

                txt.Attributes.Add("onblur", "change('" + strIndex + "','" + txt.Text + "');");
                TableCell celltxt = e.Row.Cells[3];
                celltxt.Controls.Add(txt);
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            tblparamenters.Visible = false;
            DrawGrid();
        }

    }
}