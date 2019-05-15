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

namespace PLA_Approval
{
	/// <summary>
	/// Summary description for AdjutmentHistory.
	/// </summary>
	public class AdjutmentHistory : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblType;
		protected System.Web.UI.WebControls.DataGrid dgAdjust;
		protected System.Web.UI.WebControls.TextBox txtReason;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			DrawGrid();
			lblType.Text = Request.Params["type"].ToString();
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
			this.dgAdjust.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgAdjust_ItemCreated);
			this.dgAdjust.SelectedIndexChanged += new System.EventHandler(this.dgAdjust_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private DataTable GetDataTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.ExpenseAdjustmentList",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "expense_record_id_",Request.Params["recid"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "adjustmentList_","cursor","out","");

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
			
			DataTable tblAdjust = GetDataTable();
			dgAdjust.DataSource = tblAdjust;
			dgAdjust.DataBind();
		}

		private void dgAdjust_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgAdjust_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
            
		}

		private void lnk_Click(object sender, System.EventArgs e)
		{
			LinkButton lnk = (LinkButton)sender;
			string strIndex = lnk.ID.Replace("lnk_","");
			int indx = Convert.ToInt32(strIndex);
			DataTable tbl = (DataTable) dgAdjust.DataSource;
			txtReason.Text = tbl.Rows[indx]["reason"].ToString();
		}

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExpenseAdjustment.aspx?SkipCheck=YES");
        }

        protected void dgAdjust_ItemCreated1(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                (e.Item.ItemType == ListItemType.AlternatingItem) ||
                (e.Item.ItemType == ListItemType.SelectedItem))
            {
                try
                {
                    int indx = e.Item.ItemIndex;
                    DataTable tbl = (DataTable)dgAdjust.DataSource;


                    LinkButton lnk = new LinkButton();
                    lnk.ID = "lnk_" + indx.ToString();
                    if (tbl.Rows[indx]["reason"].ToString().Length > 30)
                        lnk.Text = tbl.Rows[indx]["reason"].ToString().Substring(1, 30) + "....";
                    else
                        lnk.Text = tbl.Rows[indx]["reason"].ToString();
                    lnk.Click += new System.EventHandler(this.lnk_Click);
                    TableCell cell1 = e.Item.Cells[4];
                    cell1.Controls.Add(lnk);
                }
                catch
                {
                }
            }
        }
	}
}
