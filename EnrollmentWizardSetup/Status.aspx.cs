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

namespace EnrollmentWizardSetup
{
    public partial class Status : System.Web.UI.Page
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
                SetupTabStrip1.SetTabIndex(4);
                SetAccountName();
                ViewState["rbAccount"] = rblAccounts.Items[1].Text;
                //DataTable tbl = Data.CoveragsPageItems();
                //rblItem.Items.Clear();
                //rblItem.DataTextField = "Text";
                //rblItem.DataValueField = "Value";
                //rblItem.DataSource = tbl;
                //rblItem.DataBind();
                GetText();
                FillClassCode();
                setupCurrentShowCost();
            }

            
            DrawGrid();
            DrawGridBenefit();
        }



        private void setupCurrentShowCost()
        {
            DataTable tbl = Data.GetShowCostSetting(session_id);
            GridView gv = Bas_Utility.Utilities.GetGridView(Page, "gvCurrentSetting");
            gv.DataSource = tbl;
            gv.DataBind();

            TextBox txt = Bas_Utility.Utilities.GetTextBox(Page, "txtCostColumnTitle");
            txt.Text = Data.Get_er_property_accnt(ViewState["Selected_Account_Number"].ToString(), "537");
        }

        private RadioButtonList GetRadioButtonList(string id)
        {
            return Bas_Utility.Utilities.GetRadioButtonList(Page, id);
        }

        private CheckBoxList GetCheckBoxList(string id)
        {
            return Bas_Utility.Utilities.GetCheckBoxList(Page, id);
        }

        private Label GetLabel(string id)
        {
            return Bas_Utility.Utilities.GetLabel(Page, id);
        }

        private Panel GetPanel(string id)
        {
            return Bas_Utility.Utilities.GetPanel(Page, id);
        }

        private TextBox GetTextBox(string id)
        {
            return Bas_Utility.Utilities.GetTextBox(Page, id);
        }

        private RadEditor GetRaEditor(string id)
        {
            //return Bas_Utility.Utilities.GetRadEditor(Page, id);
            return (RadEditor)Page.FindControl(id);
        }

        private DropDownList GetDropDown(string id)
        {
            return Bas_Utility.Utilities.GetDropDown(Page, id);
        }

        private GridView GetGridView(string id)
        {
            return Bas_Utility.Utilities.GetGridView(Page, id);
        }

        private void SetAccountName()
        {
            string strAccountName = "";
            if (string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
            {
                GetRadioButtonList("rblAccounts").Items[1].Enabled = false;
                GetRadioButtonList("cblAccounts").Items[1].Enabled = false;
                GetRadioButtonList("cblAccounts").Items[2].Enabled = false;
            }
            else
            {
                strAccountName = "(" + SQLStatic.AccountData.AccountName(ViewState["Selected_Account_Number"].ToString()) + ")";
            }
            GetRadioButtonList("rblAccounts").Items[1].Text = GetRadioButtonList("rblAccounts").Items[1].Text.Replace("[Accnt]", strAccountName);
            GetRadioButtonList("cblAccounts").Items[1].Text = GetRadioButtonList("cblAccounts").Items[1].Text.Replace("[Accnt]", strAccountName);
            GetRadioButtonList("cblAccounts").Items[2].Text = GetRadioButtonList("cblAccounts").Items[2].Text.Replace("[Accnt]", strAccountName);
        }

        private void GetText()
        {
            DataTable tbl = Data.GetMessageDetail(session_id, rblEnrollmentType.SelectedValue, rblItem.SelectedValue, rblAccounts.SelectedValue);
            lblText.Text = tbl.Rows[0]["page_display_value"].ToString();
            lblDescription.Text = tbl.Rows[0]["description"].ToString();
            textDescription.Text = lblDescription.Text;
            RadEditor1.Content = tbl.Rows[0]["page_display_value"].ToString();
            tbl.Dispose();

            bool has_acc = Data.Has_Account_Specific_text(ViewState["Selected_Account_Number"].ToString(), rblEnrollmentType.SelectedValue, rblItem.SelectedValue);
            if (!has_acc)
            {
                if (rblAccounts.SelectedIndex.Equals(1))
                    lblText.Text = "<span style='font-size: 26px; font-family: arial; color: #c00000;'><strong><span style='font-size: 20px;'>Using Default Text</span></strong></span>";
                rblAccounts.Items[1].Text = ViewState["rbAccount"].ToString() + "  <strong style='background-color: #ffff00;'><span style='font-family: arial; font-size: 13px; color: #c00000;'>Using Default</span></strong>";
            }
            else
            {
                rblAccounts.Items[1].Text = ViewState["rbAccount"].ToString() + "  <strong style='background-color: #ebf1dd;'><span style='font-family: arial; font-size: 13px; color: #567a31;'>Using Account Specific</span></strong>";
            }
            //DataTable tbl = Data.GetMessageDetail(session_id, rblEnrollmentType.SelectedValue, rblItem.SelectedValue, rblAccounts.SelectedValue);
            //    /*Data.GetMessageDetail(session_id, GetRadioButtonList("rblEnrollmentType").SelectedValue, GetRadioButtonList("rblItem").SelectedValue,
            //    GetRadioButtonList("rblAccounts").SelectedValue);*/
            //GetLabel("lblText").Text = tbl.Rows[0]["page_display_value"].ToString();
            //GetLabel("lblDescription").Text = tbl.Rows[0]["description"].ToString();
            //GetTextBox("textDescription").Text = GetLabel("lblDescription").Text;
            //GetRaEditor("RadEditor1").Content = tbl.Rows[0]["page_display_value"].ToString();
            //tbl.Dispose();

            //bool has_acc = Data.Has_Account_Specific_text(ViewState["Selected_Account_Number"].ToString(), rblEnrollmentType.SelectedValue, rblItem.SelectedValue);
            //if (!has_acc)
            //{
            //    if (rblAccounts.SelectedIndex.Equals(1))
            //        lblText.Text = "<span style='font-size: 26px; font-family: arial; color: #c00000;'><strong><span style='font-size: 20px;'>Using Default Text</span></strong></span>";
            //    rblAccounts.Items[1].Text = ViewState["rbAccount"].ToString() + "  <strong style='background-color: #ffff00;'><span style='font-family: arial; font-size: 13px; color: #c00000;'>Using Default</span></strong>";
            //}
            //else
            //{
            //    rblAccounts.Items[1].Text = ViewState["rbAccount"].ToString() + "  <strong style='background-color: #ebf1dd;'><span style='font-family: arial; font-size: 13px; color: #567a31;'>Using Account Specific</span></strong>";
            //}
        }



        protected void rblMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetRadioButtonList("cblAccounts").SelectedIndex = GetRadioButtonList("rblAccounts").SelectedIndex;
            Welcome.ClearRadioButtonList(GetRadioButtonList("cblAccounts"));
            GetCheckBoxList("cblEnrollmentType").SelectedIndex = GetRadioButtonList("rblEnrollmentType").SelectedIndex;
            GetPanel("dvEdit").Visible = GetRadioButtonList("rblMode").SelectedValue.Equals("1");
            GetPanel("dvView").Visible = !GetPanel("dvEdit").Visible;
        }

        protected void rblItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetText();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                foreach (ListItem li in cblEnrollmentType.Items)
                {
                    if (li.Selected)
                    {
                        foreach (ListItem lia in cblAccounts.Items)
                            if (lia.Selected)
                            {
                                Data.SaveMessageData(session_id, li.Value, rblItem.SelectedValue, lia.Value, textDescription.Text, RadEditor1.Content, conn);
                            }
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            rblMode.SelectedIndex = 0;
            dvEdit.Visible = rblMode.SelectedValue.Equals("1");
            dvView.Visible = !dvEdit.Visible;
            GetText();
            Bas_Utility.Misc.AlertSaved(Page);
            //Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            //try
            //{
            //    foreach (ListItem li in GetCheckBoxList("cblEnrollmentType").Items)
            //    {
            //        if (li.Selected)
            //        {
            //            foreach (ListItem lia in GetRadioButtonList("cblAccounts").Items)
            //                if (lia.Selected)
            //                {
            //                    Data.SaveMessageData(session_id, li.Value, GetRadioButtonList("rblItem").SelectedValue, lia.Value,
            //                        GetTextBox("textDescription").Text, GetRaEditor("RadEditor1").Content, conn);
            //                }
            //        }
            //    }
            //}
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}
            //GetRadioButtonList("rblMode").SelectedIndex = 0;
            //GetPanel("dvEdit").Visible = GetRadioButtonList("rblMode").SelectedValue.Equals("1");
            //GetPanel("dvView").Visible = !GetPanel("dvEdit").Visible;
            //GetText();
        }

        protected void btnSave_Click2(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                foreach (ListItem li in GetCheckBoxList("cblEnrollmentType2").Items)
                {
                    if (li.Selected)
                    {
                        foreach (ListItem lia in GetRadioButtonList("cblAccounts2").Items)
                            if (lia.Selected)
                            {
                                Data.SaveShowCost(session_id, li.Value, GetRadioButtonList("rbtlstShowCost").SelectedValue, lia.Value, conn);
                                //Data.SaveMessageData(session_id, li.Value, GetRadioButtonList("rblItem").SelectedValue, lia.Value,
                                //    GetTextBox("textDescription").Text, GetRaEditor("RadEditor1").Content, conn);
                            }
                    }
                }
                string strAll = "";
                RadioButtonList rbl = GetRadioButtonList("cblAccounts2");
                if (rbl.SelectedValue.Equals("1"))
                    strAll = "0";
                else
                    strAll = "1";

                //Data.save_Choice(session_id, strAll, "537", txtCostColumnTitle.Text);
                //TextBox tb = GetTextBox("txtCostColumnTitle");

                Data.save_Choice(session_id, strAll, "537", GetTextBox("txtCostColumnTitle").Text);               
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            GetRadioButtonList("rblMode").SelectedIndex = 0;
            GetPanel("dvEdit").Visible = GetRadioButtonList("rblMode").SelectedValue.Equals("1");
            GetPanel("dvView").Visible = !GetPanel("dvEdit").Visible;
            GetText();
            setupCurrentShowCost();
            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void btnSave_cvrg_Click(object sender, EventArgs e)
        {
            Response.Redirect("SkippedPlans.aspx", true);
        }

        //-----------------------------------------------
        private void FillClassCode()
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                string strAccountNumber = SQLStatic.Sessions.GetSessionValue(session_id, "Account_Number", conn);
                string strProcessing_year = Data.open_nrollment_Processing_year(strAccountNumber, conn);
                DataTable tbl = Data.GetClassCodes(strAccountNumber, strProcessing_year);
                foreach (DataRow dr in tbl.Rows)
                {
                    ListItem li = new ListItem(dr["Description"].ToString(), dr["Class_Code"].ToString());
                    GetDropDown("ddlClass").Items.Add(li);
                    GetDropDown("ddlClass2").Items.Add(li);
                }
            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }
        }

        private DataTable GetData()
        {
            RadioButtonList rblOperation_ = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblOperation");
            return Data.GetCoveragesMarkSkip(session_id, GetDropDown("ddlClass").SelectedValue, rblOperation_.SelectedValue);
        }

        private DataTable GetDataBenefit()
        {
            RadioButtonList rblOperation_ = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblOperation");
            return Data.GetCoveragesMarkSkipBenefit(session_id, GetDropDown("ddlClass2").SelectedValue, rblOperation_.SelectedValue);
        }

        private void DrawGrid()
        {
            DataTable tbl = GetData();
            GetLabel("lblWrning").Visible = tbl.Rows.Count.Equals(0) ? true : false;
            GetGridView("gvPlans").DataSource = tbl;
            GetGridView("gvPlans").DataBind();
        }

        private void DrawGridBenefit()
        {
            DataTable tbl = GetDataBenefit();
            GetLabel("lblWrningBebefit").Visible = tbl.Rows.Count.Equals(0) ? true : false;
            GetGridView("gvBenefit").DataSource = tbl;
            GetGridView("gvBenefit").DataBind();
        }

        protected void gvBenefit_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)GetGridView("gvBenefit").DataSource;
            if (tbl == null)
                tbl = GetDataBenefit();
            if (e.Row.RowIndex < 0)
                return;
            if (e.Row.RowIndex > tbl.Rows.Count)
                return;
            try
            {
                string strIndex = tbl.Rows[e.Row.RowIndex]["RECORD_ID"].ToString();
                Label lbl = new Label();


                CheckBox cbl = new CheckBox();
                cbl.ID = "cblBenefit_" + strIndex;
                cbl.Checked = tbl.Rows[e.Row.RowIndex]["SKIP_CVRG"].ToString().Equals("0");
                TableCell cell = e.Row.Cells[1];
                cell.Controls.Add(cbl);
            }
            catch
            {
            }
        }

        protected void gvPlans_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)GetGridView("gvPlans").DataSource;
            if (tbl == null)
                tbl = GetData();
            if (e.Row.RowIndex < 0)
                return;
            if (e.Row.RowIndex > tbl.Rows.Count)
                return;
            try
            {
                string strIndex = tbl.Rows[e.Row.RowIndex]["RECORD_ID"].ToString();
                Label lbl = new Label();
                lbl.ID = "lbl_" + strIndex;
                lbl.Text = tbl.Rows[e.Row.RowIndex]["core_benefit"].ToString().Equals("T") ? "Core" : "Optional";
                TableCell celllbl = e.Row.Cells[1];
                celllbl.Controls.Add(lbl);

                CheckBox cbl = new CheckBox();
                cbl.ID = "cbl_" + strIndex;
                cbl.Enabled = tbl.Rows[e.Row.RowIndex]["core_benefit"].ToString().Equals("T") ? false : true;
                cbl.Checked = tbl.Rows[e.Row.RowIndex]["SKIP_CVRG"].ToString().Equals("0");
                TableCell cell = e.Row.Cells[2];
                cell.Controls.Add(cbl);
            }
            catch
            {
            }

        }


        protected void btnSaveBenefit_Click(object sender, EventArgs e)
        {
            DoSaveBenefit();
            DrawGridBenefit();
        }

        // Save Included Coverage in OE
        protected void btnSave_Click3(object sender, EventArgs e)
        {
            DoSave();
            DrawGrid();
            Bas_Utility.Misc.AlertSaved(Page);
        }

        private void DoSave()
        {
            DataTable tbl = (DataTable)GetGridView("gvPlans").DataSource;
            if (tbl == null)
                tbl = GetData();
            string strIndex = null;
            CheckBox cb = null;
            int DoSkip = 0;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            RadioButtonList rblOperation_ = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblOperation");
            try
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    strIndex = dr["RECORD_ID"].ToString();
                    cb = Bas_Utility.Utilities.GetCheckBox(Page, "cbl_" + strIndex);
                    if (cb.Checked)
                        DoSkip = 0;
                    else
                        DoSkip = 1;
                    Data.SaveCoverageSkip(session_id, strIndex, GetRadioButtonList("rblSaveType").SelectedValue, DoSkip.ToString(), rblOperation_.SelectedValue, conn);
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

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rblOperation_ = Bas_Utility.Utilities.GetRadioButtonList(Page, "rblOperation");
            switch (rblOperation_.SelectedIndex)
            {
                case 0:
                    GetGridView("gvPlans").Columns[2].HeaderText = "Include Plans";
                    break;
                case 1:
                    GetGridView("gvPlans").Columns[2].HeaderText = "Editable Plans";
                    break;
            }
            DrawGrid();
        }

        protected void ddlClass2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGridBenefit();
        }

        private void DoSaveBenefit()
        {
            DataTable tbl = (DataTable)GetGridView("gvBenefit").DataSource;
            if (tbl == null)
                tbl = GetDataBenefit();
            string strIndex = null;
            CheckBox cb = null;
            int DoSkip = 0;
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            Oracle.DataAccess.Client.OracleTransaction tx = conn.BeginTransaction();
            try
            {
                foreach (DataRow dr in tbl.Rows)
                {
                    strIndex = dr["RECORD_ID"].ToString();
                    cb = Bas_Utility.Utilities.GetCheckBox(Page, "cblBenefit_" + strIndex);
                    if (cb.Checked)
                        DoSkip = 0;
                    else
                        DoSkip = 1;
                    Data.SaveCoverageSkipBenefit(session_id, strIndex, GetRadioButtonList("rblSaveTypeBenefit").SelectedValue, DoSkip.ToString(), conn);
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

        }

        protected void cblAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblAccounts.SelectedValue.Equals("1"))
            {
                btnClear.Visible = false;
                Bas_Utility.Misc.Alert(Page, Welcome.stAlertMessage);
            }
            else
                btnClear.Visible = true; 
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            RadEditor1.Content = string.Empty;
            btnSave_Click(null, null);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetText();
        }

        
        
    }
}
