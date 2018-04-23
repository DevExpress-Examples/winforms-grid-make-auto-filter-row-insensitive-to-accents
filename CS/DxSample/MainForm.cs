using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DxSample.Filtering;

namespace DxSample {
    public partial class MainForm : XtraForm {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            DataSet ds = new DataSet();
            ds.ReadXml("nwind.xml");
            DataTable dt = ds.Tables["Customers"];
            var customers = from r in dt.Rows.Cast<DataRow>()
                            let required = new string[] {
                                "ANTON", "BERGS", "BLONP", "BOLID", "COMMI",
                                "FOLKO", "GALED", "GODOS", "HILAA"
                            }
                            where required.Contains((string)r["CustomerID"])
                            select new {
                                CompanyName = (string)r["CompanyName"],
                                ContactName = (string)r["ContactName"],
                                ContactTitle = (string)r["ContactTitle"]
                            };
            this.GridControl.DataSource = customers.ToList();
        }

        private void GridView_SubstituteFilter(object sender, SubstituteFilterEventArgs e) {
            e.Filter = GridFilterSubstitutor.Substitute(e.Filter);
        }
    }
}
