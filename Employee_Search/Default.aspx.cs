using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Employee_Search
{
    public partial class Default1 : System.Web.UI.Page
    {
        string session_id = string.Empty;
        string urlhead_top = string.Empty;   
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.Params["close"]))
            {
                if (Request.Params["close"].Equals("1"))
                {
                    Response.Redirect(Request.Params["usrl"], true);
                    return;
                }
            }

            ViewState["template"] = System.Configuration.ConfigurationManager.AppSettings["template"];
            if (ViewState["template"].ToString().Equals("2"))
                urlhead_top = "";


            session_id = Request.Cookies["Session_ID"].Value.ToString();
            string OriginalPage = SQLStatic.Sessions.GetSessionValue(session_id, "PAGE_ID");
            #region BasTemplate
            if (!IsPostBack)
            {
                //if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                //{
                //    string path = Request.Path + "?SkipCheck=YES";
                //    if (Request.Params["pc"] != null)
                //        path = Request.Path + "?SkipCheck=YES&pc=" + Request.Params["pc"];
                //    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", path);
                //    Response.Redirect("/web_projects/PTemplate/index.htm");
                //    return;
                //}
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
                    if (string.IsNullOrEmpty(Request.Params["status"]))
                    {
                        if (string.IsNullOrEmpty(Request.Params["skipf"]))
                        {
                            string setPTemplate = "<script language='javascript'> OpenHeader('') </script>" ;

                                //"window.open('/web_projects/ptemplate/header.aspx?pagename=Employee Search','Frame_detailing_the_selected_module_and_current_program_page');</script>";
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "setPTemplate", setPTemplate);
                        }
                    }

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
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                //if (Convert.ToInt64(OriginalPage) > 1000000)
                if (string.IsNullOrEmpty(OriginalPage))
                {
                    OriginalPage = "854";                    
                }
                SQLStatic.Sessions.SetSessionValue(session_id, "PAGE_ID", OriginalPage, conn);
                string origEE = SQLStatic.Sessions.GetEmployeeNumber(session_id, conn);
                string OrigER = SQLStatic.Sessions.GetAccountNumber(session_id, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "ori_EMPLOYEE_NUMBER", origEE, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "ori_ACCOUNT_NUMBER", OrigER, conn);
                string mybackPage = SQLStatic.Sessions.GetSessionValue(session_id, "MyBackPage", conn);

                SQLStatic.SQL.CloseConnection(conn);

                if (!string.IsNullOrEmpty(mybackPage))
                {
                    if (mybackPage.ToUpper().Contains("RBCEERETURN.ASPX"))
                    {
                        this.dgEEs.ClientSettings.Scrolling.AllowScroll = true;
                    }
                }

                txtSearch.Focus();
                FillDropDown();
                DataTable tbl = Data.get_Instruction_for_search("540", "2","13");
                if (!tbl.Rows.Count.Equals(0))
                {
                    //lblInstruction.ToolTip = tbl.Rows[0]["clob_col"].ToString();
                    imgDefaultSearchHelp.ToolTip = tbl.Rows[0]["clob_col"].ToString();
                    //imgInstruction.ToolTip = tbl.Rows[0]["clob_col"].ToString();
                }
                //tbl = Data.get_Instruction_for_search("540", "2", "65");
                //if (!tbl.Rows.Count.Equals(0))
                //{
                //    imgDefaultSearchHelp.ToolTip = tbl.Rows[0]["clob_col"].ToString();
                //    //cbLabel.ToolTip = tbl.Rows[0]["clob_col"].ToString();
                //}               
                tbl.Dispose();
                setDefaultControls();
                SetLastSelectedEEs();
            }

            if (!string.IsNullOrEmpty(hid3.Value))
            {
                ProcessSelection(hid3.Value);
                hid3.Value = string.Empty;
            }
        }

        private void SetLastSelectedEEs()
        {
            DataTable tbl = Data.Get_last_selected_ee(ViewState["User_ID"].ToString());
            if (tbl.Rows.Count.Equals(0))
            {
                dvEEs.Visible = false;
                tbl.Dispose();
                return;
            }
            dvEEs.Visible = true;
            foreach(DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["employee_name"].ToString(), dr["employee_number"].ToString());
                rblSelectedEEs.Items.Add(li);
            }
            tbl.Dispose();
        }

        private void setDefaultControls()
        {
            string controls = Data.get_laat_search_contols(ViewState["User_ID"].ToString());
            if (string.IsNullOrEmpty(controls))
                return;
            string[] str = controls.Split('~');
            try { ddlEmployeeStatus.FindItemByValue(str[0]).Selected = true; } catch { }
            try { ddlaccount_location.FindItemByValue(str[1]).Selected = true; } catch { }
            try { ddlBenefitsClass.FindItemByValue(str[2]).Selected = true; }catch { }
            try { ddlEligibility.FindItemByValue(str[3]).Selected = true; } catch { }
        }

        private void FillDropDown()
        {
            if (ViewState["User_Group_ID"].ToString().Equals("1"))
            {
                ddlaccount_location.FindItemByValue("0").Selected = true;
                ddlaccount_location.Enabled = false;
                ddlBenefitsClass.FindItemByValue("0").Selected = true;
                ddlBenefitsClass.Enabled = false;
                return;
            }
            DataTable tbl = Data.GetSearchList(ViewState["User_ID"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem(dr["account_name"].ToString(), dr["account_number"].ToString());
                ddlaccount_location.Items.Add(item);
            }

            tbl = Data.GetClassListByUser(ViewState["User_ID"].ToString());
            foreach (DataRow dr in tbl.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem(dr["description"].ToString(), dr["class_code"].ToString());
                ddlBenefitsClass.Items.Add(item);
            }

        }

        protected void rgHeader_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName && e.Item is GridDataItem)
            {
                hid2.Value = e.Item.ItemIndex.ToString();

                dgEEs.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true; //.GetDataKeyValue(.DataKeyValues[0].ToString();

                int SelValue = Convert.ToInt32(dgEEs.SelectedValue.ToString());

                int index1 = Convert.ToInt32(hid2.Value.ToString());

                ((RadGrid)dgEEs.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataSource = Data.Get_Detail(session_id, SelValue);
                ((RadGrid)dgEEs.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataBind();

            }
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //return;
            if (!string.IsNullOrEmpty(txtSearch.Text))
            dgEEs.DataSource = Data.search_Employee_new(session_id, txtSearch.Text.Trim(), ddlEmployeeStatus.SelectedValue,
              ddlaccount_location.SelectedValue, ddlBenefitsClass.SelectedValue,ddlEligibility.SelectedValue);
        }

        protected void DrawGrid()
        {
            string employeeStatus  = ddlEmployeeStatus.SelectedValue;
            if (string.IsNullOrEmpty(employeeStatus))
                employeeStatus = "1";

            string location = ddlaccount_location.SelectedValue;
            if (string.IsNullOrEmpty(location))
                location = "0";

            string benefitclass = ddlBenefitsClass.SelectedValue;
            if (string.IsNullOrEmpty(benefitclass))
                benefitclass = "0";

            dgEEs.DataSource = Data.search_Employee_new(session_id, txtSearch.Text.Trim(), employeeStatus, location, benefitclass, ddlEligibility.SelectedValue);
            //dgEEs.DataSource = Data.search_Employee_new(session_id, txtSearch.Text.Trim(), ddlEmployeeStatus.SelectedValue,
            //  ddlaccount_location.SelectedValue, ddlBenefitsClass.SelectedValue);
            dgEEs.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DrawGrid();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            //string strEmployee = SQLStatic.Sessions.GetEmployeeNumber(Request.Cookies["Session_ID"].Value.ToString());
            string strPrefix = "";
            if (Request.Params["prefix"] != null)
                strPrefix = Request.Params["prefix"].ToString();
            string strEmployee = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), strPrefix + "EMPLOYEE_NUMBER");
            if ((string.IsNullOrEmpty(strEmployee)) || (strEmployee.Equals("0")))
            {
                Bas_Utility.Misc.Alert(Page, "You must select an employee");
                return;
            }
            string retURL = "";

            string defPY = SQLStatic.Sessions.GetSessionValue(session_id, "PROCESSING_YEAR");
                //Data.EE_Current_Processing_Year(ViewState["employee_number"].ToString());
            //SQLStatic.EmployeeData.Current_Processing_Year(ViewState["employee_name"].ToString()); ViewState["employee_number"]
                //GetDefualtProcessingYear(ViewState["employee_name"].ToString()); // Maher 05/12/2017

            DataTable tbl = null;

            try
            {
                tbl = SQLStatic.AccountData.GetProcessingYearList_LastFirst(ViewState["Return_Account_Number"].ToString());
            }
            catch
            {
                tbl = SQLStatic.AccountData.GetProcessingYearList_LastFirst(SQLStatic.Sessions.GetAccountNumber(session_id));
            }


            string strFirstPy = tbl.Rows[0]["processing_year"].ToString();
            string strLastPy = tbl.Rows[tbl.Rows.Count-1]["processing_year"].ToString();
            tbl.Dispose();
            string strpy = strFirstPy + "," + strLastPy +","+ defPY;  //"'2016','2013','2014'";


            string stBarName = Data.toolbarbtnEEName(session_id);
            if (Request.Params["goto"] != null)
                retURL = Request.Params["goto"].ToString();

            string strEnrol = Data.HasEnrollment(session_id);            

            if(!string.IsNullOrEmpty(retURL))
                if(!string.IsNullOrEmpty(Request.Params["skipf"]))
                {
                    Response.Redirect(retURL, true);
                    return;
                }
            
            string mybackPage = SQLStatic.Sessions.GetSessionValue(session_id, "MYBACKPAGE");
            //Bas_Utility.Misc.Alert(Page, mybackPage);
            //return;
            //SQLStatic.Sessions.SetSessionValue(session_id, "MyBackPage", "");      Maher 05/12/2017
            if (!string.IsNullOrEmpty(mybackPage))
            {
               
                //if (mybackPage.ToUpper().Contains("RBCEERETURN.ASPX"))
                {
                    // SQLStatic.Sessions.SetSessionValue(session_id, "MyBackPage", string.Empty);  Maher 05/12/2017
                    if ((mybackPage.ToUpper().Contains("CUSTOMLOGON")) || (mybackPage.ToUpper().Contains("WEBFORM")))
                    {


                        string setPTemplate = "<script language='javascript'>JavaScript:RunBack('" + mybackPage + "') </script>";  //https://www.myenroll.com/web_projects/RBCLink/MainPage.aspx
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "setPTemplate", setPTemplate);    //JavaScript:RunBack()
                        return;
                    }
                    else
                    {
                        SQLStatic.Sessions.SetSessionValue(session_id, "MyBackPage", string.Empty);  //Maher 05/12/2017
                        Response.Redirect(mybackPage, true);
                    }
                    return;
                }
                retURL = mybackPage;
                //SQLStatic.Sessions.SetSessionValue(session_id, "MyBackPage",string.Empty);
            }

            if (retURL.ToUpper().IndexOf(Request.Path.ToUpper()) != -1)
                retURL = "";
            if (retURL != "")
            {
                if (Request.Params["samePage"] != null)
                    if (Request.Params["samePage"] == "y")
                        Response.Redirect(retURL, true);

                if (retURL.IndexOf("SkipCheck") == -1)
                    retURL = retURL + "?SkipCheck=YES";

                if (sender != null)
                    lblScript.Text = "<script>window.location.href='" + retURL + "';</script>";
                else
                {
                    if (string.IsNullOrEmpty(Request.Params["status"]))                      
                      Response.Redirect("Finish.aspx?stBarName=" + stBarName + "&strpy=" + strpy + "&retURL=" + retURL);


                        //lblScript.Text = "<script>window.open('/web_projects/ptemplate/top.aspx?session=YES&code=0','Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame');" +
                        //    "window.location.href='" + retURL + "';</script>";
                    else
                        lblScript.Text = "<script>window.location.href='" + retURL + "';</script>";
                }
            }
            else
            {
                retURL = "/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES";
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LAST_URL","/web_projects/DemographicsPage/Default.aspx");                
                Response.Redirect("Finish.aspx?stBarName=" + stBarName + "&strpy=" + strpy + "&retURL=" + retURL + "&enrol=" + strEnrol);                
                return;
            }
        }

        private string GetDefualtProcessingYear(string employee_number)
        {
            return SQLStatic.EmployeeData.Current_Processing_Year(employee_number);
        }

        private void ProcessSelection(string employee_number)
        {

            string strPrefix = "";
            if (Request.Params["prefix"] != null)
                strPrefix = Request.Params["prefix"].ToString();
            ViewState["eeno"] = employee_number;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();

            if (SQLStatic.Sessions.GetSessionValue(session_id, "ori_EMPLOYEE_NUMBER").Equals("0"))
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "ori_EMPLOYEE_NUMBER", employee_number, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "ori_ACCOUNT_NUMBER", SQLStatic.EmployeeData.Account_Number(employee_number), conn);
            }
            try
            {
                ViewState["Return_Account_Number"] = SQLStatic.EmployeeData.Account_Number(employee_number);
                ViewState["employee_name"] = SQLStatic.EmployeeData.employee_name_(employee_number);
                ViewState["employee_number"] = employee_number;
                SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Employee_Number", employee_number, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Employee_Name", SQLStatic.EmployeeData.employee_name_(employee_number), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Account_Number", ViewState["Return_Account_Number"].ToString(), conn);
                Data.setup_rocessing_year_class(session_id, employee_number, conn);
                Data.add_laat_search_contols(ViewState["User_ID"].ToString(), ddlEmployeeStatus.SelectedValue, ddlaccount_location.SelectedValue, 
                    ddlBenefitsClass.SelectedValue,ddlEligibility.SelectedValue);
                Data.add_last_selected_ee(ViewState["User_ID"].ToString(), employee_number);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            SQLStatic.EmployeeData.AddSelectedEmployee(employee_number, ViewState["User_Name"].ToString());
            btnClose_Click(null, null);
        }

        protected void rblSelectedEEs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblSelectedEEs.SelectedValue.Equals("0"))
            {
                txtSearch.Text = string.Empty;
                dgEEs.DataSource = Data.search_Employee_new(session_id, "~", "1", "0", "0", ddlEligibility.SelectedValue);
                dgEEs.DataBind();
                return;
            }
            else
                txtSearch.Text = rblSelectedEEs.SelectedValue;
            dgEEs.DataSource = Data.search_Employee_new(session_id, txtSearch.Text.Trim(), "1", "0", "0", ddlEligibility.SelectedValue);
            dgEEs.DataBind();
            ProcessSelection(txtSearch.Text);
        }

       
    }
}