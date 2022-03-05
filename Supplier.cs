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
    public partial class Supplier : Form
    {
        private readonly DatabaseContext _db = new DatabaseContext();
        private enum Mode { Default, Add, Edit }
        private Mode _mode;
        private readonly DatabaseContext db;
        private Login login;
        public Supplier(DatabaseContext db)
        {
            InitializeComponent();
            _db = new DatabaseContext();
            _mode = Mode.Default;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxSupplier.Enabled = true;

            var id = _db.Suppliers.OrderByDescending(pr => pr).FirstOrDefault()?.Id[1..];
            textBoxID.Text = id == null ? "S0001" : $"S{(int.Parse(id) + 1):D4}";

            _mode = Mode.Add;

        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            groupBoxSupplier.Enabled = false;

            loadToTable();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxSupplier.Enabled = true;

            var id = textBoxID.Text = dataGridViewSupplier.SelectedRows[0].Cells[0].Value.ToString();
            var supplier = _db.Suppliers.Find(id);
            textBoxName.Text = supplier.Name;

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

            groupBoxSupplier.Enabled = false;
            buttonAdd.Enabled = buttonEdit.Enabled = true;

            loadToTable();
        }

        private void addToDatabase()
        {
            var suples = new Models.Supplier
            {
                Id = textBoxID.Text,
                Name = textBoxName.Text
            };

            _db.Suppliers.Add(suples);
            _db.SaveChanges();

        }

        private void clearData()
        {
            textBoxID.Text = textBoxName.Text = string.Empty;
        }

        private void editData()
        {
            var supply = _db.Suppliers.Find(textBoxID.Text);

            supply.Name = textBoxName.Text;

            _db.Suppliers.Update(supply);
            _db.SaveChanges();

        }

        private void loadToTable()
        {
            dataGridViewSupplier.DataSource =
                (
                from supy in _db.Suppliers
                select new
                {
                    supy.Id,
                    supy.Name
                }
                ).ToList();

        }
        private bool validateData()
        {
            var error = string.Empty;

            if (textBoxName.Text == string.Empty)
                error += "Name can not be empty";
            if (error != string.Empty)
            {
                MessageBox.Show(error, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void deleteData(Models.Supplier supreh)
        {
            _db.Suppliers.Remove(supreh);
            _db.SaveChanges();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            groupBoxSupplier.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = dataGridViewSupplier.SelectedRows[0].Cells[0].Value.ToString();
            var suplai = _db.Suppliers.Find(id);
            var confirmation = MessageBox.Show($"Are you sure want to delete {suplai.Name} with the ID of {suplai.Id}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            deleteData(suplai);
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
