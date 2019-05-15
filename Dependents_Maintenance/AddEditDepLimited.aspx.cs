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

namespace Dependents_Maintenance
{
    public partial class AddEditDepLimited : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                
                FillYears();
                FillState();
                lblTitle.Text = "Edit Dependent";
                SetExistingFields();
                SetDependentAddress();
                if ((!string.IsNullOrEmpty(Request.Params["SSN"])) && (Request.Params["SSN"].EndsWith("1")))
                {
                    pnlSSNOnly.Enabled = false;
                    pnlSSNOnly2.Enabled = false;
                }
            }            
        }
        private void FillYears()
        {
            int intStartYear = Convert.ToInt16(ViewState["Processing_Year"].ToString());
            ListItem lio = new ListItem("Year", "0");
            ddlYear.Items.Add(lio);
            for (int i = intStartYear; i < (intStartYear + 7); i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                ddlYear.Items.Add(li);
            }
        }

        private void FillState()
        {
            DataTable tbl = SQLStatic.CD_Tables.States();
            ListItem li2 = new ListItem("Select", "0");
            ddlState.Items.Add(li2);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["state_description"].ToString(), dr["state"].ToString());
                ddlState.Items.Add(li);
            }
        }

        protected void setValue(TextBox txt, string strValue)
        {
            ViewState[txt.ID] = strValue;
            txt.Text = strValue;
        }

        protected void setValue(DropDownList ddl, string strValue)
        {
            ViewState[ddl.ID] = strValue;
            ListItem li = ddl.Items.FindByValue(strValue);
            if (li != null)
                li.Selected = true;
        }

        private void SetExistingFields()
        {
            DataTable tbl = Data.GetDependentsInfoFromID(Request.Params["id"], Request.Params["dep_id"]);
            if (tbl.Rows.Count == 0)
                return;
            DataRow dr = tbl.Rows[0];
            
            setValue(txtSSN, dr["social_security_number"].ToString());
            setValue(txtDOB, dr["birth_date"].ToString());           
            setValue(txtSchool, dr["School"].ToString());            
            if (dr["GraduationDate"].ToString() != "")
            {
                setValue(ddlMonth, dr["GraduationDate"].ToString().Substring(4));
                setValue(ddlYear, dr["GraduationDate"].ToString().Substring(0, 4));
            }
            tbl.Dispose();
        }

        private void SetDependentAddress()
        {
            DataTable tbl = Data.GetDependentsAddress(Request.Params["id"], Request.Params["dep_id"]);
            if (tbl.Rows.Count == 0)
                return;
            DataRow dr = tbl.Rows[0];
            setValue(txtStreet, dr["address_line_1"].ToString());
            setValue(txtApt, dr["address_line_2"].ToString());
            setValue(txtCity, dr["city"].ToString());
            setValue(ddlState, dr["state"].ToString());
            setValue(txtZip, dr["zipcode"].ToString());
            setValue(txtHomePhone, dr["home_phone"].ToString());
            tbl.Dispose();
        }

        protected void aspxbtn_Click(object sender, EventArgs e)
        {
            string strGradDate = ddlYear.SelectedValue + ddlMonth.SelectedValue;
            if ((ddlMonth.SelectedIndex == 0) || (ddlYear.SelectedIndex == 0))
                strGradDate = "";
            string strSate = ddlState.SelectedValue;
            if (ddlState.SelectedValue == "0")
                strSate = "";
            string strDepID = "";
            if (Request.Params["id"] == "-1")
                strDepID = "0";
            else
                strDepID = Request.Params["dep_id"];
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction idx = conn.BeginTransaction();
            //string strID;
            try
            {
                Data.SaveDependentsLimited(Request.Params["id"], ViewState["Employee_Number"].ToString(), strDepID, ViewState["Processing_Year"].ToString(), 
                    txtSSN.Text, txtDOB.Text, txtSchool.Text,  strGradDate,  ViewState["User_Name"].ToString(), conn);
                Data.SaveDependentAddressByEE(ViewState["Employee_Number"].ToString(), Request.Params["dep_id"], txtStreet.Text, txtApt.Text, txtCity.Text, strSate, txtZip.Text, txtHomePhone.Text, ViewState["User_Name"].ToString(), conn);               
                idx.Commit();            
            }
            catch
            {
                idx.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
            return;
        }
        
    }
}
