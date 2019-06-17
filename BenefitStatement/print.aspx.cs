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

namespace BenefitStatement
{
    public partial class print : System.Web.UI.Page
    {
        string strStyle = @"<style>
.FullPage
{
width:775px;
}

.FontSmall{
font-family:Arial,Sans-Serif;
font-size:9pt;
}

.InputRowTitle
{
width:523px;
padding-left:5px;
padding-right:5px;
float:left;
}

.FontSmall10{
font-family:Arial,Sans-Serif;
font-size:10pt;
}

.Datablank10
{
width:500px;
float:left;
height:10px;
}
.Field
{
    float:left;
    width:100px;
}
.FieldText
{
    float:right;
    width:367px;
}
</style>";
        string session_id = "";
        string strnocoverage = @"<b><span style='font-size: 10.5pt; color: #911108'>Benefits Statement Processing Warning</span></b><span style='font-size: 10.5pt; color: #911108'> 
-</span><span style='font-size: 10.5pt'> [name] (MyEnroll ID# [no]) does not 
have any coverage during the plan year: [py]. 
Please change the Plan Year from the Plan Year: [py] link above to a 
Plan Year coinciding with the following information:<br>
<br>
&nbsp;</span><table border='0' width='500' cellspacing='0' cellpadding='0'>
	<tr>
		<td width='265'>Earliest recorded benefit class year</td>
		<td>[classyear]</td>
	</tr>
	<tr>
		<td width='265'>Earliest recorded benefit plan year</td>
		<td>[benefityear]</td>
	</tr>
	<tr>
		<td width='265'>Most recent recorded benefit plan year</td>
		<td>[lastbenefit]</td>
	</tr>
	<tr>
		<td width='265'>Termination Date</td>
		<td>[trmdate]</td>
	</tr>
</table><br>
<br>
[msg]
</p>";


        protected void Page_Load(object sender, EventArgs e)
        {

            session_id = Request.Cookies["Session_ID"].Value.ToString();

            if (!IsPostBack)
            {
                SetProcessingYear();

            }

            #region BasTemplate
            if (!IsPostBack)
            {

                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
                    Response.Redirect("/web_projects/PTemplate/index.htm");
                    //Response.Redirect("/web_projects/PTemplate/index_ifram.htm");
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
                    //objBasTemplate.SetSeatchField(0);
                    //objBasTemplate.ShowProcessingYear = true;
                    //if (!objBasTemplate.strUser_Group_ID.Equals("3"))
                    //    objBasTemplate.ShowSelectEmployee = true;
                    //else
                    //    objBasTemplate.ShowSelectEmployee = false;
                    //objBasTemplate.ShowNotes = false;
                    //objBasTemplate.ShowFontSizeSelector = false;
                    //LblTemplateHeader2.Text = objBasTemplate.Header2();
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
                    ViewState["Page_Id"] = "897";
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
                SQLStatic.Sessions.SetSessionValue(session_id, "SESSION_CALLING_MODULE", "N");
                string strEmployeeNumber = ViewState["Employee_Number"].ToString();
                if ((strEmployeeNumber.Equals("0")) || (string.IsNullOrEmpty(strEmployeeNumber)))
                {
                    string strGetEE = "<script>GetEE('" + Request.Path + "')</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strGetEE", strGetEE);
                    return;
                }
                if (!Data.HasCoverage(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString()))
                {
                    Bas_Utility.Misc.Alert(Page, "The selected employee doesn’t have any coverage for the selected plan year");
                    dvAll.Visible = false;
                    lblNoCvrg.Text = GetWarning();
                    lblNoCvrg.CssClass = "FontMedium";
                    return;
                }
                else
                {
                    dvAll.Visible = true;
                    lblNoCvrg.Text = string.Empty;
                }
                ViewState["Selected_Account_Number"] = SQLStatic.EmployeeData.Account_Number(ViewState["Employee_Number"].ToString());
                lblPreparedOn.Text = DateTime.Today.ToLongDateString();
                SetHeaderTest();
                Show_Hide_dependent();
                GetShowCost();
                ViewState["RetaAccount"] = SQLStatic.AccountData.RetaAccount(ViewState["Selected_Account_Number"].ToString());
                if (ViewState["Selected_Account_Number"].ToString().IndexOf("0007217").Equals(0))
                    ViewState["RetaAccount"] = false;
                //if (!(bool)ViewState["RetaAccount"]) hide the messages per JIRA MYENROLL-18495
                {
                    dvYourElectionTitle.Visible = false;
                    dvYourElection.Visible = false;
                }
                lblCost.Visible = ViewState["Selected_Account_Number"].ToString().IndexOf("0007208") > -1;
                try
                {
                    Bas_Utility.Utilities.SetHeaderFrame(Page, "Benefits Statement", "ACCOUNT_INFO", SQLStatic.EmployeeData.EmployeeNameHeader(ViewState["Employee_Number"].ToString()));
                }
                catch { }

                ViewState["typeof"] = Data.Enrollment_type(ViewState["Selected_Account_Number"].ToString());
                dvSummary.Visible = ViewState["typeof"].ToString().Equals("0");
                dvSpecisl.Visible = !dvSummary.Visible;


                if (Data.allows_pretax_posttax(ViewState["Selected_Account_Number"].ToString()))
                {
                    dvTax.Visible = true;
                    rblDeductionOption.Items.FindByValue(Data.ee_using_pretax(ViewState["Employee_Number"].ToString())).Selected = true;
                    //lblPayRollDeduction.Text = rblDeductionOption.Items[rblDeductionOption.SelectedIndex].Text;
                    lblPayRollDeduction.Text = Data.ee_pre_post_value(ViewState["Employee_Number"].ToString(), ViewState["Processing_Year"].ToString());
                    //foreach (ListItem li in rblDeductionOption.Items)
                    //    li.Enabled = li.Selected;
                }
            }
            DrawGrig();
            DrawSpecialGrid();
            DrawExtraGrid();
        }

