using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnrollmentWizardSetup
{
    public partial class Properties : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(15);
                populateDatax();            
            }

        }

        private void populateDatax()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "184", conn).Equals("1"))
                {
                    cblFSALink.Items.FindByValue("184").Selected = true;
                    rblSelectedFSA.Items.FindByValue("1").Selected = true;
                }
                if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "185", conn).Equals("1"))
                {
                    cblFSALink.Items.FindByValue("185").Selected = true;
                    rblSelectedFSA.Items.FindByValue("1").Selected = true;
                }
                if (Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "186", conn).Equals("1"))
                {
                    cblFSALink.Items.FindByValue("186").Selected = true;
                    rblSelectedFSA.Items.FindByValue("1").Selected = true;
                }
                try
                {
                    rblPostTax.Items.FindByValue(Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "187", conn)).Selected = true;
                }
                catch { }
                try
                {
                    rblHidRunningValue.Items.FindByValue(Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "188", conn)).Selected = true;
                }
                catch { }
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
            

        }

        protected void brnSavePrePostTax_Click(object sender, EventArgs e)
        {
            string strOE = string.Empty;
            foreach (ListItem li in cblFSALink.Items)
            {
                if (li.Selected)
                    strOE +=li.Value;
            }
            if (string.IsNullOrEmpty(strOE))
            {
                Bas_Utility.Misc.Alert(Page,"Must select at least one OE type");
                return;
            }
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                foreach (ListItem li in cblFSALink.Items)
                {
                    if (li.Selected)
                        Data.Save_er_property(ViewState["Selected_Account_Number"].ToString(), li.Value, rblSelectedFSA.SelectedValue,
                            ViewState["User_Name"].ToString(),rblFSALink.SelectedValue, conn);
                }
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

            Bas_Utility.Misc.AlertSaved(Page);
        }

        

        protected void btnDefaultPrePostTax_Click(object sender, EventArgs e)
        {
            Data.Save_er_property(ViewState["Selected_Account_Number"].ToString(), "187", rblPostTax.SelectedValue,
                            ViewState["User_Name"].ToString(), rblSaveTaxTo.SelectedValue, null);
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void btnSaveHidRunningTotal_Click(object sender, EventArgs e)
        {
            Data.Save_er_property(ViewState["Selected_Account_Number"].ToString(), "188", rblHidRunningValue.SelectedValue,
                            ViewState["User_Name"].ToString(), rblSaveHidRunningTotalTo.SelectedValue, null);
            Bas_Utility.Misc.AlertSaved(Page);
        }

       
    }
}