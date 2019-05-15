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
    public partial class Coverage : System.Web.UI.Page
    {
        Oracle.DataAccess.Client.OracleConnection Globalconn = null;
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
                ///
                //Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                //ViewState["Processing_Year"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "PROCESSING_YEAR", conn);
                //ViewState["Employee_Number"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "EMPLOYEE_NUMBER", conn);
                //conn.Close();
                //conn.Dispose();
                //ViewState["User_Name"] = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
                ////
                txtEffectiveDate.Enabled = ViewState["User_Group_ID"].ToString() != "3";
                ViewState["RecID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "RecID");
                string strDepName = SQLStatic.SQL.ExecScaler("select pkg_employee_maintenance.get_dependent_name(-" + ViewState["RecID"].ToString() + ") from dual").ToString();
                LBL_FLD_DEPENEDIT_COVERAGE_INSTRUCTION.Text = LBL_FLD_DEPENEDIT_COVERAGE_INSTRUCTION.Text.Replace("[dependent]", strDepName);
                Globalconn = SQLStatic.SQL.OracleConnection();
                GetCoverages();
                Globalconn.Close();
                Globalconn.Dispose();
            }
        }

        private void GetCoverages()
        {
            DataTable tbl = Data.GetEleigibleCoverages(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString(), Globalconn);
            int rowid = 1;
            Label lbl = null;
            CheckBox cb = null;
            DropDownList ddl = null;
            foreach (DataRow dr in tbl.Rows)
            {
                if (rowid == 1)
                  txtEffectiveDate.Text = Data.GetEffectiveDate(Request.Cookies["Session_ID"].Value.ToString(), dr["Category_Code"].ToString(), dr["Category_Plan"].ToString());
                lbl = (Label)Page.FindControl("lblBenefit" + rowid.ToString());
                lbl.Text = dr["long_description"].ToString();
                lbl.Visible = true;

                cb = (CheckBox)Page.FindControl("cbselect" + rowid.ToString());
                cb.Checked = dr["Include_Dom_Prtnr"].ToString() == "1";
                cb.Visible = true;

                if (cb.Checked)
                {
                    ((Label)Page.FindControl("lblAlreadyAssigned" + rowid.ToString())).Visible = true;
                    cb.Enabled = false;
                    //ddl = (DropDownList)Page.FindControl("ddlAvailableStatus" + rowid.ToString());
                    //ddl.Visible = true;
                    //ddl.Enabled = true;
                    //FillStatus(ddl, dr["record_id"].ToString());
                    //ddl.Items.FindByValue(dr["family_status_code"].ToString()).Selected = true;
                }
                else
                {
                    ddl = (DropDownList)Page.FindControl("ddlAvailableStatus" + rowid.ToString());
                    
                    ddl.Visible = true;
                    ddl.Enabled = false;
                    FillStatus(ddl, dr["record_id"].ToString());
                }
                ViewState["Record_id" + rowid.ToString()] = dr["record_id"].ToString();
                rowid++;
            }
            tbl.Dispose();
        }

        private void FillStatus(DropDownList ddl, string recID)
        {
            DataTable tbl = Data.GetFamilyStatus(recID, Globalconn);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["description"].ToString(),dr["family_status_code"].ToString());
                ddl.Items.Add(li);
            }
            tbl.Dispose();
        }



        protected void cbselect1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            string strID = cb.ID.Replace("cbselect", "");
            DropDownList ddl = (DropDownList)Page.FindControl("ddlAvailableStatus" + strID);
            ddl.Enabled = cb.Checked;   
            //Label lbl =(Label)Page.FindControl("lblAlreadyAssigned" + strID);
            //if ((lbl.Visible) && (!cb.Checked))
            //{
            //    lbl.Text = "Shall be Removed";
            //    lbl.ForeColor = System.Drawing.Color.Maroon;
            //}
            //else
            //{
            //    lbl.Text = "Already Assigned ";
            //    lbl.ForeColor = System.Drawing.Color.Black;
            //}
        }

        private string stripDate(string str)
        {
            str = str.Replace("_", "");
            if (str == "//")
                str = "";
            return str;
        }

        protected void aspxbtn_Click(object sender, EventArgs e)
        {
            txtEffectiveDate.Text = stripDate(txtEffectiveDate.Text);
            Validate();
            if (!IsValid)
                return;
            Globalconn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction idx = Globalconn.BeginTransaction();            
            string strRecid = ViewState["RecID"].ToString();
            try
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (ViewState["Record_id" + i.ToString()] != null)
                    {
                        CheckBox cb = (CheckBox)Page.FindControl("cbselect" + i.ToString());
                        if (cb.Checked && cb.Enabled)
                        {
                            DropDownList ddl = (DropDownList)Page.FindControl("ddlAvailableStatus" + i.ToString());
                            Data.SaveCoverage(ViewState["Record_id" + i.ToString()].ToString(), ViewState["Employee_Number"].ToString(), strRecid, ddl.SelectedValue, txtEffectiveDate.Text, ViewState["User_Name"].ToString(), Globalconn);
                        }
                    }
                }
                idx.Commit();
            }
            catch
            {
                idx.Rollback();
                throw;
            }
            finally
            {
                Globalconn.Close();
                Globalconn.Dispose();
            }
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            ViewState["Show_Declaration"] = Data.Show_Declara_Form_Send_Processess(ViewState["Employee_Number"].ToString());
            if (ViewState["Show_Declaration"].ToString()=="1")
            {
                strCallCloseWindow = "<script>docloseWindow(2)</script>";
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string strCallCloseWindow = "<script>docloseWindow(1)</script>";
            ViewState["Show_Declaration"] = Data.Show_Declara_Form_Send_Processess(ViewState["Employee_Number"].ToString());
            if (ViewState["Show_Declaration"].ToString() == "1")
            {
                strCallCloseWindow = "<script>docloseWindow(2)</script>";
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCallCloseWindow", strCallCloseWindow);
        }


    }
}
