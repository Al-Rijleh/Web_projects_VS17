using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;

namespace Vendor
{
    public class Data
    {
        public static string ConnectioString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];

        public static string CourseName(string record_id)
        {
            return SQLStatic.SQL.ExecScaler("select PKG_Training.CourseCodeTitle(" + record_id + ") from dual",
                Data.ConnectioString).ToString();
        }

        public static string AvailableAmount(string employee_number, string processing_year)
        {

            string strAmount = SQLStatic.SQL.ExecScaler("select pkg_training.availablebalance(" + employee_number + "," + processing_year + ") from dual",
                Data.ConnectioString).ToString();
            if (strAmount == "")
                return "$0.00";
            else
                return Convert.ToDouble(strAmount).ToString("$##,0.00");
        }

        public static string ManagerEENumber(string employee_number)
        {
            object ob = SQLStatic.SQL.ExecScaler("select pkg_training.sprvsr_employee_number(" + employee_number + ") from dual",
                Data.ConnectioString).ToString();
            string strEENo = "";
            if (ob != null)
                strEENo = ob.ToString();
            ob = null;
            return strEENo;
        }


        public static string IsEeDataOk(string employee_number)
        {
            string strSQL = "select pkg_trn_fdic.applicantcanaccess(" + employee_number + ") from dual";
            string strMsg = null;
            object ob = SQLStatic.SQL.ExecScaler(strSQL, Data.ConnectioString);
            if (ob == null)
                return "";
            else
            {
                strMsg = ob.ToString();
                ob = null;
            }
            return strMsg;
        }

        public static string HelpPhoneNumber()
        {

            object ob = SQLStatic.SQL.ExecScaler("select pkg_bas_system.sp from dual",
                     Data.ConnectioString).ToString();
            string HelpPhone = "";
            if (ob != null)
                HelpPhone = ob.ToString();
            ob = null;
            return HelpPhone;
        }

        public static string ApplicationStatus(string header_record_id)
        {
            string strSQL = "select pkg_training.course_approval_status(" + header_record_id + ") from dual";
            string strStatus = null;
            object ob = SQLStatic.SQL.ExecScaler(strSQL, Data.ConnectioString);
            if (ob == null)
                return "0";
            else
            {
                strStatus = ob.ToString();
                ob = null;
            }
            if (strStatus == "")
                strStatus = "0";
            return strStatus;
        }

