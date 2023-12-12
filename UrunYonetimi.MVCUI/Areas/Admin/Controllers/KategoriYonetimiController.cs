using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi.MVCUI.Areas.Admin.Controllers
{
    public class KategoriYonetimiController : Controller
    {
        CategoryManager manager = new CategoryManager();
        // GET: Admin/KategoriYonetimi
        public ActionResult Index()
        {
            var model = manager.GetCategories();
            return View(model); // içi dolu kategori listesini parantez içerisinde sayfaya yolluyoruz.
        }

        // GET: Admin/KategoriYonetimi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KategoriYonetimi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KategoriYonetimi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KategoriYonetimi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/KategoriYonetimi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KategoriYonetimi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/KategoriYonetimi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
