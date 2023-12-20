using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi.MVCUI.Controllers
{
    public class ProductsController : Controller
    {
        Repository<Product> repositoryProduct = new Repository<Product>();
        // GET: Products
        public ActionResult Index()
        {
            return View(repositoryProduct.GetAll(p => p.IsActive));
        }
        public ActionResult Detail(int id)
        {
            var model = repositoryProduct.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}