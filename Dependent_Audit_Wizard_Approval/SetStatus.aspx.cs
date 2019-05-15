using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Telerik.Web.UI;

namespace Dependent_Audit_Wizard_Approval
{
    public partial class SetStatus : System.Web.UI.Page
    {
        string strSrc = "/web_projects/DocumentViwer/viewer.aspx?id=[id]&skip=1&type=application/pdf";
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            #region BasTemplate
            if (!IsPostBack)
            {

                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    string path = Request.Path + "?SkipCheck=YES";
                    if (Request.Params["pc"] != null)
                        path = Request.Path + "?SkipCheck=YES&pc=" + Request.Params["pc"];
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", path);
                    Response.Redirect("/web_projects/PTemplate/index.htm");
                    return;
                }
                Template.BasTemplate objBasTemplate = new Template.BasTemplate();
                try
                {
                    if (Request.Cookies["Session_ID"] == null)
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", true);
                    string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, false);
                    if (strResult != "")
                    {
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult, false);
                        return;
                    }
                    ViewState["AccessType"] = objBasTemplate.strAccessType;
                    ViewState["Employee_Number"] = objBasTemplate.strEmployee_Number;
                    ViewState["Processing_Year"] = objBasTemplate.strProcessingYear;
                    ViewState["Role_Restriction_Level"] = objBasTemplate.strRole_Restriction_Level;
                    ViewState["Selected_Account_Number"] = objBasTemplate.strSelected_Account_Number;
                    ViewState["Selected_Employee_Class_Code"] = objBasTemplate.strSelected_Employee_Class_Code;
                    ViewState["User_Group_ID"] = objBasTemplate.strUser_Group_ID;
                    ViewState["User_ID"] = objBasTemplate.strUser_ID;
                    ViewState["User_Name"] = objBasTemplate.strUser_Name;
                    ViewState["User_Primary_Role"] = objBasTemplate.strUser_Primary_Role;
                }
                catch (Exception ex)
                {
                    string strError = "Error Message: " + ex.Message + "~~Application:" + ex.Source + "~~Method:" + ex.TargetSite + "~~Detail:" + ex.StackTrace;
                    Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strError.Replace("\n", "~"));
                }
                finally
                {
                    objBasTemplate.CleanUp();
                    objBasTemplate.Dispose();
                }
            }
            #endregion
            if (!IsPostBack)
            {
                Page.MaintainScrollPositionOnPostBack = true;
                dvDes.Visible = false;
                dvWarning.Visible = false;
                dvimage.Visible = false;
                dvHeader.Visible = false;
                dvPending.Visible = false;
                dvDes.Visible = false;
                RadToolTip1.TargetControlID = lblStatusValue.ID;
                FillMasterAccnts();
            }

            if (!string.IsNullOrEmpty(hid3.Value))
            {
                processDependent(hid3.Value);
                hid3.Value = string.Empty;
            }

            if (!string.IsNullOrEmpty(hid560.Value))
            {
                hid2.Value = Hid560id.Value;
                SetStaus(hid2.Value);
                ShowPDF(hid560.Value);
                hid560.Value = string.Empty;
                Hid560id.Value = string.Empty;
                hid560sta.Value = string.Empty;
            }

            if (!string.IsNullOrEmpty(hidAction.Value))
            {
                if (hidAction.Value.Equals("Cancel"))
                    DoCancel();
                else if (hidAction.Value.Equals("Reset"))
                    ResetPage();
                else if (hidAction.Value.Equals("Master"))
                    ResetMaster();
                hidAction.Value = string.Empty;
            }
        }

        private void SetStaus(string record_id)
        {
            DataTable tbl = Data.DocumentStatusForStatus(record_id);
            rblApproval.Items[0].Selected = false;
            rblApproval.Items[1].Selected = false;
            try
            {
                lblDepStatus.Text = "Current Status: " + tbl.Rows[0]["status"].ToString();
                try
                {
                    //rblApproval.Items.FindByText( (tbl.Rows[0]["status"].ToString()).Selected = true;
                    if (tbl.Rows[0]["StatusNo"].ToString().ToString().Contains("1"))
                        rblApproval.Items[0].Selected = true;
                    if (tbl.Rows[0]["StatusNo"].ToString().ToString().Contains("2"))
                        rblApproval.Items[1].Selected = true;
                }
                catch { }
                lblStatusValue.ToolTip = tbl.Rows[0]["DocStatus"].ToString();
                lblStatusValue.Text = tbl.Rows[0]["DocStatus"].ToString();
                ViewState["Dep_no"] = tbl.Rows[0]["dependent_sequence_no"].ToString();
                if ((tbl.Rows[0]["DocStatus_id"].ToString().Equals("1"))||
                    (tbl.Rows[0]["status"].ToString().Equals("Approved")))
                {

                    try
                    {
                        rblApproval.Items.FindByText(tbl.Rows[0]["status"].ToString()).Selected = true;
                    }
                    catch { }
                    btApply.Visible = true;
                    dvDes.Visible = true;

                }
                else
                {
                    dvDes.Visible = false;
                    lblDepStatus.Text = string.Empty;
                }

                //btApply.Visible = !rblApproval.SelectedIndex.Equals(0);
                
            }
            catch
            {
                dvDes.Visible = false;
                
                
            }
           // rblApproval.ClearSelection();
        }

        private void ResetMaster()
        {
            ddlMaterAccounts.Items.Clear();
            FillMasterAccnts();
            ResetPage();
        }

        private void FillMasterAccnts()
        {
            DataTable tbl = Data.Pending_Master_Accounts(session_id);
            foreach(DataRow dr in tbl.Rows)
            {
                if (!dr["account_number"].ToString().StartsWith("0000699"))
                {
                    dr.Delete();
                }
            }
            tbl.AcceptChanges();
            ddlMaterAccounts.DataSource = tbl;
            ddlMaterAccounts.DataTextField = "account_name";
            ddlMaterAccounts.DataValueField = "account_number";
            ddlMaterAccounts.DataBind();
        }

        private void DoCancel()
        {
            dvDoc.Visible = true;
            rblApproval.ClearSelection();
            btApply.Visible = false;
        }

        private void ShowPDF(string r_log_id)
        {
            //dvDes.Visible = true;
            dvWarning.Visible =true;
            Viewer.Attributes.Add("src", strSrc.Replace("[id]", r_log_id));
        }

        private int CurrentImageIndex()
        {
            return (int)ViewState["CurrentlyViewed"];
        }

        private void setPrevImageIndex()
        {
            int index = (int)ViewState["CurrentlyViewed"];
            if (index > 1)
            {
                index--;
                ViewState["CurrentlyViewed"] = index;
            }
        }

        private void setNexImageIndex()
        {
            int index = (int)ViewState["CurrentlyViewed"];
            if (index < (int)ViewState["count"])
            {
                index++;
                ViewState["CurrentlyViewed"] = index;
            }
        }

        private string GetR_log(int index)
        {
            ArrayList al = new ArrayList();
            al = (ArrayList)ViewState["AllImages"];
            string strImageData = al[index - 1].ToString();
            string[] str = strImageData.Split('~');
            lblDocName.Text = str[2];
            hid2.Value = str[0];

            lblStatusValue.Text = str[4];
            lblStatusValue.ToolTip = string.Empty;
            if (str[3].ToString().Equals("2"))// Decline
            {
                lblStatusValue.ToolTip = str[7];
                lblStatusValue.Text = lblStatusValue.Text + " (View)";
            }
            else if (str[3].Equals("3"))// More Inf
            {
                lblStatusValue.ToolTip = str[7];
                lblStatusValue.Text = lblStatusValue.Text + " (View)";
            }
            else if (str[3].Equals("0"))// More Inf
            {
                lblStatusValue.ToolTip = "Have not been processed yet";
                lblStatusValue.Text = lblStatusValue.Text + " (View)";
            }
            else if (str[3].Equals("1"))// More Inf
            {
                lblStatusValue.ToolTip = "Processed and approved";
                lblStatusValue.Text = lblStatusValue.Text + " (View)";
            }

            try
            {
                rblApproval.Items.FindByValue(str[3]).Selected = true;
            }
            catch
            {
                rblApproval.ClearSelection();
                btApply.Visible = false;
            }
            return str[1];

        }



        private void buildDocumentsList(DataTable tbl)
        {
            ArrayList al = new ArrayList(tbl.Rows.Count);
            foreach (DataRow dr in tbl.Rows)
            {
                al.Add(dr["record_id"].ToString() + "~" + dr["r_log_record_id"].ToString() + "~" + dr["file_name"].ToString() + "~" + dr["status"].ToString() + "~" +
                    dr["status_text"].ToString() + "~" + dr["Dep_Name"].ToString() + "~" + dr["status_text"].ToString() + "~" +
                    dr["Decline"].ToString() + dr["More_Info"].ToString());
            }
            ViewState["AllImages"] = al;
            ViewState["CurrentlyViewed"] = 1;
            ViewState["count"] = tbl.Rows.Count;
        }

        private void processDependent(string dependent_number)
        {
            Viewer.Attributes.Add("src", "");
            DataTable tbl = Data.GetDepDocuments(dependent_number);
            rblApproval.Visible = true;
            if (tbl.Rows.Count.Equals(1))
            {
                dvimage.Visible = false;
                hid2.Value = tbl.Rows[0]["record_id"].ToString();
                ShowPDF(tbl.Rows[0]["r_log_record_id"].ToString());
                lblStatusValue.Text = tbl.Rows[0]["status_text"].ToString();
                lblStatusValue.ToolTip = string.Empty;
                if (tbl.Rows[0]["status"].ToString().Equals("2"))// Decline
                {
                    lblStatusValue.ToolTip = tbl.Rows[0]["Decline"].ToString();
                    lblStatusValue.Text = lblStatusValue.Text + " (View)";
                }
                else if (tbl.Rows[0]["status"].ToString().Equals("3"))// More Inf
                {
                    lblStatusValue.ToolTip = tbl.Rows[0]["More_Info"].ToString();
                    lblStatusValue.Text = lblStatusValue.Text + " (View)";
                }
                else if (tbl.Rows[0]["status"].ToString().Equals("0"))// More Inf
                {
                    lblStatusValue.ToolTip = "Have not been processed yet";
                    lblStatusValue.Text = lblStatusValue.Text + " (View)";
                }
                else if (tbl.Rows[0]["status"].ToString().Equals("1"))// More Inf
                {
                    lblStatusValue.ToolTip = "Processed and approved";
                    lblStatusValue.Text = lblStatusValue.Text + " (View)";
                }

                try
                {
                    rblApproval.Items.FindByValue(tbl.Rows[0]["status"].ToString()).Selected = true;
                }
                catch
                {
                    rblApproval.ClearSelection();
                    btApply.Visible = false;
                }
                return;
            }
            buildDocumentsList(tbl);
            dvimage.Visible = true;
            ShowPDF(GetR_log((int)ViewState["CurrentlyViewed"]));


        }

        protected void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (CurrentImageIndex() == 1)
                return;
            setPrevImageIndex();
            ShowPDF(GetR_log(CurrentImageIndex()));
        }

        protected void btnNextImage_Click(object sender, EventArgs e)
        {
            setNexImageIndex();
            ShowPDF(GetR_log(CurrentImageIndex()));
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgEEList.DataSource = Data.processed_dependents560(session_id, ddlMaterAccounts.SelectedValue);            
        }

        private void DrawGrid()
        {
            if (ddlMaterAccounts.SelectedValue.Equals("ALL"))
                rgEEList.DataSource = Data.Pending_Dependents();
            else
            {
                if (Data.Get_er_property_accnt(ddlMaterAccounts.SelectedValue, "560").Equals("1"))
                    rgEEList.DataSource = Data.pending_dependents560(session_id, ddlMaterAccounts.SelectedValue);
                else
                    rgEEList.DataSource = Data.Pending_Dependents(ddlMaterAccounts.SelectedValue);
            }
            rgEEList.DataBind();
        }

        protected void rgEEList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName && e.Item is GridDataItem)
            {
                int iopen = -1;
                bool boolstop = false;
                foreach (GridDataItem dataItem in rgEEList.MasterTableView.Items)
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

                hid2.Value = e.Item.ItemIndex.ToString();

                rgEEList.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true; //.GetDataKeyValue(.DataKeyValues[0].ToString();

                int SelValue = Convert.ToInt32(rgEEList.SelectedValue.ToString());

                int index1 = Convert.ToInt32(hid2.Value.ToString());

                lblEmail.Text = Data.ee_Email(SelValue.ToString());
                lblNoEmail.Visible = string.IsNullOrEmpty(lblEmail.Text);
                lblEmail.Visible = !lblNoEmail.Visible;
                if (lblEmail.Visible)
                    lblEmail.Text = "Employee's Email Address: " + lblEmail.Text;



                ((RadGrid)rgEEList.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataSource = Data.GetDependentsForStatus(SelValue.ToString());
                ((RadGrid)rgEEList.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataBind();

                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();

                SQLStatic.Sessions.SetSessionValue(session_id, "EMPLOYEE_NUMBER", SelValue.ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "ACCOUNT_NUMBER", SQLStatic.EmployeeData.Account_Number(SelValue.ToString()), conn);

                lblScript.Text = @"<script language='javascript' type='text/javascript'> try {window.top.RefreshHeader(); } catch (err) { };  
                        try {window.top.RefreshTopSession(); } catch (err) { } </script>";

                Viewer.Attributes.Add("src", string.Empty);
                dvimage.Visible = false;
                dvDes.Visible = false;
                dvWarning.Visible = dvDes.Visible;
                dvDoc.Visible = true;

            }
        }

        protected void rgEEList_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        private void ResetPage()
        {
            string strSelectedEE = string.Empty;
            dvimage.Visible = false;
            dvDes.Visible = false;
            dvWarning.Visible = dvDes.Visible;
            dvDoc.Visible = true;
            Viewer.Attributes.Add("src", "");
            foreach (GridDataItem item in rgEEList.MasterTableView.Items)
            {
                if (item.Selected)
                {
                    strSelectedEE = item.GetDataKeyValue("employee_number").ToString();
                }
            }

            DrawGrid();

            int iopen = -1;
            bool boolstop = false;
            foreach (GridDataItem item in rgEEList.MasterTableView.Items)
            {
                if (!boolstop)
                    iopen++;
                if (item.GetDataKeyValue("employee_number").ToString() == strSelectedEE)
                {
                    boolstop = true;
                    item.Selected = true;
                    item.Expanded = true;
                }

            }
            if ((!string.IsNullOrEmpty(strSelectedEE)) && (!iopen.Equals(-1)))
            {
                ((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).DataSource = Data.GetDependents(strSelectedEE);
                ((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).DataBind();
            }


        }

        protected void btApply_Click(object sender, EventArgs e)
        {
            string strStuent = "F";
            if (rblApproval.Items[0].Selected)
                strStuent = "T";

            string strDisab = "F";
            if (rblApproval.Items[1].Selected)
                strDisab = "T";
            Data.ModifyDependentStatu(ViewState["Dep_no"].ToString(), strStuent, strDisab, ViewState["User_Name"].ToString());

            SetStaus(hid2.Value);
  
            Bas_Utility.Misc.AlertSaved(Page);

            //if (rblApproval.SelectedValue.Equals("1"))
            //{
            //    dvDoc.Visible = false;
            //    ShowReason("1", , lblDocName.Text);
            //}
            //else if (rblApproval.SelectedValue.Equals("2"))
            //{
            //    dvDoc.Visible = false;
            //    ShowReason("2", hid2.Value, lblDocName.Text);
            //}
            //else if (rblApproval.SelectedValue.Equals("3"))
            //{
            //    dvDoc.Visible = false;
            //    ShowReason("3", hid2.Value, lblDocName.Text);
            //}


        }

        protected void rblApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            btApply.Visible = true;
        }



        protected void ShowReason(string code, string docId, string docName)
        {

            RadWindow window1 = new RadWindow();
            window1.Behavior = WindowBehaviors.Move;
            window1.NavigateUrl = "SaveStatus.aspx?code=" + code + "&docdocId=" + docId + "&docName=" + Server.HtmlDecode(docName);
            window1.VisibleOnPageLoad = true;
            window1.Modal = true;
            window1.Width = 400;
            window1.Height = 300;
            window1.VisibleStatusbar = false;
            window1.VisibleTitlebar = true;
            if (code.Equals("2"))
                window1.Skin = "Sunset";
            else if (code.Equals("1"))
                window1.Skin = "Default";
            else if (code.Equals("3"))
            {
                window1.Skin = "WebBlue";
                window1.Height = 320;
            }
            window1.OnClientClose = "OnClientclose";
            this.form1.Controls.Add(window1);

        }

        protected void ddlMaterAccounts_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ResetPage();
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            dvReady.Visible = RadTabStrip1.SelectedTab.Value.Equals("1");
            dvPending.Visible = !dvReady.Visible;
            //if (dvPending.Visible)
            //    DrawGridNoDoc();
        }

        //protected void DrawGridNoDoc()
        //{
        //    if (ddlMaterAccounts.SelectedValue.Equals("ALL"))
        //        rgPending.DataSource = Data.Pending_Dependents_No_doc();
        //    else
        //        rgPending.DataSource = Data.Pending_Dependents_No_doc(ddlMaterAccounts.SelectedValue);
        //    rgPending.DataBind();
        //}

        //protected void rgPending_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{
        //    if (ddlMaterAccounts.SelectedValue.Equals("ALL"))
        //        rgPending.DataSource = Data.Pending_Dependents_No_doc();
        //    else
        //        rgPending.DataSource = Data.Pending_Dependents_No_doc(ddlMaterAccounts.SelectedValue);
        //}

        protected void rgPending_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }
    }
}