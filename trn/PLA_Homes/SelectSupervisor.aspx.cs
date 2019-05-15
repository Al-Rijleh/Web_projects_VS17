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
	/// Summary description for SelectSupervisor.
	/// </summary>
	public class SelectSupervisor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblHidden;
		protected System.Web.UI.WebControls.DataGrid dgEEs;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Label lblSupervisorListTitle;
		protected System.Web.UI.WebControls.Label lblScript;

		string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		private void Page_Load(object sender, System.EventArgs e)
		{		
			#region PopUp BasTemplate
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
			this.dgEEs.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgEEs_ItemCreated);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private DataTable GetTable()
		{
			DataTable tbl=null;			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("pkg_training_2.employeeslist_sup",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;			
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "admin_ee_number","number","in",ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_","cursor","out","");
			
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
			DataTable tbl = GetTable();
			dgEEs.DataSource = tbl;
			dgEEs.DataBind();
		}

		private void dgEEs_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				int indx = e.Item.ItemIndex;
				DataTable tbl = (DataTable) dgEEs.DataSource;				
				
				try
				{
					
					string strEmployee_Number = tbl.Rows[indx]["supervisor_employee_number"].ToString();						
					
					// create drop down
					DropDownList ddl = new DropDownList();
					ddl.CssClass="fontsmall";
					ddl.Width=System.Web.UI.WebControls.Unit.Pixel(120);
					ddl.ID = "ddl_"+strEmployee_Number;					
					ListItem li = new ListItem("Select","0");						
					ddl.Items.Add(li);						
																
					// create button
					Button btn2 = new Button();
					btn2.CssClass = "actbtn_go_next_button";
					btn2.ID="btn_"+strEmployee_Number;
					btn2.Text = "Go";				
					btn2.Click += new System.EventHandler(this.btnMenu_Click);
					TableCell cell = e.Item.Cells[2];						
					cell.Controls.Add(ddl);
					cell.Controls.Add(btn2);

					LinkButton lnk1 = new LinkButton();
					lnk1.ID = "lnk1_"+strEmployee_Number;
					lnk1.CssClass = "fontsmall";
					lnk1.Text = tbl.Rows[indx]["name"].ToString();
					lnk1.Click += new System.EventHandler(this.lnkMenu_Click);
					TableCell cell1 = e.Item.Cells[0];						
					cell1.Controls.Add(lnk1);

					LinkButton lnk2 = new LinkButton();
					lnk2.ID = "lnk2_"+strEmployee_Number;
					lnk2.CssClass = "fontsmall";
					lnk2.Text = tbl.Rows[indx]["email_number"].ToString();
					lnk2.Click += new System.EventHandler(this.lnkMenu_Click);
					TableCell cell2 = e.Item.Cells[1];						
					cell2.Controls.Add(lnk2);						
				}
				catch
				{
				}
			}		
		}

		private void ProcessClick(string strEmployee_Number)
		{
			DataTable dt=(DataTable) dgEEs.DataSource;
			string strEEFldNumber="TRN_FOUND_EMPLOYEE_NUMBER";
			string strEEFldName = "Found_Name";
			string strEEFldEmail= "Found_Email";
			if ((Request.Params["UseDefaultName"] != null)&&(Request.Params["UseDefaultName"] == "Y"))
			{
				strEEFldNumber= "Employee_Number";
				strEEFldName  = "Employee_Name";
				strEEFldEmail = "Employee_Email";
			}
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["supervisor_employee_number"].ToString()==strEmployee_Number)
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),strEEFldNumber,dr["supervisor_employee_number"].ToString(),ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),strEEFldName,dr["name"].ToString(),ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),strEEFldEmail,dr["email_number"].ToString(),ConnectionString);
				}
			}
		}

		private void lnkMenu_Click(object sender, System.EventArgs e)
		{
			ProcessClick(((LinkButton)sender).ID.Substring(5));	
			string strURL = "SupervisorApprove.aspx";
			if (Request.Params["returl"]!=null)
				strURL = Request.Params["returl"];
			lblScript.Text="<script>opener.window.location.href='/Web_Projects/trn/PLA_Approval/SupervisorPendingApplications.aspx?SkipCheck=YES';window.close()</script>";
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			ProcessClick(((Button)sender).ID.Substring(4));	
			string strURL = "SupervisorApprove.aspx";
			if (Request.Params["returl"] != null)
				strURL = Request.Params["returl"];
			lblScript.Text="<script>opener.window.location.href='/Web_Projects/trn/PLA_Approval/SupervisorPendingApplications.aspx';window.close()</script>";
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lblScript.Text="<script>window.close()</script>";
		}
	}
}
