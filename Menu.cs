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
    public partial class Menu : Form
    {
        private Login _login;
        private Product _product;
        private Supplier _suplier;
        private Employee _employee;
        private NewTransaction _newTrans;
        private BrowseProducts _browse;

        private readonly DatabaseContext _db;

        public Menu(DatabaseContext db, Login login)
        {
            InitializeComponent();
            _db = db;
            _login = login;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        public static Form loadForm(Form form, Form anotherForm)
        {
            if (form == null || form.IsDisposed)
            {
                form = anotherForm;
                form.Show();
            }
            if (!form.Focused)
            {
                form.Focus();
            }
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            return form;
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mLogout_Click(object sender, EventArgs e)
        {
            _login.Show();
            this.Close();
        }

        private void mProduct_Click(object sender, EventArgs e)
        {
            loadForm(_product, new Product(_db));
        }

        private void mSupplier_Click(object sender, EventArgs e)
        {
            loadForm(_suplier, new Supplier(_db));
        }

        private void mEmployee_Click(object sender, EventArgs e)
        {
            loadForm(_employee, new Employee(_db));
        }

        private void mExportData_Click(object sender, EventArgs e)
        {
            ExportData exp = new ExportData();
            exp.Show();
        }

        private void mNewTransaction_Click(object sender, EventArgs e)
        {
            loadForm(_newTrans, new NewTransaction(_db, _browse));
        }

        private void mDaily_Click(object sender, EventArgs e)
        {
            DailyReport daily = new DailyReport();
            daily.Show();
        }
    }
}
