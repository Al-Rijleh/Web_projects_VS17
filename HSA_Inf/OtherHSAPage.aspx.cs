using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HSA_Inf
{
    public partial class OtherHSAPage : System.Web.UI.Page
    {
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                ViewState["FS"] = SQLStatic.Sessions.GetSessionValue(session_id, "FAMILY_STATUS_CODE");
                setStatus();
            }
            //lnkbtnNo.Attributes.Add("click", "Javascript:closeWindow(20)");
        }

        private void setStatus()
        {
            DataTable tbl = Data.HSA_constatnts(ViewState["Selected_Account_Number"].ToString(), ViewState["FS"].ToString(), ViewState["Employee_Number"].ToString());

            lblInstruction.Text = lblInstruction.Text.Replace("[py]", tbl.Rows[0]["processing_year"].ToString());
            lblInstruction.Text = lblInstruction.Text.Replace("[sng]", tbl.Rows[0]["singleLimit"].ToString());
            lblInstruction.Text = lblInstruction.Text.Replace("[fm]", tbl.Rows[0]["familylimit"].ToString());

            lblNaxContiution.Text = "Your Maximum Contribution is " + tbl.Rows[0]["maxlimit_Formated"].ToString();
            txtContribution.MaxValue = Convert.ToDouble(tbl.Rows[0]["maxlimit"].ToString());

           //if (ViewState["FS"].ToString().Equals("001"))
           //{
           //    lblNaxContiution.Text ="Your Maximum Contribution is $3,350.00";
           //    txtContribution.MaxValue =3350;
           //}
           //else
           //{
           //    lblNaxContiution.Text ="Your Maximum Contribution is $6,675.00";
           //    txtContribution.MaxValue =6675;
           //}
            txtContribution.Text = Data.GetSPN_HSA(session_id,ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString(),"INS-HSA","002");
        }

        

        protected void lnkbtnNo_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                Data.SaveSPN_HSA(session_id, ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), "INS-HSA", "001",
                    "0", "0", conn);
                Data.SaveStatusCoverage(session_id, conn);
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
            Data.SaveStatusCoverage(session_id);
            string strClose = "<script>Javascript:closeWindow(20);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
        }

        protected void lnkbtnYes_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid)
                return;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                Data.SaveSPN_HSA(session_id, ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), "INS-HSA", "002",
                    txtContribution.Value.ToString(), "0",conn);
                Data.SaveStatusCoverage(session_id, conn);
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
            string strClose = "<script>Javascript:closeWindow(20);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
        }
    }
}