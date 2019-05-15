using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;using System.Data;

namespace Dependents_Maintenance
{
    public partial class Default2 : System.Web.UI.Page
    {
     
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Params["stay"]))
            {
                if (string.IsNullOrEmpty(Request.Params["OE"]))
                    Response.Redirect("DefaultOld.aspx?SkipCheck=YES", true);
                if (SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE").Equals("L"))
                    Response.Redirect("DefaultOld.aspx?SkipCheck=YES", true);
            }
            if (string.IsNullOrEmpty(Request.Cookies["Session_ID"].Value.ToString()))
            {
                Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Your Session has timed out", true);
                return;
            }
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
                dvChoise.Visible = false;
                dvRemoveCvrg.Visible = false;
                HidOE.Value = SQLStatic.Sessions.GetSessionValue(session_id, "SESSION_CALLING_MODULE");
                if (inOE())
                {
                    //dvTop.Visible = false;
                    dvAll.Attributes["class"] = "fullWidth";
                    setPageText();
                }
                else
                    dvAll.Attributes["class"] = "AddEditMain";
                if (!string.IsNullOrEmpty(Request.Params["OE"]))
                    dvHeaderText.Visible = false;
                rgNeedDoc.MasterTableView.GetColumn("Submit_doc_link").ItemStyle.ForeColor = System.Drawing.Color.Blue;
            }
            if (!string.IsNullOrEmpty(HidDeoID.Value))
            {
                dvAll.Visible = false;
                dvChoise.Visible = true;
                SetDepName(HidDeoID.Value);
                ViewState["TermDep"] = HidDeoID.Value;
                HidDeoID.Value = string.Empty;
            }
            if(!string.IsNullOrEmpty(hiRemove.Value))
            {
                hiRemove.Value = string.Empty;
                dvRemoveCvrg.Visible = false;
                string TerminationDate = Data.LastDayInCurrentYear(ViewState["Selected_Account_Number"].ToString());
                Data.terminate_All_dep_cvrg(ViewState["TermDep"].ToString(), ViewState["Processing_Year"].ToString(),
                    TerminationDate, "1000", ViewState["User_Name"].ToString());
                btnCancel_Click(null, null);
            }
        }

        private void SetDepName(string DeoNo)
        {
            DataTable tbl = Data.get_dependent(DeoNo);
            if (!tbl.Rows.Count.Equals(0))
            {
                string Name = "<span class='fontweight'>" + tbl.Rows[0]["last_name"].ToString() + ", " + tbl.Rows[0]["first_name"].ToString() +
                    " " +tbl.Rows[0]["middle_initial"].ToString()+ "</span> ";
                lblDeoName.Text = lblDeoName.Text.Replace("[detail]", Name);
            }
        }

        private bool inOE()
        {
            return !string.IsNullOrEmpty(Request.Params["OE"]);
        }

        private void setPageText()
        {

            lblInstuction.Text = Data.GetText(session_id, "9");
        }


        protected DataTable GetDepList(string certify_flag)
        {
            DataTable tbl = null;
            if (cbShowActiveOnly.Checked)
            {
                tbl = Data.GetDependentsListActive(ViewState["Employee_Number"].ToString(), certify_flag);                
            }
            else
            {
                tbl = Data.GetDependentsList(ViewState["Employee_Number"].ToString(), certify_flag);
            }
            if (tbl.Rows.Count.Equals(0))
                if (certify_flag.Equals("0"))
                    dvnoDoc.Visible = false;
                else
                    dvDoc.Visible = false;

            return tbl;
        }

        protected void rgDep_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgDep.DataSource = GetDepList("0");
        }

        protected void DrawDepListGrid()
        {
            rgDep.DataSource = GetDepList("0");
            rgDep.DataBind();
        }

        protected void rgDep_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DropDownList ddl = (DropDownList)item["Action"].FindControl("ddlAction");
                
                ListItem li = new ListItem("Select..", "0");
                ddl.Items.Add(li);

                ListItem li1 = new ListItem("Edit", "1");
                ddl.Items.Add(li1);

                ListItem li2 = new ListItem("Remove", "2");
                ddl.Items.Add(li2);
            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridDataItem item in rgDep.MasterTableView.Items)
            {
                if ((DropDownList)item["Action"].FindControl("ddlAction") == (DropDownList)sender)
                {
                    try
                    {
                        DropDownList ddl = (DropDownList)sender;
                        string DepNo = item.GetDataKeyValue("dependent_sequence_no").ToString();
                        string dep_record_id = Data.Rec_Id_From_Dep_no(DepNo);

                        SQLStatic.Sessions.SetSessionValue(session_id, "dep_record_id", dep_record_id);
                        SQLStatic.Sessions.SetSessionValue(session_id, "DepNo", DepNo);
                        if(inOE())
                            SQLStatic.Sessions.SetSessionValue(session_id, "ininOE", "1");
                        else
                            SQLStatic.Sessions.SetSessionValue(session_id, "ininOE", "0");

                        if (ddl.SelectedValue.Equals("1"))
                        {
                            string strParam = "?id=" + dep_record_id + "&dep_id=" + DepNo;                            
                            ShowRadWindow("1", strParam);                           
                        }
                        else  if (ddl.SelectedValue.Equals("2"))
                        {
                            if (ViewState["User_Group_ID"].ToString() == "3")
                            {
                                string strParam = "?id=" + dep_record_id + "&dep_id=" + DepNo;
                                ShowRadWindow("2", strParam);
                            }
                            else
                            {
                                string strParam = "?id=" + dep_record_id + "&dep_id=" + DepNo + "&back=" + Request.Path;
                                ShowRadWindow("3", strParam);
                            }
                        }

                            
                    }
                    catch
                    {
                        throw;
                    }
                    break;
                }
            }

        }

        protected void cbShowActiveOnly_CheckedChanged(object sender, EventArgs e)
        {
            DrawDepListGrid();
            DrawDepListGridNeedDoc();
        }

        protected void ShowRadWindow(string code, string strParam)
        {
            if (inOE())
            {
                if (code.Equals("1"))
                    lblScript.Text = "<script>try {window.parent.EditDep('" + strParam + "'); } catch (err) { };</script>";
                else
                    lblScript.Text = "<script>try {window.parent.RemoveDep('" + strParam + "'); } catch (err) { };</script>";
                return;
            }
            strParam = string.Empty;
            RadWindow window1 = new RadWindow();
            
            if (code.Equals("1"))
            {
                window1.NavigateUrl = "AddEditDep.aspx" + strParam;
                window1.VisibleOnPageLoad = true;
                window1.Modal = true;
                window1.Width = 750;
                window1.Height = 450;
                window1.VisibleStatusbar = false;
                window1.VisibleTitlebar = false;
                window1.OnClientClose = "OnClientclose";
                this.Form.Controls.Add(window1);
                return;
            }

            if (code.Equals("2"))
            {
                window1.NavigateUrl = "RemoveDep.aspx" + strParam;
                window1.VisibleOnPageLoad = true;
                window1.Modal = true;
                window1.Width = 550;
                window1.Height = 400;
                window1.VisibleStatusbar = false;
                window1.VisibleTitlebar = false;
                window1.OnClientClose = "OnClientclose";
                this.Form.Controls.Add(window1);
                return;
            }

            if (code.Equals("3"))
            {
                window1.NavigateUrl = "RemoveDepNew.aspx" + strParam;// "/WEB_PROJECTS/Dependent_Terminate/Default.aspx" + strParam;
                window1.VisibleOnPageLoad = true;
                window1.Modal = true;
                window1.Width = 600;
                window1.Height = 400;
                window1.VisibleStatusbar = false;
                window1.VisibleTitlebar = false;
                window1.OnClientClose = "OnClientclose";
                this.Form.Controls.Add(window1);
                return;
            }
        }       

        protected void rgNeedDoc_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgNeedDoc.DataSource = GetDepList("1");
            rgNeedDoc.MasterTableView.GetColumn("Submit_doc_link").ItemStyle.ForeColor = System.Drawing.Color.Blue;
        }

        protected void DrawDepListGridNeedDoc()
        {
            rgNeedDoc.DataSource = GetDepList("1");
            rgNeedDoc.DataBind();
            rgNeedDoc.MasterTableView.GetColumn("Submit_doc_link").ItemStyle.ForeColor = System.Drawing.Color.Blue;
        }

        protected void btnAddDependent_Click(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetSessionValue(session_id, "dep_record_id", "-1");
            SQLStatic.Sessions.SetSessionValue(session_id, "DepNo", "-1");
            string strParam = "?id=-1&dep_id=-1";
            ShowRadWindow("1", strParam);
        }

        protected void btnTerm_Click(object sender, EventArgs e)
        {
            //lblScript.Text = "<script type='text/javascript'>RemoveDepCvrg('123');</script>";
            dvRemoveCvrg.Visible = true;
            btnTerm.Visible = false;
        }

        protected void btnGetDocs_Click(object sender, EventArgs e)
        {
            string strDepNo = SQLStatic.Sessions.GetSessionValue(session_id, "DEPENDDEP");
            lblScript.Text = "<script type='text/javascript'>Process('" + strDepNo + "');</script>";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnNo_Click(null,null);
            dvAll.Visible = true;
            dvChoise.Visible = false;
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            dvRemoveCvrg.Visible = false;
            btnTerm.Visible = true;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            string TerminationDate = Data.LastDayInCurrentYear(ViewState["Selected_Account_Number"].ToString());
            Data.terminate_All_dep_cvrg(ViewState["TermDep"].ToString(), ViewState["Processing_Year"].ToString(),
                TerminationDate, "1000", ViewState["User_Name"].ToString());
            btnCancel_Click(null, null);
        }
       
    }
}