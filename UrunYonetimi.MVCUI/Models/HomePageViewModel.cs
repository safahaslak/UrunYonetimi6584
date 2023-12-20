using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunYonetim6584.Entities;

namespace UrunYonetimi.MVCUI.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}