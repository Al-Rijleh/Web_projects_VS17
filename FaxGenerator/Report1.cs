namespace FaxGenerator
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class Report1 : Telerik.Reporting.Report
    {
        public Report1()
        {
            //
            // Required for telerik Reporting designer support
            //
            //InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public void Process(string session_,string reta)
        {
            InitializeComponent();
            string dep = SQLStatic.Sessions.GetSessionValue(session_, "dep");
            string account_number = SQLStatic.Sessions.GetAccountNumber(session_);

            ArrayList aldoc = new ArrayList(3);
            account_number = account_number.Substring(0, 7) + "-0000-000";
            aldoc.Add(SQLStatic.StoredProcedure.OneParamerer("account_number_", "in", "varchar2", account_number));
            aldoc.Add(SQLStatic.StoredProcedure.OneParamerer("code_", "in", "number", "560"));
            string reqdoc = SQLStatic.StoredProcedure.ExecuteFunction("pkg_enrollment_wizard_setup.Get_er_property_accnt", "varchar2", aldoc).ToString();
            if (reqdoc.Equals("1"))
                textBox3.Value = "Dependent Requires Documentation(s)";

            DataTable tbl = null;
            if (reta.Equals("0"))
            {
                ArrayList al = new ArrayList(2);
                al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", dep));
                al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
                tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_Dependents_Audit.faxverifyreportinformation", al);
            }
            else if (reta.Equals("2"))
            {
                textBox3.Value = "New Dependent Verification of Eligibility";
                ArrayList al = new ArrayList(2);
                al.Add(SQLStatic.StoredProcedure.OneParamerer("dependent_sequence_no_", "in", "varchar2", dep));
                al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
                tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependent_audit_wizard.faxverifyinformation", al);
            }
            else
            {
                textBox3.Value = "New Dependent Verification of Eligibility";
                ArrayList al = new ArrayList(2);
                al.Add(SQLStatic.StoredProcedure.OneParamerer("request_recird_id_", "in", "varchar2", dep));
                al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
                tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_dependent_audit_wizard.faxverifyreportinformation", al);
            }
            this.DataSource = tbl;

        }
    }
}