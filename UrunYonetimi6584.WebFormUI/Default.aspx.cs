using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI
{
    public partial class Default : System.Web.UI.Page
    {
        ProductManager manager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptUrunler.DataSource = manager.GetAll();
            rptUrunler.DataBind();
        }
    }
}