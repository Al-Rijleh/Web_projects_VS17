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
using System.Text;

namespace PLA_Source
{
	/// <summary>
	/// Summary description for ReviewEval.
	/// </summary>
	public class ReviewEval : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.DataGrid dgQA;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label lblEndDate;
		protected System.Web.UI.WebControls.Label lblStartDate;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblTitleCourse;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblOffice;
		protected System.Web.UI.WebControls.Label lblPhone;
		protected System.Web.UI.WebControls.Label lblSSN;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.LinkButton lnkbtnAcknowledge ;
		protected System.Web.UI.WebControls.LinkButton lnkbtnBack;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.WebControls.Image imgOther;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Image imgPLA;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.ListBox lbAnweres;
        protected System.Web.UI.WebControls.TextBox txtComments;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			#region BasTemplate
			if (!IsPostBack)
			{	
				//				if ((Request.Params["SkipCheck"] == null) || (Request.Params["SkipCheck"] != "YES"))
				//				{
				//					SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"main_run",Request.Path+"?SkipCheck=YES",Training_Source.TrainingClass.ConnectioString);
				//					Response.Redirect("/web_projects/PTemplate/index.htm");
				//					return;
				//				}
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
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
			}
			lbAnweres.Width=System.Web.UI.WebControls.Unit.Pixel(1);
			lbAnweres.Height=System.Web.UI.WebControls.Unit.Pixel(1);
			lbAnweres.ForeColor = System.Drawing.Color.White;
			lbAnweres.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
			
			ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);			
			string strAccessType = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Acknowledge",Training_Source.TrainingClass.ConnectioString);
			lnkbtnAcknowledge.Visible = strAccessType=="true";
			SQLStatic.Sessions.SetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Acknowledge","",Training_Source.TrainingClass.ConnectioString);
			FillHeader();
			GetCDAnswerList();
			DrawGrid();
			if (Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				lnkbtnAcknowledge.Enabled=false;
			SetHeaderInformation();
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
			this.dgQA.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgQA_ItemCreated);
			this.lnkbtnBack.Click += new System.EventHandler(this.lnkbtnBack_Click);
			this.lnkbtnAcknowledge.Click += new System.EventHandler(this.lnkbtnAcknowledge_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			string parPtemplate = Training_Source.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private void FillHeader()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.get_evaluation_record",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "eval_record","cursor","out","");
			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				lblName.Text = tbl.Rows[0]["employee_name"].ToString();
				lblSSN.Text = tbl.Rows[0]["employee_ssn_last_4_digits"].ToString();
				lblPhone.Text = tbl.Rows[0]["phone_number"].ToString();
				lblOffice.Text = tbl.Rows[0]["division_office_location"].ToString();
				lblTitleCourse.Text = tbl.Rows[0]["title_of_course"].ToString();
				lblStartDate.Text = tbl.Rows[0]["start_date"].ToString();
				lblEndDate.Text = tbl.Rows[0]["completed_date"].ToString();
                txtComments.Text = tbl.Rows[0]["comments"].ToString(); 
				if (tbl.Rows[0]["type_of_trainig"].ToString()=="5632")
				{
					imgPLA.ImageUrl="img/completed.JPG";
					imgOther.ImageUrl = "img/incomplete.JPG";
				}
				else
				{
					imgPLA.ImageUrl="img/incomplete.JPG";
					imgOther.ImageUrl = "img/completed.JPG";
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();				
			}
		}

		private void GetCDAnswerList()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.get_evaluation_cd_answr",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "questions_list_","cursor","out","");
			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];	
				foreach(DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["answer"].ToString(),dr["record_id"].ToString());
					lbAnweres.Items.Add(li);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();	
				if (tbl != null)
					tbl.Dispose();
			}			
		}

		private DataTable GetDataTable()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.get_evaluation_ansers",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "eval_answer","cursor","out","");
			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl;
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
			DataTable tbl=GetDataTable();
			dgQA.DataSource = tbl;
			dgQA.DataBind();
		}

		private void dgQA_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgQA.DataSource;
					string strindex = tbl.Rows[indx]["record_id"].ToString();
					string strAnswer = tbl.Rows[indx]["answer"].ToString();
					StringBuilder sbText = new StringBuilder(lbAnweres.Items.Count);
//					foreach (ListItem li in lbAnweres.Items)
//					{
//						if (li.Text == strAnswer)
//							sbText.Append("<span style='font-family: Wingdings; color: red'>è</span><font color='#FF0000'>"+li.Text+"</font>");
//						else
//							sbText.Append("&nbsp;&nbsp;&nbsp;<font color='#a9a9a9'>"+li.Text+"</font>");
//					}
					foreach (ListItem li in lbAnweres.Items)
					{
						if (li.Text == strAnswer)
							sbText.Append("&nbsp;&nbsp;&nbsp;"+li.Text);
						else
							sbText.Append("&nbsp;&nbsp;&nbsp;<font color='#a9a9a9'>"+li.Text+"</font>");
					}
					Label lbl = new Label();
					lbl.ID = "lbl_"+strindex;
					lbl.Text = sbText.ToString();
					lbl.CssClass = "fontsmall";
					
					TableCell cell = e.Item.Cells[2];
					cell.Controls.Add(lbl);					
				}
				catch
				{
				}
			}
		}

		private bool DoSave()
		{
			bool IsOk=true;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.AcknowledgeEvaluation",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "user_name_",ViewState["User_Name"].ToString());
			
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();				
			}
			finally
			{
				cmd.Dispose();
				conn.Close();
				conn.Dispose();				
			}
			return IsOk;
		}

		private void lnkbtnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(Request.Params["call"]);
		}

		private void lnkbtnAcknowledge_Click(object sender, System.EventArgs e)
		{
			if (DoSave())
				lblScript.Text = "<script>alert('Your acknowledgement was saved');window.location.href='"+Request.Params["call"]+"';</script>";
		}

	}
}
