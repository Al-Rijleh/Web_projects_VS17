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

namespace Dependents_Maintenance
{
    public partial class _Default : System.Web.UI.Page
    {
        int depid = 0;
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Cookies["Session_ID"].Value.ToString()))
            {
                Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Your Session has timed out", true);
                return;
            }
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if ((!SQLStatic.Web_Data.HasRole(session_id, "100103")) || (SQLStatic.Sessions.GetAccountNumber(session_id).StartsWith("0012695")))
                btnAddDependent.Attributes.Add("onclick", "showDialogAdd(-1,-1);return false;");
            else
                btnAddDependent.Visible = false;
            if (hidCommand.Value == "DM")
            {
                hidCommand.Value = "";
                string strLaunchMessage = "<script type='text/javascript'>DoshowDialog3();</script>";

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strLaunchMessage", strLaunchMessage);

            }
            if(hidCommand.Value.ToString().StartsWith("Approve-"))
            {
                string strDepo = hidCommand.Value.ToString().Replace("Approve-", "");
                hidCommand.Value = string.Empty;
                Data.ManualDenedentApproval(session_id, strDepo);
            }

            
                if (!IsPostBack)
                {
                    Data.CheckSetProcessing_Year_ee(Request.Cookies["Session_ID"].Value.ToString());
                    Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PARENTID", "1", conn);
                    ViewState["SESSION_CALLING_MODULE"] = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
        //btnAddDependent.Text = ViewState["SESSION_CALLING_MODULE"].ToString(); // ////////////////
                    //btnNextEnrollmentStep.Visible = InOpenEnrollment();
                    //dvOpenEnrollmentNote.Visible = btnNextEnrollmentStep.Visible;
                    //divBlank.Visible = !btnNextEnrollmentStep.Visible;
                    
                   //btnBackToLiveEvent.Visible = InLifeEvent();
                    //ViewState["EE_Action_Level"] = Data.EEActionLevel(Request.Cookies["Session_ID"].Value.ToString(), conn);  
                    ViewState["EE_Action_Level"] = "0"; // do not look for open enrollment
                    setAddDep();
                    conn.Close();
                    conn.Dispose();
                    //lblScript.Text = "<script language='javascript' type='text/javascript'> try { window.top.HideHederInf(); }catch (err) { }</script>";
                }
            

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
                ViewState["ReqAudit"] = Data.account_need_dep_audit(ViewState["Selected_Account_Number"].ToString());
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "SESSION_CALLING_MODULE", "N");
                lblInstucrion.Text = Data.GetText(Request.Cookies["Session_ID"].Value.ToString(), "9");
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "SESSION_CALLING_MODULE", ViewState["SESSION_CALLING_MODULE"].ToString());
                if (ViewState["Selected_Account_Number"].ToString().IndexOf("000699").Equals(-1))
                    lblInstucrion.Text ="Listed below are your dependents, if any, recorded in MyEnroll.com. Click on the Add New Dependent link below to enter data for a dependent not currently listed";
                string strEmployeeNumber = ViewState["Employee_Number"].ToString();
                if (strEmployeeNumber.Equals("0")||(string.IsNullOrEmpty(strEmployeeNumber)))
                {
                    string strGetEE = "<script>GetEE('" + Request.Path + "')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGetEE", strGetEE);
                    return;
                }
                ViewState["EE_Terminated"] = Data.IsEETerminated(strEmployeeNumber);
                if (ViewState["EE_Terminated"].ToString().Equals("1"))
                    btnAddDependent.Visible = false;
                if (btnNextEnrollmentStep.Visible)
                {
                    if (SQLStatic.AccountData.RetaAccount(ViewState["Selected_Account_Number"].ToString()))
                        btnNextEnrollmentStep.Visible = false;
                }
                if (!Data.EmployeeIsDependentEligible(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()))
                {
                    
                    dvMain.Visible = false;
                    LBL_FLD_Instruction.Visible = false;
                    dvMessage.Visible = true;
                    lblWarning.Text = lblWarning.Text.Replace("[Name]", SQLStatic.EmployeeData.EmployeeNameFirstNameFirst(ViewState["Employee_Number"].ToString()));
                    lblWarning.Text = lblWarning.Text.Replace("[Number]", ViewState["Employee_Number"].ToString());
                }
                //Bas_Utility.Utilities.SetHeaderFrame(Page, "ACCOUNT_INFO", SQLStatic.EmployeeData.EmployeeNameHeader(ViewState["Employee_Number"].ToString()));
                SetFullHeader(Page, ViewState["Employee_Number"].ToString());
                processStar();
            }
            if (!string.IsNullOrEmpty(hidShowTerm.Value))
            {
                hidShowTerm.Value = string.Empty;
                cbShowActiveOnly.Checked = false;
            }
            SQLStatic.Sessions.SetSessionValue(session_id, "HideInfo", "1");
            lblScript.Text = "<script language='javascript' type='text/javascript'> try { window.top.HideHederInf(); }catch (err) { }</script>";
            DrawGrid();
        }

        private bool Account_Require_Dep_Audit()
        {
            return ViewState["ReqAudit"].ToString().Equals("1");
        }

        //private void ShowRelationOnly()
        //{
        //    dvFirstName.Visble = false;
        //    dvMI.Visble = false;
        //    dvLastName.Visble = false;
        //    dvSSN.Visble = false;
        //    dvD.Visble = false;
        //    dvDOB.Visble = false;
        //    dvGender.Visble = false;
        //    dvStudent.Visble = false;
        //    dvDisabled.Visble = false;
        //    dvEffectiveDate.Visble = false;
        //    dvSchool.Visble = false;
        //    dvGraduation.Visble = false;
        //    dvRightPanel.Visble = false;
        //}

        private void setAddDep()
        {
            string UrserFroup = SQLStatic.Sessions.GetUserGroupID(Request.Cookies["Session_ID"].Value.ToString());
            if (UrserFroup.Equals("3"))
                //return;
            btnAddDependent.Visible = false;
            //switch (ViewState["EE_Action_Level"].ToString())
            //{
            //    case "0":
            //        btnAddDependent.Enabled = false;
            //        break;
            //    case "1":
            //        btnAddDependent.Enabled = true;
            //        break;
            //    case "2":
            //        btnAddDependent.Enabled = false;
            //        break;
            //}

        }

        public static void SetFullHeader(Page wpage, string strEmployee_number)
        {
            DataTable tbl = null;
            string eeinfo = "";
            string erinfo = "";

            try
            {
                tbl = SQLStatic.EmployeeData.EEProfile_StoredProcedure(strEmployee_number);
                if (tbl.Rows.Count > 0)
                {
                    eeinfo = "Employee:&nbsp;&nbsp;&nbsp;" + tbl.Rows[0]["Name"].ToString() + "  -  MyEnroll#: " + strEmployee_number;
                    erinfo = "Employer:&nbsp;&nbsp;&nbsp;" + tbl.Rows[0]["account_name"].ToString() + " (Acct# " + tbl.Rows[0]["account_number"].ToString() + ")";
                }
            }
            finally
            {
                if (tbl != null)
                    tbl.Dispose();
            }
            SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(), "2ndTitle", eeinfo);
            SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(), "3rdTitle", erinfo);

            string setPTemplate = "<script language='javascript'>" +
                    "window.open('/web_projects/ptemplate/header.aspx?callingurl=" + wpage.Request.Path + "','Frame_detailing_the_selected_module_and_current_program_page');</script>";
            wpage.ClientScript.RegisterStartupScript(wpage.GetType(), "setPTemplate", setPTemplate);
        }

        private bool InOpenEnrollment()
        {
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "O")
                return true;
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "A")
                return true;
            return false;
        }

        private bool InLifeEvent()
        {
            string lifeEvent = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LIFE_EVENT_CODE");

            if (lifeEvent != "")
                return true;
            return false;
        }

        //private void ApproveDependent(string strID)
        //{
        //    Data.MoveOutOfPending(strID, "", ViewState["User_Name"].ToString());
        //}

        protected void processStar()
        {
            BasStar.StarFunctionality star = new BasStar.StarFunctionality();
            try
            {
                star.ConnStr = Data.ConnectionString;
                star.SetLabel(this, ViewState["Selected_Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(),
                    Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
            }
            finally
            {
                star = null;
            }
        }


        protected void DrawGrid()
        {
            DataTable tbl = null;
            if (cbShowActiveOnly.Checked)
                tbl = Data.GetDependentsListActive(ViewState["Employee_Number"].ToString(),"0");
            else
                tbl = Data.GetDependentsList(ViewState["Employee_Number"].ToString(),"9");
            if (tbl.Rows.Count.Equals(0))
            {
                
                DataTable dt = Data.NoDep();
                gvEmpty.DataSource = dt;
                gvEmpty.DataBind();
                //int coulCount = gvDep.Columns.Count;
                //for (int i = 0; i < coulCount; i++)
                //{
                //    if (!i.Equals(1))
                //    {
                //        gvDep.Columns[i].Visible = false;
                //    }
                //}
                //foreach (DataColumn col in tbl.Columns)
                //{
                //    if 
                //}

            }
            gvDep.DataSource = tbl;
            gvDep.DataBind();

            DataTable tblPending = Data.Get_Pending_Dependents(ViewState["Employee_Number"].ToString());
            if (!tblPending.Rows.Count.Equals(0))
            {
                //lblNoPendingDependents.Visible = false;
                lblPendingDependents.Visible = true;
                gvPending.DataSource = tblPending;
                gvPending.DataBind();
            }
            else
            {
                gvPending.Visible = false;
                lblPendingDependents.Visible = false;
                //lblNoPendingDependents.Visible = false;
            }
        }

        protected void gvDep_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (SQLStatic.Web_Data.HasRole(session_id, "100103"))
                return;
            DataTable dt = null;
            if (ViewState["EE_Terminated"].ToString().Equals("1"))
            {
                if (!ViewState["User_Group_ID"].ToString().Equals("1"))
                    return;
                dt = (DataTable)gvDep.DataSource;
                if (dt == null)
                    return;

                try
                {
                    if (e.Row.RowIndex.Equals(-1))
                        return;
                    if (dt.Rows.Count < e.Row.RowIndex)
                        return;
                    string strIndex = dt.Rows[e.Row.RowIndex]["record_id"].ToString();

                    Button btn = null;
                    if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Inactive "))
                    {
                        btn = new Button();
                        if (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending")
                            btn.Attributes.Add("onclick", "showDialog(" + strIndex + ", -1);return false;");
                        else
                        {
                            if ((dt.Rows[e.Row.RowIndex]["relationship_code"].ToString().Equals("0")) || (dt.Rows[e.Row.RowIndex]["Status"].ToString().Equals("00")))
                                btn.Attributes.Add("onclick", "showDialogAddFix(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                            else
                                btn.Attributes.Add("onclick", "showDialogAdd(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                        }
                        btn.ID = "btn_" + strIndex;
                        btn.Text = "Edit";
                        btn.BackColor = System.Drawing.Color.White;
                        btn.BorderStyle = BorderStyle.None;
                        btn.ForeColor = System.Drawing.Color.Blue;
                        btn.Font.Underline = true;
                        btn.ToolTip = "Edit or Remove Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                        TableCell cell = e.Row.Cells[8];
                        cell.Controls.Add(btn);
                    }
                }

                catch { }
                return;
            }
            dt = (DataTable)gvDep.DataSource;
            if (dt == null)
                return;
            try
            {
                if (dt.Rows.Count < e.Row.RowIndex)
                    return;
                string strIndex = dt.Rows[e.Row.RowIndex]["record_id"].ToString();

                Button btn = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending")
                    || (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Inactive "))
                {
                    btn = new Button();
                    if (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending")
                        btn.Attributes.Add("onclick", "showDialog(" + strIndex + ", -1);return false;");
                    else
                    {
                        if ((dt.Rows[e.Row.RowIndex]["relationship_code"].ToString().Equals("0")) || (dt.Rows[e.Row.RowIndex]["Status"].ToString().Equals("00")))
                            btn.Attributes.Add("onclick", "showDialogAddFix(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                        else
                            btn.Attributes.Add("onclick", "showDialogAdd(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                    }
                    btn.ID = "btn_" + strIndex;
                    btn.Text = "Edit";
                    btn.BackColor = System.Drawing.Color.White;
                    btn.BorderStyle = BorderStyle.None;
                    btn.ForeColor = System.Drawing.Color.Blue;
                    btn.Font.Underline = true;
                    btn.ToolTip = "Edit or Remove Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                }
                Button btn2 = null;
                if (!SQLStatic.AccountData.RetaAccount(ViewState["Selected_Account_Number"].ToString()))
                {
                    if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending"))
                    {
                        btn2 = new Button();
                        if (ViewState["User_Group_ID"].ToString() == "3")
                            btn2.Attributes.Add("onclick", "showDialog2(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                        else
                            btn2.Attributes.Add("onclick", "showTermDep(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + Request.Path + "?SkipCheck=YES');return false;");
                        btn2.ID = "btn2_" + strIndex;
                        btn2.Text = "Remove";
                        btn2.BackColor = System.Drawing.Color.White;
                        btn2.BorderStyle = BorderStyle.None;
                        btn2.ForeColor = System.Drawing.Color.Blue;
                        btn2.Font.Underline = true;
                        btn2.ToolTip = "Edit or Remove Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                    }
                }

                
                else if (SQLStatic.AccountData.RetaAccount(ViewState["Selected_Account_Number"].ToString()) && ViewState["User_Group_ID"].ToString().Equals("1"))
                {
                    if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending"))
                    {
                        btn2 = new Button();
                        if (ViewState["User_Group_ID"].ToString() == "3")
                            btn2.Attributes.Add("onclick", "showDialog2(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                        else
                            btn2.Attributes.Add("onclick", "showTermDep(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + Request.Path + "?SkipCheck=YES');return false;");
                        btn2.ID = "btn2_" + strIndex;
                        btn2.Text = "Remove";
                        btn2.BackColor = System.Drawing.Color.White;
                        btn2.BorderStyle = BorderStyle.None;
                        btn2.ForeColor = System.Drawing.Color.Blue;
                        btn2.Font.Underline = true;
                        btn2.ToolTip = "Edit or Remove Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                    }
                }

                Button btnVerify = null;
                if ((Account_Require_Dep_Audit()) && ViewState["User_Group_ID"].ToString().Equals("1"))
                {
                    if (!dt.Rows[e.Row.RowIndex]["Verify"].ToString().Replace(" ", string.Empty).Equals("Verifed"))
                    {
                        if ((!dt.Rows[e.Row.RowIndex]["Verify"].ToString().Equals("N/A"))
                            || (!Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(),"560").Equals("1")))
                        {
                            btnVerify = new Button();
                            //if (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending")
                            //    btn.Attributes.Add("onclick", "showDialog(" + strIndex + ", -1);return false;");
                            //else
                            //{
                            //    if ((dt.Rows[e.Row.RowIndex]["relationship_code"].ToString().Equals("0")) || (dt.Rows[e.Row.RowIndex]["Status"].ToString().Equals("00")))
                            //        btn.Attributes.Add("onclick", "showDialogAddFix(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                            //    else
                            //        btn.Attributes.Add("onclick", "showDialogAdd(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                            //}
                            btnVerify.ID = "btnVerify_" + strIndex;
                            btnVerify.Text = "Verify";
                            btnVerify.BackColor = System.Drawing.Color.White;
                            btnVerify.BorderStyle = BorderStyle.None;
                            btnVerify.ForeColor = System.Drawing.Color.Blue;
                            btnVerify.Font.Underline = true;
                            btnVerify.Attributes.Add("onclick",
                                "showDialogVer(" + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString().Replace("'", string.Empty) + "');return false;");
                            btnVerify.ToolTip = "Verify Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                            if (Data.CanUseManualApproval(session_id, dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString()).Equals("0"))
                            {
                                btnVerify.ToolTip = "This dependent can’t be verified here. He/she has unprocessed coverage or document. Please use “Pending Dependent Audit” to verify this dependent.";
                                btnVerify.Enabled = false;
                            }
                            TableCell cell = e.Row.Cells[8];
                            cell.Controls.Add(btnVerify);
                        }
                    }
                }

                Button btn3 = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Pending") && (ViewState["User_Group_ID"].ToString() == "1"))
                {
                    btn3 = new Button();
                    btn3.Attributes.Add("onclick", "showDialog14(" + strIndex + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString() + "');return false;");
                    btn3.ID = "btn3_" + strIndex;
                    btn3.Text = "Approve";
                    btn3.BackColor = System.Drawing.Color.White;
                    btn3.BorderStyle = BorderStyle.None;
                    btn3.ForeColor = System.Drawing.Color.Blue;
                    btn3.Font.Underline = true;
                    btn2.ToolTip = "Approve Pending Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString().Replace("'",string.Empty);

                }

                Button btn4 = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Inactive") != -1))
                {
                    btn4 = new Button();
                    //string strvalue = "showDialog6(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString() + "') return false;";
                    string strvalue = "showDialog6( " + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString().Replace("'", "") + "')";
                    btn4.Attributes.Add("onclick", strvalue );//return false;");
                    btn4.ID = "btn4_" + strIndex;
                    btn4.Text = "Reactivate";
                    btn4.BackColor = System.Drawing.Color.White;
                    btn4.BorderStyle = BorderStyle.None;
                    btn4.ForeColor = System.Drawing.Color.Blue;
                    btn4.Font.Underline = true;
                    btn4.ToolTip = "Reactivate Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();

                }
                Button btn9 = null;
                if ((ViewState["User_Group_ID"].ToString() == "3")||(ViewState["User_Group_ID"].ToString() == "2"))
                {
                    
                    btn9 = new Button();
                    btn9.ID = "btn_" + strIndex;
                    btn9.Text = "Edit";
                    if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "317").Equals("1"))
                    {
                        btn9.Attributes.Add("onclick", "showDialogLimitedSSN(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                        btn9.Text = "Edit SSN";
                    }

                    if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "856").Equals("1"))
                    {
                        btn9.Attributes.Add("onclick", "showDialog100(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                        btn9.Text = "View";
                    }


                    else if (ViewState["Selected_Account_Number"].ToString().IndexOf("0007200").Equals(-1))
                        btn9.Attributes.Add("onclick", "showDialogLimited(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                    else
                        btn9.Attributes.Add("onclick", "showDialog(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                       
                    btn9.BackColor = System.Drawing.Color.White;
                    btn9.BorderStyle = BorderStyle.None;
                    btn9.ForeColor = System.Drawing.Color.Blue;
                    btn9.Font.Underline = true;
                    btn9.ToolTip = "Edit Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                    if (ViewState["User_Group_ID"].ToString() == "3")
                    {
                        switch (ViewState["EE_Action_Level"].ToString())
                        {
                            case "0":
                                btn = null; btn2 = null; btn3 = null; btn4 = null; //btnAddDependent.Enabled = false;
                                break;
                            case "1":
                                btn = null; btn2 = null; btn3 = null; btn4 = null; //btnAddDependent.Enabled = true;
                                break;
                            case "2":
                                btn = null; btn3 = null; btn4 = null; //btnAddDependent.Enabled = false;
                                break;
                        }
                    }

                }
                string OEType = SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE");
                //if (ViewState["User_Group_ID"].ToString() == "3")
                {
                   // if (ViewState["Selected_Account_Number"].ToString().IndexOf("0010004").Equals(-1))
                    {
                        TableCell cell = e.Row.Cells[8];
                        if (btn != null)
                        {
                            if ((!string.IsNullOrEmpty(OEType))||(!OEType.Equals("N")))
                                if (btn9 != null)
                                {
                                    if (!btn9.Text.EndsWith("SSN"))
                                        btn9 = null;
                                }
                        }
                        if (btn != null)
                            cell.Controls.Add(btn);
                        if (btn9 != null)
                            cell.Controls.Add(btn9);
                        if (btn2 != null)
                            cell.Controls.Add(btn2);
                        if (btn3 != null)
                            cell.Controls.Add(btn3);
                        if (btn4 != null)
                            cell.Controls.Add(btn4);
                    }
                }
            }
            catch
            {
            }
        }

        protected void btnNextEnrollmentStep_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/popup_checker/check.aspx?url=/Web_Projects/addupdate_benefits/Benefits.aspx?SkipCheck=YES");
        }

        protected void btnBackToLiveEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/popup_checker/check.aspx?url=/Web_Projects/addupdate_benefits/Benefits.aspx?SkipCheck=YES");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES", true);  
            
        }

        protected void gvPending_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (SQLStatic.Web_Data.HasRole(session_id, "100103"))
                return;
            DataTable dt = (DataTable)gvPending.DataSource;
            if (dt == null)
                return;
            try
            {
                if (dt.Rows.Count < e.Row.RowIndex)
                    return;
                string strIndex = dt.Rows[e.Row.RowIndex]["record_id"].ToString();

                Button btn = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || ((dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Pending").Equals(0))))
                {
                    btn = new Button();
                    btn.Width = System.Web.UI.WebControls.Unit.Pixel(70);

                    depid = new Random().Next(0, int.MaxValue);
                    string id = SQLStatic.Sessions.get_guid(session_id, "id" + depid.ToString(), strIndex);
                    string dep_id = SQLStatic.Sessions.get_guid(session_id, "dep_id" + depid.ToString(), dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString());
                    string type = depid.ToString();
                    btn.Attributes.Add("onclick", "showDialog('" + depid + "');return false;");

                    //btn.Attributes.Add("onclick", "showDialog(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                    btn.ID = "btn_" + strIndex;
                    btn.Text = "Edit";
                    btn.CausesValidation = false;
                    btn.BorderStyle = BorderStyle.None;
                    btn.ForeColor = System.Drawing.Color.Blue;
                    btn.Font.Underline = true;
                    //btn.CssClass = "fontsmall";
                    //btn.BackColor = System.Drawing.Color.FromName("#f4ede1");
                    btn.ToolTip = "Edit Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                }
                //Button btn = null;
                //if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || ((dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Pending").Equals(0))))
                //{
                //    btn = new Button();
                //    btn.Width = System.Web.UI.WebControls.Unit.Pixel(70);
                //    btn.Attributes.Add("onclick", "showDialog(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                //    btn.ID = "btn_" + strIndex;
                //    btn.Text = "Edit";
                //    btn.CausesValidation = false;
                //    btn.BorderStyle = BorderStyle.None;
                //    btn.ForeColor = System.Drawing.Color.Blue;
                //    btn.Font.Underline = true;
                //    //btn.CssClass = "fontsmall";
                //    //btn.BackColor = System.Drawing.Color.FromName("#f4ede1");
                //    btn.ToolTip = "Edit Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                //}
                Button btn2 = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Active") || ((dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Pending").Equals(0))))
                {
                    btn2 = new Button();
                    btn2.Width = System.Web.UI.WebControls.Unit.Pixel(70);
                    //if (ViewState["User_Group_ID"].ToString() == "3")
                    btn2.Attributes.Add("onclick", "showDialog2(-" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ");return false;");
                    //else
                    //    btn2.Attributes.Add("onclick", "showTermDep(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + Request.Path + "');return false;");
                    btn2.ID = "btn2_" + strIndex;
                    btn2.Text = "Remove";
                    btn2.CausesValidation = false;
                    btn2.BorderStyle = BorderStyle.None;
                    btn2.ForeColor = System.Drawing.Color.Blue;
                    btn2.Font.Underline = true;
                    //btn2.CssClass = "fontsmall";
                   btn2.BackColor = System.Drawing.Color.FromName("#f4ede1");
                    btn2.ToolTip = "Remove Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                }

                Button btn3 = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Pending").Equals(0)) && (ViewState["User_Group_ID"].ToString() != "3") )
                {
                    btn3 = new Button();
                    btn3.Width = System.Web.UI.WebControls.Unit.Pixel(70);
                    
                    btn3.ID = "btn3_" + strIndex;
                    if (dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Term.").Equals(-1))
                    {
                        if (!SQLStatic.AccountData.RetaAccount(ViewState["Selected_Account_Number"].ToString()))
                        {
                            btn3.Text = "Approve";
                            btn3.Attributes.Add("onclick", "showDialog14(" + strIndex + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString() + "');return false;");
                            btn3.ToolTip = "Approve Pending Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                        }
                    }
                    else
                    {
                        btn3.Text = "Terminate";
                        btn3.Attributes.Add("onclick", "showDialog24(" + strIndex + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString() + "');return false;");
                        btn3.ToolTip = "Terminate Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();
                    }
                    
                    btn3.BackColor = System.Drawing.Color.White;
                    btn3.BorderStyle = BorderStyle.None;
                    btn3.ForeColor = System.Drawing.Color.Blue;
                    btn3.Font.Underline = true;
                    btn3.BackColor = System.Drawing.Color.FromName("#f4ede1");

                }

                Button btn4 = null;
                if ((dt.Rows[e.Row.RowIndex]["Status"].ToString().IndexOf("Inactive") != -1))
                {
                    btn4 = new Button();
                    btn4.Width = System.Web.UI.WebControls.Unit.Pixel(70);
                    btn4.Attributes.Add("onclick", "showDialog6(" + strIndex + "," + dt.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString() + ",'" + dt.Rows[e.Row.RowIndex]["FullName"].ToString() + "');return false;");
                    btn4.ID = "btn4_" + strIndex;
                    btn4.Text = "Reactivate";
                    btn4.BackColor = System.Drawing.Color.White;
                    btn4.BorderStyle = BorderStyle.None;
                    btn4.ForeColor = System.Drawing.Color.Blue;
                    btn4.Font.Underline = true;
                    btn4.ToolTip = "Reactivate Dependent " + dt.Rows[e.Row.RowIndex]["FullName"].ToString();

                }
                Button btn9 = null;
                TableCell cell = e.Row.Cells[7];
                if (btn != null)
                    btn9 = null;
                if (btn != null)
                    cell.Controls.Add(btn);
                if (btn9 != null)
                    cell.Controls.Add(btn9);
                if (btn2 != null)
                    cell.Controls.Add(btn2);
                if (btn3 != null)
                    cell.Controls.Add(btn3);
                if (btn4 != null)
                    cell.Controls.Add(btn4);
            }
            catch
            {
            }
        }

        protected void gvEmpty_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex<0)
            {
                string strPad = "";
                for (int i = 0; i <= 18; i++)
                    strPad += "&nbsp;";
                Label lbl = new Label();
                lbl.ID = "lbl1";                
                lbl.Text = "Full Name" + strPad + "Relation" + strPad + "DOB" + strPad + "Gender" + strPad + "Status" + strPad + "Termination Date";
                TableCell cell = e.Row.Cells[0];
                cell.Controls.Add(lbl);
                return;
            }
            Label lblf = new Label();
            lblf.ID = "lblf1";
            lblf.Text = "<div style='font-size: 10pt; color: red'> There are no active dependents recorded in the system</div>";
            TableCell cellf = e.Row.Cells[0];
            cellf.Controls.Add(lblf);
        }
    }
}
