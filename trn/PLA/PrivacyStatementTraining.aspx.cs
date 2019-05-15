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
	/// Summary description for PrivacyStatementTraining.
	/// </summary>
	public class PrivacyStatementTraining : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label lbl_fldPLAPrivacyNotice;
		protected System.Web.UI.WebControls.RadioButtonList optAgree;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
                Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out" + "&backurl=0", true);			
			bool Viewed=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Viewed")=="1";
			if (Viewed)
			{
				Response.Redirect("/Web_Projects/trn/PLA/SelectApp.aspx?SkipCheck=YES");
				return;
			}
			
			#region BasTemplate
			if (!IsPostBack)
			{	
				if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
				{
					if (!SQLStatic.Misc.pTemplateOn(Request.Cookies["Session_ID"].Value.ToString()))
					{
						SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"main_run",Request.Path+"?SkipCheck=YES",Training_Source.TrainingClass.ConnectioString);
						Response.Redirect("/web_projects/PTemplate/index.htm");
						return;
					}
				}
				Template.BasTemplate objBasTemplate = new Template.BasTemplate();
				try
				{					
					if (Request.Cookies["Session_ID"] == null)
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error=Cookie not found. Please signon first",true);					
					string strResult = objBasTemplate.Authenticate(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),true,false);
					if (strResult!="")
					{
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult,false);
						return;
					}
					objBasTemplate.SetSeatchField(0);
					objBasTemplate.ShowNotes = false;					
					LblTemplateHeader2.Text = objBasTemplate.Header2();		
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
				
					// setup header information. You need to add the "2nd" and "3rd" parmeter.					
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
				if ((ViewState["Employee_Number"].ToString() == "") || (ViewState["Employee_Number"].ToString() == "0"))
				{
					Response.Redirect("out.aspx?message=You must select an employee first " , true);
				}
				if (!ProductCodeNotExists())
					Response.Redirect("out.aspx?message=Your Employer has not selected the Training Product for Processing_Year " + ViewState["Processing_Year"].ToString(), true);	

				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"FOUND_EMPLOYEE_NUMBER","",Training_Source.TrainingClass.ConnectioString);
				if ((ViewState["User_ID"] == null) ||(ViewState["User_ID"].ToString() == ""))
					Response.Redirect("out.aspx?message= \"Request and Manage Training\" failed to connect to the program. You might not have the proper authorization. Please contact MyEnroll.com at "+Training_Source.TrainingClass.HelpPhoneNumber(),true);
				if (ViewState["User_Group_ID"].ToString()=="2")
				{
					Response.Redirect("out.aspx?message="+"You are currently logged in as Benefit Administrator. You must logon as an Employee to access this program.",true);
					return;
				}
				if (ViewState["User_Group_ID"].ToString()!="1")
				{
					if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
						if (!Training_Source.TrainingClass.CanAccessOtherApplications(ViewState["User_ID"].ToString())) //not super user
							if (!SetEmployeeNumber())
								Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your MyEnroll Employee Number is not defined. Please Contact MyEnroll.com @ "+
									Training_Source.TrainingClass.HelpPhoneNumber(),true);
				}

				if (ViewState["Employee_Number"].ToString() == "0")
					Response.Redirect("out.aspx?message=You must select an employee first",true);

                //if (ViewState["User_Group_ID"].ToString()!="1")
                //{
                //    string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
                //    if (strMesg!="")
                //        Response.Redirect("out.aspx?message="+strMesg,true);
                //}
				SetCurrentProcessingYear();
								
				ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
				lbl_fldPLAPrivacyNotice.Text = Training_Source.TrainingClass.Privacy_Statement(ViewState["Employee_Number"].ToString());
				SetPageHeader();
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
			this.optAgree.SelectedIndexChanged += new System.EventHandler(this.optAgree_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private bool ProductCodeNotExists()
		{
			string strSQL = "select pkg_training.accounthasproduct_id(" + ViewState["Employee_Number"].ToString() + "," + ViewState["Processing_Year"].ToString() + ") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL);
			if (ob.ToString() == "0")
				return false;
			else
				return true;
		}

		private bool SetEmployeeNumber()
		{
			bool eeFound = true;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training.set_employee_number",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "User_id_",ViewState["User_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Session_id_",Request.Cookies["Session_ID"].Value.ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_","varchar2","out",null,20);
			
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
				if (cmd.Parameters["employee_number_"].Value == null)
					eeFound = false;
				else
					ViewState["Employee_Number"]= cmd.Parameters["employee_number_"].Value.ToString();
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();				
			}
			return eeFound;
		}

		private void SetCurrentProcessingYear()
		{
			string strSQL="select pkg_training.ee_current_processing_year("+ViewState["Employee_Number"].ToString()+") from dual";
			object ob = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString);
			if (ob==null)
				Response.Redirect("out.aspx?message=Current Processing Year is not defined for Employee Number "+ViewState["Employee_Number"].ToString(),true);
			else
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Processing_Year",ob.ToString(),Training_Source.TrainingClass.ConnectioString);
				ViewState["Processing_Year"]=ob.ToString();
				ob = null;
			}
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=Training_Source.TrainingClass.ConnectioString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}
		
		private void SetPageHeader()
		{
			string setPTemplate = SetFullHeader(Page,ViewState["Employee_Number"].ToString()); 
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"setPTemplate", setPTemplate);
			string strFoorer = FormId(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
			strFoorer=Setfooter(strFoorer);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"strFoorer", strFoorer);
		}

		private string SetFullHeader(Page wpage,string strEmployee_number)
		{
			DataTable tbl=null;
			string eeinfo="";
			string erinfo="";
	
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					Training_Source.TrainingClass.ConnectioString);
				eeinfo = "Employee:&nbsp;&nbsp;&nbsp;"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
					"  -  MyEnroll#: "+strEmployee_number+
					"  Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
				erinfo = "Employer:&nbsp;&nbsp;&nbsp;"+tbl.Rows[0]["account_name"].ToString()+" (Acct# "+tbl.Rows[0]["account_number"].ToString()+")";
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
			SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"2ndTitle",eeinfo,Training_Source.TrainingClass.ConnectioString);
			SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"3rdTitle",erinfo,Training_Source.TrainingClass.ConnectioString);
			if (!SQLStatic.Web_Data.Has_Role(strEmployee_number,"100400"))
			{
				SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"HPA","",Training_Source.TrainingClass.ConnectioString);
			}
			else
				SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"HPA","PLA",Training_Source.TrainingClass.ConnectioString);
			string setPTemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/header.aspx?callingurl="+wpage.Request.Path+"','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			return setPTemplate;
		}

		private string SetHeaderInformation(string strEmployee_number, Label lblEE, Label lblER,
			Label lblFormID)
		{
			DataTable tbl=null;
			string strAccountNumber = "";
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					Training_Source.TrainingClass.ConnectioString);
				lblEE.Text = "<B>"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
					"</B>  -  MyEnroll#: "+strEmployee_number+
					"  Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
				lblER.Text = tbl.Rows[0]["account_name"].ToString()+" (Acct# "+tbl.Rows[0]["account_number"].ToString()+")";
				strAccountNumber = tbl.Rows[0]["account_number"].ToString();
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
			return strAccountNumber;			
		}

		private string Setfooter(string strextra)
		{
			string setPTemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/CopyRight.aspx?extra="+strextra+"','Benefit_Allocations_Systems_Inc_Copyright_Information_Frame');</script>";
			return setPTemplate;
		}

		private string FormId(string employee_number, string processing_year)
		{
			object ob = SQLStatic.SQL.ExecScaler(
				"select pkg_training.get_form_id("+employee_number+","+processing_year+") from dual",Training_Source.TrainingClass.ConnectioString);
			if (ob!=null)
				return ob.ToString();
			else
				return "";
		}

		private void optAgree_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (optAgree.SelectedIndex==0)
			{
				SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Viewed","1");
				Response.Redirect("/Web_Projects/trn/PLA/SelectApp.aspx?SkipCheck=YES");
			}
			else
				Response.Redirect("/web_projects/pTemplate/routing/Default.aspx?URL_=/scripts/basweb.exe/view?Module=N");
		}
	}
}
