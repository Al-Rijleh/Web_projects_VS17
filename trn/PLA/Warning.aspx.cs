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
	/// Summary description for Confirm.
	/// </summary>
	public class Warning : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSaveNext;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCloseStay;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{	
			lblScript.Text="";
			if (!IsPostBack)
			{
				if (Request.Params["d"]=="b")
				{
					lnkbtnSaveNext.Text = lnkbtnSaveNext.Text.Replace("next","back");
					lblInstruction.Text=lblInstruction.Text.Replace("next","previous");
				}
				if (Request.Params["d"]=="c")
				{
					lnkbtnSaveNext.Text = "Save then Close";
					lnkbtnCloseStay.Text= "Close without Saving";
					lblInstruction.Text="Data was changed without saving. Please choose one of the options below:";
				}
				if (Request.Params["d"]=="l")
				{
					
					lnkbtnSaveNext.Text = "Yes - Delete Record";
					lnkbtnCloseStay.Text= "No - Close without Deleting";
					lblInstruction.Text="Are you sure you want to delete the expense item <b>'"+Request.Params["type"].ToString()+"'</B>";
				}
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
			this.lnkbtnSaveNext.Click += new System.EventHandler(this.lnkbtnSaveNext_Click);
			this.lnkbtnCloseStay.Click += new System.EventHandler(this.lnkbtnCloseStay_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnkbtnCloseStay_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["d"]=="c")
				lblScript.Text="<script>closeparent()</script>";
			else
			  lblScript.Text="<script>closerefresh()</script>";
		}

		private void lnkbtnSaveNext_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["d"]=="b")
				lblScript.Text="<script>saveback()</script>";
			else
				lblScript.Text="<script>savenext()</script>";
		
		}
		
	}
}
