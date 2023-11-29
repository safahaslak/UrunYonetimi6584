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

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}