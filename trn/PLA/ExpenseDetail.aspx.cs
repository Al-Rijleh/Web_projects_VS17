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
	/// Summary description for ExpenseDetail.
	/// </summary>
	public class ExpenseDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgBudgetDetail;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Label4;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);			
			if (!IsPostBack)
			{
				SetHeaderInformation();
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,Request.Params["ee"],Request.Params["py"]);
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
			this.dgBudgetDetail.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetDetail_ItemCreated);
			this.dgBudgetDetail.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetDetail_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"] = Training_Source.TrainingClass.SetHeaderInformation(Request.Params["ee"],lblEmployeeInfo,lblDivision);
		}

		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_trn_budget.employees_Expense",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",Request.Params["ee"]);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",ddlBudgetYear.SelectedItem.Text);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_list_","cursor","out","");

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
					lbl0.Text = tbl.Rows[indx]["CourseName"].ToString();
					lbl0.Text += " "+BASUSA.MiscTidBit.Launch_Page("(Detail)","ItemDetail.aspx?ee="+Request.Params["ee"]+"&py="+ddlBudgetYear.SelectedItem.Text+"&item="+strRecordId,"itemexpn",500,500,30,30,true,true);
					TableCell cell0 = e.Item.Cells[0];
					cell0.Controls.Add(lbl0);			

					Label lbl = new Label();
					lbl.ID = "lbl_"+strRecordId;
					lbl.Text = tbl.Rows[indx]["Expense"].ToString();					
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
				if (tbl.Rows[e.Item.ItemIndex]["record_id"].ToString()=="-1")
				{
					e.Item.BackColor=System.Drawing.ColorTranslator.FromHtml("#0066CC");
					e.Item.ForeColor=System.Drawing.Color.White;
					e.Item.Font.Bold=true;
				}

			}
			catch
			{
			}
		}
	}
}
