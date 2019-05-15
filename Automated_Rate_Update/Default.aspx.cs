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

namespace Automated_Rate_Update
{
    public partial class _Default : System.Web.UI.Page
    {
        protected string strOldClass = "";
        protected string strOldCode = "";
        protected string strOldPlan = "";
        protected string strOldPDesc = "";
        protected string strAccount_Number = "";
        protected string strUserID = "";
        protected string strEmail = "";
        protected string strBatch = "";
        protected string strRateRenewal = "";
        protected string strProcessing_year = "";
        DataTable tblCb = null;

        protected string OneRow = @"<div class='Class_Heder' style='width=599px;[color]'>
 header1
</div>
<div class='CoveragePlan' >

 header2

</div>

<div class='fontsmall' style='width=599px;float:left'>
 <div class='Record' style='width=55px;float:left'><input type='text' id='txtmarate?' disabled=disabled size='10' onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&1'></div>
 <div class='Record' style='width=20px;float:left;visibility:hidden'><input type='text' id='txterrate?' size='10' onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&2'></div>
 <div class='Record' style='width=20px;float:left;visibility:hidden'><input type='text' id='txteerate?' size='10'onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&3'></div>
</div>";

        protected string OneRowEEDisabled = @"<div class='Class_Heder;[color]'>
 header1
</div>
<div class='fontsmall' style='width:599px; padding-left:0px'>
 header2
<div class='fontsmall' style='width=599px;float:left'>
 <div class='fontsmall' style='width=120px;float:left'><input type='text' id='txtmarate?' size='10' onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&1'></div>
 <div class='fontsmall' style='width=120px;float:left;visibility:hidden'><input type='text' id='txterrate?' size='10' onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&2'></div>
 <div class='fontsmall' style='width=120px;float:left;visibility:hidden'><input type='text' id='txteerate?' size='10' value='&&3' disabled='true'></div>
</div>
</div>";

        protected string strTitle = @"<div style='width:599px; '>
 <div class='fontsmall'style=' padding-left:30px;width:150px; float:left'>&nbsp;</div>
<div class='fontsmall' style='width=599px;float:left'>
 <div class='fontsmall' style='width=120px;float:left'><input type='text' id='txtmarate?' size='10' onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&1'></div>
 <div class='fontsmall' style='width=120px;float:left;visibility:hidden'><input type='text' id='txterrate?' size='10' onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&2'></div>
 <div class='fontsmall' style='width=120px;float:left;visibility:hidden'><input type='text' id='txteerate?' size='10'onkeypress='return isNumberKey(event)' onblur='calc(this)' value='&&3'></div>
</div>";

        //protected string strCvrg="<input id='Cb#' type='checkbox' />";
       // <input id="Checkbox1" checked="checked" type="checkbox" />
        protected string strCvrg = "<br /><input type='checkbox' id='Cb#' onclick='cb(this)' /><span class='fontsmall10' style='margin-bottom:5px;color:Black' >COBRA continuants should have the right to participate in open enrollment. Check here if you want CCS to send COBRA continuants an enrollment form to make open enrollment elections.</span>&nbsp;";
        protected string strCvrgChecked = "<br /><input type='checkbox' checked='checked' id='Cb#' onclick='cb(this)' /><span class='fontsmall10' style='margin-bottom:5px;color:Black' >COBRA continuants should have the right to participate in open enrollment. Check here if you want CCS to send COBRA continuants an enrollment form to make open enrollment elections.</span>&nbsp;";

        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            strUserID = ViewState["email"].ToString();
            strBatch = ViewState["batch"].ToString();
            strProcessing_year = ViewState["py"].ToString();
            strRateRenewal = ViewState["renewal"].ToString();
            hidParam.Value = Request.Params["id"];
            if (!IsPostBack)
            {
                dvNote.Visible = false;
                ShowProcessed();
                FillddlEffectiveDate(strAccount_Number);
                lblInstuction.Text = lblInstuction.Text.Replace("[Account Name]", SQLStatic.AccountData.AccountName(strAccount_Number) + " (" + strAccount_Number+")");
                lblInstuction.Text = lblInstuction.Text.Replace("[Date]", ddlEffectiveDate.SelectedItem.Text.Substring(0, 10));
                lblInstuction.Text = lblInstuction.Text.Replace("[cdate]", ddlEffectiveDate.SelectedItem.Text.Substring(0, 10));
                //lblInstuction.Text = lblInstuction.Text.Replace("[cdate]", Data.BeginingOfNextMonth());
                SetupAddPlans();
                return; ////////////////////////////////////////////////////////
            }            
            DrawGrid();
            if (!string.IsNullOrEmpty(hidSave.Value))
            {
                DoSave();
                string[] Values = new string[3];
                char[] splitter = { '~' };
                Values = hidSave.Value.Split(splitter);
                hidSave.Value = "";
                Response.Redirect("Covege_Main.aspx?c=" + Values[0].ToString() + "&s=" + Values[1].ToString() + "&a=" + Values[2].ToString() + "&id=" + hidParam.Value, true);
            }
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
        }

        

