using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetim6584.WinFormUI
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        ProductManager manager = new ProductManager(); // 1. yöntem ProductManager
        Repository<Category> repository = new Repository<Category>(); // 2. yöntem Repository e Product classını yollayarak
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        void DataLoad()
        {
            //dgvUrunler.DataSource = manager.GetAll();  // dgvUrunler i 1.yöntem ile doldur.
            dgvUrunler.DataSource = manager.GetProducts();
            cmbKategoriler.DataSource = repository.GetAll(); // 2. yöntem ile doldur.
            //dgvUrunler.Rows[0].Cells[10]. = false;
            //dgvUrunler.Columns.Remove("Image2");
            //dgvUrunler.Columns.Remove("CategoryId");
            //dgvUrunler.Columns.Remove("Category");
        }
        void Temizle()
        {
            //txtName.Text = string.Empty;
            //txtDescription.Text = "";
            var nesneler = groupBox1.Controls.OfType<TextBox>();  // groupBox1 üzerinden tipi TextBox olan nesneleri bul.
            foreach (var item in nesneler) // bu nesnelerde dön
            {
                item.Clear(); // her nesneyi temizle.
            }
            cbIsActive.Checked = false;
            txtDescription.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Ürün Adı Boş Geçilemez!");
                return;
            }
            var urun = new Product()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Brand = txtBrand.Text,
                IsActive = cbIsActive.Checked,
                Price = Convert.ToDecimal(txtPrice.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CreateDate = DateTime.Now,
                CategoryId = Convert.ToInt32(cmbKategoriler.SelectedValue)
            };
            manager.Add(urun);
            try
            {
                int sonuc = manager.Save();
                if (sonuc > 0)
                {
                    Temizle();
                    DataLoad();
                    btnEkle.Enabled = true;
                    btnGuncelle.Enabled = false;
                    btnSil.Enabled = false;
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
            
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var urun = manager.Find(id);
            txtBrand.Text = urun.Brand;
            txtDescription.Text = urun.Description;
            txtName.Text = urun.Name;
            txtPrice.Text = urun.Price.ToString();
            txtStock.Text = urun.Stock.ToString();
            cbIsActive.Checked = urun.IsActive;
            cmbKategoriler.SelectedValue = urun.CategoryId; // ekrandaki kategorilerden urun kategorisi ile eşleşeni seçili hale getir.
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))  // kategori tablosunun boş bırakılmaması şartı.
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez!");
                return;
            }
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var urun = new Product()
            {
                Id = id,
                Name = txtName.Text,
                Description = txtDescription.Text,
                Brand = txtBrand.Text,
                IsActive = cbIsActive.Checked,
                Price = Convert.ToDecimal(txtPrice.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CategoryId = Convert.ToInt32(cmbKategoriler.SelectedValue),
                CreateDate = Convert.ToDateTime(dgvUrunler.CurrentRow.Cells[6].Value)
                
            };
            manager.Update(urun);
            try
            {
                int sonuc = manager.Save();
                if (sonuc > 0)
                {
                    Temizle();
                    DataLoad();
                    btnEkle.Enabled = true;
                    btnGuncelle.Enabled = false;
                    btnSil.Enabled = false;
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id); 
            manager.Delete(kayit);
            var sonuc = manager.Save();
            if (sonuc > 0)
            {
                Temizle();
                DataLoad();
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                MessageBox.Show("Kayıt Başarılı!");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = manager.GetAll(u => u.Name.Contains(textBox1.Text));
        }
    }
}
