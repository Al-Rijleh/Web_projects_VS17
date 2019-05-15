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
	/// Summary description for TrainingSummary.
	/// </summary>
	public class TrainingSummary : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LblTemplateHeader;
		protected System.Web.UI.WebControls.Label LblTemplateFooter;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtCourseCode;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCourseTitle;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.TextBox txtDescribtion;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.DropDownList ddlTrainingType;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.RadioButtonList optMandatoryTraining;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTainingOther;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.RadioButtonList optCoursrTime;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursDuty;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursNonDuty;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursTotal;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.LinkButton lnkbtnBack;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			#region MyEnroll Template
			try
			{
				if(!this.IsPostBack)
				{
					if(!(Request.Cookies["Session_ID"]!=null))
						Response.Redirect("/Web_Projects/login/default.aspx",false);
					MyEnroll_Template.Cls_MyEnroll_Template ObjTemplate = new MyEnroll_Template.Cls_MyEnroll_Template(Request.Cookies["Session_ID"].Value.ToString(),Request.Url.Authority.ToString(),Request.Url.AbsolutePath.ToString(),Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ClientLogoID"]));
					if (ObjTemplate.RedirectResponse)
						Response.Redirect(ObjTemplate.Header,false);
					else
						this.LblTemplateHeader.Text = ObjTemplate.Header;
					this.LblTemplateFooter.Text = ObjTemplate.Footer;
					ViewState["AccessType"] = ObjTemplate.AccessType.ToString();
					ViewState["Employee_Number"] = ObjTemplate.Employee_Number.ToString();
					ViewState["Processing_Year"] = ObjTemplate.Processing_Year.ToString();
					ViewState["Role_Restriction_Level"] = ObjTemplate.Role_Restriction_Level.ToString();
					ViewState["Selected_Account_Number"] = ObjTemplate.Selected_Account_Number.ToString();
					ViewState["Selected_Employee_Class_Code"] = ObjTemplate.Selected_Employee_Class_Code.ToString();
					ViewState["User_Group_ID"] = ObjTemplate.User_Group_ID.ToString();
					ViewState["User_ID"] = ObjTemplate.User_ID.ToString();
					ViewState["User_Name"] = ObjTemplate.User_Name.ToString();
					ViewState["User_Primary_Role"] = ObjTemplate.User_Primary_Role.ToString();
					ObjTemplate=null;
				}
			}
			catch
			{
				Response.Redirect("/Web_Projects/login/default.aspx",false);
			}
			#endregion
			if (!IsPostBack)
			{
				if (ViewState["User_Group_ID"].ToString()!="1")
				{
					string strMesg = Training_Source.TrainingClass.IsEeDataOk(ViewState["Employee_Number"].ToString());
					if (strMesg!="")
						Response.Redirect("out.aspx?message="+strMesg,true);
				}
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				SetHeaderInformation();
				FillSatesDropDown();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Request_Record_ID",System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
				ViewState["Product_Code"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Product_Code",System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
				FillData();
				FillDataDateTimes();
				FillDropDowns();
				FillDataTypesNeeds();
				DrawGrid();
				SetInView();
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
			this.dgExpense.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgExpense_ItemCreated);
			this.lnkbtnBack.Click += new System.EventHandler(this.lnkbtnBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SetInView()
		{			
			txtCourseCode.Enabled =false;
			txtCourseTitle.Enabled=false;
			txtVedorName.Enabled = false;
			txtPhoneNumber.Enabled=false;
			txtFaxNumber.Enabled=false;
			txtAddressLine1.Enabled=false;
			txtAddressLine2.Enabled=false;
			txtCity.Enabled=false;
			ddlStates.Enabled=false;
			txtZipCode.Enabled=false;
			txtDescribtion.Enabled=false;
			txtWebSite.Enabled=false;
			txtStartDate.Enabled=false;
			txtEndDate.Enabled=false;
			optCoursrTime.Enabled=false;
			txtCourseHoursDuty.Enabled=false;
			txtCourseHoursNonDuty.Enabled=false;
			ddlTrainingType.Enabled=false;
			optMandatoryTraining.Enabled=false;
			ddlSourseTraining.Enabled=false;
			ddlPurposeOfTraining.Enabled=false;
			txtPurposeOfTainingOther.Enabled = false;			
		}

		private void SetHeaderInformation()
		{
			DataTable tbl=null;
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(ViewState["Employee_Number"].ToString(),
					System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
				lblEmployeeInfo.Text = "<B>"+BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString())+
					"</B> - MyEnroll#: "+ViewState["Employee_Number"].ToString()+" SS#: "+BASUSA.MiscTidBit.MaskSSN(tbl.Rows[0]["social_security_number"].ToString())+
					" Tel: "+BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
				lblDivision.Text = tbl.Rows[0]["account_number"].ToString()+" - "+tbl.Rows[0]["account_name"].ToString();
				lblCourseTitle.Text = "     -";
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
		}	

		private void FillSatesDropDown()
		{
			DataTable dtStates = SQLStatic.CD_Tables.States(System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
			try
			{
				foreach (DataRow dr in dtStates.Rows)
				{
					ListItem li = new ListItem(dr["state_description"].ToString(),dr["state"].ToString());
					ddlStates.Items.Add(li);
				}
			}
			finally
			{
				if (dtStates != null)
					dtStates.Dispose();
			}
		}
		private void FillOneDropDown(DropDownList ddl,string strTableName)
		{
			
			ddl.Items.Clear();
			ddl.Items.Add(new ListItem("---- Select ----","xx"));
			string strSQL="select record_id,description from "+strTableName;
			CoreLab.Oracle.OracleConnection conn = 	new CoreLab.Oracle.OracleConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
			CoreLab.Oracle.OracleCommand cmd = new CoreLab.Oracle.OracleCommand(strSQL,conn);
			conn.Open();			
			CoreLab.Oracle.OracleDataReader reader =null;
			try
			{
				reader = cmd.ExecuteReader();
				
				while (reader.Read())
				{
					ListItem li = new ListItem(reader.GetString(1),reader.GetString(0));
					ddl.Items.Add(li);
				}
			}
			finally
			{
				reader.Dispose();
				cmd.Dispose();
				conn.Dispose();
			}
		}

		private void FillDropDowns()
		{
			FillOneDropDown(ddlTrainingType,"cd_training_training_type ");
			FillOneDropDown(ddlSourseTraining,"cd_training_source ");
			FillOneDropDown(ddlPurposeOfTraining,"cd_training_purpose ");
		}

		private void SetDropDownIndex(DropDownList ddl,string strValue)
		{
			for (int i=0; i<ddl.Items.Count;i++)
				if (ddl.Items[i].Value==strValue)
				{
					ddl.SelectedIndex = i;
					break;
				}
		}

		private void FillData()
		{
			if (ViewState["Request_Record_ID"].ToString()=="-1")
			{
				txtCourseCode.Text = "";
				txtCourseTitle.Text = "";
				txtVedorName.Text = "";
				txtPhoneNumber.Text = "";
				txtFaxNumber.Text = "";
				txtAddressLine1.Text = "";
				txtAddressLine2.Text = "";
				txtCity.Text = "";
				ddlStates.SelectedIndex = 0;
				txtZipCode.Text = "";
				txtWebSite.Text = "";
				txtDescribtion.Text = "";
				return;
			}
			CoreLab.Oracle.OracleConnection conn = new CoreLab.Oracle.OracleConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
			CoreLab.Oracle.OracleCommand cmd = new CoreLab.Oracle.OracleCommand("BASDBA.PKG_Training.GetHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			CoreLab.Oracle.OracleDataAdapter da = new CoreLab.Oracle.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				txtCourseCode.Text = tbl.Rows[0]["course_code"].ToString();
				txtCourseTitle.Text = tbl.Rows[0]["course_title"].ToString();
				txtVedorName.Text = tbl.Rows[0]["vendor_name"].ToString();
				txtPhoneNumber.Text = tbl.Rows[0]["vendor_phone_number"].ToString();
				txtFaxNumber.Text = tbl.Rows[0]["vendor_fax_number"].ToString();
				txtAddressLine1.Text = tbl.Rows[0]["vendor_address1"].ToString();
				txtAddressLine2.Text = tbl.Rows[0]["vendor_address2"].ToString();
				txtCity.Text = tbl.Rows[0]["vendor_city"].ToString();
				string strState = tbl.Rows[0]["vendor_state"].ToString();
				txtZipCode.Text = tbl.Rows[0]["vendor_zip_code"].ToString();
				txtWebSite.Text = tbl.Rows[0]["vendor_website"].ToString();
				txtDescribtion.Text = tbl.Rows[0]["desription_of_course_value"].ToString();
				ViewState["application_status"]= tbl.Rows[0]["application_status"].ToString();
				ViewState["description"]=tbl.Rows[0]["description"].ToString();
				for (int i=0;i<ddlStates.Items.Count;i++)
					if (ddlStates.Items[i].Value==strState)
					{
						ddlStates.SelectedIndex = i;
						break;
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
			
			lblCourseTitle.Text= txtCourseCode.Text+" - "+txtCourseTitle.Text;
		}

		private void FillDataDateTimes()
		{
			
			CoreLab.Oracle.OracleConnection conn = new CoreLab.Oracle.OracleConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
			CoreLab.Oracle.OracleCommand cmd = new CoreLab.Oracle.OracleCommand("BASDBA.PKG_Training.gettrainingcoursedatetimerec",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_3_record","cursor","out","");

			DataSet mds = new DataSet();
			CoreLab.Oracle.OracleDataAdapter da = new CoreLab.Oracle.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				if (tbl.Rows.Count!=0)
				{
					txtStartDate.Text = tbl.Rows[0]["course_start_date"].ToString();
					txtEndDate.Text = tbl.Rows[0]["course_end_date"].ToString();
					string strCourseTime = tbl.Rows[0]["course_time"].ToString();
					txtCourseHoursDuty.Text = tbl.Rows[0]["course_hours_duty"].ToString();
					txtCourseHoursNonDuty.Text = tbl.Rows[0]["course_hours_non_duty"].ToString();
					txtCourseHoursTotal.Text = tbl.Rows[0]["course_hours_total"].ToString();
					for (int i=0;i<optCoursrTime.Items.Count;i++)
						if (optCoursrTime.Items[i].Value==strCourseTime)
						{
							optCoursrTime.SelectedIndex = i;
							break;
						}
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

		private void FillDataTypesNeeds()
		{
			
			CoreLab.Oracle.OracleConnection conn = new CoreLab.Oracle.OracleConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
			CoreLab.Oracle.OracleCommand cmd = new CoreLab.Oracle.OracleCommand("BASDBA.PKG_Training.TrainingTypesNeedsRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Step_4_record","cursor","out","");

			DataSet mds = new DataSet();
			CoreLab.Oracle.OracleDataAdapter da = new CoreLab.Oracle.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				if (tbl.Rows.Count!=0)
				{
					SetDropDownIndex(ddlTrainingType, tbl.Rows[0]["training_type"].ToString());
					optMandatoryTraining.SelectedIndex = tbl.Rows[0]["mandatory_training"].ToString()=="T" ? 0 : 1;
					SetDropDownIndex(ddlSourseTraining, tbl.Rows[0]["source_of_training"].ToString());
					SetDropDownIndex(ddlPurposeOfTraining, tbl.Rows[0]["purpose_of_training"].ToString());
					txtPurposeOfTainingOther.Text = tbl.Rows[0]["purpose_of_training_other"].ToString();
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

		private DataTable GetExpenseTable()
		{
			DataTable tbl=null;
			CoreLab.Oracle.OracleConnection conn = new CoreLab.Oracle.OracleConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]);
			CoreLab.Oracle.OracleCommand cmd = new CoreLab.Oracle.OracleCommand("BASDBA.pkg_training.GetEmployeeExpenses",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Expenses_List_","cursor","out","");

			DataSet mds = new DataSet();
			CoreLab.Oracle.OracleDataAdapter da = new CoreLab.Oracle.OracleDataAdapter(cmd);
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

		private string GetTotalExpense()
		{
			string strSQL="select pkg_training.calctotalrequestexpense("+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,System.Configuration.ConfigurationSettings.AppSettings["Connstr"]).ToString();
			if (strResult=="")
				strResult = "0";
			return Convert.ToDouble(strResult).ToString("$#,###.00");
		}

		private void DrawGrid()
		{
			DataTable dt= GetExpenseTable();
			dgExpense.DataSource = dt;
			dgExpense.DataBind();
			lblAmount.Text = GetTotalExpense();
		}

		private void dgExpense_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType==ListItemType.Item)||
				(e.Item.ItemType==ListItemType.AlternatingItem)||
				(e.Item.ItemType==ListItemType.SelectedItem))
			{
				try
				{
					int indx = e.Item.ItemIndex;
					DataTable tbl = (DataTable) dgExpense.DataSource;
					string strindex = tbl.Rows[indx]["record_id"].ToString();

					Label lbl = new Label();
					lbl.ID="lbl_"+strindex;
					lbl.Width = System.Web.UI.WebControls.Unit.Percentage(90);
					if (tbl.Rows[indx]["note"].ToString().Length > 80)
						lbl.Text= tbl.Rows[indx]["note"].ToString().Substring(0,80);
					else
						lbl.Text=tbl.Rows[indx]["note"].ToString();
					
					TableCell cell2 = e.Item.Cells[2];
					cell2.Controls.Add(lbl);
				}
				catch
				{
				}
			}
		}

		private void lnkbtnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SelectApp.aspx");
		}
	}
}
