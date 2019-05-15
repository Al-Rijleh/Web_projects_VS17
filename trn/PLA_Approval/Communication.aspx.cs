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
	/// Summary description for Communication.
	/// </summary>
	public class Communication : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid dgComm;
		protected System.Web.UI.WebControls.LinkButton lmkbtnRespond;
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.LinkButton lnkbtnBack;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label LblTemplateFooter;
		protected System.Web.UI.WebControls.Label lbl_fldPla_Approval_Communication_Module;
		protected System.Web.UI.WebControls.Label lblCourseName;
		protected System.Web.UI.WebControls.Label lbl_fldPla_Approval_Communication_ModuleCDP;
		protected System.Web.UI.WebControls.Label LblTemplateHeader1;
		protected Karamasoft.WebControls.UltimateMenu um;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected Karamasoft.WebControls.UltimatePanel upPO;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblError.Text = "";
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
				ViewState["From_Who"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"From_Who",PLA_Approval.TrainingClass.ConnectionString);
				if (ViewState["User_Group_ID"].ToString()!="1")
				{
					if (ViewState["From_Who"].ToString() != "CDP")
					{
						string strMesg;
						if (ViewState["From_Who"].ToString()=="Payor")
							strMesg = PLA_Approval.TrainingClass.IsPayorDataOk(ViewState["Employee_Number"].ToString());
						else
							strMesg = PLA_Approval.TrainingClass.IsSprvsrDataOk(ViewState["Employee_Number"].ToString());
						if (strMesg!="")
							Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message="+strMesg,true);
					}
				}
				ViewState["Employee_Number"]= PLA_Approval.TrainingClass.UsedEmployeeNumber(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				SetHeaderInformation();	
				ProcessesStarFunctionality();
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
			this.dgComm.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgComm_ItemCreated);
			this.lmkbtnRespond.Click += new System.EventHandler(this.lmkbtnRespond_Click);
			this.lnkbtnBack.Click += new System.EventHandler(this.lnkbtnBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
			if (ViewState["Product_Code"].ToString()=="11001")
			{
				lblCourseName.Text = "Application For";
				lblCourseTitle.Text = "Career Development Plan";
				lbl_fldPla_Approval_Communication_ModuleCDP.Visible = true;
				lbl_fldPla_Approval_Communication_Module.Visible = false;
			}
			else
			{
				lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
				lbl_fldPla_Approval_Communication_ModuleCDP.Visible = false;
				lbl_fldPla_Approval_Communication_Module.Visible = true;
			}
			ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Applicant_Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}
	
		private  DataTable GetGridTable()
		{
			string strProcedureName = "BASDBA.pkg_training.CommunicationList";
			if (ViewState["Product_Code"].ToString()=="11001")
				strProcedureName = "BASDBA.pkg_training_cdp.CommunicationList";
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",-1);			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "msg_list","cursor","out","");

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
			DataTable dt = GetGridTable();
			if (dt.Rows.Count==0)
			{
				lblError.Text = "There are no messages for this request.";
			}
			else
			{
				dgComm.DataSource=dt;
				dgComm.DataBind();
				
			}
		}

		
		private void lnkMenu_Click(object sender, System.EventArgs e)
		{
			string strIndex = ((LinkButton)sender).ID.Substring(4);
			
			DataTable tbl = (DataTable) dgComm.DataSource;			
			int intGridIndex=0;
			foreach (DataRow dr in tbl.Rows)
			{
				if (dr["record_id"].ToString()==strIndex)
				{
					txtMessage.Text = dr["memo_body"].ToString();
					ViewState["from_employee_number"]=dr["from_employee_number"].ToString();
					ViewState["to_employee_number"]=dr["to_employee_number"].ToString();
					ViewState["comm_record_id"]=strIndex;
					break;
				}
				intGridIndex ++;
			}
			dgComm.SelectedIndex = intGridIndex;
			lmkbtnRespond.Enabled=true;
		}

		private void lnkbtnBack_Click(object sender, System.EventArgs e)
		{
//			if (ViewState["Product_Code"].ToString()=="11001")
//				lblScript.Text = "<script>window.location.href='/Web_Projects/trn/FDIC_CDP/main.aspx'</script>";
//			else
				Response.Redirect(Request.Params["w"]+".aspx?SkipCheck=YES",true);
		}

		private void lmkbtnRespond_Click(object sender, System.EventArgs e)
		{
			string streeno = ViewState["from_employee_number"].ToString();
			string streenofrom = ViewState["to_employee_number"].ToString();
			string strindx = ViewState["comm_record_id"].ToString();
			lblScript.Text="<script>popup('SenMessage.aspx?to="+streeno+ "&from="+streenofrom+"&indx="+strindx+
				"+&w="+Request.Params["w"]+"',500,700)</script>";
		}

		private void dgComm_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgComm.DataSource;
					string strRecordId = tbl.Rows[indx]["record_id"].ToString();	
					
					LinkButton lnk=new LinkButton();
					lnk.ID="lnk_"+strRecordId;
					lnk.Text="<B>"+tbl.Rows[indx]["subject"].ToString()+"</B>";
					lnk.CssClass = "smallsize";
					lnk.Click += new System.EventHandler(this.lnkMenu_Click);

					Label lbl = new Label();
					lbl.ID = "lbl_"+strRecordId;
					lbl.Text = "<BR>From: " +tbl.Rows[indx]["from_person"].ToString()+
						"<BR>To: " +tbl.Rows[indx]["To_person"].ToString()+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+tbl.Rows[indx]["Add_Date_Time"].ToString();
					lbl.Font.Size = System.Web.UI.WebControls.FontUnit.XXSmall;
//					lbl.CssClass = "smallsize";
					

					TableCell cell = e.Item.Cells[0];
					cell.Controls.Add(lnk);
					cell.Controls.Add(lbl);
				}
				catch{}
			}
		}
	}
}
