using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Collections;

namespace EnrollmentWizardSetup
{
    public partial class Classes : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(16);
                ShowData();
                //DrawGrid();
            }

        }

        private void ShowData()
        {
            DataTable tbl = Data.Get_Class_Code_List(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
            cbEligible.DataSource = tbl;
            cbEligible.DataTextField = "full_description";
            cbEligible.DataValueField = "class_code";
            cbEligible.DataBind();
            foreach (DataRow dr in tbl.Rows)
            {
                cbEligible.Items.FindByValue(dr["class_code"].ToString()).Selected = dr["oe_eligible"].ToString().Equals("1");
            }
        }

        protected void btnClassSave_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                Data.Make_All_Classes_Eligible(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString(),
                    rblSaveTaxTo.SelectedValue, ViewState["User_Name"].ToString(), conn);

                foreach (ListItem li in cbEligible.Items)
                {
                    if (!li.Selected)
                        Data.update_one_class(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString(),
                    rblSaveTaxTo.SelectedValue,li.Value,"0", ViewState["User_Name"].ToString(), conn);

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
            ShowData();
            Bas_Utility.Misc.AlertSaved(Page);
            
        }

        //private void DrawGrid()
        //{
        //    RadGrid1.DataSource = Data.Get_Class_Code_List(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
        //    RadGrid1.DataBind();
        //}

        //protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    RadGrid1.DataSource = Data.Get_Class_Code_List(ViewState["Selected_Account_Number"].ToString(), ViewState["Processing_Year"].ToString());
        //}

        //protected void RadGrid1_BatchEditCommand(object sender, Telerik.Web.UI.GridBatchEditingEventArgs e)
        //{
        //    ArrayList al = new ArrayList();
        //    foreach (GridBatchEditingCommand command in e.Commands)
        //    {

        //        Hashtable newValues = command.NewValues;
        //        Hashtable oldValues = command.OldValues;
        //        al.Add(oldValues["catcodeplanstaus"].ToString() + "!" + newValues["rate_override3"].ToString());
        //    }
        //}

       

        
    }
}