        private void DrawExtraGrid()
        {
            DataTable tbl = Data.get_screen_scheme_iframe(ViewState["Page_Id"].ToString(), "2", ViewState["Selected_Account_Number"].ToString());
            if ((tbl.Rows.Count.Equals(0)) || (string.IsNullOrEmpty(tbl.Rows[0]["url"].ToString())))
            {
                dvExtra.Visible = false;
                iExtra.Visible = false;
            }
            else
            {
                iExtra.Attributes.Add("src", tbl.Rows[0]["url"].ToString());
                iExtra.Attributes.Add("height", tbl.Rows[0]["height"].ToString() + "px");
                iExtra.Attributes.Add("width", tbl.Rows[0]["width"].ToString() + "px");

            }
        }

        private string GetWarning()
        {
            DataTable tbl = Data.get_warning_data(ViewState["Employee_Number"].ToString());
            string strResult = strnocoverage.Replace("[name]", tbl.Rows[0]["ee_name"].ToString())
                                            .Replace("[no]", ViewState["Employee_Number"].ToString())
                                            .Replace("[py]", ViewState["Processing_Year"].ToString())
                                            .Replace("[classyear]", tbl.Rows[0]["class_year"].ToString())
                                            .Replace("[benefityear]", tbl.Rows[0]["first_year"].ToString())
                                            .Replace("[lastbenefit]", tbl.Rows[0]["last_tear"].ToString())
                                            .Replace("[trmdate]", tbl.Rows[0]["term_date"].ToString())
                                            .Replace("[msg]", tbl.Rows[0]["msg"].ToString());

            return strResult;
        }

        private void SetProcessingYear()
        {
            string strProcessingYear = "";
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            string strAccountNumber = SQLStatic.Sessions.GetAccountNumber(session_id, conn);
            string strSessionProcessingYear = SQLStatic.Sessions.GetSessionValue(session_id, "processing_year");
            if (string.IsNullOrEmpty(strSessionProcessingYear))
                strSessionProcessingYear = DateTime.Today.Year.ToString();
            if (!Data.GoodProcessingYear(strAccountNumber, strSessionProcessingYear, conn))
            {

                strProcessingYear = Data.Current_Processing_Year(strAccountNumber, conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "processing_year", strProcessingYear, conn);
            }

            SQLStatic.SQL.CloseConnection(conn);
        }

