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
using System.Text;

namespace Automated_Rate_Update
{
    public partial class Default_2 : System.Web.UI.Page
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
        string currentClass = string.Empty;
        string CurrentCatCode = string.Empty;
        string CurrentCatPlan = string.Empty;
        //DataTable tblCb = null;
        string session_id = "";
        string strClassCodeTable = @"<table class='masterwidth marginbottom5 paddingbottomm5 bottomline ' style='margin-left: auto;
        margin-right: auto'>
        <tr id='trClass[code1]' runat='server' class='masterwidth marginbottom5 paddingbottomm5 bottomline '
            style='margin-left: auto; margin-right: auto'>
            <td>
                <span class='dataSetctionTitle'>[class]</span>
            </td>
        </tr>
    </table>";
        string strPlanNameTable = @"<table class='masterwidth marginbottom5 ' style='margin-left: auto;
        margin-right: auto'>
    <tr id='trPlanType[code2]' runat='server' class='cvrgrow marginbottom5 paddingbottomm5 bottomline' style='margin-left: auto;
        margin-right: auto'>
            <td>
                <div class='cvrgrow marginbottom5 paddingbottomm5 bottomline'>
                    <span class='dataSetctionTitle'>[Type]</span><br />
                    <span>If you want add a new [Type], click this
                        button:</span>
                    <input id='btnAdd' type='button'  value='Add Another [Type]' onclick='return btnAdd_onclick([param])' />
                </div>
            </td>
        </tr>
    </table>";
        string strCoverageTable = @"<table class='masterwidth [color]  ' style='margin-left: auto;
        margin-right: auto'>
    <tr>
            <td>
                <div class='raterow marginbottom5 paddingbottomm5 bottomline'>
                    <span  class='dataSubSetctionTitle'>[planname]</span><br />

                    <table>
                        <tr>
                            <td>
                                <img alt='' src='[loc]' />
                            </td>
                            <td>
                                <span>Will send COBRA continuants open enrollment information about this plan</span>
                            </td>
                        </tr>
                    </table>
                    <div class='marginbottom2'>
                        &nbsp;
                    </div>
                    <table class='ratewidth'>
                        <tr>
                            <td align='center' valign='top'>
                                [Grid]
                            </td>
                            <td class='ManagePlan' align='center' valign='top'>
                                <span><strong><span 
                                    style='font-size: 10pt; font-family: Arial;'>Manage This Plan</span></strong></span>
                                <br />
                                <span><strong><span 
                                    style='color: red; font-family: Arial;font-size: 9pt;'>Changes Effective [effdate]</span></strong></span>
                                <br />
                                <br />
                                <div style='text-align: left;' class='ManagePlan marginbottom10'>
                                    [Action]
                                </div>
                                <input  type='button' value='Make Change' onclick='return btnChange__onclick([param2])' />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        </table>";
        string strMedChoices = @"<table id='tbActionmed' align='left' cellpadding='0' cellspacing='5' class='ManagePlan'>
        <tr>
            <td valign='top'>
                <input id='same_code_' name='Action_code' value='same' type='radio' />
            </td>
            <td>
                KEEP this plan AND rating methodology, BUT MODIFY the Rates.
            </td>
        </tr>
        <tr class='marginbottom5'>
            <td valign='top'>
                <input id='change_code_' name='Action_code' value='change' type='radio' />
            </td>
            <td>
                KEEP this plan BUT CHANGE THE RATING METHOD (Requires Terminating Plan and Adding
                a New Plan. All current plan information -- except rates -- will be copied from
                this plan to the new plan, automatically).
            </td>
        </tr>
        <tr class='marginbottom5'>
            <td valign='top'>
                <input id='remove_code_' name='Action_code' value='remove' type='radio'  />
            </td>
            <td>
                [RA]
            </td>
        </tr>
    </table>";
        string strOtherChoice = @"<table id='tbActionOther' align='left' cellpadding='0' cellspacing='5' class='ManagePlan'>
                                    <tr>
                                        <td valign='top'>
                                           <input id='Action_code' name='Action_code' value='same' type='radio' />
                                        </td>
                                        <td>
                                            KEEP this plan AND rating methodology, BUT MODIFY the Rates.
                                        </td>
                                    </tr>
                                    <tr class='marginbottom5'>
                                        <td valign='top'>
                                           <input id='Action_code' name='Action_code' value='remove' type='radio'  />
                                        </td>
                                        <td>
                                            [RA]
                                        </td>
                                    </tr>
                                </table>";
        //String strRemove = "Terminate this plan with NO CORRESPONDING REPLACEMENT PLAN (Do Not Use this option if you are replacing this plan with a new plan; use the 2nd radio button above instead).";
        String strRemove = "Terminate this plan.";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("Default4.aspc?id=" + Request.Params["id"], true);
            //return;
            try { session_id = Request.Cookies["Session_ID"].Value.ToString(); }
            catch { session_id = string.Empty; }
            if (!string.IsNullOrEmpty(session_id))
            {
                string userGroup = SQLStatic.Sessions.GetUserGroupID(session_id);
                if (!userGroup.Equals("1"))
                {
                    session_id = string.Empty;
                    htmbtnReset.Visible = false;
                    Panel4.Visible = false;
                    htmBtnManagePlans.Visible = false;
                }

            }
            if (ViewState["accnt"] == null)
            {
                if (!string.IsNullOrEmpty(session_id))
                    GetParametersBas();
                else
                    GetParameters(Request.Params["id"]);


            }

