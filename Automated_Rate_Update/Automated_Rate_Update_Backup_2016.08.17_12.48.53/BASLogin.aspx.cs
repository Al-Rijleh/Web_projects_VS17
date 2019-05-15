using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Automated_Rate_Update
{
    public partial class BASLogin : System.Web.UI.Page
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
                    objBasTemplate.ShowSelectEmployee = true;
                    objBasTemplate.ShowNotes = false;
                    objBasTemplate.ShowFontSizeSelector = false;
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
                    ViewState["Page_id"] = objBasTemplate.strPageId;
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
                RadTabStrip1.Tabs[0].Selected = true;
                htmBtnManagePlans.Visible = false;
                if (!string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
                {
                    Data.SetFrameHeader(Page, ViewState["Selected_Account_Number"].ToString(), Request.Path);
                    txtAccountNameNumberValues.Text = SQLStatic.AccountData.AccountName(ViewState["Selected_Account_Number"].ToString());
                    btnConnect.Text = "Go To " + txtAccountNameNumberValues.Text;
                    
                    GetList();
                }
            }

        }

        private void GetList()
        {
            DataTable tbl = Data.GetAccountEntries(ViewState["Selected_Account_Number"].ToString());
            rblRateRewal.Items.Clear();
            foreach (DataRow dr in tbl.Rows)
            {
                //ListItem li = new ListItem(dr["rate_renewal_date"].ToString() + " - " + dr["processing_year"].ToString(), dr["rate_renewal_date"].ToString() + "/" + dr["processing_year"].ToString());
                ListItem li = new ListItem(dr["rate_renewal_date"].ToString() + " - " + dr["batch_id"].ToString().Substring(6),
                    dr["batch_id"].ToString());
                ViewState["py" + dr["batch_id"].ToString()] = dr["processing_year"].ToString();
                rblRateRewal.Items.Add(li);
            }
        }

  
        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("/web_projects/Account_Number/Default.aspx?SkipCheck=YES" +
                    "&goto=" + Request.Path, true);
            return;
        }

        protected void rblRateRewal_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Text = "Go To " + txtAccountNameNumberValues.Text+ "("+rblRateRewal.SelectedValue+")";
            btnConnect.Visible = true;
            htmBtnManagePlans.Visible = true;
            SQLStatic.Sessions.SetSessionValue(session_id, "processing_year", ViewState["py"+rblRateRewal.SelectedValue].ToString());
            SQLStatic.Sessions.SetSessionValue(session_id, "batchid", rblRateRewal.SelectedValue);
        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            string strParam = "?accnt="+ViewState["Selected_Account_Number"]+"&ip="+rblRateRewal.SelectedValue.Substring(0,5)+"&py="+rblRateRewal.SelectedValue.Substring(6);
            Response.Redirect("Default_2.aspx" + strParam, true);
        }

        
    }
}