using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Collections;
using System.IO;
using Telerik.Web.UI.Upload;

namespace StartLifeEventv1
{
    public partial class Default : System.Web.UI.Page
    {
        string session_id = "";
        /*ArrayList uploadedFiles; string altDiv = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head> <style type='text/css'> .FullPage { width:550px; font-family: Arial; font } .FullRow { width:530px;  font-family:Arial; font-size:9pt; } .Row { width:530; } .marginbottom10 { margin-bottom: 10px; } .leftText { width:200px; font-weight:bolder; float:left; } .rightTextGreen { color:Green; font-weight:bold; } .rightTextMaroon { color:Maroon; font-weight:bold; } .rightTextNavy { color:Navy; font-weight:bold; } </style></head><body><div class='FullPage'> <div class='FullRow'> <div class='Row marginbottom10'> <h3>Upload Documents</h3> </div> <div class='Row marginbottom10'> You have chosen to upload documents from your computer that will verify your dependent's eligibility  </div> <!--EE Name--> <div class='Row marginbottom10'> <div class='leftText'>Employee</div><div class='rightTextGreen'>[EEName]</div> </div> <!--Dep Name--> <div class='Row marginbottom10'> <div class='leftText'>Selected Dependent</div><div class='rightTextMaroon'>[DepName]</div> </div> <!--Required Document--> <div class='Row marginbottom10'> <div class='leftText'>Required Documents</div><div class='rightTextNavy'><a href=[url] target='_blank'>View</a></div> </div> </div></div></body></html>";  */
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();

            string accnt = SQLStatic.Sessions.GetAccountNumber(session_id);
            string Py = SQLStatic.Sessions.GetSessionValue(session_id,"PROCESSING_YEAR");
            DataTable tbl = Data.Get_ER_Setup(session_id,accnt, Py,DateTime.Today.ToShortDateString());
            if (tbl.Rows.Count.Equals(0))
            {
                string strError = "<script>Javescript:NoAccess('Your employer is not setup for Life Event module.')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
                return ;
            }
            #region BasTemplate
            if (!IsPostBack)
            {
                //if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                //{
                //    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
                //    Response.Redirect("/web_projects/PTemplate/index.htm");
                //    //Response.Redirect("/web_projects/PTemplate/index_ifram.htm");
                //    return;
                //}
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
            #endregion  //if(!IsPostBack)
            
            string strEmployeeNumber = ViewState["Employee_Number"].ToString();
            if (strEmployeeNumber.Equals("0"))
            {
                string strGetEE = "<script>GetEE('" + Request.Path + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGetEE", strGetEE);
                return;
            }

            string strBlockLE = Data.Block_in_OE(session_id, ViewState["Selected_Account_Number"].ToString());
            if (!string.IsNullOrEmpty(strBlockLE))
            {
                strBlockLE = "'" + strBlockLE + "'";
                string stringNoAccess = "<script>InOE(" + strBlockLE + ")</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringNoAccess", stringNoAccess);
                return;
            }

            if (!Data.is_EE_in_New_Open_Enrollment(ViewState["Employee_Number"].ToString()).Equals("0"))
            {
                string stringNoAccess = "<script>InNewOE()</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringNoAccess", stringNoAccess);
                return;
            }

