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
    public partial class DoubleAgeRateWithStatus : System.Web.UI.Page
    {
        string strFamilyStatus = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetUsage();
                SetupCheckBoxes();
            }
        }

        private void SetupCheckBoxes()
        {
            DataTable tbl = Data.Family_Status_List(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                            Request.Params["catplan"], Request.Params["py"], Request.Params["batch"]);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["description"].ToString(), dr["family_status_code"].ToString());
                li.Selected = dr["exist"].ToString().Equals("1");
                cblStatus.Items.Add(li);
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
                string newCatePlN = Request.Params["catplan"];
                if (cbOe.Checked)
                    strInOPenEE = "1";
                Data.Save_In_OE(Request.Params["accnt"], Request.Params["py"], strInOPenEE, Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["class"], Request.Params["batch"], conn);
                if (!Request.Params["action"].Equals("0"))
                    newCatePlN = Data.Replace_coverage(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                            Request.Params["catplan"], Request.Params["py"], Request.Params["batch"], Request.Params["ratetype"], conn);

                if (!string.IsNullOrEmpty(hidcomVales.Value))
                {
                    // remove first seperatoe
                    hidcomVales.Value = hidcomVales.Value.Remove(0, 1);
                    ArrayList ar = new ArrayList(hidcomVales.Value.Split(new char[] { '!' }));
                    string long_description = Request.Params["cvrg"];
                    if (!Request.Params["cvrg"].IndexOf(" - ").Equals(-1))
                        long_description = Request.Params["cvrg"].Substring(0, Request.Params["cvrg"].IndexOf(" - "));
                    string strFamilyStatus = string.Empty;
                    foreach (string str in ar)
                    {
                        string[] fs = str.Split('=');
                        strFamilyStatus = fs[0].Substring(0, 3);
                        fs[0] = fs[0].Substring(3);
                        string[] age = fs[0].Split('-');
                        age[0] = age[0].Replace(" + ", "");
                        Data.SaveRate_ver1(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                        newCatePlN, strFamilyStatus, Request.Params["py"], Request.Params["batch"], fs[1], age[0].Trim(), "", "", long_description, fs[0], "1", conn);
                    }
                }


                if (!string.IsNullOrEmpty(hidcomVale2.Value))
                {
                    // remove first seperatoe
                    hidcomVale2.Value = hidcomVale2.Value.Remove(0, 1);
                    ArrayList ar = new ArrayList(hidcomVale2.Value.Split(new char[] { '!' }));
                    string long_description = Request.Params["cvrg"];
                    if (!Request.Params["cvrg"].IndexOf(" - ").Equals(-1))
                        long_description = Request.Params["cvrg"].Substring(0, Request.Params["cvrg"].IndexOf(" - "));
                    foreach (string str in ar)
                    {
                        string[] fs = str.Split('=');
                        strFamilyStatus = fs[0].Substring(0, 3);
                        fs[0] = fs[0].Substring(3);
                        string[] age = fs[0].Split('-');
                        age[0] = age[0].Replace(" + ", "");
                        age[0] = age[0].Replace("_a", "");
                        Data.SaveRate_ver1(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                        newCatePlN, strFamilyStatus, Request.Params["py"], Request.Params["batch"], fs[1], age[0].Trim(), "", "", long_description, fs[0], "2", conn);
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

            DataColumn col0 = new DataColumn("Family_status");
            DataColumn col1 = new DataColumn("Age_Band");
            DataColumn col2 = new DataColumn("Rate_amount");
            DataColumn col3 = new DataColumn("rate_override1");
            DataColumn col4 = new DataColumn("AGE_RATE_DESCRIPTION");

            col0.DataType = System.Type.GetType("System.String");
            col1.DataType = System.Type.GetType("System.String");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.String");
            col4.DataType = System.Type.GetType("System.String");

            table.Columns.Add(col0);
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            table.Columns.Add(col4);

            Int16 inStart = Convert.ToInt16(txtMinAge.Value);
            Int16 instep = Convert.ToInt16(txtStep.Value);
            Int16 inLast = Convert.ToInt16(txtLastAge.Value);

            foreach (ListItem li in cblStatus.Items)
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
                            row[col1] = i.ToString()+" + ";
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

        private DataTable CreateTable(DataTable tbl)
        {
            DataTable tblwork = Data.GetRates(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["py"], Request.Params["batch"]);
            DataTable table = new DataTable();

            DataColumn col0 = new DataColumn("Family_status");
            DataColumn col1 = new DataColumn("Age_Band");
            DataColumn col2 = new DataColumn("Rate_amount");
            DataColumn col3 = new DataColumn("rate_override1");
            DataColumn col4 = new DataColumn("AGE_RATE_DESCRIPTION");

            col0.DataType = System.Type.GetType("System.String");
            col1.DataType = System.Type.GetType("System.String");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.String");
            col4.DataType = System.Type.GetType("System.String");

            table.Columns.Add(col0);
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            table.Columns.Add(col4);
            string strOldStatus = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                DataRow rowstatus = table.NewRow();
                if (!strOldStatus.Equals(dr["family_status"].ToString()))
                {
                    rowstatus[col0] = dr["family_status"].ToString();
                    rowstatus[col1] = "";
                    rowstatus[col2] = "";
                    rowstatus[col3] = "";
                    table.Rows.Add(rowstatus);
                }
                if (!strOldStatus.Equals( dr["family_status"].ToString()))
                {
                    strOldStatus = dr["family_status"].ToString();
                    foreach (DataRow dr2 in tblwork.Rows)
                    {
                        if (dr2["family_status"].ToString().Equals(dr["family_status"].ToString()))
                        {
                            DataRow row = table.NewRow();
                            row[col1] = dr2["Age Band"].ToString();
                            row[col2] = dr2["NonTobacco"].ToString();
                            row[col3] = dr2["Tobacco"].ToString();
                            table.Rows.Add(row);
                        }
                    }
                }
            }
            table.AcceptChanges();
            gvEditRate.DataSource = table;
            gvEditRate.DataBind();
            return table;
            Int16 inStart = Convert.ToInt16(txtMinAge.Value);
            Int16 instep = Convert.ToInt16(txtStep.Value);
            Int16 inLast = Convert.ToInt16(txtLastAge.Value);
            

            foreach (ListItem li in cblStatus.Items)
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
                            row[col1] = i.ToString()+" + ";
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


        private void DrawGrid()
        {
            
            DataTable tbl = null;
            if (Request.Params["action"].Equals("0"))
            {
                gvRates.Visible = false;
                tbl = Data.GetRates(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["py"], Request.Params["batch"]);
                tbl = CreateTable(tbl);
                return;
            }
            //    tbl.Columns.Add("Age_Band", typeof(string));
                
            //    foreach (DataRow dr in tbl.Rows)
            //    {
            //        string str = dr["age_rate_description"].ToString();
            //        string[] values = str.Split('-');
            //        string strAge_Band = values[0].Trim();
            //        dr["Age_Band"] = strAge_Band;
            //    }
            //    tbl.AcceptChanges();
            //    gvRates.Columns[0].Visible = true;
            //    gvRates.Columns[1].Visible = false;
            //}
            //else
            gvEditRate.Visible = false;
            tbl = CreateTable();
            gvRates.Columns[1].Visible = true;
            gvRates.Columns[2].Visible = false;
            
            gvRates.DataSource = tbl;
            gvRates.DataBind();
        }

        protected void gvRates_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;
            DataTable dt = (DataTable)gv.DataSource;
            if (dt == null)
                return;
            if (e.Row.RowIndex < 0)
                return;

            if (dt.Rows.Count < e.Row.RowIndex)
                return;
            if (!string.IsNullOrEmpty(dt.Rows[e.Row.RowIndex]["family_status"].ToString()))
            {
                strFamilyStatus = dt.Rows[e.Row.RowIndex]["family_status"].ToString().Substring(0, 3);
                return;
            }
            string strIndex = strFamilyStatus+dt.Rows[e.Row.RowIndex]["Age_Band"].ToString();

            TextBox txt = new TextBox();
            txt.ID = "txt_" + strIndex;
            txt.Width = Unit.Pixel(100);
            if (Request.Params["action"].Equals("0"))
                txt.Text = dt.Rows[e.Row.RowIndex]["Rate_amount"].ToString().Replace("$", "").Replace(",", "");

            txt.Attributes.Add("onblur", "change('" + strIndex + "','" + txt.Text + "');");
            TableCell celltxt = null;
            if (Request.Params["action"].Equals("0"))
                celltxt = e.Row.Cells[2];
            else
                celltxt = e.Row.Cells[3];
            celltxt.Controls.Add(txt);

            // Tobaco
            strIndex = strFamilyStatus + "_a" + dt.Rows[e.Row.RowIndex]["Age_Band"].ToString();
            TextBox txt2 = new TextBox();
            txt2.ID = "txt_2" + strIndex;
            txt2.Width = Unit.Pixel(100);
            if (Request.Params["action"].Equals("0"))
                txt2.Text = dt.Rows[e.Row.RowIndex]["rate_override1"].ToString().Replace("$", "").Replace(",", "");

            txt2.Attributes.Add("onblur", "change2('" + strIndex + "','" + txt.Text + "');");
            TableCell celltxt2 = null;
            if (Request.Params["action"].Equals("0"))
                celltxt2 = e.Row.Cells[3];
            else
                celltxt2 = e.Row.Cells[4];
            celltxt2.Controls.Add(txt2);

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            tblparamenters.Visible = false;
            DrawGrid();
        }
    }
}