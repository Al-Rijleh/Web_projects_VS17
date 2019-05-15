using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Reports
{
	public class rptFDICTraining : ActiveReport
	{
		public rptFDICTraining()
		{
			InitializeReport();
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.OleDBDataSource ds = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Picture Picture = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label lblEeName = null;
		private DataDynamics.ActiveReports.Label lblEeNumber = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label lblSsn = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label lblEePhone = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label lblWebSite = null;
		private DataDynamics.ActiveReports.Label Label24 = null;
		private DataDynamics.ActiveReports.Label Label25 = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label27 = null;
		private DataDynamics.ActiveReports.Label Label28 = null;
		private DataDynamics.ActiveReports.Label Label29 = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
		private DataDynamics.ActiveReports.Label Label31 = null;
		private DataDynamics.ActiveReports.Label Label34 = null;
		private DataDynamics.ActiveReports.Label Label35 = null;
		private DataDynamics.ActiveReports.Label Label36 = null;
		private DataDynamics.ActiveReports.Label Label37 = null;
		private DataDynamics.ActiveReports.Label Label38 = null;
		private DataDynamics.ActiveReports.Label Label39 = null;
		private DataDynamics.ActiveReports.Label Label40 = null;
		private DataDynamics.ActiveReports.Label Label41 = null;
		private DataDynamics.ActiveReports.Label Label42 = null;
		private DataDynamics.ActiveReports.Label Label43 = null;
		private DataDynamics.ActiveReports.Label Label44 = null;
		private DataDynamics.ActiveReports.Label Label45 = null;
		private DataDynamics.ActiveReports.TextBox TextBox7 = null;
		private DataDynamics.ActiveReports.TextBox TextBox8 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label46 = null;
		private DataDynamics.ActiveReports.Label Label47 = null;
		private DataDynamics.ActiveReports.Label Label48 = null;
		private DataDynamics.ActiveReports.Label Label49 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TextBox = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Label Label50 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TextBox6 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Reports.rptFDICTraining.rpx");
			this.ds = ((DataDynamics.ActiveReports.DataSources.OleDBDataSource)(this.DataSource));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.Picture = ((DataDynamics.ActiveReports.Picture)(this.PageHeader.Controls[0]));
			this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.lblEeName = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.lblEeNumber = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lblSsn = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.lblEePhone = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[10]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[20]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[21]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[22]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[23]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[24]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[25]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[26]));
			this.lblWebSite = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[27]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[28]));
			this.Label25 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[29]));
			this.Label26 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[30]));
			this.Label27 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[31]));
			this.Label28 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[32]));
			this.Label29 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[33]));
			this.Label30 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[34]));
			this.Label31 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[35]));
			this.Label34 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[36]));
			this.Label35 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[37]));
			this.Label36 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[38]));
			this.Label37 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[39]));
			this.Label38 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[40]));
			this.Label39 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[41]));
			this.Label40 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[42]));
			this.Label41 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[43]));
			this.Label42 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[44]));
			this.Label43 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[45]));
			this.Label44 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[46]));
			this.Label45 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[47]));
			this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[48]));
			this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[49]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[50]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[51]));
			this.Label46 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
			this.Label47 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
			this.Label48 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
			this.Label49 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[3]));
			this.TextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupFooter1.Controls[0]));
			this.Label50 = ((DataDynamics.ActiveReports.Label)(this.GroupFooter1.Controls[1]));
			this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[2]));
			this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[3]));
			this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[4]));
		}

		#endregion
	}
}
