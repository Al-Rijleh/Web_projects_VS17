using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EnrollmentApproval
{
    public partial class Dependents : System.Web.UI.Page
    {
        string session_id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
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
            session_id = Request.Cookies["Session_ID"].Value.ToString();

            if (!IsPostBack)
            {
                if (Data.requires_dep_verify(Request.Params["ee"]).Equals("1"))
                {
                    SQLStatic.Sessions.SetSessionValue(session_id, "EMPLOYEE_NUMBER", Request.Params["ee"]);
                    SQLStatic.Sessions.SetSessionValue(session_id, "ACCOUNT_NUMBER", SQLStatic.EmployeeData.Account_Number(Request.Params["ee"]));
                    if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                        Response.Redirect("/WEB_PROJECTS/DEPENDENT_AUDIT_WIZARD_APPROVAL/APPROVE.ASPX?SkipCheck=YES&type=2&EE="
                            + ViewState["Employee_Number"].ToString() + "&Verify=" + Request.Params["Verify"]);
                    else
                        Response.Redirect("/WEB_PROJECTS/DEPENDENT_AUDIT_WIZARD_APPROVAL/APPROVE.ASPX?SkipCheck=YES&type=2&EE=" + ViewState["Employee_Number"].ToString());
                }
            }
            
            if (!string.IsNullOrEmpty(Request.Params["ee"]))
            {
                if(!Data.HasMorePendingDep(Request.Params["ee"]))
                    Response.Redirect("default.aspx?SkipCheck=YES", true);
            }
            if (!IsPostBack)
            {
                Bulid_EEList();
                if (rblstEmployees.Items.Count.Equals(0))
                {
                    if (!string.IsNullOrEmpty(Request.Params["ee"]))
                    {
                        lblNoPending.Visible = true;
                        jscriptsFunctions.Misc.Alert(Page, SQLStatic.EmployeeData.Account_Number(Request.Params["ee"]) + " Prcessed");
                    }
                    else
                    {
                        try
                        {
                            jscriptsFunctions.Misc.Alert(Page, SQLStatic.EmployeeData.Account_Number(rblstEmployees.SelectedValue) + " Prcessed");
                        }
                        catch
                        {
                            jscriptsFunctions.Misc.Alert(Page, " Prcessed");
                        }
                    }
                    btnBack_Click(null, null);

                    //dveelist.Visible = false;
                    //dvGrid.Style.Add("float", "left");
                    //dvButtons.Visible = false;
                    //btnBack.Visible = true;
                    ////btnNext.Visible = true;
                    ////btnNext.Enabled = true;
                    //btnSave.Visible = false;
                    //lblNoPending.Visible = true;
                    //lblNodep.Visible = false;
                    return;
                }
                if (!string.IsNullOrEmpty(Request.Params["ee"]))
                {
                    dveelist.Visible = false;
                    dvGrid.Style.Add("float", "left");                   
                    btnBack.Visible = true;
                    //btnNext.Visible = true;
                    rblstEmployees.Items.FindByValue(Request.Params["ee"]).Selected = true;                  
                }
                else
                {
                    btnBack.Visible = false;
                    //btnNext.Visible = false;
                }
                
                ViewState["email_apprve"] = 1;
                ViewState["email_descline"] = 1;                
            }
            if (rblstEmployees.Items.Count.Equals(0))
            {
                if (string.IsNullOrEmpty(Request.Params["ee"]))
                    Response.Redirect("/WEB_PROJECTS/ADMIPOINT/DEFAULT.ASPX", true);
                return;
            }
            if (SQLStatic.AccountData.RetaAccount(SQLStatic.EmployeeData.Account_Number(rblstEmployees.SelectedValue)))
            {
                dvButtons.Visible = false;
                ViewState["email_descline"] = 0;
                ViewState["email_apprve"] = 0;
            }
            DrawGrid();
            try
            {
                lblName.Text = rblstEmployees.SelectedItem.Text + " Bas# " + rblstEmployees.SelectedValue + "<br />" + Generate_Account_Name(rblstEmployees.SelectedValue);
            }
            catch
            {
                lblName.Text = "";
            }

        }
        

        private string Generate_Account_Name(string employee_number)
        {
            string strAccountNumber = SQLStatic.EmployeeData.Account_Number(employee_number);
            return SQLStatic.AccountData.AccountName(strAccountNumber)
                +" ("+strAccountNumber+")";
        }

        private void Bulid_EEList()
        {
            rblstEmployees.Items.Clear();
            DataTable tbl = Data.Get_Pending_Dep_list(session_id);
            if (!string.IsNullOrEmpty(Request.Params["ee"]))
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!dr["employee_number"].ToString().Equals(Request.Params["ee"]))
                        dr.Delete();
                }
                tbl.AcceptChanges();
            }
            if (tbl.Rows.Count.Equals(0))
            {
                lblNodep.Visible = true;
                //lblName.Text = rblstEmployees.SelectedItem.Text + " Bas# " + Request.Params["ee"] + "<br />" + Generate_Account_Name(Request.Params["ee"]);
                lblName.Text = SQLStatic.EmployeeData.employee_name_(Request.Params["ee"])+" Bas# " + Request.Params["ee"] + "<br /> " + Generate_Account_Name(Request.Params["ee"]);
               //dvMain.Visible = false;
                return;
            }
            
            rblstEmployees.DataSource = tbl;
            rblstEmployees.DataTextField = "Name";
            rblstEmployees.DataValueField = "employee_number";
            rblstEmployees.DataBind();
            foreach (ListItem li in rblstEmployees.Items)
                li.Text = li.Value + " - " + li.Text;
            
            if (rblstEmployees.Items.Count > 0)
            {
                rblstEmployees.SelectedIndex = 0;
                Get_email();
            }
            else
            {
                lblNoPending.Visible = true;
                btnSave.Visible = false;
            }
            //lblName.Text = rblstEmployees.SelectedItem.Text + " Bas# " + rblstEmployees.SelectedValue;
            lblName.Text = rblstEmployees.SelectedItem.Text + " Bas# " + rblstEmployees.SelectedValue + "<br />" + Generate_Account_Name(rblstEmployees.SelectedValue);
            
            txtEmailAddress.Text = Data.employee_email(rblstEmployees.SelectedValue);
            txtSubject.Text = "";
            txtMassage.Text = "";
            SQLStatic.Sessions.SetSessionValue(session_id, "Approve_Subject", "");
            SQLStatic.Sessions.SetSessionValue(session_id, "Disapprove_Subject", "");
        }

        protected void rblstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblName.Text = rblstEmployees.SelectedItem.Text + " Bas# " + rblstEmployees.SelectedValue;
            lblName.Text = rblstEmployees.SelectedItem.Text + " Bas# " + rblstEmployees.SelectedValue + "<br />" + Generate_Account_Name(rblstEmployees.SelectedValue);          
            dvButtons.Visible = !SQLStatic.AccountData.RetaAccount(SQLStatic.EmployeeData.Account_Number(rblstEmployees.SelectedValue));
            if (dvButtons.Visible)
                ViewState["email_descline"] = 1;
            else
                ViewState["email_descline"] = 0;
            ViewState["email_apprve"] = ViewState["email_descline"];
            txtEmailAddress.Text = Data.employee_email(rblstEmployees.SelectedValue);
            txtEmailAddress.Text = Data.employee_email(rblstEmployees.SelectedValue);
            DrawGrid();
            Get_email();
        }

        private void DrawGrid()
        {
            DataTable tbl = Data.GetPendingDependents(session_id, rblstEmployees.SelectedValue);
            gvCvrg.DataSource = tbl;
            gvCvrg.DataBind();
            btnSave.Visible = !tbl.Rows.Count.Equals(0);
           // btnNext.Enabled = tbl.Rows.Count.Equals(0);
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

        protected void gvCvrg_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvCvrg.DataSource;
            if (dt == null)
                return;
            int intRowIndex = e.Row.RowIndex;
            if ((intRowIndex < 0) || (intRowIndex >= dt.Rows.Count))
                return;
            string strIndex = dt.Rows[intRowIndex]["Record_id"].ToString();


            RadioButtonList rblst = new RadioButtonList();
            rblst.ID = "rblst_" + strIndex;
            rblst.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
            rblst.AutoPostBack = false;
            //rblst.SelectedIndexChanged += new System.EventHandler(this.rblst_SelectedIndexChanged);
            Fill(rblst, "0", "1");
            TableCell cell_req = e.Row.Cells[4];
            cell_req.Controls.Add(rblst);
        }

        private void Get_email()
        {
            DataTable dt = Data.GetDepedenApprovalEmail(SQLStatic.EmployeeData.Account_Number(rblstEmployees.SelectedValue));
            if (dt.Rows.Count.Equals(0))
            {
                ViewState["decline_suject"] = "";
                ViewState["decline_text"] = "";
                ViewState["Approve_subject"] = "";
                ViewState["Approve_text"] = "";
            }
            else
            {
                ViewState["decline_suject"] = dt.Rows[1]["subject"].ToString();
                ViewState["decline_text"] = dt.Rows[1]["memo"].ToString();
                ViewState["Approve_subject"] = dt.Rows[0]["subject"].ToString();
                ViewState["Approve_text"] = dt.Rows[0]["memo"].ToString();
            }
            ViewState["Default_Emal"] = Data.employee_email(rblstEmployees.SelectedValue);
            if (!string.IsNullOrEmpty(SQLStatic.Sessions.GetSessionValue(session_id, "Approve_Subject")))
            {
                ViewState["Approve_subject"] = SQLStatic.Sessions.GetSessionValue(session_id, "Approve_Subject");
                ViewState["Approve_text"] = SQLStatic.Sessions.GetCLOBSessionValue(session_id, "Approve");
                ViewState["Approve_Email"] = SQLStatic.Sessions.GetSessionValue(session_id, "Approve_Email");
            }
            if (!string.IsNullOrEmpty(SQLStatic.Sessions.GetSessionValue(session_id, "Disapprove_Subject")))
            {
                ViewState["decline_suject"] = SQLStatic.Sessions.GetSessionValue(session_id, "Disapprove_Subject");
                ViewState["decline_text"] = SQLStatic.Sessions.GetCLOBSessionValue(session_id, "Disapprove");
                ViewState["Disapprove_Email"] = SQLStatic.Sessions.GetSessionValue(session_id, "Disapprove_Email");
            }
        }

        protected void rblst_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl = (RadioButtonList)sender;
            if (rbl.SelectedValue.Equals("0"))
            {
                txtSubject.Text = ViewState["decline_suject"].ToString();
                txtMassage.Text = ViewState["decline_text"].ToString();
            }
            else
            {
                txtSubject.Text = ViewState["Approve_subject"].ToString();
                txtMassage.Text = ViewState["Approve_text"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = gvCvrg.DataSource as DataTable;
            if (tbl == null)
                tbl = Data.GetPendingDependents(session_id, rblstEmployees.SelectedValue);
            RadioButtonList rblst = null;
            string strRecord_id = "";
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {


                foreach (DataRow dr in tbl.Rows)
                {
                    //rblst =  FindControl ("rblst_" + dr["Record_id"].ToString()) as RadioButtonList;
                    rblst =  Bas_Utility.Utilities.GetRadioButtonList(Page, "rblst_" + dr["Record_id"].ToString());
                    strRecord_id = rblst.ID.Replace("rblst_", "");
                    if (rblst.SelectedValue.Equals("1"))
                    {
                        Data.MoveOutOfPending(session_id, strRecord_id, ViewState["User_Name"].ToString(), ViewState["email_apprve"].ToString());
                        ViewState["email_apprve"] = "0";
                    }
                    else if (rblst.SelectedValue.Equals("0"))
                    {
                        Data.Deney_pending_Dep(session_id, strRecord_id, ViewState["User_Name"].ToString(), ViewState["email_descline"].ToString());
                        ViewState["email_descline"] = "0";
                    }
                    else
                    {
                        //tx.Rollback();
                        //string strError = "<script>alert('You must ckeck all the dependents first')</script>";
                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
                        //return;
                    }

                }
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
            if (!string.IsNullOrEmpty(Request.Params["ee"]))
            {
                if (!Data.HasMorePendingDep(Request.Params["ee"]))
                    Response.Redirect("default.aspx?SkipCheck=YES", true);
            }
            if (!string.IsNullOrEmpty(Request.Params["ee"]))
            {
                DrawGrid();
                if (!btnSave.Visible)
                {
                    //btnNext.Enabled = true;
                    lblNoPending.Visible = true;
                    gvCvrg.Visible = false;
                    return;
                }
            }
            Bulid_EEList();
            if (rblstEmployees.Items.Count.Equals(0))
                Response.Redirect("Dependents.aspx?SkipCheck=YES&ee=" + Request.Params["ee"], true);
            DrawGrid();
        }

        protected void btnShowApprove_Click(object sender, EventArgs e)
        {
            dvSendEmail.Visible = true;
            txtSubject.Text = ViewState["Approve_subject"].ToString();
            txtMassage.Text = ViewState["Approve_text"].ToString();
            if (ViewState["Approve_Email"] != null)
                txtEmailAddress.Text = ViewState["Approve_Email"].ToString();
            ViewState["Edit"] = "Approve";
        }

        protected void btnShowDecline_Click(object sender, EventArgs e)
        {
            dvSendEmail.Visible = true;
            txtSubject.Text = ViewState["decline_suject"].ToString();
            txtMassage.Text = ViewState["decline_text"].ToString();
            if (ViewState["Disapprove_Email"] != null)
                txtEmailAddress.Text = ViewState["Disapprove_Email"].ToString();
            ViewState["Edit"] = "Disapprove";
        }

        protected void btnEditEmail_Click(object sender, EventArgs e)
        {
            dvEditMail.Visible = true;
            dvMain.Visible = false;
            lblEditEmailTitle.Text = "Edit Subject and Memo for the " + ViewState["Edit"].ToString() + " email";
            txtEditSubject.Text = txtSubject.Text;
            txtEditMessage.Content = txtMassage.Text;
            txtEditEmail.Text = txtEmailAddress.Text;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            dvEditMail.Visible = false;
            dvMain.Visible = true;
        }

        protected void btnSaveEmail_Click(object sender, EventArgs e)
        {

            SQLStatic.Sessions.SetSessionValue(session_id, ViewState["Edit"].ToString() + "_Email", txtEditEmail.Text);
            SQLStatic.Sessions.SetSessionValue(session_id, ViewState["Edit"].ToString() + "_Subject", txtEditSubject.Text);
            SQLStatic.Sessions.SetCLOBSessionValue(session_id, ViewState["Edit"].ToString(), txtEditMessage.Content);
            dvSendEmail.Visible = false;
            Get_email();
            btnCancel_Click(null, null);
        }

        protected void btnRest_Click(object sender, EventArgs e)
        {
            txtEditSubject.Text = "";
            btnSaveEmail_Click(null, null);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx?SkipCheck=YES", true);         
        }

       
    }
}