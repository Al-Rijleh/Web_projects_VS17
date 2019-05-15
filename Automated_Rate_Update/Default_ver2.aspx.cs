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
    public partial class Default_ver2 : System.Web.UI.Page
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
        DataTable tblCb = null;
        string session_id = "";


        string strClass = @"<table class='masterwidth marginbottom5 paddingbottomm5 bottomline ' style='margin-left: auto;
        margin-right: auto'>
        <tr id='trClass[code1]' runat='server' class='masterwidth marginbottom5 paddingbottomm5 bottomline '
            style='margin-left: auto; margin-right: auto'>
            <td>
                <span class='dataSetctionTitle'>[class]</span>
            </td>
        </tr>";

        string strPlanType = @"<tr id='trPlanType[code2]' runat='server' class='cvrgrow marginbottom5 paddingbottomm5 bottomline' style='margin-left: auto;
        margin-right: auto'>
            <td>
                <div class='cvrgrow marginbottom5 paddingbottomm5 bottomline'>
                    <span class='dataSetctionTitle'>[Type]</span><br />
                    <span>If you want add a new [Type], click this
                        button:</span>
                    <input id='btnAdd' type='button'  value='Add Another [Type]' onclick='return btnAdd_onclick([param])' />
                </div>
            </td>
        </tr>";
        string strcoverage=@"<tr>
            <td>
                <div class='raterow marginbottom5 paddingbottomm5 bottomline'>
                    <span  class='dataSubSetctionTitle'>[planname]</span><br />
                    <img alt='' src='[loc]' />
                    <span> Will send COBRA continuants open enrollment information
                        about this plan</span>
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
        </tr>";

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
                <asp:Label ID='lblRemReact_111' runat='server'>REMOVE this plan with NO CORRESPONDING REPLACEMENT PLAN (Do Not Use this option if you are replacing this plan with a new plan; use the 2nd radio button above instead).</asp:Label>
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
                                            <asp:Label ID='Label1' runat='server'>REMOVE this plan with NO CORRESPONDING REPLACEMENT PLAN (Do Not Use this option if you are replacing this plan with a new plan; use the 2nd radio button above instead).</asp:Label>
                                        </td>
                                    </tr>
                                </table>";



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
            BuildRates();

            if (!IsPostBack)
            {
                FillddlEffectiveDate(strAccount_Number);
            }
        }

        private void GetParametersBas()
        {
            ViewState["accnt"] = SQLStatic.Sessions.GetAccountNumber(session_id);
            ViewState["email"] = SQLStatic.Sessions.GetUserName(session_id);
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
        }

        private void FillddlEffectiveDate(string strAccount_Number)
        {
            DataTable tbl = Data.Default_EffectiveDate_2(ViewState["accnt"].ToString(), ViewState["renewal"].ToString(), ViewState["py"].ToString());
        }

        private void BuildRates()
        {
            DataTable tbl = Data.GetTable(strAccount_Number, strProcessing_year, strRateRenewal);           
            int Rowid = 0;            
            int inpnl = 0;
            strOldClass = string.Empty;
            strOldPlan = string.Empty;
            foreach (DataRow dr in tbl.Rows)
            {
                lblForm.Text += SetupTable(dr,tbl);
            }
            lblForm.Text += "</table>";
        }

        private string SetupTable(DataRow dr, DataTable tbl)
        {
            string strTable = "";
            if (!strOldClass.Equals(dr["class_code"].ToString()))
            {
                strOldClass = dr["class_code"].ToString();
                strTable = strClass.Replace("[class]",dr["class_code"].ToString()+" - "+dr["Description"].ToString());
            }
            if (!strOldPlan.Equals(dr["plan_name"].ToString()))
            {
                strOldPlan = dr["plan_name"].ToString();
                string paramter = "\"?c=c_&s=s_&a=a_&id=" + hidParam.Value+"\"";
                paramter = paramter.Replace("c_", dr["category_code"].ToString()).Replace("s_", dr["class_code"].ToString()).Replace("a_", strAccount_Number);                
                strTable += strPlanType.Replace("[Type]",dr["plan_name"].ToString()).Replace("[param]",paramter);
            }
            foreach (DataRow drcvrg in tbl.Rows)
            {
                if (strOldPlan.Equals(dr["plan_name"].ToString()))
                {
                    if (!strOldPlanName.Equals(dr["category_plan"].ToString()))
                    {
                        string ratetype = Data.GetRateType(strAccount_Number, dr["Version_Number"].ToString(), dr["class_code"].ToString(),
                                 dr["category_code"].ToString(), dr["category_plan"].ToString(), strProcessing_year);

                        string strParamurl = "?accnt=" + strAccount_Number +
                                          "&ver=" + dr["Version_Number"].ToString() +
                                          "&class=" + dr["class_code"].ToString() +
                                          "&catcode=" + dr["category_code"].ToString() +
                                          "&catplan=" + dr["category_plan"].ToString() +
                                          "&py=" + strProcessing_year +
                                          "&batch=" + strBatch +
                                          "&cvrg=" + dr["long_description"].ToString() +
                                          "&ratetype=" + ratetype +
                                          "&action=[actionntype]" +
                                          "&id=" + hidParam.Value;
                        strParamurl = "\"" + strParamurl + "\"";

                        strOldPlanName = dr["category_plan"].ToString();
                        string strParam = "\"" + dr["category_code"].ToString() + dr["category_plan"].ToString() + "_" + dr["class_code"].ToString() + "\"";
                        string imgUrl = string.Empty;
                        if (dr["in_oe"].ToString().Equals("1"))
                            imgUrl = "/web_projects/Automated_Rate_Update//Img/Yeas";
                        else
                            imgUrl = "/web_projects/Automated_Rate_Update//Img/No";
                        string htmTable = buildStatusTable(dr["long_description"].ToString(), tbl);
                        strTable += strcoverage.Replace("[planname]", dr["long_description"].ToString()).Replace("[Action]", GetAction(dr)).Replace("[Grid]", htmTable).
                            Replace("[effdate]", strBatch).Replace("[param2]", strParam + "," + strParamurl + ",\"" + ratetype + "\"").Replace("[loc]", imgUrl);

                    }
                }
            }
            return strTable;
        }

        private string GetCoverage(DataRow dr, DataTable tbl)
        {
            tblCb = tbl.Copy();
            strOldPDesc = string.Empty;
            string coverage = string.Empty;
            foreach (DataRow dr_c in tblCb.Rows)
            {
                
                if (dr_c["plan_name"].ToString().Equals(dr["plan_name"].ToString()))
                {

                }
            }


            

            return coverage;
        }

        private string GetAction(DataRow dr)
        {
            string strAction = strMedChoices;
            if (!dr["category_code"].ToString().Equals("INS-MED"))
                strAction = strOtherChoice;
            string strParam = dr["category_code"].ToString() + dr["category_plan"].ToString() + "_" + dr["class_code"].ToString();
            strAction = strAction.Replace("Action_code", strParam);

            return strAction;
        }

        private string buildStatusTable(string coverage_name, DataTable tbl)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BASUSA.HTML_Table.StartTable("Statusciverage", "Statusciverage", false, "htmtable"));
            sb.Append(BASUSA.HTML_Table.StartTR("", "", false, ""));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Family Status"));
            sb.Append(BASUSA.HTML_Table.TD("", "", false, "htmtableheader", "Rate Amount"));
            sb.Append(BASUSA.HTML_Table.CloseTR());
            foreach(DataRow dr in tbl.Rows)
            {
                if (coverage_name.Equals(dr["long_description"].ToString()))
                {
                    sb.Append(BASUSA.HTML_Table.StartTR("","",false,""));
                    sb.Append(BASUSA.HTML_Table.TD("","",false,"",dr["fs_description"].ToString()));
                    sb.Append(BASUSA.HTML_Table.TD("","",false,"",dr["Rate_amount"].ToString()));
                    sb.Append(BASUSA.HTML_Table.CloseTR());
                }
            }
            sb.Append(BASUSA.HTML_Table.CloseTable());
            return sb.ToString();
        }

        //private void BuildCoveragee(DataRow dr)
        //{
        //    string str = strPlan;
        //    str = str.Replace("[lblPlanName]", dr["long_description"].ToString()).Replace("[effdate]", dr["strEffectiveDate"].ToString());            
        //    lblForm.Text += str;
        //}

        //private void BuildPlanType(DataRow dr)
        //{            
        //    string strparam = "\"Covege_Main.aspx?c=" + dr["category_code"].ToString() +
        //        "&s=" + currentClass + "&a=" + strAccount_Number + "&id=\"";
        //    string str = strplantype.Replace("[plan]", dr["plan_name"].ToString()).Replace("[param]", strparam);
        //    lblForm.Text += str;
        //    CurrentCatCode = dr["category_code"].ToString();
        //}

        //private void AddClass(DataRow dr)
        //{
        //    lblForm.Text += strclass.Replace("[class]", dr["class_code"].ToString() + " - " + dr["Description"].ToString());
        //    currentClass = dr["class_code"].ToString(); 
        //}
    }
}