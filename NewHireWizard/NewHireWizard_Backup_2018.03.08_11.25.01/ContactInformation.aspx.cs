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

namespace NewHireWizard
{
    public partial class ContactInformation : System.Web.UI.Page
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
                    objBasTemplate.SetSeatchField(0);
                    objBasTemplate.ShowProcessingYear = true;
                    objBasTemplate.ShowNotes = false;
                    objBasTemplate.ShowFontSizeSelector = false;
                    LblTemplateHeader2.Text = objBasTemplate.Header2();
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
                if (Data.ShowAdditionalInfoPage(ViewState["Selected_Account_Number"].ToString()))
                    TabStrip1.ShowTab(2, true);
                //Fields._Default.Start(Page);
                ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER");
                if (ViewState["Employee_Number"].ToString().Equals("0"))
                {
                    string NoEE = "<script>Javascript:No_EE()</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "NoEE", NoEE);
                    return;
                }
                ViewState["Domain"] = Data.Default_Email_Domain_from_acct((ViewState["Selected_Account_Number"].ToString())).ToUpper();
                CustomValidator1.ErrorMessage = "Whoops! You entered a domain for the work email address (the portion of the email to the right of the '@' symbol) that does not coincide with the employer's required domain., which is @<value>. You can only enter a work email address that uses the '@<value>";
                CustomValidator1.ErrorMessage = CustomValidator1.ErrorMessage.Replace("<value>", ViewState["Domain"].ToString());
                hidDomain.Value = ViewState["Domain"].ToString(); 
                TabStrip1.SetCurrentTab(Request.Path);
                //TabStrip1.SetTabIndex(2);
                FillDropDowns();
                GetDataFromSession();
                try
                {
                    jscriptsFunctions.Utilities.SetHeaderFrame(Page, TabStrip1.TabName(), Data.HeaderText(session_id), "");
                }
                catch { }
                DoStar();
                SetRequired();
            }
            TabStrip1.wPage = Page;
            TabStrip1.CurrentPath = Request.Path;
           // TabStrip1.CheckEnrrollmentKit(ViewState["Selected_Account_Number"].ToString());
        }

        private void SetRequired()
        {
            RequiredFieldValidator10.Visible = Data.master_account_property_accnt(ViewState["Selected_Account_Number"].ToString(), "180").Equals("0");
            Label14.Visible = RequiredFieldValidator10.Visible;
        }

        private void DoStar()
        {
            BasStar.StarFunctionality star = new BasStar.StarFunctionality();
            star.ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            star.SetLabel(this, ViewState["Selected_Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(), Convert.ToInt16(ViewState["User_Group_ID"].ToString()));
            star = null;
        }

        private void FillDropDowns()
        {
            DataTable tbl = Data.States();
            ddlState.Items.Clear();
            ListItem li0 = new ListItem("Select State", "0");
            ddlState.Items.Add(li0);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["state_description"].ToString(), dr["state"].ToString());
                ddlState.Items.Add(li);
            }

            tbl = SQLStatic.CD_Tables.Countries();
            ddlCountry.Items.Clear();
         
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["name"].ToString(), dr["code"].ToString());
                li.Selected = dr["code"].ToString().Equals("USA");
                ddlCountry.Items.Add(li);
            }
            tbl.Dispose();

        }


        private bool GetDataFromSession()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                DataTable tbl = Data.GetContactInformation(session_id, conn);
                if (!tbl.Rows.Count.Equals(0))
                {
                    foreach (ListItem li in ddlCountry.Items)
                        li.Selected = false;
                    ddlCountry.Items.FindByValue(tbl.Rows[0]["country_code"].ToString()).Selected = true;
                    txtprovince.Text = tbl.Rows[0]["province"].ToString();
                    txtforeign_phone_number.Text = tbl.Rows[0]["foreign_phone_number"].ToString();
                    txtAddressLine1.Text = tbl.Rows[0]["address1"].ToString();
                    txtAddressLine2.Text = tbl.Rows[0]["address2"].ToString();
                    txtCity.Text = tbl.Rows[0]["city"].ToString();
                    string strState = tbl.Rows[0]["state"].ToString();
                    txtZipCode.Text = tbl.Rows[0]["zip_code"].ToString();
                    txtWorkPhone.Text = tbl.Rows[0]["office_number"].ToString();
                    txtExtension.Text = tbl.Rows[0]["work_phone_ext"].ToString();
                    txtHomePhone.Text = tbl.Rows[0]["phone_number"].ToString();
                    txtMobilePhone.Text = tbl.Rows[0]["mobile_number"].ToString();
                    txtFaxNumber.Text = tbl.Rows[0]["fax_number"].ToString();
                    txtEmailWork.Text = tbl.Rows[0]["work_email"].ToString();
                    txtAlternateEmail.Text = tbl.Rows[0]["personal_email"].ToString();
                    if (!string.IsNullOrEmpty(strState))
                        ddlState.Items.FindByValue(strState).Selected = true;
                }
                tbl.Dispose();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            ddlCountry_SelectedIndexChanged(null, null);
            return true;
        }

        private bool DoSave()
        {
            if (txtEmailWork.Text.ToUpper().Equals(txtAlternateEmail.Text.ToUpper()))
            {
                if (!string.IsNullOrEmpty(txtEmailWork.Text.Trim()))
                {
                    string strError = "<script>alert('Your Work Email and Alternate Email are the same. The Work Email can’t be the same as Alternate Email')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
                    return false;
                }
            }

            Data.SaveContactInformation(session_id, txtAddressLine1.Text, txtAddressLine2.Text, txtCity.Text, ddlState.SelectedValue, txtZipCode.Text, txtWorkPhone.TextWithLiterals,
                txtExtension.Text, txtHomePhone.TextWithLiterals, txtMobilePhone.TextWithLiterals, txtFaxNumber.TextWithLiterals, txtEmailWork.Text, txtAlternateEmail.Text,
                ddlCountry.SelectedValue,txtprovince.Text,txtforeign_phone_number.Text);
            return true;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabStrip1.PreviousURL());
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            if (DoSave())
                Response.Redirect(TabStrip1.NextURL());
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedValue.Equals("USA"))
            {
                txtprovince.Visible = false;
                txtforeign_phone_number.Visible = false;
                ddlState.Visible = true;
                txtWorkPhone.Visible = true;
                txtExtension.Visible = true;
                pnlMobilePhone.Visible = true;
                pnlFaxNumber.Visible = true;
                pnlHomePhone.Visible = true;
                lblWorkPhone.Text = "Work Phone / Ext";
                lblState.Text = "State";
                Label11.Visible = true;
                Label14.Visible = true;
            }
            else
            {
                txtprovince.Visible = true;
                txtforeign_phone_number.Visible = true;
                ddlState.Visible = false;
                txtWorkPhone.Visible = false;
                txtExtension.Visible = false;
                pnlMobilePhone.Visible = false;
                pnlFaxNumber.Visible = false;
                pnlHomePhone.Visible = false;
                lblWorkPhone.Text = "Phone Number";
                lblState.Text = "Province";
                Label11.Visible = false;
                Label14.Visible = false;
            }

            RequiredFieldValidator8.Enabled = ddlState.Visible;
            if (RequiredFieldValidator10.Visible)
                RequiredFieldValidator10.Enabled = txtWorkPhone.Visible;
        }

        protected void GoodDomain(object source, ServerValidateEventArgs args)
        {
            if (ViewState["Domain"].ToString().Length.Equals(0))
            {
                args.IsValid = true;
                return;
            }
            string stsDomain = txtEmailWork.Text.Substring(txtEmailWork.Text.IndexOf("@") + 1);
            args.IsValid = (stsDomain.ToUpper().Equals(ViewState["Domain"].ToString()));
        }
    }
}
