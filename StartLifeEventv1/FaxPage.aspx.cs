using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

namespace StartLifeEventv1
{
    public partial class FaxPage : System.Web.UI.Page
    {

        string session_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            btnSubmit.Attributes.Add("onclick", "showfax(" + SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LE_EE_ID") + ")");

            string leID = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LE_EE_ID");

            ViewState["leID"] = leID;
            if (!IsPostBack)
            {
                rgDoc.ShowHeader = false;
                SetSendFaxTo();
            }
            if (!string.IsNullOrEmpty(hidRemove.Value))
            {
                Data.Remove_Document(session_id, hidRemove.Value);
                hidRemove.Value = string.Empty;
                rgDoc.Rebind();
            }
        }
        
        private void SetSendFaxTo()
        {
            string employee_number = SQLStatic.Sessions.GetEmployeeNumber(Request.Cookies["Session_ID"].Value.ToString());
            DataTable tbl = Data.SendFaxTo(employee_number);
            dllSentTo.DataSource = tbl;
            dllSentTo.DataTextField = "name";
            dllSentTo.DataValueField = "email";
            dllSentTo.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            

            string Go = "showfax(" + SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "LE_EE_ID");
            string showfax = "<script>Javescript:DisableObj(" + Go + ")</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "showfax", showfax);
            rgDoc.Rebind();
        }

        protected void dllSentTo_ItemChecked(object sender, Telerik.Web.UI.RadComboBoxItemEventArgs e)
        {
            btnSubmit.Enabled = true;
            string code = creatTo();
            btnSubmit.Enabled = !code.Equals("000"); 
        }

        private string creatTo()
        {
            string code = string.Empty;
            string Email = string.Empty;
            foreach (RadComboBoxItem li in dllSentTo.Items)
            {
                if (li.Checked)
                {
                    code = code + "1";
                    Email = Email + li.Value+"~";
                }
                else
                {
                    code = code + "0";
                    Email = Email +  " ~";
                }

            }
            Email = Email.Remove(Email.Length - 1);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "code", code);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Email", Email);
            return code;
        }

        protected void txtmsgFax_TextChanged(object sender, EventArgs e)
        {
            SQLStatic.Sessions.SetCLOBSessionValue(Request.Cookies["Session_ID"].Value.ToString(), ViewState["leID"].ToString(), txtmsgFax.Text);
        }

        protected void rgDoc_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgDoc.DataSource = Data.uploaded_Doc_Cursor(SQLStatic.Sessions.GetSessionValue(session_id, "LE_EE_ID"), "C");
        }
    }
}