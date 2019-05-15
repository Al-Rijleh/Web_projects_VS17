using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace Dependent_Audit_Wizard_Approval
{
    public partial class requestinfoAttachment : System.Web.UI.Page
    {
        String eoLicense = "5Grc0Qng5na0wMAe6KDl5QUg8Z61kZvnrqXg5/YZ8p61kZt14+30EO2s3MKe" +
    "tZ9Zl6TNF+ic3PIEEMidtbjF37BvrrbE2691pvD6DuSn6unaD71GgaSxy591" +
    "4+30EO2s3OnP566l4Of2GfKe3MKetZ9Zl6TNDOul5vvPuIlZl6Sxy59Zl8Dy" +
    "D+NZ6/0BELxbvNO/++OfmaQHEPGs4PP/6KFtpbSzy653hI6xy59Zs7PyF+uo" +
    "7sKetZ9Zl6TNGvGd3PbaGeWol+jyH+R2mbrA3LJoqbTC3aFZ7ekDHuio5cGz" +
    "36FZpsKetZ9Zl6TNHuig5eUFIPGetczZ3OOmyNTG9+166NbF89U=";
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            //#region BasTemplate
            //if (!IsPostBack)
            //{
            //    Template.BasTemplate objBasTemplate = new Template.BasTemplate();
            //    try
            //    {
            //        if (Request.Cookies["Session_ID"] == null)
            //            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", true);
            //        string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(), Request.Url.Authority.ToString(), Request.Url.AbsolutePath.ToString(), true, false);
            //        if (strResult != "")
            //        {
            //            Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult, false);
            //            return;
            //        }
            //        ViewState["AccessType"] = objBasTemplate.strAccessType;
            //        ViewState["Employee_Number"] = objBasTemplate.strEmployee_Number;
            //        ViewState["Processing_Year"] = objBasTemplate.strProcessingYear;
            //        ViewState["Role_Restriction_Level"] = objBasTemplate.strRole_Restriction_Level;
            //        ViewState["Selected_Account_Number"] = objBasTemplate.strSelected_Account_Number;
            //        ViewState["Selected_Employee_Class_Code"] = objBasTemplate.strSelected_Employee_Class_Code;
            //        ViewState["User_Group_ID"] = objBasTemplate.strUser_Group_ID;
            //        ViewState["User_ID"] = objBasTemplate.strUser_ID;
            //        ViewState["User_Name"] = objBasTemplate.strUser_Name;
            //        ViewState["User_Primary_Role"] = objBasTemplate.strUser_Primary_Role;
            //    }
            //    catch (Exception ex)
            //    {
            //        string strError = "Error Message: " + ex.Message + "~~Application:" + ex.Source + "~~Method:" + ex.TargetSite + "~~Detail:" + ex.StackTrace;
            //        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strError.Replace("\n", "~"));
            //    }
            //    finally
            //    {
            //        objBasTemplate.CleanUp();
            //        objBasTemplate.Dispose();
            //    }
            //}
            //#endregion
            if (!IsPostBack)
            {
                //buildPage();
            }

        }

        private void buildPage()
        {
            DataTable tbl = Data.FaxDepReportInformation(Request.Params["dep"]);
            lblErName.Text = tbl.Rows[0]["employer"].ToString();
            lblEE.Text = tbl.Rows[0]["employee"].ToString();
            lblDep.Text = tbl.Rows[0]["deps"].ToString();
            lblAuditId.Text = tbl.Rows[0]["code"].ToString();
            Image2.ImageUrl = tbl.Rows[0]["Bar"].ToString();
        }
    }
}