            if (!IsPostBack)
            {
                hidPendCvrg.Value = "?acnt=" + ViewState["accnt"].ToString() + "&py=" + ViewState["py"].ToString() + "&batch=" + ViewState["batch"].ToString();
            }

            strAccount_Number = ViewState["accnt"].ToString();

            strEmail = ViewState["email"].ToString();
            strUserID = ViewState["user_id"].ToString();
            strBatch = ViewState["batch"].ToString();
            strProcessing_year = ViewState["py"].ToString();
            strRateRenewal = ViewState["renewal"].ToString();
            hidParam.Value = Request.Params["id"];
            lblForm.Text = string.Empty;
            BuildRates();

            if (!IsPostBack)
            {
                ShowProcessed();
                FillddlEffectiveDate(strAccount_Number);
            }
            //btnResetMetal.Attributes.Add("onclick", "metal()");
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

            if (hidSave.Value.Equals("save"))
            {
                hidSave.Value = string.Empty;
                btnFinish_Click(null, null);
                return;
            }

            if (hidSave.Value.Equals("Reset"))
            {
                hidSave.Value = string.Empty;
                Reset();
                return;
            }
            if (!IsPostBack)
            {
                hidPendCvrg.Value = "?acnt="+ViewState["accnt"].ToString()+"&py="+ ViewState["py"].ToString()+"&batch="+ ViewState["batch"].ToString();
            }
        }

        private void Reactivate(string strReactivate)
        {
            string[] Values = new string[2];
            char[] splitter = { '~' };
            Values = strReactivate.Split(splitter);
            string[] class_code = Values[0].Split('!');

            Data.reactivate(strAccount_Number, class_code[2], Values[1], strProcessing_year, strBatch);

            //string account_number, string class_code, string Nameofmedicalplan, string Processing_Year, string strBatch)

            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";
            lblForm.Text = string.Empty;
            BuildRates();
            jscriptsFunctions.Misc.Alert(Page, "Item(s) reactivated successfully.");
        }

        private void Remove(string strRemove)
        {
            string[] Values = new string[2];
            char[] splitter = { '~' };
            Values = strRemove.Split(splitter);
            string[] class_code = Values[0].Split('!');

            Data.remove_ver1(strAccount_Number, class_code[2], Values[1], class_code[0], class_code[1], strProcessing_year, strBatch);
            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";
            lblForm.Text = string.Empty;
            BuildRates();
            jscriptsFunctions.Misc.Alert(Page, "Item(s) marked successfully for removal.");
        }

        private void GetParametersBas()
        {
            ViewState["accnt"] = SQLStatic.Sessions.GetAccountNumber(session_id);
            ViewState["email"] = SQLStatic.Sessions.GetUserName(session_id);
            ViewState["user_id"] = SQLStatic.Sessions.GetUserName(session_id);
            ViewState["batch"] = SQLStatic.Sessions.GetSessionValue(session_id, "batchid");
            ViewState["py"] = SQLStatic.Sessions.GetSessionValue(session_id, "processing_year");
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
            hidId.Value = param;
            htmBtnManagePlans.Visible = false;
            ViewState["accnt"] = tbl.Rows[0]["account_number"].ToString();
            ViewState["email"] = tbl.Rows[0]["email"].ToString();
            ViewState["user_id"] = tbl.Rows[0]["user_name_"].ToString();
            ViewState["batch"] = tbl.Rows[0]["batch_id"].ToString();
            ViewState["py"] = tbl.Rows[0]["processing_year"].ToString();
            ViewState["renewal"] = tbl.Rows[0]["rate_renewal"].ToString();
        }

        private void FillddlEffectiveDate(string strAccount_Number)
        {
            DataTable tbl = Data.Default_EffectiveDate_2(ViewState["accnt"].ToString(), ViewState["renewal"].ToString(), ViewState["py"].ToString());
        }

        private void BuildRates()
        {
            DataTable tbl = Data.GetClasses(strAccount_Number, strProcessing_year, strRateRenewal, ViewState["user_id"].ToString());
            ViewState["Version_Number"] = tbl.Rows[0]["version_number"].ToString();
            string strclass = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                strclass = strClassCodeTable.Replace("[class]", "Class: " + dr["class_code"].ToString() + " - " + dr["description"].ToString());
                lblForm.Text += strclass;
                ViewState["Class_Code"] = dr["class_code"].ToString();
                ViewState["C_Desc"] = dr["description"].ToString();
                BuildPlanTypes();
            }

        }

        private void BuildPlanTypes()
        {
            DataTable tbl = Data.GetPlanTypes(strAccount_Number, ViewState["Version_Number"].ToString(), ViewState["Class_Code"].ToString());
            string strPlanType = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {

                string paramter = "\"?c=c_&s=s_&a=a_&id=" + hidParam.Value + "\"";
                paramter = paramter.Replace("c_", dr["category_code"].ToString()).Replace("s_", ViewState["Class_Code"].ToString()).Replace("a_", strAccount_Number);
                strPlanType = strPlanNameTable.Replace("[Type]", dr["Plan_Name"].ToString()).Replace("[param]", paramter);
                lblForm.Text += strPlanType;
                ViewState["Category_Code"] = dr["category_code"].ToString();
                BuildCoverages();
            }
        }

        private void BuildCoverages()
        {
            DataTable tbl = Data.GetCoverages(strAccount_Number, ViewState["Version_Number"].ToString(), ViewState["Class_Code"].ToString(), ViewState["Category_Code"].ToString(), strBatch);
            string strCoverage = string.Empty;
            string strloc = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                ViewState["Category_Plan"] = dr["category_plan"].ToString();
                strCoverage = strCoverageTable.Replace("[planname]", dr["long_description"].ToString() + " - (" + ViewState["Category_Code"].ToString() + "-" + dr["category_plan"].ToString() + ")");
                if (dr["in_oe"].ToString().Equals("1"))
                    strloc = "https://www.myenroll.com/images/yes.gif";
                else
                    strloc = "https://www.myenroll.com/images/No.gif";
                strCoverage = strCoverage.Replace("[loc]", strloc);

                string ratetype = Data.GetRateType(strAccount_Number, ViewState["Version_Number"].ToString(), ViewState["Class_Code"].ToString(),
                                 ViewState["Category_Code"].ToString(), dr["category_plan"].ToString(), strProcessing_year);                

                string strParamurl = "?accnt=" + strAccount_Number +
                                  "&ver=" + ViewState["Version_Number"].ToString() +
                                  "&class=" + ViewState["Class_Code"].ToString() +
                                  "&catcode=" + ViewState["Category_Code"].ToString() +
                                  "&catplan=" + dr["category_plan"].ToString() +
                                  "&py=" + strProcessing_year +
                                  "&batch=" + strBatch +
                                  "&cvrg=" + HttpUtility.HtmlEncode(dr["long_description"].ToString().Replace("#", "%23")) +
                                  "&ratetype=" + ratetype +
                                  "&action=[actionntype]" +
                                  "&id=" + hidParam.Value;
                strParamurl = "\"" + strParamurl + "\"";

                string strParam = "\"" + ViewState["Category_Code"].ToString() + dr["category_plan"].ToString() + "_" + ViewState["Class_Code"].ToString() + "\"";

                string htmTable = string.Empty;
                if (ratetype.Equals("1"))
                    htmTable = buildStatusTable(dr["long_description"].ToString());
                if (ratetype.Equals("0"))
                    htmTable = buildTobbacoNonTobbaco(dr["long_description"].ToString());
                if (ratetype.Equals("2"))
                    htmTable = buildAgeRate(dr["long_description"].ToString());


                string strColor = string.Empty;
                string strMessage = string.Empty;
                string strParam3 = string.Empty;
                strParam3 = "\"" + dr["long_description"].ToString() + "\",\"" + ViewState["C_Desc"].ToString() + "\",\"" + ViewState["Class_Code"].ToString() + "\"";
                if (dr["status"].ToString().Equals("R"))
                {
                    strColor = "RemovedColor";
                    strMessage = "Reactivate Coverage";
                    //strParam3 = "\"" + dr["long_description"].ToString() + "\",\"" + ViewState["C_Desc"].ToString() + "\",\"" + ViewState["Class_Code"].ToString() + "\"";
                    hidAction.Value = "A";
                }
                if (dr["status"].ToString().Equals("A"))
                {
                    strColor = "ActiverColor";
                    strMessage = strRemove;
                    if (!dr["Replace"].ToString().Equals("0"))
                        strMessage = "Reset to Original Coverage";
                    //strParam3 = "\"" + dr["long_description"].ToString() + "\",\"" + ViewState["Class_Code"].ToString() + "\",\"" + ViewState["Class_Code"].ToString() + "\"";
                    hidAction.Value = "R";
                }
                if (dr["status"].ToString().Equals("N"))
                {
                    strColor = "NewActiveColor";
                    strMessage = strRemove;
                    if (!dr["Replace"].ToString().Equals("0"))
                        strMessage = "Reset to Original Coverage";
                    //strParam3 = "\"" + dr["long_description"].ToString() + "\",\"" + ViewState["Class_Code"].ToString() + "\",\"" + ViewState["Class_Code"].ToString() + "\"";
                    hidAction.Value = "R";
                }
                string combined = ViewState["Category_Code"].ToString() + "!" + dr["category_plan"].ToString() + "!" + ViewState["Class_Code"].ToString();
                strCoverage = strCoverage.Replace("[Action]", GetAction(dr)).Replace("[Grid]", htmTable).Replace("[color]", strColor).
                Replace("[RA]", strMessage).Replace("[effdate]", strBatch).Replace("[param2]", strParam + "," + strParamurl + ",\"" + ratetype +
                "\",\"" + dr["long_description"].ToString() + "\",\"" + ViewState["C_Desc"].ToString() + "\",\"" +
                combined + "\",\"" + hidAction.Value + "\",\"" + Request.Params["id"] + "\"");

                lblForm.Text += strCoverage;
            }
        }

        private string GetAction(DataRow dr)
        {
            string strAction = strMedChoices;
            if (!ViewState["Category_Code"].ToString().Equals("INS-MED"))
                strAction = strOtherChoice;
            string strParam = ViewState["Category_Code"].ToString() + ViewState["Category_Plan"].ToString() + "_" + ViewState["Class_Code"].ToString();
            strAction = strAction.Replace("Action_code", strParam);

            return strAction;
        }

        private string buildStatusTable(string coverage_name)
        {
            DataTable tbl = Data.GetRates(strAccount_Number, ViewState["Version_Number"].ToString(), ViewState["Class_Code"].ToString(), ViewState["Category_Code"].ToString(),
                ViewState["Category_Plan"].ToString(), strProcessing_year, ViewState["batch"].ToString());
            StringBuilder sb = new StringBuilder();
            sb.Append(BASUSA.HTML_Table.StartTable("Statusciverage", "Statusciverage", false, "htmtable"));
            sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Family Status"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Rate Amount"));
            sb.Append(BASUSA.HTML_Table.CloseTR());
            foreach (DataRow dr in tbl.Rows)
            {
                sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Family_Status"].ToString()));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Rate"].ToString()));
                sb.Append(BASUSA.HTML_Table.CloseTR());
            }
            sb.Append(BASUSA.HTML_Table.CloseTable());
            return sb.ToString();
        }

        private string buildTobbacoNonTobbaco(string coverage_name)
        {
            DataTable tbl = Data.GetRates(strAccount_Number, ViewState["Version_Number"].ToString(), ViewState["Class_Code"].ToString(), ViewState["Category_Code"].ToString(),
                ViewState["Category_Plan"].ToString(), strProcessing_year, ViewState["batch"].ToString());
            StringBuilder sb = new StringBuilder();
            sb.Append(BASUSA.HTML_Table.StartTable("TobbacoNonTobbaco", "TobbacoNonTobbaco", false, "htmtable"));
            sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Family Status"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Age Band"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "NonTobacco"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Tobacco"));
            sb.Append(BASUSA.HTML_Table.CloseTR());
            string oldstatus = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
                if (!oldstatus.Equals(dr["Family_Status"].ToString()))
                {
                    oldstatus = dr["Family_Status"].ToString();
                    sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Family_Status"].ToString()));
                    sb.Append(BASUSA.HTML_Table.CloseTR());
                    sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
                }
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", "&nbsp;"));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Age Band"].ToString()));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["NonTobacco"].ToString()));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Tobacco"].ToString()));
                sb.Append(BASUSA.HTML_Table.CloseTR());
            }
            sb.Append(BASUSA.HTML_Table.CloseTable());
            return sb.ToString();
        }

        private string buildAgeRate(string coverage_name)
        {
            DataTable tbl = Data.GetRates(strAccount_Number, ViewState["Version_Number"].ToString(), ViewState["Class_Code"].ToString(), ViewState["Category_Code"].ToString(),
                ViewState["Category_Plan"].ToString(), strProcessing_year, ViewState["batch"].ToString());
            StringBuilder sb = new StringBuilder();
            sb.Append(BASUSA.HTML_Table.StartTable("TobbacoNonTobbaco", "TobbacoNonTobbaco", false, "htmtable"));
            sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Family Status"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Age Band"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Rate"));
            sb.Append(BASUSA.HTML_Table.CloseTR());
            string oldstatus = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
                if (!oldstatus.Equals(dr["Family_Status"].ToString()))
                {
                    oldstatus = dr["Family_Status"].ToString();
                    sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Family_Status"].ToString()));
                    sb.Append(BASUSA.HTML_Table.CloseTR());
                    sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
                }
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", "&nbsp;"));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Age Band"].ToString()));
                sb.Append(BASUSA.HTML_Table.TD("", "", false, "", dr["Rate"].ToString()));
                sb.Append(BASUSA.HTML_Table.CloseTR());
            }
            sb.Append(BASUSA.HTML_Table.CloseTable());
            return sb.ToString();
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

        protected void btnSaveDoNothing_Click(object sender, EventArgs e)
        {

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

        protected void Reset()
        {
            Data.Reset(strBatch, strAccount_Number);
            strOldClass = "";
            strOldCode = "";
            strOldPlan = "";
            strOldPDesc = "";
            string strParam = "?accnt="+strAccount_Number+"&ip="+ ViewState["renewal"].ToString()+"&py="+strProcessing_year;
            Response.Redirect("/WEB_PROJECTS/AUTOMATED_RATE_UPDATE/Default_2.aspx" + strParam, true);
           
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

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            dvNote.Visible = true;
            txtMessage.Text = Data.Get_Comments(strAccount_Number, strBatch);
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

        private void OpenPlans()
        {
            RadWindow window1 = new RadWindow();            
            window1.NavigateUrl = "PendingCcvrgs.aspx";
            window1.VisibleOnPageLoad = true;
            window1.Modal = true;
            window1.Width = 700;
            window1.Height = 400;
            window1.VisibleStatusbar = false;
            window1.VisibleTitlebar = true;
            window1.Skin = "Default";            
            window1.OnClientClose = "OnClientclose";
            this.form1.Controls.Add(window1);  
        }

       
        
    }
}