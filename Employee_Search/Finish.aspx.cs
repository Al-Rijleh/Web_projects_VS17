using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Search
{
    public partial class Finish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HidRun.Value))
            {
                Response.Redirect(HidRun.Value, true);
                return;
            }
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
            //        objBasTemplate.SetSeatchField(0);
            //        objBasTemplate.ShowFontSizeSelector = false;
            //        objBasTemplate.ShowNotes = false;
            //        objBasTemplate.ShowProcessingYear = true;
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
            //        if (string.IsNullOrEmpty(Request.Params["status"]))
            //        {
            //            string setPTemplate = "<script language='javascript'>" +
            //                "window.open('/web_projects/ptemplate/header.aspx?pagename=Employee Search','Frame_detailing_the_selected_module_and_current_program_page');</script>";
            //            Page.ClientScript.RegisterStartupScript(Page.GetType(), "setPTemplate", setPTemplate);
            //        }

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
            hidbtndName.Value = Request.Params["stBarName"];
            HidEnroll.Value = Request.Params["enrol"];
            string[] spy = Request.Params["strpy"].Split(',');
            Hidstrpy1.Value = spy[0];
            Hidstrpy2.Value = spy[1];
            Hidstrpy3.Value = spy[2];

            HidretURL.Value = Request.Params["retURL"];
            if (HidretURL.Value.IndexOf("?SkipCheck=YES").Equals(-1))
                HidretURL.Value = HidretURL.Value + "?SkipCheck=YES";
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LAST_URL", HidretURL.Value);

            if (System.Configuration.ConfigurationManager.AppSettings["template"].Equals("2"))
            {
                Response.Redirect(HidretURL.Value, true);
                return;
            }

            string strGp = "<Script>Go()</script>";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "strGp", strGp);
        }
    }
}