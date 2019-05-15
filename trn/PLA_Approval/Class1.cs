using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.Collections;

namespace PLA_Approval
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class TrainingClass
	{
        public static string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
		public static string CourseName(string record_id)
		{
            
			return SQLStatic.SQL.ExecScaler("select PKG_Training.CourseCodeTitle("+record_id+") from dual",
				PLA_Approval.TrainingClass.ConnectionString).ToString();
		}	
		
		public static string AvailableAmount(string employee_number,string processing_year)
		{

			string strAmount = SQLStatic.SQL.ExecScaler("select pkg_training.availablebalance("+employee_number+","+processing_year+") from dual",
				PLA_Approval.TrainingClass.ConnectionString).ToString();
			if (strAmount=="")
				return "$0.00";
			return Convert.ToDouble(strAmount).ToString("$##,0.00");
		}

		public static string IsSprvsrDataOk(string employee_number_)
		{
			string strSQL="select pkg_trn_fdic.SuperviorCanAccess("+employee_number_+") from dual";
			string strMsg=null;
			object ob=SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob == null)
				return "";
			else
			{
				strMsg= ob.ToString();				
				ob = null;
			}
			return strMsg;
		}

		public static string IsPayorDataOk(string employee_number_)
		{
			string strSQL="select pkg_trn_fdic.PayorCanAccess("+employee_number_+") from dual";
			string strMsg=null;
			object ob=SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString);
			if (ob == null)
				return "";
			else
			{
				strMsg= ob.ToString();				
				ob = null;
			}
			return strMsg;
		}

		public static string HelpPhoneNumber()
		{
			 
			object ob = SQLStatic.SQL.ExecScaler("select pkg_bas_system.sp from dual",
				PLA_Approval.TrainingClass.ConnectionString).ToString();
			string HelpPhone = "";
			if (ob!=null)
				HelpPhone = ob.ToString();
			ob = null;
			return HelpPhone;
		}

		public static string SetHeaderInformation(string strEmployee_number, Label lblEE, Label lblER)
		{
			DataTable tbl=null;
			string strAccountNumber = "";
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					PLA_Approval.TrainingClass.ConnectionString);
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

		public static string Employee_Name(string strEmployee_number)
		{
			DataTable tbl=null;
			string strEmployeeName = "";
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					PLA_Approval.TrainingClass.ConnectionString);
				strEmployeeName = BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(),tbl.Rows[0]["last_name"].ToString(),tbl.Rows[0]["middle_initial"].ToString());					
			}
			finally
			{
				if (tbl != null)
					tbl.Dispose();
			}
			return strEmployeeName;	
		}

		public static string employee_name_from_record_id(string strRecordId)
		{
			string strSQL = "select pkg_training.employee_name_from_record_id("+strRecordId+") from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
		}

		public static bool SessionHasTimeOut(string strSessionId)
		{
			string strSQL = "select pkg_sessions_data.validate_session_2('"+strSessionId+"') from dual";
			return
				SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString()=="0";
		}

		public static bool CanAccessOtherApplications(string strUserId)
		{
			object ob = SQLStatic.SQL.ExecScaler(
				"select pkg_training.can_access_other_application("+strUserId+") from dual",PLA_Approval.TrainingClass.ConnectionString);
			if (ob!=null)
				return ob.ToString()=="1";
			else
				return false;
		}

		public static string UsedEmployeeNumber(string strDefaulrEmployeeNumber,string strSessionID)
		{
			string strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID,"TRN_FOUND_EMPLOYEE_NUMBER",PLA_Approval.TrainingClass.ConnectionString);
			if (strEmployeeNumber=="")
				return strDefaulrEmployeeNumber;
			else
				return strEmployeeNumber;
		}

		public static void FillBudgetYears(DropDownList ddl,Label lbl, string strEmployeeNumber ,string strDefaultBudgetYear)
		{
			DataTable tbl=null;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.availablebalanceslist",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_",strEmployeeNumber);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_",strDefaultBudgetYear);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "budget_years_list_","cursor","out","");

			DataSet mds = new DataSet();
			Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
			try
			{
				conn.Open();
				da.Fill(mds);
				tbl=mds.Tables[0];
				ddl.Items.Clear();
				bool blnFound = false;
				foreach(DataRow dr in tbl.Rows)
				{
					ListItem li = new ListItem(dr["budget_year"].ToString(),dr["budget_year"].ToString()+"_"+dr["total_remaining_amount"].ToString());
					if (li.Text == strDefaultBudgetYear)
					{
						li.Selected = true;
						lbl.Text = FormatedRemainingAmount(li,strEmployeeNumber);
						blnFound = true;
					}
					ddl.Items.Add(li);
				}
				if ((ddl.Items.Count>0)&&(!blnFound))
				{
					ddl.SelectedIndex = 0;
					lbl.Text = FormatedRemainingAmount(ddl.Items[0],strEmployeeNumber);
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

		public static double SelectedYearBudget(DropDownList ddl, string strProcessingYear)
		{
			foreach (ListItem li in ddl.Items)
			{
				if (li.Text==strProcessingYear)
				{
					return Convert.ToDouble(RemainingAmount(li.Value));
				}
			}
			return 0;
		}

		public static string RemainingAmount(string strValue)
		{
			return strValue.Substring(5);
		}

		public static string FormatedRemainingAmount(ListItem li, string strEmployeeNumber)
		{
			string strAmount = RemainingAmount(li.Value);
            return BASUSA.MiscTidBit.Launch_Page(Convert.ToDouble(strAmount).ToString("$###,##0.00") + "&nbsp;Includes Training Request(s) Pending Payment",
				"/web_projects/trn/pla/BudgetDetail.aspx?ee="+strEmployeeNumber+"&py="+li.Text,"budget",600,500,10,10,true,true);
		}

		public static string Require_Continouation_Form(string strEmployeeNumber ,string strProcessingYear)
		{
			string strSQL="select pkg_trn_budget.require_continuation_form("+strEmployeeNumber+","+strProcessingYear+") from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,PLA_Approval.TrainingClass.ConnectionString).ToString();
		}

		public static void CheckBudgetForApproval(string strheader_record_id, string strCurseExpense,
			ref string returned_condintion, ref string returned_test)
		{
			
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(PLA_Approval.TrainingClass.ConnectionString);
			conn.Open();
			try
			{
				CheckBudgetForApproval(conn,strheader_record_id,strCurseExpense,ref returned_condintion, ref returned_test);
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
//			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.ChecBudgetBeforeApproval_suprv",conn);
//			cmd.CommandType = System.Data.CommandType.StoredProcedure;
//			cmd.CommandTimeout = 30;
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "pla_header_record_id_",strheader_record_id);
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "course_expense_",strCurseExpense);
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "return_condition_","varchar2","out","");
//			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "return_condition_text_","varchar2","out","");			
//			conn.Open();
//			try
//			{
//				cmd.ExecuteNonQuery();
//				returned_condintion = cmd.Parameters["return_condition_"].Value.ToString();
//				if (returned_condintion != "1")
//					returned_test = cmd.Parameters["return_condition_text_"].Value.ToString();
//				else
//					returned_test = "";
//			}
//			finally
//			{
//				conn.Close();
//				conn.Dispose();
//				cmd.Dispose();
//				
//			}
		}

		public static void CheckBudgetForApproval(Oracle.DataAccess.Client.OracleConnection conn, string strheader_record_id, 
			string strCurseExpense,	ref string returned_condintion, ref string returned_test)
		{
			
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.ChecBudgetBeforeApproval_suprv",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "pla_header_record_id_",strheader_record_id);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "course_expense_",strCurseExpense);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "return_condition_","varchar2","out",null,10);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "return_condition_text_","varchar2","out",null,4000);						
			try
			{
				cmd.ExecuteNonQuery();
				returned_condintion = cmd.Parameters["return_condition_"].Value.ToString();
				if (returned_condintion != "1")
					returned_test = cmd.Parameters["return_condition_text_"].Value.ToString();
				else
					returned_test = "";
			}
			finally
			{				
				cmd.Dispose();
			}
		}

		public static bool SubmitedContinuedServiceAgreement(string strEmployeeNumber ,string strProcessingYear)
		{
			return
				SQLStatic.SQL.ExecScaler("select pkg_trn_budget.submited_continued_service("+strEmployeeNumber+","+strProcessingYear+") from dual",
				PLA_Approval.TrainingClass.ConnectionString).ToString()=="1";
		}

		public static bool IsReadOnly(string session_id)
		{
			return SQLStatic.Sessions.GetSessionValue(session_id,"TRN_READONLY",PLA_Approval.TrainingClass.ConnectionString).ToString()=="T";	
		}
		

		public static void DisableAll(System.Web.UI.Control oMe,string strRole_id)
		{		
			int cnt = oMe.Controls.Count;			
			for(int i=0; i<cnt; i++)
			{
				if ((oMe.Controls[i].GetType().ToString()== "System.Web.UI.WebControls.TextBox"))
					((System.Web.UI.WebControls.TextBox)oMe.Controls[i]).Enabled=false;	
				else if ((oMe.Controls[i].GetType().ToString()== "System.Web.UI.WebControls.LinkButton"))
					((System.Web.UI.WebControls.LinkButton)oMe.Controls[i]).Enabled=false;	
				else if ((oMe.Controls[i].GetType().ToString()== "System.Web.UI.WebControls.DropDownList"))
					((System.Web.UI.WebControls.DropDownList)oMe.Controls[i]).Enabled=false;
				else if ((oMe.Controls[i].GetType().ToString()== "System.Web.UI.WebControls.Button"))
					((System.Web.UI.WebControls.Button)oMe.Controls[i]).Enabled=false;	
				else if ((oMe.Controls[i].GetType().ToString()== "System.Web.UI.WebControls.CheckBoxList"))
					((System.Web.UI.WebControls.CheckBoxList)oMe.Controls[i]).Enabled=false;
				else if ((oMe.Controls[i].GetType().ToString()== "System.Web.UI.WebControls.RadioButtonList"))
					((System.Web.UI.WebControls.RadioButtonList)oMe.Controls[i]).Enabled=false;
				if (oMe.Controls[i].HasControls())
				{
					DisableAll(oMe.Controls[i],strRole_id);					
				}					
			}
		}

		public static bool isAdministrator(string employee_number)
		{
			string sql = "select pkg_training_2.hasrole("+employee_number+",100408) from dual";
			return SQLStatic.SQL.ExecScaler(sql,PLA_Approval.TrainingClass.ConnectionString).ToString() != "0";
		}

		public static bool isAdministratorByUserID(string user_id)
		{
			return SQLStatic.SQL.ExecScaler("select pkg_employee_3.user_has_role("+user_id+",100408) from dual").ToString()=="1";
		}
		public static string SetFullHeader(Page wpage,string strEmployee_number)
		{
			DataTable tbl=null;
			string eeinfo="";
			string erinfo="";
	
			try
			{
				tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
					PLA_Approval.TrainingClass.ConnectionString);
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
			SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"2ndTitle",eeinfo,PLA_Approval.TrainingClass.ConnectionString);
			SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"3rdTitle",erinfo,PLA_Approval.TrainingClass.ConnectionString);
			if (!SQLStatic.Web_Data.Has_Role(strEmployee_number,"100400"))
			{
				SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"HPA","",PLA_Approval.TrainingClass.ConnectionString);
			}
			else
				SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(),"HPA","PLA",PLA_Approval.TrainingClass.ConnectionString);
			string setPTemplate = "<script language='javascript'>" +
				"window.open('/web_projects/ptemplate/header.aspx?callingurl="+wpage.Request.Path+"','Frame_detailing_the_selected_module_and_current_program_page');</script>";
			return setPTemplate;
		}

		public static string GetAccountNumber(string employee_number)
		{
			string strAccountNumber="";
			try
			{
				strAccountNumber=SQLStatic.SQL.ExecScaler(" select pkg_employee.ee_account_number("+employee_number+") from dual",PLA_Approval.TrainingClass.ConnectionString).ToString();
			}
			catch
			{
				return "";
			}
			return strAccountNumber;
		}

		public static void SetValidators(Page wpage)
		{
			RequiredFieldValidator valid =null;
			for (int i=0; i<=100; i++)
			{
				valid = (RequiredFieldValidator)wpage.FindControl("RequiredFieldValidator"+i.ToString());
				if (valid!=null)
				{
					valid.ToolTip = valid.ErrorMessage+" Click this link move to field "+valid.ControlToValidate;
					valid.ErrorMessage = "<a href=\"JavaScript:SetFocus('"+valid.ControlToValidate+"')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>"+valid.ErrorMessage.Replace("ERROR - ","")+"</u></font></a>";
				}
			}
			RegularExpressionValidator rgValid=null;
			for (int i=0; i<=100; i++)
			{
				rgValid = (RegularExpressionValidator)wpage.FindControl("RegularExpressionValidator"+i.ToString());
				if (rgValid!=null)
				{
					rgValid.ToolTip = rgValid.ErrorMessage+" Click this link move to field "+rgValid.ControlToValidate;
					rgValid.ErrorMessage = "<a href=\"JavaScript:SetFocus('"+rgValid.ControlToValidate+"')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>"+rgValid.ErrorMessage.Replace("ERROR - ","")+"</u></font></a>";					
				}
			}
			CompareValidator compValid = null;
			for (int i=0; i<=100; i++)
			{
				compValid = (CompareValidator)wpage.FindControl("CompareValidator"+i.ToString());
				if (compValid!=null)
				{
					compValid.ToolTip = compValid.ErrorMessage+" Click this link move to field "+compValid.ControlToValidate;
					compValid.ErrorMessage = "<a href=\"JavaScript:SetFocus('"+compValid.ControlToValidate+"')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>"+compValid.ErrorMessage.Replace("ERROR - ","")+"</u></font></a>";					
				}
			}

			RangeValidator RangeValid = null;
			for (int i=0; i<=100; i++)
			{
				RangeValid = (RangeValidator)wpage.FindControl("RangeValidator"+i.ToString());
				if (RangeValid!=null)
				{
					RangeValid.ToolTip = RangeValid.ErrorMessage+" Click this link move to field "+RangeValid.ControlToValidate;
					RangeValid.ErrorMessage = "<a href=\"JavaScript:SetFocus('"+RangeValid.ControlToValidate+"')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>"+RangeValid.ErrorMessage.Replace("ERROR - ","")+"</u></font></a>";					
				}
			}
		}
		public static string Application_Processing_Year(string header_id)
		{
			return SQLStatic.SQL.ExecScaler("select pkg_training_2.application_processing_year("+header_id+") from dual").ToString();
			
		}
        public static bool HasDocuments(string strHeader_ID)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_training.getdocumentscount(" + strHeader_ID + ") from dual").ToString() != "0";       
        }

        public static DataTable CPBudgetDetail(string strEmployeeNumber, string strProcessingYear)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("employee_number_", "in", "varchar2", strEmployeeNumber));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("processing_year_", "in", "varchar2", strProcessingYear));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_trn_competitive_pogram.get_cp_budget_detail", al);
        }

        public static void HideAll_CDP_Request(string trn_cdp_ee_status_record_id_, string user_name_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("trn_cdp_ee_status_record_id_", "in", "varchar2", trn_cdp_ee_status_record_id_));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("user_name_", "in", "varchar2", user_name_));
            SQLStatic.StoredProcedure.ExecuteNonQueryProcedure("pkg_training_cdp.HideAll_CDP_Request", al);
        }

        public static DataTable Hid_CDP_into(string trn_cdp_ee_status_record_id_)
        {
            ArrayList al = new ArrayList(3);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("trn_cdp_ee_status_record_id_", "in", "varchar2", trn_cdp_ee_status_record_id_));           
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retResult_", "out", "cursor", null));
            return SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training_cdp.Hid_CDP_into", al);
        }

	}
}
