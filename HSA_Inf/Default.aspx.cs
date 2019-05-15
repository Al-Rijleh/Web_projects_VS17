using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Reflection;

namespace HSA_Inf
{
    public partial class Default : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Session_ID"] == null)
                Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", true);
            if (Data.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
                Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out" + "&backurl=0", true);
            session_id = Request.Cookies["Session_ID"].Value.ToString();            
            #region BasTemplate
            if (!IsPostBack)
            {
                Template.BasTemplate objBasTemplate = new Template.BasTemplate();
                try
                {                    
                    string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, true);
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
                    ViewState["Page"] = objBasTemplate.strPageId;
                   
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
                if (ViewState["Selected_Account_Number"].ToString().StartsWith("0011303"))
                {
                    Response.Redirect("OtherHSAPage.aspx", true);
                    return;
                }
                if ((ViewState["Employee_Number"] == null) || (ViewState["Employee_Number"].ToString().Equals("0")))
                {
                    Response.Redirect("/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/web_projects/HSA_Inf/Default.aspx?SkipCheck=YES" );
                    return;
                }

                if (!SQLStatic.Sessions.GetSessionValue(session_id, "FromOE").Equals("1"))
                {
                    if (Data.Have_HSA(session_id, ViewState["Selected_Account_Number"].ToString(), "", "").Equals("0"))
                    {

                        string strClose = "<script>Javascript:closepage2();</script>";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                        return;
                    }
                }
                dvBebefiries.Visible = false;
                dveditaccnt.Visible = Data.CanAddEditHSAacct(session_id).Equals("1");
                SetValues();
                setRequired();
                lblBeneficiaryError.Visible = false;
                lblIncorrectPassword.Visible = false;
            }

            if (!string.IsNullOrEmpty(hidSaveAccount.Value))
            {
                hidSaveAccount.Value = string.Empty;
                SaveBankAccount();
                //Button1_Click1(null, null);
            }
        }

        private void setRequired()
        {
            required(lblHomePhone);
            required(lblERPhone);
            required(lblLengthOfEmployment);
            required(lblDriversLicenseIssuingState);
            required(lblDriverLicenseNo);
            required(lblDriversLicenseEffectiveDate);
            required(lblDriversLicenseExpirationDate);
            required(lblYourOccupation);
            required(lblHSAInformationEeContTitle);         
        }

        private void FormatDocTitle(RadDock doc, string title)
        {
            doc.Title = "<span style='ont-size: 10pt; color:#964B4B; font-weight:bolder;'>"+title+"</span>";
        }

        private void closeForm()
        {
            ViewState["FromOE"] = SQLStatic.Sessions.GetSessionValue(session_id, "FromOE");
            SQLStatic.Sessions.SetSessionValue(session_id, "FromOE", "0");

            //if (!ViewState["FromOE"].ToString().Equals("1"))
            if (!string.IsNullOrEmpty(lblHSA_Account_NumberValues.Text))
            {
                if (Data.EE_Has_HSA(session_id, ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()).ToString().Equals("0"))
                {
                    string strClose = "<script>Javascript:closepage();</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                    return;
                }
                rdBank.Collapsed = true;
                rdHSABankingInformation.Collapsed = true;
                rdHSABeneficiaryInformation.Collapsed = true;
                rdHSAInformation.Collapsed = false;
                rdBank.Enabled = false;
                rdHSABankingInformation.Enabled = false;
                rdHSABeneficiaryInformation.Enabled = false;
                rdBank.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                rdHSABankingInformation.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                rdHSABeneficiaryInformation.DefaultCommands = Telerik.Web.UI.Dock.DefaultCommands.None;
                
            }
        }

