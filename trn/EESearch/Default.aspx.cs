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

namespace EESearch
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Label lblHeading;
		protected System.Web.UI.WebControls.TextBox txtSearch;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo;
		protected System.Web.UI.WebControls.DataGrid dgEEs;
		protected System.Web.UI.WebControls.CheckBox chkTerminated;
		protected System.Web.UI.WebControls.CheckBox chbShowCannotAccess;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Button btnCack;

        private string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		private void Page_Load(object sender, System.EventArgs e)
		{
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
						Response.Redirect("/web_projects/login_error/ErrorPage.aspx?error="+strResult,false);
						return;
					}
					if ((Request.Params["samePage"]!=null)&&(Request.Params["samePage"]=="y"))
					{
						objBasTemplate.SetSeatchField(0);
						objBasTemplate.ShowNotes = false;					
						LblTemplateHeader2.Text = objBasTemplate.Header2();		
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
				if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="pla_admin"))
				{
					lblHeading.Enabled = false;
					txtSearch.Enabled = false;
					lnkbtnGo.Enabled = false;
					chkTerminated.Enabled = false;
					SetHeaderInformation();
				}
				else
					txtSearch.Text = Request.Params["start"];				
			}
			string strwidth = "'100%'";
			if ((Request.Params["samePage"]!=null)&&(Request.Params["samePage"]=="y"))
				strwidth ="'795'";
			else
			{
				string strSetWidth="<script> setTableWidth("+strwidth+");</script>";
				Page.ClientScript.RegisterStartupScript(Page.GetType(),"strSetWidth",strSetWidth);
			}

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
			this.lnkbtnGo.Click += new System.EventHandler(this.lnkbtnGo_Click);
			this.dgEEs.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgEEs_ItemCreated);
			this.btnCack.Click += new System.EventHandler(this.btnCack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private  void SetHeaderInformation()
		{
			string strEmployee_number = ViewState["Employee_Number"].ToString();
			DataTable tbl=null;
			string eeinfo="";
			string erinfo="";
	
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					ConnectionString);
				eeinfo = "Employee:&nbsp;&nbsp;&nbsp;"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
					"  -  MyEnroll#: "+strEmployee_number+
					"  Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
				erinfo = "Employer:&nbsp;&nbsp;&nbsp;"+tbl.Rows[0]["account_name"].ToString()+" (Acct# "+tbl.Rows[0]["account_number"].ToString()+")";
				ViewState["Account_Number"]= tbl.Rows[0]["account_number"].ToString();

			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"2ndTitle",eeinfo,ConnectionString);
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"3rdTitle",erinfo,ConnectionString);
			string setPTemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/header.aspx?callingurl="+Request.Path+"?SkipCheck=YES','Frame_detailing_the_selected_module_and_current_program_page');</script>";			
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"setPTemplate",setPTemplate);
		}

		private  void FilterTable(DataTable tbl)
		{
            foreach (DataRow dr in tbl.Rows)
            {
                if (!dr["email_number"].ToString().ToUpper().EndsWith("MENTO@FDIC.GOV"))
                    dr["email_number"] = string.Empty;                
            }
            tbl.AcceptChanges();
			// if the user is not Contractor Super User then exit;
			if ((ViewState["User_Primary_Role"].ToString()!="100408")||(ViewState["User_Group_ID"].ToString()!="7"))
				return;
			
			object obj = SQLStatic.SQL.ExecScaler(
				"select pkg_training_3.super_contractors_cansee("+ViewState["User_ID"].ToString()+") from dual");
			if (obj==null)
				return;
			string strLimitiation= obj.ToString();
			if (strLimitiation=="")
				return;
			int cnt=0;
			foreach (DataRow dr in tbl.Rows)
			{
				if (strLimitiation.IndexOf(dr["poi"].ToString()) == -1)
					tbl.Rows[cnt].Delete();
                else if (string.IsNullOrEmpty(dr["poi"].ToString()))
                    tbl.Rows[cnt].Delete();
				else if ((dr["can_access"].ToString() == "0")&&(!chbShowCannotAccess.Checked))
					tbl.Rows[cnt].Delete();                
				cnt++;
			}
			tbl.AcceptChanges();
		}

		private DataTable GetTable()
		{
			DataTable tbl=null;
			string strProcedureName="";
			if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="pla_admin"))
			{
				strProcedureName = "pkg_training_2.EmployeesList_adin";
				if (chkTerminated.Checked)
					strProcedureName = "pkg_training_2.EmployeesList_adin_withterm";
			}
			else if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="pla_adminee"))
			{
				strProcedureName = "pkg_training_2.EmployeesList_adin";
				if (chkTerminated.Checked)
					strProcedureName = "pkg_training_2.EmployeesList_adin_withterm";
			}	
			else if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="Super"))
			{
				strProcedureName = "pkg_training_3.supervisorslist";
				
			}	
			else
			{
				strProcedureName = "pkg_training_2.employeeslist";
				if (chkTerminated.Checked)
					strProcedureName = "pkg_training_2.employeeslistwithterminated";
			}
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="pla_adminee"))
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "search_name_",txtSearch.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "admin_ee_number","number","in",ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_","cursor","out","");
			}
			else if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="pla_admin"))
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "admin_ee_number","number","in",ViewState["Employee_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_","cursor","out","");
			}
			else if ((Request.Params["who"]!=null)&& (Request.Params["who"]=="Super"))
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "searchfor_",txtSearch.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "accountnumber_",ViewState["Selected_Account_Number"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_","cursor","out","");
				
			}	
			else
			{
                string strShow_cannot_access = "0";
                if (chbShowCannotAccess.Checked)
                    strShow_cannot_access = "1";
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "search_name_",txtSearch.Text);
                SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Show_cannot_access_", strShow_cannot_access);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "retresult_","cursor","out","");
			}

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
			FilterTable(tbl);
            //---- commeted out per Art Email Re: PLA Manager Search Results Fri 6/10/2016 12:58 PM

            //foreach (DataRow dr in tbl.Rows)
            //{               
            //    if (!dr["email_number"].ToString().ToUpper().EndsWith("@FDIC.GOV"))
            //        dr.Delete();
            //}
            //tbl.AcceptChanges();
			if (tbl.Rows.Count > 10)
			{
				for (int i=10;i<=tbl.Rows.Count-1;i++)
					tbl.Rows[i].Delete();
				tbl.AcceptChanges();
			}
			return tbl;
		}

		private void DrawGrid()
		{
			DataTable tbl = GetTable();
			dgEEs.DataSource = tbl;
			dgEEs.DataBind();
		}

		private void lnkbtnGo_Click(object sender, System.EventArgs e)
		{
			DrawGrid();
		}

		private void dgEEs_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataTable dt = (DataTable) dgEEs.DataSource;
			try
			{  
				
				DateTime dTermDate=(DateTime) dt.Rows[e.Item.ItemIndex]["termination_date"];
				{
					e.Item.Cells[0].BackColor = System.Drawing.Color.LightCoral;
					e.Item.Cells[0].ForeColor=System.Drawing.Color.White;
					e.Item.Cells[0].Font.Italic=true;
					e.Item.Cells[0].Font.Strikeout=true;	

					e.Item.Cells[1].BackColor = System.Drawing.Color.LightCoral;
					e.Item.Cells[1].ForeColor=System.Drawing.Color.White;
					e.Item.Cells[1].Font.Italic=true;
					e.Item.Cells[1].Font.Strikeout=true;	
				}
			
			}
			catch {}
		}

		private bool ProcessClick(string strEmployee_Number)
		{
			string strApplicantEmployeeNumber = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Applicant_Employee_Number");
			if (strApplicantEmployeeNumber == strEmployee_Number)
			{
				if ((Request.Params["AllowApplicant"] == null) || (Request.Params["AllowApplicant"].ToString() != "YES"))
				{
					string strCannotReroutetoSelf = "<script>alert('You cannot select this employee because he/she is the applicant');</script>";
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "strCannotReroutetoSelf", strCannotReroutetoSelf);
					return false;
				}
			}
			DataTable dt=(DataTable) dgEEs.DataSource;
			string strEEFldNumber="Found_Employee_Number";
			string strEEFldName = "Found_Name";
			string strEEFldEmail= "Found_Email";
            if ((Request.Params["UseAltName"] != null) && (Request.Params["UseAltName"].ToString() != ""))
            {
                strEEFldNumber = Request.Params["UseAltName"]+"_Number";
                strEEFldName = Request.Params["UseAltName"]+"_Name";
                strEEFldEmail = Request.Params["UseAltName"]+"_Email";
            }
			if ((Request.Params["UseDefaultName"] != null)&&(Request.Params["UseDefaultName"] == "Y"))
			{
				strEEFldNumber= "Employee_Number";
				strEEFldName  = "Employee_Name";
				strEEFldEmail = "Employee_Email";
			}
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["employee_number"].ToString()==strEmployee_Number)
				{
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),strEEFldNumber,dr["employee_number"].ToString(),ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),strEEFldName,dr["name"].ToString(),ConnectionString);
					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),strEEFldEmail,dr["email_number"].ToString(),ConnectionString);
				}
			}
			return true;
		}

		private void lnkMenu_Click(object sender, System.EventArgs e)
		{
			if (!ProcessClick(((LinkButton)sender).ID.Substring(5)))
				return;
            SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(), "Adjust_Employee", "");	
			string strURL = "SupervisorApprove.aspx";
			if (Request.Params["returl"]!=null)
				strURL = Request.Params["returl"];
			if ((Request.Params["samePage"]!=null)&&(Request.Params["samePage"]=="y"))
				Response.Redirect(strURL);
            if ((Request.Params["samePage"] != null) && (Request.Params["samePage"] == "R")) // Telerik window
                lblScript.Text = "<script>closeWindow(2)</script>";
			else
				lblScript.Text="<script>opener.window.location.href='"+strURL+"';window.close()</script>";
		}

		private void btnMenu_Click(object sender, System.EventArgs e)
		{
			ProcessClick(((Button)sender).ID.Substring(4));	
			string strURL = "SupervisorApprove.aspx";
			if (Request.Params["returl"] != null)
				strURL = Request.Params["returl"];
			if ((Request.Params["samePage"]!=null)&&(Request.Params["samePage"]=="y"))
				Response.Redirect(strURL);
            if ((Request.Params["samePage"] != null) && (Request.Params["samePage"] == "R")) // Telerik window
                lblScript.Text = "<script>closeWindow(2)</script>";
			else
				lblScript.Text="<script>opener.window.location.href='"+strURL+"';window.close()</script>";
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
					
					string strEmployee_Number = tbl.Rows[indx]["employee_number"].ToString();						
					
			

					LinkButton lnk1 = new LinkButton();
					lnk1.ID = "lnk1_"+strEmployee_Number;
					lnk1.CssClass = "smallsize";
					lnk1.Text = tbl.Rows[indx]["name"].ToString();
					lnk1.Click += new System.EventHandler(this.lnkMenu_Click);
					TableCell cell1 = e.Item.Cells[0];						
					cell1.Controls.Add(lnk1);

					LinkButton lnk2 = new LinkButton();
					lnk2.ID = "lnk2_"+strEmployee_Number;
					lnk2.CssClass = "smallsize";
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

		

		private void btnCack_Click(object sender, System.EventArgs e)
		{
			string strURL = Request.Params["returl"];
			if ((Request.Params["samePage"]!=null)&&(Request.Params["samePage"]=="y"))
				Response.Redirect(strURL);
            if ((Request.Params["samePage"] != null) && (Request.Params["samePage"] == "R")) // Telerik window
                lblScript.Text = "<script>closeWindow(1)</script>";
			else
				lblScript.Text="<script>opener.window.location.href='"+strURL+"';window.close()</script>";
		}

	}
}
