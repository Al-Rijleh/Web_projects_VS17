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
	/// Summary description for TrainingAnswers.
	/// </summary>
	public class TrainingAnswers : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lbl_fldInstructionForTriningCourseTrainingAnswer;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblSSN;
		protected System.Web.UI.WebControls.Label lblPhone;
		protected System.Web.UI.WebControls.Label lblOffice;
		protected System.Web.UI.WebControls.Label lblTitleCourse;
		protected System.Web.UI.WebControls.Label lblStartDate;
		protected System.Web.UI.WebControls.Label lblEndDate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.DataGrid dgQA;
		protected System.Web.UI.WebControls.ListBox lbAnweres;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Image imgPLA;
		protected System.Web.UI.WebControls.Image imgOther;
		protected System.Web.UI.WebControls.Label lblScript;
        protected System.Web.UI.WebControls.TextBox txtComments;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblScript.Text = "";
			lblError.Text = "";
			lblError.Visible = false;
			if (!IsPostBack)
			{
				lbAnweres.Width=System.Web.UI.WebControls.Unit.Pixel(1);
				lbAnweres.Height=System.Web.UI.WebControls.Unit.Pixel(1);
				lbAnweres.ForeColor = System.Drawing.Color.White;
				lbAnweres.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
				string stridParam0=TransferedParam(Request.Params[0]);
				int intpos = stridParam0.IndexOf("_");
				ViewState["Request_Record_ID"] =  stridParam0.Substring(intpos+1);
				ViewState["Record_ID"]= stridParam0.Substring(0,intpos);
				CanAccess();
				ViewState["Employee_Number"]=Training_Source.TrainingClass.EmployeeNumberFromRecordID(ViewState["Request_Record_ID"].ToString());								
				FillData();
				GetCDAnswerList();
			}		
			if (Request.Cookies["Session_ID"] != null)
				if (Training_Source.TrainingClass.IsReadOnly(Request.Cookies["Session_ID"].Value.ToString()))
				{
					btnSave.Enabled = false;
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
			this.dgQA.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgQA_ItemCreated);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		

		private string TransferedParam(string stridParam0)
		{
			string strSQL= "select pkg_trn_fdic.get_trnsfered_completed_id('"+stridParam0+"') from dual";
			return SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
		}

		private void CanAccess()
		{
			string strSQL="select pkg_trn_fdic.canaccessevaluation("+ViewState["Record_ID"].ToString()+","+ViewState["Request_Record_ID"].ToString()+") from dual";
			string strResult = SQLStatic.SQL.ExecScaler(strSQL,Training_Source.TrainingClass.ConnectioString).ToString();
			if (strResult=="1")
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Unknown Application"+"&backurl=0" ,true);
			else if (strResult=="2")
				Response.Redirect("/Web_Projects/trn/PLA/out.aspx?message=Evaluation already completed"+"&backurl=0" ,true);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if ((Request.Params["call"]==null)||(Request.Params["call"].ToString()==""))
				lblScript.Text = "<script>window.location.href='http://www.myenroll.com'</script>";
			else
				lblScript.Text = "<script>window.location.href='"+Request.Params["call"].ToString()+"'</script>";
//				Response.Redirect(Request.Params["call"])

		}

		private void FillData()
		{
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.evaluation_form_header_info",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_number_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_name_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "employee_ssn_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "telephone_no_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "division_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "title_of_course_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "start_date_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "completion_date_","varchar2","out","");
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "Type_of_Training_","varchar2","out","");			
			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
				ViewState["Employee_Number"]= cmd.Parameters["employee_number_"].Value.ToString();
				lblName.Text = cmd.Parameters["employee_name_"].Value.ToString();
				lblSSN.Text = cmd.Parameters["employee_ssn_"].Value.ToString();
				lblPhone.Text = cmd.Parameters["telephone_no_"].Value.ToString();
				lblOffice.Text = cmd.Parameters["division_"].Value.ToString();
				lblTitleCourse.Text = cmd.Parameters["title_of_course_"].Value.ToString();
				lblStartDate.Text = cmd.Parameters["start_date_"].Value.ToString();
				lblEndDate.Text = cmd.Parameters["completion_date_"].Value.ToString();
				if (cmd.Parameters["Type_of_Training_"].Value.ToString()=="5632")
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
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.get_evaluation_questions",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "questions_list_","cursor","out","");
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

		private void FillRadioButtonList(RadioButtonList opnlst)
		{
			foreach (ListItem li in lbAnweres.Items)
			{
				ListItem li2 = new ListItem(li.Text,li.Value);
				opnlst.Items.Add(li2);
			}
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
					// create Option List
					RadioButtonList opnlst = new RadioButtonList();
					opnlst.CssClass="fontsmall";					
					opnlst.ID = "opn_"+strindex;
					opnlst.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
					FillRadioButtonList(opnlst);
					opnlst.Enabled = btnSave.Enabled;
					TableCell cell = e.Item.Cells[2];
					cell.Controls.Add(opnlst);					
				}
				catch
				{
				}
			}
		}

		private RadioButtonList Getopnlst(Control oMe,string txtName)
		{
			int cnt = oMe.Controls.Count;
			RadioButtonList opnlst = null;
			for(int i=0; i<cnt; i++)
			{
				string s =oMe.Controls[i].GetType().ToString();				
				if ((oMe.Controls[i].GetType().ToString()==
					"System.Web.UI.WebControls.RadioButtonList"))
				{					
					opnlst =(RadioButtonList)oMe.Controls[i];					
					if ((opnlst.ID == txtName))
					{
						s = opnlst.SelectedValue;
						break;
					}
					else
						opnlst = null;
				}
				else 
					if (oMe.Controls[i].HasControls())
				{
					opnlst = Getopnlst(oMe.Controls[i],txtName);
					if (opnlst != null)
						break;
				}
			}
			return opnlst;
		}

		private bool DataIsOK()
		{
			bool blnDataIsOk = true;
			DataTable tbl = (DataTable) dgQA.DataSource;
			RadioButtonList opnlst;
			string strID;
			foreach(DataRow dr in tbl.Rows)
			{
				strID = "opn_"+dr["record_id"].ToString();
				opnlst = Getopnlst(this,strID);
				if (opnlst.SelectedIndex==-1)
				{
					blnDataIsOk = false;
					break;
				}
				opnlst=null;
			}
			return blnDataIsOk;
		}

		private void SaveOne(Oracle.DataAccess.Client.OracleConnection conn,string strQuestionID, string strAnswerId)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.save_ee_evaluation_answer",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_",ViewState["Request_Record_ID"].ToString());
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "question_id_",strQuestionID);
			SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "answer_id_",strAnswerId);
			try
			{
				cmd.ExecuteNonQuery();				
			}
			finally
			{				
				cmd.Dispose();				
			}
		}

		private void SaveFinalizeEvaluation(Oracle.DataAccess.Client.OracleConnection conn)
		{
			Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("BASDBA.pkg_trn_fdic.Finalize_Evaluation",conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.CommandTimeout = 30;
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "header_record_id_", ViewState["Request_Record_ID"].ToString());
            SQLStatic.ProcedureParameters.SetStoredProcedureParameter(cmd, "comments_", txtComments.Text);
			try
			{
				cmd.ExecuteNonQuery();				
			}
			finally
			{				
				cmd.Dispose();				
			}
		}

		private bool DoSave()
		{
			bool blnSaved = true;
			DataTable tbl = (DataTable) dgQA.DataSource;
			RadioButtonList opnlst;
			string strID;
			Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(Training_Source.TrainingClass.ConnectioString);
			conn.Open();
			Oracle.DataAccess.Client.OracleTransaction txn = conn.BeginTransaction();
			try
			{
				foreach(DataRow dr in tbl.Rows)
				{
					strID = "opn_"+dr["record_id"].ToString();
					opnlst = Getopnlst(this,strID);
					SaveOne(conn,dr["record_id"].ToString(),opnlst.SelectedValue);
					opnlst=null;
				}
				SaveFinalizeEvaluation(conn);
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

		return blnSaved;
	}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!DataIsOK())
			{
				lblError.Text="All questions must be answered";
				lblError.Visible=true;
			}
			else
			{
				if (DoSave())
				{
					string UrlTo="";
					if ((Request.Params["call"]==null)||(Request.Params["call"].ToString()==""))
						UrlTo = "http://www.myenroll.com";
					else
						UrlTo = Request.Params["call"].ToString();
						
					lblScript.Text ="<script>ConfirmaSave();window.location.href ='"+UrlTo+"'</script>";
				}
			}
		}
	


	}
}
