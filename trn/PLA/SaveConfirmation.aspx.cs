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
	/// Summary description for SaveConfirmation.
	/// </summary>
	public class SaveConfirmation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblAmount;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.DataGrid dgExpense;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.TextBox txtPurposeOfTainingOther;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList ddlPurposeOfTraining;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.DropDownList ddlSourseTraining;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.RadioButtonList optMandatoryTraining;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.DropDownList ddlTrainingType;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursTotal;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursNonDuty;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtCourseHoursDuty;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.RadioButtonList optCoursrTime;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtDescribtion;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtWebSite;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtZipCode;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtAddressLine2;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtAddressLine1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtVedorName;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCourseTitle;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCourseCode;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label lblBalance;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblCourseTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDivision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblEmployeeInfo;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Build_Fields();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ReadField(TextBox txt)
		{
//			txt.Text=SQLStatic.Sessions.GetSessionValue(Request.Cookies["Session_ID"].Value.ToString(),txt.ID,Training_Source.TrainingClass.ConnectioString);
			txt.Text = Request.Params[txt.ID];
	}

		private void Build_Fields()
		{
//			ReadField(txtCode);
			ReadField(txtAddressLine1);
			ReadField(txtAddressLine2);
			ReadField(txtCity);
			ReadField(txtCourseCode);
			ReadField(txtCourseHoursNonDuty);
			ReadField(txtCourseHoursNonDuty);
			ReadField(txtCourseHoursTotal);
			ReadField(txtCourseTitle);
			ReadField(txtDescribtion);
			ReadField(txtEndDate);
			ReadField(txtFaxNumber);
			ReadField(txtPhoneNumber);
			ReadField(txtPurposeOfTainingOther);
			ReadField(txtStartDate);
			ReadField(txtVedorName);
			ReadField(txtWebSite);
			ReadField(txtZipCode);
		}
	}
}
