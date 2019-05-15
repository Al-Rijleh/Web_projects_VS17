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
using System.ComponentModel;


namespace NewHireWizard
{
    public partial class TabStrip : System.Web.UI.UserControl
    {
        protected Page _wPage;
        [BrowsableAttribute(true)]
        [DescriptionAttribute("Page")]
       
        public Page wPage
        {
            get { return _wPage; }
            set { _wPage = value; }
        }

        protected string _CurrentPath;
        [BrowsableAttribute(true)]
        [DescriptionAttribute("Page")]

        public string CurrentPath
        {
            get { return _CurrentPath; }
            set { _CurrentPath = value; }
        }

        string session_id = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.Cookies["Session_ID"].Value.ToString();
            //RadTabStrip1.Tabs[4].Visible =  SQLStatic.Sessions.GetUserGroupID(session_id).Equals("1");
            RadTabStrip1.Tabs[3].Visible = false;
            SetTabText();
        }

        private void SetTabText()
        {
            return;
            bool isPendeing = false;
            try
            {
               isPendeing = Data.isPendingEmployee(session_id, null);
            }
            catch
            {
                isPendeing = Convert.ToInt16(SQLStatic.Sessions.GetSessionValue(session_id, "NH_EMPLOYEE_NUMBER").ToString()) < 0;
            }
                foreach (RadTab tab in RadTabStrip1.Tabs)
                {
                    if (tab.Value.Replace("?SkipCheck=YES", "").ToLower().Equals("/web_projects/newhirewizard/pending.aspx"))
                    {
                        tab.Visible = isPendeing;
                        break;
                    }
                }
            
        }

        public int CurrentTab()
        {
            return RadTabStrip1.SelectedIndex;
        }

        public void SetCurrentTab(string strPath)
        {
            foreach (RadTab tab in RadTabStrip1.Tabs)
            {
                if (tab.Value.Replace("?SkipCheck=YES","").ToLower().Equals(strPath.ToLower()))
                {
                    tab.Selected = true;
                    break;
                }
            }
        }

        public string NextURL()
        {
            if (CurrentTab().Equals(RadTabStrip1.Tabs.Count))
                return RadTabStrip1.SelectedTab.Value;
            for (int i = RadTabStrip1.SelectedIndex + 1;i<=RadTabStrip1.Tabs.Count; i++)
            {
                if (RadTabStrip1.Tabs[i].Visible)
                    return RadTabStrip1.Tabs[i].Value;
            }
            return RadTabStrip1.SelectedTab.Value;
        }

        public string PreviousURL()
        {
            if (CurrentTab().Equals(0))
                return RadTabStrip1.SelectedTab.Value;
            for (int i = RadTabStrip1.SelectedIndex - 1; i >= 0; i--)
            {
                if (RadTabStrip1.Tabs[i].Visible)
                    return RadTabStrip1.Tabs[i].Value;
            }
            return RadTabStrip1.SelectedTab.Value;
        }

        public string TabUrl(int id)
        {
            return RadTabStrip1.Tabs[id].Value;
        }

        public void SetTabIndex(int id)
        {
            RadTabStrip1.SelectedIndex = id;
        }

        public string  TabName()
        {
            return RadTabStrip1.SelectedTab.Text;
        }

        protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            if (CurrentPath.ToUpper().Equals("/WEB_PROJECTS/NEWHIREWIZARD/ACCOUNT_DIVISION_CLASS_PAYSCHEDULE.ASPX"))
            {
                (wPage.FindControl("RequiredFieldValidator1") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator3") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator4") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator5") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator6") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator7") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator9") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator10") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator11") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator12") as RequiredFieldValidator).Enabled = true;
                (wPage.FindControl("RequiredFieldValidator13") as RequiredFieldValidator).Enabled = true;
                string strSSN = (wPage.FindControl("txtSSN") as RadMaskedTextBox).TextWithLiterals;
                string strSSNExist = Data.SSN_Exists_Check_EE(strSSN, SQLStatic.Sessions.GetAccountNumber(session_id), session_id);
                if (!strSSNExist.Equals("1"))
                {
                    string radalertscript =
                    @"<script language='javascript'> Sys.Application.add_load(function(){radalert('You must complete the information on the current page before you may proceed to this tab. You may only use the tab system once you have passed through the page containing the information that corresponds with the tab you clicked.', 560, 200);})</script>";
                    wPage.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

                    //string strerror = "<script>alert('error')</script>";
                    //wPage.ClientScript.RegisterStartupScript(wPage.GetType(), "strerror", strerror);
                    SetCurrentTab(CurrentPath);
                    return;
                }
                wPage.Validate();
                if (!wPage.IsValid)
                {
                    string radalertscript =
                    @"<script language='javascript'> Sys.Application.add_load(function(){radalert('You must complete the information on the current page before you may proceed to this tab. You may only use the tab system once you have passed through the page containing the information that corresponds with the tab you clicked.', 560, 200);})</script>";
                    wPage.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

                    //string strerror = "<script>alert('error')</script>";
                    //wPage.ClientScript.RegisterStartupScript(wPage.GetType(), "strerror", strerror);
                    SetCurrentTab(CurrentPath);
                    return;
                }
            }
            Response.Redirect(e.Tab.Value);
        }

        public void ShowTab(int id, bool state)
        {
            if (id.Equals(3))
                return;
            RadTabStrip1.Tabs[id].Visible = state;
        }

        public void Disable()
        {
            RadTabStrip1.Enabled = false;
        }
        
    }
}