            if (!Allowin())
            {
                string stringNoAccess = "<script>NoAccess('" + ViewState["Error"].ToString() + "')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringNoAccess", stringNoAccess);
                return;
            }

            if (Data.ee_eligible_for_life(ViewState["Employee_Number"].ToString(), session_id).Equals("0"))
            {
                string stringNoAccess = "<script>NoAccess('You are in a class which is not eligible for Life Event.')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "stringNoAccess", stringNoAccess);
                return;
            }
            if (!IsPostBack)
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "SESSION_CALLING_MODULE", "L");
                lblEmployerInstruction.Text = Data.Get_message(Request.Cookies["Session_ID"].Value.ToString(), "5");
                //tdContol.Visible = false;                                            
                SQLStatic.Sessions.SetSessionValue(session_id, "SESSION_CALLING_MODULE", "L");
                txtNote.Text = string.Empty;
                
                GetEmployerInfo(tbl);
                //Whate Page                
                SetLifeEvents();
                // When
                SetWhen(tbl);
                
                // Proof
                SetProof();

                // set Comment Visibility
                SetCommentVisiblity();
                GetExistingData();
            }
            //btnManageDocument.Attributes.Add("click","CallHelp()")
            if (!string.IsNullOrEmpty(hidRefrehDoc.Value))
            {
                hidRefrehDoc.Value = string.Empty;
                Update_lblDocumentation();
                return;
            }
            if (!string.IsNullOrEmpty(hidGoToDemgraohic.Value))
            {
                hidGoToDemgraohic.Value = string.Empty;
                btnDisagree_Click(null, null);
                return;
            }

            if (!string.IsNullOrEmpty(hidSaveLife.Value))
            {
                hidSaveLife.Value = string.Empty;
                DateTime minDate = Convert.ToDateTime(ViewState["minDate"].ToString());
                DateTime selectedDate = txtLifeEventDate.SelectedDate.Value;
                if (minDate > selectedDate)
                    return;
                if (selectedDate > DateTime.Today)
                    return;
                Data.save_le_ee_session_info(session_id, ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(),
                           txtLifeEventDate.SelectedDate.Value.ToShortDateString(), "", ddlItem.SelectedValue, lblAcknowledgeText.Text,
                           ViewState["User_Name"].ToString());
                ////string hiddiv = "<script>Javescript:hidfax('0')</script>";
                ////Page.ClientScript.RegisterStartupScript(Page.GetType(), "hiddiv", hiddiv);
                RadWizard1.ActiveStepIndex = RadWizard1.WizardSteps.IndexOf(RadWizard1.WizardSteps[3]);
            }

            if (!string.IsNullOrEmpty(hidSaveCoo.Value))
            {
                
            }

            if (!string.IsNullOrEmpty(hidGotoWizard.Value))
            {
                hidGotoWizard.Value = string.Empty;
                NewRegistrationButton_Click(null, null); 
            }
        }

        private bool Allowin()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                if (SQLStatic.Web_Data.ViewOnly(session_id, conn))
                {
                    ViewState["Error"] = "You are \"View Only\" user. You do not have access to this module.";
                    return false;
                }
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
            return true;
        }

        private void SetCommentVisiblity()
        {
            RadWizard1.WizardSteps[1].Enabled = false;
            RadWizard1.WizardSteps[2].Enabled = false;
            RadWizard1.WizardSteps[4].Enabled = false;
            RadWizard1.WizardSteps[5].Enabled = false;
            //RadWizard1.WizardSteps[6].Enabled = false;
            
            string ShowGetDocument = Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString().Substring(0, 7) + "-0000-000", "194");
            //if (ShowGetDocument.Equals("1"))
            //{
            //    string Retiree = Data.is_currently_retiree(ViewState["Employee_Number"].ToString());
            //    if (Retiree.Equals("1"))
            //        ShowGetDocument = null;
            //}

            // Disaable First tav
            RadWizard1.WizardSteps[0].CssClass = "wizardStepHidden";
            RadWizard1.ActiveStepIndex = 1;  //go to step 4
            RadWizard1.WizardSteps[1].Enabled = true;


            ViewState["hasEffective"] = 0;
            if ((!string.IsNullOrEmpty(ShowGetDocument)) || (ShowGetDocument.Equals("1")))
            {
                string Retiree = Data.is_currently_retiree(ViewState["Employee_Number"].ToString());
                if (!Retiree.Equals("1"))
                {
                    RadWizard1.WizardSteps[3].CssClass = "wizardStepHidden";
                    hidtab3.Value = "1";
                }
                else
                    RadWizard1.WizardSteps[3].Enabled = false;
            }
            else
                RadWizard1.WizardSteps[3].Enabled = false;
        }

        private void GetExistingData()
        {
            DataTable tbl = Data.Get_le_ee_session_info(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString(), ViewState["Employee_Number"].ToString());
            if (tbl.Rows.Count > 0)
            {

                tbl.Rows[0]["notes"] = BASUSA.MiscTidBit.HTMLToText(tbl.Rows[0]["notes"].ToString());
                tbl.AcceptChanges();


                lblAcknowledgeText.Text = lblAcknowledgeText.Text +
                    "<br/><br/><input id='cbAgree' type='checkbox' name='cbAgree' checked='checked' disabled='disabled' onclick='JavaScript:cbHandel(this);' /><label for='cbAgree'>I Agree</label>";
                SQLStatic.Sessions.SetSessionValue(session_id, "LE_EE_ID", tbl.Rows[0]["record_id"].ToString());
                ViewState["LE_EE_ID"] = tbl.Rows[0]["record_id"].ToString();
                txtVal.Text = "ok";
                cbAcknowledgment.Checked = true;
                txtNote.Text = tbl.Rows[0]["notes"].ToString();
                if (!string.IsNullOrEmpty(txtNote.Text))
                {
                    RadWizard1.WizardSteps[4].Enabled = true;  // Enable Comments Step
                    RadWizard1.WizardSteps[5].Enabled = true; // Enable Confirmation Step
                    Update_lblComments(txtNote.Text);
                }

                ddlGroup.FindItemByValue(tbl.Rows[0]["groupid"].ToString()).Selected = true;
                SetItemLifeEvents();
                ddlItem.FindItemByValue(tbl.Rows[0]["code"].ToString()).Selected = true;
                RadWizard1.WizardSteps[1].Enabled = true;  // Enable what Step
                SQLStatic.Sessions.SetSessionValue(session_id, "LIFE_EVENT_CODE", tbl.Rows[0]["code"].ToString()); // Setup Life Code in Session

               // lblLifeEvent.Text = tbl.Rows[0]["description"].ToString();
                Update_lblLifeEvent(tbl.Rows[0]["description"].ToString());
                try
                {
                    txtLifeEventDate.SelectedDate = (DateTime)tbl.Rows[0]["action_date"];
                    //lblEventDate.Text = tbl.Rows[0]["action_date"].ToString();
                    Update_lblEventDate(tbl.Rows[0]["action_date"].ToString());
                    RadWizard1.WizardSteps[2].Enabled = true;  // Enable When Step
                    SQLStatic.Sessions.SetSessionValue(session_id, "LIFE_EVENT_DATE", tbl.Rows[0]["action_date"].ToString().Replace(" 12:00:00 AM", string.Empty)); // Setup Life Code in Session

                    if (txtEffectiveDate.Visible)
                        txtEffectiveDate.SelectedDate = (DateTime)tbl.Rows[0]["override_effective_date"];
                    
                    RadWizard1.WizardSteps[3].Enabled = true;  // Enable Proof Step

                }
                catch { }
                ViewState["code"] = tbl.Rows[0]["code"].ToString();
                ViewState["groupid"] = tbl.Rows[0]["groupid"].ToString();
                //rblApproval.SelectedIndex = 0;
                tbl.Dispose();

            }
            else
                lblAcknowledgeText.Text = lblAcknowledgeText.Text + "<br/><br/><input id='cbAgree' type='checkbox' name='cbAgree' onclick='JavaScript:cbHandel(this);' /><label for='cbAgree'>I Agree</label>";
            if (Data.ee_property_value(ViewState["Employee_Number"].ToString(), "708").Equals("1"))
            {
                RadPanelBar1.Items[0].Expanded = false;
                RadPanelBar1.Items[1].Expanded = true;
            }
            Update_lblDocumentation();
        }


        #region Agree
        private bool GetEmployerInfo(DataTable tbl)
        {

            if (tbl.Rows.Count.Equals(0))
            {
                string strError = "<script>Javescript:NoAccess('Your employer is not setup for Life Event module.')</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
                return false;
            }
            lblAcknowledgeText.Text = tbl.Rows[0]["certification_text"].ToString().Replace("\n", "<br>");
            return true;
        }
        #endregion

        #region What
        private void SetLifeEvents()
        {
            ddlGroup.DataSource = Data.Get_Group_Life_Event(ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(), session_id);
            ddlGroup.DataTextField = "grouping_title";
            ddlGroup.DataValueField = "record_id";
            ddlGroup.DataBind();
            ddlGroup_SelectedIndexChanged(null, null);
        }
        protected void ddlGroup_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            SetItemLifeEvents();
        }

        protected void ddlItem_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            string LifeWventDate = txtLifeEventDate.SelectedDate.ToString();
            
            Update_lblLifeEvent(ddlItem.SelectedText); 
            hidLifeEvent.Value = ddlItem.SelectedValue;
            Data.save_le_ee_session_info(session_id, ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(),
                           LifeWventDate, "", ddlItem.SelectedValue, lblAcknowledgeText.Text,
                           ViewState["User_Name"].ToString());
            ViewState["LE_EE_ID"] = SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID");
        }

        private void SetItemLifeEvents()
        {
            if (ddlGroup.SelectedIndex.Equals(-1))
                return;
            ddlItem.DataSource = Data.Get_Life_Events_For_Group(ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(), ddlGroup.SelectedValue, session_id);
            ddlItem.DataTextField = "description";
            ddlItem.DataValueField = "code";
            ddlItem.DataBind();
        }
        #endregion

        #region When
        private void SetWhen(DataTable tbl)
        {
            //lblAcknowledgeText.Text = tbl.Rows[0]["certification_text"].ToString().Replace("\n", "<br>");
            //txtLifeEventDate.MinDate = (DateTime)tbl.Rows[0]["min_date"];
            ViewState["minDate"] = (DateTime)tbl.Rows[0]["min_date"];

            RangeValidator1.MaximumValue = Convert.ToDateTime(tbl.Rows[0]["max_date"].ToString()).ToShortDateString();
            RangeValidator1.MinimumValue = Convert.ToDateTime(tbl.Rows[0]["min_date"].ToString()).ToShortDateString();
            RangeValidator1.ErrorMessage = "The Reporting Date must be between " + RangeValidator1.MinimumValue + " and " + RangeValidator1.MaximumValue;

            RequiredFieldValidator1.ErrorMessage = "The Reporting Date must be between " + RangeValidator1.MinimumValue + " and " + RangeValidator1.MaximumValue;
            hidErrorDate.Value = "The Life Event Date must be between " + RangeValidator1.MinimumValue + " and " + RangeValidator1.MaximumValue;
           
            lblDateRange.Text = "The Life Event Date must be between " + RangeValidator1.MinimumValue + " and " + RangeValidator1.MaximumValue;
            txtLifeEventDate.MinDate = Convert.ToDateTime(tbl.Rows[0]["min_date"].ToString());

            if (tbl.Rows[0]["showEffSelection"].ToString().Equals("1"))
            {
                txtNetEffectiveDate.Visible = false;
                txtEffectiveDate.Visible = true;
                RequiredFieldValidator2.Enabled = true;
            }
            txtLifeEventDate.MaxDate = DateTime.Today;
            SetEffectiveDateSetup(tbl);

            
            //RequiredFieldValidator4.ErrorMessage = "Incorrect Date: The Reporting Date " + DateTime.Today.ToShortDateString() + " is more than " + tbl.Rows[0]["max_days_to_allow"].ToString() + " days past the Life Event Dateyou entered";
        }

        private void SetEffectiveDateSetup(DataTable tbl)
        {
            if (txtLifeEventDate.SelectedDate == null)
                return;
            if (tbl.Rows[0]["showEffSelection"].ToString().Equals("1"))
            {
                ViewState["hasEffective"] = 1;
                //if (!string.IsNullOrEmpty(txtNetEffectiveDate.Text))
                //    txtEffectiveDate.SelectedDate = Convert.ToDateTime(txtNetEffectiveDate.Text); 
                txtNetEffectiveDate.Visible = false;
                txtEffectiveDate.Visible = true;
                RequiredFieldValidator2.Enabled = true;
                //RangeValidator2.MaximumValue = Convert.ToDateTime(tbl.Rows[0]["effmax_date"].ToString()).ToShortDateString();
                //RangeValidator2.MinimumValue = Convert.ToDateTime(tbl.Rows[0]["effmin_date"].ToString()).ToShortDateString();
                //lblEddDateRange.Text = "The Effecrive Date must be between " + RangeValidator2.MinimumValue + " and " + RangeValidator2.MaximumValue;
                //hidEffErrorDate.Value = lblEddDateRange.Text;
                //txtEffectiveDate.MinDate = Convert.ToDateTime(RangeValidator2.MinimumValue );
                //txtEffectiveDate.MaxDate = Convert.ToDateTime(RangeValidator2.MaximumValue);
            }
                
        }

        
        #endregion

        protected void SetProof( )
        {
            Bas_Utility.Utilities.GetLabel(Page, "lblInstruction").Text = Data.LifeEventProoftabInstruction();
        }

        protected void NewRegistrationButton_Click(object sender, EventArgs e)
        {
            hidSaveCoo.Value = string.Empty;
            Data.updatele_ee_session_info(session_id, txtLifeEventDate.SelectedDate.Value.ToShortDateString(), txtNote.Text);
            RadWizard1.ActiveStepIndex = RadWizard1.WizardSteps.IndexOf(RadWizard1.WizardSteps[5]);
            Response.Redirect("/web_projects/ENROLLMENTWIZARD/DependentInfo.aspx");

        }

        protected void RadWizard1_PreviousButtonClick(object sender, WizardEventArgs e)
        {
            int currentStep = e.CurrentStepIndex;
            int prevStep = e.CurrentStepIndex;

            if (prevStep.Equals(1))
            {
                RadWizard1.ActiveStepIndex = 1;
            }

            if (prevStep.Equals(4)) 
            {
                if (hidtab3.Value.Equals("1"))
                {
                    RadWizard1.ActiveStepIndex = 2;
                }
                else
                {
                    string hiddiv = "<script>Javescript:hidfax('0')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "hiddiv", hiddiv);
                }                 
            }
            if (currentStep.Equals(3))
                Update_lblDocumentation();
            if (currentStep.Equals(4))
            {
                if (RadPanelBar1.Items[0].Expanded == true)
                    Data.add_ee_property_code(ViewState["Employee_Number"].ToString(), "708", "1", ViewState["User_Name"].ToString());                
            }
            //setPage(RadWizard1.ActiveStepIndex);
        }

        protected void RadWizard1_NextButtonClick(object sender, Telerik.Web.UI.WizardEventArgs e)
        {
            int nextStep = e.NextStepIndex;
            int currentStep = e.CurrentStepIndex;
            try
            {
                if (nextStep.Equals(5))
                    Data.updatele_ee_session_info(session_id, txtLifeEventDate.SelectedDate.Value.ToShortDateString(), txtNote.Text);

                if (hidtab3.Value.Equals("1"))
                {
                    if (nextStep.Equals(3))
                    {
                        RadWizard1.ActiveStepIndex = 4;  //go to step 4
                        RadWizard1.WizardSteps[4].Enabled = true;
                    }
                    else
                    {
                        RadWizard1.WizardSteps[nextStep].Enabled = true;
                        Update_lblDocumentation();

                    }
                }
                else
                    RadWizard1.WizardSteps[nextStep].Enabled = true;

                if (currentStep.Equals(2))
                {
                    if (RadPanelBar1.Items[0].Expanded == true)
                        Data.add_ee_property_code(ViewState["Employee_Number"].ToString(), "708", "1", ViewState["User_Name"].ToString());
                }

                if (currentStep.Equals(3))
                {
                    Update_lblDocumentation();
                }
                //lblComments4.ToolTip = txtNote.Content;
                //lblComments3.ToolTip = txtNote.Content;
                //setPage(RadWizard1.ActiveStepIndex);
                if (nextStep.Equals(3))
                {
                    string hiddiv = "<script>Javescript:hidfax('0')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "hiddiv", hiddiv);
                }
            }
            catch { }
            //RadWizard1.WizardSteps[3].CssClass = "wizardStepHidden";
        }

        [System.Web.Services.WebMethod]
        public static string SetLifeEvent(string name)
        {
            string session_id = HttpContext.Current.Request.Cookies["Session_ID"].Value.ToString();
            int tabNo = Convert.ToInt32(name);
            if (tabNo < 0)
            {
                tabNo = tabNo*(-1);
                Data.Remove_Document(session_id, tabNo.ToString());
                return "1";
            }

                        
            if (tabNo < 10)
            {
                try
                {
                    switch (tabNo)
                    {
                        case 0:
                            SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", "2481");
                            break;
                        case 1:
                            SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", "2482");
                            break;
                        case 2:
                            SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", "2483");
                            break;
                        case 3:
                            SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", "2484");
                            break;
                        case 4:
                            SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", "2485");
                            break;
                        case 5:
                            SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", "2486");
                            break;
                    }


                    return "0";
                }

                catch { return "0"; }
            }
            else
            {
                string FaxDoc = Data.uploaded_Fax_Doc(SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID"));
                return FaxDoc;
            }

            return "0";
            
        }



        protected void Update_lblLifeEvent(string LE)
        {
            lblLifeEvent.Text = LE;
            lblLifeEvent0.Text = LE;
            lblLifeEvent1.Text = LE;
            lblLifeEvent2.Text = LE;
            //lblLifeEvent3.Text = LE;
            lblLifeEvent4.Text = LE;
        }

        protected void Update_lblEventDate(string LE)
        {
            LE = LE.Replace(" 12:00:00 AM", string.Empty);
            lblEventDate.Text = LE;
            lblEventDate0.Text = LE;
            lblEventDate1.Text = LE;
            lblEventDate2.Text = LE;
            //lblEventDate3.Text = LE;
            lblEventDate4.Text = LE;
            txtNetEffectiveDate.Text = Data.MaxCoverageEffectiveDate(session_id, ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(),
                ViewState["Processing_Year"].ToString(), ViewState["Selected_Employee_Class_Code"].ToString(), ddlItem.SelectedValue, LE);
            //if (txtEffectiveDate.Visible)
            //    txtEffectiveDate.SelectedDate = Convert.ToDateTime(txtNetEffectiveDate.Text);
            //if (ViewState["hasEffective"].ToString().Equals("1"))
            //    if (string.IsNullOrEmpty(txtEffectiveDate.SelectedDate.ToString()))
            //        txtEffectiveDate.SelectedDate = Convert.ToDateTime(txtNetEffectiveDate.Text);
            
            //    txtEffectiveDate.SelectedDate=
        }

        protected void Update_lblDocumentation()
        {
            string FaxDoc = Data.uploaded_Fax_Doc(SQLStatic.Sessions.GetSessionValue(session_id,"LE_EE_ID"));
            string[] items = FaxDoc.Split('~');        
            string LE = items[0];
            if (!string.IsNullOrEmpty(LE))
                LE = items[0]+"....";
            string strTooTip = string.Empty;
            try
            {
                strTooTip = items[1];
            }
            catch { }
            lblDocumentation.Text = LE;
            lblDocumentation0.Text = LE;
            lblDocumentation1.Text = LE;
            lblDocumentation2.Text = LE;
            //lblDocumentation3.Text = LE;
            lblDocumentation4.Text = strTooTip; 

            lblDocumentation.ToolTip = strTooTip;
            lblDocumentation0.ToolTip = strTooTip;
            lblDocumentation1.ToolTip = strTooTip;
            lblDocumentation2.ToolTip = strTooTip;
            //lblDocumentation3.ToolTip = strTooTip;
            //lblDocumentation4.ToolTip = strTooTip;
        }

        protected void Update_lblComments(string LE)
        {
            string strTooTip = string.Empty;
            string strShortLE = LE;
            if (LE.Length > 100)
            {
                strShortLE = LE.Substring(0, 49) + "....";
                strTooTip = LE;
            }
            lblComments.Text = strShortLE;
            lblComments0.Text = strShortLE;
            lblComments1.Text = strShortLE;
            lblComments2.Text = strShortLE;
            //lblComments3.Text = strShortLE;

            lblComments.ToolTip = strTooTip;
            lblComments0.ToolTip = strTooTip;
            lblComments1.ToolTip = strTooTip;
            lblComments2.ToolTip = strTooTip;
            //lblComments3.ToolTip = strTooTip;

            lblComments4.Text = LE;
        }

        protected void btnDisagree_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES", true);
        }

        protected void txtLifeEventDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            //Validate();
            //if (!IsValid)
            //    return;
            //lblEventDate.Text = txtLifeEventDate.SelectedDate.Value.ToShortDateString();
            DataTable tbl = Data.Get_ER_Setup(session_id, ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString(),
                txtLifeEventDate.SelectedDate.Value.ToShortDateString());
            SetEffectiveDateSetup(tbl);
            tbl.Dispose();
            Update_lblEventDate(txtLifeEventDate.SelectedDate.Value.ToShortDateString());
            Data.updatele_ee_session_info_date(session_id, txtLifeEventDate.SelectedDate.Value.ToShortDateString());
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            txtVal.Text = "ABC";
            int i =  RadWizard1.ActiveStep.Index;
            int nextstep = i + 1;
            try
            {
                RadWizard1.WizardSteps[nextstep].Enabled = true;
                RadWizard1.WizardSteps[nextstep].Active = true;
            }
            catch
            { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            int i = RadWizard1.ActiveStep.Index;
            int nextstep = i - 1;
            if (i < 0)
                return;
            try
            {
                RadWizard1.WizardSteps[nextstep].Enabled = true;
                RadWizard1.WizardSteps[nextstep].Active = true;
            }
            catch
            { }
        }

        protected void txtNote_TextChanged(object sender, EventArgs e)
        {
            Update_lblComments(txtNote.Text);
        }

        protected void ShowDocuments(string url)
        {
            RadWindow window1 = new RadWindow();
            window1.NavigateUrl = url;//"ManageDocs.aspx";
            window1.Title = "Tip of the Day";
            window1.IconUrl = "https://www.myenroll.com/images/Template/Buttonbar_RetaBenefitsCenter.png";
            window1.Behaviors = WindowBehaviors.Move;//None
            window1.Attributes.Add("style", "z-indes: 20000");
            window1.VisibleOnPageLoad = true;
            window1.Modal = true;
            //window1.set_visibleTitlebar(false);
            window1.Width = 700;
            window1.Height = 400;
            window1.Left = 0;
            window1.VisibleStatusbar = false;
            window1.Skin = "Bootstrap";
            window1.OnClientClose = "OnClientclose";
            //window1.VisibleTitlebar = false;
            this.form1.Controls.Add(window1);

        }

        protected void ShowMessage()
        {
            RadWindow window1 = new RadWindow();
            window1.NavigateUrl = "EmployerInstruction.aspx";
            window1.Title = "Tip of the Day";
            window1.IconUrl = "https://www.myenroll.com/images/Template/Buttonbar_RetaBenefitsCenter.png";
            window1.Behaviors = WindowBehaviors.Move;//None
            window1.Attributes.Add("style", "z-indes: 20000");
            window1.VisibleOnPageLoad = true;
            window1.Modal = true;
            //window1.set_visibleTitlebar(false);
            window1.Width = 700;
            window1.Height = 400;
            window1.Left = 0;
            window1.VisibleStatusbar = false;
            window1.Skin = "Bootstrap";
            window1.OnClientClose = "OnClientclose";
            //window1.VisibleTitlebar = false;
            this.form1.Controls.Add(window1);

        }

        protected void btnManageDocument_Click(object sender, EventArgs e)
        {
            ShowDocuments("ManageDocs.aspx");            
        }

        protected void btnGotIt_Clicked(object sender, EventArgs e)
        {

        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            RadPanelBar1.Items[0].Expanded = false;
            RadPanelBar1.Items[1].Expanded = true;
        }

        protected void ERInstruction_Click(object sender, EventArgs e)
        {
            ShowDocuments("ManageDocs.aspx");  
           // ShowMessage();
        }

        protected void txtEffectiveDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            Data.updatele_ee_sess_info_Effdate(session_id, txtEffectiveDate.SelectedDate.Value.ToShortDateString());
        }

       
        protected void cbAcknowledgment_Click(object sender, EventArgs e)
        {
            if (cbAcknowledgment.Checked==true)
                txtVal.Text = "abc";
            else
                txtVal.Text = string.Empty;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RadPanelBar1.Items[0].Expanded = true;
        }

       

        

        
        
    }
}