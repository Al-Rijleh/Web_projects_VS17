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
	/// Summary description for AddEditExpense.
	/// </summary>
	public class AddEditExpense : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblScript;
		protected System.Web.UI.WebControls.Label lblExpenseType;
		protected System.Web.UI.WebControls.DropDownList ddlExpenseType;
		protected System.Web.UI.WebControls.Label lblExpenseName;
		protected System.Web.UI.WebControls.TextBox txtExpenseName;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtVendorContact;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;

		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtRemaining;
		protected System.Web.UI.WebControls.TextBox txtemail;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCancel;
		protected System.Web.UI.WebControls.LinkButton lnkbtnSaveAndStay;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtApprovedAmount;
		protected System.Web.UI.WebControls.TextBox txtPaidAmount;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label lblApprovedAmount;
		protected System.Web.UI.WebControls.Label lblPaidAmount;
		protected System.Web.UI.WebControls.TextBox txtExpenseType;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.Label lblCountry;
		protected System.Web.UI.WebControls.DropDownList ddlContries;
		protected System.Web.UI.WebControls.Label lblCityState;
		protected System.Web.UI.WebControls.TextBox txtProvince;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (PLA_Approval.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text ="";
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
			if (!IsPostBack)
			{
                Template.BASPtemplate.SetHeaderPageNameByURL(Page, Request.Path);
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",PLA_Approval.TrainingClass.ConnectionString);
				ViewState["Applicant_Employee_Number"]=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"Applicant_Employee_Number",PLA_Approval.TrainingClass.ConnectionString);
				SetHeaderInformation();	
				FillExpenseType();
                FillSatesDropDown();
				FillContries();
				if (Request.Params["expid"] != "-1")
					GetExistingData();	
				txtExpenseType.Text = ddlExpenseType.SelectedItem.Text;
				txtState.Text = ddlStates.SelectedItem.Text;
			}
			HandleContractors();
		}

		private void HandleContractors()
		{
			if (!PLA_Approval.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			//PLA_Approval.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());	
			
			txtPaidAmount.Enabled = false;
			txtApprovedAmount.Enabled = false;
			lnkbtnSaveAndStay.Enabled = false;
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
			this.ddlExpenseType.SelectedIndexChanged += new System.EventHandler(this.ddlExpenseType_SelectedIndexChanged);
			this.lnkbtnSaveAndStay.Click += new System.EventHandler(this.lnkbtnSaveAndStay_Click);
			this.lnkbtnCancel.Click += new System.EventHandler(this.lnkbtnCancel_Click);
			
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void FillContries()
		{
			DataTable dtCounty = SQLStatic.CD_Tables.Countries();
			foreach (DataRow dr in dtCounty.Rows)
			{
				ListItem li = new ListItem(dr["name"].ToString(), dr["code"].ToString());
				ddlContries.Items.Add(li);
			}
		}

		private void FillSatesDropDown()
		{
			DataTable dtStates = SQLStatic.CD_Tables.States(PLA_Approval.TrainingClass.ConnectionString);
			try
			{
				ListItem li0 = new ListItem("--Select--"," ");
				ddlStates.Items.Add(li0);
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

		private void SetHeaderInformation()
		{	
			lblCourseTitle.Text = PLA_Approval.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
		}

		private void GetExistingData()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetExpenseList",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",Request.Params["expid"]);			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "expenses_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				foreach (DataRow dr in tbl.Rows)
				{
					txtExpenseName.Text = dr["expense_type"].ToString();
					lblAmount.Text= Convert.ToDouble(dr["amount"].ToString()).ToString("$#,##0.00");
					lblApprovedAmount.Text= Convert.ToDouble(dr["approved_amount"].ToString()).ToString("$#,##0.00");
					lblPaidAmount.Text= Convert.ToDouble(dr["Paid_amount"].ToString()).ToString("$#,##0.00");
					
					if (Request.Params["w"]=="s")
					{
						txtApprovedAmount.Text= dr["approved_amount"].ToString();
						txtApprovedAmount.Visible = true;
						lblApprovedAmount.Visible = false;
					}
					else
					{
						txtPaidAmount.Text= dr["approved_amount"].ToString();
						txtPaidAmount.Visible = true;
						lblPaidAmount.Visible = false;
					}

					txtDescription.Text = dr["note"].ToString();
					ListItem li0 = new ListItem("--Select--"," ");				
					ddlExpenseType.Items.Add(li0);
					if (dr["expense_type_ID"].ToString() != "1000")
					{
						ListItem li = new ListItem(txtExpenseName.Text,dr["expense_type_ID"].ToString());				
						ddlExpenseType.Items.Add(li);						
					}
					for (int i=0;i<ddlExpenseType.Items.Count;i++)
						if (ddlExpenseType.Items[i].Value == dr["expense_type_ID"].ToString())
						{
							ddlExpenseType.SelectedIndex=i;
							break;
						}
					txtVedorName.Text = dr["vendor_name"].ToString();
					txtVendorContact.Text = dr["vendor_contact_name"].ToString();
					txtAddressLine1.Text = dr["vendor_address_1"].ToString();
					txtAddressLine2.Text = dr["vendor_address2"].ToString();
					txtCity.Text = dr["vendor_city"].ToString();
					string strState = dr["vendor_state"].ToString();
					txtZipCode.Text = dr["vendor_zip"].ToString();
					txtPhoneNumber.Text = dr["vendor_phone"].ToString();
					txtFaxNumber.Text = dr["vendor_fax"].ToString();
					txtemail.Text = dr["vendor_email"].ToString();
					txtProvince.Text = dr["province"].ToString();
					string strCountry = dr["country_code"].ToString();

					foreach (ListItem li in ddlContries.Items)
					{
						li.Selected = li.Value == strCountry;
					}

					for (int i=0;i<ddlStates.Items.Count;i++)
						if (ddlStates.Items[i].Value==strState)
						{
							ddlStates.SelectedIndex=i;
							break;
						}
					ddlExpenseType_SelectedIndexChanged(null,null);
					txtExpenseName.Text = dr["expense_type"].ToString();
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				tbl.Dispose();
			}
			setCountryFields();
		}

		protected void setCountryFields()
		{
			if (ddlContries.SelectedValue != "US")
			{
				txtPhoneNumber.MaxLength = 30;
				txtFaxNumber.MaxLength = 30;
				lblCityState.Text = "City/Province";
				txtProvince.Visible = true;
				ddlStates.Visible = false;				
				txtZipCode.Visible = false;
				txtState.Visible = false;
				
			}
			else
			{
				txtPhoneNumber.MaxLength = 14;
				txtFaxNumber.MaxLength = 14;
				lblCityState.Text = "City/Province";
				txtProvince.Visible = false;
				ddlStates.Visible = true;				
				txtZipCode.Visible = true;
				txtState.Visible = true;
			}
		}

		private void FillExpenseType()
		{			
			ddlExpenseType.Items.Clear();
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetExpenseTypes",conn);
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
				foreach (DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["description"].ToString(),dr["record_id"].ToString());
					ddlExpenseType.Items.Add(li);
				}
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				mds.Dispose();
				tbl.Dispose();
			}		
		}

		private void ddlExpenseType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblExpenseName.Visible=false;
			txtExpenseName.Visible=false;;
			if (ddlExpenseType.SelectedValue=="1000")
			{
				txtExpenseName.Text = "";
				lblExpenseName.Visible=true;
				txtExpenseName.Visible=true;
			}
			else
			{
				txtExpenseName.Text = ddlExpenseType.SelectedItem.Text;
			}
		}



		private void SaveOne()
		{
            Validate();
            if (!IsValid)
                return;
			string strIs_approved_amount;
			string strValue;
			if (Request.Params["w"]=="s")
			{
				strIs_approved_amount = "1";
				strValue = txtApprovedAmount.Text;
			}
			else
			{
				strIs_approved_amount = "0";
				strValue = txtPaidAmount.Text;
			}
					Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);			
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(
				"basdba.pkg_training.SaveApprovedPaidAmount",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"expns_record_id_","varchar2","in",Request.Params["expid"]);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"is_approved_amount_","varchar2","in",strIs_approved_amount);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"amount_","varchar2","in",strValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_name_","varchar2","in",ViewState["User_Name"].ToString());
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			finally  
			{
				cmd.Dispose();
				conn.Close();
				conn.Dispose();
			}

		}

		private void lnkbtnSaveAndStay_Click(object sender, System.EventArgs e)
		{
            Validate();
            if (!IsValid)
                return;
			SaveOne();
			if (Request.Params["w"]=="s")
				Response.Redirect("SupervisorApproval.aspx?SkipCheck=YES&f=a");
			else
				Response.Redirect("PayorApprovalPage.aspx");

		}

		private void lnkbtnCancel_Click(object sender, System.EventArgs e)
		{
            if (Request.Params["w"] == "s")
                Response.Redirect("SupervisorApproval.aspx?SkipCheck=YES&f=a");
            else
                Response.Redirect("PayorApprovalPage.aspx");
			
		}

		private void ChangeVendorState(bool blnEnabled)
		{
			
		}

	

		
		


	}
}
