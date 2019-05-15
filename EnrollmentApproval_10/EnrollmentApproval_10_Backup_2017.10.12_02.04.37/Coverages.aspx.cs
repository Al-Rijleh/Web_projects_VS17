using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace EnrollmentApproval
{
    public partial class Coverages : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();

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

            if (!IsPostBack)
            {
                
                if (!string.IsNullOrEmpty(Request.Params["ee"]))
                {
                    if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                        Response.Redirect("Dependents.aspx?SkipCheck=YES&Skipcvrg=1&ee=" + Request.Params["ee"] + "&Verify=" + Request.Params["Verify"], true);
                    if (!Data.HasMorePendingCvrg(Request.Params["ee"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                            Response.Redirect("Dependents.aspx?SkipCheck=YES&Skipcvrg=1&ee=" + Request.Params["ee"] + "&Verify=" + Request.Params["Verify"], true);
                        else
                          Response.Redirect("Dependents.aspx?SkipCheck=YES&Skipcvrg=1&ee=" + Request.Params["ee"], true);
                    }
                    dvLeft.Visible = false;
                    dvRight.Style.Add("float","left");
                    btnBack.Visible = true;
                    ViewState["EE_Number"] = Request.Params["ee"];
                    setLabelName();
                }
                else
                {
                    ViewState["EE_Number"] = "-1";
                    drawEEGrid();
                }
            }
            if (!string.IsNullOrEmpty(hidDecline.Value))
            {
                DisApprove(hidDecline.Value);
                hidDecline.Value = "";
                return;
            }
            //if (!Data.HasMorePendingCvrg(Request.Params["ee"]))
            //{
            //    Response.Redirect("Dependents.aspx?SkipCheck=YES&Skipcvrg=1&ee=" + Request.Params["ee"], true);
            //}
            AutoSelect();
            DrawCvrgGrid();
            DrawDepGrid();

        }

        private void AutoSelect()
        {
            if (rgEmployees.SelectedIndexes.Count == 0)
            {
                rgEmployees.SelectedIndexes.Add(0);
                DataTable tbl = (DataTable)rgEmployees.DataSource;
                try
                {
                    if (tbl.Rows.Count > 0)
                    {
                        lblNo.Text = tbl.Rows.Count.ToString();
                        ViewState["EE_Number"] = tbl.Rows[0]["employee_number"].ToString();
                        DrawCvrgGrid();
                        if (!gvCvrg.Visible)
                        {
                            
                        }
                        DrawDepGrid();
                        setLabelName();
                    }
                }
                catch
                {
                }
            }
        }

        private void DrawDepGrid()
        {
            DataTable tbl = Data.GetPendingDepCvrgsForEE(session_id, ViewState["EE_Number"].ToString());
            gvDepCvrg.DataSource = tbl;
            gvDepCvrg.DataBind();
            lblDenentsList.Visible = !tbl.Rows.Count.Equals(0);
        }



        private void DrawCvrgGrid()
        {
            DataTable tbl = Data.GetPendingCvrgs(ViewState["EE_Number"].ToString());
            if (!string.IsNullOrEmpty(Request.Params["ee"]))
            {
                if (tbl.Rows.Count.Equals(0))
                {
                    gvCvrg.Visible = false;
                    return;
                }
            }
            gvCvrg.DataSource = tbl;
            gvCvrg.DataBind();
            lblName.Visible = !tbl.Rows.Count.Equals(0);
        }

        private void drawEEGrid()
        {
            DataTable tbl = Data.Pending_Employee_Cvrg(session_id);
            if (tbl.Rows.Count.Equals(0))
                lblNoRecords.Visible = true;
            rgEmployees.DataSource = tbl;
            rgEmployees.DataBind();
        }


        private void Fill(RadioButtonList rblst, string value0, string value1)
        {
            for (int i = 0; i < 2; i++)
            {
                ListItem li = null;
                if (i.Equals(0))
                {
                    li = new ListItem("Disapprove", value0);
                }
                else
                {
                    li = new ListItem("Approve", value1);
                }
                rblst.Items.Add(li);
            }
        }



        protected void gvCvrg_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvCvrg.DataSource;
            if (dt == null)
                return;
            int intRowIndex = e.Row.RowIndex;
            if ((intRowIndex < 0) || (intRowIndex >= dt.Rows.Count))
                return;
            //string strIndex = intRowIndex.ToString();
               string strIndex = dt.Rows[e.Row.RowIndex]["record_id"].ToString();

            LinkButton lnkbtnD = new LinkButton();
            lnkbtnD.ID = "lnkbtnD_" + strIndex;
            lnkbtnD.Text = "/ Decline";
            lnkbtnD.Click += new System.EventHandler(this.Clicked);

            LinkButton lnkbtnA = new LinkButton();
            lnkbtnA.ID = "lnkbtnA_" + strIndex;
            lnkbtnA.Text = "Approve ";
            lnkbtnA.Click += new System.EventHandler(this.ClickedA);

            Label lbl_chilld = new Label();
            lbl_chilld.ID = "lbl_chilld_" + strIndex;
            lbl_chilld.Text = "Child Plan (Bundled Coverage)";

            TableCell cell_req = e.Row.Cells[3];
            if ((dt.Rows[intRowIndex]["links_detail_item_type"].ToString().Equals("0")) && (dt.Rows.Count > 1))
                cell_req.Controls.Add(lbl_chilld);
            else
            {
                cell_req.Controls.Add(lnkbtnA);
                cell_req.Controls.Add(lnkbtnD);
            }

            Label lbl_Status = new Label();
            lbl_Status.ID = "lbl_Status" + strIndex;
            if (dt.Rows[intRowIndex]["family_status_code"].ToString().Equals("010"))
                lbl_Status.Text = dt.Rows[intRowIndex]["Benefit_Level"].ToString();
            else
                lbl_Status.Text = dt.Rows[intRowIndex]["description"].ToString();
            TableCell cell_Status = e.Row.Cells[1];
            cell_Status.Controls.Add(lbl_Status);

            RadDatePicker  txtEffDate = new RadDatePicker();
            txtEffDate.ID = "txtEffDate"+strIndex;
            txtEffDate.Width = new Unit(110, UnitType.Pixel);
            txtEffDate.DateInput.DisplayDateFormat="M/d/yyyy";
            try
            {
                txtEffDate.SelectedDate = Convert.ToDateTime(dt.Rows[intRowIndex]["effective_date"].ToString());
            }
            catch { }
            TableCell cell_eff = e.Row.Cells[2];
            cell_eff.Controls.Add(txtEffDate);

           
        }

        protected void Clicked(object sender, EventArgs e)
        {
            string strIndex = (sender as LinkButton).ID.Replace("lnkbtnD_", "");
            
            //int iIndex = Convert.ToInt16(strIndex);
            //DataTable tbl = gvCvrg.DataSource as DataTable;
            //if (tbl == null)
            //    tbl = Data.GetPendingCvrgs(ViewState["EE_Number"].ToString());
            //tbl.Dispose();
            string strMsg = "Are you sure you want to decline coverage " + Data.PeningCoverageLongDespription(strIndex) + "?\\n Press Ok for Yes Cancel for No";
            
            string strVerify = "<script>verify('" + strMsg + "'," + strIndex + ")</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strVerify", strVerify);
            //DisApprove(strIndex);

        }

        protected void ClickedA(object sender, EventArgs e)
        {
            string strIndex = (sender as LinkButton).ID.Replace("lnkbtnA_", "");
            
            RadDatePicker txtEffDatE = Bas_Utility.Utilities.GetRadDatePicker(Page, "txtEffDate" + strIndex);
            try
            {
               ViewState["deffectiveDate"]  = txtEffDatE.SelectedDate.Value.ToString("MM/dd/yyyy");
            }
            catch
            {
                Bas_Utility.Misc.Alert(Page, "Require Effective Date");
                return;
            }
            
            Approve(strIndex);
        }

        protected void ClickedDep(object sender, EventArgs e)
        {
            //string strIndex = (sender as LinkButton).ID.Replace("lnkbtnD_", "");
            //int iIndex = Convert.ToInt16(strIndex);
            //DataTable tbl = gvDepCvrg.DataSource as DataTable;
            //if (tbl == null)
            //    tbl = Data.GetPendingDepCvrgsForEE(session_id, ViewState["EE_Number"].ToString());
            //string strMsg = "Are you sure you want to decline coverage " + tbl.Rows[iIndex]["long_description"].ToString() + "?\\n Press Ok for Yes Cancel for No";
            //tbl.Dispose();
            //string strVerify = "<script>verify('" + strMsg + "'," + strIndex + ")</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strVerify", strVerify);
            ////DisApprove(strIndex);

        }

        protected void ClickedDepA(object sender, EventArgs e)
        {
            //string strIndex = (sender as LinkButton).ID.Replace("lnkbtnA_", "");
            //DataTable tbl = gvDepCvrg.DataSource as DataTable;
            
            //Approve(strIndex);
        }

        private void SaveLife(DataRow dr)
        {

            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "Account_Number", dr["account_number"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "Employee_number", dr["employee_number"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "Category_Code", dr["category_code"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "Category_Plan", dr["category_plan"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "Family_Status_Code", dr["family_status_code"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "BENEFIT_LEVEL", dr["raw_multiplier_override"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "BENEFIT_AMOUNT", dr["raw_multiplier_override"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "Effective_date", ViewState["deffectiveDate"].ToString(), conn);
                
                SQLStatic.Sessions.SetSessionValue(session_id, "Skip", "1", conn);
                Data.CheckEnrollmentType(session_id, dr["record_id"].ToString());
                Data.SaveLifeCoverage(session_id, conn);
                Data.ProcessPendCoverages(session_id, dr["cvrg_group_header_id"].ToString(), "1", conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        private void SaveStatus(DataRow dr)
        {

            Data.SaveCoverage(session_id, dr["record_id"].ToString());
            jscriptsFunctions.Misc.AlertSaved(Page);
            //Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            //try
            //{
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Account_Number", dr["account_number"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Employee_number", dr["employee_number"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Category_Code", dr["category_code"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Category_Plan", dr["category_plan"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Family_Status_Code", dr["family_status_code"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "BENEFIT_LEVEL", dr["raw_multiplier_override"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "BENEFIT_AMOUNT", dr["raw_multiplier_override"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "PROCESSING_YEAR", dr["processing_year"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Effective_date", dr["effective_date"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Skip", "1", conn);
            //    Data.CheckEnrollmentType(session_id, dr["record_id"].ToString());

            //    Data.process_dependents(session_id, dr["record_id"].ToString());
            //    Data.SaveStausCoverage(session_id, conn);
            //    Data.ProcessPendCoverages(session_id, dr["cvrg_group_header_id"].ToString(), "1", conn);
            //}
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}

        }

        private void SaveDependents(DataRow dr)
        {

            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                DataTable tbl = Data.GetPendingDepCvrgs(session_id, dr["Record_id"].ToString());
                if (tbl.Rows.Count.Equals(0))
                    return;
                SQLStatic.Sessions.SetSessionValue(session_id, dr["Category_Code"].ToString(), "1", conn);
                foreach (DataRow drdep in tbl.Rows)
                {
                    SQLStatic.Sessions.SetSessionValue(session_id, dr["Category_Code"].ToString() + drdep["dependent_sequence_no"].ToString(), "1", conn);
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Data.ProcessDependentCoverages(session_id);
        }

        private void Disapprove(DataRow dr)
        {

            Data.DeclineCoverage(session_id, dr["record_id"].ToString());
            jscriptsFunctions.Misc.AlertSaved(Page);

            //Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            //try
            //{
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Account_Number", dr["account_number"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Employee_number", dr["employee_number"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Category_Code", dr["category_code"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Category_Plan", dr["category_plan"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Family_Status_Code", dr["family_status_code"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "BENEFIT_LEVEL", dr["raw_multiplier_override"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "BENEFIT_AMOUNT", dr["raw_multiplier_override"].ToString(), conn);
            //    SQLStatic.Sessions.SetSessionValue(session_id, "Skip", "1", conn);
            //    Data.ProcessPendCoverages(session_id, dr["cvrg_group_header_id"].ToString(), "2", conn);
            //}
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}

        }

        protected void Approve(string indx)
        {
            //DataTable tbl = gvCvrg.DataSource as DataTable;
            //if (tbl == null)
            //    tbl = Data.GetPendingCvrgs(ViewState["EE_Number"].ToString());
            //int intIndex = Convert.ToInt32(indx);
            //DataRow dr = tbl.Rows[intIndex];
            if (Data.PeningCoverageFamilyStatus(indx).Equals("010"))
                SaveLife(null);
            else
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "Effective_date", ViewState["deffectiveDate"].ToString());
                Data.SaveCoverage(session_id, indx);
                jscriptsFunctions.Misc.AlertSaved(Page);
            }
            if (!Data.HasMorePendingCvrg(ViewState["EE_Number"].ToString()))
            {
                drawEEGrid();
                AutoSelect();
            }
            if (!Data.HasMorePendingCvrg(Request.Params["ee"]))
            {
                Response.Redirect("Dependents.aspx?SkipCheck=YES&Skipcvrg=1&ee=" + Request.Params["ee"], true);
            }
            DrawCvrgGrid();
            DrawDepGrid();

        }

        protected void DisApprove(string indx)
        {
            Data.DeclineCoverage(session_id, indx);
            jscriptsFunctions.Misc.AlertSaved(Page);
            if (!Data.HasMorePendingCvrg(Request.Params["ee"]))
            {
                Response.Redirect("Dependents.aspx?SkipCheck=YES&Skipcvrg=1&ee=" + Request.Params["ee"], true);
            }
            //DataTable tbl = gvCvrg.DataSource as DataTable;
            //if (tbl == null)
            //    tbl = Data.GetPendingCvrgs(ViewState["EE_Number"].ToString());
            //int intIndex = Convert.ToInt32(indx);
            //DataRow dr = tbl.Rows[intIndex];
            //Disapprove(dr);
            //if (!Data.HasMorePendingCvrg(ViewState["EE_Number"].ToString()))
            //{
            //    drawEEGrid();
            //    AutoSelect();
            //}
            DrawCvrgGrid();
            DrawDepGrid();
        }

        //protected void gvDepCvrg_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    return;
        //    DataTable dt = (DataTable)gvDepCvrg.DataSource;
        //    if (dt == null)
        //        return;
        //    int intRowIndex = e.Row.RowIndex;
        //    if ((intRowIndex < 0) || (intRowIndex >= dt.Rows.Count))
        //        return;
        //    string strIndex = intRowIndex.ToString();

        //    LinkButton lnkbtnD = new LinkButton();
        //    lnkbtnD.ID = "lnkbtnD_" + strIndex;
        //    lnkbtnD.Text = "/ Decline";
        //    lnkbtnD.Click += new System.EventHandler(this.ClickedDep);

        //    LinkButton lnkbtnA = new LinkButton();
        //    lnkbtnA.ID = "lnkbtnA_" + strIndex;
        //    lnkbtnA.Text = "Approve ";
        //    lnkbtnA.Click += new System.EventHandler(this.ClickedDepA);
        //    TableCell cell= e.Row.Cells[4];
        //    cell.Controls.Add(lnkbtnA);
        //    cell.Controls.Add(lnkbtnD);
        //}



        protected void rgEmployees_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable tbl = Data.Pending_Employee_Cvrg(session_id);
            if (tbl.Rows.Count.Equals(0))
                lblNoRecords.Visible = true;
            this.rgEmployees.DataSource = tbl;
        }

        protected void rgEmployees_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                ViewState["EE_Number"] = (e.CommandSource as LinkButton).Text.Replace("<u>", "").Replace("</u>", "");
                DrawCvrgGrid();
                DrawDepGrid();
                setLabelName();
            }
        }

        private void setLabelName()
        {
            DataTable tbl = Data.ee_detail(session_id, ViewState["EE_Number"].ToString());
            lblName.Text = "<b>" + tbl.Rows[0]["name"].ToString() + " (MyEnroll ID# " + ViewState["EE_Number"].ToString() + ")</b><br />" +
                           tbl.Rows[0]["master_account_name"].ToString() + " (" + tbl.Rows[0]["masteraccountnumber"].ToString() + ")<br />" +
                           tbl.Rows[0]["account_name"].ToString() + " (" + tbl.Rows[0]["account_number"].ToString() + ")";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx?SkipCheck=YES", true);            
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dependents.aspx?SkipCheck=YES&ee=" + Request.Params["ee"], true);
        }
    }
}