﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi6584.WebFormUI
{
    public partial class Default : System.Web.UI.Page
    {
        ProductManager manager = new ProductManager();
        Repository<Slide> repository = new Repository<Slide>();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptUrunler.DataSource = manager.GetAll(p=>p.IsActive && p.IsHome);
            rptUrunler.DataBind();

            rptSlider.DataSource = repository.GetAll();
            rptSlider.DataBind();
        }
    }
}