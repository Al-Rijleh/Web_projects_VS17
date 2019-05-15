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
using Telerik.Web.UI;


namespace Employee_Search
{
    public partial class Default : System.Web.UI.Page
    {
        int intCharacterToShow = 19;
        string session_id = string.Empty;
        string strToopTip = string.Empty;
        string urlhead_top = string.Empty;        
        protected void Page_Load(object sender, EventArgs e)
        {
            ///EnableViewState = false;
            strToopTip = @"<strong><span style='font-size: 10.5pt; color: black;'>Tip - How to Perform Employee Searches</span></strong> </p>
<p><span style='font-size: 9pt; color: black;'>As an administrator, you are permitted to search for any person who has ever been recorded in this system provided that person was affiliated with an employer account to which you have been assigned access rights.</span> </p>
<p><strong><span style='font-size: 9pt; color: #7f0000;'>Types of Searches</span></strong> </p>
<p><strong><span style='font-size: 9pt; color: black;'>Person's Name</span></strong><span style='font-size: 9pt; color: black;'> &ndash; Using the format 'Last Name, First Name' you may type some or all of a person's name. Typically, typing the full last name followed by a comma, a space and 1-3 letters of the person's first name will yield sufficiently limited results.</span> </p>
<p><strong><span style='font-size: 9pt;'>Employee ID Number</span></strong><span style='font-size: 9pt;'>&nbsp;(EMPID)&nbsp;&ndash;&nbsp;Often referred to as an 'Employee Number' or 'MyEnroll ID', the EMPID is a unique value assigned to each person when he/she was added to this system. The EMPID is frequently listed on reports and online screens. When searching using the EMPID, you must enter the complete EMPID, in order to return exact results.</span> </p>
<p><strong><span style='font-size: 9pt;'>Social Security Number</span></strong><span style='font-size: 9pt;'>&nbsp;&ndash;&nbsp;You may search by a person's Social Security Number by entering the complete 9-digit value including hyphens. For example 111-11-1111.</span> </p>
<p><strong><span style='font-size: 9pt;'>Email Address</span></strong><span style='font-size: 9pt;'>&nbsp;&ndash;&nbsp;You may search by a&nbsp;person's&nbsp;email address, which may include his/her work and alternate email addresses recorded in this system. To search by email address, you must enter the complete value of an email address including the '@' and domain name (e.g.,&nbsp;<a href='mailto:BSmith@ABC.com'>BSmith@ABC.com</a>).</span> </p>
<p><strong><span style='font-size: 9pt; color: #7f0000;'>Filters</span></strong> </p>
<p><span style='font-size: 9pt;'>You may use the radio buttons presented below the Search input box to filter your search results. Simply, mouse-click the radio button representing your filter choice and the results will be filter instantly.&nbsp;</span>";
            
            lblScript.Text = "";

            ViewState["template"] =  System.Configuration.ConfigurationManager.AppSettings["template"];
            if (ViewState["template"].ToString().Equals("2"))                
                urlhead_top = "";

            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!string.IsNullOrEmpty(Request.Params["inner"]))
            {
                if (ViewState["retrunInner"] == null)
                    ViewState["retrunInner"] = SQLStatic.Sessions.GetSessionValue(session_id, "LAST_URL");
            }
            #region BasTemplate
            if (!IsPostBack)
            {
                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    string path= Request.Path + "?SkipCheck=YES";
                    if (Request.Params["pc"] != null)
                        path = Request.Path + "?SkipCheck=YES&pc=" + Request.Params["pc"];
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run",path);
                    Response.Redirect("/web_projects/PTemplate/index.htm");
                    return;
                }
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
                    LblTemplateHeader2.Text = objBasTemplate.Header2();
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
                        string setPTemplate =  "<script language='javascript'> OpenHeader('') </script>" ;
                            //"window.open('/web_projects/ptemplate/header.aspx?pagename=Employee Search','Frame_detailing_the_selected_module_and_current_program_page');</script>";
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "setPTemplate", setPTemplate);
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
            //EnableViewState = false;
            if (!IsPostBack)
            {                
                if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
                    AddCOBRASearch();
                else
                {
                    string strProcessingYear = SQLStatic.AccountData.Current_Processing_Year((ViewState["Selected_Account_Number"].ToString()));
                    if (Data.Is_COBRA(ViewState["Selected_Account_Number"].ToString(),strProcessingYear))
                        AddCOBRASearch();
                }

                ViewState["Return_Account_Number"] = ViewState["Selected_Account_Number"].ToString();
                try
                {
                    if (!ViewState["Employee_Number"].ToString().Equals("0"))
                    {
                        lblEmployeeSelected.Text = SQLStatic.EmployeeData.EmployeeNameHeader(ViewState["Employee_Number"].ToString());
                        lblEmployeeSelected.CssClass = "fontsmall green_";
                    }
                    else
                    {
                        lblEmployeeSelected.Text = "None";
                        lblEmployeeSelected.CssClass = "fontsmall red_";
                    }
                }
                catch
                {
                    lblEmployeeSelected.Text = "Employee# " + ViewState["Employee_Number"].ToString()+" not found";
                    lblEmployeeSelected.CssClass = "fontsmall red_";
                }
                if (Request.Params["start"] != null)
                {
                    if (Request.Params["start"].Trim() != "")
                    {
                        txtSearch.Text = Request.Params["start"];
                        btnGo_Click1(null, null);
                    }
                }
                ViewState["CallCenterUser"] = Data.CallCenterUser(ViewState["User_ID"].ToString());
                txtSearch.Focus();
                dvHeder.Visible = false;
                RadToolTip1.TargetControlID= lblInstruction.ID;
            }
            if (!string.IsNullOrEmpty(hid3.Value))
            {
                ProcessSelection(hid3.Value);
                hid3.Value = string.Empty;
            }
            lblInstruction.ToolTip = strToopTip;
            //else if (!string.IsNullOrEmpty(txtSearch.Text))
            //    DrawGrid();            
        }

        private void AddCOBRASearch()
        {
            ListItem li = new ListItem("COBRA", "3");
            opnlstFilter.Items.Add(li);
        }

        private DataTable GetTable()
        {
            
            DataTable tbl = null;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                if (Request.Params["pc"] == null)
                    tbl = Data.search_Employee_pc_2(Request.Cookies["Session_ID"].Value.ToString(), txtSearch.Text, opnlstFilter.SelectedValue, conn);
                else
                    tbl = Data.search_employee_pc(Request.Cookies["Session_ID"].Value.ToString(), txtSearch.Text, opnlstFilter.SelectedValue, Request.Params["pc"], conn);
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
            return tbl;
        }

        private void DrawGrid()
        {
            txtSearch.Text = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(txtSearch.Text))
                return;
            //dgEEs.Columns[0].Visible = false;
            dgEEs.DataSource = GetTable();
            dgEEs.DataBind();
         
        }

        protected void btnGo_Click1(object sender, EventArgs e)
        {
            DrawGrid();
        }

        protected void opnlstFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGrid();
        }

        

        private void lnkMenu_Click(object sender, System.EventArgs e)
        {
            int rownu = Convert.ToInt32(((LinkButton)sender).ID.Substring(5));
            ProcessIndexChanged(rownu);
        }

        private void ProcessIndexChanged(int rownum)
        {
            DataTable tbl = (DataTable)dgEEs.DataSource;
            if (tbl == null)
                tbl = GetTable();
            string employee_number = tbl.Rows[rownum]["MyEnroll#"].ToString();
            string strPrefix = "";
            if (Request.Params["prefix"] != null)
                strPrefix = Request.Params["prefix"].ToString();
            ViewState["eeno"] = employee_number;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), strPrefix + "Employee_Number", tbl.Rows[rownum]["MyEnroll#"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), strPrefix + "Employee_Name", tbl.Rows[rownum]["Employee Name"].ToString(), conn);
                SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), strPrefix + "Account_Number", tbl.Rows[rownum]["account_number"].ToString(), conn);
                ViewState["Return_Account_Number"] = tbl.Rows[rownum]["account_number"].ToString();
                string strClass = Data.ee_class_code(tbl.Rows[rownum]["MyEnroll#"].ToString(), ViewState["Processing_Year"].ToString(), conn);
                if (string.IsNullOrEmpty(strClass))
                {
                    string process_year = Data.EE_Current_Processing_Year(tbl.Rows[rownum]["MyEnroll#"].ToString(), conn);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), strPrefix + "Processing_Year", process_year, conn);
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            SQLStatic.EmployeeData.AddSelectedEmployee(tbl.Rows[rownum]["MyEnroll#"].ToString(), ViewState["User_Name"].ToString());
            btnClose_Click(null, null);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            string strEmployee = SQLStatic.Sessions.GetEmployeeNumber(Request.Cookies["Session_ID"].Value.ToString());
            if ((string.IsNullOrEmpty(strEmployee)) || (strEmployee.Equals("0")))
            {
                Bas_Utility.Misc.Alert(Page, "You must select an employee");
                return;
            }
            string retURL = "";            


            if (Request.Params["goto"] != null)
                retURL = Request.Params["goto"].ToString();
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
                    if (!ViewState["template"].ToString().Equals("2"))
                        urlhead_top = "/web_projects/ptemplate/top.aspx?session=YES&code=0','Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame";
                    if (string.IsNullOrEmpty(Request.Params["status"]))
                        lblScript.Text = "<script>try {window.open(" + urlhead_top + ");} catch (err) { }" +
                            "window.location.href='" + retURL + "';</script>";
                    else
                        lblScript.Text = "<script>window.location.href='" + retURL + "';</script>";
                }
            }
            else
            {
                retURL = "/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES";
                //if (!string.IsNullOrEmpty(Request.Params["inner"]))
                //{

                //    if (ViewState["retrunInner"] != null)
                //    {
                //        if (!ViewState["retrunInner"].ToString().Contains("ENROLLMENTWIZARD"))
                //            retURL = ViewState["retrunInner"].ToString();
                //        else
                //        {
                //            SQLStatic.Sessions.SetSessionValue(session_id, "SESSION_CALLING_MODULE", "N");
                //            SQLStatic.Sessions.SetSessionValue(session_id, "LIFE_EVENT_CODE", "");
                //        }
                //        retURL = BASUSA.MiscTidBit.CheckForSkipCheck(retURL);
                //    }
                //}
                if (!ViewState["template"].ToString().Equals("2"))
                    urlhead_top = "/web_projects/ptemplate/top.aspx?session=YES&code=0','Employer_and_Benefit_Allocation_Systems_and_MyEnroll_organizational_logos_and_branding_frame";
                lblScript.Text = "<script>try {window.open(" + urlhead_top + ");} catch (err) { }" +
                       "window.open('/web_projects/ptemplate/Alert_Notes.aspx','MyEnroll_Alert_Notes_Menu_frame');" +
                       "try {window.top.setactivemenu(1); } catch (err) { }" +
                       "window.location.href='" + retURL + "';</script>";
                return;            
            }
        }

        private void setWidth(LinkButton lnkbtn)
        {
            if (lnkbtn.Text.Length > intCharacterToShow + 3)
            {
                lnkbtn.ToolTip = lnkbtn.Text;
                lnkbtn.Text = lnkbtn.Text.Substring(0, intCharacterToShow) + "...";
            }
        }

        private void setWidth(Label lbl)
        {
            if (lbl.Text.Length > intCharacterToShow + 3)
            {
                lbl.ToolTip = lbl.Text;
                lbl.Text = lbl.Text.Substring(0, intCharacterToShow) + "...";
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                return;
            dgEEs.DataSource = GetTable();
        }

       
        protected void CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton chk = sender as RadioButton;
            GridDataItem item = (GridDataItem)chk.NamingContainer;
            int index = item.ItemIndex;
            ProcessIndexChanged(index);
            
        }

        protected void dgEEs_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                string Employee = (e.CommandSource as LinkButton).Text.Replace("<u>", "").Replace("</u>", "");
                ProcessSelection(Employee);
            }
        }

        private void ProcessSelection(string employee_number )
        {
            
            string strPrefix = "";
            if (Request.Params["prefix"] != null)
                strPrefix = Request.Params["prefix"].ToString();
            ViewState["eeno"] = employee_number;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                ViewState["Return_Account_Number"]  = SQLStatic.EmployeeData.Account_Number(employee_number);
                SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Employee_Number", employee_number, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Employee_Name",SQLStatic.EmployeeData.employee_name_(employee_number), conn);
                SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Account_Number", ViewState["Return_Account_Number"].ToString(), conn);
                Data.setup_rocessing_year_class(session_id, employee_number, conn);

                //string strClass = SQLStatic.EmployeeData.CurrentClassCode(employee_number, conn);
                //string process_year = SQLStatic.EmployeeData.Current_Processing_Year(employee_number);             
                //SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "Processing_Year", process_year, conn);
                //SQLStatic.Sessions.SetSessionValue(session_id, strPrefix + "class_code", strClass, conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            SQLStatic.EmployeeData.AddSelectedEmployee(employee_number, ViewState["User_Name"].ToString());
            btnClose_Click(null, null);
        }

        protected void dgEEs_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //e.Item.Attributes.Add("onMouseOver", "Highlight(this)");
            //e.Item.Attributes.Add("onMouseOut", "UnHighlight(this)"); 

        }

        

        protected void rgHeader_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName && e.Item is GridDataItem)
            {
                hid2.Value = e.Item.ItemIndex.ToString();

                dgEEs.MasterTableView.Items[Convert.ToInt32(e.Item.ItemIndex.ToString())].Selected = true; //.GetDataKeyValue(.DataKeyValues[0].ToString();

                int SelValue = Convert.ToInt32(dgEEs.SelectedValue.ToString());

                int index1 = Convert.ToInt32(hid2.Value.ToString());

                ((RadGrid)dgEEs.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataSource = Data.Get_Detail(session_id,SelValue);
                ((RadGrid)dgEEs.MasterTableView.Items[index1].ChildItem.FindControl("rgDetal")).DataBind();

            }
        }
    }
}