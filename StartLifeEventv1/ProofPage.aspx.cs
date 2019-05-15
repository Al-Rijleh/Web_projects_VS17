using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Upload;
namespace StartLifeEventv1
{
    public partial class ProofPage : System.Web.UI.Page
    {
        ArrayList uploadedFiles; string altDiv = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head> <style type='text/css'> .FullPage { width:550px; font-family: Arial; font } .FullRow { width:530px;  font-family:Arial; font-size:9pt; } .Row { width:530; } .marginbottom10 { margin-bottom: 10px; } .leftText { width:200px; font-weight:bolder; float:left; } .rightTextGreen { color:Green; font-weight:bold; } .rightTextMaroon { color:Maroon; font-weight:bold; } .rightTextNavy { color:Navy; font-weight:bold; } </style></head><body><div class='FullPage'> <div class='FullRow'> <div class='Row marginbottom10'> <h3>Upload Documents</h3> </div> <div class='Row marginbottom10'> You have chosen to upload documents from your computer that will verify your dependent's eligibility  </div> <!--EE Name--> <div class='Row marginbottom10'> <div class='leftText'>Employee</div><div class='rightTextGreen'>[EEName]</div> </div> <!--Dep Name--> <div class='Row marginbottom10'> <div class='leftText'>Selected Dependent</div><div class='rightTextMaroon'>[DepName]</div> </div> <!--Required Document--> <div class='Row marginbottom10'> <div class='leftText'>Required Documents</div><div class='rightTextNavy'><a href=[url] target='_blank'>View</a></div> </div> </div></div></body></html>";
        string SavedInst = "<br/><span style='font-size: 9pt; font-family: Arial;'><strong>Press <span style='font-size: 9pt; color: #c00000;'>OK </span>button to exit <span style='font-size: 9pt; color: #c00000;'>Cancel </span>button to stay</strong></span>";
        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {

                ViewState["Error"] = 'F';
                ViewState["Docs"] = string.Empty;
                ViewState["ErrDocs"] = string.Empty;
                rgDoc.ShowHeader = false;
                
            }
            if(!string.IsNullOrEmpty(hidRemove.Value))
            {
                Data.Remove_Document(session_id, hidRemove.Value);
                hidRemove.Value = string.Empty;
                rgDoc.Rebind();
                return;
            }
            hidUpload.Value = "0";
            //btnSubmit.Attributes.Add("disabled","true");
            Page.Header.DataBind();
            Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
            try
            {
                ViewState["Account_Number"] = SQLStatic.Sessions.GetAccountNumber(session_id, conn);
                ViewState["Employee_number"] = SQLStatic.Sessions.GetEmployeeNumber(session_id, conn);
                ViewState["uesr_name"] = SQLStatic.Sessions.GetUserName(session_id, conn);
                ViewState["Dependent_No"] = SQLStatic.Sessions.GetSessionValue(session_id, "dep_id");


            }
            finally
            {
                SQLStatic.SQL.CloseConnection(conn);
            }

            int i = RadAsyncUpload1.InitialFileInputsCount;

            if (uploadedFiles == null)
            {
                uploadedFiles = new ArrayList();
            }
            //string hiddiv = "<script>Javescript:DisableObj('" + btnSubmit.ID + "')</script>";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "hiddiv", hiddiv);
            btnSubmit.Attributes.Add("onclick", "DoUpload()");
        }


        protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            string SavedDoc = string.Empty;
            string fileName = string.Empty;
            // try
            {

                int i = RadAsyncUpload1.InitialFileInputsCount;
                try
                {
                    using (Stream str = e.File.InputStream) ;
                }
                catch
                {
                    string strError = "<Script>FileTimedOut()</script>";
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "strError", strError);
                    return;
                }
                using (Stream str = e.File.InputStream)
                {

                    byte[] content = new byte[str.Length];
                    content = ReadFully(str);
                    uploadedFiles.Add(content);

                    fileName = e.File.FileName.Replace("'", "");
                    Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();

                    try
                    {
                        SQLStatic.Sessions.SetSessionValue(session_id, "UPLOAD_MESSAGE", txtmsgUpload.Text);
                        Data.SavePDF(session_id, fileName, content);
                        hidUpload.Value = "1";
                    }
                    catch
                    {
                    }
                    str.Read(content, 0, content.Length);
                    ViewState["Docs"] = ViewState["Docs"].ToString() + "<li>" + fileName + "</li>";
                }

            }
            //catch
            //{
            //    ViewState["Error"] = "T";
            //}
            if (hidcount.Value.Length > 0)
                hidcount.Value = hidcount.Value.Remove(0, 1);

            if (hidcount.Value.Length == 0)
            {
                if (!string.IsNullOrEmpty(ViewState["Docs"].ToString()))
                    SavedDoc = "<br/><u><b>Documents Uploaded Successfully</b></u><ul>" + ViewState["Docs"].ToString() + "</ul>";
                if (ViewState["Error"].ToString().Equals("F"))
                {
                    ConfromSave(SavedDoc);
                }
                else
                {
                    if (string.IsNullOrEmpty(ViewState["Docs"].ToString()))
                        SavedDoc = "<br/><br/><u><b>Documents Uploaded Successfully</b></u><ul> None</ul>";
                    else
                        SavedDoc = "<br/><br/><u><b>Documents Uploaded Successfully</b></u><ul>" + ViewState["Docs"].ToString() + "</ul>";
                    RadWindowManager1.RadAlert("Upload Failed. Please Try Again." + SavedDoc, 300, 200, "Upload Failed", null);
                }
                ViewState["Docs"] = string.Empty;
                //btnSubmit.Enabled = false;
            }
            txtmsgUpload.Text = string.Empty;
            rgDoc.Rebind();
            string strLE_EE_ID = SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID");
            string strGp = "<Script>Go('" + strLE_EE_ID + "')</script>";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "strGp", strGp);
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {

        }

        protected void ConfromSave(string Extra)
        {
            //RadWindowManager1.RadConfirm("Your upload was successful!" + Extra, "confirmCallBackFn", 530, 180, null, "Upload Successful", null);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //RadWindowManager1.RadAlert("Your upload was successful!", 300, 200, "successful Upload", null);



            RadWindowManager1.RadConfirm("Your upload was successful!", "confirmCallBackFn", 530, 180, null, "Upload Successful", null);
        }

        protected void rgDoc_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgDoc.DataSource = Data.uploaded_Doc_Cursor(SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID"), "U");
        }
    }
}