using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cemetery_and_Mortuary_Benefit_Plan
{
    public partial class Default : System.Web.UI.Page
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

            //ViewState["Employee_Number"] = 337185;
            //ViewState["Selected_Account_Number"] = "0007208-0033-000";
            //ViewState["Processing_Year"] = 2019;
            if (Data.ShowFunralBenefitPage(ViewState["Selected_Account_Number"].ToString(), ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()).Equals("0"))
            {
                //lblScript.Text = "<script>ineligiblePopup()</script>";
                string strError = "<script>ineligiblePopup()</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strError", strError);
            }

            benefitTableSection.InnerHtml = Getclob();
        }

        private string Getclob()
        {
            string class_coed = SQLStatic.EmployeeData.CurrentClassCode(ViewState["Employee_Number"].ToString());// Data.ee_Class_Code(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());
            return Data.GetFuneralClob(class_coed, ViewState["Employee_Number"].ToString());
        }




    }
}