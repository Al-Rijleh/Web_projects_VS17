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

namespace NewHireWizard
{
    public partial class _Default : System.Web.UI.Page
    {
        string session_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            if (!IsPostBack)
            {
                if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
                {
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "main_run", Request.Path + "?SkipCheck=YES");
                    Response.Redirect("/web_projects/PTemplate/index.htm");
                    return;
                }
            }
            if (!IsPostBack)
            {
                RadPanelBar1.Items[0].Selected = true;
                RadPanelBar1.Items[0].Expanded = true;
                RadPanelBar1.Items[0].Enabled = true;
                SetupControls();
                FillDropDowns();
            }
            ProcesseshidDiv();
            ProcesseshidClass();
        }

        private void ProcesseshidDiv()
        {
            if (hidDiv.Value.Equals("Go"))
            {
                hidDiv.Value = "";
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                ViewState["Account_Number"] = SQLStatic.Sessions.GetSessionValue(session_id, "Account_Number", conn);
                TextBox txt_ = txt("txtAccountNameNumberValues");
                txt_.Text = ViewState["Account_Number"].ToString() + " - " +
                                                         SQLStatic.Sessions.GetSessionValue(session_id, "Account_Name", conn);
                txt_.ToolTip = txt_.Text;
                conn.Close();
                conn.Dispose();
            }
        }

        private void ProcesseshidClass()
        {
            if (hidClass.Value.Equals("Go"))
            {
                hidClass.Value = "";
                Oracle.DataAccess.Client.OracleConnection conn = SQLStatic.SQL.OracleConnection();
                string strClass_code = SQLStatic.Sessions.GetSessionValue(session_id, "CLASS", conn);
                TextBox txt_ = txt("txtClassValue");
                txt_.Text = strClass_code + " - " +
                                 SQLStatic.AccountData.ClassDescription(ViewState["Account_Number"].ToString(),
                                 SQLStatic.AccountData.Current_Processing_Year(ViewState["Account_Number"].ToString(),conn),strClass_code,conn)+
                                 " (" + SQLStatic.Sessions.GetSessionValue(session_id, "CLASSEFF", conn) + ")";
                txt_.ToolTip = txt_.Text;
            }
        }

        private TextBox txt(string name)
        {
            return (TextBox)Bas_Utility.Utilities.GetTextBox(Page, name);
        }

        private DropDownList ddl(string name)
        {
            return (DropDownList)Bas_Utility.Utilities.GetDropDown(Page,name);
        }

        private void FillDropDowns()
        {
            DataTable tbl = Data.MritalStatus();
            ddl("ddlMaritalStatus").Items.Clear();
            ListItem li0 = new ListItem("Select", "x");
            ddl("ddlMaritalStatus").Items.Add(li0);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["marital_description"].ToString(), dr["marital_status_code"].ToString());
                ddl("ddlMaritalStatus").Items.Add(li);
            }
            tbl.Dispose();

            tbl = Data.States();
            ddl("ddlState").Items.Clear();
            li0 = new ListItem("Select State", "0");
            ddl("ddlState").Items.Add(li0);
            foreach (DataRow dr in tbl.Rows)
            {
                ListItem li = new ListItem(dr["state_description"].ToString(), dr["state"].ToString());
                ddl("ddlState").Items.Add(li);
            }
            tbl.Dispose();

        }

        private void SetupControls()
        {
            LinkButton lnk = null;
            lnk = (LinkButton)Bas_Utility.Utilities.GetLinkButton(Page, "lnkbtnChangeDivision");
            lnk.Attributes.Add("onclick", "showDialog3(); return false;");
            lnk = (LinkButton)Bas_Utility.Utilities.GetLinkButton(Page, "lnkbtnChangeClass");
            lnk.Attributes.Add("onclick", "showDialog2(); return false;");
            lnk = (LinkButton)Bas_Utility.Utilities.GetLinkButton(Page, "lnkbtnChangePaySchedule");
            lnk.Attributes.Add("onclick", "showDialog4(); return false;");
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            Validate();
            if (IsValid)
                GoToNextItem();
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Validate();
            if (IsValid)
                GoToPrevious_Item();
        }

        private void GoToNextItem()
        {
            int selectedIndex = RadPanelBar1.SelectedItem.Index;

            RadPanelBar1.Items[selectedIndex + 1].Selected = true;
            RadPanelBar1.Items[selectedIndex + 1].Expanded = true;
            RadPanelBar1.Items[selectedIndex + 1].Enabled = true;
            RadPanelBar1.Items[selectedIndex].Expanded = false;
        }

        private void GoToPrevious_Item()
        {
            int selectedIndex = RadPanelBar1.SelectedItem.Index;

            RadPanelBar1.Items[selectedIndex - 1].Selected = true;
            RadPanelBar1.Items[selectedIndex - 1].Expanded = true;
            RadPanelBar1.Items[selectedIndex - 1].Enabled = true;
            RadPanelBar1.Items[selectedIndex].Expanded = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
