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
    public partial class NewTransaction : Form
    {
        public static int count = 1;
        private readonly DatabaseContext _db;
        private BrowseProducts _browseForm;
        private readonly Dictionary<string, TransactionData> _transactions;
        public NewTransaction(DatabaseContext db, BrowseProducts browse)
        {
            InitializeComponent();

            _db = db;
            _browseForm = browse;
            _transactions = new Dictionary<string, TransactionData>();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            _browseForm = (BrowseProducts)
            Menu.loadForm(_browseForm, new BrowseProducts(_db, _transactions)
            {
                selectProduct = (id, stock) =>
                {
                    textBoxProductID.Text = id;
                    numericUpDownQty.Maximum = stock;
                    Focus();
                }
            });
        }

        private void NewTransaction_Load(object sender, EventArgs e)
        {
            LoadTransaction();

            dataGridView1.Columns[0].HeaderText = "ProductID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Price";
        }

        private void LoadTransaction()
        {
            dataGridView1.DataSource =
                (
                from tran in _transactions
                select new
                {
                    tran.Key,
                    tran.Value.ProductName,
                    tran.Value.ProductPrice,
                    tran.Value.Qty,
                    Subtotal = tran.Value.ProductPrice * tran.Value.Qty
                }
                ).ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var product = _db.Products.Find(textBoxProductID.Text);

            AddTransaction(product);
            LoadTransaction();
        }

        private void AddTransaction(Models.Product prot)
        {
            var quan = (int)numericUpDownQty.Value;

            if (quan == 0)
                return;

            if (_transactions.ContainsKey(prot.Id))
            {
                var addedProduct = _transactions[prot.Id];
                var currentStock = int.Parse(prot.Stock) - addedProduct.Qty;

                if (quan > currentStock) quan = currentStock;

                addedProduct.Qty += quan;
                CountTotalPrice(quan * prot.Price);
                return;
            }

            if (quan > int.Parse(prot.Stock))
                quan = int.Parse(prot.Stock);

            _transactions.Add(prot.Id, new TransactionData()
            {
                ProductName = prot.Name,
                ProductPrice = prot.Price,
                Qty = quan
            });

            CountTotalPrice(prot.Price * quan);
        }

        private void CountTotalPrice(int price)
        {
            var currentPrice = labelPrice.Text;
            labelPrice.Text = (currentPrice + price).ToString();
        }

        private bool ValidateTransactions()
        {
            if (_transactions.Count == 0)
            {
                MessageBox.Show("Quantity can not be zero");
                return false;
            }

            return true;
        }

        private void ClearData()
        {
            
        }

        private void ButtonCheckout_Click(object sender, EventArgs e)
        {
            if (!ValidateTransactions())
                return;

            
            Close();
        }

        public void TotalTransaction()
        {
            if (ValidateTransactions())
                count++;
        }
    }
}
