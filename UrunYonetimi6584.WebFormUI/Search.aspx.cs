using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI
{
    public partial class Search : System.Web.UI.Page
    {
        ProductManager manager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            var kelime = Request.QueryString["q"]; // q parametresi
            rptUrunler.DataSource = manager.GetAll(p => p.IsActive && p.Name.Contains(kelime) || p.Description.Contains(kelime));
            rptUrunler.DataBind();
        }
    }
}