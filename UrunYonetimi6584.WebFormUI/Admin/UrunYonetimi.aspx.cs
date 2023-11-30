﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI.Admin
{
    public partial class UrunYonetimi : System.Web.UI.Page
    {
        ProductManager manager = new ProductManager();
        Repository<Category> repository = new Repository<Category>();
        void DataLoad()
        {
            dgvUrunler.DataSource = manager.GetProducts();
            dgvUrunler.DataBind();
            cmbKategoriler.DataSource = repository.GetAll();
            cmbKategoriler.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // sayfa sunucuya gönderilmemişse
            {
                DataLoad(); // grid i ve kategorileri doldur.
            }   
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Response.Write("<script>alert('Ürün Adı Boş Geçilemez!')</script>");
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
            if (fuImage.HasFile)
            {
                fuImage.SaveAs(Server.MapPath("/Images/" + fuImage.FileName)); // bilgisayardan seçilen dosyayı sunucuya yükle.
                urun.Image = fuImage.FileName; // eklenecek ürünün image özelliğine seçilen dosya adını ata.
            }
            manager.Add(urun);
            try
            {
                int sonuc = manager.Save();
                if (sonuc > 0)
                {
                    Response.Redirect("UrunYonetimi.aspx");
                }
            }
            catch (Exception hata)
            {

                Response.Write("Hata Oluştu!" + hata.Message);
            }
        }

        protected void dgvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
            var urun = manager.Find(id);
            txtBrand.Text = urun.Brand;
            txtDescription.Text = urun.Description;
            txtName.Text = urun.Name;
            txtPrice.Text = urun.Price.ToString();
            txtStock.Text = urun.Stock.ToString();
            cbIsActive.Checked = urun.IsActive;
            cmbKategoriler.SelectedValue = urun.CategoryId.ToString(); // ekrandaki kategorilerden urun kategorisi ile eşleşeni seçili hale getir.
            Image1.ImageUrl = "/Images/" + urun.Image;
            Image1.Height = 78;
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))  // kategori tablosunun boş bırakılmaması şartı.
            {
                Response.Write("<script>alert('Ürün Adı Boş Geçilemez!')</script>");
                return;
            }
            var id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
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
                CreateDate = Convert.ToDateTime(dgvUrunler.SelectedRow.Cells[7].Text)

            };
            if (fuImage.HasFile)
            {
                fuImage.SaveAs(Server.MapPath("/Images/" + fuImage.FileName)); // bilgisayardan seçilen dosyayı sunucuya yükle.
                urun.Image = fuImage.FileName; // eklenecek ürünün image özelliğine seçilen dosya adını ata.
            }
            manager.Update(urun);
            try
            {
                int sonuc = manager.Save();
                if (sonuc > 0)
                {
                    
                    Response.Redirect("UrunYonetimi.aspx");
                }
            }
            catch (Exception hata)
            {

                Response.Write("Hata Oluştu!" + hata.Message);
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);
            manager.Delete(kayit);
            var sonuc = manager.Save();
            if (sonuc > 0)
            {
                Response.Redirect("UrunYonetimi.aspx");
            }
        }
    }
}