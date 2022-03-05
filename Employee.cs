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
    public partial class Employee : Form
    {
        private readonly DatabaseContext _db = new DatabaseContext();
        private enum Mode { Default, Add, Edit }
        private Mode _mode;
        private readonly DatabaseContext db;
        private Login login;
        public Employee(DatabaseContext db)
        {
            InitializeComponent();
            _db = new DatabaseContext();
            _mode = Mode.Default;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxEmployee.Enabled = true;

            var id = _db.Employees.OrderByDescending(pr => pr).FirstOrDefault()?.Id[1..];
            textBoxID.Text = id == null ? "E0001" : $"P{(int.Parse(id) + 1):D4}";

            _mode = Mode.Add;

        }

        private void Product_Load(object sender, EventArgs e)
        {
            groupBoxEmployee.Enabled = false;

            loadToTable();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxEmployee.Enabled = true;

            var id = textBoxID.Text = dataGridViewEmployee.SelectedRows[0].Cells[0].Value.ToString();
            var implu = _db.Employees.Find(id);

            textBoxName.Text = implu.Name;
            textBoxEmail.Text = implu.Email;
            textBoxPhone.Text = implu.Phone;
            textBoxPassword.Text = implu.Password;

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

            groupBoxEmployee.Enabled = false;
            buttonAdd.Enabled = buttonEdit.Enabled = true;

            loadToTable();
        }

        private void addToDatabase()
        {
            var emplo = new Models.Employee
            {
                Id = textBoxID.Text,
                Name = textBoxName.Text,
                Email = textBoxEmail.Text,
                Phone = textBoxPhone.Text,
                Password = textBoxPassword.Text
            };

            _db.Employees.Add(emplo);
            _db.SaveChanges();

        }

        private void clearData()
        {
            textBoxID.Text = textBoxName.Text = textBoxPhone.Text = textBoxPassword.Text = string.Empty;
            
        }

        private void editData()
        {
            var employ = _db.Employees.Find(textBoxID.Text);

            employ.Name = textBoxName.Text;
            employ.Email = textBoxEmail.Text;
            employ.Phone = textBoxPhone.Text;
            employ.Password = textBoxPassword.Text;

            _db.Employees.Update(employ);
            _db.SaveChanges();

        }

        private void loadToTable()
        {
            dataGridViewEmployee.DataSource =
                (
                from emp in _db.Employees
                select new
                {
                    emp.Id,
                    emp.Name,
                    emp.Email,
                    emp.Phone,
                    emp.Password
                }
                ).ToList();

        }
        private bool validateData()
        {
            var error = string.Empty;

            if (textBoxName.Text == string.Empty)
                error += "Name can not be empty";
            if (textBoxEmail.Text == string.Empty)
                error += "Email can not be empty";
            if (textBoxPhone.Text == string.Empty)
                error += "Phone can not be empty";
            else if (!int.TryParse(textBoxPhone.Text, out int stock) || stock < 0)
                error += "Phone must be positive number";
            if (textBoxPassword.Text == String.Empty)
                error += "Add some password";
            if (error != string.Empty)
            {
                MessageBox.Show(error, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void deleteData(Models.Employee ploy)
        {
            _db.Employees.Remove(ploy);
            _db.SaveChanges();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            groupBoxEmployee.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = dataGridViewEmployee.SelectedRows[0].Cells[0].Value.ToString();
            var ploo = _db.Employees.Find(id);
            var confirmation = MessageBox.Show($"Are you sure want to delete {ploo.Name} with the ID of {ploo.Id}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            deleteData(ploo);
            loadToTable();
        }

        private void Employee_Leave(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(db, login);
            menu.Show();
        }
    }
}
