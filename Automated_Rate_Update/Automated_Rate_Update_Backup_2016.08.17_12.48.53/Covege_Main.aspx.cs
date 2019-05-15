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
using Telerik.Web.UI;

namespace Automated_Rate_Update
{
    public partial class Covege_Main : System.Web.UI.Page
    {
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
            if (!IsPostBack)
            {
                btnAddPredefindMetalPlan.Visible = Request.Params["c"].Equals("INS-MED");
                lblMedInstruction.Visible = btnAddPredefindMetalPlan.Visible;
                if (!string.IsNullOrEmpty(session_id))
                {
                    ViewState["py"] = SQLStatic.Sessions.GetSessionValue(session_id, "processing_year");
                    ViewState["batch"] = SQLStatic.Sessions.GetSessionValue(session_id, "batchid");
                    ViewState["user_id"] = SQLStatic.Sessions.GetUserName(session_id);
                }
                else
                    ViewState["user_id"] = Data.user_name_from_id(Request.Params["id"]);
                string strCategory_Code = Request.Params["c"];
                if (Request.Params["c"].Equals("INS-MED")) strCategory_Code = "Medical";
                else if (Request.Params["c"].Equals("INS-DEN")) strCategory_Code = "Dental";
                else if (Request.Params["c"].Equals("INS-VIS")) strCategory_Code = "Vision";

                SetBatchID();

                



                lblPlanName.Text = lblPlanName.Text.Replace("[Plan]", strCategory_Code);
                lblInstruction.Text = lblInstruction.Text.Replace("[plan]", strCategory_Code);
                lblmedicalplan.Text = lblmedicalplan.Text.Replace("[Plan]", strCategory_Code);
                lbl_planname.Text = lbl_planname.Text.Replace("[Page_Name]", strCategory_Code);
                hidProcessing_Year.Value = Data.Get_processing_year(Request.Params["a"]);
                BuildClassList();
                
                ddlState.DataSource = SQLStatic.CD_Tables.States();
                ddlState.DataTextField = "state_description";
                ddlState.DataValueField = "state";
                ddlState.DataBind();

                if (!string.IsNullOrEmpty(Request.Params["cvid"]))
                {
                    txtPlanName.Text = Request.Params["cvname"].Substring(0, Request.Params["cvname"].Length - 16);
                    txtEfectiveDate.SelectedDate = Convert.ToDateTime(Request.Params["date"]);
                    string strMonth = txtEfectiveDate.SelectedDate.Value.ToString("MM");
                    string strDay = ((int)txtEfectiveDate.SelectedDate.Value.Day).ToString().PadLeft(2, '0');
                    ddlMoth.FindItemByValue(strMonth).Selected = true;
                    ddlMoth_SelectedIndexChanged(null, null);
                    ddlDay.FindItemByValue(strDay).Selected = true;
                    ddlMoth.Enabled = false;
                    ddlDay.Enabled = false;
                    txtPlanName.Enabled = false;
                    txtEfectiveDate.Enabled = false;
                    dvOE.Visible = true;
                }
            }
            //btnSave.Attributes.Add("onclock", "DoSave()");
            if (!string.IsNullOrEmpty(hidSave.Value))
            {
                hidSave.Value = string.Empty;
                btnSave_Click(null, null);
            }
        }

