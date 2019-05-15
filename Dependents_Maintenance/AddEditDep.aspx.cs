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
using System.IO;
using Telerik.Web.UI;

namespace Dependents_Maintenance
{
    public partial class AddEditDep : System.Web.UI.Page
    {
        string session_id = "";
        string strCallCloseWindow = "";
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

                if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "856").Equals("1"))
                {
                    if (ViewState["User_Group_ID"].ToString().Equals("3"))
                    {
                        Panel1.Enabled = false;
                        htmbtnSave.Visible = false;
                        Button1.Value = "Return";
                    }
                }

                if (!string.IsNullOrEmpty(Request.Params["sessom"]))
                {                    
                    ViewState["id"] =  SQLStatic.Sessions.GetSessionValue(session_id, "dep_record_id");
                    ViewState["dep_id"] = SQLStatic.Sessions.GetSessionValue(session_id, "DepNo");
                    string  strInOE = SQLStatic.Sessions.GetSessionValue(session_id, "ininOE");
                    htmbtnInOE.Visible = false;
                    Button1.Visible = false;
                    if (!string.IsNullOrEmpty(strInOE))
                    {
                        ViewState["ininOE"] = strInOE;
                        if (ViewState["ininOE"].ToString().Equals("1"))
                            htmbtnInOE.Visible = true;
                        else
                            htmbtnInOE.Visible = false;
                        Button1.Visible = !htmbtnInOE.Visible;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Request.Params["sessom"]))
                            htmbtnInOE.Visible = true;
                        Button1.Visible = !htmbtnInOE.Visible;
                    }
                }
                else
                {
                    ViewState["id"] = Request.Params["id"];
                    ViewState["dep_id"] = Request.Params["dep_id"];
                    Button1.Visible = true;
                    htmbtnInOE.Visible = false;
                }

                //ddlStudent.Enabled = Data.Get_other(ViewState["Selected_Account_Number"] .ToString(),"321","0").Equals("0");
                //lblReqStudent.Visible = ddlStudent.Enabled;
                txtDOB.MaxDate = DateTime.Today;
                RangeValidator1.MaximumValue = DateTime.Today.ToShortDateString();
                //if (!string.IsNullOrEmpty(Request.Params["ret"]))
                //{
                //    Button1.Visible=false;
                //    btnCancel.Visible = true;
                //}
                //else
                //{
                //    Button1.Visible=true;
                //    btnCancel.Visible = false;
                //}

                txtHomePhone.Text = string.Empty; //  "0000000000";
                ViewState["SESSION_CALLING_MODULE"] = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());

                if (ViewState["id"].ToString() != "-1")
                {
                    string strID = ViewState["id"].ToString();
                    if (ViewState["dep_id"].ToString() == "-1")
                        strID = "-" + strID;
                    SQLStatic.Sessions.SetSessionValue(session_id,"strID",strID);
                    try
                    {
                        ViewState["Dependent_Name"] = SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.get_dependent_name(" + strID + ") from dual").ToString();
                    }
                    catch { }
                    
                    ViewState["SESSION_CALLING_MODULE"] = Data.Current_Action(Request.Cookies["Session_ID"].Value.ToString());
                    if (InOpenEnrollment())
                        dvOpenEnrollNote.Visible = false;
                }
                ViewState["EE_Has_Dep"] = SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.employee_has_dependents(" + ViewState["Employee_Number"].ToString() + ") from dual").ToString();
                ViewState["Show_Declaration"] = Data.Show_Declara_Form_Send_Processess(ViewState["Employee_Number"].ToString());
                
                GetSpouseInfo();                
                FillRelationTable();
                FillYears();
                FillState();
                //Bas_Utility.Utilities.SetValidatorsNoLink(Page);
                string strEffectiveDate =string.Empty;
                if (ViewState["id"].ToString() == "-1")
                {
                    lblTitle.Text = "Add a New Dependent";
                    ViewState["ddlRelation"] = "";
                    //txtEffDate.Text = "01/01/2009";
                    try
                    {
                        //txtEffDate.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LIFE_EVENT_DATE");
                        strEffectiveDate = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LIFE_EVENT_DATE");
                        if (!string.IsNullOrEmpty(strEffectiveDate))
                            txtEffDate.SelectedDate = Convert.ToDateTime(strEffectiveDate);
                    }
                    catch
                    {
                    }
                    //if (txtEffDate.Text == "")
                    //{                        
                    //    txtEffDate.Text = "01/01/2009";
                    //}
                    if (txtEffDate.Text == "")
                    {
                        if (Data.Current_Action2(Request.Cookies["Session_ID"].Value.ToString()) == "O")
                            strEffectiveDate = Data.BeginOfNextYear(ViewState["Selected_Account_Number"].ToString());
                        else
                            //strEffectiveDate = string.Empty;
                            strEffectiveDate = Data.Class_Effective_Date(Request.Cookies["Session_ID"].Value.ToString());
                    }
                    if (ViewState["User_Group_ID"].Equals("3")) 
                        divEffectiveDate.Visible = false;
                    try
                    {
                        if (!string.IsNullOrEmpty(strEffectiveDate))
                            txtEffDate.SelectedDate = Convert.ToDateTime(strEffectiveDate);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    lblTitle.Text = "Edit Dependent";
                    SetExistingFields();
                    SetDependentAddress();
                }
                txtEffDate.Enabled = ViewState["User_Group_ID"].ToString() != "3";
                ddlRelation_SelectedIndexChanged(null, null);
                ddlStudent_SelectedIndexChanged(null, null);
                if (SQLStatic.Web_Data.ViewOnly(session_id))
                    btnSave.Enabled = false;
            }
            ddlStudent.Enabled = Data.Get_other(ViewState["Selected_Account_Number"].ToString().Substring(0,7)+"-0000-000", "321", "0").Equals("0");
            if (!ddlStudent.Enabled)
                lblReqStudent.ForeColor = System.Drawing.Color.White;
            if (!string.IsNullOrEmpty(hidSave.Value))
            {
                hidSave.Value = "";
                Validate();
                if (!IsValid)
                    return;
                if ((!string.IsNullOrEmpty(Request.Params["dep_id"])&& Request.Params["dep_id"].Equals("-1")))
                {
                    string IsDuplicate = Data.check_duplicate_dependent(ViewState["Employee_Number"].ToString(), txtSSN.TextWithLiterals, txtFirstName.Text, txtLastName.Text, txtDOB.SelectedDate.Value.ToShortDateString(), ddlRelation.SelectedValue);
                    if (!string.IsNullOrEmpty(IsDuplicate))
                    {
                        Bas_Utility.Misc.Alert(Page, IsDuplicate);
                        return;
                    }
                }
                aspxbtn_Click(null, null);
                if (string.IsNullOrEmpty(strCallCloseWindow))
                {
                    if (!string.IsNullOrEmpty(Request.Params["sessom"]))
                        strCallCloseWindow = "<script>docloseWindow(1)</script>";
                    else
                        strCallCloseWindow = "<script>closeWindowcloseWindowOE(1)</script>";
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
                return;
            }
            if (!string.IsNullOrEmpty(hidRetSave.Value))
            {
                Send_Email_Retiree(hidRetSave.Value == "yes");
            }
            if (!string.IsNullOrEmpty(hidRelation.Value))
            {
                hidRelation.Value = "";
                foreach (ListItem li in ddlRelation.Items)
                    li.Selected = false;
                ddlRelation.SelectedIndex = 0;
                ddlRelation_SelectedIndexChanged(null, null);
            }
            
            Singleton.Windows[1].VisibleOnPageLoad = false;
            lnkbtnDependentEligibilityRules.Attributes.Add("onclick", "showDialog1();return false;");
            //if (SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE").Equals("A"))
            {
                RequiredFieldValidator6.Enabled = false;
                lblReqStudent.Visible = !Data.Get_other(ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "555", "0").Equals("1");
                //RequiredFieldValidator6.Enabled = lblReqStudent.Visible;
                try
                {
                    RequiredFieldValidator6.Enabled = Data.SpuseTypeRelationship(ddlRelation.SelectedValue).Equals("0");
                }
                catch { }
                try
                {
                    RequiredFieldValidator6.Enabled = ddlStudent.SelectedValue.Equals("T");
                }
                catch { }
            }
        }

        


        private bool InOpenEnrollment()
        {
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "O")
                return true;
            //if (ViewState["SESSION_CALLING_MODULE"].ToString() == "A")
            //    return true;
            return false;
        }

        private void GetSpouseInfo()
        {
            string strSpouseInfo = SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.get_dep_spouse_name2(" + ViewState["Employee_Number"].ToString() + ")from dual").ToString();
            strSpouseInfo = strSpouseInfo.Trim();
            if (strSpouseInfo.Equals("Error: More than one spouse found"))
            {
                string SpouseError = "<script>SpouseError()</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "SpouseError", SpouseError);
                return;
            }
            if (string.IsNullOrEmpty(strSpouseInfo))
            {
                ViewState["Spouse_Name"] = null;
                ViewState["Spouse_Number"] = "x";
            }
            else
            {
                ViewState["Spouse_Type"] = strSpouseInfo.Substring(0, 1); // N= Spouse  D= Domestic Partner
                ViewState["Spouse_Name"] = strSpouseInfo.Substring(1, strSpouseInfo.IndexOf("~"));
                ViewState["Spouse_Number"] = strSpouseInfo.Substring(strSpouseInfo.IndexOf("~")+1);
            }
        }

        private void FillRelationTable()
        {
            ListItem li0 = new ListItem("-- Select --" , "x");
            ddlRelation.Items.Add(li0);
            DataTable tbl = null;
            if (SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE").Equals("L"))
            {
                string strLifeCode = SQLStatic.Sessions.GetSessionValue(session_id, "LIFE_EVENT_CODE");
                tbl = Data.GetRelationships(ViewState["Employee_Number"].ToString(),strLifeCode);
            }
            else
                tbl = Data.GetRelationships(ViewState["Employee_Number"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["relationship_description"].ToString(), dr["bas_relationship_code"].ToString());
                ddlRelation.Items.Add(li);
                ViewState[dr["bas_relationship_code"].ToString()] = dr["sex_code"].ToString();
            }
        }

        private void FillYears()
        {
            int intStartYear = Convert.ToInt16(ViewState["Processing_Year"].ToString());
            ListItem lio = new ListItem("Year", "0");
            ddlYear.Items.Add(lio);
            for (int i = intStartYear; i < (intStartYear + 7); i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                ddlYear.Items.Add(li);
            }
        }

        private void FillState()
        {
            DataTable tbl = SQLStatic.CD_Tables.States();
            ListItem li2 = new ListItem("Select", "0");
            ddlState.Items.Add(li2);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["state_description"].ToString(), dr["state"].ToString());
                ddlState.Items.Add(li);
            }
        }

        protected void setValue(TextBox txt, string strValue)
        {
            ViewState[txt.ID] = strValue;
            txt.Text = strValue;
        }

        protected void setValue(RadMaskedTextBox txt, string strValue)
        {
            if (strValue.Equals("(000) 000-0000"))
                strValue = "0000000000";
            if (strValue.Equals("(000)000-0000"))
                strValue = "0000000000";
            ViewState[txt.ID] = strValue;
            
            txt.Text = strValue;
        }

        protected void setValue(RadDateInput txt, string strValue)
        {
            try
            {
                ViewState[txt.ID] = strValue;
                txt.SelectedDate = Convert.ToDateTime(strValue);
            }
            catch { }
        }

        protected void setValue(DropDownList ddl, string strValue)
        {
            ViewState[ddl.ID] = strValue;
            foreach (ListItem li0 in ddl.Items)
                li0.Selected = false;
            ListItem li = ddl.Items.FindByValue(strValue);
            if (li != null)
                li.Selected = true;
        }

        private void SetExistingFields()
        {
            DataTable tbl = Data.GetDependentsInfoFromID(ViewState["id"].ToString(), ViewState["dep_id"].ToString());
            if (tbl.Rows.Count == 0)
                return;
            DataRow dr = tbl.Rows[0];
            lblTitle.Text = lblTitle.Text + ": " + dr["FullName"].ToString();
            setValue(txtLastName, dr["Last_Name"].ToString());
            setValue(txtFirstName, dr["First_Name"].ToString());
            setValue(txtMI, dr["middle_initial"].ToString());
            setValue(txtSSN, dr["social_security_number"].ToString());
            setValue(txtDOB, dr["birth_date"].ToString());
            setValue(txtEffDate, dr["eff_Date"].ToString());
            setValue(txtSchool, dr["School"].ToString());
            setValue(ddlRelation, dr["relationship_code"].ToString());
            setValue(ddlRelation, dr["relationship_code"].ToString());
            setValue(ddlGender, dr["sex"].ToString());
            setValue(ddlStudent, dr["full_time_student"].ToString());
            setValue(ddlHandiCap, dr["handicapped"].ToString());
            if (dr["GraduationDate"].ToString() != "")
            {
                setValue(ddlMonth, dr["GraduationDate"].ToString().Substring(4));
                setValue(ddlYear, dr["GraduationDate"].ToString().Substring(0, 4));
            }
            ViewState["hc"] = dr["handicapped"].ToString();
            ViewState["st"] =  dr["full_time_student"].ToString();
            tbl.Dispose();
        }

        private void SetDependentAddress()
        {
            DataTable tbl = Data.GetDependentsAddress(ViewState["id"].ToString(), ViewState["dep_id"].ToString());
            if (tbl.Rows.Count == 0)
                return;
            DataRow dr = tbl.Rows[0];
            setValue(txtStreet, dr["address_line_1"].ToString());
            setValue(txtApt, dr["address_line_2"].ToString());
            setValue(txtCity, dr["city"].ToString());
            setValue(ddlState, dr["state"].ToString());
            setValue(txtZip, dr["zipcode"].ToString());
            setValue(txtHomePhone, dr["home_phone"].ToString());

        }

        private void DoSave()
        {
            string strGradDate = ddlYear.SelectedValue + ddlMonth.SelectedValue;
            if ((ddlMonth.SelectedIndex == 0) || (ddlYear.SelectedIndex == 0))
                strGradDate = "";
            string strSate = ddlState.SelectedValue;
            if (ddlState.SelectedValue == "0")
                strSate = "";
            string strDepID = "";
            if (ViewState["id"].ToString() == "-1")
                strDepID = "0";
            else
                strDepID = ViewState["dep_id"].ToString();
            string strIsOpenEnrollment = "0";
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "O")
                strIsOpenEnrollment = "1";
            if (ViewState["SESSION_CALLING_MODULE"].ToString() == "L")
                strIsOpenEnrollment = "3";
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction idx = conn.BeginTransaction();
            string strID;
            try
            {
                
                if (strIsOpenEnrollment.Equals("3"))
                    strID = Data.Save_DependentLE(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), strDepID, ViewState["Processing_Year"].ToString(), txtLastName.Text, txtFirstName.Text, txtMI.Text, ddlRelation.SelectedValue,
                    txtSSN.Text, txtDOB.SelectedDate.Value.ToShortDateString(), txtEffDate.SelectedDate.Value.ToShortDateString(), ddlGender.SelectedValue, ddlStudent.SelectedValue, ddlHandiCap.SelectedValue, txtSchool.Text,
                    strGradDate, strIsOpenEnrollment,ViewState["User_Name"].ToString(),"A", conn);
                else
                strID = Data.SaveDependents(session_id, ViewState["id"].ToString(), ViewState["Employee_Number"].ToString(), strDepID, ViewState["Processing_Year"].ToString(), txtLastName.Text, txtFirstName.Text, txtMI.Text, ddlRelation.SelectedValue,
                    txtSSN.Text, txtDOB.SelectedDate.Value.ToShortDateString(), txtEffDate.SelectedDate.Value.ToShortDateString(), ddlGender.SelectedValue, ddlStudent.SelectedValue, ddlHandiCap.SelectedValue, txtSchool.Text,
                    strGradDate, strIsOpenEnrollment,ViewState["User_Name"].ToString(), conn);
                
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "dep_id", strID);
                if (strID.IndexOf("-") == -1)
                    Data.SaveDependentsAddress(ViewState["Employee_Number"].ToString(), strID, txtStreet.Text, txtApt.Text, txtCity.Text, strSate, txtZip.Text, txtHomePhone.Text, ViewState["User_Name"].ToString(), conn);
                else
                    Data.SaveRequestDependentsAddress(ViewState["Employee_Number"].ToString(), strID.Replace("-",""), txtStreet.Text, txtApt.Text, txtCity.Text, strSate, txtZip.Text, txtHomePhone.Text, ViewState["User_Name"].ToString(), conn);
                idx.Commit();
                if (!strDepID.Equals("0"))
                    Data.VerifyDependentElig(session_id, strDepID);

                //string strPosID = strID;
                //if (strID.IndexOf("-") != -1)
                //    strPosID = strID.Replace("-", "");
                //Data.SaveDependentsAddress(ViewState["Employee_Number"].ToString(), strPosID, txtStreet.Text, txtApt.Text, txtCity.Text, strSate, txtZip.Text, txtHomePhone.Text, ViewState["User_Name"].ToString(), conn);
                //if (strPosID != strID)
                //    Data.MoveToPending(ViewState["Employee_Number"].ToString(), strPosID, ViewState["Processing_Year"].ToString(),ViewState["User_Name"].ToString(), conn);
                //
            }
            catch
            {
                idx.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            strID = strID.Replace("-", "");
            if (ViewState["id"].ToString() =="-1")
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "RecID", strID);
            else
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "RecID", ViewState["id"].ToString());
        }

        private string stripDate(string str)
        {
            str = str.Replace("_", "");
            if (str == "//")
                str = "";
            return str;
        }

        private void SetupForSave()
        {
            txtHomePhone.Text = txtHomePhone.Text.Replace("_", "");
            if (txtHomePhone.Text == "() -")
                txtHomePhone.Text = "";

            txtSSN.Text = txtSSN.Text.Replace("_", "");
            if (txtSSN.Text == "--")
                txtSSN.Text = "";

            txtDOB.Text = stripDate(txtDOB.Text);
            txtEffDate.Text = stripDate(txtEffDate.Text);
        }

        private bool HasDomesticChild()
        {
            return SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.employee_has_dom_par_child(" + ViewState["Employee_Number"].ToString() + ") from dual").ToString() != "0"; 
        }

        protected void aspxbtn_Click(object sender, EventArgs e)
        {
            if ((ddlRelation.SelectedValue == "23") ||
                (ddlRelation.SelectedValue == "24") ||
                (ddlRelation.SelectedValue == "29") ||
                (ddlRelation.SelectedValue == "03") ||
                (ddlRelation.SelectedValue == "04"))
            {
                if ((ViewState["Spouse_Number"].ToString() != "x") && (ViewState["Spouse_Number"].ToString() != ViewState["id"].ToString()))
                {
                    if (Data.CurrentSpousePendingTerm(ViewState["Employee_Number"].ToString()).Equals("0"))
                    {
                        lblWarning.Text = "<font color='#800000'><b>ERROR </b>- You already select {name}. You cannot make this relationship selection. You must remove {name} before you can make this selection.</font>";
                        lblWarning.Text = lblWarning.Text.Replace("{name}", ViewState["Spouse_Name"].ToString());

                        string strRelatioSelectionError = lblWarning.Text.Replace("<font color='#800000'><b>", "").Replace("</font>", "").Replace("</b>", "");
                        strRelatioSelectionError = "<script>alert('" + strRelatioSelectionError + "') </script>";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRelatioSelectionError", strRelatioSelectionError);
                        return;
                    }
                }
            }
            lblWarning.Text = "";
            lblWarning.Text = CanMakeSelection();
            if (lblWarning.Text != "")
            {
                string strRelatioSelectionError2 = "<script>alert('You may not save your changes to this dependent’s record. Please refer to the ERROR message shown on the screen.') </script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strRelatioSelectionError2", strRelatioSelectionError2);
                return;
            }
            SetupForSave();
            RequiredFieldValidator6.Enabled = ddlStudent.SelectedValue.Equals("T");
               
            Validate();
            if (!IsValid)
                return;
            DoSave();
            if (string.IsNullOrEmpty(Request.Params["sessom"]))
                strCallCloseWindow = "<script>docloseWindow(1)</script>";
            else
                strCallCloseWindow = "<script>closeWindowcloseWindowOE(1)</script>";
            if (Data.requires_dep_verify(ViewState["Employee_Number"].ToString()).Equals("1"))
            {
                if (ViewState["SESSION_CALLING_MODULE"].ToString().Equals("L"))
                {
                    strCallCloseWindow = "<script>docloseWindow(11)</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
                    return;
                }
            }
            if (ViewState["SESSION_CALLING_MODULE"].ToString().Equals("L"))
            {
                // Maher 3/6/2015
                // -- If domestic partner then treat this addd dep as OE added dependent
                if ((ddlRelation.SelectedValue == "23") ||
                (ddlRelation.SelectedValue == "24") ||
                (ddlRelation.SelectedValue == "25") ||
                (ddlRelation.SelectedValue == "26"))
                {
                }
                else
                {                    
                    if ((ViewState["ininOE"].ToString().Equals("1"))||(!string.IsNullOrEmpty(Request.Params["sessom"])))
                        strCallCloseWindow = "<script>closeWindowcloseWindowOE(1)</script>";
                    else                    
                        strCallCloseWindow = "<script>docloseWindow(1)</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(Request.Params["ret"]))
            {
                Response.Redirect("Dep_Cvrg.aspx", true);
            }
            //string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            if ((ddlRelation.SelectedValue == "23") ||
                (ddlRelation.SelectedValue == "24") ||
                (ddlRelation.SelectedValue == "25") ||
                (ddlRelation.SelectedValue == "26"))
            {
                if (!Data.SkipRetiree(ViewState["Employee_Number"].ToString(), ViewState["User_Name"].ToString()))
                {                                        
                    if (Data.ShowCoveragePage(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()))
                    {
                        //if (!ViewState["SESSION_CALLING_MODULE"].ToString().Equals("L"))
                        {
                            bool blnDepenedtActive = Data.DependentIsActive(ViewState["Employee_Number"].ToString(), ViewState["dep_id"].ToString());
                            if (!blnDepenedtActive)
                                strCallCloseWindow = "<script>docloseWindow(3)</script>";
                        }
                    }
                    else
                    {
                        bool blnShowDeclaration = ViewState["Show_Declaration"].ToString() == "1";
                        if (blnShowDeclaration)
                        {
                            if (ViewState["Selected_Account_Number"].ToString().StartsWith("0000699"))
                            {
                                Response.Redirect("Declaration_Form.aspx", true);
                                return;
                            }
                            strCallCloseWindow = "<script>docloseWindow(2)</script>";
                        }
                    }                    
                }
                else
                {
                    string strSaveRetiree = "<Script>confimemail()</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(),"strSaveRetiree",strSaveRetiree);
                    return;
                }
            }

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        private void Send_Email_Retiree(bool blnSend)
        {
            hidRetSave.Value = "";
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            string strFileName = "";
            DataTable tbl = null;
            try
            {
                tbl = Data.Get_Declation_Document_Location(ViewState["Employee_Number"].ToString(), conn);
                strFileName = tbl.Rows[0]["send_doc"].ToString();
            }
            finally
            {
                if (tbl != null)
                    tbl.Dispose();
                conn.Close();
                conn.Dispose();
            }
            byte[] bTheData;
            bTheData = StreamFile(strFileName);
            if (blnSend)
                Data.Send_Email_Doc_Retiree(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), ViewState["User_Name"].ToString(), bTheData);
            else
                Data.Send_Email_Doc(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), ViewState["User_Name"].ToString(), bTheData);

            if (string.IsNullOrEmpty(Request.Params["sessom"]))
                strCallCloseWindow = "<script>docloseWindow(1)</script>";
            else
                strCallCloseWindow = "<script>closeWindowcloseWindowOE(1)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();

            return ImageData; //return the byte data
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string strCallCloseWindow = "<script>docloseWindow(0)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string CanMakeSelection()
        {
            string strError = "";
            
            if (ViewState["EE_Has_Dep"].ToString() == "0")
                return "";
            if ((ddlRelation.SelectedValue == "23") ||
                    (ddlRelation.SelectedValue == "24") ||
                    (ddlRelation.SelectedValue == "29") ||
                    (ddlRelation.SelectedValue == "03") ||
                    (ddlRelation.SelectedValue == "04"))
            {
                if ((ViewState["Spouse_Number"].ToString() != "x") && (ViewState["Spouse_Number"].ToString() != ViewState["id"].ToString()))
                {
                    if (Data.CurrentSpousePendingTerm(ViewState["Employee_Number"].ToString()).Equals("0"))
                    {
                        strError = "<font color='#800000'><b>ERROR </b>- You already select {name}. You cannot make this relationship selection. You must remove {name} before you can make this selection.</font>";
                        strError = strError.Replace("{name}", ViewState["Spouse_Name"].ToString());
                        return strError;
                    }
                }
            }
            if (ViewState["id"].ToString() != "-1")
            {
                if ((",23,24,25,26,").IndexOf(ViewState["ddlRelation"].ToString()) == -1)
                {
                    if ((",23,24,25,26,").IndexOf(ddlRelation.SelectedValue) != -1)
                    {
                        string strHimHer = "him";
                        if (ddlGender.SelectedValue == "F")
                            strHimHer = "her";
                        string strExistingRelationName = ddlRelation.Items.FindByValue(ViewState["ddlRelation"].ToString()).Text;
                        string strNewRelationName = ddlRelation.SelectedItem.Text;
                        strError = "<font color='#800000'><b>ERROR</b> - - You may not change {Existing_Relationship} to {New_Relationship}. If you wish to make this change, you must click \"Cancel\" button then use the \"Remove\" link on the next screen that is associated with {Dependent_Name}’s record. Once you complete the removal, you may use the \"Add New Dependent\" link located above the dependent listing table on the next screen.<br/><b>Note</b>: If you proceed with this removal and new add, then you will need to go to the benefits update screen to reassign {Dependent_Name}’s benefits that will be terminated when you process the removal.</font>";
                        strError = strError.Replace("{Existing_Relationship}", strExistingRelationName).Replace("{New_Relationship}", strNewRelationName).Replace("{Dependent Name}", ViewState["Dependent_Name"].ToString());
                        return strError;
                    }

                }

                if ((",23,24,25,26,").IndexOf(ViewState["ddlRelation"].ToString()) != -1)
                {
                    if ((",23,24,25,26,").IndexOf(ddlRelation.SelectedValue) == -1)
                    {
                        string strHimHer = "him";
                        if (ddlGender.SelectedValue == "F")
                            strHimHer = "her";
                        string strExistingRelationName = ddlRelation.Items.FindByValue(ViewState["ddlRelation"].ToString()).Text;
                        string strNewRelationName = ddlRelation.SelectedItem.Text;
                        strError = "<font color='#800000'><b>ERROR</b> - You may not change {Existing_Relationship} to {New_Relationship}.If you wish to make this<br>change, you must click &quot;Cancel&quot; button then use the &quot;Remove&quot; link on the next screen that is associated<br>with {Dependent’s Name}’s record. Once you complete the removal, you may use the &quot;Add New<br>Dependent&quot; link located above the dependent listing table on the next screen.<br><b>Note</b>: If you proceed with this removal and new add, then you will need to go to the benefits update<br>screen to reassign {Dependent Name}’s benefits that will be terminated when you process the removal.</font>";
                        strError = strError.Replace("{Existing_Relationship}", strExistingRelationName).Replace("{New_Relationship}", strNewRelationName).Replace("{Dependent Name}", ViewState["Dependent_Name"].ToString());
                        return strError;
                    }

                }
            }
            if (ViewState["Spouse_Number"].ToString() != "x")
            {
                if ((",25,26,").IndexOf(ddlRelation.SelectedValue) != -1)
                {
                    if (ViewState["Spouse_Type"].ToString() == "N")
                    {
                        strError = "<font color='#800000'><b>ERROR</b> - You may not add a domestic partner child when you  have an active spouse in the system. You must remove your spouse from this system, then you may add your domestic partner child. To proceed with removing your spouse and adding your domestic partner child, click the \"Cancel\" button on this page, and on the next screen click \"Remove\" associated with your spouse’s record. Once you complete the removal, you may use the \"Add New Dependent\" link shown above the dependent listing grid on the next screen to add your domestic partner child.</font>";
                        return strError;
                    }
                }

            }
            if ((",03,04,29").IndexOf(ddlRelation.SelectedValue) != -1)
            {
                if (HasDomesticChild())
                {
                    strError = "<font color='#800000'><b>ERROR</b> - You may not add a spouse when you  have an active domestic partner child in the system. You must remove your domestic partner child from this system, then you may add your spouse. To proceed with removing your domestic partner child and adding your spouse, click the \"Cancel\" button on this page, and on the next screen click \"Remove\" associated with your domestic partner child’s record. Once you complete the removal, you may use the \"Add New Dependent\" link shown above the dependent listing grid on the next screen to add your Spouse. </font>";
                }
            }


            return strError;
        }

        private void HideShowAddress(bool blnShow)
        {
            lblInfo.Visible = blnShow;
            lblStreet.Visible = blnShow;
            lblApt.Visible = blnShow;
            lblCity.Visible = blnShow;
            lblState.Visible = blnShow;
            lblZipCode.Visible = blnShow;
            lblHomePhonr.Visible = blnShow;

            txtStreet.Visible = blnShow;
            txtApt.Visible = blnShow;
            txtCity.Visible = blnShow;
            ddlState.Visible = blnShow;
            txtZip.Visible = blnShow;
            txtHomePhone.Visible = blnShow;

            RegularExpressionValidator3.Enabled = blnShow;
            RegularExpressionValidator2.Enabled = blnShow;
        }

        private void CheckWhoSelected()
        {
            ddlStudent.Enabled = true;
            ddlHandiCap.Enabled = true;
            txtSchool.Enabled = true;
            ddlMonth.Enabled = true;
            ddlYear.Enabled = true;
            if (ddlRelation.SelectedValue.Equals("01") ||
                ddlRelation.SelectedValue.Equals("02") ||
                ddlRelation.SelectedValue.Equals("03") ||
                ddlRelation.SelectedValue.Equals("04") ||
                ddlRelation.SelectedValue.Equals("23") ||
                ddlRelation.SelectedValue.Equals("29") ||
                ddlRelation.SelectedValue.Equals("30") ||
                ddlRelation.SelectedValue.Equals("24"))
            {
                //ddlStudent.Enabled = false;
                //ddlHandiCap.Enabled = false;
                txtSchool.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
            }

            ddlGender.Enabled = true;
            try
            {
                if (ViewState[ddlRelation.SelectedValue].ToString().Equals("M"))
                {
                    ddlGender.SelectedIndex = 0;
                    ddlGender.Enabled = false;
                }
                else if (ViewState[ddlRelation.SelectedValue].ToString().Equals("F"))
                {
                    ddlGender.SelectedIndex = 1;
                    ddlGender.Enabled = false;
                }
            }
            catch { }
            if (ddlRelation.SelectedValue.Equals("29") && Data.CanHaveSameSexSpouse(ViewState["Employee_Number"].ToString(), "29").Equals("1"))
                ddlGender.Enabled = true;
            if (ddlRelation.SelectedValue.Equals("29") && Data.Get_other(ViewState["Selected_Account_Number"].ToString(), "202", "0").Equals("0"))
                ddlGender.Enabled = false;

        }

        protected void ClearDDLSelected(DropDownList ddl)
        {
            foreach (ListItem li in ddl.Items)
                li.Selected = false;
        }

        protected void ddlRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRelation.SelectedIndex.Equals(0))
                return;

            if ((ddlRelation.SelectedValue == "03") ||
                (ddlRelation.SelectedValue == "04"))
            {
                if (Data.CanHaveSameSexSpouse(ViewState["Employee_Number"].ToString(), ddlRelation.SelectedValue).Equals("0"))
                {
                    Bas_Utility.Misc.Alert(Page, "You cannot select same gender spouse");
                    ddlRelation.SelectedIndex = -1;
                    return;
                }
            }

            dvData.Disabled = false;
            HideShowAddress(true);
            btnSave.Enabled = true;
            CheckWhoSelected();
            if ((ddlRelation.SelectedValue == "23") ||
                (ddlRelation.SelectedValue == "24") ||
                (ddlRelation.SelectedValue == "25") ||
                (ddlRelation.SelectedValue == "26"))
            {
                if (!Data.CanAddDOMPartner(Request.Cookies["Session_ID"].Value.ToString()))
                {
                    dvData.Disabled = true;
                    btnSave.Enabled = false;
                    HideShowAddress(false);
                    ClearDDLSelected(ddlRelation);
                    ddlRelation.Items.FindByValue("x").Selected = true;
                    string strError = "<script>ErrorDP()</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
                    return;
                }
            }

            if (SQLStatic.Web_Data.ViewOnly(session_id))
                btnSave.Enabled = false;
            lblWarning.Text = "";
            lblWarning.Text = CanMakeSelection();
            if (lblWarning.Text != "")
                return;
            if ((ddlRelation.SelectedValue == "23") ||
                (ddlRelation.SelectedValue == "24") ||
                (ddlRelation.SelectedValue == "25") ||
                (ddlRelation.SelectedValue == "26"))
            {
                if (ViewState["Show_Declaration"].ToString() == "1")
                    lblWarning.Text = Data.GetText(session_id, "36");
                HideShowAddress(false);
            }
            else
            {
                lblWarning.Text = "";
                HideShowAddress(true);
            }
            if ((ddlRelation.SelectedValue == "23") ||
               (ddlRelation.SelectedValue == "24") ||
               (ddlRelation.SelectedValue == "29") ||
               (ddlRelation.SelectedValue == "03") ||
               (ddlRelation.SelectedValue == "04"))
            {
                string strEEGender = Data.Employee_Gender(ViewState["Employee_Number"].ToString());
                string CanHaveSameSexSpouse = Data.CanHaveSameSexSpouse(ViewState["Employee_Number"].ToString(), ddlRelation.SelectedValue);
                if (CanHaveSameSexSpouse.Equals("0"))
                    ClearDDLSelected(ddlGender);
                ClearDDLSelected(ddlHandiCap);
                ClearDDLSelected(ddlStudent);
                if (CanHaveSameSexSpouse.Equals("0"))
                {
                    if (strEEGender.Equals("F"))
                    {
                        ddlGender.Items.FindByValue("M").Selected = true;
                        ddlGender.Enabled = false;
                    }
                    else if (strEEGender.Equals("M"))
                    {
                        ddlGender.Items.FindByValue("F").Selected = true;
                        ddlGender.Enabled = false;
                    }
                }
                if (ddlRelation.SelectedValue.Equals("29") && Data.CanHaveSameSexSpouse(ViewState["Employee_Number"].ToString(), "29").Equals("1"))
                    ddlGender.Enabled = true;
                if (ddlRelation.SelectedValue.Equals("29") && Data.Get_other(ViewState["Selected_Account_Number"].ToString(), "202", "0").Equals("1"))
                    ddlGender.Enabled = false;
                //else 
                ClearDDLSelected(ddlHandiCap);
                ClearDDLSelected(ddlStudent);
                //ddlHandiCap.Items.FindByValue("F").Selected = true;
                //ddlHandiCap.Enabled = false;
                //ddlStudent.Items.FindByValue("F").Selected = true;
                //ddlStudent.Enabled = false;
                txtSchool.Text = "";
                txtSchool.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
            }
            else
            {
                if (ViewState["id"].ToString().Equals("-1"))
                {
                    ClearDDLSelected(ddlGender);
                    ClearDDLSelected(ddlHandiCap);
                    ClearDDLSelected(ddlStudent);

                    ddlHandiCap.Items.FindByValue("F").Selected = true;
                    ddlStudent.Items.FindByValue("F").Selected = true;
                }
                ddlGender.Enabled = true;
                ddlHandiCap.Enabled = true;
                ddlStudent.Enabled = true;

            }
            if (ddlRelation.SelectedValue == "23")
            {
                ClearDDLSelected(ddlGender);
                ddlGender.Items.FindByValue("M").Selected = true;
                ddlGender.Enabled = false;
            }
            else if (ddlRelation.SelectedValue == "24")
            {
                ClearDDLSelected(ddlGender);
                ddlGender.Items.FindByValue("F").Selected = true;
                ddlGender.Enabled = false;
            }
            if (ddlRelation.SelectedValue.Equals("29") && Data.CanHaveSameSexSpouse(ViewState["Employee_Number"].ToString(), "29").Equals("1"))
                ddlGender.Enabled = true;
            try
            {
                if (ViewState[ddlRelation.SelectedValue].ToString().Equals("M"))
                {
                    ddlGender.SelectedIndex = 0;
                }
                else if (ViewState[ddlRelation.SelectedValue].ToString().Equals("F"))
                {
                    ddlGender.SelectedIndex = 1;
                }
            }
            catch { }
            if (Data.dep_realtion_has_note(ViewState["Selected_Account_Number"].ToString(), ddlRelation.SelectedValue).Equals("1"))
            {
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Relation", ddlRelation.SelectedValue);
                Singleton.Windows[1].VisibleOnPageLoad = true;
                return;
            }
            if (ddlRelation.SelectedValue.Equals("01") ||
                ddlRelation.SelectedValue.Equals("02") ||
                ddlRelation.SelectedValue.Equals("03") ||
                ddlRelation.SelectedValue.Equals("04") ||
                ddlRelation.SelectedValue.Equals("23") ||
                ddlRelation.SelectedValue.Equals("29") ||
                ddlRelation.SelectedValue.Equals("30") ||
                ddlRelation.SelectedValue.Equals("24"))
            {
                if (!ViewState["id"].ToString().Equals("-1"))
                {
                    try
                    {
                        ClearDDLSelected(ddlHandiCap);
                        ddlHandiCap.Items.FindByValue(ViewState["hc"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ClearDDLSelected(ddlStudent);
                        ddlStudent.Items.FindByValue(ViewState["st"].ToString()).Selected = true;
                    }
                    catch { }
                }
            }
            if (ViewState["id"].ToString().Equals("-1"))
            {
                try
                {
                    ClearDDLSelected(ddlHandiCap);
                    ddlHandiCap.Items.FindByValue("F").Selected = true;
                }
                catch { }
                try
                {
                    ClearDDLSelected(ddlStudent);
                    ddlStudent.Items.FindByValue("F").Selected = true;
                }
                catch { }
            }
            if (ddlRelation.SelectedValue.Equals("29") && Data.Get_other(ViewState["Selected_Account_Number"].ToString(), "202", "0").Equals("1"))
                ddlGender.Enabled = false;
            //else
            //    txtDOB_TextChanged(null,null);
        }

        protected void txtHomePhone_TextChanged(object sender, EventArgs e)
        {
            RegularExpressionValidator2.Enabled = txtHomePhone.Text != "(___) ___-____";
        }

        private int Age()
        {
            if ((ViewState["id"].ToString() == "-1") & (string.IsNullOrEmpty(txtLastName.Text)))
                return 0;
            DateTime BirthDate;
            try
            {
                BirthDate = txtDOB.SelectedDate.Value;// Convert.ToDateTime(txtDOB.Text);
            }
            catch
            {
                //lblIncorrectDate.Visible = true;
                return 0;
            }
            //lblIncorrectDate.Visible = false;
            int years = DateTime.Now.Year - BirthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (DateTime.Now.Month < BirthDate.Month ||
                (DateTime.Now.Month == BirthDate.Month &&
                DateTime.Now.Day < BirthDate.Day))
                years--;
            return years;
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            // 04/19/2011
            //int maxAge = Convert.ToInt16(Data.MaxEligibleDate(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()));
            //if (Age() <= maxAge)
            //{
            //    ClearDDLSelected(ddlHandiCap);
            //    ClearDDLSelected(ddlStudent);
            //    lblReqStudent.ForeColor = System.Drawing.Color.White;
            //    ddlStudent.Enabled = false;
            //    ddlHandiCap.Items.FindByValue("F").Selected = true;
            //    //ddlHandiCap.Enabled = false;
            //    ddlStudent.Items.FindByValue("F").Selected = true;
            //    ddlStudent.Enabled = false;
            //    txtSchool.Text = "";
            //    txtSchool.Enabled = false;
            //    RequiredFieldValidator6.Enabled = false;
            //    ddlMonth.Enabled = false;
            //    ddlYear.Enabled = false;
            //}
            //else
            //{
            //    if (!isSpouse())
            //    {
            //        lblReqStudent.ForeColor = System.Drawing.Color.Maroon;
            //        ddlHandiCap.Enabled = true;
            //        ddlStudent.Enabled = true;                    
            //        txtSchool.Enabled = true;
            //        RequiredFieldValidator6.Enabled = true;
            //        ddlMonth.Enabled = true;
            //        ddlYear.Enabled = true;
            //    }
            //}
            
            SetSchoolRequired();
        }

        private bool isSpouse()
        {
            if ((ddlRelation.SelectedValue == "23") ||
               (ddlRelation.SelectedValue == "24") ||
               (ddlRelation.SelectedValue == "29") ||
               (ddlRelation.SelectedValue == "03") ||
               (ddlRelation.SelectedValue == "04"))
                return true;
            else
                return false;
        }

        private void SetSchoolRequired()
        {
            if ((ddlStudent.Enabled)&(ddlStudent.SelectedValue.Equals("T")))
            {
                lblReqSchoolName.ForeColor = System.Drawing.Color.Maroon;
                RequiredFieldValidator6.Enabled = true;
                txtSchool.Enabled = true;
                ddlMonth.Enabled = true;
                ddlYear.Enabled = true;
                ddlHandiCap.Enabled = true;
            }
            else
            {
                lblReqSchoolName.ForeColor = System.Drawing.Color.White;
                RequiredFieldValidator6.Enabled = false;
                // 04/19/2011
                txtSchool.Text = " ";
                txtSchool.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
                // -----------------
            }
        }

        protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtDOB_TextChanged(null, null);   04/19/2011
            SetSchoolRequired();
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["ret"]))
            {
                Response.Redirect("Dep_Cvrg.aspx", true);
            }
        }

        protected void ddlHandiCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRelation.SelectedValue.Equals("01") ||
               ddlRelation.SelectedValue.Equals("02") ||
               ddlRelation.SelectedValue.Equals("03") ||
               ddlRelation.SelectedValue.Equals("04") ||
               ddlRelation.SelectedValue.Equals("23") ||
               ddlRelation.SelectedValue.Equals("29") ||
               ddlRelation.SelectedValue.Equals("30") ||
               ddlRelation.SelectedValue.Equals("24"))
                return;
            RequiredFieldValidator6.Enabled = ddlHandiCap.SelectedValue.Equals("F");
        }
    }
}
