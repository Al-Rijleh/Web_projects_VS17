using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Rates
{
    public partial class UseOld : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Params["catplan"].StartsWith("0"))
            {
                string user_name = string.Empty;
                try { session_id = Request.Cookies["Session_ID"].Value.ToString(); }
                catch { session_id = string.Empty; }
                if (!string.IsNullOrEmpty(session_id))
                {
                    user_name = SQLStatic.Sessions.GetUserName(session_id);
                }
                

                string cvrgid = string.Empty;
                if (!string.IsNullOrEmpty(Request.Params["cvrgid"]))
                    cvrgid = Request.Params["cvrgid"];

                string strBack = string.Empty;
                if (!string.IsNullOrEmpty(Request.Params["back"]))
                    strBack = Request.Params["back"];

                string strParam = "?batch=" + Request.Params["batch"] + "&py=" + Request.Params["py"] + "&catplan=" + Request.Params["catplan"] +
                    "&id=" + Request.Params["id"] + "&accnt=" + Request.Params["accnt"] + "&back=" + strBack +
                    "&ver=" + Request.Params["ver"] + "&userID=" + user_name + "&cvrgid=" + cvrgid + "&class=" + Request.Params["class"];
                Response.Redirect("PreDefindMetalCoverage.aspx" + strParam, true);
                return;
            }
            if (!IsPostBack)
            {
                SetUsage();
                if (!string.IsNullOrEmpty(Request.Params["back"]))
                {
                    Panel1.Visible = false;
                    if ((Request.Params["back"].Equals("2")))
                        btnCancel.Visible = false;
                }

            }
            if (hidSave.Value.Equals("save"))
            {
                hidSave.Value = string.Empty;
                btnSave_Click(null, null);
                return;
            }
        }

        private void SetUsage()
        {
            if (Request.Params["action"].Equals("0"))
            {
                tblparamenters.Visible = false;
                DrawGrid();
            }

            try { session_id = Request.Cookies["Session_ID"].Value.ToString(); }
            catch { session_id = string.Empty; }
            if (!string.IsNullOrEmpty(session_id))
            {
                ViewState["user_id"] = SQLStatic.Sessions.GetUserName(session_id);
            }
           

            string strInOE = Data.Cvrg_in_OE(Request.Params["accnt"], Request.Params["py"], Request.Params["catcode"], Request.Params["catplan"], Request.Params["class"], Request.Params["batch"]);
            cbOe.Checked = strInOE.Equals("1");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["back"]) && (Request.Params["back"].Equals("1")))
            {
                string strURL = "/web_projects/AccountSetupWizard/Status.aspx?id=13";
                lblScript.Text = "<script>Javascript:NavigateTo('" + strURL + "')</script>";
                //Response.Redirect("/web_projects/AccountSetupWizard/Status.aspx?id=13", true);
                return;
            }
            string strParam = string.Empty;
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
            string session_id = string.Empty;
            DataTable tbl = null;
            if (!string.IsNullOrEmpty(Request.Params["back"]))
            {
                if (string.IsNullOrEmpty(hidcomVales.Value) && string.IsNullOrEmpty(hidcomVale2.Value))
                {
                    jscriptsFunctions.Misc.Alert(Page, "Nothing to save!");
                    DrawGrid();
                    return;
                }
                session_id = Request.Cookies["Session_ID"].Value.ToString();
                tbl = Data.Family_Status_Generic(session_id, Request.Params["accnt"], Request.Params["cvrgid"], Request.Params["class"], Request.Params["catcode"],
                Request.Params["catplan"], Request.Params["py"]);
            }
            else
                tbl = Data.Family_Status_List(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                Request.Params["catplan"], Request.Params["py"], Request.Params["batch"]);

            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                //string strInOPenEE = "0";
                string newCatePlN = Request.Params["catplan"];
                
                if (string.IsNullOrEmpty(hidcomVales.Value) && string.IsNullOrEmpty(hidcomVale2.Value))
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
                    {
                        btnCancel_Click(null, null);
                        return;
                    }
                }

                

                if (!string.IsNullOrEmpty(hidcomVales.Value))
                {
                    // remove first seperatoe
                    hidcomVales.Value = hidcomVales.Value.Remove(0, 1);
                    ArrayList ar = new ArrayList(hidcomVales.Value.Split(new char[] { '!' }));
                    string long_description = Request.Params["cvrg"];
                    if (!Request.Params["cvrg"].IndexOf(" - ").Equals(-1))
                        long_description = Request.Params["cvrg"].Substring(0, Request.Params["cvrg"].IndexOf(" - "));
                    foreach (DataRow dr in tbl.Rows)
                    {
                        if (!dr["exist"].ToString().Equals("0"))
                        {
                            foreach (string str in ar)
                            {
                                string[] fs = str.Split('=');
                                string[] age = fs[0].Split('-');
                                age[0] = age[0].Replace(" + ", "");
                                if (!string.IsNullOrEmpty(Request.Params["back"]))
                                {
                                    Data.SaveRate_ver2_tbl(Request.Params["accnt"], Request.Params["ver"], dr["class_code"].ToString(), Request.Params["catcode"],
                                   newCatePlN, dr["family_status_code"].ToString(), Request.Params["py"], Request.Params["batch"], fs[1], age[0].Trim(), "",
                                   ViewState["user_id"].ToString(), long_description, fs[0], "1", "0", conn);
                                }
                            //    else
                            //        Data.SaveRate_ver2(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                            }
                        }
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
                    foreach (DataRow dr in tbl.Rows)
                    {
                        if (!dr["exist"].ToString().Equals("0"))
                        {
                            foreach (string str in ar)
                            {
                                string[] fs = str.Split('=');
                                string[] age = fs[0].Split('-');
                                age[0] = age[0].Replace(" + ", "");
                                age[0] = age[0].Replace("_a", "");
                                if (!string.IsNullOrEmpty(Request.Params["back"]))
                                {
                                    Data.SaveRate_ver2_tbl(Request.Params["accnt"], Request.Params["ver"], dr["class_code"].ToString(), Request.Params["catcode"],
                                    newCatePlN, dr["family_status_code"].ToString(), Request.Params["py"], Request.Params["batch"], fs[1], age[0].Trim(), "",
                                    ViewState["user_id"].ToString(), long_description, fs[0], "2", "0", conn);
                                }
                            }
                        }
                    }
                }


                if (!string.IsNullOrEmpty(Request.Params["back"]))
                {
                    //Data.UpdateRates_One_Cvrg(Request.Params["accnt"], Request.Params["cvrgid"], Request.Params["batch"], conn);
                    Data.add_formulas_for_COBRA_Setup(Request.Params["accnt"], Request.Params["cvrgid"], conn);
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
            if (!string.IsNullOrEmpty(Request.Params["back"]))
            {
                if ((Request.Params["back"].Equals("2")))
                {
                    string strParam = "?accnt=" + Request.Params["accnt"] +
                              "&ver=" + Request.Params["ver"] +
                              "&class=" + Request.Params["class"] +
                              "&catcode=" + Request.Params["catcode"] +
                              "&catplan=" + Request.Params["catplan"] +
                              "&py=" + Request.Params["py"] +
                              "&batch=" + Request.Params["batch"] +
                              "&cvrg=" + Request.Params["cvrg"] +
                              "&back=2" +
                              "&cvrgid=" + Request.Params["cvrgid"] +
                              "&action=" + "0" +
                              "&id=";
                    //string strURL = "/WEB_PROJECTS/AUTOMATED_RATE_UPDATE/DoubleAgeRate.aspx" + strParam;
                    string strURL = "/WEB_PROJECTS/Rates/UseOld.aspx" + strParam;
                    lblScript.Text = "<script>Javascript:ReRun('" + strURL + "')</script>";
                    //Bas_Utility.Misc.AlertSaved(Page);
                    //DrawGrid();
                    return;
                }
            }

            btnCancel_Click(null, null);
        }

        private DataTable CreateTable()
        {
            DataTable table = new DataTable();

            DataColumn col1 = new DataColumn("Age_Band");
            DataColumn col2 = new DataColumn("Rate_amount");
            DataColumn col3 = new DataColumn("rate_override1");
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
            row0[col1] = "0 - " + (inStart).ToString();
            row0[col2] = "";
            table.Rows.Add(row0);
            inStart++;
            for (int i = inStart; i <= inLast; i += instep)
            {
                DataRow row = table.NewRow();
                if (i.Equals(inLast))
                    row[col1] = i.ToString() + " + ";
                //else if (i.Equals(inStart))                 
                //    row[col1] = i.ToString() + " - " + (i + instep).ToString();
                else
                    row[col1] = i.ToString() + " - " + (i + instep - 1).ToString();
                row[col2] = "";
                table.Rows.Add(row);
            }
            return table;
        }

        private void DrawGrid()
        {
            DataTable tbl = null;
            
                    tbl = Data.GetRatesFrmRateTbl(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
                    Request.Params["catplan"], Request.Params["py"]);
               
                tbl.Columns.Add("Age_Band", typeof(string));
                string sroldStatus = tbl.Rows[0]["Family_Status"].ToString();
                foreach (DataRow dr in tbl.Rows)
                {
                    if (dr["Family_Status"].ToString().Equals(sroldStatus))
                    {
                        string str = dr["Age Band"].ToString();
                        string[] values = str.Split('-');
                        string strAge_Band = values[0].Trim();
                        dr["Age_Band"] = strAge_Band;
                    }
                    else
                        dr.Delete();
                }

                tbl.AcceptChanges();
                gvRates.Columns[0].Visible = false;
            
            
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

            if (dt.Rows.Count < e.Row.RowIndex)
                return;
            string strIndex = dt.Rows[e.Row.RowIndex]["Age_Band"].ToString();

            TextBox txt = new TextBox();
            txt.ID = "txt_" + strIndex;
            txt.Width = Unit.Pixel(100);
            if (Request.Params["action"].Equals("0"))
                txt.Text = dt.Rows[e.Row.RowIndex]["NonTobacco"].ToString().Replace("$", "").Replace(",", "");
            else
            {
                txt.Text = "0";

            }
            hidcomVales.Value += "!" + strIndex + "=" + txt.Text;
            txt.Attributes.Add("onblur", "change('" + strIndex + "','" + txt.Text + "');");
            TableCell celltxt = e.Row.Cells[2];
            celltxt.Controls.Add(txt);

            // Tobaco
            strIndex = "_a" + dt.Rows[e.Row.RowIndex]["Age_Band"].ToString();
            TextBox txt2 = new TextBox();
            txt2.ID = "txt_2" + strIndex;
            txt2.Width = Unit.Pixel(100);
            if (Request.Params["action"].Equals("0"))
                txt2.Text = dt.Rows[e.Row.RowIndex]["Tobacco"].ToString().Replace("$", "").Replace(",", "");
            else
            {
                txt2.Text = "0";

            }
            hidcomVale2.Value += "!" + strIndex + "=" + txt2.Text;
            txt2.Attributes.Add("onblur", "change2('" + strIndex + "','" + txt.Text + "');");
            TableCell celltxt2 = e.Row.Cells[3];
            celltxt2.Controls.Add(txt2);

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            tblparamenters.Visible = false;
            DrawGrid();
        }
    }
}