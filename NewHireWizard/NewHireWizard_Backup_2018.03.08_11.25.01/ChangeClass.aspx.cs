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
    public partial class ChangeClass : System.Web.UI.Page
    {
        string session_id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = HttpContext.Current.Request.Cookies["SESSION_ID"].Value.ToString();
            if (!IsPostBack)
            {
                ViewState["Account_Number"] = SQLStatic.Sessions.GetAccountNumber(session_id);
                ViewState["processing_year"] = SQLStatic.Sessions.GetSessionValue(session_id, "Processing_Year");
                GetClassCodesList();                                   
            }           
        }

        protected void GetClassCodesList()
        {
            DataTable tbl = Data.GetClassGroupingPy(ViewState["Account_Number"].ToString(), ViewState["processing_year"].ToString());
            if (tbl.Rows.Count.Equals(0))
                BuildTreeNoGroup();
            else
                BuildTreeGroup(tbl);
        }

        private void BuildTreeGroup(DataTable tbl)
        {
            tvClass.Nodes.Clear();
            DataTable tblClasses = Data.Get_Class_Code_List2(ViewState["Account_Number"].ToString(), ViewState["processing_year"].ToString());
            
            foreach (DataRow dr in tbl.Rows)
            {
                TreeNode pNode = new TreeNode("Class Group: " + dr["grouping_title"].ToString(), dr["record_id"].ToString());
                FillItems(tblClasses,dr["record_id"].ToString(), pNode);
                pNode.PopulateOnDemand = false;
                pNode.SelectAction = TreeNodeSelectAction.Expand;
                pNode.Collapse();
                tvClass.Nodes.Add(pNode);
            }
            tblClasses.Dispose();
        }

        private void FillItems(DataTable tbl,string Group_id, TreeNode pNode)
        {
            bool found = false;
            
            foreach (DataRow dr in tbl.Rows)
            {
                if (dr["ereligclassee_grouping_code"].ToString().Equals(Group_id))
                {
                    found = true;
                    string strTitle = "Class: " + dr["description"].ToString();
                    if (dr["discontinue"].ToString().Equals("1"))
                        strTitle = "Class: <b><font SIZE='2' COLOR='#880000'><u>DO NOT USE</u></font></b>  " + dr["description"].ToString();
                    TreeNode ChildNode = new TreeNode(strTitle, dr["class_code"].ToString());
                    ChildNode.ToolTip = dr["extended_description"].ToString();
                    //ChildNode.NavigateUrl = "JavaScript:OpenViewer(" + dr["billing_date"].ToString() + ")";
                    pNode.ChildNodes.Add(ChildNode);
                }
            }
            if (!found)
            {
                if (ViewState["Account_Number"].ToString().StartsWith("0007208"))
                    pNode.Text = pNode.Text + "<font color='#FF0000'>(Class not set up at this time. Please use Lay Employee (30+ hours) Class for benefit processing)</font>";
                else
                    pNode.Text = pNode.Text + "<font color='#FF0000'>(No Classes Setup at this time)</font>";
                return;
            }
        }

        private void BuildTreeNoGroup()
        {
            lblInstruction2.Text = System.Configuration.ConfigurationManager.AppSettings["Grouping_1_Group"];
            tvClass.Nodes.Clear();            
            TreeNode pNode = new TreeNode("Class Codes", "");
            FillNoGroupItems( pNode);
            pNode.PopulateOnDemand = false;
            pNode.SelectAction = TreeNodeSelectAction.Expand;
            pNode.Expand();
            tvClass.Nodes.Add(pNode);

        }

        private void FillNoGroupItems(TreeNode pNode)
        {
            DataTable tbl = SQLStatic.AccountData.GetClassCodes(ViewState["Account_Number"].ToString(), ViewState["processing_year"].ToString());            
            foreach (DataRow dr in tbl.Rows)
            {
                TreeNode ChildNode = new TreeNode(dr["Description"].ToString(), dr["class_code"].ToString());
                //ChildNode.NavigateUrl = "JavaScript:OpenViewer(" + dr["class_code"].ToString() + ")";
                pNode.ChildNodes.Add(ChildNode);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string StrExit = "<script>closeWindow(1);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "StrExit", StrExit);
        }

        protected void tvClass_SelectedNodeChanged(object sender, EventArgs e)
        {
            lblSelectedClass.Text = tvClass.SelectedNode.Value;
            lblSelectedDescription.Text = tvClass.SelectedNode.Text;
            lblClassTitle.Text = tvClass.SelectedNode.Value + " - " + tvClass.SelectedNode.Text.Replace("Class: ", "");
            lblInstruction.Visible = true;
            dvtopButtons.Visible = true;
            lblSelectedDescription.Visible = false;
            lblClassTitle.Visible = true;
            ViewState["selectedClassCode"] = lblSelectedClass.Text;
            btnSave.Enabled = true;
            if (ViewState["Account_Number"].ToString().Contains("0007208-"))
                if (tvClass.SelectedNode.Value.Equals("VII"))
                    jscriptsFunctions.Misc.Alert(Page, "Coverage begins on the first day of the month following one month from the date of hire.  ");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            SQLStatic.Sessions.SetSessionValue(session_id, "class_code", ViewState["selectedClassCode"].ToString());
            string StrExit = "<script>closeWindow(2);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "StrExit", StrExit);
        }


    }
}
