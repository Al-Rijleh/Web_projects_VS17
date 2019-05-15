using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PLA_Source
{
	/// <summary>
	/// Summary description for BudgetDetail.
	/// </summary>
	public class BudgetDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.DataGrid dgBudgetDetail;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label lblCompetitveProgramBudget;
        protected System.Web.UI.WebControls.DataGrid dgCPDetail;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			#region PopUp BasTemplate
			if (!IsPostBack)
			{					
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,false);
					if (strResult!="")
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult.Replace("\n","~"),false);
						return;
					}
					ViewState["AccessType"]						= objBasTemplate.strAccessType;
					ViewState["Employee_Number"]				= objBasTemplate.strEmployee_Number;
					ViewState["Processing_Year"]				= objBasTemplate.strProcessingYear;
					ViewState["Role_Restriction_Level"]			= objBasTemplate.strRole_Restriction_Level;
					ViewState["Selected_Account_Number"]		= objBasTemplate.strSelected_Account_Number;
					ViewState["Selected_Employee_Class_Code"]	= objBasTemplate.strSelected_Employee_Class_Code;
					ViewState["User_Group_ID"]					= objBasTemplate.strUser_Group_ID;
					ViewState["User_ID"]						= objBasTemplate.strUser_ID;
					ViewState["User_Name"]						= objBasTemplate.strUser_Name;
					ViewState["User_Primary_Role"]				= objBasTemplate.strUser_Primary_Role;	
				}
				catch (Exception ex)
				{
					string strError = "Error Message: "+ex.Message+"~~Application:"+ex.Source+"~~Method:"+ex.TargetSite+"~~Detail:"+ex.StackTrace;
					Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strError.Replace("\n","~"));
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
				SetHeaderInformation();
				FillBudgetYears(ddlBudgetYear,lblBalance,Request.Params["ee"],Request.Params["py"]);
			}
			DrawGrid();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ddlBudgetYear.SelectedIndexChanged += new System.EventHandler(this.ddlBudgetYear_SelectedIndexChanged);
			this.dgBudgetDetail.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetDetail_ItemCreated);
			this.dgBudgetDetail.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetDetail_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			try
			{
				ViewState["Account_Number"] = SetHeaderInformation2(Request.Params["ee"],lblEmployeeInfo,lblDivision);
			}
			catch{}
		}

		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_trn_budget.budget_detail_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",Request.Params["ee"]);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ddlBudgetYear.SelectedItem.Text);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "budget_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
			}
			return tbl;
		}

		private void DrawGrid()
		{
			DataTable tbl = GetGridTable();
			dgBudgetDetail.DataSource = tbl;
			dgBudgetDetail.DataBind();

            DataTable tblCP = PLA_Approval.TrainingClass.CPBudgetDetail(Request.Params["ee"], ddlBudgetYear.SelectedItem.Text);
            if (tblCP.Rows.Count == 1)
            {
                dgCPDetail.Visible = false;
                lblCompetitveProgramBudget.Visible = false;
            }
            else
            {
                dgCPDetail.Visible = true;
                lblCompetitveProgramBudget.Visible = true;
                dgCPDetail.DataSource = tblCP;
                dgCPDetail.DataBind();
            }
		}
		
		private void dgBudgetDetail_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgBudgetDetail.DataSource;
					string strRecordId = tbl.Rows[indx]["record_id"].ToString();
					
					Label lbl0 = new Label();
					lbl0.ID = "lbl0_"+strRecordId;
					lbl0.Text = tbl.Rows[indx]["category_name"].ToString();
					if (tbl.Rows[indx]["category_id"].ToString()=="6")
						lbl0.Text += " "+BASUSA.MiscTidBit.Launch_Page("(Detail)","ExpenseDetail.aspx?ee="+Request.Params["ee"]+"&py="+ddlBudgetYear.SelectedItem.Text,"expense",500,500,20,20,true,true);
					TableCell cell0 = e.Item.Cells[0];
					cell0.Controls.Add(lbl0);			

					Label lbl = new Label();
					lbl.ID = "lbl_"+strRecordId;
					lbl.Text = tbl.Rows[indx]["amount"].ToString();
					if (lbl.Text.IndexOf("-")!=-1)
					{
						lbl.Text = "("+ lbl.Text.Replace("-","") +")";
					}
					lbl.Text += "&nbsp;&nbsp;&nbsp;";
					TableCell cell = e.Item.Cells[1];
					cell.Controls.Add(lbl);													
				}
				catch{}
			}
		}

		private void dgBudgetDetail_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataTable tbl = (DataTable) dgBudgetDetail.DataSource;
			if (tbl == null)
				tbl = GetGridTable();
			try
			{
				if (tbl.Rows[e.Item.ItemIndex]["record_id"].ToString()=="-1000")
				{
					e.Item.BackColor=System.Drawing.ColorTranslator.FromHtml("#0066CC");
					e.Item.ForeColor=System.Drawing.Color.White;
					e.Item.Font.Bold=true;
				}
				if (tbl.Rows[e.Item.ItemIndex]["amount"].ToString().IndexOf("-")!=-1)
					e.Item.Cells[1].ForeColor = System.Drawing.Color.Red;

				
				
			}
			catch
			{
			}
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public static string RemainingAmount(string strValue)
		{
			return strValue.Substring(5);
		}

		public static string FormatedRemainingAmount(ListItem li, string strEmployeeNumber)
		{
			string strAmount = RemainingAmount(li.Value);
			return BASUSA.MiscTidBit.Launch_Page(Convert.ToDouble(strAmount).ToString("$###,##0.00"),
				"BudgetDetail.aspx?ee="+strEmployeeNumber+"&py="+li.Text,"budget",600,500,10,10,true,true);
		}

		public static void FillBudgetYears(DropDownList ddl,Label lbl, string strEmployeeNumber ,string strDefaultBudgetYear)
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.availablebalanceslist",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",strEmployeeNumber);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",strDefaultBudgetYear);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "budget_years_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				ddl.Items.Clear();
				bool blnFound = false;
				lbl.Text = "";
				foreach(DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["budget_year"].ToString(),dr["budget_year"].ToString()+"_"+dr["total_remaining_amount"].ToString());
					if (li.Text == strDefaultBudgetYear)
					{
						li.Selected = true;
						lbl.Text = FormatedRemainingAmount(li,strEmployeeNumber);
						blnFound = true;
					}
					ddl.Items.Add(li);
				}
				
				if ((ddl.Items.Count>0)&&(!blnFound))
				{
					ddl.SelectedIndex = 0;
					lbl.Text = FormatedRemainingAmount(ddl.Items[0],strEmployeeNumber);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				if (tbl != null)
					tbl.Dispose();
			}
		}

		public static string SetHeaderInformation2(string strEmployee_number, Label lblEE, Label lblER)
		{
			DataTable tbl=null;
			string strAccountNumber = "";
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					PLA_Approval.TrainingClass.ConnectionString);
				lblEE.Text = "<B>"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
					"</B>  -  MyEnroll#: "+strEmployee_number+
					"  Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
				lblER.Text = tbl.Rows[0]["account_name"].ToString()+" (Acct# "+tbl.Rows[0]["account_number"].ToString()+")";
				strAccountNumber = tbl.Rows[0]["account_number"].ToString();
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
			return strAccountNumber;			
		}

	}
}
