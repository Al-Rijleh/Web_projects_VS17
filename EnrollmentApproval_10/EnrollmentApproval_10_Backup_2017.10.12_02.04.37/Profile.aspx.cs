using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EnrollmentApproval
{
    public partial class Profile : System.Web.UI.Page
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
                //if (!string.IsNullOrEmpty(Request.Params["ee"]))
                //    SQLStatic.Sessions.SetSessionValue(session_id, "employee_number", Request.Params["ee"]);
                //Tab1.ClearTabs();
                //Tab1.BuildTabs("pkg_enrollment_approvals.gettabslist");
                //Tab1.SetTab(Page.Request.Path);
                if (!string.IsNullOrEmpty(Request.Params["ee"]))
                {
                    ViewState["EE_Number"] = Request.Params["ee"];
                    dveelist.Visible = false;
                    dvButton.Visible = true;
                    btnBack.Visible = true;
                    lblRemaining.Visible = false;
                    //btnNext.Visible = btnBack.Visible;
                    btnSave.Visible = true;
                    dvProfile.Style.Add("float", "left");
                    DrawProfile();
                    setLabelName();
                    if (lblNoRecords0.Visible)
                    {
                        if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                            Response.Redirect("Coverages.aspx?SkipCheck=YES&SkipProfile=1&ee=" + Request.Params["ee"] + "&Verify=" + Request.Params["Verify"], true);
                        else
                            Response.Redirect("Coverages.aspx?SkipCheck=YES&SkipProfile=1&ee=" + Request.Params["ee"], true);
                    }

                }
                else
                {
                    ViewState["EE_Number"] = "-1";
                    dvButton.Visible = true;
                    btnBack.Visible = false;
                    //btnNext.Visible = btnBack.Visible;
                    drawEEGrid();
                    btnSave.Visible = true;
                }
            }
            AutoSelect();
            DrawProfile();
        }

        private void AutoSelect()
        {
            if (rgEmployees.SelectedIndexes.Count == 0)
            {
                rgEmployees.SelectedIndexes.Add(0);
                DataTable tbl = (DataTable)rgEmployees.DataSource;
                try
                {
                    lblNo.Text = tbl.Rows.Count.ToString();
                    if (tbl.Rows.Count > 0)
                    {
                        ViewState["EE_Number"] = tbl.Rows[0]["employee_number"].ToString();
                        DrawProfile();
                        setLabelName();
                    }
                }
                catch
                {
                }
            }
        }

        protected void rgEmployees_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                ViewState["EE_Number"] = (e.CommandSource as LinkButton).Text.Replace("<u>", "").Replace("</u>", "");
                DrawProfile();
                setLabelName();
            }
        }

        private DataTable GetData()
        {
            DataTable tblprof = Data.get_modified_profile(session_id, ViewState["EE_Number"].ToString());
            DataTable tbladd = Data.get_modified_address(session_id, ViewState["EE_Number"].ToString());
            tblprof.Merge(tbladd);
            return tblprof;
        }
        private void DrawProfile()
        {
            DataTable tbl = GetData();
            if (tbl.Rows.Count.Equals(0))
            {
                if (!string.IsNullOrEmpty(Request.Params["ee"]))
                {
                    btnNext.Enabled = true;
                    lblNoRecords0.Visible = true;
                    btnSave.Visible = false;
                    return;
                }
                else
                    drawEEGrid();

            }
            else
            {
                gvProfile.DataSource = tbl;
                gvProfile.DataBind();
            }
            gvProfile.Visible = !tbl.Rows.Equals(0);
        }

        private void setLabelName()
        {
            DataTable tbl = Data.ee_detail(session_id, ViewState["EE_Number"].ToString());
            lblName.Text = "<b>" + tbl.Rows[0]["name"].ToString() + " (MyEnroll ID# " + ViewState["EE_Number"].ToString() + ")</b><br />" +
                           tbl.Rows[0]["master_account_name"].ToString() + " (" + tbl.Rows[0]["masteraccountnumber"].ToString() + ")<br />" +
                           tbl.Rows[0]["account_name"].ToString() + " (" + tbl.Rows[0]["account_number"].ToString() + ")";
        }

        protected void rgEmployees_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable tbl = Data.GetPendingProfileEEList(session_id);
            if (tbl.Rows.Count.Equals(0))
            {
                lblNoRecords.Visible = true;
                btnSave.Visible = !lblNoRecords.Visible;
            }
            this.rgEmployees.DataSource = tbl;
        }

        protected void gvCvrg_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvProfile.DataSource;
            if (dt == null)
                return;
            int intRowIndex = e.Row.RowIndex;
            if ((intRowIndex < 0) || (intRowIndex >= dt.Rows.Count))
                return;
            string strIndex = intRowIndex.ToString();

            Label lbl = new Label();
            lbl.ID = "lbl_" + strIndex;
            if (dt.Rows[intRowIndex]["Existing"].ToString() == "")
                lbl.Text = "Empty";
            else
                lbl.Text = dt.Rows[intRowIndex]["Existing"].ToString();
            TableCell cell_Status = e.Row.Cells[1];
            cell_Status.Controls.Add(lbl);

            RadioButtonList rblst = new RadioButtonList();
            rblst.ID = "rblst_" + strIndex;
            rblst.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
            rblst.AutoPostBack = false;            
            Fill(rblst, "0", "1");
            TableCell cell_req = e.Row.Cells[3];
            cell_req.Controls.Add(rblst);

            //LinkButton lnkbtnD = new LinkButton();
            //lnkbtnD.ID = "lnkbtnD_" + strIndex;
            //lnkbtnD.Text = "/ Decline";
            //lnkbtnD.Click += new System.EventHandler(this.Clicked);

            //LinkButton lnkbtnA = new LinkButton();
            //lnkbtnA.ID = "lnkbtnA_" + strIndex;
            //lnkbtnA.Text = "Approve ";
            //lnkbtnA.Click += new System.EventHandler(this.ClickedA);

            
            //cell_req.Controls.Add(lnkbtnD);
        }

        private void Fill(RadioButtonList rblst, string value0, string value1)
        {
            for (int i = 0; i < 2; i++)
            {
                ListItem li = null;
                if (i.Equals(0))
                {
                    li = new ListItem("Decline", value0);
                }
                else
                {
                    li = new ListItem("Approve", value1);
                }
                rblst.Items.Add(li);
            }
        }

        protected void Clicked(object sender, EventArgs e)
        {
            string strIndex = (sender as LinkButton).ID.Replace("lnkbtnD_", "");
            DisApprove(strIndex);
            Response.Redirect("Profile.aspx?SkipCheck=YES&ee=" + Request.Params["ee"], true);
        }

        protected void ClickedA(object sender, EventArgs e)
        {
            string strIndex = (sender as LinkButton).ID.Replace("lnkbtnA_", "");
            Approve(strIndex);
            Response.Redirect("Profile.aspx?SkipCheck=YES&ee=" + Request.Params["ee"], true);
        }

        protected void DisApprove(string indx)
        {
            DataTable tbl = gvProfile.DataSource as DataTable;
            if (tbl == null)
                tbl = GetData();
            int intIndex = Convert.ToInt32(indx);
            DataRow dr = tbl.Rows[intIndex];
            if (dr["which"].ToString().Equals("a"))
                processdisapproveAddress(dr);

            //else
            //    processProfile(dr);

        }

        private void processdisapproveAddress(DataRow dr)
        {
            string sql = "update pending_emplyee_address  set  [fld_name] = '~[fls_value]' where employee_number = [eeno]";
            sql = sql.Replace("[fld_name]", dr["fld_name"].ToString());
            sql = sql.Replace("[fls_value]", dr["Proposed"].ToString());
            sql = sql.Replace("[eeno]", ViewState["EE_Number"].ToString());
            SQLStatic.SQL.ExecScaler(sql);
            if (GetData().Rows.Count.Equals(0))
            {
                Data.processes_profile_address(ViewState["EE_Number"].ToString(), ViewState["User_Name"].ToString());
                drawEEGrid();
                AutoSelect();
            }
            DrawProfile();
        }

        protected void Approve(string indx)
        {
            DataTable tbl = gvProfile.DataSource as DataTable;
            if (tbl == null)
                tbl = GetData();
            int intIndex = Convert.ToInt32(indx);
            DataRow dr = tbl.Rows[intIndex];
            if (dr["which"].ToString().Equals("a"))
                processAddress(dr);
            else
                processProfile(dr);

        }

        private void processProfile(DataRow dr)
        {
            if (dr["fld_name"].ToString().ToUpper().Equals("MARITAL_STATUS"))
            {
                Data.update_marital_status(ViewState["EE_Number"].ToString(), dr["Proposed"].ToString(), ViewState["User_Name"].ToString());
            }
            else if (dr["fld_name"].ToString().ToUpper().Equals("BIRTH_DATE"))
            {
                Data.update_DOB(ViewState["EE_Number"].ToString(), dr["Proposed"].ToString(), ViewState["User_Name"].ToString());
            }
            else
            {
                string sql = "update eeprofile_  set  [fld_name] = '[fls_value]',  maintenance_userid = '[user]',  maintenance_date_time = sysdate  where employee_number = [eeno]";
                sql = sql.Replace("[fld_name]", dr["fld_name"].ToString());
                sql = sql.Replace("[fls_value]", dr["Proposed"].ToString());
                sql = sql.Replace("[user]", ViewState["User_Name"].ToString());
                sql = sql.Replace("[eeno]", ViewState["EE_Number"].ToString());
                SQLStatic.SQL.ExecScaler(sql);
            }
            //if (GetData().Rows.Count.Equals(0))
            //{
            //    Data.processes_profile_address(ViewState["EE_Number"].ToString(), ViewState["User_Name"].ToString());
            //    drawEEGrid();
            //    AutoSelect();
            //}
            //DrawProfile();
        }



        private void processAddress(DataRow dr)
        {
            string sql = "update eeaddress  set  [fld_name] = '[fls_value]',  maintenance_userid = '[user]',  maintenance_date_time = sysdate  where employee_number = [eeno]";
            sql = sql.Replace("[fld_name]", dr["fld_name"].ToString());
            sql = sql.Replace("[fls_value]", dr["Proposed"].ToString());
            sql = sql.Replace("[user]", ViewState["User_Name"].ToString());
            sql = sql.Replace("[eeno]", ViewState["EE_Number"].ToString());
            SQLStatic.SQL.ExecScaler(sql);
            //if (GetData().Rows.Count.Equals(0))
            //{
            //    Data.processes_profile_address(ViewState["EE_Number"].ToString(), ViewState["User_Name"].ToString());
            //    drawEEGrid();
            //    AutoSelect();
            //}
            //DrawProfile();
        }

        private void drawEEGrid()
        {
            DataTable tbl = Data.GetPendingProfileEEList(session_id);
            if (tbl.Rows.Count.Equals(0))
            {
                lblNoRecords.Visible = true;
                btnSave.Visible = !lblNoRecords.Visible;
            }
            rgEmployees.DataSource = tbl;            
            rgEmployees.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx?SkipCheck=YES", true);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coverages.aspx?SkipCheck=YES&ee=" + Request.Params["ee"], true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = gvProfile.DataSource as DataTable;
            if (tbl == null)
                tbl = GetData(); 
            RadioButtonList rblst = null;
            string strRecord_id = "";
            int indx = 0;
            foreach (DataRow dr in tbl.Rows)
            {
                //rblst = FindControl( "rblst_" + indx.ToString()) as RadioButtonList ;
                rblst = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblst_" + indx.ToString());
                indx++;
                strRecord_id = rblst.ID.Replace("rblst_", "");
                if (rblst.SelectedValue.Equals("1"))
                {
                   
                }
                else if (rblst.SelectedValue.Equals("0"))
                {
                   
                }
                else
                {
                    jscriptsFunctions.Misc.Alert(Page, "A Decision  must be made for ALL items");
                    return;
                }
            }
            strRecord_id = "";
            indx = 0;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                
                foreach (DataRow dr in tbl.Rows)
                {
                    //rblst = FindControl( "rblst_" + indx.ToString()) as RadioButtonList;
                    rblst = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblst_" + indx.ToString());
                    indx++;
                    strRecord_id = rblst.ID.Replace("rblst_", "");
                    if (rblst.SelectedValue.Equals("1"))
                    {
                        if (dr["which"].ToString().Equals("a"))
                            processAddress(dr);
                        else
                            processProfile(dr);
                        ViewState["email_apprve"] = "0";
                    }
                    //else if (rblst.SelectedValue.Equals("0"))
                    //{
                    //}
                    //else
                    //{
                    //    //tx.Rollback();
                    //    //string strError = "<script>alert('You must ckeck all the dependents first')</script>";
                    //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
                    //    //return;
                    //}

                }
                Data.Close_pending_ee_profile_addrs(session_id, ViewState["EE_Number"].ToString());
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
            jscriptsFunctions.Misc.AlertSaved(Page);
            btnNext_Click(null, null);
            //Response.Redirect("Profile.aspx?SkipCheck=YES&ee=" + Request.Params["ee"], true);
        }
    }
}