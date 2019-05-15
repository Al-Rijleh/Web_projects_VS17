using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Collections;

namespace Dependents_Maintenance
{
    public partial class RemoveDep1 : System.Web.UI.Page
    {
        string session_id = string.Empty;
         
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
                ViewState["id"] = SQLStatic.Sessions.GetSessionValue(session_id, "dep_record_id");
                ViewState["dep_id"] = SQLStatic.Sessions.GetSessionValue(session_id, "DepNo");
                string strInOE = SQLStatic.Sessions.GetSessionValue(session_id, "ininOE");                
                dvTermCov.Visible = false;
                dvReson.Visible = false;
                dvTermDep.Visible = false;
                dvWillClose.Visible = false;
                dvTopVutton.Visible = false;
                dvcheckBox.Visible = false;
                SetupPageText();
                ViewState["Is_COBRA"] = Data.Has_COBRA(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());         
                ViewState["SESSION_CALLING_MODULE"] = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
                rblTermDep_SelectedIndexChanged(null, null);
                CheckOpener();
                ViewState["TermDep"] = "";
            }
            if (InOpenEnrollment())
                FillReason();
            if (!string.IsNullOrEmpty(Request.Params["hidTerm"]))
            {
                ViewState["TermDep"] = Request.Params["hidTerm"];
                DoSaveCvrgs();
                return;
            }
            
