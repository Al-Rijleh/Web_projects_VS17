using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace DependentsAuditGetDocuments
{
    public partial class Default : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            lblScript.Text = string.Empty;
            #region BasTemplate
            if (!IsPostBack)
            {

                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
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
            if (ViewState["Employee_Number"].ToString().Equals("0"))
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "MYBACKPAGE",Request.Path+"?SkipCheck=YES");
                Response.Redirect("/web_projects/Employee_Search/default.aspx?inner=1&SkipCheck=YES",true);
                return;
            }
            if (!IsPostBack)
            {
                ViewState["dep_id"] = SQLStatic.Sessions.GetSessionValue(session_id, "DEPENDDEP");
                if (!string.IsNullOrEmpty(ViewState["dep_id"].ToString()))
                {
                    ViewState["back"] = SQLStatic.Sessions.GetSessionValue(session_id, "DEPENBACK");
                    btnDone.Visible = true;
                    SQLStatic.Sessions.SetSessionValue(session_id, "DEPENDDEP", string.Empty);
                    SQLStatic.Sessions.SetSessionValue(session_id, "DEPENBACK", string.Empty);
                }

                if (!string.IsNullOrEmpty(Request.Params["OE"]))
                    btnDone.Visible = false;
                else
                    lblWarning.Text = "<span style='color: red;'><strong><span style='font-size: 11pt; font-family: Calibri, sans-serif;'>No Dependents to validate</span></strong></span>";

                if (string.IsNullOrEmpty(Request.Params["depmain"]))
                {
                    btnDone.Visible = true;
                    btnDone.Text = "Finished Return to Manage Dependents";
                    btnDone.Width = System.Web.UI.WebControls.Unit.Pixel(250); 
                    ViewState["back"] = "/WEB_PROJECTS/DEPENDENTS_MAINTENANCE/DefaultOld.aspx?SkipCheck=YES";
                }

                if (string.IsNullOrEmpty(Request.Params["depent"]))
                {
                    btnDone.Visible = true;
                    btnDone.Text = "Finished Return to Manage Dependents";
                    btnDone.Width = System.Web.UI.WebControls.Unit.Pixel(250);
                    ViewState["back"] = "/web_projects/EnrollmentWizard/DependentInfo.aspx";
                }

                if (string.IsNullOrEmpty(Request.Params["cat"]))
                    lblInstruction.Visible = false;
                lblInstruction2.Text = lblInstruction2.Text.Replace("[effectiv]", Data.RequiredSubmissionDate(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()));
                lblEEName.Text = "<b>Employee</b>&nbsp;" + SQLStatic.EmployeeData.employee_name_(ViewState["Employee_Number"].ToString()) + " (ID#" + ViewState["Employee_Number"].ToString() + ")";

                if (SQLStatic.AccountData.RetaAccount(ViewState["Selected_Account_Number"].ToString()))
                {
                    ViewState["NonReta"] = 0;
                }
                else
                {
                    lblInstruction2.Visible = false;
                    ViewState["NonReta"] = 1;
                }
                dvFax.Visible = false;
                dvFaxSent.Visible = Data.showuploadedFaxes(ViewState["Employee_Number"].ToString()).Equals("1");
                rgFax.Visible = dvFaxSent.Visible;
            }


            if (!string.IsNullOrEmpty(hidUpload.Value))
            {
                dvFax.Visible = false;
                OpenRow(hidUpload.Value);
                ProcessUpload(hidUpload.Value);
                hidUpload.Value = string.Empty;
            }

            if (!string.IsNullOrEmpty(hidFax.Value))
            {
                OpenRow(hidFax.Value);
                ProcessFax(hidFax.Value);
                hidFax.Value = string.Empty;
            }

            if (!string.IsNullOrEmpty(hid1.Value))
            {
                hid1.Value = string.Empty;

                ResetPage();

                //DrawGrid();

            }
            if (!string.IsNullOrEmpty(hidRemove.Value))
            {
                Data.RemoveDocument(hidRemove.Value);
                hidRemove.Value = string.Empty;
                ResetPage();

                //DrawGrid();

            }
            if (!string.IsNullOrEmpty(hidRemoveFax.Value))
            {
                Data.RemoveFax(hidRemoveFax.Value, ViewState["User_Name"].ToString());
                hidRemoveFax.Value = string.Empty;
                dvFax.Visible = false;
                dvFaxSent.Visible = Data.showuploadedFaxes(ViewState["Employee_Number"].ToString()).Equals("1");
                rgFax.Visible = dvFaxSent.Visible;
                if (rgFax.Visible)
                    DrawrgFax();
                ResetPage();

                //DrawGrid();

            }

        }

        private void OpenRow(string strDepNo)
        {
            foreach (GridDataItem item in rgEEList.MasterTableView.Items)
            {
                item.Selected = false;
                item.Expanded = false;
            }

            foreach (GridDataItem item in rgEEList.MasterTableView.Items)
            {
                if (item.GetDataKeyValue("dependent_sequence_no").ToString() == strDepNo)
                {
                    item.Selected = true;
                    item.Expanded = true;
                }
            }
        }

        private void ResetPage()
        {

            string strSelected = string.Empty;

            foreach (GridDataItem item in rgEEList.MasterTableView.Items)
            {
                if (item.Selected)
                {
                    strSelected = item.GetDataKeyValue("dependent_sequence_no").ToString();
                }
            }

            DrawGrid();

            int iopen = -1;
            bool boolstop = false;
            foreach (GridDataItem item in rgEEList.MasterTableView.Items)
            {
                if (!boolstop)
                    iopen++;
                if (item.GetDataKeyValue("dependent_sequence_no").ToString() == strSelected)
                {
                    boolstop = true;
                    item.Selected = true;
                    item.Expanded = true;

                }

            }
            DataTable tbl = null;

            if (ViewState["NonReta"].ToString().Equals("1"))
                tbl = Data.GetDocumentsNonReta(strSelected);
            else
                tbl = Data.GetDocuments(strSelected);

            //((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            //((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            ((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).DataSource = tbl;
            ((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).DataBind();
        }

        private void ProcessUpload(string dep_id)
        {
            ViewState["Dep_No"] = dep_id;
            SQLStatic.Sessions.SetSessionValue(session_id, "dep_id", dep_id);
            SQLStatic.Sessions.SetSessionValue(session_id, "dep", dep_id);
            SQLStatic.Sessions.SetSessionValue(session_id, "DEPENDDEP", ViewState["dep_id"].ToString());
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "DEPENBACK", ViewState["back"].ToString());
            }
            catch { }
            OpenScan();

        }

        private void ProcessFax(string dep_id)
        {
            ViewState["Dep_No"] = dep_id;
            SQLStatic.Sessions.SetSessionValue(session_id, "dep_id", dep_id);
            SQLStatic.Sessions.SetSessionValue(session_id, "dep", dep_id);
            dvFax.Visible = true;
            btnPrintCoverSheet.Attributes.Add("onclick", "showfax('" + dep_id + "')");
        }

        private void DrawGrid()
        {
            DataTable tbl = Data.DepRequiringVerifications(ViewState["Employee_Number"].ToString(), Request.Params["cat"]);
            if (!string.IsNullOrEmpty(ViewState["dep_id"].ToString()))
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!dr["dependent_sequence_no"].ToString().Equals(ViewState["dep_id"].ToString()))
                        dr.Delete();
                }
                tbl.AcceptChanges();
            }
            if (tbl.Rows.Count.Equals(0))
                lblWarning.Visible = true;
            else
            {
                rgEEList.DataSource = tbl;
                rgEEList.DataBind();
            }
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

                rgEEList.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true;

                int SelValue = Convert.ToInt32(rgEEList.SelectedValue.ToString());

                int index1 = Convert.ToInt32(hid2.Value.ToString());

                DataTable tbl = null;

                if (ViewState["NonReta"].ToString().Equals("1"))
                    tbl = Data.GetDocumentsNonReta(SelValue.ToString());
                else
                    tbl = Data.GetDocuments(SelValue.ToString());

                //((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                //((RadGrid)rgEEList.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                ((RadGrid)rgEEList.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataSource = tbl;
                ((RadGrid)rgEEList.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataBind();
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string strCatCode = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["cat"]))
                strCatCode = Request.Params["cat"];
            DataTable tbl = Data.DepRequiringVerifications(ViewState["Employee_Number"].ToString(),strCatCode);
            if (!string.IsNullOrEmpty( ViewState["dep_id"].ToString()))
            {
                foreach(DataRow dr in tbl.Rows)
                {
                    if (!dr["dependent_sequence_no"].ToString().Equals( ViewState["dep_id"].ToString()))
                        dr.Delete();
                }
                tbl.AcceptChanges();
            }
            if (tbl.Rows.Count.Equals(0))
                lblWarning.Visible = true;
            else
                rgEEList.DataSource = tbl;
        }

        protected void OpenScan()
        {
            RadWindow window1 = new RadWindow();

            window1.NavigateUrl = "/web_projects/TestUpload/Default.aspx";
            window1.VisibleOnPageLoad = true;
            window1.Modal = true;
            window1.Width = 620;
            window1.Height = 450;
            window1.VisibleStatusbar = false;
            window1.VisibleTitlebar = false;
            window1.OnClientClose = "OnClientclose";
            this.Form.Controls.Add(window1);
            return;
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["back"].ToString(), true);
        }

        protected void rgFax_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName && e.Item is GridDataItem)
            {
                int iopen = -1;
                bool boolstop = false;
                foreach (GridDataItem dataItem in rgFax.MasterTableView.Items)
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

                rgFax.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true;

                int SelValue = Convert.ToInt32(rgFax.SelectedValue.ToString());

                int index1 = Convert.ToInt32(hid2.Value.ToString());

                DataTable tbl = null;

                if (ViewState["NonReta"].ToString().Equals("1"))
                    tbl = Data.uploadedFaxes(SelValue.ToString());
                else
                    tbl = Data.uploadedFaxes(SelValue.ToString());

                //((RadGrid)rgFax.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                //((RadGrid)rgFax.MasterTableView.Items[iopen].ChildItem.FindControl("rgDetal")).ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                ((RadGrid)rgFax.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataSource = tbl;
                ((RadGrid)rgFax.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataBind();
            }
        }

        protected void DrawrgFax()
        {
            string strCatCode = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["cat"]))
                strCatCode = Request.Params["cat"];
            DataTable tbl = Data.DepRequiringVerifications(ViewState["Employee_Number"].ToString(), strCatCode);
            if (!string.IsNullOrEmpty(ViewState["dep_id"].ToString()))
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!dr["dependent_sequence_no"].ToString().Equals(ViewState["dep_id"].ToString()))
                        dr.Delete();
                }
                tbl.AcceptChanges();
            }
            if (tbl.Rows.Count.Equals(0))
                lblWarning.Visible = true;
            else
            {
                rgFax.DataSource = tbl;
                rgFax.DataBind();
            }
        }

        protected void rgFax_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            string strCatCode = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["cat"]))
                strCatCode = Request.Params["cat"];
            DataTable tbl = Data.DepRequiringVerifications(ViewState["Employee_Number"].ToString(), strCatCode);
            if (!string.IsNullOrEmpty(ViewState["dep_id"].ToString()))
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!dr["dependent_sequence_no"].ToString().Equals(ViewState["dep_id"].ToString()))
                        dr.Delete();
                }
                tbl.AcceptChanges();
            }
            if (tbl.Rows.Count.Equals(0))
                lblWarning.Visible = true;
            else
                rgFax.DataSource = tbl;
        }

       
    }
}