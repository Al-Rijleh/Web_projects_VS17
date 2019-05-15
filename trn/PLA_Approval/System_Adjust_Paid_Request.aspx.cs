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
	/// Summary description for System_Adjust_Paid_Request.
	/// </summary>
	public class System_Adjust_Paid_Request : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Button btnSelect;
		protected System.Web.UI.WebControls.TextBox txtEmployeeName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DataGrid dgTrainingRequest;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Label lblScript;
        protected System.Web.UI.HtmlControls.HtmlTable TableData;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);			
			lblScript.Text = "";
			#region BasTemplate
			if (!IsPostBack)
			{	
				if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"main_run",Request.Path+"?SkipCheck=YES",PLA_Approval.TrainingClass.ConnectionString);
					Response.Redirect("/web_projects/PTemplate/index.htm");
					return;
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
				SetCurrentProcessingYear();
				SetHeaderInformation();
				ProcessesStarFunctionality();	
				
				ViewState["Adjust_Employee"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Found_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
                if (ViewState["Adjust_Employee"].ToString() != "")
                {
                    txtEmployeeName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Name", PLA_Approval.TrainingClass.ConnectionString);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Employee_Number", "", PLA_Approval.TrainingClass.ConnectionString);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Name", "", PLA_Approval.TrainingClass.ConnectionString);
                    SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Found_Email", "", PLA_Approval.TrainingClass.ConnectionString);
                }
                else
                {
                    ViewState["Adjust_Employee"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Applicant_Employee_Number", PLA_Approval.TrainingClass.ConnectionString);
                    txtEmployeeName.Text = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Applicant_Employee_Name", PLA_Approval.TrainingClass.ConnectionString);
                }
                if (ViewState["Adjust_Employee"].ToString()!="")
                    DrawGrid();
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
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			this.dgTrainingRequest.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTrainingRequest_ItemCreated);
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
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
//			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
            string strParamQuery = "&returl=" + Request.Path + "?SkipCheck=YES&start=a";
            Response.Redirect("/Web_Projects/trn/EESearch/Default.aspx?samePage=y" + strParamQuery);
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

		private void dgTrainingRequest_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgTrainingRequest.DataSource;
					string strindex = tbl.Rows[indx]["record_id"].ToString();

					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="smallsize";					
					ddl.ID = "ddl_"+strindex;						
					ListItem li;
					li = new ListItem("Adjust Paid Amounts","1");								
					ddl.Items.Add(li);
														
					// create button
					Button btn2 = new Button();
					btn2.CssClass = "actbtn_go_next_button";
					btn2.ID="btn_"+strindex;
					btn2.Text = "Go";				
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[2];					
					cell.Controls.Add(ddl);
					cell.Controls.Add(btn2);					
				}
				catch
				{
				}
			}
		}
		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			string strindex = ((Button)sender).ID.Substring(4);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",ViewState["Adjust_Employee"].ToString(),PLA_Approval.TrainingClass.ConnectionString);
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Applicant_Employee_Name", txtEmployeeName.Text, PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",strindex,PLA_Approval.TrainingClass.ConnectionString);
			Response.Redirect("ExpenseAdjustment.aspx?SkipCheck=YES&call="+Request.Path);	
			
		}

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("System_Administrator.aspx?SkipCheck=YES");
        }
	}
}