        private void SetHeaderTest()
        {
            DataTable tbl = Data.GetBenefitStatmentHeader(session_id);

            lblMasterAccount.Text = tbl.Rows[0]["Master_Name"].ToString();
            lblAccountNumber.Text = tbl.Rows[0]["account_number"].ToString();
            lblEmployeeID.Text = tbl.Rows[0]["employee_number"].ToString();
            lblAccountName.Text = tbl.Rows[0]["account_name"].ToString();
            lblPlanYear.Text = ViewState["Processing_Year"].ToString();
            if (string.IsNullOrEmpty(tbl.Rows[0]["address2"].ToString()))
            {
                lblName1.Text = "&nbsp;";
                lblName2.Text = tbl.Rows[0]["name"].ToString();
                lblName3.Text = tbl.Rows[0]["address1"].ToString();
                lblName4.Text = tbl.Rows[0]["city"].ToString();
            }
            else
            {
                lblName1.Text = tbl.Rows[0]["name"].ToString();
                lblName2.Text = tbl.Rows[0]["address1"].ToString();
                lblName3.Text = tbl.Rows[0]["address2"].ToString();
                lblName4.Text = tbl.Rows[0]["city"].ToString();
            }
            string strSupportPhone = "";
            if (ViewState["User_ID"].ToString().Equals("3"))
                strSupportPhone = tbl.Rows[0]["ee_support_phone"].ToString();
            else
                strSupportPhone = tbl.Rows[0]["er_support_phone"].ToString();
            if (!string.IsNullOrEmpty(strSupportPhone))
                lblSupportPhone.Text = strSupportPhone;
            lblServiceEmail.Text = tbl.Rows[0]["service_email"].ToString();
            tbl.Dispose();


        }

        private void Show_Hide_dependent()
        {
            dvDepGrid.Visible = Data.DependentsCoverageEligible(session_id);
            dvDepTitle.Visible = dvDepGrid.Visible;
        }

        private string Manage(string strHTML)
        {
            string strHead = "<font face='Arial' size='2' color='Black'>" + "<b>Signed By:&nbsp;</b>" + Data.UserName(ViewState["User_Name"].ToString()) +
                      "<b>Signed On:&nbsp;</b>" + DateTime.Today.ToLongDateString() + "&nbsp;@&nbsp;" + DateTime.Now.ToLongTimeString() +
                      "</font><br /><br />";
            strHTML = strHead + strHTML;
            return strHTML.Replace("onclick", "onclick.").Replace("<a", "<a.");
        }



        private void GetShowCost()
        {
            ViewState["ShowCost"] = Data.GetShowCost(session_id);
        }

        private string TotalCost(DataTable tbl, string FieldName)
        {
            string strValue = "";
            double dblValue = 0;
            foreach (DataRow dr in tbl.Rows)
            {

                strValue = dr[FieldName].ToString();
                if (strValue != "****")
                {
                    strValue = strValue.Replace("$", "").Replace(",", "");
                    dblValue += Convert.ToDouble(strValue);
                }

            }
            return String.Format("{0:$###0.00;($###0.00);Zero}", dblValue);
        }

        private void AddRow(DataTable tbl, string FieldName, string strTitle)
        {
            string value = TotalCost(tbl, FieldName);
            DataRow NewRow;
            NewRow = tbl.NewRow();
            NewRow["BenefitLevel"] = strTitle;
            NewRow[FieldName] = value;
            tbl.Rows.Add(NewRow);
        }

        private void AddRow(DataTable tbl)
        {
            DataRow NewRow;
            NewRow = tbl.NewRow();
            tbl.Rows.Add(NewRow);
        }

