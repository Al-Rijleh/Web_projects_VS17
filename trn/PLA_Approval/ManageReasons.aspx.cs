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
	/// Summary description for ManageReasons.
	/// </summary>
	public class ManageReasons : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgReasons;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAddItem;
		protected System.Web.UI.WebControls.TextBox txtNew;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSave;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.LinkButton lnkbtnClose;
		protected System.Web.UI.WebControls.LinkButton lkbtnReset;
		protected System.Web.UI.WebControls.Label lblTitle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text = "";
			if (!IsPostBack)
			{
				ViewState["mode"]="";
				SetTitle();
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
			this.lnkbtnAddItem.Click += new System.EventHandler(this.lnkbtnAddItem_Click);
			this.dgReasons.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgReasons_ItemCreated);
			this.dgReasons.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgReasons_PageIndexChanged);
			this.lnkbtnSave.Click += new System.EventHandler(this.lnkbtnSave_Click);
			this.lnkbtnClose.Click += new System.EventHandler(this.lnkbtnClose_Click);
			this.lkbtnReset.Click += new System.EventHandler(this.lkbtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetTitle()
		{
			if (Request.Params["type"].ToString()=="1")
				lblTitle.Text = "Reasons for Supervisor Declination";
			else if (Request.Params["type"].ToString()=="2")
				lblTitle.Text = "Reasons for Supervisor Partial Payment";
			else if (Request.Params["type"].ToString()=="3")
				lblTitle.Text = "Reasons for Administrator Declination";
			else if (Request.Params["type"].ToString()=="4")
				lblTitle.Text = "Reasons for Administrator Partial Payment";
		}

		private DataTable GetData()
		{
			string strProcedureName ="pkg_training.reason_for_suprvsl_denial_list";
			if (Request.Params["type"]=="2")
				strProcedureName ="pkg_training.reason_for_supr_partial_list";
			if (Request.Params["type"]=="3")
				strProcedureName ="pkg_training.reason_for_admin_denial_list";
			if (Request.Params["type"]=="4")
				strProcedureName ="pkg_training.reason_for_admin_partial_list";
			if (Request.Params["type"]=="5")
				strProcedureName ="pkg_training_cdp.reason_for_suprvsl_denial_list";
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_list_","cursor","out","");
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{
				
				da.Fill(mds,"Purpose");
				dTable = mds.Tables["Purpose"];				
				
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();				
			}
			return dTable;
		}

		private void DrawGrid()
		{
			DataTable dt = GetData();
			dgReasons.DataSource = dt;
			dgReasons.DataBind();
		}

		private void dgReasons_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{				
				try
				{
					
					int index = e.Item.ItemIndex;
					index=dgReasons.PageSize*dgReasons.CurrentPageIndex+index;
					DataTable tbl = (DataTable) dgReasons.DataSource;
					string strindex = tbl.Rows[index]["record_id"].ToString();						
					
					TextBox txtapp = new TextBox();
					txtapp.ID = "txt_"+strindex;
					txtapp.Text = tbl.Rows[index]["description"].ToString();
					txtapp.CssClass = "smallsize";
					txtapp.Width = System.Web.UI.WebControls.Unit.Percentage(98);
					txtapp.Height = System.Web.UI.WebControls.Unit.Pixel(50);
					txtapp.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
					
					TableCell cellApp = e.Item.Cells[0];
					cellApp.Controls.Add(txtapp);										
				}
				catch
				{
				}				
			}
		
		}
		
		private TextBox GetTextBox(Control oMe,string txtName)
		{
			int cnt = oMe.Controls.Count;
			TextBox txt = null;
			for(int i=0; i<cnt; i++)
			{
				string s =oMe.Controls[i].GetType().ToString();
				if ((oMe.Controls[i].GetType().ToString()==
					"System.Web.UI.WebControls.TextBox"))
				{
					txt =(TextBox)oMe.Controls[i];
					if ((txt.ID == txtName))
					{
						s = txt.Text;
						break;
					}
					else
						txt = null;
				}
				else 
					if (oMe.Controls[i].HasControls())
				{
					txt = GetTextBox(oMe.Controls[i],txtName);
					if (txt != null)
						break;
				}
			}
			return txt;
		}

		private void SetEnableStatus(bool blnStatus)
		{
			TextBox txt;	
			string strIndex;	
			DataTable dt = (DataTable) dgReasons.DataSource;
			foreach(DataRow dr in dt.Rows)
			{
				strIndex = "txt_"+dr["record_id"].ToString();
				txt = GetTextBox(this,strIndex);
				txt.Enabled = blnStatus;
			}
		}

		private void lnkbtnAddItem_Click(object sender, System.EventArgs e)
		{
			SetEnableStatus(false);
			txtNew.Text="";
			txtNew.Visible=true;
			ViewState["mode"]="new";
		}

		private void dgReasons_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgReasons.CurrentPageIndex=e.NewPageIndex;
			DrawGrid();
		}

		private void DoSave(string strRecordId,string strReason)
		{
			
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.add_edit_reason",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_",strRecordId);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_type_",Request.Params["type"]);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_",strReason);
			
			conn.Open();
			try
			{				
				cmd.ExecuteNonQuery();							
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();							
			}			
		}

		private void UpdateData()
		{
			DataTable dt = (DataTable) dgReasons.DataSource;
			string strIndex;
			TextBox txt;
			foreach (DataRow dr in dt.Rows)
			{
				strIndex = "txt_"+dr["record_id"].ToString();
				txt = GetTextBox(this,strIndex);
				DoSave(dr["record_id"].ToString(),txt.Text);
			}
		}

		private void ShowSaved(string strMsg)
		{
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"SavedMsg",strMsg,PLA_Approval.TrainingClass.ConnectionString);
			lblScript.Text = "<script>popup('/Web_Projects/trn/PLA/saved.aspx',200,400)</script>";
		}

		private void lnkbtnSave_Click(object sender, System.EventArgs e)
		{
			if (ViewState["mode"].ToString()=="new")
			{
				DoSave("-1",txtNew.Text);
				ViewState["mode"]="";
				txtNew.Visible=false;
			}
			else
			{
				UpdateData();
			}
			ShowSaved("Data was Saved Successfully");
			DrawGrid();
		  
		}

		private void lnkbtnClose_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["type"]=="3")
				lblScript.Text="<script>opener.location.href='"+Request.Params["surl"].ToString()+"?who=payor'; window.close();</script>";
			else
				lblScript.Text="<script>opener.location.href='"+Request.Params["surl"].ToString()+"'; window.close();</script>";
		}

		private void lkbtnReset_Click(object sender, System.EventArgs e)
		{
			ViewState["mode"]="";
			txtNew.Visible=false;
			SetEnableStatus(true);
			DrawGrid();
		}

	}
}
