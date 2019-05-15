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
    public partial class ViewDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PopUp BasTemplate
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
                        Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=" + strResult.Replace("\n", "~"), false);
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
                ViewState["Employee_Number"] = Data.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(), Request.Cookies["Session_ID"].Value.ToString());
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
                SetHeaderInformation();
                Data.FillBudgetYears(ddlBudgetYear, lblBalance, ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());
                ProcessesStarFunctionality();
            }
            DrawGrid();
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Params["Back"]+"?SkipCheck=YES");
        }

        protected void ddlBudgetYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBalance.Text = Data.FormatedRemainingAmount(ddlBudgetYear.SelectedItem, ViewState["Employee_Number"].ToString());
        }

        protected void DrawGrid()
        {
            DataTable tbl = Data.GetDocuments(ViewState["Request_Record_ID"].ToString());
            gvDocuments.DataSource = tbl;
            gvDocuments.DataBind();
        }

        protected void gvDocuments_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvDocuments.DataSource;
            if (dt == null)
                return;
            try
            {
                if (e.Row.RowIndex == -1)
                {
                    return;
                }
                if (dt.Rows.Count < e.Row.RowIndex)
                    return;
                string strIndex = e.Row.RowIndex.ToString() ;

                LinkButton btn = null;
                btn = new LinkButton();
                btn.Click += new System.EventHandler(this.btn_Click);
                btn.ID = "btn_" + strIndex;
                btn.Text = dt.Rows[e.Row.RowIndex]["document_name"].ToString();
                btn.ToolTip = "Show Documents "+btn.Text;
                TableCell cell = e.Row.Cells[0];
                cell.Controls.Add(btn);
            }
            catch { }
        }

        private void btn_Click(object sender, System.EventArgs e)
        {            
            string strIndex = ((LinkButton)sender).ID.Replace("btn_","");
            int index = Convert.ToInt16(strIndex);
            DataTable tbl = (DataTable)gvDocuments.DataSource;
            txtDocumentDescription.Text = tbl.Rows[index]["description"].ToString();
            lblDocumentName.Text = "Description For:&nbsp;&nbsp;<b>"+ tbl.Rows[index]["document_name"].ToString()+"<b/>";
            ViewState["Role_id"] = tbl.Rows[index]["r_log_id"].ToString();
            btnViewDocument.Enabled = tbl.Rows[index]["image_type"].ToString()!="";
        }

        protected void btnViewDocument_Click(object sender, EventArgs e)
        {
            string strURL = "ShowFile.aspx?id=" + ViewState["Role_id"].ToString();
            string strViewImage = "<script>window.open('" + strURL + "','_blank');</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strViewImage", strViewImage);
        }
      
    }
}
