using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplerRetail.Models;

namespace SimplerRetail
{
    public partial class BrowseProducts : Form
    {
        private readonly DatabaseContext _db;
        private readonly Dictionary<string, TransactionData> _transactions;
        public Action<string, int> selectProduct { private get; set; }
        public BrowseProducts(DatabaseContext db, Dictionary<string, TransactionData> transactions)
        {
            InitializeComponent();
            _db = db;
            _transactions = transactions;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            var id = dataGridViewBrowseProducts.SelectedRows[0].Cells[0].Value.ToString();
            var stock = (int)dataGridViewBrowseProducts.SelectedRows[0].Cells[3].Value;

            selectProduct(id, stock);
            Close();
        }

        private void BrowseProducts_Load(object sender, EventArgs e)
        {
            dataGridViewBrowseProducts.DataSource =
                (
                from pro in _db.Products
                select new
                {
                    pro.Id,
                    pro.Name,
                    pro.Price,
                    Stock = int.Parse(pro.Stock) - (_transactions.ContainsKey(pro.Id) ? _transactions[pro.Id].Qty : 0),
                }
                ).ToList();

        }
    }
}