        private void SetupAddPlans()
        {
            string param = "'" + "INS-MED" + "','" + "XXXXX" + "','" + ViewState["accnt"] + "','" + hidParam.Value + "'";
           // hlAddMedical.NavigateUrl = "Javascript:AddCvrg(" + param + ")";

            param = "'" + "INS-DEN" + "','" + "XXXXX" + "','" + ViewState["accnt"] + "','" + hidParam.Value + "'";
            hlAddDental.NavigateUrl = "Javascript:AddCvrg(" + param + ")";

            param = "'" + "INS-VIS" + "','" + "XXXXX" + "','" + ViewState["accnt"] + "','" + hidParam.Value + "'";
            hlAddVision.NavigateUrl = "Javascript:AddCvrg(" + param + ")";
        }

        private void GetParameters(string param)
        {
            btnReset.Visible = false;
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
            
        }

        private void GetParametersBas()
        {
            ViewState["accnt"] = SQLStatic.Sessions.GetAccountNumber(session_id);
            ViewState["email"] = SQLStatic.Sessions.GetUserName(session_id);
            ViewState["batch"] = ViewState["batch"] = SQLStatic.Sessions.GetSessionValue(session_id, "batchid");
            ViewState["py"] = ViewState["batch"].ToString().Substring(6);
            ViewState["renewal"] = ViewState["batch"].ToString().Substring(0,5);
            btnReset.Visible = true;
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

        private void FillddlEffectiveDate(string strAccount_Number)
        {
            DataTable tbl = Data.Default_EffectiveDate_2(ViewState["accnt"].ToString(), ViewState["renewal"].ToString(), ViewState["py"].ToString());
            ListItem liDefault = new ListItem(tbl.Rows[0]["Formated_Date"].ToString(),tbl.Rows[0]["Formated_Date"].ToString());
            ddlEffectiveDate.Items.Add(liDefault);
            //tbl = Data.EfectiveDateList(strAccount_Number);
            //foreach (DataRow dr in tbl.Rows)
            //{
            //    ListItem li = new ListItem(dr["Formated_Date"].ToString(), dr["Formated_Date"].ToString());
            //    ddlEffectiveDate.Items.Add(li);
            //}
            ddlEffectiveDate.SelectedIndex = 0;
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
            DrawGrid();
            jscriptsFunctions.Misc.Alert(Page, "Item(s) reactivated successfully.");
        }

        private void Remove(string strRemove)
        {
            string[] Values = new string[2];
            char[] splitter = { '~' };
            Values = strRemove.Split(splitter);
            Data.remove(strAccount_Number, Values[0], Values[1],strProcessing_year, strBatch);
            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";
            DrawGrid();
            jscriptsFunctions.Misc.Alert(Page, "Item(s) marked successfully for removal.");
        }

        

        private void DrawGrid()
        {
            DataTable tbl = Data.GetTable(strAccount_Number,strProcessing_year,strRateRenewal);
            tblCb = Data.Get_In_OE(strAccount_Number, strBatch);
            gvRates.DataSource = tbl;
            gvRates.DataBind();
            if (!cbAutoCalcEERate.Checked)
                CheckError();
            tblCb.Dispose();

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //gvRates.DataSource = tbl;
            //gvRates.DataBind();
        }

        protected string Cell0Text(DataRow dr, int RowCount)
        {
            string strClassCode = "Class: " + dr["class_code"].ToString() + " - " + dr["description"].ToString();
            string strCategory_Code = dr["category_code"].ToString();
            if (dr["category_code"].ToString().Equals("INS-MED")) strCategory_Code = "Medical Plans";
            else if (dr["category_code"].ToString().Equals("INS-DEN")) strCategory_Code = "Dental Plans";
            else if (dr["category_code"].ToString().Equals("INS-VIS")) strCategory_Code = "Vision Plans";

            string param = "'" + dr["category_code"].ToString() + "','" + dr["class_code"].ToString() + "','" + strAccount_Number + "','" +hidParam.Value+ "'";
            strCategory_Code += "&nbsp;&nbsp;<a href=\"Javascript:AddCvrg(" + param + ")\">Add A New " + strCategory_Code.Replace("Plans", "Plan") + "</a>";


            //string param = "~c=" + dr["category_code"].ToString() + "#s=" + dr["class_code"].ToString()+"&a="+strAccount_Number;
            //strCategory_Code += "&nbsp;&nbsp;<a href='Covege_Main.aspx" + param + "'>Add " + strCategory_Code.Replace("Plans", "Plan") + "</a>";

            string retResult = "";

            if (dr["category_code"].ToString() != strOldCode)
            {
                retResult = "<div class='CoveragePlan' style='padding-left:0px;font-weight:bold;'>" + strCategory_Code + "</div>";
                strOldCode = dr["category_code"].ToString();
            }

            if (dr["class_code"].ToString() != strOldClass)
            {
                //retResult = "<div class='fontsmall' style='font-weight:bold;border-top-style:solid; border-top-width:1px;color: dimgray;'>" + strClassCode + "</div>";
                retResult += strClassCode;
                strOldClass = dr["class_code"].ToString();
            }
            
            if (dr["long_description"].ToString() != strOldPDesc)
            {                
                string strRemove = "";
                string strCverCount= Data.Cvrg_Count(strAccount_Number, strProcessing_year, dr["category_code"].ToString());
                if (!strCverCount.Equals("1"))
                {
                    
                    if (!dr["status"].ToString().Equals("R"))
                    {
                        string strParam = "\"" + dr["long_description"].ToString() + "\",\"" + dr["description"].ToString() + "\",\"" + dr["class_code"].ToString() + "\"";
                        strRemove = "<span style='float:right; background-color: #C0C0C0; border-style: outset'><a href='Javascript:remove(" + strParam + ")' >Remove</a></span>";
                    }
                    else
                    {
                        string strParam = "\"" + dr["long_description"].ToString() + "\",\"" + dr["description"].ToString() + "\",\"" + dr["class_code"].ToString() + "\"";
                        strRemove = "<span style='float:right; background-color: #C0C0C0; border-style: outset'><a href='Javascript:Reactivate(" + strParam + ")'>Reactivate</a></span>";
                    }
                }
                string strID=dr["category_code"].ToString().Replace("-","_")+dr["category_plan"].ToString()+dr["class_code"].ToString();
                string strCB = strCvrg;
                if (CBCHecked(strID))
                    strCB = strCvrgChecked;
                string strBackColor = "background-color:White;"; 
                if (string.IsNullOrEmpty(dr["unique_id"].ToString()))
                    strBackColor = "background-color:Yellow;";
                if (dr["status"].ToString().Equals("R"))
                    strBackColor = "background-color:LightPink;";
                retResult += "<div class='LongDesc' style='"+strBackColor+" padding-left:20px;font-weight:bold;width: 500px'>" +"<span style='width:270px;'>"+dr["long_description"].ToString() + "</span>&nbsp;" + strRemove + strCB.Replace("#", strID) + "</div>";

                strOldPDesc = dr["long_description"].ToString();                
            }
            //retResult += "<div style='height:18px; padding-left:30px'>" + dr["fs_description"].ToString() + "</div>";
            if (retResult == "")
                retResult = "<div style='height:1px;'></div>";
            return retResult;
        }

        private bool CBCHecked(string strID)
        {
            foreach (DataRow dr in tblCb.Rows)
            {
                if ((dr["lookup"].ToString().Equals(strID.Replace("_","-")))&&(dr["In_open_enrollment"].ToString().Equals("1")))
                    return true;
            }
            return false;
        }



        private string strValue(string strAllValues, string strName, string strDefaultValue)
        {
            string strValue = strDefaultValue;

            string str = strAllValues;
            int epos;
            string strItem;
            string[] nameValue = new string[2];
            char[] splitter = { '=' };
            while (str.Length > 0)
            {
                epos = str.IndexOf("]");
                strItem = str.Substring(1, epos - 1);
                nameValue = strItem.Split(splitter);
                if (nameValue[0] == strName)
                    strValue = nameValue[1];
                str = str.Remove(0, epos + 1);
            }
            return strValue;
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            DataTable dt = (DataTable)Repeater1.DataSource;
            if (dt == null)
                return;
            try
            {
                if (e.Item.ItemIndex == -1)
                {
                    return;
                }
                if (dt.Rows.Count < e.Item.ItemIndex)
                    return;
                string strIndex = dt.Rows[e.Item.ItemIndex]["unique_id"].ToString(); /*e.Row.RowIndex.ToString() ;*/

                Label lbl = new Label();
                lbl.ID = "lbl_" + strIndex;
                if (cbAutoCalcEERate.Checked)
                    lbl.Text = OneRowEEDisabled.Replace("header1", Cell0Text(dt.Rows[e.Item.ItemIndex],0)).Replace("?", strIndex);
                else
                    lbl.Text = OneRow.Replace("header1", Cell0Text(dt.Rows[e.Item.ItemIndex],0)).Replace("?", strIndex);
                lbl.Text = lbl.Text.Replace("header2", "<div style=' padding-left:30px;width:150px; float:left'>" + dt.Rows[e.Item.ItemIndex]["fs_description"].ToString() + "</div>");
                lbl.Text = lbl.Text.Replace("&&1", strValue(hid1.Value, "txtmarate" + strIndex, dt.Rows[e.Item.ItemIndex]["rate_amount"].ToString()));
                lbl.Text = lbl.Text.Replace("&&2", strValue(hid1.Value, "txterrate" + strIndex, dt.Rows[e.Item.ItemIndex]["employer_split"].ToString()));
                if (cbAutoCalcEERate.Checked)
                {
                    double dblMainRate = 0;
                    if (dt.Rows[e.Item.ItemIndex]["rate_amount"].ToString() != "")
                        dblMainRate = Convert.ToDouble(strValue(hid1.Value, "txtmarate" + strIndex, dt.Rows[e.Item.ItemIndex]["rate_amount"].ToString()));
                    double dblERRate = 0;
                    if (dt.Rows[e.Item.ItemIndex]["employer_split"].ToString() != "")
                        dblERRate = Convert.ToDouble(strValue(hid1.Value, "txterrate" + strIndex, dt.Rows[e.Item.ItemIndex]["employer_split"].ToString()));
                    string streeRate = (Math.Round((dblMainRate - dblERRate), 2)).ToString();
                    lbl.Text = lbl.Text.Replace("&&3", streeRate);
                }
                else
                    lbl.Text = lbl.Text.Replace("&&3", strValue(hid1.Value, "txteerate" + strIndex, dt.Rows[e.Item.ItemIndex]["employee_split"].ToString()));
                e.Item.Controls.Add(lbl);


            }
            catch { }
        }

        private void ProcessesError(string str, ArrayList ar)
        {
            str = str.Replace("=0", "=1");
            for (int i = ar.Count - 1; i >= 0; i--)
            {
                if (ar[i].ToString() == str)
                    ar.Remove(str);
            }
        }

        private ArrayList SplitText(string str)
        {
            int epos;
            string strItem;
            ArrayList ar = new ArrayList();
            while (str.Length > 0)
            {
                epos = str.IndexOf("]");
                strItem = str.Substring(1, epos - 1);
                if (strItem.IndexOf("=1") != -1)
                    ar.Add(strItem);
                else
                    ProcessesError(strItem, ar);
                str = str.Remove(0, epos + 1);
            }
            return ar;
        }

        private void ShowError(ArrayList ar)
        {
            string strCalc;
            string str;
            foreach (string arstr in ar)
            {
                str = arstr;
                str = str.Replace("=1", "");
                strCalc = "<script>Javascript:forceClac('" + str + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), str, strCalc);
            }
        }

        protected bool CheckError()
        {
            ArrayList ar = SplitText(hidError.Value);

            if (ar.Count == 0)
                return true;
            else
            {
                ShowError(ar);
                return false;
            }
        }

        protected ArrayList SplitChangedText(string str)
        {
            int epos;
            string strItem;
            ArrayList ar = new ArrayList();
            while (str.Length > 0)
            {
                epos = str.IndexOf("]");
                strItem = str.Substring(1, epos - 1);
                ar.Add(strItem);
                str = str.Remove(0, epos + 1);
            }
            return ar;
        }

        public static void SaveArray(int intCount, string[] strRecordID, string[] strFieldName, string[] strRate, string[] strUserName) 
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(" pkg_automated_rate_update.saverate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ArrayBindCount = intCount;

            OracleParameter paramRecordID = new OracleParameter("record_id_", OracleDbType.Varchar2);
            paramRecordID.Direction = ParameterDirection.Input;
            paramRecordID.Value = strRecordID;
            cmd.Parameters.Add(paramRecordID);

            OracleParameter paramFieldName = new OracleParameter("fieldname_", OracleDbType.Varchar2);
            paramFieldName.Direction = ParameterDirection.Input;
            paramFieldName.Value = strFieldName;
            cmd.Parameters.Add(paramFieldName);

            OracleParameter paramRates = new OracleParameter("rates_", OracleDbType.Varchar2);
            paramRates.Direction = ParameterDirection.Input;
            paramRates.Value = strRate;
            cmd.Parameters.Add(paramRates);

            OracleParameter paramUserName = new OracleParameter("user_name_", OracleDbType.Varchar2);
            paramUserName.Direction = ParameterDirection.Input;
            paramUserName.Value = strUserName;
            cmd.Parameters.Add(paramUserName);
            

            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }

        protected bool DoSave()
        {
            if (!Save_OE())
                return false;
            if (string.IsNullOrEmpty(hid1.Value))
                return false;
            ArrayList ar = SplitChangedText(hid1.Value);
            hid2.Value = "";
            string[] fieldNames = new string[ar.Count];
            string[] record_id = new string[ar.Count];
            string[] rates = new string[ar.Count];
            string[] usernames = new string[ar.Count];
            string[] Batch = new string[ar.Count];
            int i = 0;
            string strRecordID = "";
            foreach (string str in ar)
            {
                fieldNames[i] = str.Substring(0, 9);
                strRecordID = str.Remove(0, 9);
                record_id[i] = strRecordID.Substring(0, strRecordID.IndexOf("="));
                rates[i] = str.Remove(0, str.IndexOf("=") + 1);
                usernames[i] = strUserID;
                i++;
            }
            SaveArray(ar.Count, record_id, fieldNames, rates, usernames);
            hid1.Value = "";
            hidError.Value = "";
            return true;
        }

        private bool Save_OE()
        {
            if (string.IsNullOrEmpty(hidCB.Value))
                return true;
            hidCB.Value = hidCB.Value.Remove(0, 1);
            ArrayList ar = new ArrayList(hidCB.Value.Split(new char[] { '~' }));
            hidCB.Value = "";
            string[] account_number      = new string[ar.Count];
            string[] processing_year     = new string[ar.Count];
            string[] in_open_enrollment  = new string[ar.Count];
            string[] category_code       = new string[ar.Count];
            string[] categoty_plan       = new string[ar.Count];
            string[] class_code          = new string[ar.Count];
            string[] batch_id            = new string[ar.Count];
            int i = 0;
            foreach (string str in ar)
            {
                account_number [i] = ViewState["accnt"].ToString();
                processing_year [i] = ViewState["py"].ToString();
                in_open_enrollment[i] = str.Substring(0, 1);
                if (str.Substring(3, 3).Replace("_", "-").Equals("HRA"))
                {
                    category_code[i] = str.Substring(3, 3).Replace("_", "-");
                    categoty_plan[i] = str.Substring(6, 3);
                    class_code[i] = str.Substring(9);
                }
                else
                {
                    category_code[i] = str.Substring(3, 7).Replace("_", "-");
                    categoty_plan[i] = str.Substring(10, 3);
                    class_code[i] = str.Substring(13);
                }
                batch_id [i] = ViewState["batch"].ToString();
                i++;
            }



            SaveCBArray(ar.Count, account_number,processing_year,in_open_enrollment,category_code,categoty_plan,class_code,batch_id);
            hidCB.Value = "";
            hidError.Value = "";


            return true;
        }


        public static void SaveCBArray(int intCount, string[] account_number, string[] processing_year, string[] in_open_enrollment, string[] category_code, 
            string[] categoty_plan, string[] class_code, string[] batch_id)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(" pkg_automated_rate_update.Save_In_OE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ArrayBindCount = intCount;

            OracleParameter parmaAccountNumber = new OracleParameter("account_number_", OracleDbType.Varchar2);
            parmaAccountNumber.Direction = ParameterDirection.Input;
            parmaAccountNumber.Value = account_number;
            cmd.Parameters.Add(parmaAccountNumber);

            OracleParameter paramprocessing_year = new OracleParameter("processing_year_", OracleDbType.Varchar2);
            paramprocessing_year.Direction = ParameterDirection.Input;
            paramprocessing_year.Value = processing_year;
            cmd.Parameters.Add(paramprocessing_year);

            OracleParameter paramRates = new OracleParameter("in_open_enrollment_", OracleDbType.Varchar2);
            paramRates.Direction = ParameterDirection.Input;
            paramRates.Value = in_open_enrollment;
            cmd.Parameters.Add(paramRates);

            OracleParameter paramcategory_code = new OracleParameter("category_code_", OracleDbType.Varchar2);
            paramcategory_code.Direction = ParameterDirection.Input;
            paramcategory_code.Value = category_code;
            cmd.Parameters.Add(paramcategory_code);

            OracleParameter parmcategoty_plan = new OracleParameter("categoty_plan_", OracleDbType.Varchar2);
            parmcategoty_plan.Direction = ParameterDirection.Input;
            parmcategoty_plan.Value = categoty_plan;
            cmd.Parameters.Add(parmcategoty_plan);

            OracleParameter paramclass_code = new OracleParameter("class_code_", OracleDbType.Varchar2);
            paramclass_code.Direction = ParameterDirection.Input;
            paramclass_code.Value = class_code;
            cmd.Parameters.Add(paramclass_code);

            OracleParameter parambatch_id = new OracleParameter("batch_id_", OracleDbType.Varchar2);
            parambatch_id.Direction = ParameterDirection.Input;
            parambatch_id.Value = batch_id;
            cmd.Parameters.Add(parambatch_id);


            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }


        

        protected void cbAutoCalcEERate_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gvRates_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvRates.DataSource;
            if (dt == null)
                return;
            try
            {
                if (e.Row.RowIndex == -1)
                {
                    return;
                }
                if (dt.Rows.Count < e.Row.RowIndex)
                    return;
                string strIndex = dt.Rows[e.Row.RowIndex]["record_id"].ToString(); /*e.Row.RowIndex.ToString() ;*/

                Label lbl = new Label();
                lbl.ID = "lbl_" + strIndex;
                if (cbAutoCalcEERate.Checked)
                    lbl.Text = OneRowEEDisabled.Replace("header1", Cell0Text(dt.Rows[e.Row.RowIndex], dt.Rows.Count)).Replace("?", strIndex).Replace("~", "?")/*.Replace("#","&")*/;
                else
                    lbl.Text = OneRow.Replace("header1", Cell0Text(dt.Rows[e.Row.RowIndex], dt.Rows.Count)).Replace("?", strIndex).Replace("~", "?")/*.Replace("#", "&")*/;
                string strBackColor = "background-color:White;";
                if (string.IsNullOrEmpty(dt.Rows[e.Row.RowIndex]["unique_id"].ToString()))
                    strBackColor = "background-color:Yellow;";
                if (dt.Rows[e.Row.RowIndex]["status"].ToString().Equals("R"))
                    strBackColor = "background-color:LightPink;";
                lbl.Text = lbl.Text.Replace("[color]", strBackColor);

                lbl.Text = lbl.Text.Replace("header2", "<div class='Record' style=' padding-left:30px;width:150px; float:left'>" + dt.Rows[e.Row.RowIndex]["fs_description"].ToString() + "</div>");
                lbl.Text = lbl.Text.Replace("&&1", strValue(hid1.Value, "txtmarate" + strIndex, dt.Rows[e.Row.RowIndex]["rate_amount"].ToString()));
                lbl.Text = lbl.Text.Replace("&&2", strValue(hid1.Value, "txterrate" + strIndex, dt.Rows[e.Row.RowIndex]["employer_split"].ToString()));
                if (cbAutoCalcEERate.Checked)
                {
                    double dblMainRate = 0;
                    if (dt.Rows[e.Row.RowIndex]["rate_amount"].ToString() != "")
                        dblMainRate = Convert.ToDouble(strValue(hid1.Value, "txtmarate" + strIndex, dt.Rows[e.Row.RowIndex]["rate_amount"].ToString()));
                    double dblERRate = 0;
                    if (dt.Rows[e.Row.RowIndex]["employer_split"].ToString() != "")
                        dblERRate = Convert.ToDouble(strValue(hid1.Value, "txterrate" + strIndex, dt.Rows[e.Row.RowIndex]["employer_split"].ToString()));
                    string streeRate = (Math.Round((dblMainRate - dblERRate), 2)).ToString();
                    lbl.Text = lbl.Text.Replace("&&3", streeRate);                    
                }
                else
                    lbl.Text = lbl.Text.Replace("&&3", strValue(hid1.Value, "txteerate" + strIndex, dt.Rows[e.Row.RowIndex]["employee_split"].ToString()));

                if (!dt.Rows[e.Row.RowIndex]["status"].ToString().Equals("R"))
                    lbl.Text = lbl.Text.Replace("disabled=disabled", "");                
                TableCell cell3 = e.Row.Cells[0];
                cell3.Controls.Add(lbl);
                if (string.IsNullOrEmpty(dt.Rows[e.Row.RowIndex]["unique_id"].ToString()))
                    cell3.BackColor = System.Drawing.Color.Yellow;
                if (dt.Rows[e.Row.RowIndex]["status"].ToString().Equals("R"))
                    cell3.BackColor = System.Drawing.Color.LightPink;// ColorTranslator.FromHtml("#CCFFCC");


            }
            catch { }
        }

        protected void btnSavePend_Click(object sender, EventArgs e)
        {
            if (DoSave())
            {
                strOldClass = "";
                strOldCode = "";
                strOldPlan = "";
                strOldPDesc = "";
                                
            }
            DrawGrid();
            jscriptsFunctions.Misc.AlertSaved(Page);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
            Data.finalize(strAccount_Number,ddlEffectiveDate.SelectedValue,strUserID,strProcessing_year,strBatch);
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

        protected void btnlnkAddMedicalPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("Covege_Main.aspx?c=" + "INS-MED" + "&s=" + "I" + "&a=" + ViewState["accnt"].ToString() + "&id=" + Request.Params["id"], true);
        }

        protected void btnlnkAddDentalPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("Covege_Main.aspx?c=" + "INS-DEN" + "&s=" + "I" + "&a=" + ViewState["accnt"].ToString() + "&id=" + Request.Params["id"], true);
        }

       

       

        protected void btnCancelMessage_Click(object sender, EventArgs e)
        {
            tbMain.Visible = true;
            dvNote.Visible = false;
        }

        protected void btnSaveMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (message.Length>1000)
                message = message.Substring(0,999);
            Data.Save_Comments(message, strAccount_Number, strBatch);
            btnCancelMessage_Click(null, null);
        }

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            tbMain.Visible = false;
            dvNote.Visible = true;
            txtMessage.Text = Data.Get_Comments(strAccount_Number, strBatch);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Data.Reset(ViewState["batch"].ToString(), ViewState["accnt"].ToString());
            DrawGrid();
        }
        
    }
}
