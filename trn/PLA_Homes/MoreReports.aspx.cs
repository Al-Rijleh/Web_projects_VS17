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
	/// Summary description for MoreReports.
	/// </summary>
	public class MoreReports : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblHidden;
		protected System.Web.UI.WebControls.LinkButton lnkbtnRequestinLast7Days;
		protected System.Web.UI.WebControls.LinkButton lnkbtnPaidInLast7Days;
		protected System.Web.UI.WebControls.LinkButton lnkbtnDeclinedInLastSevenDays;
		protected System.Web.UI.WebControls.LinkButton lnkbtnEmployeeOverBudget;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCDPEmployeeList;
		protected System.Web.UI.WebControls.LinkButton lnkbtnComprehense;
		protected System.Web.UI.WebControls.LinkButton lnkbtnNoCDP;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Label lblReportNameTitle;
	
		bool isAdministrator=false;	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblScript.Text="";
			#region PopUp BasTemplate
			if (!IsPostBack)
			{					
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{
					if (Request.Cookies["Session_ID"] == null)
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first", false);
						return;
					}
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,false);
					if (strResult!="")
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult,false);
						return;
					}
					ViewState["AccessType"]						= objBasTemplate.strAccessType;
					ViewState["Employee_Number"]				= objBasTemplate.strEmployee_Number;
					ViewState["Processing_Year"]				= objBasTemplate.strProcessingYear;
					ViewState["Role_Restriction_Level"]			= objBasTemplate.strRole_Restriction_Level;
					ViewState["Selected_Account_Number"]		= objBasTemplate.strSelected_Account_Number;
					ViewState["Selected_Employee_Class_Code"]	= objBasTemplate.strSelected_Employee_Class_Code;
					ViewState["User_Group_ID"]					= objBasTemplate.strUser_Group_ID;
					ViewState["User_ID"]						= objBasTemplate.strUser_ID;
					ViewState["User_Name"]						= objBasTemplate.strUser_Name;
					ViewState["User_Primary_Role"]				= objBasTemplate.strUser_Primary_Role;	
				}
				catch (Exception ex)
				{
					string strError = "Error Message: "+ex.Message+"~~Application:"+ex.Source+"~~Method:"+ex.TargetSite+"~~Detail:"+ex.StackTrace;
					Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strError.Replace("\n","~"));
				}
				finally
				{
					objBasTemplate.CleanUp();
					objBasTemplate.Dispose();
				}

			}
			#endregion
			if (!IsPostBack)
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "ReportReturnTo", Request.Path);
			}
			isAdministrator = (Request.Params["isadmin"]!=null)&&(Request.Params["isadmin"]== "T");

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
			this.lnkbtnRequestinLast7Days.Click += new System.EventHandler(this.lnkbtnRequestinLast7Days_Click);
			this.lnkbtnPaidInLast7Days.Click += new System.EventHandler(this.lnkbtnPaidInLast7Days_Click);
			this.lnkbtnDeclinedInLastSevenDays.Click += new System.EventHandler(this.lnkbtnDeclinedInLastSevenDays_Click);
			this.lnkbtnEmployeeOverBudget.Click += new System.EventHandler(this.lnkbtnEmployeeOverBudget_Click);
			this.lnkbtnCDPEmployeeList.Click += new System.EventHandler(this.lnkbtnCDPEmployeeList_Click);
			this.lnkbtnComprehense.Click += new System.EventHandler(this.lnkbtnComprehense_Click);
			this.lnkbtnNoCDP.Click += new System.EventHandler(this.lnkbtnNoCDP_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private string setReportURL(int intID)
		{
			return "javascript:open('/web_projects/Reporting/FillParameters.aspx?recid="+intID.ToString()+"&rep=DisplayExcel.aspx&accnt=','Param','width=600,title=no,resizable,scrollbars,height=500,left=50,screenX=50,top=50,screenY=50')";
		}

		private void lnkbtnsurvey_non_respond_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				lblScript.Text = "<script>alert('This report is not available at this time it will be Coming Soon');</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid="+541+"&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(541)+"</script>";
		}

		private void lnkbtnRequestNotReviewed_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				lblScript.Text = "<script>alert('This report is not available at this time it will be Coming Soon');</script>";
			else
				lblScript.Text = "<script>"+setReportURL(542)+"</script>";
		}

		private void lnkbtnRequestinLast7Days_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=721&rep=DisplayExcel.aspx");
				//lblScript.Text = lblScript.Text = "<script>"+setReportURL(721)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 543 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(543)+"</script>";
		}

		private void lnkbtnPaidInLast7Days_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=722&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(722)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 544 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(544)+"</script>";
		}

		private void lnkbtnDeclinedInLastSevenDays_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=723&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(723)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 545 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(545)+"</script>";
		}
		
		private void lnkbtnEmployeeOverBudget_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=724&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(724)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 546 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(546)+"</script>";
		}

		private void lnkbtnCDPEmployeeList_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=725&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(725)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 3 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(3)+"</script>";
		}

		private void lnkbtnComprehense_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=726&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(726)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 121 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(121)+"</script>";
		}

		private void lnkbtnNoCDP_Click(object sender, System.EventArgs e)
		{
			if (isAdministrator)
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=727&rep=DisplayExcel.aspx");
				//lblScript.Text = "<script>"+setReportURL(727)+"</script>";
			else
				Response.Redirect("/web_projects/Reporting/FillParameters.aspx?recid=" + 441 + "&rep=DisplayExcel.aspx&accnt=");
				//lblScript.Text = "<script>"+setReportURL(441)+"</script>";
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Home1.aspx?SkipCheck=YES");
		}
	}
}
