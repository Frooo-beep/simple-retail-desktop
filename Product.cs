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
        private readonly DatabaseContext _db = new DatabaseContext();//database context yg ada di models
        private enum Mode { Default, Add, Edit }//mode  untuk memudahkan 
        private Mode _mode;//mode
        private readonly DatabaseContext db;
        private Login login;
        
        public Product(DatabaseContext db)
        {
            InitializeComponent();
            _db = new DatabaseContext();
            _mode = Mode.Default;//defaultnya default
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxProduct.Enabled = true;

            var id = _db.Products.OrderByDescending(pr => pr).FirstOrDefault()?.Id[1..];//varisabel id yg di urutkan diambil yg terakhir lalu diurutkan
            textBoxID.Text = id == null ? "P0001" : $"P{(int.Parse(id) + 1):D4}";
            //jika blm ada id maka id defaultnya P0001 jika sudah ada, maka selanjutnya P0001 + 1 = P0002, angka yg berubah sesuai D4 yaitu setelah objek ke 4 pada id

            _mode = Mode.Add;//modenya jadi mode add

        }

        private void Product_Load(object sender, EventArgs e)
        {
            groupBoxProduct.Enabled = false;

            loadToTable();

            comboBoxSupplier.DataSource = (from supp in _db.Suppliers select supp.Name).ToList();
            //data di combobox diambil dari supplier lalu ditampilkan ke dalam list
            comboBoxSupplier.SelectedItem = null;
            //default value combo box = null
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = buttonEdit.Enabled = false;
            groupBoxProduct.Enabled = true;

            var id = textBoxID.Text = dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString();
            //id yang dipilih dari tabel di masukkan ke dalam textbox dalam bentuk string
            
            var product = _db.Products.Find(id);//variabel id berisi id dari produk
            product.Supplier = _db.Suppliers.Find(product.SupplierId);//ambil id supplier

            textBoxName.Text = product.Name;//setiap textbox memiliki value dari tabel yang di klik sesuai nama textboxnya
            textBoxPrice.Text = product.Price.ToString();
            textBoxStock.Text = product.Stock.ToString();
            comboBoxSupplier.SelectedItem = product.Supplier.Name;

            _mode = Mode.Edit;//mode edit
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!validateData())//jika data tidak valid
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

        private void addToDatabase()//tambah data ke database
        {
            var produc = new Models.Product//buat variabel dari database PRODUCT 
            {
                // yg di kiri itu nama kolom yg setelah sama dengan itu nama textbox dan inputanya
                Id = textBoxID.Text,
                Name = textBoxName.Text,
                Price = int.Parse(textBoxPrice.Text),
                Stock = textBoxStock.Text,
                Supplier = _db.Suppliers.First(sup => sup.Name == comboBoxSupplier.Text)
                //khusus nama supplier harus diambil dari database supplier dan dimunculkan namanya dlalm bentuk string
            };

            _db.Products.Add(produc);//meminta ijin ke database product untuk menambahkan varibel produc ke dlamnya
            _db.SaveChanges();//simpan perubahan
            
        }

        private void clearData()
        {
            textBoxID.Text = textBoxName.Text = textBoxPrice.Text = textBoxStock.Text = string.Empty;//dikosongkan
            comboBoxSupplier.SelectedItem = null;//dijadikan default
        }

        private void editData()
        {
            var produar = _db.Products.Find(textBoxID.Text);//variabel produar mewakili id dari tiap produk
            
            //yg kiri nama kolom yg setelah sama dengan itu inputan dan datanya
            produar.Name = textBoxName.Text;
            produar.Price = int.Parse(textBoxPrice.Text);
            produar.Stock = textBoxStock.Text;
            produar.SupplierId = _db.Suppliers.First(sup => sup.Name == comboBoxSupplier.Text).Id;
            //supplier diambil dari databaenya lalu dimunculkan namanya dalam bentuk string

            _db.Products.Update(produar);//meminta izin ke Products untuk update data yg ada menjadi variabel produar
            _db.SaveChanges();//simpan
            
    }

        private void loadToTable()
        {
            dataGridViewProduct.DataSource =//nama grid vuew tujuan
                (
                from prod in _db.Products/// from nama variabel1 in variabel dataase.Nama database1
                join sup in _db.Suppliers// (ambil data dari tabel lain) from variabel2 in variabel database.nama database2 
                on prod.SupplierId equals sup.Id// on variable1.data yg diambil dari database2 equals variabel2.data yg diambil 
                select new//ambil data terbaru
                {
                    //variable1.data yg diambil ari database1
                    prod.Id,
                    prod.Name,
                    prod.Price,
                    prod.Stock,
                    Supplier = sup.Name//kolom supplier diambill dari variabel2.data yg diambil
                }
                ).ToList();//dimunculkan ke dalam tabel dalam bentuk urutan

        }
        private bool validateData()
        {
            var error = string.Empty;//variabel error adalah string yang kososng

            if (textBoxName.Text == string.Empty)
                error += "Name can not be empty";
            if (textBoxPrice.Text == string.Empty)
                error += "Price can not be empty";
            else if (!int.TryParse(textBoxPrice.Text, out int price)|| price < 0)//jika harga tidak berupa angka dan memiliki nilai kurang dari 0
                error += "Price must be positive number";//muncul pesan error
            if (textBoxStock.Text == string.Empty)
                error += "Stock can not be empty";
            else if (!int.TryParse(textBoxPrice.Text, out int stock) || stock < 0)
                error += "Stock must be positive number";
            if (comboBoxSupplier.SelectedItem == null)//jika combobox tidak memilih apapun maka 
                error += "Select a suppplier";//muncul pesan error
            if (error != string.Empty) //jika error selain karena string yang kososng maka
            {
                MessageBox.Show(error, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);//muncul pesan error
                return false;//tidak di kembalikan
            }
            return true;//dikembalikan ke if pertama
        }

        private void deleteData(Models.Product product)//parameter produk
        {
            _db.Products.Remove(product);//menghapus data pada _db.products
            _db.SaveChanges();//simpan
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            groupBoxProduct.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString();//variabel id berisi kolom yang di pilih sesuai barisanya
            var produh = _db.Products.Find(id);//variabel produh mewakili id pada produk yg di pilih
            var confirmation = MessageBox.Show($"Are you sure want to delete {produh.Name} with the ID of {produh.Id}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //variabel confirmation berisi pesan konfirmasi untuk menghapus data dari database

            if (confirmation == DialogResult.No)//jika pada confirmation di klik NO maka tidak jadi dihapus
                return;

            deleteData(produh);//hapus seluruh data pada variabel produh
            loadToTable();//tamplikan ke tabel
        }

        private void Product_Leave(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(db, login);
            menu.Show();
        }
    }
}
