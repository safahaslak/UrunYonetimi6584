﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    }
}