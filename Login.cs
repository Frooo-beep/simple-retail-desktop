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
    public partial class Login : Form
    {
        private readonly DatabaseContext db;
        private Login login;
        public string getUser;
        public Login()
        {
            InitializeComponent();
            db = new DatabaseContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Email == tbEmail.Text && e.Password == tbPassword.Text);

            if (employee == null)
            {
                MessageBox.Show("Account Not Found", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (employee.Password != tbPassword.Text)
            {
                MessageBox.Show("Inc  orrect Password", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var menu = new Menu(db, login);

            menu.Show();
            this.Hide();
        }
    }
}
