using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI
{
    public partial class Kategori : System.Web.UI.Page
    {
        CategoryManager manager = new CategoryManager();
        ProductManager ProductManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id != null)
            {
                try
                {
                    int katid = Convert.ToInt32(id);
                    var kayit = manager.GetCategory(katid);
                    kategori.InnerText = kayit.Name;
                    rptUrunler.DataSource = ProductManager.GetAll(p => p.IsActive && p.CategoryId == katid); // Dikkat!! GetAll metodu içerisinde veri tipi dönüşümü yaptırma!!
                    rptUrunler.DataBind();
                }
                catch (Exception)
                {
                    kategori.InnerText = "Hata Oluştu!";
                }
            }
        }
    }
}