        public static string SetHeaderInformation(string strEmployee_number, Label lblEE, Label lblER)
        {
            DataTable tbl = null;
            string strAccountNumber = "";
            try
            {
                tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
                    Data.ConnectioString);
                lblEE.Text = "<B>" + BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(), tbl.Rows[0]["last_name"].ToString(), tbl.Rows[0]["middle_initial"].ToString()) +
                    "</B>  -  MyEnroll#: " + strEmployee_number +
                    "  Tel: " + BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
                lblER.Text = tbl.Rows[0]["account_name"].ToString() + " (Acct# " + tbl.Rows[0]["account_number"].ToString() + ")";
                strAccountNumber = tbl.Rows[0]["account_number"].ToString();
            }
            finally
            {
                if (tbl != null)
                    tbl.Dispose();
            }
            return strAccountNumber;
        }

        public static string SetHeader(Page wpage)
        {
            string setPTemplate = "<script language='javascript'>" +
                "window.open('/web_projects/ptemplate/header.aspx?callingurl=" + wpage.Request.Path + "','Frame_detailing_the_selected_module_and_current_program_page');</script>";
            return setPTemplate;
        }

        public static string Setfooter(string strextra)
        {
            string setPTemplate = "<script language='javascript'>" +
                "window.open('/web_projects/ptemplate/CopyRight.aspx?extra=" + strextra + "','Benefit_Allocations_Systems_Inc_Copyright_Information_Frame');</script>";
            return setPTemplate;
        }

        public static string SetFullHeader(Page wpage, string strEmployee_number)
        {
            DataTable tbl = null;
            string eeinfo = "";
            string erinfo = "";

            try
            {
                tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
                    Data.ConnectioString);
                eeinfo = "Employee:&nbsp;&nbsp;&nbsp;" + BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(), tbl.Rows[0]["last_name"].ToString(), tbl.Rows[0]["middle_initial"].ToString()) +
                    "  -  MyEnroll#: " + strEmployee_number +
                    "  Tel: " + BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
                erinfo = "Employer:&nbsp;&nbsp;&nbsp;" + tbl.Rows[0]["account_name"].ToString() + " (Acct# " + tbl.Rows[0]["account_number"].ToString() + ")";
            }
            finally
            {
                if (tbl != null)
                    tbl.Dispose();
            }
            SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(), "2ndTitle", eeinfo, Data.ConnectioString);
            SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(), "3rdTitle", erinfo, Data.ConnectioString);
            if (!SQLStatic.Web_Data.Has_Role(strEmployee_number, "100400"))
            {
                SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(), "HPA", "", Data.ConnectioString);
            }
            else
                SQLStatic.Sessions.SetSessionValue(wpage.Request.Cookies["Session_ID"].Value.ToString(), "HPA", "PLA", Data.ConnectioString);
            string setPTemplate = "<script language='javascript'>" +
                "window.open('/web_projects/ptemplate/header.aspx?callingurl=" + wpage.Request.Path + "','Frame_detailing_the_selected_module_and_current_program_page');</script>";
            return setPTemplate;
        }

        public static string GetAccountNumber(string employee_number)
        {
            string strAccountNumber = "";
            try
            {
                strAccountNumber = SQLStatic.SQL.ExecScaler(" select pkg_employee.ee_account_number(" + employee_number + ") from dual", Data.ConnectioString).ToString();
            }
            catch
            {
                return "";
            }
            return strAccountNumber;
        }

        public static string SetHeaderInformation(string strEmployee_number, Label lblEE, Label lblER,
            Label lblFormID)
        {
            DataTable tbl = null;
            string strAccountNumber = "";
            try
            {
                tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
                    Data.ConnectioString);
                lblEE.Text = "<B>" + BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(), tbl.Rows[0]["last_name"].ToString(), tbl.Rows[0]["middle_initial"].ToString()) +
                    "</B>  -  MyEnroll#: " + strEmployee_number +
                    "  Tel: " + BASUSA.MiscTidBit.FormatPhoneNumber(tbl.Rows[0]["phone_number"].ToString());
                lblER.Text = tbl.Rows[0]["account_name"].ToString() + " (Acct# " + tbl.Rows[0]["account_number"].ToString() + ")";
                strAccountNumber = tbl.Rows[0]["account_number"].ToString();
            }
            finally
            {
                if (tbl != null)
                    tbl.Dispose();
            }
            return strAccountNumber;
        }

        public static string Account_Number(string strEmployee_number)
        {
            DataTable tbl = null;
            string strAccountNumber = "";
            try
            {
                tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
                    Data.ConnectioString);
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
            DataTable tbl = null;
            string strEmployeeName = "";
            try
            {
                tbl = SQLStatic.EmployeeData.EEProfile(strEmployee_number,
                    Data.ConnectioString);
                strEmployeeName = BASUSA.MiscTidBit.FullName(tbl.Rows[0]["first_name"].ToString(), tbl.Rows[0]["last_name"].ToString(), tbl.Rows[0]["middle_initial"].ToString());
            }
            finally
            {
                if (tbl != null)
                    tbl.Dispose();
            }
            return strEmployeeName;
        }

        public static bool SessionHasTimeOut(string strSessionId)
        {
            string strSQL = "select pkg_sessions_data.validate_session_2('" + strSessionId + "') from dual";
            return
                SQLStatic.SQL.ExecScaler(strSQL, Data.ConnectioString).ToString() == "0";
        }

        public static string EmployeeNumberFromRecordID(string record_id)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_training.employee_number_from_record_id(" + record_id + ") from dual", Data.ConnectioString).ToString();
        }

        public static string FormId(string header_record_id)
        {
            object ob = SQLStatic.SQL.ExecScaler(
                "select pkg_training.get_form_id(" + header_record_id + ") from dual", Data.ConnectioString);
            if (ob != null)
                return ob.ToString();
            else
                return "";
        }

        public static string FormId(string employee_number, string processing_year)
        {
            object ob = SQLStatic.SQL.ExecScaler(
                "select pkg_training.get_form_id(" + employee_number + "," + processing_year + ") from dual", Data.ConnectioString);
            if (ob != null)
                return ob.ToString();
            else
                return "";
        }

        public static bool CanAccessOtherApplications(string strUserId)
        {
            object ob = SQLStatic.SQL.ExecScaler(
                "select pkg_training.can_access_other_application(" + strUserId + ") from dual", Data.ConnectioString);
            if (ob != null)
                return ob.ToString() == "1";
            else
                return false;
        }

        public static string UsedEmployeeNumber(string strDefaulrEmployeeNumber, string strSessionID)
        {
            string strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID, "FOUND_EMPLOYEE_NUMBER", Data.ConnectioString);
            if (strEmployeeNumber == "")
                return strDefaulrEmployeeNumber;
            else
                return strEmployeeNumber;
        }

        public static string UsedEmployeeNumber2(string strDefaulrEmployeeNumber, string strSessionID)
        {
            string strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID, "APPLICANT_EMPLOYEE_NUMBER", Data.ConnectioString);
            if (strEmployeeNumber == "")
                strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID, "TRN_EMPLOYEE_NUMBER", Data.ConnectioString);
            if (strEmployeeNumber == "")
                return strDefaulrEmployeeNumber;
            else
                return strEmployeeNumber;
            // Maher 4/25/2016
            //string strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID, "TRN_EMPLOYEE_NUMBER", Data.ConnectioString);
            //if (strEmployeeNumber == "")
            //    strEmployeeNumber = SQLStatic.Sessions.GetSessionValue(strSessionID, "APPLICANT_EMPLOYEE_NUMBER", Data.ConnectioString);
            //if (strEmployeeNumber == "")
            //    return strDefaulrEmployeeNumber;
            //else
            //    return strEmployeeNumber;
        }

        public static bool HasPendingEvaluation(string strEmployeeNumber)
        {
            object ob = SQLStatic.SQL.ExecScaler(
                "select pkg_training.has_pending_approval(" + strEmployeeNumber + ") from dual", Data.ConnectioString);
            if (ob != null)
                return ob.ToString() == "1";
            else
                return false;
        }

        public static bool aquiredpreaproval(string strEmployeeNumber, string strProceesingYear)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_training.AquiredPrerequsit(" + strEmployeeNumber + "," + strProceesingYear + ") from dual", Data.ConnectioString).ToString() == "1";
        }

        public static void FillBudgetYears(DropDownList ddl, Label lbl, string strEmployeeNumber, string strDefaultBudgetYear)
        {
            DataTable tbl = null;
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.availablebalanceslist", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_", strEmployeeNumber);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "processing_year_", strDefaultBudgetYear);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "budget_years_list_", "cursor", "out", "");

            DataSet mds = new DataSet();
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(mds);
                tbl = mds.Tables[0];
                ddl.Items.Clear();
                bool blnFound = false;
                lbl.Text = "";
                foreach (DataRow dr in tbl.Rows)
                {
                    ListItem li = new ListItem(dr["budget_year"].ToString(), dr["budget_year"].ToString() + "_" + dr["total_remaining_amount"].ToString());
                    if (li.Text == strDefaultBudgetYear)
                    {
                        li.Selected = true;
                        lbl.Text = FormatedRemainingAmount(li, strEmployeeNumber);
                        blnFound = true;
                    }
                    ddl.Items.Add(li);
                }

                if ((ddl.Items.Count > 0) && (!blnFound))
                {
                    ddl.SelectedIndex = 0;
                    lbl.Text = FormatedRemainingAmount(ddl.Items[0], strEmployeeNumber);
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
                if (li.Text == strProcessingYear)
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
            return BASUSA.MiscTidBit.Launch_Page(Convert.ToDouble(strAmount).ToString("$###,##0.00"),
                  "/web_projects/trn/pla/BudgetDetail.aspx?ee=" + strEmployeeNumber + "&py=" + li.Text, "budget", 600, 500, 10, 10, true, true);
        }

        public static void CheckBudgetForApproval(string strheader_record_id, string strCurseExpense,
             ref string returned_condintion, ref string returned_test)
        {

            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Data.ConnectioString);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_budget.checbudgetbeforeapproval_ee", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "pla_header_record_id_", strheader_record_id);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "course_expense_", strCurseExpense);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "return_condition_", "varchar2", "out", null, 10);
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "return_condition_text_", "varchar2", "out", null, 4000);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                returned_condintion = cmd.Parameters["return_condition_"].Value.ToString();
                if (returned_condintion != "1")
                    returned_test = cmd.Parameters["return_condition_text_"].Value.ToString();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();

            }
        }

        public static bool IsReadOnly(string session_id)
        {
            return SQLStatic.Sessions.GetSessionValue(session_id, "TRN_READONLY", Data.ConnectioString).ToString() == "T";
        }

        public static bool IsSuperUser(string session_id, string user_id, string employee_number)
        {
            bool UserIsSuper = SQLStatic.SQL.ExecScaler("select pkg_training_2.issuperuser(" + user_id + ") from dual", Data.ConnectioString).ToString() != "0";
            string strSelectFoundEE = "";
            if (UserIsSuper)
                strSelectFoundEE = SQLStatic.Sessions.GetSessionValue(session_id, "FOUND_EMPLOYEE_NUMBER", Data.ConnectioString).ToString();
            if (strSelectFoundEE == "")
                return false;
            else
            {
                if (strSelectFoundEE == employee_number)
                    return false;
                else
                    return true;
            }
        }

        public static void DisableAll(System.Web.UI.Control oMe, string strRole_id)
        {
            int cnt = oMe.Controls.Count;
            for (int i = 0; i < cnt; i++)
            {
                if ((oMe.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.TextBox"))
                    ((System.Web.UI.WebControls.TextBox)oMe.Controls[i]).Enabled = false;
                else if ((oMe.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.LinkButton"))
                    ((System.Web.UI.WebControls.LinkButton)oMe.Controls[i]).Enabled = false;
                else if ((oMe.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.DropDownList"))
                    ((System.Web.UI.WebControls.DropDownList)oMe.Controls[i]).Enabled = false;
                else if ((oMe.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.Button"))
                    ((System.Web.UI.WebControls.Button)oMe.Controls[i]).Enabled = false;
                else if ((oMe.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.CheckBoxList"))
                    ((System.Web.UI.WebControls.CheckBoxList)oMe.Controls[i]).Enabled = false;
                else if ((oMe.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.RadioButtonList"))
                    ((System.Web.UI.WebControls.RadioButtonList)oMe.Controls[i]).Enabled = false;
                if (oMe.Controls[i].HasControls())
                {
                    DisableAll(oMe.Controls[i], strRole_id);
                }
            }
        }

        public static void SetValidators(Page wpage)
        {
            RequiredFieldValidator valid = null;
            for (int i = 0; i <= 100; i++)
            {
                valid = (RequiredFieldValidator)wpage.FindControl("RequiredFieldValidator" + i.ToString());
                if (valid != null)
                {
                    valid.ToolTip = valid.ErrorMessage + " Click this link move to field " + valid.ControlToValidate;
                    valid.ErrorMessage = "<a href=\"JavaScript:SetFocus('" + valid.ControlToValidate + "')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>" + valid.ErrorMessage.Replace("ERROR - ", "") + "</u></font></a>";
                }
            }
            RegularExpressionValidator rgValid = null;
            for (int i = 0; i <= 100; i++)
            {
                rgValid = (RegularExpressionValidator)wpage.FindControl("RegularExpressionValidator" + i.ToString());
                if (rgValid != null)
                {
                    rgValid.ToolTip = rgValid.ErrorMessage + " Click this link move to field " + rgValid.ControlToValidate;
                    rgValid.ErrorMessage = "<a href=\"JavaScript:SetFocus('" + rgValid.ControlToValidate + "')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>" + rgValid.ErrorMessage.Replace("ERROR - ", "") + "</u></font></a>";
                }
            }
            CompareValidator compValid = null;
            for (int i = 0; i <= 100; i++)
            {
                compValid = (CompareValidator)wpage.FindControl("CompareValidator" + i.ToString());
                if (compValid != null)
                {
                    compValid.ToolTip = compValid.ErrorMessage + " Click this link move to field " + compValid.ControlToValidate;
                    compValid.ErrorMessage = "<a href=\"JavaScript:SetFocus('" + compValid.ControlToValidate + "')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>" + compValid.ErrorMessage.Replace("ERROR - ", "") + "</u></font></a>";
                }
            }

            RangeValidator RangeValid = null;
            for (int i = 0; i <= 100; i++)
            {
                RangeValid = (RangeValidator)wpage.FindControl("RangeValidator" + i.ToString());
                if (RangeValid != null)
                {
                    RangeValid.ToolTip = RangeValid.ErrorMessage + " Click this link move to field " + RangeValid.ControlToValidate;
                    RangeValid.ErrorMessage = "<a href=\"JavaScript:SetFocus('" + RangeValid.ControlToValidate + "')\"><b><font color=\"#800000\">ERROR</font></b><font color='blue'> - <u>" + RangeValid.ErrorMessage.Replace("ERROR - ", "") + "</u></font></a>";
                }
            }
        }

        public static void RegisterWarning(Page wpage, string strURL)
        {
            string strWarning = "<script>javascript:CheckSave(" + strURL + ")</script>";
            wpage.ClientScript.RegisterStartupScript(wpage.GetType(), "strWarning", strWarning);
        }

        public static string application_Processing_Year(string header_id)
        {
            return SQLStatic.SQL.ExecScaler(
                "select pkg_training_2.application_processing_year(" + header_id + ") from dual", Data.ConnectioString).ToString();
        }

        public static bool PageCompleted(string strUrl, string AllUncompleted)
        {
            if (AllUncompleted == "~")
                return true;
            strUrl = strUrl.ToUpper();
            if ((strUrl.IndexOf("COURSEDATEANDTIME.ASPX") != -1) && (AllUncompleted.IndexOf("~SCH") != -1))
                return false;
            else if ((strUrl.IndexOf("TRAININGTYPEANDNEEDS2008.ASPX") != -1) && (AllUncompleted.IndexOf("~TYP") != -1))
                return false;
            if ((strUrl.IndexOf("TRAININGEXPENSES.ASPX") != -1) && (AllUncompleted.IndexOf("~EXP") != -1))
                return false;
            return true;
        }

        public static string WizardMenuXML(string session_id, string curURL, string header_record_id, ref string retResult)
        {
            bool Use2008 = true;
            if (header_record_id != "-1")
                Use2008 = Data.Use2008Types_Needs(header_record_id);
            StringBuilder sb = new StringBuilder();
            DataTable dt = SQLStatic.Web_Data.Get_Wizard_Data_Table(session_id, ref retResult);
            string strIncomplatePages =
                SQLStatic.SQL.ExecScaler("select pkg_training.incompletepages(" + header_record_id + ")from dual").ToString();
            if (!Use2008)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["url"].ToString().ToUpper() == "/WEB_PROJECTS/TRN/PLA/TRAININGTYPEANDNEEDS2008.ASPX")
                    {
                        dr["url"] = "/WEB_PROJECTS/TRN/PLA/TRAININGTYPESANDNEEDS.ASPX";
                        break;
                    }
                }
                dt.AcceptChanges();
            }
            if (retResult != "")
            {
                return "";
            }
            string strToolTip = "";
            int intWidth;
            string strURL = "";
            string strTitle = "";
            bool ItemOk = false;
            bool OneMore = false;
            foreach (DataRow dr in dt.Rows)
            {
                intWidth = dr["Page_Title"].ToString().Length * 9;
                strURL = dr["url"].ToString();
                strTitle = dr["Page_Title"].ToString();
                strToolTip = "Goto " + dr["Page_Title"].ToString() + " page";

                //				ItemOk = strURL.ToUpper()==curURL.ToUpper();
                //				if (!ItemOk)
                ItemOk = Data.PageCompleted(strURL, strIncomplatePages);
                if (!ItemOk)
                    OneMore = true;
                sb.Append(TemplateMenuXML.MenuXML.Build_Item_Code(strTitle, strToolTip, strURL, intWidth));
                if ((OneMore) || (header_record_id == "-1"))
                    break;
            }
            TemplateMenuXML.MenuXML mXML = new TemplateMenuXML.MenuXML();
            string xml = mXML.XML(sb.ToString(), true, 8);
            mXML = null;
            return xml;
        }

        public static bool Use2008Types_Needs(string header_record_id)
        {
            return SQLStatic.SQL.ExecScaler(
                "select  pkg_training_3.use2008typeneeds(" + header_record_id + ") from dual",
                Data.ConnectioString).ToString() == "1";
        }

        public static string Privacy_Statement(string strEmployeeNumber)
        {
            return SQLStatic.SQL.ExecScaler("select pkg_training_3.privacy_statment(" + strEmployeeNumber + ") from dual").ToString();
        }        
    }
}
