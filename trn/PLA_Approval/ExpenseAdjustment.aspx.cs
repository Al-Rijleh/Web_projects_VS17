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
	/// Summary description for ExpenseAdjustment.
	/// </summary>
	public class ExpenseAdjustment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblType1;
		protected System.Web.UI.WebControls.Label lblType2;
		protected System.Web.UI.WebControls.Label lblType4;
		protected System.Web.UI.WebControls.Label lblType5;
		protected System.Web.UI.WebControls.Label lblType6;
		protected System.Web.UI.WebControls.Label lblType7;
		protected System.Web.UI.WebControls.Label lblType8;
		protected System.Web.UI.WebControls.Label lblType9;
		protected System.Web.UI.WebControls.Label lblType3;
		protected System.Web.UI.WebControls.Label lblPaid6a;
		protected System.Web.UI.WebControls.Label lblType010;
		protected System.Web.UI.WebControls.TextBox txtAdjustment1;
		protected System.Web.UI.WebControls.TextBox TextBox9;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.HyperLink HyperLink3;
		protected System.Web.UI.WebControls.HyperLink HyperLink4;
		protected System.Web.UI.WebControls.HyperLink HyperLink7;
		protected System.Web.UI.WebControls.HyperLink HyperLink8;
		protected System.Web.UI.WebControls.HyperLink HyperLink9;
		protected System.Web.UI.WebControls.HyperLink HyperLink10;
		protected System.Web.UI.WebControls.TextBox txtReason1;
		protected System.Web.UI.WebControls.TextBox txtReason2;
		protected System.Web.UI.WebControls.TextBox txtReason3;
		protected System.Web.UI.WebControls.TextBox txtReason4;
		protected System.Web.UI.WebControls.TextBox txtReason5;
		protected System.Web.UI.WebControls.TextBox txtReason6;
		protected System.Web.UI.WebControls.TextBox txtReason7;
		protected System.Web.UI.WebControls.TextBox txtReason9;
		protected System.Web.UI.WebControls.TextBox txtReason10;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink6;
		protected System.Web.UI.WebControls.TextBox textNewAmount1;
		protected System.Web.UI.WebControls.TextBox textNewAmount2;
		protected System.Web.UI.WebControls.TextBox textNewAmount3;
		protected System.Web.UI.WebControls.TextBox textNewAmount4;
		protected System.Web.UI.WebControls.TextBox textNewAmount5;
		protected System.Web.UI.WebControls.TextBox textNewAmount6;
		protected System.Web.UI.WebControls.TextBox textNewAmount7;
		protected System.Web.UI.WebControls.TextBox textNewAmount8;
		protected System.Web.UI.WebControls.TextBox textNewAmount9;
		protected System.Web.UI.WebControls.TextBox textNewAmount110;
		protected System.Web.UI.WebControls.TextBox txtNewAmount2;
		protected System.Web.UI.WebControls.TextBox txtNewAmount3;
		protected System.Web.UI.WebControls.TextBox txtNewAmount4;
		protected System.Web.UI.WebControls.TextBox txtNewAmount5;
		protected System.Web.UI.WebControls.TextBox txtNewAmount6;
		protected System.Web.UI.WebControls.TextBox txtNewAmount7;
		protected System.Web.UI.WebControls.TextBox txtNewAmount8;
		protected System.Web.UI.WebControls.TextBox txtNewAmount9;
		protected System.Web.UI.WebControls.TextBox txtPaid1;
		protected System.Web.UI.WebControls.TextBox txtPaid2;
		protected System.Web.UI.WebControls.TextBox txtPaid3;
		protected System.Web.UI.WebControls.TextBox txtPaid4;
		protected System.Web.UI.WebControls.TextBox txtPaid5;
		protected System.Web.UI.WebControls.TextBox txtPaid6;
		protected System.Web.UI.WebControls.TextBox txtPaid7;
		protected System.Web.UI.WebControls.TextBox txtPaid8;
		protected System.Web.UI.WebControls.TextBox txtPaid9;
		protected System.Web.UI.WebControls.TextBox txtPaid10;
		protected System.Web.UI.WebControls.HyperLink Hyperlink5;
		protected System.Web.UI.WebControls.TextBox txtNewAmount1;
		protected System.Web.UI.WebControls.TextBox txtAdjustment2;
		protected System.Web.UI.WebControls.TextBox txtAdjustment3;
		protected System.Web.UI.WebControls.TextBox txtAdjustment4;
		protected System.Web.UI.WebControls.TextBox txtAdjustment5;
		protected System.Web.UI.WebControls.TextBox txtAdjustment6;
		protected System.Web.UI.WebControls.TextBox txtAdjustment7;
		protected System.Web.UI.WebControls.TextBox txtAdjustment8;
		protected System.Web.UI.WebControls.TextBox Textbox8;
		protected System.Web.UI.WebControls.TextBox Textbox10;
		protected System.Web.UI.WebControls.TextBox txtAdjustment9;
		protected System.Web.UI.WebControls.TextBox txtAdjustment10;
		protected System.Web.UI.WebControls.TextBox txtNewAmount10;
		protected System.Web.UI.WebControls.TextBox txtPaidTotal;
		protected System.Web.UI.WebControls.TextBox txtAdjustmentTotal;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNewAmountTotal;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo1;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo2;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo3;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo4;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo5;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo6;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo7;
		protected System.Web.UI.WebControls.DropDownList DropDownList7;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo8;
		protected System.Web.UI.WebControls.DropDownList DropDownList8;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo9;
		protected System.Web.UI.WebControls.DropDownList DropDownList9;
		protected System.Web.UI.WebControls.LinkButton lnkbtnGo10;
		protected System.Web.UI.WebControls.DropDownList DropDownList10;
		protected System.Web.UI.WebControls.TextBox txtReason8;
		protected System.Web.UI.WebControls.Label lblErrorText;
		protected System.Web.UI.WebControls.Label lblErrorMark;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator4;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator5;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator6;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator7;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator8;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator9;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator10;
		protected System.Web.UI.WebControls.Label lblErrorText2;
		protected System.Web.UI.WebControls.Label lblErrorMark2;
		protected System.Web.UI.WebControls.Label lblError1;
		protected System.Web.UI.WebControls.Label lblError2;
		protected System.Web.UI.WebControls.Label lblError3;
		protected System.Web.UI.WebControls.Label lblError4;
		protected System.Web.UI.WebControls.Label lblError5;
		protected System.Web.UI.WebControls.Label lblError6;
		protected System.Web.UI.WebControls.Label lblError7;
		protected System.Web.UI.WebControls.Label lblError8;
		protected System.Web.UI.WebControls.Label lblError9;
		protected System.Web.UI.WebControls.Label lblError10;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
        protected System.Web.UI.WebControls.Button btnSave;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
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
			lblScript.Text= "";
			if (!IsPostBack)
			{
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);				
				SetHeaderInformation();
				FillData();
				
			}
			lblErrorText.Visible = false;
			lblErrorMark.Visible = false;
			lblErrorText2.Visible = false;
			lblErrorMark2.Visible = false;
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;	
			btnSave.Enabled = false;				
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
			this.lnkbtnGo1.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo2.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo4.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo5.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo6.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo7.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo8.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo9.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.lnkbtnGo10.Click += new System.EventHandler(this.lnkbtnGo1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetHeaderInformation()
		{
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			ViewState["Account_Number"]=PLA_Approval.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			string parPtemplate = PLA_Approval.TrainingClass.SetFullHeader(Page,ViewState["Employee_Number"].ToString());
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
			//ViewState["Account_Number"] = PLA_Approval.TrainingClass.SetHeaderInformation(ViewState["Applicant_Employee_Number"].ToString(),lblEmployeeInfo,lblDivision);
		}

		private void ProcessesStarFunctionality()
		{
			BasStar.StarFunctionality star = new BasStar.StarFunctionality();
			star.ConnStr=PLA_Approval.TrainingClass.ConnectionString;
			star.SetLabel(this,ViewState["Account_Number"].ToString(),"N",ViewState["User_Name"].ToString(),
				Convert.ToInt32(ViewState["User_Group_ID"].ToString()));
			star = null;
		}

		private void SetLabelItem(string strName,string strValue)
		{
			Label lbl = (Label)Page.FindControl(strName);
			lbl.Text = strValue;
			lbl.Visible = true;
		}

		private void SetTextItem(string strName,string strValue)
		{
			TextBox txt = (TextBox)Page.FindControl(strName);
			txt.Text = strValue;
			txt.Visible = true;
		}

		private void MakeTextVisible(string strName)
		{
			TextBox txt = (TextBox)Page.FindControl(strName);
			txt.Visible = true;
		}

		private void MakeHyperLinkVisible(string strName)
		{
			HyperLink hl = (HyperLink)Page.FindControl(strName);
            if (hl != null)
			    hl.Visible = true;
		}

        private void MakeLikButtonWriteVisible(string strName)
        {
            LinkButton lnk = (LinkButton)Page.FindControl(strName);
            lnk.Visible = true;
        }

		private void MakeLikButtonVisible(string strName)
		{
			LinkButton lnk = (LinkButton)Page.FindControl(strName);
			lnk.Visible = true;
		}

		private void MakeDropDownVisible(string strName)
		{
			DropDownList ddl = (DropDownList)Page.FindControl(strName);
			ddl.Visible = true;
		}

		private void MakevalidatorVisible(string strName)
		{
			RequiredFieldValidator val = (RequiredFieldValidator)Page.FindControl(strName);
			val.Visible = true;
		}

		private void MakeRangeValidatorVisible(string strName, string MinAmount)
		{
			RangeValidator val = (RangeValidator)Page.FindControl(strName);
			val.Visible = true;			
			val.MinimumValue = "-"+MinAmount;
		}

		private void FillData()
		{
			DataTable dt = GetExpenseTable();
			int counter =1;
			double TotalPaid = 0;
			foreach (DataRow dr in dt.Rows)
			{
				SetLabelItem("lblType"+counter.ToString(),dr["expense_type"].ToString());
				double dbl=Convert.ToDouble(dr["paid_amount"].ToString());
				TotalPaid = TotalPaid + dbl;
				SetTextItem("txtPaid"+counter.ToString(), dbl.ToString("$#,##0.00"));
				SetTextItem("txtNewAmount"+counter,dbl.ToString("$#,##0.00"));
				SetTextItem("txtAdjustment"+counter.ToString(),"0");
				MakeTextVisible("txtAdjustment"+counter);
				MakeTextVisible("txtReason"+counter);
				MakeHyperLinkVisible("HyperLink"+counter);
                MakeLikButtonWriteVisible("lnkbtnWriter" + counter);
				MakeLikButtonVisible("lnkbtnGo"+counter);
				MakeDropDownVisible("DropDownList"+counter);
				MakeRangeValidatorVisible("RangeValidator"+counter, dr["paid_amount"].ToString());
				txtAdjustmentTotal.Text = "$0.00";
				txtPaidTotal.Text = TotalPaid.ToString("$#,##0.00");
				txtNewAmountTotal.Text = txtPaidTotal.Text;
				ViewState["Record_id_"+counter.ToString()] = dr["record_id"].ToString();
				counter ++;
			}
		}
		private DataTable GetExpenseTable()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetEmployeeExpenses",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Expenses_List_","cursor","out","");

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

		private void SaveOne(Oracle.DataAccess.Client.OracleConnection conn, int intId)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.saveadjustment",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			TextBox txtAdjust = (TextBox)Page.FindControl("txtAdjustment"+intId.ToString());
			TextBox txtReason = (TextBox)Page.FindControl("txtReason"+intId.ToString());
			try
			{
				
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_",ViewState["Record_id_"+intId.ToString()].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"adjustment_amount_",txtAdjust.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"reason_",txtReason.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_",ViewState["User_Name"].ToString());
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();				
			}
		}

		private void DoSave()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			conn.Open();
			Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
			try
			{
				for (int i=1;i<11;i++)
				{
					if (ViewState["Record_id_"+i.ToString()] != null)
						SaveOne(conn,i);
				}
                txn.Commit();
			}
			catch
			{
				txn.Rollback();
				throw;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		private bool MissingReason()
		{
			TextBox txtAdjust;
			TextBox txtReason;
			bool blnResult = false;
			for (int i=1;i<11;i++)
			{
				if (ViewState["Record_id_"+i.ToString()] != null)
				{
					txtAdjust = (TextBox)Page.FindControl("txtAdjustment"+i.ToString());
					txtReason = (TextBox)Page.FindControl("txtReason"+i.ToString());					
					if ((txtAdjust.Text != "0")&&(txtReason.Text==""))
					{
						Label lbl = (Label)Page.FindControl("lblError"+i.ToString());
						lbl.Visible = true;
						blnResult = true;
					}

				}
			}
			return blnResult;
		}


		private void lnkbtnGo1_Click(object sender, System.EventArgs e)
		{
			LinkButton lnk = (LinkButton)sender;
			string strID = lnk.ID.Replace("lnkbtnGo","");
			string strRecordId = ViewState["Record_id_"+strID].ToString();
			Label lbl = (Label)Page.FindControl("lblType"+strID);
			Response.Redirect("AdjutmentHistory.aspx?recid="+strRecordId+"&type="+lbl.Text);
		}

        protected void lnkbtnWriter_Click(object sender, EventArgs e)
        {
            string strLinkID = ((LinkButton)sender).ID.Replace("lnkbtnWriter","");
            strLinkID = "txtReason" + strLinkID;
            TextBox txtReason = (TextBox)Page.FindControl(strLinkID);
            if (txtReason.TextMode == TextBoxMode.MultiLine)
            {
                ((LinkButton)sender).Text = "Writer";
                txtReason.Width = System.Web.UI.WebControls.Unit.Percentage(90);
                string strText = txtReason.Text;
                txtReason.TextMode = TextBoxMode.SingleLine;
                txtReason.Text = strText;
                txtReason.Height = System.Web.UI.WebControls.Unit.Pixel(18);
            }
            else
            {
                ((LinkButton)sender).Text = "Done";
                txtReason.Width = System.Web.UI.WebControls.Unit.Pixel(300);
                txtReason.TextMode = TextBoxMode.MultiLine;
                txtReason.Height = System.Web.UI.WebControls.Unit.Pixel(100);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((!IsValid) || (MissingReason()))
            {
                lblScript.Text = BASUSA.MiscTidBit.JSAlert("Reason For Adjustment must be filled\\nAdjustment Amount must be a number and does not cause the paid amount to be less than zero");
                lblErrorText.Visible = true;
                lblErrorMark.Visible = true;
                lblErrorText2.Visible = true;
                lblErrorMark2.Visible = true;
                return;
            }
            DoSave();
			Response.Redirect("System_Adjust_Paid_Request.aspx?SkipCheck=YES"); // 4/10/2008
			//if ((Request.Params["call"] == null) || (Request.Params["call"] == ""))	// 4/10/2008
			//    lblScript.Text = "<script>location.href='PayorPendingApprovals.aspx?SkipCheck=YES'</script>";	// 4/10/2008
			//else	// 4/10/2008
			//    lblScript.Text = "<script>location.href='" + BASUSA.MiscTidBit.CheckForSkipCheck(Request.Params["call"]) + "'</script>";	// 4/10/2008
				
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
			Response.Redirect("System_Adjust_Paid_Request.aspx?SkipCheck=YES"); // 4/10/2008
			//if ((Request.Params["call"] != null) && (Request.Params["call"] != ""))	// 4/10/2008
			//    Response.Redirect(BASUSA.MiscTidBit.CheckForSkipCheck(Request.Params["call"]));	// 4/10/2008
			//Response.Redirect("PayorPendingApprovals.aspx?SkipCheck=YES");	// 4/10/2008
        }

	
					 

	}
}