            if (!string.IsNullOrEmpty(Request.Params["recid"]))
            {
                if (!Request.Params["recid"].Equals("0"))
                    Data.terminate_dep_cvrg_from_web(Request.Params["recid"], txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString(), null);                
            }
        }

        private void CheckOpener()
        {
            if (Data.DepCoverageCount( ViewState["dep_id"].ToString(),ViewState["Processing_Year"].ToString()).Equals("0"))
                dvStep1.Visible = true;
            else
            { 
                dvStep1.Visible = false;                
            }
            dvReson.Visible = !dvStep1.Visible;
        }

        private void SetupPageText()
        {
            DataTable tbl = Data.GetDependentsInfoFromID(ViewState["id"].ToString(),ViewState["dep_id"].ToString());

            string depDetail = "<span class='fontweight'>"+tbl.Rows[0]["fullname"].ToString() + " (" +
                                             tbl.Rows[0]["relation_name"].ToString() + ", DOB: " +
                                             tbl.Rows[0]["birth_date"].ToString()+")</span> " ;
            string Name = "<span class='fontweight'>" + tbl.Rows[0]["fullname"].ToString() + "</span> ";
            lblDepRemoveCoverage.Text = lblDepRemoveCoverage.Text.Replace("[detail2]", tbl.Rows[0]["fullname"].ToString()) + " <span class='fontweight'> will be removed from these coverage</span>";
            lblCanKeepCoverage2.Text = lblCanKeepCoverage2.Text.Replace("[detail2]", tbl.Rows[0]["fullname"].ToString());
            lblTermDep.Text = lblTermDep.Text.Replace("[detail2]", tbl.Rows[0]["fullname"].ToString());
            lblDependentTerinate.Text = lblDependentTerinate.Text.Replace("[detail]",depDetail) + " <span class='fontweight'> will be terminated</span>";
            lblConfirmDepTerm.Text = lblConfirmDepTerm.Text.Replace("{name}", tbl.Rows[0]["fullname"].ToString());
            lblNoCoverage.Text = lblNoCoverage.Text.Replace("{name}", Name);
            lblTitle.Text = lblTitle.Text.Replace("[detail]", depDetail);
            ViewState["depName"] = tbl.Rows[0]["fullname"].ToString();
        }

        private void DrowGrids()
        {
            DataTable tbl = Data.Dependents_cvrg_will_remove(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString(),
                ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                dvWillClose.Visible = false;
            }
            else
            {
                dvWillClose.Visible = false;
                lblCanKeepCoverage2.Text = lblCanKeepCoverage2.Text.Replace("still", "NOT");
                //rgTem.DataSource = tbl;
                //rgTem.DataBind();
            }

            DataTable tbl2 = Data.Dependents_cvrg_will_Keep(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString(),
                ViewState["Processing_Year"].ToString());
            if (tbl2.Rows.Count.Equals(0))
            {
                dvCouldTemCov.Visible = false;
                return;
            }
            else
            {
                rdKeep.DataSource = tbl2;
                rdKeep.DataBind();
            }
        }

        protected void rgTem_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable tbl =Data.Dependents_cvrg_will_remove(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString(),
                ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                dvWillClose.Visible = false;
                return;
            }
            dvWillClose.Visible = false;
            lblCanKeepCoverage2.Text = lblCanKeepCoverage2.Text.Replace("still", "NOT");
            //rgTem.DataSource = tbl;
        }

        protected void rdKeep_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable tbl = Data.Dependents_cvrg_will_Keep(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString(),
                ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                dvCouldTemCov.Visible = false;
                return;
            }
            rdKeep.DataSource = Data.Dependents_cvrg_will_Keep(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString(),
                ViewState["Processing_Year"].ToString());
            DataTable tblremove= Data.Dependents_cvrg_will_remove(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString(),
               ViewState["Processing_Year"].ToString());
            if (!tblremove.Rows.Count.Equals(0))
            {
                dvWillClose.Visible = false;
                lblCanKeepCoverage2.Text = lblCanKeepCoverage2.Text.Replace("still", "NOT");
            }

        }

        private bool InOpenEnrollment()
        {
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "O")
                return true;
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "A")
                return true;
            if (!string.IsNullOrEmpty(Request.Params["sessom"]))
                return true;
            return false;
        }

        private void FillReason()
        {
            ddlReason.Items.Clear();
            if (InOpenEnrollment())
            {
                ListItem lio = new ListItem("Open Enrollment", "1000");
                lio.Selected = true;
                ddlReason.Items.Add(lio);
                ddlReason.AutoPostBack = true;
                ddlReason.Enabled = false;
                txtTerminationDate.Text = Data.LastDayInCurrentYear(ViewState["Selected_Account_Number"].ToString());
                txtTerminationDate.Enabled = false;
                ddlReason_SelectedIndexChanged(null, null);
                //lblOpenEnrollmentNote.Visible = true;
                //lblInstruction.Visible = false;
            }

            string current_action = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
            if (current_action.Equals("L"))
            {
                txtTerminationDate.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LIFE_EVENT_DATE");
                txtTerminationDate.Enabled = false;
                //lblInstruction.Visible = false;
            }
            DataTable tbl = Data.GetTermReason(Request.Cookies["Session_ID"].Value.ToString());
            string strDescription;
            foreach (DataRow dr in tbl.Rows)
            {
                strDescription = dr["description"].ToString();
                if (ViewState["Is_COBRA"].ToString() == "T")
                {
                    if (dr["generate_cobra"].ToString() == "T")
                        strDescription = strDescription + " (COBRA)";
                }
                ListItem li = new ListItem(strDescription, dr["record_id"].ToString());
                ddlReason.Items.Add(li);
            }
            tbl.Dispose();

        }


        protected void rblTermDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dvReson.Visible = rblTermDep.SelectedValue.Equals("0"))
            {
                dvReson.Visible = false;
                dvTermCov.Visible = false;
                return;
            }
            if (!ViewState["User_Group_ID"].ToString().Equals("3"))
            {
                FillReason();
                dvReson.Visible = rblTermDep.SelectedValue.Equals("1");
            }
            else
                dvTermCov.Visible = true;
        }

        protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvTermCov.Visible = true;
            //DrowGrids();
        }

        private void SaveCoverage(Oracle.DataAccess.Client.OracleConnection conn)
        {
            foreach (GridDataItem item in rgTem.MasterTableView.Items)
            {
                CheckBox chkb = (CheckBox)item["TemplateColumn"].FindControl("chkWillRemove");
                if (chkb != null)
                {
                    try
                    {
                        if (chkb.Checked)
                        {
                            string recotd_id = item.GetDataKeyValue("record_id").ToString();
                            Data.terminate_dep_cvrg_from_web(recotd_id, txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString(), conn);
                        }                        
                    }
                    catch
                    {
                        throw;
                    }                    
                }
            }
        }

        private void SaveCoverageKeep(Oracle.DataAccess.Client.OracleConnection conn)
        {
            foreach (GridDataItem item in rdKeep.MasterTableView.Items)
            {
                CheckBox chkb = (CheckBox)item["TemplateColumn2"].FindControl("chkWillRemove2");
                if (chkb != null)
                {
                    try
                    {
                        if (!chkb.Checked)
                        {
                            string recotd_id = item.GetDataKeyValue("record_id").ToString();
                            Data.terminate_dep_cvrg_from_web(recotd_id, txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString(),conn);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblScript.Text = "<script>checkTermDep('" + ViewState["depName"].ToString() + "')</script>";
            return;
            int cnt = 0;
            ArrayList al = new ArrayList();
            foreach (GridDataItem item in rdKeep.MasterTableView.Items)
            {
                CheckBox chkb = (CheckBox)item["TemplateColumn2"].FindControl("chkWillRemove2");
                if (chkb != null)
                {
                    try
                    {
                        if (chkb.Checked)
                        {
                            cnt++;
                        }
                        else
                        {
                            string recotd_id = item.GetDataKeyValue("record_id").ToString();
                            al.Add(recotd_id);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            if (cnt.Equals(0))
                lblScript.Text = "<script>checkTermDep('" + ViewState["depName"].ToString() + "')</script>";
            else
            {
                if (!al.Count.Equals(0))
                {
                    string coverageNamr = Data.GetCoverageNamefromid(al[0].ToString());                    
                    lblScript.Text = "<script>checkTermcvr('" + ViewState["depName"].ToString() + "','" + coverageNamr + "','" + al[0].ToString() + "')</script>";
                  ViewState["remCoverage"] = cnt.ToString();
                  //DoSaveCvrgs();
                }
            }

        }


        protected void DoSaveCvrgs()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {

                SaveCoverage(conn);
                SaveCoverageKeep(conn);
                if (rblTermdependent.SelectedValue.Equals("1"))
                    //if (ViewState["remCoverage"].ToString().Equals("0"))
                    if  (!string.IsNullOrEmpty(ViewState["TermDep"].ToString()))
                        if (ViewState["TermDep"].ToString().Equals("yes"))
                        DoSave(conn);
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }


            {
                if (!string.IsNullOrEmpty(Request.Params["sessom"]))
                    lblScript.Text = "<script>closeWindowcloseWindowOE(1)</script>";
                else
                    lblScript.Text = "<script>closeWindow</script>";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["sessom"]))
                lblScript.Text = "<script>closeWindowcloseWindowOE(1)</script>";
            else
                lblScript.Text = "<script>closeWindow(1)</script>";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            btnCancel_Click(null, null);
            
        }
        private string stripDate(string str)
        {
            str = str.Replace("_", "");
            if (str == "//")
                str = "";
            return str;
        }

        private void DoSave(Oracle.DataAccess.Client.OracleConnection conn )
        {
            if (ViewState["dep_id"].ToString() != "-1")
            {
                string current_action = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
                if (current_action.Equals("L"))
                    Data.Pend_Terminate_Dependent(Request.Cookies["Session_ID"].Value.ToString(), ViewState["id"].ToString(), txtTerminationDate.Text, ddlReason.SelectedValue);
                else
                    Data.Terminate_Dependent(ViewState["id"].ToString(), txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString(),conn);
            }
            else
                Data.Terminate_Request_Dependent(ViewState["id"].ToString().Replace("-", ""), ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), txtTerminationDate.Text, ddlReason.SelectedValue, ViewState["User_Name"].ToString());
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            txtTerminationDate.Text = stripDate(txtTerminationDate.Text);
            Validate();
            if (!IsValid)
                return;
            DoSave(null);
            string strCallCloseWindow = "<script>closeWindow(1)</script>";
            string strSession = Request.Cookies["Session_ID"].Value.ToString();
            if ((ViewState["Is_COBRA"].ToString() == "T") && (ddlReason.SelectedItem.Text.IndexOf("COBRA") != -1) && (ViewState["dep_id"].ToString() != "-1"))
            {
                strCallCloseWindow = "<script>closeWindow(10)</script>";
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                SQLStatic.Sessions.SetSessionValue(strSession, "TYPE", "QELD_2");
                SQLStatic.Sessions.SetSessionValue(strSession, "GO_URL", "/web_projects/Dependents_Maintenance/Default.aspx?SkipCheck=YES");
                SQLStatic.Sessions.SetSessionValue(strSession, "ACCOUNT_NUMBER", ViewState["Account_Number"].ToString());
                SQLStatic.Sessions.SetSessionValue(strSession, "EMPLOYEE_NUMBER", ViewState["Employee_Number"].ToString());
                SQLStatic.Sessions.SetSessionValue(strSession, "DEPENDENT_NUMBER", ViewState["dep_id"].ToString());
                conn.Close();
                conn.Dispose();
            }
            btnCancel_Click(null, null);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        protected void RadGrid1_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            btnSave_Click(null, null);
        }

      

    }

}