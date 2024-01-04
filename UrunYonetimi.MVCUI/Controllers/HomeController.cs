using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYonetim6584.Entities;
using UrunYonetimi.MVCUI.Models;
using UrunYonetimi6584.BL;

namespace UrunYonetimi.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        Repository<Category> repositoryCategory = new Repository<Category>();
        Repository<Slide> repositorySlider = new Repository<Slide>();
        Repository<Product> repositoryProduct = new Repository<Product>();
        Repository<Contact> repositoryContact = new Repository<Contact>();
        public ActionResult Index()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.Slides = repositorySlider.GetAll();
            homePageViewModel.Products = repositoryProduct.GetAll(p => p.IsActive && p.IsHome);
            return View(homePageViewModel);
        }

        public PartialViewResult PartialMenu()
        {
            return PartialView(repositoryCategory.GetAll(c => c.IsActive));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bize Ulaşın.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryContact.Add(contact);
                    var sonuc = repositoryContact.Save();
                    if (sonuc > 0)
                    {
                        TempData["Message"] = "Mesajınız Gönderildi..";
                        return RedirectToAction("Contact");
                    }
                }
                catch (System.Exception)
                {

                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.Message = "Bize Ulaşın.";

            return View();
        }
    }
}