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
	/// Summary description for ItemDetail.
	/// </summary>
	public class ItemDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgBudgetDetail;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Label Label4;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);			
			if (!IsPostBack)
			{
				SetHeaderInformation();				
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"] = Training_Source.TrainingClass.SetHeaderInformation(Request.Params["ee"],lblEmployeeInfo,lblDivision);;
		}
		
		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_trn_budget.Items_expense_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "PLA_header_record_id",Request.Params["item"]);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "items_list_","cursor","out","");

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
					string strMarket = "";
					if (tbl.Rows[indx]["pay_to"].ToString()=="2")
						strMarket =BASUSA.MiscTidBit.Font("*&nbsp;","","red","","");
					Label lbl = new Label();
					lbl.ID = "lbl_"+strRecordId;
					lbl.Text = strMarket+tbl.Rows[indx]["Amount"].ToString();					
					lbl.Text += "&nbsp;&nbsp;&nbsp;";
					TableCell cell = e.Item.Cells[1];
					cell.Controls.Add(lbl);													
				}
				catch{}
			}
		}
	}
}
