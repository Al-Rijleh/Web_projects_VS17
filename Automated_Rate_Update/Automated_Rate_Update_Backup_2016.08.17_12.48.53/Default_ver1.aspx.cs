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
using Oracle.DataAccess.Client;
using Telerik.Web.UI;

namespace Automated_Rate_Update
{
    public partial class Default_ver1 : System.Web.UI.Page
    {
        protected string strOldClass = "";
        protected string strOldCode = "";
        protected string strOldPlan = "";
        protected string strOldPDesc = "";
        protected string strOldPlanName = "";
        protected string strAccount_Number = "";
        protected string strUserID = "";
        protected string strEmail = "";
        protected string strBatch = "";
        protected string strRateRenewal = "";
        protected string strProcessing_year = "";
        DataTable tblCb = null;
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblScript.Text = string.Empty;
            try { session_id = Request.Cookies["Session_ID"].Value.ToString(); }
            catch { session_id = string.Empty; }
            if (!string.IsNullOrEmpty(session_id))
            {
                string userGroup = SQLStatic.Sessions.GetUserGroupID(session_id);
                if (!userGroup.Equals("1"))
                    session_id = string.Empty;
            }
            if (ViewState["accnt"] == null)
            {
                if (!string.IsNullOrEmpty(session_id))
                    GetParametersBas();
                else
                    GetParameters(Request.Params["id"]);
            }
            strAccount_Number = ViewState["accnt"].ToString();

            strEmail = ViewState["email"].ToString();
            strUserID = ViewState["user_id"].ToString();
            strBatch = ViewState["batch"].ToString();
            strProcessing_year = ViewState["py"].ToString();
            strRateRenewal = ViewState["renewal"].ToString();
            hidParam.Value = Request.Params["id"];
            // Process Action
            if (!string.IsNullOrEmpty(hidRemove.Value))
            {
                Remove(hidRemove.Value);
                hidRemove.Value = "";
            }
            if (!string.IsNullOrEmpty(hidReactivate.Value))
            {
                Reactivate(hidReactivate.Value);
                hidReactivate.Value = "";
            }
            //hidParam.Value = Request.Params["id"];
            if (!IsPostBack)
            {
                //dvNote.Visible = false;
                ShowProcessed();
                BuildNormalRates();
                FillddlEffectiveDate(strAccount_Number);

            }
            
        }

        private void ShowProcessed()
        {
            DataTable tbl = Data.processedby(strAccount_Number, strBatch);
            if (tbl.Rows.Count.Equals(0))
            {
                dvProcessed.Visible = false;
                return;
            }
            if (!string.IsNullOrEmpty(tbl.Rows[0]["processed_by"].ToString()))
            {
                dvProcessed.Visible = true;
                lblProcessed.Text = "This account was processed and completed by " + tbl.Rows[0]["processed_by"].ToString() + " on " + tbl.Rows[0]["processed_on"].ToString();
            }
            else
                dvProcessed.Visible = false;
        }

        private void BuildNormalRates()
        {
            DataTable tbl = Data.GetClasses(strAccount_Number, strProcessing_year, strRateRenewal);
            int pnlid = 0;
            Panel pnl = null;
            Label lbl = null;
            ViewState["Version_Number"] = tbl.Rows[0]["version_number"].ToString();
            foreach (DataRow dr in tbl.Rows)
            {
                pnlid++;
                pnl = (Panel)FindControl("pnl_"+pnlid.ToString());
                pnl.Visible = true;
                pnl = (Panel)FindControl("dvClass_" + pnlid.ToString());
                pnl.Visible = true;
                lbl = (Label)FindControl("lblClass_" + pnlid.ToString());
                lbl.Text = "Class: " + dr["class_code"].ToString() + " - " + dr["description"].ToString();
                strOldClass = dr["class_code"].ToString();
                SetPlanType(dr["class_code"].ToString(),dr["version_number"].ToString(),pnlid.ToString());
                if (pnlid.Equals(4))
                break;
            }
            tbl.Dispose();
        }

