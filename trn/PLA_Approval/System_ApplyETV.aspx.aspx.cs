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
	/// Summary description for System_ApplyETV_aspx.
	/// </summary>
	public class System_ApplyETV_aspx : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblTemplateFooter;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid dgTrainingRequest;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.TextBox txtEmployeeName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected Karamasoft.WebControls.UltimateMenu um;
		protected System.Web.UI.WebControls.Label LblTemplateHeader1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected Karamasoft.WebControls.UltimatePanel upPO;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);			
			lblScript.Text = "";
			#region BasTemplate
			if (!IsPostBack)
			{	
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{					
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,false);
					if (strResult!="")
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult.Replace("\n","~"),false);
						return;
					}
					LblTemplateHeader1.Text = objBasTemplate.Header1();
					LblTemplateHeader2.Text = objBasTemplate.Header2();
					LblTemplateFooter.Text = objBasTemplate.Footer();
					um.MenuSourceXml = objBasTemplate.MenuXML(); 
					um.DataBind();			
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
					// Wizard
					string strpnlXML = objBasTemplate.PanelXML();
					if (strpnlXML!="")
					{
						if (strpnlXML.IndexOf("Error:") != -1)
						{
							Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strpnlXML.Replace("\n","~"),false);
							return;
						}
						upPO.PanelSourceXml = strpnlXML;
						upPO.DataBind();
						ViewState["CurrGrp"]			= objBasTemplate.Wizard_Value("CurrGrp");
						ViewState["CurrGrpTtl"]			= objBasTemplate.Wizard_Value("CurrGrpTtl");
						ViewState["CurrGrpUrl"]			= objBasTemplate.Wizard_Value("CurrGrpUrl");
						ViewState["CurrStp"]			= objBasTemplate.Wizard_Value("CurrStp");
						ViewState["CurrStpTtl"]			= objBasTemplate.Wizard_Value("CurrStpTtl");
						ViewState["CurrStpUrl"]			= objBasTemplate.Wizard_Value("CurrStpUrl");
						ViewState["Is_Step_Completed"]	= objBasTemplate.Wizard_Value("Is_Step_Completed");
						ViewState["NextGrp"]			= objBasTemplate.Wizard_Value("NextGrp");
						ViewState["NextGrpTtl"]			= objBasTemplate.Wizard_Value("NextGrpTtl");
						ViewState["NextGrpUrl"]			= objBasTemplate.Wizard_Value("NextGrpUrl");
						ViewState["NextStp"]			= objBasTemplate.Wizard_Value("NextStp");
						ViewState["NextStpTtl"]			= objBasTemplate.Wizard_Value("NextStpTtl");
						ViewState["NextStpUrl"]			= objBasTemplate.Wizard_Value("NextStpUrl");
						ViewState["NoGrp"]				= objBasTemplate.Wizard_Value("NoGrp");
						ViewState["NoStpInGrp"]			= objBasTemplate.Wizard_Value("NoStpInGrp");
						ViewState["PrvGrp"]				= objBasTemplate.Wizard_Value("PrvGrp");
						ViewState["PrvGrpTtl"]			= objBasTemplate.Wizard_Value("PrvGrpTtl");
						ViewState["PrvGrpUrl"]			= objBasTemplate.Wizard_Value("PrvGrpUrl");
						ViewState["PrvStp"]				= objBasTemplate.Wizard_Value("PrvStp");  
						ViewState["PrvStpTtl"]			= objBasTemplate.Wizard_Value("PrvStpTtl");
						ViewState["PrvStpUrl"]			= objBasTemplate.Wizard_Value("PrvStpUrl");
					}
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
			LblTemplateHeader1.Text = Template.BasTemplate.ChangeLogo(LblTemplateHeader1.Text,1);
			if (!IsPostBack)
			{
				SetCurrentProcessingYear();
				SetHeaderInformation();
				ProcessesStarFunctionality();	
				
				ViewState["Adjust_Employee"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				if (ViewState["Adjust_Employee"].ToString()!="")
				{
					txtEmployeeName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Name",PLA_Approval.TrainingClass.ConnectionString);					
					DrawGrid();
				}
			}
			if (ViewState["Adjust_Employee"].ToString()!="")
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetCurrentProcessingYear()
		{
			string strSQL="select pkg_training.ee_current_processing_year("+ViewState["Employee_Number"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob==null)
				Response.Redirect("out.aspx?message=Current Processing Year is not defined for Employee Number "+ViewState["Employee_Number"].ToString(),true);
			else
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Processing_Year",ob.ToString(),PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Processing_Year"]=ob.ToString();
				ob = null;
			}
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			string strParamQuery="?returl="+Request.Path+"&inst=4";
			lblScript.Text = "<script>popup('/Web_Projects/trn/PLA_Approval/SearchEmployee.aspx"+strParamQuery+"',500,700)</script>";
		}

		private  DataTable GetGridTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training.paid_request_list",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",ViewState["Adjust_Employee"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "paid_list_","cursor","out","");

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
			dgTrainingRequest.DataSource = tbl;
			dgTrainingRequest.DataBind();
		}
	}
}
