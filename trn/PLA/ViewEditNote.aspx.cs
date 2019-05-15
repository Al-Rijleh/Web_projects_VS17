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
	/// Summary description for ViewEditNote.
	/// </summary>
	public class ViewEditNote : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkbtnSaveAndStay;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancel;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.TextBox txtDescribtion;
		protected System.Web.UI.WebControls.TextBox txtRemaining;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblExpenseType;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text = "";
			if (!IsPostBack)
			{
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);	
                //}
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();	
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				SetHeaderInformation();
				GetNote();
				SetInView();
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
			this.lnkbtnCancel.Click += new System.EventHandler(this.lnkbtnCancel_Click);
			this.lnkbtnSaveAndStay.Click += new System.EventHandler(this.lnkbtnSaveAndStay_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetInView()
		{
			string strInView = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"InView",Training_Source.TrainingClass.ConnectioString);
			if (strInView=="T")
			{				
				txtDescribtion.Enabled=false;
				lnkbtnSaveAndStay.Enabled=false;
			}
		}

		private void SetHeaderInformation()
		{
			DataTable tbl=null;
			try
			{
				lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
				ViewState["Account_Number"] = Training_Source.TrainingClass.SetHeaderInformation(ViewState["Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
//				tbl = SQLStatic.EmployeeData.EEProfile(ViewState["Employee_Number"].ToString(),
//					Training_Source.TrainingClass.ConnectioString);
//				lblEmployeeInfo.Text = "<B>"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
//					"</B> - MyEnroll#: "+ViewState["Employee_Number"].ToString()+" SS#: "+BASUSA.MiscTidBit.MaskSSN(tbl.Rows[0]["social_security_number"].ToString())+
//					" Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
//				lblDivision.Text = tbl.Rows[0]["account_number"].ToString()+" - "+tbl.Rows[0]["account_name"].ToString();
//				lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
		}
		private void GetNote()
		{
			string strSQL="select t.note,t.expense_type from trn_ee_rqst_expns  t where t.record_id="+Request.Params["rid"];
			Oracle.DataAccess.Client.OracleConnection conn = 	new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strSQL,conn);
			conn.Open();	
			Oracle.DataAccess.Client.OracleDataReader reader =null;		
			try
			{
				reader = cmd.ExecuteReader();
				reader.Read();
				txtDescribtion.Text=reader.GetValue(0).ToString();
				lblExpenseType.Text = reader.GetValue(1).ToString();
			}
			finally
			{
				if (reader!=null)
					reader.Dispose();
				cmd.Dispose();
				conn.Dispose();
			}
			txtDescribtion.Text = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			txtRemaining.Text = (4000-txtDescribtion.Text.Length).ToString();
		}

		private void lnkbtnCancel_Click(object sender, System.EventArgs e)
		{
			lblScript.Text = "<script>window.close()</script>";
		}

	

		private void lnkbtnSaveAndStay_Click(object sender, System.EventArgs e)
		{
			SQLStatic.SQL.ExecNonQuery("update training_ee_expenses set note='"+txtDescribtion.Text+"' where record_id="+Request.Params["rid"],Training_Source.TrainingClass.ConnectioString);
			lblScript.Text = "<script>reloadclose()</script>";
		}
	}
}
