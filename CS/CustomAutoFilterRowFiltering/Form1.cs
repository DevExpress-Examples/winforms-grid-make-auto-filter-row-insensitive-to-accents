using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CustomAutoFilterRowFiltering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myGridView1.OptionsView.ShowAutoFilterRow = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            

        }
    }
}
