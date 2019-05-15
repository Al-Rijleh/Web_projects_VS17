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

namespace NewHireWizard
{
    public partial class Start : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            #region BasTemplate
            if (!IsPostBack)
            {
                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
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
                ViewState["pageid"] = "0";
                if (!ViewState["User_Group_ID"].ToString().Equals("1"))
                {
                    if (!string.IsNullOrEmpty(ViewState["Selected_Account_Number"].ToString()))
                        btnPendingNewHireRecords.Visible = Data.CanEditPending(ViewState["Selected_Account_Number"].ToString());
                }
                
                CheckClose();
                jscriptsFunctions.Utilities.SetHeaderFrame(Page, "New Hire Wizard", " ", " ");
                if (Request.Params["Pend"] != null)
                    if (Request.Params["Pend"].Equals("1"))
                        btnPendingNewHireRecords_Click(null, null);
                btnStartNewEmployee.Focus();
            }
            if (!string.IsNullOrEmpty(hid1.Value))
            {
                Data.ApprovePending(session_id, hid1.Value);
                hid1.Value = "";
            }

            if (!string.IsNullOrEmpty(hid2.Value))
            {
                Data.DisapprovePending(session_id, hid2.Value);
                hid2.Value = "";
            }

            if (!string.IsNullOrEmpty(hid3.Value))
            {
                Data.RemoveInComplete(session_id, hid3.Value);
                hid3.Value = "";                
            }
            DrawGrid();
            DrawGrid2();
        }

        private void CheckClose()
        {
            DataSet ds = null;
            ds = Data.IncompleteNewHire(session_id);
            if (!ds.Tables[0].Rows.Count.Equals(0))
                return;
            ds = Data.PendingNewHire(session_id);
            if (ds.Tables[0].Rows.Count.Equals(0))
                btnStartNewEmployee_Click(null, null);
        }     

        protected void dgCB_EditCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            
            string EmployeeNumber = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["employee_number"].ToString();
            Data.SetProcessIncompleteNewHire(session_id, EmployeeNumber);
            Response.Redirect("Account_Division_Class_PaySchedule.aspx?old-1",true);
        }

        protected void btnStartNewEmployee_Click(object sender, EventArgs e)
        {
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                SQLStatic.Sessions.SetSessionValue(session_id, "NH_EMPLOYEE_NUMBER", "0", conn);
                SQLStatic.Sessions.SetSessionValue(session_id, "2NDTITLE", "", conn);
                Data.Clear_Session_Data(session_id, conn);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            //Response.Redirect("Account_Division_Class_PaySchedule.aspx",true);
            Response.Redirect("SelectAccount.aspx", true);

        }        

        protected void dgCB_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Approve"))
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                string EmployeeNumber = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["employee_number"].ToString();
                string strDoApprove = "<script>Approve(" + EmployeeNumber + ")</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strDoApprove", strDoApprove);
            }
            else if (e.CommandName.Equals("Decline"))
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                string EmployeeNumber = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["employee_number"].ToString();
                string strDoApprove = "<script>DisApprove(" + EmployeeNumber + ")</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strDoApprove", strDoApprove);
            }

            else if (e.CommandName.Equals("Remove"))
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                string EmployeeNumber = editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["employee_number"].ToString();
                string strDoApprove = "<script>RemovePend(" + EmployeeNumber + ")</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strDoApprove", strDoApprove);
            }
        }

        private void DrawGrid()
        {
            DataTable tbl = Data.GetPendingList(session_id);
            if (tbl.Rows.Count.Equals(0))            
                lblNoPending.Visible = true;
            else
                lblNoPending.Visible = false;
            gvPending.DataSource = tbl;
            gvPending.DataBind();
        }

        private void DrawGrid2()
        {
            DataTable tbl = Data.IncompleteNewHireTable(session_id);
            if (tbl.Rows.Count.Equals(0))           
                lblNoIncomplete.Visible = true;            
            else
                lblNoIncomplete.Visible = false;  

            gvIncomp.DataSource = tbl;
            gvIncomp.DataBind();
        }

        protected void btnIncompleteNewHire_Click(object sender, EventArgs e)
        {
            btnIncompleteNewHire.Enabled = false;
            btnPendingNewHireRecords.Enabled = true;
            ViewState["pageid"] = "0";
            lblInst.Visible = false;
            dvMessage.Visible = true;
            dvGrid.Visible = true;
            dvGridPend.Visible = false;
            DrawGrid2();
            lblInstruction.Text = System.Configuration.ConfigurationManager.AppSettings["Incomplete"].Replace("]", ">").Replace("[", "<");
        }

        protected void btnPendingNewHireRecords_Click(object sender, EventArgs e)
        {
            btnIncompleteNewHire.Enabled = true;
            btnPendingNewHireRecords.Enabled = false;
            ViewState["pageid"] = "1";
            lblInst.Visible = true;
            dvMessage.Visible = true;
            dvGrid.Visible = false;
            dvGridPend.Visible = true;
            DrawGrid();
            lblInstruction.Text = System.Configuration.ConfigurationManager.AppSettings["Pending"].Replace("]", ">").Replace("[", "<");
        }

        protected void gvPending_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvPending.DataSource;
            if (tbl == null)
                return;
            int intRowIndex = e.Row.RowIndex;
            if (intRowIndex < 0)
            {
                Label lblh1 = new Label();
                lblh1.ID = "lbl_h1";
                lblh1.Text = "Action";
                lblh1.CssClass = "BackColor";
                TableCell cell_h1 = e.Row.Cells[0];
                cell_h1.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h1.Controls.Add(lblh1);

                Label lblh2 = new Label();
                lblh2.ID = "lblh2";
                lblh2.Text = "Account Name";
                lblh2.CssClass = "BackColor";
                TableCell cell_h2 = e.Row.Cells[1];
                cell_h2.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h2.Controls.Add(lblh2);

                Label lblh3 = new Label();
                lblh3.ID = "lbl_h3";
                lblh3.Text = "Employee Name";
                lblh3.CssClass = "BackColor";
                TableCell cell_h3 = e.Row.Cells[2];
                cell_h3.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h3.Controls.Add(lblh3);

                Label lblh4 = new Label();
                lblh4.ID = "lbl_h4";
                lblh4.Text = "Effective Date";
                lblh4.CssClass = "BackColor";
                TableCell cell_h4 = e.Row.Cells[3];
                cell_h4.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h4.Controls.Add(lblh4);

                Label lblh5 = new Label();
                lblh5.ID = "lbl_h5";
                lblh5.Text = "Class Description";
                lblh5.CssClass = "BackColor";
                TableCell cell_h5 = e.Row.Cells[4];
                cell_h5.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h5.Controls.Add(lblh5);
                return;
            }
            try
            {
                /*
                Button btnApprove = new Button();
                btnApprove.ID = "gvPending_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                btnApprove.Text = "Approve";
                string strParam = tbl.Rows[intRowIndex]["employee_number"].ToString() + ",\"" + tbl.Rows[intRowIndex]["ee_name"].ToString() + "\"";
                 * btnApprove.Attributes.Add("onclick", "Approve(" + strParam + "); return false;");  
                */

                string strParam = string.Empty;
                Button btnApprove = new Button();
                btnApprove.Width = System.Web.UI.WebControls.Unit.Pixel(65);
                btnApprove.ID = "gvPending_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                if (tbl.Rows[intRowIndex]["effective_date"].ToString().Equals("Missing"))
                {
                    btnApprove.Text = "Add Class";
                    string strPar = tbl.Rows[intRowIndex]["employee_number"].ToString();
                    btnApprove.Attributes.Add("onclick", "Missing(" + strPar + "); ");
                    //btnApprove.Visible = false;
                }
                else
                {
                    if (!tbl.Rows[intRowIndex]["require_verify"].ToString().Equals("0"))
                    {
                        btnApprove.Text = "Verify";
                        string strPar = tbl.Rows[intRowIndex]["employee_number"].ToString();
                        btnApprove.Attributes.Add("onclick", "Verify(" + strPar + "); return false;");
                    }
                    else
                    {
                        btnApprove.Text = "Approve";
                        strParam = tbl.Rows[intRowIndex]["employee_number"].ToString() + ",\"" + tbl.Rows[intRowIndex]["ee_name"].ToString() + "\"";
                        btnApprove.Attributes.Add("onclick", "Approve(" + strParam + "); return false;");
                    }
                }

                              
                Label lbl = new Label();
                lbl.ID = "lbl_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                lbl.Text = "&nbsp;";

                Button btnDisApprove = new Button();
                btnDisApprove.ID = "btnDisApprove_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                btnDisApprove.Text = "Decline";
                btnDisApprove.Attributes.Add("onclick", "DisApprove(" + strParam + "); return false;");

                Label lbl2 = new Label();
                lbl2.ID = "lbl2_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                lbl2.Text = "&nbsp;";

                Button btnEdit = new Button();
                btnEdit.ID = "btnEdit_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                btnEdit.Text = "Edit";
                btnEdit.Click += new System.EventHandler(this.btnEdit_Click);                

                TableCell cell_btn = e.Row.Cells[0];
                cell_btn.Controls.Add(btnEdit);
                cell_btn.Controls.Add(lbl2);
                if (btnApprove.Text.Equals("Verify"))
                {
                    if (ViewState["User_Group_ID"].ToString().Equals("1"))
                        cell_btn.Controls.Add(btnApprove);
                }
                else
                    cell_btn.Controls.Add(btnApprove);
                //cell_btn.Controls.Add(btnApprove);
                cell_btn.Controls.Add(lbl);
                cell_btn.Controls.Add(btnDisApprove);
                
                
            }
            catch
            {
            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            string EmployeeNumber = (sender as Button).ID.Replace("btnEdit_","") ;
            Data.SetProcessIncompleteNewHire(session_id, EmployeeNumber);
            Response.Redirect("Account_Division_Class_PaySchedule.aspx?old-1", true);
        }

        protected void gvIncomp_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvIncomp.DataSource;
            if (tbl == null)
                return;
            int intRowIndex = e.Row.RowIndex;
            if (intRowIndex < 0)
            {
                Label lblh1 = new Label();
                lblh1.ID = "lbl_h1";
                lblh1.Text = "Action";
                lblh1.CssClass = "BackColor";
                TableCell cell_h1 = e.Row.Cells[0];
                cell_h1.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h1.Controls.Add(lblh1);

                Label lblh2 = new Label();
                lblh2.ID = "lblh2";
                lblh2.Text = "Account Name";
                lblh2.CssClass = "BackColor";
                TableCell cell_h2 = e.Row.Cells[1];
                cell_h2.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h2.Controls.Add(lblh2);

                Label lblh3 = new Label();
                lblh3.ID = "lbl_h3";
                lblh3.Text = "Employee Name";
                lblh3.CssClass = "BackColor";
                TableCell cell_h3 = e.Row.Cells[2];
                cell_h3.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h3.Controls.Add(lblh3);

                Label lblh4 = new Label();
                lblh4.ID = "lbl_h4";
                lblh4.Text = "Effective Date";
                lblh4.CssClass = "BackColor";
                TableCell cell_h4 = e.Row.Cells[3];
                cell_h4.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h4.Controls.Add(lblh4);

                Label lblh5 = new Label();
                lblh5.ID = "lbl_h5";
                lblh5.Text = "Class Description";
                lblh5.CssClass = "BackColor";
                TableCell cell_h5 = e.Row.Cells[4];
                cell_h5.BackColor = System.Drawing.Color.FromName("#f4ede1");
                cell_h5.Controls.Add(lblh5);
                return;
            }
            try
            {
                

                Button btnRemove = new Button();
                btnRemove.ID = "btnRemove_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                btnRemove.Text = "Remove";
                btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

                Label lbl2 = new Label();
                lbl2.ID = "lbl2_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                lbl2.Text = "&nbsp;";

                Button btnEdit = new Button();
                btnEdit.ID = "btnEdit_" + tbl.Rows[intRowIndex]["employee_number"].ToString();
                btnEdit.Text = " Edit ";                
                btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

                TableCell cell_btn = e.Row.Cells[0];                
                cell_btn.Controls.Add(btnEdit);
                cell_btn.Controls.Add(lbl2);
                cell_btn.Controls.Add(btnRemove);
            }
            catch
            {
            }
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            string EmployeeNumber = (sender as Button).ID.Replace("btnRemove_", "");
            string strDoApprove = "<script>RemovePend(" + EmployeeNumber + ")</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strDoApprove", strDoApprove);
        }
    }
}
