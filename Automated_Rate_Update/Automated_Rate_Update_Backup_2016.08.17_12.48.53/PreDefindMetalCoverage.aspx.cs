using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Automated_Rate_Update
{
    public partial class PreDefindMetalCoverage : System.Web.UI.Page
    {
        string session_id = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["catplan"]))
                {
                    if (Data.Category_Plan_Exist(Request.Params["batch"], Request.Params["catplan"]).Equals("0"))
                    {
                        dvSelectReport.Visible = false;
                        Div5.Visible = false;
                        dvProgramType.Visible = false;
                        Div1.Visible = false;
                        dvRatelbl.Visible = false;
                        dvRatesList.Visible = false;
                        Div4.Visible = false;
                        return;
                    }
                    else
                    {
                        dvError.Visible = false;
                        dvErrorbtn.Visible = false;
                    }
                }
                else
                {
                    dvError.Visible = false;
                    dvErrorbtn.Visible = false;
                }
                string strInOE = Data.Cvrg_in_OE(Request.Params["accnt"], Request.Params["py"], "INS-MED", Request.Params["catplan"], Request.Params["class"], Request.Params["batch"]);
                cbOe.Checked = strInOE.Equals("1");
                if (!string.IsNullOrEmpty(Request.Params["catplan"])) // Account Seyp
                {
                    txtEffectiveDates.SelectedDate = Convert.ToDateTime(Request.Params["batch"]);
                    setupForEdit();
                    FillMetalTiers();
                    FillMetalCoverage();
                    SetupEdit();
                    ddlMetalTier.Enabled = false;
                    ddlPlansList.Enabled = false;
                    btnChangedate.Enabled = false;
                    btnSave.Visible = false;
                    if (!string.IsNullOrEmpty(Request.Params["back"]) && Request.Params["back"].Equals("2"))
                        btnCancel.Visible = false;
                    btnUpdate.Visible = true;
                    return;
                }
                //else if (!string.IsNullOrEmpty(Request.Params["c"])) // Account Setup Wizard
                else if (Account_Wiz())
                {
                    ViewState["PY"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PROCESSING_YEAR");
                    //setupForEdit();
                    //FillMetalTiers();
                    //FillMetalCoverage();
                    //SetupEdit();
                    //ddlMetalTier.Enabled = false;
                    //ddlPlansList.Enabled = false;
                    //btnChangedate.Enabled = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            //btnUpdate.Attributes.Add("onclick", "DoSave()");
            lblScript.Text = string.Empty;
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
                SetBatchID();
                FillMetalTiers();
            }
            if (!string.IsNullOrEmpty(hidSave.Value))
            {
                btnUpdate_Click(null, null);
            }
        }

        private bool Account_Wiz()
        {
            if (!string.IsNullOrEmpty(Request.Params["c"]) && (!string.IsNullOrEmpty(Request.Params["back"])))
                return true;
            else
                return false;
        }

        private void setupForEdit()
        {
            DataTable tbl =null;
            if (!string.IsNullOrEmpty(Request.Params["catplan"]))
                tbl = Data.GetMetalCoverageRow(Request.Params["catplan"], txtEffectiveDates.SelectedDate.Value.Year.ToString());
            else
                return;
            ViewState["metal_tier"] = tbl.Rows[0]["metal_tier"].ToString();
            ViewState["record_id"] = tbl.Rows[0]["record_id"].ToString();
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
            //ViewState["py"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "processing_year");
            //ViewState["renewal"] = ViewState["batch"].ToString().Substring(0, 5);
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

        private void FillMetalTiers()
        {
            ddlMetalTier.DataSource = Data.MetalTires();
            ddlMetalTier.DataTextField = "metal_tier";
            ddlMetalTier.DataValueField = "metal_tier";
            ddlMetalTier.DataBind();
            if (!string.IsNullOrEmpty(Request.Params["catplan"]))
                ddlMetalTier.Items.FindItemByValue(ViewState["metal_tier"].ToString()).Selected = true;
        }

        private void FillMetalCoverage()
        {
            DataTable tbl = Data.MetalCoveragesList(ddlMetalTier.SelectedValue, txtEffectiveDates.SelectedDate.Value.ToShortDateString());
            if (tbl.Rows.Count.Equals(0))
            {
                jscriptsFunctions.Misc.Alert(Page, "There are no predefined plans for the effective date you entered");
                return;
            }
            ddlPlansList.DataSource = tbl;
            ddlPlansList.DataTextField = "Extend_description";
            ddlPlansList.DataValueField = "record_id";
            ddlPlansList.DataBind();
            if (!string.IsNullOrEmpty(Request.Params["catplan"]))
                ddlPlansList.Items.FindItemByValue(ViewState["record_id"].ToString()).Selected = true;
            DrawGrid();
        }

        

        protected void ddlMetalTier_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            FillMetalCoverage();
            //dvRatesList.Visible = false;
            //dvRatelbl.Visible = false;
        }

        protected void ddlPlansList_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DrawGrid();
            //dvRatesList.Visible = false;
            //dvRatelbl.Visible = false;            
        }

        private void DrawGrid()
        {
            lblRates.Text = "Tobacco/non-Tobacco Rates - " + ddlPlansList.SelectedItem.Text;
            RadGrid1.DataSource = Data.MetalRatesList(ddlPlansList.SelectedValue, txtEffectiveDates.SelectedDate.Value.ToShortDateString());
            RadGrid1.DataBind();
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!dvRatesList.Visible)
                return;
            if (ddlPlansList.Items.Count.Equals(0))
                return;
            lblRates.Text = "Tobacco/non-Tobacco Rates - " + ddlPlansList.SelectedItem.Text;
            RadGrid1.DataSource = Data.MetalRatesList(ddlPlansList.SelectedValue, txtEffectiveDates.SelectedDate.Value.ToShortDateString());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // check if it is called from Manage Account Setup
            if (!string.IsNullOrEmpty(Request.Params["back"]) && Request.Params["back"].Equals("2"))
            {
                lblScript.Text = "<script type='text/javascript'>Cancel('" + "/web_projects/Coverages/ERCoverages/EditMainCiveragePage.aspx?IndexID=" + Request.Params["cvrgid"] +
                    "&userID=" + Request.Params["userID"] + "')</script>";
                //Response.Redirect("/web_projects/Coverages/ERCoverages/EditMainCiveragePage.aspx?IndexID=" + Request.Params["cvrgid"] +
                //    "&userID=" + Request.Params["userID"], true);
                return;
            }

            if  (!string.IsNullOrEmpty(Request.Params["back"]))
            {
                //lblScript.Text = "<script type='text/javascript'>javascript:Cancel('/WEB_PROJECTS/ACCOUNTSETUPWIZARD/Covege_Main.aspx?id=0&cvrg=INS-MED&Name=Medical')</script>";
                string strURL = "'/WEB_PROJECTS/ACCOUNTSETUPWIZARD/Covege_Main.aspx?id=0&cvrg=INS-MED&Name=Medical'";
                   
                lblScript.Text = "<script type='text/javascript'>window.open("+strURL+", '_top');</script>";
                return;
            }

            if (!string.IsNullOrEmpty(Request.Params["catplan"]))
            {
                Response.Redirect("Default_2.aspx?id=" + Request.Params["id"], true);
                return;
            }
            string strParam ="?c="+Request.Params["c"]+"&s="+Request.Params["s"]+"&a="+Request.Params["a"]+"&id="+Request.Params["id"]+"&cvrg="+Request.Params["c"];
            if (string.IsNullOrEmpty(Request.Params["back"]))
                Response.Redirect("Covege_Main.aspx" + strParam, true);
            else
            {
                strParam = Request.Params["back"] + strParam + SQLStatic.Sessions.GetSessionValue(session_id, "cancelParam");
                strParam = "'" +strParam+  "'";
                lblScript.Text = "<script type='text/javascript'>GoBack(" + strParam + ")</script>";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(session_id, "OESelection", cbOe.Checked.ToString());
            string strParam = "?c=" + Request.Params["c"] + "&s=" + Request.Params["s"] + "&a=" + Request.Params["a"] + "&id=" +
                Request.Params["id"] + "&cvrg=" + Request.Params["c"] + "&date=" +txtEffectiveDates.SelectedDate.Value.ToShortDateString() +
                "&cvid=" + ddlPlansList.SelectedValue+"&cvname=" + HttpUtility.HtmlEncode(ddlPlansList.SelectedItem.Text);
            if (string.IsNullOrEmpty(Request.Params["back"]))
                Response.Redirect("Covege_Main.aspx" + strParam, true);
            else
            {
                strParam = "'"+Request.Params["back"] + strParam+"'";
                lblScript.Text = "<script type='text/javascript'>GoBack("+strParam+")</script>";
            }
            //Response.Redirect(Request.Params["back"] + strParam, true);    window.open(" + strParam + ",'_top')
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (txtEffectiveDates.SelectedDate == null)
            {
                jscriptsFunctions.Misc.Alert(Page, "Missing Effective Date");
                return;
            }
            FillMetalCoverage();
            if (ddlPlansList.Items.Count.Equals(0))
                return;
            dvRatesList.Visible = true;
            dvRatelbl.Visible = true;
            ddlMetalTier.Enabled = true;
            ddlPlansList.Enabled = true;
            btnSave.Visible = true;
            DrawGrid();
            btnGo.Visible = false;
            txtEffectiveDates.Enabled = false;
            btnChangedate.Visible = true;
            if (!string.IsNullOrEmpty(Request.Params["catplan"]))
                btnSave.Visible = false;
            if (Account_Wiz())
                btnSave.Visible = false;
        }

        protected void SetupEdit()
        {                        
            dvRatesList.Visible = true;
            dvRatelbl.Visible = true;
            ddlMetalTier.Enabled = true;
            ddlPlansList.Enabled = true;
            btnSave.Visible = true;
            DrawGrid();
            btnGo.Visible = false;
            txtEffectiveDates.Enabled = false;
            btnChangedate.Visible = true;
            if (!string.IsNullOrEmpty(Request.Params["catplan"]))
                btnSave.Visible = false;
            if (Account_Wiz())
                btnSave.Visible = false;
        }

        protected void txtEffectiveDates_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            dvRatesList.Visible = false;
            dvRatelbl.Visible = false;            
        }

        protected void btnChangedate_Click(object sender, EventArgs e)
        {
            dvRatesList.Visible = false;
            dvRatelbl.Visible = false;
            ddlMetalTier.Enabled = false;
            ddlPlansList.Enabled = false;
            txtEffectiveDates.Enabled = true;
            btnGo.Visible = true;
            btnChangedate.Visible = false;
            btnSave.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string user_name;
            if (string.IsNullOrEmpty(Request.Params["id"]))
            {
                user_name = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
            }
            else
            {
                DataTable tbl = Data.get_parameters(Request.Params["id"]);
                user_name = tbl.Rows[0]["user_name_"].ToString();
                tbl.Dispose();
            }

            if (!string.IsNullOrEmpty(Request.Params["cvrgid"]))
            {
                Data.UpdateOneRateMetalCoverage(Request.Params["accnt"], Request.Params["catplan"], Request.Params["batch"], Request.Params["ver"], user_name);
                
            }
            else if (Account_Wiz())
            {
                string strParam = "?c=" + Request.Params["c"] + "&s=" + Request.Params["s"] + "&a=" + Request.Params["a"] + "&id=" +
                Request.Params["id"] + "&cvrg=" + Request.Params["c"] + "&date=" + txtEffectiveDates.SelectedDate.Value.ToShortDateString() +
                "&cvid=" + ddlPlansList.SelectedValue + "&cvname=" + HttpUtility.HtmlEncode(ddlPlansList.SelectedItem.Text);

                string strURL = "'/WEB_PROJECTS/ACCOUNTSETUPWIZARD/Covege_Main.aspx" + strParam + "'";

                lblScript.Text = "<script type='text/javascript'>window.open(" + strURL + ", '_top');</script>";
                return;
                //Data.UpdateOneRateMetalCoverage(strAccount_number, Request.Params["catplan"], Request.Params["batch"], Request.Params["ver"], user_name);
            }
            else
            {
                string in_oe = "0";
                if (cbOe.Checked)
                    in_oe = "1";
                Data.UpdateOneMetalCoverage(Request.Params["accnt"], Request.Params["py"], Request.Params["catplan"],Request.Params["class"], Request.Params["batch"], in_oe, user_name);
                btnCancel_Click(null, null);
            }
            jscriptsFunctions.Misc.AlertSaved(Page);
        }
    }
}