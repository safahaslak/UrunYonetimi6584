using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI.Admin
{
    public partial class KullaniciYonetimi : System.Web.UI.Page
    {
        Repository<User> repository = new Repository<User>(); // Repository üzerinden veritabanı işlemleri yapabilmek için önce bunu tanımlıyoruz.
        void Yukle()
        {
            dgvKullanicilar.DataSource = repository.GetAll();
            dgvKullanicilar.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Yukle();
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Response.Write("Ad Alanı Boş Geçilemez!");
                return;
            }
            var kullanici = new User()
            {
                CreateDate = DateTime.Now,
                Email = txtEmail.Text,
                IsActive = cbIsActive.Checked,
                IsAdmin = cbIsAdmin.Checked,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text,
                Username = txtUserName.Text
            };
            repository.Add(kullanici);
            try
            {
                var sonuc = repository.Save();
                if (sonuc > 0)
                {
                    Response.Redirect("KullaniciYonetimi.aspx");
                }
            }
            catch (Exception)
            {

                Response.Write("Hata Oluştu!");
            }
        }

        protected void dgvKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
            var kullanici = repository.Find(id);
            txtEmail.Text = kullanici.Email;
            txtName.Text = kullanici.Name;
            txtPassword.Text = kullanici.Password;
            txtPhone.Text = kullanici.Phone;
            txtSurname.Text = kullanici.Surname;
            txtUserName.Text = kullanici.Name;
            cbIsActive.Checked = kullanici.IsActive;
            cbIsAdmin.Checked = kullanici.IsAdmin;
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Response.Write("Ad Alanı Boş Geçilemez!");
                return;
            }
            var id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);

            var kullanici = new User()
            {
                Id = id,
                CreateDate = DateTime.Now,
                Email = txtEmail.Text,
                IsActive = cbIsActive.Checked,
                IsAdmin = cbIsAdmin.Checked,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text,
                Username = txtUserName.Text
            };
            repository.Update(kullanici);
            try
            {
                var sonuc = repository.Save();
                if (sonuc > 0)
                {
                    Response.Redirect("KullaniciYonetimi.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("Hata Oluştu!");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
            var kullanici = repository.Find(id);
            repository.Delete(kullanici);
            try
            {
                var sonuc = repository.Save();
                if (sonuc > 0)
                {
                    Response.Redirect("KullaniciYonetimi.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("Hata Oluştu!");
            }
        }
    }
}