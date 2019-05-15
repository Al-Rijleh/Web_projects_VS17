using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.Collections;
using System.Text.RegularExpressions;

namespace Rates
{
    public partial class Default : System.Web.UI.Page
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
                    objBasTemplate.ShowFontSizeSelector = false;
                    objBasTemplate.ShowNotes = false;
                    objBasTemplate.ShowProcessingYear = true;
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
            lblScript.Text = string.Empty;
            if(!IsPostBack)
            {
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                try
                {
                    ViewState["Account_number"] = SQLStatic.Sessions.GetSessionValue(session_id, "ACCOUNT_NUMBER", conn);
                    ViewState["Version"] = SQLStatic.Sessions.GetSessionValue(session_id, "Version", conn);
                    ViewState["class_code"] = SQLStatic.Sessions.GetSessionValue(session_id, "class_code", conn);

                    ViewState["category_code"] = SQLStatic.Sessions.GetSessionValue(session_id, "category_code", conn);
                    ViewState["category_plan"] = SQLStatic.Sessions.GetSessionValue(session_id, "category_plan", conn);
                    ViewState["PROCESSING_YEAR"] = SQLStatic.Sessions.GetSessionValue(session_id, "PROCESSING_YEAR", conn);
                    ViewState["CVRG"] = SQLStatic.Sessions.GetSessionValue(session_id, "CVRG", conn);
                    ViewState["CVRGID"] = SQLStatic.Sessions.GetSessionValue(session_id, "CVRGID", conn);
                }

                finally 
                {
                    SQLStatic.SQL.CloseConnection(conn);
                }
            }
            btnRestRates.Attributes.Add("onclick", "CheckRestRate()");
            if (!string.IsNullOrEmpty(hidReset.Value))
            {       
                hidSave.Value = string.Empty;
                
                RestRate();
                Response.Redirect("/WEB_PROJECTS/Rates/Default.aspx",true);
                return;
            }
        }

        private void DoSave()
        {
            ArrayList al = (ArrayList)ViewState["save"];
            string unique_id_ = string.Empty;
            string rate_amount = string.Empty;
            string employer_split = string.Empty;
            string rate_override1 = string.Empty;
            string user_name_ = SQLStatic.Sessions.GetUserName(session_id);
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();            
            try
            {
                foreach (string str in al)
                {
                    string[] codeoverride = str.Split('!');
                    unique_id_ = codeoverride[0];
                    rate_amount = codeoverride[1].Replace("$", "").Replace(",", "");
                    employer_split = codeoverride[2].Replace("$", "").Replace(",", "");
                    rate_override1 = codeoverride[3].Replace("$", "").Replace(",", "");
                    if(!cbSelectOnFS.Checked)
                        Data.SaveOneErRate(unique_id_, rate_amount, employer_split, rate_override1, user_name_, conn);
                    else
                        Data.SAVEONEERRATE_OneFS(unique_id_, rate_amount, employer_split, rate_override1, user_name_, conn);
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
            DrawGrid();
            Bas_Utility.Misc.AlertSaved(Page);

        }

        private DataTable GetTable()
        {
            return Data.GetNewRatesFrmRateTbl(ViewState["Account_number"].ToString(), ViewState["Version"].ToString(), ViewState["class_code"].ToString(),
                ViewState["category_code"].ToString(), ViewState["category_plan"].ToString(), ViewState["PROCESSING_YEAR"].ToString());            
        }

        private void DrawGrid()
        {
            DataTable tbl = GetTable();
            if (tbl.Rows.Count.Equals(0))
            {
                Response.Redirect("BuildFSAge.aspx", true);
                return;
            }
            RadGrid1.DataSource = tbl;
            RadGrid1.DataBind();
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable tbl = GetTable();
            if (tbl.Rows.Count.Equals(0))
            {
                Response.Redirect("BuildFSAge.aspx", true);
                return;
            }
            RadGrid1.DataSource = tbl;
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            
            if (e.CommandName == RadGrid.ExpandCollapseCommandName && e.Item is GridDataItem)
            {
                int ItemIndex = e.Item.ItemIndex;

                RadGrid1.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true; 

                string SelValue = RadGrid1.SelectedValue.ToString();
               
                //string[] CodePlanStatus = SelValue.Split('~');
                //string category_code = CodePlanStatus[0];
                //string category_plan = CodePlanStatus[1];
                //string family_status = CodePlanStatus[2];
                //DataTable tbl = null;

                //tbl = Data.GetNewRatesFrmRateTbl("0011137-0000-000", "1", "I", "INS-MED", "003", "2015"); ;

                //((RadGrid)RadGrid1.MasterTableView.Items[ItemIndex].ChildItem.FindControl("rgDetal")).DataSource = tbl;
                //((RadGrid)RadGrid1.MasterTableView.Items[ItemIndex].ChildItem.FindControl("rgDetal")).DataBind();

            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                Bas_Utility.Misc.Alert(Page, e.Item.ItemIndex.ToString());
            }
        }

        protected void RadGrid1_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            ArrayList al = new ArrayList();
            foreach (GridBatchEditingCommand command in e.Commands)
            {

                Hashtable newValues = command.NewValues;
                Hashtable oldValues = command.OldValues;
                al.Add(oldValues["unique_id"].ToString() + "!" + newValues["rate_amount"].ToString() + "!" + newValues["employer_split"].ToString() + "!" + newValues["rate_override1"].ToString());
            }
            ViewState["save"] = al;
            DoSave();
            //lblScript.Text = "<Script>Javascript:CheckSave()</script>";
        }

        protected void RadGrid1_ItemDeleted(object sender, GridDeletedEventArgs e)
        {
            Bas_Utility.Misc.Alert(Page, e.Item.ItemIndex.ToString());
        }

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            Bas_Utility.Misc.Alert(Page, e.Item.ItemIndex.ToString());
        }

        protected void btnSetup_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuildFSAge.aspx", true);
        }

        protected void btnUseOld_Click(object sender, EventArgs e)
        {
            string strParam = "?accnt="+ViewState["Account_number"].ToString()+
                "&ver="+ViewState["Version"].ToString()+
                "&class="+ViewState["class_code"].ToString()+
                "&catcode="+ViewState["category_code"].ToString()+
                "&catplan="+ViewState["category_plan"].ToString()+
                "&py="+ViewState["PROCESSING_YEAR"].ToString()+
                "&cvrg="+ViewState["CVRG"].ToString()+
                "&action=0"+
                "&back=2" +
                "&cvrgid="+ViewState["CVRGID"].ToString();
            Response.Redirect("UseOld.aspx" + strParam,true);
        }

        protected void RestRate()
        {
            Data.ResetRateForCoverage(ViewState["Account_number"].ToString(), ViewState["Version"].ToString(), ViewState["class_code"].ToString(),
                ViewState["category_code"].ToString(), ViewState["category_plan"].ToString(), ViewState["User_Name"].ToString());
            Response.Redirect("/WEB_PROJECTS/Rates/Default.aspx", true);
            return;
        }

        protected void btnRestRates_Click(object sender, EventArgs e)
        {
            RestRate();
            Response.Redirect("/WEB_PROJECTS/Rates/Default.aspx", true);
            //RestRate();

            //string strShowParent = "<script>OpenProgram('" + strURL + "')</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "strShowParent", strShowParent);

            string strCheckRestRate = "<Script>Javascript:CheckRestRate('" + ViewState["CVRG"].ToString() + "')</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "strCheckRestRate", strCheckRestRate);

            //lblScript.Text = "<Script>Javascript:CheckRestRate('" + ViewState["CVRG"].ToString() + "')</script>";
        }

        //private void RadGrid1_DeleteCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        //{
        //    string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CustomerID"].ToString();

      
           
        //}

    }   
}