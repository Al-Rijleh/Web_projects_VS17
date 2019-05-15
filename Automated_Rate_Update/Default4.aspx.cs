using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;


namespace Automated_Rate_Update
{
    public partial class Default4 : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                else
                {
                    session_id = string.Empty;
                    htmbtnReset.Visible = false;
                    Panel4.Visible = false;
                    htmBtnManagePlans.Visible = false;
                }
                if (ViewState["accnt"] == null)
                {
                    if (!string.IsNullOrEmpty(session_id))
                        GetParametersBas();
                    else
                        GetParameters(Request.Params["id"]);
                }                              
                DataTable tbl = Data.GetClasses(ViewState["accnt"].ToString(), ViewState["py"].ToString(),ViewState["renewal"].ToString(), ViewState["user_id"].ToString());
                SetCoverageTypes(); 
                ShowProcessed();
                ViewState["verion"]= tbl.Rows[0]["version_number"].ToString();
                tbl.Dispose();
                ddlCoverageTypes_SelectedIndexChanged(null, null);
                dvManage.Visible = false;
                hidPendCvrg.Value = "?acnt=" + ViewState["accnt"].ToString() + "&py=" + ViewState["py"].ToString() + "&batch=" + ViewState["batch"].ToString();
            }
            lblScript.Text = string.Empty;
            if (!string.IsNullOrEmpty(hidCvrgID.Value))
            {
                ViewState["cvrhID"] = hidCvrgID.Value;
                hidCvrgID.Value = string.Empty;
                ProcessAction(false);
            }
            if (!string.IsNullOrEmpty(hidRemove.Value))
            {
                hidRemove.Value = string.Empty;
                DoRemove();
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
            Panel3.Visible = !dvManage.Visible;
        }

        private void SetCoverageTypes()
        {

            if (Data.hasCoverage(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), "INS-MED").Equals("1"))
                ddlCoverageTypes.Items.Add(new RadComboBoxItem("Medical Plans", "INS-MED"));
            if (Data.hasCoverage(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), "INS-DEN").Equals("1"))
                ddlCoverageTypes.Items.Add(new RadComboBoxItem("Dental Plans", "INS-DEN"));
            if (Data.hasCoverage(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), "INS-VIS").Equals("1"))
                ddlCoverageTypes.Items.Add(new RadComboBoxItem("Vision Plans", "INS-VIS"));

            if (Data.hasCoverage(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), "HRA").Equals("1"))
                ddlCoverageTypes.Items.Add(new RadComboBoxItem("Health Reimbursement Account Plan", "HRA"));

            if (Data.hasCoverage(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), "INS-PSC").Equals("1"))
                ddlCoverageTypes.Items.Add(new RadComboBoxItem("Prescription Plan", "INS-PSC"));

            if (Data.hasCoverage(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), "INS-GAP").Equals("1"))
                ddlCoverageTypes.Items.Add(new RadComboBoxItem("GAP Plan", "INS-GAP"));
            ddlCoverageTypes.SelectedIndex = 0;
        }

        private void ProcessAction(bool Skip)
        {
            DataTable tblcvrg = Data.GetCoverageDetail(ViewState["cvrhID"].ToString());
            ViewState["Rate_Method"] = tblcvrg.Rows[0]["rate_method"].ToString();
            ViewState["class_code"] = tblcvrg.Rows[0]["class_code"].ToString();
            ViewState["category_code"] = tblcvrg.Rows[0]["category_code"].ToString();
            ViewState["category_plan"] = tblcvrg.Rows[0]["category_plan"].ToString();
            ViewState["cvrg_name"] = tblcvrg.Rows[0]["long_description"].ToString();
            lblManageCoverage.Text = ViewState["class_code"].ToString() + " - " + ViewState["cvrg_name"].ToString() + " (" + ViewState["category_code"].ToString() + " " + ViewState["category_plan"].ToString() + ")";
            tblcvrg.Dispose();

            DataTable tbl = Data.Default_EffectiveDate_2(ViewState["accnt"].ToString(), ViewState["renewal"].ToString(), ViewState["py"].ToString());
            ViewState["effectivedate"] = tbl.Rows[0]["Formated_Date"].ToString();
            lblEffectiveDate.Text = "Changes Effective "+tbl.Rows[0]["Formated_Date"].ToString();
            tbl.Dispose();
            if (!Skip)
            {
                SelectRow();
                string Param = "?accnt=" + ViewState["accnt"].ToString() +
                        "&ver=" + ViewState["verion"] +
                        "&class=" + ViewState["class_code"].ToString() +
                        "&catcode=" + ViewState["category_code"].ToString() +
                        "&catplan=" + ViewState["category_plan"].ToString() +
                        "&py=" + ViewState["py"].ToString() +
                        "&batch=" + ViewState["batch"].ToString() +
                        "&cvrg=" + ViewState["cvrg_name"].ToString() +
                        "&ratetype=" + ViewState["Rate_Method"].ToString() +
                        "&efDare="+lblEffectiveDate.Text +
                        "&action=0" +
                        "&id=" + Request.Params["id"];
               // dvManage.Visible = true;
                Panel3.Visible = false;
                dvcvrlist.Visible = false;
                dvManage.Visible = true;
                //ShowManage(Param);
            }

        }

        private void ShowProcessed()
        {
            DataTable tbl = Data.processedby(ViewState["accnt"].ToString(), ViewState["batch"].ToString());
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

        protected void SelectRow()
        {
            foreach (GridDataItem item in rgCvrg.MasterTableView.Items)
            {
                if (item.GetDataKeyValue("record_id").ToString().Equals(ViewState["cvrhID"].ToString()))
                {
                    item.Selected = true;
                    //item.BackColor = System.Drawing.Color.Gold;
                    string str = item.Cells[2].Text;
                    break;
                }
                
                
            }

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
            ViewState["accnt"] = tbl.Rows[0]["account_number"].ToString();
            ViewState["email"] = tbl.Rows[0]["email"].ToString();
            ViewState["user_id"] = tbl.Rows[0]["user_name_"].ToString();
            ViewState["batch"] = tbl.Rows[0]["batch_id"].ToString();
            ViewState["py"] = tbl.Rows[0]["processing_year"].ToString();
            ViewState["renewal"] = tbl.Rows[0]["rate_renewal"].ToString();
        }

        protected void rgDep_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataTable tbl = Data.GeteAllCoverage(ViewState["accnt"].ToString(), ViewState["py"].ToString(), ViewState["Select_Cat"].ToString(), ViewState["renewal"].ToString(), ViewState["batch"].ToString());
                if (tbl.Rows.Count.Equals(0))
                    HidAddButton();
                rgCvrg.DataSource = tbl;
            }
            catch { }
        }

        private void HidAddButton()
        {
            btnAddMedical.Visible = false;
            btnAddDental.Visible = false;
            btnAddVistion.Visible = false;
        }

        protected void rgDep_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            //    DropDownList ddl = (DropDownList)item["Action"].FindControl("ddlAction");

            //    ListItem li = new ListItem("Select..", "0");
            //    ddl.Items.Add(li);

            //    ListItem li1 = new ListItem("Edit", "1");
            //    ddl.Items.Add(li1);

            //    ListItem li2 = new ListItem("Remove", "2");
            //    ddl.Items.Add(li2);
            //}
        }

        protected void DrawGrid()
        {
            try
            {
                DataTable tbl = Data.GeteAllCoverage(ViewState["accnt"].ToString(), ViewState["py"].ToString(), ViewState["Select_Cat"].ToString(), ViewState["renewal"].ToString(), ViewState["batch"].ToString());
                if (tbl.Rows.Count.Equals(0))
                    HidAddButton();
                rgCvrg.DataSource = tbl;
                rgCvrg.DataBind();
            }
            catch
            {
                HidAddButton();
            }
        }

        protected void ddlCoverageTypes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            btnAddMedical.Visible = false;
            btnAddDental.Visible = false;
            btnAddVistion.Visible = false;
            if (ddlCoverageTypes.SelectedValue.Equals("INS-MED"))
            {
                ViewState["Select_Cat"] = "INS-MED";
                btnAddMedical.Visible = true;
            }
            else if (ddlCoverageTypes.SelectedValue.Equals("INS-DEN"))
            {
                ViewState["Select_Cat"] = "INS-DEN";
                btnAddDental.Visible = true;
            }
            else if (ddlCoverageTypes.SelectedValue.Equals("INS-VIS"))
            {
                ViewState["Select_Cat"] = "INS-VIS";
                btnAddVistion.Text = "Add a New " + ddlCoverageTypes.SelectedItem.Text;
                btnAddVistion.Visible = true;
            }
            else
            {
                ViewState["Select_Cat"] = ddlCoverageTypes.SelectedValue;
                btnAddVistion.Text = "Add a New "+ddlCoverageTypes.SelectedItem.Text;
                btnAddVistion.Visible = true;
            }

            DrawGrid();
        }

        protected void btnMakechange_Click(object sender, EventArgs e)
        {
            string Param = "?accnt=" + ViewState["accnt"].ToString() +
                        "&ver=" + ViewState["verion"] +
                        "&class=" + ViewState["class_code"].ToString() +
                        "&catcode=" + ViewState["category_code"].ToString() +
                        "&catplan=" + ViewState["category_plan"].ToString() +
                        "&py=" + ViewState["py"].ToString() +
                        "&batch=" + ViewState["batch"].ToString() +                        
                        "&ratetype=" + ViewState["Rate_Method"].ToString() +
                        "&action=0" +
                        "&id=" + Request.Params["id"]+
                        "&cvrg=" + ViewState["cvrg_name"].ToString() ;
            
            if (rblAction.SelectedValue.Equals("same"))
            {
                if (ViewState["Rate_Method"].ToString().Equals("0"))
                {
                    Response.Redirect(HttpUtility.UrlDecode("DoubleAgeRate.aspx" + Param));
                }
                if (ViewState["Rate_Method"].ToString().Equals("1"))
                {
                    Response.Redirect(HttpUtility.UrlDecode("StatusRate.aspx" + Param));
                }
            }
            else if (rblAction.SelectedValue.Equals("remove"))
            {
                string strRemove = "'"+ViewState["cvrg_name"].ToString()+"'";
                strRemove = "<script type='text/javascript'>remove(" + strRemove + ")  </script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRemove", strRemove);

               // lblScript.Text = "<script type='text/javascript'>remove(" + strRemove + ")  </script>";                
            }
            else if (rblAction.SelectedValue.Equals("change"))
            {
                Param = Param.Replace("&action=0", "&action=1");
                Response.Redirect(HttpUtility.UrlDecode("NewRateType.aspx" + Param));
                //Response.Redirect("NewRateType.aspx" + Param);
            }
        }

        protected void DoRemove()
        {
            Data.remove_ver1(ViewState["accnt"].ToString(), ViewState["class_code"].ToString(), ViewState["cvrg_name"].ToString(), ViewState["category_code"].ToString(),
                ViewState["category_plan"].ToString(), ViewState["py"].ToString(), ViewState["batch"].ToString());
            DrawGrid();
            jscriptsFunctions.Misc.AlertSaved(Page);
            btnCancel_Click(null, null);
        }

        protected void btnAddMedical_Click(object sender, EventArgs e)
        {           
            string param = "?c="+ViewState["Select_Cat"].ToString() +
                           "&s="+//ViewState["class_code"].ToString() +
                           "&a="+ ViewState["accnt"].ToString() +
                           "&id=" + Request.Params["id"];
            Response.Redirect("Covege_Main.aspx" + param);
        }

        protected void rgCvrg_ItemCreated(object sender, GridItemEventArgs e)
        {
            
        }

        protected void rgCvrg_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName && e.Item is GridDataItem)
            {
                dvManage.Visible = false;
                if (e.Item.Expanded)
                {
                    if (e.Item is GridDataItem)
                    {
                        GridDataItem item = e.Item as GridDataItem;

                        item.Expanded = false;
                        DrawGrid();
                        return;
                    }
                }

                int iopen = -1;
                bool boolstop = false;
                foreach (GridDataItem dataItem in rgCvrg.MasterTableView.Items)
                {
                    if (!boolstop)
                        iopen++;
                    if (dataItem.Expanded)
                    {
                        boolstop = true;
                        dataItem.Expanded = false;
                    }
                }

               
                
                //if (iopen.Equals(e.Item.ItemIndex))
                //    return;

                if (e.Item is GridDataItem)
                {
                    GridDataItem item = e.Item as GridDataItem;

                    string strID = item.GetDataKeyValue("record_id").ToString();
                    ViewState["cvrhID"] = strID;
                }
                
                string hid2 = e.Item.ItemIndex.ToString();

                rgCvrg.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true; //.GetDataKeyValue(.DataKeyValues[0].ToString();

                int SelValue = Convert.ToInt32(rgCvrg.SelectedValue.ToString());

                int index1 = Convert.ToInt32(hid2.ToString());

                ProcessAction(true);

                DataTable tblStatus = Data.RateStatus(ViewState["accnt"].ToString(), ViewState["verion"].ToString(), ViewState["class_code"].ToString(), ViewState["category_code"].ToString(),
                ViewState["category_plan"].ToString(), ViewState["py"].ToString(), ViewState["batch"].ToString());

                 string strStatus = tblStatus.Rows[0]["status"].ToString();

                 if (strStatus.Equals("R"))
                     ((RadGrid)rgCvrg.MasterTableView.Items[index1].ChildItem.FindControl("rgRate")).Skin = "Sunset";
                 else if (strStatus.Equals("A"))
                     ((RadGrid)rgCvrg.MasterTableView.Items[index1].ChildItem.FindControl("rgRate")).Skin = "Windows7";


                DataTable tbl = Data.GetRates(ViewState["accnt"].ToString(), ViewState["verion"].ToString(), ViewState["class_code"].ToString(), ViewState["category_code"].ToString(),
                ViewState["category_plan"].ToString(), ViewState["py"].ToString(), ViewState["batch"].ToString());

                ((RadGrid)rgCvrg.MasterTableView.Items[index1].ChildItem.FindControl("rgRate")).DataSource = tbl;
                ((RadGrid)rgCvrg.MasterTableView.Items[index1].ChildItem.FindControl("rgRate")).DataBind();



            }
        }

        protected void Reset()
        {
            Data.Reset(ViewState["batch"].ToString(), ViewState["accnt"].ToString());
            DrawGrid();

        }

        protected void btnSaveDoNothing_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Data.finalize(ViewState["accnt"].ToString(), ViewState["batch"].ToString(), ViewState["user_id"].ToString(), ViewState["py"].ToString(), ViewState["batch"].ToString());
            

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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            dvManage.Visible = false;
            Panel3.Visible = true;            
            dvcvrlist.Visible = true;
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            string strParam = string.Empty;
            if (string.IsNullOrEmpty(Request.Params["id"]))
                strParam = strParam = "?accnt=" + ViewState["accnt"].ToString() + "&ip=" + ViewState["batch"].ToString().Substring(0, 5) + "&py=" + ViewState["py"].ToString();
            else
                strParam = "?id=" + Request.Params["id"];

            Response.Redirect("help.aspx" + strParam, true);
        }

        protected void ShowManage(string param)
        {
            RadWindow window1 = new RadWindow();
            window1.NavigateUrl = "Manage.aspx"+param;
            window1.VisibleOnPageLoad = true;
            window1.Modal = false;
            window1.Width = 600;
            window1.Height = 400;
            window1.VisibleStatusbar = false;
            window1.VisibleTitlebar = true;
            window1.OnClientClose = "OnClientclose";
            this.form1.Controls.Add(window1);

        }

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            dvcvrlist.Visible = false;
            dvManage.Visible = false;
            dvNote.Visible = true;
            txtMessage.Text = Data.Get_Comments(ViewState["accnt"].ToString(), ViewState["batch"].ToString());
        }

        protected void btnCancelMessage_Click(object sender, EventArgs e)
        {
            btnCancel_Click(null,null);
            dvNote.Visible = false;
        }

        protected void btnSaveMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (message.Length > 1000)
                message = message.Substring(0, 999);
            Data.Save_Comments(message, ViewState["accnt"].ToString(), ViewState["batch"].ToString());
            btnCancelMessage_Click(null, null);
        }

    }
}