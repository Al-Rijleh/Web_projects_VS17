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
    public partial class UploadPLAFax : System.Web.UI.Page
    {
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
                    objBasTemplate.SetSeatchField(0);
                    objBasTemplate.ShowFontSizeSelector = false;
                    objBasTemplate.ShowNotes = false;
                    objBasTemplate.ShowProcessingYear = true;
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
            if(!IsPostBack)
            {
                hide(true);
                SetHeaderInformation();
                string strUser = SQLStatic.EmployeeData.employee_name_from_log_user_id(ViewState["User_Name"].ToString());
                Template.BASPtemplate.SetHeader2ndLine(Page,"User:&nbsp;&nbsp;"+strUser);
                Template.BASPtemplate.SetHeader3rdLine(Page,"&nbsp;");
            }
        }

        private void SetHeaderInformation()
        {           
            string parPtemplate = Data.SetHeader(Page);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "parPtemplate", parPtemplate);
        }

        private void hide(bool what)
        {
            dvAppName.Visible = !what;
            dvDescription.Visible = !what;
            pnlImage.Visible = !what;
            dvbtn.Visible = !what;
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

        protected void DoSave()
        {
            Validate();
            if (!IsValid)
                return;
            if (lblFileName.Text == "Not Selected") 
            {
                string radalertscript = "<script language='javascript'> Sys.Application.add_load(function(){radalert('You must select a file first!', 260, 120);})</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
                return;
            }
            Data.SaveDocument(Request.Cookies["Session_ID"].Value.ToString(), txtRecordID.Text);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
            string radalertscript = "<script language='javascript'> Sys.Application.add_load(function(){radalert('Document Saved Successfully!', 260, 120);})</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
            lblFileName.Text = "Not Selected";
            txtRecordID.Text = "";
            txtHederID.Text = "";
            hide(true);
            return;
        }

        protected void btnRetriveRecord_Click(object sender, EventArgs e)
        {
            DataTable tbl = Data.GetDocumentNameDescription(txtHederID.Text, txtRecordID.Text);
            if (tbl.Rows.Count==0)
            {
                string radalertscript = "<script language='javascript'> Sys.Application.add_load(function(){radalert('Document not Found. Chech the PLA ID above.', 260, 120);})</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
                return;
            }
            lblApplicationTitle.Text = tbl.Rows[0][0].ToString();
            lblApplicationDesc.Text = tbl.Rows[0][1].ToString();
            hide(false);
        }
    }
}
