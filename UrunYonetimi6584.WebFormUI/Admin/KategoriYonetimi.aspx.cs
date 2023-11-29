using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI.Admin
{
    public partial class KategoriYonetimi : System.Web.UI.Page
    {
        CategoryManager manager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = manager.GetCategories();
            dgvKategoriler.DataBind(); // web de bu metodu çağırmazsak ekrana veri yüklenmiyor!
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            var kategori = new Category()
            {
                CreateDate = DateTime.Now,
                Description = txtDescription.Text,
                IsActive = cbIsActive.Checked,
                Name = txtName.Text
            };
            manager.Add(kategori);
            var sonuc = manager.Save();
            if (sonuc > 0)
            {
                Response.Redirect("KategoriYonetimi.aspx");
            }

        }

        protected void dgvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvKategoriler.SelectedRow.Cells[1].Text);
            var kategori = manager.GetCategory(id);
            txtName.Text = kategori.Name;
            txtDescription.Text = kategori.Description;
            cbIsActive.Checked = kategori.IsActive;
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))  // kategori tablosunun boş bırakılmaması şartı.
            {
                Response.Write("<script>alert('Kategori Adı Boş Geçilemez!')</script>");
                return;
            }
            var id = Convert.ToInt32(dgvKategoriler.SelectedRow.Cells[1].Text);
            var eklenmeTarihi = Convert.ToDateTime(dgvKategoriler.SelectedRow.Cells[5].Text);
            var kategori = new Category()
            {
                Id = id,
                CreateDate = eklenmeTarihi,
                Description = txtDescription.Text,
                IsActive = cbIsActive.Checked,
                Name = txtName.Text
            };
            manager.Update(kategori);   
            var sonuc = manager.Save();
            if (sonuc > 0)
            {
                Response.Write("Kayıt Güncelleme Başarılı!");
                Response.Redirect("KategoriYonetimi.aspx");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvKategoriler.SelectedRow.Cells[1].Text);
            var kategori = manager.GetCategory(id);
            manager.Delete(kategori);
            var sonuc = manager.Save();
            if (sonuc > 0)
            {
               Response.Write("Kayıt Silme Başarılı!");
               Response.Redirect("KategoriYonetimi.aspx");
            }
        }
    }
}