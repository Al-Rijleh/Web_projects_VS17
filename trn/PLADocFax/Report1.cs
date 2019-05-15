namespace PLADocFax
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Collections;

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
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public void Process(string strID)
        {
            InitializeComponent();
            ArrayList al = new ArrayList(2);
            al.Add(SQLStatic.StoredProcedure.OneParamerer("record_id_", "in", "varchar2", strID));
            al.Add(SQLStatic.StoredProcedure.OneParamerer("retresult_", "out", "cursor", null));
            DataTable tbl = SQLStatic.StoredProcedure.ExecuteTableProcedure("pkg_training.faxinformation", al);
            //pictureBox3.Value = "http://fx2007.ciban.com/imgbc.aspx?bs=6&bd=" + tbl.Rows[0]["header_id"].ToString();
            this.DataSource = tbl;
        }
    }
}