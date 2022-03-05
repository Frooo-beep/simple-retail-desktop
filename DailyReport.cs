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
    public partial class DailyReport : Form
    {
        private readonly DatabaseContext _db;
        public DailyReport()
        {
            InitializeComponent();
        }

        private void DailyReport_Load(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("MM-dd-yyyy");
            var transCount = _db.Transactions.Where(t => t.Date == date).Count();
            var transProduct = (
                from transactionProduct in _db.TransactionProducts
                join transaction in _db.Transactions
                on transactionProduct.TransactionProductId equals transaction.Id
                where (transaction.Date == date)
                select new
                {
                    transactionProduct.Qty,
                    transactionProduct.Price
                }
                ).ToList();

            labelDateValue.Text = date;
            labelToTrans.Text = transCount.ToString();

        }
    }
}
