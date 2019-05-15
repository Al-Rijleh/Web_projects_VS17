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
	/// Summary description for PrivacyStatementEval.
	/// </summary>
	public class PrivacyStatementEval : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButtonList optAgree;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lbl_fldPLAPrivacyNotice;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblFormID;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string stridParam0=TransferedParam(Request.Params[0]);
			int intpos = stridParam0.IndexOf("_");
			ViewState["Request_Record_ID"] =  stridParam0.Substring(intpos+1);
			ViewState["Record_ID"]= stridParam0.Substring(0,intpos);
			CanAccess();
			ViewState["Employee_Number"]=Training_Source.TrainingClass.EmployeeNumberFromRecordID(ViewState["Request_Record_ID"].ToString());
			ViewState["User_Name"] = "Auto Gen";
			ViewState["User_Group_ID"]="3";
			ViewState["Processing_Year"]=DateTime.Today.Year.ToString();

			SetHeaderInformation();
			lbl_fldPLAPrivacyNotice.Text = Training_Source.TrainingClass.Privacy_Statement(ViewState["Employee_Number"].ToString());
//			lblFormID.Text = Training_Source.TrainingClass.FormId(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
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
			this.optAgree.SelectedIndexChanged += new System.EventHandler(this.optAgree_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private string TransferedParam(string stridParam0)
		{
			string strSQL= "select pkg_trn_fdic.get_trnsfered_completed_id('"+stridParam0+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"] = Training_Source.TrainingClass.SetHeaderInformation(ViewState["Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}	 

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void CanAccess()
		{
			string strSQL="select pkg_trn_fdic.canaccessevaluation("+ViewState["Record_ID"].ToString()+","+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="1")
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Unknown Application"+"&backurl=0" ,true);
			else if (strResult=="2")
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Evaluation already completed"+"&backurl=0" ,true);
		}

		private void optAgree_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			if (optAgree.SelectedValue=="0")
			{
				if (Request.Params["a"]==null)
					Response.Redirect("TrainingAnswers.aspx?"+Request.Params[0],true);
				else
					Response.Redirect("CancelPaidRequest.aspx?id="+Request.Params[0],true);
			}	
			else			
				lblScript.Text = "<script>window.location.href='http://www.myenroll.com'</script>";
			
		}
	}
}