        private void SetValues()
        {
            
           


            lbHSABeneficiaryInformation.Text = Data.HSA_Beneficiary_Information("");

             FormatDocTitle(rdHSABeneficiaryInformation,"HSA Beneficiary Information");
             FormatDocTitle(rdHSABankingInformation,"HSA Banking Information");
             FormatDocTitle(rdBank, "Additional Information Required by Gulf Cost Bank");
             FormatDocTitle(rdEmployeeInfo,"Employee");
             FormatDocTitle(rdHSAInformation,"HSA Information");

            

            DataTable tbl = Data.HSA_Employee_Employer_Info(ViewState["Employee_Number"].ToString());
            lblName.Text = tbl.Rows[0]["Employee_Info"].ToString();
            lblEmployer.Text = tbl.Rows[0]["Employer_Info"].ToString();
            lblHSA_Account_NumberValues.Text = tbl.Rows[0]["hsa_account_number"].ToString();
            txtBankAccountNumber.Text = lblHSA_Account_NumberValues.Text;
            closeForm();
            tbl.Dispose();


            tbl = Data.HSA_Information(session_id);
            lblHSAInformationSec1.Text = tbl.Rows[0]["sec1"].ToString();
            lblHSAInformationSec2.Text = tbl.Rows[0]["sec2"].ToString();
            lblHSAInformationSec3.Text = tbl.Rows[0]["sec3"].ToString();

            // States list
            tbl = SQLStatic.CD_Tables.States();
            RadComboBoxItem item = new RadComboBoxItem("-- Select --", "");
            ddlLicState.Items.Add(item);
            foreach (DataRow dr in tbl.Rows)
            {
                //RadComboBoxItem itema = new RadComboBoxItem(dr["state_description"].ToString(), dr["state"].ToString());
                RadComboBoxItem itema = new RadComboBoxItem(dr["state_description"].ToString(), dr["state_description"].ToString());
                ddlLicState.Items.Add(itema);
            }

            // Conties List
            tbl = SQLStatic.CD_Tables.Countries();
            RadComboBoxItem itemc2 = new RadComboBoxItem("-- Select --", "");
            ddlCountry.Items.Add(itemc2);
            foreach (DataRow dr in tbl.Rows)
            {
                //RadComboBoxItem itema = new RadComboBoxItem(dr["name"].ToString(), dr["code"].ToString());
                RadComboBoxItem itema = new RadComboBoxItem(dr["name"].ToString(), dr["name"].ToString());
                ddlCountry.Items.Add(itema);
            }

            // Conties List
            tbl = SQLStatic.CD_Tables.Countries();
            RadComboBoxItem itemc1 = new RadComboBoxItem("-- Select --", "");
            ddloreignCountry.Items.Add(itemc1);
            foreach (DataRow dr in tbl.Rows)
            {
                RadComboBoxItem itema = new RadComboBoxItem(dr["name"].ToString(), dr["name"].ToString());
                ddloreignCountry.Items.Add(itema);
            }


            // Conties List
            tbl = SQLStatic.CD_Tables.Countries();
            RadComboBoxItem itemc3 = new RadComboBoxItem("-- Select --", "");
            ddlFamilyOffice.Items.Add(itemc3);
            foreach (DataRow dr in tbl.Rows)
            {
                RadComboBoxItem itema = new RadComboBoxItem(dr["name"].ToString(), dr["name"].ToString());
                ddlFamilyOffice.Items.Add(itema);
            }

            // Limits
            tbl = Data.HSA_Values(session_id, ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());
            if (tbl.Rows.Count.Equals(1))
            {
                ViewState["Annual_er_contribution"] = tbl.Rows[0]["er"].ToString();
                lblHSAInformationErContValue.Text = String.Format("{0:C}",Convert.ToDouble(tbl.Rows[0]["monthly_er_contribution"].ToString()));
                txtHSAInformationEeContTitle.Text = tbl.Rows[0]["monthly_ee_election"].ToString();
                hidPayDate.Value = tbl.Rows[0]["payCount"].ToString();
                hidErCont.Value = tbl.Rows[0]["monthly_er_contribution"].ToString();
                txtTOTALMONTHLYCONTRIBUTIONTValue.Text = String.Format("{0:C}", Convert.ToDouble(tbl.Rows[0]["monthly_er_contribution"].ToString()) +
                                                         Convert.ToDouble(tbl.Rows[0]["monthly_ee_election"].ToString()));

                if (Convert.ToDouble(tbl.Rows[0]["minimum_contrib_amount"].ToString()) > Convert.ToDouble(tbl.Rows[0]["monthly_maximum_contrib_amount"].ToString()))
                {
                    string strClose = "<script>Javascript:closepage();</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                    return;
                }
                try
                {
                    txtHSAInformationEeContTitle.MinValue = Convert.ToDouble(tbl.Rows[0]["minimum_contrib_amount"].ToString()); 
                    txtHSAInformationEeContTitle.MaxValue = Convert.ToDouble(tbl.Rows[0]["monthly_maximum_contrib_amount"].ToString()) + 0.01;
                }
                catch
                {
                    string strClose = "<script>Javascript:closepage();</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                    return;
                }
                lblMaxSelection.Text = "<b>Maximum =</b> "+ String.Format("{0:C}",Convert.ToDouble(tbl.Rows[0]["monthly_maximum_contrib_amount"].ToString()));
            }

            
            // Existing Employee Info
            tbl = Data.Get_Answers(session_id, ViewState["Employee_Number"].ToString());
            if (!tbl.Rows.Count.Equals(0))
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    switch (dr["answer_type"].ToString())
                    {
                        case "1"://RadMaskedTextBox
                            process_RadMaskedTextBox(dr);
                            break;
                        case "2"://RadNumericTextBox
                            process_RadNumericTextBox(dr);
                            break;
                        case "3"://RadTextBox
                            process_RadTextBox(dr);
                            break;
                        case "4"://RadDatePicker
                            process_RadDatePicker(dr);
                            break;
                        case "5"://RadComboBox
                            process_RadComboBox(dr);
                            break;
                        case "6"://RadComboBox
                            process_TextBox(dr);
                            break;
                        case "20"://RadioButtonList
                            process_RadioButtonList(dr);
                            break;
                    }
                }                   
            }
            rblcitzenofForeignCountry_SelectedIndexChanged(null,null);
            rblforeignoffice_SelectedIndexChanged(null, null);
            rblFamilyOffice_SelectedIndexChanged(null, null);
        }

        private void process_RadMaskedTextBox(DataRow dr)
        {
            RadMaskedTextBox txt = Bas_Utility.Utilities.GetRadMaskedTextBox(Page, dr["answer_control_name"].ToString());
            txt.Text = dr["answer"].ToString();
        }

        private void process_RadNumericTextBox(DataRow dr)
        {
            RadNumericTextBox txt = Bas_Utility.Utilities.GetRadNumericTextBox(Page, dr["answer_control_name"].ToString());
            if (txt != null)
                txt.Text = dr["answer"].ToString();
        }

        private void process_RadTextBox(DataRow dr)
        {
            RadTextBox txt = Bas_Utility.Utilities.GetRadTextBox(Page, dr["answer_control_name"].ToString());
            txt.Text = dr["answer"].ToString();
        }

        private void process_TextBox(DataRow dr)
        {
            TextBox txt = Bas_Utility.Utilities.GetTextBox(Page, dr["answer_control_name"].ToString());
            txt.Text = dr["answer"].ToString();
        }

        private void process_RadDatePicker(DataRow dr)
        {
            RadDatePicker txt = Bas_Utility.Utilities.GetRadDatePicker(Page, dr["answer_control_name"].ToString());
            txt.SelectedDate = Convert.ToDateTime(dr["answer"].ToString());
        }

        private void process_RadComboBox(DataRow dr)
        {
            RadComboBox txt = Bas_Utility.Utilities.GetRadComboBox(Page, dr["answer_control_name"].ToString());
            txt.Items.FindItemByValue(dr["answer"].ToString()).Selected = true;
        }

        private void process_RadioButtonList(DataRow dr)
        {
            RadioButtonList txt = Bas_Utility.Utilities.GetRadioButtonList(Page, dr["answer_control_name"].ToString());
            txt.SelectedValue = dr["answer"].ToString();

            //string methodName = txt.ID + "_SelectedIndexChanged";
            //MethodInfo mi = this.GetType().GetMethod(methodName);
            //mi.Invoke(null, null);
        }

        private void required(Label lbl)
        {
            lbl.Text = lbl.Text + "<span style='color: #ff0000;'>*</span>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RadDock doc = (RadDock)Page.FindControl("rdEmployeeInfo");
            doc.Collapsed = false;
            TextBox txt = Bas_Utility.Utilities.GetTextBox(Page, "txtTest");               
            txt.Focus();
        }

        protected void btnNextAdditinalIno_Click(object sender, EventArgs e)
        {
            rdHSABankingInformation.Collapsed = false;            
            txtYourOccupation.Focus();
        }

        protected void rblcitzenofForeignCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblcitzenofForeignCountry.SelectedValue.Equals("Y"))
            {
                required(lblWhatCountry);
                req9.Enabled = true;
            }
            else
            {
                lblWhatCountry.Text = lblWhatCountry.Text.Replace("*","");
                req9.Enabled = false;
                ddlCountry.SelectedIndex = 0;
               
            }
            ddlCountry.Enabled = req9.Enabled;
            //RadioButtonList rbl = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblcitzenofForeignCountry");
            //rbl.Focus();
        }

        protected void rblforeignoffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblforeignoffice.SelectedValue.Equals("Y"))
            {
                required(lblWhatPosition);
                required(lbloreignCountry);
                req10.Enabled = true;
                req11.Enabled = true;
                             
            }
            else
            {
                lblWhatPosition.Text = lblWhatPosition.Text.Replace("*", "");
                lbloreignCountry.Text = lbloreignCountry.Text.Replace("*", "");
                req10.Enabled = false;
                req11.Enabled = false;
                txtWhatPosition.Text = string.Empty;
                ddloreignCountry.SelectedIndex = 0;
            }
            txtWhatPosition.Enabled = req11.Enabled ;
            ddloreignCountry.Enabled = req11.Enabled;
        }

        protected void RemoveStar(Label lbl)
        {
            lbl.Text = lbl.Text.Replace("*", "");
        }

        protected void rblFamilyOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFamilyOffice.SelectedValue.Equals("Y"))
            {
                req12.Enabled = true;
                req13.Enabled = true;
                req14.Enabled = true;
                req15.Enabled = true;
                required(lblFamilyOfficeFirstName);
                required(lblFamilyOfficeLastName);
                required(lblFamilyOfficePosition);
                required(lblFamilyOfficeCountry);
            }
            else
            {
                req12.Enabled = false;
                req13.Enabled = false; 
                req14.Enabled = false;
                req15.Enabled = false;
                RemoveStar(lblFamilyOfficeFirstName);
                RemoveStar(lblFamilyOfficeLastName);
                RemoveStar(lblFamilyOfficePosition);
                RemoveStar(lblFamilyOfficeCountry);
                txtFamilyOfficeFirstName.Text = string.Empty;
                txtFamilyOfficeLastName.Text = string.Empty;
                txtFamilyOffice.Text = string.Empty;
                ddlFamilyOffice.SelectedIndex =0;
            }
            txtFamilyOfficeFirstName.Enabled = req12.Enabled;
            txtFamilyOfficeLastName.Enabled = req12.Enabled;
            txtFamilyOffice.Enabled = req12.Enabled;
            ddlFamilyOffice.Enabled = req12.Enabled;
        }

        protected void btnHSABankingInformation_Click(object sender, EventArgs e)
        {
            rdHSABeneficiaryInformation.Collapsed = false;
            btnHSABeneficiaryInformation.Focus();
        }

        protected void disableAllRequiredValidators( Control oMe)
        {
           
            int cnt = oMe.Controls.Count;
            
            for (int i = 0; i < cnt; i++)
            {
                string s = oMe.Controls[i].GetType().ToString();
                if ((oMe.Controls[i].GetType().ToString() ==
                    "System.Web.UI.WebControls.RequiredFieldValidator"))
                {
                    ((System.Web.UI.WebControls.RequiredFieldValidator)oMe.Controls[i]).Enabled = false;
                }
                else
                    if (oMe.Controls[i].HasControls())
                    {
                        disableAllRequiredValidators(oMe.Controls[i]);
                        
                    }
                    
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ViewState["InOE"] = "0";
            if (!string.IsNullOrEmpty(txtBankAccountNumber.Text))            
                disableAllRequiredValidators(Page);

            string RecIDfromHDR = string.Empty;
            lblIncorrectPassword.Visible = Data.Good_Password(ViewState["User_Name"].ToString(), txtPassword.Text).Equals("0");
            if (lblIncorrectPassword.Visible)
            {
                txtPassword.Focus();
                return;
            }

            if ((ViewState["FromOE"].ToString().Equals("1"))||
                ((string.IsNullOrEmpty(lblHSA_Account_NumberValues.Text))))// coming from OE or HSA Account# is blank
            {
                if (string.IsNullOrEmpty(txtBankAccountNumber.Text))
                    lblBeneficiaryError.Visible = !Data.Has_Beneficiaries(session_id, ViewState["Employee_Number"].ToString()).Equals("1");
                else
                    lblBeneficiaryError.Visible = false;
                //lblIncorrectPassword.Visible = Data.Good_Password(ViewState["User_Name"].ToString(), txtPassword.Text).Equals("0");
                Validate();
                if ((!IsValid) || (lblBeneficiaryError.Visible) || (lblIncorrectPassword.Visible))
                {
                    rdHSABeneficiaryInformation.Collapsed = false;
                    rdHSABankingInformation.Collapsed = false;
                    rdBank.Collapsed = false;
                    rdEmployeeInfo.Collapsed = false;
                    rdHSAInformation.Collapsed = false;
                    if (lblIncorrectPassword.Visible)
                        btnSave.Focus();
                    if (lblBeneficiaryError.Visible)
                        btnGoToBebefiries.Focus();
                    return;
                }
                RecIDfromHDR = Data.Create_New_EE(session_id, ViewState["Employee_Number"].ToString(), ViewState["User_Name"].ToString());
            }
        
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            if (!string.IsNullOrEmpty(txtBankAccountNumber.Text))
            {
                disableAllRequiredValidators(Page);
                if (ViewState["FromOE"].ToString().Equals("1"))
                {
                    Data.SaveStatusCoverage(session_id, conn);
                    ViewState["FromOE"] = "0";
                    ViewState["InOE"] = "1";
                }

            }
            try
            {
                if (txtHSAInformationEeContTitle.Text.Equals("0"))
                {
                    txtHSAInformationEeContTitle.Text="0.0000001";
                }
                if ((ViewState["FromOE"].ToString().Equals("1")) ||
                ((string.IsNullOrEmpty(lblHSA_Account_NumberValues.Text))))// coming from OE or HSA Account# is blank
                {

                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtHomePhone.ID, txtHomePhone.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtERPhone.ID, txtERPhone.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtLengthOfEmployment.ID, txtLengthOfEmployment.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, ddlLicState.ID, ddlLicState.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtDriverLicenseNo.ID, txtDriverLicenseNo.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtDriversLicenseEffectiveDate.ID, txtDriversLicenseEffectiveDate.SelectedDate.Value.ToShortDateString(), ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtDriversLicenseExpirationDate.ID, txtDriversLicenseExpirationDate.SelectedDate.Value.ToShortDateString(), ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtYourOccupation.ID, txtYourOccupation.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, rblcitzenofForeignCountry.ID, rblcitzenofForeignCountry.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, ddlCountry.ID, ddlCountry.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, rblforeignoffice.ID, rblforeignoffice.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtWhatPosition.ID, txtWhatPosition.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, ddloreignCountry.ID, ddloreignCountry.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, rblFamilyOffice.ID, rblFamilyOffice.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtFamilyOfficeFirstName.ID, txtFamilyOfficeFirstName.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtFamilyOfficeLastName.ID, txtFamilyOfficeLastName.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtFamilyOffice.ID, txtFamilyOffice.Text, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, ddlFamilyOffice.ID, ddlFamilyOffice.SelectedValue, ViewState["User_Name"].ToString(), conn);
                    Data.save_one_control(session_id, ViewState["Employee_Number"].ToString(), RecIDfromHDR, txtHSAInformationEeContTitle.ID, txtHSAInformationEeContTitle.Text, ViewState["User_Name"].ToString(), conn);

                    if (ViewState["FromOE"].ToString().Equals("1"))
                        Data.SaveStatusCoverage(session_id, conn);

                    string strCatCode = SQLStatic.Sessions.GetSessionValue(session_id, "HSACATEGORY_CODE", conn);
                    string strCatPlan = SQLStatic.Sessions.GetSessionValue(session_id, "HSACATEGORY_PLAN", conn);
                    SQLStatic.Sessions.SetSessionValue(session_id, "Category_Code", strCatCode, conn);
                    SQLStatic.Sessions.SetSessionValue(session_id, "Category_Plan", strCatPlan, conn);
                    if ((ViewState["FromOE"].ToString().Equals("1"))||(ViewState["InOE"].ToString().Equals("1")))
                        Data.saveHSANammount(session_id, ViewState["Annual_er_contribution"].ToString(), (txtHSAInformationEeContTitle.Value).ToString(),"1", conn);
                    else
                        Data.saveHSANammount(session_id, ViewState["Annual_er_contribution"].ToString(), (txtHSAInformationEeContTitle.Value).ToString(), "0", conn);
                }
                else
                    if ((ViewState["FromOE"].ToString().Equals("1")) || (ViewState["InOE"].ToString().Equals("1")))
                        Data.saveHSANammount(session_id, ViewState["Annual_er_contribution"].ToString(), (txtHSAInformationEeContTitle.Value).ToString(), "1", conn);
                    else
                        Data.saveHSANammount(session_id, ViewState["Annual_er_contribution"].ToString(), (txtHSAInformationEeContTitle.Value).ToString(), "0", conn);
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

            if (ViewState["InOE"].ToString().Equals("1"))
            {
                ViewState["FromOE"] = "1";
                ViewState["InOE"] = "0";
            }
           
            btnCancel_Click(null, null);
        }

        protected void btnHSABeneficiaryInformation_Click(object sender, EventArgs e)
        {
            rdHSAInformation.Collapsed = false;
            txtHSAInformationEeContTitle.Focus();
        }

        protected void OpenBeneficeir()
        {
            iBeneficiaries.Attributes["src"] = "/Web_Projects/BeneficiaryNew/BeneficiaryHome.aspx?SkipCheck=YES";
            dvBebefiries.Visible = true;
            iBeneficiaries.Visible = true;
            //RadWindow window1 = new RadWindow();

            //window1.NavigateUrl = "Beneficiaries.aspx";
            //window1.VisibleOnPageLoad = true;
            //window1.Modal = true;
            //window1.Width = 650;
            //window1.Height = 530;
            //window1.VisibleStatusbar = false;
            //window1.VisibleTitlebar = false;
            //window1.OnClientClose = "OnClientclose";
            //this.Form.Controls.Add(window1);
            //return;
        }

        protected void btnGoToBebefiries_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(session_id, "HSACateCode", "SPN-HSA");
            SQLStatic.Sessions.SetSessionValue(session_id, "HSACatePlan", "001");

            OpenBeneficeir();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (ViewState["FromOE"].ToString().Equals("1"))
            {
                string strClose = "<script>Javascript:closeWindow(20);</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
            }
            else
                Response.Redirect("/WEB_PROJECTS/DEMOGRAPHICSPAGE/DEFAULT.ASPX?SkipCheck=YES", true);
        }

        protected void txtDriversLicenseEffectiveDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            txtDriversLicenseExpirationDate.MinDate = txtDriversLicenseEffectiveDate.SelectedDate.Value;
            lblMinDate.Text = "<b>Minimum Date:</B> "+ txtDriversLicenseEffectiveDate.SelectedDate.Value.ToShortDateString();
        }

        protected void SaveBankAccount()
        {
            Data.SaveAccountNumber(ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(), txtBankAccountNumber.Text, ViewState["User_Name"].ToString());
            lblHSA_Account_NumberValues.Text = txtBankAccountNumber.Text;
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Data.SaveAccountNumber(ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(), txtBankAccountNumber.Text, ViewState["User_Name"].ToString());
            lblHSA_Account_NumberValues.Text = txtBankAccountNumber.Text;
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void btnDomeBenefit_Click(object sender, EventArgs e)
        {
            iBeneficiaries.Attributes["src"] = "";
            dvBebefiries.Visible = false;
            iBeneficiaries.Visible = false;
        }

        
    }
}