using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace Dependent_Audit_Wizard_Approval
{
    public partial class Approve : System.Web.UI.Page
    {
        String eoLicense = "5Grc0Qng5na0wMAe6KDl5QUg8Z61kZvnrqXg5/YZ8p61kZt14+30EO2s3MKe" +
   "tZ9Zl6TNF+ic3PIEEMidtbjF37BvrrbE2691pvD6DuSn6unaD71GgaSxy591" +
   "4+30EO2s3OnP566l4Of2GfKe3MKetZ9Zl6TNDOul5vvPuIlZl6Sxy59Zl8Dy" +
   "D+NZ6/0BELxbvNO/++OfmaQHEPGs4PP/6KFtpbSzy653hI6xy59Zs7PyF+uo" +
   "7sKetZ9Zl6TNGvGd3PbaGeWol+jyH+R2mbrA3LJoqbTC3aFZ7ekDHuio5cGz" +
   "36FZpsKetZ9Zl6TNHuig5eUFIPGetczZ3OOmyNTG9+166NbF89U=";
        string session_id = "";
        bool skip = false;
        MemoryStream ms;
        string strSrc = "/web_projects/DocumentViwer/viewer.aspx?id=[id]&skip=1&type=application/pdf";
        protected void Page_Load(object sender, EventArgs e)
        {
            EO.Pdf.Runtime.AddLicense(eoLicense);
            skip = false;
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
                doStyle_2();
                
                ViewState["Crrent_Pdf"] = "-1";                
                dvDepData.Visible = false;
                dvApproval.Visible = false;
                dvimage.Visible = false;
                dvDecision.Visible = false;
                dvReson.Visible = false;
                dvAddItem.Visible = false;

                dvHeader.Visible = false;

                ddlSelectEmployee_SelectedIndexChanged(null, null);
                skip = true;
            }
            if (!skip)
                DrawGrid();
        }

        private void doStyle_2()
        {
            if (IsStyle2())
            {
                dvSelection.Visible = false;
                /*
                rblDecision.Items.Clear();
                ListItem li1 = new ListItem("Approve","2");
                rblDecision.Items.Add(li1);
                ListItem li2 = new ListItem("Disapprove", "3");
                rblDecision.Items.Add(li2);
                */
                
                lblSelectedEmployer.Text = SQLStatic.EmployeeData.Account_Name(ViewState["Employee_Number"].ToString());
                lblSelectedEmployee.Text = SQLStatic.EmployeeData.employee_name_(ViewState["Employee_Number"].ToString());
            }
            else
                SetAccountsList();
            dvEmployeeInfo.Visible = !dvSelection.Visible;
        }


        private bool IsStyle2()
        {
            
            return (!string.IsNullOrEmpty(Request.Params["type"]))&&(Request.Params["type"].Equals("2"));
        }

        private void SetAccountsList()
        {
            DataTable tbl = Data.AccountsList();
            if (tbl.Rows.Count.Equals(0))
            {
                lblDependentData.Text = "No more employees to processes.";
                tbl.Dispose();
                return;
            }
            ddlAccounts.DataSource = tbl;
            ddlAccounts.DataTextField = "accnt_name";
            ddlAccounts.DataValueField = "account_number";
            ddlAccounts.DataBind();
            ddlAccounts_SelectedIndexChanged(null, null);
        }

        private void SetEmployeeList(string strAccountNumber)
        {
            DataTable tbl = Data.EmployeesList(strAccountNumber);
            if (tbl.Rows.Count.Equals(0))
            {
                lblDependentData.Text = "No more employees to processes.";
                tbl.Dispose();
                return;
            }
            ddlSelectEmployee.DataSource = tbl;
            ddlSelectEmployee.DataTextField = "emp_name";
            ddlSelectEmployee.DataValueField = "employee_number";
            ddlSelectEmployee.DataBind();
            DrawGrid();
        }

        private void ShowPDF(string Dependent_number)
        {
            Viewer.Attributes.Add("src", strSrc.Replace("[id]", ViewState["docID"].ToString()));
            //PdfViewer1.LicenseKey = "QGtyYHF3YHNzd2BzbnBgc3FucXJueXl5eQ==";
            //byte[] bValue = Data.Get_Dependent_PDF_rec(Dependent_number);
            //PdfViewer1.PdfSourceBytes = bValue;
            //PdfViewer1.DataBind();
            //PdfViewer1.Visible = true;

        }

        protected void ddlAccounts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SetEmployeeList(ddlAccounts.SelectedValue);
        }

        private void DrawGrid()
        {
            DataTable tbl  = null;
            if(IsStyle2())
                tbl = Data.Get_Approval_Dep_Listing_sty_2(ViewState["Employee_Number"].ToString());
            else
                tbl = Data.Get_Approval_Dep_Listing(ddlSelectEmployee.SelectedValue);
            if (tbl.Rows.Count.Equals(0))
            {
                tbl.Dispose();
                gvDependent.Visible = false;
                return;
            }
            gvDependent.Visible = true;
            gvDependent.DataSource = tbl;
            gvDependent.DataBind();
            
        }

        protected void gvDependent_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DataTable tbl = (DataTable)gvDependent.DataSource;
            try
            {
                string strIndex = tbl.Rows[e.Row.RowIndex]["dependent_sequence_no"].ToString();
                if (IsStyle2())
                    strIndex = tbl.Rows[e.Row.RowIndex]["record_id"].ToString();
                Button btn = new Button();
                btn.ID = "btn_" + strIndex;
                btn.Text = "Process";
                btn.Click += new EventHandler(this.btnclicked);
                TableCell cell = e.Row.Cells[0];
                cell.Controls.Add(btn);                
            }

            catch
            {
            }
        }

        protected void btnclicked(object sender, EventArgs e)
        {
            string strDepNo = ((Button)sender).ID.Replace("btn_", "");
            ViewState["request_dp_id"] = strDepNo;
            dobtnclick(strDepNo);
        }

        private void dobtnclick(string strDepNo)
        {
            ViewState["DepNo"] = strDepNo;
            SetDocumentsList(strDepNo);
            DataTable tbl = null;
            if (IsStyle2())
                tbl = Data.Get_Dependent_Data_sty_2(strDepNo);
            else
                tbl = Data.Get_Dependent_Data(strDepNo);
            lblDependentData.Text = "Process Dependent: " + tbl.Rows[0]["FullName"].ToString();
            ViewState["DepName"] = tbl.Rows[0]["FullName"].ToString();
            lblSSN.Text = tbl.Rows[0]["SSN"].ToString();
            lblRelation.Text = tbl.Rows[0]["relation_desc"].ToString();
            lblDOB.Text = tbl.Rows[0]["DOB"].ToString();
            lblEffective.Text = tbl.Rows[0]["effective_date"].ToString();
            dvDepData.Visible = true;
            dvApproval.Visible = true;
        }

        private void SetDocumentsList(string strDepNo)
        {
            DataTable tbl = null;
            if (IsStyle2())
            {
                tbl = Data.Get_Dep_Doc_List_sty_2(ddlSelectEmployee.SelectedValue.ToString(), strDepNo);
                ViewState["docID"] = tbl.Rows[0]["R_Log_id"].ToString();
            }
            else
                tbl = Data.Get_Dep_Doc_List(ddlSelectEmployee.SelectedValue.ToString(), strDepNo);


            if (tbl.Rows.Count.Equals(0))
            {
                if (IsStyle2())
                    Response.Redirect("/WEB_PROJECTS/ENROLLMENTAPPROVAL_10/default.aspx?SkipCheck=YES");
                else
                    Response.Redirect(Request.Path + "?SkipCheck=YES");
                return;
            }
            else
                dvimage.Visible = tbl.Rows.Count >= 2;
            
            ViewState["doc_count"] = tbl.Rows.Count.ToString();
            int i = 1;
            foreach (DataRow dr in tbl.Rows)
            {
                ViewState["image_" + i] = dr["r_log_id"].ToString();
                ViewState["type_" + i] = dr["document_type"].ToString();
                if (dr["approval_status"].ToString().Equals("3"))
                    ViewState["msg_" + i] = "Requested More Information";
                else
                    ViewState["msg_" + i] = string.Empty;
                
                i++;

            }
            ViewState["current_doc"] = "1";
            if (dvimage.Visible)
                SetButtons();
            lblWrning.Text = imageMessage();
            lblWrning2.Text = lblWrning.Text;
            if (!IsStyle2())
                rblDecision.Items.FindByValue("0").Enabled = (string.IsNullOrEmpty(lblWrning2.Text));
            ShowPDFByLog_id();

        }


        private int doc_count()
        {
            return Convert.ToInt16(ViewState["doc_count"]);
        }

        private int current_doc()
        {
            return Convert.ToInt16(ViewState["current_doc"]);
        }

        private string imageMessage()
        {
            return ViewState["msg_" + ViewState["current_doc"].ToString()].ToString();
        }

        private Int64 imageRLogID()
        {
            return Convert.ToInt64(ViewState["image_" + ViewState["current_doc"].ToString()].ToString());
        }

        private string imageType()
        {
            return ViewState["type_" + ViewState["current_doc"].ToString()].ToString();
        }

        private void SetButtons()
        {
            btnPrevImage.Enabled = !ViewState["current_doc"].ToString().Equals("1");
            btnNextImage.Enabled = !ViewState["current_doc"].ToString().Equals(ViewState["doc_count"].ToString());
        }

        protected void btnPrevImage_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt16(ViewState["current_doc"].ToString());
            current--;
            if (current.Equals(0))
                current = 1;
            ViewState["current_doc"] = current.ToString();
            SetButtons();

            lblWrning.Text = imageMessage();
            lblWrning2.Text = lblWrning.Text;

            ShowPDFByLog_id();
        }

        protected void btnNextImage_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt16(ViewState["current_doc"].ToString());

            current++;
            ViewState["current_doc"] = current.ToString();

            lblWrning.Text = imageMessage();
            lblWrning2.Text = lblWrning.Text;

            SetButtons();
            ShowPDFByLog_id();
        }

        //private void ShowPDFByLog_id()
        //{
        //    string record_id = imageRLogID().ToString();
        //    if (ViewState["Crrent_Pdf"].ToString().Equals(record_id))
        //        return;
        //    ViewState["Crrent_Pdf"] = record_id;
        //    PdfViewer1.LicenseKey = "QGtyYHF3YHNzd2BzbnBgc3FucXJueXl5eQ==";
        //    byte[] bValue = Data.Get_PDF_rec(record_id);
        //    PdfViewer1.PdfSourceBytes = bValue;
        //    PdfViewer1.DataBind();
        //    PdfViewer1.Visible = true;

        //}

        protected System.Drawing.Image CreateSizedImage(Stream stream)
        {
            //This method takes an uploaded image file and resizes it to be as close to an 8.5 x 11 PDF as possible.
            try
            {
                System.Drawing.Image sdImage = System.Drawing.Image.FromStream(stream);
                double pdfAspect = 8.5 / 11;
                double aspectRatio = Convert.ToDouble(sdImage.Size.Width) / Convert.ToDouble(sdImage.Size.Height);
                int newWidth;
                int newHeight;

                //PDF w x h = 816 x 1056 (based on 8.5" x 11" at 96 dpi).
                if (aspectRatio <= pdfAspect)
                {
                    //If image aspect ratio is less than pdf aspect, image is taller than pdf. 
                    //   Resize based on pdf height
                    newHeight = 1050;
                    newWidth = Convert.ToInt32(1050 * aspectRatio);
                }
                else
                {
                    //If image aspect ratio is greater than pdf aspect, image is wider than pdf. 
                    //   Resize based on pdf width
                    newWidth = 810;
                    newHeight = Convert.ToInt32(810 / aspectRatio);
                }

                //I got the following logic from an online forum:
                System.Drawing.Image newImage = new Bitmap(newWidth, newHeight);

                System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(newImage);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(sdImage, 0, 0, newWidth, newHeight);

                System.Drawing.Imaging.ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters encoderParameters;
                encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                ms = new MemoryStream();
                newImage.Save(ms, info[1], encoderParameters);
                ms.Close();
                return newImage;
            }
            catch
            {
                throw;
            }
        }

        private byte[] GetDoc()
        {
            string record_id = imageRLogID().ToString();            
            byte[] bValue = Data.Get_PDF_rec(record_id);
            if (imageType().Contains("image"))
            {
                PdfDocument pdfDoc;
                PdfPage pdfPage;
                PdfImage pdfImage;
                System.Drawing.Image sdImage;
                byte[] buf;
                pdfPage = null;
                sdImage = null;
                pdfImage = null;
                pdfDoc = new PdfDocument();
                pdfPage = pdfDoc.Pages.Add();
                MemoryStream memStream = new MemoryStream(bValue);
                sdImage = CreateSizedImage(memStream);

                pdfImage = new PdfImage(sdImage);
                PdfImageContent content = new PdfImageContent(pdfImage);
                content.GfxMatrix.Translate(0, 0);
                content.AutoScale();
                pdfPage.Contents.Add(content);

                MemoryStream ms = new MemoryStream();

                pdfPage.Document.Save(ms);
                buf = ms.ToArray();
                return buf;
            }
            return bValue;

        }

        private void ShowPDFByLog_id()
        {
            string record_id = imageRLogID().ToString();
            if (ViewState["Crrent_Pdf"].ToString().Equals(record_id))
                return;
            ViewState["Crrent_Pdf"] = record_id;
            Viewer.Attributes.Add("src", strSrc.Replace("[id]", ViewState["docID"].ToString()));

        }

        

        protected void ddlSelectEmployee_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //PdfViewer1.Visible = false;
            dvDepData.Visible = false;
            dvApproval.Visible = false;
            lblWrning.Text = string.Empty;
            lblWrning2.Text = string.Empty;            
            DrawGrid();
            rblDecision_SelectedIndexChanged(null, null);
        }               

        protected void rblDecision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSelectEmployee.Enabled = false;
            if (rblDecision.SelectedValue.Equals("2"))
                PrepareForApprove(false);
            else if (rblDecision.SelectedValue.Equals("3"))
                PrepareForDisApprove(false);
            else if (rblDecision.SelectedValue.Equals("0"))
                PrepareForRequest(false);
            else
                ddlSelectEmployee.Enabled = true;
            dvHome.Visible = !dvDecision.Visible;
        }

        private void PrepareForRequest(bool bln)
        {
            gvDependent.Visible = bln;
            rblDecision.Enabled = bln;
            dvReson.Visible = !bln;
            dvimage.Visible = bln && (doc_count() >= 2);
            dvDecision.Visible = !bln;
            lblDecided.Text = "Are you sure you want to request more information for Dependent [dep]? Please click \"Yes\" Button below to continue with the request, otherwise, click the \"Cancel\" button.";
            lblDecided.Text = lblDecided.Text.Replace("[dep]", ViewState["DepName"].ToString());
            btnSave.Text = "Yes";
            FillRequestReason();
        }

        private void FillRequestReason()
        {
            DataTable tbl = Data.RequestResons();
            ddlReson.Items.Clear();
            ddlReson.DataSource = tbl;
            ddlReson.DataTextField = "description";
            ddlReson.DataValueField = "code";
            ddlReson.DataBind();
        }
        private void PrepareForApprove(bool bln)
        {
            gvDependent.Visible = bln;
            rblDecision.Enabled = bln;
            dvDecision.Visible = !bln;
            dvimage.Visible = bln&&(doc_count()>=2);
            lblDecided.Text = "Are you sure you want to approve Dependent [dep]? Please click \"Approve\" Button below to approve the dependent, otherwise, click the \"Cancel\" button.";
            lblDecided.Text = lblDecided.Text.Replace("[dep]", ViewState["DepName"].ToString());
            btnSave.Text = "Approve";
        }

        private void PrepareForDisApprove(bool bln)
        {
            gvDependent.Visible = bln;
            rblDecision.Enabled = bln;
            dvReson.Visible = !bln;
            dvimage.Visible = bln && (doc_count() >= 2);
            dvDecision.Visible = !bln;
            lblDecided.Text = "Are you sure you want to disapprove Dependent [dep]? Please click \"Disapprove\" Button below to approve the dependent, otherwise, click the \"Cancel\" button.";
            lblDecided.Text = lblDecided.Text.Replace("[dep]", ViewState["DepName"].ToString());
            btnSave.Text = "Disapprove";
            FillDispproveReason();
        }

        private void FillDispproveReason()
        {
            DataTable tbl = Data.DeclineResons();
            ddlReson.Items.Clear();
            ddlReson.DataSource = tbl;
            ddlReson.DataTextField = "description";
            ddlReson.DataValueField = "code";
            ddlReson.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddlSelectEmployee.Enabled = true;
            if (rblDecision.SelectedValue.Equals("2"))
                PrepareForApprove(true);
            else if (rblDecision.SelectedValue.Equals("3"))
                PrepareForDisApprove(true);
            else if (rblDecision.SelectedValue.Equals("0"))
                PrepareForRequest(true);
            rblDecision.SelectedIndex = -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {           

            if (rblDecision.SelectedValue.Equals("2"))
            {
                if (IsStyle2())
                    Data.move_out_of_pending_sty_2(session_id, ViewState["Employee_Number"].ToString(), ViewState["request_dp_id"].ToString(),
                        ViewState["User_Name"].ToString(), "0");
                else
                    Data.Approve_doc(session_id, imageRLogID().ToString(), ViewState["User_Name"].ToString());
            }
            if (rblDecision.SelectedValue.Equals("3"))
            {
                if (IsStyle2())
                    Data.Deney_pending_Dep_sty_2(session_id, ViewState["Employee_Number"].ToString(), ViewState["request_dp_id"].ToString(),
                        ViewState["User_Name"].ToString(),ddlReson.SelectedItem.Text, "0");
                else
                    Data.DisApprove_doc(session_id, imageRLogID().ToString(),ViewState["User_Name"].ToString(), ddlReson.SelectedValue);
            }

            if (rblDecision.SelectedValue.Equals("0"))
            {
                if (!IsStyle2())
                    DoRequestInfo();
                else
                    Data.Request_info_doc_sty_2(ViewState["Employee_Number"].ToString(), ViewState["User_Name"].ToString(), 
                        ViewState["request_dp_id"].ToString(), ddlReson.SelectedItem.Text);                     
            }
            string strDep = string.Empty;
            if(IsStyle2())
                strDep = Data.remaining_depend_count(ViewState["Employee_Number"].ToString());
            else
                strDep = Data.FirstDependent(ddlSelectEmployee.SelectedValue);
            if (!strDep.Equals("0"))
            {
                ViewState["DepNo"] = strDep;
                DrawGrid();
                if (!IsStyle2())
                    dobtnclick(ViewState["DepNo"].ToString());
                btnCancel_Click(null, null);
            }
            else
            {
                if (IsStyle2())
                    btnHome_Click(null, null);
                else
                    SetEmployeeList(ddlAccounts.SelectedValue);
            }
        }

        private void DoRequestInfo()
        {

            MemoryStream ms;
            byte[] buf = {
             0,   1,   2,   4,   8,  16,  32,  64, 128, 255 };
            ms = new MemoryStream();
            //string strSite = System.Configuration.ConfigurationSettings.AppSettings["urlProcessing"];
            //string strSite = System.Configuration.ConfigurationManager.AppSettings["urlProcessing"];
            //HtmlToPdf.ConvertUrl(strSite + "web_projects/Dependent_Audit_Wizard_Request_page/DoRequestInfo.aspx?dep=" + ViewState["DepNo"].ToString(), ms);

            //buf = ms.ToArray();
            string strPDFName = "Dep_Audit_Require_inf_" + ddlSelectEmployee.SelectedValue + "_" + ViewState["DepNo"].ToString() + "_" + imageRLogID().ToString();        
            Data.Request_info_doc(ddlSelectEmployee.SelectedValue, ddlAccounts.SelectedValue, ViewState["User_Name"].ToString(), imageRLogID().ToString(),
                ddlReson.SelectedValue, strPDFName, buf);

            Bas_Utility.Misc.AlertSaved(Page);
        }

        protected void lnkbtnAddReason_Click(object sender, EventArgs e)
        {
            dvAddItem.Visible = true;
            dvDecision.Visible = false;
            if (rblDecision.SelectedValue.Equals("3"))
            {
               // lblAddDecision.Text = "Add New Disaprovel Reason";
            }

            if (rblDecision.SelectedValue.Equals("0"))
            {
              //  lblAddDecision.Text = "Add New Request Information Reason";
            }
        }

        protected void btnReasonCance_Click(object sender, EventArgs e)
        {
            dvAddItem.Visible = false;
            dvDecision.Visible = true;
        }

        protected void btnReasonSave_Click(object sender, EventArgs e)
        {
            string strGroup = string.Empty;
            if (rblDecision.SelectedValue.Equals("3"))
            {
                strGroup = "13000";
            }

            if (rblDecision.SelectedValue.Equals("0"))
            {
                strGroup = "12000";
            }
            Data.Add_Reason(strGroup, txtReason.Text);
            if (rblDecision.SelectedValue.Equals("3"))
            {
                FillDispproveReason();
            }

            if (rblDecision.SelectedValue.Equals("0"))
            {
                FillRequestReason();
            }
            btnReasonCance_Click(null, null);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["Verify"]))
                Response.Redirect("/WEB_PROJECTS/ENROLLMENTAPPROVAL_10/VerifyDependents.aspx?SkipCheck=YES");
            else
                Response.Redirect("/WEB_PROJECTS/ENROLLMENTAPPROVAL_10/default.aspx?SkipCheck=YES");
        }

        
    }
}