using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI
{
    public partial class Onyuz : System.Web.UI.MasterPage
    {
        CategoryManager manager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptKategoriler.DataSource = manager.GetCategories();
            rptKategoriler.DataBind();
        }
    }
}