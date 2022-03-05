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
    public partial class Product : Form
    {
        private readonly DatabaseContext _db = new DatabaseContext();
        private enum Mode { Default, Add, Edit }
        private Mode _mode;
        private readonly DatabaseContext db;
        private Login login;
        public Product(DatabaseContext db)
        {
            InitializeComponent();
            _db = new DatabaseContext();
            _mode = Mode.Default;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxProduct.Enabled = true;

            var id = _db.Products.OrderByDescending(pr => pr).FirstOrDefault()?.Id[1..];
            textBoxID.Text = id == null ? "P0001" : $"P{(int.Parse(id) + 1):D4}";

            _mode = Mode.Add;

        }

        private void Product_Load(object sender, EventArgs e)
        {
            groupBoxProduct.Enabled = false;

            loadToTable();

            comboBoxSupplier.DataSource = (from supp in _db.Suppliers select supp.Name).ToList();
            comboBoxSupplier.SelectedItem = null;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxProduct.Enabled = true;

            var id = textBoxID.Text = dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString();
            
            var product = _db.Products.Find(id);
            product.Supplier = _db.Suppliers.Find(product.SupplierId);

            textBoxName.Text = product.Name;
            textBoxPrice.Text = product.Price.ToString();
            textBoxStock.Text = product.Stock.ToString();
            comboBoxSupplier.SelectedItem = product.Supplier.Name;

            _mode = Mode.Edit;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!validateData())
                return;
            if (_mode == Mode.Add)
                addToDatabase();
            if (_mode == Mode.Edit)
                editData();
            if (_mode == Mode.Default)
                return;

            groupBoxProduct.Enabled = false;
            buttonAdd.Enabled = buttonEdit.Enabled = true;

            loadToTable();
        }

        private void addToDatabase()
        {
            var produc = new Models.Product
            {
                Id = textBoxID.Text,
                Name = textBoxName.Text,
                Price = int.Parse(textBoxPrice.Text),
                Stock = textBoxStock.Text,
                Supplier = _db.Suppliers.First(sup => sup.Name == comboBoxSupplier.Text)
            };

            _db.Products.Add(produc);
            _db.SaveChanges();
            
        }

        private void clearData()
        {
            textBoxID.Text = textBoxName.Text = textBoxPrice.Text = textBoxStock.Text = string.Empty;
            comboBoxSupplier.SelectedItem = null;
        }

        private void editData()
        {
            var produar = _db.Products.Find(textBoxID.Text);

            produar.Name = textBoxName.Text;
            produar.Price = int.Parse(textBoxPrice.Text);
            produar.Stock = textBoxStock.Text;
            produar.SupplierId = _db.Suppliers.First(sup => sup.Name == comboBoxSupplier.Text).Id;

            _db.Products.Update(produar);
            _db.SaveChanges();
            
    }

        private void loadToTable()
        {
            dataGridViewProduct.DataSource =
                (
                from prod in _db.Products
                join sup in _db.Suppliers
                on prod.SupplierId equals sup.Id
                select new
                {
                    prod.Id,
                    prod.Name,
                    prod.Price,
                    prod.Stock,
                    Supplier = sup.Name
                }
                ).ToList();

        }
        private bool validateData()
        {
            var error = string.Empty;

            if (textBoxName.Text == string.Empty)
                error += "Name can not be empty";
            if (textBoxPrice.Text == string.Empty)
                error += "Price can not be empty";
            else if (!int.TryParse(textBoxPrice.Text, out int price)|| price < 0)
                error += "Price must be positive number";
            if (textBoxStock.Text == string.Empty)
                error += "Stock can not be empty";
            else if (!int.TryParse(textBoxPrice.Text, out int stock) || stock < 0)
                error += "Stock must be positive number";
            if (comboBoxSupplier.SelectedItem == null)
                error += "Select a suppplier";
            if (error != string.Empty) 
            {
                MessageBox.Show(error, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void deleteData(Models.Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            groupBoxProduct.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString();
            var produh = _db.Products.Find(id);
            var confirmation = MessageBox.Show($"Are you sure want to delete {produh.Name} with the ID of {produh.Id}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            deleteData(produh);
            loadToTable();
        }

        private void Product_Leave(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(db, login);
            menu.Show();
        }
    }
}