        private void SetBatchID()
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                GetParameters(Request.Params["id"]);
            }
            else
            {
                GetParametersBas();
            }
        }

        private void GetParametersBas()
        {
            ViewState["accnt"] = SQLStatic.Sessions.GetAccountNumber(Request.Cookies["Session_ID"].Value.ToString());
            ViewState["email"] = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
            ViewState["user_id"] = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
            ViewState["batch"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "batchid");
            ViewState["py"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "processing_year");
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
            ViewState["user_id"] = tbl.Rows[0]["user_name_"].ToString();
            ViewState["batch"] = tbl.Rows[0]["batch_id"].ToString();
            ViewState["py"] = tbl.Rows[0]["processing_year"].ToString();
            ViewState["renewal"] = tbl.Rows[0]["rate_renewal"].ToString();
        }

        private void BuildClassList()
        {
            DataTable tbl = null;
            if (string.IsNullOrEmpty(session_id))
                tbl = Data.Class_list(Request.Params["id"], Request.Params["c"]);
            else
                tbl = Data.Class_list2(Request.Params["a"],ViewState["py"].ToString(),Request.Params["c"]);
            if (tbl.Rows.Count.Equals(0))
            {
                RadComboBoxItem li = new RadComboBoxItem(Request.Params["s"] + " - " + SQLStatic.AccountData.ClassDescription(Request.Params["a"], hidProcessing_Year.Value, Request.Params["s"]), Request.Params["s"]);
                ddlClass.Items.Add(li);
                return;
            }
            if (tbl.Rows.Count > 1)
            {
                RadComboBoxItem liALL = new RadComboBoxItem("All Classes", "ALL");
                ddlClass.Items.Add(liALL);
            }
            foreach (DataRow dr in tbl.Rows)
            {
                RadComboBoxItem li = new RadComboBoxItem(dr["class_code"].ToString() + " - " + dr["description"].ToString(), dr["class_code"].ToString());
                li.Selected = li.Value == Request.Params["s"];
                ddlClass.Items.Add(li);
            }
            try
            {
                ddlClass.FindItemByValue("ALL").Selected = true;
            }
            catch
            {
            }
        }

        protected void ddlMoth_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int days = Data.DaysInMonth(ddlMoth.SelectedValue, "01", hidProcessing_Year.Value);
            ddlDay.Items.Clear();
            for (int i = 1; i <= days; i++)
            {
                RadComboBoxItem li = new RadComboBoxItem(i.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0'));
                ddlDay.Items.Add(li);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //string RequestParam = Request.QueryString.ToString();
            //RequestParam = RequestParam.Substring(RequestParam.IndexOf("&accnt"));
            //RequestParam = RequestParam.Replace("&accnt","?accnt");
            Response.Redirect("Default_2.aspx?id=" + Request.Params["id"], true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            if (ddlClass.SelectedValue.Equals("ALL"))
            {
                foreach (RadComboBoxItem li in ddlClass.Items)
                {
                    if (!li.Value.Equals("ALL"))
                    {
                        if (!string.IsNullOrEmpty(Request.Params["cvid"]))
                        {
                            string strInOPenEE = "0";
                            if (SQLStatic.Sessions.GetSessionValue(session_id, "OESelection").Equals("True")) //(cbOe.Checked)
                                strInOPenEE = "1";
                            SQLStatic.Sessions.SetSessionValue(session_id, "OESelection","");
                            Data.Save_Metal_cvrg(ViewState["py"].ToString(), ViewState["batch"].ToString(), Request.Params["a"], li.Value, Request.Params["c"],
                                txtPlanName.Text, txtInsuranceName.Text, txtPolicyNumber.Text, txtEfectiveDate.SelectedDate.Value.ToShortDateString(), ddlMoth.SelectedValue,
                               ddlDay.SelectedValue, rblHMO.SelectedValue, ddlState.SelectedValue, ViewState["user_id"].ToString(), rblSelf_Insured.SelectedValue,
                               ViewState["batch"].ToString(), Request.Params["cvid"], strInOPenEE);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(session_id))
                                Data.Save_cvrg(Request.Params["id"], Request.Params["a"], li.Value, Request.Params["c"], txtPlanName.Text, txtInsuranceName.Text, txtPolicyNumber.Text,
                                    txtEfectiveDate.SelectedDate.Value.ToShortDateString(), ddlMoth.SelectedValue,
                                    ddlDay.SelectedValue, rblHMO.SelectedValue, ddlState.SelectedValue, ViewState["user_id"].ToString(), rblSelf_Insured.SelectedValue);
                            else
                                Data.Save_cvrg_2(ViewState["py"].ToString(), ViewState["batch"].ToString(), Request.Params["a"], li.Value, Request.Params["c"],
                                    txtPlanName.Text, txtInsuranceName.Text, txtPolicyNumber.Text, txtEfectiveDate.SelectedDate.Value.ToShortDateString(), ddlMoth.SelectedValue,
                                   ddlDay.SelectedValue, rblHMO.SelectedValue, ddlState.SelectedValue, ViewState["user_id"].ToString(), rblSelf_Insured.SelectedValue);
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.Params["cvid"]))
                {
                    string strInOPenEE = "0";
                    if (SQLStatic.Sessions.GetSessionValue(session_id, "OESelection").Equals("True"))//(cbOe.Checked)
                        strInOPenEE = "1";
                    SQLStatic.Sessions.SetSessionValue(session_id, "OESelection", "");
                    Data.Save_Metal_cvrg(ViewState["py"].ToString(), ViewState["batch"].ToString(), Request.Params["a"], ddlClass.SelectedValue, Request.Params["c"],
                        txtPlanName.Text, txtInsuranceName.Text, txtPolicyNumber.Text, txtEfectiveDate.SelectedDate.Value.ToShortDateString(), ddlMoth.SelectedValue,
                       ddlDay.SelectedValue, rblHMO.SelectedValue, ddlState.SelectedValue, ViewState["user_id"].ToString(), rblSelf_Insured.SelectedValue,
                       ViewState["batch"].ToString(), Request.Params["cvid"], strInOPenEE);
                }
                else
                {
                    if (string.IsNullOrEmpty(session_id))
                        Data.Save_cvrg(Request.Params["id"], Request.Params["a"], ddlClass.SelectedValue, Request.Params["c"], txtPlanName.Text, txtInsuranceName.Text, txtPolicyNumber.Text,
                            txtEfectiveDate.SelectedDate.Value.ToShortDateString(), ddlMoth.SelectedValue,
                            ddlDay.SelectedValue, rblHMO.SelectedValue, ddlState.SelectedValue, ViewState["user_id"].ToString(), rblSelf_Insured.SelectedValue);
                    else
                        Data.Save_cvrg_2(ViewState["py"].ToString(), ViewState["batch"].ToString(), Request.Params["a"], ddlClass.SelectedValue, Request.Params["c"],
                            txtPlanName.Text, txtInsuranceName.Text, txtPolicyNumber.Text, txtEfectiveDate.SelectedDate.Value.ToShortDateString(), ddlMoth.SelectedValue,
                           ddlDay.SelectedValue, rblHMO.SelectedValue, ddlState.SelectedValue, ViewState["user_id"].ToString(), rblSelf_Insured.SelectedValue);
                }
            }
            btnBack_Click(null, null);
        }

        protected void btnAddPredefindMetalPlan_Click(object sender, EventArgs e)
        {
            string strParam ="?c="+Request.Params["c"]+"&s="+ddlClass.SelectedValue+"&a="+Request.Params["a"]+"&id="+Request.Params["id"];
            Response.Redirect("PreDefindMetalCoverage.aspx" + strParam, true);
        }

        
    }
}
