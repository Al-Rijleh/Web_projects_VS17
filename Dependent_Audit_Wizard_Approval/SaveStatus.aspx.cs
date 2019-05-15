using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dependent_Audit_Wizard_Approval
{
    public partial class SaveStatus : System.Web.UI.Page
    {
        string strDecline = "Are you sure you want to DECLINE selected document from dependent ";
        string strApprove = "Are you sure you want to APPROVE selected document from dependent ";
        string strReq = "Request more information for the selected document from dependent ";
        string strDeclineTitle = "Decline Selected Document";
        string strApproveTitle = "Approve Selected Document";
        string strReqTitle = "Required Information";
        string strReasonDeclineLabe = "Please, enter the reason for declining this document";
        string strReasonReqLabe = "Please, enter the reason for requesting more information";
        string strNavigateUrl = "Javascript:ViewDoc('[id]')";

        string session_id = string.Empty;
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
                DataTable tbl = Data.DepNameFromDocID(Request.Params["docdocId"]);
                string DepName = string.Empty;               
                if (!tbl.Rows.Count.Equals(0))
                {
                    DepName = tbl.Rows[0]["DepName"].ToString();
                    ViewState["ReqDoc"] = tbl.Rows[0]["Req_doc"].ToString();
                    ViewState["DepNo"] = tbl.Rows[0]["dependent_sequence_no"].ToString();
                    ViewState["EENO"] = tbl.Rows[0]["employee_number"].ToString();
                    hlDocLink.NavigateUrl = strNavigateUrl.Replace("[id]",tbl.Rows[0]["r_log_record_id"].ToString());                    
                    lblDependentName.Text = "Dependent: "+ DepName;
                    dvApproveWarning.Visible = false;
                    dvConfirmSave.Visible = false;
                    dvDDIC.Visible = false;
                    dvDepStatus.Visible = false;
                    dvDes.Visible = false;
                    dvDepStatus.Visible = false;
                }

                if (!string.IsNullOrEmpty(Request.Params["FDIC"]))
                {
                    dvDes.Visible = true;
                    dvDDIC.Visible = true;
                    dvDepStatus.Visible = true;
                    dvDocCount.Visible = false;
                    RequiredFieldValidator2.Visible = false;
                    lblReqDoc.Visible = false;
                    SetFDICStatus();
                }
                else
                {
                    btnSave.Visible = true;
                }


                if (Request.Params["code"].Equals("1"))
                {
                    lblInformation.Text = strApprove.Replace("[doc]", Request.Params["docName"]) + DepName;
                    lblTitle.Text = strApproveTitle;
                    lblReqDoc.Text = "This dependent requires <b>" + ViewState["ReqDoc"].ToString() + "</B> documents to be approved";
                    if (ViewState["ReqDoc"].ToString().Equals("1"))
                        txtDocCountRad.Text = "1";
                    dvReason.Visible = false;
                    dvApproveInfo.Visible = true;
                    txtDocCountRad.Enabled = !ViewState["ReqDoc"].ToString().Equals("1");
                    if (!txtDocCountRad.Enabled)
                        txtDocCountRad.Text = "1";
                }

                if (Request.Params["code"].Equals("2"))
                {
                    lblInformation.Text = strDecline.Replace("[doc]", Request.Params["docName"]) + DepName;
                    lblTitle.Text = strDeclineTitle;
                    lblResonTitle.Text = strReasonDeclineLabe;
                    dvReason.Visible = true;
                    dvApproveInfo.Visible = false;
                }
                if (Request.Params["code"].Equals("3"))
                {
                    lblInformation.Text = strReq.Replace("[doc]", Request.Params["docName"]) + DepName;
                    lblTitle.Text = strReqTitle;
                    lblResonTitle.Text = strReasonReqLabe;
                    dvReason.Visible = true;
                    dvApproveInfo.Visible = false;
                }
            }
        }

        private void SetFDICStatus()
        {
            string record_id = Request.Params["docdocId"];
            DataTable tbl = Data.DocumentStatusForStatus(record_id);
            rblApproval.Items[0].Selected = false;
            rblApproval.Items[1].Selected = false;
            try
            {
                lblDepStatus.Text = "Current Status: <b>" + tbl.Rows[0]["status"].ToString()+"</b>";
                try
                {
                    //rblApproval.Items.FindByText( (tbl.Rows[0]["status"].ToString()).Selected = true;
                    if (tbl.Rows[0]["StatusNo"].ToString().ToString().Contains("1"))
                        rblApproval.Items[0].Selected = true;
                    if (tbl.Rows[0]["StatusNo"].ToString().ToString().Contains("2"))
                        rblApproval.Items[1].Selected = true;
                }
                catch { }

                ViewState["Dep_no"] = tbl.Rows[0]["dependent_sequence_no"].ToString();
                rblApproval_SelectedIndexChanged(null, null);
                //    if ((tbl.Rows[0]["DocStatus_id"].ToString().Equals("1")) ||
                //        (tbl.Rows[0]["status"].ToString().Equals("Approved")))
                //    {

                //        try
                //        {
                //            rblApproval.Items.FindByText(tbl.Rows[0]["status"].ToString()).Selected = true;
                //        }
                //        catch { }
                //        //btApply.Visible = true;
                //        dvDes.Visible = true;

                //    }
                //    else
                //    {
                //        dvDes.Visible = false;
                //        lblDepStatus.Text = string.Empty;
                //    }

                //    rblApproval_SelectedIndexChanged(null, null);
                //    //btApply.Visible = !rblApproval.SelectedIndex.Equals(0);

                //}
                //catch
                //{
                //    dvDes.Visible = false;


                //}

            }
            catch { }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string strClose = "<script>Javascript:closeWindow(1);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["FDIC"]))
                btApply_Click(null, null);
            string use_name = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
            if (Request.Params["code"].Equals("2"))
            {
               Data.Decline_Documnent(Request.Params["docdocId"], txtReason.Text, use_name);
               string strClose = "<script>Javascript:closeWindow(3);</script>";
               Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
               return;
            }
            else if (Request.Params["code"].Equals("3"))
            {
                Data.Require_Info(Request.Params["docdocId"], txtReason.Text, use_name);
                string strClose = "<script>Javascript:closeWindow(3);</script>";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                return;
            }
            else if (Request.Params["code"].Equals("1"))
            {
                if (string.IsNullOrEmpty(Request.Params["FDIC"]))
                {
                    if (Convert.ToInt16(txtDocCountRad.Text) < Convert.ToInt16(ViewState["ReqDoc"]))
                    {
                        string strDocumentCount = Data.ExistDocumentCount(ViewState["DepNo"].ToString());
                        if (Convert.ToInt16(strDocumentCount) < Convert.ToInt16(ViewState["ReqDoc"]))
                        {
                            dvApproveWarning.Visible = true;
                            btnSave.Visible = false;
                            return;
                        }
                    }
                }
                if (Data.approve_depndent_only(ViewState["EENO"].ToString(), SQLStatic.Sessions.GetAccountNumber(session_id)).Equals("0"))
                {
                    if (dvDocCount.Visible)
                        Data.Approve_Documnent(session_id, Request.Params["docdocId"], txtDocCountRad.Text, use_name);
                    else
                        Data.Approve_Documnent(session_id, Request.Params["docdocId"], "1", use_name);
                }
                else
                {
                    if (dvDocCount.Visible)
                        Data.Approve_Documnent_Dependent(session_id, Request.Params["docdocId"], txtDocCountRad.Text, use_name);
                    else
                        Data.Approve_Documnent_Dependent(session_id, Request.Params["docdocId"], "1", use_name);
                }

                if (Data.IsEEReadyForApproval(ViewState["EENO"].ToString()).Equals("1"))
                {
                    if (Data.approve_depndent_only(ViewState["EENO"].ToString(), SQLStatic.Sessions.GetAccountNumber(session_id)).Equals("1"))
                    {
                        if (Data.is_allow_EE_Releae(ViewState["EENO"].ToString()).Equals("0"))
                        {
                            string strClose = "<script>Javascript:closeWindow(3);</script>";
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                            return;
                        }
                    }
                    Process_Approve_EE();
                }
                else
                {
                    string strClose = "<script>Javascript:closeWindow(2);</script>";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);
                }
            }
            
        }

        private void Process_Approve_EE()
        {
            dvConfirmSave.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnFinalize.Visible = true;
        }

        protected void btnFinalize_Click(object sender, EventArgs e)
        {
            string use_name = SQLStatic.Sessions.GetUserName(Request.Cookies["Session_ID"].Value.ToString());
            if (Data.approve_depndent_only(ViewState["EENO"].ToString(), SQLStatic.Sessions.GetAccountNumber(session_id)).Equals("1"))
            {
                if (Data.is_allow_EE_Releae(ViewState["EENO"].ToString()).Equals("1"))             
                    Data. relese_All_Dep_verified(session_id,ViewState["Selected_Account_Number"].ToString(),ViewState["Employee_Number"].ToString(),
                    ViewState["Processing_Year"].ToString(),use_name);  
            }
            else
                Data.Apporve_employee(ViewState["EENO"].ToString(), use_name);
            string strClose = "<script>Javascript:closeWindow(3);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "strClose", strClose);

        }

        protected void rblApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((rblApproval.Items[0].Selected) || (rblApproval.Items[1].Selected))
                btnSave.Visible = true;
            else
                btnSave.Visible = false;
        }

        protected void btApply_Click(object sender, EventArgs e)
        {
            string strStuent = "F";
            if (rblApproval.Items[0].Selected)
                strStuent = "T";

            string strDisab = "F";
            if (rblApproval.Items[1].Selected)
                strDisab = "T";
            Data.ModifyDependentStatu(ViewState["Dep_no"].ToString(), strStuent, strDisab, ViewState["User_Name"].ToString());
        }
    }
}