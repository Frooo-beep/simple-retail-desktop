using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplerRetail
{
    public partial class ExportData : Form
    {
        public ExportData()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog browsePath = new OpenFileDialog();
            browsePath.Title = "Open path";
            browsePath.Filter = "CSV file|*.csv";

            if (browsePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(browsePath.FileName);
                textBoxPath.Text = browsePath.FileName;
            }

        }
    }
}