        private void SetGrid(DataTable tbl, string strFieldName, string strTitle, int intColumnToHide)
        {
            if (intColumnToHide < 0)
            {
                gvSummary.Columns[3].Visible = false;
                gvSummary.Columns[4].Visible = false;
                gvSummary.ShowFooter = false;
                return;
            }
            ViewState["Total_Value"] = TotalCost(tbl, strFieldName);
            ViewState["Total_Title"] = "";// strTitle;
            //gvSummary.Columns[intColumnToHide].Visible = false;
        }

        private int ColumnNumber()
        {
            if (ViewState["ShowCost"].ToString().Equals("P"))
                return 4;
            else if (ViewState["ShowCost"].ToString().Equals("M"))
                return 6;
            else
                return -1;
            //if (ViewState["ShowCost"].ToString().Equals("P"))
            //    return 3;
            //else if (ViewState["ShowCost"].ToString().Equals("M"))
            //    return 4;
            //else
            //    return -1;
        }

        private void DrawSpecialGrid()
        {
            if (ViewState["typeof"].ToString().Equals("0"))
                return;
            DataTable tbl = Data.OptionalBenefits(session_id);
            gvspecial.DataSource = tbl;
            gvspecial.DataBind();
        }

        private void DrawGrig()
        {
            if (ViewState["typeof"].ToString().Equals("0"))
            {
                DataTable tbl = Data.OptionalBenefits(session_id);
                foreach (DataRow dr in tbl.Rows)
                {
                    if (dr["Category_PlanCode"].ToString().Equals("001LIF-CYL"))
                    {
                        decimal bl = Convert.ToDecimal(dr["multiplier_override"]);
                        dr["BenefitLevel"] = String.Format("{0:C}", bl);
                    }
                }
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["End Date"].ToString()))
                    {
                        DateTime dtermdate = Convert.ToDateTime(dr["End Date"].ToString());
                        if (DateTime.Today > dtermdate)
                            dr.Delete();
                    }
                }
                tbl.AcceptChanges();

                //int col_number = ColumnNumber();
                ////lblCostBase.Visible = true;
                //if (!col_number.Equals(-1))
                //{
                //    gvSummary.Columns[col_number].Visible = true;
                //    string strheader = Data.PerpayText(ViewState["Selected_Account_Number"].ToString());
                //    if (!string.IsNullOrEmpty(strheader))
                //        gvSummary.Columns[col_number].HeaderText = strheader;
                //}
                //else
                //    lblCostBase.Visible = false;

