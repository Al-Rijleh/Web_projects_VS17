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
using System.Collections;

namespace PLA_Source
{
	/// <summary>
	/// Summary description for Out.
	/// </summary>
	public class Out : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkbtnHome;
		protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel dvBadData;
        protected System.Web.UI.WebControls.Panel dvMsg;
        protected System.Web.UI.WebControls.Panel dvbtn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            if (!Request.Params["message"].Equals("code=1"))
                Label1.Text = Request.Params["message"];
            else
            {
                dvBadData.Visible = true;
                dvMsg.Visible = false;
                dvbtn.Visible = false;
            }
			
//			if (Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
//				hlHome.NavigateUrl = "/web_projects/trn/PLA_Homes/Home1.aspx";
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
			this.lnkbtnHome.Click += new System.EventHandler(this.lnkbtnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnkbtnHome_Click(object sender, System.EventArgs e)
		{
            string strURL = "/scripts/basweb.exe/view?Module=N";
			if (Request.Params["backurl"] != null)
			{
				if (Request.Params["backurl"] != "0")
					strURL=Request.Params["backurl"];
				BASUSA.MiscTidBit.CheckForSkipCheck(strURL);
			}
			Response.Redirect("/web_projects/pTemplate/routing/Default.aspx?URL_="+strURL);
		}

        protected void brnHome_Click(object sender, EventArgs e)
        {
            string strURL = "/scripts/basweb.exe/view?Module=N";
            if (Request.Params["backurl"] != null)
            {
                if (Request.Params["backurl"] != "0")
                    strURL = Request.Params["backurl"];
                BASUSA.MiscTidBit.CheckForSkipCheck(strURL);
            }
            Response.Redirect("/web_projects/pTemplate/routing/Default.aspx?URL_=" + strURL);
        }

        protected void btnPlaEligible_Click(object sender, EventArgs e)
        {
            SendEmail();
            brnHome_Click(null, null);
        }

        private void SendEmail()
        {
            ArrayList al = new ArrayList(1);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("session_id_","in","varchar2",Request.Cookies["Session_ID"].Value.ToString()));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_3.email_not_eligible_pla",al);
        }
	}
}
