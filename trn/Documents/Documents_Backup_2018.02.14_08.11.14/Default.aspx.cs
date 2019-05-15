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

namespace Documents
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region BasTemplate
            if (!IsPostBack)
            {
                Template.BasTemplate objBasTemplate = new Template.BasTemplate();
                try
                {
                    if (Request.Cookies["Session_ID"] == null)
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", false);
                    string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, true);
                    if (strResult != "")
                    {
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult, false);
                        return;
                    }
                    objBasTemplate.SetSeatchField(0);
                    objBasTemplate.ShowNotes = false;
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
                    // Wizard
                    string strpnlXML = objBasTemplate.PanelXML();
                    if (strpnlXML != "")
                    {
                        if (strpnlXML.IndexOf("Error:") != -1)
                        {
                            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strpnlXML, true);
                            return;
                        }
                        ViewState["CurrGrp"] = objBasTemplate.Wizard_Value("CurrGrp");
                        ViewState["CurrGrpTtl"] = objBasTemplate.Wizard_Value("CurrGrpTtl");
                        ViewState["CurrGrpUrl"] = objBasTemplate.Wizard_Value("CurrGrpUrl");
                        ViewState["CurrStp"] = objBasTemplate.Wizard_Value("CurrStp");
                        ViewState["CurrStpTtl"] = objBasTemplate.Wizard_Value("CurrStpTtl");
                        ViewState["CurrStpUrl"] = objBasTemplate.Wizard_Value("CurrStpUrl");
                        ViewState["Is_Step_Completed"] = objBasTemplate.Wizard_Value("Is_Step_Completed");
                        ViewState["NextGrp"] = objBasTemplate.Wizard_Value("NextGrp");
                        ViewState["NextGrpTtl"] = objBasTemplate.Wizard_Value("NextGrpTtl");
                        ViewState["NextGrpUrl"] = objBasTemplate.Wizard_Value("NextGrpUrl");
                        ViewState["NextStp"] = objBasTemplate.Wizard_Value("NextStp");
                        ViewState["NextStpTtl"] = objBasTemplate.Wizard_Value("NextStpTtl");
                        ViewState["NextStpUrl"] = objBasTemplate.Wizard_Value("NextStpUrl");
                        ViewState["NoGrp"] = objBasTemplate.Wizard_Value("NoGrp");
                        ViewState["NoStpInGrp"] = objBasTemplate.Wizard_Value("NoStpInGrp");
                        ViewState["PrvGrp"] = objBasTemplate.Wizard_Value("PrvGrp");
                        ViewState["PrvGrpTtl"] = objBasTemplate.Wizard_Value("PrvGrpTtl");
                        ViewState["PrvGrpUrl"] = objBasTemplate.Wizard_Value("PrvGrpUrl");
                        ViewState["PrvStp"] = objBasTemplate.Wizard_Value("PrvStp");
                        ViewState["PrvStpTtl"] = objBasTemplate.Wizard_Value("PrvStpTtl");
                        ViewState["PrvStpUrl"] = objBasTemplate.Wizard_Value("PrvStpUrl");
                    }
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
            ProcessCommad();
            if (!string.IsNullOrEmpty(hidCommand.Value))
            {
                if (hidCommand.Value.Equals("DoLoad"))
                {
                    hidCommand.Value = string.Empty;
                    LoadImage();
                    return;
                }
                if (hidCommand.Value.Equals("DoSave"))
                {
                    hidCommand.Value = string.Empty;
                    //btnSave_Click(null, null);
                    DoSave();
                    return;
                }
            }
            btnLoad.Attributes.Add("onclick", "Do_Load()");
            btnSave.Attributes.Add("onclick", "Do_Save()");
            if (!IsPostBack)
            {
                
                ViewState["Employee_Number"] = Data.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(), Request.Cookies["Session_ID"].Value.ToString());
                Bas_Utility.Utilities.SetValidators(this.Page);
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    ViewState["Book"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "BookRequest", conn);
                    ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Request_Record_ID", conn);
                    ViewState["AppStatus"] = Data.ApplicationStatus(ViewState["Request_Record_ID"].ToString());
                    ViewState["Product_Code"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Product_Code", conn);
                    lblBalance.Text = Data.AvailableAmount(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), conn);
                    lblCourseTitle.Text = Data.CourseName(ViewState["Request_Record_ID"].ToString(), conn);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                RadTabStrip1.Tabs[0].Selected = true;
                RadTabStrip1_TabClick(null, null);
                SetHeaderInformation();
                Data.FillBudgetYears(ddlBudgetYear, lblBalance, ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());
                ProcessesStarFunctionality();
                SetupWizardMenu();               
            }
        }

        private void ProcessCommad()
        {
            //if (!string.IsNullOrEmpty(hidCommand.Value))
            //{
            //    if (hidCommand.Value == "Upload")
            //    {
            //        hidCommand.Value = "";
            //        LoadImage();
            //    }
            //}
        }

        private void SetHeaderInformation()
        {
            ViewState["Account_Number"] = Data.GetAccountNumber(ViewState["Employee_Number"].ToString());
            string parPtemplate = Data.SetHeader(Page);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "parPtemplate", parPtemplate);
        }

        private void ProcessesStarFunctionality()
        {
            BasStar2009.StarFunctionality star = new BasStar2009.StarFunctionality();
            star.SetLabel(this, ViewState["Account_Number"].ToString(), "N", ViewState["User_Name"].ToString(),
                Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
            star = null;
        }

        private void SetupWizardMenu()
        {
            string retResult = "";
            string xml = Data.WizardMenuXML(Request.Cookies["Session_ID"].Value.ToString(), Request.Path, ViewState["Request_Record_ID"].ToString(), ref retResult);
            if (retResult != "")
            {
                lblWizardError.Text = retResult;
                return;
            }
            UltimateMenu1.MenuSourceXml = xml;
            UltimateMenu1.DataBind();
        }

        protected void ddlBudgetYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBalance.Text = Data.FormatedRemainingAmount(ddlBudgetYear.SelectedItem, ViewState["Employee_Number"].ToString());
        }

        protected void LoadImage()
        {
            HttpPostedFile TheFile = FileUpload1.PostedFile;
            int intFileLen = TheFile.ContentLength;
            string strContantType = TheFile.ContentType;
            string strFileName = TheFile.FileName;
            if (strFileName == "")
            {
                string radalertscript = "<script language='javascript'> Sys.Application.add_load(function(){radalert('You must select a file first!', 260, 120);})</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
                return;
            }
            lblFileName.Text = strFileName;
            strFileName = strFileName.Substring(strFileName.LastIndexOf(@"\") + 1);
            byte[] bTheData = new byte[intFileLen];
            TheFile.InputStream.Read(bTheData, 0, intFileLen);
            SQLStatic.Sessions.SetBLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Image", bTheData);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Image_Length", intFileLen.ToString());
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Image_Type", strContantType);
            string strViewImage = "<script>window.open('ShowFile.aspx','_blank');</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strViewImage", strViewImage);

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/trn/PLA/SelectApp.aspx", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["PrvStpUrl"].ToString());
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["NextStpUrl"].ToString());
        }

        protected void DoSave()
        {
            Validate();
            if (!IsValid)
                return;
            if ((lblFileName.Text == "Not Selected")&&(RadTabStrip1.SelectedIndex ==0))
            {
                string radalertscript = "<script language='javascript'> Sys.Application.add_load(function(){radalert('You must select a file first!', 260, 120);})</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
                return;
            }
            ViewState["return_id"] = Data.SaveDocument(Request.Cookies["Session_ID"].Value.ToString(), ViewState["Request_Record_ID"].ToString(), ViewState["Employee_Number"].ToString(), txtDocumentName.Text, txtDescription.Text,(RadTabStrip1.SelectedIndex+1).ToString(), ViewState["User_Name"].ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
            string radalertscript = "<script language='javascript'> Sys.Application.add_load(function(){radalert('Document Saved Successfully!', 260, 120);})</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
            txtDescription.Text = "";
            txtDocumentName.Text = "";
            lblFileName.Text = "Not Selected";
            return;
        }

        protected void btnViewDocument_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewDocument.aspx?Back=" + Request.Path, true);
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            pnlImage.Visible = false;
            pnlFax.Visible = false;
            pnlHand.Visible = false;
            pnlImage.Visible = RadTabStrip1.SelectedIndex == 0;
            pnlFax.Visible = RadTabStrip1.SelectedIndex == 1;
            pnlHand.Visible = RadTabStrip1.SelectedIndex == 2;
            btnSave.Enabled = true;
            btnSave.Visible = true;
            lblVerifyCheckBox.Visible = false;
            if (RadTabStrip1.SelectedIndex == 1)
                btnSave.Visible = false;
            if (RadTabStrip1.SelectedIndex == 2)
            {
                if (!cbVerify.Checked)
                {
                    btnSave.Enabled = false;
                    lblVerifyCheckBox.Visible = true;
                }
            }
        }

        protected void btnCoverPage_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            Response.Redirect("/web_projects/trn/PLAViewFax/Default.aspx?id=" + ViewState["return_id"].ToString(), true);
        }

        protected void cbVerify_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            lblVerifyCheckBox.Visible = false;
            if (!cbVerify.Checked)
            {
                btnSave.Enabled = false;
                lblVerifyCheckBox.Visible = true;
            }        
        }
       
       

    }
}