                gvSummary.DataSource = tbl;
                gvSummary.DataBind();
            }
            DataTable tblDep = Data.GetDependentsListActive(ViewState["Employee_Number"].ToString());
            gvDep.DataSource = tblDep;
            gvDep.DataBind();
            if (tblDep.Rows.Count.Equals(0))
                lblNoDependent.Visible = true;

            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            DataTable tblPend = Data.GetBenefitStatmentPendingList(session_id, conn);
            if (!tblPend.Rows.Count.Equals(0))
            {
                gvEOI.DataSource = tblPend;
                gvEOI.DataBind();
            }
            else
            {
                gvEOI.Visible = false;
                lblNoPendingElection.Visible = true;
                divPendingInstruction.Visible = false;
            }
            tx.Rollback();
            SQLStatic.SQL.CloseConnection(conn);
            if (Data.benefitpagevisible(ViewState["Selected_Account_Number"].ToString()))
            {
                Label2.Visible = true;
                DataTable tblBenef = Data.GetBeneficiary(session_id);
                if (!tblBenef.Rows.Count.Equals(0))
                {
                    gvBenefit.DataSource = tblBenef;
                    gvBenefit.DataBind();
                }
                else
                {
                    gvBenefit.Visible = false;
                    lblNoBeneficireies.Visible = true;
                }
            }
            //if (ViewState["typeof"].ToString().Equals("0"))
            //{
            //    DataTable tbl = Data.OptionalBenefits(session_id);
            //    foreach (DataRow dr in tbl.Rows)
            //    {
            //        if (dr["Category_PlanCode"].ToString().Equals("001LIF-CYL"))
            //        {
            //            decimal bl = Convert.ToDecimal(dr["multiplier_override"]);
            //            dr["BenefitLevel"] = String.Format("{0:C}", bl);
            //        }
            //    }
            //    foreach (DataRow dr in tbl.Rows)
            //    {
            //        if (!string.IsNullOrEmpty(dr["End Date"].ToString()))
            //        {
            //            DateTime dtermdate = Convert.ToDateTime(dr["End Date"].ToString());
            //            if (DateTime.Today > dtermdate)
            //                dr.Delete();
            //        }
            //    }
            //    tbl.AcceptChanges();
            //    if (ViewState["ShowCost"].ToString().Equals("P"))
            //    {
            //        if ((bool)ViewState["RetaAccount"])
            //            SetGrid(tbl, "PerPayCost", "Your Total<br>Monthly Cost", 4);
            //        else
            //            SetGrid(tbl, "PerPayCost", "Your Total<br>Perpay Cost", 4);
            //    }
            //    else if (ViewState["ShowCost"].ToString().Equals("M"))
            //        SetGrid(tbl, "MonthlyCost", "Total<br>Monthly Cost", 3);
            //    else
            //        SetGrid(tbl, "", "", -1);
            //    //AddRow(tbl);
            //    ViewState["GoAhead"] = "No";
            //    gvSummary.DataSource = tbl;
            //    gvSummary.DataBind();
            //}
            //DataTable tblDep = Data.GetDependentsListActive(ViewState["Employee_Number"].ToString());
            //gvDep.DataSource = tblDep;
            //gvDep.DataBind();
            //if (tblDep.Rows.Count.Equals(0))
            //    lblNoDependent.Visible = true;

            //Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            //Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            //DataTable tblPend = Data.GetBenefitStatmentPendingList(session_id, conn);
            //if (!tblPend.Rows.Count.Equals(0))
            //{
            //    gvEOI.DataSource = tblPend;
            //    gvEOI.DataBind();
            //}
            //else
            //{
            //    gvEOI.Visible = false;
            //    lblNoPendingElection.Visible = true;
            //    divPendingInstruction.Visible = false;
            //}
            //tx.Rollback();
            //SQLStatic.SQL.CloseConnection(conn);
            //if (Data.benefitpagevisible(ViewState["Selected_Account_Number"].ToString()))
            //{
            //    Label2.Visible = true;
            //    DataTable tblBenef = Data.GetBeneficiary(session_id);
            //    if (!tblBenef.Rows.Count.Equals(0))
            //    {
            //        gvBenefit.DataSource = tblBenef;
            //        gvBenefit.DataBind();
            //    }
            //    else
            //    {
            //        gvBenefit.Visible = false;
            //        lblNoBeneficireies.Visible = true;
            //    }
            //}
        }

        protected void gvSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvSummary.DataSource;
            if (dt == null)
                return;
            try
            {
                if (e.Row.RowIndex.Equals(-1))
                {
                    if (ViewState["GoAhead"].ToString().Equals("No"))
                    {
                        Label lblhdr = new Label();
                        lblhdr.ID = "lblhedr";
                        lblhdr.Text = "Core/Optional<br />Benefit";
                        TableCell cellhdr = e.Row.Cells[3];
                        cellhdr.Controls.Add(lblhdr);

                        Label lblMonth = new Label();
                        lblMonth.ID = "lblMonth";
                        lblMonth.Text = "Your + Trustor<br>Monthly Cost";
                        TableCell cellMonthly = e.Row.Cells[6];
                        cellMonthly.Controls.Add(lblMonth);

                        Label lblPerpay = new Label();
                        lblPerpay.ID = "lblPerpay";
                        string cost_label = Data.PerpayText(ViewState["Selected_Account_Number"].ToString());
                        if (!string.IsNullOrEmpty(cost_label))
                            lblPerpay.Text = cost_label;
                        else
                        {
                            if ((bool)ViewState["RetaAccount"])
                                lblPerpay.Text = "Your&nbsp;&nbsp;&nbsp;<br />Monthly<br />Cost&nbsp;&nbsp;&nbsp;";
                            else
                                lblPerpay.Text = "Your&nbsp;&nbsp;&nbsp;<br />Perpay<br />Cost&nbsp;&nbsp;&nbsp;";
                        }
                        //lblPerpay.Text = "Your&nbsp;&nbsp;&nbsp;<br />Monthly<br />Cost&nbsp;&nbsp;&nbsp;";
                        TableCell cellPerpay = e.Row.Cells[4];
                        cellPerpay.Controls.Add(lblPerpay);

                        Label lblTrustor = new Label();
                        lblTrustor.ID = "lblTrustor";
                        lblTrustor.Text = "Trustor<br>Monthly<br>Cost ";
                        TableCell cellTrustor = e.Row.Cells[5];
                        cellTrustor.Controls.Add(lblTrustor);

                        ViewState["GoAhead"] = "Yes";
                        return;
                    }
                    Label lbl = new Label();
                    lbl.ID = "lbl_Title";
                    lbl.Text = ViewState["Total_Title"].ToString();
                    TableCell cell = e.Row.Cells[3];
                    cell.Controls.Add(lbl);

                    Label lbl2 = new Label();
                    lbl2.ID = "lbl_Value";
                    lbl2.Text = ViewState["Total_Value"].ToString();
                    TableCell cell2 = null;
                    if (ViewState["ShowCost"].ToString().Equals("P"))
                        cell2 = e.Row.Cells[4];
                    if (ViewState["ShowCost"].ToString().Equals("M"))
                        cell2 = e.Row.Cells[6];

                    cell2.Controls.Add(lbl2);

                    //Label lbl2 = new Label();
                    //lbl2.ID = "lbl_Value";
                    //lbl2.Text = ViewState["Total_Value"].ToString();
                    //TableCell cell2 = e.Row.Cells[4];
                    //cell2.Controls.Add(lbl2);
                }
                else
                {
                    HyperLink hl = new HyperLink();
                    hl.ID = "hl_" + dt.Rows[e.Row.RowIndex]["BenefitGroupID"].ToString();
                    hl.Text = dt.Rows[e.Row.RowIndex]["GroupTypeName"].ToString();
                    hl.NavigateUrl = dt.Rows[e.Row.RowIndex]["URL"].ToString();
                    TableCell cell3 = e.Row.Cells[0];
                    cell3.Controls.Add(hl);
                }
            }
            catch
            {
            }

        }

        private string headername()
        {
            if (ViewState["ShowCost"].ToString().Equals("P"))
                return "Your per Pay Cost";
            else if (ViewState["ShowCost"].ToString().Equals("M"))
                return "Monthly Cost";
            else if (ViewState["ShowCost"].ToString().Equals("E"))
                return "Your Monthly Cost";
            return "";
        }

        private string value(DataRow dr)
        {
            if (ViewState["ShowCost"].ToString().Equals("P"))
                return dr["PerPayCost"].ToString();
            else if (ViewState["ShowCost"].ToString().Equals("M"))
                return dr["MonthlyCost"].ToString();
            else if (ViewState["ShowCost"].ToString().Equals("E"))
                return dr["EEMonthlyCost"].ToString(); ;
            return "";
        }

        protected void gvSummary_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = (DataTable)gvSummary.DataSource;
            if (dt == null)
                return;
            if (e.Row.RowType == DataControlRowType.Footer)
                return;
            string strIndex = e.Row.RowIndex.ToString();
            try
            {
                if (e.Row.RowIndex.Equals(-1))
                {

                    Label lblhdr = new Label();
                    lblhdr.ID = "lblhedr";
                    lblhdr.Text = headername();
                    TableCell cellhdr = e.Row.Cells[4];
                    cellhdr.Controls.Add(lblhdr);
                }
                else
                {
                    Label lblValue = new Label();
                    lblValue.ID = "lblValue" + strIndex;
                    lblValue.Text = value(dt.Rows[e.Row.RowIndex]);
                    TableCell cellhdr = e.Row.Cells[4];
                    cellhdr.Controls.Add(lblValue);
                }
            }
            catch { }
        }
    }
}