        private void SetPlanType(string class_code, string version_number, string pnlid)
        {
            Label lbl = null;
            Panel pnl = null;
            DataTable tbl = Data.GetPlanTypes(strAccount_Number, version_number, class_code);
            int plncounter = 0;
            string typeid = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                plncounter++;
                typeid = pnlid + plncounter.ToString();
                pnl = (Panel)FindControl("pnlTypeMaster_" + typeid);
                pnl.Visible = true;
                pnl = (Panel)FindControl("dvPlanType_" + typeid);
                pnl.Visible = true;

                lbl = (Label)FindControl("lblPlanType_" + typeid);
                lbl.Text = dr["Plan_Name"].ToString();
                lbl = (Label)FindControl("lblAddNewPlan_" + typeid);
                lbl.Text = lbl.Text.Replace("[plan]", dr["Plan_Name"].ToString());
                Button btn= (Button)FindControl("btnAdd_" + typeid);
                btn.Text = btn.Text.Replace("[plan]", dr["Plan_Name"].ToString());


                setCoverages(class_code, version_number, typeid, dr["category_code"].ToString());
                if (typeid.Equals("16"))
                    break;
            }
            tbl.Dispose();
        }

        private void setCoverages(string class_code, string version_number, string pnlid, string category_code)
        {
            //category_code = "INS-MED";
            DataTable tbl = Data.GetCoverages(strAccount_Number, version_number, class_code,category_code);
            int cvrgcounter = 0;
            string cvrgid = string.Empty; 
             foreach (DataRow dr in tbl.Rows)
             {
                 cvrgcounter++;                 
                 cvrgid = pnlid + cvrgcounter.ToString();
                 // Long Description
                 Label lbl = (Label)FindControl("lblPlanName_" + cvrgid);
                 lbl.Text = dr["long_description"].ToString() + " - (" + category_code + "-" + dr["category_plan"].ToString()+")";

                 // In OE
                 //CheckBox cb = (CheckBox)FindControl("cbOe_" + cvrgid);
                 //cb.Checked = dr["in_oe"].ToString().Equals("1");
                 Image img = (Image)FindControl("cbOe_" + cvrgid);
                 if (dr["in_oe"].ToString().Equals("1"))
                     img.ImageUrl = "https://www.myenroll.com/images/yes.gif";
                 else
                     img.ImageUrl = "https://www.myenroll.com/images/No.gif";

                 Panel pnl = (Panel)FindControl("dvNRate_" + cvrgid);
                 pnl.Visible = true;
                 if (dr["status"].ToString().Equals("R"))                                      
                     SetRemove(pnl,cvrgid);
                 if (dr["status"].ToString().Equals("A"))
                     SetActive(pnl, cvrgid);
                 if (dr["status"].ToString().Equals("N"))
                     SetNewActive(pnl, cvrgid);
                 
                 SetRates(class_code, version_number, cvrgid, category_code, dr["category_plan"].ToString());
                 if (cvrgcounter.Equals(9))
                     break;
             }
             tbl.Dispose();
           
        }

        private void ShowType0(DataTable tbl, string pnlid)
        {
            //DataTable tblwork = Data.GetRates(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
            //        Request.Params["catplan"], Request.Params["py"]);
            DataTable tblwork = tbl.Copy();
            DataTable table = new DataTable();

            DataColumn col0 = new DataColumn("Family_Status");
            DataColumn col1 = new DataColumn("Age Band");
            DataColumn col2 = new DataColumn("Rate");
            DataColumn col3 = new DataColumn("NonTobacco");
            DataColumn col4 = new DataColumn("Tobacco");

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
                    rowstatus[col3] = "";
                    rowstatus[col4] = "";
                    table.Rows.Add(rowstatus);
                }
                if (!strOldStatus.Equals(dr["family_status"].ToString()))
                {
                    strOldStatus = dr["family_status"].ToString();
                    foreach (DataRow dr2 in tblwork.Rows)
                    {
                        if (dr2["family_status"].ToString().Equals(dr["family_status"].ToString()))
                        {
                            DataRow row = table.NewRow();
                            row[col1] = dr2["Age Band"].ToString();
                            row[col3] = dr2["NonTobacco"].ToString();
                            row[col4] = dr2["Tobacco"].ToString();
                            table.Rows.Add(row);
                        }
                    }
                }
            }
            table.AcceptChanges();
            GridView gv = (GridView)FindControl("GridView_" + pnlid);
            gv.Columns[2].Visible = false;
            gv.DataSource = table;
            gv.DataBind();
        }

        private void ShowType2(DataTable tbl, string pnlid)
        {
            //DataTable tblwork = Data.GetRates(Request.Params["accnt"], Request.Params["ver"], Request.Params["class"], Request.Params["catcode"],
            //        Request.Params["catplan"], Request.Params["py"]);
            DataTable tblwork = tbl.Copy();
            DataTable table = new DataTable();

            DataColumn col0 = new DataColumn("Family_Status");
            DataColumn col1 = new DataColumn("Age Band");
            DataColumn col2 = new DataColumn("Rate");
            DataColumn col3 = new DataColumn("NonTobacco");
            DataColumn col4 = new DataColumn("Tobacco");

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
                    rowstatus[col3] = "";
                    rowstatus[col4] = "";
                    table.Rows.Add(rowstatus);
                }
                if (!strOldStatus.Equals(dr["family_status"].ToString()))
                {
                    strOldStatus = dr["family_status"].ToString();
                    foreach (DataRow dr2 in tblwork.Rows)
                    {
                        if (dr2["family_status"].ToString().Equals(dr["family_status"].ToString()))
                        {
                            DataRow row = table.NewRow();
                            row[col1] = dr2["Age Band"].ToString();
                            row[col2] = dr2["Rate"].ToString();
                            table.Rows.Add(row);
                        }
                    }
                }
            }
            table.AcceptChanges();
            GridView gv = (GridView)FindControl("GridView_" + pnlid);
            gv.Columns[3].Visible = false;
            gv.Columns[4].Visible = false;
            gv.DataSource = table;
            gv.DataBind();
        }

        private void SetRates(string class_code, string version_number, string pnlid, string category_code, string category_plan)
        {            
            Label lbl = (Label)FindControl("lblEffDate_" + pnlid);
            lbl.Text = lbl.Text.Replace("[effdate]", ViewState["batch"].ToString());
            DataTable tbl = Data.GetRates(strAccount_Number, version_number, class_code, category_code, category_plan, strProcessing_year);
            string ratetype = Data.GetRateType(strAccount_Number, ViewState["Version_Number"].ToString(), class_code, category_code, category_plan, strProcessing_year);            
                
            GridView gv = (GridView)FindControl("GridView_" + pnlid);

            if (ratetype.Equals("1"))
            {
                gv.Columns[1].Visible = false;
                gv.Columns[4].Visible = false;
                gv.Columns[3].Visible = false;
            }
            if (ratetype.Equals("0"))
            {
                ShowType0(tbl, pnlid);
                return;
            }
            if (ratetype.Equals("2"))
            {
                ShowType2(tbl, pnlid);
                return;
            }

            //if ((ratetype.Equals("2"))||(ratetype.Equals("0")))            
            //RadGrid gv = (RadGrid)FindControl("GridView_" + pnlid);
            //if ((ratetype.Equals("2"))||(ratetype.Equals("0")))
            //{
            //    GridGroupByExpression expression = new GridGroupByExpression();
            //    GridGroupByField gridGroupByField = new GridGroupByField();
            //    gridGroupByField = new GridGroupByField();
            //    gridGroupByField.FieldName = "family_status";
            //    gridGroupByField.FieldAlias = "Family_Status";
            //    expression.GroupByFields.Add(gridGroupByField);
            //    gv.MasterTableView.GroupByExpressions.Add(expression);
            //}
            //else
            //    gv.MasterTableView.GroupByExpressions.Clear();
            gv.DataSource = tbl;
            gv.DataBind();
            //gv.Columns[0].ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }


        private void GetParametersBas()
        {
            ViewState["accnt"] = SQLStatic.Sessions.GetAccountNumber(session_id);
            ViewState["email"] = "";
            ViewState["user_id"] = SQLStatic.Sessions.GetUserName(session_id);
            ViewState["batch"] = ViewState["batch"] = SQLStatic.Sessions.GetSessionValue(session_id, "batchid");
            ViewState["py"] = ViewState["batch"].ToString().Substring(6);
            ViewState["renewal"] = ViewState["batch"].ToString().Substring(0, 5);
            //btnReset.Visible = true;
        }

        private void GetParameters(string param)
        {
            //btnReset.Visible = false;
            DataTable tbl = Data.get_parameters(param);
            if (tbl.Rows.Count.Equals(0))
            {
                throw new Exception(param + " was not found");
            }
            ViewState["accnt"] = tbl.Rows[0]["account_number"].ToString();
            ViewState["email"] = tbl.Rows[0]["email"].ToString();
            ViewState["batch"] = tbl.Rows[0]["batch_id"].ToString();
            ViewState["py"] = tbl.Rows[0]["processing_year"].ToString();
            ViewState["renewal"] = tbl.Rows[0]["rate_renewal"].ToString();
            ViewState["user_id"] = tbl.Rows[0]["user_name_"].ToString();
        }

        private void FillddlEffectiveDate(string strAccount_Number)
        {
            DataTable tbl = Data.Default_EffectiveDate_2(ViewState["accnt"].ToString(), ViewState["renewal"].ToString(), ViewState["py"].ToString());
            ViewState["EffectiveDat"] =  tbl.Rows[0]["Formated_Date"].ToString();
            tbl.Dispose();
            
        }

        

        protected void RowCreate(object sender, GridViewRowEventArgs e)
        {

        }

        protected void RowBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void rblIndescChanged(object sender, EventArgs e)
        {

        }

        private string checkedRadiobutton(string ID)
        {
            RadioButton rbtSame = (RadioButton)FindControl("Same_" + ID);
            RadioButton rbtChane = (RadioButton)FindControl("Change_" + ID);
            RadioButton rbtRemove = (RadioButton)FindControl("Remove_" + ID);
            if (rbtSame.Checked)
                return "Same_";
            else if (rbtChane.Checked)
                return "Change";
            else if (rbtRemove.Checked)
            {
                if (rbtSame.Enabled)
                    return "Remove";
                else
                    return "Reactivate";
            }
            return string.Empty;
        }

        protected void ChangeButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string ID = btn.ID.Replace("btnChange_","");

            string strcheckedButton = checkedRadiobutton(ID);
            if (string.IsNullOrEmpty(strcheckedButton))
            {
                Bas_Utility.Misc.Alert(Page, "You must select an action from the Radiobutton list");
                return;
            }

            string long_description = ((Label)FindControl("lblPlanName_" + ID)).Text;

            // Get Category Code and Category Plan
            
            string category_code = long_description.Substring(long_description.Length - long_description.IndexOf("(")).Replace(")", "");
            string category_plan = category_code.Substring(category_code.Length - 3);
            category_code = category_code.Replace("-" + category_plan, "");
            int start = long_description.IndexOf("(");
            int end = long_description.IndexOf(")");
            category_code = long_description.Substring(start+1, end - start - 5);

            long_description = long_description.Substring(0,long_description.IndexOf("- (")).Trim();



            string class_description = ((Label)FindControl("lblClass_" + ID.Substring(0,1))).Text;
            string class_code = class_description.Replace("Class: ","");
            class_code = class_code.Substring(0, class_code.IndexOf("-")).Trim();
            class_description = class_description.Replace("Class: ", "").Replace(class_code + " - ", "");
            

            Panel pnl = (Panel)FindControl("dvNRate_" + ID);

            string ratetype = Data.GetRateType(strAccount_Number, ViewState["Version_Number"].ToString(), class_code, category_code, category_plan, strProcessing_year);


            if (strcheckedButton.Equals("Remove"))
            {
                string strParam = "'" + long_description + "','" + class_description + "','" + category_code+"!"+category_plan+"!"+class_code + "','" +  ID + "'";
                lblScript.Text = "<script>Javascript:remove(" + strParam + ")</script>";
                //SetRemove(pnl, ID);
            }
            else if (strcheckedButton.Equals("Reactivate"))
            {
                string strParam = "'" + long_description + "','" + class_description + "','" + class_code + "','" + ID + "'";
                lblScript.Text = "<script>Javascript:Reactivate(" + strParam + ")</script>";
                //SetActive(pnl, ID);
            }
            else if (strcheckedButton.Equals("Same_"))
            {
                string strParam = "?accnt=" + strAccount_Number +
                                   "&ver=" + ViewState["Version_Number"].ToString() +
                                   "&class=" + class_code +
                                   "&catcode=" + category_code +
                                   "&catplan=" + category_plan +
                                   "&py=" + strProcessing_year+
                                   "&batch=" + strBatch+
                                   "&cvrg=" + ((Label)FindControl("lblPlanName_" + ID)).Text +
                                   "&ratetype=" + ratetype +
                                   "&action=0" +
                                   "&id="+hidParam.Value;
                if (ratetype.Equals("1"))
                    Response.Redirect("StatusRate.aspx" + strParam, true);
                else if (ratetype.Equals("0"))
                    Response.Redirect("DoubleAgeRate.aspx" + strParam, true);
                else if (ratetype.Equals("2"))
                    Response.Redirect("FamilyAgeRate.aspx" + strParam, true);
            }
            else if (strcheckedButton.Equals("Change"))
            {
                string strParam = "?accnt=" + strAccount_Number +
                                   "&ver=" + ViewState["Version_Number"].ToString() +
                                   "&class=" + class_code +
                                   "&catcode=" + category_code +
                                   "&catplan=" + category_plan +
                                   "&py=" + strProcessing_year +
                                   "&batch=" + strBatch +
                                   "&cvrg=" + ((Label)FindControl("lblPlanName_" + ID)).Text +
                                   "&ratetype=" + ratetype+                                   
                                   "&id=" + hidParam.Value; ;

                Response.Redirect("NewRateType.aspx" + strParam, true);
            }
           
        }

        private void Remove(string strRemove)
        {
            string[] Values = new string[2];
            char[] splitter = { '~' };
            Values = strRemove.Split(splitter);
            string[] class_code = Values[0].Split('!');

            Data.remove_ver1(strAccount_Number, class_code[2], Values[1],class_code[0],class_code[1], strProcessing_year, strBatch);
            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";            
            Panel pnl = (Panel)FindControl("dvNRate_" + Values[2]);
            pnl.Visible = false;
            string strParam = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = "?accnt=" + strAccount_Number +
                              "&ip=" + strRateRenewal +
                              "&py=" + strProcessing_year;
            else
                strParam = "?id=" + Request.Params["id"];
            
            Bas_Utility.Misc.Alert(Page, "Item(s) marked successfully for removal.");
            Response.Redirect("Default_2.aspx" + strParam, true);
            //BuildNormalRates();
        }

        private void Reactivate(string strReactivate)
        {
            string[] Values = new string[2];
            char[] splitter = { '~' };
            Values = strReactivate.Split(splitter);
            Data.reactivate(strAccount_Number, Values[0], Values[1], strProcessing_year, strBatch);
            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";
            BuildNormalRates();
            Bas_Utility.Misc.Alert(Page, "Item(s) reactivated successfully.");
        }

        private void SetRemove(Panel pnl,string cvrgid)
        {            
            pnl.Attributes.Add("class","raterow marginbottom5 paddingbottomm5 bottomline RemovedColor");
            Label lbl = (Label)FindControl("lblRemReact_" + cvrgid);
            lbl.Text = "Reactivate this plan";
            RadioButton rb = null;

            rb = (RadioButton)FindControl("Same_" + cvrgid);
            rb.Enabled = false;
            rb = (RadioButton)FindControl("Change_" + cvrgid);
            rb.Enabled = false;

            //CheckBox cb = (CheckBox)FindControl("cbOe_" + cvrgid);
            //cb.Enabled = false;
        }

        private void SetActive(Panel pnl, string cvrgid)
        {
            Label lbl = (Label)FindControl("lblRemReact_" + cvrgid);
            if (lbl.Text.Equals("Remove this plan"))
                return;
            lbl.Text = "REMOVE this plan with NO CORRESPONDING REPLACEMENT PLAN (Do Not Use this option if you are replacing this plan with a new plan; use the 2nd radio button above instead).";           
            pnl.Attributes.Add("class","raterow marginbottom5 paddingbottomm5 bottomline ActiverColor");
            
            RadioButton rb = null;

            rb = (RadioButton)FindControl("Same_" + cvrgid);
            rb.Enabled = true;
            rb = (RadioButton)FindControl("Change_" + cvrgid);
            {
                string stPlanType=((Label)FindControl("lblPlanType_"+cvrgid.Substring(0,2))).Text;
                if (stPlanType.Contains("Medical"))
                    rb.Enabled = true;
                else
                    rb.Enabled = false;
            }

            //CheckBox cb = (CheckBox)FindControl("cbOe_" + cvrgid);
            //cb.Enabled = false;
        }

        private void SetNewActive(Panel pnl, string cvrgid)
        {
            SetActive(pnl, cvrgid);
            pnl.Attributes.Add("class","raterow marginbottom5 paddingbottomm5 bottomline NewActiveColor");

        }

        private string GetCategoryCode(string desc)
        {
            if (desc.Equals("Medical Plan"))
                return "INS-MED";
            else if (desc.Equals("Dental Plan"))
                return "INS-DEN";
            else if (desc.Equals("Vision Plan"))
                return "INS-VIS";
            else if (desc.Equals("Prescription Plan"))
                return "INS-PSC";
            else
                return desc;
        }

        protected void AddCoverageClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string ID = btn.ID.Replace("btnAdd_", "");
           

            string class_description = ((Label)FindControl("lblClass_" + ID.Substring(0, 1))).Text;
            string class_code = class_description.Replace("Class: ", "");
            class_code = class_code.Substring(0, class_code.IndexOf("-")).Trim();

            string category_code = GetCategoryCode(((Label)FindControl("lblPlanType_" + ID)).Text);


            string param = "'" + category_code + "','" + class_code + "','" + strAccount_Number + "','" + hidParam.Value + "'";
            lblScript.Text = "<script>Javascript:AddCvrg(" + param + ")</script>";
        }

        private string Get_class_code(string id)
        {
            string class_Desc = ((Label)FindControl("lblClass_" + id)).Text;
            class_Desc = class_Desc.Replace("Class: ", "");
            string[] class_code = class_Desc.Split('-');
            return class_code[0].Trim();

        }
       

        protected void GridDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            string id = ((RadGrid)sender).ID;
            id = id.Replace("GridView_","");
            string class_code= Get_class_code(id.Substring(0,1));
            
            string long_description = ((Label)FindControl("lblPlanName_" + id)).Text;            
            string category_code = long_description.Substring(long_description.Length - 12).Replace(")", "");
            string category_plan = category_code.Substring(category_code.Length - 3);
            category_code = category_code.Replace("-" + category_plan, "");
            DataTable tbl = Data.GetRates(strAccount_Number, ViewState["Version_Number"].ToString(), class_code, category_code, category_plan, strProcessing_year);
            ((RadGrid)sender).DataSource = tbl;
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            string strParam = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = strParam = "?accnt=" + strAccount_Number + "&ip=" + strBatch.Substring(0, 5) + "&py=" + strProcessing_year;
            else
                strParam = "?id=" + Request.Params["id"];
            
            Response.Redirect("help.aspx" + strParam, true);
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Data.finalize(strAccount_Number, strBatch, strUserID, strProcessing_year, strBatch);
            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";

            //DrawGrid();
            if (string.IsNullOrEmpty(session_id))
            {
                string strSaved = "<script>ShowSaved()</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strSaved", strSaved);
            }
            else
            {
                string strSaved = "<script>ShowSavedBas()</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strSaved", strSaved);
            }
        }

        protected void btnCancelMessage_Click(object sender, EventArgs e)
        {
            pnlData.Visible = true;
            dvNote.Visible = false;
        }

        protected void btnSaveMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (message.Length > 1000)
                message = message.Substring(0, 999);
            Data.Save_Comments(message, strAccount_Number, strBatch);
            btnCancelMessage_Click(null, null);
        }

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            dvNote.Visible = true;
            txtMessage.Text = Data.Get_Comments(strAccount_Number, strBatch);
        }

        

        
       
    }
}