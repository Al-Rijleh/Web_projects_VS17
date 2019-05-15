using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Collections;

namespace Automated_Rate_Update
{
    public partial class StatusRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                SetUsage();
                SetupCheckBoxes();
                
                lblTitle.Text +=" - "+ Request.Params["cvrg"];
                SetOE();
                DrawGrid();
            }
            //DrawGrid();
        }

        private void SetupCheckBoxes()
        {
            DataTable tbl = Data.Family_Status_List(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                            Request.Params["catplan"], Request.Params["py"], Request.Params["batch"]);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["description"].ToString(), dr["family_status_code"].ToString());
                li.Selected = !dr["exist"].ToString().Equals("0");
                cblStatus.Items.Add(li);
            }
        }

        private void SetUsage()
        {
            if (string.IsNullOrEmpty(Request.Params["action"])||(Request.Params["action"].Equals("0")))            
            {
                tblparamenters.Visible = false;
                DrawGrid();
            }

            string strInOE = Data.Cvrg_in_OE(Request.Params["accnt"], Request.Params["py"], Request.Params["catcode"], Request.Params["catplan"], Request.Params["class"], Request.Params["batch"]);
            cbOe.Checked = strInOE.Equals("1");

        }

        private void SetOE()
        {
            string strinOE = Data.Cvrg_in_OE(Request.Params["accnt"], Request.Params["py"], Request.Params["catcode"],
                   Request.Params["catplan"], Request.Params["class"], Request.Params["batch"]);
            if (strinOE.Equals("0"))
                cbOe.Checked = false;
            else
                cbOe.Checked = true;
        }

        private void DrawGrid()
        {
            DataTable tbl = null;
            if (Request.Params["action"].Equals("0"))
            {
                tbl = Data.GetRatesForEdit(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["py"]);
            }
            else
            {
                tbl = CreateTable();
                gvRates.Columns[1].Visible = false;

            }
            gvRates.DataSource = tbl;
            gvRates.DataBind();

        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();

            DataColumn col1 = new DataColumn("FAMILY_STATUS");
            DataColumn col2 = new DataColumn("New Rate");

            col1.DataType = System.Type.GetType("System.String");
            col2.DataType = System.Type.GetType("System.String");
            


            table.Columns.Add(col1);
            table.Columns.Add(col2);
            

           

           foreach (ListItem li in cblStatus.Items)
            {
                if (li.Selected)
                {
                    DataRow row = table.NewRow();
                    row[col1] = li.Value + " - " + li.Text;
                    row[col2] = "";
                    table.Rows.Add(row);
                }
                table.AcceptChanges();
            }
            return table;
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
                string strIndex = string.Empty;
                if (Request.Params["action"].Equals("0"))
                    strIndex = dt.Rows[e.Row.RowIndex]["family_status_code"].ToString();
                else
                    strIndex = dt.Rows[e.Row.RowIndex]["FAMILY_STATUS"].ToString().Substring(0,3);
                TextBox txt = new TextBox();
                txt.ID = "txt_" + strIndex;
                txt.Width = Unit.Pixel(100);
                if (Request.Params["action"].Equals("0"))
                    txt.Text = dt.Rows[e.Row.RowIndex]["oldRate"].ToString();
                else
                {
                    txt.Text = "0";
                    hidcomVales.Value += "!"+strIndex + "=0";
                }
                txt.Attributes.Add("onblur", "change('" + strIndex + "','" + txt.Text + "');");
                TableCell celltxt = e.Row.Cells[2];
                celltxt.Controls.Add(txt);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string strParam  = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = "?accnt=" + Request.Params["accnt"] +
                                  "&ip=" + Request.Params["batch"].Substring(0, 4) +
                                  "&py=" + Request.Params["py"].Substring(0, 4);
            else
                strParam = "?id=" + Request.Params["id"];

            Response.Redirect("Default4.aspx" + strParam, true);
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
                if (string.IsNullOrEmpty(hidcomVales.Value))
                {
                    tx.Commit();
                    SQLStatic.SQL.CloseConnection(conn);
                    if (!Request.Params["action"].Equals("0"))
                    {
                        jscriptsFunctions.Misc.Alert(Page, "You did not enter Rates");
                        btnCancel_Click(null, null);
                        return;
                    }
                    else
                        btnCancel_Click(null, null);
                }
                if (!string.IsNullOrEmpty(hidcomVales.Value))
                {

                    string long_description = Request.Params["cvrg"];
                    if (!Request.Params["cvrg"].IndexOf(" - ").Equals(-1))
                        long_description = Request.Params["cvrg"].Substring(0, Request.Params["cvrg"].IndexOf(" - "));
                    hidcomVales.Value = hidcomVales.Value.Remove(0, 1);
                    ArrayList ar = new ArrayList(hidcomVales.Value.Split(new char[] { '!' }));

                    foreach (string str in ar)
                    {
                        string[] fs = str.Split('=');

                        Data.SaveRate_ver1(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                       newCatePlN, fs[0], Request.Params["py"], Request.Params["batch"], fs[1], "0", "", "", long_description, "", "1", conn);
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

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            tblparamenters.Visible = false;
            DrawGrid();
        }

       
    }
}