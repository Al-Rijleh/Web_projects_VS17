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

namespace PLA_Homes
{
	/// <summary>
	/// Summary description for Viewer.
	/// </summary>
	public class Viewer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Label lblTitle;

		string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["type"] == "ins")
			{
				lblTitle.Text = "Instruction";
				bject obj = SQLStatic.SQL.ExecScaler("select pkg_web.get_page_instruction('"+Request.Params["SessionId"]+"','"+Request.Params["path"]+"','1') from dual");
				if (obj != null)
					lblInstruction.Text = obj.ToString();
			}
			else if (Request.Params["type"].Trim() == "spe".Trim())
			{
				lblTitle.Text = "Special Message";
				object obj = SQLStatic.SQL.ExecScaler("select pkg_web.get_page_special_msg('"+Request.Params["SessionId"]+"','"+Request.Params["path"]+"','1','1','') from dual",ConnectionString);
				if (obj != null)
					lblInstruction.Text = obj.ToString();
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
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lblScript.Text="<script>window.close()</script>";
		}
	}
}
