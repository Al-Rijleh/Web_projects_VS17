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
		protected System.Web.UI.WebControls.TextBox txtAmount;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.TextBox txtVendorContact;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtRemaining;
		protected System.Web.UI.WebControls.RadioButtonList optlstVendor;
		protected System.Web.UI.WebControls.TextBox txtemail;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Label lblColor;
		protected System.Web.UI.WebControls.Label lblWarning;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtExpenseType;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.RadioButton rbVendor;
		protected System.Web.UI.WebControls.DropDownList ddlBudgetYear;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label LblTemplateHeader2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
		protected System.Web.UI.WebControls.Label lblRequiredSymbol;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.HtmlControls.HtmlInputHidden doSave;
		protected System.Web.UI.HtmlControls.HtmlInputButton htmBtnSave;
		protected System.Web.UI.WebControls.Label req1;
		protected System.Web.UI.WebControls.Label req2;
		protected System.Web.UI.WebControls.Label req3;
		protected System.Web.UI.WebControls.Label req4;
		protected System.Web.UI.WebControls.Label req5;
		protected System.Web.UI.WebControls.Label req6;
		protected System.Web.UI.WebControls.Label req7;
		protected System.Web.UI.WebControls.Label req8;
		protected System.Web.UI.WebControls.Label req9;
		protected System.Web.UI.WebControls.Label req10;
		protected System.Web.UI.WebControls.Label lblEstimatedAmount;
		protected System.Web.UI.WebControls.Label lblVendorName;
		protected System.Web.UI.WebControls.Label lblVendorContact;
		protected System.Web.UI.WebControls.Label lblVedorTelephoneandFax;
		protected System.Web.UI.WebControls.Label lblAddressLine1AndAddressLine2;
		protected System.Web.UI.WebControls.Label lblVendorEmail;
		protected System.Web.UI.WebControls.Label lblAdditionInformation;
		protected System.Web.UI.WebControls.Label lblTextLimit;
		protected System.Web.UI.WebControls.Label lblCountry;
		protected System.Web.UI.WebControls.Label lblCityState;
		protected System.Web.UI.WebControls.DropDownList ddlContries;
		protected System.Web.UI.WebControls.TextBox txtProvince;
        protected System.Web.UI.WebControls.Label lblPhoneFormat;
        protected System.Web.UI.HtmlControls.HtmlTableRow r1;
        protected System.Web.UI.HtmlControls.HtmlTableRow r2;
        protected System.Web.UI.HtmlControls.HtmlTableRow r3;
        protected System.Web.UI.HtmlControls.HtmlTableRow r4;
        protected System.Web.UI.HtmlControls.HtmlTableRow r5;
        protected System.Web.UI.HtmlControls.HtmlTableRow r6;
        protected System.Web.UI.HtmlControls.HtmlTableRow r7;
        protected System.Web.UI.HtmlControls.HtmlTableRow r8;

		private int FieldCounter=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Training_Source.TrainingClass.SessionHasTimeOut(Request.Cookies["Session_ID"].Value.ToString()))
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Your Session has timed out"+"&backurl=0" ,true);
			lblScript.Text ="";
			lblError.Text = "";
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
					if (Request.Params["s"]=="v")
						LblTemplateHeader2.Text = "Expense Detail";
					else
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
				Training_Source.TrainingClass.SetValidators(Page);
				ViewState["Employee_Number"]=Training_Source.TrainingClass.UsedEmployeeNumber2(ViewState["Employee_Number"].ToString(),Request.Cookies["Session_ID"].Value.ToString());
				lblBalance.Text = Training_Source.TrainingClass.AvailableAmount(ViewState["Employee_Number"].ToString(),ViewState["Processing_Year"].ToString());
				ViewState["Session_ID"]=Request.Cookies["Session_ID"].Value.ToString();
				ViewState["Request_Record_ID"] = SQLStatic.Sessions.GetSessionValue(ViewState["Session_ID"].ToString(),"Request_Record_ID",Training_Source.TrainingClass.ConnectioString);
				ViewState["AppStatus"]=Training_Source.TrainingClass.ApplicationStatus(ViewState["Request_Record_ID"].ToString());				
				SetHeaderInformation();	
				FillExpenseType();
				FillSatesDropDown();
				FillContries();
				HighLightKeyFields();
				if (Request.Params["expid"] != "-1")
					GetExistingData();	
			    else
                    SetValue(ddlContries, "USA");
				if (txtVedorName.Text == "FDIC ETV")
				{
					optlstVendor.SelectedIndex=2;
					optlstVendor_SelectedIndexChanged(null,null);
				}
				SetInView();
				string strProcessingYear = SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),"CoursePY",Training_Source.TrainingClass.ConnectioString);
                if (strProcessingYear == "")
                    strProcessingYear = ViewState["Processing_Year"].ToString();
                ViewState["App_Processing_Year"] = strProcessingYear;
				Training_Source.TrainingClass.FillBudgetYears(ddlBudgetYear,lblBalance,ViewState["Employee_Number"].ToString(),strProcessingYear);
				rbVendor.Text = optlstVendor.SelectedItem.Text;
				ddlContries_SelectedIndexChanged(null, null);
                optlstVendor_SelectedIndexChanged(null, null);
			}
			HandleContractors();
			if (!(Request.Form["doSave"] == null||Request.Form["doSave"] == ""))
			{
				string strGoTo = Request.Form["doSave"].Replace("'","");
				doSave.Value="";
				this.Validate();
				if(this.IsValid)
				{					
					if(DoSave())
						Response.Redirect("TrainingExpenses.aspx?Admin="+Request.Params["Admin"]);
					htmBtnSave.Disabled=false;
				}
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
			this.ddlBudgetYear.SelectedIndexChanged += new System.EventHandler(this.ddlBudgetYear_SelectedIndexChanged);
			this.ddlExpenseType.SelectedIndexChanged += new System.EventHandler(this.ddlExpenseType_SelectedIndexChanged);
			this.optlstVendor.SelectedIndexChanged += new System.EventHandler(this.optlstVendor_SelectedIndexChanged);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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

		private void HighLightKeyFields()
		{
			if (Request.Params["s"]=="v")
				return;
			if (Request.Params["expid"] != "-1")
			{
                if (Convert.ToInt32(ViewState["AppStatus"].ToString()) > 1)
                {
                    if (Request.Params["Admin"] != "YES")
                    {
                        txtAmount.BackColor = System.Drawing.Color.Cyan;
                        lblColor.Visible = true;
                        lblInfo.Visible = true;
                    }
                }
			}
			else
			{
				if (Convert.ToInt32(ViewState["AppStatus"].ToString())>1)
                    if (Request.Params["Admin"] != "YES")
					    lblWarning.Visible = true;
			}
            //if (Request.Params["Admin"] != "YES")
            //{
            //    lblWarning.Visible = true;
            //}			
		}

		private void SetInView()
		{
			if (Request.Params["s"]=="v")
			{
				lblRequiredSymbol.Text="&nbsp;";
				Label lbl = null;
				for (int i=0;i<=100;i++)
				{
					lbl = (Label)Page.FindControl("req"+i.ToString());
					if (lbl!=null)
						lbl.Visible = false;
				}
				txtExpenseType.Visible = true;
				ddlExpenseType.Visible=false;
				txtExpenseName.ReadOnly=true;
				txtAmount.ReadOnly=true;
				txtAmount.BackColor = System.Drawing.Color.White;
				txtDescription.ReadOnly=true;
				txtDescription.BackColor = System.Drawing.Color.White;
				htmBtnSave.Disabled=true;
				rbVendor.Visible = true;
				optlstVendor.Visible=false;
				ChangeVendorState(false);

				txtVedorName.ReadOnly=true;
				txtVedorName.BackColor = System.Drawing.Color.White;
				txtVendorContact.ReadOnly=true;
				txtVendorContact.BackColor = System.Drawing.Color.White;
				txtAddressLine1.ReadOnly=true;
				txtAddressLine1.BackColor = System.Drawing.Color.White;
				txtAddressLine2.ReadOnly=true;
				txtAddressLine2.BackColor = System.Drawing.Color.White;
				txtCity.ReadOnly=true;
				txtCity.BackColor = System.Drawing.Color.White;
				ddlStates.Visible = false;
				txtZipCode.ReadOnly=true;
				txtZipCode.BackColor = System.Drawing.Color.White;
				txtPhoneNumber.ReadOnly=true;
				txtPhoneNumber.BackColor = System.Drawing.Color.White;
				txtFaxNumber.ReadOnly=true;
				txtFaxNumber.BackColor = System.Drawing.Color.White;
				txtemail.ReadOnly=true;				
				txtemail.BackColor = System.Drawing.Color.White;
				txtState.Visible = true;	
				txtState.BackColor = System.Drawing.Color.White;
				txtExpenseName.ReadOnly=true;
				txtExpenseName.BackColor = System.Drawing.Color.White;
			}
		}

		private void FillSatesDropDown()
		{
			DataTable dtStates = SQLStatic.CD_Tables.States(Training_Source.TrainingClass.ConnectioString);
			try
			{
				ListItem li0 = new ListItem("--Select--","x");
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
			ViewState["Account_Number"]=Training_Source.TrainingClass.GetAccountNumber(ViewState["Employee_Number"].ToString());
			lblCourseTitle.Text = Training_Source.TrainingClass.CourseName(ViewState["Request_Record_ID"].ToString());
			if (Request.Params["s"]=="v")
				return;
			string parPtemplate = Training_Source.TrainingClass.SetHeader(Page);
			Page.ClientScript.RegisterStartupScript(Page.GetType(),"parPtemplate",parPtemplate);
		}

		private void GetExistingData()
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_training.GetExpenseList",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",Request.Params["expid"]);			
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "expenses_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			string strPay_to = "";
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];				
				foreach (DataRow dr in tbl.Rows)
				{
					SetValue(txtExpenseName, dr["expense_type"].ToString());
					double dbAmount = Convert.ToDouble(dr["amount"].ToString());
					if (dbAmount<0)
						dbAmount = -dbAmount;
					SetValue(txtAmount,dbAmount.ToString());
					SetValue(txtDescription,dr["note"].ToString());
					
//					ListItem li0 = new ListItem("--Select--"," ");				
//					ddlExpenseType.Items.Add(li0);
					if (dr["expense_type_ID"].ToString() != "1000")
					{
						ListItem li = new ListItem(txtExpenseName.Text,dr["expense_type_ID"].ToString());				
						ddlExpenseType.Items.Add(li);
					}
					SetValue(ddlExpenseType,dr["expense_type_ID"].ToString());
					for (int i=0;i<ddlExpenseType.Items.Count;i++)
						if (ddlExpenseType.Items[i].Value == dr["expense_type_ID"].ToString())
						{
							SetValue(txtExpenseType,ddlExpenseType.Items[i].Text);
							ddlExpenseType.SelectedIndex=i;
							break;
						}
					SetValue(txtVedorName,dr["vendor_name"].ToString());
					SetValue(txtVendorContact,dr["vendor_contact_name"].ToString());
					SetValue(txtAddressLine1,dr["vendor_address_1"].ToString());
					SetValue(txtAddressLine2,dr["vendor_address2"].ToString());
					SetValue(txtCity,dr["vendor_city"].ToString());
					SetValue(ddlStates,dr["vendor_state"].ToString());
					SetValue(txtZipCode,dr["vendor_zip"].ToString());
					SetValue(txtPhoneNumber,dr["vendor_phone"].ToString());
					SetValue(txtFaxNumber,dr["vendor_fax"].ToString());
					SetValue(txtemail,dr["vendor_email"].ToString());
					SetValue(txtProvince, dr["province"].ToString());
					SetValue(ddlContries, dr["country_code"].ToString());

					strPay_to = dr["pay_to"].ToString();
									
//					for (int i=0;i<ddlStates.Items.Count;i++)
//						if (ddlStates.Items[i].Value==strState)
//						{
//							ddlStates.SelectedIndex=i;
//							break;
//						}
					txtState.Text= ddlStates.SelectedItem.Text;
					ddlExpenseType_SelectedIndexChanged(null,null);
					ddlContries_SelectedIndexChanged(null, null);
					SetValue(txtExpenseName,dr["expense_type"].ToString());
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
			if (strPay_to != "")
			{
				optlstVendor.SelectedIndex = Convert.ToInt32(strPay_to);	
				optlstVendor_SelectedIndexChanged(null,null);
			}
		}

		private bool DataChanged()
		{
			bool blnChanged = false;
			TextBox txt = null;
			DropDownList ddl = null;
			string fldId="";
			for (int i=0;i<=100;i++)
			{
				if (ViewState["id_"+i.ToString()]!=null)
				{
					fldId=ViewState["id_"+i.ToString()].ToString();
					if (fldId.IndexOf("txt")==0)
					{
						txt = (TextBox)Page.FindControl(fldId);
						if (txt != null)
						{
							blnChanged = txt.Text!=ViewState[fldId].ToString();
							if (blnChanged)
								break;
						}
					}
					else
					{
						ddl = (DropDownList)Page.FindControl(fldId);
						if (ddl != null)
						{
							blnChanged = ddl.SelectedValue!=ViewState[fldId].ToString();
							if (blnChanged)
								break;
						}
					}
				}
			}
			return blnChanged;			
		}

		private void SetValue(TextBox txt,string strValue)
		{
			txt.Text=strValue;
			ViewState[txt.ID]=strValue;
			ViewState["id_"+FieldCounter]=txt.ID;
			FieldCounter++;
		}

		private void SetValue(DropDownList ddl, string strValue)
		{
			foreach(ListItem li in ddl.Items)
			{
				li.Selected = (li.Value == strValue);
				if (li.Selected)
				{
					ViewState[ddl.ID]=strValue;
					ViewState["id_"+FieldCounter]=ddl.ID;
					FieldCounter++;
					break;
				}
			}
		}
		
		private void SetValue(RadioButtonList opt, string strValue)
		{
			foreach(ListItem li in opt.Items)
			{
				li.Selected = (li.Value == strValue);
				if (li.Selected)
				{
					ViewState[opt.ID]=strValue;
					ViewState["id_"+FieldCounter]=opt.ID;
					FieldCounter++;
					break;
				}
			}
		}

		private void FillExpenseType()
		{			
			ddlExpenseType.Items.Clear();
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
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

				ListItem li0 = new ListItem("--Select--"," ");
				ddlExpenseType.Items.Add(li0);

				foreach (DataRow dr in tbl.Rows)
				{
					if (dr["record_id"].ToString() != "2000")
					{
						ListItem li = new ListItem(dr["description"].ToString(),dr["record_id"].ToString());
						ddlExpenseType.Items.Add(li);
					}
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
			txtExpenseName.Visible=false;
			req2.Visible = false;
            optlstVendor.Enabled = true;
			if (ddlExpenseType.SelectedValue=="1000")
			{
				txtExpenseName.Text = "";
				lblExpenseName.Visible=true;
				txtExpenseName.Visible=true;
				req2.Visible = true;
			}
			else if ((ddlExpenseType.SelectedValue=="40")||(ddlExpenseType.SelectedValue=="50")||
				(ddlExpenseType.SelectedValue=="60")||
				(ddlExpenseType.SelectedValue=="42")||(ddlExpenseType.SelectedValue=="43")||
				(ddlExpenseType.SelectedValue=="44")||(ddlExpenseType.SelectedValue=="45"))
			{
				optlstVendor.SelectedIndex = 2;
				optlstVendor_SelectedIndexChanged(null,null);
                optlstVendor.Enabled = false;
			}
			else if (ddlExpenseType.SelectedValue=="70")
			{
				optlstVendor.SelectedIndex = 3;
				optlstVendor_SelectedIndexChanged(null,null);
			}
			else
			{
				txtExpenseName.Text = ddlExpenseType.SelectedItem.Text;
			}
		}

		private double remaining_amount(Oracle.DataAccess.Client.OracleConnection conn)
		{
            if (Request.Params["Admin"] == "YES")
            {
                return 0;
            }
			string sSQL = "select pkg_trn_budget.total_cushion_budget_remaining("+ViewState["Employee_Number"].ToString()+","+ViewState["App_Processing_Year"].ToString()+") from dual";
			Oracle.DataAccess.Client.OracleCommand cmd=
				new Oracle.DataAccess.Client.OracleCommand(sSQL,conn);			
			object obj=null;
			try
			{
				obj = cmd.ExecuteScalar();
			}
			finally
			{				
				cmd.Dispose();
			}
			double dblValue;
			try
			{
				dblValue = Convert.ToDouble(obj.ToString());
			}
			catch
			{
				dblValue = 0;
			}
				return dblValue;
		}

		private bool DoSave()
		{
			if (ddlExpenseType.SelectedValue != "1000")
				txtExpenseName.Text = ddlExpenseType.SelectedItem.Text;

			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
             
            string strProcedureName = "basdba.PKG_Training.AddUpdateEmploeeExpense";
            if (Request.Params["Admin"] == "YES")
                strProcedureName = "basdba.PKG_Training.AddUpdateEmploeeExpense_Admin";
			 Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strProcedureName,conn);
       
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			bool blnok=false;
            conn.Open();
            Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
			try
			{
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"record_id_","number","in",Request.Params["expid"]);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"header_record_id_","number","in",ViewState["Request_Record_ID"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"expense_type_ID_","number","in",ddlExpenseType.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"expense_type_","varchar2","in",txtExpenseName.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"amount_","number","in",txtAmount.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"pay_to_","number","in",optlstVendor.SelectedIndex);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"note_","varchar2","in",txtDescription.Text);								
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_name_","varchar2","in",txtVedorName.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_contact_name_","varchar2","in",txtVendorContact.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_address_1_","varchar2","in",txtAddressLine1.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_address2_","varchar2","in",txtAddressLine2.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_city_","varchar2","in",txtCity.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_state_","varchar2","in",ddlStates.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_zip_","varchar2","in",txtZipCode.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_phone_","varchar2","in",txtPhoneNumber.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_fax_","varchar2","in",txtFaxNumber.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"vendor_emai_","varchar2","in",txtemail.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"user_id_","varchar2","in",ViewState["User_Name"].ToString());
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "country_code_", "varchar2", "in", ddlContries.SelectedValue);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "province_", "varchar2", "in", txtProvince.Text);
				SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd,"new_record_id_","number","out","");
				
				cmd.ExecuteNonQuery();
				double dblremain = remaining_amount(conn);
				if (dblremain<0)
				{
					txn.Rollback();
					blnok = false;
					lblError.Text = "You do not have enough money in your budget to pay for this expense. You "+
					"should request at lease "+(-1*dblremain).ToString("$###,###,##0.00")+" extra from the Division/Office Director to pay for this expense";
				}
				else
				{
					blnok = true;
					txn.Commit();
				}
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
				cmd.Dispose();
			}
			return blnok;
		}

		

	

		private void ChangeVendorState(bool blnEnabled)
		{
            r1.Visible = blnEnabled;
            r2.Visible = blnEnabled;
            r3.Visible = blnEnabled;
            r4.Visible = blnEnabled;
            r5.Visible = blnEnabled;
            r6.Visible = blnEnabled;
            r7.Visible = blnEnabled;
            r8.Visible = blnEnabled;

			txtVedorName.ReadOnly=!blnEnabled;
			txtVendorContact.ReadOnly=!blnEnabled;
			txtAddressLine1.ReadOnly=!blnEnabled;
			txtAddressLine2.ReadOnly=!blnEnabled;
			txtCity.ReadOnly=!blnEnabled;
			ddlStates.Visible=blnEnabled;
			txtState.Visible =!blnEnabled;
			txtZipCode.ReadOnly=!blnEnabled; 
			txtPhoneNumber.ReadOnly=!blnEnabled;
			txtFaxNumber.ReadOnly=!blnEnabled;
			txtemail.ReadOnly=!blnEnabled;
			System.Drawing.Color backColor;
			if (Request.Params["s"]!="v")
			{
				if (!blnEnabled)
					backColor = System.Drawing.Color.Gainsboro;
				else
					backColor = System.Drawing.Color.White;
			
				txtVedorName.BackColor = backColor;
				txtVendorContact.BackColor = backColor;
				txtAddressLine1.BackColor = backColor;
				txtAddressLine2.BackColor = backColor;
				txtCity.BackColor = backColor;				
				txtState.BackColor = backColor;
				txtZipCode.BackColor = backColor; 
				txtPhoneNumber.BackColor = backColor;
				txtFaxNumber.BackColor = backColor;
				txtemail.BackColor = backColor;
				txtDescription.BackColor = backColor;
				txtAmount.BackColor = backColor;
				txtExpenseName.BackColor = backColor;
			}
			
			RequiredFieldValidator5.Enabled = blnEnabled;
			Regularexpressionvalidator3.Enabled = blnEnabled;
			RequiredFieldValidator6.Enabled = blnEnabled;
			RequiredFieldValidator3.Enabled = blnEnabled;
			Regularexpressionvalidator4.Enabled = blnEnabled;
			RequiredFieldValidator4.Enabled = blnEnabled;
			RequiredFieldValidator5.Enabled = blnEnabled;
			RequiredFieldValidator7.Enabled = blnEnabled;
			Requiredfieldvalidator8.Enabled = blnEnabled;

		}

		private void ClearVendorFields()
		{
			txtVedorName.Text = "";
			txtVendorContact.Text = "";
			txtAddressLine1.Text = "";
			txtAddressLine2.Text = "";
			txtCity.Text = "";
			ddlStates.SelectedIndex = 0;
			txtZipCode.Text = ""; 
			txtPhoneNumber.Text = "";
			txtFaxNumber.Text = "";
			txtemail.Text = "";
		}

		private void CopyVendorInfo()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.PKG_Training.GetHeaderRecord",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			DataTable tbl=null;
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				
				txtVedorName.Text = tbl.Rows[0]["vendor_name"].ToString();
				txtVendorContact.Text = tbl.Rows[0]["vendor_contact"].ToString();
				txtPhoneNumber.Text = tbl.Rows[0]["vendor_phone_number"].ToString();
				txtFaxNumber.Text = tbl.Rows[0]["vendor_fax_number"].ToString();
				txtAddressLine1.Text = tbl.Rows[0]["vendor_address1"].ToString();
				txtAddressLine2.Text = tbl.Rows[0]["vendor_address2"].ToString();
				txtCity.Text = tbl.Rows[0]["vendor_city"].ToString();
				string strState = tbl.Rows[0]["vendor_state"].ToString();
				txtZipCode.Text = tbl.Rows[0]["vendor_zip_code"].ToString();
				txtProvince.Text = tbl.Rows[0]["province"].ToString();
				string strCountry = tbl.Rows[0]["country_code"].ToString();

				foreach (ListItem li in ddlContries.Items)
				{
					li.Selected = li.Value == strCountry;
				}
				
				for (int i=0;i<ddlStates.Items.Count;i++)
					if (ddlStates.Items[i].Value==strState)
					{
						ddlStates.SelectedIndex = i;
						break;
					}
				txtState.Text= ddlStates.SelectedItem.Text;
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

		private void optlstVendor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (optlstVendor.SelectedIndex==0)
			{
				ChangeVendorState(true);
				CopyVendorInfo();
			}
			else if (optlstVendor.SelectedIndex==1)
				ChangeVendorState(true);
			else if (optlstVendor.SelectedIndex==3)
			{
				ChangeVendorState(false);
				ClearVendorFields();
				txtVedorName.Text = "Employee Contribution";
			}
			else
			{
				ChangeVendorState(false);
				ClearVendorFields();
				txtVedorName.Text = "FDIC ETV";
			}
			ddlContries_SelectedIndexChanged(null, null);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			if ((Request.Params["s"]!=null)&&(Request.Params["s"]=="v"))
			{
				Response.Redirect("NewSummary.aspx?Tab=3");
				return;
			}

			if (DataChanged())
			{
				Training_Source.TrainingClass.RegisterWarning(Page,"'TrainingExpenses.aspx'");
				return;
			}	
			else
			{
					Response.Redirect("TrainingExpenses.aspx?Admin="+Request.Params["Admin"]);
			}
		}

		private void ddlBudgetYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblBalance.Text = Training_Source.TrainingClass.FormatedRemainingAmount(ddlBudgetYear.SelectedItem,ViewState["Employee_Number"].ToString());
		}

		private void HandleContractors()
		{
			if (!Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				return;
			Training_Source.TrainingClass.DisableAll(this,ViewState["User_Primary_Role"].ToString());			
			btnClose.Enabled	= true;	
			ddlBudgetYear.Enabled	= true;
			htmBtnSave.Disabled = true;
		}

		protected void ddlContries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlContries.SelectedValue != "USA")
			{
				RequiredFieldValidator4.Visible = false;
				Regularexpressionvalidator3.Visible = false;
				Regularexpressionvalidator4.Visible = false;
				txtPhoneNumber.MaxLength = 30;
				txtFaxNumber.MaxLength = 30;
				lblCityState.Text = "City/Province";
				txtProvince.Visible = true;
				ddlStates.Visible = false;
				RequiredFieldValidator6.Visible = false;
				txtZipCode.Visible = false;
				Requiredfieldvalidator8.Visible = false;
				Regularexpressionvalidator2.Visible = false;
				RequiredFieldValidator7.Visible = false;
				Label19.Visible = false;
				Label20.Visible = false;
                lblPhoneFormat.Visible = false;
			}
			else
			{
				RequiredFieldValidator4.Visible = true;
				Regularexpressionvalidator3.Visible = true;
				Regularexpressionvalidator4.Visible = true;
				txtPhoneNumber.MaxLength = 14;
				txtFaxNumber.MaxLength = 14;
				lblCityState.Text = "City/Province";
				txtProvince.Visible = false;
				ddlStates.Visible = true;
				RequiredFieldValidator6.Visible = true;
				txtZipCode.Visible = true;
				Requiredfieldvalidator8.Visible = true;
				Regularexpressionvalidator2.Visible = true;
				RequiredFieldValidator7.Visible = true;
				Label19.Visible = true;
				Label20.Visible = true;
                lblPhoneFormat.Visible = true;
			}
		}

	
		
		
	}
}
