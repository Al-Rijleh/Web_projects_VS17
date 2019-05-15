using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Audit_Documents_list
{
    public partial class Default : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            #region BasTemplate
            if (!IsPostBack)
            {                
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
                if ((ViewState["Employee_Number"] == null) || (ViewState["Employee_Number"].ToString().Equals("0")))
                    dvee.Visible = false;
                else
                    lblSelectedEmployee.Text = SQLStatic.EmployeeData.employee_name_(ViewState["Employee_Number"].ToString()) + " #" + ViewState["Employee_Number"].ToString();
                if (ViewState["User_Group_ID"].ToString().Equals("3") )
                    dvbtn.Visible = false;
                FillMasterAccounts();
            }
        }

        private void FillMasterAccounts()
        {
            DataTable tbl = Data.Pending_Master_AccountsForList(session_id);
            ddlMaterAccounts.DataSource = tbl;
            ddlMaterAccounts.DataTextField = "account_name";
            ddlMaterAccounts.DataValueField = "account_number";
            ddlMaterAccounts.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {             
            Response.Redirect("/web_projects/Employee_Search/Default.aspx?SkipCheck=YES&goto="+Request.Path, true);
        }

        protected void rgEEDoc_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!((ViewState["Employee_Number"] == null) || (ViewState["Employee_Number"].ToString().Equals("0"))))
                rgEEDoc.DataSource = Data.GetEEDocuments(ViewState["Employee_Number"].ToString());
        }

        protected void ddlMaterAccounts_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            FillDevions();
        }

        private void FillDevions()
        {
            DataTable tbl = Data.Pending_AccountsForList(session_id, ddlMaterAccounts.SelectedValue,ddlDays.SelectedValue);
            ddlItem.DataSource = tbl;
            ddlItem.DataTextField = "account_name";
            ddlItem.DataValueField = "account_number";
            ddlItem.DataBind();
        }

        protected void btnGetEEs_Click(object sender, EventArgs e)
        {
            DataTable tbl = Data.Pending_Dependents_List(session_id, ddlItem.SelectedValue, ddlDays.SelectedValue);
            rgEEDoc.DataSource = tbl;
            rgEEDoc.DataBind();
        }

        protected void ddlDays_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlMaterAccounts.SelectedValue))
              FillDevions();
        }


        // Vicora Code
        protected void chkRemovePaging_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkRemovePaging = (CheckBox)sender;
            if (!chkRemovePaging.Checked)
            {
                rgEEDoc.AllowPaging = false;
                rgEEDoc.Rebind();
            }
            else
            {
                rgEEDoc.AllowPaging = true;
                rgEEDoc.PageSize = 15;
                rgEEDoc.Rebind();

            }
        }

        protected void btnClearFilter_Click(object sender, ImageClickEventArgs e)
        {
            rgEEDoc.MasterTableView.FilterExpression = string.Empty;
            Telerik.Web.UI.RadToolBarItem textItem = RadToolBar1.FindItemByValue("ClearFilter");
            Telerik.Web.UI.RadToolTip RadToolTip1 = (Telerik.Web.UI.RadToolTip)textItem.FindControl("RadToolTip1");
            ImageButton btnClearFilter = (ImageButton)textItem.FindControl("btnClearFilter");
            btnClearFilter.Enabled = false;
            btnClearFilter.Visible = false;
            RadToolTip1.Text = "Clear All Grid Filters";
            foreach (Telerik.Web.UI.GridColumn column in rgEEDoc.MasterTableView.RenderColumns)
            {
                column.ResetCurrentFilterValue();
                column.ListOfFilterValues = null;
                if (column is Telerik.Web.UI.GridBoundColumn)
                {
                    Telerik.Web.UI.GridBoundColumn boundColumn = column as Telerik.Web.UI.GridBoundColumn;
                    boundColumn.CurrentFilterValue = string.Empty;
                }
            }
            Telerik.Web.UI.RadToolBarItem textItemFilter = RadToolBar1.FindItemByValue("Filters");
            Telerik.Web.UI.RadMenu tlbrMenu = (Telerik.Web.UI.RadMenu)textItemFilter.FindControl("tlbrMenu");
            Telerik.Web.UI.RadMenuItem SaveFilter = (Telerik.Web.UI.RadMenuItem)tlbrMenu.FindItemByValue("SaveFilter");
            SaveFilter.Enabled = false;
            rgEEDoc.MasterTableView.Rebind();

        }

        protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
        {

            RadToolBarButton btn = e.Item as RadToolBarButton;
            string caseSwitch = btn.CommandName.ToString();

            RadToolBarItem textItem = RadToolBar1.FindItemByValue("PagesAll");
            CheckBox chkPagesAll = (CheckBox)textItem.FindControl("chkPagesAll");

            if (chkPagesAll.Checked) { rgEEDoc.ExportSettings.IgnorePaging = true; }
            else { rgEEDoc.ExportSettings.IgnorePaging = false; }

            rgEEDoc.ExportSettings.ExportOnlyData = true;
            rgEEDoc.ExportSettings.OpenInNewWindow = true;
            string datetimerun = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");// DateTime.Now.ToString("MMddyyHHmm");
            string filename = "ABC";// DataAccess.get_report_name(Convert.ToInt32(ViewState["recid"].ToString()));
            rgEEDoc.ExportSettings.FileName = filename.Replace(" ", "_") + "_" + datetimerun;
            switch (caseSwitch)
            {
                case "XLSX":
                    //rgEEDoc.ExportSettings.Excel.Format = GridExcelExportFormat.Html;
                    rgEEDoc.MasterTableView.ExportToExcel();
                    break;
                case "PDF":
                    int itemsCount = rgEEDoc.PageCount * rgEEDoc.Items.Count;
                    if (itemsCount >= 3000 && rgEEDoc.ExportSettings.IgnorePaging)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('The data is too large for PDF file. Please filter the data or Export in CSV/XSL/DOC format');", true);
                        return;
                    }
                    rgEEDoc.ExportSettings.Pdf.ForceTextWrap = true;
                    rgEEDoc.ExportSettings.Pdf.PaperSize = Telerik.Web.UI.GridPaperSize.Letter;
                    rgEEDoc.ExportSettings.Pdf.PageHeight = Unit.Parse("215mm");
                    rgEEDoc.ExportSettings.Pdf.PageWidth = Unit.Parse("750mm");
                    rgEEDoc.ExportSettings.Pdf.PageLeftMargin = Unit.Parse("13mm");
                    rgEEDoc.ExportSettings.Pdf.PageRightMargin = Unit.Parse("13mm");
                    rgEEDoc.ExportSettings.Pdf.PageTopMargin = Unit.Parse("13mm");
                    rgEEDoc.ExportSettings.Pdf.PageBottomMargin = Unit.Parse("13mm");
                    rgEEDoc.ExportSettings.Pdf.AllowAdd = false;
                    rgEEDoc.ExportSettings.Pdf.AllowModify = false;
                    rgEEDoc.MasterTableView.ExportToPdf();
                    break;

                case "CSV":
                    rgEEDoc.MasterTableView.ExportToCSV();
                    break;
                case "DOC":
                    rgEEDoc.ExportSettings.Word.Format = GridWordExportFormat.Html;
                    rgEEDoc.MasterTableView.ExportToWord();
                    break;
            }
        }

        //protected void tlbrMenu_ItemClick(object sender, RadMenuEventArgs e)
        //{
        //    if (e.Item.Value == "SaveFilter")
        //    {
        //        string session = Request.Cookies["Session_ID"].Value;
        //        rgEEDoc.MasterTableView.FilterExpression = rgEEDoc.MasterTableView.FilterExpression.Replace("]", "\"");
        //        rgEEDoc.MasterTableView.FilterExpression = rgEEDoc.MasterTableView.FilterExpression.Replace("[", "\"");
        //        string filter = show_columns.Value + "|" + rgEEDoc.MasterTableView.FilterExpression;
        //        DataAccess.set_session_value(session, "REPORT_FILTER", filter);
        //    }
        //    else if (e.Item.Value == "RemoveSelectedFilter")
        //    {
        //        NameValueCollection queryString = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        //        queryString.Set("filterID", "");
        //        string session = Request.Cookies["Session_ID"].Value;
        //        SQLStatic.Sessions.SetSessionValue(session, "REPORT_FILTER", "");
        //        Response.Redirect("ReportGenerator.aspx?SkipCheck=YES");
        //    }
        //    else if ((e.Item.Value != "SaveFilter") || (e.Item.Value != "RemoveSelectedFilter") || (e.Item.Value != "LoadFilter"))
        //    {
        //        NameValueCollection queryString = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        //        queryString.Set("rfc", "false");
        //        Response.Redirect("ReportGenerator.aspx?SkipCheck=YES&filterID=" + e.Item.Value + "&filter_name=" + e.Item.Text + "&rfc=true");
        //    }

        //}

    }
}