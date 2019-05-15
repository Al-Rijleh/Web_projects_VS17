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
	/// Summary description for ProgramCodes.
	/// </summary>
	public class ProgramCodes : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.RadioButtonList optProgramCode;
		protected System.Web.UI.WebControls.Label lblScript;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				FillProgramCode();
			}
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
			this.optProgramCode.SelectedIndexChanged += new System.EventHandler(this.optProgramCode_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void FillProgramCode()
		{
			string strCode = Request.Params["code"].ToString();
			System.Data.DataTable dTable;
			Oracle.DataAccess.Client.OracleConnection conn= new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd =
				new Oracle.DataAccess.Client.OracleCommand("pkg_training.program_code_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
						
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"list_","cursor","out","");
			Oracle.DataAccess.Client.OracleDataAdapter da = 
				new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataSet mds=new DataSet();
			conn.Open();
			try
			{
				
				da.Fill(mds,"Purpose");
				dTable = mds.Tables["Purpose"];	
				optProgramCode.Items.Clear();
				
				foreach (DataRow dr in dTable.Rows)
				{
					ListItem li = new ListItem(dr["program_code"].ToString()+" - "+dr["description"].ToString(),dr["program_code"].ToString()+" - "+dr["description"].ToString());
					if (dr["program_code"].ToString() == strCode)
						li.Selected = true;
					optProgramCode.Items.Add(li);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				da.Dispose();
				mds.Dispose();
				dTable=null;
			}			
		}

	

		private void optProgramCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>returnvalue('"+optProgramCode.SelectedValue+"');</script>";
		}
	}
}
